using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSWA_TestExtractData
{
    /*Lấy thêm cấu hình thông tin máy tính*/
    public partial class FrmDemoGrid : Form
    {
        public FrmDemoGrid()
        {
            InitializeComponent();
        }

        private void FrmDemoGrid_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText="<img src='http://24h-img.24hstatic.com/upload/1-2016/images/2016-01-13/thumbnail/1452692761-anh-dai-dien.jpg'>";
            label1.Text = System.Environment.Version.ToString() + "    " + Environment.CurrentDirectory;

            var sbd = Environment.WorkingSet.ToString() + "  " + Environment.OSVersion + "   " + Environment.Is64BitProcess + Environment.Is64BitOperatingSystem + "   ";
            label2.Text = sbd;


            var lst = new List<Student>
            {
                new Student{Name="ManhNguyen",Address="GiaLam"},
                new Student{Name="ThinhVu",Address="BacNinh"},
                new Student{Name="HoangHieu",Address="GiaLam"},
                new Student{Name="DatDo",Address="BacNinh"}
            };
            dataGridView1.DataSource = lst;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                listBox1.Items.Add(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Vui long nhap text");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x != -1)
            {
                listBox1.Items.RemoveAt(x);
            }
            else
            {
                MessageBox.Show("Vui long chon phan tu de xoa");
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
