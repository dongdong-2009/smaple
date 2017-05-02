using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MQTools
{
    public class MQTools:Label
    {
        #region Properties
        //TextBoxControlID
        public string TextBoxControlID
        {
            //在这里我们使用ViewState,是不想声明变量
            set {ViewState["TextBoxControlID"]=value;}
            get
            {
                string id = (string)ViewState["TextBoxControlID"];
                return id==null?string.Empty:id;
            }
        }
        public int WarningDisplayTime
        {
            get
            {
                object o = ViewState["WarningDisplayTime"];
                if (o != null && o is int)
                    return Convert.ToInt32(o);
                else
                    return 2500;
            }
            set
            {
                ViewState["WarningDisplayTime"] = value;
            }
        }
        #endregion

        #region 方法
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);            
            writer.AddStyleAttribute(HtmlTextWriterStyle.Visibility, "hidden");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
        }
        protected override void OnPreRender(EventArgs e)
        {
           

            if (this.Enabled)
            {
                // (1) 注册客户端脚本
                Page.ClientScript.RegisterClientScriptInclude("MQTools",
                Page.ClientScript.GetWebResourceUrl(this.GetType(),
                                            "MQTools.JsLib.js"));                
                // (2) Call CheckCapsLock
                TextBox tb = GetTextBoxControl();
                
               tb.Attributes.Add("onkeypress", string.Format("CheckCapsLock(event, '{0}', {1});", this.ClientID, this.WarningDisplayTime));
               
            }
            base.OnPreRender(e);
        }

        //获得页面上的输入框控件
        protected  TextBox GetTextBoxControl()
        {
            if (string.IsNullOrEmpty(this.TextBoxControlID))
                throw new HttpException(string.Format("You must provide a value for the TextBoxControlId property for the mqTool control with ID '{0}'.", this.ID));

            TextBox tb = this.FindControl(this.TextBoxControlID) as TextBox;
            if (tb == null)
                throw new HttpException(string.Format("The  control with ID '{0}' could not find a TextBox control with the ID '{1}'.", this.ID, this.TextBoxControlID));

            return tb;
        }

        #endregion
    }
}
