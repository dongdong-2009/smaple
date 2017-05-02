using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControl
{
    [ToolboxData("<{0}:EmailInput runat=server></{0}:EmailInput>")]
    public class EmailInput : CompositeControl
    {
        protected RegularExpressionValidator _regValidator;
        protected RequiredFieldValidator _rqrValidatator;
        protected TextBox _input;
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        protected override void CreateChildControls()
        {
            Controls.Clear();
            _input = new TextBox();
            _input.ID = "txtEmail";

            _rqrValidatator = new RequiredFieldValidator();
            _rqrValidatator.ID = "rqvEmail";
            _rqrValidatator.ErrorMessage = "请输入邮件地址";
            _rqrValidatator.Text = "*";
            _rqrValidatator.Display = ValidatorDisplay.Dynamic;
            _rqrValidatator.ControlToValidate = _input.ID;

            _regValidator = new RegularExpressionValidator();
            _regValidator.ID = "revEmail";
            _regValidator.Display = ValidatorDisplay.Dynamic;
            _regValidator.ErrorMessage = "邮件格式错误";
            _regValidator.Text = "*";
            _regValidator.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            _regValidator.ControlToValidate = _input.ID;

            this.Controls.Add(_input);
            this.Controls.Add(_rqrValidatator);
            this.Controls.Add(_regValidator);

            ChildControlsCreated = true;
        }
    }
}
