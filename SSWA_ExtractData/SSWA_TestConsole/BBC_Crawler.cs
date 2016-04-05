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
            //TestBBC_Content();
            //TestBBC_Img();
            //TestRegex3();
            TestRegex4();
            //GetFileName();
            //Directory.CreateDirectory(@"D:\Manh\DucTran");
            Console.ReadLine();
        }

        public static void TestRegex4()
        {
            var strInput = "http://i2.cdn.turner.com/cnnnext/dam/assets/150312114428-scott-walker-gallery-6-large-169.jpg";
            var strInput2 = "http://i2.cdn.turner.com/cnnnext/dam/assets/150312114521-scott-walker-gallery-9-super-169.jpg";
            //var patern = @"-\d+-(?<size>\w+)-\d+.jpg";
            var patern = @"(?<first>-\d+-)(?<size>\w+)(?<end>-\d+.jpg)";
            var reg = Regex.Match(strInput, patern);
            var strOutput = Regex.Replace(strInput, patern, m => m.Groups["first"] + "exlarge" + m.Groups["end"]);
            Console.WriteLine("Link mới là:- " + strOutput);
            //Console.WriteLine(Regex.Replace(strInput, patern, ""));
            //Console.WriteLine(Regex.IsMatch(strInput, patern));
            //Console.WriteLine(reg.Groups["size"].Value);
        }

        public static void TestRegex3()
        {
            var strInput = @"<div class='media-player-wrapper'>figer</div>What are you doing<div class='media-player-wrapper'>Alo Home Teahcher</div><h2>Pro</h2>";
            var patern = @"(<div class=[^<]media-player-wrapper[^<]*)(</div>)";
            var reg = new Regex(patern);
            Console.WriteLine(reg.IsMatch(strInput));
            Console.WriteLine(reg.Replace(strInput, ""));
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

        #region TestBBC
        public static void TestBBC_Content()
        {
            var contentData = ResultWebClient("http://www.bbc.com/news/magazine-35943598");
            var patern = string.Format("//div[@class='story-body']/h1");
            var patern2 = string.Format("//div[@class='story-body']/div[@class='story-body__inner']");
            var htmlNode = contentData.DocumentNode.SelectSingleNode(patern2);
            var lstNodeChildP = htmlNode.SelectNodes("//p");
            var sbdNewString = new StringBuilder();
            foreach (var item in lstNodeChildP)
            {
                Console.WriteLine(item.InnerText);
                sbdNewString.Append(item.InnerText).Append(Environment.NewLine);
            }

            var text = htmlNode.InnerText.Replace("\r\n\t", "").Replace("\n", "").Replace("\t", "");
            //var newText = TachChuoi(text);
            //Console.WriteLine(text);
            File.WriteAllText("data.txt", sbdNewString.ToString());
        }
        public static void TestBBC_Img()
        {
            var contentData = ResultWebClient("http://www.bbc.com/news/business-35958730");
            var patern = string.Format("//div[@class='story-body']/h1");
            var patern2 = string.Format("//div[@class='story-body']/div[@class='story-body__inner']");
            var htmlNode = contentData.DocumentNode.SelectSingleNode(patern2);
            var lstNodeChildP = htmlNode.SelectNodes("//figure/span/div");
            var sbdNewString = new StringBuilder();
            foreach (var item in lstNodeChildP)
            {
                var linkNew = ReplaceLink(item.Attributes["data-src"].Value);
                Console.WriteLine(linkNew);
                sbdNewString.Append(linkNew).Append(Environment.NewLine);
            }

            var text = htmlNode.InnerText.Replace("\r\n\t", "").Replace("\n", "").Replace("\t", "");
            //var newText = TachChuoi(text);
            //Console.WriteLine(text);
            File.WriteAllText("data.txt", sbdNewString.ToString());
        }
        #endregion

        #region TestCNN
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
        #endregion

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

        public static string ReplaceLink(string strInput)
        {
            var patern = @"/news/\d{3}/cpsprodpb/";
            var reg = new Regex(patern);
            return reg.Replace(strInput, "/news/624/cpsprodpb/");
        }
    }
}
