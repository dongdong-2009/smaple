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
    #region 货币输入框
    /// <summary>
    /// 货币输入框
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
            this.Attributes.Add("oncontextmenu", "return false;");//屏蔽反键
            this.Style.Add("ime-Mode", "disabled");//屏蔽输入法
            //失去焦点让时,如果最后一位是小数点则删除小数点,如果第1位为小数点则在小数点前补0
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
                <!-- 首位不能小数点 -->
                 if((keycode == 110 || keycode == 190)&&ctrl.value=='')
                 {
                     event.returnValue = false;
                     return false;
                 }
                 var realkey = String.fromCharCode(keycode);
                 if((keycode>=96 && keycode<=105)||keycode==8 || keycode==46||(keycode>=35 && keycode<=40)||keycode == 110 || keycode == 190||keycode == 109 || keycode == 189)
                 {
                    <!-- 不能有2个小数点 和 负号 -->
                    if(ctrl.value.indexOf('.') != -1)
                    {
                        if(keycode == 110 || keycode == 190)
                        {
                            event.returnValue = false;
                            return false; 
                        }
                    }

                    <!-- 负号只能在第1位 -->
                    if(ctrl.value.indexOf('-') != -1 || ShowCursorPos(ctrl) !=1)
                    {
                        if(keycode == 109 || keycode == 189)
                        {
                            event.returnValue = false;
                            return false; 
                        }
                    }

                    <!-- 如果第1位输0 自动在后面跟上. -->
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

            <!-- 获取光标在文本框中的位置. -->
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
            //keycode>=35 && keycode<=40 ↑↓←→
            //keycode==186 ;(分号)
            //keycode==189 -
            //keycode>=96 && keycode<=105 小键盘数字键
            //keycode=190 .
            //keycode=110 小键盘.
            //keycode=48  0
            //keycode=96 小键盘0
            //keycode=189 -(负号)
            //keycode=109 小键盘-(负号)
            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "CurrencyNum"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CurrencyNum", s.ToString(), true);
            }
        }
    }
    #endregion
}
