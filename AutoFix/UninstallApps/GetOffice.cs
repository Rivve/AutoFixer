namespace AutoFixer.UninstallsApp
{
    class GetOffice : UninstallAppAbstract
    {
        public GetOffice()
        {
            DisplayName = "Get Office";
            Descripton = "Uninstall preinstalled 'Get Office' app";
            ProgramName = "officehub";
            Installed = IsInstalled();
        }
    }
}
