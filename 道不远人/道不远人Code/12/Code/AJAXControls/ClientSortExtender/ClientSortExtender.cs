using AjaxControlToolkit;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

[assembly: TagPrefix("AJAXControls", "ajaxToolkit")]
[assembly: WebResource("AJAXControls.ascending.gif", "image/gif")]
[assembly: WebResource("AJAXControls.descending.gif", "image/gif")]
[assembly: WebResource("AJAXControls.ClientSortExtenderBehavior.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("AJAXControls.ClientSortExtenderBehavior.debug.js", "text/javascript", PerformSubstitution = true)]


namespace AJAXControls
{
    [TargetControlType(typeof(GridView)),//指定扩展GridView
     //声明AJAXControls.ClientSortBehavior客户端Behavior
     //使用装配件中的AJAXControls.ClientSortExtenderBehavior.js
     ClientScriptResource("AJAXControls.ClientSortBehavior"
         , "AJAXControls.ClientSortExtenderBehavior.js"),
     Designer(typeof(ClientSortExtenderDesigner))]
    public class ClientSortExtender : ExtenderControlBase
    {
        [Category("Behavior"),
        DefaultValue(""),
        //如果属性名和脚本中的属性名对不上，
        //则使用ClientPropertyName指定对应关系
        ClientPropertyName("ascendingIconUrl"),
        //标记为ExtenderControlProperty的属性
        //会自动添加到客户端$create()方法的参数中
        ExtenderControlProperty,
        UrlProperty,
        Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string AscendingIconUrl
        {
            get
            {
                return base.GetPropertyValue<string>("ascendingIconUrl", "");
            }
            set
            {
                base.SetPropertyValue<String>("ascendingIconUrl", value);
            }
        }

        [Category("Behavior"),
        UrlProperty,
        Editor(typeof(ImageUrlEditor), typeof(UITypeEditor)),
        DefaultValue(""),
        ClientPropertyName("descendingIconUrl"),
        ExtenderControlProperty]
        public string DescendingIconUrl
        {
            get
            {
                return base.GetPropertyValue<string>("descendingIconUrl","");
            }
            set
            {
                base.SetPropertyValue<string>("descendingIconUrl", value);
            }
        }

        [DefaultValue(""),
        Category("Behavior"),
        Editor(typeof(SortExpressionEditor), typeof(UITypeEditor)),
        ClientPropertyName("sortExpressions"),
        ExtenderControlProperty]
        public string SortExpressions
        {
            get
            {
                return base.GetPropertyValue<string>("sortExpressions","");
            }
            set
            {
                base.SetPropertyValue<string>("sortExpressions", value);
            }
        }

        /// <summary>
        /// 方便设计器得到被扩展对象
        /// </summary>
        /// <returns>GridView</returns>
        public GridView GetTargetControl()
        {
            if (TargetControl != null && TargetControl is GridView)
            {
                return TargetControl as GridView;
            }
            return null;
        }
    }
}
