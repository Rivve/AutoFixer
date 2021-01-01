using AutoFixer.Actions;
using AutoFixer.Toggles;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFixer
{
    class RunModes
    {
        /// <summary>
        /// Run simple mode and close program after user clicked reboot "yes / no"
        /// </summary>
        public static void RunAutoMode()
        {
            List<ExecuteAbstract> actions = new List<ExecuteAbstract>()
            {
                new MemoryLeak(),
                new XboxDVR(),
                new UpdateShare(),
                new HighPerformance(),
                new DisableSuperFetch(),
                new DisableWindowsSearch()
            };

            //Check so the computer even supports the function with help of Windows build
            for (int i = actions.Count - 1; i >= 0; --i)
                if (actions[i].Unavailable)
                    actions.Remove(actions[i]);

            foreach (ExecuteAbstract action in actions)
            {
                Task task = Task.Factory.StartNew(() => action.ExecuteAction());
                Task.WaitAll(task);
            }

            GameBar gb = new GameBar();
            if (!gb.Unavailable) //Check so the computer even supports the function with help of Windows build
                if (gb.Active)
                    gb.DoToggle();

            GameMode gm = new GameMode();
            if (!gm.Unavailable) //Check so the computer even supports the function with help of Windows build
                if (gm.Active)
                    gm.DoToggle();

            DialogResult dialog = MessageBox.Show("Your hardware settings have changed. \nPlease reboot your computer for these changes to take effect!", "Restart now?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) Restart();
        }

        /// <summary>
        /// Reset the settings the program changes with the auto mode/actions incase someone gets problems with the tool.
        /// Except power plan setting and the memory leak
        /// </summary>
        public static void ResetSettings()
        {
            try
            {
                //start all the services again
                Process.Start("sc.exe", "config SysMain start=auto");
                Process.Start("sc.exe", "start SysMain");
                Process.Start("sc.exe", "config WSearch start=auto");
                Process.Start("sc.exe", "start WSearch");
                Process.Start("sc.exe", "config DiagTrack start=auto");
                Process.Start("sc.exe", "start DiagTrack");
                Process.Start("sc.exe", "config dmwappushservice start=auto");
                Process.Start("sc.exe", "start dmwappushservice");

                //change all the registry settings
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", "AllowTelemetry ", 1, RegistryValueKind.DWord); // basic
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization", "DODownloadMode", 3, RegistryValueKind.DWord); // internet peering again
                if (Utils.IsWindows10(0))
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\System\\GameConfigStore", "GameDVR_Enabled", 1, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", "AllowGameDVR", 1, RegistryValueKind.DWord);
                }
                if (Utils.IsWindows10(15019))
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\GameDVR", "AppCaptureEnabled", 1, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "AllowAutoGameMode", 1, RegistryValueKind.DWord);
                }
            }
            catch (Exception) { }


            DialogResult dialog = MessageBox.Show("Your hardware settings have changed. \nPlease reboot your computer for these changes to take effect!", "Restart now?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) Restart();


        }

        /// <summary>
        /// Restart the users computer if the user pressed yes in a dialog
        /// </summary>
        private static void Restart()
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.FileName = "cmd";
            proc.Arguments = "/C shutdown -f -r";
            Process.Start(proc);
            Application.Exit();
        }
    }
}
