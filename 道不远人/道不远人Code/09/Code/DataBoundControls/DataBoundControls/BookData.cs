using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBoundControls
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class BookData:WebControl,IDataItemContainer
    {
        [Category("Data")]
        public string ISBN
        {
            get
            {
                if (ViewState["ISBN"] == null)
                    return "";

                return (string)ViewState["ISBN"];
            }
            set
            {
                ViewState["ISBN"] = value;
            }
        }

        [Category("Data")]
        public string Title
        {
            get
            {
                if (ViewState["Title"] == null)
                    return "";

                return (string)ViewState["Title"];
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        [Category("Data")]
        public string Author
        {
            get
            {
                if (ViewState["Author"] == null)
                    return "";

                return (string)ViewState["Author"];
            }
            set
            {
                ViewState["Author"] = value;
            }
        }

        [Category("Data")]
        public string Publisher
        {
            get
            {
                if (ViewState["Publisher"] == null)
                    return "";

                return (string)ViewState["Publisher"];
            }
            set
            {
                ViewState["Publisher"] = value;
            }
        }

        [Category("Data")]
        public string Description
        {
            get
            {
                if (ViewState["Description"] == null)
                    return "";

                return (string)ViewState["Description"];
            }
            set
            {
                ViewState["Description"] = value;
            }
        }

        public BookData()
        {
        }

        public BookData(string isbn, string title, string author,string publisher, string description)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Publisher = publisher;
            Description = description;
        }

        #region IDataItemContainer ≥…‘±

        public object DataItem
        {
            get { return this; }
        }

        public int DataItemIndex
        {
            get {return 0; }
        }

        public int DisplayIndex
        {
            get { return 0; }
        }

        #endregion
    }
}
