using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

[assembly: WebResource("ZhouM_WebControl.Common.js", "application/x-javascript")]
[assembly: WebResource("ZhouM_WebControl.Other.Slash.js", "application/x-javascript")]
//使用该控件必须去掉页面上的
//<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
//寻求解决方案


//另：本控件在设计时无外观，给设计带来了不便，有待改进。
namespace ZhouM_WebControl
{
    
    public class Slash:BaseContorl
    {
        /// <summary>
        /// 要加入斜线的控件的客户端ID
        /// </summary>
        private string controlClientID;
        public string ControlClientID
        {
            get { return controlClientID; }
            set { controlClientID = value; }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        private string colorCode;
        public string ColorCode
        {
            get { return colorCode; }
            set { colorCode = value; }
        }

        private string border;

        public string Border
        {
            get { return border; }
            set { border = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (ControlClientID == null || ControlClientID.Trim() == string.Empty)
            {
                throw new Exception("属性ControlClientID未赋值。");
            }

            if (ColorCode == null || ColorCode.Trim() == string.Empty)
            {
                throw new Exception("属性ColorCode未赋值。");
            }

            base.OnInit(e);           
            base.Page.ClientScript.RegisterClientScriptResource(this.GetType(), "ZhouM_WebControl.Common.js");
            base.Page.ClientScript.RegisterClientScriptResource(this.GetType(), "ZhouM_WebControl.Other.Slash.js");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.Page.ClientScript.RegisterStartupScript(this.GetType(), ControlClientID, "line_laodongjie('" + ControlClientID + "','" + ColorCode + "','" + Border + "')", true);
        }
    }
}