using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;


namespace Catálogo_Web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                usuario.Id = negocio.registrarUsuario(usuario);
                Session.Add("usuario", usuario);
                Response.Redirect("default.aspx", false);
                //if (negocio.logear(usuario))
                //{
                //    Session.Add("usuario", usuario);
                //    Response.Redirect("MenuLogin.aspx", false);
                //}
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}