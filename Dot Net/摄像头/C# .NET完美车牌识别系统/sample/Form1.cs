using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Security.Cryptography;

//using System.Windows.Forms.SaveFileDialog;

namespace sample
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class ImageProcess : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.Button GrayButton;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Panel panel2;

		private Bitmap m_Bitmap ;//整幅图像
		private Bitmap m_Bitmap1;
		private Bitmap m_Bitmap2;
		private Bitmap m_Bitmap3;
		private Bitmap c_Bitmap ;//车牌图像
		private int maxX;
		private int maxY;
		Pen pen1=new Pen(Color.Black);
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button InvertButton;
		private System.Windows.Forms.Button BrightButton;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel GraphyPanel;
		private System.Windows.Forms.Panel LcolorPanel;
		private System.Windows.Forms.GroupBox groupBox4; 

		private String name;
		private bool aline=false;
		int [] gray=new int[256];
		int [] rr = new int[256];
		int [] gg = new int[256];
		int [] bb = new int[256];
		private float count ;
		
		private float [] gl=new float[256];
		int flag=0;
		private System.Windows.Forms.Button NoiselessButton;
		private System.Windows.Forms.Button MarginalButton;
		private System.Windows.Forms.Button TwoValueButton;
		int xx=-1;

		public ImageProcess()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			m_Bitmap = new Bitmap(2,2);
			m_Bitmap1 = new Bitmap(2,2);
						m_Bitmap2 = new Bitmap(2,2);
						m_Bitmap3 = new Bitmap(2,2);
			c_Bitmap = new Bitmap(2,2);
			InitializeComponent();
			

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageProcess));
            this.OpenButton = new System.Windows.Forms.Button();
            this.GrayButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GraphyPanel = new System.Windows.Forms.Panel();
            this.InvertButton = new System.Windows.Forms.Button();
            this.BrightButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LcolorPanel = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TwoValueButton = new System.Windows.Forms.Button();
            this.MarginalButton = new System.Windows.Forms.Button();
            this.NoiselessButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(8, 24);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 1;
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.Open_Click);
            // 
            // GrayButton
            // 
            this.GrayButton.Enabled = false;
            this.GrayButton.Location = new System.Drawing.Point(8, 120);
            this.GrayButton.Name = "GrayButton";
            this.GrayButton.Size = new System.Drawing.Size(75, 23);
            this.GrayButton.TabIndex = 2;
            this.GrayButton.Text = "Gray";
            this.GrayButton.Click += new System.EventHandler(this.GrayButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(8, 248);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(78, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 16);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 264);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // GraphyPanel
            // 
            this.GraphyPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GraphyPanel.ForeColor = System.Drawing.Color.Coral;
            this.GraphyPanel.Location = new System.Drawing.Point(360, 156);
            this.GraphyPanel.Name = "GraphyPanel";
            this.GraphyPanel.Size = new System.Drawing.Size(210, 120);
            this.GraphyPanel.TabIndex = 7;
            this.GraphyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphyPanel_Paint);
            // 
            // InvertButton
            // 
            this.InvertButton.Enabled = false;
            this.InvertButton.Location = new System.Drawing.Point(8, 56);
            this.InvertButton.Name = "InvertButton";
            this.InvertButton.Size = new System.Drawing.Size(75, 23);
            this.InvertButton.TabIndex = 10;
            this.InvertButton.Text = "Invert";
            this.InvertButton.Click += new System.EventHandler(this.InvertButton_Click);
            // 
            // BrightButton
            // 
            this.BrightButton.Enabled = false;
            this.BrightButton.Location = new System.Drawing.Point(8, 88);
            this.BrightButton.Name = "BrightButton";
            this.BrightButton.Size = new System.Drawing.Size(75, 23);
            this.BrightButton.TabIndex = 11;
            this.BrightButton.Text = "Equalize";
            this.BrightButton.Click += new System.EventHandler(this.BrightButton_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Location = new System.Drawing.Point(8, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 62);
            this.panel4.TabIndex = 13;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Location = new System.Drawing.Point(354, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "车牌";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LcolorPanel);
            this.groupBox2.Location = new System.Drawing.Point(354, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 174);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "直方图";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // LcolorPanel
            // 
            this.LcolorPanel.Location = new System.Drawing.Point(8, 152);
            this.LcolorPanel.Name = "LcolorPanel";
            this.LcolorPanel.Size = new System.Drawing.Size(208, 18);
            this.LcolorPanel.TabIndex = 0;
            this.LcolorPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LcolorPanel_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(6, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 288);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "待处理图像";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "文件路径";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TwoValueButton);
            this.groupBox4.Controls.Add(this.MarginalButton);
            this.groupBox4.Controls.Add(this.SaveButton);
            this.groupBox4.Controls.Add(this.InvertButton);
            this.groupBox4.Controls.Add(this.OpenButton);
            this.groupBox4.Controls.Add(this.NoiselessButton);
            this.groupBox4.Controls.Add(this.GrayButton);
            this.groupBox4.Controls.Add(this.BrightButton);
            this.groupBox4.Location = new System.Drawing.Point(582, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(88, 300);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // TwoValueButton
            // 
            this.TwoValueButton.Enabled = false;
            this.TwoValueButton.Location = new System.Drawing.Point(8, 216);
            this.TwoValueButton.Name = "TwoValueButton";
            this.TwoValueButton.Size = new System.Drawing.Size(75, 23);
            this.TwoValueButton.TabIndex = 14;
            this.TwoValueButton.Text = "2Value";
            this.TwoValueButton.Click += new System.EventHandler(this.InciseButton_Click);
            // 
            // MarginalButton
            // 
            this.MarginalButton.Enabled = false;
            this.MarginalButton.Location = new System.Drawing.Point(8, 184);
            this.MarginalButton.Name = "MarginalButton";
            this.MarginalButton.Size = new System.Drawing.Size(75, 23);
            this.MarginalButton.TabIndex = 13;
            this.MarginalButton.Text = "Marginal";
            this.MarginalButton.Click += new System.EventHandler(this.MarginalButton_Click_1);
            // 
            // NoiselessButton
            // 
            this.NoiselessButton.Enabled = false;
            this.NoiselessButton.Location = new System.Drawing.Point(8, 152);
            this.NoiselessButton.Name = "NoiselessButton";
            this.NoiselessButton.Size = new System.Drawing.Size(75, 23);
            this.NoiselessButton.TabIndex = 12;
            this.NoiselessButton.Text = "Noiseless";
            this.NoiselessButton.Click += new System.EventHandler(this.NoiselessButton_Click);
            // 
            // ImageProcess
            // 
            this.ClientSize = new System.Drawing.Size(676, 320);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GraphyPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImageProcess";
            this.Text = "数字图像处理实验－－陈家伟 200345005006";
            this.Load += new System.EventHandler(this.ImageProcess_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ImageProcess());
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			
		}

		private void Open_Click(object sender, System.EventArgs e)
		{
			
			BrightButton.Enabled=false;
			NoiselessButton.Enabled=false;
			MarginalButton.Enabled=false;
			TwoValueButton.Enabled=false;
			SaveButton.Enabled=false;
			panel4.Enabled=false;		


			OpenFileDialog openFileDialog = new OpenFileDialog(); 

			openFileDialog.Filter = "Jpeg文件(*.jpg)|*.jpg|Bitmap文件(*.bmp)|*.bmp| 所有合适文件(*.bmp/*.jpg)|*.bmp/*.jpg";   

			openFileDialog.FilterIndex = 2 ; 

			openFileDialog.RestoreDirectory = true ; 

			if(DialogResult.OK == openFileDialog.ShowDialog()) 

			{ 
				name = openFileDialog.FileName;
				m_Bitmap = (Bitmap)Bitmap.FromFile(name, false); 

				this.panel1.AutoScroll = true; 

				this.panel1.AutoScrollMinSize=new Size ((int)(m_Bitmap.Width),(int) 

					m_Bitmap.Height); 

				this.InvertButton.Enabled=true;
				this.GrayButton.Enabled=true;
				

				panel1.Invalidate(); 
				panel2.Invalidate();
				panel4.Invalidate();

			} 

		}

		private void ImageProcess_Load(object sender, System.EventArgs e)
		{
			
		}

		private void hScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			panel1.Invalidate();
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics; 
			g.DrawImage(m_Bitmap, new Rectangle(this.panel1.AutoScrollPosition.X, this.panel1.AutoScrollPosition.Y, 
				(int)(m_Bitmap.Width), (int)(m_Bitmap.Height)));

		}

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Bitmap文件(*.bmp)|*.bmp| Jpeg文件(*.jpg)|*.jpg| 所有合适文件(*.bmp/*.jpg)|*.bmp/*.jpg";
			saveFileDialog.FilterIndex = 1 ; 

			saveFileDialog.RestoreDirectory = true ; 

			if(DialogResult.OK == saveFileDialog.ShowDialog()) 

			{ 
				c_Bitmap.Save(saveFileDialog.FileName); 

			} 

		}

		private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics; 
			g.DrawString(name,new Font("Arial", 8), new SolidBrush(Color.Black),0,0);
		}

		private void label1_Click_1(object sender, System.EventArgs e)
		{
		
		}

		private void InvertButton_Click(object sender, System.EventArgs e)
		{
			if(Filters.Invert(m_Bitmap,out gray)) 
			{
				LcolorPanel.Invalidate();
				graydo();
			}

		}


		private void GraphyPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			int p;
			p = m_Bitmap.Width*m_Bitmap.Height;
		//	this.l_pixel.Text=p.ToString();

			int height =this.GraphyPanel.Height;
			for(int j=0;j<256;j++)
			{
				if(gl[j]>height)
					gl[j]=height;
				g.DrawLine(pen1,j,height,j,height-gl[j]);
			}
			if(aline)
			{
				g.DrawLine(Pens.OrangeRed,xx,0,xx,height);   
			}
		}

		private void GraphyPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			xx=e.X; 
			if(xx>255)
				xx=255;
			if(xx<=0)
				xx=0;
   
			aline=true;
			this.GraphyPanel.Invalidate();
		}

		private void GraphyPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Point p=new Point(e.X,e.Y);
			if(new Rectangle(0,0,256,127).Contains(p))
			{
				this.xx=e.X;
			}
			else
			{
				this.xx=-1;
			}
   
			this.GraphyPanel.Invalidate();
		}

		private void GraphyPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			aline=false;
		}

		private void LcolorPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			int width=this.LcolorPanel.Width;
			int height=this.LcolorPanel.Height;
			int j;
			Color c;
			Graphics g=e.Graphics;

			switch(flag)
			{
				case 1:
				{
					for(int i=width;i>=0;i--)
					{
						j=i;
						if(j>255) j=255;
						c=Color.FromArgb(j,j,j);
						Pen pen2=new Pen(c,1);   
						g.DrawLine(pen2,i,0,i,height);
					}
					break;
				}
				case 2:
				{
					for(int i=width;i>=0;i--)
					{
						j=i;
						if(j>255) j=255;
						c=Color.FromArgb(j,0,0);
						Pen pen2=new Pen(c,1);   
						g.DrawLine(pen2,i,0,i,height);
					}
					break;
				}
				case 3:
				{
					for(int i=width;i>=0;i--)
					{
						j=i;
						if(j>255) j=255;
						c=Color.FromArgb(0,j,0);
						Pen pen2=new Pen(c,1);   
						g.DrawLine(pen2,i,0,i,height);
					}
					break;
				}
				case 4:
				{
					for(int i=width;i>=0;i--)
					{
						j=i;
						if(j>255) j=255;
						c=Color.FromArgb(0,0,j);
						Pen pen2=new Pen(c,1);   
						g.DrawLine(pen2,i,0,i,height);
					}
					break;
				}
				default:
					break;

			}
		}

		private void GrayButton_Click(object sender, System.EventArgs e)
		{
			Filters.zft(m_Bitmap,out gray,out rr,out gg, out bb); 
			this.BrightButton.Enabled=true;
			this.NoiselessButton.Enabled=true;
			LcolorPanel.Invalidate();
			graydo();
		
		}

		private void BrightButton_Click(object sender, System.EventArgs e)
		{
		
			if(Filters.Brightness(m_Bitmap,gray,out gray,(int)count) )
				graydo();

		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void panel4_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics; 
			Point ulCorner = new Point( 0, 0);
			g.DrawImage(c_Bitmap,0,0);
			//g.DrawImage(c_Bitmap, new Rectangle(this.panel1.AutoScrollPosition.X, this.panel1.AutoScrollPosition.Y, 
			//	(int)(c_Bitmap.Width), (int)(c_Bitmap.Height)));
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void label1_Click_2(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}
		private void graydo()
		{
			this.flag=1;
			count = m_Bitmap.Width * m_Bitmap.Height;
			gl=new float[256];
			for(int i=0;i<256; i++)
				gl[i]= gray[i]/count *1500;
			pen1=Pens.Red;
			panel1.Invalidate();
			GraphyPanel.Invalidate();
		}

		private void NoiselessButton_Click(object sender, System.EventArgs e)
		{
			if(Filters.GaussianFilter(m_Bitmap,out gray))
				graydo();
			this.MarginalButton.Enabled=true;
		}

		private void MarginalButton_Click_1(object sender, System.EventArgs e)
		{
			int ccount;
			int yl,yr,xu,xd;
			if (Filters.MarginalFilter(m_Bitmap,out gray,out ccount ,67,out xu,out xd,out yl,out yr,out maxX,out maxY)) {
			
				m_Bitmap1 = (Bitmap)Bitmap.FromFile(name, false); 
				Rectangle sourceRectangle = new Rectangle(yl,xu,yr-yl,xd-xu);
				c_Bitmap= m_Bitmap1.Clone(sourceRectangle,
					PixelFormat.DontCare);
				groupBox1.Text="车牌";
				groupBox1.Invalidate();
				
				this.SaveButton.Enabled=true;
				this.TwoValueButton.Enabled=true;
				panel4.Invalidate();
				graydo();
			}
		}


		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void InciseButton_Click(object sender, System.EventArgs e)
		{
			
			Filters.zft(c_Bitmap,out gray,out rr,out gg, out bb); 
			Rectangle sourceRectangle = new Rectangle(maxY,maxX,66,14);
			Bitmap xc_Bitmap=c_Bitmap.Clone(sourceRectangle,
				PixelFormat.DontCare);
			if (Filters.TowValue(c_Bitmap,xc_Bitmap,maxY,maxY)) {
				groupBox1.Text="车牌（经二值化处理）";
				groupBox1.Invalidate();
				panel4.Invalidate();
			}
		}

	}
}
