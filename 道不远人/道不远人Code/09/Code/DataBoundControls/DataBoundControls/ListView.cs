using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;

namespace DataBoundControls
{
    [Designer(typeof(ListViewDesigner))]
    public class ListView:CompositeDataBoundControl
    {
        #region Styles

        private Style _alternatingRowStyle;

        [Category("Styles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Style AlternatingRowStyle
        {
            get
            {
                if (_alternatingRowStyle == null)
                {
                    _alternatingRowStyle = new Style();
                    if (IsTrackingViewState)
                        ((IStateManager)_alternatingRowStyle).TrackViewState();
                }
                return _alternatingRowStyle;
            }
        }

        private Style _rowStyle;

        [Category("Styles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Style RowStyle
        {
            get
            {
                if (_rowStyle == null)
                {
                    _rowStyle = new Style();
                    if (IsTrackingViewState)
                        ((IStateManager)_rowStyle).TrackViewState();
                }
                return _rowStyle;
            }
        }

        #endregion

        #region ViewState

        protected override void LoadViewState(object savedState)
        {
            if (savedState == null)
                base.LoadViewState(savedState);
            else
            {
                object[] states = savedState as object[];
                if (states.Length != 3)
                {
                    throw new ArgumentException("无效的视图状态");
                }
                base.LoadViewState(states[0]);
                ((IStateManager)_alternatingRowStyle).LoadViewState(states[1]);
                ((IStateManager)_rowStyle).LoadViewState(states[2]);
            }
        }

        protected override object SaveViewState()
        {
            object[] states = new object[3];
            states[0] = base.SaveViewState();
            if (_alternatingRowStyle != null)
                states[1] = ((IStateManager)_alternatingRowStyle).SaveViewState();
            if (_rowStyle != null)
                states[2] = ((IStateManager)_rowStyle).SaveViewState();
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
            if (_rowStyle != null)
                ((IStateManager)_rowStyle).TrackViewState();
            if (_alternatingRowStyle != null)
                ((IStateManager)_alternatingRowStyle).TrackViewState();
        }

        #endregion



        private ITemplate _itemTemplate;

        [TemplateContainer(typeof(ListViewItem))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ITemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set { _itemTemplate = value; }
        }

        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            int index = 0;
            if (_itemTemplate != null)
            {
                Controls.Clear();
                foreach (object dataItem in dataSource)
                {
                    ListViewItem listViewItem = new ListViewItem(dataItem, index, index);
                    _itemTemplate.InstantiateIn(listViewItem);

                    if (index % 2 == 0)
                    {
                        if (RowStyle != null && !RowStyle.IsEmpty)
                        {
                            Style s = new Style();
                            s.CopyFrom(RowStyle);
                            listViewItem.ApplyStyle(s);
                        }
                    }
                    else
                    {
                        Style s = new Style();
                        if (AlternatingRowStyle != null)
                            s.CopyFrom(AlternatingRowStyle);
                        else if (RowStyle != null)
                            s.CopyFrom(RowStyle);
                        if(!s.IsEmpty)
                            listViewItem.ApplyStyle(s);
                    }
                    Controls.Add(listViewItem);
                    index++;
                }
                DataBind(false);
                ChildControlsCreated = true;
            }
            return index;
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Ul;
            }
        }
    }

    [ToolboxItem(false)]
    public class ListViewItem:WebControl,IDataItemContainer,INamingContainer
    {
        private object _dataItem;
        private int _index;
        private int _displayIndex;

        #region IDataItemContainer 成员

        public object DataItem
        {
            get {return _dataItem; }
        }

        public int DataItemIndex
        {
            get { return _index ; }
        }

        public int DisplayIndex
        {
            get { return _displayIndex; }
        }

        #endregion

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Li;
            }
        }

        public ListViewItem()
        {
        }

        public ListViewItem(object dataItem, int index,int displayIndex)
        {
            this._dataItem = dataItem;
            this._index = index;
            this._displayIndex = displayIndex;
        }
    }

    public class ListViewDesigner :DataBoundControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }

        public override string GetDesignTimeHtml()
        {
            ListView control = Component as ListView;
            if (control != null)
            {
                if (control.ItemTemplate == null)
                {
                    return CreatePlaceHolderDesignTimeHtml("Please edit ItemTemplate");
                }
            }
            return base.GetDesignTimeHtml();
        }

        TemplateGroupCollection _tempgc;
        public override TemplateGroupCollection TemplateGroups
        {
            get
            {
                if (_tempgc == null)
                {
                    _tempgc = base.TemplateGroups;
                    TemplateGroup templates = new TemplateGroup("ItemTemplate");
                    TemplateDefinition temp = new TemplateDefinition(this, "ItemTemplate",
                        Component, "ItemTemplate", false);
                    temp.SupportsDataBinding = true;
                    templates.AddTemplateDefinition(temp);
                    _tempgc.Add(templates);

                }
                return _tempgc;
            }
        }
    }
}
