namespace SSWA_ExtractData.UserInterface
{
    partial class A06FrmChangePass
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
            if (disposing && (components!= null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A06FrmChangePass));
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barBtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnReload = new DevExpress.XtraBars.BarButtonItem();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.barListMessageChangePass = new DevExpress.XtraBars.BarListItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkPassOld = new DevExpress.XtraEditors.CheckEdit();
            this.progressBarShowInfor = new DevExpress.XtraWaitForm.ProgressPanel();
            this.chkValidAll = new System.Windows.Forms.CheckBox();
            this.txtRePass = new DevExpress.XtraEditors.TextEdit();
            this.txtPassNew = new DevExpress.XtraEditors.TextEdit();
            this.txtPassOld = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlPassOld = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlPassNew = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlEnterRePass = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPassOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRePass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPassOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPassNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlEnterRePass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar4,
            this.bar5});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnReload,
            this.barBtnSave,
            this.barListMessageChangePass});
            this.barManager1.MainMenu = this.bar4;
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar5;
            // 
            // bar4
            // 
            this.bar4.BarName = "Main menu";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar4.OptionsBar.MultiLine = true;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Main menu";
            // 
            // barBtnSave
            // 
            this.barBtnSave.Caption = "Save";
            this.barBtnSave.Glyph = global::SSWA_ExtractData.Properties.Resources.save;
            this.barBtnSave.Id = 1;
            this.barBtnSave.Name = "barBtnSave";
            this.barBtnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSave_ItemClick);
            // 
            // barBtnReload
            // 
            this.barBtnReload.Caption = "Reload";
            this.barBtnReload.Glyph = global::SSWA_ExtractData.Properties.Resources.reload;
            this.barBtnReload.Id = 0;
            this.barBtnReload.Name = "barBtnReload";
            this.barBtnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnReload_ItemClick);
            // 
            // bar5
            // 
            this.bar5.BarName = "Status bar";
            this.bar5.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barListMessageChangePass)});
            this.bar5.OptionsBar.AllowQuickCustomization = false;
            this.bar5.OptionsBar.DrawDragBorder = false;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Status bar";
            // 
            // barListMessageChangePass
            // 
            this.barListMessageChangePass.Caption = "Security: Password Change";
            this.barListMessageChangePass.Id = 3;
            this.barListMessageChangePass.Name = "barListMessageChangePass";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(512, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 188);
            this.barDockControlBottom.Size = new System.Drawing.Size(512, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 162);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(512, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 162);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pictureBox1);
            this.layoutControl1.Controls.Add(this.chkPassOld);
            this.layoutControl1.Controls.Add(this.progressBarShowInfor);
            this.layoutControl1.Controls.Add(this.chkValidAll);
            this.layoutControl1.Controls.Add(this.txtRePass);
            this.layoutControl1.Controls.Add(this.txtPassNew);
            this.layoutControl1.Controls.Add(this.txtPassOld);
            this.layoutControl1.Controls.Add(this.txtUserName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(512, 162);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SSWA_ExtractData.Properties.Resources.keepassx;
            this.pictureBox1.Location = new System.Drawing.Point(400, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // chkPassOld
            // 
            this.chkPassOld.Location = new System.Drawing.Point(400, 36);
            this.chkPassOld.MenuManager = this.barManager1;
            this.chkPassOld.Name = "chkPassOld";
            this.chkPassOld.Properties.Caption = "Check PassOld";
            this.chkPassOld.Size = new System.Drawing.Size(100, 19);
            this.chkPassOld.StyleController = this.layoutControl1;
            this.chkPassOld.TabIndex = 6;
            this.chkPassOld.CheckedChanged += new System.EventHandler(this.chkPassOld_CheckedChanged);
            // 
            // progressBarShowInfor
            // 
            this.progressBarShowInfor.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressBarShowInfor.Appearance.Options.UseBackColor = true;
            this.progressBarShowInfor.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressBarShowInfor.AppearanceCaption.Options.UseFont = true;
            this.progressBarShowInfor.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressBarShowInfor.AppearanceDescription.Options.UseFont = true;
            this.progressBarShowInfor.Caption = "ExtracData Proffessional";
            this.progressBarShowInfor.Location = new System.Drawing.Point(12, 132);
            this.progressBarShowInfor.Name = "progressBarShowInfor";
            this.progressBarShowInfor.Size = new System.Drawing.Size(488, 16);
            this.progressBarShowInfor.StyleController = this.layoutControl1;
            this.progressBarShowInfor.TabIndex = 9;
            this.progressBarShowInfor.Text = "progressPanel1";
            // 
            // chkValidAll
            // 
            this.chkValidAll.Location = new System.Drawing.Point(12, 108);
            this.chkValidAll.Name = "chkValidAll";
            this.chkValidAll.Size = new System.Drawing.Size(384, 20);
            this.chkValidAll.TabIndex = 9;
            this.chkValidAll.Text = "Check Valid";
            this.chkValidAll.UseVisualStyleBackColor = true;
            this.chkValidAll.CheckedChanged += new System.EventHandler(this.chkValidAll_CheckedChanged);
            // 
            // txtRePass
            // 
            this.txtRePass.Location = new System.Drawing.Point(109, 84);
            this.txtRePass.MenuManager = this.barManager1;
            this.txtRePass.Name = "txtRePass";
            this.txtRePass.Properties.PasswordChar = '*';
            this.txtRePass.Properties.UseSystemPasswordChar = true;
            this.txtRePass.Size = new System.Drawing.Size(287, 20);
            this.txtRePass.StyleController = this.layoutControl1;
            this.txtRePass.TabIndex = 8;
            // 
            // txtPassNew
            // 
            this.txtPassNew.Location = new System.Drawing.Point(109, 60);
            this.txtPassNew.MenuManager = this.barManager1;
            this.txtPassNew.Name = "txtPassNew";
            this.txtPassNew.Properties.PasswordChar = '*';
            this.txtPassNew.Properties.UseSystemPasswordChar = true;
            this.txtPassNew.Size = new System.Drawing.Size(287, 20);
            this.txtPassNew.StyleController = this.layoutControl1;
            this.txtPassNew.TabIndex = 7;
            // 
            // txtPassOld
            // 
            this.txtPassOld.Location = new System.Drawing.Point(109, 36);
            this.txtPassOld.MenuManager = this.barManager1;
            this.txtPassOld.Name = "txtPassOld";
            this.txtPassOld.Properties.PasswordChar = '*';
            this.txtPassOld.Properties.UseSystemPasswordChar = true;
            this.txtPassOld.Size = new System.Drawing.Size(287, 20);
            this.txtPassOld.StyleController = this.layoutControl1;
            this.txtPassOld.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(109, 12);
            this.txtUserName.MenuManager = this.barManager1;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(391, 20);
            this.txtUserName.StyleController = this.layoutControl1;
            this.txtUserName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlUserName,
            this.layoutControlPassOld,
            this.layoutControlPassNew,
            this.layoutControlEnterRePass,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(512, 162);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlUserName
            // 
            this.layoutControlUserName.Control = this.txtUserName;
            this.layoutControlUserName.CustomizationFormText = "UserLogin";
            this.layoutControlUserName.Location = new System.Drawing.Point(0, 0);
            this.layoutControlUserName.Name = "layoutControlUserName";
            this.layoutControlUserName.Size = new System.Drawing.Size(492, 24);
            this.layoutControlUserName.Text = "UserName";
            this.layoutControlUserName.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlPassOld
            // 
            this.layoutControlPassOld.Control = this.txtPassOld;
            this.layoutControlPassOld.CustomizationFormText = "Password Old";
            this.layoutControlPassOld.Location = new System.Drawing.Point(0, 24);
            this.layoutControlPassOld.Name = "layoutControlPassOld";
            this.layoutControlPassOld.Size = new System.Drawing.Size(388, 24);
            this.layoutControlPassOld.Text = "Password Old";
            this.layoutControlPassOld.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlPassNew
            // 
            this.layoutControlPassNew.Control = this.txtPassNew;
            this.layoutControlPassNew.CustomizationFormText = "Password New";
            this.layoutControlPassNew.Location = new System.Drawing.Point(0, 48);
            this.layoutControlPassNew.Name = "layoutControlPassNew";
            this.layoutControlPassNew.Size = new System.Drawing.Size(388, 24);
            this.layoutControlPassNew.Text = "Password New";
            this.layoutControlPassNew.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlEnterRePass
            // 
            this.layoutControlEnterRePass.Control = this.txtRePass;
            this.layoutControlEnterRePass.CustomizationFormText = "Enter the password";
            this.layoutControlEnterRePass.Location = new System.Drawing.Point(0, 72);
            this.layoutControlEnterRePass.Name = "layoutControlEnterRePass";
            this.layoutControlEnterRePass.Size = new System.Drawing.Size(388, 24);
            this.layoutControlEnterRePass.Text = "Enter the password";
            this.layoutControlEnterRePass.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkValidAll;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(388, 24);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.progressBarShowInfor;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(492, 22);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkPassOld;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(388, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 24);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pictureBox1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(388, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(104, 72);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // FrmChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 212);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Change";
            this.Load += new System.EventHandler(this.FrmChangePass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPassOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRePass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPassOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPassNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlEnterRePass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarButtonItem barBtnReload;
        private DevExpress.XtraBars.BarButtonItem barBtnSave;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarListItem barListMessageChangePass;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.CheckEdit chkPassOld;
        private DevExpress.XtraWaitForm.ProgressPanel progressBarShowInfor;
        private System.Windows.Forms.CheckBox chkValidAll;
        private DevExpress.XtraEditors.TextEdit txtRePass;
        private DevExpress.XtraEditors.TextEdit txtPassNew;
        private DevExpress.XtraEditors.TextEdit txtPassOld;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlUserName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlPassOld;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlPassNew;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlEnterRePass;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;


    }
}