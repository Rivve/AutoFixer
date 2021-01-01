using Microsoft.Win32;

namespace AutoFixer.Toggles
{
    class VisualFX : ToggleAbstract
    {
        public VisualFX()
        {
            Name = "Best Performance Visual effects";
            Descripton = "Changes the visual effects - Checked = Best performance, Unchecked = Best for your computer and visually.";
            RegistrySet = Registry.CurrentUser;
            RegKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects\\";
            Value = "VisualFXSetting";
            ValueKind = RegistryValueKind.DWord;
            CheckValue = 2;
            UncheckValue = 3;
            ReturnMessage = "Requires a restart / log out&in to take affect...";
            DefaultValue = false;

            Active = StartValue = CheckStartValue();
        }
    }
}
