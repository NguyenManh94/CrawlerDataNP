using System;
using System.Management;

namespace SSWA_ExtractData.Common.Security
{
    /// <summary>
    ///     Create By: ManhNV1 -Date: 02/25/2016
    ///     Description: Get Information Hardware
    /// </summary>
    internal class SEDHardwareInfor
    {
        /// <summary>
        ///     [EN] GetProcessorId
        ///     Retrieving Processor Id.
        /// </summary>
        /// <returns></returns>
        public static string GetProcessorId()
        {
            var mc = new ManagementClass("win32_processor");
            var moc = mc.GetInstances();
            var Id = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;
        }

        /// <summary>
        ///     [EN] GetHDDSerialNo
        ///     Retrieving HDD Serial No.
        /// </summary>
        /// <returns></returns>
        public static string GetHDDSerialNo()
        {
            var mangnmt = new ManagementClass("Win32_LogicalDisk");
            var mcol = mangnmt.GetInstances();
            var result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return result;
        }

        /// <summary>
        ///     [EN] GetMACAddress
        ///     Retrieving System MAC Address.
        /// </summary>
        /// <returns></returns>
        public static string GetMACAddress()
        {
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();
            var MACAddress = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == string.Empty)
                {
                    if ((bool) mo["IPEnabled"]) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }

        /// <summary>
        ///     [EN] GetBoardMaker
        ///     Retrieving Motherboard Manufacturer.
        /// </summary>
        /// <returns></returns>
        public static string GetBoardMaker()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", SEDSecurityConst.SQL_WIN32_BASEBOARD);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch
                {
                }
            }
            return "Board Maker: Unknown";
        }

        /// <summary>
        ///     [EN] GetBoardProductId
        ///     Retrieving Motherboard Product Id.
        /// </summary>
        /// <returns></returns>
        public static string GetBoardProductId()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", SEDSecurityConst.SQL_WIN32_BASEBOARD);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Product").ToString();
                }
                catch
                {
                }
            }
            return "Product: Unknown";
        }

        /// <summary>
        ///     [EN] GetCdRomDrive
        ///     Retrieving CD-DVD Drive Path.
        /// </summary>
        /// <returns></returns>
        public static string GetCdRomDrive()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_CDROMDRIVE);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Drive").ToString();
                }
                catch
                {
                }
            }
            return "CD ROM Drive Letter: Unknown";
        }

        /// <summary>
        ///     [EN] GetBIOSmaker
        ///     Retrieving BIOS Maker.
        /// </summary>
        /// <returns></returns>
        public static string GetBIOSmaker()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_BIOS);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch
                {
                }
            }
            return "BIOS Maker: Unknown";
        }

        /// <summary>
        ///     [EN] GetBIOSserNo
        ///     Retrieving BIOS Serial No.
        /// </summary>
        /// <returns></returns>
        public static string GetBIOSserNo()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_BIOS);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch
                {
                }
            }
            return "BIOS Serial Number: Unknown";
        }

        /// <summary>
        ///     [EN] GetBIOScaption
        ///     Retrieving BIOS Caption.
        /// </summary>
        /// <returns></returns>
        public static string GetBIOScaption()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_BIOS);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Caption").ToString();
                }
                catch
                {
                }
            }
            return "BIOS Caption: Unknown";
        }

        /// <summary>
        ///     [EN] GetAccountName
        ///     Retrieving System Account Name.
        /// </summary>
        /// <returns></returns>
        public static string GetAccountName()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_USERACCOUNT);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Name").ToString();
                }
                catch
                {
                }
            }
            return "User Account Name: Unknown";
        }

        /// <summary>
        ///     [EN] GetPhysicalMemory
        ///     Retrieving Physical Ram Memory.
        /// </summary>
        /// <returns></returns>
        public static string GetPhysicalMemory()
        {
            var oMs = new ManagementScope();
            var oQuery = new ObjectQuery(SEDSecurityConst.SQL_WIN32_PHYSICALMEMORY);
            var oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            var oCollection = oSearcher.Get();

            long MemSize = 0;
            long mCap = 0;

            // In case more than one Memory sticks are installed
            foreach (ManagementObject obj in oCollection)
            {
                mCap = Convert.ToInt64(obj["Capacity"]);
                MemSize += mCap;
            }
            MemSize = (MemSize/1024)/1024;
            return MemSize + "MB";
        }

        /// <summary>
        ///     [EN] GetNoRamSlots
        ///     Retrieving No of Ram Slot on Motherboard.
        /// </summary>
        /// <returns></returns>
        public static string GetNoRamSlots()
        {
            var MemSlots = 0;
            var oMs = new ManagementScope();
            var oQuery2 = new ObjectQuery(SEDSecurityConst.SQL_WIN32_PHYSICALMEMORYARRAY);
            var oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
            var oCollection2 = oSearcher2.Get();
            foreach (ManagementObject obj in oCollection2)
            {
                MemSlots = Convert.ToInt32(obj["MemoryDevices"]);
            }
            return MemSlots.ToString();
        }

        /// <summary>
        ///     [EN] Get CPU Temprature
        ///     method for retrieving the CPU Manufacturer
        ///     using the WMI class
        /// </summary>
        /// <returns>CPU Manufacturer</returns>
        public static string GetCPUManufacturer()
        {
            var cpuMan = string.Empty;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            var mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            var objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuMan == string.Empty)
                {
                    // only return manufacturer from first CPU
                    cpuMan = obj.Properties["Manufacturer"].Value.ToString();
                }
            }
            return cpuMan;
        }

        /// <summary>
        ///     [EN] GetCPUCurrentClockSpeed
        ///     method to retrieve the CPU's current
        ///     clock speed using the WMI class
        /// </summary>
        /// <returns>Clock speed</returns>
        public static int GetCPUCurrentClockSpeed()
        {
            var cpuClockSpeed = 0;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            var mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            var objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuClockSpeed == 0)
                {
                    // only return cpuStatus from first CPU
                    cpuClockSpeed = Convert.ToInt32(obj.Properties["CurrentClockSpeed"].Value.ToString());
                }
            }
            //return the status
            return cpuClockSpeed;
        }

        /// <summary>
        ///     [EN] GetDefaultIPGateway
        ///     method to retrieve the network adapters
        ///     default IP gateway using WMI
        /// </summary>
        /// <returns>adapters default IP gateway</returns>
        public static string GetDefaultIPGateway()
        {
            //create out management class object using the
            //Win32_NetworkAdapterConfiguration class to get the attributes
            //of the network adapter
            var mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //create our ManagementObjectCollection to get the attributes with
            var objCol = mgmt.GetInstances();
            var gateway = string.Empty;
            //loop through all the objects we find
            foreach (ManagementObject obj in objCol)
            {
                if (gateway == string.Empty) // only return MAC Address from first card
                {
                    //grab the value from the first network adapter we find
                    //you can change the string to an array and get all
                    //network adapters found as well
                    //check to see if the adapter's IPEnabled
                    //equals true
                    if ((bool) obj["IPEnabled"])
                    {
                        gateway = obj["DefaultIPGateway"].ToString();
                    }
                }
                //dispose of our object
                obj.Dispose();
            }
            //replace the ":" with an empty space, this could also
            //be removed if you wish
            gateway = gateway.Replace(":", "");
            //return the mac address
            return gateway;
        }

        /// <summary>
        ///     [EN] GetCpuSpeedInGHz
        ///     Retrieve CPU Speed.
        /// </summary>
        /// <returns></returns>
        public static double? GetCpuSpeedInGHz()
        {
            double? GHz = null;
            using (var mc = new ManagementClass("Win32_Processor"))
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    GHz = 0.001*(uint) mo.Properties["CurrentClockSpeed"].Value;
                    break;
                }
            }
            return GHz;
        }

        /// <summary>
        ///     [EN] GetCurrentLanguage
        ///     Retrieving Current Language
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLanguage()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_BIOS);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("CurrentLanguage").ToString();
                }
                catch
                {
                }
            }
            return "BIOS Maker: Unknown";
        }

        /// <summary>
        ///     [EN] GetOSInformation
        ///     Retrieving Current Language.
        /// </summary>
        /// <returns></returns>
        public static string GetOSInformation()
        {
            var searcher = new ManagementObjectSearcher(SEDSecurityConst.SQL_WIN32_OPERATINGSYSTEM);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return ((string) wmi["Caption"]).Trim() + ", " + (string) wmi["Version"] + ", " +
                           (string) wmi["OSArchitecture"];
                }
                catch
                {
                }
            }
            return "BIOS Maker: Unknown";
        }

        /// <summary>
        ///     [EN] GetProcessorInformation
        ///     Retrieving Processor Information.
        /// </summary>
        /// <returns></returns>
        public static string GetProcessorInformation()
        {
            var mc = new ManagementClass("win32_processor");
            var moc = mc.GetInstances();
            var info = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                var name = (string) mo["Name"];
                name =
                    name.Replace("(TM)", "™")
                        .Replace("(tm)", "™")
                        .Replace("(R)", "®")
                        .Replace("(r)", "®")
                        .Replace("(C)", "©")
                        .Replace("(c)", "©")
                        .Replace("    ", " ")
                        .Replace("  ", " ");

                info = name + ", " + (string) mo["Caption"] + ", " + (string) mo["SocketDesignation"];
                //mo.Properties["Name"].Value.ToString();
                //break;
            }
            return info;
        }

        /// <summary>
        ///     [EN] GetComputerName
        ///     Retrieving Computer Name.
        /// </summary>
        /// <returns></returns>
        public static string GetComputerName()
        {
            var mc = new ManagementClass("Win32_ComputerSystem");
            var moc = mc.GetInstances();
            var info = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                info = (string) mo["Name"];
                //mo.Properties["Name"].Value.ToString();
                //break;
            }
            return info;
        }
    }
}