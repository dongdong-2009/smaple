using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace MobileControlLibrary.UI
{
    /// <summary>
    /// 将ViewState保存到Session中
    /// 在实际项目中，应该考虑更健壮复杂的方案
    /// </summary>
    class SessionPageStatePersister:PageStatePersister
    {
        public SessionPageStatePersister(Page page)
            : base(page)
        {
        }
        const string VIEWSTATE = "__VIEWSTATE";
        const string CONTROLSTATE = "__CONTROLSTATE";

        public override void Load()
        {
            if (Page.Session[VIEWSTATE] != null)
            {
                base.ViewState = Page.Session[VIEWSTATE];
            }
            if (Page.Session[CONTROLSTATE] != null)
            {
                base.ViewState = Page.Session[CONTROLSTATE];
            }
        }

        public override void Save()
        {
            if(ViewState != null)
                Page.Session[VIEWSTATE] = base.ViewState;
            if(ControlState != null)
                Page.Session[CONTROLSTATE] = base.ControlState;
        }
    }
}
