using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace PostBackControls
{
[ParseChildren(true),PersistChildren(false)]
[DefaultProperty("Value"),DefaultEvent("Click")]
public class NumericUpDown:Control,IPostBackEventHandler
{
    #region Event

    static object _click = new object();

    [Category("Action")]
    public event EventHandler<NumericArgs> Click
    {
        add
        {
            Events.AddHandler(_click, value);
        }
        remove
        {
            Events.RemoveHandler(_click, value);
        }
    }

    #endregion

    #region Properties

    [Category("Behavior")]
    [DefaultValue(0)]
    [Description("设置控件的当前值")]
    public int Value
    {
        get 
        {
            if (ViewState["Value"] == null)
                return 0;
            return (int)ViewState["Value"];
        }
        set 
        {
            ViewState["Value"] = value;
        }
    }

    [Category("Behavior")]
    [DefaultValue(1)]
    [Description("设置点击按钮时，控件值的步进幅度")]
    [TypeConverter(typeof(Int32Converter))]
    public int Step
    {
        get 
        {
            if (ViewState["Step"] == null)
            {
                return 1;
            }
            return (int)ViewState["Step"];
        }
        set 
        {
            ViewState["Step"] = value;
        }
    }

    #endregion

        #region IPostBackEventHandler 成员

        public void RaisePostBackEvent(string eventArgument)
        {
            NumericArgs args = new NumericArgs(eventArgument);
            Value += args.AddValue;
            if (Events[_click] != null)
            {
                (Events[_click] as EventHandler<NumericArgs>)(null, args);
            }
        }

        #endregion

        #region Render
        protected override void  Render(HtmlTextWriter writer)
        {
            //div
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "relative");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "1.2em");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "100px");
            writer.AddStyleAttribute("border", "solid 1px blue");
            writer.AddAttribute(HtmlTextWriterAttribute.Name,this.UniqueID);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.Indent++;
            //input
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "1em");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "80px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0 2px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "absolute");
            writer.AddStyleAttribute("border", "0px");
            writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Value.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
            //up
            string upRef = Page.ClientScript.GetPostBackClientHyperlink(this, Step.ToString());
            writer.AddAttribute(HtmlTextWriterAttribute.Href, upRef);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "absolute");
            writer.AddStyleAttribute("right", "0px");
            writer.AddStyleAttribute("border", "solid 1px blue");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "0.5em");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Indent++;
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, "0px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "relative");
            writer.AddStyleAttribute("top", "-3px");
            writer.AddAttribute(HtmlTextWriterAttribute.Src, DesignMode?"up.gif":ResolveUrl("~/up.gif"));
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag(); 
            writer.Indent--;
            writer.RenderEndTag();
            //down
            string downRef = Page.ClientScript.GetPostBackClientHyperlink(this, (Step*-1).ToString());
            writer.AddAttribute(HtmlTextWriterAttribute.Href, downRef);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "absolute");
            writer.AddStyleAttribute("right", "0px");
            writer.AddStyleAttribute("border", "solid 1px blue");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "0.5em");
            writer.AddStyleAttribute("bottom", "0px");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Indent++;
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, "0px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "relative");
            writer.AddStyleAttribute("top", "-3px");
            writer.AddAttribute(HtmlTextWriterAttribute.Src, DesignMode?"down.gif":ResolveUrl("~/down.gif"));
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();
            writer.Indent--;
            writer.RenderEndTag();
            writer.Indent--;
            writer.RenderEndTag();
        }

        #endregion
    }

    public class NumericArgs : EventArgs
    {
        static Regex _numReg = new Regex(@"^[\-\+]?\d+$", RegexOptions.Compiled);
        private int _addValue;

        public int AddValue
        {
            get { return _addValue; }
            set { _addValue = value; }
        }

        public NumericArgs(string args)
        {
            if (!_numReg.IsMatch(args))
                throw new ArgumentException("Plz pass numbers");
            AddValue = int.Parse(args, System.Globalization.NumberStyles.AllowLeadingSign);
        }
    }
}
