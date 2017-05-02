using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

[assembly:WebResource("IntegrateWithJavascriptLibrary.jquery.js","text/javascript")]
[assembly:WebResource("IntegrateWithJavascriptLibrary.interface.js","text/javascript")]

namespace IntegrateWithJavascriptLibrary
{

    public class TabbableTextArea:TextBox
    {

        bool _supportJS;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override TextBoxMode TextMode
        {
            get
            {
                return TextBoxMode.MultiLine;
            }
            set
            {
                throw new NotSupportedException("Can not change the TextMode property");
            }
        }

        void DetermineJS()
        {
            if (!DesignMode)
            {
                if (Page.Request.Browser.EcmaScriptVersion.Major > 0 && Page.Request.Browser.W3CDomVersion.Major > 0)
                {
                    this._supportJS = true;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            DetermineJS();
            if (_supportJS)
            {
                Page.ClientScript.RegisterClientScriptResource(this.GetType(), "IntegrateWithJavascriptLibrary.jquery.js");
                Page.ClientScript.RegisterClientScriptResource(this.GetType(), "IntegrateWithJavascriptLibrary.interface.js");
                Page.ClientScript.RegisterStartupScript(this.GetType(), this.UniqueID,
                    string.Format("    $('#{0}').EnableTabs();\r\n", this.UniqueID), true);
            }
        }
    }
}
