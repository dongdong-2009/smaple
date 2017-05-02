using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;

namespace DataBoundControls
{
    public class EnablePageDataList:DataList
    {
        private static readonly object EventPageIndexChanged = new object();
        PagedDataSource pagedDataSource;

        [DefaultValue(false),Category("Paging")]
        public virtual bool AllowPaging
        {
            get
            {
                object obj2 = this.ViewState["AllowPaging"];
                if (obj2 != null)
                {
                    return (bool)obj2;
                }
                return false;
            }
            set
            {
                this.ViewState["AllowPaging"] = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public virtual int VirtualItemCount
        {
            get
            {
                object obj2 = this.ViewState["VirtualItemCount"];
                if (obj2 != null)
                {
                    return (int)obj2;
                }
                return 0;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.ViewState["VirtualItemCount"] = value;
            }
        }

        [DefaultValue(10), Category("Paging")]
        public virtual int PageSize
        {
            get
            {
                object obj2 = this.ViewState["PageSize"];
                if (obj2 != null)
                {
                    return (int)obj2;
                }
                return 10;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.ViewState["PageSize"] = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public int PageCount
        {
            get
            {
                if (this.pagedDataSource != null)
                {
                    return this.pagedDataSource.PageCount;
                }
                object obj2 = this.ViewState["PageCount"];
                if (obj2 == null)
                {
                    return 0;
                }
                return (int)obj2;
            }
        }

        [ Browsable(false), 
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPageIndex
        {
            get
            {
                object obj2 = this.ViewState["CurrentPageIndex"];
                if (obj2 != null)
                {
                    return (int)obj2;
                }
                return 0;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.ViewState["CurrentPageIndex"] = value;
                OnPageIndexChanged(new DataGridPageChangedEventArgs(this, value));
            }
        }

        protected virtual void OnPageIndexChanged(DataGridPageChangedEventArgs e)
        {
            DataGridPageChangedEventHandler handler = (DataGridPageChangedEventHandler)Events[EventPageIndexChanged];
            if (handler != null)
                handler(this, e);
        }

        [Category("Action")]
        public event DataGridPageChangedEventHandler PageIndexChanged
        {
            add
            {
                base.Events.AddHandler(EventPageIndexChanged, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventPageIndexChanged, value);
            }
        }

        protected override System.Collections.IEnumerable GetData()
        {
            IEnumerable dataSource =  base.GetData();
            if (AllowPaging && dataSource != null)
            {
                pagedDataSource = new PagedDataSource();
                ICollection collection = dataSource as ICollection;
                if (collection != null)
                {
                    pagedDataSource.VirtualCount = collection.Count;
                    VirtualItemCount = pagedDataSource.VirtualCount;
                    
                }
                else if(dataSource is IListSource)
                {
                    pagedDataSource.VirtualCount = (dataSource as IListSource).GetList().Count;
                    VirtualItemCount = pagedDataSource.VirtualCount;
                }
                else if (VirtualItemCount > 0)
                {
                    pagedDataSource.VirtualCount = VirtualItemCount;
                }
                else
                {
                    pagedDataSource = null;
                    return dataSource;
                }
                pagedDataSource.DataSource = dataSource;
                pagedDataSource.CurrentPageIndex = CurrentPageIndex;
                pagedDataSource.PageSize = PageSize;
                pagedDataSource.AllowPaging = true;
                pagedDataSource.AllowCustomPaging = false;
                ViewState["PageCount"] = pagedDataSource.PageCount;
                return pagedDataSource;
            }
            return dataSource;
        }
    }
}
