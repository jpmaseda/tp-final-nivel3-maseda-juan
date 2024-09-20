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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    txtEmail.Text = ((Usuario)Session["usuario"]).Email;
                    if (((Usuario)Session["usuario"]).Nombre != null)
                        txtNombre.Text = ((Usuario)Session["usuario"]).Nombre;
                    if (((Usuario)Session["usuario"]).Apellido != null)
                        txtApellido.Text = ((Usuario)Session["usuario"]).Apellido;
                    if (((Usuario)Session["usuario"]).ImagenPerfil != null)
                        imgPerfil.ImageUrl = "~/images/perfiles/" + ((Usuario)Session["usuario"]).ImagenPerfil;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                string ruta = Server.MapPath("./images/perfiles/");
                Usuario usuario = (Usuario)Session["usuario"];
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                if (txtImagen.PostedFile.FileName != "")
                {
                    usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }
                else
                    usuario.ImagenPerfil = null;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;                
                negocio.actualizar(usuario);
                Response.Redirect("default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }    
    }
}