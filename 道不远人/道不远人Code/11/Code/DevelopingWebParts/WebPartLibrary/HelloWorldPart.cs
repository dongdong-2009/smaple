using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;

namespace WebPartLibrary
{
    public class HelloWorldPart:WebPart
    {
        string _title = "This is a test part";
        public override string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        string _userName;

        [Personalizable(true)]
        [WebBrowsable(true)]
        [WebDisplayName("UserName")]
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }


        public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
        {
            writer.Write("Hello world,"+_userName);
        }
    }
}
