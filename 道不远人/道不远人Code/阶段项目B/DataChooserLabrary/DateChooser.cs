using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using DateChooserLibrary.Designer;
using System.Drawing.Design;
using System.Web.UI.HtmlControls;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DateChooserLibrary
{
    [DesignerAttribute(typeof(DateChooserDesigner))]
    [ValidationProperty("SelectedDate")]
    [DefaultProperty("SelectedDate")]
    [DefaultEvent("SelectedDateChanged")]
    public class DateChooser:CompositeControl
    {
        TextBox _textBox;
        bool _supportJS = true;
        IFormatProvider _culture = new CultureInfo("zh-CN", true);

        const string PNGFix = @"
        <!--[if lt IE 7]>
         <style type=""text/css"">
          .calendar img { behavior: url({0}) }
         </style>
        <![endif]-->
                ";

        [Category("Action")]
        public event EventHandler SelectedDateChanged
        {
            add
            {
                EnsureChildControls();
                _textBox.TextChanged += value;
            }
            remove
            {
                EnsureChildControls();
                _textBox.TextChanged -= value;
            }
        }

        [Editor(typeof(DateTimeEditor),typeof(UITypeEditor))]
        [Category("Behavior")]
        [TypeConverter(typeof(DateConverter))]
        [Description("选中日期")]
        public DateTime SelectedDate
        {
            get
            {
                EnsureChildControls();
                if (_textBox.Text == string.Empty)
                {
                    return DateTime.MinValue;
                }

                Regex regDateFormat = new Regex(@"([ymd])\1{0,3}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                MatchCollection formatMatches = regDateFormat.Matches(DateFormat);
                Regex regDate = new Regex(@"\d+",RegexOptions.Compiled);
                MatchCollection dateMatches = regDate.Matches(this._textBox.Text);
                int year = 0;
                int month = 0;
                int day = 0;
                for(int i = 0 ; i < formatMatches.Count ; i++)
                {
                    Match match = formatMatches[i];
                    switch (match.Value[0])
                    {
                        case 'Y':
                        case 'y':
                            year = int.Parse(dateMatches[i].Value);
                            break;
                        case 'M':
                        case 'm':
                            month = int.Parse(dateMatches[i].Value);
                            break;
                        case 'D':
                        case 'd':
                            day = int.Parse(dateMatches[i].Value);
                            break;
                    }
                }
                return new DateTime(year, month, day);

                //return DateTime.ParseExact(_textBox.Text, DateFormat, _culture);
            }
            set
            {
                EnsureChildControls();
                _textBox.Text = value.ToString(DateFormat, _culture);
            }
        }

        [Category("Behavior")]
        public bool AutoPostBack
        {
            get
            {
                EnsureChildControls();
                return _textBox.AutoPostBack; 
            }
            set
            {
                EnsureChildControls();
                _textBox.AutoPostBack = value;
            }
        }

        [Category("Behavior")]
        [TypeConverter(typeof(DateFormatConverter))]
        [Description("日期格式")]
        public string DateFormat
        {
            get
            {
                if (ViewState["DateFormat"] == null)
                    return "yyyy/MM/dd";
                return (string)ViewState["DateFormat"];
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }

        [Category("Behavior")]
        [TypeConverter(typeof(DateConverter))]
        [Description("最大有效日期（含）")]
        public DateTime MaxDate
        {
            get
            {
                if(ViewState["MaxDate"] == null)
                    return DateTime.MaxValue;
                return (DateTime)ViewState["MaxDate"];
            }
            set
            {
                if(value > MinDate)
                    ViewState["MaxDate"] = value;
            }
        }
        [Category("Behavior")]
        [TypeConverter(typeof(DateConverter))]
        [Description("最小有效日期（含）")]
        public DateTime MinDate
        {
            get
            {
                if (ViewState["MinDate"] == null)
                    return DateTime.MinValue;
                return (DateTime)ViewState["MinDate"];
            }
            set
            {
                if (value < MaxDate)
                    ViewState["MinDate"] = value;
            }
        }

        [Category("Behavior")]
        [TypeConverter(typeof(ShowFxConverter))]
        [Description("显示选择面板时的特效")]
        public string ShowFx
        {
            get
            {
                if (ViewState["ShowFx"] == null)
                    return "None";
                return (string)ViewState["ShowFx"];
            }
            set
            {
                ViewState["ShowFx"] = value;
            }
        }
        [Category("Behavior")]
        [TypeConverter(typeof(HideFxConverter))]
        [Description("隐藏选择面板时的特效")]
        public string HideFx
        {
            get
            {
                if (ViewState["HideFx"] == null)
                    return "None";
                return (string)ViewState["HideFx"];
            }
            set
            {
                ViewState["HideFx"] = value;
            }
        }


        [UrlProperty("*.css")]
        [Category("Behavior")]
        [DefaultValue(CssFilePathConverter.EmbeddedCss)]
        //[TypeConverter(typeof(Designer.CssFilePathConverter))]
        [Editor(typeof(CssUrlEditor),typeof(UITypeEditor))]
        [Description("通过指定外部CSS文件定制控件的样式，同一页面中的所有DateChooser只能有相同样式")]
        public string CssFilePath
        {
            get
            {
                if (ViewState["CssFilePath"] == null)
                    return CssFilePathConverter.EmbeddedCss;
                else
                    return (string)ViewState["CssFilePath"];
            }
            set
            {
                ViewState["CssFilePath"] = value;
            }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            _textBox = new TextBox();
            _textBox.ID = "txtDate";
            _textBox.CssClass = "calendarInput";
            Controls.Add(_textBox);
            ChildControlsCreated = true;
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            EnsureID();
            if (!DesignMode)
            {
                if (Page.Request.Browser.EcmaScriptVersion.Major < 1
                    || Page.Request.Browser.W3CDomVersion.Major < 1)
                {
                    _supportJS = false;
                }
            }
            if (_supportJS)
            {
                RegisterCSSFile(this);
                RegisterJavascriptFile();
                RegisterJavascript();
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (_supportJS)
            {
                AddAttributesToRender(writer);
                RenderBeginTag(writer);
                RenderContents(writer);
                RenderEndTag(writer);
            }
            else
            {
                RenderChildren(writer);
            }
        }

        public bool RegisterCSSFile(DateChooser control)
        {
            if (!DesignMode)
            {
                string cssFile = control.CssFilePath;
                if (cssFile == CssFilePathConverter.EmbeddedCss)
                    cssFile = control.GetWebResourceCSSPath();
                return control.RegisterCSSFile(control.Page.Header, cssFile);
            }
            return false;
        }

        void RegisterJavascriptFile()
        {
            Page.ClientScript.RegisterClientScriptResource(typeof(DateChooser), "DateChooserLibrary.Javascript.Globalization.zh-CN.js");
            Page.ClientScript.RegisterClientScriptResource(typeof(DateChooser), "DateChooserLibrary.Javascript.TypeExtend.js");
            Page.ClientScript.RegisterClientScriptResource(typeof(DateChooser), "DateChooserLibrary.Javascript.jquery.js");
            Page.ClientScript.RegisterClientScriptResource(typeof(DateChooser), "DateChooserLibrary.Javascript.jquery.dimensions.js");            
            if (ShowFx != "None" || HideFx != "None")
            {
                Page.ClientScript.RegisterClientScriptResource(typeof(DateChooser), "DateChooserLibrary.Javascript.interface.js");
            }
            Page.ClientScript.RegisterClientScriptResource(typeof(DateChooser), "DateChooserLibrary.Javascript.DateChooser.js");
        }
        void RegisterJavascript()
        {
            string minDate = "null";
            if (MinDate > DateTime.MinValue)
            {
                minDate = string.Format("'{0}'",MinDate.ToString(DateFormat, _culture));
            }
            string maxDate = "null";
            if (MaxDate < DateTime.MaxValue)
            {
                maxDate = string.Format("'{0}'", MaxDate.ToString(DateFormat, _culture));
            }
            string showFx = GetFxString(ShowFx);
            string hideFx = GetFxString(HideFx);
            string script = string.Format(@"
            var dateChooser_{0};
                dateChooser_{0} = new DateChooser('{0}','dateChooser_{0}','{1}',{2},{3},'{4}','{5}');
                dateChooser_{0}.initiate();
            ", this.ClientID, this.DateFormat, minDate,
            maxDate, showFx, hideFx);
            Page.ClientScript.RegisterStartupScript(typeof(DateChooser), this.UniqueID, script, true);
        }
        string GetFxString(string fxString)
        {
            switch (fxString)
            {
                case "None":
                    return fxString;
                case "Fold":
                case "UnFold":
                    return fxString + "(500,30)";
                default:
                    return fxString + "(500)";
            }
        }
        bool RegisterCSSFile(HtmlHead head, string cssFile)
        {
            bool added = false;
            foreach (Control c in head.Controls)
            {
                HtmlLink link = c as HtmlLink;
                if (link != null)
                {
                    if (link.Href == cssFile)
                    {
                        added = true;
                        break;
                    }
                }
            }
            if (!added)
            {
                HtmlLink link = new HtmlLink();
                link.Href = cssFile;
                link.Attributes["type"] = "text/css";
                link.Attributes["rel"] = "Stylesheet";
                link.Attributes["rev"] = "Stylesheet";
                head.Controls.Add(link);
                string pngfix = PNGFix.Replace("{0}",
                    head.Page.ClientScript.GetWebResourceUrl(typeof(DateChooser),
                    "DateChooserLibrary.Javascript.iepngfix.htc"));
                LiteralControl literal = new LiteralControl(pngfix);
                head.Controls.Add(literal);
                added = true;
            }
            return added;
        }
        public string GetCssPath()
        {
            if (CssFilePath == CssFilePathConverter.EmbeddedCss)
                return GetWebResourceCSSPath();
            return CssFilePath;
        }
        string GetWebResourceCSSPath()
        {
            return Page.ClientScript.GetWebResourceUrl(typeof(DateChooser), "DateChooserLibrary.CSS.DateChooser.css");
        }

        public void AddAttributeToRender(HtmlTextWriter writer, bool isDesignTime)
        {
            AddAttributesToRender(writer);
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendar");
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(TagKey);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarInputView");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarDropDownButton");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            if (DesignMode)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Src, Page.ClientScript.GetWebResourceUrl(typeof(DateChooser),
                    "DateChooserLibrary.Images.edit_0.gif"));
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();
            writer.RenderEndTag();
            RenderChildren(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarAddButton");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            if (DesignMode)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Src,Page.ClientScript.GetWebResourceUrl(typeof(DateChooser),
                    "DateChooserLibrary.Images.edit_1.gif"));
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarReduceButton");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            if (DesignMode)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Src, Page.ClientScript.GetWebResourceUrl(typeof(DateChooser),
                    "DateChooserLibrary.Images.edit_2.gif"));
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderEndTag();
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            EnsureChildControls();
            _textBox.RenderControl(writer);
        }

        public void RenderContents(HtmlTextWriter writer, bool isDesignTime)
        {
            RenderContents(writer);
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            DateTime showDate = (SelectedDate == DateTime.MinValue) ? DateTime.Today : SelectedDate; 

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarView");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarMonthView");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            if (DesignMode)
            {
                RenderNavigator(writer, showDate);
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarMonthTable");
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
            writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
            writer.RenderBeginTag(HtmlTextWriterTag.Table);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarMonthHearder");
            writer.RenderBeginTag(HtmlTextWriterTag.Thead);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarSunday");
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            if (DesignMode)
            {
                writer.Write("日");
            }
            writer.RenderEndTag();//calendarSunday
            string[] days = { "一","二","三","四","五"};
            for (int i = 0; i < 5; i++)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarDay");
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                if (DesignMode)
                {
                    writer.Write(days[i]);
                }
                writer.RenderEndTag();
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarSaturday");
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            if (DesignMode)
            {
                writer.Write("六");
            }
            writer.RenderEndTag();//calendarSaturday
            writer.RenderEndTag();//calendarMonthHearder
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarMonthDay");
            writer.RenderBeginTag(HtmlTextWriterTag.Tbody);

            
            if (DesignMode)
            {
                RenderMonthDay(writer,showDate);
            }
            writer.RenderEndTag();//calendarMonthDay
            writer.RenderEndTag();//calendarMonthTable
            writer.RenderEndTag();//calendarMonthView
            if (!DesignMode)
            {
                RenderYearView(writer);
                RenderNavigator(writer, showDate);
            }
            writer.RenderEndTag();//calendarView
        }

        void RenderYearView(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarYearView");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarYearTable");
            writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
            writer.RenderBeginTag(HtmlTextWriterTag.Table);
            writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
            writer.RenderEndTag();//tbody
            writer.RenderEndTag();//table
            writer.RenderEndTag();//div
        }

        void RenderNavigator(HtmlTextWriter writer,DateTime showDate)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarNavigator");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarPrev");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.AddAttribute(HtmlTextWriterAttribute.Src,
                Page.ClientScript.GetWebResourceUrl(typeof(DateChooser),
                "DateChooserLibrary.Images.bPrev.png"));
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();//img
            writer.RenderEndTag();//a
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarNext");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.AddAttribute(HtmlTextWriterAttribute.Src,
                Page.ClientScript.GetWebResourceUrl(typeof(DateChooser),
                "DateChooserLibrary.Images.bNext.png"));
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();//img
            writer.RenderEndTag();//a
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "calendarTitle");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            if (DesignMode)
            {
                writer.Write(showDate.ToString("yyyy MM"));
            }
            writer.RenderEndTag();//a
            writer.RenderEndTag();//div
        }

        void RenderMonthDay(HtmlTextWriter writer,DateTime showDate)
        {
            DateTime[] daysOfMonth = MonthDays(showDate);
            for (int i = 0; i < daysOfMonth.Length; i++)
            {
                DateTime day = daysOfMonth[i];
                bool isValid = day >= MinDate && day <= MaxDate;
                bool isSunday = day.DayOfWeek == DayOfWeek.Sunday;
                bool isSaturday = day.DayOfWeek == DayOfWeek.Saturday;
                if (isSunday)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                }
                string className = "calendarDay";
                if (day.Month != showDate.Month)
                {
                    className = " calendarOtherMonth";
                }                
                if (isSunday)
                    className = "calendarSunday";
                if (isSaturday)
                    className = "calendarSaturday";                
                if (!isValid)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
                    className += " calendarInvalid";
                }
                writer.AddAttribute(HtmlTextWriterAttribute.Class, className);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write(day.Day.ToString());
                writer.RenderEndTag();//td
                if (isSunday)
                {
                    writer.RenderEndTag();//tr
                }
            }
        }

        /// <summary>
        /// 取得月视图中的所有日期
        /// </summary>
        /// <param name="currentDay">所求月份</param>
        /// <returns>日期数组</returns>
        DateTime[] MonthDays(DateTime currentDay)
        {
            List<DateTime> days = new List<DateTime>();
            DateTime firstDay = new DateTime(currentDay.Year, currentDay.Month, 1);
            DateTime lastDay = firstDay.AddMonths(1);
            while (firstDay.DayOfWeek != DayOfWeek.Sunday)
            {
                firstDay = firstDay.AddDays(-1d);
            }
            for (int i = 0; firstDay < lastDay || (i % 7)!=0; i++)
            {
                days.Add(firstDay);
                firstDay = firstDay.AddDays(1d);
            }
            return days.ToArray();
        }

    }
}
