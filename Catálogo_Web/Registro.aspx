<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Catálogo_Web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color:crimson;
            font-size: 18px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <br />
            <h1>Creá tu perfil</h1>
            <br />
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" placeholder="usuario@dominio.com" CssClass="form-control" REQUIRED="" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Debe completar con un email válido" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPass" placeholder="" CssClass="form-control" type="password" REQUIRED="" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="La contraseña debe tener entre 4 y 10 caracteres." ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,10}$" ControlToValidate="txtPass" runat="server" />
            </div>
            <asp:Button Text="Registro" CssClass="btn btn-primary" ID="btnRegistro" OnClick="btnRegistro_Click" runat="server" />
            <a class="form-control-color" href="/">Volver al inicio</a>
        </div>
    </div>
</asp:Content>
