using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.SharePoint.Common.ServiceLocation;

namespace MVC.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("e6ed5bed-eaf4-455a-bc2a-ee0269bb376d")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        //public override void FeatureActivated(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            IServiceLocator serviceLocator = SharePointServiceLocator.GetCurrent();
            IServiceLocatorConfig serviceLocatorConfig = serviceLocator.GetInstance<IServiceLocatorConfig>();
            serviceLocatorConfig.RegisterTypeMapping<IListsService, ListsService>();
        }


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
            IServiceLocator serviceLocator = SharePointServiceLocator.GetCurrent();
            IServiceLocatorConfig serviceLocatorConfig = serviceLocator.GetInstance<IServiceLocatorConfig>();
            serviceLocatorConfig.RemoveTypeMappings<IListsService>();
        }

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
