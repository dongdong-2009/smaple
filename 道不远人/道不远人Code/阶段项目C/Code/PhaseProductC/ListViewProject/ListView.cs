    using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;

namespace ListViewProject
{
    [Designer(typeof(ListViewDesigner))]
    public class ListView : CompositeDataBoundControl,INamingContainer//,IPostBackEventHandler,IPostBackContainer
    {
        ListViewUpdateArgument _updateArgs;

        int _editIndex = -1;
        [Category("Default"), DefaultValue(-1)]
        public int EditIndex
        {
            get
            {
                return _editIndex;
            }
            set
            {
                _editIndex = value;
            }
        }

        #region DataKeys

        private void ClearDataKeys()
        {
            this._dataKeysArrayList = null;
        }

        string[] _dataKeyNames;
        [Category("Data"), DefaultValue((string)null),
        TypeConverter(typeof(StringArrayConverter))]
        public virtual string[] DataKeyNames
        {
            get
            {
                object keys = this._dataKeyNames;
                if (keys != null)
                {
                    return (string[])((string[])keys).Clone();
                }
                return new string[0];
            }
            set
            {
                if (!CompareStringArrays(value, this.DataKeyNamesInternal))
                {
                    if (value != null)
                    {
                        this._dataKeyNames = (string[])value.Clone();
                    }
                    else
                    {
                        this._dataKeyNames = null;
                    }
                    this.ClearDataKeys();
                    if (base.Initialized)
                    {
                        base.RequiresDataBinding = true;
                    }
                }
            }
        }

        private string[] DataKeyNamesInternal
        {
            get
            {
                object obj2 = this._dataKeyNames;
                if (obj2 != null)
                {
                    return (string[])obj2;
                }
                return new string[0];
            }
        }


        DataKeyArray _dataKeyArray;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public virtual DataKeyArray DataKeys
        {
            get
            {
                if (this._dataKeyArray == null)
                {
                    this._dataKeyArray = new DataKeyArray(this.DataKeysArrayList);
                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)this._dataKeyArray).TrackViewState();
                    }
                }
                return this._dataKeyArray;
            }
        }

        private ArrayList _dataKeysArrayList;
        private ArrayList DataKeysArrayList
        {
            get
            {
                if (this._dataKeysArrayList == null)
                {
                    this._dataKeysArrayList = new ArrayList();
                }
                return this._dataKeysArrayList;
            }
        }

        #endregion

        #region Events

        private static readonly object EventCancelCommand = new object();
        private static readonly object EventEditCommand = new object();
        private static readonly object EventUpdateCommand = new object();

        [Category("Action")]
        public event EventHandler CancelCommand
        {
            add
            {
                base.Events.AddHandler(EventCancelCommand, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventCancelCommand, value);
            }
        }

        [Category("Action")]
        public event EventHandler<ListViewArgument> EditCommand
        {
            add
            {
                base.Events.AddHandler(EventEditCommand, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventEditCommand, value);
            }
        }

        [Category("Action")]
        public event EventHandler<ListViewUpdateArgument> UpdateCommand
        {
            add
            {
                base.Events.AddHandler(EventUpdateCommand, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventUpdateCommand, value);
            }
        }

        protected virtual void OnCancelCommand(EventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[EventCancelCommand];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEditCommand(ListViewArgument e)
        {
            EventHandler<ListViewArgument> handler = (EventHandler<ListViewArgument>)base.Events[EventEditCommand];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnUpdateCommand(ListViewUpdateArgument e)
        {
            EventHandler<ListViewUpdateArgument> handler = (EventHandler<ListViewUpdateArgument>)base.Events[EventUpdateCommand];
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Styles

        private Style _alternatingRowStyle;

        [Category("Styles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Style AlternatingRowStyle
        {
            get
            {
                if (_alternatingRowStyle == null)
                {
                    _alternatingRowStyle = new Style();
                    if (IsTrackingViewState)
                        ((IStateManager)_alternatingRowStyle).TrackViewState();
                }
                return _alternatingRowStyle;
            }
        }

        private Style _rowStyle;

        [Category("Styles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Style RowStyle
        {
            get
            {
                if (_rowStyle == null)
                {
                    _rowStyle = new Style();
                    if (IsTrackingViewState)
                        ((IStateManager)_rowStyle).TrackViewState();
                }
                return _rowStyle;
            }
        }

        private Style _editRowStyle;

        [Category("Styles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public Style EditRowStyle
        {
            get
            {
                if (_editRowStyle == null)
                {
                    _editRowStyle = new Style();
                    if (IsTrackingViewState)
                        ((IStateManager)_editRowStyle).TrackViewState();
                }
                return _editRowStyle;
            }
        }



        #endregion

        #region ViewState

        protected override void LoadViewState(object savedState)
        {
            if (savedState == null)
                base.LoadViewState(savedState);
            else
            {
                object[] states = savedState as object[];
                if (states.Length != 4)
                {
                    throw new ArgumentException("无效的视图状态");
                }
                base.LoadViewState(states[0]);
                ((IStateManager)AlternatingRowStyle).LoadViewState(states[1]);
                ((IStateManager)RowStyle).LoadViewState(states[2]);
                ((IStateManager)EditRowStyle).LoadViewState(states[3]);
                //((IStateManager)DataKeys).LoadViewState(states[4]);
            }
        }

        protected override object SaveViewState()
        {
            object[] states = new object[4];
            states[0] = base.SaveViewState();
            if (_alternatingRowStyle != null)
                states[1] = ((IStateManager)_alternatingRowStyle).SaveViewState();
            if (_rowStyle != null)
                states[2] = ((IStateManager)_rowStyle).SaveViewState();
            if (_editRowStyle != null)
                states[3] = ((IStateManager)_editRowStyle).SaveViewState();
            //if (_dataKeyArray != null)
            //    states[4] = ((IStateManager)_dataKeyArray).SaveViewState();
            foreach (object state in states)
            {
                if (state != null)
                    return states;
            }
            return null;
        }

        protected override void TrackViewState()
        {
            base.TrackViewState();
            if (_rowStyle != null)
                ((IStateManager)_rowStyle).TrackViewState();
            if (_alternatingRowStyle != null)
                ((IStateManager)_alternatingRowStyle).TrackViewState();
            if (_editRowStyle != null)
                ((IStateManager)_editRowStyle).TrackViewState();
            //if (_dataKeyArray != null)
            //    ((IStateManager)_dataKeyArray).TrackViewState();
        }

        #endregion

        #region ControlState

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override void LoadControlState(object savedState)
        {
            if (savedState is Pair)
            {
                Pair pair = (Pair)savedState;
                base.LoadControlState(pair.First);

                Triplet states = (Triplet)pair.Second;
                this._editIndex = (int)states.First;
                this._dataKeyNames = (string[])states.Second;
                LoadDataKeysState(states.Third);
            }
            else
            {
                base.LoadControlState(savedState);
            }
        }

        protected override object SaveControlState()
        {
            Pair statePair = new Pair();
            statePair.First = base.SaveControlState();
            Triplet stateTriplet = new Triplet();
            stateTriplet.First = this._editIndex;
            stateTriplet.Second = this._dataKeyNames;
            stateTriplet.Third = this.SaveDataKeysState();
            statePair.Second = stateTriplet;
            return statePair;
        }

        private void LoadDataKeysState(object state)
        {
            if (state != null)
            {
                object[] objArray = (object[])state;
                string[] keyNames = this.DataKeyNamesInternal;
                int capacity = keyNames.Length;
                for (int i = 0; i < objArray.Length; i++)
                {
                    this.DataKeysArrayList.Add(new DataKey(new OrderedDictionary(capacity), keyNames));
                    ((IStateManager)this.DataKeysArrayList[i]).LoadViewState(objArray[i]);
                }
            }
        }

        private object SaveDataKeysState()
        {
            object obj2 = new object();
            int count = 0;
            if ((this._dataKeysArrayList != null) && (this._dataKeysArrayList.Count > 0))
            {
                count = this._dataKeysArrayList.Count;
                obj2 = new object[count];
                for (int i = 0; i < count; i++)
                {
                    ((object[])obj2)[i] = ((IStateManager)this._dataKeysArrayList[i]).SaveViewState();
                }
            }
            if ((this._dataKeysArrayList != null) && (count != 0))
            {
                return obj2;
            }
            return null;
        }

        #endregion

        #region Templates

        private ITemplate _itemTemplate;

        [TemplateContainer(typeof(ListViewItem))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ITemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set { _itemTemplate = value; }
        }

        private ITemplate _editTemplate;

        [TemplateContainer(typeof(ListViewItem),BindingDirection.TwoWay)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ITemplate EditTemplate
        {
            get { return _editTemplate; }
            set { _editTemplate = value; }
        }

        #endregion

        #region Render

        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            int index = 0;
            if (dataBinding)
            {
                DataKeysArrayList.Clear();
            }
            this._dataKeyArray = null;

            if (_itemTemplate != null)
            {
                Controls.Clear();
                bool hasDatakyes = dataBinding && (DataKeyNamesInternal.Length > 0);

                foreach (object dataItem in dataSource)
                {
                    if (hasDatakyes)
                    {
                        OrderedDictionary keyTable = new OrderedDictionary(DataKeyNames.Length);
                        foreach (string key in DataKeyNames)
                        {
                            object propertyValue = null;
                            if(!DesignMode)
                            {
                                propertyValue = DataBinder.GetPropertyValue(dataItem, key);
                            }
                            keyTable.Add(key, propertyValue);
                        }
                        if (_dataKeysArrayList.Count == index)
                        {
                            _dataKeysArrayList.Add(new DataKey(keyTable, DataKeyNames));
                        }
                        else
                        {
                            _dataKeysArrayList[index] = new DataKey(keyTable, DataKeyNames);
                        }
                    }

                    ListViewItem listViewItem = new ListViewItem(this, dataItem, index, index);
                    if (index == EditIndex)
                    {
                        if (_editTemplate != null)
                        {
                            _editTemplate.InstantiateIn(listViewItem);
                            if (EditRowStyle != null && !EditRowStyle.IsEmpty)
                            {
                                Style s = new Style();
                                s.CopyFrom(EditRowStyle);
                                listViewItem.ApplyStyle(s);
                            }
                        }
                    }
                    else
                    {
                        _itemTemplate.InstantiateIn(listViewItem);

                        if (index % 2 == 0)
                        {
                            if (RowStyle != null && !RowStyle.IsEmpty)
                            {
                                Style s = new Style();
                                s.CopyFrom(RowStyle);
                                listViewItem.ApplyStyle(s);
                            }
                        }
                        else
                        {
                            Style s = new Style();
                            if (AlternatingRowStyle != null)
                                s.CopyFrom(AlternatingRowStyle);
                            else if (RowStyle != null)
                                s.CopyFrom(RowStyle);
                            if (!s.IsEmpty)
                                listViewItem.ApplyStyle(s);
                        }
                    }
                    Controls.Add(listViewItem);
                    index++;
                }
            }
            DataBind(false);
            ChildControlsCreated = true;
            return index;

        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Ul;
            }
        }

        #endregion

        #region Handle events

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            bool handled = false;
            if (args is CommandEventArgs)
            {
                CommandEventArgs cmdArgs = args as CommandEventArgs;
                if (cmdArgs.CommandName.Equals("Update", StringComparison.OrdinalIgnoreCase))
                {
                    ListViewArgument e = new ListViewArgument((ListViewItem)source);
                    HandleUpdate(e);
                    handled = true;
                }
                else if (cmdArgs.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
                {
                    HandleCancel(args);
                    handled = true;
                }
                else if (cmdArgs.CommandName.Equals("Edit", StringComparison.OrdinalIgnoreCase))
                {
                    ListViewArgument e = new ListViewArgument((ListViewItem)source);
                    HandleEdit(e);
                    handled = true;
                }
            }
            return handled;
        }

        void HandleCancel(EventArgs e)
        {
            EditIndex = -1;
            RequiresDataBinding = true;
            OnCancelCommand(e);
        }

        void HandleEdit(ListViewArgument e)
        {
            if (GetData().CanUpdate)
            {
                EditIndex = e.Item.DataItemIndex;
                RequiresDataBinding = true;
                OnEditCommand(e);
            }
            else
            {
                throw new InvalidOperationException("数据源不支持更新");
            }
        }

        void HandleUpdate(ListViewArgument e)
        {
            _updateArgs = new ListViewUpdateArgument(e.Item);
            if (DataKeys.Count > e.Item.DataItemIndex)
            {
                foreach (DictionaryEntry de in DataKeys[e.Item.DataItemIndex].Values)
                {
                    _updateArgs.Keys.Add(de.Key, de.Value);
                    _updateArgs.OldValues.Add(de.Key, de.Value);
                }
            }
            _updateArgs.NewValues = (_editTemplate as IBindableTemplate).ExtractValues(e.Item);
            GetData().Update(_updateArgs.Keys, _updateArgs.NewValues, _updateArgs.OldValues, new DataSourceViewOperationCallback(HandleUpdateCallback));
        }

        private bool HandleUpdateCallback(int affectedRows, Exception ex)
        {
            _updateArgs.AffectedRows = affectedRows;
            if (ex != null)
            {
                _updateArgs.ExceptionHandled = false;
                _updateArgs.UpdateException = ex;
            }
            this.OnUpdateCommand(_updateArgs);
            if ((ex != null) && !_updateArgs.ExceptionHandled)
            {
                throw ex;
            }
            EditIndex = -1;
            RequiresDataBinding = true;
            return true;
        }

        #endregion


        #region Utilities

        public static bool CompareStringArrays(string[] stringA, string[] stringB)
        {
            if ((stringA != null) || (stringB != null))
            {
                if ((stringA == null) || (stringB == null))
                {
                    return false;
                }
                if (stringA.Length != stringB.Length)
                {
                    return false;
                }
                for (int i = 0; i < stringA.Length; i++)
                {
                    if (!string.Equals(stringA[i], stringB[i], StringComparison.Ordinal))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region IPostBackContainer 成员

        //public PostBackOptions GetPostBackOptions(IButtonControl buttonControl)
        //{
        //    if (buttonControl == null)
        //    {
        //        throw new ArgumentNullException("buttonControl");
        //    }
        //    ListViewItem viewItem = (buttonControl as Control).NamingContainer as ListViewItem;
        //    if (viewItem != null)
        //    {

        //        PostBackOptions options = new PostBackOptions(this, buttonControl.CommandName
        //            + "$" + viewItem.DataItemIndex.ToString());
        //        options.RequiresJavaScriptProtocol = true;
        //        return options;
        //    }
        //    return null;
        //}

        #endregion

        #region IPostBackEventHandler 成员

        //public void RaisePostBackEvent(string eventArgument)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        #endregion
    }
}
