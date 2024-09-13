<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Catálogo_Web._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .imagen {
            max-height: 300px;
            object-fit: scale-down;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row row-cols-1 row-cols-md-4 g-4">
        <%foreach (dominio.Articulo articulo in ListaArticulos)
            {%>
        <div class="col">
            <div class="card">
                <img src="<%: articulo.urlImagen %>" onerror="this.onerror=null; this.src='/images/no_image.jpg'" class="card-img-top imagen" alt="<%: articulo.Nombre %>">
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                    <p class="card-text">
                        Marca: <%: articulo.Marca %>
                        <br />
                        Precio: <%: articulo.Precio.ToString("C") %>                        
                    </p>
                </div>
            </div>
        </div>
        <%} %>
    </div>
</asp:Content>
