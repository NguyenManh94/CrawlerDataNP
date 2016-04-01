using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SSWA_WFTestApp
{
    public partial class FrmParseTest: Form
    {
        public FrmParseTest()
        {
            InitializeComponent();
        }

        private void FrmParseTest_Load(object sender, EventArgs e)
        {
            var lstDate = new List<Tuple<string, string>>();
            lstDate.Add(Tuple.Create("1", "Toi la ai"));
            lstDate.Add(Tuple.Create("2", "Toi la di"));
            lstDate.Add(Tuple.Create("3", "Toi la ci"));
            lstDate.Add(Tuple.Create("4", "Toi la b"));

            listBoxControl1.DataSource = lstDate;
            listBoxControl1.DisplayMember = "Item2";
            listBoxControl1.ValueMember = "Item1";

            gridControl1.DataSource = lstDate;

            label1.Text = Environment.MachineName;
            label2.Text = Environment.UserName + " " + Environment.Version + " Số nhân máy tính: " + Environment.ProcessorCount
                + " Platform " + Environment.OSVersion + " __";
            label5.Text = GetIpMacCurrent();
        }

        private void btnCheckConnect_Click(object sender, EventArgs e)
        {
            var check = SWWAInternetConnection.IsConnectedToInternet();
            if (check == true)
            {
                MessageBox.Show("Kết nối");
            }
            else MessageBox.Show("Mất kết nôi");
        }


        public static string GetIpMacCurrent()
        {
            var sbdHardwareInfor = new StringBuilder();
            var sbdListMac = new StringBuilder();
            NetworkInterface[] DanhSachCardMang = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < DanhSachCardMang.Length; i++)
            {
                PhysicalAddress DiaChiMAC = DanhSachCardMang[i].GetPhysicalAddress();
                sbdListMac.Append(DanhSachCardMang[i].Name).Append(":");
                byte[] ByteDiaChi = DiaChiMAC.GetAddressBytes();
                for (int j = 0; j < ByteDiaChi.Length; j++)
                {
                    sbdListMac.Append(ByteDiaChi[j].ToString("X2"));
                    if (j != ByteDiaChi.Length - 1)
                    {
                        sbdListMac.Append("-");
                    }
                }
                sbdListMac.Append("\r\n");
                sbdHardwareInfor.Append(sbdListMac);
            }
            return sbdHardwareInfor.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var htmlDocument = ResultWebClient(textBox1.Text.Trim());
            var node = htmlDocument.DocumentNode.SelectSingleNode("////div[@class='divNewsContent']").InnerHtml;
            webBrowser1.DocumentText = node;
        }

        private HtmlDocument ResultWebClient(string url)
        {
            var wc = new WebClient { Encoding = Encoding.UTF8 };
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36");
            string result = wc.DownloadString(url);
            string htmlDecode = WebUtility.HtmlDecode(result);
            HtmlDocument hdoc = new HtmlDocument();
            hdoc.LoadHtml(htmlDecode);
            return hdoc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listBoxControl1.ItemCount.ToString());
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
    }
}
