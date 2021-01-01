using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class GameMode : ToggleAbstract
    {
        public GameMode()
        {
            Name = "Disable Windows GameMode - Windows 10 build 15019+";
            Descripton = "Checked: Active, Unchecked : Inactive, inactive is recommended!";
            RegistrySet = Registry.CurrentUser;
            RegKey = "SOFTWARE\\Microsoft\\GameBar\\";
            Value = "AllowAutoGameMode";
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
