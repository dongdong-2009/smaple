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
        /// ֻ����Bool�ֶ�
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
        /// Trueѡ���Ե�����
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
        /// False�Աߵ�����
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
        /// ֵΪ��ʱĬ����True����False
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

        //����ѡ�����Boolֵ
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
        /// ���ʱ����True
        /// </summary>
        protected override object GetDesignTimeValue()
        {
            return true;
        }

        //��RadioButtonList��ʼ����Ԫ������
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
        /// ��������ֵѡ��ѡ��
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