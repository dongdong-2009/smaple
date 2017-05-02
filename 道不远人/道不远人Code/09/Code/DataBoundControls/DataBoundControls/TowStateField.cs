using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Web.UI;

namespace DataBoundControls
{
    public class TowStateField : CheckBoxField
    {
        /// <summary>
        /// 只用于Bool字段
        /// </summary>
        [TypeConverter(typeof(DataSourceBooleanViewSchemaConverter))]
        public override string DataField
        {
            get
            {
                return base.DataField;
            }
            set
            {
                base.DataField = value;
            }
        }

        /// <summary>
        /// True选项旁的文字
        /// </summary>
        public string TrueText
        {
            get
            {
                if (ViewState["TrueText"] == null)
                {
                    return "True";
                }
                return (string)ViewState["TrueText"];
            }
            set
            {
                ViewState["TrueText"] = value;
            }
        }

        /// <summary>
        /// False旁边的文字
        /// </summary>
        public string FalseText
        {
            get
            {
                if (ViewState["FalseText"] == null)
                {
                    return "False";
                }
                return (string)ViewState["FalseText"];
            }
            set
            {
                ViewState["FalseText"] = value;
            }
        }

        /// <summary>
        /// 值为空时默认用True还是False
        /// </summary>
        public bool NullValue
        {
            get
            {
                if (ViewState["NullValue"] == null)
                {
                    return false;
                }
                return (bool)ViewState["NullValue"];
            }
            set
            {
                ViewState["NullValue"] = value;
            }
        }

        protected override DataControlField CreateField()
        {
            return new TowStateField();
        }

        //根据选中项返回Bool值
        public override void ExtractValuesFromCell(IOrderedDictionary dictionary,
            DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
        {
            RadioButtonList radioList = cell.Controls[0] as RadioButtonList;
            if (radioList != null)
            {
                dictionary[DataField] = radioList.SelectedIndex == 0;
            }
        }

        /// <summary>
        /// 设计时返回True
        /// </summary>
        protected override object GetDesignTimeValue()
        {
            return true;
        }

        //用RadioButtonList初始化单元格内容
        protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
        {
            RadioButtonList radioList = new RadioButtonList();
            radioList.RepeatDirection = RepeatDirection.Horizontal;
            radioList.RepeatLayout = RepeatLayout.Flow;
            radioList.ToolTip = HeaderText;
            ListItem trueItem = new ListItem(TrueText, Convert.ToString(true));
            ListItem falseItem = new ListItem(FalseText, Convert.ToString(false));
            radioList.Items.Add(trueItem);
            radioList.Items.Add(falseItem);
            radioList.Enabled = 
                (rowState == DataControlRowState.Edit || rowState == DataControlRowState.Insert);
            radioList.DataBinding += OnDataBindField;
            cell.Controls.Add(radioList);
        }

        /// <summary>
        /// 根据数据值选中选项
        /// </summary>
        protected override void OnDataBindField(object sender, EventArgs e)
        {
            RadioButtonList radioList = (RadioButtonList)sender;
            System.Web.UI.Control container = radioList.NamingContainer;
            object value = (bool)GetValue(container);
            bool parsedValue = false;
            if (value != null)
            {
                if (Convert.IsDBNull(value))
                {
                    parsedValue = NullValue;
                }
                else
                {
                    parsedValue = bool.Parse(value.ToString());
                }
            }
            radioList.SelectedIndex = parsedValue ? 0 : 1;
        }
    }
}