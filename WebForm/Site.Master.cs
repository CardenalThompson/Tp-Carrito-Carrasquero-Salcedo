using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negosio;

namespace WebForm
{
    public partial class SiteMaster : MasterPage
    {
        public List<Articulo> listaBuscar { get; set; }
        public string cont;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> listaarticulo = new List<Articulo>();

            if (Session["carrito"]==null)
            {
                Session.Add("carrito", new List<Articulo>());
            }
            else
            {
                listaarticulo = (List<Articulo>)Session["carrito"];
                cont = listaarticulo.Count.ToString();
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> lista = new List<Articulo>();
            ArticuloNegocio Negocio = new ArticuloNegocio();
                if (TexBuscar.Text!="")
                {
                   lista = Negocio.listar();
                   listaBuscar = lista.FindAll(x => x.nombre.ToLower().Contains(TexBuscar.Text.ToLower()) || x.marca.nombre.ToLower().Contains(TexBuscar.Text.ToLower())); //buscamos coinsidencias por nombre o por marca
                   Session.Add("ListBuscar", listaBuscar);     // agregamos a la session "carrito" el articulo encontrado 
                   Response.Redirect("Default.aspx");                       
                }
        }
    }
}