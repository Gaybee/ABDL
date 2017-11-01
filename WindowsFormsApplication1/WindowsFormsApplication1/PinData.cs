using System;
using System.Collections.Generic;
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
                    public class PinData
                    {
                        public enum PinType { input, output, status };

                        public int number { get; set; }
                        public string name { get; set; }
                        public string data { get; set; }
                        public PinType pinType { get; set; }

                        public PinData()
                        {
                            number = 1;
                            name = "STATUS";
                            data = "status0";
                            pinType = PinType.status;
                        }
                        public PinData(int number, string name, string data, PinType pinType)
                        {
                            this.number = number;
                            this.name = name;
                            this.data = data;
                            this.pinType = pinType;
                        }
                        public PinData(PinData pinData)
                        {
                            this.number = pinData.number;
                            this.name = pinData.name;
                            this.data = pinData.data;
                            this.pinType = pinData.pinType;
                        }
                    }

                }
            }
        }

    }
}