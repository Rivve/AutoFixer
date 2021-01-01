namespace AutoFixer.UninstallsApp
{
    class News : UninstallAppAbstract
    {
        public News()
        {
            DisplayName = "News";
            Descripton = "Uninstall preinstalled News app";
            ProgramName = "bingnews";
            Installed = IsInstalled();
        }
    }
}
