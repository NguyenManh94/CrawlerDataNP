namespace SSWA_ExtractData.UserInterface
{
    partial class FrmAccoutsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccoutsList));
            this.barToggleSwitchItem1 = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetStatus = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreate = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barManagerCrud = new DevExpress.XtraBars.BarManager(this.components);
            this.gcShowListAccount = new DevExpress.XtraEditors.GroupControl();
            this.gcShowAccountData = new DevExpress.XtraGrid.GridControl();
            this.gvShowAccountData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPermission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SSWA_ExtractData.UserInterface.WaitFormPlease), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerCrud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShowListAccount)).BeginInit();
            this.gcShowListAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcShowAccountData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowAccountData)).BeginInit();
            this.SuspendLayout();
            // 
            // barToggleSwitchItem1
            // 
            this.barToggleSwitchItem1.Caption = "barToggleSwitchItem1";
            this.barToggleSwitchItem1.Id = 0;
            this.barToggleSwitchItem1.Name = "barToggleSwitchItem1";
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 529);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(967, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 529);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 555);
            this.barDockControlBottom.Size = new System.Drawing.Size(967, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(967, 26);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Glyph = global::SSWA_ExtractData.Properties.Resources.reload;
            this.btnReload.Id = 4;
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.Caption = "Set Status";
            this.btnSetStatus.Glyph = global::SSWA_ExtractData.Properties.Resources.sua1;
            this.btnSetStatus.Id = 3;
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetStatus_ItemClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Caption = "Create";
            this.btnCreate.Glyph = global::SSWA_ExtractData.Properties.Resources.them1;
            this.btnCreate.Id = 1;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreate_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCreate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSetStatus, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barManagerCrud
            // 
            this.barManagerCrud.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManagerCrud.DockControls.Add(this.barDockControlTop);
            this.barManagerCrud.DockControls.Add(this.barDockControlBottom);
            this.barManagerCrud.DockControls.Add(this.barDockControlLeft);
            this.barManagerCrud.DockControls.Add(this.barDockControlRight);
            this.barManagerCrud.Form = this;
            this.barManagerCrud.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barToggleSwitchItem1,
            this.btnCreate,
            this.btnSetStatus,
            this.btnReload});
            this.barManagerCrud.MainMenu = this.bar2;
            this.barManagerCrud.MaxItemId = 5;
            // 
            // gcShowListAccount
            // 
            this.gcShowListAccount.Controls.Add(this.gcShowAccountData);
            this.gcShowListAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcShowListAccount.Location = new System.Drawing.Point(0, 26);
            this.gcShowListAccount.Name = "gcShowListAccount";
            this.gcShowListAccount.Size = new System.Drawing.Size(967, 529);
            this.gcShowListAccount.TabIndex = 5;
            this.gcShowListAccount.Text = "List Account";
            // 
            // gcShowAccountData
            // 
            this.gcShowAccountData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcShowAccountData.Location = new System.Drawing.Point(2, 21);
            this.gcShowAccountData.MainView = this.gvShowAccountData;
            this.gcShowAccountData.MenuManager = this.barManagerCrud;
            this.gcShowAccountData.Name = "gcShowAccountData";
            this.gcShowAccountData.Size = new System.Drawing.Size(963, 506);
            this.gcShowAccountData.TabIndex = 0;
            this.gcShowAccountData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShowAccountData});
            // 
            // gvShowAccountData
            // 
            this.gvShowAccountData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcId,
            this.gcFullName,
            this.gcAddress,
            this.gcPhone,
            this.gcEmail,
            this.gcUserName,
            this.gcPermission,
            this.gcStatus});
            this.gvShowAccountData.GridControl = this.gcShowAccountData;
            this.gvShowAccountData.Name = "gvShowAccountData";
            this.gvShowAccountData.OptionsFind.AlwaysVisible = true;
            this.gvShowAccountData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvShowAccountData_FocusedRowChanged);
            // 
            // gcId
            // 
            this.gcId.Caption = "Id";
            this.gcId.FieldName = "Id";
            this.gcId.Name = "gcId";
            this.gcId.Visible = true;
            this.gcId.VisibleIndex = 0;
            this.gcId.Width = 49;
            // 
            // gcFullName
            // 
            this.gcFullName.Caption = "Full Name";
            this.gcFullName.FieldName = "FullName";
            this.gcFullName.Name = "gcFullName";
            this.gcFullName.Visible = true;
            this.gcFullName.VisibleIndex = 1;
            this.gcFullName.Width = 147;
            // 
            // gcAddress
            // 
            this.gcAddress.Caption = "Address";
            this.gcAddress.FieldName = "Address";
            this.gcAddress.Name = "gcAddress";
            this.gcAddress.Visible = true;
            this.gcAddress.VisibleIndex = 2;
            this.gcAddress.Width = 197;
            // 
            // gcPhone
            // 
            this.gcPhone.Caption = "Phone";
            this.gcPhone.FieldName = "Phone";
            this.gcPhone.Name = "gcPhone";
            this.gcPhone.Visible = true;
            this.gcPhone.VisibleIndex = 3;
            this.gcPhone.Width = 104;
            // 
            // gcEmail
            // 
            this.gcEmail.Caption = "Email";
            this.gcEmail.FieldName = "Email";
            this.gcEmail.Name = "gcEmail";
            this.gcEmail.Visible = true;
            this.gcEmail.VisibleIndex = 4;
            this.gcEmail.Width = 151;
            // 
            // gcUserName
            // 
            this.gcUserName.Caption = "User Name";
            this.gcUserName.FieldName = "UserName";
            this.gcUserName.Name = "gcUserName";
            this.gcUserName.Visible = true;
            this.gcUserName.VisibleIndex = 5;
            this.gcUserName.Width = 111;
            // 
            // gcPermission
            // 
            this.gcPermission.Caption = "Permission";
            this.gcPermission.FieldName = "Permission";
            this.gcPermission.Name = "gcPermission";
            this.gcPermission.Visible = true;
            this.gcPermission.VisibleIndex = 6;
            this.gcPermission.Width = 93;
            // 
            // gcStatus
            // 
            this.gcStatus.Caption = "Status";
            this.gcStatus.FieldName = "Status";
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.Visible = true;
            this.gcStatus.VisibleIndex = 7;
            this.gcStatus.Width = 92;
            // 
            // FrmAccoutsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 555);
            this.Controls.Add(this.gcShowListAccount);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAccoutsList";
            this.Text = "List system account";
            this.Load += new System.EventHandler(this.FrmAccoutsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerCrud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShowListAccount)).EndInit();
            this.gcShowListAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcShowAccountData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowAccountData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnSetStatus;
        private DevExpress.XtraBars.BarButtonItem btnCreate;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarManager barManagerCrud;
        private DevExpress.XtraEditors.GroupControl gcShowListAccount;
        private DevExpress.XtraGrid.GridControl gcShowAccountData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvShowAccountData;
        private DevExpress.XtraGrid.Columns.GridColumn gcId;
        private DevExpress.XtraGrid.Columns.GridColumn gcFullName;
        private DevExpress.XtraGrid.Columns.GridColumn gcAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gcPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gcPermission;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}