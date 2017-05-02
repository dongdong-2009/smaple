using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace ZhouM_WebControl
{
    [ToolboxData("<{0}:DropDownTreeList runat=server></{0}:DropDownTreeList>")]
    public class DropDownTreeList : DropDownList
    {
        private object dataSource;
        private int deep = 0; 


        #region ----重写----
        public override object DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                this.dataSource = value;
            }
        }

        public override void DataBind()
        {
            if (ChildProperty == null)
            {
                throw new Exception("ChildProperty参数必须设置");
            }
            this.Items.Clear();
            ListItemCollection items=ConvertTreeToList(dataSource);
            foreach (ListItem item in items)
            {
                this.Items.Add(item);
            } 

        }
        #endregion 

        #region ----私有方法----
        private ListItemCollection ConvertTreeToList(object root)
        {
            deep = 0;
            ListItemCollection list =  new ListItemCollection();
            list.Add(GetListItem(root));
            ConvertTree(list, root);
            return list;
        }

        /**//// <summary>
        /// 将对象转换为ListItem
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private ListItem GetListItem(object root)
        {
            ListItem item = new ListItem();
            item.Text =GetDeepChar()+ root.GetType().GetProperty(this.DataTextField).GetValue(root, null).ToString();
            item.Value = root.GetType().GetProperty(this.DataValueField).GetValue(root, null).ToString();
            return item;
        }

        private void ConvertTree(ListItemCollection list, object root)
        {
            object childs= root.GetType().GetProperty(this.ChildProperty).GetValue(root,null);//获得Child的集合
            if(childs==null)
            {
                return;
            }
            if(!(childs is ICollection))
            {
                throw new Exception("数据源的"+ChildProperty+"属性必须实现ICollection接口");
            }
            deep++;
            foreach(object child in (ICollection)childs)
            { 

                list.Add(GetListItem(child));
                ConvertTree(list, child);//递归转换下一层节点
            }
            deep--;
        }

        /**//// <summary>
        /// 根据节点的深度返回节点前的占位字符
        /// </summary>
        /// <returns></returns>
        private string GetDeepChar()
        {
            string str = "";
            for (int i = 0; i < deep; i++)
            {
                str += DeepChar;
            }
            return str; 

        }
        #endregion

        #region ----公开的属性----
        [Description("表示深度增加的字符")]
        public string DeepChar
        {
            get
            {
                if (ViewState["DeepChar"] == null || ViewState["DeepChar"].ToString()=="")
                {
                    return "--";
                }
                return ViewState["DeepChar"].ToString();
            }
            set { ViewState["DeepChar"] = value; }
        }

        [Description("对象的子节点集合属性名")]
        public string ChildProperty
        {
            get
            {
                if (ViewState["ChildProperty"] == null)
                {
                    return null;
                }
                return ViewState["ChildProperty"].ToString();
            }
            set { ViewState["ChildProperty"] = value; }
        }
        #endregion
    }
} 