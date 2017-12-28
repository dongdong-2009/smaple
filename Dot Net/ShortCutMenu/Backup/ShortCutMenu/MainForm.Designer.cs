namespace ShortCutMenu
{
    partial class frm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm));
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.pMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tab_Add = new System.Windows.Forms.TabPage();
            this.GB_newApp = new System.Windows.Forms.GroupBox();
            this.btn_newApp = new System.Windows.Forms.Button();
            this.lab_SelGroup = new System.Windows.Forms.Label();
            this.cbBox_SelGroup = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_newAppPath = new System.Windows.Forms.TextBox();
            this.lab_newAppPath = new System.Windows.Forms.Label();
            this.txt_newAppName = new System.Windows.Forms.TextBox();
            this.lab_newAppName = new System.Windows.Forms.Label();
            this.GB_newGruop = new System.Windows.Forms.GroupBox();
            this.btn_newGroup = new System.Windows.Forms.Button();
            this.txt_groupName = new System.Windows.Forms.TextBox();
            this.tab_Del = new System.Windows.Forms.TabPage();
            this.GB_DelApp = new System.Windows.Forms.GroupBox();
            this.btn_DelApp = new System.Windows.Forms.Button();
            this.lb_selApp = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_selGroup = new System.Windows.Forms.ListBox();
            this.GB_DelGroup = new System.Windows.Forms.GroupBox();
            this.lab_SelDelGroup = new System.Windows.Forms.Label();
            this.btn_Del = new System.Windows.Forms.Button();
            this.CB_SelDelGroup = new System.Windows.Forms.ComboBox();
            this.tab_Sys = new System.Windows.Forms.TabPage();
            this.GB_sys = new System.Windows.Forms.GroupBox();
            this.chkbox_Sys = new System.Windows.Forms.CheckedListBox();
            this.watchNewExec = new System.IO.FileSystemWatcher();
            this.tabCtrl.SuspendLayout();
            this.tab_Add.SuspendLayout();
            this.GB_newApp.SuspendLayout();
            this.GB_newGruop.SuspendLayout();
            this.tab_Del.SuspendLayout();
            this.GB_DelApp.SuspendLayout();
            this.GB_DelGroup.SuspendLayout();
            this.tab_Sys.SuspendLayout();
            this.GB_sys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchNewExec)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDlg
            // 
            this.openFileDlg.DefaultExt = "exe";
            this.openFileDlg.Filter = "应用程序(.exe)|*.exe|批处理程序(.bat)|*.bat";
            this.openFileDlg.InitialDirectory = "C:\\Program Files";
            this.openFileDlg.Title = "选择应用程序";
            // 
            // pMenu
            // 
            this.pMenu.AllowDrop = true;
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.pMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tab_Add);
            this.tabCtrl.Controls.Add(this.tab_Del);
            this.tabCtrl.Controls.Add(this.tab_Sys);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(292, 273);
            this.tabCtrl.TabIndex = 1;
            // 
            // tab_Add
            // 
            this.tab_Add.Controls.Add(this.GB_newApp);
            this.tab_Add.Controls.Add(this.GB_newGruop);
            this.tab_Add.Location = new System.Drawing.Point(4, 21);
            this.tab_Add.Name = "tab_Add";
            this.tab_Add.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Add.Size = new System.Drawing.Size(284, 248);
            this.tab_Add.TabIndex = 0;
            this.tab_Add.Text = "新增";
            this.tab_Add.UseVisualStyleBackColor = true;
            // 
            // GB_newApp
            // 
            this.GB_newApp.Controls.Add(this.btn_newApp);
            this.GB_newApp.Controls.Add(this.lab_SelGroup);
            this.GB_newApp.Controls.Add(this.cbBox_SelGroup);
            this.GB_newApp.Controls.Add(this.button1);
            this.GB_newApp.Controls.Add(this.txt_newAppPath);
            this.GB_newApp.Controls.Add(this.lab_newAppPath);
            this.GB_newApp.Controls.Add(this.txt_newAppName);
            this.GB_newApp.Controls.Add(this.lab_newAppName);
            this.GB_newApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_newApp.Location = new System.Drawing.Point(3, 66);
            this.GB_newApp.Name = "GB_newApp";
            this.GB_newApp.Size = new System.Drawing.Size(278, 179);
            this.GB_newApp.TabIndex = 1;
            this.GB_newApp.TabStop = false;
            this.GB_newApp.Text = "新增应用程序";
            // 
            // btn_newApp
            // 
            this.btn_newApp.Location = new System.Drawing.Point(219, 90);
            this.btn_newApp.Name = "btn_newApp";
            this.btn_newApp.Size = new System.Drawing.Size(53, 23);
            this.btn_newApp.TabIndex = 7;
            this.btn_newApp.Text = "新增";
            this.btn_newApp.UseVisualStyleBackColor = true;
            this.btn_newApp.Click += new System.EventHandler(this.btn_newApp_Click);
            // 
            // lab_SelGroup
            // 
            this.lab_SelGroup.AutoSize = true;
            this.lab_SelGroup.Location = new System.Drawing.Point(6, 101);
            this.lab_SelGroup.Name = "lab_SelGroup";
            this.lab_SelGroup.Size = new System.Drawing.Size(59, 12);
            this.lab_SelGroup.TabIndex = 6;
            this.lab_SelGroup.Text = "选 择 组:";
            // 
            // cbBox_SelGroup
            // 
            this.cbBox_SelGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox_SelGroup.FormattingEnabled = true;
            this.cbBox_SelGroup.Location = new System.Drawing.Point(74, 93);
            this.cbBox_SelGroup.MaxDropDownItems = 20;
            this.cbBox_SelGroup.Name = "cbBox_SelGroup";
            this.cbBox_SelGroup.Size = new System.Drawing.Size(131, 20);
            this.cbBox_SelGroup.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_newAppPath
            // 
            this.txt_newAppPath.Location = new System.Drawing.Point(74, 22);
            this.txt_newAppPath.Name = "txt_newAppPath";
            this.txt_newAppPath.ReadOnly = true;
            this.txt_newAppPath.Size = new System.Drawing.Size(131, 21);
            this.txt_newAppPath.TabIndex = 3;
            // 
            // lab_newAppPath
            // 
            this.lab_newAppPath.AutoSize = true;
            this.lab_newAppPath.Location = new System.Drawing.Point(6, 31);
            this.lab_newAppPath.Name = "lab_newAppPath";
            this.lab_newAppPath.Size = new System.Drawing.Size(59, 12);
            this.lab_newAppPath.TabIndex = 2;
            this.lab_newAppPath.Text = "程序路径:";
            // 
            // txt_newAppName
            // 
            this.txt_newAppName.Location = new System.Drawing.Point(74, 57);
            this.txt_newAppName.Name = "txt_newAppName";
            this.txt_newAppName.Size = new System.Drawing.Size(131, 21);
            this.txt_newAppName.TabIndex = 1;
            // 
            // lab_newAppName
            // 
            this.lab_newAppName.AutoSize = true;
            this.lab_newAppName.Location = new System.Drawing.Point(6, 66);
            this.lab_newAppName.Name = "lab_newAppName";
            this.lab_newAppName.Size = new System.Drawing.Size(59, 12);
            this.lab_newAppName.TabIndex = 0;
            this.lab_newAppName.Text = "程 序 名:";
            // 
            // GB_newGruop
            // 
            this.GB_newGruop.Controls.Add(this.btn_newGroup);
            this.GB_newGruop.Controls.Add(this.txt_groupName);
            this.GB_newGruop.Dock = System.Windows.Forms.DockStyle.Top;
            this.GB_newGruop.Location = new System.Drawing.Point(3, 3);
            this.GB_newGruop.Name = "GB_newGruop";
            this.GB_newGruop.Size = new System.Drawing.Size(278, 63);
            this.GB_newGruop.TabIndex = 0;
            this.GB_newGruop.TabStop = false;
            this.GB_newGruop.Text = "新增组";
            // 
            // btn_newGroup
            // 
            this.btn_newGroup.Location = new System.Drawing.Point(219, 18);
            this.btn_newGroup.Name = "btn_newGroup";
            this.btn_newGroup.Size = new System.Drawing.Size(53, 23);
            this.btn_newGroup.TabIndex = 1;
            this.btn_newGroup.Text = "新增";
            this.btn_newGroup.UseVisualStyleBackColor = true;
            this.btn_newGroup.Click += new System.EventHandler(this.btn_newGroup_Click);
            // 
            // txt_groupName
            // 
            this.txt_groupName.Location = new System.Drawing.Point(5, 20);
            this.txt_groupName.Name = "txt_groupName";
            this.txt_groupName.Size = new System.Drawing.Size(200, 21);
            this.txt_groupName.TabIndex = 0;
            // 
            // tab_Del
            // 
            this.tab_Del.Controls.Add(this.GB_DelApp);
            this.tab_Del.Controls.Add(this.GB_DelGroup);
            this.tab_Del.Location = new System.Drawing.Point(4, 21);
            this.tab_Del.Name = "tab_Del";
            this.tab_Del.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Del.Size = new System.Drawing.Size(284, 248);
            this.tab_Del.TabIndex = 1;
            this.tab_Del.Text = "删除";
            this.tab_Del.UseVisualStyleBackColor = true;
            // 
            // GB_DelApp
            // 
            this.GB_DelApp.Controls.Add(this.btn_DelApp);
            this.GB_DelApp.Controls.Add(this.lb_selApp);
            this.GB_DelApp.Controls.Add(this.label2);
            this.GB_DelApp.Controls.Add(this.label1);
            this.GB_DelApp.Controls.Add(this.lb_selGroup);
            this.GB_DelApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_DelApp.Location = new System.Drawing.Point(3, 82);
            this.GB_DelApp.Name = "GB_DelApp";
            this.GB_DelApp.Size = new System.Drawing.Size(278, 163);
            this.GB_DelApp.TabIndex = 1;
            this.GB_DelApp.TabStop = false;
            this.GB_DelApp.Text = "删除应用程序";
            // 
            // btn_DelApp
            // 
            this.btn_DelApp.Location = new System.Drawing.Point(219, 128);
            this.btn_DelApp.Name = "btn_DelApp";
            this.btn_DelApp.Size = new System.Drawing.Size(53, 23);
            this.btn_DelApp.TabIndex = 6;
            this.btn_DelApp.Text = "删除";
            this.btn_DelApp.UseVisualStyleBackColor = true;
            this.btn_DelApp.Click += new System.EventHandler(this.btn_DelApp_Click);
            // 
            // lb_selApp
            // 
            this.lb_selApp.FormattingEnabled = true;
            this.lb_selApp.ItemHeight = 12;
            this.lb_selApp.Location = new System.Drawing.Point(115, 39);
            this.lb_selApp.Name = "lb_selApp";
            this.lb_selApp.Size = new System.Drawing.Size(98, 112);
            this.lb_selApp.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择应用程序:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择组:";
            // 
            // lb_selGroup
            // 
            this.lb_selGroup.FormattingEnabled = true;
            this.lb_selGroup.ItemHeight = 12;
            this.lb_selGroup.Location = new System.Drawing.Point(8, 39);
            this.lb_selGroup.Name = "lb_selGroup";
            this.lb_selGroup.Size = new System.Drawing.Size(99, 112);
            this.lb_selGroup.TabIndex = 0;
            this.lb_selGroup.SelectedIndexChanged += new System.EventHandler(this.lb_selGroup_SelectedIndexChanged);
            // 
            // GB_DelGroup
            // 
            this.GB_DelGroup.Controls.Add(this.lab_SelDelGroup);
            this.GB_DelGroup.Controls.Add(this.btn_Del);
            this.GB_DelGroup.Controls.Add(this.CB_SelDelGroup);
            this.GB_DelGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.GB_DelGroup.Location = new System.Drawing.Point(3, 3);
            this.GB_DelGroup.Name = "GB_DelGroup";
            this.GB_DelGroup.Size = new System.Drawing.Size(278, 79);
            this.GB_DelGroup.TabIndex = 0;
            this.GB_DelGroup.TabStop = false;
            this.GB_DelGroup.Text = "删除组";
            // 
            // lab_SelDelGroup
            // 
            this.lab_SelDelGroup.AutoSize = true;
            this.lab_SelDelGroup.Location = new System.Drawing.Point(6, 41);
            this.lab_SelDelGroup.Name = "lab_SelDelGroup";
            this.lab_SelDelGroup.Size = new System.Drawing.Size(47, 12);
            this.lab_SelDelGroup.TabIndex = 2;
            this.lab_SelDelGroup.Text = "选择组:";
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(219, 30);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(53, 23);
            this.btn_Del.TabIndex = 1;
            this.btn_Del.Text = "删除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // CB_SelDelGroup
            // 
            this.CB_SelDelGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SelDelGroup.FormattingEnabled = true;
            this.CB_SelDelGroup.Location = new System.Drawing.Point(59, 33);
            this.CB_SelDelGroup.Name = "CB_SelDelGroup";
            this.CB_SelDelGroup.Size = new System.Drawing.Size(121, 20);
            this.CB_SelDelGroup.TabIndex = 0;
            // 
            // tab_Sys
            // 
            this.tab_Sys.Controls.Add(this.GB_sys);
            this.tab_Sys.Location = new System.Drawing.Point(4, 21);
            this.tab_Sys.Name = "tab_Sys";
            this.tab_Sys.Size = new System.Drawing.Size(284, 248);
            this.tab_Sys.TabIndex = 2;
            this.tab_Sys.Text = "系统工具";
            this.tab_Sys.UseVisualStyleBackColor = true;
            // 
            // GB_sys
            // 
            this.GB_sys.Controls.Add(this.chkbox_Sys);
            this.GB_sys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_sys.Location = new System.Drawing.Point(0, 0);
            this.GB_sys.Name = "GB_sys";
            this.GB_sys.Size = new System.Drawing.Size(284, 248);
            this.GB_sys.TabIndex = 1;
            this.GB_sys.TabStop = false;
            this.GB_sys.Text = "选择要显示的程序";
            // 
            // chkbox_Sys
            // 
            this.chkbox_Sys.BackColor = System.Drawing.SystemColors.Control;
            this.chkbox_Sys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkbox_Sys.CheckOnClick = true;
            this.chkbox_Sys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkbox_Sys.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkbox_Sys.FormattingEnabled = true;
            this.chkbox_Sys.Location = new System.Drawing.Point(3, 17);
            this.chkbox_Sys.MultiColumn = true;
            this.chkbox_Sys.Name = "chkbox_Sys";
            this.chkbox_Sys.Size = new System.Drawing.Size(278, 218);
            this.chkbox_Sys.TabIndex = 0;
            this.chkbox_Sys.SelectedIndexChanged += new System.EventHandler(this.chkbox_Sys_SelectedIndexChanged);
            // 
            // watchNewExec
            // 
            this.watchNewExec.EnableRaisingEvents = true;
            this.watchNewExec.SynchronizingObject = this;
            // 
            // frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.tabCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.tabCtrl.ResumeLayout(false);
            this.tab_Add.ResumeLayout(false);
            this.GB_newApp.ResumeLayout(false);
            this.GB_newApp.PerformLayout();
            this.GB_newGruop.ResumeLayout(false);
            this.GB_newGruop.PerformLayout();
            this.tab_Del.ResumeLayout(false);
            this.GB_DelApp.ResumeLayout(false);
            this.GB_DelApp.PerformLayout();
            this.GB_DelGroup.ResumeLayout(false);
            this.GB_DelGroup.PerformLayout();
            this.tab_Sys.ResumeLayout(false);
            this.GB_sys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.watchNewExec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.ContextMenuStrip pMenu;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tab_Add;
        private System.Windows.Forms.TabPage tab_Del;
        private System.Windows.Forms.GroupBox GB_newGruop;
        private System.Windows.Forms.TextBox txt_groupName;
        private System.Windows.Forms.Button btn_newGroup;
        private System.Windows.Forms.GroupBox GB_newApp;
        private System.Windows.Forms.TextBox txt_newAppName;
        private System.Windows.Forms.Label lab_newAppName;
        private System.Windows.Forms.TextBox txt_newAppPath;
        private System.Windows.Forms.Label lab_newAppPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lab_SelGroup;
        private System.Windows.Forms.ComboBox cbBox_SelGroup;
        private System.Windows.Forms.Button btn_newApp;
        private System.Windows.Forms.GroupBox GB_DelGroup;
        private System.Windows.Forms.GroupBox GB_DelApp;
        private System.Windows.Forms.Label lab_SelDelGroup;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.ComboBox CB_SelDelGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_selGroup;
        private System.Windows.Forms.Button btn_DelApp;
        private System.Windows.Forms.ListBox lb_selApp;
        private System.Windows.Forms.TabPage tab_Sys;
        private System.Windows.Forms.CheckedListBox chkbox_Sys;
        private System.Windows.Forms.GroupBox GB_sys;
        private System.IO.FileSystemWatcher watchNewExec;
    }
}

