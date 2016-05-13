using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSWA_WFTestApp
{
    public partial class FrmTest3 : Form
    {
        public FrmTest3()
        {
            InitializeComponent();
        }

        private void txtTest_TextChanged(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(txtTest, "Nhap so vao day");
        }

        private void FrmTest3_Load(object sender, EventArgs e)
        {
            btnSet1.Enabled = false; btnSet2.Enabled = false;
            List<Button> lstButton = new List<Button>
            {
                btnSet1,
                btnSet2
            };
            var lstCaption = new List<string> { "button2", "button3" };
            foreach (var item in lstButton)
            {
                if (lstCaption.Contains(item.Text))
                {
                    item.Enabled = true;
                }
            }
        }

        private void txtTest_MouseClick(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(txtTest, "Nhap so vao day");
        }
    }

    public enum SetCaption
    {
        button1,
        button2
    }
}
