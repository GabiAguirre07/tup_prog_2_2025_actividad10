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
        private LinkedList<Solicitud> solicitudesPendientes = new LinkedList<Solicitud>();
        private Queue<Solicitud> colaDeAtencion = new Queue<Solicitud>();
        private Stack<Resolucion> pilaHistorica = new Stack<Resolucion>();

        public void ImportarCSVSolicitudesEntrantes(FileStream fs)
        {
            StreamReader sr = new StreamReader(fs);
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                Solicitud solicitud = new Solicitud();
                solicitud.Importar(linea);
                AgregarSolicitudSiNoExiste(solicitud);
            }
            sr.Close();
        }
        public void ExportarCSVHistorialResoluciones(FileStream fs)
        {
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Descripción Resolución; Número de Solicitud; Descripción Solicitud");
            foreach(Resolucion resolucion in pilaHistorica)
            {
                sw.WriteLine(resolucion.Exportar());
            }
            sw.Close();
        }
        public LinkedListNode<Solicitud> GetSolicitudPendiente()
        {
            if (solicitudesPendientes.Count > 0)
            {
            return solicitudesPendientes.First;
            }
            return null;
        }
        public void Atender(Solicitud solicitud)
        {
            LinkedListNode<Solicitud> encontrada = solicitudesPendientes.Find(solicitud);
            solicitudesPendientes.Remove(solicitud);
            colaDeAtencion.Enqueue(solicitud);
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
        public Solicitud ResolverSolicitudEnEspera()//Es de tipo Solicitud ya que necesito retornarla para poder eliminarla de la lista de solicitudes en cola de atención.
        {
            if (colaDeAtencion.Count > 0)
            {
                Solicitud resuelta = colaDeAtencion.Dequeue();//se resuelve la solicitud mas antigua en la cola de atención.
                string Descripcion = "Solicitud Atendida!!, lo esperamos nuevamente con ansias!";
                Resolucion resolucion = new Resolucion(Descripcion, resuelta);
                pilaHistorica.Push(resolucion);
                return resuelta;
            }
            return null;
        }
        public string[] VerDescripcionPilaHistorica()
        {
            string[] descripciones = new string[pilaHistorica.Count];
            int n = 0;
            foreach(Resolucion resolucion in pilaHistorica)
            {
                descripciones[n++] = resolucion.ToString();
            }
            return descripciones;
        }
        protected bool AgregarSolicitudSiNoExiste(Solicitud nueva)
        {
            foreach (Solicitud existente in solicitudesPendientes)
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

            solicitudesPendientes.AddLast(nueva);
            return true;
        }
    }
}
