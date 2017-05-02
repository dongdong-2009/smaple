using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace MVC
{
    public interface IListsService 
    {
        IEnumerable<ListInfo> GetLists();
    }
}
