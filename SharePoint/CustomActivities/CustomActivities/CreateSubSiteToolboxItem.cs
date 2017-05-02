using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.Design;
using CustomActivities.Workflow1;

namespace CustomActivities
{
    [Serializable]
    internal class CreateSubSiteToolboxItem : ActivityToolboxItem
    {
        public CreateSubSiteToolboxItem(Type type): base(type)
        {
        }
        private CreateSubSiteToolboxItem(SerializationInfo serializeinfo, StreamingContext context)
        {
            this.Deserialize(serializeinfo, context);
            this.Description = "Creates sub site below context web.";
            this.Company = "SP WFs in Action";
            this.DisplayName = "Create Sub Site";
            //c:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\TEMPLATE\IMAGES\STSICON.gif
            this.Bitmap = new System.Drawing.Bitmap(CustomActivities.Properties.Resources.STSICON);
        }

        //set default values
        protected override IComponent[] CreateComponentsCore(IDesignerHost host)
        {
            CreateSubSite css = new CreateSubSite();
            css.SiteName = "Contoso Team Site";
            return new IComponent[]
                {
                css
                };
        }
    }
}
