using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace SequentialWorkflow.Workflow1
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void WhileOne(object sender, ConditionalEventArgs e)
        {
            e.Result = true;

        }

        private void sendEmail1_MethodInvoking(object sender, EventArgs e)
        {
            //SPListItem wfItem = onWorkflowActivated1.WorkflowProperties.Item;
            //SPFieldUser assignedTo = (SPFieldUser)wfItem.Fields["Assigned To"];
            //SPFieldUserValue user = (SPFieldUserValue)assignedTo.GetFieldValue(wfItem["Assigned To"].ToString());
            //string assigneeEmail = user.User.Email;
            //sendEmailToAssignee.To = assigneeEmail;
            //sendEmailToAssignee.Subject = "New work order has been created.";
            //sendEmailToAssignee.Body = "Work order number " +onWorkflowActivated1.WorkflowProperties.Item.ID + " has just been created and assigned to you.";

            sendEmailToAssignee.To = "ming.zhou@hp.com";
            sendEmailToAssignee.Subject = "New work order has been created.";
            sendEmailToAssignee.Body = "Work order number " + onWorkflowActivated1.WorkflowProperties.Item.ID + " has just been created and assigned to you.";
        }

        public Hashtable onWorkflowItemChanged1_AfterProperties1 = new System.Collections.Hashtable();
        public Hashtable onWorkflowItemChanged1_BeforeProperties1 = new System.Collections.Hashtable();

        //condition 1
        private void HasStatusChanged(object sender, ConditionalEventArgs e)
        {
            string aStatus = onWorkflowItemChanged1_AfterProperties1["Status"].ToString();
            if (onWorkflowItemChanged1_BeforeProperties1["Status"] == null)
            {
                e.Result = false;
                return;
            }
            string bStatus = onWorkflowItemChanged1_BeforeProperties1["Status"].ToString();
            if (bStatus == aStatus)
            {
                e.Result = true; //Not Update
            }
            else
            {
                e.Result = false;
            }
        }

        //condition 2
        private void IsStatusPendingCompletion(object sender, ConditionalEventArgs e)
        {
            string astatus =onWorkflowItemChanged1_AfterProperties1["Status"].ToString();
            if (astatus == "Pending Completed")
                e.Result = true;
            else
                e.Result = false;
        }

        //condition 3
        private void IsStatusOnHold(object sender, ConditionalEventArgs e)
        {
            string astatus =onWorkflowItemChanged1_AfterProperties1["Status"].ToString();
            if (astatus == "On Hold")
                e.Result = true;
            else
                e.Result = false;
        }

        //condition 4
        private void IsStatusCompleted(object sender, ConditionalEventArgs e)
        {
            string astatus =onWorkflowItemChanged1_AfterProperties1["Status"].ToString();
            if (astatus == "Completed")
                e.Result = true;
            else
                e.Result = false;
        }
    }
}
