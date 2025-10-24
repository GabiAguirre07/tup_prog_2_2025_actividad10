using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadEnElAula10.Models
{
    [Serializable]
    public class Solicitud:IExportable
    {
       public int Numero {  get; set; }
       public string Motivo { get; set; }
       
        public Solicitud() { }
        public Solicitud(int Numero, string motivo)
        {
            this.Numero = Numero;
            Motivo = motivo;
        }

        public string Exportar()
        {
            return $" {Numero};{Motivo}";
        }
        public void Importar(string datos)
        {
            string[] campos = datos.Split(';');
            Numero = Convert.ToInt32(campos[0]);
            Motivo = campos[1];
        }
        public override string ToString()
        {
            return $"{Numero}({Motivo.Substring(0, Math.Min(Motivo.Length, 20))})";//Establece que la cadena "Motivo" tiene un tope de 20 caracteres máximo.
        }
    }
}
