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
            //Esta clase representaria en principio por ejemplo a un PLC que resuelve logica

            
            public class HardwareConfigurationData
            {
                public string name { get; set; }

                public HardwareConfigurationData()
                {
                    name = "AutomationPlatform0";
                }
            }
            public class ScheduleGroupData
            {
                public string id { get; set; }
                public int period { get; set; }
                public int offset { get; set; }
                public int priority { get; set; }

                public ScheduleGroupData()
                {
                    id = "Schedule0";
                    period = 100;
                    offset = 0;
                    priority = 99;
                }
                public ScheduleGroupData(string id, int period, int offset, int priority)
                {
                    this.id = id;
                    this.period = period;
                    this.offset = offset;
                    this.priority = priority;
                }
            }
            public class MemoryData
            {
                public List<Register> registers { get; set; }

                public MemoryData()
                {
                    registers = new List<Register>();
                }
                public class Register
                {
                    public string name { get; set; }
                    public string type { get; set; }//probablemente tambien tenga que ser estilo "baselib.INT"
                    public string initialValue { get; set; }
                    public string description { get; set; }
                    public long offset { get; set; }

                    public Register()
                    {
                        name = "register0";
                        type = "baselib.UINT";
                        initialValue = "0";
                        description = "";
                        offset = 0;
                    }
                }
            }

            public HardwareConfigurationData hardwareConfigurationData;
            public List<ScheduleGroupData> ScheduleGroupsData;
            public List<RutineData> RutinesData;

            public AutomationPlatformData()
            {
                hardwareConfigurationData = new HardwareConfigurationData();
                ScheduleGroupsData = new List<ScheduleGroupData>();
                RutinesData = new List<RutineData>();
            }


        }

    }
}
