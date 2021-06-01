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
        protected void Page_Load(object sender, EventArgs e)
        {

            listaBuscar = (List<Articulo>)Session["ListArticulos"];
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> lista = new List<Articulo>();
            ArticuloNegocio Negocio = new ArticuloNegocio();

            try
            {
                lista = Negocio.listar();
                listaBuscar = lista.FindAll(x => x.nombre.ToLower().Contains(TexBuscar.Text.ToLower()) || x.marca.nombre.ToLower().Contains(TexBuscar.Text.ToLower())); //buscamos coinsidencias por nombre o por marca
                Session.Add("ListArticulos", listaBuscar);     // agregamos a la session "carrito" el articulo encontrado 
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}