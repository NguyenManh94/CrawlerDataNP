namespace SSWA_WFTestApp
{
    partial class FrmTest3
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
            this.btnSet1 = new System.Windows.Forms.Button();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.btnSet2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSet1
            // 
            this.btnSet1.Location = new System.Drawing.Point(162, 223);
            this.btnSet1.Name = "btnSet1";
            this.btnSet1.Size = new System.Drawing.Size(75, 23);
            this.btnSet1.TabIndex = 2;
            this.btnSet1.Text = "button1";
            this.btnSet1.UseVisualStyleBackColor = true;
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(95, 133);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(335, 20);
            this.txtTest.TabIndex = 4;
            this.txtTest.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTest_MouseClick);
            this.txtTest.TextChanged += new System.EventHandler(this.txtTest_TextChanged);
            // 
            // btnSet2
            // 
            this.btnSet2.Location = new System.Drawing.Point(304, 222);
            this.btnSet2.Name = "btnSet2";
            this.btnSet2.Size = new System.Drawing.Size(75, 23);
            this.btnSet2.TabIndex = 5;
            this.btnSet2.Text = "button2";
            this.btnSet2.UseVisualStyleBackColor = true;
            // 
            // FrmTest3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 444);
            this.Controls.Add(this.btnSet2);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.btnSet1);
            this.Name = "FrmTest3";
            this.Text = "FrmTest3";
            this.Load += new System.EventHandler(this.FrmTest3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSet1;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSet2;
    }
}