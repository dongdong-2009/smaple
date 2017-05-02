using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace MobileControlLibrary.UI.Controls
{
    /// <summary>
    /// ��Ҫ�ش����ݵı���ؼ�����
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
