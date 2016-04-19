using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PermissionContext;
using SSWA_ExtractData.Common;
using SSWA_ExtractData.Common.Constant;
using SSWA_ExtractData.Common.Security;
using SSWA_ExtractData.Entity;

//TODO Comment Parse New Feed

namespace SSWA_ExtractData.UserInterface
{
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class PE01FrmParseCNN : XtraForm
    {
        private int _index;
        private int _rowHandle;
        private int? _selectedRowHandle;

        /// <summary>
        ///     [EN] Contructor PE01FrmParseCNN
        ///     Create By: Default
        /// </summary>
        public PE01FrmParseCNN()
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

        /// <summary>
        ///     [EN] ShowListCnn
        ///     Create By: ManhNV -Date: 05/19/2016
        ///     Description: Select List Item Rss NewFeeds///
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EvenHandel type EventArgs</param>
        private void PE01FrmParseNewFeed_Load(object sender, EventArgs e)
        {
            try
            {
                BaseControl[] bsControlSet = { btnGetContent, txtEditUrl };
                SEDFuncCall.SetControlVisible(bsControlSet, false);
                chkSinglePage.Checked = false;
                ShowListCnn();
            }
            catch (Exception ex)
            {
                SEDFuncCall.MessageWarning(ex.Message, SEDConst.TITLE_WARNING);
            }
        }

        /// <summary>
        ///     [EN] ShowListCnn
        ///     Create By: ManhNV -Date: 05/19/2016
        ///     Description: Select List Item Rss NewFeeds
        /// </summary>
        private void ShowListCnn()
        {
            var permissionContext = new PermissionDataContext();
            Task.Factory.StartNew(
                () => permissionContext.RssMenuPages.Where(c => c.IdRssPage == 5)
                    .Select(a => new TopicData
                    {
                        TopicName = "CNN> " + a.Name,
                        Link = a.Link
                    }))
                .ContinueWith(pre =>
                {
                    gcShowCateInfor.DataSource = pre.Result;
                    barStaticCate.Caption = @"Categories: CNN -Total: " + gvShowCateInfor.RowCount;
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

        private void gvShowCateInfor_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            _index = e.FocusedRowHandle;
        }

        private void gvShowCateInfor_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
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
                //lblChildCateDynamic.Text = gvShowCateInfor.GetRowCellValue(_index, "TopicName").ToString();
                //lblTotalChildDynamic.Text = lstFeeds.Count.ToString();
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

        private void gvShowFeeds_RowStyle(object sender, RowStyleEventArgs e)
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
        }

        private void btnGetContent_Click(object sender, EventArgs e)
        {
            if (txtEditUrl.Text.Trim().Length == 0)
            {
                SEDFuncCall.MessageWarning(@"Please input url need get content!", SEDConst.TITLE_WARNING);
                return;
            }
            if (Regex.IsMatch(txtEditUrl.Text.Trim(), @"^http://edition.cnn.com/"))
            {
                SEDFuncCall.MessageWarning(@"Link invalid! Link only supports magazines CNN!", SEDConst.TITLE_WARNING);
                return;
            }
            if (txtEditPathDefault.Text.Trim().Length == 0)
            {
                SEDFuncCall.MessageWarning(@"Please choice path default!", SEDConst.TITLE_WARNING);
                return;
            }
            Task.Factory.StartNew(() => { });
        }
    }
}