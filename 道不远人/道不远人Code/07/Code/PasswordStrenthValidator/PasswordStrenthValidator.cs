using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System.Text.RegularExpressions;

[assembly: WebResource("CustomValidators.PasswordStrenth.js", "application/x-javascript")]

namespace CustomValidators
{
    [ToolboxData("<{0}:PasswordStrenthValidator runat=\"server\" ErrorMessage=\"PasswordStrenthValidator\"></{0}:PasswordStrenthValidator>")]
    public class PasswordStrenthValidator:BaseValidator
    {
        static Regex[] _regexes = { new Regex("[a-z]", RegexOptions.Compiled),new Regex("[A-Z]",RegexOptions.Compiled),
                                    new Regex("[0-9]",RegexOptions.Compiled),new Regex(@"[^a-z,A-Z,0-9,\x20]",RegexOptions.Compiled)};
        static int[] _ratio = { 5, 5, 5, 10 };
        static readonly int _multiType = 20;

        [Category("Behavior")]
        [DefaultValue(60)]
        public int PassWordStrenth
        {
            get
            {
                if (ViewState["PassWordStrenth"] == null)
                    return 60;
                return (int)ViewState["PassWordStrenth"];
            }
            set
            {
                ViewState["PassWordStrenth"] = value;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!DesignMode)
            {
                Page.ClientScript.RegisterClientScriptResource(typeof(PasswordStrenthValidator), "CustomValidators.PasswordStrenth.js");
            }
        }
	
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            if (base.RenderUplevel)
            {
                string controlId = ClientID;
                Page.ClientScript.RegisterExpandoAttribute(ClientID, "evaluationfunction", "PasswordStrenthValidatorEvaluateIsValid", false);
                Page.ClientScript.RegisterExpandoAttribute(ClientID, "passwordStrenth", this.PassWordStrenth.ToString(),false);
            }
        }

        protected override bool EvaluateIsValid()
        {
            string value = GetControlValidationValue(ControlToValidate);
            if (value == null && value.Trim() == string.Empty)
                return true;
            int strenthValue = 0;
            int multiType = -1;
            for (int i = 0; i < _regexes.Length; i++)
            {
                Regex reg = _regexes[i];
                int matchCount = reg.Matches(value).Count;
                strenthValue += matchCount * _ratio[i];
                if (matchCount > 0)
                {
                    multiType++;
                }
            }
            strenthValue += multiType * _multiType;
            return strenthValue >= PassWordStrenth;
        }
    }
}
