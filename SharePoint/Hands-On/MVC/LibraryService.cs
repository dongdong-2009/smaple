using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;

namespace MVC
{
    class LibraryService : IListsService 
    {
        public IEnumerable<ListInfo> GetLists() 
        {
            SPWeb web = SPContext.Current.Web;
            List<ListInfo> listInfo = new List<ListInfo>();
            foreach (SPList list in web.GetListsOfType(SPBaseType.DocumentLibrary)) 
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
