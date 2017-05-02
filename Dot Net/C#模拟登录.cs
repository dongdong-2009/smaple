public class WebAutoLogin
    {
        #region ����
        /// <summary>
        /// ��½�󷵻ص�Html
        /// </summary>
        public static string ResultHtml
        {
            get;
            set;
        }
        /// <summary>
        /// ��һ�������Url
        /// </summary>
        public static string RequestUrl
        {
            get;
            set;
        }
        /// <summary>
        /// ��Ҫ��Զ�̵����л�ȡCOOKIEһ��ҪΪrequest�趨һ��CookieContainer����װ�ط��ص�cookies
        /// </summary>
        public static CookieContainer CookieContainer
        {
            get;
            set;
        }
        /// <summary>
        /// Cookies �ַ���
        /// </summary>
        public static string CookiesString
        {
            get;
            set;
        }
        #endregion

        #region ����
        /// <summary>
        /// �û���½ָ������վ
        /// </summary>
        /// <param name="loginUrl"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public static void PostLogin(string loginUrl, string account, string password)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
 Element loginform = doc.getElementById("frmLogin");
         Elements inputElements = loginform.getElementsByTag("input");
         List<String> paramList = new ArrayList<String>();
         for (Element inputElement : inputElements) {
             String key = inputElement.attr("name");
             String value = inputElement.attr("value");
             if (key.equals("tbUserName"))
                 value = Test.Name;
             else if (key.equals("tbPassword"))
                 value = Test.passwd;
             paramList.add(key + "=" + URLEncoder.encode(value, "UTF-8"));
         }


                string postdata = "__VIEWSTATE=%2FwEPDwULLTE1MzYzODg2NzZkGAEFHl9fQ29udHJvbHNSZXF1aXJlUG9zdEJhY2tLZXlfXxYBBQtjaGtSZW1lbWJlcm1QYDyKKI9af4b67Mzq2xFaL9Bt";
                postdata += "&__EVENTVALIDATION=%2FwEdAAUyDI6H%2Fs9f%2BZALqNAA4PyUhI6Xi65hwcQ8%2FQoQCF8JIahXufbhIqPmwKf992GTkd0wq1PKp6%2B%2F1yNGng6H71Uxop4oRunf14dz2Zt2%2BQKDEIYpifFQj3yQiLk3eeHVQqcjiaAP";
                postdata += "&tbUserName=amingo&tbPassword=amingo";
                postdata += "&btnLogin=%E7%99%BB++%E5%BD%95";
                postdata +="&txtReturnUrl=http%3A%2F%2Fhome.cnblogs.com%2F";
                request = (HttpWebRequest)WebRequest.Create(loginUrl);//ʵ����web������  
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";//�����ύ��ʽΪPOST  
                request.ContentType = "application/x-www-form-urlencoded";    //ģ��ͷ  
                request.AllowAutoRedirect = false;   // �������Զ���ת
                //��������CookieContainer�洢���󷵻ص�Cookies
                if (CookieContainer != null)
                {
                    request.CookieContainer = CookieContainer;
                }
                else
                {
                    request.CookieContainer = new CookieContainer();
                    CookieContainer = request.CookieContainer;
                }
                request.KeepAlive = true;
                //�ύ����  
                byte[] postdatabytes = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabytes.Length;
                Stream stream;
                stream = request.GetRequestStream();
                //����POST ����
                stream.Write(postdatabytes, 0, postdatabytes.Length);
                stream.Close();
                //������Ӧ  
                response = (HttpWebResponse)request.GetResponse();
                //���淵��cookie  
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                CookieCollection cook = response.Cookies;
                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);
                CookiesString = strcrook;
                //ȡ��һ��GET��ת��ַ  
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd();
                sr.Close();
                request.Abort();
                response.Close();
                //���ݵ�½�ɹ��󷵻ص�Page��Ϣ������´������url
                //ÿ����վ��½����ص�Url��˳�򲻾���ͬ���������������ʵ����������⴦���Ӷ��õ��´������URL
                string[] substr = content.Split(new char[] { '"' });
                RequestUrl = substr[1];
            }
            catch (WebException ex)
            {
                //MessageBox.Show(string.Format("��½ʱ������ϸ��Ϣ��{0}", ex.Message));
            }
        }
        /// <summary>
        /// ��ȡ�û���½����һ�����󷵻ص�����
        /// </summary>
        public static void GetPage()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(RequestUrl);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "GET";
                request.KeepAlive = true;
                request.Headers.Add("Cookie:" + CookiesString);
                request.CookieContainer = CookieContainer;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                //����cookie  
                CookiesString = request.CookieContainer.GetCookieHeader(request.RequestUri);
                //ȡ�ٴ���ת����  
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string ss = sr.ReadToEnd();
                sr.Close();
                request.Abort();
                response.Close();
                //���ݵ�½�ɹ��󷵻ص�Page��Ϣ������´������url
                //ÿ����վ��½����ص�Url��˳�򲻾���ͬ���������������ʵ����������⴦���Ӷ��õ��´������URL
                string[] substr = ss.Split(new char[] { '"' });
                RequestUrl = substr[1];
                ResultHtml = ss;
            }
            catch (WebException ex)
            {
                //MessageBox.Show(string.Format("��ȡҳ��HTML��Ϣ������ϸ��Ϣ��{0}", ex.Message));
            }
        }
        #endregion

    }