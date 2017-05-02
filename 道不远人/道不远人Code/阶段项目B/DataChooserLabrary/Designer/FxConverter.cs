using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DateChooserLibrary.Designer
{
    public class ShowFxConverter : BaseConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] values = { "None", "BlindDown", "BlindRight", "UnFold", "DropInUp", "DropInRight", "DropInDown", "DropInLeft", "OpenVertically", "OpenHorizontally", "Grow", "SlideInUp", "SlideInRight", "SlideInDown", "SlideInLeft"};
            return new StandardValuesCollection(values);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    public class HideFxConverter : BaseConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] values = { "None", "BlindUp", "BlindLeft", "Fold", "DropOutUp", "DropOutRight", "DropOutDown", "DropOutLeft", "CloseVertically", "ColseHorizontally", "Shrink", "SlideOutUp", "SlideOutRight", "SlideOutDown", "SlideOutLeft" };
            return new StandardValuesCollection(values);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
