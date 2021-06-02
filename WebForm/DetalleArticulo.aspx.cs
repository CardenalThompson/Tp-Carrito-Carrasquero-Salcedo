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
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["idArticulo"]);
            List<Articulo> listado = (List<Articulo>)Session["ListArticulos"];
            Articulo articulo = listado.Find(x => x.id == id);

            if (articulo == null)
            {
                return;
            }

            lblselecionado.Text = articulo.nombre;
            Imagenselecionado.ImageUrl = articulo.imagen;
            lblMarca.Text = articulo.marca.nombre;
            lblPrecio.Text = articulo.precio.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}