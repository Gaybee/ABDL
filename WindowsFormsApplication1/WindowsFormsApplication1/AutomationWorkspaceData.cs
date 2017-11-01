using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using static OpenAutomationPlatform.AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData;
using static OpenAutomationPlatform.AutomationWorkspaceData.AutomationPlatformData;
using static OpenAutomationPlatform.AutomationWorkspaceData.AutomationPlatformData.RutineData;
using static OpenAutomationPlatform.RutineBDUI.OperationBDUI;

namespace OpenAutomationPlatform
{
    public interface IBDUI
    {
        //Interface for Block Diagram User Interface.
       // IBDUI parent { get; set; }
        Graphics graphics { get; }
        //Brush brush { get; set; }
        //Pen pen { get; set; }
        //Font font { get; set; }
        bool selected { get; set; }
        bool HitTest(PointF hitPoint);
        event PaintEventHandler Paint;
    }
    
    public partial class AutomationWorkspaceData
    {
        
        public List<AutomationPlatformData> AutomationPlatformsData { get; set; }
        
        public AutomationWorkspaceData()
        {
            AutomationPlatformsData = new List<AutomationPlatformData>();
        }
    }

   
    
}
