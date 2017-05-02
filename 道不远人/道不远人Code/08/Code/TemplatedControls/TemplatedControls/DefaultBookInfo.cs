using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace TemplatedControls
{
    public class DefaultBookInfo:BookInfo
    {
        protected override void CreateChildControls()
        {
            if (ItemTemplate == null)
            {
                ItemTemplate = new BookInfoDefaultTemplate();
            }
            ItemTemplate.InstantiateIn(this);
        }
    }

    public class BookInfoDefaultTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            HtmlGenericControl divContainer = new HtmlGenericControl("div");
            divContainer.Attributes["class"] = "bookContainer";
            container.Controls.Add(divContainer);
            Image img = new Image();
            img.ID = "imgBook";
            img.CssClass = "bookCover";
            img.DataBinding += new EventHandler(img_DataBinding);
            divContainer.Controls.Add(img);
            HtmlGenericControl divContent = new HtmlGenericControl("div");
            divContent.Attributes["class"] = "bookContent";
            divContainer.Controls.Add(divContent);
            HtmlGenericControl h3 = new HtmlGenericControl("h3");
            divContent.Controls.Add(h3);
            Literal ltlTitle = new Literal();
            ltlTitle.DataBinding += new EventHandler(ltlTitle_DataBinding);
            h3.Controls.Add(ltlTitle);
            Literal ltlContent = new Literal();
            divContent.Controls.Add(ltlContent);
            ltlContent.DataBinding += new EventHandler(ltlContent_DataBinding);
            HtmlGenericControl divPublisher = new HtmlGenericControl("div");
            divPublisher.Attributes["class"] = "bookPublisher";
            divContent.Controls.Add(divPublisher);
            Literal ltlPublisher = new Literal();
            ltlPublisher.DataBinding += new EventHandler(ltlPublisher_DataBinding);
            divPublisher.Controls.Add(ltlPublisher);
        }

        void ltlPublisher_DataBinding(object sender, EventArgs e)
        {
            Literal ltl = (Literal)sender;
            DefaultBookInfo container = (DefaultBookInfo)ltl.NamingContainer;
            ltl.Text = container.DataItem.Publisher;
        }

        void ltlContent_DataBinding(object sender, EventArgs e)
        {

            Literal ltl = (Literal)sender;
            DefaultBookInfo container = (DefaultBookInfo)ltl.NamingContainer;
            ltl.Text = "Written by:" + container.DataItem.Author + "<br/>ISBN:#" + container.DataItem.ISBN;
            
        }

        void ltlTitle_DataBinding(object sender, EventArgs e)
        {
            Literal ltl = (Literal)sender;
            DefaultBookInfo container = (DefaultBookInfo)ltl.NamingContainer;
            ltl.Text = container.DataItem.Title;
        }

        void img_DataBinding(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            DefaultBookInfo container = (DefaultBookInfo)img.NamingContainer;
            img.AlternateText = container.DataItem.Title;
            img.ImageUrl = "~/images/" + container.DataItem.ISBN + ".png";
        }

    }
}
