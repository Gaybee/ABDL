using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OpenAutomationPlatform.AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData;

namespace OpenAutomationPlatform
{
    public partial class Form1 : Form
    {
        AutomationLibrary automationLibrary;

        AutomationWorkspaceData automationWorkspaceData;
        AutomationWorkspaceData.AutomationPlatformData automationPlatformData;
        AutomationWorkspaceData.AutomationPlatformData.RutineData rutineData;

        RutineBDUI rutineBDUI;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //construyo una libreria:
            automationLibrary = new AutomationLibrary();
            automationLibrary.dataTypes.Add(new AutomationLibrary.DataTypeDefinition("INT","Signed short integer"));
            automationLibrary.dataTypes.Add(new AutomationLibrary.DataTypeDefinition("UINT", "Unsigned short integer"));
            automationLibrary.dataTypes.Add(new AutomationLibrary.DataTypeDefinition("LONG", "Signed long integer"));
            automationLibrary.dataTypes.Add(new AutomationLibrary.DataTypeDefinition("BOOL", "boolean"));
            automationLibrary.dataTypes.Add(new AutomationLibrary.DataTypeDefinition("FLOAT", "Single precision floating point"));

            AutomationLibrary.OperationDefinition operationDefinition = new AutomationLibrary.OperationDefinition();
            operationDefinition.implementation = "C = A * B;";
            operationDefinition.id = "baselib.AND2";
            operationDefinition.ExecutionOrder = 1;
            operationDefinition.Pins.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData(1,"A","",PinType.input));
            operationDefinition.Pins.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData(1, "B", "", PinType.input));
            operationDefinition.Pins.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData(1, "C", "", PinType.output));
            automationLibrary.OperationsLibrary.Add(operationDefinition);

            operationDefinition = new AutomationLibrary.OperationDefinition();
            operationDefinition.implementation = "C = A + B;";
            operationDefinition.id = "baselib.OR2";
            operationDefinition.ExecutionOrder = 1;
            operationDefinition.Pins.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData(1, "A", "", PinType.input));
            operationDefinition.Pins.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData(1, "B", "", PinType.input));
            operationDefinition.Pins.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData(1, "C", "", PinType.output));
            automationLibrary.OperationsLibrary.Add(operationDefinition);
            
            operationDefinition = new AutomationLibrary.OperationDefinition();
            operationDefinition.implementation = "C = !A";
            operationDefinition.id = "baselib.NOT";
            operationDefinition.ExecutionOrder = 1;
            operationDefinition.Pins.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData(1, "A", "", PinType.input));
            operationDefinition.Pins.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData.PinData(1, "B", "", PinType.output));
            automationLibrary.OperationsLibrary.Add(operationDefinition);


            //creo una plataforma con una operacion
            automationWorkspaceData = new AutomationWorkspaceData();
            automationWorkspaceData.AutomationPlatformsData.Add(automationPlatformData = new AutomationWorkspaceData.AutomationPlatformData());
            automationPlatformData.hardwareConfigurationData.name = "PLC0";
            automationPlatformData.ScheduleGroupsData.Add(new AutomationWorkspaceData.AutomationPlatformData.ScheduleGroupData("Periodic100ms", 100, 0, 99));
            automationPlatformData.RutinesData.Add(rutineData = new AutomationWorkspaceData.AutomationPlatformData.RutineData(automationPlatformData.ScheduleGroupsData[0].id));
            rutineData.OperationsData.Add(new AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData(automationLibrary.OperationsLibrary.Find(x => x.id == "baselib.AND2")));
            rutineData.OperationsData[0].ExecutionOrder = 1;
            rutineData.OperationsData[0].Pins.Find(x => x.name == "A").data = "Registro1";
            rutineData.OperationsData[0].Pins.Find(x => x.name == "B").data = "Registro2";
            rutineData.OperationsData[0].Pins.Find(x => x.name == "C").data = "Registro3";
            rutineData.OperationsData[0].position = new PointF(100, 100);
            //creo la interfaz grafica
            rutineBDUI = new RutineBDUI(this,rutineData);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(b.HitTest(new Point(e.X, e.Y)).ToString());
            //MessageBox.Show(p.HitTest_onLineValue(new Point(e.X,e.Y)).ToString());
        }
    }
}
