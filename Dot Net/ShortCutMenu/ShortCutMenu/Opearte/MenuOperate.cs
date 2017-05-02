/****************************************
 * 周铭
 * 2007-07-04
 * XmlOperate.cs * 
 * 最后修改时间：2007-07-18
 * **************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ShortCutMenu
{
    class MenuOperate
    {
        private static readonly string STR_SYSTEMMANAGER = "系统工具";
        private static readonly string STR_GROUPIMAGE = @"\Images\group.ico";
        private static readonly string STR_MSDN = "MSDN";
        private static readonly string STR_MSDNPATH = @"C:\Program Files\Common Files\Microsoft Shared\Help 8\dexplore.exe";
        private static readonly string STR_PARA_VS = "/helpcol ms-help://ms.vscc.v80 /LaunchNamedUrlTopic DefaultPage /usehelpsettings VisualStudio.8.0";
        private static readonly string STR_PARA_SQL = "/helpcol ms-help://MS.SQLCC.v9 /usehelpsettings SQLServerBooksOnline.9.0 /LaunchFKeywordTopic sql9.portal.f1";
        private static readonly string STR_MSDN_VS = "Visual Studio 文档";
        private static readonly string STR_MSDN_SQL = "SQL Server 联机丛书";
        private static readonly string STR_AutoRun = "开机自动运行";
        //private static readonly string STR_CHECKEDIMAGE = @"Images/Checked.ico";
        public static void BindApplication(ContextMenuStrip PopupMenu)
        {            
            GroupItem[] Groups = XmlOperate.GetGroup();
            for (int i = 0; i < Groups.Length; i++)
            {
                ToolStripMenuItem PopupMenuGroup = (ToolStripMenuItem)PopupMenu.Items.Add(Groups[i].GroupName);
                SetImageOnGroup(PopupMenuGroup);
                PopupMenuGroup.Name = Groups[i].GroupId;
                for (int j = 0; j < Groups[i].AppItems.Length; j++)
                {
                    if (!File.Exists(Groups[i].AppItems[j].Str_AppPath))
                    {
                        XmlOperate.DelSubAppByGroupIdAppId(Groups[i].GroupId, Groups[i].AppItems[j].Str_AppId);
                        continue;
                    }
                    AppItem item = Groups[i].AppItems[j];
                    ToolStripItem applicationItem =  PopupMenuGroup.DropDown.Items.Add(item.Str_AppName);
                    applicationItem.Name = item.Str_AppId;
                    applicationItem.Tag = item.Str_AppPath;
                    Icon icon = IconReader.GetFileIcon(item.Str_AppPath, IconReader.IconSize.Small, false);
                    applicationItem.Image = icon.ToBitmap();
                    applicationItem.Click += new EventHandler(applicationItem_Click);
                }
            }

            AppItem[] rootAppItems = XmlOperate.GetRootApp();
            for (int i = 0; i < rootAppItems.Length; i++)
            {
                if (!File.Exists(rootAppItems[i].Str_AppPath))
                {
                    XmlOperate.DelRootAppById(rootAppItems[i].Str_AppId); //通过不存在的根应用程序
                    continue;
                }
                ToolStripItem newItem = PopupMenu.Items.Add(rootAppItems[i].Str_AppName);
                newItem.Name = rootAppItems[i].Str_AppId;
                newItem.Tag = rootAppItems[i].Str_AppPath;
                newItem.Click += new EventHandler(applicationItem_Click);
            }
        }

        static void applicationItem_Click(object sender, EventArgs e)
        {
            string appPath = ((ToolStripItem)sender).Tag.ToString();
            System.Diagnostics.Process.Start(appPath,null);
        }

        public static bool AddNewRootApp(AppItem app)
        {
            switch (XmlOperate.createItemInRoot(app))
            { 
                case "0":
                    {
                        return true;
                    }
                case "1":
                    {
                        return false;                        
                    }
                default:
                    {
                        throw new Exception("error");
                    }
            }
        }

        public static bool AddNewGroupApp(string groupId,AppItem app)
        {
            switch (XmlOperate.createItemInGroup(groupId,app))
            {
                case "0":
                    {
                        return true;
                    }
                case "1":
                    {
                        return false;
                    }
                default:
                    {
                        throw new Exception("error");
                    }
            }
        }

        public static void DelGroup(string groupId)
        {
            XmlOperate.DelGroup(groupId);
        }

        public static void DelRootApp(string appId)
        {
            XmlOperate.DelRootAppById(appId);
        }

        public static void DelGroupApp(string groupId, string appId)
        {
            XmlOperate.DelSubAppByGroupIdAppId(groupId, appId);
        }

        public static AppItem[] GetRootApps()
        {
            return XmlOperate.GetRootApp();
        }

        public static AppItem[] GetGroupApps(string groupId)
        { 
            return XmlOperate.GetGroupApps(groupId);
        }

        public static void BindSystemApplication(ContextMenuStrip PopupMenu)
        {
            AppItem[] apps = XmlOperate.GetSystemApplicationVisible().ToArray();
            if(apps.Length == 0)
            {
                return;
            }
            ToolStripMenuItem SystemGroup = (ToolStripMenuItem)PopupMenu.Items.Add(STR_SYSTEMMANAGER);
            SetImageOnGroup(SystemGroup);
            for (int i = 0; i < apps.Length; i++)
            {
                if (!File.Exists(apps[i].Str_AppPath))
                {
                    XmlOperate.DelSystemApplicationById(apps[i].Str_AppId);
                    continue;
                }
                ToolStripItem SystemApp = SystemGroup.DropDown.Items.Add(apps[i].Str_AppName);
                SystemApp.Name = apps[i].Str_AppId;
                SystemApp.Tag = apps[i].Str_AppPath;
                SystemApp.Image = IconReader.GetFileIcon(apps[i].Str_AppPath, IconReader.IconSize.Small, false).ToBitmap();
                SystemApp.Click += new EventHandler(applicationItem_Click);
            }
            MenuOperate.BindSeparateLine(PopupMenu);
        }

        private static void SetImageOnGroup(ToolStripMenuItem item)
        {
            string path = Application.StartupPath + STR_GROUPIMAGE;
            if (File.Exists(path))
            {
                item.Image = Image.FromFile(path);
            }            
        }

        private static void SetImageOnApp(ToolStripMenuItem item)
        {
            string path = Application.StartupPath + STR_GROUPIMAGE;
            if (File.Exists(path))
            {
                item.Image = Image.FromFile(path);
            }
        }

        public static void SetShowWinItemStyle(ToolStripItem item)
        {
            Font font = new Font(item.Font, FontStyle.Bold);
            item.Font = font;
        }

        public static void BindCheckedListBox(CheckedListBox clb)
        {
            clb.Items.Clear();
            List<AppItem> list = XmlOperate.GetSystemApplication();
            for (int i = 0; i < list.Count; i++)
            {
                clb.Items.Add(list[i], Convert.ToBoolean(list[i].Visible));                
            }
        }

        public static void ChangeSystemApplicationState(string id)
        {
            XmlOperate.ChangeSystemApplicationStateById(id);
        }

        public static void BindMSDN(ContextMenuStrip PopupMenu)
        {
            if (File.Exists(STR_MSDNPATH))
            {
                ToolStripMenuItem PopupMenuMsdn = (ToolStripMenuItem)PopupMenu.Items.Add(STR_MSDN);
                SetImageOnGroup(PopupMenuMsdn);
                ToolStripItem vsItem = PopupMenuMsdn.DropDown.Items.Add(STR_MSDN_VS);
                vsItem.Click += new EventHandler(vsItem_Click);

                ToolStripItem sqlItem = PopupMenuMsdn.DropDown.Items.Add(STR_MSDN_SQL);
                sqlItem.Click += new EventHandler(sqlItem_Click);
            }
        }

        static void sqlItem_Click(object sender, EventArgs e)
        {
            RunMsdn(STR_PARA_SQL);
        }

        static void vsItem_Click(object sender, EventArgs e)
        {
            RunMsdn(STR_PARA_VS);
        }

        private static void RunMsdn(string para)
        {
            try
            {
                System.Diagnostics.Process.Start(STR_MSDNPATH, para);
            }
            catch
            {
                System.Diagnostics.Process.Start(STR_MSDNPATH);
            }
        }

        #region Bind 分隔线
        public static void BindSeparateLine(ContextMenuStrip PopupMenu)
        {
            ToolStripItem SeparateLine = new ToolStripSeparator();
            PopupMenu.Items.Add(SeparateLine);
        }
        #endregion

        #region BindAutoRun
        public static void BindAutoRun(ContextMenuStrip PopupMenu)
        {
            ToolStripItem autoRunItem = PopupMenu.Items.Add(STR_AutoRun);
            if (utility.ifExsistKey())
            {
                ToolStripMenuItem item = (ToolStripMenuItem)autoRunItem;
                item.Checked = true;

                /***********/
                //autoRunItem.Image = Image.FromFile(STR_CHECKEDIMAGE);
                /***********/
            }
            autoRunItem.Click += new EventHandler(autoRunItem_Click);
        }

        static void autoRunItem_Click(object sender, EventArgs e)
        {
            ToolStripItem autoRunItem = (ToolStripItem)sender;            
            if (utility.ifExsistKey())
            {
                ToolStripMenuItem item = (ToolStripMenuItem)autoRunItem;
                item.Checked = false;

                /***********/
                autoRunItem.Image = null;
                /***********/
                utility.DelAutoRun();
            }
            else
            {
                ToolStripMenuItem item = (ToolStripMenuItem)autoRunItem;
                item.Checked = true;

                /***********/
                //autoRunItem.Image = Image.FromFile(STR_CHECKEDIMAGE);
                /***********/
                utility.autoRun();
            }
        }
        #endregion
    }
}