namespace SSWA_TestExtractData
{
    partial class frmDemo
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
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SSWA_TestExtractData.WaitForm1), true, true);
            this.btnSelectMenuData = new System.Windows.Forms.Button();
            this.rtbShowData = new System.Windows.Forms.RichTextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectMenuData
            // 
            this.btnSelectMenuData.Location = new System.Drawing.Point(12, 27);
            this.btnSelectMenuData.Name = "btnSelectMenuData";
            this.btnSelectMenuData.Size = new System.Drawing.Size(149, 23);
            this.btnSelectMenuData.TabIndex = 0;
            this.btnSelectMenuData.Text = "Lấy Danh Mục";
            this.btnSelectMenuData.UseVisualStyleBackColor = true;
            this.btnSelectMenuData.Click += new System.EventHandler(this.btnSelectMenuData_Click);
            // 
            // rtbShowData
            // 
            this.rtbShowData.Location = new System.Drawing.Point(176, 142);
            this.rtbShowData.Name = "rtbShowData";
            this.rtbShowData.Size = new System.Drawing.Size(647, 352);
            this.rtbShowData.TabIndex = 1;
            this.rtbShowData.Text = "";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(260, 44);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(585, 450);
            this.webBrowser1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "//*[@id=\'menu_web\']/li[1]",
            "//*[@id=\'menu_web\']/li[16]",
            "//*[@id=\'menu_web\']/li[17]"});
            this.listBox1.Location = new System.Drawing.Point(720, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 56);
            this.listBox1.TabIndex = 3;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(14, 56);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(147, 109);
            this.webBrowser2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(803, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 112);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 516);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.rtbShowData);
            this.Controls.Add(this.btnSelectMenuData);
            this.Name = "frmDemo";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectMenuData;
        private System.Windows.Forms.RichTextBox rtbShowData;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}

