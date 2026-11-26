using System.Diagnostics;

namespace Silk_Client
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            Console.Title = "SilkCord";
            Process? discordProcess = null;
            bool waitingMessageShown = false;

            while (discordProcess == null)
            {
                Process[] processes = Process.GetProcessesByName("Discord");

                if (processes.Length > 0)
                {
                    discordProcess = processes[0];

                    Console.WriteLine($"\nDiscord detected: Discord.exe | PID: {discordProcess.Id}");
                    Console.WriteLine("Press any key to continue...");

                    Console.ReadKey();

                    break;
                }

                if (!waitingMessageShown)
                {
                    Console.WriteLine("No Discord found. Open Discord and try again.");
                    waitingMessageShown = true;
                }

                await Task.Delay(3000);
            }

            Console.Clear();
            Console.WriteLine("Connected");

            ApplicationConfiguration.Initialize();
            Application.Run(new Silk());
        }

        internal static bool HasDiscordProcess()
        {
            return Process.GetProcessesByName("Discord").Length > 0 ||
                   Process.GetProcessesByName("DiscordPTB").Length > 0 ||
                   Process.GetProcessesByName("DiscordCanary").Length > 0;
        }
    }
}