using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catálogo_Web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    Session.Add("listaArticulos", negocio.listarFavoritos(1));
                    Session.Add("listaMarcas", marcaNegocio.listar());
                    Session.Add("listaCategarias", categoriaNegocio.listar());
                    dgvFavoritos.DataSource = Session["listaArticulos"];
                    dgvFavoritos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvFavoritos.SelectedDataKey.Value.ToString();
            Session.Add("Id", id);
            Response.Redirect("Detalles.aspx", false);
        }
    }
}