using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ZhouM_WebControl
{
    public class QQonline : ExtendImageButton
    {
        /// <summary>
        /// 要联系的QQ号
        /// </summary>
        private string qq;
        public string QQ
        {
            get { return qq; }
            set { qq = value; }
        }


        private const string defaultImageURL = "http://wpa.qq.com/pa?p=1:31767702:13";//13代表图片类型共有1-13可选。
        private string imageUrl = defaultImageURL;                                      

        //设置新建的地址
        [DefaultValue(defaultImageURL)]
        public override string ImageUrl
        {
            get
            {
                return imageUrl;
            }
            set
            {
                imageUrl = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (QQ == null || QQ.Trim() == string.Empty)
            {
                throw new Exception("请输入QQ号。");
            }

            base.OnLoad(e);

            this.PostBackUrl = "tencent://message/?uin=" + QQ + "&site=http://google.com&menu=yes";
            //this.Attributes.Add("onclick", "window.open('tencent://message/?uin="+QQ+"&site=http://google.com&menu=yes')"); //设置单击事件
            //this.Attributes.Add("onmouseover", "this.style.cursor='pointer';");
        }
    }
}
