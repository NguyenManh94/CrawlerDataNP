using SSWA_ExtractData.Common.Constant;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SSWA_ExtractData.Common.Security
{
    /// <summary>
    /// Create By: ManhNV1 -Date: 02/25/2016
    /// Description: Netword Processor
    /// </summary>
    sealed class SEDInternetConnection
    {
        /// <summary>
        /// Create By: ManhNV1 -Date: 02/25/2016
        /// Description: Check Internet Connect
        /// </summary>
        /// <param name="description">out int </param>
        /// <param name="reservedValue"></param>
        /// <returns></returns>
        [DllImport(SEDSecurityConst.WININET_DLL)]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);
        public static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        /// <summary>
        /// Create By: ManhNV1 -Date: 02/25/2016
        /// Description: Get Information Mac Commputer Current
        /// </summary>
        /// <returns>String Current Mac</returns>
        public static string GetIpMacCurrent()
        {
            var sbdHardwareInfor = new StringBuilder();
            var sbdListMac = new StringBuilder();
            // array NetwordCard
            var lstNetwordCard = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < lstNetwordCard.Length; i++)
            {
                //Type: PhysicalAddress
                var MacAddress = lstNetwordCard[i].GetPhysicalAddress();
                sbdListMac.Append(lstNetwordCard[i].Name).Append(SEDSecurityConst.IS_COLON);
                byte[] ByteAddress = MacAddress.GetAddressBytes();
                for (int j = 0; j < ByteAddress.Length; j++)
                {
                    sbdListMac.Append(ByteAddress[j].ToString(SEDConst.X_2_UPPER));
                    if (j != ByteAddress.Length - 1)
                    {
                        sbdListMac.Append(SEDConst.MINUS);
                    }
                }
                sbdListMac.Append(SEDConst.SPECIAL_CHARACTERS);
                sbdHardwareInfor.Append(sbdListMac);
            }
            return sbdHardwareInfor.ToString();
        }

        //TODO Comment
        public static void CheckConnect()
        {
            if (IsConnectedToInternet() == false)
            {
                SEDFuncCall.MessageWarning(SEDConst.MESSAGE_DISCONNECT_CHECK, SEDConst.MESSAGE_WARNING_DISCONNECTED);
                return;
            }
        }

        //TODO Comment
        public static void CheckConnectTimeOut()
        {
            if (IsConnectedToInternet() == false)
            {
                Thread.Sleep(5000);
                if (IsConnectedToInternet() == false)
                {
                    System.Windows.Forms.MessageBox.Show("Connect Timout!", SEDConst.MESSAGE_WARNING_DISCONNECTED);
                    return;
                }
            }
        }

        //TODO Comment
        public static bool CheckConnectTimeOutWait(DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager)
        {
            if (IsConnectedToInternet() == false)
            {
                splashScreenManager.ShowWaitForm();
                //TODO Set Constant
                splashScreenManager.SetWaitFormCaption("Checking the network connection!");
                splashScreenManager.SetWaitFormDescription(SEDConst.SET_PLEASE_WAIT);
                Thread.Sleep(7000);
                splashScreenManager.CloseWaitForm();
                if (IsConnectedToInternet() == false)
                {
                    //TODO Set Constant
                    DevExpress.XtraEditors.XtraMessageBox.Show("Connect Timout. Checking the network connection...!", SEDConst.MESSAGE_WARNING_DISCONNECTED);
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
