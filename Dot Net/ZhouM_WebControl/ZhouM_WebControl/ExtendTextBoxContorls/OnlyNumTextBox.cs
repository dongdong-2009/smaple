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
    #region ��������� ֻ����������
    /// <summary>
    /// ���������
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:OnlyNumTextBox runat=server></{0}:OnlyNumTextBox>")]
    public class OnlyNumTextBox : ExtendTextBox, INamingContainer
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegisterJavascript();
            this.Attributes.Add("onkeydown", "OnlyNum(event);");
            this.Attributes.Add("oncontextmenu", "return false;");//���η���
            this.Style.Add("ime-Mode", "disabled");//�������뷨
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }

        private void RegisterJavascript()
        {
            StringBuilder s = new StringBuilder("");
            s.Append(@"
            function OnlyNum(e)
            {
                 var keycode = window.event ? e.keyCode:e.which;
                 var realkey = String.fromCharCode(keycode);
                 if((keycode>=96 && keycode<=105)||keycode==8 || keycode==46||(keycode>=35 && keycode<=40))
                 {
                    return true;
                 }
                 else if(!/\d/.test(realkey))
                 {
                     if(window.event)
                   {window.event.returnValue = false;}
                else
                    {e.preventDefault();}//for firefox
                 }
            }            
            ");
            //keycode==8 backspace
            //keycode==46 delete
            //keycode>=35 && keycode<=40 ��������
            //keycode==186 ;(�ֺ�)
            //keycode==189 -
            //keycode>=96 && keycode<=105 С�������ּ�
            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "OnlyNum"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OnlyNum", s.ToString(), true);
            }
        }
    }
    #endregion
}