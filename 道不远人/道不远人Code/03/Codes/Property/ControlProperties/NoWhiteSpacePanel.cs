using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ControlProperties
{
public class NoWhiteSpacePanel:Panel
{
    protected override void AddParsedSubObject(object obj)
    {
        LiteralControl ltl = obj as LiteralControl;
        if (ltl != null && (ltl.Text.Trim() == string.Empty))
            return;
        base.AddParsedSubObject(obj);
    }
}
}
