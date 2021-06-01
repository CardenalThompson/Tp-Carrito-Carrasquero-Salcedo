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
    public partial class FormUpdate : Form
    {

        private Articulo articulo = null;

        public FormUpdate()
        {
            InitializeComponent();

        }

        public FormUpdate(Articulo arti)
        {
            InitializeComponent();
            articulo = arti;
            this.Text = "Modificar artículo";
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            MarcaNegosio marca = new MarcaNegosio();
            cbMarca.DataSource = marca.listar();    // llena el comno box con la lista de marcas
            cbMarca.ValueMember = "id";
            cbMarca.DisplayMember = "nombre";
            cbMarca.SelectedIndex = -1;

            CategoriaNegosio cat = new CategoriaNegosio();
            cbCategoria.DataSource = cat.listar();    // llena el comno box con la lista de categorias
            cbCategoria.ValueMember = "id";
            cbCategoria.DisplayMember = "nombre";
            cbCategoria.SelectedIndex = -1;

            if (articulo != null)
            {
                tbCodigo.Text = articulo.codigo;
                tbNombre.Text = articulo.nombre;
                tbDescripcion.Text = articulo.descripcion;
                tbImagen.Text = articulo.imagen;
                tbPrecio.Text = Convert.ToString(articulo.precio);

                cbMarca.SelectedValue = articulo.marca.id;
                cbCategoria.SelectedValue = articulo.categoria.id;
            }    
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (validarCampo())
            {
                if (articulo == null) articulo = new Articulo();

                ArticuloNegocio articuloNegosio = new ArticuloNegocio();
                articulo.codigo = tbCodigo.Text;              
                articulo.nombre = tbNombre.Text;              
                articulo.descripcion = tbDescripcion.Text;    
                articulo.imagen = tbImagen.Text;
                articulo.marca = (Marca)cbMarca.SelectedItem;
                articulo.categoria = (Categoria)cbCategoria.SelectedItem;
                articulo.precio = decimal.Parse(tbPrecio.Text);

                if (articulo.id > 0)
                {                                           
                    if (articuloNegosio.editar(articulo))
                    {
                        MessageBox.Show("Se editó el artículo correctamente");   
                    }
                    else
                    {
                        MessageBox.Show("No se pudo editar el artículo");
                    }
                }
                else
                {
                    if (articuloNegosio.agregar(articulo))
                    {
                        MessageBox.Show("Se agregó el artículo correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el artículo");
                    }
                }
                this.Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarCampo()
        {
            string mensaje = "este campo no puede estar vacio";

            if (tbCodigo.Text.Trim() == string.Empty )
            {
                errorProvider1.SetError(tbCodigo,mensaje);
                return false;
            }
            else
            {
                errorProvider1.SetError(tbCodigo, string.Empty);
            }
            if (tbNombre.Text.Trim() == string.Empty)
            {
               
                errorProvider1.SetError(tbNombre, mensaje);
                return false;
            }
            else
            {
                errorProvider1.SetError(tbNombre, string.Empty);
            }
            if (tbDescripcion.Text.Trim() == String.Empty) // si esta vacio 
            {
               
                errorProvider1.SetError(tbDescripcion, mensaje);
                return false;
            }
            else
            {
                errorProvider1.SetError(tbDescripcion, string.Empty);
            }
            if (cbMarca.SelectedIndex <= -1)
            {
                
                errorProvider1.SetError(cbMarca, mensaje);
                return false;
            }
            else
            {
                errorProvider1.SetError(cbMarca, string.Empty);
                
            }

            if (cbCategoria.SelectedIndex <= -1)
            {
                errorProvider1.SetError(cbCategoria, mensaje);
                return false;
            }
            else
            { 
                errorProvider1.SetError(cbCategoria, string.Empty); 
            }

            if (tbPrecio.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(tbPrecio, mensaje);
                return false;
            }
            else
            {
                errorProvider1.SetError(tbPrecio, string.Empty);
            }

            decimal precio = 0;
            bool esNumero = decimal.TryParse(tbPrecio.Text.Trim(), out precio);
            if (!esNumero)
            {
                errorProvider1.SetError(tbPrecio, "El precio no posee un formato correcto");
                return false;
            }
            else
            {
                errorProvider1.SetError(tbPrecio, string.Empty);
            }

            return true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
