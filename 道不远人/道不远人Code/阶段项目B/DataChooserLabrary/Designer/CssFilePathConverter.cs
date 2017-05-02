using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DateChooserLibrary.Designer
{
    public class BaseConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }
    public class CssFilePathConverter : BaseConverter
    {
        public const string EmbeddedCss = "ÄÚ½¨Css";
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] values = { EmbeddedCss };
            return new StandardValuesCollection(values);
        }
    }
}
