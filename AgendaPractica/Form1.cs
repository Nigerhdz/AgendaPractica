using Newtonsoft.Json;
using System.Security.AccessControl;

namespace AgendaPractica
{
    public partial class Form1 : Form
    {
        int inicializacion = 0;
        bool autoGuardado = false;
        string archivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "informacion.json");


        public Form1()
        {
            InitializeComponent();
            var json = File.ReadAllText(archivoJson);
            var registros = JsonConvert.DeserializeObject<base_de_datos>(json);
            cargarRegistros(registros);
            autoGuardado = true;
        }
        private base_de_datos Cargardatos()
        {

            var registros = new base_de_datos();
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (fila.IsNewRow) continue;
                var persona = new Persona();
                {
                    persona.nombre = fila.Cells[0].Value?.ToString() ?? string.Empty;
                    persona.appaterno = fila.Cells[1].Value?.ToString() ?? string.Empty;
                    persona.apMaterno = fila.Cells[2].Value?.ToString() ?? string.Empty;
                    persona.direccion = fila.Cells[3].Value?.ToString() ?? string.Empty;
                    persona.telefono = fila.Cells[4].Value?.ToString() ?? string.Empty;
                    persona.correo = fila.Cells[5].Value?.ToString() ?? string.Empty;
                }
                registros.personas.Add(persona);
            }
            registros.TotalRegistros = registros.personas.Count;
            return registros;

        }
        private void GuardarJson(base_de_datos lista)
        {
            var caractetisticas = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore,
            };
            string json = JsonConvert.SerializeObject(lista, caractetisticas);
            File.WriteAllText(archivoJson, json);
        }
        private void cargarRegistros(base_de_datos registros)
        {
            dgvDatos.Rows.Clear();
            if (registros != null && registros.personas != null && registros.personas.Count > 0)
            {
                foreach (var persona in registros.personas)
                {
                    dgvDatos.Rows.Add(persona.nombre,
                                      persona.appaterno,
                                      persona.apMaterno,
                                      persona.direccion,
                                      persona.telefono,
                                      persona.correo);
                }
            }
            else
            {
                MessageBox.Show("No hay registros en el json", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var registros = Cargardatos();
            GuardarJson(registros);
            MessageBox.Show("Datos guardados correctamente", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            inicializacion++;

            if (autoGuardado == true && inicializacion > 6)
            {
                try
                {
                    var baseDeDatos = Cargardatos();
                    GuardarJson(baseDeDatos);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "sistem Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
