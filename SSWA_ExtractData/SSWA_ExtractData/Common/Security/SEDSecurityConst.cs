namespace SSWA_ExtractData.Common.Security
{
    /// <summary>
    ///     Create by: ManhNV1 -Date: 02/25/2016
    ///     Description: Constanst Security -Sql information Hardware System
    /// </summary>
    public sealed class SEDSecurityConst
    {
        //TODO Wait after Deployment and Comment

        #region

        public const string IS_EMPTY = "";

        public const string IS_COLON = ":";

        public const string WININET_DLL = "wininet.dll";

        public const string WIN32_PROCESSOR = "win32_processor";

        public const string PROCESSORID = "processorID";

        public const string WIN32_LOGICALDISK = "Win32_LogicalDisk";

        public const string VOLUMESERIALNUMBER = "VolumeSerialNumber";

        public const string WIN32_NETWORKADAPTERCONFIGURATION = "Win32_NetworkAdapterConfiguration";

        public const string IPENABLED = "IPEnabled";

        public const string MACADDRESS = "MacAddress";

        public const string ROOT_CIMV2 = "root\\CIMV2";

        public const string MANUFACTURER = "Manufacturer";

        public const string BOARD_MAKER_UNKNOWN = "Board Maker: Unknown";

        #endregion

        #region Sql Constants

        /** ManhNV1 - Table Win32_BaseBoard*/
        public const string SQL_WIN32_BASEBOARD = "SELECT * FROM Win32_BaseBoard";

        /** ManhNV1 - Table Win32_CDROMDrive*/
        public const string SQL_WIN32_CDROMDRIVE = "SELECT * FROM Win32_CDROMDrive";

        /** ManhNV1 - Table Win32_BIOS*/
        public const string SQL_WIN32_BIOS = "SELECT * FROM Win32_BIOS";

        /** ManhNV1 - Table Win32_UserAccount*/
        public const string SQL_WIN32_USERACCOUNT = "SELECT * FROM Win32_UserAccount";

        /** ManhNV1 - Table Win32_PhysicalMemory*/
        public const string SQL_WIN32_PHYSICALMEMORY = "SELECT Capacity FROM Win32_PhysicalMemory";

        /** ManhNV1 - Table Win32_PhysicalMemoryArray*/
        public const string SQL_WIN32_PHYSICALMEMORYARRAY = "SELECT MemoryDevices FROM Win32_PhysicalMemoryArray";

        /** ManhNV1 - Table Win32_OperatingSystem*/
        public const string SQL_WIN32_OPERATINGSYSTEM = "SELECT * FROM Win32_OperatingSystem";

        #endregion
    }
}