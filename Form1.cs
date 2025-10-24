using ActividadEnElAula10.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace ActividadEnElAula10
{
    public partial class Form1 : Form
    {
        CentroAtencion CentroAtencion = new CentroAtencion();
        public Form1()
        {
            InitializeComponent();
            lbxVerSolicitudesImportadas.SelectedIndexChanged += SelectedValueItem;
        }
        protected void VerSolicitudesPendientes()
        {
            lbxVerSolicitudesImportadas.Items.Clear();
            LinkedListNode<Solicitud> solicitud = CentroAtencion.GetSolicitudPendiente();
            while (solicitud != null)
            {
                lbxVerSolicitudesImportadas.Items.Add(solicitud.Value);
                solicitud = solicitud.Next;
            }
        }

        protected void VerSolicitudesAAtender()
        {
            lbxColaSolicitudesAAtender.Items.Clear();
            lbxColaSolicitudesAAtender.Items.AddRange(CentroAtencion.VerDescripcionColaAtencion());
        }

        protected void VerHistorialResoluciones()
        {
            lbxHistorialResoluciones.Items.Clear();
            lbxHistorialResoluciones.Items.AddRange(CentroAtencion.VerDescripcionPilaHistorica());
        }

        private void SelectedValueItem(object sender, EventArgs e)
        {
            Solicitud seleccionada = lbxVerSolicitudesImportadas.SelectedItem as Solicitud;
            if (seleccionada != null)
            {
                lbSolicitudSeleccionada.Text = seleccionada.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = null;
            try
            {
                    fs = new FileStream("Estado.bin", FileMode.OpenOrCreate, FileAccess.Read);
#pragma warning disable SYSLIB0011
                    BinaryFormatter bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    CentroAtencion = (CentroAtencion)bf.Deserialize(fs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recuperar el estado del sistema: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            VerSolicitudesPendientes();
            VerSolicitudesAAtender();
            VerHistorialResoluciones();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Estado.bin");
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
#pragma warning disable SYSLIB0011
                BinaryFormatter bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                bf.Serialize(fs, CentroAtencion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al persistir el estado del sistema: {ex.Message}","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        private void btnImportarSolicitudes_Click(object sender, EventArgs e)
        {
            opfd.Filter = "Archivos .csv|*.csv";
            if (opfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                string path = opfd.FileName;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    CentroAtencion.ImportarCSVSolicitudesEntrantes(fs);
                    MessageBox.Show("Archivo importado con éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al importar las solicitudes: {ex.Message}","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
            VerSolicitudesPendientes();
        }

        private void btnConfirmarAtencion_Click(object sender, EventArgs e)
        {
            Solicitud seleccionada = lbxVerSolicitudesImportadas.SelectedItem as Solicitud;
            if (seleccionada != null)
            {
                CentroAtencion.Atender(seleccionada);
                lbxVerSolicitudesImportadas.Items.Remove(seleccionada);
                VerSolicitudesAAtender();
            }
            else
            {
                MessageBox.Show("Error al atender la solicitud especificada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResolverSolicitud_Click(object sender, EventArgs e)
        {
            Solicitud resuelta = CentroAtencion.ResolverSolicitudEnEspera();
            if (resuelta != null)
            {
                lbxColaSolicitudesAAtender.Items.Remove(resuelta.ToString());//Elimino la solicitud de la cola de atención
                VerHistorialResoluciones();
            }
            else
            {
                MessageBox.Show("Error al resolver la solicitud", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarResoluciones_Click(object sender, EventArgs e)
        {
            svfd.Filter = "Archivos .csv|*.csv";
            if (svfd.ShowDialog() == DialogResult.OK)
            {
                string path = svfd.FileName;
                FileStream fs = null;
                try
                {
                    fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    CentroAtencion.ExportarCSVHistorialResoluciones(fs);
                    MessageBox.Show("Solicitudes exportadas con éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar las solicitudes: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }

        }
    }
}
