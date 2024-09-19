using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catálogo_Web
{
    public partial class _default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    ListaArticulos = negocio.listar();
                    Session.Add("listaArticulos", ListaArticulos);
                    repArticulos.DataSource = ListaArticulos;
                    repArticulos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            //Agregar a Favoritos con commandargument y Session["Usuario"] y
            //¿redirigir a página fav o que solo muestre una alerta que se agrego y deje seguir agragando?
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            int fav = int.Parse(((Button)sender).CommandArgument);
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                negocio.agregarFavoritos(((Usuario)Session["usuario"]).Id, fav);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Artículo agregado a favoritos.')", true);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}