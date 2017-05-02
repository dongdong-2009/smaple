public class WebAutoLogin
    {
        #region 属性
        /// <summary>
        /// 登陆后返回的Html
        /// </summary>
        public static string ResultHtml
        {
            get;
            set;
        }
        /// <summary>
        /// 下一次请求的Url
        /// </summary>
        public static string RequestUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 若要从远程调用中获取COOKIE一定要为request设定一个CookieContainer用来装载返回的cookies
        /// </summary>
        public static CookieContainer CookieContainer
        {
            get;
            set;
        }
        /// <summary>
        /// Cookies 字符创
        /// </summary>
        public static string CookiesString
        {
            get;
            set;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 用户登陆指定的网站
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
                request = (HttpWebRequest)WebRequest.Create(loginUrl);//实例化web访问类  
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";//数据提交方式为POST  
                request.ContentType = "application/x-www-form-urlencoded";    //模拟头  
                request.AllowAutoRedirect = false;   // 不用需自动跳转
                //必须设置CookieContainer存储请求返回的Cookies
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
                //提交请求  
                byte[] postdatabytes = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabytes.Length;
                Stream stream;
                stream = request.GetRequestStream();
                //设置POST 数据
                stream.Write(postdatabytes, 0, postdatabytes.Length);
                stream.Close();
                //接收响应  
                response = (HttpWebResponse)request.GetResponse();
                //保存返回cookie  
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                CookieCollection cook = response.Cookies;
                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);
                CookiesString = strcrook;
                //取下一次GET跳转地址  
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd();
                sr.Close();
                request.Abort();
                response.Close();
                //依据登陆成功后返回的Page信息，求出下次请求的url
                //每个网站登陆后加载的Url和顺序不尽相同，以下两步需根据实际情况做特殊处理，从而得到下次请求的URL
                string[] substr = content.Split(new char[] { '"' });
                RequestUrl = substr[1];
            }
            catch (WebException ex)
            {
                //MessageBox.Show(string.Format("登陆时出错，详细信息：{0}", ex.Message));
            }
        }
        /// <summary>
        /// 获取用户登陆后下一次请求返回的内容
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
                //设置cookie  
                CookiesString = request.CookieContainer.GetCookieHeader(request.RequestUri);
                //取再次跳转链接  
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string ss = sr.ReadToEnd();
                sr.Close();
                request.Abort();
                response.Close();
                //依据登陆成功后返回的Page信息，求出下次请求的url
                //每个网站登陆后加载的Url和顺序不尽相同，以下两步需根据实际情况做特殊处理，从而得到下次请求的URL
                string[] substr = ss.Split(new char[] { '"' });
                RequestUrl = substr[1];
                ResultHtml = ss;
            }
            catch (WebException ex)
            {
                //MessageBox.Show(string.Format("获取页面HTML信息出错，详细信息：{0}", ex.Message));
            }
        }
        #endregion

    }