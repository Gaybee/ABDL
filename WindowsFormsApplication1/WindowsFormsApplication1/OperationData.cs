using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAutomationPlatform
{
    public partial class AutomationWorkspaceData
    {
        public partial class AutomationPlatformData
        {
            public partial class RutineData
            {
                public partial class OperationData
                {
                    
                    public string id { get; set; }//deberia ser algo tipo "baselib.AND"
                    public List<PinData> Pins { get; set; }
                    public PointF position { get; set; }
                    public long ExecutionOrder { get; set; }

                    public OperationData()
                    {
                        id = "baselib.NOP";
                        Pins = new List<PinData>();
                        position = new PointF(0, 0);
                        ExecutionOrder = 1;
                    }
                    public OperationData(OperationData operation)
                    {
                        ExecutionOrder = 99999;
                        id = operation.id;
                        Pins = new List<PinData>();
                        foreach (PinData p in operation.Pins)
                            Pins.Add(new PinData(p));
                        position = new PointF(operation.position.X, operation.position.Y);
                        ExecutionOrder = operation.ExecutionOrder;
                    }

                }

            }
        }
    }
}
