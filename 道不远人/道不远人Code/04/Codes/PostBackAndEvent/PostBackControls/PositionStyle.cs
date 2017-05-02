using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

namespace PostBackControls
{
    public enum PositionMode
    {
        Static,
        Absolute,
        Relative,
        Fixed
    }

    public class PositionStyle : Style
    {
        const int PROP_POSITION = 0x10000;
        const int PROP_TOP = 0x20000;
        const int PROP_RIGHT = 0x40000;
        const int PROP_BOTTOM = 0x80000;
        const int PROP_LEFT = 0x160000;

        public PositionStyle()
        {
        }

        public PositionStyle(StateBag bag)
            : base(bag)
        {
        }

        [
            Bindable(true),
            Category("Layout"),
            DefaultValue(PositionMode.Static),
            NotifyParentProperty(true),
            TypeConverter(typeof(EnumConverter))
        ]
        public virtual PositionMode Position
        {
            get
            {
                if (IsSet(PROP_POSITION))
                {
                    return (PositionMode)ViewState["PROP_POSITION"];
                }
                return PositionMode.Static;
            }
            set
            {
                ViewState["PROP_POSITION"] = value;
            }
        }

        [
           Bindable(true),
           Category("Layout"),
           DefaultValue(typeof(Unit),"0"),
           NotifyParentProperty(true),
           TypeConverter(typeof(UnitConverter))
        ]
        public virtual Unit Top
        {
            get
            {
                if (IsSet(PROP_TOP))
                {
                    return (Unit)ViewState["PROP_TOP"];
                }
                return 0;
            }
            set
            {
                ViewState["PROP_TOP"] = value;
            }
        }

        [
           Bindable(true),
           Category("Layout"),
           DefaultValue(typeof(Unit),"0"),
           NotifyParentProperty(true),
           TypeConverter(typeof(UnitConverter))
        ]
        public virtual Unit Left
        {
            get
            {
                if (IsSet(PROP_LEFT))
                {
                    return (Unit)ViewState["PROP_LEFT"];
                }
                return 0;
            }
            set
            {
                ViewState["PROP_LEFT"] = value;
            }
        }

        [
           Bindable(true),
           Category("Layout"),
           DefaultValue(typeof(Unit), "0"),
           NotifyParentProperty(true),
           TypeConverter(typeof(UnitConverter))
        ]
        public virtual Unit Right
        {
            get
            {
                if (IsSet(PROP_RIGHT))
                {
                    return (Unit)ViewState["PROP_RIGHT"];
                }
                return 0;
            }
            set
            {
                ViewState["PROP_RIGHT"] = value;
            }
        }

        [
           Bindable(true),
           Category("Layout"),
           DefaultValue(typeof(Unit), "0"),
           NotifyParentProperty(true),
           TypeConverter(typeof(UnitConverter))
        ]
        public virtual Unit Bottom
        {
            get
            {
                if (IsSet(PROP_BOTTOM))
                {
                    return (Unit)ViewState["PROP_BOTTOM"];
                }
                return 0;
            }
            set
            {
                ViewState["PROP_BOTTOM"] = value;
            }
        }

        protected new internal bool IsEmpty
        {
            get
            {
                return base.IsEmpty &&
                    !IsSet(PROP_POSITION) &&
                    !IsSet(PROP_BOTTOM) &&
                    !IsSet(PROP_RIGHT) &&
                    !IsSet(PROP_TOP) &&
                    !IsSet(PROP_LEFT);
            }
        }

        public override void AddAttributesToRender(HtmlTextWriter writer,
            WebControl owner)
        {
            base.AddAttributesToRender(writer, owner);

            if (IsSet(PROP_POSITION))
            {
                string position = new EnumConverter(typeof(PositionMode)).ConvertToInvariantString(Position);
                writer.AddStyleAttribute(HtmlTextWriterStyle.Position, position);
            }

            if (IsSet(PROP_LEFT))
            {
                string left = TypeDescriptor.GetConverter(typeof(Unit)).ConvertToInvariantString(Left);
                writer.AddStyleAttribute(HtmlTextWriterStyle.Left, left);
            }

            if (IsSet(PROP_TOP))
            {
                string top = TypeDescriptor.GetConverter(typeof(Unit)).ConvertToInvariantString(Top);
                writer.AddStyleAttribute(HtmlTextWriterStyle.Top, top);
            }

            if (IsSet(PROP_BOTTOM))
            {
                string bottom = TypeDescriptor.GetConverter(typeof(Unit)).ConvertToInvariantString(Bottom);
                writer.AddStyleAttribute("bottom", bottom);
            }

            if (IsSet(PROP_RIGHT))
            {
                string right = TypeDescriptor.GetConverter(typeof(Unit)).ConvertToInvariantString(Right);
                writer.AddStyleAttribute("right",right);
            }
        }

        public override void CopyFrom(Style s)
        {
            if (s != null)
            {
                base.CopyFrom(s);

                if (s is PositionStyle)
                {
                    PositionStyle mps = (PositionStyle)s;

                    if (!mps.IsEmpty)
                    {
                        if (mps.IsSet(PROP_BOTTOM))
                            Bottom = mps.Bottom;
                        if (mps.IsSet(PROP_LEFT))
                            Left = mps.Left;
                        if (mps.IsSet(PROP_POSITION))
                            Position = mps.Position;
                        if (mps.IsSet(PROP_RIGHT))
                            Right = mps.Right;
                        if (mps.IsSet(PROP_TOP))
                            Top = mps.Top;
                    }
                }
            }
        }

        internal bool IsSet(int propNumber)
        {
            string key = null;
            switch (propNumber)
            {
                case PROP_BOTTOM:
                    key = "PROP_BOTTOM";
                    break;
                case PROP_LEFT:
                    key = "PROP_LEFT";
                    break;
                case PROP_POSITION:
                    key = "PROP_POSITION";
                    break;
                case PROP_RIGHT:
                    key = "PROP_RIGHT";
                    break;
                case PROP_TOP:
                    key = "PROP_TOP";
                    break;
            }

            if (key != null)
            {
                return ViewState[key] != null;
            }
            return false;
        }

        public override void MergeWith(Style s)
        {
            if (s != null)
            {
                if (IsEmpty)
                {
                    CopyFrom(s);
                    return;
                }

                base.MergeWith(s);

                if (s is PositionStyle)
                {
                    PositionStyle mps = (PositionStyle)s;

                    if (!mps.IsEmpty)
                    {
                        if (mps.IsSet(PROP_TOP) &&
                            !this.IsSet(PROP_TOP))
                            this.Top = mps.Top;
                        if (mps.IsSet(PROP_RIGHT) &&
                            !this.IsSet(PROP_RIGHT))
                            this.Right = mps.Right;
                        if (mps.IsSet(PROP_POSITION) &&
                            !this.IsSet(PROP_POSITION))
                            this.Position = mps.Position;
                        if (mps.IsSet(PROP_LEFT) &&
                            !this.IsSet(PROP_LEFT))
                            this.Left = mps.Left;
                        if (mps.IsSet(PROP_BOTTOM) &&
                            !this.IsSet(PROP_BOTTOM))
                            this.Bottom = mps.Bottom;
                    }
                }
            }
        }

        public override void Reset()
        {
            base.Reset();
            if (IsEmpty)
            {
                return;
            }

            if (IsSet(PROP_BOTTOM))
                ViewState.Remove("PROP_BOTTOM");
            if (IsSet(PROP_LEFT))
                ViewState.Remove("PROP_LEFT");
            if (IsSet(PROP_POSITION))
                ViewState.Remove("PROP_POSITION");
            if (IsSet(PROP_RIGHT))
                ViewState.Remove("PROP_RIGHT");
            if (IsSet(PROP_TOP))
                ViewState.Remove("PROP_TOP");
        }
    }
}
