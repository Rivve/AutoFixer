namespace AutoFixer.UninstallsApp
{
    class XboxApp : UninstallAppAbstract
    {
        public XboxApp()
        {
            DisplayName = "Xbox App";
            Descripton = "Uninstall all programs associated with the Xbox App";
            ProgramName = "xboxapp";
            Installed = IsInstalled();
        }
    }
}
