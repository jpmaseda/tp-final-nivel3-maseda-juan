using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Collections;

namespace Catálogo_Web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public bool CheckGrilla { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckGrilla = true;
            if (!IsPostBack)
            {
                try
                {
                    vincularLista();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.Message.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
        protected void dgvFavoritos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Getting the values of DataKeys inside RowCommand Event
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Get the value of column from the DataKeys using the RowIndex.
            int idArticulo = Convert.ToInt32(dgvFavoritos.DataKeys[rowIndex].Values[0]);

            //Botón para quitar de favoritos
            if (e.CommandName == "quitarFav")
                try
                {
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    negocio.eliminarFavoritos(((Usuario)Session["usuario"]).Id, idArticulo);
                    vincularLista();
                    return;
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.Message.ToString());
                    Response.Redirect("Error.aspx", false);
                }

            //Botón para ver detalles
            if (e.CommandName == "detalles")
            {
                Session.Add("Id", idArticulo);
                Response.Redirect("Detalles.aspx", false);
            }

        }

        protected void btnGrilla_Click(object sender, EventArgs e)
        {
            CheckGrilla = true;
        }

        protected void btnImagen_Click(object sender, EventArgs e)
        {
            CheckGrilla = false;
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            int fav = int.Parse(((Button)sender).CommandArgument);
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                negocio.eliminarFavoritos(((Usuario)Session["usuario"]).Id, fav);
                vincularLista();
                CheckGrilla = false;
                return;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void vincularLista()
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            if (Session["usuario"] != null)
            {
                Session.Add("listaFav", negocio.listarFavoritos(((Usuario)Session["usuario"]).Id));
                dgvFavoritos.DataSource = Session["listaFav"];
                dgvFavoritos.DataBind();
                repFavoritos.DataSource = Session["listaFav"];
                repFavoritos.DataBind();
            }
        }
    }
}