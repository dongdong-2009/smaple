using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace MVC
{
    class ListsService : IListsService 
    {
        public IEnumerable<ListInfo> GetLists() 
        {
            SPWeb web = SPContext.Current.Web;
            List<ListInfo> listInfo = new List<ListInfo>();
            foreach (SPList list in web.Lists) 
            {
                listInfo.Add(new ListInfo() 
                {
                    Title = list.Title,
                    Url = list.DefaultViewUrl
                });

            }
            return listInfo;
        }
    }
}
