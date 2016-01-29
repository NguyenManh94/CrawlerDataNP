using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace SSWA_TestExtractData
{
    public partial class frmDemo : Form
    {
        public frmDemo()
        {
            InitializeComponent();
        }

        private void btnSelectMenuData_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            ListUnitMenu();
            //Test();
        }

        /*Load DataWeb*/
        public HtmlAgilityPack.HtmlDocument ResultWeb(string url)
        {
            var hw = new HtmlWeb
            {
                UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36",
                OverrideEncoding = Encoding.UTF8
            };
            return hw.Load(url);
        }

        /*Select NodeList vs Xpath*/
        public HtmlNodeCollection SelectNodes(string url, string xpath)
        {
            var htmlDocument = ResultWeb(url);
            return htmlDocument.DocumentNode.SelectNodes(xpath);
        }

        /*Load MenuData Vn Express*/
        public List<Tuple<string, string>> ListUnitMenu()
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("Đang phân tích dữ liệu");
            var htmlDocument = ResultWeb("http://vnexpress.net/");
            //var htmlNodeListCate = htmlDocument.DocumentNode.SelectNodes("//ul[@id='menu_web']/li[not(@*) ]");


            //var delete1 = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='menu_web']/li[1]");
            //delete1.ParentNode.RemoveChild(delete1);
            //var delete = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='menu_web']/li[16]");
            //delete.ParentNode.RemoveChild(delete);
            //var delete2 = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='menu_web']/li[17]");
            //delete2.ParentNode.RemoveChild(delete2);

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                var delete1 = htmlDocument.DocumentNode.SelectSingleNode(listBox1.Items[i].ToString());
                delete1.ParentNode.RemoveChild(delete1);
            }


            var htmlNodeListCate = htmlDocument.DocumentNode.QuerySelectorAll("ul#menu_web > li").ToList();
            var lstTemp = new List<Tuple<string, string>>();
            for (int i = 0; i < htmlNodeListCate.Count; i++)
            {
                //var x = htmlNodeListCate[i].QuerySelector("a").Attributes["href"].Value;
                lstTemp.Add(Tuple.Create(
                    "http://vnexpress.net" + htmlNodeListCate[i].QuerySelector("a").Attributes["href"].Value,
                    htmlNodeListCate[i].QuerySelector("a").InnerText
                    ));
            }
            var lstTEmp2 = new List<Tuple<string, string, string, string, string>>();
            //for (int i = 0; i < lstTemp.Count; i++)
            for (int i = 0; i < 1; i++)
            {
                var htmlDocument2 = ResultWeb(lstTemp[i].Item1);
                var htmlNodeList2 = htmlDocument2.DocumentNode.QuerySelectorAll("ul.list_news > li").ToList();
                //var lstTEmp2 = new List<Tuple<string, string, string, string, string>>();
                //for (int j = 0; j < htmlNodeList2.Count; j++)
                for (int j = 0; j < 1; j++)
                {
                    //var htmlDocument3 = ResultWeb(htmlNodeList2[j].QuerySelector("div.title_news a.txt_link").Attributes["href"].Value);
                    var htmlDocument3 = ResultWeb("http://kinhdoanh.vnexpress.net/tin-tuc/doanh-nghiep/oto-nhap-khau-tang-gia-ca-ty-dong-3340259.html");
                    var htmlNodeList3 = "";
                    try
                    {
                        htmlNodeList3 = htmlDocument3.DocumentNode
                            .SelectSingleNode("//div[@class='fck_detail width_common']").InnerHtml;
                        if (htmlNodeList3.Length < 2100)
                        {
                            htmlNodeList3 = htmlDocument3.DocumentNode
                            .SelectSingleNode("//div[@id='article_content']").InnerHtml;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        try
                        {
                            htmlNodeList3 = htmlDocument3.DocumentNode
                                .SelectSingleNode("//div[@id='article_content']").InnerHtml;
                        }
                        catch (NullReferenceException)
                        {
                            htmlNodeList3 = htmlDocument3.DocumentNode
                            .SelectSingleNode("//div[@class='fck_detail width_common']").InnerHtml;
                        }
                    }
                    lstTEmp2.Add(Tuple.Create(
                       htmlNodeList2[j].QuerySelector("div.title_news a.txt_link").InnerText,
                       htmlNodeList2[j].QuerySelector("div.title_news a.txt_link").Attributes["href"].Value,
                       htmlNodeList2[j].QuerySelector("div.thumb a img").Attributes["src"].Value,
                       htmlNodeList2[j].QuerySelector("div.news_lead").InnerText,
                       htmlNodeList3
                        ));
                }
                var lstTest = lstTEmp2;

            }

            //webBrowser1.DocumentText = lstTEmp2[0].Item5;
            var sbd = new StringBuilder();
            sbd.Append(lstTEmp2[0].Item5);
            sbd.Append("<div><p style='font-style:italic;font-weight:bold;font-size:15px;'>Nguồn Dân Trí.Com</p></div>");
            webBrowser1.DocumentText = sbd.ToString();
            /*Lấy thông tin trong từng trang*/

            //var sbd = new StringBuilder();
            //for (int i = 0; i < lstTemp.Count; i++)
            //{
            //    sbd.Append(lstTemp[i].Item1 + "  " + lstTemp[i].Item2 + "\r\n");
            //}
            //rtbShowData.Text = sbd.ToString();
            splashScreenManager1.CloseWaitForm();
            return lstTemp;
        }

        public void Test()
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };

            //Load trang web, nạp html vào document
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load("http://www.webtretho.com/forum/f26/");
            var threadItems = document.DocumentNode.QuerySelectorAll("ul#stickies > li").ToList();

            var obj = new List<object>();

            foreach (var item in threadItems)
            {
                var linkNode = item.QuerySelector("a.title");
                var link = linkNode.Attributes["href"].Value;
                var text = linkNode.InnerText;
                //var test = linkNode.InnerHtml;
                //var xxx = linkNode.QuerySelector("h3").InnerHtml;
                var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;

                obj.Add(new { link, text, readCount });
            }
            var x = obj;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //SplashScreen1 slc = new SplashScreen1();
            //slc.Text = "1234434343";
            //slc.ShowDialog();

            webBrowser2.DocumentText = "http://img.f28.kinhdoanh.vnecdn.net/2016/01/10/o-to-nhap-khau-1960-1429863448-4216-1452390967_180x108.jpg";
        }

        //String strTest = "<div class='news_lead' data-mobile-href='http://thethao.vnexpress.net/tin-tuc/tuong-thuat/diego-costa-toa-sang-chelsea-thang-tran-dau-cung-hiddink-3336958.html'>Các pha lập công của Oscar, Willian và Diego Costa giúp Chelsea giành chiến thắng 3-0 trong trận derby thành London với Crystal Palace.</div>";
    }
}
