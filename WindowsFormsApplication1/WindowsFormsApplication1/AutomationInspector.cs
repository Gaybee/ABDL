using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAutomationPlatform
{
    public partial class AutomationInspector
    {
        /*el inspector contiene una coleccion de inspecciones. Cada inspeccion contiene un listado de registros que se consultan.
         * Entonces, una ventana que contiene logica puede generar una inspeccion.
         * Asi mismo, un cuadro de tendencia, o un listado de variables, pueden generar una inspeccion.
         * se podria usar para armar hmi
         */
        public List<AutomationInspection> automationInspections { get; set; }

        
        public AutomationInspector()
        {
            automationInspections = new List<AutomationInspection>();
        }
    }

}
