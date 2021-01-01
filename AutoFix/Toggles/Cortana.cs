using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class Cortana : ToggleAbstract
    {
        public Cortana()
        {
            Name = "Toggle Cortana";
            Descripton = "Checked: Active, Unchecked: Inactive, Toggle Cortana in windows 10";
            RegistrySet = Registry.LocalMachine;
            RegKey = "Software\\Policies\\Microsoft\\Windows\\Windows Search\\";
            Value = "AllowCortana";
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
