using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;

namespace TemplatedControls
{
    [Designer(typeof(BookInfoDesigner))]
    public class BookInfo:CompositeControl
    {


        BookData _dataItem;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Data")]
        public virtual BookData DataItem
        {
            get 
            {
                if (_dataItem == null)
                {
                    _dataItem = new BookData();
                    ((IStateManager)_dataItem).TrackViewState();
                }
                return _dataItem;
            }
            set 
            {
                _dataItem = value;
            }
        }


        private ITemplate _itemTemplate;

        [Browsable(false)]
        [TemplateContainer(typeof(BookInfo))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ITemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set 
            {
                _itemTemplate = value;
                base.ChildControlsCreated = false; 
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        protected override void CreateChildControls()
        {
            Controls.Clear();
            if (_itemTemplate != null)
                _itemTemplate.InstantiateIn(this);
            else
                base.CreateChildControls();
            ChildControlsCreated = true;
        }


        #region ViewState

        protected override object SaveViewState()
        {
            object[] states = new object[2];
            states[0] = base.SaveViewState();
            states[1] = ((IStateManager)DataItem).SaveViewState();
            return states;
        }

        protected override void LoadViewState(object savedState)
        {
            object[] states = (object[])savedState;
            base.LoadViewState(states[0]);
            ((IStateManager)DataItem).LoadViewState(states[1]);
        }

        protected override void TrackViewState()
        {
            base.TrackViewState();
            ((IStateManager)DataItem).TrackViewState();
        }

        #endregion
    }

    public class BookInfoDesigner : CompositeControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }

        public override string GetDesignTimeHtml()
        {
            BookInfo control = Component as BookInfo;
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
                    templates.AddTemplateDefinition(new TemplateDefinition(this, "ItemTemplate",
                    Component, "ItemTemplate",false));
                    _tempgc.Add(templates);

                }
                return _tempgc;
            }
        }
    }
}
