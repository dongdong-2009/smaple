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
    #region 电话号码输入框 除了输入数字还可输入-() ;
    /// <summary>
    /// 电话号码输入框
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TelNumTextBox runat=server></{0}:TelNumTextBox>")]
    //[ToolboxBitmap(typeof(TelNumTextBox), "ZhouM_WebControl.OnlyNumText.bmp")]
    //问题：如何捕获Ctrl+V  如何识别数字键和数字键的副键(如8 *)。firefox下访问clipboardData
    public class TelNumTextBox : ExtendTextBox, INamingContainer
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegisterJavascript();
            this.Attributes.Add("onkeydown", "TelNum(event);");
            //this.Attributes.Add("oncontextmenu", "return false;");//屏蔽反键
            this.Attributes.Add("onpaste", "filterClipBoard(this);");//屏蔽反键
            this.Style.Add("ime-Mode", "disabled");//屏蔽输入法
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
                var chararray = content.replace(/(.)(?=[^$])/g,'$1,').split(',');//将字符串转为字符数组。
                
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
            //keycode>=35 && keycode<=40 ↑↓←→
            //keycode==186 ;(分号)
            //keycode==189 -
            //keycode>=96 && keycode<=105 小键盘数字键
            //keycode == 109     小键盘-
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
