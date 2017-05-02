using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;

namespace DateChooserLibrary.Designer
{
    public class DateChooserDesigner:ControlDesigner
    {
        private bool _showPanel = false;

        internal bool ShowPanel
        {
            get { return _showPanel; }
            set { _showPanel = value; }
        }

        public override string GetDesignTimeHtml()
        {
            try
            {
                DateChooser control = Component as DateChooser;
                if (control != null)
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter sw = new StringWriter(sb);
                    HtmlTextWriter writer = new HtmlTextWriter(sw);
                    HtmlLink link = new HtmlLink();
                    link.Href = control.GetCssPath();
                    link.Attributes["type"] = "text/css";
                    link.Attributes["rel"] = "Stylesheet";
                    link.Attributes["rev"] = "Stylesheet";
                    link.RenderControl(writer);
                    control.AddAttributeToRender(writer, true);
                    control.RenderBeginTag(writer);
                    if (ShowPanel)
                        control.RenderContents(writer, true);
                    control.RenderEndTag(writer);
                    return sb.ToString();
                }
                return base.GetDesignTimeHtml();
            }
            catch (Exception ex)
            {
                return base.GetErrorDesignTimeHtml(ex);
            }
        }

        DesignerActionListCollection _actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionLists == null)
                {
                    _actionLists = new DesignerActionListCollection();
                    _actionLists.AddRange(base.ActionLists);
                    _actionLists.Add(new DateChooserActionList(this));
                }
                return _actionLists;
            }
        }
    }

    class DateChooserActionList : DesignerActionList
    {
        DateChooserDesigner _designer;
        public DateChooserActionList(DateChooserDesigner designer)
            : base(designer.Component)
        {
            _designer = designer;
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection list = new DesignerActionItemCollection();
            list.Add(new DesignerActionTextItem("查看选择面板", "ShowPanel"));
            list.Add(new DesignerActionPropertyItem("ShowPanel", "显示", "ShowPanel"));
            list.Add(new DesignerActionPropertyItem("SelectedDate", "选中日期", "Date"));
            list.Add(new DesignerActionPropertyItem("DateFormat", "日期格式", "Date"));
            list.Add(new DesignerActionPropertyItem("MaxDate", "最大日期", "Date"));
            list.Add(new DesignerActionPropertyItem("MinDate", "最小日期", "Date"));
            list.Add(new DesignerActionPropertyItem("ShowFx", "打开面板效果", "FX"));
            list.Add(new DesignerActionPropertyItem("HideFx", "关闭面板效果", "FX"));
            return list;
        }

        public bool ShowPanel
        {
            get
            {
                return _designer.ShowPanel;
            }
            set
            {
                _designer.ShowPanel = value;
                _designer.UpdateDesignTimeHtml();
            }
        }

        [TypeConverter(typeof(DateConverter))]
        public DateTime SelectedDate
        {
            get
            {
                return (Component as DateChooser).SelectedDate;
            }
            set
            {
                TypeDescriptor.GetProperties(Component)["SelectedDate"].SetValue(Component, value);
                _designer.UpdateDesignTimeHtml();
            }
        }

        [TypeConverter(typeof(DateFormatConverter))]
        public string DateFormat
        {
            get
            {
                return (Component as DateChooser).DateFormat;
            }
            set
            {
                TypeDescriptor.GetProperties(Component)["DateFormat"].SetValue(Component, value);
                _designer.UpdateDesignTimeHtml();
            }
        }

        [TypeConverter(typeof(DateConverter))]
        public DateTime MaxDate
        {
            get
            {
                return (Component as DateChooser).MaxDate;
            }
            set
            {
                TypeDescriptor.GetProperties(Component)["MaxDate"].SetValue(Component, value);
                _designer.UpdateDesignTimeHtml();
            }
        }

        [TypeConverter(typeof(DateConverter))]
        public DateTime MinDate
        {
            get
            {
                return (Component as DateChooser).MinDate;
            }
            set
            {
                TypeDescriptor.GetProperties(Component)["MinDate"].SetValue(Component, value);
                _designer.UpdateDesignTimeHtml();
            }
        }

        [TypeConverter(typeof(ShowFxConverter))]
        public string ShowFx
        {
            get
            {
                return (Component as DateChooser).ShowFx;
            }
            set
            {
                TypeDescriptor.GetProperties(Component)["ShowFx"].SetValue(Component, value);
                _designer.UpdateDesignTimeHtml();
            }
        }

        [TypeConverter(typeof(HideFxConverter))]
        public string HideFx
        {
            get
            {
                return (Component as DateChooser).HideFx;
            }
            set
            {
                TypeDescriptor.GetProperties(Component)["HideFx"].SetValue(Component, value);
                _designer.UpdateDesignTimeHtml();
            }
        }
    }
}
