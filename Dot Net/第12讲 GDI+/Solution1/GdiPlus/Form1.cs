using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace GdiPlus
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCreateGraphics;
		Graphics g;//����
		Pen pen;//����
		Brush brush;//��ˢ
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

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
			this.btnCreateGraphics = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCreateGraphics
			// 
			this.btnCreateGraphics.Location = new System.Drawing.Point(24, 24);
			this.btnCreateGraphics.Name = "btnCreateGraphics";
			this.btnCreateGraphics.TabIndex = 0;
			this.btnCreateGraphics.Text = "��������";
			this.btnCreateGraphics.Click += new System.EventHandler(this.btnCreateGraphics_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(128, 24);
			this.btnClear.Name = "btnClear";
			this.btnClear.TabIndex = 1;
			this.btnClear.Text = "��ջ���";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(32, 152);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "������";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(24, 72);
			this.button2.Name = "button2";
			this.button2.TabIndex = 3;
			this.button2.Text = "��������";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(128, 72);
			this.button3.Name = "button3";
			this.button3.TabIndex = 4;
			this.button3.Text = "������ˢ";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(32, 208);
			this.button4.Name = "button4";
			this.button4.TabIndex = 5;
			this.button4.Text = "����Բ";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(136, 152);
			this.button5.Name = "button5";
			this.button5.TabIndex = 6;
			this.button5.Text = "������";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(136, 204);
			this.button6.Name = "button6";
			this.button6.TabIndex = 7;
			this.button6.Text = "�����Բ";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(232, 24);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(128, 23);
			this.button7.TabIndex = 8;
			this.button7.Text = "�ͷŻ�����ռ����Դ";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(32, 256);
			this.button8.Name = "button8";
			this.button8.TabIndex = 9;
			this.button8.Text = "���ַ���";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(512, 430);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnCreateGraphics);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.ResumeLayout(false);

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
			//�õ�����
			Graphics g = e.Graphics;
			
		}

		private void btnCreateGraphics_Click(object sender, System.EventArgs e)
		{
			//��������
			g = this.CreateGraphics();
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			//��ջ���
			g.Clear(this.BackColor);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			//�½����ʣ�����ָ����ɫ����ϸ��������ʽ
			pen = new Pen(Color.Red,3);
			pen.DashStyle = DashStyle.DashDotDot;

			//����ˢ�Ļ���
//			pen = new Pen(brush,10);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//������
			g.DrawRectangle(pen,200,200,100,200);
			
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			//����Բ
			g.DrawEllipse(pen,200,200,100,200);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			//ʵ�Ļ�ˢ
//			brush = new SolidBrush(Color.Pink);

			//����ˢ
			//brush = new HatchBrush(HatchStyle.DashedUpwardDiagonal,Color.Red,Color.Green);

			//���Խ��仭ˢ
			//brush = new LinearGradientBrush(new Point(0,0),new Point(20,30),Color.Red,Color.Blue);

			//���ƻ�ˢ
			brush = new TextureBrush(Image.FromFile(@"C:\Documents and Settings\All Users\Documents\My Pictures\ʾ��ͼƬ\2.jpg"),new Rectangle(0,0,100,100));
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			//������
			g.FillRectangle(brush,200,200,100,200);
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			//����Բ
			g.FillEllipse(brush,200,200,100,200);
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			g.Dispose();
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			//���ַ���
			Font font = new Font("����",50);
			g.DrawString("hello",font,brush,200,200);
		}
	}
}
