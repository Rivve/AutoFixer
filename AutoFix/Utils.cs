using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Windows.Forms;

namespace AutoFixer
{
    class Utils
    {

        /// <summary>
        /// Check if the system is running windows 10 and at a certain build
        /// </summary>
        /// <param name="AboveBuildNumber">which build we are looking for</param>
        /// <returns>True or false (Build>CompBuild)</returns>
        public static bool IsWindows10(Int32 AboveBuildNumber)
        {
            try
            {
                var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
                string productName = (string)reg.GetValue("ProductName");

                bool result = productName.StartsWith("Windows 10");
                int build = 0;

                if (result)
                    build = Int32.Parse((string)reg.GetValue("CurrentBuild"));

                return result && (build >= AboveBuildNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Restart the users computer if the user pressed yes in a dialog
        /// </summary>
        public static void Restart()
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.FileName = "cmd";
            proc.Arguments = "/C shutdown -f -r";
            Process.Start(proc);

            Application.Exit();
        }

        private static Runspace runspace = null;
        /// <summary>
        /// Run script and return the result as a string
        /// </summary>
        /// <param name="scriptText">Which command we shall send to the powershell</param>
        /// <returns>The string output due to the command we sent in.</returns>
        public static string RunScript(string scriptText)
        {
            if (runspace == null)
            {
                runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();
            }

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
            pipeline.Commands.Add("Out-String");

            Collection<PSObject> results = pipeline.Invoke();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (PSObject obj in results)
                stringBuilder.AppendLine(obj.ToString());

            return stringBuilder.ToString();
        }

    }
}
