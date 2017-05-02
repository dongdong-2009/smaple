using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormDrag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Control control;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDrag_Paint);
            control = new Button();
            control.MouseDown += new MouseEventHandler(control_MouseDown);
            control.MouseMove += new MouseEventHandler(control_MouseMove);
            control.MouseUp += new MouseEventHandler(control_MouseUp);
            this.Controls.Add(control);
        }

        //鼠标按下坐标（control控件的相对坐标） 
        Point mouseDownPoint = Point.Empty;
        //显示拖动效果的矩形 
        Rectangle rect = Rectangle.Empty;
        //是否正在拖拽 
        bool isDrag = false;
        void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = e.Location;
                //记录控件的大小 
                rect = control.Bounds;
            }
        }
        void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                //重新设置rect的位置，跟随鼠标移动 
                rect.Location = getPointToForm(new Point(e.Location.X - mouseDownPoint.X, e.Location.Y - mouseDownPoint.Y));
                this.Refresh();
            }
        }
        void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isDrag)
                {
                    isDrag = false;
                    //移动control到放开鼠标的地方 
                    control.Location = rect.Location;
                    this.Refresh();
                }
                reset();
            }
        }
        //重置变量 
        private void reset()
        {
            mouseDownPoint = Point.Empty;
            rect = Rectangle.Empty;
            isDrag = false;
        }
        //窗体重绘 
        private void FormDrag_Paint(object sender, PaintEventArgs e)
        {
            if (rect != Rectangle.Empty)
            {
                if (isDrag)
                {//画一个和Control一样大小的黑框 
                    e.Graphics.DrawRectangle(Pens.Black, rect);
                }
                else
                {
                    e.Graphics.DrawRectangle(new Pen(this.BackColor), rect);
                }
            }
        }
        //把相对与control控件的坐标，转换成相对于窗体的坐标。 
        private Point getPointToForm(Point p)
        {
            return this.PointToClient(control.PointToScreen(p));
        }
    }
}
