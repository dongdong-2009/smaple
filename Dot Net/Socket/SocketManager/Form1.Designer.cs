namespace SocketManager
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIn1 = new System.Windows.Forms.TextBox();
            this.txtOut1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListen1 = new System.Windows.Forms.Button();
            this.btnSend1 = new System.Windows.Forms.Button();
            this.txtSend1 = new System.Windows.Forms.TextBox();
            this.btnOn1 = new System.Windows.Forms.Button();
            this.btnOff1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnListen2 = new System.Windows.Forms.Button();
            this.btnSend2 = new System.Windows.Forms.Button();
            this.txtSend2 = new System.Windows.Forms.TextBox();
            this.btnOn2 = new System.Windows.Forms.Button();
            this.btnOff2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOut2 = new System.Windows.Forms.TextBox();
            this.txtIn2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOn3 = new System.Windows.Forms.Button();
            this.btnOff3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbMsg = new System.Windows.Forms.ListBox();
            this.msg1 = new System.Windows.Forms.Label();
            this.msg2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 109);
            this.button1.TabIndex = 0;
            this.button1.Text = "发卡仿真";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(364, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 109);
            this.button2.TabIndex = 1;
            this.button2.Text = "受理仿真";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(678, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 109);
            this.button3.TabIndex = 2;
            this.button3.Text = "清算仿真";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "监听";
            // 
            // txtIn1
            // 
            this.txtIn1.Location = new System.Drawing.Point(55, 15);
            this.txtIn1.Name = "txtIn1";
            this.txtIn1.Size = new System.Drawing.Size(125, 21);
            this.txtIn1.TabIndex = 4;
            this.txtIn1.Text = "16.187.151.159:9991";
            // 
            // txtOut1
            // 
            this.txtOut1.Location = new System.Drawing.Point(55, 64);
            this.txtOut1.Name = "txtOut1";
            this.txtOut1.Size = new System.Drawing.Size(125, 21);
            this.txtOut1.TabIndex = 6;
            this.txtOut1.Text = "16.187.151.159:8881";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "连接";
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
            this.panel1.Location = new System.Drawing.Point(12, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 228);
            this.panel1.TabIndex = 7;
            // 
            // btnListen1
            // 
            this.btnListen1.Location = new System.Drawing.Point(3, 116);
            this.btnListen1.Name = "btnListen1";
            this.btnListen1.Size = new System.Drawing.Size(62, 23);
            this.btnListen1.TabIndex = 12;
            this.btnListen1.Tag = "msg1";
            this.btnListen1.Text = "开始监听";
            this.btnListen1.UseVisualStyleBackColor = true;
            this.btnListen1.Click += new System.EventHandler(this.btnListen1_Click);
            // 
            // btnSend1
            // 
            this.btnSend1.Location = new System.Drawing.Point(135, 195);
            this.btnSend1.Name = "btnSend1";
            this.btnSend1.Size = new System.Drawing.Size(45, 23);
            this.btnSend1.TabIndex = 11;
            this.btnSend1.Text = "发送";
            this.btnSend1.UseVisualStyleBackColor = true;
            this.btnSend1.Click += new System.EventHandler(this.btnSend1_Click);
            // 
            // txtSend1
            // 
            this.txtSend1.Location = new System.Drawing.Point(16, 195);
            this.txtSend1.Name = "txtSend1";
            this.txtSend1.Size = new System.Drawing.Size(100, 21);
            this.txtSend1.TabIndex = 10;
            // 
            // btnOn1
            // 
            this.btnOn1.Location = new System.Drawing.Point(71, 116);
            this.btnOn1.Name = "btnOn1";
            this.btnOn1.Size = new System.Drawing.Size(45, 23);
            this.btnOn1.TabIndex = 9;
            this.btnOn1.Tag = "msg1";
            this.btnOn1.Text = "连接";
            this.btnOn1.UseVisualStyleBackColor = true;
            this.btnOn1.Click += new System.EventHandler(this.btnOn1_Click);
            // 
            // btnOff1
            // 
            this.btnOff1.Location = new System.Drawing.Point(131, 116);
            this.btnOff1.Name = "btnOff1";
            this.btnOff1.Size = new System.Drawing.Size(45, 23);
            this.btnOff1.TabIndex = 8;
            this.btnOff1.Tag = "msg1";
            this.btnOff1.Text = "停止";
            this.btnOff1.UseVisualStyleBackColor = true;
            this.btnOff1.Click += new System.EventHandler(this.btnOff1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnListen2);
            this.panel2.Controls.Add(this.btnSend2);
            this.panel2.Controls.Add(this.txtSend2);
            this.panel2.Controls.Add(this.btnOn2);
            this.panel2.Controls.Add(this.btnOff2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtOut2);
            this.panel2.Controls.Add(this.txtIn2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(344, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 228);
            this.panel2.TabIndex = 8;
            // 
            // btnListen2
            // 
            this.btnListen2.Location = new System.Drawing.Point(3, 116);
            this.btnListen2.Name = "btnListen2";
            this.btnListen2.Size = new System.Drawing.Size(63, 23);
            this.btnListen2.TabIndex = 14;
            this.btnListen2.Tag = "msg2";
            this.btnListen2.Text = "开始监听";
            this.btnListen2.UseVisualStyleBackColor = true;
            this.btnListen2.Click += new System.EventHandler(this.btnListen2_Click);
            // 
            // btnSend2
            // 
            this.btnSend2.Location = new System.Drawing.Point(135, 195);
            this.btnSend2.Name = "btnSend2";
            this.btnSend2.Size = new System.Drawing.Size(45, 23);
            this.btnSend2.TabIndex = 13;
            this.btnSend2.Text = "发送";
            this.btnSend2.UseVisualStyleBackColor = true;
            this.btnSend2.Click += new System.EventHandler(this.btnSend2_Click);
            // 
            // txtSend2
            // 
            this.txtSend2.Location = new System.Drawing.Point(16, 195);
            this.txtSend2.Name = "txtSend2";
            this.txtSend2.Size = new System.Drawing.Size(100, 21);
            this.txtSend2.TabIndex = 12;
            // 
            // btnOn2
            // 
            this.btnOn2.Location = new System.Drawing.Point(78, 116);
            this.btnOn2.Name = "btnOn2";
            this.btnOn2.Size = new System.Drawing.Size(45, 23);
            this.btnOn2.TabIndex = 9;
            this.btnOn2.Tag = "msg2";
            this.btnOn2.Text = "连接";
            this.btnOn2.UseVisualStyleBackColor = true;
            this.btnOn2.Click += new System.EventHandler(this.btnOn2_Click);
            // 
            // btnOff2
            // 
            this.btnOff2.Location = new System.Drawing.Point(129, 116);
            this.btnOff2.Name = "btnOff2";
            this.btnOff2.Size = new System.Drawing.Size(45, 23);
            this.btnOff2.TabIndex = 8;
            this.btnOff2.Tag = "msg2";
            this.btnOff2.Text = "停止";
            this.btnOff2.UseVisualStyleBackColor = true;
            this.btnOff2.Click += new System.EventHandler(this.btnOff2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "监听";
            // 
            // txtOut2
            // 
            this.txtOut2.Location = new System.Drawing.Point(55, 64);
            this.txtOut2.Name = "txtOut2";
            this.txtOut2.Size = new System.Drawing.Size(125, 21);
            this.txtOut2.TabIndex = 6;
            this.txtOut2.Text = "16.187.151.159:9991";
            // 
            // txtIn2
            // 
            this.txtIn2.Location = new System.Drawing.Point(55, 15);
            this.txtIn2.Name = "txtIn2";
            this.txtIn2.Size = new System.Drawing.Size(125, 21);
            this.txtIn2.TabIndex = 4;
            this.txtIn2.Text = "16.187.151.159:8881";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "连接";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.textBox8);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnOn3);
            this.panel3.Controls.Add(this.btnOff3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(658, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 228);
            this.panel3.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "Input2";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(55, 152);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(125, 21);
            this.textBox7.TabIndex = 13;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(55, 103);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(125, 21);
            this.textBox8.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "Output2";
            // 
            // btnOn3
            // 
            this.btnOn3.Location = new System.Drawing.Point(55, 195);
            this.btnOn3.Name = "btnOn3";
            this.btnOn3.Size = new System.Drawing.Size(45, 23);
            this.btnOn3.TabIndex = 9;
            this.btnOn3.Text = "On";
            this.btnOn3.UseVisualStyleBackColor = true;
            // 
            // btnOff3
            // 
            this.btnOff3.Location = new System.Drawing.Point(135, 195);
            this.btnOff3.Name = "btnOff3";
            this.btnOff3.Size = new System.Drawing.Size(45, 23);
            this.btnOff3.TabIndex = 8;
            this.btnOff3.Text = "Off";
            this.btnOff3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Input1";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(55, 64);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(125, 21);
            this.textBox5.TabIndex = 6;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(55, 15);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(125, 21);
            this.textBox6.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Output1";
            // 
            // lbMsg
            // 
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbMsg.FormattingEnabled = true;
            this.lbMsg.ItemHeight = 12;
            this.lbMsg.Location = new System.Drawing.Point(0, 404);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(570, 256);
            this.lbMsg.TabIndex = 10;
            // 
            // msg1
            // 
            this.msg1.AutoSize = true;
            this.msg1.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msg1.Location = new System.Drawing.Point(87, 140);
            this.msg1.Name = "msg1";
            this.msg1.Size = new System.Drawing.Size(0, 15);
            this.msg1.TabIndex = 11;
            // 
            // msg2
            // 
            this.msg2.AutoSize = true;
            this.msg2.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msg2.Location = new System.Drawing.Point(420, 140);
            this.msg2.Name = "msg2";
            this.msg2.Size = new System.Drawing.Size(0, 15);
            this.msg2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 660);
            this.Controls.Add(this.msg2);
            this.Controls.Add(this.msg1);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIn1;
        private System.Windows.Forms.TextBox txtOut1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOn1;
        private System.Windows.Forms.Button btnOff1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOn2;
        private System.Windows.Forms.Button btnOff2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOut2;
        private System.Windows.Forms.TextBox txtIn2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOn3;
        private System.Windows.Forms.Button btnOff3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbMsg;
        private System.Windows.Forms.Button btnSend1;
        private System.Windows.Forms.TextBox txtSend1;
        private System.Windows.Forms.Button btnSend2;
        private System.Windows.Forms.TextBox txtSend2;
        private System.Windows.Forms.Button btnListen1;
        private System.Windows.Forms.Button btnListen2;
        private System.Windows.Forms.Label msg1;
        private System.Windows.Forms.Label msg2;
    }
}

