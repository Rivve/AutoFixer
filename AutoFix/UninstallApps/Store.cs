namespace AutoFixer.UninstallsApp
{
    class Store : UninstallAppAbstract
    {
        public Store()
        {
            DisplayName = "Windows Store";
            Descripton = "Uninstall preinstalled Store app";
            ProgramName = "windowsstore";
            Installed = IsInstalled();
        }
    }
}
