using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;

namespace ControlDesignTimeLabrary
{
    [Designer(typeof(MyTemplateControlDesigner)),
        ToolboxData("<{0}:MyTemplateControl runat=server></{0}:MyTemplateControl>")]
    public sealed class MyTemplateControl : WebControl, INamingContainer
    {
        private ITemplate[] _templates;

        public MyTemplateControl()
        {
            _templates = new ITemplate[4];
        }

        [Browsable(false),
            PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Template1
        {
            get { return _templates[0]; }
            set { _templates[0] = value; }
        }
        [Browsable(false),
            PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Template2
        {
            get { return _templates[1]; }
            set { _templates[1] = value; }
        }
        [Browsable(false),
            PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Template3
        {
            get { return _templates[2]; }
            set { _templates[2] = value; }
        }
        [Browsable(false),
            PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Template4
        {
            get { return _templates[3]; }
            set { _templates[3] = value; }
        }

        protected override void CreateChildControls()
        {
            for (int i = 0; i < 4; i++)
            {
                Panel pan = new Panel();
                _templates[i].InstantiateIn(pan);
                this.Controls.Add(pan);
            }
        }
    }

    public class MyTemplateControlDesigner : ControlDesigner
    {
        TemplateGroupCollection col = null;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }

        public override string GetDesignTimeHtml()
        {
            MyTemplateControl control = (MyTemplateControl)Component;
            string message = "Click here and use the task menu to edit the templates.";
            if (control.Template1 != null)
                message += "<br/>Template1 finished";
            if (control.Template2 != null)
                message += "<br/>Template2 finished";
            if (control.Template3 != null)
                message += "<br/>Template3 finished";
            if (control.Template4 != null)
                message += "<br/>Template4 finished";

            return CreatePlaceHolderDesignTimeHtml(message);
            
        }

        public override TemplateGroupCollection TemplateGroups
        {
            get
            {

                if (col == null)
                {
                    col = base.TemplateGroups;
                  
                    TemplateDefinition tempDef;
                    MyTemplateControl ctl = (MyTemplateControl)Component;

                    TemplateGroup tempGroup = new TemplateGroup("Template Set A");

                    tempDef = new TemplateDefinition(this, "Template A1", 
                        ctl, "Template1", true);

                    tempGroup.AddTemplateDefinition(tempDef);

                    tempDef = new TemplateDefinition(this, "Template A2", 
                        ctl, "Template2", true);

                    tempGroup.AddTemplateDefinition(tempDef);

                    col.Add(tempGroup);

                    tempGroup = new TemplateGroup("Template Set B");
                    tempDef = new TemplateDefinition(this, "Template B1", 
                        ctl, "Template3", true);
                    tempGroup.AddTemplateDefinition(tempDef);
                    tempDef = new TemplateDefinition(this, "Template B2", 
                        ctl, "Template4", true);
                    tempGroup.AddTemplateDefinition(tempDef);

                    col.Add(tempGroup);
                }

                return col;
            }
        }

        public override bool AllowResize
        {
            get
            {
                if (this.InTemplateMode)
                    return true;
                else
                    return false;
            }
        }
    }
}