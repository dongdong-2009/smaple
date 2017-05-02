using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace SPHOL302_Ex2.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("f9b9ca14-9a42-4438-ab48-06568c8b1fd3")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            //using (SPWeb spWeb = properties.Feature.Parent as SPWeb)
            //{
            //    SPContentType newAnnouncement = spWeb.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name == "New Announcements");
    
            //    if (newAnnouncement != null) 
            //    { 
            //        newAnnouncement.Delete(); 
            //    } 
            //    SPField newField = spWeb.Fields.Cast<SPField>().FirstOrDefault(f => f.StaticName == "Team Project"); 
            //    if (newField != null) 
            //    { 
            //        newField.Delete(); 
            //    } 
            //    SPContentType myContentType = new SPContentType(spWeb.ContentTypes["Announcement"], spWeb.ContentTypes, "New Announcements"); 
            //    myContentType.Group = "Custom Content Types"; 
            //    spWeb.Fields.Add("Team Project", SPFieldType.Text, true);
            //    SPFieldLink projFeldLink = new SPFieldLink(spWeb.Fields["Team Project"]); 
            //    myContentType.FieldLinks.Add(projFeldLink); 
            //    SPFieldLink companyFieldLink = new SPFieldLink(spWeb.Fields["Company"]); 
            //    myContentType.FieldLinks.Add(companyFieldLink); 
            //    spWeb.ContentTypes.Add(myContentType); 
            //    myContentType.Update();
            //}
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
