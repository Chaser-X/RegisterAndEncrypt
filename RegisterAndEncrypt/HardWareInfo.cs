using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft;
using Microsoft.Win32;


namespace RegisterAndEncrypt
{
    public class HardWareInfo
    {

        private HardWareInfo() { }

        public enum InfoType
        {
            CPUID = 0,
            DiskID = 1,
            MemoryID = 2
        }

        private static string[] pathName
        = new string[3]
        {
            "Win32_Processor|ProcessorID",
            "Win32_DiskDrive|Model",
            "Win32_ComputerSystem|TotalPhysicalMemory"
        };

        public static string GetInfo(InfoType type)
        {
            string info = string.Empty;
            string[] path = pathName[(int)type].Split('|');
            var machine = new ManagementClass(path[0]);
            var temp = machine.GetInstances();
            
            foreach (var x in temp)
            {
                info = x.Properties[path[1]].Value.ToString();
                break;
            }

            return info;
        }

    }
}
