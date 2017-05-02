using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly:WebResource("AJAXControlLibrary.ToolTipsControl.js","text/javascript")]
[assembly: WebResource("AJAXControlLibrary.ToolTipsControl.debug.js", "text/javascript;charset=utf8")]

namespace AJAXControlLibrary
{
    [ParseChildren(true)]
    [DefaultProperty("Text")]
    public class ToolTips : ScriptControl,INamingContainer
    {
        private ITemplate _popupTemplate;

        /// <summary>
        /// 弹出提示框模板
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Browsable(false)]
        [DefaultValue(null)]
        [TemplateContainer(typeof(PopupContainer))]
        public ITemplate PopupTemplate
        {
            get { return _popupTemplate; }
            set { _popupTemplate = value; }
        }

        /// <summary>
        /// 控件内容
        /// </summary>
        [PersistenceMode(PersistenceMode.Attribute)]
        public string Text
        {
            get
            {
                if (ViewState["Text"] == null)
                    return string.Empty;
                return (string)ViewState["Text"];
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        /// <summary>
        /// 客户端show事件响应程序
        /// </summary>
        [PersistenceMode(PersistenceMode.Attribute)]
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

        /// <summary>
        /// 客户端hide事件响应程序
        /// </summary>
        [PersistenceMode(PersistenceMode.Attribute)]
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

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Span;
            }
        }

        PopupContainer _popupControl = null;

        /// <summary>
        /// 根据模板实例化子控件
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();
            if (PopupTemplate != null)
            {
                _popupControl = new PopupContainer();
                _popupControl.ID = "popup";
                PopupTemplate.InstantiateIn(_popupControl);
                Controls.Add(_popupControl);
            }
            ChildControlsCreated = true;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write(HttpUtility.HtmlEncode(Text));
            base.RenderContents(writer);
        }

        /// <summary>
        /// 返回用于创建控件的$create()脚本的描述列表
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            EnsureChildControls();
            List<ScriptDescriptor> descriptors = new List<ScriptDescriptor>();
            if (_popupControl != null)
            {
                ScriptControlDescriptor descriptor = new ScriptControlDescriptor("AJAXControls.ToolTips", this.ClientID);
                descriptor.AddScriptProperty("popupElement", "'"+_popupControl.ClientID+"'");
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

        /// <summary>
        /// 返回需要注册到页面的脚本引用列表
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            ScriptReference previewScript = new ScriptReference("PreviewScript.js", "Microsoft.Web.Preview");
            ScriptReference toolTipsScript = new ScriptReference("AJAXControlLibrary.ToolTipsControl.js", this.GetType().Assembly.FullName);
            ScriptReference[] references = new ScriptReference[] { previewScript, toolTipsScript };
            return references;
        }
    }

    /// <summary>
    /// 模板容器需要实现INamingContainer接口
    /// </summary>
    [ToolboxItem(false)]//不显示在工具箱中
    public class PopupContainer : WebControl, INamingContainer
    {
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
    }
}
