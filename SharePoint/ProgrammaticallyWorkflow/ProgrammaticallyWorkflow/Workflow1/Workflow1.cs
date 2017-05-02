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
using System.Xml.Serialization;
using System.Xml;


namespace ProgrammaticallyWorkflow.Workflow1
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            SPFile file = onWorkflowActivated1.WorkflowProperties.Item.File;
            XmlTextReader reader = new XmlTextReader(file.OpenBinaryStream());
            XmlSerializer serializer = new XmlSerializer(
            typeof(SPWFiAExpenseReport));
            SPWFiAExpenseReport fields = (SPWFiAExpenseReport)serializer.Deserialize(reader);
            double total = 0;
            foreach (Expense expense in fields.Expenses)
            {
                total += (double)expense.Amount;
            }
            file.Item["Total Again"] = total;
            file.Item.Update();
        }
    }
}
