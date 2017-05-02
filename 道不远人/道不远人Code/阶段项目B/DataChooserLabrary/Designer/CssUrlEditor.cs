using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design;

namespace DateChooserLibrary.Designer
{
    public class CssUrlEditor:System.Web.UI.Design.UrlEditor
    {
        protected override string Caption
        {
            get
            {
                return "选择Css";
            }
        }

        protected override string Filter
        {
            get
            {
                return "CSS文件(*.css)|*.css|所有文件(*.*)|*.*";
            }
        }
    }
}
