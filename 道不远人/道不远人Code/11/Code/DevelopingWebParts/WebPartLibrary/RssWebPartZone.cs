using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;

namespace WebPartLibrary
{
    public class RssWebPartZone:WebPartZone
    {
        private string _headerText = "Rss ืสิด";

        public override string HeaderText
        {
            get { return _headerText; }
            set { _headerText = value; }
        }

        protected override WebPartChrome CreateWebPartChrome()
        {
            return new RssWebPartChrome(this, WebPartManager);
        }
    }
}
