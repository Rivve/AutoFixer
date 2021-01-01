using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;
using System.IO;
using OpenHardwareMonitor.Hardware;

/*
 * AutoFixer is a tool which shall help users in a friendly way to toggle
 * certain parameters/functions inside of Windows. The program is also
 * used to display what products the computer is containing.
 * Copyright(C) 2017  Marcus Strandner - Marcus@Strandner.se
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>.
 * 
 * This program comes with ABSOLUTELY NO WARRANTY!
 */
namespace AutoFixer
{
    public class AutoFixer
    {
        public static bool reqRestart = false;
        public static Computer chw = new Computer() { CPUEnabled = true, GPUEnabled = true }; //Computer hardware 

        public const int STD_OUTPUT_HANDLE = -11;
        public const int STD_INPUT_HANDLE = -10;
        public const int STD_ERROR_HANDLE = -12;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint GENERIC_READ = 0x80000000;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetStdHandle(int nStdHandle, IntPtr hHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPTStr)] string filename,
                                               [MarshalAs(UnmanagedType.U4)]     uint access,
                                               [MarshalAs(UnmanagedType.U4)]     FileShare share,
                                                                                 IntPtr securityAttributes,
                                               [MarshalAs(UnmanagedType.U4)]     FileMode creationDisposition,
                                               [MarshalAs(UnmanagedType.U4)]     FileAttributes flagsAndAttributes,
                                                                                 IntPtr templateFile);

        /// <summary>
        /// The core which starts and loads the program itself
        /// </summary>
        public AutoFixer()
        {
            if (System.Diagnostics.Debugger.IsAttached) //Open console if we're running debug mode
            {
                AllocConsole();
                var hOut = GetStdHandle(STD_OUTPUT_HANDLE);
                var hRealOut = CreateFile("CONOUT$", GENERIC_READ | GENERIC_WRITE, FileShare.Write, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                if (hRealOut != hOut)
                {
                    SetStdHandle(STD_OUTPUT_HANDLE, hRealOut);
                    Console.SetOut(new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding) { AutoFlush = true });
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UIAdvanced(this));
        }

        /// <summary>
        /// Starting the program
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            new AutoFixer();
        }
    }
}
