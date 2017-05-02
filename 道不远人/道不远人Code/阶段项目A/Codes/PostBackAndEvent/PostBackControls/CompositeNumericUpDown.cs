using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;

namespace PostBackControls
{
    [DefaultProperty("Value"), DefaultEvent("Click")]
    public class CompositeNumericUpDown:CompositeControl,IPostBackEventHandler
    {
        TextBox _txt;
        LinkButton _lbtnUp;
        LinkButton _lbtnDown;

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

        protected virtual void OnClick(object sender,NumericArgs args)
        {
            Value += args.AddValue;
            if (Events[_click] != null)
            {
                (Events[_click] as EventHandler<NumericArgs>)(null, args);
            }
        }

        [Category("Action")]
        public event EventHandler TextChanged
        {
            add
            {
                EnsureChildControls();
                _txt.TextChanged += value;
            }
            remove
            {
                EnsureChildControls();
                _txt.TextChanged -= value;
            }
        }


        #endregion

        #region Properties

        [Category("Behavior")]
        [DefaultValue(0)]
        [Description("设置控件的当前值")]
        [TypeConverter(typeof(Int32Converter))]
        public int Value
        {
            get
            {
                EnsureChildControls();
                return int.Parse(this._txt.Text);
            }
            set
            {
                EnsureChildControls();
                this._txt.Text = value.ToString();
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

        #region Styles

        private PositionStyle _controlStyle;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public new PositionStyle ControlStyle
        {
            get 
            {
                if (_controlStyle == null)
                {
                    _controlStyle = CreateControlStyle() as PositionStyle;
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_controlStyle).TrackViewState();
                    }
                }
                return _controlStyle; 
            }
        }


        private PositionStyle _inputStyle;

        [Category("Style")]
        [Description("输入框的样式")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PositionStyle InputStyle
        {
            get 
            { 
                if(_inputStyle == null)
                {
                    _inputStyle = new PositionStyle();
                    _inputStyle.Height = new Unit(1d,UnitType.Em);
                    _inputStyle.Width = new Unit(80d);
                    _inputStyle.BorderWidth = new Unit(0d);
                    _inputStyle.Position = PositionMode.Absolute;
                    if(IsTrackingViewState)
                        ((IStateManager)_inputStyle).TrackViewState();
                }
                return _inputStyle; 
            }
        }

        private PositionStyle _upButtonStyle;

        [Category("Style")]
        [Description("增加按钮的样式")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PositionStyle UpButtonStyle
        {
            get 
            { 
                if(_upButtonStyle == null)
                {
                    _upButtonStyle = new PositionStyle();
                    _upButtonStyle.Height = new Unit(0.5d, UnitType.Em);
                    _upButtonStyle.BorderWidth = new Unit(1d);
                    _upButtonStyle.BorderColor = Color.Blue;
                    _upButtonStyle.BorderStyle = BorderStyle.Solid;
                    _upButtonStyle.Position = PositionMode.Absolute;
                    _upButtonStyle.Right = new Unit(0d);
                    if(IsTrackingViewState)
                        ((IStateManager)_upButtonStyle).TrackViewState();
                }
                return _upButtonStyle; 
            }
        }

        private PositionStyle _downButtonStyle;

        [Category("Style")]
        [Description("减少按钮的样式")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PositionStyle DownButtonStyle
        {
            get
            {
                if (_downButtonStyle == null)
                {
                    _downButtonStyle = new PositionStyle();
                    _downButtonStyle.Height = new Unit(0.5d, UnitType.Em);
                    _downButtonStyle.BorderWidth = new Unit(1d);
                    _downButtonStyle.BorderColor = Color.Blue;
                    _downButtonStyle.BorderStyle = BorderStyle.Solid;
                    _downButtonStyle.Position = PositionMode.Absolute;
                    _downButtonStyle.Right = new Unit(0d);
                    _downButtonStyle.Bottom = new Unit(0d);
                    if (IsTrackingViewState)
                        ((IStateManager)_downButtonStyle).TrackViewState();
                }
                return _downButtonStyle;
            }
        }
        protected override Style CreateControlStyle()
        {
            if (_controlStyle == null)
            {
                _controlStyle = new PositionStyle(ViewState);
                PositionStyle temp = new PositionStyle();
                temp.Height = new Unit(1.2d, UnitType.Em);
                temp.Width = new Unit(100d);
                temp.BorderColor = Color.Blue;
                temp.BorderStyle = BorderStyle.Solid;
                temp.BorderWidth = new Unit(1d);
                temp.Position = PositionMode.Relative;
                _controlStyle.MergeWith(temp);
            }
            return _controlStyle;
        }

        [Browsable(false), 
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), 
        EditorBrowsable(EditorBrowsableState.Advanced)]
        public new bool ControlStyleCreated
        {
            get
            {
                return _controlStyle != null;
            }
        }

        #endregion
        #endregion

        #region ViewState

        protected override void LoadViewState(object savedState)
        {
            if (savedState == null)
                base.LoadViewState(savedState);
            else
            {
                object[] states = savedState as object[];
                if (states.Length != 4)
                {
                    throw new ArgumentException("无效的视图状态");
                }
                base.LoadViewState(states[0]);
                ((IStateManager)_inputStyle).LoadViewState(states[1]);
                ((IStateManager)_upButtonStyle).LoadViewState(states[2]);
                ((IStateManager)_downButtonStyle).LoadViewState(states[3]);

            }
        }

        protected override object SaveViewState()
        {
            object[] states = new object[4];
            states[0] = base.SaveViewState();
            if (_inputStyle != null)
                states[1] = ((IStateManager)_inputStyle).SaveViewState();
            if (_upButtonStyle != null)
                states[2] = ((IStateManager)_upButtonStyle).SaveViewState();
            if (_downButtonStyle != null)
                states[3] = ((IStateManager)_downButtonStyle).SaveViewState();
            foreach (object state in states)
            {
                if (state != null)
                    return states;
            }
            return null;
        }

        protected override void TrackViewState()
        {
            base.TrackViewState();
            if (_inputStyle != null)
                ((IStateManager)_inputStyle).TrackViewState();
            if (_upButtonStyle != null)
                ((IStateManager)_upButtonStyle).TrackViewState();
            if (_downButtonStyle != null)
                ((IStateManager)_downButtonStyle).TrackViewState();
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

        #region Event bubble

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            if (args is CommandEventArgs)
            {
                NumericArgs narg = new NumericArgs((args as CommandEventArgs).CommandArgument.ToString());
                OnClick(this, narg);
                return true;
            }
            else
            {
                return base.OnBubbleEvent(source, args);
            }
        }

        #endregion

        #region render

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            ControlStyle.AddAttributesToRender(writer);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0px");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
        }


        protected override void CreateChildControls()
        {
            Controls.Clear();
            _txt = new TextBox();
            _txt.Text = "0";
            Controls.Add(_txt);
            _lbtnUp = new LinkButton();
            System.Web.UI.WebControls.Image imgUp = new System.Web.UI.WebControls.Image();
            imgUp.Attributes["Style"] = "border-width:0px;position:relative;top:-3px;";
            imgUp.ImageUrl = DesignMode ? "up.gif" : ResolveUrl("~/up.gif");
            _lbtnUp.Controls.Add(imgUp);
            _lbtnUp.CommandName = "Add";
            _lbtnUp.CommandArgument = Step.ToString();
            Controls.Add(_lbtnUp);
            _lbtnDown = new LinkButton();
            _lbtnDown.CommandName = "Reduce";
            _lbtnDown.CommandArgument = (Step * -1).ToString();
            System.Web.UI.WebControls.Image imgDown = new System.Web.UI.WebControls.Image();
            imgDown.Attributes["Style"] = "border-width:0px;position:relative;top:-3px;";
            imgDown.ImageUrl = DesignMode ? "down.gif" : ResolveUrl("~/down.gif");
            _lbtnDown.Controls.Add(imgDown);
            Controls.Add(_lbtnDown);

        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            InputStyle.AddAttributesToRender(writer);
            _txt.RenderControl(writer);
            UpButtonStyle.AddAttributesToRender(writer);
            _lbtnUp.RenderControl(writer);
            DownButtonStyle.AddAttributesToRender(writer);
            _lbtnDown.RenderControl(writer);
        }
        
        #endregion
    }
}
