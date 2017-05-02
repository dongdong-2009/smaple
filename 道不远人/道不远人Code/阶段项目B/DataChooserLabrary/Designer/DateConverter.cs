using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace DateChooserLibrary.Designer
{
    public class DateConverter:DateTimeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if ((destinationType == typeof(string)) && (value is DateTime))
            {
                string format;
                DateTime time = (DateTime)value;
                if (culture == null)
                {
                    culture = CultureInfo.CurrentCulture;
                }
                DateTimeFormatInfo info = (DateTimeFormatInfo)culture.GetFormat(typeof(DateTimeFormatInfo));
                if (culture == CultureInfo.InvariantCulture)
                {
                    return time.ToString("yyyy-MM-dd", culture);                    
                }
                format = info.ShortDatePattern;
                
                return time.ToString(format, CultureInfo.CurrentCulture);
            }
            return base.ConvertTo(context, culture, value, destinationType);

        }
    }
}
