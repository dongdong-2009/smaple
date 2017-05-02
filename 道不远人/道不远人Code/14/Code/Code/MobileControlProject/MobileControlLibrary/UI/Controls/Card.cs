using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Web.UI.Design;

namespace MobileControlLibrary.UI.Controls
{
    public class Card:Panel
    {
        public string Title
        {
            get
            {
                return (string)ViewState["Title"];
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        protected override void AddParsedSubObject(object obj)
        {
            if (obj is Panel || obj is Button)
            {
                Controls.Add(obj as Control);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (DesignMode)
            {
                base.Render(writer);
            }
            else
            {
                WmlTextWriter wmlWriter = writer as WmlTextWriter;
                wmlWriter.AddMobileAttribute(MobileAttribute.ID, this.ClientID);
                wmlWriter.AddMobileAttribute(MobileAttribute.Name, this.UniqueID);
                if (!String.IsNullOrEmpty(Title))
                {
                    wmlWriter.AddMobileAttribute(MobileAttribute.Title, Title);
                }
                wmlWriter.RenderWmlBeginTag(MobileTag.Card);
                base.RenderChildren(writer);
                wmlWriter.RenderEndTag();
            }
        }
    }

}
