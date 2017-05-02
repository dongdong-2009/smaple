using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;

namespace TemplatedControls
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class BookData:IStateManager
    {
        [NotifyParentProperty(true)]
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

        [NotifyParentProperty(true)]
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
        [NotifyParentProperty(true)]
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

        [NotifyParentProperty(true)]
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

        [NotifyParentProperty(true)]
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


        #region IStateManager ≥…‘±

        private bool _isTrackViewState;
        private StateBag _viewState;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        
        public StateBag ViewState
        {
            get
            {
                if (_viewState == null)
                {
                    _viewState = new StateBag(false);
                    if (_isTrackViewState)
                    {
                        ((IStateManager)_viewState).TrackViewState();
                    }
                }
                return _viewState;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTrackingViewState
        {
            get 
            {
                return _isTrackViewState;
            }
        }

        public void LoadViewState(object state)
        {
            if (state != null)
            {
                ((IStateManager)ViewState).LoadViewState(state);
            }
        }

        public object SaveViewState()
        {
            if (this._viewState != null)
            {
                return ((IStateManager)_viewState).SaveViewState();
            }
            return null;
        }

        public void TrackViewState()
        {
            this._isTrackViewState = true;
            if (_viewState != null)
            {
                ((IStateManager)_viewState).TrackViewState();
            }
        }

        #endregion
    }
}
