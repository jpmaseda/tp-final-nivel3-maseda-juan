<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Catálogo_Web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvFavoritos" CssClass="table table-striped table-hover" DataKeyNames="Id" runat="server" OnRowCommand="dgvFavoritos_RowCommand" AutoGenerateColumns="false" AllowPaging="true">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" />
            <asp:ButtonField HeaderText="Detalles" ControlStyle-CssClass="btn btn-outline-primary" CommandName="detalles" buttontype="Button" Text="Ver" />       
            <asp:ButtonField HeaderText="Favoritos" CommandName="quitarFav" ControlStyle-CssClass="btn btn-outline-warning" buttontype="Button" Text="Quitar" />       
        </Columns>
        <PagerSettings Mode="Numeric"
            Position="Bottom" />
        <PagerStyle BackColor=""
            ForeColor="WhiteSmoke"
            Height="30px"
            VerticalAlign="Bottom"
            HorizontalAlign="center" />
    </asp:GridView>
</asp:Content>
