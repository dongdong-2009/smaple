using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Collections;

namespace DataSourceControls
{
    public class RssDataSourceView : DataSourceView
    {
        RssDataSource _owner;

        internal RssDataSourceView(RssDataSource owner, string viewName)
            : base(owner, viewName)
        {
            _owner = owner;
        }

        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
        {
            return _owner.Channel.SelectItems();
        }
    }
}
