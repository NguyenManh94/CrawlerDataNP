using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSWA_ExtractData.Common;
using SSWA_ExtractData.Common.Constant;
using SSWA_ExtractData.Properties;

//TODO Comment and FixCode

namespace SSWA_ExtractData.UserInterface
{
    public partial class PR03FrmViewPosts : XtraForm
    {
        private byte[] _downloadedData;

        public PR03FrmViewPosts()
        {
            InitializeComponent();
        }

        private void FrmViewPosts_Load(object sender, EventArgs e)
        {
            try
            {
                Text = Title;
                lblTitle.Text = Title;
                rtbViewSummary.Text = Description;
                barLblWebsite.Caption = Resources.Website + Link.NameWebsite();
                barLblPubDate.Caption = Resources.Publish_Date + PubDate;
                wbShowContentPost.DocumentText = Content;
                DownloadData(Image);
                var stream = new MemoryStream(_downloadedData);
                var img = System.Drawing.Image.FromStream(stream);
                stream.Close();
                pbShowImage.Image = img;
            }
            catch
            {
                // ignored
            }
        }

        private void DownloadData(string url)
        {
            _downloadedData = new byte[0];
            try
            {
                //Optional
                Application.DoEvents();

                //Get a data stream from the url
                var req = WebRequest.Create(url);
                var response = req.GetResponse();
                var stream = response.GetResponseStream();

                //Download in chuncks
                var buffer = new byte[1024];

                //With the total data we can set up our progress indicators

                Application.DoEvents();

                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                var memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    if (stream != null)
                    {
                        var bytesRead = stream.Read(buffer, 0, buffer.Length);

                        if (bytesRead == 0)
                        {
                            break;
                        }
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);
                    }
                }
                //Convert the downloaded stream to a byte array
                _downloadedData = memStream.ToArray();
                //Clean up
                stream.Close();
                memStream.Close();
            }
            catch (Exception)
            {
                //May not be connected to the internet
                //Or the URL might not exist
                SEDFuncCall.MessageWarning("There was an error accessing the URL.!", SEDConst.TITLE_WARNING);
            }
        }

        private void barBtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barBtnMinimine_ItemClick(object sender, ItemClickEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void barBtnAddDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            SEDFuncCall.MessageWarning("This feature is used only when registered in advance!", SEDConst.TITLE_WARNING);

            #region Feature Server Assigment

            //using (var sywbContext = new SyntheticDataContext())
            //{
            //    try
            //    {
            //        var post = new Post
            //        {
            //            IdAccount = A01FrmAuthentication.Id,
            //            IdSCategory = IdScategories,
            //            Title = Title,
            //            Image = Image,
            //            Summary = Description,
            //            ContentView = Content,
            //            DatePost = DateTime.Now,
            //            Active = true,
            //            Viewed = 0
            //        };
            //        sywbContext.Posts.InsertOnSubmit(post);
            //        sywbContext.SubmitChanges();
            //        SEDFuncCall.MessageSuccess("Add new data successfully!", SEDConst.TITLE_NOTE);
            //    }
            //    catch
            //    {
            //        SEDFuncCall.MessageWarning("Add new data failed! Please try again!", SEDConst.TITLE_WARNING);
            //    }
            //}

            #endregion
        }

        #region variable global ViewPost

        public int IdScategories = 0;
        public string Title = "";
        public string Link = "";
        public string PubDate = "";
        public string Image = "";
        public string Description = "";
        public string Content = "";

        #endregion

        #region Move Control

        private int _mouseStartX, _mouseStartY;
        private int _formStartX, _formStartY;
        // ReSharper disable once RedundantDefaultMemberInitializer
        private bool _formDragging = false;

        private void gbSumary_MouseMove(object sender, MouseEventArgs e)
        {
            if (_formDragging)
            {
                Location = new Point(
                    _formStartX + MousePosition.X - _mouseStartX,
                    _formStartY + MousePosition.Y - _mouseStartY
                    );
            }
        }

        private void gbSumary_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseStartX = MousePosition.X;
            _mouseStartY = MousePosition.Y;
            _formStartX = Location.X;
            _formStartY = Location.Y;
            _formDragging = true;
        }

        private void gbSumary_MouseUp(object sender, MouseEventArgs e)
        {
            _formDragging = false;
        }

        private void pbShowImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (_formDragging)
            {
                Location = new Point(
                    _formStartX + MousePosition.X - _mouseStartX,
                    _formStartY + MousePosition.Y - _mouseStartY
                    );
            }
        }

        private void pbShowImage_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseStartX = MousePosition.X;
            _mouseStartY = MousePosition.Y;
            _formStartX = Location.X;
            _formStartY = Location.Y;
            _formDragging = true;
        }

        private void pbShowImage_MouseUp(object sender, MouseEventArgs e)
        {
            _formDragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_formDragging)
            {
                Location = new Point(
                    _formStartX + MousePosition.X - _mouseStartX,
                    _formStartY + MousePosition.Y - _mouseStartY
                    );
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseStartX = MousePosition.X;
            _mouseStartY = MousePosition.Y;
            _formStartX = Location.X;
            _formStartY = Location.Y;
            _formDragging = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _formDragging = false;
        }

        #endregion
    }

    public static class GetNameWeb
    {
        public static string NameWebsite(this string strInput)
        {
            return strInput.Replace("https://", "").Replace("http://", "").Split('/')[0].Replace("www.", "");
        }
    }
}