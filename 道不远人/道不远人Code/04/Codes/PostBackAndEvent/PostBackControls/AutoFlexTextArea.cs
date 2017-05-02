using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;
using System.ComponentModel;
using System.Web.UI;

namespace PostBackControls
{
    [ParseChildren(true, "Text"), 
     ControlBuilder(typeof(AutoFlexTextAreaBuilder)),
     DefaultEvent("TextChanged"),
     DefaultProperty("Text")]
    public class AutoFlexTextArea:WebControl,IPostBackDataHandler
    {
        bool _scriptSupported = false;

        static readonly object EventTextChanged;
        
        //声明事件
        [Category("Action")]
        public event EventHandler TextChanged
        {
            add
            {
                Events.AddHandler(EventTextChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventTextChanged, value);
            }
        }

        
        //检测浏览器是否支持脚本功能
        void DetermineScript()
        {
            if (Page != null && !(Site != null && Site.DesignMode))
            {
                HttpBrowserCapabilities browser = Page.Request.Browser;
                _scriptSupported = ( browser.EcmaScriptVersion.CompareTo(new Version(1,2))>=0 )
                                    && (browser.MSDomVersion.Major >= 4);
            }
        }

        [DefaultValue("0"), 
         Category("Appearance"), 
         Description("文本域的最大高度")]
        public int MaxHeight
        {
            get
            {
                object obj2 = this.ViewState["MaxHeight"];
                if (obj2 != null)
                {
                    return (int)obj2;
                }
                return 0;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MaxHeight must more than 0.");
                }
                this.ViewState["MaxHeight"] = value;
            }
        }

        [Category("Appearance"),
         PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty), 
         DefaultValue("")]
        public virtual string Text
        {
            get
            {
                string text = (string)this.ViewState["Text"];
                if (text != null)
                {
                    return text;
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["Text"] = value;
            }
        }

        protected override System.Web.UI.HtmlTextWriterTag TagKey
        {
            get
            {
                return System.Web.UI.HtmlTextWriterTag.Textarea;
            }
        }

        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            if (Page != null)
            {
                Page.VerifyRenderingInServerForm(this);
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);

            if (!Enabled)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            }

            DetermineScript();
            if (_scriptSupported)
            {
                string script = null;
                if (this.MaxHeight <= 0)
                {
                    script = "this.style.height = this.scrollHeight + ( this.offsetHeight - this.clientHeight )";
                }
                else
                {
                    script = "this.style.height = ( this.scrollHeight > " + this.MaxHeight.ToString() + " ) ? " + this.MaxHeight.ToString() + " : this.scrollHeight + ( this.offsetHeight - this.clientHeight )";
                }
                writer.AddAttribute("onpropertychange", script);
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            HttpUtility.HtmlEncode(this.Text, writer);
        }

        protected override void AddParsedSubObject(object obj)
        {
            if(!(obj is LiteralControl))
                return;
            base.AddParsedSubObject(obj);
        }


        #region IPostBackDataHandler 成员

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string text = this.Text;
            string text2 = postCollection[postDataKey];
            if (!text.Equals(text2, StringComparison.Ordinal))
            {
                this.Text = text2;
                return true;
            }
            return false;

        }

        public void RaisePostDataChangedEvent()
        {
            EventHandler handler = (EventHandler)Events[EventTextChanged];
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion
    }

    public class AutoFlexTextAreaBuilder : ControlBuilder
    {
        public override bool AllowWhitespaceLiterals()
        {
            return false;
        }

        public override bool HtmlDecodeLiterals()
        {
            return true;
        }
    }
}
