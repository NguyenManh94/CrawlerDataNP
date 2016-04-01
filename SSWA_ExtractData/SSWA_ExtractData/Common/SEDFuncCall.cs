using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Linq;
using SSWA_ExtractData.Common.Security;
using DevExpress.XtraSplashScreen;
using SSWA_ExtractData.Common.Constant;

namespace SSWA_ExtractData.Common
{
    /// <summary>
    /// [EN] SSWAFunctionCall
    /// Create by: ManhNV1 -Date: 02/20/2016
    /// Function: Call Common Used
    /// </summary>
    // ReSharper disable once InconsistentNaming
    static class SEDFuncCall
    {
        #region Function Void
        /// <summary>
        /// [EN]
        /// Create By: ManhNV1 -Date: 02/22/2016
        /// </summary>
        /// <param name="btnSet">Array Button need SetEnable</param>
        /// <param name="setEnable">Value set</param>
        public static void SetButtonEnable(BarButtonItem[] btnSet, bool setEnable)
        {
            if (btnSet == null) throw new ArgumentNullException("btnSet");
            foreach (var btnItem in btnSet)
            { btnItem.Enabled = setEnable; }
        }

        /// <summary>
        /// [EN] SetDefaultExit
        /// Create By: ManhNV1 -Date: 02/23/2016
        /// Description: Set Application Exit Default
        /// </summary>
        /// <param name="e">FormClosingEventArgs Click</param>
        public static void SetDefaultExit(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = XtraMessageBox.Show(SEDConst.MAIN_MESSAGE_CLOSEPROGRAM
                , SEDConst.TITLE_NOTE
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) { e.Cancel = true; }
                else { e.Cancel = false; Application.Exit(); }
            }
        }

        /// <summary>
        /// [EN] SetAppExit
        /// Create By: ManhNV1 -Date: 02/23/2016
        /// Description: Set Application Exit
        /// </summary>
        public static void SetAppExit()
        {
            var result = XtraMessageBox.Show(SEDConst.MAIN_MESSAGE_CLOSEPROGRAM
                , SEDConst.TITLE_NOTE
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { Application.Exit(); }
        }

        /// <summary>
        /// [EN] SetTextEditReadonly
        /// Create By: ManhNV1 -Date: 02/23/2016
        /// Description: Set Readonly TextEdit
        /// </summary>
        /// <param name="arrTextEdit">ArrayTextEdit</param>
        /// <param name="valueSet">Bool set Readonly</param>
        public static void SetTextEditReadonly(TextEdit[] arrTextEdit, bool valueSet)
        {
            foreach (var item in arrTextEdit)
            {
                item.ReadOnly = valueSet;
            }
        }

        /// <summary>
        /// [EN] SetTextEditValue
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Set Common Value to TextEdit
        /// </summary>
        /// <param name="arrTextEdit">TextEdit[] ArrayTextEdit</param>
        /// <param name="valueSet">string set Value Text</param>
        public static void SetTextEditValue(TextEdit[] arrTextEdit, string valueSet)
        {
            if (arrTextEdit == null) throw new ArgumentNullException("arrTextEdit");
            foreach (var item in arrTextEdit)
            {
                item.Text = valueSet;
            }
        }

        /// <summary>
        /// [EN] SetTextBoxValue
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Set Common Value to TextBox
        /// </summary>
        /// <param name="arrTextBox">TextBox[] ArrayTextBox</param>
        /// <param name="valueSet">string set Value Text</param>
        public static void SetTextBoxValue(IEnumerable<TextBox> arrTextBox, string valueSet)
        {
            foreach (var item in arrTextBox)
            {
                item.Text = valueSet;
            }
        }

        /// <summary>
        /// [EN] SetCheckBoxStatus
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Set Common CheckState to CheckBox
        /// </summary>
        /// <param name="arrCheckBox"></param>
        /// <param name="checkState">CheckState Type Check or Uncheck</param>
        public static void SetCheckBoxStatus(CheckBox[] arrCheckBox, CheckState checkState)
        {
            if (arrCheckBox == null) throw new ArgumentNullException("arrCheckBox");
            foreach (var item in arrCheckBox)
            {
                item.CheckState = checkState;
            }
        }

        #endregion

        #region Function Return Value
        /// <summary>
        /// [EN] CheckStringMatch
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// </summary>
        /// <param name="strPatern">String Patern</param>
        /// <param name="strInput">String Input</param>
        /// <returns></returns>
        public static bool CheckStringMatch(string strPatern, string strInput)
        {
            var checkValid = new Regex(strPatern).Match(strInput);
            return checkValid.Success;
        }

        /// <summary>
        /// [EN] CheckTextBoxEmpty
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Check Empty TextBox in ArrayTextBox
        /// </summary>
        /// <param name="textBoxCheck">TextBox[] textBox need CheckEmpty</param>
        /// <returns></returns>
        public static bool CheckTextBoxEmpty(TextBox[] textBoxCheck)
        {
            foreach (var item in textBoxCheck)
            {
                if (item.Text.Equals(""))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// [EN] CheckTextEditEmpty
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Check Empty TextEdit in ArrayTextEdit
        /// </summary>
        /// <param name="textEditCheck">TextEdit[] textEdit need CheckEmpty</param>
        /// <returns></returns>
        public static bool CheckTextEditEmpty(TextEdit[] textEditCheck)
        {
            return textEditCheck.Any(item => item.Text.Equals(""));
        }

        /// <summary>
        /// [EN] InforHardware
        /// Create By: ManhNV1 -Date:02/25/2016
        /// Descripton: Demo GetKeys 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> InforHardware()
        {
            var dcMap = new Dictionary<string, string>
            {
                {SEDKeys.MachineName, Environment.MachineName.ToStringNew()},
                {SEDKeys.Version, Environment.Version.ToString()},
                {SEDKeys.Processorcount, Environment.ProcessorCount.ToString()},
                {SEDKeys.Osversion, Environment.OSVersion.ToString()},
                {SEDKeys.CpuSpeed, SEDHardwareInfor.GetCpuSpeedInGHz().ToString()},
                {SEDKeys.CpuMarker, SEDHardwareInfor.GetCPUManufacturer().ToStringNew()},
                {SEDKeys.PhysicalMemory, SEDHardwareInfor.GetPhysicalMemory().ToStringNew()}
            };
            return dcMap;
        }

        /// <summary>
        /// [EN] ShowWaitForm
        /// Create By: ManhNV1 -Date:02/25/2016
        /// Descripton: ShowWaitForm 
        /// </summary>
        /// <param name="frmWaitForm">Form Used</param>
        /// <param name="strCaption">Title WaitForm: 
        /// if strCaption = null => Value = Please Wait
        /// else => Value = strCaption
        /// </param>
        /// <param name="strDescription">Description WaitForm</param>
        /// <returns>SplashScreenManager Type</returns>
        public static SplashScreenManager ShowWaitForm(Form frmWaitForm, string strCaption
            , string strDescription)
        {
            var splashScreenManager = new SplashScreenManager(frmWaitForm
                , typeof(UserInterface.WaitFormPlease), true, true);
            splashScreenManager.ShowWaitForm();
            if (strCaption == null)
                splashScreenManager.SetWaitFormCaption(SEDConst.SET_PLEASE_WAIT);
            else splashScreenManager.SetWaitFormCaption(strCaption);
            // Nếu Null thì dùng strDescription không thì  Set_Loading
            splashScreenManager.SetWaitFormDescription(strDescription ?? SEDConst.SET_LOADING);
            return splashScreenManager;
        }
        #endregion

        #region Function Custom .Net
        /// <summary>
        /// [EN] SetCheckBoxStatus
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Set Common CheckState to CheckBox
        /// </summary>
        /// <param name="checkBox">CheckBox one checkbox</param>
        /// <param name="checkState">int Set Value: 0-Unchecked | 1-Checked | Indeterminate </param>
        public static void SetCheckBoxStatus(CheckBox checkBox, int checkState)
        {
            switch (checkState)
            {
                case 0:
                    checkBox.CheckState = CheckState.Unchecked;
                    break;
                case 1:
                    checkBox.CheckState = CheckState.Checked;
                    break;
                default:
                    checkBox.CheckState = CheckState.Indeterminate;
                    break;
            }
        }

        /// <summary>
        /// [EN] SetCheckEditStatus
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Set Common CheckState to CheckBox
        /// </summary>
        /// <param name="checkEdit">CheckEdit one checkEdit</param>
        /// <param name="checkState">int Set Value: 0-Unchecked | 1-Checked | Indeterminate </param>0
        public static void SetCheckEditStatus(CheckEdit checkEdit, int checkState)
        {
            if (checkState == 0)
                checkEdit.CheckState = CheckState.Unchecked;
            else if (checkState == 1)
                checkEdit.CheckState = CheckState.Checked;
            else checkEdit.CheckState = CheckState.Indeterminate;
        }

        /// <summary>
        /// [EN] MessageWarning
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Set Common Show Message
        /// </summary>
        /// <param name="text">string Message</param>
        /// <param name="title">string title Value</param>
        public static void MessageWarning(string text, string title)
        {
            XtraMessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// [EN] MessageSuccess
        /// Create By: ManhNV1 -Date: 02/24/2016
        /// Description: Set Common Show Message
        /// </summary>
        /// <param name="text">string Message</param>
        /// <param name="title">string title Value</param>
        public static void MessageSuccess(string text, string title)
        {
            XtraMessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
