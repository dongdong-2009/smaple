using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using System.Workflow.Runtime;

namespace PluggableWorkflowServices
{
    [ExternalDataExchange]
    public interface IHelloWorldService
    {
        event EventHandler<HelloWorldEventArgs> HelloWorkflow;
        void HelloHost(string message);
    }

    public class HelloWorldService : Microsoft.SharePoint.Workflow.SPWorkflowExternalDataExchangeService, IHelloWorldService
    {
        public void HelloHost(string message)
        {
            SPWeb web = this.CurrentWorkflow.ParentWeb;
            SPList list = web.Lists["Announcements"];
            SPListItem item = list.Items.Add();
            item["Title"] = message;
            item["Instance"] = WorkflowEnvironment.WorkflowInstanceId.ToString();
            item.Update();
        }

        public event EventHandler<HelloWorldEventArgs> HelloWorkflow;

        public override void CallEventHandler(Type eventType, string eventName, object[] eventData, SPWorkflow workflow, string identity, IPendingWork workHandler, object workItem)
        {
            switch (eventName)
            {
                case "HelloWorkflow":
                var args = new HelloWorldEventArgs(workflow.InstanceId);
                args.Answer = eventData[0].ToString();
                //this.HelloWorkflow(null, args);                 
                break;
            }        
        }

        public override void CreateSubscription(MessageEventSubscription subscription)
        {
            throw new NotImplementedException();
        }

        public override void DeleteSubscription(Guid subscriptionId)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class HelloWorldEventArgs : ExternalDataEventArgs
    {
        public HelloWorldEventArgs(Guid id) : base(id) { }
        public string Answer;
    }
}
