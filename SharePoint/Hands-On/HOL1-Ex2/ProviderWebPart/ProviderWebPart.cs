using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;

namespace HOL1_Ex2.ProviderWebPart
{
    [ToolboxItemAttribute(false)]
    public class ProviderWebPart : Microsoft.SharePoint.WebPartPages.WebPart, IProject
    {
        DropDownList _projectPicker = null;

        protected override void CreateChildControls()
        {   
            base.CreateChildControls();
            try 
            { 
                _projectPicker = new DropDownList();
                using (SPSite spSite = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        SPList projectsList = spWeb.Lists["WorkSummary"];
                        foreach (SPListItem project in projectsList.Items)
                        {
                            _projectPicker.Items.Add(new ListItem(project.Title, project.ID.ToString()));
                        }
                    }
                }
                _projectPicker.AutoPostBack = true; 
                this.Controls.Add(_projectPicker);                
            }
            catch (Exception ex) 
            { 
                this.Controls.Clear(); 
                this.Controls.Add(new LiteralControl(ex.Message)); 
            }
        }

        [ConnectionProvider("Project Name and ID")]
        public IProject NameDoesNotMatter() 
        { 
            return this; 
        }      


        public int Id
        {
            get 
            {
                return int.Parse(_projectPicker.SelectedValue);
            }
        }

        public string Name
        {
            get 
            {
                return _projectPicker.SelectedItem.Text;
            }
        }


        public Control AsyncTrigger
        {
            get 
            {
                EnsureChildControls();
                return  _projectPicker; 
            }
        }
    }
}
