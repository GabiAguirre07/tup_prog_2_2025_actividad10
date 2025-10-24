using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadEnElAula10.Models
{
    [Serializable]
    public class CentroAtencion
    {
        LinkedList<Solicitud> SolicitudesEntrantes = new LinkedList<Solicitud>();
        Queue<Solicitud> colaDeAtencion = new Queue<Solicitud>();
        Stack<Resolucion> pilaHistorica = new Stack<Resolucion>();

        public void ImportarCSVSolicitudesEntrantes(FileStream fs)
        {
            StreamReader sr = new StreamReader(fs);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Solicitud solicitud = new Solicitud();//Creamos una nueva solicitud por cada linea del archivo
                string linea = sr.ReadLine();
                solicitud.Importar(linea);
                AgregarSolicitudSiNoExiste(solicitud);
            }
            sr.Close();
        }
        public void ExportarCSVHistorialResoluciones(FileStream fs)
        {
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Descripción Resolución; Número de Solicitud; Descripción de Solicitud");
            foreach (Resolucion resolucion in pilaHistorica)
            {
                sw.WriteLine(resolucion.Exportar());
            }
            sw.Close();
        }
        public LinkedListNode<Solicitud> GetSolicitudPendiente()
        {
            if (SolicitudesEntrantes.Count > 0)
                return SolicitudesEntrantes.First;
            return null;
        }
        public void Atender(Solicitud solicitud)
        {
            LinkedListNode<Solicitud> encontrada = SolicitudesEntrantes.Find(solicitud);
            if (encontrada != null)//Si encontró la solicitud la elimina de la lista enlazada(pendientes) y la agrega a la cola de atención(Queue)
            {
                SolicitudesEntrantes.Remove(solicitud);//Elimina
                colaDeAtencion.Enqueue(solicitud);//Agrega
            }
        }
        public string[] VerDescripcionColaAtencion()
        {
            string[] descripciones = new string[colaDeAtencion.Count];
            int n = 0;
            foreach (Solicitud solicitud in colaDeAtencion)
            {
                descripciones[n++] = solicitud.ToString();
            }

            return descripciones;
        }
        public string[] VerDescripcionPilaHistorica()
        {
            string[] descripciones = new string[pilaHistorica.Count];
            int n = 0;
            foreach (Resolucion resolucion in pilaHistorica)
            {
                descripciones[n++] = resolucion.ToString();
            }

            return descripciones;
        }
        public Solicitud ResolverSolicitudEnEspera()
        {
            if (colaDeAtencion.Count > 0)
            {
                Solicitud solicitud = colaDeAtencion.Dequeue();// Se resuelve la solicitud mas antigua en la cola de atención
                string Descripcion = "Solicitud Atendida!! vuelva pronto, lo esperamos con ansias!!!!";
                Resolucion resolucion = new Resolucion(Descripcion, solicitud);
                pilaHistorica.Push(resolucion);//Registramos la resolución en la pila
                return solicitud;
            }
            return null;
        }
        protected bool AgregarSolicitudSiNoExiste(Solicitud nueva)
        {
            foreach (Solicitud existente in SolicitudesEntrantes)
            {
                if (existente.Numero == nueva.Numero)
                {
                    MessageBox.Show($"La solicitud {nueva.Numero} ya existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            foreach (Solicitud enCola in colaDeAtencion)
            {
                if (enCola.Numero == nueva.Numero)
                {
                    MessageBox.Show($"La solicitud {nueva.Numero} ya está en cola de atención", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            foreach (Resolucion res in pilaHistorica)
            {
                if (res.Solicitud.Numero == nueva.Numero)
                {
                    MessageBox.Show($"La solicitud {nueva.Numero} ya fue atendida previamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            SolicitudesEntrantes.AddLast(nueva);
            return true;
        }
    }
}
