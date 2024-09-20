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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is _default || Page is Login || Page is Registro || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }

            if (Seguridad.sesionActiva(Session["usuario"]) && ((Usuario)Session["usuario"]).ImagenPerfil != null)
                imgPerfil.ImageUrl = "~/images/perfiles/" + ((Usuario)Session["usuario"]).ImagenPerfil;
            else
                imgPerfil.ImageUrl = "~/images/circle.png";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}