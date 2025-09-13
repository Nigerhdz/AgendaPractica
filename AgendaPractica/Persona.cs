using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace AgendaPractica
{
    internal class Persona
    {
        public Persona(string nombre, string appaterno, string apMaterno, string direccion, string telefono, string correo)
        {
            this.nombre = nombre;
            this.appaterno = appaterno;
            this.apMaterno = apMaterno;
            this.direccion = direccion;
            this.telefono  = telefono;
            this.correo    = correo;


        }
        public Persona()
        { 
           this.nombre = "";
            this.appaterno = "";
            this.apMaterno = "";
            this.direccion = "";
            this.telefono = "";
            this.correo = "";
        }
        public string nombre { get; set; }
        public string appaterno { get; set; }
        public string apMaterno { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }









    }

}
