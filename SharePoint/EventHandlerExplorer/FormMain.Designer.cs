namespace EventHandlerExplorer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSiteCollectionURL = new System.Windows.Forms.TextBox();
            this.buttonExplore = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAssemlby = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSequence = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxEventType = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.treeViewItems = new System.Windows.Forms.TreeView();
            this.buttonLoadAssembly = new System.Windows.Forms.Button();
            this.comboBoxClasses = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonExit);
            this.groupBox1.Controls.Add(this.buttonExplore);
            this.groupBox1.Controls.Add(this.textBoxSiteCollectionURL);
            this.groupBox1.Location = new System.Drawing.Point(592, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(403, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter URL for the site collection you want to explore";
            // 
            // textBoxSiteCollectionURL
            // 
            this.textBoxSiteCollectionURL.Location = new System.Drawing.Point(9, 27);
            this.textBoxSiteCollectionURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSiteCollectionURL.Name = "textBoxSiteCollectionURL";
            this.textBoxSiteCollectionURL.Size = new System.Drawing.Size(386, 22);
            this.textBoxSiteCollectionURL.TabIndex = 0;
            // 
            // buttonExplore
            // 
            this.buttonExplore.Image = ((System.Drawing.Image)(resources.GetObject("buttonExplore.Image")));
            this.buttonExplore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExplore.Location = new System.Drawing.Point(191, 57);
            this.buttonExplore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExplore.Name = "buttonExplore";
            this.buttonExplore.Size = new System.Drawing.Size(92, 29);
            this.buttonExplore.TabIndex = 1;
            this.buttonExplore.Text = "Explore";
            this.buttonExplore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExplore.UseVisualStyleBackColor = true;
            this.buttonExplore.Click += new System.EventHandler(this.buttonExplore_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeViewItems);
            this.groupBox2.Location = new System.Drawing.Point(0, 1);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(590, 524);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SharePoint Explorer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxClasses);
            this.groupBox3.Controls.Add(this.buttonLoadAssembly);
            this.groupBox3.Controls.Add(this.buttonRemove);
            this.groupBox3.Controls.Add(this.buttonAdd);
            this.groupBox3.Controls.Add(this.comboBoxEventType);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxSequence);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxAssemlby);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(592, 106);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(403, 294);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Details of Event Handler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assembly:";
            // 
            // textBoxAssemlby
            // 
            this.textBoxAssemlby.Location = new System.Drawing.Point(12, 58);
            this.textBoxAssemlby.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAssemlby.Multiline = true;
            this.textBoxAssemlby.Name = "textBoxAssemlby";
            this.textBoxAssemlby.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAssemlby.Size = new System.Drawing.Size(383, 57);
            this.textBoxAssemlby.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sequence:";
            // 
            // textBoxSequence
            // 
            this.textBoxSequence.Location = new System.Drawing.Point(114, 185);
            this.textBoxSequence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSequence.Name = "textBoxSequence";
            this.textBoxSequence.Size = new System.Drawing.Size(148, 22);
            this.textBoxSequence.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 218);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Event Type:";
            // 
            // comboBoxEventType
            // 
            this.comboBoxEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEventType.FormattingEnabled = true;
            this.comboBoxEventType.Items.AddRange(new object[] {
            "EmailReceived",
            "FieldAdded",
            "FieldAdding",
            "FieldDeleted",
            "FieldDeleting",
            "FieldUpdated",
            "FieldUpdating",
            "ItemAdded",
            "ItemAdding",
            "ItemAttachmentAdded",
            "ItemAttachmentAdding",
            "ItemAttachmentDeleted",
            "ItemAttachmentDeleting",
            "ItemCheckedIn",
            "ItemCheckedOut",
            "ItemCheckingIn",
            "ItemCheckingOut",
            "ItemDeleted",
            "ItemDeleting",
            "ItemFileMoved",
            "ItemFileMoving",
            "ItemFileTransformed",
            "ItemUncheckOut",
            "ItemUncheckingOut",
            "ItemUpdated",
            "ItemUpdating",
            "SiteDeleted",
            "SiteDeleting",
            "WebDeleted",
            "WebDeleting",
            "WebMoved",
            "WebMoving"});
            this.comboBoxEventType.Location = new System.Drawing.Point(114, 210);
            this.comboBoxEventType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxEventType.Name = "comboBoxEventType";
            this.comboBoxEventType.Size = new System.Drawing.Size(281, 24);
            this.comboBoxEventType.TabIndex = 7;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(13, 252);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(170, 28);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add Handler";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(191, 252);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(170, 28);
            this.buttonRemove.TabIndex = 9;
            this.buttonRemove.Text = "Remove Handler";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // treeViewItems
            // 
            this.treeViewItems.ImageIndex = 0;
            this.treeViewItems.ImageList = this.imageList1;
            this.treeViewItems.Location = new System.Drawing.Point(9, 23);
            this.treeViewItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewItems.Name = "treeViewItems";
            this.treeViewItems.SelectedImageIndex = 0;
            this.treeViewItems.Size = new System.Drawing.Size(575, 493);
            this.treeViewItems.TabIndex = 0;
            this.treeViewItems.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewItems_NodeMouseDoubleClick);
            this.treeViewItems.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewItems_NodeMouseClick);
            // 
            // buttonLoadAssembly
            // 
            this.buttonLoadAssembly.Location = new System.Drawing.Point(263, 22);
            this.buttonLoadAssembly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLoadAssembly.Name = "buttonLoadAssembly";
            this.buttonLoadAssembly.Size = new System.Drawing.Size(132, 28);
            this.buttonLoadAssembly.TabIndex = 10;
            this.buttonLoadAssembly.Text = "Load Assembly";
            this.buttonLoadAssembly.UseVisualStyleBackColor = true;
            this.buttonLoadAssembly.Click += new System.EventHandler(this.buttonLoadAssembly_Click);
            // 
            // comboBoxClasses
            // 
            this.comboBoxClasses.FormattingEnabled = true;
            this.comboBoxClasses.Location = new System.Drawing.Point(12, 148);
            this.comboBoxClasses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxClasses.Name = "comboBoxClasses";
            this.comboBoxClasses.Size = new System.Drawing.Size(383, 24);
            this.comboBoxClasses.TabIndex = 11;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(998, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(274, 17);
            this.toolStripStatusLabel1.Text = "Created by Patrick Tisseghem (U2U) - (patrick@u2u.be)";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder Blue.ico");
            this.imageList1.Images.SetKeyName(1, "Globe 2.ico");
            this.imageList1.Images.SetKeyName(2, "Home 2.ico");
            this.imageList1.Images.SetKeyName(3, "noextension32.gif");
            this.imageList1.Images.SetKeyName(4, "PAGELOGO.GIF");
            this.imageList1.Images.SetKeyName(5, "DESVIEW.GIF");
            this.imageList1.Images.SetKeyName(6, "DETAIL.GIF");
            this.imageList1.Images.SetKeyName(7, "EXC16.GIF");
            this.imageList1.Images.SetKeyName(8, "GENERIC.GIF");
            this.imageList1.Images.SetKeyName(9, "ITSMRTPG.GIF");
            this.imageList1.Images.SetKeyName(10, "LISTSET.GIF");
            this.imageList1.Images.SetKeyName(11, "LTDATASH.GIF");
            this.imageList1.Images.SetKeyName(12, "LTDCL.GIF");
            // 
            // buttonExit
            // 
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.Location = new System.Drawing.Point(303, 57);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(92, 29);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Exit";
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click_1);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 551);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Handler Explorer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonExplore;
        private System.Windows.Forms.TextBox textBoxSiteCollectionURL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxEventType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSequence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAssemlby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TreeView treeViewItems;
        private System.Windows.Forms.Button buttonLoadAssembly;
        private System.Windows.Forms.ComboBox comboBoxClasses;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonExit;
    }
}

