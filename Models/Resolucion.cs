using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadEnElAula10.Models
{
    [Serializable]
    public class Resolucion : IExportable
    {
        public Solicitud Solicitud { get; set; }
        public string Descripcion { get; set; }
        public Resolucion(string Descripcion, Solicitud Solicitud)
        {
            this.Descripcion = Descripcion;
            this.Solicitud = Solicitud;
        }
        public string Exportar()
        {
            return $"{Descripcion};{Solicitud.Numero};{Solicitud.Exportar()}";
        }

        public void Importar(string datos)
        {

        }
        public override string ToString()
        {
            return $"{Solicitud.Numero}({Descripcion.Substring(0, Math.Min(Descripcion.Length, 20))})";
        }
    }

}
