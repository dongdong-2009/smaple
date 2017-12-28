/****************************************
 * ����
 * 2007-07-04
 * XmlOperate.cs * 
 * ����޸�ʱ�䣺2007-07-08
 * **************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

//0��������ɹ�

namespace ShortCutMenu
{
    public class XmlOperate
    {
        #region ��Ա
        public static readonly string config_path = Application.StartupPath + "\\ShortCut.dll";
        private static readonly string STR_PARENTTAGNAME = "GROUP";
        public static readonly string STR_GROUPID = "GROUPID";
        public static readonly string STR_GROUPNAME = "GROUPNAME";
        private static readonly string STR_APPLICATION = "APPLICATION";
        public static readonly string STR_APPLICATIONID = "APPLICATIONID";
        public static readonly string STR_APPLICATIONNAME = "APPLICATIONNAME";
        public static readonly string STR_APPLICATIONPATH = "APPLICATIONPATH";
        public static readonly string STR_SYSTEM = "SYSTEM";
        public static readonly string STR_DISPLAY = "DISPLAY";
        public static readonly string STR_TRUE = "TRUE";
        public static readonly string STR_FALSE = "FALSE";
        #endregion

        #region ������
        public static string createGroup(string str_GroupName)
        {
            if (exsistGroupName(str_GroupName))
            {
                return "1";
            }
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlElement NewElemet = xdoc.CreateElement(STR_PARENTTAGNAME);
            Random rand = new Random();
            string  str_id = "Group" + Convert.ToInt32(rand.NextDouble()*123456789).ToString();
            NewElemet.SetAttribute(STR_GROUPID, str_id);
            NewElemet.SetAttribute(STR_GROUPNAME, str_GroupName.Trim());
            xe.AppendChild(NewElemet);
            xdoc.Save(config_path);
            return "0";
        }
        #endregion

        #region �Ƿ������ͬ����
        private static bool exsistGroupName(string str_GroupName)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList xnl = xe.SelectNodes(STR_PARENTTAGNAME);
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes[STR_GROUPNAME].Value == str_GroupName.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region ������Ӧ�ó���
        public static string createItemInGroup(string groupId, AppItem app)
        {
            XmlNode xn = XmlOperate.GetGroupById(groupId);
            if (exsistItemName(xn, app.Str_AppName))
            {
                return "1";
            }
            XmlDocument xdoc = xn.OwnerDocument;            
            XmlElement xe = xdoc.CreateElement(STR_APPLICATION);
            xe.SetAttribute(STR_APPLICATIONNAME, app.Str_AppName);
            xe.SetAttribute(STR_APPLICATIONID, app.Str_AppId);
            xe.SetAttribute(STR_APPLICATIONPATH, app.Str_AppPath);
            xn.AppendChild(xe);            
            xdoc.Save(config_path);
            return "0";
        }
        #endregion

        #region ������Ӧ�ó���
        public static string createItemInRoot(AppItem app)
        {            
            if (exsistItemName(null, app.Str_AppName))
            {
                return "1";
            }
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlElement NewElemet = xdoc.CreateElement(STR_APPLICATION);
            NewElemet.SetAttribute(STR_APPLICATIONNAME, app.Str_AppName);            
            NewElemet.SetAttribute(STR_APPLICATIONID, app.Str_AppId);
            NewElemet.SetAttribute(STR_APPLICATIONPATH, app.Str_AppPath);
            xe.AppendChild(NewElemet);
            xdoc.Save(config_path);
            return "0";
        }
        #endregion

        #region �Ƿ������ͬ��Ŀ��
        private static bool exsistItemName(XmlNode xn, string ApplicationName)
        {
            if (xn != null)
            {
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode xnTemp in xnl)
                {
                    if (xnTemp.Attributes[STR_APPLICATIONNAME].Value == ApplicationName.Trim())
                    {
                        return true;
                    }
                }
            }
            else
            {
                AppItem[] Apps = XmlOperate.GetRootApp();
                foreach (AppItem App in Apps)
                {
                    if (App.Str_AppName == ApplicationName.Trim())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region ɾ���ڵ�
        private static void deleteNode(XmlNode xn)
        {
            XmlDocument xdoc = xn.OwnerDocument;            
            XmlNode parentNode = xn.ParentNode;
            parentNode.RemoveChild(xn);
            xdoc.Save(config_path);
        }
        #endregion

        #region ��ȡGroup
        public static GroupItem[] GetGroup()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList xnl = xe.SelectNodes(STR_PARENTTAGNAME);
            GroupItem[] Groups = new GroupItem[xnl.Count];
            for (int i = 0; i < xnl.Count; i++)
            {
                Groups[i] = new GroupItem();
                Groups[i].GroupId = xnl[i].Attributes[STR_GROUPID].Value;
                Groups[i].GroupName = xnl[i].Attributes[STR_GROUPNAME].Value;
                XmlNodeList appList = xnl[i].SelectNodes(STR_APPLICATION);
                AppItem[] appItem = new AppItem[appList.Count];
                for (int j = 0; j < appList.Count; j++)
                {
                    appItem[j] = new AppItem();
                    appItem[j].Str_AppId = appList[j].Attributes[STR_APPLICATIONID].Value;
                    appItem[j].Str_AppName = appList[j].Attributes[STR_APPLICATIONNAME].Value;
                    appItem[j].Str_AppPath = appList[j].Attributes[STR_APPLICATIONPATH].Value;                    
                }
                Groups[i].AppItems = appItem;
            }
            return Groups;
        }
        #endregion

        #region ��ȡ���ڵ��µ�Application
        public static AppItem[] GetRootApp()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList appList = xe.SelectNodes(STR_APPLICATION);
            AppItem[] appItem = new AppItem[appList.Count];
            for (int j = 0; j < appList.Count; j++)
            {
                appItem[j] = new AppItem();
                appItem[j].Str_AppId = appList[j].Attributes[STR_APPLICATIONID].Value;
                appItem[j].Str_AppName = appList[j].Attributes[STR_APPLICATIONNAME].Value;
                appItem[j].Str_AppPath = appList[j].Attributes[STR_APPLICATIONPATH].Value;
            }
            return appItem;
        }
        #endregion       

        #region ͨ��ID�õ�������ڵ�
        private static XmlNode GetRootAppById(string id)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList xnl = xe.SelectNodes(STR_APPLICATION);
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes[STR_APPLICATIONID].Value == id)
                {
                    return xn;
                }
            }
            return null;
        }
        #endregion

        #region ͨ��ID�õ���ڵ�
        private static XmlNode GetGroupById(string id)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList xnl = xe.SelectNodes(STR_PARENTTAGNAME);
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes[STR_GROUPID].Value == id)
                {
                    return xn;
                }
            }
            return null;
        }
        #endregion

        #region ͨ��IDɾ��������ڵ�
        public static void DelRootAppById(string id)
        { 
            XmlOperate.deleteNode(XmlOperate.GetRootAppById(id));
        }
        #endregion

        #region ͨ����Id��Ӧ�ó���Id�õ�����ڵ�
        private static XmlNode GetSubAppByGroupIdAppId(string GroupId, string AppId)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList xnl =  xe.SelectNodes(STR_PARENTTAGNAME);
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes[STR_GROUPID].Value == GroupId)
                {
                    XmlNodeList appLists = xn.SelectNodes(STR_APPLICATION);
                    foreach (XmlNode app in appLists)
                    {
                        if (app.Attributes[STR_APPLICATIONID].Value == AppId)
                        {
                            return app;
                        }
                    }
                }
            }
            return null;
        }
        #endregion

        #region ͨ����Id��Ӧ�ó���Idɾ������ڵ�
        public static void DelSubAppByGroupIdAppId(string GroupId, string AppId)
        {
            XmlOperate.deleteNode(GetSubAppByGroupIdAppId(GroupId, AppId));
        }        
        #endregion

        #region ɾ����
        public static void DelGroup(string groupId)
        {
            XmlNode xn = XmlOperate.GetGroupById(groupId);
            XmlOperate.deleteNode(xn);
        }
        #endregion

        #region �õ���Ӧ�ó���
        public static AppItem[] GetGroupApps(string groupId)
        {
            XmlNode xn = XmlOperate.GetGroupById(groupId);
            XmlNodeList xnl = xn.SelectNodes(STR_APPLICATION);
            AppItem[] apps = new AppItem[xnl.Count];
            for (int i = 0; i < apps.Length; i++)
            {
                apps[i] = new AppItem();
                apps[i].Str_AppId = xnl[i].Attributes[STR_APPLICATIONID].Value;
                apps[i].Str_AppName = xnl[i].Attributes[STR_APPLICATIONNAME].Value;
                apps[i].Str_AppPath = xnl[i].Attributes[STR_APPLICATIONPATH].Value;
            }
            return apps;
        }
        #endregion

        #region �õ��ɼ���ϵͳӦ�ó����б�
        public static List<AppItem> GetSystemApplicationVisible()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList xnl = xe.SelectNodes(XmlOperate.STR_SYSTEM);
            List<AppItem> apps = new List<AppItem>();
            for (int i = 0; i < xnl.Count; i++)
            {
                if (Convert.ToBoolean(xnl[i].Attributes[STR_DISPLAY].Value))
                {
                    AppItem app = new AppItem();
                    app.Str_AppId = xnl[i].Attributes[STR_APPLICATIONID].Value;
                    app.Str_AppName = xnl[i].Attributes[STR_APPLICATIONNAME].Value;
                    app.Str_AppPath = xnl[i].Attributes[STR_APPLICATIONPATH].Value;
                    apps.Add(app);
                }                
            }
            return apps;
        }
        #endregion

        #region �õ�ϵͳӦ�ó����б�
        public static List<AppItem> GetSystemApplication()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList xnl = xe.SelectNodes(XmlOperate.STR_SYSTEM);
            List<AppItem> apps = new List<AppItem>();
            for (int i = 0; i < xnl.Count; i++)
            {
                AppItem app = new AppItem();
                app.Str_AppId = xnl[i].Attributes[STR_APPLICATIONID].Value;
                app.Str_AppName = xnl[i].Attributes[STR_APPLICATIONNAME].Value;
                app.Str_AppPath = xnl[i].Attributes[STR_APPLICATIONPATH].Value;
                app.Visible = Convert.ToBoolean(xnl[i].Attributes[STR_DISPLAY].Value);
                apps.Add(app);
            }
            return apps;
        }
        #endregion

        #region ��ȡϵͳӦ�ó���ById
        private static XmlNode GetSystemApplicationById(string appId)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(config_path);
            XmlElement xe = xdoc.DocumentElement;
            XmlNodeList xnl = xe.SelectNodes(STR_SYSTEM);
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes[STR_APPLICATIONID].Value == appId)
                {
                    return xn;
                }
            }
            return null;
        }
        #endregion

        #region ɾ��ϵͳӦ�ó���ById
        public static void DelSystemApplicationById(string appId)
        {
            XmlNode xn = XmlOperate.GetSystemApplicationById(appId);
            XmlOperate.deleteNode(xn);
        }
        #endregion

        #region �ı�ϵͳӦ�ó������ʾ״̬
        private static void ChangeSystemApplicationState(XmlNode xn)
        {
           xn.Attributes[STR_DISPLAY].Value = (Convert.ToBoolean(xn.Attributes[STR_DISPLAY].Value)) ? (STR_FALSE) : (STR_TRUE);
        }
        #endregion

        #region �ı�ϵͳӦ�ó������ʾ״̬ById
        public static void ChangeSystemApplicationStateById(string id)
        {            
            XmlNode xn = XmlOperate.GetSystemApplicationById(id);
            xn.Attributes[STR_DISPLAY].Value = (Convert.ToBoolean(xn.Attributes[STR_DISPLAY].Value)) ? (STR_FALSE) : (STR_TRUE);
            XmlDocument xdoc = xn.OwnerDocument;
            xdoc.Save(config_path);
        }
        #endregion

    }
}
