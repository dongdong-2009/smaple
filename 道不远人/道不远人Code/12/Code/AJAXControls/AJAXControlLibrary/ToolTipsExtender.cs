using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource("AJAXControlLibrary.ToolTipsBehavior.js", "text/javascript")]
[assembly: WebResource("AJAXControlLibrary.ToolTipsBehavior.debug.js", "text/javascript;charset=utf8")]

namespace AJAXControlLibrary
{
    [TargetControlType(typeof(Control))]
    public class ToolTipsExtender : ExtenderControl
    {
        public string ToolTipsContent
        {
            get
            {
                if (ViewState["ToolTipsContent"] == null)
                    return string.Empty;
                return (string)ViewState["ToolTipsContent"];
            }
            set
            {
                ViewState["ToolTipsContent"] = value;
            }
        }

        public string ClientShowHandler
        {
            get
            {
                if (ViewState["ClientShowHandler"] == null)
                    return string.Empty;
                return (string)ViewState["ClientShowHandler"];
            }
            set
            {
                ViewState["ClientShowHandler"] = value;
            }
        }

        public string ClientHideHandler
        {
            get
            {
                if (ViewState["ClientHideHandler"] == null)
                    return string.Empty;
                return (string)ViewState["ClientHideHandler"];
            }
            set
            {
                ViewState["ClientHideHandler"] = value;
            }
        }
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
        {
            List<ScriptDescriptor> descriptors = new List<ScriptDescriptor>();

            if (targetControl != null)
            {
                ScriptBehaviorDescriptor descriptor = new ScriptBehaviorDescriptor("AJAXControls.ToolTipsBehavior", targetControl.ClientID);
                descriptor.AddScriptProperty("toolTipsContent", "'" + ToolTipsContent + "'");
                if (!String.IsNullOrEmpty(ClientShowHandler))
                {
                    descriptor.AddEvent("show", ClientShowHandler);
                }
                if (!String.IsNullOrEmpty(ClientHideHandler))
                {
                    descriptor.AddEvent("hide", ClientHideHandler);
                }
                descriptors.Add(descriptor);                 
            }

            return descriptors;
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            ScriptReference toolTipsScript = new ScriptReference("AJAXControlLibrary.ToolTipsBehavior.js", this.GetType().Assembly.FullName);
            ScriptReference[] references = new ScriptReference[] { toolTipsScript };
            foreach (ScriptReference reference in references)
            {
                yield return reference;
            }
        }
    }
}
