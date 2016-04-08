using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SSWA_ExtractData.Common.Security;
using SSWA_ExtractData.Common.Constant;
using DevExpress.XtraBars;
using PermissionContext;
using SSWA_ExtractData.Common;

namespace SSWA_ExtractData.UserInterface
{
    public partial class A06FrmChangePass: XtraForm
    {
        public A06FrmChangePass()
        {
            InitializeComponent();
        }

        private string passOld = SEDConst.STRING_EMPTY;
        private void FrmChangePass_Load(object sender, EventArgs e)
        {
            txtPassOld.Focus();
            using (var permissionContex = new PermissionDataContext())
            {
                var accoutInfor = permissionContex.Accounts.SingleOrDefault(a => (a.Id == A01FrmAuthentication.Id));
                txtUserName.Text = accoutInfor.FullName;
                passOld = accoutInfor.Password;
            }
        }

        private void barBtnReload_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.FrmChangePass_Load(sender, e);
            TextEdit[] txtEdit = { txtPassOld, txtPassNew, txtRePass };
            SEDFuncCall.SetTextEditValue(txtEdit, SEDConst.STRING_EMPTY);
            SEDFuncCall.SetTextEditReadonly(txtEdit, true);
        }

        private void chkPassOld_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassOld.Checked)
            {
                if (txtPassOld.Text.Equals(SEDConst.STRING_EMPTY))
                {
                    XtraMessageBox.Show(SEDConst.CHANGEPASS_MESSAGE_INPUT, SEDConst.TITLE_NOTE
                        , MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    SEDFuncCall.SetCheckEditStatus(chkPassOld, 0);
                    return;
                }
                else
                {
                    var strEncodePassOldInput = new SEDDataEncrypt().EncodeOneWay(txtPassOld.Text);
                    if (!strEncodePassOldInput.Equals(passOld))
                    {
                        SEDFuncCall.MessageWarning(SEDConst.CHANGEPASS_MESSAGE_NOTMATCH_PASSWORD
                            , SEDConst.TITLE_WARNING);
                        SEDFuncCall.SetCheckEditStatus(chkPassOld, 0);
                        return;
                    }
                    else
                    {
                        txtPassOld.ReadOnly.Equals(true);
                        SEDFuncCall.MessageSuccess(SEDConst.CHANGEPASS_MESSAGE_MATCH_PASSWORD, SEDConst.TITLE_NOTE);
                    }
                }
            }
        }

        private void chkValidAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValidAll.Checked)
            {
                if (chkPassOld.CheckState == CheckState.Unchecked)
                {
                    XtraMessageBox.Show(SEDConst.CHANGEPASS_MESSAGE_CHECK_PASSOLD, SEDConst.TITLE_WARNING
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SEDFuncCall.SetCheckBoxStatus(chkValidAll, 0);
                    return;
                }
                else
                {
                    if (txtPassNew.Text.Length < SEDConst.LENGTH_PASS_VALID)
                    {
                        XtraMessageBox.Show(SEDConst.CHANGEPASS_MESSAGE_NUMBER_OF_CHARACTER_INVALID, SEDConst.TITLE_WARNING
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SEDFuncCall.SetCheckBoxStatus(chkValidAll, 0);
                        return;
                    }
                    else if (!txtPassNew.Text.Equals(txtRePass.Text))
                    {
                        XtraMessageBox.Show(SEDConst.CHANGEPASS_MESSAGE_RETYPE_NOT_MATCH, SEDConst.TITLE_WARNING
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SEDFuncCall.SetCheckBoxStatus(chkValidAll, 0);
                        return;
                    }
                    else
                    {
                        TextEdit[] txtEdit = { txtPassOld, txtPassNew, txtUserName, txtRePass };
                        SEDFuncCall.SetTextEditReadonly(txtEdit, false);
                        SEDFuncCall.MessageSuccess(SEDConst.CHANGEPASS_MESSAGE_VALID, SEDConst.TITLE_WARNING);
                        return;
                    }
                }
            }
            else
            {
                TextEdit[] textEdit = { txtPassOld, txtPassNew, txtUserName, txtRePass };
                SEDFuncCall.SetTextEditReadonly(textEdit, true);
            }
        }

        private void barBtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkValidAll.CheckState == CheckState.Unchecked)
            {
                XtraMessageBox.Show(string.Format(SEDConst.CHANGEPASS_MESSAGE_CHECK_VALID, chkValidAll.Text)
                    , SEDConst.TITLE_WARNING
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Encrypt Password_New and Update Pass, WriteLog => Database
                var passNew = new SEDDataEncrypt().EncodeOneWay(txtPassNew.Text);
                using (var permissionContext = new PermissionDataContext())
                {
                    var accoutCurrent = permissionContext.Accounts.SingleOrDefault(a => (a.Id == A01FrmAuthentication.Id));
                    accoutCurrent.Password = passNew;
                    // Write Log
                    var logUpdateAction = new Log
                    {
                        UserId = A01FrmAuthentication.Id,
                        Action = SEDConst.WRITE_LOG_UPDATE_PASSWORD,
                        Time = SEDConst.WRITE_DATETIME_NOW
                    };
                    permissionContext.Logs.InsertOnSubmit(logUpdateAction);
                    permissionContext.SubmitChanges();
                    XtraMessageBox.Show(SEDConst.CHANGEPASS_MESSAGE_UPDATE, SEDConst.TITLE_NOTE
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}