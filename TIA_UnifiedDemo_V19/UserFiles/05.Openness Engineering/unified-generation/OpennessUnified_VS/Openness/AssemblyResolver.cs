using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;

namespace OpennessLibrary
{
    public class AssemblyResolver
    {
        #region Properties
        /// <summary>
        /// Short version of TIA Portal (Openness)
        /// 16.0, 15.1, 15.0
        /// </summary>
        public static string versionShort { get; set; } = "19.0";

        /// <summary>
        /// Long version of TIA Portal (Openness)
        /// 16.0.0.0, 15.1.0.0, 15.0.0.0
        /// </summary>
        public static string versionLong { get; set; } = "19.0.0.0";
        #endregion

        public static void AddResolver()
        {
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);
        }

        private static Assembly MyResolver(object sender, ResolveEventArgs args)
        {
            int index = args.Name.IndexOf(',');
            if (index == -1)
            {
                return null;
            }
            string name = args.Name.Substring(0, index) + ".dll";

            // Check for 64bit installation
            RegistryKey filePathReg = Registry.LocalMachine.OpenSubKey($"SOFTWARE\\Wow6432Node\\Siemens\\Automation\\Openness\\{versionShort}\\PublicAPI\\{versionLong}");

            // Check for 32bit installations
            if (filePathReg == null)
            {
                filePathReg = Registry.LocalMachine.OpenSubKey($"SOFTWARE\\Siemens\\Automation\\Openness\\{versionShort}\\PublicAPI\\{versionLong}");
            }

            string filePath = filePathReg.GetValue("Siemens.Engineering").ToString();
            string fullPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(filePath), name));

            if (File.Exists(fullPath))
            {
                return Assembly.LoadFrom(fullPath);
            }
            return null;
        }
    }
}
