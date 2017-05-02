using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ControlDesignTimeLabrary
{
    public class SelectedIndexConverter:Int32Converter
    {
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if (context != null)
            {
                TabControl control = context.Instance as TabControl;
                if (control == null)
                {
                    control = (context.Instance as TabControlDesigner.TabControlActionList).Component as TabControl;
                }
                if (control != null)
                {
                    List<int> values = new List<int>(control.Controls.Count);
                    for (int i = 0; i < control.Controls.Count; i++)
                    {
                        values.Add(i);
                    }
                    return new StandardValuesCollection(values);
                }
            }
            return base.GetStandardValues(context);
        }
    }
}
