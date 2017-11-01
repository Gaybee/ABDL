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
            /*
             * este modulo hace inspecciones periodicas de un grupo determinado de registro
             * aca se define el periodo
             * hay que hacer metodos para arrancar y parar
             * hay que hacer procedimientos para agregar y quitar variables a la lista de registros inspeccionados
             * las clases de UI pueden tomar referencia directa a los objetos en la lista para evitar buscar cada vez que necesitan
             * saber el valor online
             * 
             */
            public int period { get; set; }
            public AutomationWorkspaceData.AutomationPlatformData automationPlatform { get; set; }
            public List<RegisterInspection> registersInspected { get; set; }
            public bool inspecting { get; set; }


            public AutomationInspection(ref AutomationWorkspaceData.AutomationPlatformData automationPlatform)
            {
                period = 500;
                this.automationPlatform = automationPlatform;
                registersInspected = new List<RegisterInspection>();
            }

            
        }

    }
}
