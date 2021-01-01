namespace AutoFixer.UninstallsApp
{
    class SolitaireCollection : UninstallAppAbstract
    {
        public SolitaireCollection()
        {
            DisplayName = "Microsoft Solitaire Collection";
            Descripton = "Uninstall preinstalled Microsoft Solitaire Collection app";
            ProgramName = "solitairecollection";
            Installed = IsInstalled();
        }
    }
}
