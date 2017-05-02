using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC
{
    public interface IListsView 
    {
        IEnumerable<ListInfo> Lists 
        {
            get;
            set;
        }
    }
}
