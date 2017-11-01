using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAutomationPlatform
{
    public class TextBDUI : IBDUI
    {
        //Text Block Diagram User Interface
        public RutineBDUI.OperationBDUI.PinBDUI parent { get; set; }
        public System.Drawing.Graphics graphics { get { return parent.graphics; } }
        public string text { get; set; }

        public enum textAlignment { Center, Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight };
        public textAlignment alignment { get; set; }

        public System.Drawing.Brush brush { get; set; }
        public System.Drawing.Pen pen { get; set; }
        public System.Drawing.PointF pointStart { get; set; }
        public System.Drawing.Font font { get; set; }
        public bool selected { get; set; }

        public event System.Windows.Forms.PaintEventHandler Paint;

        public TextBDUI(string text, textAlignment alignment, System.Drawing.PointF pointStart, RutineBDUI.OperationBDUI.PinBDUI parent)
        {

            this.text = text;
            this.alignment = alignment;
            this.pointStart = pointStart;
            this.parent = parent;

            this.parent.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) =>
            {
                if (Paint != null)
                    this.Paint(sender, e);
                float width, height;
                width = graphics.MeasureString(text, font).Width;
                height = graphics.MeasureString(text, font).Height;
                switch (alignment)
                {
                    case textAlignment.Center:
                        e.Graphics.DrawString(text, font, brush, pointStart.X - width / 2, pointStart.Y - width / 2);
                        break;
                    case textAlignment.Left:
                        e.Graphics.DrawString(text, font, brush, pointStart.X - width, pointStart.Y - width / 2);
                        break;
                    case textAlignment.Right:
                        e.Graphics.DrawString(text, font, brush, pointStart.X, pointStart.Y - height / 2);
                        break;
                    case textAlignment.Top:
                        e.Graphics.DrawString(text, font, brush, pointStart.X - width / 2, pointStart.Y - height);
                        break;
                    case textAlignment.Bottom:
                        e.Graphics.DrawString(text, font, brush, pointStart.X - width, pointStart.Y - height / 2);
                        break;
                    case textAlignment.TopLeft:
                        e.Graphics.DrawString(text, font, brush, pointStart.X - width, pointStart.Y - height);
                        break;
                    case textAlignment.TopRight:
                        e.Graphics.DrawString(text, font, brush, pointStart.X, pointStart.Y - height);
                        break;
                    case textAlignment.BottomLeft:
                        e.Graphics.DrawString(text, font, brush, pointStart.X - width, pointStart.Y);
                        break;
                    case textAlignment.BottomRight:
                        e.Graphics.DrawString(text, font, brush, pointStart.X, pointStart.Y);
                        break;
                    default:
                        break;
                }
                e.Graphics.DrawString(text, font, brush, pointStart);
            };
        }

        public bool HitTest(System.Drawing.PointF hitPoint)
        {
            System.Drawing.SizeF s = parent.graphics.MeasureString(text, font);
            return hitPoint.X >= pointStart.X & hitPoint.X <= pointStart.X + s.Width
              & hitPoint.Y >= pointStart.Y & hitPoint.Y <= pointStart.Y + s.Height;
        }

    }

}
