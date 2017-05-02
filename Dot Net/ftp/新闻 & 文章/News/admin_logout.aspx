<%@ Import Namespace="System.Web" %>
<script Language="C#" runat=server>
void Page_Load(object serder,EventArgs E){
	string cpath = Request.Url.AbsolutePath;
	cpath = cpath.Substring(0,cpath.LastIndexOf("/")+1);
	HttpCookie myCookie=new HttpCookie("news_admin");
	myCookie.Path=cpath;
	myCookie.Expires=DateTime.Now.AddHours(-1);
	Response.Cookies.Add(myCookie);
	Response.Redirect ("default.aspx");
	}
</script>