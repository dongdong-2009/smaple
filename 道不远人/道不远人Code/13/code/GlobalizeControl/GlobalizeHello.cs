using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Threading;
using System.Web.UI;

[assembly: WebResource("GlobalizeControl.GlobalizedHello.js", "text/javascript")]
[assembly: WebResource("GlobalizeControl.GlobalizedHello_zh-CN.js", "text/javascript")]

namespace GlobalizeControl
{
    public class GlobalizeHello:Label
    {
        [GlobalizeDescription("Text_Description")]
        public override string Text
        {
            get
            {
                return AssemblyResourceManager.PropertyResource.GetString("GlobalHello_Text");
            }
            set
            {
                //throw new NotSupportedException(AssemblyResourceManager.ExceptionResource.GetString("TextCantSet"));
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string scriptFile = "GlobalizeControl.GlobalizedHello.js";
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals(
                        "zh-CN", StringComparison.OrdinalIgnoreCase))
            {
                scriptFile = "GlobalizeControl.GlobalizedHello_zh-CN.js";
            }
            Page.ClientScript.RegisterClientScriptResource(this.GetType(), scriptFile);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Hello", "onload = function(){alert(helloString);}", true);
        }
    }
}
