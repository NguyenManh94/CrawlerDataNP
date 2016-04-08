using System;
using System.Linq;
using DevExpress.XtraEditors;
using SSWA_ExtractData.Common.Constant;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SSWA_ExtractData.Common.Security;
using PermissionContext;
using SSWA_ExtractData.Common;

//TODO Comment
namespace SSWA_ExtractData.UserInterface
{
    //TODO Comment All FrmAccountsCrud
    public partial class A05FrmAccoutsCrud: XtraForm
    {
        public A05FrmAccoutsCrud() { InitializeComponent(); }

        private void FrmAccoutsCrud_Load(object sender, EventArgs e)
        {
            using (var permissionContext = new PermissionDataContext())
            {
                txtCreator.Text = permissionContext.Accounts
                    .SingleOrDefault(a => a.Id == A01FrmAuthentication.Id).FullName;
            }
        }

        private void barBtnReload_ItemClick(object sender, ItemClickEventArgs e)
        {
            TextEdit[] arrTextEdit = { txtFullName, txtAddress, txtEmail, txtPhone, txtUserName, txtPassword };
            CheckBox[] arrCheckBox = { chkValidEmail, chkValidPassword, chkSetPermission, chkSetStatus, chkCheckValidAll };
            SEDFuncCall.SetTextEditValue(arrTextEdit, SEDConst.STRING_EMPTY);
            SEDFuncCall.SetCheckBoxStatus(arrCheckBox, CheckState.Unchecked);
        }

        private void barBtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkCheckValidAll.CheckState == CheckState.Unchecked)
            {
                var strMessageChangePass = string.Format(SEDConst.CHANGEPASS_MESSAGE_CHECK_VALID, chkCheckValidAll.Text);
                SEDFuncCall.MessageWarning(strMessageChangePass, SEDConst.TITLE_WARNING);
                return;
            }
            else
            {
                try
                {
                    using (var permissionContext = new PermissionDataContext())
                    {
                        var accountNew = new Account
                        {
                            FullName = txtFullName.Text,
                            Address = txtAddress.Text,
                            Phone = txtPhone.Text,
                            UserName = txtUserName.Text,
                            Password = new SEDDataEncrypt().EncodeOneWay(txtPassword.Text),
                            Email = txtEmail.Text,
                            Permission = (chkSetPermission.Checked ? 1 : 0),
                            Status = (chkSetStatus.Checked ? 1 : 0)
                        };
                        permissionContext.Accounts.InsertOnSubmit(accountNew);
                        permissionContext.SubmitChanges();
                        SEDFuncCall.MessageSuccess(SEDConst.ACCOUNTCRUD_MESSAGE_CREATE_SUCCSESS
                            , SEDConst.TITLE_NOTE);
                    }
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.Message, SEDConst.TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void chkValidEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValidEmail.Checked)
            {
                if (txtEmail.Text.Equals(SEDConst.STRING_EMPTY))
                {
                    SEDFuncCall.MessageWarning(SEDConst.ACCOUNTCRUD_MESSAGE_EMAIL_EMPTY, SEDConst.TITLE_WARNING);
                    SEDFuncCall.SetCheckBoxStatus(chkValidEmail, 0);
                    return;
                }
                else if (SEDFuncCall
                    .CheckStringMatch(SEDConst.PARTERN_CHECK_EMAIL, txtEmail.Text) == false)
                {
                    SEDFuncCall.MessageWarning(SEDConst.ACCOUNTCRUD_EMAIL_INVALID, SEDConst.TITLE_WARNING);
                    SEDFuncCall.SetCheckBoxStatus(chkValidEmail, 0);
                    return;
                }
                else
                {
                    SEDFuncCall.MessageSuccess(SEDConst.ACCOUNTCRUD_EMAIL_VALID, SEDConst.TITLE_NOTE);
                }
            }
        }

        private void chkValidPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValidPassword.Checked)
            {
                if (txtPassword.Equals(SEDConst.STRING_EMPTY))
                {
                    SEDFuncCall.MessageWarning(SEDConst.ACCOUNTCRUD_PASSWORD_EMPTY, SEDConst.TITLE_WARNING);
                    SEDFuncCall.SetCheckBoxStatus(chkValidPassword, 0);
                    return;
                }
                else if (txtPassword.Text.Length < SEDConst.LENGTH_PASS_VALID)
                {
                    SEDFuncCall.MessageWarning(SEDConst.CHANGEPASS_MESSAGE_NUMBER_OF_CHARACTER_INVALID, SEDConst.TITLE_WARNING);
                    SEDFuncCall.SetCheckBoxStatus(chkValidPassword, 0);
                    return;
                }
                else
                {
                    SEDFuncCall.MessageSuccess(SEDConst.ACCOUNTCRUD_PASSWORD_VALID, SEDConst.TITLE_NOTE);
                }
            }
        }

        private void chkCheckValidAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckValidAll.Checked)
            {
                TextEdit[] arrTextEdit = { txtFullName, txtAddress, txtEmail, txtPhone, txtUserName, txtPassword };
                if (chkValidEmail.CheckState == CheckState.Unchecked
                    || chkValidPassword.CheckState == CheckState.Unchecked)
                {
                    var strMessage = string.Format(SEDConst.ACCOUNTCRUD_MESSAGE_CHECK_ALL
                        , chkValidEmail.Text
                        , chkValidPassword.Text
                        , chkCheckValidAll.Text);
                    SEDFuncCall.MessageWarning(strMessage, SEDConst.TITLE_WARNING);
                    SEDFuncCall.SetCheckBoxStatus(chkCheckValidAll, 0);
                    return;
                }
                else if (SEDFuncCall.CheckTextEditEmpty(arrTextEdit) == true)
                {
                    SEDFuncCall.MessageWarning(SEDConst.ACCOUNTCRUD_MESSAGE_LACK_OF_DATA, SEDConst.TITLE_WARNING);
                    SEDFuncCall.SetCheckBoxStatus(chkCheckValidAll, 0);
                    return;
                }
                else
                {
                    SEDFuncCall.MessageSuccess(SEDConst.CHANGEPASS_MESSAGE_VALID, SEDConst.TITLE_NOTE);
                }
            }
        }

        private void txtEmail_EditValueChanged(object sender, EventArgs e)
        {
            SEDFuncCall.SetCheckBoxStatus(chkValidEmail, 0);
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            SEDFuncCall.SetCheckBoxStatus(chkValidPassword, 0);
        }
    }
}