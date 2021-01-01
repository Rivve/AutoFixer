namespace AutoFixer.UninstallsApp
{
    class BingSport : UninstallAppAbstract
    {
        public BingSport()
        {
            DisplayName = "Sports";
            Descripton = "Uninstall preinstalled Sports app";
            ProgramName = "bingsports";
            Installed = IsInstalled();
        }
    }
}
