namespace AutoFixer.UninstallsApp
{
    class MoviesAndTV : UninstallAppAbstract
    {
        public MoviesAndTV()
        {
            DisplayName = "Movies & TV";
            Descripton = "Uninstall preinstalled Movies & TV app";
            ProgramName = "zunevideo";
            Installed = IsInstalled();
        }
    }
}
