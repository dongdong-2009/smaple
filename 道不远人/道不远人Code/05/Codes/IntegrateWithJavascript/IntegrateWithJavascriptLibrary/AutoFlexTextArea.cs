using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

namespace IntegrateWithJavascriptLibrary
{
    public class AutoFlexTextArea:TextBox
    {
        bool _supportJS;
        const string AUTOFLEXJS = @"
    function AutoFlex(id,maxHeight){
        this._id = id;
        this.maxHeight = maxHeight;
    }
    AutoFlex.prototype._onPropertyChange = function(){
        if(this.maxHeight){
            this._element.style.height =
             ( this._element.scrollHeight > this.maxHeight ) ? this.maxHeight : 
                this._element.scrollHeight + ( this._element.offsetHeight - this._element.clientHeight );          
        }
        else{
            this._element.style.height = this._element.scrollHeight 
                + ( this._element.offsetHeight - this._element.clientHeight );
        }  
    }
    AutoFlex.prototype._getPropertyChangeHandler = function(){
        var obj = this;
        return function (){
            obj._onPropertyChange.call(obj);
        }
    }
    AutoFlex.prototype.initiate = function(){
        this._element = document.getElementById(this._id);
        if(this._element){
            this._element.onpropertychange = this._getPropertyChangeHandler();
        }
    }";

        [DefaultValue(0)]
        [Category("Behavior")]
        [Description("最大伸展高度")]
        public int MaxHeight
        {
            get
            {
                if (ViewState["MaxHeight"] == null)
                {
                    return 0;
                }
                return (int)ViewState["MaxHeight"];
            }
            set
            {
                ViewState["MaxHeight"] = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override TextBoxMode TextMode
        {
            get
            {
                return TextBoxMode.MultiLine;
            }
            set
            {
                throw new NotSupportedException("Can not change the TextMode property");
            }
        }

        void DetermineJS()
        {
            if (!DesignMode)
            {
                if (Page.Request.Browser.EcmaScriptVersion.Major > 0 && Page.Request.Browser.W3CDomVersion.Major > 0)
                {
                    this._supportJS = true;
                }
            }
        }
        

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            DetermineJS();
            if (_supportJS)
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(),"AUTOFLEXJS"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AUTOFLEXJS", AUTOFLEXJS, true);
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            if (_supportJS)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), this.UniqueID,
                    string.Format("    var {0}_AutoFlex = new AutoFlex('{0}',{1});\r\n    {0}_AutoFlex.initiate();\r\n",
                    this.UniqueID,this.MaxHeight.ToString()), true);
            }
        }
    }
}
