using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel;
using Microsoft.SharePoint;
using System.ComponentModel;
using Microsoft.SharePoint.WorkflowActions;
using System.Workflow.ComponentModel.Compiler;

namespace CustomActivities.Workflow1
{
    [ActivityValidator(typeof(UrlValidator))]
    [ToolboxItem(typeof(CreateSubSiteToolboxItem))]
    public class CreateSubSite : Activity
    {
        public enum SiteTemplates
        {
            BLOG,
            MPS,
            STS,
            WIKI
        };


        public static DependencyProperty SiteNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("SiteName", typeof(string), typeof(CreateSubSite));
        public static DependencyProperty SiteUrlProperty = System.Workflow.ComponentModel.DependencyProperty.Register("SiteUrl", typeof(string), typeof(CreateSubSite));
        public static DependencyProperty SiteTemplateProperty = System.Workflow.ComponentModel.DependencyProperty.Register("SiteTemplate", typeof(SiteTemplates), typeof(CreateSubSite));
        public static DependencyProperty __ContextProperty = System.Workflow.ComponentModel.DependencyProperty.Register("__Context", typeof(WorkflowContext), typeof(CreateSubSite));
        [Description("Enter a name for the new site")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string SiteName
        {
            get
            {
                return ((string)(base.GetValue(CreateSubSite.SiteNameProperty)));
            }
            set
            {
                base.SetValue(CreateSubSite.SiteNameProperty, value);
            }
        }
        [Description("Enter a relative URL for the new site")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string SiteUrl
        {
            get
            {
                return ((string)(base.GetValue(CreateSubSite.SiteUrlProperty)));
            }
            set
            {
                base.SetValue(CreateSubSite.SiteUrlProperty, value);
            }
        }

        [Description("Specify the site template that will be used.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public SiteTemplates SiteTemplate
        {
            get
            {
                return ((SiteTemplates)(base.GetValue(
                CreateSubSite.SiteTemplateProperty)));
            }
            set
            {
                base.SetValue(CreateSubSite.SiteTemplateProperty, value);
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public WorkflowContext __Context
        {
            get
            {
                return ((WorkflowContext)(base.GetValue(
                CreateSubSite.__ContextProperty)));
            }
            set
            {
                base.SetValue(CreateSubSite.__ContextProperty, value);
            }
        }

        public class UrlAlreadyInUseException : Exception
        {
            public UrlAlreadyInUseException()
            {

            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(__Context.Site.ID))
                {
                    using (SPWeb web = site.AllWebs[__Context.Web.ID])
                    {
                        if (web.Webs.Names.Contains(SiteUrl))
                        {
                            throw new UrlAlreadyInUseException();
                        }
                        else
                        {
                            web.Webs.Add(
                            SiteUrl,
                            SiteName,
                            "desc.",
                            1033,
                            SiteTemplate.ToString(),
                            false,
                            false);
                        }
                    }
                }
            });
            return ActivityExecutionStatus.Closed;
        }
    }
}
