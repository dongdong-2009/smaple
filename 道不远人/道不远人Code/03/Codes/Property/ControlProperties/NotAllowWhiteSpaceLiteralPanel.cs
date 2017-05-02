using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

namespace ControlProperties
{
    [ControlBuilder(typeof(NotAllowWhiteSpaceLiteralPanelBuilder))]
    public class NotAllowWhiteSpaceLiteralPanel:Panel
    {
    }
    
    public class NotAllowWhiteSpaceLiteralPanelBuilder : ControlBuilder
    {
        public override bool AllowWhitespaceLiterals()
        {
            return false;
        }
    }
}
