namespace SocketManager2
{
    partial class Form2
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
            this.lbMsg = new System.Windows.Forms.ListBox();
            this.socketCtrl1 = new SocketManager2.SocketCtrl();
            this.socketCtrl2 = new SocketManager2.SocketCtrl();
            this.btn1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbMsg.FormattingEnabled = true;
            this.lbMsg.Location = new System.Drawing.Point(0, 464);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(897, 251);
            this.lbMsg.TabIndex = 10;
            // 
            // socketCtrl1
            // 
            this.socketCtrl1.ButtonName = "发卡仿真";
            this.socketCtrl1.connectip = "";
            this.socketCtrl1.lbMsg = null;
            this.socketCtrl1.listenip = "";
            this.socketCtrl1.Location = new System.Drawing.Point(12, 31);
            this.socketCtrl1.Name = "socketCtrl1";
            this.socketCtrl1.Size = new System.Drawing.Size(207, 426);
            this.socketCtrl1.TabIndex = 11;
            // 
            // socketCtrl2
            // 
            this.socketCtrl2.ButtonName = "发卡仿真";
            this.socketCtrl2.connectip = "16.187.151.159:8881";
            this.socketCtrl2.lbMsg = null;
            this.socketCtrl2.listenip = "16.187.151.159:9991";
            this.socketCtrl2.Location = new System.Drawing.Point(225, 31);
            this.socketCtrl2.Name = "socketCtrl2";
            this.socketCtrl2.Size = new System.Drawing.Size(207, 426);
            this.socketCtrl2.TabIndex = 12;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(13, 2);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 13;
            this.btn1.Text = "添加模块";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 715);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.socketCtrl2);
            this.Controls.Add(this.socketCtrl1);
            this.Controls.Add(this.lbMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbMsg;
        private SocketCtrl socketCtrl1;
        private SocketCtrl socketCtrl2;
        private System.Windows.Forms.Button btn1;
    }
}

