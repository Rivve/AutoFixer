namespace AutoFixer.UninstallsApp
{
    class GetSkype : UninstallAppAbstract
    {
        public GetSkype()
        {
            DisplayName = "Get Skype";
            Descripton = "Uninstall preinstalled 'Get Skype' app";
            ProgramName = "skypeapp";
            Installed = IsInstalled();
        }
    }
}
