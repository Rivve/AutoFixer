using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class DisableUac : ToggleAbstract
    {
        public DisableUac()
        {
            Name = "Disable UAC";
            Descripton = "Disable User Access Control";
            RegistrySet = Registry.LocalMachine;
            RegKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\";
            Value = "EnableLUA";
            ValueKind = RegistryValueKind.DWord;
            CheckValue = 1;
            UncheckValue = 0;
            ReturnMessage = "Requires a restart to take affect...";

            if (Utils.IsWindows10(0)) DefaultValue = false;
            else Unavailable = true;

            Active = StartValue = CheckStartValue();
        }
    }
}
