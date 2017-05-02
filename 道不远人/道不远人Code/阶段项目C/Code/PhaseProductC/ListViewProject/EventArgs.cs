using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ListViewProject
{
    public class ListViewArgument : EventArgs
    {
        private ListViewItem _item;

        public ListViewItem Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public ListViewArgument()
        {
        }

        public ListViewArgument(ListViewItem item)
        {
            _item = item;
        }
    }

    public class ListViewUpdateArgument : ListViewArgument
    {
        private bool _exceptionHandled = true;

        public bool ExceptionHandled
        {
            get { return _exceptionHandled; }
            set { _exceptionHandled = value; }
        }


        private int _affectedRows;

        public int AffectedRows
        {
            get { return _affectedRows; }
            internal set { _affectedRows = value; }
        }


        private Exception _exception;

        public Exception UpdateException
        {
            get { return _exception; }
            internal set { _exception = value; }
        }
        
        private IOrderedDictionary _keys = new OrderedDictionary();

        public IOrderedDictionary Keys
        {
            get { return _keys; }
        }

        private IOrderedDictionary _newValues = new OrderedDictionary();

        public IOrderedDictionary NewValues
        {
            get { return _newValues; }
            internal set { _newValues = value; }
        }

   
        private IOrderedDictionary _oldValues = new OrderedDictionary();

        public IOrderedDictionary OldValues
        {
            get { return _oldValues; }
        }

        public ListViewUpdateArgument()
        {
        }

        public ListViewUpdateArgument(ListViewItem item)
            : base(item)
        {
        }

        public ListViewUpdateArgument(ListViewItem item, IOrderedDictionary keys, IOrderedDictionary newValues, IOrderedDictionary oldValues)
            : base(item)
        {
            this._keys = keys;
            this._newValues = newValues;
            this._oldValues = oldValues;
        }
    }
}
