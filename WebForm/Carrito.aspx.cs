﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negosio;
namespace WebForm
{
    public partial class Carrito : System.Web.UI.Page
    {
        public Articulo articuloNuevo { get; set; }
        public List<Articulo> carritoCompra = null;
        private int idArticulo=0;
        decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoCompra = new List<Articulo>();
            if (Session["carrito"] == null)    // si session "carrito" es nulo creamos una session del lista de articulos
            {
                Session.Add("carrito", new List<Articulo>());
            }
    


            if (Request.QueryString["idArticulo"] !=null)
            {
                try
                {
                    idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
                    articuloNuevo = new Articulo();
                    ArticuloNegocio auxNegocio = new ArticuloNegocio();
                    articuloNuevo = auxNegocio.listar().Find(x => x.id == idArticulo);  // le asigna a la variable articulonuevo  el id encontrado
                    carritoCompra = (List<Articulo>)Session["carrito"];
                    carritoCompra.Add(articuloNuevo);
                    Session.Add("carrito", carritoCompra);             //agregamos a la lista secion "carrito" con el nuevo articulo 

                }
                catch (Exception)
                {
                    Response.Redirect("Error.aspx");
                }

            }
            if (Request.QueryString["idCancelar"]!=null)   //si se hizo click en el boton cancelar
            {
                try
                {

                idArticulo = Convert.ToInt32(Request.QueryString["idCancelar"]); //comvertimos a entero el id de articulo
                carritoCompra = (List<Articulo>)Session["carrito"];                   // llenamos  carritoCompra con la session "carrito" que tiene al lista de articulos
                carritoCompra.Remove(carritoCompra.Find(x => idArticulo == x.id)); // se remueve  de la lista de carrito compra el id seleccionado
                Session["carrito"] = carritoCompra;
                }
                catch
                {
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                carritoCompra = (List<Articulo>)Session["carrito"]; // si no se agrega un articulo  se llena carrito compra con la session "carrito"
            }
            cacular();
        }
       private void cacular()
        {
            foreach (var item in carritoCompra)
            {
                total = total + item.precio;
            }
            lbtotal.Text = string.Format("{0:C}", total);

        }
    }
}


//carritoCompra = (List<Articulo>)Session["ListaCarrito"];// mi lista con los Items del carrito q agregue en session
//foreach (var item in carritoCompra)
//{
//    if (item.id == idArticulo)
//    {
//        item.cantidad++;
//    }
//}