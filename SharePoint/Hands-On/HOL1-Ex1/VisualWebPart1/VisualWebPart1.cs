using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.Utilities;
using System.Threading;

namespace HOL1_Ex1.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public class VisualWebPart1 : System.Web.UI.WebControls.WebParts.WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/HOL1_Ex1/VisualWebPart1/VisualWebPart1UserControl.ascx";

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
        System.Web.UI.WebControls.WebParts.WebDisplayName("Custom Prop"),
        System.Web.UI.WebControls.WebParts.Personalizable(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared)]  
        [SPWebCategoryName("Feed Properties")]
        public string Text 
        {
            get;
            set; 
        }

        protected override void CreateChildControls()
        {
            VisualWebPart1UserControl control = Page.LoadControl(_ascxPath) as VisualWebPart1UserControl;
            Controls.Add(control);

            control.LabelText = this.Text;

            //using (SPMonitoredScope scope =new SPMonitoredScope("CreateChildControls"))
            //{
            //    SlowMethod();
            //    FastMethod();
            //}
            
        }       

        private void SlowMethod()
        {
            using (SPMonitoredScope scope =
            new SPMonitoredScope("SlowMethod"))
            {
                System.Threading.Thread.SpinWait(1);
            }
        }
        private void FastMethod()
        {
            using (SPMonitoredScope scope =
            new SPMonitoredScope("FastMethod"))
            {
                System.Threading.Thread.SpinWait(1);
            }
        }

    }
}
