using System.Diagnostics;

namespace AutoFixer.Actions
{
    class HighPerformance : ExecuteAbstract
    {
        public HighPerformance()
        {
            this.Name = "High Performance mode";
            this.Desc = "Sets the computers Powerplan to High Performance mode";
        }

        public override void ExecuteAction()
        {
            Process.Start("powercfg.exe", "-setactive 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c");
        }
    }
}
