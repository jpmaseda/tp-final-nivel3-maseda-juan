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
    public partial class Detalles : System.Web.UI.Page
    {
        public bool CheckConfirmar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            string decimalSeparator = ci.NumberFormat.CurrencyDecimalSeparator;
            string groupSeparator = ci.NumberFormat.CurrencyGroupSeparator;
            lblAdvertencia.Text = "El precio debe contener números enteros o decimales con '" + decimalSeparator + "' para separar decimales y '" + groupSeparator + "' para separa grupos de mil.";
            CheckConfirmar = false;
            btnEliminar.Enabled = false;
            //btnInactivar.Enabled = false;
            if (txtId.Text != "")
                btnEliminar.Enabled = true;
            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                    if (Request.QueryString["Id"] != null)
                        Session["Id"] = Request.QueryString["Id"];
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                Response.Redirect("Error.aspx", false);
            }
            if (Session["Id"] != null)
            {
                btnAceptar.Text = "Modificar";
                btnEliminar.Enabled = true;
                //btnInactivar.Enabled = true;
                List<Articulo> temporal = (List<Articulo>)Session["listaArticulos"];
                int id = int.Parse(Session["Id"].ToString());
                Articulo seleccionado = temporal.Find(x => x.Id == id);
                Session.Add("articuloSeleccionado", seleccionado);
                txtId.Text = seleccionado.Id.ToString();
                txtCodigo.Text = seleccionado.Codigo.ToString();
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion.ToString();
                txtPrecio.Text = seleccionado.Precio.ToString("N");
                txtUrlImagen.Text = seleccionado.urlImagen.ToString();
                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                imgTapa.ImageUrl = txtUrlImagen.Text;
                //if (seleccionado.Activo == false)
                //    btnInactivar.Text = "Reactivar";
                Session["Id"] = null;
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                Articulo nuevo = new Articulo();
                nuevo.Marca = new Marca();
                nuevo.Categoria = new Categoria();
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.urlImagen = txtUrlImagen.Text;
                if (decimal.TryParse(txtPrecio.Text, out decimal result))
                    nuevo.Precio = decimal.Parse(txtPrecio.Text);
                else
                {
                    lblErrorFormato.Text = "FORMATO INCORRECTO";
                    return;
                }
                if (txtId.Text != "")
                {
                    nuevo.Id = int.Parse(txtId.Text.ToString());
                    negocio.modificar(nuevo);
                }
                else
                    negocio.agregar(nuevo);

                Response.Redirect("Listado.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgTapa.ImageUrl = txtUrlImagen.Text;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CheckConfirmar = true;
        }
        protected void btnConfEliminar_Click(object sender, EventArgs e)
        {
            if (chkConfimarEliminar.Checked)
            {
                try
                {
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    negocio.eliminarFisico(int.Parse(txtId.Text));
                    Response.Redirect("Listado.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.Message.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }

        }

    }
}