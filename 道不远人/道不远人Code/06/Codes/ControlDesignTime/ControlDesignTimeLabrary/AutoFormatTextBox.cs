using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Security.Permissions;

namespace ControlDesignTimeLabrary
{
    [Designer(typeof(AutoFormatTextBoxDesigner))]
    public class AutoFormatTextBox:TextBox
    {
    }

    [SupportsPreviewControl(true)]
    public class AutoFormatTextBoxDesigner : ControlDesigner
    {
        static DesignerAutoFormatCollection _autoFormats;
        public override DesignerAutoFormatCollection AutoFormats
        {
            get
            {
                if (_autoFormats == null)
                {
                    _autoFormats = new DesignerAutoFormatCollection();
                    _autoFormats.Add(new TextBoxFormat("MultiLine"));
                    _autoFormats.Add(new TextBoxFormat("Red"));
                    _autoFormats.Add(new TextBoxFormat("Default"));
                }
                return _autoFormats;
            }
        }

        class TextBoxFormat : DesignerAutoFormat
        {
            public TextBoxFormat(string name)
                : base(name)
            {
            }

            public override void Apply(System.Web.UI.Control control)
            {
                AutoFormatTextBox textbox = control as AutoFormatTextBox;
                if (textbox != null)
                {
                    switch (this.Name)
                    {
                        case "MultiLine":
                            textbox.TextMode = TextBoxMode.MultiLine;
                            textbox.BorderColor = Color.Empty;
                            textbox.ForeColor = Color.Empty;
                            textbox.Rows = 20;
                            textbox.Columns = 20;
                            break;
                        case "Red":
                            textbox.TextMode = TextBoxMode.SingleLine;
                            textbox.BorderColor = Color.Red;
                            textbox.BorderStyle = BorderStyle.Solid;
                            textbox.BorderWidth = new Unit(1);
                            textbox.ForeColor = Color.Red;
                            break;
                        default:
                            textbox.TextMode = TextBoxMode.SingleLine;
                            textbox.BorderColor = Color.Empty;
                            textbox.ForeColor = Color.Empty;
                            break;
                    }
                }
            }
        }
    }
}
