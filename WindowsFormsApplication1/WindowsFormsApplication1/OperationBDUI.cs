using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenAutomationPlatform
{
    public partial class RutineBDUI
    {
        public partial class OperationBDUI
        {
            //Operation Block Diagram User Interface
            
            public AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData data { get; set; }

            public RutineBDUI parent { get; set; }
            public Graphics graphics { get { return parent.graphics; } }


            public bool selected { get; set; }

            public List<PinBDUI> pinsUI { get; set; }
            public BoxBDUI boxUI { get; set; }

            public event PaintEventHandler Paint;

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
            public OperationBDUI(RutineBDUI rutineBDUI, AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData operationData)
            {
                this.parent = rutineBDUI;
                this.data = operationData;
                selected = false;
                pinsUI = new List<PinBDUI>();
                foreach (AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData p in operationData.Pins)
                    pinsUI.Add(new PinBDUI(this, p));
                boxUI = new BoxBDUI(this);
                rutineBDUI.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) =>
                {
                    if (Paint != null)
                        this.Paint(sender, e);
                };
            }
            public bool HitTest(Point hitPoint)
            {
                return boxUI.HitTest(hitPoint);
            }

        }
    }
}