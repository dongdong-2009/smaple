using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace DataBoundControls
{
    public class RequiredBoundField : BoundField
    {
        protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
        {
            bool isEdit = ((rowState & DataControlRowState.Edit) == DataControlRowState.Edit) & !ReadOnly;
            bool isEditOrInsert = isEdit
                || ((rowState & DataControlRowState.Insert) == DataControlRowState.Insert);
            if (isEditOrInsert)
            {
                TextBox txt = new TextBox();
                txt.ToolTip = HeaderText;
                txt.ID = "txt" + HeaderText;
                if (isEdit && !string.IsNullOrEmpty(DataField) && Visible)
                {
                    txt.DataBinding += new EventHandler(base.OnDataBindField);
                }
                cell.Controls.Add(txt);
                RequiredFieldValidator validator = new RequiredFieldValidator();
                validator.Text = "*";
                validator.ErrorMessage = HeaderText + " field required!";
                validator.ControlToValidate = txt.ID;
                cell.Controls.Add(validator);
            }
            else if (!string.IsNullOrEmpty(DataField) && Visible)
            {
                cell.DataBinding += new EventHandler(base.OnDataBindField);
            }

        }
    }
}
