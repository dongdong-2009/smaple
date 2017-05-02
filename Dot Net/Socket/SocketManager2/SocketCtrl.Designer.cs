namespace SocketManager2
{
    partial class SocketCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msg1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListen1 = new System.Windows.Forms.Button();
            this.btnSend1 = new System.Windows.Forms.Button();
            this.txtSend1 = new System.Windows.Forms.TextBox();
            this.btnOn1 = new System.Windows.Forms.Button();
            this.btnOff1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOut1 = new System.Windows.Forms.TextBox();
            this.txtIn1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msg1
            // 
            this.msg1.AutoSize = true;
            this.msg1.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msg1.Location = new System.Drawing.Point(71, 131);
            this.msg1.Name = "msg1";
            this.msg1.Size = new System.Drawing.Size(0, 15);
            this.msg1.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnListen1);
            this.panel1.Controls.Add(this.btnSend1);
            this.panel1.Controls.Add(this.txtSend1);
            this.panel1.Controls.Add(this.btnOn1);
            this.panel1.Controls.Add(this.btnOff1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtOut1);
            this.panel1.Controls.Add(this.txtIn1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 247);
            this.panel1.TabIndex = 13;
            // 
            // btnListen1
            // 
            this.btnListen1.Location = new System.Drawing.Point(3, 126);
            this.btnListen1.Name = "btnListen1";
            this.btnListen1.Size = new System.Drawing.Size(45, 25);
            this.btnListen1.TabIndex = 12;
            this.btnListen1.Tag = "msg1";
            this.btnListen1.Text = "监听";
            this.btnListen1.UseVisualStyleBackColor = true;
            this.btnListen1.Click += new System.EventHandler(this.btnListen1_Click);
            // 
            // btnSend1
            // 
            this.btnSend1.Location = new System.Drawing.Point(135, 211);
            this.btnSend1.Name = "btnSend1";
            this.btnSend1.Size = new System.Drawing.Size(45, 25);
            this.btnSend1.TabIndex = 11;
            this.btnSend1.Text = "发送";
            this.btnSend1.UseVisualStyleBackColor = true;
            this.btnSend1.Click += new System.EventHandler(this.btnSend1_Click);
            // 
            // txtSend1
            // 
            this.txtSend1.Location = new System.Drawing.Point(16, 211);
            this.txtSend1.Name = "txtSend1";
            this.txtSend1.Size = new System.Drawing.Size(100, 20);
            this.txtSend1.TabIndex = 10;
            // 
            // btnOn1
            // 
            this.btnOn1.Location = new System.Drawing.Point(67, 126);
            this.btnOn1.Name = "btnOn1";
            this.btnOn1.Size = new System.Drawing.Size(45, 25);
            this.btnOn1.TabIndex = 9;
            this.btnOn1.Tag = "msg1";
            this.btnOn1.Text = "连接";
            this.btnOn1.UseVisualStyleBackColor = true;
            this.btnOn1.Click += new System.EventHandler(this.btnOn1_Click);
            // 
            // btnOff1
            // 
            this.btnOff1.Location = new System.Drawing.Point(131, 126);
            this.btnOff1.Name = "btnOff1";
            this.btnOff1.Size = new System.Drawing.Size(45, 25);
            this.btnOff1.TabIndex = 8;
            this.btnOff1.Tag = "msg1";
            this.btnOff1.Text = "停止";
            this.btnOff1.UseVisualStyleBackColor = true;
            this.btnOff1.Click += new System.EventHandler(this.btnOff1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "监听";
            // 
            // txtOut1
            // 
            this.txtOut1.Location = new System.Drawing.Point(55, 69);
            this.txtOut1.Name = "txtOut1";
            this.txtOut1.Size = new System.Drawing.Size(125, 20);
            this.txtOut1.TabIndex = 6;
            this.txtOut1.Text = "16.187.151.159:8881";
            // 
            // txtIn1
            // 
            this.txtIn1.Location = new System.Drawing.Point(55, 16);
            this.txtIn1.Name = "txtIn1";
            this.txtIn1.Size = new System.Drawing.Size(125, 20);
            this.txtIn1.TabIndex = 4;
            this.txtIn1.Text = "16.187.151.159:9991";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "连接";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 118);
            this.button1.TabIndex = 12;
            this.button1.Text = "发卡仿真";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SocketCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.msg1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "SocketCtrl";
            this.Size = new System.Drawing.Size(207, 426);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msg1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnListen1;
        private System.Windows.Forms.Button btnSend1;
        private System.Windows.Forms.TextBox txtSend1;
        private System.Windows.Forms.Button btnOn1;
        private System.Windows.Forms.Button btnOff1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOut1;
        private System.Windows.Forms.TextBox txtIn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
