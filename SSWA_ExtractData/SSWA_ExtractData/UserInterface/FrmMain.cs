using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using SSWA_ExtractData.Common.Constant;
using System.Linq;
using PermissionContext;
using SSWA_ExtractData.Common;

namespace SSWA_ExtractData.UserInterface
{
    /// <summary>
    /// [EN] FrmMain Program
    /// Main Program ExtractData
    /// Create By: ManhNV1 -Date: 02/20/2016
    /// </summary>
    public partial class FrmMain: RibbonForm
    {
        /// <summary>
        /// [EN] FrmMain
        /// Initial Component
        /// </summary>
        public FrmMain()
        {
            FrmMainDynamic = this;
            InitializeComponent();
            InitSkinGallery();
        }

        /// <summary>
        /// [EN] InitSkinGallery
        /// InitSkinGallery to Devexpress
        /// </summary>
        void InitSkinGallery() { SkinHelper.InitSkinGallery(rgbiSkins, true); }

        /// <summary>
        /// [EN] Progress Check Login
        /// Create By: ManhNV1 -Date: 02/22/2016
        /// Description: Init Variable Global use Data Transmission
        /// </summary>
        #region Progress Check Login: FrmMain <-> FrmAuthentication
        /** frmMain Dynamic*/
        // ReSharper disable once RedundantDefaultMemberInitializer
        public static FrmMain FrmMainDynamic = null;

        /// <summary>
        /// [EN] CheckLoginPermission
        /// Create By: ManhNV1 -Date: 02/22/2016
        /// Description: Decentralized use program
        /// </summary>
        /// <param name="checkPermission">Permission</param>
        public void CheckLoginPermission(int checkPermission)
        {
            switch (checkPermission)
            {
                case 1:
                    SetEnableAllButton(true);
                    barBtnLogin.Enabled = false;
                    LoadBarInforUser();
                    break;
                case 0:
                    SetEnableAllButton(true);
                    barBtnLogin.Enabled = false;
                    LoadBarInforUser();
                    break;
                default:
                    SetEnableAllButton(false);
                    barBtnLogin.Enabled = true;
                    break;
            }
        }

        #endregion

        /// <summary>
        /// [EN] FrmMain_Load
        /// Create By: ManhNV1 -Date: 02/20/2016
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs Load</param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            barTextEdit.EditValue = DateTime.Now.ToShortDateString();
            barTextEdit.Enabled = false;
            SetEnableAllButton(false);
            barBtnLogin.Enabled = true;
            FrmAuthenShow();
            ShowFormBackGround();
        }

        /// <summary>
        /// [EN] ShowFormBackGround
        /// Create By: ManhNV1 -Date: 02/25/2016
        /// </summary>
        private void ShowFormBackGround()
        {
            try
            {
                var frm = CheckFormExists(typeof(FrmBackground));
                if (frm != null) { frm.Activate(); }
                else
                {
                    var f = new FrmBackground { MdiParent = this };
                    f.Show();
                }
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// [EN] barBtnExit_ItemClick
        /// Create By: ManhNV1 -Date: 02/20/2016
        /// Description: Close Program when click button Exit
        /// </summary>
        /// <param name="sender">Message</param>
        /// <param name="e">EventArgs Click</param>
        private void barBtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            SEDFuncCall.SetAppExit();
        }

        /// <summary>
        /// [EN] FrmMain_FormClosing
        /// Create By: ManhNV1 -Date: 02/20/2016
        /// Description: Close Program when click Exit default
        /// </summary>
        /// <param name="sender">Message</param>
        /// <param name="e">EventArgs Click</param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SEDFuncCall.SetDefaultExit(e);
        }

        /// <summary>
        /// [EN] barBtnHelp_ItemClick
        /// Create By: ManhNV1 -Date: 02/20/2016
        /// Description: View Information Help
        /// </summary>
        /// <param name="sender">Message</param>
        /// <param name="e">EventArgs Click</param>
        private void barBtnHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show(SEDConst.MAIN_HELP, SEDConst.TITLE_NOTE
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// [EN] barBtnAbout_ItemClick
        /// Create By: ManhNV1 -Date: 02/20/2016
        /// Description: View Information Help
        /// </summary>
        /// <param name="sender">Message</param>
        /// <param name="e">EventArgs Click</param>
        private void barBtnAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show(SEDConst.MAIN_ABOUT, SEDConst.TITLE_NOTE
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// [EN] barBtnLogin_ItemClick
        /// Create By: ManhNV1 -Date: 02/20/2016
        /// Description: Show Form Login
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs Click</param>>
        private void barBtnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAuthenShow();
        }

        /// <summary>
        /// [EN] barBtnLogout_ItemClick
        /// Create By: ManhNV1 -Date: 02/22/2016
        /// Description: Show Form Logout
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">ItemClickEventArgs Click</param>>
        private void barBtnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = XtraMessageBox.Show(SEDConst.MAIN_MESSAGE_LOG_OUT, SEDConst.TITLE_NOTE
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SetEnableAllButton(false);
                barBtnLogin.Enabled = true;
                var logWriteLogout = new Log
                {
                    UserId = FrmAuthentication.Id,
                    Action = SEDConst.WRITE_LOG_OUT_SYSTEM,
                    Time = SEDConst.WRITE_DATETIME_NOW
                };
                try
                {
                    using (var permissionContex = new PermissionDataContext())
                    {
                        permissionContex.Logs.InsertOnSubmit(logWriteLogout);
                        permissionContex.SubmitChanges();
                        foreach (var f in MdiChildren)
                        {
                            f.Close();
                        }
                    }
                }
                catch
                {
                    XtraMessageBox.Show(SEDConst.AUTHENTICATION_WARING_BEHAVIOR_DATABASE, SEDConst.TITLE_NOTE
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                FrmAuthenShow();
            }
        }

        #region Methdod Common
        /// <summary>
        /// [EN] FrmAuthenShow
        /// Create By: ManhNV1 -Date: 02/22/2016
        /// Description: Show Form Authentication
        /// </summary>
        private static void FrmAuthenShow()
        {
            var frmAuthen = new FrmAuthentication();
            frmAuthen.ShowDialog();
        }

        /// <summary>
        /// [EN] FrmAuthenShow
        /// Create By: ManhNV1 -Date: 02/22/2016
        /// </summary>
        /// <param name="setValueEnable">bool Value Set Enable Button</param>
        private void SetEnableAllButton(bool setValueEnable)
        {
            BarButtonItem[] btnSet = 
            { 
                barBtnPassChange
                , barBtnAccount
                , barBtnLogin
                , barBtnLogout
                , barBtnLstAccount
                , barBtnSingleUrl
                , barBtnSinglePage
                , barBtnMultiplePage
            };
            SEDFuncCall.SetButtonEnable(btnSet, setValueEnable);
        }
        #endregion

        //TODO Comment
        private void barBtnPassChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmChangePass = new FrmChangePass();
            frmChangePass.ShowDialog();
        }

        //TODO Comment
        private void barBtnAccount_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //TODO Comment
        private void barBtnLstAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var permissionContext = new PermissionDataContext())
            {
                var currentAccount = permissionContext.Accounts.SingleOrDefault(a => a.Id == FrmAuthentication.Id);
                if (currentAccount != null && currentAccount.Permission == 0)
                {
                    SEDFuncCall.MessageWarning(SEDConst.MAIN_PERMISSION_NOT_GRATED, SEDConst.TITLE_WARNING);
                    return;
                }
                var splashScreenManager = SEDFuncCall.ShowWaitForm(this, null, null);
                var frm = CheckFormExists(typeof(FrmAccoutsList));
                if (frm != null) { frm.Activate(); }
                else
                {
                    var f = new FrmAccoutsList { MdiParent = this };
                    f.Show();
                }
                splashScreenManager.CloseWaitForm();
            }
        }

        //TODO Comment
        private Form CheckFormExists(Type fType)
        {
            return MdiChildren.FirstOrDefault(f => f.GetType() == fType);
        }

        //TODO Comment
        private void LoadBarInforUser()
        {
            using (var permissionContext = new PermissionDataContext())
            {
                var currentAccout = permissionContext.Accounts
                    .SingleOrDefault(a => a.Id == FrmAuthentication.Id);
                if (currentAccout != null)
                {
                    siFullName.Caption = string.Format(SEDConst.BAR_USERNAME, currentAccout.FullName);
                    siEmail.Caption = string.Format(SEDConst.BAR_EMAIL, currentAccout.Email);
                    siStatus.Caption = string.Format(SEDConst.BAR_STATUS, currentAccout.Status == 0
                        ? SEDConst.QUERY_NOT_ACTIVE : SEDConst.QUERY_ACTIVE);
                    siPermission.Caption = string.Format(SEDConst.BAR_PERMISSION, currentAccout.Permission == 1
                        ? SEDConst.QUERY_ADMINISTRATOR : SEDConst.QUERY_STAFF);
                }
            }
        }

        //TODO Comment
        private void barBtnSinglePage_ItemClick(object sender, ItemClickEventArgs e)
        {
            var splashScreenManager = SEDFuncCall.ShowWaitForm(this, null, null);
            var frm = CheckFormExists(typeof(FrmParseSingleWebPage));
            if (frm != null) { frm.Activate(); }
            else
            {
                var f = new FrmParseSingleWebPage { MdiParent = this };
                f.Show();
            }
            splashScreenManager.CloseWaitForm();
        }

        private void barBtnMultiplePage_ItemClick(object sender, ItemClickEventArgs e)
        {
            var splashScreenManager = SEDFuncCall.ShowWaitForm(this, null, null);
            var frm = CheckFormExists(typeof(FrmParseMultiplePage));
            if (frm != null) { frm.Activate(); }
            else
            {
                var f = new FrmParseMultiplePage { MdiParent = this };
                f.Show();
            }
            splashScreenManager.CloseWaitForm();
        }
    }
}