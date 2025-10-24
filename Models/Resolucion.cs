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
       
        public Resolucion(string descripcion,Solicitud solicitud)
        {
            Descripcion = descripcion;
            Solicitud = solicitud;
        }
        public string Exportar()
        {
            return $"{Descripcion};{Solicitud.Exportar()}";
        }
        public void Importar(string datos)
        {

        }
        public override string ToString()
        {
            return $"{Solicitud.Numero}({Descripcion.Substring(0,Math.Min(Descripcion.Length,20))})";
        }
    }

}
