using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using SSWA_ExtractData.Common.Security;
using SSWA_ExtractData.Entity;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using SSWA_ExtractData.Common.Constant;
using PermissionContext;
using SSWA_ExtractData.Common;

namespace SSWA_ExtractData.UserInterface
{
    /// <summary>
    /// [EN] FrmAuthentication
    /// Creat by: ManhNV1 -Date: 02/20/2016
    /// Description: Authentication Login
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("45CBBB62-CB28-4CE5-8C12-A1D869E2E823")]
    public partial class FrmAuthentication: XtraForm
    {
        public FrmAuthentication() { InitializeComponent(); }

        /// <summary>
        /// [EN] FrmAuthentication_Load
        /// Create By: ManhNV1 -Date: 02/20/2016
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs Load</param>
        private void FrmAuthentication_Load(object sender, EventArgs e)
        {
            var checkExist = File.Exists(SEDConst.PATH_USER_LOGIN);
            if (checkExist)
            {
                var strAccount = File.ReadAllText(SEDConst.PATH_USER_LOGIN, Encoding.UTF8);
                var account = JsonConvert.DeserializeObject<UserLoginRemember>(strAccount);
                var decodeData = new SEDDataEncrypt();
                txtUserName.Text = decodeData.DecodeTwoWay(account.UserLogin);
                txtPassword.Text = decodeData.DecodeTwoWay(account.Password);
            }
        }

        /// <summary>
        /// [EN] btnExit_CheckedChanged
        /// Create By: ManhNV1 -Date: 02/20/2016
        /// Description: Close Program when click button Exit
        /// </summary>
        /// <param name="sender">Message</param>
        /// <param name="e">EventArgs Click</param>
        private void btnExit_CheckedChanged(object sender, EventArgs e)
        {
            SEDFuncCall.SetAppExit();
        }

        /// <summary>
        /// Create By: ManhNV1 -Date: 02/23/2016
        /// Description: Close the program when you click the default exit
        /// </summary>
        /// <param name="sender">Object default</param>
        /// <param name="e">EventArgs Click</param>
        private void FrmAuthentication_FormClosing(object sender, FormClosingEventArgs e)
        {
            SEDFuncCall.SetDefaultExit(e);
        }

        /// <summary>
        /// [EN] btnReset_CheckedChanged
        /// Create by: ManhNV1 -Date: 02/20/2016
        /// Description: Reset Text and switch Checked = Unchecked
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs Changed</param>
        private void btnReset_CheckedChanged(object sender, EventArgs e)
        {

            txtUserName.Text = txtPassword.Text = "";
            txtUserName.Focus();
            if (chkRememberLogin.CheckState == CheckState.Checked)
            {
                chkRememberLogin.CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// [EN] timerLoadDayHours_Tick
        /// Create by: ManhNV1 -Date: 02/20/2016
        /// Description: System Time Changes
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs TimerLoad</param>
        private void timerLoadDayHours_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDayDynamic.Text = DateTime.Now.ToShortDateString();
                lblHoursDynamic.Text = DateTime.Now.ToLongTimeString();
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// [EN] chkRememberLogin_CheckedChanged
        /// Create by: ManhNV1 -Date: 02/22/2016
        /// Description: System Progress Login
        /// </summary>
        /// <param name="sender">Object default</param>
        /// <param name="e">EvenArgs Changed</param>
        private void chkRememberLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRememberLogin.Checked)
            {
                if (txtPassword.Text.Equals(SEDConst.STRING_EMPTY)
                    || txtUserName.Text.Equals(SEDConst.STRING_EMPTY))
                {
                    chkRememberLogin.CheckState = CheckState.Unchecked;
                    XtraMessageBox.Show(SEDConst.MAIN_WARNING_CHECKEMPTY, SEDConst.TITLE_WARNING
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// [EN] btnLogin_CheckedChanged
        /// Create by: ManhNV1 -Date: 02/22/2016
        /// Description: System Progress Login
        /// </summary>
        /// <param name="sender">Object default</param>
        /// <param name="e">EventArgs Changed</param>
        private void btnLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.TextTrim().Equals(SEDConst.STRING_EMPTY)
                || txtUserName.TextTrim().Equals(SEDConst.STRING_EMPTY))
            {
                XtraMessageBox.Show(SEDConst.MAIN_MESSAGE_EMPTY, SEDConst.TITLE_NOTE
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var permissionContext = new PermissionDataContext())
                {
                    // Check Valid Login
                    var strEncodeUserName = new SEDDataEncrypt().EncodeOneWay(txtPassword.Text);
                    var account = permissionContext.Accounts
                        .SingleOrDefault(a => a.UserName.Equals(txtUserName.Text.ToLower())
                                              && a.Password.Equals(strEncodeUserName));
                    if (null == account)
                    {
                        XtraMessageBox.Show(SEDConst.AUTHENTICATION_MESSAGE_LOGINFAIL, SEDConst.TITLE_WARNING
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (account.Status == 0)
                    {
                        XtraMessageBox.Show(SEDConst.AUTHENTICATION_ACCOUNT_EXPIRE, SEDConst.TITLE_WARNING
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //Write Log
                    var logWriteLoginSuccess = new Log
                    {
                        UserId = account.Id,
                        Action = SEDConst.WRITE_LOG_UPDATE_LOGIN,
                        Time = SEDConst.WRITE_DATETIME_NOW
                    };
                    permissionContext.Logs.InsertOnSubmit(logWriteLoginSuccess);
                    permissionContext.SubmitChanges();
                    ProgressLoginSuccess(account);
                }
            }
            catch (Exception ex)
            {
                //SEDConst.AUTHENTICATION_NOT_FIND_DATA
                XtraMessageBox.Show(ex.Message, SEDConst.TITLE_WARNING
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Create By: ManhNV1 -Date: 02/22/2016
        /// Description: Progress Login Success
        /// </summary>
        /// <param name="account">Account account login</param>
        private void ProgressLoginSuccess(Account account)
        {
            if (chkRememberLogin.Checked)
            {
                //Save Information UserLogin and Password
                ProcessMeAccount(txtUserName.Text, txtPassword.Text);
            }
            XtraMessageBox.Show(string.Format(SEDConst.AUTHENTICATION_MESSAGE_LOGINSUCCESS, account.FullName)
            , SEDConst.TITLE_NOTE
            , MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Send User Information
            Id = (int) account.Id;
            FrmMain.FrmMainDynamic.CheckLoginPermission((int) account.Permission);
            Hide();
        }

        /// <summary>
        /// Create By: ManhNV1 -Date: 02/22/2016
        /// Description: Progress Remember Password after Login Success
        /// </summary>
        /// <param name="userName">String UserName</param>
        /// <param name="passWord">String Password</param>
        private void ProcessMeAccount(string userName, string passWord)
        {
            // Progress Encode Data
            var userEncrypt = new SEDDataEncrypt();
            var strUserLoginEncode = userEncrypt.EncodeTwoWay(userName);
            var strPasswordEncode = userEncrypt.EncodeTwoWay(passWord);
            var userLoginRemember = new UserLoginRemember
            {
                UserLogin = strUserLoginEncode,
                Password = strPasswordEncode,
                LogTime = DateTime.Now.ToLongTimeString()
            };
            var userJsonSave = JsonConvert.SerializeObject(userLoginRemember, Formatting.Indented);
            // Write Information UserLogin
            File.WriteAllText(SEDConst.PATH_USER_LOGIN, userJsonSave, Encoding.UTF8);
        }

        #region Global Variable
        /** Id UserLogin Success*/
        public static int Id;
        #endregion
    }
}