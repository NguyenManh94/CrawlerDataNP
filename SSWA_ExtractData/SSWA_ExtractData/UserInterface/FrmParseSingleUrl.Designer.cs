namespace SSWA_ExtractData.UserInterface
{
    partial class FrmParseSingleUrl
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPhysiccalMemory = new System.Windows.Forms.Label();
            this.lblCpuMarker = new System.Windows.Forms.Label();
            this.lblCPU_Speed = new System.Windows.Forms.Label();
            this.lblOsVersion = new System.Windows.Forms.Label();
            this.lblPrecessorCount = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.panelControlShowData = new DevExpress.XtraEditors.PanelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pnChoiceParseData = new DevExpress.XtraEditors.PanelControl();
            this.cbEditCate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pictureEditReload = new DevExpress.XtraEditors.PictureEdit();
            this.cbChoiceSiteCate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlShowData)).BeginInit();
            this.panelControlShowData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnChoiceParseData)).BeginInit();
            this.pnChoiceParseData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEditCate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditReload.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.pictureBox1);
            this.groupControl2.Controls.Add(this.lblPhysiccalMemory);
            this.groupControl2.Controls.Add(this.lblCpuMarker);
            this.groupControl2.Controls.Add(this.lblCPU_Speed);
            this.groupControl2.Controls.Add(this.lblOsVersion);
            this.groupControl2.Controls.Add(this.lblPrecessorCount);
            this.groupControl2.Controls.Add(this.lblVersion);
            this.groupControl2.Controls.Add(this.lblMachineName);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1284, 42);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Your hardware information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::SSWA_ExtractData.Properties.Resources.case_study_32;
            this.pictureBox1.Location = new System.Drawing.Point(1250, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblPhysiccalMemory
            // 
            this.lblPhysiccalMemory.AutoSize = true;
            this.lblPhysiccalMemory.Location = new System.Drawing.Point(911, 21);
            this.lblPhysiccalMemory.Name = "lblPhysiccalMemory";
            this.lblPhysiccalMemory.Size = new System.Drawing.Size(93, 13);
            this.lblPhysiccalMemory.TabIndex = 6;
            this.lblPhysiccalMemory.Text = "Physical Memory: ";
            // 
            // lblCpuMarker
            // 
            this.lblCpuMarker.AutoSize = true;
            this.lblCpuMarker.Location = new System.Drawing.Point(779, 21);
            this.lblCpuMarker.Name = "lblCpuMarker";
            this.lblCpuMarker.Size = new System.Drawing.Size(70, 13);
            this.lblCpuMarker.TabIndex = 5;
            this.lblCpuMarker.Text = "CPU Marker: ";
            // 
            // lblCPU_Speed
            // 
            this.lblCPU_Speed.AutoSize = true;
            this.lblCPU_Speed.Location = new System.Drawing.Point(678, 21);
            this.lblCPU_Speed.Name = "lblCPU_Speed";
            this.lblCPU_Speed.Size = new System.Drawing.Size(67, 13);
            this.lblCPU_Speed.TabIndex = 4;
            this.lblCPU_Speed.Text = "CPU Speed: ";
            // 
            // lblOsVersion
            // 
            this.lblOsVersion.AutoSize = true;
            this.lblOsVersion.Location = new System.Drawing.Point(323, 21);
            this.lblOsVersion.Name = "lblOsVersion";
            this.lblOsVersion.Size = new System.Drawing.Size(63, 13);
            this.lblOsVersion.TabIndex = 3;
            this.lblOsVersion.Text = "OSVersion: ";
            // 
            // lblPrecessorCount
            // 
            this.lblPrecessorCount.AutoSize = true;
            this.lblPrecessorCount.Location = new System.Drawing.Point(557, 21);
            this.lblPrecessorCount.Name = "lblPrecessorCount";
            this.lblPrecessorCount.Size = new System.Drawing.Size(90, 13);
            this.lblPrecessorCount.TabIndex = 2;
            this.lblPrecessorCount.Text = "ProcessorCount: ";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(184, 21);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(49, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version: ";
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new System.Drawing.Point(27, 21);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(80, 13);
            this.lblMachineName.TabIndex = 0;
            this.lblMachineName.Text = "MachineName: ";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.panelControlShowData);
            this.groupControl3.Controls.Add(this.pnChoiceParseData);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 42);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1284, 519);
            this.groupControl3.TabIndex = 4;
            this.groupControl3.Text = "Data Analyzer";
            // 
            // panelControlShowData
            // 
            this.panelControlShowData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlShowData.Controls.Add(this.groupControl4);
            this.panelControlShowData.Controls.Add(this.groupControl1);
            this.panelControlShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlShowData.Location = new System.Drawing.Point(2, 64);
            this.panelControlShowData.Name = "panelControlShowData";
            this.panelControlShowData.Size = new System.Drawing.Size(1280, 453);
            this.panelControlShowData.TabIndex = 5;
            // 
            // groupControl4
            // 
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(387, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(893, 453);
            this.groupControl4.TabIndex = 1;
            this.groupControl4.Text = "Parse Data";
            // 
            // groupControl1
            // 
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(387, 453);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Category Information";
            // 
            // pnChoiceParseData
            // 
            this.pnChoiceParseData.Controls.Add(this.cbEditCate);
            this.pnChoiceParseData.Controls.Add(this.pictureEditReload);
            this.pnChoiceParseData.Controls.Add(this.cbChoiceSiteCate);
            this.pnChoiceParseData.Controls.Add(this.label1);
            this.pnChoiceParseData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnChoiceParseData.Location = new System.Drawing.Point(2, 21);
            this.pnChoiceParseData.Name = "pnChoiceParseData";
            this.pnChoiceParseData.Size = new System.Drawing.Size(1280, 43);
            this.pnChoiceParseData.TabIndex = 4;
            // 
            // cbEditCate
            // 
            this.cbEditCate.Location = new System.Drawing.Point(167, 12);
            this.cbEditCate.Name = "cbEditCate";
            this.cbEditCate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEditCate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbEditCate.Size = new System.Drawing.Size(169, 20);
            this.cbEditCate.TabIndex = 7;
            // 
            // pictureEditReload
            // 
            this.pictureEditReload.EditValue = global::SSWA_ExtractData.Properties.Resources.reload1;
            this.pictureEditReload.Location = new System.Drawing.Point(9, 3);
            this.pictureEditReload.Name = "pictureEditReload";
            this.pictureEditReload.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.pictureEditReload.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEditReload.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEditReload.Size = new System.Drawing.Size(41, 39);
            this.pictureEditReload.TabIndex = 0;
            // 
            // cbChoiceSiteCate
            // 
            this.cbChoiceSiteCate.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.cbChoiceSiteCate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.cbChoiceSiteCate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChoiceSiteCate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbChoiceSiteCate.FormattingEnabled = true;
            this.cbChoiceSiteCate.Location = new System.Drawing.Point(354, 11);
            this.cbChoiceSiteCate.Name = "cbChoiceSiteCate";
            this.cbChoiceSiteCate.Size = new System.Drawing.Size(33, 21);
            this.cbChoiceSiteCate.TabIndex = 0;
            this.cbChoiceSiteCate.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choice Site Category";
            // 
            // FrmParseSingleUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Name = "FrmParseSingleUrl";
            this.Text = "Parse Single Url";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlShowData)).EndInit();
            this.panelControlShowData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnChoiceParseData)).EndInit();
            this.pnChoiceParseData.ResumeLayout(false);
            this.pnChoiceParseData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEditCate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditReload.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPhysiccalMemory;
        private System.Windows.Forms.Label lblCpuMarker;
        private System.Windows.Forms.Label lblCPU_Speed;
        private System.Windows.Forms.Label lblOsVersion;
        private System.Windows.Forms.Label lblPrecessorCount;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblMachineName;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PanelControl panelControlShowData;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl pnChoiceParseData;
        private DevExpress.XtraEditors.ComboBoxEdit cbEditCate;
        private DevExpress.XtraEditors.PictureEdit pictureEditReload;
        private System.Windows.Forms.ComboBox cbChoiceSiteCate;
        private System.Windows.Forms.Label label1;
    }
}