<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Catálogo_Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <br />
            <h1>Login</h1>
            <br />
            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Email</label>
                <asp:TextBox ID="txtUsuario" placeholder="Nombre de usuario" CssClass="form-control" REQUIRED="" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPass" placeholder="********" CssClass="form-control" type="password" runat="server" />
            </div>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" />
            <a class="form-control-color" href="/">Volver al inicio</a>
        </div>
    </div>
</asp:Content>
