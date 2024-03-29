//===============================================================================
// 创建者: ZhouMing
// 功能描述:
// 最后修改日期:2007-10-11
// 联系方式:QQ(31767702) dpzhoum@dfl.com.cn
//===============================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;


namespace ZhouM_WebControl
{
    public abstract class ExtendImage : Image
    {
        const string aboutAuthor = "dpzhoum@dfl.com.cn";
        /// <summary>
        ///Get The Information about the Author of this Control.(ReadOnly)
        /// </summary>
        [Bindable(true)]
        [Category("关于作者")]
        [DefaultValue("")]
        [Localizable(true)]
        public string AboutAuthor
        {
            get
            {
                return aboutAuthor;
            }
        }

        //public virtual string Text
        //{
        //    get
        //    {
        //        string s = (string)ViewState["Text"];
        //        return (s == null) ? String.Empty : s;
        //    }
        //    set
        //    {
        //        ViewState["Text"] = value;
        //    }
        //}
    }
}
