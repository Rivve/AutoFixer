namespace AutoFixer.UninstallsApp
{
    class Camera : UninstallAppAbstract
    {
        public Camera()
        {
            DisplayName = "Camera";
            Descripton = "Uninstall preinstalled Camera app";
            ProgramName = "windowscamera";
            Installed = IsInstalled();
        }
    }
}
