using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutoFixer.Toggles
{
    abstract class ToggleAbstract
    {
        /// <summary>
        /// Variables for view
        /// </summary>
        public bool Active { get; set; }
        public String Name { get; set; }
        public String Descripton { get; set; }
        public String Help { get; set; }
        /// <summary>
        /// Variables for background work
        /// </summary>
        [Browsable(false)]
        public bool StartValue { get; set; } 
        [Browsable(false)]
        public String RegKey { get; set; }
        [Browsable(false)]
        public String Value { get; set; }
        [Browsable(false)]
        public RegistryValueKind ValueKind { get; set; }
        [Browsable(false)]
        public RegistryKey RegistrySet { get; set; }
        [Browsable(false)]
        public Object CheckValue { get; set; }
        [Browsable(false)]
        public Object UncheckValue { get; set; }
        [Browsable(false)]
        public String ReturnMessage { get; set; }
        [Browsable(false)]
        public bool RestartExplorer { get; set; }
        [Browsable(false)]
        public bool DefaultValue { get; set; }
        [Browsable(false)]
        public bool Unavailable { get; set; }

        /// <summary>
        /// Do the actual effect at the system
        /// </summary>
        public bool DoToggle()
        {
            try
            {
                using (RegistryKey key = RegistrySet.OpenSubKey(RegKey, true))
                {
                    if (key != null)
                    {
                        if (Active)
                        {
                            if (UncheckValue == null)
                            {
                                if (key.GetValue(Value) != null)
                                    key.DeleteValue(Value);
                            }
                            else if (UncheckValue.GetType() == typeof(int))
                            {
                                key.SetValue(Value, UncheckValue, ValueKind);
                            }
                        }
                        else
                        {
                            if (CheckValue == null)
                            {
                                if (key.GetValue(Value) != null)
                                    key.DeleteValue(Value);
                            }
                            else if (CheckValue.GetType() == typeof(int))
                            {
                                key.SetValue(Value, CheckValue, ValueKind);
                            }
                        }
                    }
                    else if (key == null)
                    {
                        if (Active)
                        {
                            if (UncheckValue.GetType() == typeof(int))
                            {
                                Registry.SetValue(RegistrySet + "\\" + RegKey, Value, UncheckValue, ValueKind);
                            }
                        }
                        else
                        {
                            if (CheckValue.GetType() == typeof(int))
                            {
                                Registry.SetValue(RegistrySet + "\\" + RegKey, Value, CheckValue, ValueKind);
                                //key.SetValue(Value, CheckValue, ValueKind);
                            }
                        }
                    }
                }
                if (RestartExplorer)
                {
                    foreach (Process p in Process.GetProcesses())
                    {
                        try // In case we get Access Denied
                        {
                            if (p.ProcessName == "explorer")
                            {
                                p.Kill();
                                break;
                            }
                        }
                        catch { }
                    }
                    Process.Start("explorer.exe");
                }
                return true; //Success
            }
            catch (Exception)
            {
                return false; //Some exception error...
            }
        }

        /// <summary>
        /// Set Value/StartValue depending if it set... 
        /// True = Check in the list also
        /// </summary>
        /// <returns>Weither its set or not</returns>
        public bool CheckStartValue()
        {
            try
            {
                using (RegistryKey key = RegistrySet.OpenSubKey(RegKey, true))
                    if (key != null && key.GetValue(Value) != null && key.GetValue(Value).Equals(CheckValue))
                        return true;
                    else if (key == null || key.GetValue(Value) == null)
                        return DefaultValue;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return false;
        }
        
        /// <summary>
        /// Toggle the settings and the checkbox and show the user a message
        /// </summary>
        public void Toggle()
        {
            if (Unavailable) return;
            if (DoToggle())
            {
                Active = !Active;
                if (Active == StartValue) MessageBox.Show("Changes has been reverted!");
                else if (ReturnMessage != null) MessageBox.Show(ReturnMessage);
                else MessageBox.Show("Changes has been applied!");
            }
            else
            {
                MessageBox.Show("EXCEPTION ERROR! Please try to restart the program and do it again, or else report the issue and which function...");
            }
        }
    }
}
