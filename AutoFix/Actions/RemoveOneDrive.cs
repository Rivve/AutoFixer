using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace AutoFixer.Actions
{
    class RemoveOneDrive : ExecuteAbstract
    {

        public RemoveOneDrive()
        {
            this.Name = "Remove OneDrive";
            this.Desc = "Completely removes and uninstalls OneDrive";
            if (!Utils.IsWindows10(0)) Unavailable = true;
        }

        public override void ExecuteAction()
        {
            Process objProcess = new Process();
            objProcess.StartInfo.FileName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\remove-onedrive.bat";
            try
            {
                objProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
