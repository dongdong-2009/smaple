using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;
using System.Drawing;

namespace HOL1_Ex2.VerbWebPart
{
    [ToolboxItemAttribute(false)]
   public class WebPartWithVerbs : WebPart 
    {
        Label label;
        
        protected override void CreateChildControls()
        {
            label = new Label();
            label.BackColor = Color.LightBlue;
            label.Text = "Web Part Verbs";
            this.Controls.Add(label);
        }

        public override WebPartVerbCollection Verbs 
        {
            get 
            {
                List<WebPartVerb> verbs = new List<WebPartVerb>();
                WebPartVerb verb1 = new WebPartVerb("Change_Color",(sender, args) => 
                {
                    EnsureChildControls();
                    label.BackColor = label.BackColor == Color.LightBlue ? Color.LightYellow : Color.LightBlue;
                });
                verb1.Text = "Change color";
                verb1.Description = "Click here to change the background color";
                verbs.Add(verb1);

                WebPartVerb verb2 = new WebPartVerb("Client_Click","alert('You clicked me')');");
                verb2.Text = "Client script";
                verb2.Description = "Click here to show a popup window";
                verbs.Add(verb2);
                return new WebPartVerbCollection(verbs);
            }
        }
    }
}
