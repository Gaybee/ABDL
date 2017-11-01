using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OpenAutomationPlatform
{
    public class TextBDUI : IBDUI
    {
        //Text Block Diagram User Interface
        public RutineBDUI.OperationBDUI.PinBDUI parent { get; set; }
        public System.Drawing.Graphics graphics { get { return parent.graphics; } }
        public string text { get; set; }
        public PointF position { get; set; }
        public enum textAlignment { Center, Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight };
        public textAlignment alignment { get; set; }

        public bool selected { get; set; }

        public event System.Windows.Forms.PaintEventHandler Paint;

        public Font font
        {
            get
            {
                return parent.font;
            }
        }
        public Brush brush
        {
            get
            {
                return parent.brush;
            }
        }
        public TextBDUI(RutineBDUI.OperationBDUI.PinBDUI parent, string text, PointF position, textAlignment alignment)
        {
            this.parent = parent;
            this.text = text;
            this.alignment = alignment;
            this.position = position;

            parent.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) =>
            {
                if (Paint != null)
                    this.Paint(sender, e);
                float width, height;
                width = graphics.MeasureString(text, parent.parent.parent.font).Width;
                height = graphics.MeasureString(text, parent.parent.parent.font).Height;
                switch (alignment)
                {
                    case textAlignment.Center:
                        e.Graphics.DrawString(text, font, brush, position.X - width / 2, position.Y - width / 2);
                        break;
                    case textAlignment.Left:
                        e.Graphics.DrawString(text, font, brush, position.X - width, position.Y - width / 2);
                        break;
                    case textAlignment.Right:
                        e.Graphics.DrawString(text, font, brush, position.X, position.Y - height / 2);
                        break;
                    case textAlignment.Top:
                        e.Graphics.DrawString(text, font, brush, position.X - width / 2, position.Y - height);
                        break;
                    case textAlignment.Bottom:
                        e.Graphics.DrawString(text, font, brush, position.X - width, position.Y - height / 2);
                        break;
                    case textAlignment.TopLeft:
                        e.Graphics.DrawString(text, font, brush, position.X - width, position.Y - height);
                        break;
                    case textAlignment.TopRight:
                        e.Graphics.DrawString(text, font, brush, position.X, position.Y - height);
                        break;
                    case textAlignment.BottomLeft:
                        e.Graphics.DrawString(text, font, brush, position.X - width, position.Y);
                        break;
                    case textAlignment.BottomRight:
                        e.Graphics.DrawString(text, font, brush, position.X, position.Y);
                        break;
                    default:
                        break;
                }
                e.Graphics.DrawString(text, font, brush, position);
            };
        }

        public bool HitTest(System.Drawing.PointF hitPoint)
        {
            System.Drawing.SizeF s = parent.graphics.MeasureString(text, font);
            return hitPoint.X >= position.X & hitPoint.X <= position.X + s.Width
              & hitPoint.Y >= position.Y & hitPoint.Y <= position.Y + s.Height;
        }

    }

}
