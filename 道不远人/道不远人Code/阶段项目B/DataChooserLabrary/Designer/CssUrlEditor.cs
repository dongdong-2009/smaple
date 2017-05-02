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
                return "ѡ��Css";
            }
        }

        protected override string Filter
        {
            get
            {
                return "CSS�ļ�(*.css)|*.css|�����ļ�(*.*)|*.*";
            }
        }
    }
}
