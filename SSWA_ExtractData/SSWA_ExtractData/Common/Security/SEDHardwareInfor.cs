using System;
using System.Management;

namespace SSWA_ExtractData.Common.Security
{
    /// <summary>
    /// Create By: ManhNV1 -Date: 02/25/2016
    /// Description: Get Information Hardware
    /// </summary>
    class SEDHardwareInfor
    {
        /// <summary>
        /// [EN] GetProcessorId
        /// Retrieving Processor Id.
        /// </summary>
        /// <returns></returns>
        public static String GetProcessorId()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;
        }

        /// <summary>
        /// [EN] GetHDDSerialNo
        /// Retrieving HDD Serial No.
        /// </summary>
        /// <returns></returns>
        public static String GetHDDSerialNo()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return result;
        }

        /// <summary>
        /// [EN] GetMACAddress
        /// Retrieving System MAC Address.
        /// </summary>
        /// <returns></returns>
        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                {
                    if ((bool) mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }

        /// <summary>
        /// [EN] GetBoardMaker
        /// Retrieving Motherboard Manufacturer.
        /// </summary>
        /// <returns></returns>
        public static string GetBoardMaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", SEDSecurityConst.SQL_WIN32_BASEBOARD);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "Board Maker: Unknown";
        }

        /// <summary>
        /// [EN] GetBoardProductId
        /// Retrieving Motherboard Product Id.
        /// </summary>
        /// <returns></returns>
        public static string GetBoardProductId()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", SEDSecurityConst.SQL_WIN32_BASEBOARD);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Product").ToString();
                }
                catch { }
            }
            return "Product: Unknown";
        }

        /// <summary>
        /// [EN] GetCdRomDrive
        /// Retrieving CD-DVD Drive Path.
        /// </summary>
        /// <returns></returns>
        public static string GetCdRomDrive()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_CDROMDRIVE);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Drive").ToString();
                }
                catch { }
            }
            return "CD ROM Drive Letter: Unknown";
        }

        /// <summary>
        /// [EN] GetBIOSmaker
        /// Retrieving BIOS Maker.
        /// </summary>
        /// <returns></returns>
        public static string GetBIOSmaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_BIOS);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "BIOS Maker: Unknown";
        }

        /// <summary>
        /// [EN] GetBIOSserNo
        /// Retrieving BIOS Serial No.
        /// </summary>
        /// <returns></returns>
        public static string GetBIOSserNo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_BIOS);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch { }
            }
            return "BIOS Serial Number: Unknown";
        }

        /// <summary>
        /// [EN] GetBIOScaption
        /// Retrieving BIOS Caption.
        /// </summary>
        /// <returns></returns>
        public static string GetBIOScaption()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_BIOS);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Caption").ToString();
                }
                catch { }
            }
            return "BIOS Caption: Unknown";
        }

        /// <summary>
        /// [EN] GetAccountName
        /// Retrieving System Account Name.
        /// </summary>
        /// <returns></returns>
        public static string GetAccountName()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_USERACCOUNT);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Name").ToString();
                }
                catch { }
            }
            return "User Account Name: Unknown";
        }

        /// <summary>
        /// [EN] GetPhysicalMemory
        /// Retrieving Physical Ram Memory.
        /// </summary>
        /// <returns></returns>
        public static string GetPhysicalMemory()
        {
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery = new ObjectQuery(SEDSecurityConst.SQL_WIN32_PHYSICALMEMORY);
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            ManagementObjectCollection oCollection = oSearcher.Get();

            long MemSize = 0;
            long mCap = 0;

            // In case more than one Memory sticks are installed
            foreach (ManagementObject obj in oCollection)
            {
                mCap = Convert.ToInt64(obj["Capacity"]);
                MemSize += mCap;
            }
            MemSize = (MemSize / 1024) / 1024;
            return MemSize.ToString() + "MB";
        }

        /// <summary>
        /// [EN] GetNoRamSlots
        /// Retrieving No of Ram Slot on Motherboard.
        /// </summary>
        /// <returns></returns>
        public static string GetNoRamSlots()
        {

            int MemSlots = 0;
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery2 = new ObjectQuery(SEDSecurityConst.SQL_WIN32_PHYSICALMEMORYARRAY);
            ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
            ManagementObjectCollection oCollection2 = oSearcher2.Get();
            foreach (ManagementObject obj in oCollection2)
            {
                MemSlots = Convert.ToInt32(obj["MemoryDevices"]);

            }
            return MemSlots.ToString();
        }

        /// <summary>
        /// [EN] Get CPU Temprature
        /// method for retrieving the CPU Manufacturer
        /// using the WMI class
        /// </summary>
        /// <returns>CPU Manufacturer</returns>
        public static string GetCPUManufacturer()
        {
            string cpuMan = String.Empty;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuMan == String.Empty)
                {
                    // only return manufacturer from first CPU
                    cpuMan = obj.Properties["Manufacturer"].Value.ToString();
                }
            }
            return cpuMan;
        }
        /// <summary>
        /// [EN] GetCPUCurrentClockSpeed
        /// method to retrieve the CPU's current
        /// clock speed using the WMI class
        /// </summary>
        /// <returns>Clock speed</returns>
        public static int GetCPUCurrentClockSpeed()
        {
            int cpuClockSpeed = 0;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
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
        /// [EN] GetDefaultIPGateway
        /// method to retrieve the network adapters
        /// default IP gateway using WMI
        /// </summary>
        /// <returns>adapters default IP gateway</returns>
        public static string GetDefaultIPGateway()
        {
            //create out management class object using the
            //Win32_NetworkAdapterConfiguration class to get the attributes
            //of the network adapter
            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //create our ManagementObjectCollection to get the attributes with
            ManagementObjectCollection objCol = mgmt.GetInstances();
            string gateway = String.Empty;
            //loop through all the objects we find
            foreach (ManagementObject obj in objCol)
            {
                if (gateway == String.Empty)  // only return MAC Address from first card
                {
                    //grab the value from the first network adapter we find
                    //you can change the string to an array and get all
                    //network adapters found as well
                    //check to see if the adapter's IPEnabled
                    //equals true
                    if ((bool) obj["IPEnabled"] == true)
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
        /// [EN] GetCpuSpeedInGHz
        /// Retrieve CPU Speed.
        /// </summary>
        /// <returns></returns>
        public static double? GetCpuSpeedInGHz()
        {
            double? GHz = null;
            using (ManagementClass mc = new ManagementClass("Win32_Processor"))
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    GHz = 0.001 * (UInt32) mo.Properties["CurrentClockSpeed"].Value;
                    break;
                }
            }
            return GHz;
        }

        /// <summary>
        /// [EN] GetCurrentLanguage
        /// Retrieving Current Language
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLanguage()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2"
                , SEDSecurityConst.SQL_WIN32_BIOS);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("CurrentLanguage").ToString();
                }
                catch { }
            }
            return "BIOS Maker: Unknown";
        }

        /// <summary>
        /// [EN] GetOSInformation
        /// Retrieving Current Language.
        /// </summary>
        /// <returns></returns>
        public static string GetOSInformation()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(SEDSecurityConst.SQL_WIN32_OPERATINGSYSTEM);
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return ((string) wmi["Caption"]).Trim() + ", " + (string) wmi["Version"] + ", " + (string) wmi["OSArchitecture"];
                }
                catch { }
            }
            return "BIOS Maker: Unknown";
        }

        /// <summary>
        /// [EN] GetProcessorInformation
        /// Retrieving Processor Information.
        /// </summary>
        /// <returns></returns>
        public static String GetProcessorInformation()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String info = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                string name = (string) mo["Name"];
                name = name.Replace("(TM)", "™").Replace("(tm)", "™").Replace("(R)", "®").Replace("(r)", "®").Replace("(C)", "©").Replace("(c)", "©").Replace("    ", " ").Replace("  ", " ");

                info = name + ", " + (string) mo["Caption"] + ", " + (string) mo["SocketDesignation"];
                //mo.Properties["Name"].Value.ToString();
                //break;
            }
            return info;
        }

        /// <summary>
        /// [EN] GetComputerName
        /// Retrieving Computer Name.
        /// </summary>
        /// <returns></returns>
        public static String GetComputerName()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            String info = String.Empty;
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
