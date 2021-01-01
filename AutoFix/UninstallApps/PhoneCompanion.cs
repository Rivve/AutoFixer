namespace AutoFixer.UninstallsApp
{
    class PhoneCompanion : UninstallAppAbstract
    {
        public PhoneCompanion()
        {
            DisplayName = "Phone Companion";
            Descripton = "Uninstall preinstalled Phone Companion app";
            ProgramName = "windowsphone";
            Installed = IsInstalled();
        }
    }
}
