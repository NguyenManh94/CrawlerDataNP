using System;
using System.Linq;
using SSWA_ExtractData.Common.Constant;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using PermissionContext;
using SSWA_ExtractData.Common;

namespace SSWA_ExtractData.UserInterface
{
    //TODO Comment
    public partial class FrmAccoutsList: XtraForm
    {
        public FrmAccoutsList() { InitializeComponent(); }

        private void FrmAccoutsList_Load(object sender, EventArgs e) { this.LoadListAccouts(); }

        private void btnReload_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.LoadListAccouts();
        }

        private void LoadListAccouts()
        {
            using (var permissionContext = new PermissionDataContext())
            {
                var listAccounts = permissionContext.Accounts
                    .Select(a => new
                    {
                        a.Id,
                        a.FullName,
                        a.Address,
                        a.Phone,
                        a.Email,
                        a.UserName,
                        Permission = (a.Permission == 0) ? SEDConst.QUERY_STAFF : SEDConst.QUERY_ADMINISTRATOR,
                        Status = (a.Status == 0) ? SEDConst.QUERY_NOT_ACTIVE : SEDConst.QUERY_ACTIVE
                    });
                this.gcShowAccountData.DataSource = listAccounts;
            }
        }

        private void btnCreate_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmAccoutCrud = new FrmAccoutsCrud();
            frmAccoutCrud.ShowDialog();
            this.LoadListAccouts();
        }

        private int index;
        private void gvShowAccountData_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void btnSetStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            var getId = 0;
            try
            {
                getId = Int32.Parse(gvShowAccountData.GetRowCellValue(index, "Id").ToStringNew());
            }
            catch
            {
                SEDFuncCall.MessageWarning(SEDConst.MESSAGE_CLICK_GRIDVIEW, SEDConst.TITLE_WARNING);
                return;
            }
            using (var permissionContext = new PermissionDataContext())
            {
                var getAccountChoice = permissionContext.Accounts.SingleOrDefault(a => a.Id == getId);
                var strActionNew = (getAccountChoice.Status == 0) ?
                    string.Format(SEDConst.WRITE_LOG_UPDATE_STATUS_ACCOUNT, getAccountChoice.UserName) :
                    string.Format(SEDConst.WRITE_LOG_UPDATE_STATUS_ACCOUNT_STOP, getAccountChoice.UserName);
                var strMessage = SEDConst.STRING_EMPTY;
                var setActive = false;
                UpdateSetActiveAccount(permissionContext, getAccountChoice, strActionNew, ref strMessage, ref setActive);
            }
        }

        private void UpdateSetActiveAccount(PermissionDataContext permissionContext, Account getAccountChoice
            , string strActionNew, ref string strMessage, ref bool setActive)
        {
            if (getAccountChoice.Status == 0)
            {
                strMessage = string.Format(SEDConst.MESSAGE_ACCOUNTLIST_ACTIVE_ACCOUNT, getAccountChoice.FullName);
                setActive = true;
            }
            else
            {
                strMessage = string.Format(SEDConst.MESSAGE_ACCOUNTLIST_STOP_ACCOUNT, getAccountChoice.FullName);
                setActive = false;
            }
            var result = XtraMessageBox.Show(strMessage, SEDConst.TITLE_NOTE
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var logUpdateAction = new Log
                {
                    UserId = FrmAuthentication.Id,
                    Action = strActionNew,
                    Time = SEDConst.WRITE_DATETIME_NOW
                };
                getAccountChoice.Status = (getAccountChoice.Status == 0) ? 1 : 0;
                permissionContext.Logs.InsertOnSubmit(logUpdateAction);
                var strMessageUpdateSuccess = SEDConst.STRING_EMPTY;
                if (setActive == true)
                {
                    strMessageUpdateSuccess = string.Format(SEDConst.MESSAGE_ACCOUNTLIST_ACTIVE_SUCCSESS
                        , getAccountChoice.FullName);
                }
                else
                {
                    strMessageUpdateSuccess = string.Format(SEDConst.MESSAGE_ACCOUNTLIST_STOP_SUCCESS
                        , getAccountChoice.FullName);
                }
                SEDFuncCall.MessageSuccess(strMessageUpdateSuccess, SEDConst.TITLE_NOTE);
                permissionContext.SubmitChanges();
                this.LoadListAccouts();
            }
        }
    }
}