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
        [Description("UpdatePanel更新时是否仅禁用触发更新的控件，默认禁用页面中所有控件")]
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
        /// 实现同一页面中只能有一个UpdateDidsabler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (GetCurrent(Page) != null)
            {
                throw new InvalidOperationException("同一页面中不能有多个UpateDisabler");
            }
            else
            {
                Page.Items[typeof(UpdateDisabler)] = this;
            }
        }

        /// <summary>
        /// 获得页面中的UpdateDisabler对象
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
        /// 创建控件声明，将被利用生成$create()脚本
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("AJAXControls.UpdateDisabler", this.ClientID);
            descriptor.AddScriptProperty("onlyDisableTrigger", this.OnlyDisableTrigger.ToString().ToLower());
            yield return descriptor;
        }

        /// <summary>
        /// 注册控件需要使用的脚本文件
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
