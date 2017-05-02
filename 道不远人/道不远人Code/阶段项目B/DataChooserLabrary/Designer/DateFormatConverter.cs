using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DateChooserLibrary.Designer
{
    public class DateFormatConverter : BaseConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] values = { "d","D","yyyy-MM-dd","yyyy/MM/dd","yyyyƒÍMM‘¬dd»’"};
            return new StandardValuesCollection(values);
        }
    }
}
