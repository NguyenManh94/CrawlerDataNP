namespace SSWA_ExtractData.UserInterface
{
    partial class FrmAuthentication
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
            this.btnLogin = new DevExpress.XtraEditors.CheckButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnExit = new DevExpress.XtraEditors.CheckButton();
            this.btnReset = new DevExpress.XtraEditors.CheckButton();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.timerLoadDayHours = new System.Windows.Forms.Timer(this.components);
            this.grbLoginInformation = new DevExpress.XtraEditors.GroupControl();
            this.chkRememberLogin = new System.Windows.Forms.CheckBox();
            this.lblHoursDynamic = new System.Windows.Forms.Label();
            this.lblDayDynamic = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.pbImageLogin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbLoginInformation)).BeginInit();
            this.grbLoginInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(9, 128);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(88, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.CheckedChanged += new System.EventHandler(this.btnLogin_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(91, 59);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(172, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(263, 128);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 25);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.CheckedChanged += new System.EventHandler(this.btnExit_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Location = new System.Drawing.Point(136, 128);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 25);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.CheckedChanged += new System.EventHandler(this.btnReset_CheckedChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(22, 62);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(50, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // lblUserName
            // 
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(22, 34);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "UserName:";
            // 
            // txtUserName
            // 
            this.txtUserName.EnterMoveNextControl = true;
            this.txtUserName.Location = new System.Drawing.Point(91, 31);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(172, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // timerLoadDayHours
            // 
            this.timerLoadDayHours.Enabled = true;
            this.timerLoadDayHours.Tick += new System.EventHandler(this.timerLoadDayHours_Tick);
            // 
            // grbLoginInformation
            // 
            this.grbLoginInformation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.grbLoginInformation.Controls.Add(this.chkRememberLogin);
            this.grbLoginInformation.Controls.Add(this.lblHoursDynamic);
            this.grbLoginInformation.Controls.Add(this.lblDayDynamic);
            this.grbLoginInformation.Controls.Add(this.lblHours);
            this.grbLoginInformation.Controls.Add(this.lblDay);
            this.grbLoginInformation.Controls.Add(this.pbImageLogin);
            this.grbLoginInformation.Controls.Add(this.btnLogin);
            this.grbLoginInformation.Controls.Add(this.txtPassword);
            this.grbLoginInformation.Controls.Add(this.btnExit);
            this.grbLoginInformation.Controls.Add(this.btnReset);
            this.grbLoginInformation.Controls.Add(this.lblPassword);
            this.grbLoginInformation.Controls.Add(this.lblUserName);
            this.grbLoginInformation.Controls.Add(this.txtUserName);
            this.grbLoginInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbLoginInformation.Location = new System.Drawing.Point(0, 0);
            this.grbLoginInformation.Name = "grbLoginInformation";
            this.grbLoginInformation.Size = new System.Drawing.Size(365, 169);
            this.grbLoginInformation.TabIndex = 4;
            this.grbLoginInformation.Text = "Login Information";
            // 
            // chkRememberLogin
            // 
            this.chkRememberLogin.AutoSize = true;
            this.chkRememberLogin.ForeColor = System.Drawing.Color.Maroon;
            this.chkRememberLogin.Location = new System.Drawing.Point(18, 104);
            this.chkRememberLogin.Name = "chkRememberLogin";
            this.chkRememberLogin.Size = new System.Drawing.Size(105, 17);
            this.chkRememberLogin.TabIndex = 3;
            this.chkRememberLogin.Text = "Remember Login";
            this.chkRememberLogin.UseVisualStyleBackColor = true;
            this.chkRememberLogin.CheckedChanged += new System.EventHandler(this.chkRememberLogin_CheckedChanged);
            // 
            // lblHoursDynamic
            // 
            this.lblHoursDynamic.AutoSize = true;
            this.lblHoursDynamic.ForeColor = System.Drawing.Color.Purple;
            this.lblHoursDynamic.Location = new System.Drawing.Point(215, 87);
            this.lblHoursDynamic.Name = "lblHoursDynamic";
            this.lblHoursDynamic.Size = new System.Drawing.Size(23, 13);
            this.lblHoursDynamic.TabIndex = 33;
            this.lblHoursDynamic.Text = "....";
            // 
            // lblDayDynamic
            // 
            this.lblDayDynamic.AutoSize = true;
            this.lblDayDynamic.ForeColor = System.Drawing.Color.Purple;
            this.lblDayDynamic.Location = new System.Drawing.Point(74, 87);
            this.lblDayDynamic.Name = "lblDayDynamic";
            this.lblDayDynamic.Size = new System.Drawing.Size(23, 13);
            this.lblDayDynamic.TabIndex = 32;
            this.lblDayDynamic.Text = "....";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.ForeColor = System.Drawing.Color.Purple;
            this.lblHours.Location = new System.Drawing.Point(177, 87);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(39, 13);
            this.lblHours.TabIndex = 31;
            this.lblHours.Text = "Hours:";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.ForeColor = System.Drawing.Color.Purple;
            this.lblDay.Location = new System.Drawing.Point(43, 87);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(30, 13);
            this.lblDay.TabIndex = 30;
            this.lblDay.Text = "Day:";
            // 
            // pbImageLogin
            // 
            this.pbImageLogin.Image = global::SSWA_ExtractData.Properties.Resources.DangNhapHeTHong;
            this.pbImageLogin.Location = new System.Drawing.Point(278, 21);
            this.pbImageLogin.Name = "pbImageLogin";
            this.pbImageLogin.Size = new System.Drawing.Size(58, 65);
            this.pbImageLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageLogin.TabIndex = 29;
            this.pbImageLogin.TabStop = false;
            // 
            // FrmAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 169);
            this.Controls.Add(this.grbLoginInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(300, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAuthentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Authentication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAuthentication_FormClosing);
            this.Load += new System.EventHandler(this.FrmAuthentication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbLoginInformation)).EndInit();
            this.grbLoginInformation.ResumeLayout(false);
            this.grbLoginInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImageLogin;
        private DevExpress.XtraEditors.CheckButton btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private DevExpress.XtraEditors.CheckButton btnExit;
        private DevExpress.XtraEditors.CheckButton btnReset;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.Timer timerLoadDayHours;
        private DevExpress.XtraEditors.GroupControl grbLoginInformation;
        private System.Windows.Forms.CheckBox chkRememberLogin;
        private System.Windows.Forms.Label lblHoursDynamic;
        private System.Windows.Forms.Label lblDayDynamic;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblDay;
    }
}