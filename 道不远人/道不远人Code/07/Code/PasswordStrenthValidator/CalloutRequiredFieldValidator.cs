using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

[assembly:WebResource("CustomValidators.alertlarge.gif","image/gif")]
[assembly: WebResource("CustomValidators.alertsmall.gif", "image/gif")]
[assembly: WebResource("CustomValidators.close.gif", "image/gif")]
[assembly: WebResource("CustomValidators.ValidatorCallout.js", "application/x-javascript",PerformSubstitution=true)]

namespace CustomValidators
{
    [ToolboxData("<{0}:CalloutRequiredFieldValidator runat=\"server\" ErrorMessage=\"CalloutRequiredFieldValidator\"></{0}:CalloutRequiredFieldValidator>")]
    public class CalloutRequiredFieldValidator:RequiredFieldValidator
    {
        protected override void OnPreRender(EventArgs e)
        {            
            base.OnPreRender(e);
            if (RenderUplevel)
            {
                Page.ClientScript.RegisterClientScriptResource(typeof(CalloutRequiredFieldValidator),"CustomValidators.ValidatorCallout.js");
                Page.ClientScript.RegisterStartupScript(typeof(CalloutRequiredFieldValidator), this.ClientID + "Callout",
                    "new ValidatorCallout('"+this.ClientID+"').initiate();\r\n", true);
            }
        }
    }
}
