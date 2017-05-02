//===============================================================================
// ������: ZhouMing
// ��������:
// ����޸�����:2007-10-11
// ��ϵ��ʽ:QQ(31767702) dpzhoum@dfl.com.cn
//===============================================================================


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

//ʵ��INamingContainer  ȷ��������������
//CreateChildeControls  �ڵ�ǰ�ؼ��пɴ����ӿؼ�
//EnSureChildeControls  ȷ���ӿؼ�����

namespace ZhouM_WebControl
{
    #region ���ڲ�ѯ�İ�ȫSQL�ı���
    /// <summary>
    /// ��ȫ��SQL�ı���
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
