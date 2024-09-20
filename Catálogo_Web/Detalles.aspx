<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="Catálogo_Web.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .imagen {
            max-height: 500px;
            object-fit: scale-down;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" Class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" Class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" Class="form-control" REQUIRED="" runat="server"></asp:TextBox>
                <asp:Label ID="lblAdvertencia" ForeColor="WhiteSmoke" runat="server"></asp:Label>                
                <asp:Label ID="lblErrorFormato" ForeColor="Red" Text="" runat="server"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <a class="form-control-color" href='javascript:history.go(-1)'>Volver</a>
                <%--<asp:Button ID="btnInactivar" OnClick="btnInactivar_Click" CssClass="btn btn-outline-warning" runat="server" Text="Inactivar" />--%>
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Imagen del artículo</label>
                        <asp:TextBox ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" type="url" placeholder="https://ejemplo.com" pattern="https://.*" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Image ID="imgArticulo" onerror="this.onerror=null; this.src='/images/img_placeholder.png'" CssClass="img-thumbnail img-fluid imagen" ImageUrl="/images/img_placeholder.png" runat="server" Width="450px" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <%if (negocio.Seguridad.esAdmin(Session["usuario"]))
                {%>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-outline-primary" runat="server" Text="Aceptar" />
                <asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-outline-danger" Text="Eliminar" runat="server" />
            </div>
            <%} %>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <%if (CheckConfirmar)
                        {%>
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" value="" id="chkConfimarEliminar" runat="server">
                        <label class="form-check-label form-check-inline" for="chkConfimarEliminar">
                            Confirmo que deseo eliminar de la DB
                        </label>
                        <asp:Button ID="btnConfEliminar" CssClass="btn btn-danger align-top" runat="server" Text="Confimar" OnClick="btnConfEliminar_Click" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
