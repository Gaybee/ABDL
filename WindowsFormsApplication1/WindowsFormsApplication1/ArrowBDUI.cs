using OpenAutomationPlatform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ArrowBDUI : IBDUI
    {
        //Arrow Block Diagram User Interface
        public IBDUI parent { get; set; }
        public System.Windows.Forms.Form form { get; set; }
        public Graphics graphics { get { return parent.graphics; } }
        public Brush brush { get; set; }
        public Pen pen { get; set; }
        public PointF pointStart { get; set; }
        public Font font { get; set; }
        public bool selected { get; set; }

        public PointF pointEnd { get; set; }

        float a, b, c;

        public event PaintEventHandler Paint;

        public bool HitTest(PointF hitPoint)
        {
            int maxdist = 10;
            double dist;
            a = pointStart.Y - pointEnd.Y;
            b = pointEnd.X - pointStart.X;
            c = (pointStart.X - pointEnd.X) * pointStart.Y + (pointEnd.Y - pointStart.Y) * pointStart.X;
            dist = Math.Abs(a * hitPoint.X + b * hitPoint.Y + c) / Math.Sqrt(a * a + b * b);
            return dist <= maxdist &
                hitPoint.X <= Math.Max(pointStart.X, pointEnd.X) & hitPoint.X >= Math.Min(pointStart.X, pointEnd.X) &
                hitPoint.Y <= Math.Max(pointStart.Y, pointEnd.Y) & hitPoint.Y > +Math.Min(pointStart.Y, pointEnd.Y);
        }
        public ArrowBDUI()
        {
            brush = Brushes.Black;
            pen = new Pen(brush, 1);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pointStart = new Point(10, 10);
            pointEnd = new Point(50, 50);
        }
        public ArrowBDUI(System.Windows.Forms.Form DrawingForm)
        {
            brush = Brushes.Black;
            pen = new Pen(brush, 1);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pointStart = new Point(10, 10);
            pointEnd = new Point(50, 50);
            this.form = DrawingForm;
            this.form.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) =>
            {
                e.Graphics.DrawLine(pen, pointStart, pointEnd);
            };
        }


    }
}
