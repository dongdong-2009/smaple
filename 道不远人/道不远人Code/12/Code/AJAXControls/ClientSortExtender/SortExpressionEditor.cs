using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace AJAXControls
{
    internal class SortExpressionEditorUI : Control
    {
        private const int _cboWidth = 0x66;
        private int _currentHeight = 10;
        private IWindowsFormsEditorService _edSvc;
        private int _labelWeight = 10;
        private int _lblMaxWidth;
        private Button btnCancel;
        private Button btnOk;
        public System.Windows.Forms.DialogResult DialogResult = System.Windows.Forms.DialogResult.Cancel;
        private static Regex regSplit = new Regex(@"\'?\w+\'?", RegexOptions.Compiled);

        /// <summary>
        /// SortExpressionEditor使用的UI (Winforms)
        /// </summary>
        /// <param name="gridView">被扩展的GridView</param>
        /// <param name="schema">从GridVIew设计器上拿到的被绑定数据的Schema</param>
        /// <param name="originalValue">编辑之前的值</param>
        /// <param name="edSvc">设计器的编辑器服务</param>
        public SortExpressionEditorUI(System.Web.UI.WebControls.GridView gridView, IDataSourceViewSchema schema, string originalValue, IWindowsFormsEditorService edSvc)
        {
            NameValueCollection values = new NameValueCollection();
            bool originalIsNull = string.IsNullOrEmpty(originalValue);
            List<string> originalValues = new List<string>();
            List<string> columnNames = new List<string>();
            //获得原来的设置
            if (!originalIsNull)
            {
                MatchCollection matches = regSplit.Matches(originalValue);
                foreach (Match m in matches)
                {
                    originalValues.Add(m.Value);
                }
            }
            IDataSourceFieldSchema[] fields = null;
            if(schema != null)
            {
                fields = schema.GetFields();
            }
            //如果是自动生成行，则根据Schema初始化数据
            if (gridView.AutoGenerateColumns)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    IDataSourceFieldSchema fieldSchema = fields[i];
                    string columnName = fieldSchema.Name;
                    columnNames.Add(columnName);
                    if (columnName.Length > this._lblMaxWidth)
                    {
                        this._lblMaxWidth = columnName.Length;
                    }
                    if (originalValues.Count <= i)
                    {
                        originalValues.Add( GetValue(fieldSchema));                        
                    }
                }
            }
            //根据GridView的列初始化数据
            else
            {
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    string columnName = gridView.Columns[i].HeaderText;
                    columnNames.Add(columnName);
                    if (columnName.Length > this._lblMaxWidth)
                    {
                        this._lblMaxWidth = columnName.Length;
                    }
                    if (originalValues.Count <= i && fields.Length > i)
                    {
                        originalValues.Add(GetValue(fields[i]));
                        //注意，这里并没有考虑数据源字段与列的对应关系，读者朋友可以自行完善
                    }
                }
            }

            this._lblMaxWidth *= 12;
            this._edSvc = edSvc;
            this.InitializeComponent();
            base.ImeMode = ImeMode.Off;
            this.GenerateComponent(columnNames,originalValues);
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            base.Height = this._currentHeight + 10;
            base.Width = (this._lblMaxWidth + 0x66) + 20;
            this.btnOk.Left = (((base.Width - this.btnOk.Width) - this.btnCancel.Width) - 20) / 2;
            this.btnCancel.Left = (this.btnOk.Left + this.btnOk.Width) + 10;
        }

        /// <summary>
        /// 根据Schema生成类型信息
        /// </summary>
        /// <param name="fieldSchema"></param>
        /// <returns></returns>
        string GetValue(IDataSourceFieldSchema fieldSchema)
        {
            if (fieldSchema != null)
            {
                string type = fieldSchema.DataType.Name;
                if (type.StartsWith("Int"))
                {
                    return "'int'";
                }
                else if (type == "DateTime")
                {
                    return "'date'";
                }
                else if (type == "Single" || type == "Double")
                {
                    return "'float'";
                }
                else if (type == "Decimal")
                {
                    return "'currency'";
                }
                else
                {
                    return "'string'";
                }
            }
            return "'none'";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //关闭编辑UI
            this._edSvc.CloseDropDown();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._edSvc.CloseDropDown();
        }

        //生成选择类型的ComboBox，由GenerateComponent方法调用
        private void GenerateComboBox(string originalName)
        {
            ComboBox cbo = new ComboBox();
            cbo.Text = originalName;
            cbo.Name = "cbo" + this._currentHeight;
            cbo.Items.AddRange(SortType.BuiltInTypes);
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (((SortType)cbo.Items[i]).Value == originalName)
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }
            cbo.DropDownStyle = ComboBoxStyle.DropDown;
            base.Controls.Add(cbo);
            cbo.Height = 0x12;
            cbo.Width = 0x66;
            cbo.Left = this._lblMaxWidth + 10;
            cbo.Top = this._currentHeight;
            this._currentHeight += cbo.Height + 10;
        }

        //根据列集合生成UI
        private void GenerateComponent(List<string> columnNames,List<string> originalValues)
        {
            for (int i = 0; i < columnNames.Count; i++)
            {
                string name = columnNames[i];
                this.GenerateLabel(name);
                this.GenerateComboBox(originalValues[i]);
            }
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.btnCancel);
            this.btnCancel.Top = this.btnOk.Top = this._currentHeight + 10;
            this.btnOk.Left = 10;
            this.btnCancel.Left = 20 + this.btnOk.Width;
            this._currentHeight += 10 + this.btnOk.Height;
            this.btnOk.Text = "Ok";
            this.btnCancel.Text = "Cancel";
        }

        //生成选择类型ComboBox前的列名信息
        private void GenerateLabel(string columnName)
        {
            Label lbl = new Label();
            lbl.Name = "lbl" + columnName;
            lbl.Text = columnName + ":";
            lbl.Font = new Font(FontFamily.GenericSansSerif, 12f);
            lbl.AutoSize = true;
            lbl.Height = 14;
            lbl.Width = (lbl.Text.Length * 14) + 10;
            base.Controls.Add(lbl);
            lbl.Top = this._currentHeight;
            lbl.Left = 10;
            this._labelWeight = (lbl.Left + lbl.Width) + 10;
        }

        //根据选择的值返回排序表达式
        public string GetSortExpression()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (Control c in base.Controls)
            {
                ComboBox cbo = c as ComboBox;
                if (cbo != null)
                {
                    if (cbo.SelectedIndex < 0)
                    {
                        sb.Append(cbo.Text);
                    }
                    else
                    {
                        sb.Append((cbo.SelectedItem as SortType).Value);
                    }
                    sb.Append(",");
                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        private void InitializeComponent()
        {
            this.btnOk = new Button();
            this.btnCancel = new Button();
            base.SuspendLayout();
            this.btnOk.Location = new Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(0x4b, 0x17);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnCancel.Location = new Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            base.ResumeLayout(false);
        }

        /// <summary>
        /// 排序类型信息
        /// </summary>
        private class SortType
        {
            public static readonly SortExpressionEditorUI.SortType[] BuiltInTypes = new SortExpressionEditorUI.SortType[] { new SortExpressionEditorUI.SortType("int", "'int'"), new SortExpressionEditorUI.SortType("float", "'float'"), new SortExpressionEditorUI.SortType("string", "'string'"), new SortExpressionEditorUI.SortType("date", "'date'"), new SortExpressionEditorUI.SortType("currency", "'currency'"), new SortExpressionEditorUI.SortType("none", "'none'") };
            private string name;
            private string value;

            public SortType(string name, string value)
            {
                this.value = value;
                this.name = name;
            }

            public override string ToString()
            {
                return this.value;
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
            }

            public string Value
            {
                get
                {
                    return this.value;
                }
            }
        }
    }

    /// <summary>
    /// SortExpression属性的编辑器
    /// </summary>
    internal class SortExpressionEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ClientSortExtender extender = context.Instance as ClientSortExtender;
            if (extender != null)
            {
                System.Web.UI.WebControls.GridView target = extender.GetTargetControl();
                if (target != null)
                {
                    IDesignerHost host = provider.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (host != null)
                    {
                        //获得被扩展的GridView的设计器，以得到它绑定的数据的Schema
                        GridViewDesigner gridViewDesigner = host.GetDesigner((IComponent)target) as GridViewDesigner;
                        IDataSourceViewSchema schema = gridViewDesigner.DesignerView.Schema;
                        //如果有Schema信息或GridView已有列，则显示编辑UI
                        if ((schema != null && target.AutoGenerateColumns) || target.Columns.Count > 0)
                        {
                            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                            SortExpressionEditorUI ui = new SortExpressionEditorUI(target, schema, (string)value, edSvc);
                            ui.BackColor = Color.FromKnownColor(KnownColor.Control);
                            edSvc.DropDownControl(ui);
                            if (ui.DialogResult == DialogResult.OK)
                            {
                                return ui.GetSortExpression();
                            }
                        }
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// 使用下拉式编辑界面
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }

}
