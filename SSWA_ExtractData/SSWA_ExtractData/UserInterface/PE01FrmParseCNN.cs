using System;
using DevExpress.XtraEditors;
using SSWA_ExtractData.Common;
using PermissionContext;
using System.Linq;
using SSWA_ExtractData.Entity;

//TODO Comment Parse New Feed
namespace SSWA_ExtractData.UserInterface
{
    public partial class PE01FrmParseCNN : DevExpress.XtraEditors.XtraForm
    {
        public PE01FrmParseCNN()
        {
            InitializeComponent();
            #region set TooltripMenu
            btnSetPath.MouseClick +=
                (sender, e) => toolTipShowUrl.SetToolTip(btnSetPath, "Path set default data storage!");
            btnSetPath.Click += (sender, e) => toolTipShowUrl.SetToolTip(btnSetPath, "Path set default data storage!");
            txtEditUrl.TextChanged +=
                delegate(object sender, EventArgs e) { toolTipShowUrl.SetToolTip(txtEditUrl, "Input url need get content!"); };
            txtEditUrl.MouseClick += (sender, e) => toolTipShowUrl.SetToolTip(txtEditUrl, "Input url need get content!");
            #endregion
        }

        private void PE01FrmParseNewFeed_Load(object sender, EventArgs e)
        {
            BaseControl[] bsControlSet = { btnGetContent, txtEditUrl };
            SEDFuncCall.SetControlVisible(bsControlSet, false);
            ShowListCnn();
        }

        private void ShowListCnn()
        {
            using (var permissionContext = new PermissionDataContext())
            {
                var lstCnn = permissionContext.RssMenuPages.Where(c => c.IdRssPage == 5)
                    .Select(a => new TopicData
                    {
                        TopicName = "CNN> " + a.Name,
                        Link = a.Link
                    });
                gcShowCateInfor.DataSource = lstCnn;
            }
        }

        private void chkSinglePage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinglePage.Checked)
            {
                BaseControl[] bsControlSet = { btnGetContent, txtEditUrl };
                SEDFuncCall.SetControlVisible(bsControlSet, true);
            }
            else
            {
                BaseControl[] bsControlSet = { btnGetContent, txtEditUrl };
                SEDFuncCall.SetControlVisible(bsControlSet, false);
            }
        }
    }
}