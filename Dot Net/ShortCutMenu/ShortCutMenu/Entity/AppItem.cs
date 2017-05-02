/****************************************
 * 周铭
 * 2007-07-04
 * XmlOperate.cs * 
 * 最后修改时间：2007-07-09
 * **************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace ShortCutMenu
{
    public class AppItem
    {
        public AppItem(string id,string name, string path)
        {
            str_AppId = id;
            str_AppName = name;
            str_AppPath = path;
            visible = true;
        }

        public AppItem() 
        { 

        }

        string str_AppId;

        public string Str_AppId
        {
            get { return str_AppId; }
            set { str_AppId = value; }
        }
        string str_AppName;

        public string Str_AppName
        {
            get { return str_AppName; }
            set { str_AppName = value; }
        }
        string str_AppPath;

        public string Str_AppPath
        {
            get { return str_AppPath; }
            set { str_AppPath = value; }
        }

        public override string ToString()
        {
            return Str_AppName;
        }

        bool visible = true;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }
}
