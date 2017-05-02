using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC
{
    public class ListsPresenter 
    {
        protected readonly IListsView _view;
        protected readonly IListsService _model;

        public ListsPresenter(IListsView view)
            : this(view, new ListsService())
        {

        }

        public ListsPresenter(IListsView view, IListsService model)
        {
            _view = view;
            _model = model;
        }

        public void LoadLists() 
        {
            _view.Lists = _model.GetLists();
        }
    }
}
