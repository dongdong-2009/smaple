using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace MobileControlLibrary.UI.Controls
{
    /// <summary>
    /// 需要回传数据的表单域控件基类
    /// </summary>
    [ToolboxItem(false)]
    public class FormFiledControl:Control
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            (Page as MobilePage).RegisterFormFieldControl(this);
        }

        public virtual string GetFormFiledValue()
        {
            return string.Format("$({0})", this.ClientID);
        }
    }

    public class FormFieldControlCollection : List<FormFiledControl>
    {
    }
}
