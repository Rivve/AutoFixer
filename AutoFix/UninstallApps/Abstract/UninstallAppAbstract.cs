using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Windows.Forms;

namespace AutoFixer.UninstallsApp
{
    abstract class UninstallAppAbstract
    {
        /// <summary>
        /// Variables for view
        /// </summary>
        public String DisplayName { get; set; }
        public String Descripton { get; set; }

        [Browsable(false)]
        public String ProgramName { get; set; }
        [Browsable(false)]
        public bool Installed { get; set; }

        public bool IsInstalled()
        {
            return Utils.RunScript("Get-AppxPackage *" + ProgramName + "*").IndexOf(ProgramName, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public bool UninstallProgram()
        {
            if (Installed)
            {
                Utils.RunScript("Get-AppxPackage *" + ProgramName + "* | Remove-AppxPackage");
                Installed = false;
                return true;
            }
            return false;
        }
    }
}
