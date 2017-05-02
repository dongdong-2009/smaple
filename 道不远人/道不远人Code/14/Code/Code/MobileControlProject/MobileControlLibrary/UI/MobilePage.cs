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
    /// WML页面
    /// </summary>
    public class MobilePage:Page
    {
        #region viewstate persistence

        SessionPageStatePersister _persister;
        /// <summary>
        /// 替换页面状态持久器，
        /// 将视图状态等持久化到Session中
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
                //要求处理视图状态
                RegisterViewStateHandler();
            }
        }

        #endregion

        #region child controls

        private Template _template;

        /// <summary>
        /// 由于WML中元素的位置不能随意摆放
        /// 比如Template必须放在Card之前
        /// 所以用属性专门引用Template和Cards
        /// 以便解决顺序的问题
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
        /// 限制Page只接收Template、Card和Literal作为子控件
        /// </summary>
        /// <param name="obj"></param>
        protected override void AddParsedSubObject(object obj)
        {
            if (obj is Template || obj is Card || obj is Literal || obj is LiteralControl)
            {
                Template template = obj as Template;
                //一个WML页面只能有一个Template，而且必须在所有Card之前
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
                            throw new ArgumentException("Template必须位于Card之前");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("一个页面中只能有一个Template");
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
        /// 将呈现过程中使用的HtmlTextWriter替换成WMLTextWriter
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
        /// 提供FormFields和RegisterFormFieldControl()
        /// 统一管理所有表单域对象，包括Input和Select等
        /// 便于将表单域组织成PostField注册到Go中
        /// 实现ASP.NET表单回传编程模型
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
        /// 注册WML表单域
        /// </summary>
        /// <param name="control"></param>
        public void RegisterFormFieldControl(FormFiledControl control)
        {
            FormFields.Add(control);
        }

        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            //如果启用Trace，还是可以用IE查看Trace
            if (!Trace.IsEnabled)
            {
                Response.ContentType = "text/vnd.wap.wml;charset=utf-8";
                base.RenderChildren(writer);
            }
        }

        /// <summary>
        /// 因为默认的DeterminePostBackMode()
        /// 需要检查__VIEWSTATE等表单域，所以需要重写
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
