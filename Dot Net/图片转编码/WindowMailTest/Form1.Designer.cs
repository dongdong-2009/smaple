namespace WindowMailTest
{
    partial class Form1
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
            this.btn_encode = new System.Windows.Forms.Button();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_encode
            // 
            this.btn_encode.Location = new System.Drawing.Point(13, 13);
            this.btn_encode.Name = "btn_encode";
            this.btn_encode.Size = new System.Drawing.Size(75, 23);
            this.btn_encode.TabIndex = 0;
            this.btn_encode.Text = "将图片编码";
            this.btn_encode.UseVisualStyleBackColor = true;
            this.btn_encode.Click += new System.EventHandler(this.btn_encode_Click);
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(13, 43);
            this.txt_code.Multiline = true;
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(802, 472);
            this.txt_code.TabIndex = 1;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(117, 13);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(281, 23);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "将转码后的图片作为邮件正文发送出去";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 527);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.btn_encode);
            this.Name = "Form1";
            this.Text = "发送正文带图片邮件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_encode;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Button btn_send;
    }
}

