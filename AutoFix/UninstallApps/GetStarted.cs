namespace AutoFixer.UninstallsApp
{
    class GetStarted : UninstallAppAbstract
    {
        public GetStarted()
        {
            DisplayName = "Get Started";
            Descripton = "Uninstall preinstalled 'Get Started' app";
            ProgramName = "getstarted";
            Installed = IsInstalled();
        }
    }
}
