using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System.Collections.Specialized;
using System.Web.UI.Design;
using System.Web;
using System.Security.Permissions;

namespace DataBoundControls
{
    [Designer(typeof(EditableBookInfoDesigner))]
    public class EditableBookInfo:BookInfo
    {
        [DefaultValue(DetailsViewMode.ReadOnly),
        Category("Behavior")]
        public virtual DetailsViewMode Mode
        {
            get
            {
                if (ViewState["Mode"] == null)
                {
                    return DetailsViewMode.ReadOnly;
                }
                return (DetailsViewMode)ViewState["Mode"];
            }
            set
            {
                if (value == DetailsViewMode.ReadOnly 
                    || value == DetailsViewMode.Edit)
                {
                    ViewState["Mode"] = value;
                }
            }
        }

        ITemplate _editTemplate;

        [TemplateContainer(typeof(BookData),BindingDirection.TwoWay)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Browsable(false)]
        public virtual ITemplate EditTemplate
        {
            get
            {
                return _editTemplate;
            }
            set
            {
                _editTemplate = value;
                base.ChildControlsCreated = false;
            }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            //ClearChildState();
            if (Book != null)
            {
                Book.Controls.Clear();
            }
            
            if (Mode == DetailsViewMode.ReadOnly)
            {
                if (ItemTemplate != null)
                {
                    ItemTemplate.InstantiateIn(Book);
                    Controls.Add(Book);
                }
            }
            else
            {
                if (EditTemplate != null)
                {
                    EditTemplate.InstantiateIn(Book);
                    Controls.Add(Book);
                }
            }
            
            this.DataBind(false);
            ChildControlsCreated = true;
        }

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            if (args is CommandEventArgs)
            {
                CommandEventArgs cmdArg = args as CommandEventArgs;
                switch (cmdArg.CommandName.ToLower())
                {
                    case "edit":
                        Mode = DetailsViewMode.Edit;
                        ChildControlsCreated = false;
                        return true;
                    case "update":
                        BookInfoUpdateEventArgs biuargs = new BookInfoUpdateEventArgs();
                        biuargs.OldValues.Add("Author", Book.Author);
                        biuargs.OldValues.Add("ISBN", Book.ISBN);
                        biuargs.OldValues.Add("Title", Book.Title);
                        biuargs.OldValues.Add("Publisher", Book.Publisher);
                        biuargs.OldValues.Add("Description", Book.Description);

                        IOrderedDictionary results = (_editTemplate as IBindableTemplate).ExtractValues(Book);
                        if(results.Contains("Author"))
                        {
                            Book.Author = results["Author"].ToString();
                            biuargs.NewValues.Add("Author", Book.Author);
                        }
                        if(results.Contains("ISBN"))
                        {
                            Book.ISBN = results["ISBN"].ToString();
                            biuargs.NewValues.Add("ISBN", Book.ISBN);
                        }
                        if (results.Contains("Title"))
                        {
                            Book.Title = results["Title"].ToString();
                            biuargs.NewValues.Add("Title", Book.Title);
                        }
                        if (results.Contains("Publisher"))
                        {
                            Book.Publisher = results["Publisher"].ToString();
                            biuargs.NewValues.Add("Publisher", Book.Publisher);
                        }
                        if(results.Contains("Description"))
                        {
                            Book.Description = results["Description"].ToString();
                            biuargs.NewValues.Add("Description", Book.Description);
                        }
                        Mode = DetailsViewMode.ReadOnly;
                        ChildControlsCreated = false;
                        OnUpdate(biuargs);
                        return true;
                    case "cancel":
                        Mode = DetailsViewMode.ReadOnly;
                        ChildControlsCreated = false;
                        return true;
                    default :
                        return false;
                }
            }
            return base.OnBubbleEvent(source, args);
        }

        static readonly object _eventUpdate = new object();

        public event EventHandler<BookInfoUpdateEventArgs> Update
        {
            add
            {
                Events.AddHandler(_eventUpdate, value);
            }
            remove
            {
                Events.RemoveHandler(_eventUpdate, value);
            }
        }

        protected virtual void OnUpdate(BookInfoUpdateEventArgs args)
        {
            EventHandler<BookInfoUpdateEventArgs> updateHandler = (EventHandler<BookInfoUpdateEventArgs>)Events[_eventUpdate];
            if (updateHandler != null)
            {
                updateHandler(this, args);
            }
        }
    }

    public class BookInfoUpdateEventArgs : EventArgs
    {
        private NameValueCollection _oldValues = new NameValueCollection(5);
        public NameValueCollection OldValues
        {
            get { return _oldValues; }
            set { _oldValues = value; }
        }

        private NameValueCollection _newValues = new NameValueCollection(5);
        public NameValueCollection NewValues
        {
            get { return _newValues; }
            set { _newValues = value; }
        }
    }

    [SupportsPreviewControl(true)]
    public class EditableBookInfoDesigner : BookInfoDesigner
    {
        public override TemplateGroupCollection TemplateGroups
        {
            get
            {
                TemplateGroupCollection tempgc = new TemplateGroupCollection();

                TemplateGroup templates = new TemplateGroup("Templates");
                TemplateDefinition itemTemp = new TemplateDefinition(this, "ÏîÄ£°å",
                                Component, "ItemTemplate", false);
                itemTemp.SupportsDataBinding = true;
                templates.AddTemplateDefinition(itemTemp);

                TemplateDefinition editTemp = new TemplateDefinition(this, "±à¼­Ä£°å",
                    Component, "EditTemplate", false);
                editTemp.SupportsDataBinding = true;
                templates.AddTemplateDefinition(editTemp);
                tempgc.Add(templates);
                return tempgc;
            }
        }
    }
}
