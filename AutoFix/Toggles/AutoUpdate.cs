using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class AutoUpdate : ToggleAbstract
    {
        public AutoUpdate()
        {
            Name = "Notify Windows Updates";
            Descripton = "Checked: Notify for windows updates & installs but manually install , Unchecked: Auto update & install window updates";
            RegistrySet = Registry.LocalMachine;
            RegKey = "Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\";
            Value = "AUOptions";
            ValueKind = RegistryValueKind.DWord;
            CheckValue = 2;
            UncheckValue = 5;
            ReturnMessage = "Requires a restart / log out&in to take affect...";
            DefaultValue = false;

            Active = StartValue = CheckStartValue();
        }
    }
}
