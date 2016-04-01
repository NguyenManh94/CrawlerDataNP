using System;
using System.Text;
using System.Management;//[COLOR="Red"]sử dụng namespace này

namespace SSWA_WFTestApp
{
    public class SSWA_WFTestApp
    {        
        /// <summary>
        /// method to retrieve the selected HDD's serial number
        /// </summary>
        /// <param name="strDriveLetter">Drive letter to retrieve serial number for</param>
        /// <returns>the HDD's serial number</returns>
        public string GetHDDSerialNumber(string drive)
        {
            //check to see if the user provided a drive letter
            //if not default it to "C"
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            //create our ManagementObject, passing it the drive letter to the
            //DevideID using WQL
            ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            //bind our management object
            disk.Get();
            //return the serial number
            return disk["VolumeSerialNumber"].ToString();
        }
 
        /// <summary>
        /// method to retrieve the HDD's freespace
        /// </summary>
        /// <param name="drive">Drive letter to get free space from (optional)</param>
        /// <returns>The free space of the selected HDD</returns>
        public double GetHDDFreeSpace(string drive)
        {
            //check to see if the user provided a drive letter
            //if not default it to "C"
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            //create our ManagementObject, passing it the drive letter to the
            //DevideID using WQL
            ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            //bind our management object
            disk.Get();
            //return the free space amount
            return Convert.ToDouble(disk["FreeSpace"]);
        }
 
        /// <summary>
        /// method to retrieve the HDD's size
        /// </summary>
        /// <param name="drive">Drive letter to get free space from (optional)</param>
        /// <returns>The free space of the selected HDD</returns>
        public double getHDDSize(string drive)
        {
            //check to see if the user provided a drive letter
            //if not default it to "C"
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            //create our ManagementObject, passing it the drive letter to the
            //DevideID using WQL
            ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            //bind our management object
            disk.Get();
            //return the HDD's initial size
            return Convert.ToDouble(disk["Size"]);
        }
 
        /// <summary>
        /// method to find out the IPEnabled of
        /// the network adapter
        /// </summary>
        /// <returns></returns>
        public bool IsIPEnabled()
        {
            //create out management class object using the
            //Win32_NetworkAdapterConfiguration class to get the attributes
            //of the network adapter
            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //create our ManagementObjectCollection to get the attributes with
            ManagementObjectCollection objCol = mgmt.GetInstances();
            bool enabled = false;
            foreach (ManagementObject obj in objCol)
            {
                //get the status of the first adapter then
                //exit the loop
                enabled = (bool)obj["IPEnabled"];
                break;
                //dispose of the object
                obj.Dispose();
            }
            //return the IPEnabled status
            return enabled;
        }
 
        /// <summary>
        /// Returns MAC Address from first Network Card in Computer
        /// </summary>
        /// <returns>MAC Address in string format</returns>
        public string FindMACAddress()
        {
            //create out management class object using the
            //Win32_NetworkAdapterConfiguration class to get the attributes
            //of the network adapter
            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //create our ManagementObjectCollection to get the attributes with
            ManagementObjectCollection objCol = mgmt.GetInstances();
            string address = String.Empty;
            //loop through all the objects we find
            foreach (ManagementObject obj in objCol)
            {
                if (address == String.Empty)  // only return MAC Address from first card
                {
                    //grab the value from the first network adapter we find
                    //you can change the string to an array and get all
                    //network adapters found as well
                    //check to see if the adapter's IPEnabled
                    //equals true
                    if ((bool)obj["IPEnabled"] == true)
                    {
                        address = obj["MacAddress"].ToString();
                    }
                }
                //dispose of our object
                obj.Dispose();
            }
            //replace the ":" with an empty space, this could also
            //be removed if you wish
            address = address.Replace(":", "");
            //return the mac address
            return address;
        }
 
        /// <summary>
        /// method to retrieve the network adapters
        /// default IP gateway using WMI
        /// </summary>
        /// <returns>adapters default IP gateway</returns>
        public string GetDefaultIPGateway()
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
                    if ((bool)obj["IPEnabled"] == true)
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
        /// Return processorId from first CPU in machine
        /// </summary>
        /// <returns>[string] ProcessorId</returns>
        public string GetCPUId()
        {
            string cpuInfo =  String.Empty;            
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach(ManagementObject obj in objCol)
            {
                if(cpuInfo == String.Empty)
                {
                    // only return cpuInfo from first CPU
                    cpuInfo = obj.Properties["ProcessorId"].Value.ToString();
                }            
            }
            return cpuInfo;        
        }
 
        /// <summary>
        /// method for retrieving the CPU Manufacturer
        /// using the WMI class
        /// </summary>
        /// <returns>CPU Manufacturer</returns>
        public string GetCPUManufacturer()
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
        /// method for retrieving the CPU status
        /// using the WMI class
        /// </summary>
        /// <returns>the CPU status</returns>
        public string GetCPUStatus()
        {
            string cpuStatus = String.Empty;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuStatus == String.Empty)
                {
                    // only return cpuStatus from first CPU
                    cpuStatus = obj.Properties["Status"].Value.ToString();
                }
            }
            //return the status
            return cpuStatus;    
        }
 
        /// <summary>
        /// method to retrieve the CPU's current
        /// clock speed using the WMI class
        /// </summary>
        /// <returns>Clock speed</returns>
        public int GetCPUCurrentClockSpeed()
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
    }
}