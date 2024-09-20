<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Catálogo_Web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Error</h1>
    <asp:Label Text="" ID="lblError" runat="server" />
    <br />
    <br />
    <a class="form-control-color" href='javascript:history.go(-1)'>Atrás</a>
</asp:Content>
