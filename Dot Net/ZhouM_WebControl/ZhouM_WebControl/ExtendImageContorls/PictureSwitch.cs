//===============================================================================
// 创建者: ZhouMing
// 功能描述:
// 最后修改日期:2007-10-13
// 联系方式:QQ(31767702) dpzhoum@dfl.com.cn
// 待解决的问题:生成的Html代码中含有Items-Capacity属性　
//===============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.Design;

namespace ZhouM_WebControl
{
    public class PicItem
    {
        private string picUrl;
        [Description("图片路径")]
        public string PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }

        private string navigateUrl;
        [Description("链接路径")]
        public string NavigateUrl
        {
            get { return navigateUrl; }
            set { navigateUrl = value; }
        }

        private string des;
        [Description("描述信息")]
        public string PicDes
        {
            get { return des; }
            set { des = value; }
        }

        public PicItem() { }
        public PicItem(string picUrl, string navigateUrl, string des)
        {
            this.picUrl = picUrl;
            this.navigateUrl = navigateUrl;
            this.des = des;
        }
    }

    class MyCollectionEditor : CollectionEditor
    {

        public MyCollectionEditor(Type type): base(type)
        {
            
        }

        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

        protected override System.Type CreateCollectionItemType()
        {
            return typeof(PicItem);
        }


        protected override string GetDisplayText(object value)
        {
            return "PicItem";
        }
    }


    [ParseChildren(true,"Items")]
    public class PictureSwitch : ExtendImage
    {
        public PictureSwitch()
        {
            items = new List<PicItem>();
        }

        #region Property
        private const int defaultDuration = 3500;
        private int duration = defaultDuration;        
        [Category("Settings")]
        [DefaultValue(defaultDuration)]
        [Description("图片持续时间(单位：毫秒)")]
        public int Duration
        {
            get { return duration; }
            set 
            {
                if (value > 0)
                {
                    duration = value;
                }
                else
                {
                    duration = 3500;
                }
            }
        }

        private const int defaultSwitchTime = 2000;
        private int switchTime = defaultSwitchTime;
        [Category("Settings")]
        [Description("图片轮换过程中所需要的时间(单位：毫秒)")]
        [DefaultValue(defaultSwitchTime)]        
        public int SwitchTime
        {
            get { return switchTime; }
            set 
            {
                if (value > 0)
                {
                    switchTime = value;
                }
                else
                {
                    switchTime = 2000;
                }
            }
        }

        private List<PicItem> items;
        [Browsable(true)]
        [Category("Settings")]        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
        [Editor(typeof(MyCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public List<PicItem> Items
        {
            get 
            {
                if (items == null)
                {
                    items = new List<PicItem>();
                }
                return items;  
            }
            //set { items = value; }
        }	
        #endregion

        #region 加载
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);            
            RegisterJavascript();
            #region 设置控件样式
            this.Style.Add("border", "0");
            this.Style.Add("cursor", "hand");
            this.Style.Add("FILTER", "revealTrans(duration="+ SwitchTime/1000 +",transition=23)");            
            this.ImageUrl = Items[0].PicUrl;            
            #endregion

            #region 注册控件事件
            //this.Attributes.Add("onmouseover", "displayStatusMsg_" + this.ClientID + "();");//return document.returnValue;
            this.Attributes.Add("onclick", "jump2url_" + this.ClientID + "();");
            #endregion
        }
        #endregion

        #region 注册js
        private void RegisterJavascript()
        {
                StringBuilder s = new StringBuilder("");
                
                s.Append(@"<script type='text/javascript' defer='defer'>
                    %bannerAD%=new Array(); 
                    %bannerADlink%=new Array();
                    %bannerADTip%=new Array();
                    %adNum%=0;");

                for (int i = 0; i < Items.Count; i++)
                {
                    s.AppendLine("%bannerAD%["+i.ToString()+"]='"+Items[i].PicUrl+"';");
                    s.AppendLine("%bannerADlink%[" + i.ToString() + "]='" + Items[i].NavigateUrl + "';");
                    s.AppendLine("%bannerADTip%[" + i.ToString() + "]='" + Items[i].PicDes + "';");
                }

                    s.AppendLine(@"%preloadedimages%=new Array();
                    %bannerADrotator% = document.getElementById('" + this.ClientID + "');"
                        + @"for (i=0;i<%bannerAD%.length;i++)
                    { 
                        %preloadedimages%=new Image(); 
                        %preloadedimages%.src=%bannerAD%; 
                    } 
                          
                    function %setTransition%()
                    {
                        try
                        {
                            if(%bannerADrotator%.filters != null)
                            {
                                %bannerADrotator%.filters.revealTrans.Transition=Math.floor(Math.random()*23); 
                                %bannerADrotator%.filters.revealTrans.apply(); 
                            }
                        }
                        catch(err){}
                    } 
                          
                    function %playTransition%()
                    {     
                        try
                        {
                            if(%bannerADrotator%.filters != null)
                            {
                                %bannerADrotator%.filters.revealTrans.play();
                            }
                        }
                        catch(err){}
                    } 
                          
                    function %nextAd%()
                    { 
                        if(%adNum%<%bannerAD%.length-1)
                        {
                            %adNum%++ ; 
                        }
                        else 
                        {
                            %adNum%=0; 
                        }
                        
                        %setTransition%();                                                   
                        %bannerADrotator%.src=%bannerAD%[%adNum%];                         
                        %playTransition%(); 
                        var theTimer=setTimeout('%nextAd%()', " + Duration + ");"
                       + @" }                          
                    function %jump2url%()
                    { 
                        var jumpUrl=%bannerADlink%[%adNum%]; 
                        var jumpTarget='_blank'; 
                        if (jumpUrl != '')
                        { 
                            if (jumpTarget != '')
                            {
                                window.open(jumpUrl,jumpTarget); 
                            }
                            else
                            { 
                                location.href=jumpUrl; 
                            }
                        } 
                    } 

                    function %displayStatusMsg%() 
                    { 
                        window.status=%bannerADlink%[%adNum%];
                        %bannerADrotator%.title=%bannerADTip%[%adNum%];
                        document.returnValue = true; 
                    }
                    %nextAd%();
                    </script>
            ");
                string str = s.ToString();
                str = str.Replace("%bannerAD%", "bannerAD_"+this.ClientID);
                str = str.Replace("%bannerADlink%", "bannerADlink_" + this.ClientID);
                str = str.Replace("%adNum%", "adNum" + this.ClientID);
                str = str.Replace("%preloadedimages%", "preloadedimages_" + this.ClientID);
                str = str.Replace("%bannerADrotator%", "bannerADrotator_" + this.ClientID);
                str = str.Replace("%setTransition%", "setTransition_" + this.ClientID);
                str = str.Replace("%playTransition%", "playTransition_" + this.ClientID);
                str = str.Replace("%nextAd%", "nextAd_" + this.ClientID);
                str = str.Replace("%jump2url%", "jump2url_" + this.ClientID);
                str = str.Replace("%displayStatusMsg%", "displayStatusMsg_" + this.ClientID);                
                str = str.Replace("%bannerADTip%", "bannerADTip_" + this.ClientID);
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PictureSwitch_"+this.ClientID, str, false);
            }
        #endregion

        //protected override void RenderContents(HtmlTextWriter output)
        //{            
        //    output.Write(Text);
        //}
    }
}