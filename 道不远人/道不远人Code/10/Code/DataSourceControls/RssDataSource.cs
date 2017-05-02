using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using RssToolkit;

namespace DataSourceControls
{
    [Designer(typeof(RssDataSourceDesigner))]
    [DefaultProperty("Url")]
    public class RssDataSource : DataSourceControl
    {
        string _url;
        RssDataSourceView _itemsView;
        GenericRssChannel _channel;

        public RssDataSource()
        {
        }

        protected override DataSourceView GetView(string viewName)
        {
            if (_itemsView == null)
            {
                _itemsView = new RssDataSourceView(this, viewName);
            }

            return _itemsView;
        }

        public GenericRssChannel Channel
        {
            get
            {
                if (_channel == null)
                {
                    if (string.IsNullOrEmpty(_url))
                    {
                        _channel = new GenericRssChannel();
                    }
                    else
                    {
                        _channel = GenericRssChannel.LoadChannel(_url);
                    }
                }

                return _channel;
            }
        }

        public string Url
        {
            get { return _url; }

            set
            {
                _channel = null;
                _url = value;
            }
        }
    }



}
