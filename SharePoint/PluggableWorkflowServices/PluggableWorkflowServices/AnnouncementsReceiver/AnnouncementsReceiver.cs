using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace PluggableWorkflowServices.AnnouncementsReceiver
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class AnnouncementsReceiver : SPItemEventReceiver
    {
       public override void ItemAdded(SPItemEventProperties properties)
       {
           base.ItemAdded(properties);

           if (properties.ListTitle == "Announcements")
           {
               Guid instance = new Guid(properties.ListItem["Instance"].ToString());
               string answer = "Hello Workflow!";
               SPWorkflowExternalDataExchangeService.RaiseEvent(properties.Web, instance, typeof(IHelloWorldService), "HelloWorkflow", new object[] { answer });
           }
       }
    }
}
