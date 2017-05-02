using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;
using System.Data;

namespace HOL1_Ex2.ConsumerWebPart
{
     // out of box Template ?
     public class ProgressTemplate:ITemplate 
     {
         private string template;
         public ProgressTemplate(string temp) 
         { 
             template = temp; 
         }

         public void InstantiateIn(Control container)
         {
             LiteralControl ltr = new LiteralControl(this.template);
             container.Controls.Add(ltr);
         }  
     }

    [ToolboxItemAttribute(false)]
    public class ConsumerWebPart : Microsoft.SharePoint.WebPartPages.WebPart
    {
        IProject _provider = null; 
        Label _lbl = null;
        UpdatePanel updatePanel;
        UpdateProgress updateProgress;
        protected override void CreateChildControls()
        {
            updatePanel = new UpdatePanel();
            updateProgress = new UpdateProgress();
            updateProgress.AssociatedUpdatePanelID = updatePanel.ID;
            string templateHTML = "<div><img alt=\"Loading...\" src=\'~/_layouts/images/loader.gif''/>Loading...</div>";

            this.updateProgress.ProgressTemplate = new ProgressTemplate(templateHTML);

            this.Controls.Add(updatePanel);
            this.Controls.Add(updateProgress);
            base.CreateChildControls();
        }


        protected override void OnPreRender(EventArgs e)
        {            
            if (this._provider != null)
            {
                ScriptManager scriptManager =  ScriptManager.GetCurrent(this.Page);
                if (scriptManager != null)
                {
                    scriptManager.RegisterAsyncPostBackControl(_provider.AsyncTrigger);
                }
            }
            ShowInfo();
            base.OnPreRender(e);
        }

        private void ShowInfo()
        {
            try
            {
                _lbl = new Label();
                if (_provider != null)
                {
                    if (_provider.Id > 0)
                    {
                        _lbl.Text = _provider.Name + " was selected.";
                    }
                    else
                    {
                        _lbl.Text = "Nothing was selected.";
                    }
                }
                else
                {
                    _lbl.Text = "No Provider Web Part Connected.";
                }

                if (updatePanel != null)
                {
                    updatePanel.ContentTemplateContainer.Controls.Add(_lbl);
                }
            }
            catch (Exception ex)
            {
                this.Controls.Clear();
                this.Controls.Add(new LiteralControl(ex.Message));
            }
        }

        [ConnectionConsumer("Project Name and ID")]
        public void ThisNameDoesNotMatter(IProject providerInterface)
        {
            _provider = providerInterface;
        }

      
    }
}
