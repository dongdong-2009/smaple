using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

namespace ListViewProject
{
    [ToolboxItem(false)]
    public class ListViewItem : WebControl, IDataItemContainer, INamingContainer
    {
        private object _dataItem;
        private int _index;
        private int _displayIndex;
        private ListView _container;

        #region IDataItemContainer ≥…‘±

        public object DataItem
        {
            get { return _dataItem; }
        }

        public int DataItemIndex
        {
            get { return _index; }
        }

        public int DisplayIndex
        {
            get { return _displayIndex; }
        }

        #endregion

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Li;
            }
        }

        public ListViewItem()
        {
        }

        public ListViewItem(ListView container,object dataItem, int index, int displayIndex)
        {
            _container = container;
            this._dataItem = dataItem;
            this._index = index;
            this._displayIndex = displayIndex;
        }

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            if (source is IButtonControl)
            {
                CommandEventArgs cmdArgs = args as CommandEventArgs;
                if (cmdArgs != null)
                {
                    CommandEventArgs cmdArg = new CommandEventArgs(cmdArgs.CommandName, this.DataItemIndex.ToString());
                    RaiseBubbleEvent(this, cmdArg);
                    return true;
                }
            }
            return false;
        }
    }
}
