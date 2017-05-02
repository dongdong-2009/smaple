using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections;
using System.Xml;

namespace DataBoundControls
{
    public class HierarchicalHeader:HierarchicalDataBoundControl
    {
        public static HtmlTextWriterTag[] TagKeys = { HtmlTextWriterTag.H1,HtmlTextWriterTag.H2,HtmlTextWriterTag.H3,HtmlTextWriterTag.H4,HtmlTextWriterTag.H5,HtmlTextWriterTag.H6,HtmlTextWriterTag.P};
        
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        protected override void PerformDataBinding()
        {
            base.PerformDataBinding();
            if (!String.IsNullOrEmpty(DataSourceID) || DataSource != null)
            {
                this.Controls.Clear();
                IEnumerator enumerator = GetEnumerator("");
                while (enumerator.MoveNext())
                {
                    RecursiveItem(enumerator.Current as IHierarchyData, 0);

                    //如果子控件是嵌套关系，则使用这样的代码：
                    //HierarchicalHeaderItem item = RecursiveItem(enumerator.Current as IHierarchyData, 0);
                    //Controls.Add(item);
                }
            }
        }

        IEnumerator GetEnumerator(string path)
        {
            IHierarchicalEnumerable enumerable = GetData(@"").Select();
            IEnumerator enumerator = enumerable.GetEnumerator();
            return enumerator;
        }

        void RecursiveItem(IHierarchyData data,int deepth)
        {
            HierarchicalHeaderItem item = new HierarchicalHeaderItem(deepth, data);
            Controls.Add(item);
            IEnumerator enumerator = data.GetChildren().GetEnumerator();
            while (enumerator.MoveNext())
            {
                RecursiveItem(enumerator.Current as IHierarchyData, deepth + 1);                
            }
        }

        //如果子控件是嵌套关系，则代码如下
        //HierarchicalHeaderItem RecursiveItem(IHierarchyData data, int deepth)
        //{
        //    HierarchicalHeaderItem item = new HierarchicalHeaderItem(deepth, data);
        //    IEnumerator enumerator = data.GetChildren().GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        HierarchicalHeaderItem child = RecursiveItem(enumerator.Current as IHierarchyData, deepth + 1);
        //        item.Controls.Add(child);
        //    }
        //    return item;
        //}

    }

    internal class HierarchicalHeaderItem : WebControl
    {
        int _deepth;
        IHierarchyData _data;


        public HierarchicalHeaderItem()
        {
        }
        public HierarchicalHeaderItem(int deepth, IHierarchyData data)
        {
            _deepth = deepth;
            if (_deepth >= HierarchicalHeader.TagKeys.Length)
                _deepth = HierarchicalHeader.TagKeys.Length - 1;
            _data = data;
        }
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HierarchicalHeader.TagKeys[_deepth];
            }
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (_data.Item is XmlElement)
            {
                writer.Write((_data.Item as XmlElement).Name);
            }
            RenderChildren(writer);
        }
    }
}
