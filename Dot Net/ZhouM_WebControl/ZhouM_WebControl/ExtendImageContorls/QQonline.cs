using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ZhouM_WebControl
{
    public class QQonline : ExtendImageButton
    {
        /// <summary>
        /// Ҫ��ϵ��QQ��
        /// </summary>
        private string qq;
        public string QQ
        {
            get { return qq; }
            set { qq = value; }
        }


        private const string defaultImageURL = "http://wpa.qq.com/pa?p=1:31767702:13";//13����ͼƬ���͹���1-13��ѡ��
        private string imageUrl = defaultImageURL;                                      

        //�����½��ĵ�ַ
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
                throw new Exception("������QQ�š�");
            }

            base.OnLoad(e);

            this.PostBackUrl = "tencent://message/?uin=" + QQ + "&site=http://google.com&menu=yes";
            //this.Attributes.Add("onclick", "window.open('tencent://message/?uin="+QQ+"&site=http://google.com&menu=yes')"); //���õ����¼�
            //this.Attributes.Add("onmouseover", "this.style.cursor='pointer';");
        }
    }
}
