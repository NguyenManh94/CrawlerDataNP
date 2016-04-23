using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Diagnostics;

namespace SSWA_TestConsole
{
    internal class BBC_Crawler
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BufferHeight = 1000;
            #region Test Old 03-2016
            //TestImgCraw();
            //TestRegex2();
            //TestBBC_Content();
            //TestBBC_Img();
            //TestRegex3();
            //TestRegex4();
            //TestMatches();
            //GetAllProperties();
            //GetAllField();
            //GetFileName();
            //Directory.CreateDirectory(@"D:\Manh\DucTran"); 
            #endregion
            //Console.WriteLine(ContentTestCNN());
            //ImageTestCNN();

            GetAllImgHideVideo();
            TestBBC_Content1();
            Console.ReadLine();
        }

        #region Test CNN
        protected static string ContentTestCNN()
        {
            var sbdContent = new StringBuilder();
            var htmlDocument = ResultWebClient(@"http://edition.cnn.com/2016/03/25/us/oldest-cold-case-conviction-overturned-maria-ridulph-taken/index.html");
            var xpathHeader = @"//div[@class='el__leafmedia el__leafmedia--sourced-paragraph']";
            var xpathHeaderContent = @"//div[@class='pg-rail-tall__body']/section/div[@class='l-container']/div[@class='zn-body__paragraph']";
            var xpathContenPage = @"//div[@class='zn-body__read-all']/div[@class='zn-body__paragraph']";
            var headSummary = htmlDocument.DocumentNode.SelectSingleNode(xpathHeader).InnerText;
            sbdContent.Append(headSummary).Append("\r\n");
            var listReadAll = htmlDocument.DocumentNode.SelectNodes(xpathContenPage);
            var listHeader = htmlDocument.DocumentNode.SelectNodes(xpathHeaderContent);
            foreach (var item in listHeader)
            {
                sbdContent.Append("  ").Append(item.InnerText).Append("\r\n");
            }
            sbdContent.Append("===================================== Reader All =============================================\r\n");
            foreach (var item in listReadAll)
            {
                sbdContent.Append("  ").Append(item.InnerText).Append("\r\n");
            }
            return sbdContent.ToString().Trim();
        }

        protected static void ImageTestCNN()
        {
            var htmlDocument = ResultWebClient(@"http://edition.cnn.com/2016/04/19/motorsport/lewis-hamilton-formula-one-nico-rosberg/index.html");
            var xpathHeaderContent = @"//div[@class='zn-body__read-all']";
            var nodeCha = htmlDocument.DocumentNode.SelectSingleNode(xpathHeaderContent).InnerHtml;
            var pattern = @"<img.*?>";
            var lstImg = Regex.Matches(nodeCha, pattern);
            var hsImg = new HashSet<string>();
            var paternReplace = @"(?<first>-\d+-)(?<size>\w+)(?<end>-\d+.jpg)";
            foreach (var item in lstImg)
            {
                if (item.ToString().Length < 500)
                {
                    var text = Regex.Match(item.ToString(), "src=\"(?<link>.*?)\"").Groups["link"].Value;
                    if (!text.Contains("small") && !text.Contains("medium"))
                    {
                        if (text.Contains("large") || text.Contains("exlarge"))
                            hsImg.Add(Regex.Replace(text, @"large|exlarge", "super"));
                        else hsImg.Add(text);
                    }
                }
            }
            //var sbd = new StringBuilder();
            var wc = new WebClient();
            var i = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var sbd = new StringBuilder();
            try
            {
                foreach (var item in hsImg)
                {
                    wc.DownloadFile(item, sbd.Append(@"D:\New folder\anh").Append(i).Append(".jpg").ToString());
                    sbd.Clear();
                    i++;
                }
            }
            catch (System.Net.WebException) { Console.WriteLine("KHông chưa file"); }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine("Tải xuống thành công");
        }

        private static void TestRegexDiv()
        {
            var path = Environment.CurrentDirectory + "/../../What/data3.txt";
            var content = File.ReadAllText(path, Encoding.UTF8);
            var pattern = "<div class=\"el__leafmedia el__leafmedia--storyhighlights\">((<div>.*?</div>)*|.*?)*</div>";
            var strOutput = Regex.Split(content, pattern);
            Console.WriteLine(Regex.IsMatch(content, pattern));
            Console.WriteLine(strOutput[3]);
        }
        #endregion

        #region TestBBC
        public static void SplitImg()
        {
            //var htmlDocument = ResultWebClient("http://www.bbc.com/news/entertainment-arts-36108133");
            //var textContent = htmlDocument.DocumentNode.SelectSingleNode("//body").InnerHtml;
            //File.WriteAllText("dataBBC.txt", textContent);
            var text = File.ReadAllText(Environment.CurrentDirectory + "/../../What/data4.txt");
            var pattern = "unProcessedImageUrl\":\"(?<link>.*?jpg)";
            var reg = Regex.Match(text, pattern).Groups["link"].Value;
            Console.WriteLine(reg.Replace(@"\", ""));
            //File.WriteAllText("img.txt", reg.Replace(@"\", ""));
        }

        public static void GetAllImgHideVideo()
        {
            var htmlDocument = ResultWebClient("http://www.bbc.com/news/world-us-canada-36108593");
            var lstImgVideo = htmlDocument
                .DocumentNode.SelectNodes("//figure[@class='media-with-caption']/div[@class='media-player-wrapper']");
            Console.WriteLine(lstImgVideo.Count);
            var pattern = "(unProcessedImageUrl|unprocessedimageurl)\":\"(?<link>.*?jpg)";
            var sbd = new StringBuilder();
            foreach (var item in lstImgVideo)
            {
                var reg = Regex.Match(item.InnerHtml, pattern).Groups["link"].Value.Replace(@"\", "");
                Console.WriteLine(reg);
                sbd.Append(reg).Append("\r\n");
            }
            Console.WriteLine("=================================================");
            var lstImg = htmlDocument.DocumentNode.SelectNodes("//figure/span[@class='image-and-copyright-container']/div");
            foreach (var item in lstImg)
            {
                Console.WriteLine(Regex.Replace(item.Attributes["data-src"].Value, @"news/\d{3}/cpsprodpb", @"news/624/cpsprodpb"));
                sbd.Append(Regex.Replace(item.Attributes["data-src"].Value
                    , @"news/\d{3}/cpsprodpb", @"news/624/cpsprodpb")).Append("\r\n");
            }

            File.WriteAllText("img.txt", sbd.ToString());
        }

        public static void TestBBC_Content1()
        {
            var contentData = ResultWebClient("http://www.bbc.com/news/magazine-35943598");
            //var patern = "//div[@class=\'story-body\']/h1";
            var patern2 = "//div[@class=\'story-body\']/div[@class=\'story-body__inner\']";
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

        public static void TestBBC_Img1()
        {
            var contentData = ResultWebClient("http://www.bbc.com/news/business-35958730");
            var patern = "//div[@class=\'story-body\']/h1";
            var patern2 = "//div[@class='story-body']/div[@class=\'story-body__inner\']";
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

        #region TestOld 03-2016

        #region TestRegex
        public static void TestMatches()
        {
            //var pattern2 = "src=\"(?<address>/data/photos/\\w{32}/large-\\w{32}.jpg)\" alt=\"(?<fileName>[^\"]+)\"";
            var path = new StringBuilder(Environment.CurrentDirectory).Append("/../../What/test2.txt").ToString();
            var strContent = File.ReadAllText(path);
            //var pattern = @"<ul class=[\.]links links-categories[\.]><li><a\.*>(?<TagTitle>\w+)</a></li></ul>";
            //var pattern = @"(<ul\sclass=[^<]links\slinks-categories[^<]\s*>)";

            //var strContent = "<ul class=\"links links-categories\"><a href=\"movie/amateur.html\" title=\"Amateur\" class=\"btn btn-sm btn-default\">Amateur</a></ul><h1>Tôi là ai</h1>";
            var strNew = Regex.Replace(strContent, @"\r\n|\v|\t|\s+", " ");
            var pattern = "<ul\\sclass=\"links\\slinks-categories\">(?<content>.*?)</ul>";
            //var pattern = "<ul class=\"links links-categories\">(?<content>.*?)</ul>";
            Console.WriteLine(Regex.IsMatch(strNew, pattern));
            var count = Regex.Matches(strNew, pattern);
            Console.WriteLine(count.Count);
            var content = Regex.Matches(strNew, pattern)[0].Groups["content"].Value;

            foreach (Match match in Regex.Matches(content, "<li><a.*?>(?<title>.*?)</a></li>"))
            {
            }
            //var reg = Regex.Matches(strContent, pattern);
            //foreach (Match item in reg)
            //{
            //    Console.WriteLine(item.Value);
            //}
        }

        //Lấy ra tất các các thuộc tính có trong 1 lơp
        private static void GetAllProperties()
        {
            var ts = new Test();
            var lstProperties = ts.GetType().GetProperties();
            foreach (var item in lstProperties)
            {
                Console.WriteLine(item.Name);
            }
        }

        //Lấy ra tất cả trường có trong 1 lớp
        private static void GetAllField()
        {
            var gn = new GetNameProperties();
            var lstField = gn.GetType().GetFields();
            foreach (var item in lstField)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void TestRegex4()
        {
            var strInput =
                "http://i2.cdn.turner.com/cnnnext/dam/assets/150312114428-scott-walker-gallery-6-large-169.jpg";
            var strInput2 =
                "http://i2.cdn.turner.com/cnnnext/dam/assets/150312114521-scott-walker-gallery-9-super-169.jpg";
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
            //var pattern = "src=\"(?<address>/data/photos/\\w{32}/large-\\w{32}.jpg)\" alt=\"(?<fileName>[^\"]+)\"";
            var strInput =
                @"<div class='media-player-wrapper'>figer</div>What are you doing<div class='media-player-wrapper'>Alo Home Teahcher</div><h2>Pro</h2>";
            var patern = @"(<div class=[^<]media-player-wrapper[^<]*)(</div>)";
            var reg = new Regex(patern);
            Console.WriteLine(reg.IsMatch(strInput));
            Console.WriteLine("Toi in ra: " + reg.Replace(strInput, ""));
        }
        #endregion

        public static void GetFileName()
        {
            var file = Environment.CurrentDirectory + "/../../What/test.txt";
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
            wc.Headers.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36");
            var result = wc.DownloadString(url);
            var htmlDecode = WebUtility.HtmlDecode(result);
            var removeScript = SampleMatches(htmlDecode);
            var hdoc = new HtmlDocument();
            hdoc.LoadHtml(removeScript);
            return hdoc;
        }

        #region TestCNN
        public static void TestCNN()
        {
            var contentData =
                ResultWebClient(
                    "http://edition.cnn.com/2016/03/25/us/oldest-cold-case-conviction-overturned-maria-ridulph-taken/index.html");
            var patern = "//div[@class=\'story-body\']/h1";
            var patern2 = "//div[@class='pg-rail-tall__body']";
            var htmlNode = contentData.DocumentNode.SelectSingleNode(patern2);
            var text = htmlNode.InnerText;
            Console.WriteLine(text);
            File.WriteAllText("data.txt", text);
        }

        #endregion

        public static string SampleMatches(string strInput)
        {
            //link: http://stackoverflow.com/questions/6659351/removing-all-script-tags-from-html-with-js-regular-expression
            const string patern2 = @"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>";
            var reg = new Regex(patern2);
            return reg.Replace(strInput, "");
        }

        public static void TestImgCraw()
        {
            var contentData = ResultWeb("http://www.bbc.com/vietnamese/world/2016/03/160326_jia_jia_xi_letter_released");
            var patern = "//div[@class=\'story-body\']/h1";
            var patern2 = "//img";
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
                catch
                {
                    // ignored
                }
            }
        }

        private static string ReplaceLink(string strInput)
        {
            var patern = @"/news/\d{3}/cpsprodpb/";
            var reg = new Regex(patern);
            return reg.Replace(strInput, "/news/624/cpsprodpb/");
        }

        private static void NewMethod()
        {
            var lstInfoNew = new List<Tuple<string, int>> { new Tuple<string, int>("NguyenManh", 22) };
        }

        #endregion
    }
}