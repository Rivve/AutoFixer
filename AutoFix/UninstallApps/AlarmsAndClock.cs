namespace AutoFixer.UninstallsApp
{
    class AlarmsAndClock : UninstallAppAbstract
    {
        public AlarmsAndClock()
        {
            DisplayName = "Alarms and Clock";
            Descripton = "Uninstall preinstalled Alarms and Clock app";
            ProgramName = "windowsalarms";
            Installed = IsInstalled();
        }
    }
}
