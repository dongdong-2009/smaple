using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design;
using System.Web.UI;
using System.ComponentModel;

namespace CustomValidators
{
    [Designer(typeof(ValidatorCalloutExtenderDesigner))]
    public class ValidatorCalloutExtender:Control
    {
        protected override void OnPreRender(EventArgs e)
        {
            if (Page.Request.Browser.MSDomVersion.Major > 0
                && Page.Request.Browser.EcmaScriptVersion.Major > 0)
            {
                Page.ClientScript.RegisterClientScriptResource(typeof(ValidatorCalloutExtender),
                    "CustomValidators.ValidatorCallout.js");
                if (!Page.ClientScript.IsStartupScriptRegistered("ValidatorCalloutExtender"))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(ValidatorCalloutExtender), "ValidatorCalloutExtender",
                        "for(var i = 0 ; i < Page_Validators.length; i++){new ValidatorCallout(Page_Validators[i]).initiate();}\r\n", true);
                }
            }
            
        }
        public override void RenderControl(HtmlTextWriter writer)
        {
        }
    }
    public class ValidatorCalloutExtenderDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            return CreatePlaceHolderDesignTimeHtml("ValidatorCalloutExtender");
        }
    }
}
