using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Silk_Client
{
    public partial class SettingsWindow : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private Color selectedColor = Color.Teal;
        private bool classicTheme;

        public SettingsWindow()
        {
            InitializeComponent();
            ColorButton.Click += ColorButton_Click;
            ThemeButton.Click += ThemeButton_Click;
            TitlePanel.MouseDown += TitlePanel_MouseDown;
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            Silk? silkForm = Owner as Silk;
            if (silkForm != null)
            {
                selectedColor = silkForm.UiColor;
                classicTheme = silkForm.IsClassicTheme;
            }

            ApplySettingsWindowTheme();
            UpdateThemeButtonText();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            using ColorDialog colorDialog = new ColorDialog
            {
                Color = selectedColor,
                FullOpen = true
            };

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
                ApplySettings();
            }
        }

        private void ThemeButton_Click(object sender, EventArgs e)
        {
            classicTheme = !classicTheme;
            ApplySettings();
            UpdateThemeButtonText();
        }

        private void ApplySettings()
        {
            (Owner as Silk)?.ApplyUiSettings(selectedColor, classicTheme);
            ApplySettingsWindowTheme();
        }

        private void ApplySettingsWindowTheme()
        {
            ForeColor = selectedColor;
            ColorButton.ForeColor = selectedColor;
            ColorButton.BackColor = BackColor;
            ThemeButton.ForeColor = selectedColor;
            ThemeButton.BackColor = BackColor;
            ThemeLabel.ForeColor = selectedColor;
            ColorLabel.ForeColor = selectedColor;
            SaveSettingsButton.ForeColor = selectedColor;
            TitleMirror.ForeColor = selectedColor;
            CloseButton.ForeColor = selectedColor;
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void UpdateThemeButtonText()
        {
            ThemeButton.Text = $"Theme: {(classicTheme ? "Classic" : "Modern")}";
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Silk SilkForm = (Silk)Application.OpenForms["Silk"];

            using SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CFG files (*.cfg)|*.cfg|All files (*.*)|*.*",
                DefaultExt = "cfg",
                AddExtension = true,
                Title = "Save Configuration File",
                RestoreDirectory = true,
                AutoUpgradeEnabled = false
            };

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(saveFileDialog.FileName, new[]
                    {
                        $"Application={SilkForm.ApplicationTextbox.Text}",
                        $"Activity={SilkForm.ActivityComboBox.SelectedItem?.ToString() ?? "Playing"}",
                        $"Details={SilkForm.DetailsTextbox.Text}",
                        $"State={SilkForm.StateTextbox.Text}",
                        $"Large={SilkForm.LargeTextbox.Text}",
                        $"LargeText={SilkForm.LargeTextTextbox.Text}",
                        $"Small={SilkForm.SmallTextbox.Text}",
                        $"SmallText={SilkForm.SmallTextTextbox.Text}",
                        $"Color={SilkForm.UiColor.ToArgb()}",
                        $"Theme={(SilkForm.IsClassicTheme ? "Classic" : "Modern")}"
                    });

                    MessageBox.Show("Config saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error while saving configuration:\n\n{ex.Message}",
                        "Save Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
