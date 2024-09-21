<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Catálogo_Web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .imagen {
            max-height: 300px;
            object-fit: scale-down;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <br />
    <h1>Mi lista de favoritos</h1>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="btn-group" role="group" aria-label="Basic example">
                <asp:Button ID="btnGrilla" OnClick="btnGrilla_Click" Text="Grilla" CssClass="btn btn-primary" runat="server" />
                <asp:Button ID="btnImagen" OnClick="btnImagen_Click" Text="Imágenes" CssClass="btn btn-primary" runat="server" />
            </div>
            <hr />
            <%if (CheckGrilla)
                { %>
            <asp:GridView ID="dgvFavoritos" CssClass="table table-striped table-hover" DataKeyNames="Id" runat="server" OnRowCommand="dgvFavoritos_RowCommand" AutoGenerateColumns="false" AllowPaging="true">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" />
                    <asp:ButtonField HeaderText="Detalles" ControlStyle-CssClass="btn btn-outline-success" CommandName="detalles" ButtonType="Button" Text="Ver" />
                    <asp:ButtonField HeaderText="Favoritos" CommandName="quitarFav" ControlStyle-CssClass="btn btn-outline-danger" ButtonType="Button" Text="Quitar" />
                </Columns>
                <PagerSettings Mode="Numeric"
                    Position="Bottom" />
                <PagerStyle BackColor=""
                    ForeColor="WhiteSmoke"
                    Height="30px"
                    VerticalAlign="Bottom"
                    HorizontalAlign="center" />
            </asp:GridView>
            <%}
                else
                { %>
            <div class="row row-cols-1 row-cols-md-4 g-4">
                <asp:Repeater ID="repFavoritos" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card">
                                <img src="<%#Eval("urlImagen") %>" onerror="this.onerror=null; this.src='/images/no_image.jpg'" class="card-img-top imagen" alt="<%#Eval("Nombre") %>">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text">
                                        Marca: <%#Eval("Marca") %>
                                        <br />
                                        Precio: <%#string.Format("{0:C}", Eval("Precio")) %>
                                    </p>
                                    <a href="Detalles.aspx?Id=<%#Eval("Id") %>">Ver Detalles</a>
                                    <asp:Button Text="- Favoritos" ID="btnFavoritos" CssClass="btn btn-outline-primary" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnFavoritos_Click" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <%} %>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
