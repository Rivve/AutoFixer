using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class ClockSeconds : ToggleAbstract
    {
        public ClockSeconds()
        {
            Name = "Show Seconds in taskbar clock";
            Descripton = "Sets the clock in explorer/taskbar to shows seconds";
            RegistrySet = Registry.CurrentUser;
            RegKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\";
            Value = "ShowSecondsInSystemClock";
            ValueKind = RegistryValueKind.DWord;
            CheckValue = 1;
            UncheckValue = 0;
            ReturnMessage = "Requires a restart / log out&in to take affect...";
            DefaultValue = false;
            RestartExplorer = true;

            Active = StartValue = CheckStartValue();
        }
    }
}
