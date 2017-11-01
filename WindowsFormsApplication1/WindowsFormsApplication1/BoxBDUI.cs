using OpenAutomationPlatform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenAutomationPlatform
{
    public class BoxBDUI : IBDUI
    {
        //Box Block Diagram User Interface
        public bool selected { get; set; }
        public RutineBDUI.OperationBDUI parent { get; set; }
        public Graphics graphics { get { return parent.graphics; } }
        public PointF position { get; set; }//todo:combinar pointStart y Rectangle para que muestren siempre lo mismo

        public RectangleF Rectangle { get; set; }

        public event PaintEventHandler Paint;

        public BoxBDUI()
        {

            position = new PointF(10, 10);
            Rectangle = new RectangleF(position, new SizeF(100, 300));
        }
        public BoxBDUI(RutineBDUI.OperationBDUI operationBDUIParent)
        {
            this.parent = operationBDUIParent;
            position = operationBDUIParent.data.position;
            Rectangle = new RectangleF(position, new SizeF(100, 300));
            this.parent.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) =>
            {
                if (Paint != null)
                    Paint(sender, e);
                e.Graphics.DrawRectangle(parent.parent.pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            };
        }
        public Boolean HitTest(PointF hitPoint)
        {
            return hitPoint.X >= Rectangle.X & hitPoint.X <= Rectangle.X + Rectangle.Width
                 & hitPoint.Y >= Rectangle.Y & hitPoint.Y <= Rectangle.Y + Rectangle.Height;
        }
    }


}
