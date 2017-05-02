using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace ShapeForm
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Point oldPoint;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Text = "Form1";
			this.TransparencyKey = System.Drawing.Color.Transparent;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			//在窗体中绘制图形
			Graphics g = e.Graphics;
			g.DrawImage(Image.FromFile("scocca.gif"),0,0);
			//指定窗体客户区的大小与图片的大小一致
			this.ClientSize = Image.FromFile("scocca.gif").Size;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//新建一个GraphicsPath
			GraphicsPath path = new GraphicsPath();
			//由图片文件创建一个位图对象
			Bitmap bitmap = new Bitmap("scocca.gif");

			//遍历位图的所有点，将颜色与左上角第一个点的颜色不同的点加入到GraphicsPath中
			for(int i = 0;i < bitmap.Width;i ++)
			{
				for(int j = 0; j < bitmap.Height; j ++)
				{
					if(bitmap.GetPixel(i,j) != bitmap.GetPixel(1,1))
					{
						//将颜色与左上角第一个点的颜色不同的点加入到GraphicsPath中,是通过构建一个只有一个像素的矩形完成的
						path.AddRectangle(new Rectangle(i,j,1,1));
					}
				}
			}

			//通过GraphicsPath来创建一个Region
			Region reg = new Region(path);
			//指定本窗体的Region属性，来绘出不规则的窗体
			this.Region = reg;
		}

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//当鼠标点下时，记录点下时的位置
			this.oldPoint = new Point(e.X,e.Y);
		}

		private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//鼠标弹起后，移动到新的位置
			this.Left = this.Left + e.X - oldPoint.X;
			this.Top = this.Top + e.Y - oldPoint.Y;
		}
	}
}
