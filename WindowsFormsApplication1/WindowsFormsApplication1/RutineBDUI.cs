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
        //Rutine Block Diagram User Interface
       
        private Form _form;
        public AutomationWorkspaceData.AutomationPlatformData.RutineData rutineData;

        //public IBDUI parent { get; set; }
        public Graphics graphics { get { return _form.CreateGraphics(); } }
        public Brush brush { get; set; }
        public Font font { get; set; }
        public Pen pen { get; set; }
        //public PointF pointStart { get; set; }
        //public bool selected { get; set; }        
        public Form form
        {
            get
            {
                return form;
            }
            set
            {
                _form = value;
                _form.Paint += (object sender, System.Windows.Forms.PaintEventArgs e) =>
                {
                    if (Paint != null)
                        this.Paint(sender, e);
                };
            }
        }
        public List<OperationBDUI> operationBDUIs { get; set; }

        public event PaintEventHandler Paint;

        public RutineBDUI(Form form)
        {
            brush = Brushes.Black;
            font = form.Font;
            pen = new Pen(brush, 1);
            //pointStart = new PointF(10, 10);
            operationBDUIs = new List<OperationBDUI>();
            this.form = form;
        }

        public RutineBDUI(Form form, AutomationWorkspaceData.AutomationPlatformData.RutineData rutineData)
        {

            brush = Brushes.Black;
            font = form.Font;
            pen = new Pen(brush, 1);
            //pointStart = new PointF(10, 10);
            this.rutineData = rutineData;
            operationBDUIs = new List<OperationBDUI>();
            foreach (AutomationWorkspaceData.AutomationPlatformData.RutineData.OperationData o in rutineData.OperationsData)
                operationBDUIs.Add(new OperationBDUI(this, o));
            this.form = form;
        }
    }

}
