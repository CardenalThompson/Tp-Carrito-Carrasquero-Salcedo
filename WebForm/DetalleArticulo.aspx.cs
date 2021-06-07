using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negosio;

namespace WebForm
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public Articulo articulonuevo { get; set; }
        public List<Articulo> detalles = null;
        private int idArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ArticuloNegocio negosio = new ArticuloNegocio();
            detalles = new List<Articulo>();
            idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
            if (Session["detallearticulo"] == null)    // si session "carrito" es nulo creamos una session del lista de articulos
            {
                Session.Add("detallearticulo", new List<Articulo>());

            }
        try
        {
                int id = int.Parse(Request.QueryString["idArticulo"]);
                articulonuevo = new Articulo();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articulonuevo = articuloNegocio.listar().Find(x => x.id == idArticulo);
                //articulo = negosio.listar();
                //Articulo articulo = articulos.Find(x => x.id == id);
                //List<Articulo> listado = negosio.listar();
                //Articulo articulo = listado.Find(x => x.id == id);
                
                if (detalles == null)
                {
                    return;
                }
                detalles = (List<Articulo>)Session["detallearticulo"];
                detalles.Add(articulonuevo);
                    Session.Add("detallearticulo", detalles);

                //lblselecionado.Text = articulo.nombre;
                //Imagenselecionado.ImageUrl = articulo.imagen;
                //lblMarca.Text = articulo.marca.nombre;
                //lblPrecio.Text = articulo.precio.ToString("C", CultureInfo.CurrentCulture);
                //lblCategoria.Text = articulo.categoria.nombre;
                //lblDescripcion.Text = articulo.descripcion;
                Session.Abandon();
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
        }
        }
    }
