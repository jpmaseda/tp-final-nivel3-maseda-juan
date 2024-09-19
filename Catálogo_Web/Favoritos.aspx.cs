﻿using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

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
                    if (Session["usuario"] != null)
                        Session.Add("listaFav", negocio.listarFavoritos(((Usuario)Session["usuario"]).Id));
                    dgvFavoritos.DataSource = Session["listaFav"];
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