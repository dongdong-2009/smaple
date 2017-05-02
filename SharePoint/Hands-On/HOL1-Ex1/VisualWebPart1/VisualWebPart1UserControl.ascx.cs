using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint.Linq;
using Microsoft.SharePoint;
using System.Linq;

//set path=%path%;c:\program files\common files\microsoft shared\web server extensions\14\bin
//spmetal.exe /web:http://jeff/zhou /namespace:HOL1_Ex1.VisualWebPart1 /code:SPLinq.cs

namespace HOL1_Ex1.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPLinqDataContext dc = new SPLinqDataContext(SPContext.Current.Web.Url);
            EntityList<WorkSummaryItem> WorkSummary = dc.GetList<WorkSummaryItem>("WorkSummary");
            var WorkSummaryQuery = from item in WorkSummary
                                   select new { 
                                       item.Title,
                                       ApproverTitle = item.ApproverTitle.First()
                                   };

            spGridView.DataSource = WorkSummaryQuery;
            spGridView.DataBind();         
            
        }

        public string LabelText
        {
            get
            {
                return lbl.Text;
            }
            set
            {
                lbl.Text = value;
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            lbl.Text = peopleEditor.Accounts[0].ToString();
        }
    }
}
