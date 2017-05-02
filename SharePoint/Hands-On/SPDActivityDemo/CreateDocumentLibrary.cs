using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace SPDActivityDemo
{
    public partial class CreateDocumentLibrary : Activity
    {
        public static DependencyProperty UrlProperty = DependencyProperty.Register("Url", typeof(string), typeof(CreateDocumentLibrary), new PropertyMetadata(""));
        [DescriptionAttribute("Url of base site")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        public string Url { get { return ((string)(base.GetValue(CreateDocumentLibrary.UrlProperty))); } set { base.SetValue(CreateDocumentLibrary.UrlProperty, value); } }

        public static DependencyProperty DocLibNameProperty = DependencyProperty.Register("DocLibName", typeof(string), typeof(CreateDocumentLibrary), new PropertyMetadata(""));
        [DescriptionAttribute("Used as doc lib name")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        public string DocLibName { get { return ((string)(base.GetValue(CreateDocumentLibrary.DocLibNameProperty))); } set { base.SetValue(CreateDocumentLibrary.DocLibNameProperty, value); } }

        public CreateDocumentLibrary()
        {
            InitializeComponent();
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext) 
        { 
            CreateDocLib(); 
            return ActivityExecutionStatus.Closed; 
        }
        private void CreateDocLib()
        {
            using (SPSite sps = new SPSite(Url))
            {
                using (SPWeb spw = sps.RootWeb)
                {
                    Guid ID = spw.Lists.Add(DocLibName, DocLibName + " Document Library", SPListTemplateType.DocumentLibrary);
                    SPList spdl = spw.Lists[ID];
                    spdl.OnQuickLaunch = true; spdl.Update();
                }
            }
        }

    }
}
