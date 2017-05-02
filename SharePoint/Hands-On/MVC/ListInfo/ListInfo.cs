using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.SharePoint.Common.ServiceLocation;

namespace MVC
{
    [ToolboxItemAttribute(false)]
    public class ListInfoWebPart : WebPart, IListsView 
    {
        protected override void CreateChildControls()
        {
            //ListsPresenter presenter = new ListsPresenter(this);
            //presenter.LoadLists();
            //foreach (ListInfo listInfo in this.Lists)
            //{
            //    this.Controls.Add(new HyperLink()
            //    {
            //        Text = listInfo.Title,
            //        NavigateUrl = listInfo.Url
            //    });
            //    this.Controls.Add(new LiteralControl("<br/>"));
            //}


            // Use SharePoint Server Locator
            IServiceLocator serviceLocator = SharePointServiceLocator.GetCurrent();
            IListsService service = serviceLocator.GetInstance<IListsService>();
            ListsPresenter presenter = new ListsPresenter(this, service);
            presenter.LoadLists();
            foreach (ListInfo listInfo in this.Lists)
            {
                this.Controls.Add(new HyperLink()
                {
                    Text = listInfo.Title,
                    NavigateUrl = listInfo.Url
                });
                this.Controls.Add(new LiteralControl("<br/>"));
            }
        }

        public System.Collections.Generic.IEnumerable<ListInfo> Lists
        {
            get;
            set;           
        }
    }
}
