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
    /// ��Ӧ����<input/>Ԫ��,
    /// ʵ��IPostBackDataHandler֧�����ݻش�
    /// </summary>
    [ParseChildren(true,"Text")]//input��������Ԫ��
    public class Input:FormFiledControl,IFields,IPostBackDataHandler
    {
        #region TextChanged�¼�

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
                //�������ԣ����Ľ��Զ�����
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
                    //���Ļ��Զ�����
                    wmlWriter.AddMobileAttribute(MobileAttribute.Title, Title);
                }
                wmlWriter.RenderWmlBeginTag(MobileTag.Input);
                wmlWriter.RenderEndTag();
            }
        }

        #region IPostBackDataHandler ��Ա

        /// <summary>
        /// ����ش�����
        /// </summary>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {            
            string text = this.Text;
            //ȡ�ûش�����
            string text2 = postCollection[postDataKey];
            if (!text.Equals(text2, StringComparison.Ordinal))
            {
                //����ش��������б䣬���������
                //������true�������ͻ����RaisePostDataChangedEvent()
                this.Text = text2;
                return true;
            }
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
            //����TextChanged�¼�
            OnTextChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
