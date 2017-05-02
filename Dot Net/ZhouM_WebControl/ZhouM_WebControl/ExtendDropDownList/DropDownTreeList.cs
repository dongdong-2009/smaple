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


        #region ----��д----
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
                throw new Exception("ChildProperty������������");
            }
            this.Items.Clear();
            ListItemCollection items=ConvertTreeToList(dataSource);
            foreach (ListItem item in items)
            {
                this.Items.Add(item);
            } 

        }
        #endregion 

        #region ----˽�з���----
        private ListItemCollection ConvertTreeToList(object root)
        {
            deep = 0;
            ListItemCollection list =  new ListItemCollection();
            list.Add(GetListItem(root));
            ConvertTree(list, root);
            return list;
        }

        /**//// <summary>
        /// ������ת��ΪListItem
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
            object childs= root.GetType().GetProperty(this.ChildProperty).GetValue(root,null);//���Child�ļ���
            if(childs==null)
            {
                return;
            }
            if(!(childs is ICollection))
            {
                throw new Exception("����Դ��"+ChildProperty+"���Ա���ʵ��ICollection�ӿ�");
            }
            deep++;
            foreach(object child in (ICollection)childs)
            { 

                list.Add(GetListItem(child));
                ConvertTree(list, child);//�ݹ�ת����һ��ڵ�
            }
            deep--;
        }

        /**//// <summary>
        /// ���ݽڵ����ȷ��ؽڵ�ǰ��ռλ�ַ�
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

        #region ----����������----
        [Description("��ʾ������ӵ��ַ�")]
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

        [Description("������ӽڵ㼯��������")]
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