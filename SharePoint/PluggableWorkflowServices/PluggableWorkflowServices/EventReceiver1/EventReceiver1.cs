using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace PluggableWorkflowServices.EventReceiver1
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EventReceiver1 : SPItemEventReceiver
    {
       /// <summary>
       /// An item was added.
       /// </summary>
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
