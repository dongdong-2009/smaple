/****************************************
 * 周铭
 * 2007-07-04
 * XmlOperate.cs * 
 * 最后修改时间：2007-07-18
 * **************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using TestNotifyWindow;
using CustomUIControls;

namespace ShortCutMenu
{
    public partial class frm : Form
    {
        #region constructor
        public frm()
        {
            InitializeComponent();
            this.Opacity = 0.0;
            showWindow = false;
            //RemoveX(this);  //禁用关闭按钮
        }
        #endregion

        #region 成员
        private ToolStripItem _item;  //显示/隐藏主窗口
        private bool showWindow = false;
        private const int MF_BYPOSITION = 0x400;
        private const int MF_REMOVE = 0x1000;
        private const string STR_SHOWWIN = "显示主窗口";
        private const string STR_HIDEWIN = "隐藏主窗口";
        private const string STR_QIUT = "退出";
        private const string STR_MessageTitle = "ShortCutMenu";
        private const string STR_Tip = "提示";
        private const string STR_QIUTIMAGE = @"\Images\quit.ico";
        #endregion

        #region 取消关闭按钮
        [DllImport("user32.dll")]
        public static extern Int32 DrawMenuBar(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern Int32 GetMenuItemCount(IntPtr hMenu);
        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, Int32 bRevert);
        [DllImport("user32.dll")]
        public static extern Int32 RemoveMenu(IntPtr hMenu, Int32 nPosition, Int32 wFlags);
        public void RemoveX(Form frm)
        {
            IntPtr hMenu;
            Int32 menuItemCount;

            hMenu = GetSystemMenu(frm.Handle, 0);

            if (hMenu.ToInt32() != 0)
            {
                menuItemCount = GetMenuItemCount(hMenu);

                RemoveMenu(hMenu, menuItemCount - 1, MF_REMOVE + MF_BYPOSITION);

                RemoveMenu(hMenu, menuItemCount - 2, MF_REMOVE + MF_BYPOSITION);

                DrawMenuBar(frm.Handle);
            }
        }
        #endregion

        #region 捕获最小化事件
        private const int SC_MINIMIZE = 0xF020;//定义消息
        protected override void WndProc(ref Message m)
        {
            if (m.WParam.ToInt32() == SC_MINIMIZE)
            {
                ShowOrHide(_item);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        #endregion

        #region 显示/隐藏主窗口
        private void ShowOrHide(ToolStripItem item)
        {
            if (showWindow)
            {
                this.Opacity = 0.0;
                item.Text = STR_SHOWWIN;
            }
            else
            {
                this.Opacity = 100.0;
                item.Text = STR_HIDEWIN;
            }
            showWindow = !showWindow;
        }
        #endregion

        #region 添加系统菜单(显示/隐藏主窗口,退出)并绑定事件
        private void BindSystemMenu(string str_ShowHide, ContextMenuStrip menu)
        {
            ToolStripItem item = menu.Items.Add(str_ShowHide);
            item.Click += new EventHandler(item_Click);
            _item = item;
            MenuOperate.SetShowWinItemStyle(item);
            ToolStripItem item_quit = menu.Items.Add(STR_QIUT);
            item_quit.Click += new EventHandler(item_quit_Click);
            string path = Application.StartupPath + STR_QIUTIMAGE;
            if (File.Exists(path))
            {
                item_quit.Image = Image.FromFile(path);
            }
        }

        void item_quit_Click(object sender, EventArgs e)
        {
            this.notifyIcon.Dispose();
            this.Close();
            this.Dispose();
        }

        void item_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            ShowOrHide(item);
        }
        #endregion

        #region 程序加载
        private void frm_Load(object sender, EventArgs e)
        {
            ShowMessage(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), "程序已启动");
            Bind();
            //CreateWatcher();
        }
        #endregion

        #region Bind
        private void Bind()
        {
            //绑定Popup Menu
            if (!File.Exists(XmlOperate.config_path))
            {
                CreateConfig();
            }
            pMenu.Items.Clear();
            MenuOperate.BindApplication(pMenu);
            //MenuOperate.BindMSDN(pMenu);
            MenuOperate.BindSeparateLine(pMenu);
            MenuOperate.BindSystemApplication(pMenu);            
            MenuOperate.BindAutoRun(pMenu);
            BindSystemMenu(showWindow ? STR_HIDEWIN : STR_SHOWWIN, pMenu);

            //绑定ComboBox
            BindComboBox();

            //绑定ListBox_Group
            BindListBox_Group();
            //绑定ListBox_App
            BindListBox_App();

            //绑定系统工具
            MenuOperate.BindCheckedListBox(chkbox_Sys);
        }
        #endregion

        #region 生成配置文件
        private void CreateConfig()
        {
            StringBuilder context = new StringBuilder("<?xml version='1.0' encoding='utf-8'?><root>");

            List<AppItem> apps = new List<AppItem>();
            AppItem app = new AppItem("compmgmt", "计算机管理", @"C:\windows\system32\compmgmt.msc");
            apps.Add(app);

            app = new AppItem("eventvwr", "事件查看器", @"C:\windows\system32\eventvwr.msc");
            apps.Add(app);

            app = new AppItem("services", "服务", @"C:\windows\system32\services.msc");
            apps.Add(app);

            app = new AppItem("appwiz", "添加或删除程序", @"C:\WINDOWS\system32\appwiz.cpl");
            apps.Add(app);

            app = new AppItem("iis", "IIS管理器", @"C:\WINDOWS\system32\inetsrv\iis.msc");
            apps.Add(app);

            app = new AppItem("mstsc", "远程桌面", @"C:\WINDOWS\system32\mstsc.msc");
            apps.Add(app);

            app = new AppItem("inetcpl", "Internet选项", @"C:\WINDOWS\system32\inetcpl.cpl");
            apps.Add(app);

            app = new AppItem("intl", "区域和语言选项", @"C:\WINDOWS\system32\intl.cpl");
            apps.Add(app);

            app = new AppItem("sysdm", "系统属性", @"C:\WINDOWS\system32\sysdm.cpl");
            apps.Add(app);

            app = new AppItem("sysdm", "计算器", @"C:\WINDOWS\system32\calc.exe");
            apps.Add(app);

            for (int i = 0; i < apps.Count; i++)
            {
                context.AppendLine("<" + XmlOperate.STR_SYSTEM + " " + XmlOperate.STR_APPLICATIONID + "=\"" + apps[i].Str_AppId + "\" " + XmlOperate.STR_APPLICATIONNAME + "=\"" + apps[i].Str_AppName + "\" " + XmlOperate.STR_APPLICATIONPATH + "= \"" + apps[i].Str_AppPath + "\" " + XmlOperate.STR_DISPLAY + "= \"" + XmlOperate.STR_TRUE + "\" />");
            }

            apps = new List<AppItem>();
            app = new AppItem("cleanmgr", "磁盘清理", @"C:\WINDOWS\system32\cleanmgr.exe");
            apps.Add(app);

            app = new AppItem("dfrg", "碎片整理", @"C:\WINDOWS\system32\dfrg.msc");
            apps.Add(app);

            app = new AppItem("timedate", "日期和时间", @"C:\WINDOWS\system32\timedate.cpl");
            apps.Add(app);

            app = new AppItem("cmd", "命令提示符", @"C:\WINDOWS\system32\cmd.exe");
            apps.Add(app);

            app = new AppItem("mspaint", "画图", @"C:\WINDOWS\system32\mspaint.exe");
            apps.Add(app);

            app = new AppItem("desk", "显示", @"C:\WINDOWS\system32\desk.cpl");
            apps.Add(app);

            app = new AppItem("sndvol32", "声音控制", @"C:\WINDOWS\system32\sndvol32.exe ");
            apps.Add(app);

            app = new AppItem("ncpa", "网络连接", @"C:\WINDOWS\system32\ncpa.cpl");
            apps.Add(app);

            app = new AppItem("main", "鼠标", @"C:\WINDOWS\system32\main.cpl");
            apps.Add(app);

            for (int i = 0; i < apps.Count; i++)
            {
                context.AppendLine("<" + XmlOperate.STR_SYSTEM + " " + XmlOperate.STR_APPLICATIONID + "=\"" + apps[i].Str_AppId + "\" " + XmlOperate.STR_APPLICATIONNAME + "=\"" + apps[i].Str_AppName + "\" " + XmlOperate.STR_APPLICATIONPATH + "= \"" + apps[i].Str_AppPath + "\" " + XmlOperate.STR_DISPLAY + "= \"" + XmlOperate.STR_FALSE + "\" />");
            }

            context.AppendLine("</root>");
            FileStream fs = new FileStream(XmlOperate.config_path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(context.ToString());
            sw.Close();
            fs.Close();
        }
        #endregion

        #region 新增组
        private void btn_newGroup_Click(object sender, EventArgs e)
        {
            if (txt_groupName.Text.Trim() != string.Empty)
            {
                if (ShortCutMenu.XmlOperate.createGroup(txt_groupName.Text.Trim()) == "0")
                {
                    pMenu.Items.Add(txt_groupName.Text.Trim());
                    ShowMessage(STR_Tip, "新增成功!");
                    Bind();
                    txt_groupName.Text = "";
                }
                else
                {
                    ShowMessage(STR_Tip, "已存在相同的组名!");
                }
            }
            else
            {
                ShowMessage(STR_Tip, "请输入组名!");
            }
        }
        #endregion

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowOrHide(_item);
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
                ShowOrHide(_item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDlg.ShowDialog())
            {
                if (!utility.IsApplication(openFileDlg.FileName))
                {
                    ShowMessage(STR_Tip, "所选文件不是应用程序");
                }
                else
                {
                    txt_newAppName.Text = utility.getFileName(openFileDlg.FileName);
                    txt_newAppPath.Text = openFileDlg.FileName;
                }
            }
        }

        #region BIndComboBox
        private readonly string STR_BELONGTONULLVALUE = "0";
        private readonly string STR_BELONGTONULLTEXT = "BelongToNull";
        private void BindComboBox()
        {
            //Bind AddComboBox
            cbBox_SelGroup.DataSource = null;
            cbBox_SelGroup.Items.Clear();
            GroupItem[] TmpGroups = XmlOperate.GetGroup();
            GroupItem[] groups = new GroupItem[TmpGroups.Length + 1];
            for (int i = 0; i < TmpGroups.Length; i++)
            {
                groups[i] = new GroupItem();
                groups[i].AppItems = TmpGroups[i].AppItems;
                groups[i].GroupId = TmpGroups[i].GroupId;
                groups[i].GroupName = TmpGroups[i].GroupName;
            }
            groups[TmpGroups.Length] = new GroupItem();
            groups[TmpGroups.Length].AppItems = null;
            groups[TmpGroups.Length].GroupId = STR_BELONGTONULLVALUE;
            groups[TmpGroups.Length].GroupName = STR_BELONGTONULLTEXT;

            cbBox_SelGroup.Items.AddRange(groups);
            cbBox_SelGroup.ValueMember = XmlOperate.STR_GROUPID;
            cbBox_SelGroup.DisplayMember = XmlOperate.STR_GROUPNAME;
            cbBox_SelGroup.DataSource = groups;

            //Bind DelComboBox
            CB_SelDelGroup.DataSource = null;
            CB_SelDelGroup.Items.Clear();
            CB_SelDelGroup.Items.AddRange(TmpGroups);
            CB_SelDelGroup.ValueMember = XmlOperate.STR_GROUPID;
            CB_SelDelGroup.DisplayMember = XmlOperate.STR_GROUPNAME;
            CB_SelDelGroup.DataSource = TmpGroups;
        }
        #endregion

        #region 新增应用程序
        private void btn_newApp_Click(object sender, EventArgs e)
        {
            if (txt_newAppPath.Text.Trim() == string.Empty)
            {

                ShowMessage(STR_Tip, "应用程序路径不能为空");
                return;
            }
            if (txt_newAppName.Text.Trim() == string.Empty)
            {
                ShowMessage(STR_Tip, "应用程序名不能为空");
                return;
            }

            AppItem app = new AppItem();
            Random rand = new Random();
            string str_id = "appItem" + Convert.ToInt32((rand.NextDouble() * 987654321)).ToString();
            app.Str_AppId = str_id;
            app.Str_AppName = txt_newAppName.Text.Trim();
            app.Str_AppPath = txt_newAppPath.Text.Trim();
            string groupId = cbBox_SelGroup.SelectedValue.ToString();
            if (groupId == STR_BELONGTONULLVALUE)
            {
                if (MenuOperate.AddNewRootApp(app))
                {
                    ShowMessage(STR_Tip, "新增成功!");
                }
                else
                {
                    ShowMessage(STR_Tip, "已经存在相同的应用程序名!");
                }
            }
            else
            {
                if (MenuOperate.AddNewGroupApp(groupId, app))
                {
                    ShowMessage(STR_Tip, "新增成功!");
                }
                else
                {
                    ShowMessage(STR_Tip, "已经存在相同的应用程序名!");
                }
            }
            Bind();
            txt_newAppName.Text = "";
            txt_newAppPath.Text = "";
        }
        #endregion

        #region 删除组
        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (CB_SelDelGroup.SelectedIndex == -1)
            {
                ShowMessage(STR_Tip, "请选择要删除的组");
                return;
            }
            MenuOperate.DelGroup(CB_SelDelGroup.SelectedValue.ToString());
            ShowMessage(STR_Tip, "删除成功");
            Bind();
        }
        #endregion

        #region BindListBox_Group
        private void BindListBox_Group()
        {
            lb_selGroup.DataSource = null;
            lb_selGroup.Items.Clear();
            GroupItem[] TmpGroups = XmlOperate.GetGroup();
            GroupItem[] groups = new GroupItem[TmpGroups.Length + 1];
            for (int i = 0; i < TmpGroups.Length; i++)
            {
                groups[i] = new GroupItem();
                groups[i].AppItems = TmpGroups[i].AppItems;
                groups[i].GroupId = TmpGroups[i].GroupId;
                groups[i].GroupName = TmpGroups[i].GroupName;
            }
            groups[TmpGroups.Length] = new GroupItem();
            groups[TmpGroups.Length].AppItems = null;
            groups[TmpGroups.Length].GroupId = STR_BELONGTONULLVALUE;
            groups[TmpGroups.Length].GroupName = STR_BELONGTONULLTEXT;

            lb_selGroup.Items.AddRange(groups);
            lb_selGroup.ValueMember = XmlOperate.STR_GROUPID;
            lb_selGroup.DisplayMember = XmlOperate.STR_GROUPNAME;
            lb_selGroup.DataSource = groups;
        }
        #endregion

        #region BindListBox_App
        private void BindListBox_App()
        {
            //lb_selApp.DataSource = null;
            lb_selApp.Items.Clear();
            AppItem[] apps;
            if (lb_selGroup.SelectedValue == null)
            {
                return;
            }

            if (lb_selGroup.SelectedValue.ToString() == STR_BELONGTONULLVALUE)
            {
                apps = MenuOperate.GetRootApps();
            }
            else
            {
                apps = MenuOperate.GetGroupApps(lb_selGroup.SelectedValue.ToString());
            }

            lb_selApp.DisplayMember = XmlOperate.STR_APPLICATIONNAME;
            lb_selApp.ValueMember = XmlOperate.STR_APPLICATIONID;
            lb_selApp.Items.AddRange(apps);
        }
        #endregion

        private void lb_selGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindListBox_App();
        }

        private void btn_DelApp_Click(object sender, EventArgs e)
        {
            if (lb_selApp.SelectedIndex == -1)
            {
                ShowMessage(STR_Tip, "请选择要删除的应用程序");
                return;
            }
            AppItem app = (AppItem)lb_selApp.SelectedItem;
            string appId = app.Str_AppId;
            if (lb_selGroup.SelectedValue.ToString() == STR_BELONGTONULLVALUE)//删除根应用程序
            {
                MenuOperate.DelRootApp(appId);
            }
            else
            {
                MenuOperate.DelGroupApp(lb_selGroup.SelectedValue.ToString(), appId);
            }
            ShowMessage(STR_Tip, "删除成功");
            Bind();
        }

        private void ShowMessage(string title, string msg)
        {
            notifyIcon.ShowBalloonTip(200, title, msg, ToolTipIcon.Info);
        }

        private void chkbox_Sys_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppItem app = (AppItem)chkbox_Sys.SelectedItem;
            if (app == null)
            {
                return;
            }
            MenuOperate.ChangeSystemApplicationState(app.Str_AppId);
            Bind();
        }

        private void CreateWatcher()
        {
            //获得磁盘
            List<DriveInfo> list = new List<DriveInfo>();
            DriveInfo[] drive = DriveInfo.GetDrives();
            for (int i = 0; i < drive.Length; i++)
            {
                if (drive[i].DriveType == DriveType.Fixed)
                {
                    list.Add(drive[i]);
                }
            }

            bool aaa = File.Exists(@"C:\Program Files");

            FileSystemWatcher[] watcher = new FileSystemWatcher[list.Count];
            for (int i = 0; i < watcher.Length; i++)
            {
                if (!Directory.Exists(list[i].Name + "Program Files"))
                {
                    continue;
                }
                watcher[i] = new FileSystemWatcher();
                watcher[i].Path = list[i].Name + "Program Files";
                watcher[i].EnableRaisingEvents = true;
                watcher[i].Filter = "*.exe";
                watcher[i].IncludeSubdirectories = true;
                watcher[i].SynchronizingObject = this;
                watcher[i].Created += new FileSystemEventHandler(Exec_Created);
            }
        }

        void Exec_Created(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.IndexOf("RECYCLER") == -1)
            {
                string aa = e.Name;
                const string TIP = "ShortCutMenu提示";
                #region 样式1
                //NotifyWindow nw = new NotifyWindow(TIP, "asdfa");
                //nw.TextClicked += new System.EventHandler(textClick);
                //nw.SetDimensions(170, 105);
                //nw.Notify();
                #endregion

                #region 样式2
                TaskbarNotifier taskbarNotifier1;
                taskbarNotifier1 = new TaskbarNotifier();
                taskbarNotifier1.SetBackgroundBitmap(new Bitmap(GetType(), "skin.bmp"), Color.FromArgb(255, 0, 255));
                taskbarNotifier1.SetCloseBitmap(new Bitmap(GetType(), "close.bmp"), Color.FromArgb(255, 0, 255), new Point(127, 8));
                taskbarNotifier1.TitleRectangle = new Rectangle(40, 9, 70, 25);
                taskbarNotifier1.ContentRectangle = new Rectangle(8, 41, 133, 68);
                taskbarNotifier1.ContentClick += new EventHandler(delegate
                {
                    ShowOrHide(_item);
                    txt_newAppPath.Text = e.FullPath;
                    txt_newAppName.Text = utility.getFileName(e.FullPath);
                }
                    );
                taskbarNotifier1.CloseClickable = true;
                taskbarNotifier1.TitleClickable = false;
                taskbarNotifier1.ContentClickable = true;
                taskbarNotifier1.EnableSelectionRectangle = true;
                taskbarNotifier1.KeepVisibleOnMousOver = true;
                taskbarNotifier1.ReShowOnMouseOver = true;
                taskbarNotifier1.Show("提示", "检测到新程序:" + System.Environment.NewLine + "[" + e.Name + "]" + System.Environment.NewLine + System.Environment.NewLine + "点击此处添加", 500, 3000, 200);
                #endregion
            }
        }

        /// <summary>
        /// 样式1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void textClick(object sender, System.EventArgs e)
        //{
        //    MessageBox.Show("Text clicked");
        //}
    }
}