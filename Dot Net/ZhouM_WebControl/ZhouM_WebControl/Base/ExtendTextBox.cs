//===============================================================================
// ������: ZhouMing
// ��������:
// ����޸�����:2007-10-11
// ��ϵ��ʽ:QQ(31767702) dpzhoum@dfl.com.cn
//===============================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace ZhouM_WebControl
{
    public abstract class ExtendTextBox : TextBox
    {
        const string aboutAuthor = "dpzhoum@dfl.com.cn";        
        /// <summary>
        ///Get The Information about the Author of this Control.(ReadOnly)
        /// </summary>
        [Bindable(true)]
        [Category("��������")]
        [DefaultValue("")]
        [Localizable(true)]
        public string AboutAuthor
        {            
            get
            {
                return aboutAuthor;
            }
        }

        public override string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["Text"] = value;
            }
        }
    }
}
