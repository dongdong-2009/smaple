//===============================================================================
// 创建者: ZhouMing
// 功能描述:
// 最后修改日期:2007-10-11
// 联系方式:QQ(31767702) dpzhoum@dfl.com.cn
//===============================================================================


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

//实现INamingContainer  确保命名不能重名
//CreateChildeControls  在当前控件中可创建子控件
//EnSureChildeControls  确保子控件加载

namespace ZhouM_WebControl
{
    #region 用于查询的安全SQL文本框
    /// <summary>
    /// 安全的SQL文本框
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:SecureSQLTextBox runat=server></{0}:SecureSQLTextBox>")]
    public class SecureSQLTextBox : ExtendTextBox, INamingContainer
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string SecureSQLText
        {
            get
            {
                string filter = this.Text;
                filter = filter.Replace("[", "[[]");
                filter = filter.Replace("%", "[%]");
                filter = filter.Replace("_", "[_]");
                return filter;
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
    #endregion    
}
