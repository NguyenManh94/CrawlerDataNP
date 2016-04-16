using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            txtTest.Focus();
        }

        private void txtTest_MouseClick(object sender, MouseEventArgs e)
        {
            this.toolTip1.SetToolTip(txtTest, "Nhap so vao day");
        }
    }
}
