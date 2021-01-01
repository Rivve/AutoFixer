using System.Diagnostics;

namespace AutoFixer.Actions
{
    class DisableSuperFetch : ExecuteAbstract
    {
        public DisableSuperFetch()
        {
            this.Name = "Disable Superfetch";
            this.Desc = "Disable and stopping Windows superfetch";
        }

        public override void ExecuteAction()
        {
            Process.Start("sc.exe", "config SysMain start=disabled");
            Process.Start("sc.exe", "stop SysMain");
        }
    }
}
