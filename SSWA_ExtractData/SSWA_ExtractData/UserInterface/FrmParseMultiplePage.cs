using System;
using System.Collections.Generic;
using System.Linq;
using SSWA_ExtractData.Common.Constant;
using PermissionContext;
using SSWA_ExtractData.Entity;
using SSWA_ExtractData.Common.Security;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using System.Net;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Text;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using System.Xml;
using SSWA_ExtractData.Common;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;

//TODO Comment
namespace SSWA_ExtractData.UserInterface
{
    public partial class FrmParseMultiplePage : XtraForm
    {
        public FrmParseMultiplePage() { InitializeComponent(); }

        private void FrmParseMultiplePage_Load(object sender, EventArgs e)
        {
            LoadInforHardware();
        }

        private void LoadInforHardware()
        {
            // Use ExtensionMethod
            var dcHardwareInfor = SEDFuncCall.InforHardware();
            lblMachineName.Text = lblMachineName.Text
            .SetString(dcHardwareInfor[SEDKeys.MachineName]);
            lblVersion.Text = lblVersion.Text.SetString(dcHardwareInfor[SEDKeys.Version]);
            lblPrecessorCount.Text = lblPrecessorCount.Text
                .SetString(dcHardwareInfor[SEDKeys.Processorcount]);
            lblOsVersion.Text = lblOsVersion.Text.SetString(dcHardwareInfor[SEDKeys.Osversion]);
            lblCPU_Speed.Text = lblCPU_Speed.Text.SetString(dcHardwareInfor[SEDKeys.CpuSpeed]);
            lblCpuMarker.Text = lblCpuMarker.Text.SetString(dcHardwareInfor[SEDKeys.CpuMarker]);
            lblPhysiccalMemory.Text = lblPhysiccalMemory.Text
                .SetString(dcHardwareInfor[SEDKeys.PhysicalMemory]);
        }

        private void pictureEditReload_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManagerMultiplePage.ShowWaitForm();
                splashScreenManagerMultiplePage.SetWaitFormCaption(SEDConst.SET_PLEASE_WAIT);
                using (var permissionContext = new PermissionDataContext())
                {
                    cbEditCate.Properties.Items.Clear();
                    cbChoiceSiteCate.DataSource = null;
                    cbChoiceSiteCate.Items.Clear();
                    var cateStore = permissionContext.RssPages
                        .Select(c => new { c.Id, Name = c.Name.Trim() });
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
                splashScreenManagerMultiplePage.CloseWaitForm();
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
                                IdSet = (int)rmp.Id,
                                TopicName = rmp.Name + "> " + rp.Name,
                                Link = rp.Link.Replace("(", "").Replace(")", "")
                            }
                            ).Where(a => a.IdSet == intIdCate);
                    }
                }
                catch
                {
                    // ignored
                }
            }
            catch
            {
                // ignored
            }
        }

        private void cbEditCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbChoiceSiteCate.SelectedIndex = cbEditCate.SelectedIndex;
            }
            catch
            {
                // ignored
            }
        }

        private void btnAddLinkRss_Click(object sender, EventArgs e)
        {
            if (cbEditCate.Properties.Items.Count < 1)
            {
                pictureEditReload_Click(sender, e);
            }
            else if (!CheckExistListBox(cbEditCate.Text))
            {
                SEDFuncCall.MessageWarning("Duplicate data", SEDConst.TITLE_WARNING);
            }
            else lstBoxSaveRule.Items.Add(cbEditCate.Text.ToStringNew());
        }

        private bool CheckExistListBox(string strInput)
        {
            for (var i = 0; i < lstBoxSaveRule.Items.Count; i++)
            {
                if (lstBoxSaveRule.Items[i].ToString() == strInput)
                    return false;
            }
            return true;
        }

        private void btnReloadRss_Click(object sender, EventArgs e)
        {
            if (lstBoxSaveRule.Items.Count < 1)
            {
                SEDFuncCall.MessageWarning("There is no data to be analyzed!", SEDConst.TITLE_WARNING);
                return;
            }
            gcListRss.DataSource = null;
            using (var permissionContext = new PermissionDataContext())
            {
                var lstRssLink = new List<TopicData>();
                foreach (var item in lstBoxSaveRule.Items)
                {
                    var lstBoxTemp = permissionContext.RssMenuPages
                        .Join(permissionContext.RssPages
                            , rmp => rmp.IdRssPage, rp => rp.Id
                            , (rmp, rp) => new TopicData
                            {
                                IdSet = (int)rp.Id,
                                TopicName = rp.Name,
                                Link = rmp.Link.Replace("(", "").Replace(")", "")
                            }
                        ).Where(a => a.TopicName.Equals(item.ToString())).ToList();
                    gcListRss.DataSource = lstBoxTemp;
                    lstRssLink.AddRange(lstBoxTemp);
                }
                gcListRss.DataSource = lstRssLink;
                lblTotalDynamic.Text = gvListRss.RowCount.ToString();
            }
        }

        private void btnParseData_Click(object sender, EventArgs e)
        {
            if (gvListRss.RowCount < 1)
            {
                SEDFuncCall.MessageWarning("There is no data to be analyzed!", SEDConst.TITLE_WARNING);
                return;
            }
            // CheckConnect Internet
            var checkConnect = SEDInternetConnection.CheckConnectTimeOutWait(splashScreenManagerMultiplePage);
            if (checkConnect == false) return;
            splashScreenManagerMultiplePage.ShowWaitForm();
            splashScreenManagerMultiplePage.SetWaitFormDescription(SEDConst.SET_PLEASE_WAIT);
            var stw = new Stopwatch();
            stw.Start();
            var lstFeeds = new List<Feeds>();
            var intLinkFail = 0;
            for (int i = 0; i < gvListRss.RowCount; i++)
            {
                try
                {
                    var xDoc = XDocument.Load(gvListRss.GetRowCellValue(i, "Link").ToString());
                    var idSet = Convert.ToInt32(gvListRss.GetRowCellValue(i, "IdSet"));
                    var xDataRss = xDoc.Descendants("item");
                    foreach (var nodeItem in xDataRss)
                    {
                        try
                        {
                            var feed = new Feeds
                            {
                                IdRssPage = idSet,
                                Title = nodeItem.Element("title").Value.ReplaceNew(),
                                Link = nodeItem.Element("link").Value,
                                PubDate = nodeItem.Element("pubDate").Value,
                                Image = SplitSrc(nodeItem.Element("description").Value),
                                Description = Description(nodeItem.Element("description").Value)
                            };
                            lstFeeds.Add(feed);
                        }
                        catch (NullReferenceException) { intLinkFail++; continue; }
                    };
                }
                //Ngoại lệ không phù hợp không thể parse Dư liệu => chuyển qua tiếp tục
                catch (XmlException) { intLinkFail++; continue; }
                catch (NotSupportedException)
                {
                    intLinkFail++;
                    SEDFuncCall.MessageWarning(SEDConst.MESSAGE_LINK_INVALID, SEDConst.TITLE_WARNING);
                    //Riêng ở phần parse Multiple này ta sẽ để cho nó tiếp tục parse để tránh ảnh hướng tới
                    //quá trình parse dữ liệu từ các phần ở dưới
                    continue;
                }
                catch (WebException) { intLinkFail++; continue; }
                catch (Exception ex)
                {
                    intLinkFail++;
                    //Debug.WriteLine("Error Location " + i + "  Information eror:" + gvListRss.GetRowCellValue(i, "Link").ToString());
                    SEDFuncCall.MessageWarning(ex.Message, SEDConst.TITLE_WARNING);
                    return;
                }
            }
            stw.Stop();
            splashScreenManagerMultiplePage.CloseWaitForm();
            gcShowFeeds.DataSource = lstFeeds;
            lblLinkDiedDynamic.Text = intLinkFail.ToString();
            lblTimeExcuteDynamic.Text = stw.Elapsed.ToString();
            lblTotalChildDynamic.Text = new StringBuilder(gvShowFeeds.RowCount.ToString())
                .Append(" posts!").ToString();
        }

        private string SplitSrc(string input)
        {
            var reg = new Regex("src\\s*=\\s*[\"']([^\"']+)[\"']+");
            return reg.Match(input).Groups[1].ToStringNew();
        }

        private string Description(string input)
        {
            var reg = new Regex("<.*>");
            return reg.Replace(input, "").ToStringNew();
        }

        private string DownLoadContent(string url, string xpath)
        {
            try
            {
                var htmlDocument = this.ResultWebClient(url);
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

        private HtmlDocument ResultWebClient(string url)
        {
            var wc = new WebClient { Encoding = Encoding.UTF8 };
            wc.Headers.Add("User-Agent"
                , "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36");
            string result = wc.DownloadString(url);
            string htmlDecode = WebUtility.HtmlDecode(result);
            HtmlDocument hdoc = new HtmlDocument();
            hdoc.LoadHtml(htmlDecode);
            return hdoc;
        }

        private string GetPatern(string url, int idScate)
        {
            var xpath = "";
            switch (idScate)
            {
                case 1: xpath = "//div[@class='fck_detail width_common']";
                    break;
                case 2: xpath = "//div[@class='text-conent']";
                    break;
                case 3: xpath = "//div[@id='divNewsContent']";
                    break;
                case 4: xpath = "//div[@class='content-detail']";
                    break;
            }
            return DownLoadContent(url, xpath);
        }

        private void btnDeleteItem_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            gvListRss.DeleteRow(gvListRss.FocusedRowHandle);
        }

        private void btnEditView_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                var checkConnect = SEDInternetConnection.CheckConnectTimeOutWait(splashScreenManagerMultiplePage);
                if (checkConnect == false) return;
                var idScate = Convert.ToInt32(gvShowFeeds.GetRowCellValue(_indexShowFeeds, "IdRssPage").ToString()); ;
                var getLink = gvShowFeeds.GetRowCellValue(_indexShowFeeds, "Link").ToString();
                var frmViewPosts = new FrmViewPosts
                {
                    Title = gvShowFeeds.GetRowCellValue(_indexShowFeeds, "Title").ToString(),
                    Link = gvShowFeeds.GetRowCellValue(_indexShowFeeds, "Link").ToString(),
                    PubDate = gvShowFeeds.GetRowCellValue(_indexShowFeeds, "PubDate").ToString(),
                    Image = gvShowFeeds.GetRowCellValue(_indexShowFeeds, "Image").ToString(),
                    Description = gvShowFeeds.GetRowCellValue(_indexShowFeeds, "Description").ToString(),
                    IdScategories = idScate,
                    Content = GetPatern(getLink, idScate)
                };
                frmViewPosts.Show();
            }
            catch
            {
                // ignored
            }
        }

        private int _indexShowFeeds;
        private void gvShowFeeds_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            _indexShowFeeds = e.FocusedRowHandle;
        }
    }
}