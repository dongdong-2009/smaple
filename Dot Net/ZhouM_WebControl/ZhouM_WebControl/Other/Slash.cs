using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

[assembly: WebResource("ZhouM_WebControl.Common.js", "application/x-javascript")]
[assembly: WebResource("ZhouM_WebControl.Other.Slash.js", "application/x-javascript")]
//ʹ�øÿؼ�����ȥ��ҳ���ϵ�
//<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
//Ѱ��������


//�����ؼ������ʱ����ۣ�����ƴ����˲��㣬�д��Ľ���
namespace ZhouM_WebControl
{
    
    public class Slash:BaseContorl
    {
        /// <summary>
        /// Ҫ����б�ߵĿؼ��Ŀͻ���ID
        /// </summary>
        private string controlClientID;
        public string ControlClientID
        {
            get { return controlClientID; }
            set { controlClientID = value; }
        }

        /// <summary>
        /// ��ɫ
        /// </summary>
        private string colorCode;
        public string ColorCode
        {
            get { return colorCode; }
            set { colorCode = value; }
        }

        private string border;

        public string Border
        {
            get { return border; }
            set { border = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (ControlClientID == null || ControlClientID.Trim() == string.Empty)
            {
                throw new Exception("����ControlClientIDδ��ֵ��");
            }

            if (ColorCode == null || ColorCode.Trim() == string.Empty)
            {
                throw new Exception("����ColorCodeδ��ֵ��");
            }

            base.OnInit(e);           
            base.Page.ClientScript.RegisterClientScriptResource(this.GetType(), "ZhouM_WebControl.Common.js");
            base.Page.ClientScript.RegisterClientScriptResource(this.GetType(), "ZhouM_WebControl.Other.Slash.js");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.Page.ClientScript.RegisterStartupScript(this.GetType(), ControlClientID, "line_laodongjie('" + ControlClientID + "','" + ColorCode + "','" + Border + "')", true);
        }
    }
}