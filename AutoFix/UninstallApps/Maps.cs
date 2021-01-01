namespace AutoFixer.UninstallsApp
{
    class Maps : UninstallAppAbstract
    {
        public Maps()
        {
            DisplayName = "Maps";
            Descripton = "Uninstall preinstalled Maps app";
            ProgramName = "windowsmaps";
            Installed = IsInstalled();
        }
    }
}
