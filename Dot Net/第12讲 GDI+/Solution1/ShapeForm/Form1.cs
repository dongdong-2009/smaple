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
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Point oldPoint;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			//�ڴ����л���ͼ��
			Graphics g = e.Graphics;
			g.DrawImage(Image.FromFile("scocca.gif"),0,0);
			//ָ������ͻ����Ĵ�С��ͼƬ�Ĵ�Сһ��
			this.ClientSize = Image.FromFile("scocca.gif").Size;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//�½�һ��GraphicsPath
			GraphicsPath path = new GraphicsPath();
			//��ͼƬ�ļ�����һ��λͼ����
			Bitmap bitmap = new Bitmap("scocca.gif");

			//����λͼ�����е㣬����ɫ�����Ͻǵ�һ�������ɫ��ͬ�ĵ���뵽GraphicsPath��
			for(int i = 0;i < bitmap.Width;i ++)
			{
				for(int j = 0; j < bitmap.Height; j ++)
				{
					if(bitmap.GetPixel(i,j) != bitmap.GetPixel(1,1))
					{
						//����ɫ�����Ͻǵ�һ�������ɫ��ͬ�ĵ���뵽GraphicsPath��,��ͨ������һ��ֻ��һ�����صľ�����ɵ�
						path.AddRectangle(new Rectangle(i,j,1,1));
					}
				}
			}

			//ͨ��GraphicsPath������һ��Region
			Region reg = new Region(path);
			//ָ���������Region���ԣ������������Ĵ���
			this.Region = reg;
		}

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//��������ʱ����¼����ʱ��λ��
			this.oldPoint = new Point(e.X,e.Y);
		}

		private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//��굯����ƶ����µ�λ��
			this.Left = this.Left + e.X - oldPoint.X;
			this.Top = this.Top + e.Y - oldPoint.Y;
		}
	}
}
