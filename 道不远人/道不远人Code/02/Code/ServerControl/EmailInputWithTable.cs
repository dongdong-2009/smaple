using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControl
{
    [ToolboxData("<{0}:EmailInputWithTable runat=server></{0}:EmailInputWithTable>")]
    public class EmailInputWithTable : EmailInput
    {
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Table;
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            writer.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            writer.AddAttribute(HtmlTextWriterAttribute.Width, "80px");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write("Email:");
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _input.RenderControl(writer);
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _rqrValidatator.RenderControl(writer);
            _regValidator.RenderControl(writer);
            writer.RenderEndTag();

            writer.RenderEndTag();
        }
    }
}
