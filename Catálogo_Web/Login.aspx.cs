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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
                Response.Redirect("default.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.Email = txtUsuario.Text;
                usuario.Pass = txtPass.Text;
                if (negocio.logear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Email o contraseña incorrectas");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}