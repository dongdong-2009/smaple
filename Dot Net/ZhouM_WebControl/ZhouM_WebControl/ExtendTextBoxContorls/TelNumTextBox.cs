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
    #region �绰��������� �����������ֻ�������-() ;
    /// <summary>
    /// �绰���������
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TelNumTextBox runat=server></{0}:TelNumTextBox>")]
    //[ToolboxBitmap(typeof(TelNumTextBox), "ZhouM_WebControl.OnlyNumText.bmp")]
    //���⣺��β���Ctrl+V  ���ʶ�����ּ������ּ��ĸ���(��8 *)��firefox�·���clipboardData
    public class TelNumTextBox : ExtendTextBox, INamingContainer
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegisterJavascript();
            this.Attributes.Add("onkeydown", "TelNum(event);");
            //this.Attributes.Add("oncontextmenu", "return false;");//���η���
            this.Attributes.Add("onpaste", "filterClipBoard(this);");//���η���
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
            function TelNum(e)
            {
                var keycode;
                 if(window.event)
                 {
                    keycode = event.keyCode;
                 }
                 else
                 {
                    keycode = e.which;
                 }
                 var realkey = String.fromCharCode(keycode);
                 if(keycode == 109 || keycode==8 || keycode==46|| keycode==59|| keycode==186 || keycode==189 || (keycode>=35 && keycode<=40) ||((keycode>=96 && keycode<=105)))
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

            function filterClipBoard(ctrl)
            {
                var content = clipboardData.getData('Text');
                var chararray = content.replace(/(.)(?=[^$])/g,'$1,').split(',');//���ַ���תΪ�ַ����顣
                
		        var s ='';
                for(var i = 0; i < chararray.length; i++)
                {
                    var temp =   chararray[i].charCodeAt();
                    if(temp == 45 || temp==59 || temp==40|| temp==41) // - ; ( )
                     {
                        s +=chararray[i];
                     }
                     else if(/\d/.test(chararray[i]))
                     {
                        s +=chararray[i];
                     }                     
                }
                ctrl.value = s;

                if(window.event)
                {window.event.returnValue = false;}
                else
                {e.preventDefault();}//for firefox
            }

            String.prototype.toCharArray = function()            
            {
              var charArr=new Array();
              for(var i=0;i<this.value.length;i++)
              {
                  charArr[i]=this.value.charAt(i);
              }
              return charArr;
             }
            ");
            //keycode==8 backspace
            //keycode==46 delete
            //keycode>=35 && keycode<=40 ��������
            //keycode==186 ;(�ֺ�)
            //keycode==189 -
            //keycode>=96 && keycode<=105 С�������ּ�
            //keycode == 109     С����-
            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "TelNum"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "TelNum", s.ToString(), true);
            }
        }

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();
        //}
    }
    #endregion  
}
