using Microsoft.Win32;

namespace AutoFixer.Actions
{
    class MemoryLeak : ExecuteAbstract
    {
        const string NDUMEMLEAK = "HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\Ndu";

        public MemoryLeak()
        {
            this.Name = "Resolve Memleak";
            this.Desc = "Resolves a memory leak in windows 10 through Registry";
            if (!Utils.IsWindows10(0)) Unavailable = true;
        }

        public override void ExecuteAction()
        {
            Registry.SetValue(NDUMEMLEAK, "Start", 4, RegistryValueKind.DWord);
        }
    }
}
