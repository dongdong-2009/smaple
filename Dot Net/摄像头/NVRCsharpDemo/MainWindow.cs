using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NVRCsharpDemo
{
    
    public partial class MainWindow : Form
    {
        private int lUserID = -1;
        private int lRealHandle = -1;
        private long iSelIndex = 0;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96, ArraySubType = UnmanagedType.U4)]
        private int[] iChannelNum;

        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_Init();
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_Cleanup();
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 CHC_DVR_Login(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref int chanNum);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_Logout();
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 CHC_DVR_OpenPreview(byte lChannel, IntPtr hwnd);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_ClosePreview(int lRealHandle);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_AdjustFocus(int lRealHandle, int mode, int stop);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_AdjustColor(int lRealHandle, int bright, int contrast, int saturation, int hue);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_AdjustResolution(int type);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_CaptureBMP(int lRealHandle, string filename);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_CaptureJPEG(int lChannel, string filename);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_StartRecord(int lRealHandle, string filename);
        [DllImport("BYTASDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CHC_DVR_StopRecord(int lRealHandle);

        public MainWindow()
        {
            InitializeComponent();
            if (!CHC_DVR_Init())
            {
                MessageBox.Show("SDK初始化失败!");
                Application.Exit();
            }
            iChannelNum = new int[96];
            btn_Logout.Enabled = false;
            btn_Color.Enabled = false;
            btn_Resolution.Enabled = false;
            btn_Shrink.Enabled = false;
            btn_StopPreview.Enabled = false;
            btn_Stretch.Enabled = false;
            btn_StartRecord.Enabled = false;
            btn_StartPreview.Enabled = false;
            btn_StopPreview.Enabled = false;
            btn_StopRecord.Enabled = false;
            btn_BMP.Enabled = false;
            btn_JPEG.Enabled = false;
            cbc_resolution.SelectedIndex = 0;
        }


        public void InfoIPChannel()
        {
           
        }
        public void ListIPChannel(Int32 iChanNo, byte byOnline, byte byIPID)
        {
           
        }
        public void ListAnalogChannel(Int32 iChanNo, byte byEnable)
        {
            string str1 = String.Format("Camera {0}", iChanNo);
            string str2 = "";

            if (byEnable == 0)
            {
                str2 = "Disabled"; //通道已被禁用 This channel has been disabled               
            }
            else
            {
                str2 = "Enabled"; //通道处于启用状态 This channel has been enabled
            }

            listViewIPChannel.Items.Add(new ListViewItem(new string[] { str1, str2 }));//将通道添加到列表中 add the channel to the list
        }

        private void listViewIPChannel_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewIPChannel.SelectedItems.Count > 0)
            {
                iSelIndex = listViewIPChannel.SelectedItems[0].Index;  //当前选中的行
            }
        }

        private void btnBMP_Click(object sender, EventArgs e)
        {
            CHC_DVR_CaptureBMP(lRealHandle, "temp.bmp");
        }

        private void btnJPEG_Click(object sender, EventArgs e)
        {
            CHC_DVR_CaptureJPEG(1, "temp.jpg");
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            CHC_DVR_StartRecord(lRealHandle, "temp.mp4");
            btn_StopRecord.Enabled = true;
            btn_StartRecord.Enabled = false;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lRealHandle >=0)
            {
                CHC_DVR_ClosePreview(lRealHandle);
            }
            if (lUserID >= 0)
            {
                CHC_DVR_Logout();
            }
            CHC_DVR_Cleanup();
            Application.Exit();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text == "" || textBoxPort.Text == "" || textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("请输入IP，Port，UserName，Password");
            }
            else
            {
                string DVRIPAddress = textBoxIP.Text; //设备IP地址或者域名 Device IP
                Int16 DVRPortNumber = Int16.Parse(textBoxPort.Text);//设备服务端口号 Device Port
                string DVRUserName = textBoxUserName.Text;//设备登录用户名 User name to login
                string DVRPassword = textBoxPassword.Text;//设备登录密码 Password to login
                int channum = -1;
                lUserID = CHC_DVR_Login(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref channum);
                if (lUserID > -1)
                {
                    MessageBox.Show("登录成功!");
                    btn_Login.Enabled = false;
                    btn_Logout.Enabled = true;
                    btn_Resolution.Enabled = true;
                    btn_StartPreview.Enabled = true;
                    for (int i = 0; i < channum; i++)
                    {
                        ListAnalogChannel(i + 1, 1);
                        iChannelNum[i] = i + 1;
                    }
                }
            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            if (CHC_DVR_Logout())
            {
                MessageBox.Show("注销成功!");
                lUserID = -1;
                btn_Login.Enabled = true;
                btn_Logout.Enabled = false;
                btn_Resolution.Enabled = false;
                btn_StartPreview.Enabled = false;
            }
        }

        private void btn_StopPreview_Click(object sender, EventArgs e)
        {
            CHC_DVR_ClosePreview(lRealHandle);
            lRealHandle = -1;
            RealPlayWnd.Invalidate();
            btn_StartPreview.Enabled = true;
            btn_StopPreview.Enabled = false;
            btn_Shrink.Enabled = false;
            btn_Stretch.Enabled = false;
            btn_BMP.Enabled = false;
            btn_JPEG.Enabled = false;
            btn_Color.Enabled = false;
            btn_StartRecord.Enabled = false;
        }

        private void btn_StartPreview_Click(object sender, EventArgs e)
        {
            lRealHandle = CHC_DVR_OpenPreview((byte)iChannelNum[iSelIndex], RealPlayWnd.Handle);
            btn_StartPreview.Enabled = false;
            btn_Color.Enabled = true;
            btn_StopPreview.Enabled = true;
            btn_Shrink.Enabled = true;
            btn_Stretch.Enabled = true;
            btn_BMP.Enabled = true;
            btn_JPEG.Enabled = true;
            btn_StartRecord.Enabled = true;
        }

        private void btn_Stretch_Click(object sender, EventArgs e)
        {
      //      btn_Stretch.Enabled = false;
       //     btn_Shrink.Enabled = false;
      //      if (CHC_DVR_AdjustFocus(lRealHandle, 0))
       //     {
      //          btn_Stretch.Enabled = true;
      //          btn_Shrink.Enabled = true;
      //      }
        }

        private void btn_Shrink_Click(object sender, EventArgs e)
        {
        //    btn_Stretch.Enabled = false;
        //    btn_Shrink.Enabled = false;
        //    if (CHC_DVR_AdjustFocus(lRealHandle, 1))
       //     {
         //       btn_Stretch.Enabled = true;
         //       btn_Shrink.Enabled = true;
          //  }
        }

        private void btn_Color_Click(object sender, EventArgs e)
        {
            if (txt_Light.Text == "" || txt_Contrast.Text == "" || txt_Saturation.Text == "" || txt_Hue.Text == "")
            {
                MessageBox.Show("请输入亮度，对比度，饱和度，色度!");
            }
            else
            {
                CHC_DVR_AdjustColor(lRealHandle, int.Parse(txt_Light.Text), int.Parse(txt_Contrast.Text), int.Parse(txt_Saturation.Text), int.Parse(txt_Hue.Text));
            }
        }

        private void btn_Resolution_Click(object sender, EventArgs e)
        {
            if (CHC_DVR_AdjustResolution(cbc_resolution.SelectedIndex))
            {
                MessageBox.Show("OK");
            }
        }

        private void btn_StopRecord_Click(object sender, EventArgs e)
        {
            CHC_DVR_StopRecord(lRealHandle);
            btn_StartRecord.Enabled = true;
            btn_StopRecord.Enabled = false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (lRealHandle >= 0)
            {
                CHC_DVR_ClosePreview(lRealHandle);
            }
            if (lUserID >=0)
            {
                CHC_DVR_Logout();
            }
            CHC_DVR_Cleanup();
            Application.Exit();
        }

        private void btn_Stretch_MouseDown(object sender, MouseEventArgs e)
        {
            CHC_DVR_AdjustFocus(lRealHandle, 0, 0);
        }

        private void btn_Stretch_MouseUp(object sender, MouseEventArgs e)
        {
            CHC_DVR_AdjustFocus(lRealHandle, 0, 1);
        }

        private void btn_Shrink_MouseDown(object sender, MouseEventArgs e)
        {
            CHC_DVR_AdjustFocus(lRealHandle, 1, 0);
        }

        private void btn_Shrink_MouseUp(object sender, MouseEventArgs e)
        {
            CHC_DVR_AdjustFocus(lRealHandle, 1, 1);
        }

    }
}
