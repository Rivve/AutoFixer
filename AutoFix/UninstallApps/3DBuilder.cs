namespace AutoFixer.UninstallsApp
{
    class ThreeDBuilder : UninstallAppAbstract
    {
        public ThreeDBuilder()
        {
            DisplayName = "3D Builder";
            Descripton = "Uninstall preinstalled 3D Builder";
            ProgramName = "3dbuilder";
            Installed = IsInstalled();
        }
    }
}
