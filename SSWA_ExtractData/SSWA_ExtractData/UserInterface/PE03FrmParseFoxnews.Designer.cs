namespace SSWA_ExtractData.UserInterface
{
    partial class PE03FrmParseFoxnews
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grItemTopic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShowCateInfor = new DevExpress.XtraGrid.GridControl();
            this.gvShowCateInfor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grLinkPage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShowCate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnShowListData = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControlShowData = new DevExpress.XtraEditors.PanelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gcShowFeeds = new DevExpress.XtraGrid.GridControl();
            this.gvShowFeeds = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLink = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPubDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnEditView = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcDownLoadContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDownLoadContent = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.pnChoiceParseData = new DevExpress.XtraEditors.PanelControl();
            this.txtEditUrl = new DevExpress.XtraEditors.TextEdit();
            this.txtEditPathDefault = new DevExpress.XtraEditors.TextEdit();
            this.btnSetPath = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetContent = new DevExpress.XtraEditors.SimpleButton();
            this.chkSinglePage = new System.Windows.Forms.CheckBox();
            this.barStaticParseData = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barManagerBCC = new DevExpress.XtraBars.BarManager(this.components);
            this.barStaticCate = new DevExpress.XtraBars.BarStaticItem();
            this.toolTipShowUrl = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcShowCateInfor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowCateInfor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowListData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlShowData)).BeginInit();
            this.panelControlShowData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcShowFeeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowFeeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownLoadContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnChoiceParseData)).BeginInit();
            this.pnChoiceParseData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditPathDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerBCC)).BeginInit();
            this.SuspendLayout();
            // 
            // grItemTopic
            // 
            this.grItemTopic.Caption = "Topic name";
            this.grItemTopic.FieldName = "TopicName";
            this.grItemTopic.Name = "grItemTopic";
            this.grItemTopic.Visible = true;
            this.grItemTopic.VisibleIndex = 0;
            this.grItemTopic.Width = 160;
            // 
            // gcShowCateInfor
            // 
            this.gcShowCateInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcShowCateInfor.Location = new System.Drawing.Point(2, 21);
            this.gcShowCateInfor.MainView = this.gvShowCateInfor;
            this.gcShowCateInfor.Name = "gcShowCateInfor";
            this.gcShowCateInfor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnShowListData});
            this.gcShowCateInfor.Size = new System.Drawing.Size(383, 525);
            this.gcShowCateInfor.TabIndex = 1;
            this.gcShowCateInfor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShowCateInfor});
            // 
            // gvShowCateInfor
            // 
            this.gvShowCateInfor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grItemTopic,
            this.grLinkPage,
            this.gcShowCate});
            this.gvShowCateInfor.GridControl = this.gcShowCateInfor;
            this.gvShowCateInfor.Name = "gvShowCateInfor";
            this.gvShowCateInfor.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvShowCateInfor.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvShowCateInfor.OptionsBehavior.ReadOnly = true;
            this.gvShowCateInfor.OptionsCustomization.AllowColumnMoving = false;
            this.gvShowCateInfor.OptionsCustomization.AllowColumnResizing = false;
            // 
            // grLinkPage
            // 
            this.grLinkPage.Caption = "Link Page";
            this.grLinkPage.FieldName = "Link";
            this.grLinkPage.Name = "grLinkPage";
            this.grLinkPage.Visible = true;
            this.grLinkPage.VisibleIndex = 1;
            this.grLinkPage.Width = 217;
            // 
            // gcShowCate
            // 
            this.gcShowCate.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShowCate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShowCate.Caption = "Load List";
            this.gcShowCate.ColumnEdit = this.btnShowListData;
            this.gcShowCate.Name = "gcShowCate";
            this.gcShowCate.Visible = true;
            this.gcShowCate.VisibleIndex = 2;
            // 
            // btnShowListData
            // 
            this.btnShowListData.AutoHeight = false;
            this.btnShowListData.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::SSWA_ExtractData.Properties.Resources.category_icon, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnShowListData.Name = "btnShowListData";
            this.btnShowListData.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcShowCateInfor);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(387, 548);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Category Information";
            // 
            // panelControlShowData
            // 
            this.panelControlShowData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlShowData.Controls.Add(this.groupControl4);
            this.panelControlShowData.Controls.Add(this.groupControl1);
            this.panelControlShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlShowData.Location = new System.Drawing.Point(2, 51);
            this.panelControlShowData.Name = "panelControlShowData";
            this.panelControlShowData.Size = new System.Drawing.Size(1300, 548);
            this.panelControlShowData.TabIndex = 5;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.gcShowFeeds);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(387, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(913, 548);
            this.groupControl4.TabIndex = 1;
            this.groupControl4.Text = "Parse Data";
            // 
            // gcShowFeeds
            // 
            this.gcShowFeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcShowFeeds.Location = new System.Drawing.Point(2, 21);
            this.gcShowFeeds.MainView = this.gvShowFeeds;
            this.gcShowFeeds.Name = "gcShowFeeds";
            this.gcShowFeeds.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnEditView,
            this.btnDownLoadContent});
            this.gcShowFeeds.Size = new System.Drawing.Size(909, 525);
            this.gcShowFeeds.TabIndex = 1;
            this.gcShowFeeds.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShowFeeds});
            // 
            // gvShowFeeds
            // 
            this.gvShowFeeds.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTitle,
            this.gcLink,
            this.gcPubDate,
            this.gcView,
            this.gcDownLoadContent});
            this.gvShowFeeds.GridControl = this.gcShowFeeds;
            this.gvShowFeeds.Name = "gvShowFeeds";
            this.gvShowFeeds.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvShowFeeds.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvShowFeeds.OptionsBehavior.ReadOnly = true;
            // 
            // gcTitle
            // 
            this.gcTitle.Caption = "Title";
            this.gcTitle.FieldName = "Title";
            this.gcTitle.Name = "gcTitle";
            this.gcTitle.Visible = true;
            this.gcTitle.VisibleIndex = 0;
            this.gcTitle.Width = 289;
            // 
            // gcLink
            // 
            this.gcLink.Caption = "Link";
            this.gcLink.FieldName = "Link";
            this.gcLink.Name = "gcLink";
            this.gcLink.Visible = true;
            this.gcLink.VisibleIndex = 1;
            this.gcLink.Width = 277;
            // 
            // gcPubDate
            // 
            this.gcPubDate.Caption = "Publish Date";
            this.gcPubDate.FieldName = "PubDate";
            this.gcPubDate.Name = "gcPubDate";
            this.gcPubDate.Visible = true;
            this.gcPubDate.VisibleIndex = 2;
            this.gcPubDate.Width = 166;
            // 
            // gcView
            // 
            this.gcView.AppearanceHeader.Options.UseTextOptions = true;
            this.gcView.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcView.Caption = "ViewData";
            this.gcView.ColumnEdit = this.btnEditView;
            this.gcView.Name = "gcView";
            this.gcView.Visible = true;
            this.gcView.VisibleIndex = 3;
            // 
            // btnEditView
            // 
            this.btnEditView.Appearance.Options.UseTextOptions = true;
            this.btnEditView.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnEditView.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnEditView.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnEditView.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnEditView.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnEditView.AppearanceReadOnly.Options.UseTextOptions = true;
            this.btnEditView.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnEditView.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnEditView.AutoHeight = false;
            this.btnEditView.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::SSWA_ExtractData.Properties.Resources.Actions_view_calendar_list_icon, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btnEditView.Name = "btnEditView";
            this.btnEditView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gcDownLoadContent
            // 
            this.gcDownLoadContent.AppearanceHeader.Options.UseTextOptions = true;
            this.gcDownLoadContent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDownLoadContent.Caption = "Download";
            this.gcDownLoadContent.ColumnEdit = this.btnDownLoadContent;
            this.gcDownLoadContent.Name = "gcDownLoadContent";
            this.gcDownLoadContent.Visible = true;
            this.gcDownLoadContent.VisibleIndex = 4;
            this.gcDownLoadContent.Width = 79;
            // 
            // btnDownLoadContent
            // 
            this.btnDownLoadContent.AutoHeight = false;
            this.btnDownLoadContent.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::SSWA_ExtractData.Properties.Resources.save, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.btnDownLoadContent.Name = "btnDownLoadContent";
            this.btnDownLoadContent.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.panelControlShowData);
            this.groupControl3.Controls.Add(this.pnChoiceParseData);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1304, 601);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Data Analyzer";
            // 
            // pnChoiceParseData
            // 
            this.pnChoiceParseData.Controls.Add(this.txtEditUrl);
            this.pnChoiceParseData.Controls.Add(this.txtEditPathDefault);
            this.pnChoiceParseData.Controls.Add(this.btnSetPath);
            this.pnChoiceParseData.Controls.Add(this.btnGetContent);
            this.pnChoiceParseData.Controls.Add(this.chkSinglePage);
            this.pnChoiceParseData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnChoiceParseData.Location = new System.Drawing.Point(2, 21);
            this.pnChoiceParseData.Name = "pnChoiceParseData";
            this.pnChoiceParseData.Size = new System.Drawing.Size(1300, 30);
            this.pnChoiceParseData.TabIndex = 4;
            // 
            // txtEditUrl
            // 
            this.txtEditUrl.Location = new System.Drawing.Point(127, 5);
            this.txtEditUrl.Name = "txtEditUrl";
            this.txtEditUrl.Size = new System.Drawing.Size(339, 20);
            this.txtEditUrl.TabIndex = 6;
            // 
            // txtEditPathDefault
            // 
            this.txtEditPathDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditPathDefault.Location = new System.Drawing.Point(1085, 5);
            this.txtEditPathDefault.Name = "txtEditPathDefault";
            this.txtEditPathDefault.Properties.ReadOnly = true;
            this.txtEditPathDefault.Size = new System.Drawing.Size(210, 20);
            this.txtEditPathDefault.TabIndex = 5;
            // 
            // btnSetPath
            // 
            this.btnSetPath.Location = new System.Drawing.Point(1019, 5);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(64, 20);
            this.btnSetPath.TabIndex = 3;
            this.btnSetPath.Text = "Set Path";
            // 
            // btnGetContent
            // 
            this.btnGetContent.Location = new System.Drawing.Point(469, 5);
            this.btnGetContent.Name = "btnGetContent";
            this.btnGetContent.Size = new System.Drawing.Size(93, 20);
            this.btnGetContent.TabIndex = 2;
            this.btnGetContent.Text = "Get Content";
            // 
            // chkSinglePage
            // 
            this.chkSinglePage.AutoSize = true;
            this.chkSinglePage.Location = new System.Drawing.Point(10, 7);
            this.chkSinglePage.Name = "chkSinglePage";
            this.chkSinglePage.Size = new System.Drawing.Size(116, 17);
            this.chkSinglePage.TabIndex = 0;
            this.chkSinglePage.Text = "Choice Single Page";
            this.chkSinglePage.UseVisualStyleBackColor = true;
            // 
            // barStaticParseData
            // 
            this.barStaticParseData.Caption = "TopicName:";
            this.barStaticParseData.Id = 1;
            this.barStaticParseData.Name = "barStaticParseData";
            this.barStaticParseData.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 601);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1304, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 601);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 601);
            this.barDockControlBottom.Size = new System.Drawing.Size(1304, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1304, 0);
            // 
            // barManagerBCC
            // 
            this.barManagerBCC.DockControls.Add(this.barDockControlTop);
            this.barManagerBCC.DockControls.Add(this.barDockControlBottom);
            this.barManagerBCC.DockControls.Add(this.barDockControlLeft);
            this.barManagerBCC.DockControls.Add(this.barDockControlRight);
            this.barManagerBCC.Form = this;
            this.barManagerBCC.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticCate,
            this.barStaticParseData});
            this.barManagerBCC.MaxItemId = 2;
            // 
            // barStaticCate
            // 
            this.barStaticCate.Caption = "Categories: CNN -";
            this.barStaticCate.Id = 0;
            this.barStaticCate.Name = "barStaticCate";
            this.barStaticCate.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // PE03FrmParseFoxnews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 601);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PE03FrmParseFoxnews";
            this.Text = "PE03FrmParseFoxnews";
            ((System.ComponentModel.ISupportInitialize)(this.gcShowCateInfor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowCateInfor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowListData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlShowData)).EndInit();
            this.panelControlShowData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcShowFeeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowFeeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownLoadContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnChoiceParseData)).EndInit();
            this.pnChoiceParseData.ResumeLayout(false);
            this.pnChoiceParseData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditPathDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerBCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn grItemTopic;
        private DevExpress.XtraGrid.GridControl gcShowCateInfor;
        private DevExpress.XtraGrid.Views.Grid.GridView gvShowCateInfor;
        private DevExpress.XtraGrid.Columns.GridColumn grLinkPage;
        private DevExpress.XtraGrid.Columns.GridColumn gcShowCate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnShowListData;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControlShowData;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gcShowFeeds;
        private DevExpress.XtraGrid.Views.Grid.GridView gvShowFeeds;
        private DevExpress.XtraGrid.Columns.GridColumn gcTitle;
        private DevExpress.XtraGrid.Columns.GridColumn gcLink;
        private DevExpress.XtraGrid.Columns.GridColumn gcPubDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnEditView;
        private DevExpress.XtraGrid.Columns.GridColumn gcDownLoadContent;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDownLoadContent;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PanelControl pnChoiceParseData;
        private DevExpress.XtraEditors.TextEdit txtEditUrl;
        private DevExpress.XtraEditors.TextEdit txtEditPathDefault;
        private DevExpress.XtraEditors.SimpleButton btnSetPath;
        private DevExpress.XtraEditors.SimpleButton btnGetContent;
        private System.Windows.Forms.CheckBox chkSinglePage;
        private DevExpress.XtraBars.BarStaticItem barStaticParseData;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManagerBCC;
        private DevExpress.XtraBars.BarStaticItem barStaticCate;
        private System.Windows.Forms.ToolTip toolTipShowUrl;
    }
}