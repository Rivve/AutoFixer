using Microsoft.Win32;

namespace AutoFixer.Actions
{
    class XboxDVR : ExecuteAbstract
    {
        const string USERXBOXDVR = "HKEY_CURRENT_USER\\System\\GameConfigStore";
        const string MACHINEXBOXDVR = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR";

        public XboxDVR()
        {
            this.Name = "Disable Xbox DVR";
            this.Desc = "Disable Windows Xbox DVR through registry";
            if (!Utils.IsWindows10(0)) Unavailable = true;
        }

        public override void ExecuteAction()
        {
            Registry.SetValue(USERXBOXDVR, "GameDVR_Enabled", 0, RegistryValueKind.DWord);
            Registry.SetValue(MACHINEXBOXDVR, "AllowGameDVR", 0, RegistryValueKind.DWord);
            AutoFixer.reqRestart = true;
        }
    }
}
