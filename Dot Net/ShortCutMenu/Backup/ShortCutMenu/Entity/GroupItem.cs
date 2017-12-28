/****************************************
 * 周铭
 * 2007-07-04
 * XmlOperate.cs * 
 * 最后修改时间：2007-07-05
 * **************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace ShortCutMenu
{
    public class GroupItem
    {
        public GroupItem()
        {

        }

        AppItem[] appItems;
        string groupId;
        string groupName;        

        public string GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        public AppItem[] AppItems
        {
            get { return appItems; }
            set { appItems = value; }
        }
    }
}
