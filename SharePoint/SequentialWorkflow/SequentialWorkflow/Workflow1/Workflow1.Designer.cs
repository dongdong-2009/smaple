using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SequentialWorkflow.Workflow1
{
    public sealed partial class Workflow1
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition4 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition5 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            this.terminateActivity2 = new System.Workflow.ComponentModel.TerminateActivity();
            this.logWorkOrderComplete = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.logWorkOrderOnHold = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.sendEmailToAssignee = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.logWorkOrderAssigned = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.logStatusDidNotChange = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.ifCompleted = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifOnHold = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifPendingCompletion = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifStatusHasNotChanged = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.onWorkflowItemChanged1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowItemChanged();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.WhileNotCompleted = new System.Workflow.Activities.WhileActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // terminateActivity2
            // 
            this.terminateActivity2.Description = "terminate!!!! completed";
            this.terminateActivity2.Error = "Error!!!! completed";
            this.terminateActivity2.Name = "terminateActivity2";
            // 
            // logWorkOrderComplete
            // 
            this.logWorkOrderComplete.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logWorkOrderComplete.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logWorkOrderComplete.HistoryDescription = "The work is completed";
            this.logWorkOrderComplete.HistoryOutcome = "";
            this.logWorkOrderComplete.Name = "logWorkOrderComplete";
            this.logWorkOrderComplete.OtherData = "";
            this.logWorkOrderComplete.UserId = -1;
            // 
            // terminateActivity1
            // 
            this.terminateActivity1.Description = "terminate!!!!! on hold";
            this.terminateActivity1.Error = "Error!!!!! on hold";
            this.terminateActivity1.Name = "terminateActivity1";
            // 
            // logWorkOrderOnHold
            // 
            this.logWorkOrderOnHold.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logWorkOrderOnHold.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logWorkOrderOnHold.HistoryDescription = "The work is on hold.";
            this.logWorkOrderOnHold.HistoryOutcome = "";
            this.logWorkOrderOnHold.Name = "logWorkOrderOnHold";
            this.logWorkOrderOnHold.OtherData = "";
            this.logWorkOrderOnHold.UserId = -1;
            // 
            // sendEmailToAssignee
            // 
            this.sendEmailToAssignee.BCC = null;
            this.sendEmailToAssignee.Body = null;
            this.sendEmailToAssignee.CC = null;
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "Workflow1";
            this.sendEmailToAssignee.CorrelationToken = correlationtoken1;
            this.sendEmailToAssignee.From = null;
            this.sendEmailToAssignee.Headers = null;
            this.sendEmailToAssignee.IncludeStatus = false;
            this.sendEmailToAssignee.Name = "sendEmailToAssignee";
            this.sendEmailToAssignee.Subject = null;
            this.sendEmailToAssignee.To = null;
            this.sendEmailToAssignee.MethodInvoking += new System.EventHandler(this.sendEmail1_MethodInvoking);
            // 
            // logWorkOrderAssigned
            // 
            this.logWorkOrderAssigned.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logWorkOrderAssigned.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logWorkOrderAssigned.HistoryDescription = "Status changed to pending completed";
            this.logWorkOrderAssigned.HistoryOutcome = "";
            this.logWorkOrderAssigned.Name = "logWorkOrderAssigned";
            this.logWorkOrderAssigned.OtherData = "";
            this.logWorkOrderAssigned.UserId = -1;
            // 
            // logStatusDidNotChange
            // 
            this.logStatusDidNotChange.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logStatusDidNotChange.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logStatusDidNotChange.HistoryDescription = "The work order was updated, but the status did not change.";
            this.logStatusDidNotChange.HistoryOutcome = "";
            this.logStatusDidNotChange.Name = "logStatusDidNotChange";
            this.logStatusDidNotChange.OtherData = "";
            this.logStatusDidNotChange.UserId = -1;
            // 
            // ifCompleted
            // 
            this.ifCompleted.Activities.Add(this.logWorkOrderComplete);
            this.ifCompleted.Activities.Add(this.terminateActivity2);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IsStatusCompleted);
            this.ifCompleted.Condition = codecondition1;
            this.ifCompleted.Name = "ifCompleted";
            // 
            // ifOnHold
            // 
            this.ifOnHold.Activities.Add(this.logWorkOrderOnHold);
            this.ifOnHold.Activities.Add(this.terminateActivity1);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IsStatusOnHold);
            this.ifOnHold.Condition = codecondition2;
            this.ifOnHold.Name = "ifOnHold";
            // 
            // ifPendingCompletion
            // 
            this.ifPendingCompletion.Activities.Add(this.logWorkOrderAssigned);
            this.ifPendingCompletion.Activities.Add(this.sendEmailToAssignee);
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IsStatusPendingCompletion);
            this.ifPendingCompletion.Condition = codecondition3;
            this.ifPendingCompletion.Name = "ifPendingCompletion";
            // 
            // ifStatusHasNotChanged
            // 
            this.ifStatusHasNotChanged.Activities.Add(this.logStatusDidNotChange);
            codecondition4.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.HasStatusChanged);
            this.ifStatusHasNotChanged.Condition = codecondition4;
            this.ifStatusHasNotChanged.Name = "ifStatusHasNotChanged";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifStatusHasNotChanged);
            this.ifElseActivity1.Activities.Add(this.ifPendingCompletion);
            this.ifElseActivity1.Activities.Add(this.ifOnHold);
            this.ifElseActivity1.Activities.Add(this.ifCompleted);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // onWorkflowItemChanged1
            // 
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "onWorkflowItemChanged1_AfterProperties1";
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "onWorkflowItemChanged1_BeforeProperties1";
            this.onWorkflowItemChanged1.CorrelationToken = correlationtoken1;
            this.onWorkflowItemChanged1.Name = "onWorkflowItemChanged1";
            this.onWorkflowItemChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowItemChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.onWorkflowItemChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowItemChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.onWorkflowItemChanged1);
            this.sequenceActivity1.Activities.Add(this.ifElseActivity1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // WhileNotCompleted
            // 
            this.WhileNotCompleted.Activities.Add(this.sequenceActivity1);
            codecondition5.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.WhileOne);
            this.WhileNotCompleted.Condition = codecondition5;
            this.WhileNotCompleted.Name = "WhileNotCompleted";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken2.Name = "workflowToken";
            correlationtoken2.OwnerActivityName = "Workflow1";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken2;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.WhileNotCompleted);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logWorkOrderOnHold;

        private TerminateActivity terminateActivity1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logWorkOrderComplete;

        private TerminateActivity terminateActivity2;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowItemChanged onWorkflowItemChanged1;

        private SequenceActivity sequenceActivity1;

        private IfElseBranchActivity ifCompleted;

        private IfElseBranchActivity ifOnHold;

        private IfElseBranchActivity ifPendingCompletion;

        private IfElseBranchActivity ifStatusHasNotChanged;

        private IfElseActivity ifElseActivity1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logStatusDidNotChange;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logWorkOrderAssigned;

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmailToAssignee;

        private WhileActivity WhileNotCompleted;

































    }
}
