using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class VolumeMixer : ToggleAbstract
    {
        public VolumeMixer()
        {
            Name = "Old Volume mixer";
            Descripton = "Change to the old windows Volume mixer";
            RegistrySet = Registry.LocalMachine;
            RegKey = "Software\\Microsoft\\Windows NT\\CurrentVersion\\MTCUVC\\";
            Value = "EnableMtcUvc";
            ValueKind = RegistryValueKind.DWord;
            CheckValue = 0;
            UncheckValue = null;
            ReturnMessage = null;

            if (Utils.IsWindows10(0)) DefaultValue = false;
            else Unavailable = true;

            Active = StartValue = CheckStartValue();
        }
    }
}
