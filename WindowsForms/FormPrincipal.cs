using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negosio;

namespace WindowsForms
{
    public partial class FormPrincipal : Form
    {
        Articulo artiActual = new Articulo();
        List<Articulo> lista; //creo una lista golbal que me sirve para llenar la gridview con la lista total de articulos
        public FormPrincipal(string nom)
        {
            InitializeComponent();
            Saludo.Text += nom;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnIvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvlista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                artiActual = (Articulo)dgvlista.CurrentRow.DataBoundItem; // trae  el articulo de la fila seleccionada
                pbImagen.Load(artiActual.imagen);
            }
            catch
            {
                pbImagen.Load("noimagen.png");  // si no hay una imagne de articulo  se muestra un imagen del error
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            DetalleProducto detalle = new DetalleProducto(artiActual);
            detalle.ShowDialog();

            CargarGrilla();
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> listafilro = lista.FindAll(x => x.nombre.ToUpper().Contains(tbfiltro.Text.ToUpper()) || x.marca.nombre.ToUpper().Contains(tbfiltro.Text.ToUpper()));
            dgvlista.DataSource = listafilro;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormUpdate editar = new FormUpdate();
            editar.ShowDialog();

            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                ArticuloNegocio arti = new ArticuloNegocio();
                lista = arti.listar();
                dgvlista.DataSource = lista;   // carga el datagridview  la lista de articulos
                dgvlista.Columns[0].Visible = false;
                dgvlista.Columns[3].Visible = false;    // ocultamos la columna 4 que contiene la descripcion del producto
                dgvlista.Columns[4].Visible = false;    // ocultamos la columna 4 que contiene la url de imagene
                LimpiarFiltro();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error listando los artículos");
            }
        }

        private void tbfiltro_KeyUp(object sender, KeyEventArgs e)
        {
            List<Articulo> listafilro = lista.FindAll(x =>  x.nombre.ToUpper().Contains(tbfiltro.Text.ToUpper()) || 
                                                            x.marca.nombre.ToUpper().Contains(tbfiltro.Text.ToUpper()) ||
                                                            x.codigo.ToUpper().Contains(tbfiltro.Text.ToUpper()) ||
                                                            x.descripcion.ToUpper().Contains(tbfiltro.Text.ToUpper()) || 
                                                            x.categoria.nombre.ToUpper().Contains(tbfiltro.Text.ToUpper()));
            dgvlista.DataSource = listafilro;
        }

        private void LimpiarFiltro()
        {
            tbfiltro.Text = string.Empty;
        }
    }
}
