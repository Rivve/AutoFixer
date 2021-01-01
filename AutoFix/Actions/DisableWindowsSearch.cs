using System.Diagnostics;

namespace AutoFixer.Actions
{
    class DisableWindowsSearch : ExecuteAbstract
    {
        public DisableWindowsSearch()
        {
            this.Name = "Disable Windows Search";
            this.Desc = "Disable and stopping Windows Search";
        }

        public override void ExecuteAction()
        {
            Process.Start("sc.exe", "config WSearch start=disabled");
            Process.Start("sc.exe", "stop WSearch");
        }
    }
}
