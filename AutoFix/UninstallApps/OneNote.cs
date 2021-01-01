namespace AutoFixer.UninstallsApp
{
    class OneNote : UninstallAppAbstract
    {
        public OneNote()
        {
            DisplayName = "OneNote";
            Descripton = "Uninstall preinstalled OneNote app";
            ProgramName = "onenote";
            Installed = IsInstalled();
        }
    }
}
