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
    public partial class RutineBDUI
    {
        public partial class OperationBDUI
        {
            public static PointF getPinPositionForOperation(OperationBDUI operation,PinBDUI pin)
            {
                throw new NotImplementedException();
            }
            public static PointF getDataTextPositionForPin(PinBDUI pin)
            {
                throw new NotImplementedException();
            }
            public static PointF getFieldTextPositionForPin(PinBDUI pin)
            {
                throw new NotImplementedException();
            }
            public static PointF getOnLineValueTextPositionForPin(PinBDUI pin)
            {
                throw new NotImplementedException();
            }
            public class PinBDUI
            {
                //Pin Block Diagram User Interface
                public OperationBDUI parent { get; set; }
                public Graphics graphics { get { return parent.graphics; } }
                public PointF position { get; set; }
                public bool selected { get; set; }
                public bool showOnLineValues
                {
                    get
                    {
                        return registerInspection != null && registerInspection.inspecting;
                    }
                }
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
                public TextBDUI nameBDUI { get; set; }
                public TextBDUI dataBDUI { get; set; }
                public TextBDUI onLineValueBDUI { get; set; }


                public AutomationInspector.AutomationInspection.RegisterInspection registerInspection { get; set; }
                public AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData pin { get; set; }
                public event PaintEventHandler Paint;


                public PinBDUI(OperationBDUI operationBDUI, AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData pin)
                {
                    this.pin = pin;

                    this.parent = operationBDUI;

                    switch (pin.pinType)
                    {
                        case AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData.PinType.input:
                            nameBDUI = new TextBDUI(this, pin.name,  operationBDUI.data.position, TextBDUI.textAlignment.TopRight);
                            dataBDUI = new TextBDUI(this, pin.data, operationBDUI.data.position, TextBDUI.textAlignment.TopLeft);
                            onLineValueBDUI = new TextBDUI(this,"", operationBDUI.data.position, TextBDUI.textAlignment.BottomLeft);
                            break;
                        case AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData.PinType.output:
                            nameBDUI = new TextBDUI(this, pin.name, operationBDUI.data.position, TextBDUI.textAlignment.TopLeft);
                            dataBDUI = new TextBDUI(this, pin.data, operationBDUI.data.position, TextBDUI.textAlignment.TopRight);
                            onLineValueBDUI = new TextBDUI(this, "", operationBDUI.data.position, TextBDUI.textAlignment.BottomRight);
                            break;
                        case AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData.PinType.status:
                            nameBDUI = new TextBDUI(this, pin.name, operationBDUI.data.position, TextBDUI.textAlignment.BottomLeft);
                            dataBDUI = new TextBDUI(this, pin.data, operationBDUI.data.position, TextBDUI.textAlignment.BottomRight);
                            onLineValueBDUI = new TextBDUI(this, "", operationBDUI.data.position, TextBDUI.textAlignment.BottomRight);
                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    parent.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) =>
                    {
                        if (Paint != null)
                            this.Paint(sender, e);
                    };
                }

                public bool HitTest(Point hitPoint)
                {
                    return nameBDUI.HitTest(hitPoint) || dataBDUI.HitTest(hitPoint) || onLineValueBDUI.HitTest(hitPoint);
                }

            }

        }
    }
}