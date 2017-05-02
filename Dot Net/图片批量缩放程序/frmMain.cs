using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace ThumbnailImages
{
    public delegate void DelegateStart();
    public delegate void DelegateDoException(Exception ex);
    public delegate void DelegateThreadFinished(string message);
    public delegate void DelegateProgressBarPerformStep(int fileIndex, string filename);

    public partial class frmMain : Form
    {
        int width = 1024, height = 768;
        int percent = -1;
        int totalFileCount = 0;
        private Thread timedProgress;
        string sourcePath, targetPath;
        string[] files;

        public DelegateStart DelegateStart;
        public DelegateDoException DelegateDoException;
        public DelegateThreadFinished DelegateThreadFinished;
        public DelegateProgressBarPerformStep DelegateProgressBarPerformStep;

        public frmMain()
        {
            InitializeComponent();
            this.cbDefined.SelectedIndex = 2;

            DelegateStart = new DelegateStart(this.Start);
            DelegateThreadFinished = new DelegateThreadFinished(this.ThreadFinished);
            DelegateDoException = new DelegateDoException(this.DoException);
            DelegateProgressBarPerformStep = new DelegateProgressBarPerformStep(this.ProgressBarPerformStep);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string sourcePath = txtSource.Text;
            string targetPath = txtTarget.Text;
            if (sourcePath.Length == 0 || !Directory.Exists(sourcePath))
            {
                txtSource.Focus();
                MessageBox.Show("请重新选择图片文件夹!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (targetPath.Length == 0)
            {
                txtTarget.Focus();
                MessageBox.Show("请重新选择缩略图保存路径!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(targetPath))
            {
                try
                {
                    Directory.CreateDirectory(targetPath);
                }
                catch
                {
                    txtTarget.Focus();
                    MessageBox.Show("请重新选择缩略图保存路径!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            GetImageSizeSetting();
            //TimedProgressProc();

            timedProgress = new Thread(new ThreadStart(TimedProgressProc));
            timedProgress.IsBackground = true;
            timedProgress.Start();

        }

        public void Start()
        {
            sourcePath = txtSource.Text;
            targetPath = txtTarget.Text;
            files = Directory.GetFiles(sourcePath);
            totalFileCount = files.Length;
            this.lblInfo.Text = string.Format("0/{0}", totalFileCount);
            this.progressBar.Maximum = totalFileCount;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;

        }

        public void ThreadFinished(string message)
        {
            if (MessageBox.Show(message, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(targetPath);
            }
            
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            this.progressBar.Value = 0;
            this.lblInfo.Text = "全部完成!";
        }


        public void DoException(Exception ex)
        {
            MessageBox.Show(ex.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            this.progressBar.Value = 0;
        }


        public void ProgressBarPerformStep(int fileIndex, string filename)
        {
            progressBar.PerformStep();
            filename = Path.GetFileName(filename);
            this.lblInfo.Text = string.Format("{0}/{1}, 当前文件: {2}", fileIndex, totalFileCount, filename);

        }

        private void TimedProgressProc()
        {
            try
            {
                ImageCodecInfo icf = ImageHelper.GetImageCodecInfo(ImageFormat.Jpeg);

                Image image, thumbnailImage;
                string thumbnailImageFilename;
                this.Invoke(this.DelegateStart);
                int i = 0;
                foreach (string filename in files)
                {
                    if (timedProgress == null)
                        return;
                    //lblInfo.Text = string.Format("正在处理: {0} ", filename); ;
                    progressBar.Invoke(this.DelegateProgressBarPerformStep, new object[] { i++, filename });
                    string extension = Path.GetExtension(filename).ToLower();
                    if (extension != ".jpg"
                        && extension != ".jpeg"
                        && extension != ".gif"
                        && extension != ".bmp"
                        && extension != ".png"
                        )
                        continue;
                    try
                    {
                        using (image = Image.FromFile(filename))
                        {
                            Size imageSize = GetImageSize(image);

                            using (thumbnailImage = ImageHelper.GetThumbnailImage(image, imageSize.Width, imageSize.Height))
                            {
                                thumbnailImageFilename = Path.GetFileNameWithoutExtension(filename) + "_" + thumbnailImage.Width + "x" + thumbnailImage.Height + extension;
                                ImageHelper.SaveImage(thumbnailImage, Path.Combine(targetPath, thumbnailImageFilename), icf);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        string em = ex.Message;
                        //lblInfo.Text = string.Format("{0} 可能不是合法的图片文件!", filename);
                    }
                }
                this.Invoke(this.DelegateThreadFinished, new object[] { "已经全部完成!\n是否打开生成的缩略图所在文件夹?" });
            }
            catch (ThreadInterruptedException e)
            {
                return;
            }
            catch (Exception ex)
            {
                this.Invoke(this.DelegateDoException, new Object[] { ex });
            }

        }

        private Size GetImageSize(Image picture)
        {
            Size imageSize;
            if (percent > 0)
            {
                imageSize = new Size(picture.Width * percent / 100, picture.Height * percent / 100);
            }
            else
                imageSize = new Size(width, height);

            double heightRatio = (double)picture.Height / picture.Width;
            double widthRatio = (double)picture.Width / picture.Height;

            int desiredHeight = imageSize.Height;
            int desiredWidth = imageSize.Width;


            imageSize.Height = desiredHeight;
            if (widthRatio > 0)
                imageSize.Width = Convert.ToInt32(imageSize.Height * widthRatio);

            if (imageSize.Width > desiredWidth)
            {
                imageSize.Width = desiredWidth;
                imageSize.Height = Convert.ToInt32(imageSize.Width * heightRatio);
            }

            return imageSize;
        }

        private void GetImageSizeSetting()
        {
            if (rbDefined.Checked)
            {
                if (cbDefined.SelectedIndex == 0)
                {
                    width = 1024;
                    height = 768;
                }
                else if (cbDefined.SelectedIndex == 1)
                {
                    width = 800;
                    height = 600;
                }
                else if (cbDefined.SelectedIndex == 2)
                {
                    width = 640;
                    height = 480;
                }
                else if (cbDefined.SelectedIndex == 3)
                {
                    width = 448;
                    height = 336;
                }
                else if (cbDefined.SelectedIndex == 4)
                {
                    width = 314;
                    height = 235;
                }
                else if (cbDefined.SelectedIndex == 5)
                {
                    width = 160;
                    height = 160;
                }
            }
            else if (rbCustom.Checked)
            {
                width = (int)numWidth.Value;
                height = (int)numHeight.Value;
            }
            else if (rbDefined.Checked)
            {
                percent = (int)numPercent.Value;
            }
        }

        private void cbDefined_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!rbDefined.Checked)
                rbDefined.Checked = true;
        }

        private void btnBrowserSource_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = folderBrowserDialog.SelectedPath;
                if (txtTarget.Text.Length == 0)
                    txtTarget.Text = Path.Combine(folderBrowserDialog.SelectedPath, "ThumbnailImages");
            }
        }

        private void btnBrowserTarget_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtTarget.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Change the color of the link text by setting LinkVisited 
            // to true.
            linkLabel1.LinkVisited = true;
            //Call the Process.Start method to open the default browser 
            //with a URL:
            System.Diagnostics.Process.Start("http://www.openlab.net.cn");


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (timedProgress != null)
            {
                timedProgress.Interrupt();
                timedProgress = null;
                ThreadFinished("已经取消!\n是否打开生成的缩略图所在文件夹?");
                this.lblInfo.Text = "已取消!";
            }
        }
    }
}