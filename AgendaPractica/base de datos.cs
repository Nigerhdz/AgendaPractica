using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPractica
{
    internal class base_de_datos
    {
        public List<Persona> personas { get; set; } 
        public DateTime UltimaActualizacion { get; set; }

        public int TotalRegistros { get; set; }

        public base_de_datos()
        {
            personas = new List<Persona>();
            UltimaActualizacion = DateTime.Now;

        }
        public base_de_datos(List<Persona> personas)
        { 
            this.personas = personas;
            UltimaActualizacion = DateTime.Now;
            TotalRegistros = personas.Count;
        }
    }
}
