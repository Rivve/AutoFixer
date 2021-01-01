using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class LockScreen : ToggleAbstract
    {
        public LockScreen()
        {
            Name = "Toggle LockScreen";
            Descripton = "Checked: Active, Unchecked: Inactive, Toggle Pointless Lock Screen before logging in";
            RegistrySet = Registry.LocalMachine;
            RegKey = "Software\\Policies\\Microsoft\\Windows\\Personalization\\";
            Value = "NoLockScreen";
            ValueKind = RegistryValueKind.DWord;
            CheckValue = 1;
            UncheckValue = 0;
            ReturnMessage = "Requires a restart to take affect...";

            if (Utils.IsWindows10(0)) DefaultValue = true;
            else Unavailable = true;

            Active = StartValue = CheckStartValue();
        }
    }
}
