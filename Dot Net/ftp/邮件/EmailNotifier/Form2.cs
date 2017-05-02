using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EmailNotifier
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		private AxAgentObjects.AxAgent axAgent1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2(int EmailNumber)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//你可以从下面的地址下载
			//http://www.microsoft.com/msagent/downloads.htm
			//
			axAgent1.Characters.Load("Genie","Genie.acs");//导入精灵吉尼（Genie）
			AgentObjects.IAgentCtlCharacterEx  genie=axAgent1.Characters["Genie"];
			//genie的语言ID =1033，只能为英语
			genie.Show(false);
			genie.Speak("You Have "+ EmailNumber.ToString()+" emails","");
			genie.Think("Should I Leave or Stay, Himmm!!!!");
			genie.Hide(true);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form2));
			this.axAgent1 = new AxAgentObjects.AxAgent();
			((System.ComponentModel.ISupportInitialize)(this.axAgent1)).BeginInit();
			this.SuspendLayout();
			// 
			// axAgent1
			// 
			this.axAgent1.Enabled = true;
			this.axAgent1.Location = new System.Drawing.Point(40, 16);
			this.axAgent1.Name = "axAgent1";
			this.axAgent1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAgent1.OcxState")));
			this.axAgent1.Size = new System.Drawing.Size(32, 32);
			this.axAgent1.TabIndex = 0;
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(104, 69);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.axAgent1});
			this.Name = "Form2";
			this.Text = "Form2";
			((System.ComponentModel.ISupportInitialize)(this.axAgent1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
