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
    public partial class Listado : System.Web.UI.Page
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
                    Session.Add("listaArticulos", negocio.listar());
                    //Session.Add("listaMarcas", marcaNegocio.listar());
                   // Session.Add("listaCategarias", categoriaNegocio.listar());
                    dgvArticulos.DataSource = Session["listaArticulos"];
                    dgvArticulos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = ((List<Articulo>)Session["listaArticulos"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltrar.Text.ToUpper()) || x.Descripcion.ToUpper().Contains(txtFiltrar.Text.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
            if (txtFiltrar.Text == "")
                dgvArticulos.PageSize = 5;
            else
                dgvArticulos.PageSize = 20;
            dgvArticulos.DataSource = lista;
            dgvArticulos.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Session["listaFiltrada"] = null;
            dgvArticulos.PageSize = 5;
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
            txtFiltrar.Text = "";
            txtFiltroAvanzado.Text = "";
            ddlCampo.Text = "Precio";
            ddlCriterio.Items.Clear();
            ddlCriterio.Items.Add("Mayor a");
            ddlCriterio.Items.Add("Menor a");
            ddlCriterio.Items.Add("Es");
            ddlCriterio.SelectedIndex = 0;
            //ddlEstado.Text = "Todos";
            lblAdvertencia.Text = "";
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            switch (ddlCampo.SelectedItem.ToString())
            {
                case "Marca":
                    ddlCriterio.DataSource = (List<Marca>)Session["listaMarcas"];
                    ddlCriterio.DataBind();
                    break;
                case "Categoría":
                    ddlCriterio.DataSource = (List<Categoria>)Session["listaCategarias"];
                    ddlCriterio.DataBind();
                    break;
                case "Precio":
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                    ddlCriterio.Items.Add("Es");
                    break;
                case "Nombre":
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                    ddlCriterio.Items.Add("Es");
                    break;
            }            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvArticulos.PageSize = 5;
            lblAdvertencia.Text = "";
            if (ddlCampo.Text == "Precio")
            {
                if (!decimal.TryParse(txtFiltroAvanzado.Text, out decimal result))
                {
                    lblAdvertencia.Text = "El filtro debe contener números.";
                    return;
                }
            }
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                List<Articulo> lista = (List<Articulo>)negocio.filtrar(ddlCampo.Text, ddlCriterio.Text, txtFiltroAvanzado.Text);
                Session.Add("listaFiltrada", lista);
                dgvArticulos.DataSource = lista;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey.Value.ToString();
            Session.Add("Id", id);
            Response.Redirect("Detalles.aspx", false);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["listaFiltrada"] != null)
                dgvArticulos.DataSource = Session["listaFiltrada"];
            else
                dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }
    }
}