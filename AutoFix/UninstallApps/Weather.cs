
namespace AutoFixer.UninstallsApp
{
    class Weather : UninstallAppAbstract
    {
        public Weather()
        {
            DisplayName = "Weather";
            Descripton = "Uninstall preinstalled Weather app";
            ProgramName = "bingweather";
            Installed = IsInstalled();
        }
    }
}
