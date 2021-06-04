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
    public partial class _Default : Page
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                listaArticulos = (List<Articulo>)Session["ListArticulos"];
               
                if (Session["ListArticulos"] == null) // si la session "lista Aritculo" es nulo o la lista de articulos no tiene elementos
                {
                    listaArticulos = negocio.listar();                                //llenamos la variable listaArticulos de todos los articulos en base de datos
                    Session.Add("ListArticulos", listaArticulos);
                    return;
                }

                Session.Add("ListArticulos", listaArticulos);
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }

        }
    }
}