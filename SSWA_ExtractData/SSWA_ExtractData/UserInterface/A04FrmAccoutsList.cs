﻿using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using FastMember;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using PermissionContext;
using SSWA_ExtractData.Common;
using SSWA_ExtractData.Common.Constant;
using SSWA_ExtractData.Entity.PrintEntity;

namespace SSWA_ExtractData.UserInterface
{
    //TODO Comment
    public partial class A04FrmAccoutsList : XtraForm
    {
        private int index;

        public A04FrmAccoutsList()
        {
            InitializeComponent();
        }

        private void FrmAccoutsList_Load(object sender, EventArgs e)
        {
            LoadListAccouts();
        }

        private void btnReload_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadListAccouts();
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
                gcShowAccountData.DataSource = listAccounts;
            }
        }

        private void btnCreate_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmAccoutCrud = new A05FrmAccoutsCrud();
            frmAccoutCrud.ShowDialog();
            LoadListAccouts();
        }

        private void gvShowAccountData_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void btnSetStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            var getId = 0;
            try
            {
                getId = int.Parse(gvShowAccountData.GetRowCellValue(index, "Id").ToStringNew());
            }
            catch
            {
                SEDFuncCall.MessageWarning(SEDConst.MESSAGE_CLICK_GRIDVIEW, SEDConst.TITLE_WARNING);
                return;
            }
            using (var permissionContext = new PermissionDataContext())
            {
                var getAccountChoice = permissionContext.Accounts.SingleOrDefault(a => a.Id == getId);
                var strActionNew = (getAccountChoice.Status == 0)
                    ? string.Format(SEDConst.WRITE_LOG_UPDATE_STATUS_ACCOUNT, getAccountChoice.UserName)
                    : string.Format(SEDConst.WRITE_LOG_UPDATE_STATUS_ACCOUNT_STOP, getAccountChoice.UserName);
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
                    UserId = A01FrmAuthentication.Id,
                    Action = strActionNew,
                    Time = SEDConst.WRITE_DATETIME_NOW
                };
                getAccountChoice.Status = (getAccountChoice.Status == 0) ? 1 : 0;
                permissionContext.Logs.InsertOnSubmit(logUpdateAction);
                var strMessageUpdateSuccess = SEDConst.STRING_EMPTY;
                if (setActive)
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
                LoadListAccouts();
            }
        }

        private void barBtnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = XtraMessageBox.Show("You may want to export data !", SEDConst.TITLE_NOTE
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (var permissionContext = new PermissionDataContext())
                {
                    var listAccounts = permissionContext.Accounts
                        .Select(a => new AccountPrint
                        {
                            Id = a.Id,
                            FullName = a.FullName,
                            Address = a.Address,
                            Phone = a.Phone,
                            Email = a.Email,
                            UserName = a.UserName,
                            Permission = (a.Permission == 0) ? SEDConst.QUERY_STAFF : SEDConst.QUERY_ADMINISTRATOR,
                            Status = (a.Status == 0) ? SEDConst.QUERY_NOT_ACTIVE : SEDConst.QUERY_ACTIVE
                        });
                    SetPrintListAccount(listAccounts);
                }
            }
        }

        /// <summary>
        ///     [EN] SetPrintListAccount
        ///     Create By: ManhNV1 -Date: 03/27/2016
        ///     Description: Set PrintData
        /// </summary>
        /// <param name="listAccounts"></param>
        private void SetPrintListAccount(IQueryable<AccountPrint> listAccounts)
        {
            string[] paramHeaderText =
            {
                "Id", "FullName", "Address", "Phone", "Email", "UserName", "Permission",
                "Status"
            };
            var dtPrint = ConvertIEnumerableToDataTable(listAccounts, paramHeaderText);
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (Version 2007 or more (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    var exportFilePath = saveDialog.FileName;
                    var newFile = new FileInfo(exportFilePath);
                    using (var package = new ExcelPackage(newFile))
                    {
                        //Create New Sheet vs Name = "NewSheet1"
                        var worksheet = package.Workbook.Worksheets.Add("NewSheet1");
                        //Load dữ liệu từ DataTable dt vào WorkSheet vừa tạo, bắt đầu từ ô A1, với kiểu Table không có định dạng
                        worksheet.Cells["A1"].LoadFromDataTable(dtPrint, true, TableStyles.None);
                        //Save File Excel
                        package.Save();
                    }
                }
            }
        }

        /// <summary>
        ///     [EN] ConvertIEnumerableToDataTable
        ///     Create By: ManhNV1 -Date: 03/27/2016
        ///     Description: Convert Type IEnumerable to Datatabe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">List need Print</param>
        /// <param name="paramHeaderText">array string parameter</param>
        /// <returns></returns>
        private DataTable ConvertIEnumerableToDataTable<T>(IQueryable<T> data, string[] paramHeaderText)
        {
            var dtConvert = new DataTable();
            using (var reader = ObjectReader.Create(data, paramHeaderText))
            {
                dtConvert.Load(reader);
            }
            return dtConvert;
        }
    }
}