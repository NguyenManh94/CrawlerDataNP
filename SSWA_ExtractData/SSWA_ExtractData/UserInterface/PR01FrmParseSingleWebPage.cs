using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using HtmlAgilityPack;
using PermissionContext;
using SSWA_ExtractData.Common;
using SSWA_ExtractData.Common.Constant;
using SSWA_ExtractData.Common.Security;
using SSWA_ExtractData.Entity;

//TODO Comment Form ParseSingleWebPage

namespace SSWA_ExtractData.UserInterface
{
    // ReSharper disable once InconsistentNaming
    public sealed partial class PR01FrmParseSingleWebPage : XtraForm
    {
        private int _idCateChoice;
        private int _index;
        private int _index2;

        public PR01FrmParseSingleWebPage()
        {
            InitializeComponent();
        }

        private void FrmParseSingleWebPage_Load(object sender, EventArgs e)
        {
            LoadInforHardware();
        }

        private void LoadInforHardware()
        {
            // Use ExtensionMethod
            var dcHardwareInfor = SEDFuncCall.InforHardware();
            lblMachineName.Text = lblMachineName.Text.SetString(dcHardwareInfor[SEDKeys.MachineName]);
            lblVersion.Text = lblVersion.Text.SetString(dcHardwareInfor[SEDKeys.Version]);
            lblPrecessorCount.Text = lblPrecessorCount.Text.SetString(dcHardwareInfor[SEDKeys.Processorcount]);
            lblOsVersion.Text = lblOsVersion.Text.SetString(dcHardwareInfor[SEDKeys.Osversion]);
            lblCPU_Speed.Text = lblCPU_Speed.Text.SetString(dcHardwareInfor[SEDKeys.CpuSpeed]);
            lblCpuMarker.Text = lblCpuMarker.Text.SetString(dcHardwareInfor[SEDKeys.CpuMarker]);
            lblPhysiccalMemory.Text = lblPhysiccalMemory.Text.SetString(dcHardwareInfor[SEDKeys.PhysicalMemory]);
        }

        private void pictureEditReload_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManagerWebPage.ShowWaitForm();
                splashScreenManagerWebPage.SetWaitFormCaption(SEDConst.SET_PLEASE_WAIT);
                using (var permissionContext = new PermissionDataContext())
                {
                    cbEditCate.Properties.Items.Clear();
                    cbChoiceSiteCate.DataSource = null;
                    cbChoiceSiteCate.Items.Clear();
                    var cateStore = permissionContext.RssPages.Where(a => a.DisplayMode == 1)
                        .Select(c => new {c.Id, Name = c.Name.Trim()});
                    cbChoiceSiteCate.DataSource = cateStore;
                    cbChoiceSiteCate.DisplayMember = "Name";
                    cbChoiceSiteCate.ValueMember = "Id";
                    foreach (var item in cateStore)
                    {
                        cbEditCate.Properties.Items.Add(item.Name);
                    }
                    cbEditCate.SelectedIndex = 0;
                    cbEditCate_SelectedIndexChanged(sender, e);
                    cbChoiceSiteCate_SelectedIndexChanged(sender, e);
                }
                splashScreenManagerWebPage.CloseWaitForm();
            }
            catch (Exception ex)
            {
                SEDFuncCall.MessageWarning(ex.Message, SEDConst.TITLE_WARNING);
            }
        }

        private void cbChoiceSiteCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbChoiceSiteCate.Text.Equals(SEDConst.STRING_EMPTY)
                    || cbChoiceSiteCate.Text.Equals("PermissionContext.RssPage")
                    || cbChoiceSiteCate.SelectedValue.Equals("PermissionContext.RssPage"))
                    return;
                try
                {
                    using (var permissionContext = new PermissionDataContext())
                    {
                        //TODO Constanst
                        var intIdCate = Convert.ToInt16(cbChoiceSiteCate.SelectedValue);
                        var inforCate = permissionContext.RssMenuPages.Join(
                            permissionContext.RssPages,
                            rmp => rmp.IdRssPage,
                            rp => rp.Id,
                            (rp, rmp) => new TopicData
                            {
                                IdSet = (int) rmp.Id,
                                TopicName = rmp.Name + "> " + rp.Name,
                                Link = rp.Link.Replace("(", "").Replace(")", "")
                            }
                            ).Where(a => a.IdSet == intIdCate);
                        lblCateDynamic.Text = cbEditCate.Text;
                        lblTotalDynamic.Text = inforCate.ToList().Count.ToString();
                        gcShowCateInfor.DataSource = inforCate;
                    }
                }
                catch
                {
                    /* ignored*/
                }
            }
            catch
            {
                /* ignored*/
            }
        }

        private void gvShowCateInfor_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            _index = e.FocusedRowHandle;
        }

        private void LoadData(string url)
        {
            #region Pending

            //var htmlDocument = ResultWebClient("http://www.24h.com.vn/upload/rss/tintuctrongngay.rss");
            //List<Feeds> query2 = htmlDocument.DocumentNode.SelectNodes("//item")
            //    .Select(a => new Feeds
            //    {
            //        Title = a.Element("title").InnerText,
            //        //Link = a.Element("link").InnerText
            //        //PubDate = a.Element("pubDate").InnerText,
            //        Description = a.Element("description").InnerText
            //    }).ToList();
            //var query = new List<Feeds>();
            //var test = htmlDocument.DocumentNode.SelectNodes("//item");
            //foreach (var item in test)
            //{
            //    var x = item.Element("title").InnerText;
            //    query.Add(new Feeds { Title = x });
            //}
            //================= Not Use Bescause Ignore Exception
            //var lstFeeds = xDoc.Descendants("item").Select(a => new Feeds
            //{
            //    Title = a.Element("title").Value,
            //    Link = a.Element("link").Value,
            //    PubDate = a.Element("pubDate").Value,
            //    Image = SplitSrc(a.Element("description").Value),
            //    Description = Description(a.Element("description").Value)
            //});

            //gcShowFeeds.DataSource = query;

            #endregion

            try
            {
                // CheckConnect Internet
                var checkConnect = SEDInternetConnection.CheckConnectTimeOutWait(splashScreenManagerWebPage);
                if (checkConnect == false) return;

                splashScreenManagerWebPage.ShowWaitForm();
                splashScreenManagerWebPage.SetWaitFormCaption(SEDConst.SET_PLEASE_WAIT);
                var xDoc = XDocument.Load(url);
                var xDataRss = xDoc.Descendants("item");
                var lstFeeds = new List<Feeds>();
                foreach (var nodeItem in xDataRss)
                {
                    try
                    {
                        var xElement = nodeItem.Element("title");
                        if (xElement != null)
                        {
                            var feed = new Feeds
                            {
                                Title = xElement.Value.ReplaceNew().Trim(),
                                Link = nodeItem.Element("link").Value.Trim(),
                                PubDate = nodeItem.Element("pubDate").Value,
                                Image = SplitSrc(nodeItem.Element("description").Value),
                                Description = Description(nodeItem.Element("description").Value)
                            };
                            lstFeeds.Add(feed);
                        }
                    }
                    catch (NullReferenceException)
                    {
                    }
                }
                gcShowFeeds.DataSource = lstFeeds;
                lblChildCateDynamic.Text = gvShowCateInfor.GetRowCellValue(_index, "TopicName").ToString();
                lblTotalChildDynamic.Text = lstFeeds.Count.ToString();
                splashScreenManagerWebPage.CloseWaitForm();
            }
            catch (NotSupportedException)
            {
                splashScreenManagerWebPage.CloseWaitForm();
                SEDFuncCall.MessageWarning(SEDConst.MESSAGE_LINK_INVALID, SEDConst.TITLE_WARNING);
            }
            catch (Exception ex)
            {
                splashScreenManagerWebPage.CloseWaitForm();
                SEDFuncCall.MessageWarning(ex.Message, SEDConst.TITLE_WARNING);
            }
        }

        private string SplitSrc(string input)
        {
            var reg = new Regex("src\\s*=\\s*[\"']([^\"']+)[\"']+");
            return reg.Match(input).Groups[1].ToStringNew();
        }

        private static string Description(string input)
        {
            var reg = new Regex("<.*>");
            return reg.Replace(input, "").ToStringNew();
        }

        /*Load Web*/

        private HtmlDocument ResultWebClient(string url)
        {
            var wc = new WebClient {Encoding = Encoding.UTF8};
            wc.Headers.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Class1.csSafari/537.36");
            var result = wc.DownloadString(url);
            var htmlDecode = WebUtility.HtmlDecode(result);
            var hdoc = new HtmlDocument();
            hdoc.LoadHtml(htmlDecode);
            return hdoc;
        }

        private void gvShowFeeds_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            _index2 = e.FocusedRowHandle;
        }

        private void btnEditView_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                var checkConnect = SEDInternetConnection.CheckConnectTimeOutWait(splashScreenManagerWebPage);
                if (checkConnect == false) return;
                var getLink = gvShowFeeds.GetRowCellValue(_index2, "Link").ToString();
                var frmViewPosts = new PR03FrmViewPosts
                {
                    Title = gvShowFeeds.GetRowCellValue(_index2, "Title").ToString(),
                    Link = gvShowFeeds.GetRowCellValue(_index2, "Link").ToString(),
                    PubDate = gvShowFeeds.GetRowCellValue(_index2, "PubDate").ToString(),
                    Image = gvShowFeeds.GetRowCellValue(_index2, "Image").ToString(),
                    Description = gvShowFeeds.GetRowCellValue(_index2, "Description").ToString(),
                    Content = GetPatern(getLink),
                    IdScategories = _idCateChoice
                };
                frmViewPosts.Show();
            }
            catch
            {
                /* ignored*/
            }
        }

        private string DownLoadContent(string url, string xpath)
        {
            try
            {
                var htmlDocument = ResultWebClient(url);
                return htmlDocument.DocumentNode.SelectSingleNode(xpath).InnerHtml;
            }
            catch (NotSupportedException)
            {
                SEDFuncCall.MessageWarning(SEDConst.MESSAGE_LINK_INVALID, SEDConst.TITLE_WARNING);
                return SEDConst.STRING_EMPTY;
            }
            catch (XPathException)
            {
                SEDFuncCall.MessageWarning(SEDConst.MESSAGE_EROR_XPATH, SEDConst.TITLE_WARNING);
                return SEDConst.STRING_EMPTY;
            }
            catch (Exception ex)
            {
                SEDFuncCall.MessageWarning(ex.Message, SEDConst.TITLE_WARNING);
                return SEDConst.STRING_EMPTY;
            }
        }

        private string GetPatern(string url)
        {
            var xpath = "";
            switch (_idCateChoice)
            {
                case 1:
                    xpath = "//div[@class='fck_detail width_common']";
                    break;
                case 2:
                    xpath = "//div[@class='text-conent']";
                    break;
                case 3:
                    xpath = "//div[@id='divNewsContent']";
                    break;
                case 4:
                    xpath = "//div[@class='maincontent']";
                    break;
                case 5:
                    xpath = "//div[@class='pg-rail-tall__body']/section/div[@class='l-container']";
                    break;
            }
            return DownLoadContent(url, xpath);
        }

        private void cbEditCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbChoiceSiteCate.SelectedIndex = cbEditCate.SelectedIndex;
            }
            catch
            {
                /* ignored*/
            }
        }

        private void gvShowCateInfor_Click(object sender, EventArgs e)
        {
        }

        private void btnShowListData_Click(object sender, EventArgs e)
        {
            //TODO Constanst
            try
            {
                //TODO Set "idCateChoice" here because the information will derive precise categories
                _idCateChoice = Convert.ToInt16(cbChoiceSiteCate.SelectedValue);
                var getLink = gvShowCateInfor.GetRowCellValue(_index, "Link").ToString();
                LoadData(getLink);
            }
            catch
            {
                SEDFuncCall.MessageWarning(SEDConst.MESSAGE_CLICK_GRIDVIEW, SEDConst.TITLE_WARNING);
            }
        }
    }
}