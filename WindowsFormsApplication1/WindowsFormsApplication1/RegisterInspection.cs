using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAutomationPlatform
{
    public partial class AutomationInspector
    {
        public partial class AutomationInspection
        {
            public partial class RegisterInspection
            {
                public AutomationInspection inspection { get; set; }
                public AutomationWorkspaceData.AutomationPlatformData.MemoryData.Register register { get; set; }
                public string onLineValue { get; set; }
                public bool forced { get; set; }
                public DateTime timeStamp { get; set; }
                public bool inspecting
                {
                    get
                    {
                        return inspection.inspecting;
                    }
                }

            }
        }
    }
}