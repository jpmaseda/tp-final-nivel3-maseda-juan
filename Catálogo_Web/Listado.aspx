<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="Catálogo_Web.Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <br />
    <h1>Lista de artículos</h1>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row align-items-end">
                <div class="col-6">
                    <div class="mb-3">
                        <label class="form-label">Filtrar</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFiltrar" AutoPostBack="true" placeholder="Filtra por Nombre, Marca o Descripción" OnTextChanged="txtFiltrar_TextChanged" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:CheckBox ID="chkFiltroAvanzado" CssClass="" runat="server" AutoPostBack="true" />
                        <label class="form-label">Filtro avanzado</label>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar filtros" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>
            <%if (chkFiltroAvanzado.Checked)
                { %>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Campo</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoría" />
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Precio" selected="true"/>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Criterio</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCriterio">
                            <asp:ListItem Text="Mayor a" />
                            <asp:ListItem Text="Menor a" />
                            <asp:ListItem Text="Es" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Filtro</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFiltroAvanzado" />
                    </div>
                </div>
                <%--<div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Estado</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado">
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                            <asp:ListItem Text="Todos" Selected="True" />
                        </asp:DropDownList>
                    </div>
                </div>--%>
            </div>
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
            <asp:Label ID="lblAdvertencia" CssClass="text-dark bg-warning" runat="server" />
            <br />
            <%} %>
            <br />
            <asp:GridView ID="dgvArticulos" CssClass="table table-striped table-hover" DataKeyNames="Id" runat="server" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                AutoGenerateColumns="false" OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" />
                    <asp:CheckBoxField HeaderText="Favoritos"  />
                    <asp:CommandField HeaderText="Detalles" ShowSelectButton="true" SelectText="&#128221" ControlStyle-Font-Underline="false" />
                </Columns>
                <PagerSettings Mode="Numeric"
                    Position="Bottom" />
                <PagerStyle BackColor=""
                    ForeColor="WhiteSmoke"
                    Height="30px"
                    VerticalAlign="Bottom"
                    HorizontalAlign="center" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
