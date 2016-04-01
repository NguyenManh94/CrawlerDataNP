using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SSWA_TestConsole
{
    class BBC_Crawler
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BufferHeight = 1000;
            //TestImgCraw();
            //TestRegex2();
            //TestCNN();
            GetFileName();
            Directory.CreateDirectory(@"D:\Manh\DucTran");
            Console.ReadLine();
        }

        public static void GetFileName()
        {
            string file = Environment.CurrentDirectory + "/../../What/test.txt";
            var fileInfor = new FileInfo(file);
            var fileInfor2 = new FileInfo(@"D:\" + fileInfor.Name);
            if (fileInfor2.Exists == false)
            //if (!Directory.Exists(@"D:\" + fileInfor.Name))
            {
                Directory.CreateDirectory(@"D:\Folder");
                fileInfor.CopyTo(@"D:\" + fileInfor.Name, true);
                Console.WriteLine(@"D:\" + fileInfor.Name);
            }
            else
                Console.WriteLine("Đã tạo rồi");
            var path = Environment.CurrentDirectory + @"App_Data\DataPermission.db";
            var path2 = @"D:\FsoferProject";
            Console.WriteLine(Directory.Exists(path2));
            Console.WriteLine(path);
        }

        public static void CheckCreateFile()
        {
            var path = Environment.CurrentDirectory + @"App_Data\DataPermission.db";
            if (!Directory.Exists(path))
            {

            }
            else
                Console.WriteLine("Tệp tin này đã được tạo");
        }

        public static HtmlDocument ResultWeb(string url)
        {
            return new HtmlWeb
            {
                UserAgent = @"Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 
                            (KHTML, like Gecko) Chrome/49.0.2623.87 Safari/537.36",
                OverrideEncoding = Encoding.UTF8
            }.Load(url);
        }

        private static HtmlDocument ResultWebClient(string url)
        {
            var wc = new WebClient { Encoding = Encoding.UTF8 };
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36");
            var result = wc.DownloadString(url);
            var htmlDecode = WebUtility.HtmlDecode(result);
            var removeScript = SampleMatches(htmlDecode);
            var hdoc = new HtmlDocument();
            hdoc.LoadHtml(removeScript);
            return hdoc;
        }

        public static void TestBBC()
        {
            var contentData = ResultWeb("http://www.bbc.com/vietnamese/vietnam/2016/03/160322_hrw_basam");
            var patern = string.Format("//div[@class='story-body']/h1");
            var patern2 = string.Format("//div[@class='story-body']/div[@class='story-body__inner']");
            var htmlNode = contentData.DocumentNode.SelectSingleNode(patern2);
            var text = htmlNode.InnerText.Replace("\r\n", "").Replace("\n", "");
            var newText = TachChuoi(text);
            Console.WriteLine(newText);
            File.WriteAllText("data.txt", newText);
        }

        public static void TestCNN()
        {
            var contentData = ResultWebClient("http://edition.cnn.com/2016/03/25/us/oldest-cold-case-conviction-overturned-maria-ridulph-taken/index.html");
            var patern = string.Format("//div[@class='story-body']/h1");
            var patern2 = string.Format("//div[@class='pg-rail-tall__body']");
            var htmlNode = contentData.DocumentNode.SelectSingleNode(patern2);
            var text = htmlNode.InnerText;
            Console.WriteLine(text);
            File.WriteAllText("data.txt", text);
        }

        public static string SampleMatches(string strInput)
        {
            //link: http://stackoverflow.com/questions/6659351/removing-all-script-tags-from-html-with-js-regular-expression
            var patern2 = @"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>";
            var reg = new Regex(patern2);
            return reg.Replace(strInput, "");
        }

        public static void TestImgCraw()
        {
            var contentData = ResultWeb("http://www.bbc.com/vietnamese/world/2016/03/160326_jia_jia_xi_letter_released");
            var patern = string.Format("//div[@class='story-body']/h1");
            var patern2 = string.Format("//img");
            var htmlNode = contentData.DocumentNode.SelectNodes(patern2);
            var wc = new WebClient();
            var x = 0;
            foreach (var item in htmlNode)
            {
                try
                {
                    Console.WriteLine(item.Attributes["src"].Value);
                    wc.DownloadFile(item.Attributes["src"].Value, @"D:\anh" + x + ".jpg");
                    Console.WriteLine("Ảnh " + x + "Thành công");
                    x++;
                }
                catch { continue; }
            }
        }



        public static string TachChuoi(string input)
        {
            //var reg = new Regex("<script.*/script>");
            var reg = new Regex("/**/.*");
            return reg.Replace(input, "");
        }

        public static void TestRegex2()
        {
            var strInput = "/ws/660/amz/xxx";
            var patern = @"[/ws/]\d+";
            var reg = new Regex(patern);
            foreach (string result in Regex.Split(strInput, patern))
            {
                Console.WriteLine("{0}", result);
            }
        }
    }
}
