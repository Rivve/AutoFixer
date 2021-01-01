namespace AutoFixer.UninstallsApp
{
    class Photos : UninstallAppAbstract
    {
        public Photos()
        {
            DisplayName = "Photos";
            Descripton = "Uninstall preinstalled Photos app";
            ProgramName = "photos";
            Installed = IsInstalled();
        }
    }
}
