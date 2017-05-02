///--------------------------------------------------------------------------------///
///-- WSS v3 Event Handler Explorer                                              --///
///-- Demoware created by Patrick Tisseghem (U2U)                                --///
///-- patrick@u2u.be - http://blog.u2u.info/dottextweb/patrick                   --///
///-- This is a small application demonstrating how developers can retrieve      --///
///-- information regarding the event handlers associated with the various       --///
///-- types in the WSS object model. Additionally, you can register and          --///
///-- unregister event handlers.                                                 --///
///--------------------------------------------------------------------------------///
///-- You can freely use this application but remember this was created with the --///
///-- the purpose of demonstrating the concept of event handlers in WSS v3       --///
///-- and is not tested for other uses                                           --///
///--------------------------------------------------------------------------------///

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EventHandlerExplorer
{
    public partial class FormMain : Form
    {

        private SPSite site = null;

        public FormMain()
        {
            InitializeComponent();            
        }

        private void buttonExplore_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.site = new SPSite(textBoxSiteCollectionURL.Text);
                textBoxAssemlby.Text = string.Empty;
                comboBoxClasses.Items.Clear();
                textBoxSequence.Text = string.Empty;
                comboBoxEventType.SelectedIndex = -1;
                FillTree();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FillTree()
        {

            treeViewItems.Nodes.Clear();
            TreeNode siteCollectionNode = treeViewItems.Nodes.Add(site.Url);
            siteCollectionNode.ImageIndex = 2;
            siteCollectionNode.SelectedImageIndex = 2;

          
            //-- add individual sites
            TreeNode sitesNode = siteCollectionNode.Nodes.Add("Sites");


            foreach (SPWeb web in site.AllWebs)
            {
                TreeNode node = sitesNode.Nodes.Add(web.Title);
                node.Tag = web;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;

                //-- add lists and document libraries
                TreeNode listsNode = node.Nodes.Add("Lists");                
                TreeNode librariesNode = node.Nodes.Add("Document Libraries");                

                foreach (SPList list in web.Lists)
                {
                    if ((!list.Hidden) && (list.BaseType != SPBaseType.DocumentLibrary))
                    {
                        TreeNode listNode = listsNode.Nodes.Add(list.Title);
                        listNode.Tag = list;
                        listNode.ImageIndex = 11;
                        listNode.SelectedImageIndex = 11;

                        TreeNode itemsNode = listNode.Nodes.Add("Items");
                        itemsNode.Tag = "Items";
                        itemsNode.ImageIndex = 0;
                        itemsNode.SelectedImageIndex = 0;
                        

                        TreeNode eventHandlersNode = listNode.Nodes.Add("Event Handlers");
                        eventHandlersNode.Tag = "List Event Handlers";
                        eventHandlersNode.ImageIndex = 0;
                        eventHandlersNode.SelectedImageIndex = 0;                        
                    }
                    else
                    {
                        TreeNode libNode = librariesNode.Nodes.Add(list.Title);
                        libNode.Tag = list;
                        libNode.ImageIndex = 12;
                        libNode.SelectedImageIndex = 12;

                        TreeNode filesNode = libNode.Nodes.Add("Files");
                        filesNode.Tag = "Files";
                        filesNode.ImageIndex = 0;
                        filesNode.SelectedImageIndex = 0;                        

                        TreeNode eventHandlersNode = libNode.Nodes.Add("Event Handlers");
                        eventHandlersNode.Tag = "Lib Event Handlers";
                        eventHandlersNode.ImageIndex = 0;
                        eventHandlersNode.SelectedImageIndex = 0;                          
                    }
                }

                TreeNode eventHandlerNode = node.Nodes.Add("Event Handlers");
                eventHandlerNode.Tag = "Web Event Handlers";
                eventHandlerNode.ImageIndex = 0;
                eventHandlerNode.SelectedImageIndex = 0;                 

            }

            //-- add content types for the site collection
            TreeNode contentTypesNode = siteCollectionNode.Nodes.Add("Content Types");
            contentTypesNode.ImageIndex = 0;
            contentTypesNode.SelectedImageIndex = 0;                

            SPWeb rootWeb = site.RootWeb;
            foreach (SPContentType contentType in rootWeb.ContentTypes)
            {
                TreeNode node = contentTypesNode.Nodes.Add(contentType.Name);
                node.Tag = contentType;
                node.ImageIndex = 8;
                node.SelectedImageIndex = 8;

                TreeNode eventHandlersNode = node.Nodes.Add("Event Handlers");
                eventHandlersNode.Tag = "ContentType Event Handlers";
                eventHandlersNode.ImageIndex = 0;
                eventHandlersNode.SelectedImageIndex = 0;   

            }



        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void treeViewItems_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string tag = e.Node.Tag.ToString();
            switch (tag)
            {
                case "ContentType Event Handlers":
                    {
                        SPContentType item = (SPContentType) e.Node.Parent.Tag;
                        foreach (SPEventReceiverDefinition er in item.EventReceivers)
                        {
                            TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                            node.Tag = er;
                            node.ImageIndex = 10;
                            node.SelectedImageIndex = 10;
                        }
                        break;
                    }
                case "Web Event Handlers":
                    {
                        SPWeb item = (SPWeb)e.Node.Parent.Tag;
                        foreach (SPEventReceiverDefinition er in item.EventReceivers)
                        {
                            TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                            node.Tag = er;
                            node.ImageIndex = 10;
                            node.SelectedImageIndex = 10;
                        }
                        break;
                    }
                case "Lib Event Handlers":
                    {
                        SPDocumentLibrary item = (SPDocumentLibrary)e.Node.Parent.Tag;
                        foreach (SPEventReceiverDefinition er in item.EventReceivers)
                        {
                            TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                            node.Tag = er;
                            node.ImageIndex = 10;
                            node.SelectedImageIndex = 10;
                        }
                        break;
                    }
                case "Files":
                    {
                        SPDocumentLibrary item = (SPDocumentLibrary)e.Node.Parent.Tag;
                        foreach (SPListItem listItem in item.Items)
                        {
                            TreeNode node = e.Node.Nodes.Add(listItem.File.Name);
                            node.Tag = listItem.File;
                            node.ImageIndex = 3;
                            node.SelectedImageIndex = 3;
                            TreeNode evNode = node.Nodes.Add("Event Handlers");
                            evNode.Tag = "File Event Handlers";
                            
                        }
                        break;
                    }
                case "List Event Handlers":
                    {
                        SPList item = (SPList)e.Node.Parent.Tag;
                        foreach (SPEventReceiverDefinition er in item.EventReceivers)
                        {
                            TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                            node.Tag = er;
                            node.ImageIndex = 10;
                            node.SelectedImageIndex = 10;
                        }
                        break;
                    }
                case "Items":
                    {
                        SPList item = (SPList)e.Node.Parent.Tag;
                        foreach (SPListItem listItem in item.Items)
                        {
                            TreeNode node = e.Node.Nodes.Add(listItem.Title);
                            node.Tag = listItem;
                            node.ImageIndex = 5;
                            node.SelectedImageIndex = 5;
                            TreeNode evNode = node.Nodes.Add("Event Handlers");
                            evNode.Tag = "Item Event Handlers";
                            
                        }
                        break;
                    }
                case "Item Event Handlers":
                    {
                        
                        
                        SPListItem item = (SPListItem)e.Node.Parent.Tag;
                        SPList list = item.ParentList;
                        
                        foreach (SPEventReceiverDefinition er in list.EventReceivers)
                        {
                            TreeNode node = e.Node.Nodes.Add(er.Class + " (" + er.Type.ToString() + ")");
                            node.Tag = er;
                            node.ImageIndex = 10;
                            node.SelectedImageIndex = 10;                            
                        }
                        break;
                    }
                case "File Event Handlers":
                    {
                        SPFile item = (SPFile)e.Node.Parent.Tag;
                        foreach (SPEventReceiverDefinition er in item.EventReceivers)
                        {
                            TreeNode node = e.Node.Nodes.Add(er.Class);
                            node.Tag = er;
                            node.ImageIndex = 10;
                            node.SelectedImageIndex = 10;
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private void buttonLoadAssembly_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Select .NET Assembly";
                    ofd.Filter = "Assemblies (*.dll)|*.dll";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string dll = ofd.FileName;
                        Assembly ass = Assembly.LoadFile(dll);
                        if (!ass.GlobalAssemblyCache)
                        {
                            MessageBox.Show("Sorry, your Assembly has not yet been deployed in the GAC!","Event Handler Explorer",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        }
                        else
                        {
                            textBoxAssemlby.Text = ass.FullName;


                            comboBoxClasses.Items.Clear();
                            foreach (Type type in ass.GetTypes())
                            {
                                if (type.IsClass)
                                    comboBoxClasses.Items.Add(type.FullName);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                TreeNode node = treeViewItems.SelectedNode;
                if (node.Tag is SPList)
                {
                    SPList list = (SPList)node.Tag;
                    list.EventReceivers.Add
                        ((SPEventReceiverType)Enum.Parse(typeof(SPEventReceiverType), comboBoxEventType.Text),
                         textBoxAssemlby.Text, comboBoxClasses.Text);
                    list.Update();
                    flag = true;
                }
                if (node.Tag is SPContentType)
                {
                    SPContentType ct = (SPContentType)node.Tag;
                    ct.EventReceivers.Add
                        ((SPEventReceiverType)Enum.Parse(typeof(SPEventReceiverType), comboBoxEventType.Text),
                         textBoxAssemlby.Text, comboBoxClasses.Text);
                    ct.Update();
                    flag = true;
                }
                if (node.Tag is SPWeb)
                {
                    SPWeb w = (SPWeb)node.Tag;
                    w.EventReceivers.Add
                        ((SPEventReceiverType)Enum.Parse(typeof(SPEventReceiverType), comboBoxEventType.Text),
                         textBoxAssemlby.Text, comboBoxClasses.Text);
                    w.Update();
                    flag = true;
                }
                if (flag)
                   MessageBox.Show("Event handler registered!","Event Handler Explorer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                   MessageBox.Show("Are you sure your node is a list, document library, list item, file, content type or web?", "Event Handler Explorer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void treeViewItems_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
            if (e.Node.Tag is SPEventReceiverDefinition)
            {
                SPEventReceiverDefinition er = (SPEventReceiverDefinition)e.Node.Tag;
                textBoxAssemlby.Text = er.Assembly;
                comboBoxClasses.Items.Clear();
                comboBoxClasses.Text = er.Class;
                textBoxSequence.Text = er.SequenceNumber.ToString();
                for (int i=0; i<comboBoxEventType.Items.Count; i++)
                {
                    if (comboBoxEventType.Items[i].ToString() == er.Type.ToString())
                        comboBoxEventType.SelectedIndex = i;
                }
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            try
            {
                TreeNode node = treeViewItems.SelectedNode;
                SPEventReceiverDefinition er = (SPEventReceiverDefinition)node.Tag;
                if (MessageBox.Show("Are you sure you want to remove this event handler?", "Event Handler Explorer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    er.Delete();
                    textBoxAssemlby.Text = string.Empty;
                    comboBoxClasses.Items.Clear();
                    textBoxSequence.Text = string.Empty;
                    comboBoxEventType.SelectedIndex = -1;
                    node.Parent.Nodes.Remove(node);
                    MessageBox.Show("Event handler unregistered!", "Event Handler Explorer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}