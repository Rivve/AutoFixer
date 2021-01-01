using System;
using System.ComponentModel;

namespace AutoFixer.Actions
{
    abstract class ExecuteAbstract
    {
        public bool Execute { get; set; }
        public String Name { get; set; }
        public String Desc { get; set; }

        [Browsable(false)]
        public bool Unavailable { get; set; }

        public abstract void ExecuteAction();
    }
}
