namespace Server1
{
    partial class Server1
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
            this.txtget = new System.Windows.Forms.TextBox();
            this.txtsend = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtget
            // 
            this.txtget.BackColor = System.Drawing.Color.White;
            this.txtget.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtget.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtget.Location = new System.Drawing.Point(0, 0);
            this.txtget.Multiline = true;
            this.txtget.Name = "txtget";
            this.txtget.ReadOnly = true;
            this.txtget.Size = new System.Drawing.Size(744, 208);
            this.txtget.TabIndex = 4;
            // 
            // txtsend
            // 
            this.txtsend.BackColor = System.Drawing.Color.White;
            this.txtsend.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsend.Location = new System.Drawing.Point(0, 313);
            this.txtsend.Multiline = true;
            this.txtsend.Name = "txtsend";
            this.txtsend.Size = new System.Drawing.Size(590, 126);
            this.txtsend.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(613, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 81);
            this.button1.TabIndex = 7;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Server1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtsend);
            this.Controls.Add(this.txtget);
            this.Name = "Server1";
            this.Text = "Server1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Server1_FormClosed);
            this.Load += new System.EventHandler(this.Server1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtget;
        private System.Windows.Forms.TextBox txtsend;
        private System.Windows.Forms.Button button1;
    }
}

