using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;
using System.ComponentModel;

[assembly:WebResource("AJAXControlLibrary.jquery.js","text/javascript")]
[assembly:WebResource("AJAXControlLibrary.UpdateDisabler.js","text/javascript")]
[assembly: WebResource("AJAXControlLibrary.UpdateDisabler.debug.js", "text/javascript")]

namespace AJAXControlLibrary
{
    [NonVisualControl(true)]
    [Designer(typeof(UpdateDisablerDesigner))]
    public class UpdateDisabler:ScriptControl
    {
        [Description("UpdatePanel����ʱ�Ƿ�����ô������µĿؼ���Ĭ�Ͻ���ҳ�������пؼ�")]
        public bool OnlyDisableTrigger
        {
            get
            {
                if (ViewState["OnlyDisableTrigger"] == null)
                {
                    return false;
                }
                return (bool)ViewState["OnlyDisableTrigger"];
            }
            set
            {
                ViewState["OnlyDisableTrigger"] = value;
            }
        }

        /// <summary>
        /// ʵ��ͬһҳ����ֻ����һ��UpdateDidsabler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (GetCurrent(Page) != null)
            {
                throw new InvalidOperationException("ͬһҳ���в����ж��UpateDisabler");
            }
            else
            {
                Page.Items[typeof(UpdateDisabler)] = this;
            }
        }

        /// <summary>
        /// ���ҳ���е�UpdateDisabler����
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static UpdateDisabler GetCurrent(Page page)
        {
            if (page.Items[typeof(UpdateDisabler)] != null)
            {
                return page.Items[typeof(UpdateDisabler)] as UpdateDisabler;
            }
            return null;
        }

        /// <summary>
        /// �����ؼ�������������������$create()�ű�
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("AJAXControls.UpdateDisabler", this.ClientID);
            descriptor.AddScriptProperty("onlyDisableTrigger", this.OnlyDisableTrigger.ToString().ToLower());
            yield return descriptor;
        }

        /// <summary>
        /// ע��ؼ���Ҫʹ�õĽű��ļ�
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> scripts = new List<ScriptReference>();
            scripts.Add(new ScriptReference("AJAXControlLibrary.jquery.js", this.GetType().Assembly.FullName));
            scripts.Add(new ScriptReference("AJAXControlLibrary.UpdateDisabler.js", this.GetType().Assembly.FullName));
            return scripts;
        }
    }

    public class UpdateDisablerDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            return CreatePlaceHolderDesignTimeHtml("disable controls in current page when AJAX updating.");
        }
    }
}
