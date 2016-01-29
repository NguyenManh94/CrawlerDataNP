using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Xml;

namespace SSWA_ConsoleTestData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BufferHeight = 300;
            TestDecode();

            Console.ReadLine();
        }

        public static string TestDecode()
        {
            WebClient wc = new WebClient { Encoding = Encoding.UTF8 };
            wc.Headers.Add("UserAgen", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36");
            var strContent = wc.DownloadString("http://vnexpress.net/rss/the-thao.rss");
            var strTest = WebUtility.HtmlDecode(strContent);
            return strTest;
        }

        public static void TachData()
        {
            var strData = TestDecode();
            //var node = strData.
        }
    }
}
