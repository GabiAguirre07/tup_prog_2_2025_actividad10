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
            var nodo = CentroAtencion.GetSolicitudPendiente();
            while (nodo != null)
            {
                lbxVerSolicitudesImportadas.Items.Add(nodo.Value);
                nodo = nodo.Next;
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
                lbSolicitudSeleccionada.Text = seleccionada.Motivo;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("Estado.dat", FileMode.OpenOrCreate, FileAccess.Read);
#pragma warning disable SYSLIB0011 // El tipo o el miembro están obsoletos
                BinaryFormatter bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                this.CentroAtencion = (CentroAtencion)bf.Deserialize(fs);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al recuperar el estado del sistema", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (fs != null) fs.Close(); }
            VerSolicitudesPendientes();
            VerSolicitudesAAtender();
            VerHistorialResoluciones();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Estado.dat");
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
#pragma warning disable SYSLIB0011
                BinaryFormatter bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                bf.Serialize(fs, CentroAtencion);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al persistir el estado del sistema", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string path = opfd.FileName;
                FileStream fs = null;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    CentroAtencion.ImportarCSVSolicitudesEntrantes(fs);
                    MessageBox.Show("Archivo importado exitosamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al importar el archivo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
                VerSolicitudesPendientes();
            }
        }

        private void btnConfirmarAtencion_Click(object sender, EventArgs e)
        {
            Solicitud seleccionada = lbxVerSolicitudesImportadas.SelectedItem as Solicitud;
            if (seleccionada != null)
            {
                CentroAtencion.Atender(seleccionada);
                VerSolicitudesAAtender();
                lbxVerSolicitudesImportadas.Items.Remove(seleccionada);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una solicitud pendiente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResolverSolicitud_Click(object sender, EventArgs e)
        {
            Solicitud resuelta = CentroAtencion.ResolverSolicitudEnEspera();
            if (resuelta != null)
            {
                VerHistorialResoluciones();
                lbxColaSolicitudesAAtender.Items.Remove(resuelta.ToString());
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
                    MessageBox.Show("Resoluciones exportadas exitosamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar las resoluciones", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
        }
    }
}
