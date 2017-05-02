using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel.Design;
using System.Web.UI.Design.WebControls;
using System.ComponentModel;
using System;

namespace AJAXControls
{
    /// <summary>
    /// 使用泛型的ExtenderControlBaseDesigner可以快速实现Extender控件的设计器
    /// </summary>
    class ClientSortExtenderDesigner : AjaxControlToolkit.Design.ExtenderControlBaseDesigner<ClientSortExtender>
    {
        /// <summary>
        /// ExtenderControlBaseDesigner的一个显著特点是在设计时
        /// 将Extender控件除TargetControlID外的属性移到被扩展
        /// 控件的属性窗口中
        /// </summary>
        /// <param name="properties">属性列表</param>
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            //将SortExpression从properties集合中取出，
            //再交给base.PreFilterProperties()方法处理
            //避免将SortExpressions属性移到被扩展控件上
            PropertyDescriptor pd = (PropertyDescriptor)properties["SortExpressions"];
            properties.Remove("SortExpressions");
            base.PreFilterProperties(properties);
            //将SortExpressions属性放回properties集合
            properties.Add("SortExpressions",TypeDescriptor.CreateProperty(pd.ComponentType,pd,new Attribute[]{BrowsableAttribute.Yes}));
        }
    }
}
