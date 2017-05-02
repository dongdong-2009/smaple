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
        /// ������ʾ��ģ��
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
        /// �ؼ�����
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
        /// �ͻ���show�¼���Ӧ����
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
        /// �ͻ���hide�¼���Ӧ����
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
        /// ����ģ��ʵ�����ӿؼ�
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
        /// �������ڴ����ؼ���$create()�ű��������б�
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
        /// ������Ҫע�ᵽҳ��Ľű������б�
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
    /// ģ��������Ҫʵ��INamingContainer�ӿ�
    /// </summary>
    [ToolboxItem(false)]//����ʾ�ڹ�������
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
