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
    <asp:ScriptManager runat="server" />
    <br />
    <h1>Catálogo de artículos</h1>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row row-cols-1 row-cols-md-4 g-4">
                <asp:Repeater ID="repArticulos" runat="server">
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
                                    <asp:Button Text="+ Favoritos" ID="btnFavoritos" CssClass="btn btn-outline-primary" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnFavoritos_Click" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
