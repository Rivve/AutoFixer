namespace AutoFixer.UninstallsApp
{
    class People : UninstallAppAbstract
    {
        public People()
        {
            DisplayName = "People";
            Descripton = "Uninstall preinstalled People app";
            ProgramName = "people";
            Installed = IsInstalled();
        }
    }
}
