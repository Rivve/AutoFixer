using Microsoft.Win32;
using System.Diagnostics;

namespace AutoFixer.Actions
{
    class DisableWindowsCollection : ExecuteAbstract
    {

        const string DATACOLLECTION = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection";

        public DisableWindowsCollection()
        {
            this.Name = "Disable Windows Collection";
            this.Desc = "Disables all of the Windows Collection SERVICES! Check the privacy settings yourself.";
            if (!Utils.IsWindows10(0)) Unavailable = true;
        }

        public override void ExecuteAction()
        {
            Process.Start("sc.exe", "config DiagTrack start=disabled");
            Process.Start("sc.exe", "stop DiagTrack");

            Process.Start("sc.exe", "config dmwappushservice start=disabled");
            Process.Start("sc.exe", "stop dmwappushservice");

            Registry.SetValue(DATACOLLECTION, "AllowTelemetry ", 0, RegistryValueKind.DWord);
        }
    }
}
