using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class GameBar : ToggleAbstract
    {
        public GameBar()
        {
            Name = "Windows GameBar - Windows 10 build 15019+";
            Descripton = "Checked: Active, Unchecked: Inactive, Inactive is recommended, XBOX DVR off is also required.";
            RegistrySet = Registry.CurrentUser;
            RegKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\GameDVR\\";
            Value = "AppCaptureEnabled";
            ValueKind = RegistryValueKind.DWord;
            CheckValue = 1;
            UncheckValue = 0;
            ReturnMessage = "Requires a restart to take affect...";

            if (Utils.IsWindows10(15019)) DefaultValue = true;
            else Unavailable = true;

            Active = StartValue = CheckStartValue();
        }
    }
}
