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
    #region ���������
    /// <summary>
    /// ���������
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CurrencyTextBox runat=server></{0}:CurrencyTextBox>")]
    public abstract class CurrencyTextBox : ExtendTextBox, INamingContainer
    {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegisterJavascript();
            this.Attributes.Add("onkeydown", "CurrencyNum(this,event);");
            this.Attributes.Add("oncontextmenu", "return false;");//���η���
            this.Style.Add("ime-Mode", "disabled");//�������뷨
            //ʧȥ������ʱ,������һλ��С������ɾ��С����,�����1λΪС��������С����ǰ��0
            this.Attributes.Add("onblur", "parseCurrency(this);");
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }

        private void RegisterJavascript()
        {
            StringBuilder s = new StringBuilder("");
            s.Append(@"
            function CurrencyNum(ctrl,e)
            {
                 var keycode = window.event ? e.keyCode:e.which;
                <!-- ��λ����С���� -->
                 if((keycode == 110 || keycode == 190)&&ctrl.value=='')
                 {
                     event.returnValue = false;
                     return false;
                 }
                 var realkey = String.fromCharCode(keycode);
                 if((keycode>=96 && keycode<=105)||keycode==8 || keycode==46||(keycode>=35 && keycode<=40)||keycode == 110 || keycode == 190||keycode == 109 || keycode == 189)
                 {
                    <!-- ������2��С���� �� ���� -->
                    if(ctrl.value.indexOf('.') != -1)
                    {
                        if(keycode == 110 || keycode == 190)
                        {
                            event.returnValue = false;
                            return false; 
                        }
                    }

                    <!-- ����ֻ���ڵ�1λ -->
                    if(ctrl.value.indexOf('-') != -1 || ShowCursorPos(ctrl) !=1)
                    {
                        if(keycode == 109 || keycode == 189)
                        {
                            event.returnValue = false;
                            return false; 
                        }
                    }

                    <!-- �����1λ��0 �Զ��ں������. -->
                    if(ctrl.value.length == 0 && (keycode==48 || keycode==96))
                    {
                        ctrl.value='0.';
                        event.returnValue = false;
                        return false;
                    }
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

            function parseCurrency(ctrl)
            {
               ctrl.value = parseFloat(ctrl.value);
            }

            <!-- ��ȡ������ı����е�λ��. -->
            function ShowCursorPos(el)
            {  
              if (el.createTextRange)
              {
                var v = el.value;  
                var r = el.createTextRange();
	            var s=document.selection.createRange();
	            s.setEndPoint('StartToStart',el.createTextRange());
	            return (s.text.length+1);
              } 
            }
            ");
            //keycode==8 backspace
            //keycode==46 delete
            //keycode>=35 && keycode<=40 ��������
            //keycode==186 ;(�ֺ�)
            //keycode==189 -
            //keycode>=96 && keycode<=105 С�������ּ�
            //keycode=190 .
            //keycode=110 С����.
            //keycode=48  0
            //keycode=96 С����0
            //keycode=189 -(����)
            //keycode=109 С����-(����)
            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "CurrencyNum"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CurrencyNum", s.ToString(), true);
            }
        }
    }
    #endregion
}
