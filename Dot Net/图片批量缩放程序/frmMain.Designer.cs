namespace ThumbnailImages
{
    partial class frmMain
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
            if (timedProgress != null)
            {
                timedProgress.Interrupt();
                timedProgress = null;
            }

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
            this.btnBrowserSource = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnBrowserTarget = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbDefined = new System.Windows.Forms.RadioButton();
            this.rbPercent = new System.Windows.Forms.RadioButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cbDefined = new System.Windows.Forms.ComboBox();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numPercent = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowserSource
            // 
            this.btnBrowserSource.Location = new System.Drawing.Point(438, 60);
            this.btnBrowserSource.Name = "btnBrowserSource";
            this.btnBrowserSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserSource.TabIndex = 1;
            this.btnBrowserSource.Text = "浏览...";
            this.btnBrowserSource.UseVisualStyleBackColor = true;
            this.btnBrowserSource.Click += new System.EventHandler(this.btnBrowserSource_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(189, 62);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(243, 21);
            this.txtSource.TabIndex = 0;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(189, 94);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(243, 21);
            this.txtTarget.TabIndex = 2;
            // 
            // btnBrowserTarget
            // 
            this.btnBrowserTarget.Location = new System.Drawing.Point(438, 94);
            this.btnBrowserTarget.Name = "btnBrowserTarget";
            this.btnBrowserTarget.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserTarget.TabIndex = 3;
            this.btnBrowserTarget.Text = "浏览...";
            this.btnBrowserTarget.UseVisualStyleBackColor = true;
            this.btnBrowserTarget.Click += new System.EventHandler(this.btnBrowserTarget_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "要生成缩略图的图片文件夹:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "将缩略图保存到:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "将图片尺寸调整为:";
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Checked = true;
            this.rbCustom.Location = new System.Drawing.Point(77, 198);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(83, 16);
            this.rbCustom.TabIndex = 6;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "自定义尺寸";
            this.rbCustom.UseVisualStyleBackColor = true;
            // 
            // rbDefined
            // 
            this.rbDefined.AutoSize = true;
            this.rbDefined.Location = new System.Drawing.Point(77, 150);
            this.rbDefined.Name = "rbDefined";
            this.rbDefined.Size = new System.Drawing.Size(83, 16);
            this.rbDefined.TabIndex = 4;
            this.rbDefined.Text = "预定义尺寸";
            this.rbDefined.UseVisualStyleBackColor = true;
            // 
            // rbPercent
            // 
            this.rbPercent.AutoSize = true;
            this.rbPercent.Location = new System.Drawing.Point(77, 247);
            this.rbPercent.Name = "rbPercent";
            this.rbPercent.Size = new System.Drawing.Size(119, 16);
            this.rbPercent.TabIndex = 9;
            this.rbPercent.TabStop = true;
            this.rbPercent.Text = "原始尺寸的百分比";
            this.rbPercent.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(26, 18);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 12);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "欢迎使用";
            // 
            // cbDefined
            // 
            this.cbDefined.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefined.FormattingEnabled = true;
            this.cbDefined.Items.AddRange(new object[] {
            "文档 - 大(1024 x 768 像素)",
            "文档 - 小(800 x 600 像素)",
            "网页 - 大(640 x 480 像素)",
            "网页 - 小(448 x 336 像素)",
            "电子邮件 - 大(314 x 235 像素)",
            "电子邮件 - 小(160 x 160 像素)"});
            this.cbDefined.Location = new System.Drawing.Point(96, 172);
            this.cbDefined.Name = "cbDefined";
            this.cbDefined.Size = new System.Drawing.Size(155, 20);
            this.cbDefined.TabIndex = 5;
            this.cbDefined.SelectedIndexChanged += new System.EventHandler(this.cbDefined_SelectedIndexChanged);
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(96, 220);
            this.numWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(64, 21);
            this.numWidth.TabIndex = 7;
            this.numWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "x";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(187, 220);
            this.numHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(64, 21);
            this.numHeight.TabIndex = 8;
            this.numHeight.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // numPercent
            // 
            this.numPercent.Location = new System.Drawing.Point(96, 269);
            this.numPercent.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numPercent.Name = "numPercent";
            this.numPercent.Size = new System.Drawing.Size(64, 21);
            this.numPercent.TabIndex = 10;
            this.numPercent.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "%";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(28, 321);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(485, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "进度:";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(67, 306);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(446, 12);
            this.lblInfo.TabIndex = 8;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(420, 150);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 84);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(26, 39);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(155, 12);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.openlab.net.cn";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(420, 240);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(93, 75);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(536, 356);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.numPercent);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.cbDefined);
            this.Controls.Add(this.rbDefined);
            this.Controls.Add(this.rbPercent);
            this.Controls.Add(this.rbCustom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.btnBrowserTarget);
            this.Controls.Add(this.btnBrowserSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "图片批量缩放程序(作者:宝玉, openlab.net.cn)";
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowserSource;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbDefined;
        private System.Windows.Forms.RadioButton rbPercent;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cbDefined;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBrowserTarget;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnStop;
    }
}

