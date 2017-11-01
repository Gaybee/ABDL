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
                /*public PointF position
                {
                    get
                    {
                        switch (pin.pinType)
                        {
                            case AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData.PinType.input:
                                return new PointF(parent.data.position.X,
                                    parent.data.position.Y +
                                    parent.parent.form.CreateGraphics().MeasureString(pin.name, parent.parent.font).Height
                                    * (1 + pin.number));
                            case AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData.PinType.output:
                                return new PointF(parent.data.position.X +
                                    parent.boxUI.Rectangle.Width,
                                    parent.data.position.Y +
                                    parent.parent.form.CreateGraphics().MeasureString(pin.name, parent.parent.font).Height
                                    * (1 + pin.number));
                            case AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData.PinType.status:
                                return new PointF(parent.data.position.X + parent.boxUI.Rectangle.Width / 2,
                                    parent.data.position.Y +
                                    parent.parent.form.CreateGraphics().MeasureString(pin.name, parent.parent.font).Height
                                    * (1 + pin.number));
                            default:
                                throw new Exception("Pin type invalid");
                        }

                    }
                }
                */
                public bool selected { get; set; }
                public bool showOnLineValues
                {
                    get
                    {
                        return registerInspection != null && registerInspection.inspecting;
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
                            nameBDUI = new TextBDUI(pin.name, TextBDUI.textAlignment.TopRight, operationBDUI.data.position, this);
                            dataBDUI = new TextBDUI(pin.data, TextBDUI.textAlignment.TopLeft, operationBDUI.data.position, this);
                            onLineValueBDUI = new TextBDUI("", TextBDUI.textAlignment.BottomLeft, operationBDUI.data.position, this);
                            break;
                        case AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData.PinType.output:
                            nameBDUI = new TextBDUI(pin.name, TextBDUI.textAlignment.TopLeft, operationBDUI.data.position, this);
                            dataBDUI = new TextBDUI(pin.data, TextBDUI.textAlignment.TopRight, operationBDUI.data.position, this);
                            onLineValueBDUI = new TextBDUI("", TextBDUI.textAlignment.BottomRight, operationBDUI.data.position, this);
                            break;
                        case AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData.PinType.status:
                            nameBDUI = new TextBDUI(pin.name, TextBDUI.textAlignment.BottomLeft, operationBDUI.data.position, this);
                            dataBDUI = new TextBDUI(pin.data, TextBDUI.textAlignment.BottomRight, operationBDUI.data.position, this);
                            onLineValueBDUI = new TextBDUI("", TextBDUI.textAlignment.BottomRight, operationBDUI.data.position, this);
                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    this.parent.parent.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) =>
                    {
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