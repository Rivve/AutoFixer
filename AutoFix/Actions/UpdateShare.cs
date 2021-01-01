using Microsoft.Win32;

namespace AutoFixer.Actions
{
    class UpdateShare : ExecuteAbstract
    {
        const string WINDOWSUPDATESHARE = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization";

        public UpdateShare()
        {
            this.Name = "Disable Update share";
            this.Desc = "Disable windows update share completly through registry";
            if (!Utils.IsWindows10(0)) Unavailable = true;
        }

        public override void ExecuteAction()
        {
            Registry.SetValue(WINDOWSUPDATESHARE, "DODownloadMode", 0, RegistryValueKind.DWord);
            AutoFixer.reqRestart = true;
        }
    }
}
