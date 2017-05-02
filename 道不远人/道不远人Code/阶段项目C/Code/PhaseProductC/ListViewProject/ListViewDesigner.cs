using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections;
using System.Globalization;

namespace ListViewProject
{
    public class ListViewDesigner : DataBoundControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            ListView control = Component as ListView;
            if (control != null)
            {
                if (control.ItemTemplate == null)
                {
                    return CreatePlaceHolderDesignTimeHtml("Please edit ItemTemplate");
                }
            }
            return base.GetDesignTimeHtml();
        }

        protected override bool UsePreviewControl
        {
            get
            {
                return true;
            }
        }
        


        #region Templates

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }

        TemplateGroupCollection _tempgc;
        public override TemplateGroupCollection TemplateGroups
        {
            get
            {
                if (_tempgc == null)
                {
                    _tempgc = base.TemplateGroups;
                    TemplateGroup templates = new TemplateGroup("ItemTemplate");
                    TemplateDefinition temp = new TemplateDefinition(this, "ItemTemplate",
                        Component, "ItemTemplate", false);
                    temp.SupportsDataBinding = true;
                    templates.AddTemplateDefinition(temp);
                    temp = new TemplateDefinition(this, "EditTemplate",
                        Component, "EditTemplate", false);
                    temp.SupportsDataBinding = true;
                    templates.AddTemplateDefinition(temp);
                    _tempgc.Add(templates);

                }
                return _tempgc;
            }
        }

        #endregion

        #region Auto schema

        protected override void OnSchemaRefreshed()
        {
            if (!base.InTemplateMode)
            {
                System.Web.UI.Design.ControlDesigner.InvokeTransactedChange(base.Component, new TransactedChangeCallback(this.SchemaRefreshedCallback), null, "SchemaRefreshedTransaction");
            }
        }

        private bool SchemaRefreshedCallback(object context)
        {
            IDataSourceViewSchema dataSourceSchema = this.GetDataSourceSchema();
            if ((base.DataSourceID.Length > 0) && (dataSourceSchema != null))
            {
                if (((((ListView)base.Component).DataKeyNames.Length > 0) || (((ListView)base.Component).ItemTemplate != null)) || (((ListView)base.Component).EditTemplate != null))
                {
                    if (DialogResult.Yes == ShowMessage(base.Component.Site,"����ListView��ģ��ͼ�", "�Ƿ����ListViewģ������ݼ������棺�⽫ɾ������ģ�塣", MessageBoxButtons.YesNo))
                    {
                        ((ListView)base.Component).DataKeyNames = new string[0];
                        this.AddTemplatesAndKeys(dataSourceSchema);
                    }
                }
                else
                {
                    this.AddTemplatesAndKeys(dataSourceSchema);
                }
            }
            else if ((((((ListView)base.Component).DataKeyNames.Length > 0) || (((ListView)base.Component).ItemTemplate != null)) || (((ListView)base.Component).EditTemplate != null)) && (DialogResult.Yes == ShowMessage(base.Component.Site, "����ListView��ģ��ͼ�", "�Ƿ����ListViewģ������ݼ������棺�⽫ɾ������ģ�塣", MessageBoxButtons.YesNo)))
            {
                ((ListView)base.Component).DataKeyNames = new string[0];
                ((ListView)base.Component).ItemTemplate = null;
                ((ListView)base.Component).EditTemplate = null;
            }
            this.UpdateDesignTimeHtml();
            return true;
        }

        private IDataSourceViewSchema GetDataSourceSchema()
        {
            DesignerDataSourceView designerView = base.DesignerView;
            if (designerView != null)
            {
                try
                {
                    return designerView.Schema;
                }
                catch (Exception exception)
                {
                    IComponentDesignerDebugService service = (IComponentDesignerDebugService)base.Component.Site.GetService(typeof(IComponentDesignerDebugService));
                    if (service != null)
                    {
                        service.Fail(exception.Message);
                    }
                }
            }
            return null;
        }


        private void AddTemplatesAndKeys(IDataSourceViewSchema schema)
        {
            StringBuilder editTemplateBuilder = new StringBuilder();
            StringBuilder itemTemplateBuilder = new StringBuilder();
            IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            if (schema != null)
            {
                //�õ����������ֶ�
                IDataSourceFieldSchema[] fields = schema.GetFields();
                if ((fields != null) && (fields.Length > 0))
                {
                    List<string> dataKeyList = new List<string>();
                    foreach (IDataSourceFieldSchema fieldSchema in fields)
                    {
                        string field = fieldSchema.Name;
                        char[] chArray = new char[field.Length];
                        //�����ֶ����е���Ч�ַ�
                        for (int i = 0; i < field.Length; i++)
                        {
                            char c = field[i];
                            if (char.IsLetterOrDigit(c) || (c == '_'))
                            {
                                chArray[i] = c;
                            }
                            else
                            {
                                chArray[i] = '_';
                            }
                        }
                        string fieldName = new string(chArray);
                        //�����ֶ�������Eval���ʽ
                        string evalExression = CreateEvalExpression(field, string.Empty);
                        //�����ֶ�������Bind���ʽ
                        string bindExpression = CreateBindExpression(field, string.Empty);
                        //�������������ֶ�����Lable��Bool���ͳ���CheckBox����������TextBox
                        if (fieldSchema.PrimaryKey || fieldSchema.Identity)
                        {
                            editTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}: <asp:Label Text='<%# {1} %>' runat=\"server\" id=\"{2}Label1\" /><br />", new object[] { field, evalExression, fieldName }));
                            itemTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}: <asp:Label Text='<%# {1} %>' runat=\"server\" id=\"{2}Label\" /><br />", new object[] { field, evalExression, fieldName }));
                            
                        }
                        else if (fieldSchema.DataType == typeof(bool))
                        {
                            editTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}: <asp:CheckBox Checked='<%# {1} %>' runat=\"server\" id=\"{2}CheckBox\" /><br />", new object[] { field, bindExpression, fieldName }));
                            itemTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}: <asp:CheckBox Checked='<%# {1} %>' runat=\"server\" id=\"{2}CheckBox\" Enabled=\"false\" /><br />", new object[] { field, bindExpression, fieldName }));
                             }
                        else
                        {
                            editTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}: <asp:TextBox Text='<%# {1} %>' runat=\"server\" id=\"{2}TextBox\" /><br />", new object[] { field, bindExpression, fieldName }));
                            itemTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}: <asp:Label Text='<%# {1} %>' runat=\"server\" id=\"{2}Label\" /><br />", new object[] { field, bindExpression, fieldName }));
                        }
                        editTemplateBuilder.Append(Environment.NewLine);
                        itemTemplateBuilder.Append(Environment.NewLine);
                        //��������ӵ�DataKeys�б�
                        if (fieldSchema.PrimaryKey)
                        {
                            dataKeyList.Add(field);
                        }
                    }
                    //EditTemplate����Update��Cancel��ť��ItemTemplate����Edit��ť
                    if (base.DesignerView.CanUpdate)
                    {
                        itemTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "<asp:LinkButton runat=\"server\" Text=\"{3}\" CommandName=\"{0}\" id=\"{1}{0}Button\" CausesValidation=\"{2}\" />", new object[] { "Edit", string.Empty, bool.FalseString, "�༭"}));
                    }
                    editTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "<asp:LinkButton runat=\"server\" Text=\"{3}\" CommandName=\"{0}\" id=\"{1}{0}Button\" CausesValidation=\"{2}\" />", new object[] { "Update", string.Empty, bool.TrueString, "����" }));
                    editTemplateBuilder.Append("&nbsp;");
                    editTemplateBuilder.Append(string.Format(CultureInfo.InvariantCulture, "<asp:LinkButton runat=\"server\" Text=\"{3}\" CommandName=\"{0}\" id=\"{1}{0}Button\" CausesValidation=\"{2}\" />", new object[] { "Cancel", string.Empty, bool.FalseString, "ȡ��" }));
                    
                    editTemplateBuilder.Append(Environment.NewLine);
                    itemTemplateBuilder.Append(Environment.NewLine);
                    //ͨ��ControlParser���ַ������Ϊģ�����
                    try
                    {
                        ((ListView)base.Component).EditTemplate = ControlParser.ParseTemplate(designerHost, editTemplateBuilder.ToString());
                        ((ListView)base.Component).ItemTemplate = ControlParser.ParseTemplate(designerHost, itemTemplateBuilder.ToString());
                    }
                    catch
                    {
                    }
                    int count = dataKeyList.Count;
                    if (count > 0)
                    {
                        ((ListView)base.Component).DataKeyNames = dataKeyList.ToArray();
                    }
                }
            }
        }



        static DialogResult ShowMessage(IServiceProvider serviceProvider, string message, string caption, MessageBoxButtons buttons)
        {
            if (serviceProvider != null)
            {
                IUIService service = (IUIService)serviceProvider.GetService(typeof(IUIService));
                if (service != null)
                {
                    return service.ShowMessage(message, caption, buttons);
                }
            }
            return DialogResult.No;
        }

        static string CreateBindExpression(string field, string format)
        {
            string text = field;
            bool flag = false;
            for (int i = 0; i < field.Length; i++)
            {
                char c = field[i];
                if ((!char.IsLetterOrDigit(c) && (c != '_')) && !flag)
                {
                    text = "[" + field + "]";
                    flag = true;
                }
            }
            if ((format != null) && (format.Length != 0))
            {
                return string.Format(CultureInfo.InvariantCulture, "Bind(\"{0}\", \"{1}\")", new object[] { text, format });
            }
            return string.Format(CultureInfo.InvariantCulture, "Bind(\"{0}\")", new object[] { text });
        }

        static string CreateEvalExpression(string field, string format)
        {
            string text = field;
            bool flag = false;
            for (int i = 0; i < field.Length; i++)
            {
                char c = field[i];
                if ((!char.IsLetterOrDigit(c) && (c != '_')) && !flag)
                {
                    text = "[" + field + "]";
                    flag = true;
                }
            }
            if ((format != null) && (format.Length != 0))
            {
                return string.Format(CultureInfo.InvariantCulture, "Eval(\"{0}\", \"{1}\")", new object[] { text, format });
            }
            return string.Format(CultureInfo.InvariantCulture, "Eval(\"{0}\")", new object[] { text });
        }

        #endregion

    }
}
