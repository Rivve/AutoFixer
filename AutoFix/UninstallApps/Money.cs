namespace AutoFixer.UninstallsApp
{
    class Money : UninstallAppAbstract
    {
        public Money()
        {
            DisplayName = "Money";
            Descripton = "Uninstall preinstalled Money app";
            ProgramName = "bingfinance";
            Installed = IsInstalled();
        }
    }
}
