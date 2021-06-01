using System;
using System.Windows.Forms;
using Dominio;
using Negosio;

namespace WindowsForms
{
    public partial class DetalleProducto : Form
    {
        Articulo _arti = new Articulo();
        public DetalleProducto(Articulo arti)
        {
            InitializeComponent();
            _arti = arti;
        }

        private void DetalleProducto_Load(object sender, EventArgs e)
        {
            try
            {
                lbCodigo.Text = _arti.codigo;
                lbNombre.Text = _arti.nombre;
                lbDes.Text = _arti.descripcion;
                lbCat.Text = _arti.categoria.nombre;
                lbMarca.Text = _arti.marca.nombre;
                lbPrecio.Text = Convert.ToString(_arti.precio);
            
                pbImag.Load(_arti.imagen);
            }
            catch
            {
                pbImag.Load("noimagen.png");
            }

        }

        private void btnIVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormUpdate modificar = new FormUpdate(_arti);
            modificar.ShowDialog();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                DialogResult r = MessageBox.Show("esta seguro de esta operacion", "confirmacion", MessageBoxButtons.YesNo);

                if (r == DialogResult.Yes)
                {
                    negocio.eliminar(_arti.id);
                    MessageBox.Show("el articulo se elimino correctamente");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el articulo");
                Console.WriteLine("Excepcion: " + ex.Message);
            }
        }
    }
}
