using System;
using System.Collections.Generic;
using System.Text;

namespace ControlProperties
{
    public class AlbumnUsingControlState:Albumn
    {
        protected override void OnInit(EventArgs e)
        {
            Page.RegisterRequiresControlState(this);
            base.OnInit(e);
        }

        protected override object SaveControlState()
        {
            return this.ImgUrl;
        }

        protected override void LoadControlState(object savedState)
        {
            this.ImgUrl = savedState as string;
        }

    }
}
