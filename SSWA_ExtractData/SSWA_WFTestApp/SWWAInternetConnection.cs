using System.Runtime.InteropServices;

namespace SSWA_WFTestApp
{
    class SWWAInternetConnection
    {
        /// <summary>
        /// Create By: ManhNV -Date: 02/25/2016
        /// </summary>
        /// <param name="description">out int </param>
        /// <param name="reservedValue"></param>
        /// <returns></returns>
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);
        public static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
    }
}
