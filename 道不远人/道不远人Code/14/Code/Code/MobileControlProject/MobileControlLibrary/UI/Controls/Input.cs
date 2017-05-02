using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileControlLibrary.UI.Controls
{
    public enum InputType
    {
        Text,
        Password
    }
    /// <summary>
    /// 对应生成<input/>元素,
    /// 实现IPostBackDataHandler支持数据回传
    /// </summary>
    [ParseChildren(true,"Text")]//input不能有子元素
    public class Input:FormFiledControl,IFields,IPostBackDataHandler
    {
        #region TextChanged事件

        static object _textChanged = new object();

        public event EventHandler<EventArgs> TextChanged
        {
            add
            {
                Events.AddHandler(_textChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_textChanged, value);
            }
        }

        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            if (Events[_textChanged] != null)
            {
                (Events[_textChanged] as EventHandler<EventArgs>)(sender, e);
            }
        }

        #endregion

        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
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

        public string Title
        {
            get
            {
                if (ViewState["Title"] == null)
                    return string.Empty;
                return (string)ViewState["Title"];
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        public InputType Type
        {
            get
            {
                if (ViewState["Type"] == null)
                    return InputType.Text;
                return (InputType)ViewState["Type"];
            }
            set
            {
                ViewState["Type"] = value;
            }
        }

        public string Format
        {
            get
            {
                if (ViewState["Format"] == null)
                    return string.Empty;
                return (string)ViewState["Format"];
            }
            set
            {
                ViewState["Format"] = value;
            }
        }

        public bool EmptyOk
        {
            get
            {
                if (ViewState["EmptyOk"] == null)
                    return true;
                return (bool)ViewState["EmptyOk"];
            }
            set
            {
                ViewState["EmptyOk"] = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (DesignMode)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);
                writer.RenderBeginTag(HtmlTextWriterTag.Input);
                writer.RenderEndTag();
            }
            else
            {
                WmlTextWriter wmlWriter = writer as WmlTextWriter;
                //呈现属性，中文将自动编码
                wmlWriter.AddMobileAttribute(MobileAttribute.ID, this.ClientID);
                wmlWriter.AddMobileAttribute(MobileAttribute.Name, this.UniqueID);
                wmlWriter.AddMobileAttribute(MobileAttribute.Value,Text);
                wmlWriter.AddMobileAttribute(MobileAttribute.Type, this.Type.ToString().ToLower());
                wmlWriter.AddMobileAttribute(MobileAttribute.EmptyOk, EmptyOk.ToString().ToLower());
                if (!String.IsNullOrEmpty(Format))
                {
                    wmlWriter.AddMobileAttribute(MobileAttribute.Format, Format);
                }
                if (!String.IsNullOrEmpty(Title))
                {
                    //中文会自动编码
                    wmlWriter.AddMobileAttribute(MobileAttribute.Title, Title);
                }
                wmlWriter.RenderWmlBeginTag(MobileTag.Input);
                wmlWriter.RenderEndTag();
            }
        }

        #region IPostBackDataHandler 成员

        /// <summary>
        /// 处理回传数据
        /// </summary>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {            
            string text = this.Text;
            //取得回传数据
            string text2 = postCollection[postDataKey];
            if (!text.Equals(text2, StringComparison.Ordinal))
            {
                //如果回传的数据有变，则更新属性
                //并返回true，这样就会调用RaisePostDataChangedEvent()
                this.Text = text2;
                return true;
            }
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
            //触发TextChanged事件
            OnTextChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
