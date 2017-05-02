using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using MobileControlLibrary.UI.Controls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;

namespace MobileControlLibrary.UI
{
    /// <summary>
    /// WMLҳ��
    /// </summary>
    public class MobilePage:Page
    {
        #region viewstate persistence

        SessionPageStatePersister _persister;
        /// <summary>
        /// �滻ҳ��״̬�־�����
        /// ����ͼ״̬�ȳ־û���Session��
        /// </summary>
        protected override PageStatePersister PageStatePersister
        {
            get
            {
                if (_persister == null)
                    _persister = new SessionPageStatePersister(this);
                return _persister;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (IsPostBack)
            {
                //Ҫ������ͼ״̬
                RegisterViewStateHandler();
            }
        }

        #endregion

        #region child controls

        private Template _template;

        /// <summary>
        /// ����WML��Ԫ�ص�λ�ò�������ڷ�
        /// ����Template�������Card֮ǰ
        /// ����������ר������Template��Cards
        /// �Ա���˳�������
        /// </summary>
        public Template Template
        {
            get { return _template; }
            set { _template = value; }
        }

        private CardCollection _cards = new CardCollection();

        public CardCollection Cards
        {
            get { return _cards;}
        }

        /// <summary>
        /// ����Pageֻ����Template��Card��Literal��Ϊ�ӿؼ�
        /// </summary>
        /// <param name="obj"></param>
        protected override void AddParsedSubObject(object obj)
        {
            if (obj is Template || obj is Card || obj is Literal || obj is LiteralControl)
            {
                Template template = obj as Template;
                //һ��WMLҳ��ֻ����һ��Template�����ұ���������Card֮ǰ
                if (template != null)
                {
                    if (Template == null)
                    {
                        if (Cards.Count == 0)
                        {
                            Template = template;
                            Controls.Add(template);
                            return;
                        }
                        else
                        {
                            throw new ArgumentException("Template����λ��Card֮ǰ");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("һ��ҳ����ֻ����һ��Template");
                    }
                }

                Card c = obj as Card;
                if (c != null)
                {
                    Controls.Add(c);
                    Cards.Add(c);
                    return;
                }

                base.AddParsedSubObject(obj);
            }
        }

        #endregion


        #region writer

        /// <summary>
        /// �����ֹ�����ʹ�õ�HtmlTextWriter�滻��WMLTextWriter
        /// </summary>
        /// <param name="tw"></param>
        /// <returns></returns>
        protected override HtmlTextWriter CreateHtmlTextWriter(System.IO.TextWriter tw)
        {
            return new WmlTextWriter(tw);
        }

        #endregion

        #region form fields

        /// <summary>
        /// �ṩFormFields��RegisterFormFieldControl()
        /// ͳһ�������б�����󣬰���Input��Select��
        /// ���ڽ�������֯��PostFieldע�ᵽGo��
        /// ʵ��ASP.NET���ش����ģ��
        /// </summary>
        public FormFieldControlCollection FormFields
        {
            get
            {
                if(Items[typeof(FormFiledControl)] == null)
                    Items[typeof(FormFiledControl)] = new FormFieldControlCollection();
                return Items[typeof(FormFiledControl)] as FormFieldControlCollection;
            }
        }

        /// <summary>
        /// ע��WML����
        /// </summary>
        /// <param name="control"></param>
        public void RegisterFormFieldControl(FormFiledControl control)
        {
            FormFields.Add(control);
        }

        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            //�������Trace�����ǿ�����IE�鿴Trace
            if (!Trace.IsEnabled)
            {
                Response.ContentType = "text/vnd.wap.wml;charset=utf-8";
                base.RenderChildren(writer);
            }
        }

        /// <summary>
        /// ��ΪĬ�ϵ�DeterminePostBackMode()
        /// ��Ҫ���__VIEWSTATE�ȱ���������Ҫ��д
        /// </summary>
        /// <returns></returns>
        protected override NameValueCollection DeterminePostBackMode()
        {
            if (Request == null)
            {
                return null;
            }
            return GetCollectionBasedOnMethod();
        }
        
        NameValueCollection GetCollectionBasedOnMethod()
        {
            if (string.Equals(Request.HttpMethod,"POST",StringComparison.OrdinalIgnoreCase))
            {
                return this.Request.Form;
            }
            else
            {
                return this.Request.QueryString;
            }
        }
    }
}
