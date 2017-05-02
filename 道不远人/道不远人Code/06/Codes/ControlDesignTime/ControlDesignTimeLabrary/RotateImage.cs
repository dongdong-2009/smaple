using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Web.UI;


namespace ControlDesignTimeLabrary
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class AngleEditor : System.Drawing.Design.UITypeEditor
    {        
        public AngleEditor()
        {
        }

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {            
            if(value.GetType() != typeof(int) )
                return value;

            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if( edSvc != null )
            {
                AngleControl angleControl = new AngleControl(((int)value * 90), edSvc);
                edSvc.DropDownControl( angleControl );
                return angleControl.GetValue();
            }
            return value;
        }

        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            int normalX = (e.Bounds.Width/2);
            int normalY = (e.Bounds.Height/2);
            
            // Fill and ellipse and center point.
            e.Graphics.FillRectangle(new SolidBrush(Color.DarkBlue), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);            
            e.Graphics.FillEllipse(new SolidBrush(Color.White), e.Bounds.X+1, e.Bounds.Y+1, e.Bounds.Width-3, e.Bounds.Height-3);
            e.Graphics.FillEllipse(new SolidBrush(Color.SlateGray), normalX+e.Bounds.X-1, normalY+e.Bounds.Y-1, 3, 3);
            
            // Draw line along the current angle.
            double radians = (((double)(int)e.Value-1d) * (double)90 * Math.PI) / (double)180;
            e.Graphics.DrawLine( new Pen(new SolidBrush(Color.Navy), 1), normalX+e.Bounds.X, normalY+e.Bounds.Y, 
                e.Bounds.X+ ( normalX + (int)( (double)normalX * Math.Cos( radians ) ) ),
                e.Bounds.Y+ ( normalY + (int)( (double)normalY * Math.Sin( radians ) ) ) );
        }
        
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
    }

    internal class AngleControl : System.Windows.Forms.UserControl
    {
        public double angle;
        private int rotation = -90;
        private int dbx = -10;
        private int dby = -10;
        IWindowsFormsEditorService _editorSvc;
        
        public AngleControl(double initial_angle,IWindowsFormsEditorService svc)
        {
            this.angle = initial_angle;
            this._editorSvc = svc;
            this.SetStyle( ControlStyles.AllPaintingInWmPaint, true );
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Set angle origin point at center of control.
            int originX = (this.Width/2);
            int originY = (this.Height/2);            
            
            // Fill background and ellipse and center point.
            e.Graphics.FillRectangle(new SolidBrush(Color.DarkBlue), 0, 0, this.Width, this.Height);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 1, 1, this.Width-3, this.Height-3);            
            e.Graphics.FillEllipse(new SolidBrush(Color.SlateGray), originX-1, originY-1, 3, 3);
            
            // Draw angle markers.
            e.Graphics.DrawString("0", new Font("Georgia", 12,FontStyle.Bold), new SolidBrush(Color.DarkGray), (this.Width/2)-9, 10);
            e.Graphics.DrawString("1", new Font("Georgia", 12, FontStyle.Bold), new SolidBrush(Color.DarkGray), this.Width - 18, (this.Height / 2) - 11);
            e.Graphics.DrawString("2", new Font("Georgia", 12, FontStyle.Bold), new SolidBrush(Color.DarkGray), (this.Width / 2) - 9, this.Height - 18);
            e.Graphics.DrawString("3", new Font("Georgia", 12, FontStyle.Bold), new SolidBrush(Color.DarkGray), 10, (this.Height / 2) - 11);

            // Draw line along the current angle.         
            double radians = ((((GetAngle()+rotation)+360)%360)*Math.PI) / (double)180;
            e.Graphics.DrawLine( new Pen(new SolidBrush(Color.Red), 1), originX, originY, 
                originX + (int)( (double)originX * (double)Math.Cos( radians )   ),
                originY + (int)( (double)originY * (double)Math.Sin( radians ) ) );
            
            // Output angle information.
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 3, 3, 52, 13);
            e.Graphics.DrawString("Angle: "+GetValue().ToString(), new Font("Arial", 8), new SolidBrush(Color.Yellow), 5,2);
            // Draw square at mouse position of last angle adjustment.
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), dbx-2, dby-2, 4, 4);                  

        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            UpdateAngle(e.X, e.Y);                
            this.Refresh();        
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _editorSvc.CloseDropDown();
            else
                base.OnMouseUp(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                UpdateAngle(e.X, e.Y);                 
            }
            this.Refresh();
        }


        private void UpdateAngle(int mx, int my)
        {
            dbx = mx;
            dby = my;

            double widthToHeightRatio =  (double)this.Width/(double)this.Height;                        
            int tmy;
            if( my == 0 )
                tmy = my;
            else if( my < this.Height/2 )
                tmy = (this.Height/2)-(int)(((this.Height/2)-my)*widthToHeightRatio);                
            else
                tmy = (this.Height/2)+(int)((double)(my-(this.Height/2))*widthToHeightRatio);
            
            angle = (GetAngle(this.Width/2, this.Height/2, mx, tmy)-rotation)%360;                                    
        }

        int GetAngle()
        {
            return ((int)angle + 45) / 90 * 90;
        }

        public int GetValue()
        {
            int value = GetAngle() / 90;
            if (value > 3)
                value = 0;
            return value;
        }

        private double GetAngle(int x1, int y1, int x2, int y2)
        {  
            double degrees;
           
            if( x2-x1 == 0 )
            {
                if( y2 > y1 )
                    degrees = 90;
                else
                    degrees = 270;
            }
            else
            {
                double riseoverrun = (double)(y2-y1)/(double)(x2-x1);
                double radians = Math.Atan( riseoverrun );
                degrees = radians * ((double)180/Math.PI);
                       
                if( (x2-x1) < 0 || (y2-y1) < 0 )
                    degrees += 180;
                if( (x2-x1) > 0 && (y2-y1) < 0 )
                    degrees -= 180;
                if( degrees < 0 )
                    degrees += 360;
            }
            return degrees;
        }
    }

    public class RotateImage : System.Web.UI.WebControls.Image
    {
        [Editor(typeof(AngleEditor),typeof(UITypeEditor))]
        [DefaultValue(0)]
        [Category("Behavior")]
        public int Rotation
        {
            get
            {
                if (ViewState["Rotation"] != null)
                    return (int)ViewState["Rotation"];
                return 0;
            }
            set
            {
                ViewState["Rotation"] = value;
            }
        }

        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            if (Rotation > 0)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Filter, GetFilterString());
            }
        }


        private string GetFilterString()
        {
            return String.Format("progid:DXImageTransform.Microsoft.BasicImage(Rotation={0},Mirror=0)",Rotation.ToString());
        }
    }
}

