using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAutomationPlatform
{
    public class AutomationLibrary
    {
        public class RuntineDefinition : AutomationWorkspaceData.AutomationPlatformData.RutineData
        {

        }

        public class DataTypeDefinition
        {
            public string name { get; set; }
            public string description { get; set; }
            public DataTypeDefinition(string name, string definition)
            {
                this.name = name;
                this.description = description;
            }
        }
        public class OperationDefinition : AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData
        {
            public string implementation { get; set; }
        }
        public List<AutomationLibrary.OperationDefinition> OperationsLibrary { get; set; }
        public List<AutomationLibrary.RuntineDefinition> rutines { get; set; }
        public List<AutomationLibrary.DataTypeDefinition> dataTypes { get; set; }

        public AutomationLibrary()
        {
            OperationsLibrary = new List<OperationDefinition>();
            rutines = new List<RuntineDefinition>();
            dataTypes = new List<DataTypeDefinition>();
        }
    }
}
