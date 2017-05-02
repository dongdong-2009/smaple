using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;

namespace DataBoundControls
{
    [Designer(typeof(BookInfoDesigner))]
    public class BookInfo:CompositeControl
    {
        BookData _book;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Data")]
        public virtual BookData Book
        {
            get 
            {
                if (_book == null)
                    _book = new BookData();
                return _book;
            }
            set 
            {
                _book = value;
            }
        }


        private ITemplate _itemTemplate;

        [Browsable(false)]
        [TemplateContainer(typeof(BookData))]
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
            if (_book == null)
                _book = new BookData();
            if (_itemTemplate != null)
            {
                _itemTemplate.InstantiateIn(_book);
                Controls.Add(_book);
            }
            ChildControlsCreated = true;
        }

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
