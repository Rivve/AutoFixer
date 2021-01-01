namespace AutoFixer.UninstallsApp
{
    class GrooveMusic : UninstallAppAbstract
    {
        public GrooveMusic()
        {
            DisplayName = "Groove Music";
            Descripton = "Uninstall preinstalled Groove music app";
            ProgramName = "zunemusic";
            Installed = IsInstalled();
        }
    }
}
