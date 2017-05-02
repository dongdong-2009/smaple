using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using TemplatedControls;

public partial class TestDefaultBookInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/books.xml"));
            XmlNodeList books = doc.SelectNodes("//book");
            XmlNode book = books[1];
            BookData data = new BookData();
            data.ISBN = book.Attributes["isbn"].Value;
            data.Title = book.FirstChild.InnerText;
            data.Author = book.ChildNodes[1].InnerText;
            data.Publisher = book.ChildNodes[2].InnerText;
            data.Description = book.ChildNodes[3].InnerText;
            this.DefaultBookInfo1.DataItem = data;
            this.DefaultBookInfo1.DataBind();
        }
    }
}
