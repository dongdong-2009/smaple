using System;
using System.Collections.Generic;
using System.Text;
using RssToolkit;
using System.Data;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;

namespace DataSourceControls
{

public class RssDataSourceDesigner : DataSourceDesigner
{
    RssDataSource _dataSource;
    RssDesignerDataSourceView _view;

    public override void Initialize(IComponent component)
    {
        base.Initialize(component);
        _dataSource = (RssDataSource)component;
    }

    public override bool CanConfigure
    {
        get { return true; }
    }

    public override void Configure()
    {
        InvokeTransactedChange(Component, new TransactedChangeCallback(ConfigureRssDataSource), null, "Configure Data Source");
    }

    private bool ConfigureRssDataSource(object context)
    {
        try
        {
            SuppressDataSourceEvents();

            string oldUrl = _dataSource.Url;

            RssDataSourceConfigForm form = new RssDataSourceConfigForm(_dataSource);
            IUIService uiService = (IUIService)GetService(typeof(IUIService));
            DialogResult result = uiService.ShowDialog(form);

            if (result == DialogResult.OK && oldUrl != _dataSource.Url)
            {
                OnSchemaRefreshed(EventArgs.Empty);
            }

            return (result == DialogResult.OK);
        }
        finally
        {
            ResumeDataSourceEvents();
        }
    }

    public override DesignerDataSourceView GetView(string viewName)
    {
        if (_view == null)
        {
            _view = new RssDesignerDataSourceView(this, viewName);
        }

        return _view;
    }

    class RssDesignerDataSourceView : DesignerDataSourceView
    {
        RssDataSourceDesigner _owner;

        public RssDesignerDataSourceView(RssDataSourceDesigner owner, string viewName)
            : base(owner, viewName)
        {
            _owner = owner;
        }

        public override IDataSourceViewSchema Schema
        {
            get
            {
                GenericRssChannel channel = _owner._dataSource.Channel;

                if (channel.Items.Count == 0)
                {
                    return base.Schema;
                }

                Dictionary<string, string> itemAttributes = channel.Items[0].Attributes;

                // create a datatable and infer schema from there

                DataTable dt = new DataTable("items");

                foreach (KeyValuePair<string, string> a in itemAttributes)
                {
                    dt.Columns.Add(a.Key);
                }

                return new DataSetViewSchema(dt);
            }
        }
    }
}
}
