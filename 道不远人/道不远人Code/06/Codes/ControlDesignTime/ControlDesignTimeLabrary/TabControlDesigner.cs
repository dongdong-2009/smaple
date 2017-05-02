using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.ComponentModel.Design;
using System.Drawing;
using System.ComponentModel;

namespace ControlDesignTimeLabrary
{
    public class TabControlDesigner:ControlDesigner
    {
        TabControl _control;

        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            _control = component as TabControl;
        }

        public override bool AllowResize
        {
            get
            {
                return true;
            }
        }

        #region DesignerRegion

        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            if (e.Region == null)
            {
                return;
            }
            if (!e.Region.Name.StartsWith("tab"))
            {
                return;
            }

            int selectedIndex = int.Parse(e.Region.Name.Substring(3));
            if (selectedIndex != _control.SelectedTabIndex)
            {
                _control.SelectedTabIndex = selectedIndex;
                UpdateDesignTimeHtml();
            }
        }

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {            
            if (_control.Controls.Count < 1)
            {
                return GetEmptyDesignTimeHtml();
            }

            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

            TabControl contorl = ViewControl as TabControl;
            if (contorl.ControlStyleCreated)
                contorl.ControlStyle.AddAttributesToRender(htmlWriter);
            htmlWriter.AddStyleAttribute("border", "solid 1px blue");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);

            htmlWriter.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "activecaption");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);
            for (int i = 0; i < contorl.Controls.Count; i++)
            {
                TabPage tab = contorl.Controls[i] as TabPage;

                DesignerRegion region = new DesignerRegion(this, "tab" + i.ToString());
                region.DisplayName = tab.Title;
                regions.Add(region);

                if (i == contorl.SelectedTabIndex)
                {
                    //htmlWriter.AddStyleAttribute("border-bottom", "none");
                    region.Highlight = true;
                }
                else
                {
                    htmlWriter.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "navy");
                    htmlWriter.AddStyleAttribute(HtmlTextWriterStyle.Color, "white");
                }
                htmlWriter.AddStyleAttribute(HtmlTextWriterStyle.Margin, "4px");
                htmlWriter.AddStyleAttribute("border", "solid 1px blue");
                htmlWriter.AddAttribute(DesignerRegion.DesignerRegionAttributeName, i.ToString());
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Value, tab.Title);
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Input);
                htmlWriter.RenderEndTag();
            }
            htmlWriter.RenderEndTag();
            //htmlWriter.AddStyleAttribute("border", "solid 1px blue");
            htmlWriter.AddStyleAttribute(HtmlTextWriterStyle.Position, "relative");
            htmlWriter.AddStyleAttribute(HtmlTextWriterStyle.Top, "-6px");
            htmlWriter.AddAttribute(DesignerRegion.DesignerRegionAttributeName, contorl.Controls.Count.ToString());
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);

            EditableDesignerRegion editRegion = new EditableDesignerRegion(this, "edit" + contorl.SelectedTabIndex.ToString(), false);
            regions.Add(editRegion);
            htmlWriter.RenderEndTag();
            htmlWriter.RenderEndTag();
        
            return stringWriter.ToString();           
        }


        public override string GetDesignTimeHtml()
        {
            if (_control.Controls.Count < 1)
            {
                return GetEmptyDesignTimeHtml();
            }
            return base.GetDesignTimeHtml();
        }

        protected override string GetEmptyDesignTimeHtml()
        {
            return CreatePlaceHolderDesignTimeHtml("Please add TabPage");
        }

        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                int selectedIndex = int.Parse(region.Name.Substring(4));
                Control c = _control.Controls[selectedIndex];
                return ControlPersister.PersistControl(c, host);
            }
            return String.Empty;
        }

        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            if (content == null)
            {
                return;
            }

            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                int selectedIndex = int.Parse(region.Name.Substring(4));
                _control.Controls.RemoveAt(selectedIndex);
                _control.Controls.AddAt(selectedIndex, ControlParser.ParseControl(host, content));
            }
        }
        
        #endregion

        #region ActionList

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection lists = new DesignerActionListCollection();
                lists.AddRange(base.ActionLists);
                lists.Add(new TabControlActionList(Component));
                return lists;
            }
        }

        internal class TabControlActionList:DesignerActionList
        {
            DesignerActionItemCollection _items;

            public TabControlActionList(IComponent component)
                : base(component)
            {
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                if (_items == null)
                {
                    _items = new DesignerActionItemCollection();
                    _items.Add(new DesignerActionHeaderItem("选中选项页", "SelectedIndex"));
                    _items.Add(new DesignerActionPropertyItem("SelectedIndex", "输入", "SelectedIndex", "输入选中页"));
                    _items.Add(new DesignerActionPropertyItem("SelectedTabIndex", "选择", "SelectedIndex", "选择选中页"));
                    _items.Add(new DesignerActionHeaderItem("操作选项页", "Behavior"));
                    _items.Add(new DesignerActionMethodItem(this, "AddNewTab", "添加选项页","Behavior"));
                }
                return _items;
            }

            [TypeConverter(typeof(SelectedIndexConverter))]
            public int SelectedTabIndex
            {
                get
                {
                    return ((TabControl)Component).SelectedTabIndex;
                }
                set
                {
                    TypeDescriptor.GetProperties(Component)["SelectedTabIndex"].SetValue(Component, value);
                }
            }

            public int SelectedIndex
            {
                get
                {
                    return ((TabControl)Component).SelectedTabIndex;
                }
                set
                {
                    TypeDescriptor.GetProperties(Component)["SelectedTabIndex"].SetValue(Component, value);
                }

            }

            public void AddNewTab()
            {
                TransactedChangeCallback addNewCallback = new TransactedChangeCallback(DoAddNewTab);
                ControlDesigner.InvokeTransactedChange(Component, addNewCallback, "AddNewTab", "添加新的选项卡");
            }

            public bool DoAddNewTab(object args)
            {
                TabControl control = Component as TabControl;
                TabPage newPage = new TabPage();
                newPage.Title = "NewTab";
                newPage.ID = "Tab" + control.Controls.Count.ToString();
                control.Controls.Add(newPage);
                return true;
            }
        }

        #endregion
    }
}
