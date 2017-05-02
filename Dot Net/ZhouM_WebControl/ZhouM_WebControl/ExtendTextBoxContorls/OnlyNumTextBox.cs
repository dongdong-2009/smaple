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
    #region 数字输入框 只能输入数字
    /// <summary>
    /// 数字输入框
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
            this.Attributes.Add("oncontextmenu", "return false;");//屏蔽反键
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
            //keycode>=35 && keycode<=40 ↑↓←→
            //keycode==186 ;(分号)
            //keycode==189 -
            //keycode>=96 && keycode<=105 小键盘数字键
            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "OnlyNum"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OnlyNum", s.ToString(), true);
            }
        }
    }
    #endregion
}