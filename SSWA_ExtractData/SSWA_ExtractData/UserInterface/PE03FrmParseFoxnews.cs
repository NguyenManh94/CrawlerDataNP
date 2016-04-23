using DevExpress.XtraEditors;
using PermissionContext;
using SSWA_ExtractData.Common;
using SSWA_ExtractData.Common.Constant;
using SSWA_ExtractData.Entity;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;
using DevExpress.XtraGrid;
using System.Collections.Generic;
using System.Xml.Linq;
using SSWA_ExtractData.Common.Security;
using System.Text;
using System.Text.RegularExpressions;
using SSWA_ExtractData.Common.StringProcess;
using System.IO;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Net;
using System.Windows.Forms;

namespace SSWA_ExtractData.UserInterface
{
    public partial class PE03FrmParseFoxnews : DevExpress.XtraEditors.XtraForm
    {
        private int _index;
        private int _rowHandle;
        private int? _selectedRowHandle;

        /// <summary>
        ///     [EN] Contructor PE02FrmParseFoxnews
        ///     Create By: Default
        /// </summary>
        public PE03FrmParseFoxnews()
        {
            InitializeComponent();

            #region set TooltripMenu

            btnSetPath.MouseHover +=
                (sender, e) => toolTipShowUrl.SetToolTip(btnSetPath, "Path set default data storage!");
            txtEditUrl.MouseHover +=
                delegate { toolTipShowUrl.SetToolTip(txtEditUrl, "Input url need get content!"); };
            btnGetContent.MouseHover +=
                delegate { toolTipShowUrl.SetToolTip(btnGetContent, "DownLoad Content vs Links Just Lead!"); };
            chkSinglePage.MouseHover +=
                (sender, e) => { toolTipShowUrl.SetToolTip(chkSinglePage, "Choice Parse SinglePage!"); };

            #endregion
        }

        private void PE03FrmParseFoxnews_Load(object sender, EventArgs e)
        {
            try
            {
                BaseControl[] bsControlSet = { btnGetContent, txtEditUrl };
                SEDFuncCall.SetControlVisible(bsControlSet, false);
                chkSinglePage.Checked = false;
                ShowListFoxnews();
            }
            catch (Exception ex)
            {
                SEDFuncCall.MessageWarning(ex.Message, SEDConst.TITLE_WARNING);
            }
        }

        /// <summary>
        ///     [EN] ShowListFoxnews
        ///     Create By: ManhNV -Date: 05/19/2016
        ///     Description: Select List Item Rss NewFeeds
        /// </summary>
        private void ShowListFoxnews()
        {
            var permissionContext = new PermissionDataContext();
            Task.Factory.StartNew(
                () => permissionContext.RssMenuPages.Where(c => c.IdRssPage == 7)
                    .Select(a => new TopicData
                    {
                        TopicName = "Foxnews> " + a.Name,
                        Link = a.Link
                    }))
                .ContinueWith(pre =>
                {
                    gcShowCateInfor.DataSource = pre.Result;
                    barStaticCate.Caption = @"Categories: Foxnews -Total: " + gvShowCateInfor.RowCount;
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void chkSinglePage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinglePage.Checked)
            {
                BaseControl[] bsControlSet = { btnGetContent, txtEditUrl };
                SEDFuncCall.SetControlVisible(bsControlSet, true);
                txtEditUrl.Text = "";
                txtEditUrl.Focus();
            }
            else
            {
                BaseControl[] bsControlSet = { btnGetContent, txtEditUrl };
                SEDFuncCall.SetControlVisible(bsControlSet, false);
            }
        }

        private void gvShowCateInfor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _index = e.FocusedRowHandle;
        }

        private void gvShowCateInfor_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (_selectedRowHandle.GetValueOrDefault(GridControl.InvalidRowHandle) == e.RowHandle)
            {
                e.Appearance.BackColor = Color.LightBlue;
                e.Appearance.BackColor2 = Color.LightCyan;
            }
        }

        private void btnShowListData_Click(object sender, EventArgs e)
        {
            try
            {
                #region Select and setColor One RowsItem

                var prevSelectedRowHandle = _selectedRowHandle.GetValueOrDefault(GridControl.InvalidRowHandle);
                if (prevSelectedRowHandle != GridControl.InvalidRowHandle)
                    gvShowCateInfor.RefreshRow(prevSelectedRowHandle); // reset row-style to default
                _selectedRowHandle = gvShowCateInfor.FocusedRowHandle;
                gvShowCateInfor.InvalidateRow(gvShowCateInfor.FocusedRowHandle); // row painting request

                #endregion
                LoadData();
            }
            catch
            {
                SEDFuncCall.MessageWarning(SEDConst.MESSAGE_CLICK_GRIDVIEW, SEDConst.TITLE_WARNING);
            }
        }

        private void LoadData()
        {
            try
            {
                // CheckConnect Internet
                if (SEDInternetConnection.CheckConnectTimeOutWait(splashScreenManagerWebPage) == false) return;
                var url = gvShowCateInfor.GetRowCellValue(_index, "Link").ToString();
                splashScreenManagerWebPage.ShowWaitForm();
                splashScreenManagerWebPage.SetWaitFormCaption(SEDConst.SET_PLEASE_WAIT);
                Task.Factory.StartNew(() =>
                {
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
                                    PubDate = nodeItem.Element("pubDate").Value
                                };
                                lstFeeds.Add(feed);
                            }
                        }
                        catch (NullReferenceException)
                        {
                        }
                    }
                    return lstFeeds;
                }).ContinueWith(pre =>
                {
                    gcShowFeeds.DataSource = pre.Result;
                    splashScreenManagerWebPage.CloseWaitForm();
                }, TaskScheduler.FromCurrentSynchronizationContext());
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

        private void gvShowFeeds_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle == _rowHandle)
            {
                e.Appearance.BackColor = Color.Salmon;
                e.Appearance.BackColor2 = Color.SeaShell;
            }
        }

        private void btnEditView_Click(object sender, EventArgs e)
        {
            _rowHandle = gvShowFeeds.FocusedRowHandle;
            gvShowFeeds.RefreshRow(_rowHandle);
        }

        private void btnDownLoadContent_Click(object sender, EventArgs e)
        {
            if (txtEditPathDefault.Text.Trim().Length == 0)
            {
                SEDFuncCall.MessageWarning(@"Please choice path default!", SEDConst.TITLE_WARNING);
                return;
            }
            if (SEDInternetConnection.CheckConnectTimeOutWait(splashScreenManagerWebPage) == false) return;
            var title = Regex.Replace(gvShowFeeds.GetRowCellValue(_index, "Title").ToString(), "[:\\/*?\"<>|]*", "");
            var link = gvShowFeeds.GetRowCellValue(_index, "Link").ToString();
            gvShowFeeds.DeleteRow(gvShowFeeds.FocusedRowHandle);
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var content = ContentFoxnews(link);
                    //=====================================
                    var pathFolderSave = new StringBuilder(txtEditPathDefault.Text).Append(@"\").Append(title).ToString();
                    var pathFolderImage = new StringBuilder(pathFolderSave).Append(@"\Images").ToString();
                    var pathTitle = new StringBuilder(pathFolderSave).Append(@"\TitleAndLink.txt").ToString();
                    var pathContent = new StringBuilder(pathFolderSave).Append(@"\Content.txt").ToString();
                    //Create File Save Content
                    SEDFileProcess.CreateNewFile(pathFolderSave);
                    //Create File Image
                    SEDFileProcess.CreateNewFile(pathFolderImage);
                    File.WriteAllText(pathTitle, new StringBuilder(title).Append("\r\n").Append(link).ToString(), Encoding.UTF8);
                    File.WriteAllText(pathContent, content, Encoding.UTF8);
                    ImageFoxnews(link, pathFolderImage);
                }
                catch (Exception)
                {
                    splashScreenManagerWebPage.CloseWaitForm();
                }
            }).ContinueWith(pre => splashScreenManagerWebPage.CloseWaitForm()
                , TaskScheduler.FromCurrentSynchronizationContext()
            );
        }

        private void btnGetContent_Click(object sender, EventArgs e)
        {
            if (txtEditUrl.Text.Trim().Length == 0)
            {
                SEDFuncCall.MessageWarning(@"Please input url need get content!", SEDConst.TITLE_WARNING);
                return;
            }
            if (!Regex.IsMatch(txtEditUrl.Text.Trim().ToLower(), @"foxnews.com.*"))
            {
                SEDFuncCall.MessageWarning(@"Link invalid! Link only supports magazines Foxnews!", SEDConst.TITLE_WARNING);
                return;
            }
            if (txtEditPathDefault.Text.Trim().Length == 0)
            {
                SEDFuncCall.MessageWarning(@"Please choice path default!", SEDConst.TITLE_WARNING);
                return;
            }
            // CheckConnect Internet
            if (SEDInternetConnection.CheckConnectTimeOutWait(splashScreenManagerWebPage) == false) return;
            btnGetContent.Enabled = false;
            chkSinglePage.Enabled = false;
            txtEditUrl.Enabled = false;
            Task.Factory.StartNew(() =>
            {
                var link = txtEditUrl.Text.Trim();
                var title = Regex.Replace(ResultWebDecode(link)
                    .DocumentNode.SelectSingleNode(@"//div/h1[@itemprop='headline']").InnerText
                    , "[:\\/*?\"<>|]*", "");
                var content = ContentFoxnews(link);
                //=====================================
                var pathFolderSave = new StringBuilder(txtEditPathDefault.Text).Append(@"\").Append(title).ToString();
                var pathFolderImage = new StringBuilder(pathFolderSave).Append(@"\Images").ToString();
                var pathTitle = new StringBuilder(pathFolderSave).Append(@"\Title.txt").ToString();
                var pathContent = new StringBuilder(pathFolderSave).Append(@"\Content.txt").ToString();
                //Create File Save Content
                SEDFileProcess.CreateNewFile(pathFolderSave);
                //Create File Image
                SEDFileProcess.CreateNewFile(pathFolderImage);
                File.WriteAllText(pathTitle, new StringBuilder(title).Append("\r\n").Append(link).ToString(), Encoding.UTF8);
                File.WriteAllText(pathContent, content, Encoding.UTF8);
                ImageFoxnews(link, pathFolderImage);
                SEDFuncCall.MessageSuccess("Download Success!", SEDConst.TITLE_NOTE);
            }).ContinueWith(pre =>
            {
                btnGetContent.Enabled = true;
                chkSinglePage.Enabled = true;
                txtEditUrl.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        protected static string ContentFoxnews(string url)
        {
            try
            {
                var htmlDocumentTemp = ResultWebDecode(url);
                var singleContent = htmlDocumentTemp
                    .DocumentNode.SelectSingleNode("//div[@itemprop='articleBody']/div[@class='article-text']").InnerHtml;
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(singleContent);
                var listP_Content = htmlDocument.DocumentNode.SelectNodes("//p");
                var sbdContentFoxnews = new StringBuilder();
                foreach (var item in listP_Content)
                {
                    sbdContentFoxnews.Append(item.InnerText.Trim()).Append(Environment.NewLine);
                }
                return sbdContentFoxnews.ToString();
            }
            catch { return "Content Video Not Support! Please Choice Link Switch"; }
        }

        protected static void ImageFoxnews(string url, string path)
        {
            try
            {
                #region Crawler Image
                var hsImg = new HashSet<string>();
                var htmlDocument = ResultWebDecode(url);
                var strInput = htmlDocument.DocumentNode.SelectSingleNode(@"//div[@itemprop='articleBody']").InnerHtml;
                var lstImg = Regex.Matches(strInput, "<img.*?src=\"(?<link>.*?)\"");
                foreach (Match item in lstImg)
                {
                    hsImg.Add(item.Groups["link"].Value);
                }
                #endregion

                var wc = new WebClient();
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Headers.Add(HttpRequestHeader.UserAgent, "anything");
                var i = 0;
                if (hsImg.Contains("")) hsImg.Remove("");
                var sbdPath = new StringBuilder();
                try
                {
                    foreach (var item in hsImg)
                    {
                        try
                        {
                            wc.DownloadFile(item, sbdPath.Append(path).Append(@"\Picture").Append(i).Append(".jpg").ToString());
                        }
                        catch
                        {
                            sbdPath.Clear();
                            continue;
                        }
                        sbdPath.Clear();
                        i++;
                    }
                }
                catch (WebException)
                {
                    SEDFuncCall.MessageWarning("Do not exist downloaded file path!", SEDConst.TITLE_WARNING);
                    return;
                }
                wc.Dispose();
            }
            catch { }
        }

        private static HtmlDocument ResultWebDecode(string url)
        {
            var wc = new WebClient { Encoding = Encoding.UTF8 };
            wc.Headers.Add("User-Agent"
                , "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36");
            var result = wc.DownloadString(url);
            var htmlDecode = WebUtility.HtmlDecode(result);
            var removeScript = SampleMatches(htmlDecode);
            var hdoc = new HtmlDocument();
            hdoc.LoadHtml(removeScript);
            return hdoc;
        }

        private static string SampleMatches(string strInput)
        {
            //link: http://stackoverflow.com/questions/6659351/removing-all-script-tags-from-html-with-js-regular-expression
            const string patern = @"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>";
            var reg = new Regex(patern);
            return reg.Replace(strInput, "");
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = @"Please choice path default save!";
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtEditPathDefault.Text = fbd.SelectedPath;
            }
        }

        private void gvShowFeeds_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _index = e.FocusedRowHandle;
        }
    }
}