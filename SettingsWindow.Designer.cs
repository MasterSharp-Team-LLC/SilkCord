namespace Silk_Client
{
    partial class SettingsWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TitlePanel = new Panel();
            TitleMirror = new Label();
            CloseButton = new Button();
            ColorButton = new Button();
            ThemeLabel = new Label();
            ThemeButton = new Button();
            ColorLabel = new Label();
            SaveSettingsButton = new Button();
            TitlePanel.SuspendLayout();
            SuspendLayout();
            // 
            // TitlePanel
            // 
            TitlePanel.BackColor = Color.FromArgb(33, 33, 33);
            TitlePanel.Controls.Add(TitleMirror);
            TitlePanel.Controls.Add(CloseButton);
            TitlePanel.Location = new Point(0, 0);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(418, 40);
            TitlePanel.TabIndex = 0;
            // 
            // TitleMirror
            // 
            TitleMirror.AutoSize = true;
            TitleMirror.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleMirror.ForeColor = Color.Teal;
            TitleMirror.Location = new Point(11, 11);
            TitleMirror.Name = "TitleMirror";
            TitleMirror.Size = new Size(89, 18);
            TitleMirror.TabIndex = 14;
            TitleMirror.Text = "SILKCORD";
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(33, 33, 33);
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseButton.ForeColor = Color.Teal;
            CloseButton.Location = new Point(378, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(40, 40);
            CloseButton.TabIndex = 12;
            CloseButton.Text = "X";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // ColorButton
            // 
            ColorButton.FlatStyle = FlatStyle.Flat;
            ColorButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ColorButton.ForeColor = Color.Teal;
            ColorButton.Location = new Point(131, 119);
            ColorButton.Name = "ColorButton";
            ColorButton.Size = new Size(241, 36);
            ColorButton.TabIndex = 21;
            ColorButton.Text = "Change Color";
            ColorButton.UseVisualStyleBackColor = true;
            // 
            // ThemeLabel
            // 
            ThemeLabel.AutoSize = true;
            ThemeLabel.BackColor = Color.Transparent;
            ThemeLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ThemeLabel.ForeColor = Color.Teal;
            ThemeLabel.Location = new Point(38, 64);
            ThemeLabel.Name = "ThemeLabel";
            ThemeLabel.Size = new Size(81, 30);
            ThemeLabel.TabIndex = 22;
            ThemeLabel.Text = "Theme:";
            // 
            // ThemeButton
            // 
            ThemeButton.FlatStyle = FlatStyle.Flat;
            ThemeButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ThemeButton.ForeColor = Color.Teal;
            ThemeButton.Location = new Point(131, 62);
            ThemeButton.Name = "ThemeButton";
            ThemeButton.Size = new Size(241, 36);
            ThemeButton.TabIndex = 23;
            ThemeButton.Text = "Theme: Modern";
            ThemeButton.UseVisualStyleBackColor = true;
            // 
            // ColorLabel
            // 
            ColorLabel.AutoSize = true;
            ColorLabel.BackColor = Color.Transparent;
            ColorLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ColorLabel.ForeColor = Color.Teal;
            ColorLabel.Location = new Point(52, 121);
            ColorLabel.Name = "ColorLabel";
            ColorLabel.Size = new Size(67, 30);
            ColorLabel.TabIndex = 24;
            ColorLabel.Text = "Color:";
            // 
            // SaveSettingsButton
            // 
            SaveSettingsButton.FlatStyle = FlatStyle.Flat;
            SaveSettingsButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveSettingsButton.ForeColor = Color.Teal;
            SaveSettingsButton.Location = new Point(12, 492);
            SaveSettingsButton.Name = "SaveSettingsButton";
            SaveSettingsButton.Size = new Size(394, 36);
            SaveSettingsButton.TabIndex = 25;
            SaveSettingsButton.Text = "Save Settings";
            SaveSettingsButton.UseVisualStyleBackColor = true;
            SaveSettingsButton.Click += SaveSettingsButton_Click;
            // 
            // SettingsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(418, 540);
            Controls.Add(SaveSettingsButton);
            Controls.Add(ColorLabel);
            Controls.Add(ThemeButton);
            Controls.Add(ThemeLabel);
            Controls.Add(ColorButton);
            Controls.Add(TitlePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsWindow";
            ShowIcon = false;
            Load += SettingsWindow_Load;
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel TitlePanel;
        private Label TitleMirror;
        private Button MinimizeButton;
        private Button CloseButton;
        private Button ColorButton;
        private Label ThemeLabel;
        private Button ThemeButton;
        private Label ColorLabel;
        private Button SaveSettingsButton;
    }
}
