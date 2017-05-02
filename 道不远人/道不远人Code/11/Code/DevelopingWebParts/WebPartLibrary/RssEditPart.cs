using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.Design;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace WebPartLibrary
{
    public class RssEditorPart:EditorPart,INamingContainer
    {
        TextBox _txtMaxItems;
        TextBox _txtRssUrl;

        private string _title = "±‡º≠RssWebPart Ù–‘";

        public override string Title
        {
            get { return _title ; }
            set { _title  = value; }
        }
	

        protected override void CreateChildControls()
        {
            Controls.Clear();

            Label lbl = new Label();
            Controls.Add(lbl);
            _txtMaxItems = new TextBox();
            _txtMaxItems.ID = "txtMaxItems";
            Controls.Add(_txtMaxItems);
            lbl.AssociatedControlID = _txtMaxItems.ID;
            lbl.Text = "MaxItems:";
            RequiredFieldValidator reqValidator = new RequiredFieldValidator();
            reqValidator.ControlToValidate = _txtMaxItems.ID;
            reqValidator.Display = ValidatorDisplay.Dynamic;
            reqValidator.ErrorMessage = "*";
            Controls.Add(reqValidator);
            CompareValidator cprValidtor = new CompareValidator();
            cprValidtor.ControlToValidate = _txtMaxItems.ID;
            cprValidtor.Display = ValidatorDisplay.Dynamic;
            cprValidtor.ErrorMessage = "Must integer";
            cprValidtor.Operator = ValidationCompareOperator.DataTypeCheck;
            cprValidtor.Type = ValidationDataType.Integer;
            Controls.Add(cprValidtor);
            cprValidtor = new CompareValidator();
            cprValidtor.ControlToValidate = _txtMaxItems.ID;
            cprValidtor.Display = ValidatorDisplay.Dynamic;
            cprValidtor.ErrorMessage = "Must great than zero";
            cprValidtor.Operator = ValidationCompareOperator.GreaterThan;
            cprValidtor.Type = ValidationDataType.Integer;
            cprValidtor.ValueToCompare = "0";
            Controls.Add(cprValidtor);
            Literal ltl = new Literal();
            ltl.Text = "<br/>";
            Controls.Add(ltl);
            lbl = new Label();
            lbl.Text = "RssUrl:";
            Controls.Add(lbl);
            _txtRssUrl = new TextBox();
            _txtRssUrl.ID = "txtRssUrl";
            lbl.AssociatedControlID = _txtRssUrl.ID;
            Controls.Add(_txtRssUrl);
            reqValidator = new RequiredFieldValidator();
            reqValidator.ControlToValidate = _txtRssUrl.ID;
            reqValidator.Display = ValidatorDisplay.Dynamic;
            reqValidator.ErrorMessage = "*";
            Controls.Add(reqValidator);
            RegularExpressionValidator regValidator = new RegularExpressionValidator();
            regValidator.ControlToValidate = _txtRssUrl.ID;
            regValidator.ErrorMessage = "Url format error";
            regValidator.ValidationExpression = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Controls.Add(regValidator);
            
            ChildControlsCreated = true;
        }

        public override bool ApplyChanges()
        {
            bool success = false;
            EnsureChildControls();
            Page.Validate();
            if (Page.IsValid)
            {
                (WebPartToEdit as RssWebPart).MaxItems = int.Parse(_txtMaxItems.Text);
                (WebPartToEdit as RssWebPart).RssUrl = _txtRssUrl.Text;
                success = true;
            }
            return success;
        }

        public override void SyncChanges()
        {
            EnsureChildControls();
            _txtMaxItems.Text = (WebPartToEdit as RssWebPart).MaxItems.ToString();
            _txtRssUrl.Text = (WebPartToEdit as RssWebPart).RssUrl;
        }
    }
}
