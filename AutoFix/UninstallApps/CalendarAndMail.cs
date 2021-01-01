namespace AutoFixer.UninstallsApp
{
    class CalendarAndMail : UninstallAppAbstract
    {
        public CalendarAndMail()
        {
            DisplayName = "Calendar and Mail";
            Descripton = "Uninstall preinstalled Calendar and E-post app";
            ProgramName = "windowscommunicationsapps";
            Installed = IsInstalled();
        }
    }
}
