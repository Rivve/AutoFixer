
namespace AutoFixer.UninstallsApp
{
    class VoiceRecorder : UninstallAppAbstract
    {
        public VoiceRecorder()
        {
            DisplayName = "Voice Recorder";
            Descripton = "Uninstall preinstalled Voice Recorder app";
            ProgramName = "soundrecorder";
            Installed = IsInstalled();
        }
    }
}
