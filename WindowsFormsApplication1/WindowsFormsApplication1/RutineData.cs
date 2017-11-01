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
                
                public string name { get; set; }
                public string description { get; set; }
                public string scheduleGroupId { get; set; }
                public List<OperationData> OperationsData { get; set; }

                public RutineData()
                {
                    name = "MyRutine";
                    description = "No description.";
                    scheduleGroupId = "";
                    OperationsData = new List<OperationData>();
                }
                public RutineData(string shcheduleGroupId)
                {
                    name = "MyRutine";
                    description = "No description.";
                    this.scheduleGroupId = scheduleGroupId;
                    OperationsData = new List<OperationData>();
                }
                public RutineData(RutineData rutineData)
                {
                    this.name = rutineData.name;
                    this.description = rutineData.description;
                    this.scheduleGroupId = rutineData.scheduleGroupId;
                    OperationsData = new List<OperationData>();
                    foreach (OperationData o in rutineData.OperationsData)
                        OperationsData.Add(new OperationData(o));
                }
            }
        }
    }
}
