using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI;
using System.Web.UI.Design.WebControls.WebParts;
using System.ComponentModel;
using System.Web.UI.Design;

namespace WebPartLibrary
{
    public class HelpModeWebPartManager:WebPartManager
    {
        public static readonly HelpDisplayMode HelpDisplayMode = new HelpDisplayMode("Help");

        protected override WebPartDisplayModeCollection CreateDisplayModes()
        {
            WebPartDisplayModeCollection modes = base.CreateDisplayModes();
            modes.Add(HelpDisplayMode);
            return modes;
        }

        protected override void OnAuthorizeWebPart(WebPartAuthorizationEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.AuthorizationFilter))
            {
                bool authorized = false;
                string[] roles = e.AuthorizationFilter.Split(',');
                foreach (string role in roles)
                {
                    if (Page.User.IsInRole(role))
                    {
                        authorized = true;
                        break;
                    }
                }
                e.IsAuthorized = authorized;
            }
            base.OnAuthorizeWebPart(e);
        }
    }

    public class HelpDisplayMode : WebPartDisplayMode
    {
        public HelpDisplayMode(string name)
            : base(name)
        {
        }

        /// <summary>
        /// �ڴ�ģʽ�²������û����Ĳ���
        /// </summary>
        public override bool AllowPageDesign
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// ��ģʽ����Ҫ���Ի�֧��
        /// </summary>
        public override bool RequiresPersonalization
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// ��ģʽ�����صĲ���Ҳ��ʾ����
        /// </summary>
        public override bool ShowHiddenWebParts
        {
            get
            {
                return true;
            }
        }
    }

    [Designer(typeof(HelpZoneDesigner))]
    public class HelpZone : ToolZone
    {
        private string  _headerText = "����";

        public override string HeaderText
        {
            get { return _headerText; }
            set { _headerText = value; }
        }

        public string HelpMessage
        {
            get
            {
                if (ViewState["HelpMessage"] == null)
                    return string.Empty;
                return (string)ViewState["HelpMessage"];
            }
            set
            {
                ViewState["HelpMessage"] = value;
            }
        }

        public HelpZone()
            : base(HelpModeWebPartManager.HelpDisplayMode)
            //ָ������������ʲô��ʾģʽ����ʾ
        {
        }

        protected override void RenderBody(HtmlTextWriter writer)
        {
            writer.Write(HelpMessage);
        }

        protected override void Close()
        {
            WebPartManager.DisplayMode = WebPartManager.BrowseDisplayMode;
        }
    }

    public class HelpZoneDesigner : ToolZoneDesigner
    {
    }
}
