using OpenHardwareMonitor.Hardware;
using System;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoFixer
{
    /// <summary>
    /// To seperate the code to make it easier to develop and read
    /// </summary>
    partial class UIAdvanced
    {
        /// <summary>
        /// All the groups at Speclist
        /// </summary>
        ListViewGroup cpu_group, gpu_group, op_group, mobo_group, ram_group, disk_group;

        /// <summary>
        /// Fill the specs into specslist
        /// </summary>
        public void FillSpecsTab()
        {
            Invoke((MethodInvoker)(() => { specslist.View = View.Details; }));
            Invoke((MethodInvoker)(() => { specslist.Columns.Add("System Information"); }));

            foreach (ManagementObject mo in SetAndGetSystemInfo("win32_operatingsystem"))
                Invoke((MethodInvoker)(() => { AddItems(ref op_group, "Operating System", GetProp(mo, "name").Split('|')[0] + "(" + GetProp(mo, "OSArchitecture") + ")" + " - Version: " + GetProp(mo, "version")); }));
            
            try
            {
                String winKey = KeyDecoder.GetWindowsProductKey(); // Split up since invoke can otherwise LOCK due to exception
                Invoke((MethodInvoker)(() => { AddItems(ref op_group, "Operating System", "Windows license key : " + winKey); }));
            } catch (Exception) { }

            foreach (ManagementObject mo in SetAndGetSystemInfo("win32_processor"))
            {
                Invoke((MethodInvoker)(() => { AddItems(ref cpu_group, "CPU", GetProp(mo, "name")); }));
                Invoke((MethodInvoker)(() => { AddItems(ref cpu_group, "CPU", "Cores : " + GetProp(mo, "NumberOfCores") + " & Threads: " + GetProp(mo, "NumberOfLogicalProcessors")); }));
            }
            try
            {
                foreach (var hardware in AutoFixer.chw.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        hardware.Update();
                        foreach (var sensor in hardware.Sensors)
                            if (sensor.SensorType == SensorType.Clock)
                                if (sensor.Name.Contains("#"))
                                    Invoke((MethodInvoker)(() => { AddItems(ref cpu_group, "CPU", sensor.Name + " : " + (int) sensor.Value.GetValueOrDefault() + " MHz"); }));
                    }
                }
            } catch (Exception) { }

            foreach (ManagementObject mo in SetAndGetSystemInfo("win32_baseboard"))
                Invoke((MethodInvoker)(() => { AddItems(ref mobo_group, "Motherboard", GetProp(mo, "Manufacturer") + " " + GetProp(mo, "product")); }));

            foreach (ManagementObject mo in SetAndGetSystemInfo("win32_bios"))
                Invoke((MethodInvoker)(() => { AddItems(ref mobo_group, "Motherboard", "Bios version : " + GetProp(mo, "name")); }));

            foreach (ManagementObject mo in SetAndGetSystemInfo("win32_physicalmemory"))
            {
                long result = Int64.Parse(GetProp(mo, "Capacity")) / (1024 * 1024);
                Invoke((MethodInvoker)(() =>
                {
                    AddItems(ref ram_group, "RAM",
                        Vendors.GetVendor(GetProp(mo, "Manufacturer")) + " (" + Regex.Replace(GetProp(mo, "PartNumber"), @"\s+", "") + ") - "
                        + result + " MB" + " @" + GetProp(mo, "Speed") + " MHz");
                }));
            }

            try
            {
                foreach (var hardware in AutoFixer.chw.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.GpuNvidia)
                    {
                        hardware.Update();
                        foreach (var sensor in hardware.Sensors)
                            if (sensor.SensorType == SensorType.SmallData && sensor.Name.Contains("Total"))
                                Invoke((MethodInvoker)(() => { AddItems(ref gpu_group, "Graphics", hardware.Name + " - " + sensor.Value.GetValueOrDefault() + "MB Memory"); }));
                    }
                    if (hardware.HardwareType == HardwareType.GpuAti)
                    {
                        hardware.Update();
                        Invoke((MethodInvoker)(() => { AddItems(ref gpu_group, "Graphics", hardware.Name); }));
                    }
                }
            } catch (Exception) { }

            foreach (ManagementObject mo in SetAndGetSystemInfo("Win32_DiskDrive"))
            {
                ulong memory = UInt64.Parse(GetProp(mo, "Size")) / (1024 * 1024 * 1024);
                Invoke((MethodInvoker)(() => { AddItems(ref disk_group, "Disks", memory + "GB " + GetProp(mo, "Model")); }));
            }

        }

        /// <summary>
        /// Grabs the requested Value and returns it as a string depending on ManagementObject
        /// </summary>
        /// <param name="mo">The instance it shall grab the data from</param>
        /// <param name="value">The value in the instance we want</param>
        /// <returns>The Value returned as string</returns>
        public String GetProp(ManagementObject mo, String value)
        {
            try {
                return mo.Properties[value].Value.ToString();
            } catch {
                return "UNKOWN";
            }
        }

        /// <summary>
        /// A function to provide a easier solution for a multi requesting system above
        /// </summary>
        /// <param name="win32get">What it shall search for in the WMI</param>
        /// <returns>Returns the instance of what it found</returns>
        public ManagementObjectCollection SetAndGetSystemInfo(String win32get)
        {
            ManagementClass mc = new ManagementClass(win32get);
            return mc.GetInstances();
        }

        /// <summary>
        /// Requesting to adding an item to a group ref with a groupname.
        /// If the group is null it will create it with the incoming name.
        /// </summary>
        /// <param name="group">Reference to a ListViewGroup</param>
        /// <param name="groupname">The name it shall have if ref group = null</param>
        /// <param name="product">The Content that shall be added</param>
        private void AddItems(ref ListViewGroup group, String groupname, String product)
        {
            if (group == null)
            {
                group = new ListViewGroup(groupname);
                specslist.Groups.Add(group);
            }

            AddItem(product, group);
        }

        /// <summary>
        /// Adds an item to the listview
        /// </summary>
        /// <param name="product">The content it has</param>
        /// <param name="group">Which group it shall be added under</param>
        private void AddItem(String product, ListViewGroup group)
        {
            specslist.Items.Add(new ListViewItem(new string[] {
                product
            }, group));
            ResizeListViewColumns(specslist);
        }

        /// <summary>
        /// Resize the listview so it fits the content
        /// </summary>
        /// <param name="lv">The listview we wish to resize</param>
        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -1;
            }
        }

    }
}
