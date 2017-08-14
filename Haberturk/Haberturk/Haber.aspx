<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Haber.aspx.cs" Inherits="Haber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Icerik" Runat="Server">

    <asp:Label ID="LblBaslik" runat="server"></asp:Label>
    <br />
    <asp:Image ID="ImgKucukGorsel" runat="server" />
    <br />
    <asp:Label ID="LblIcerik" runat="server"></asp:Label>
    <br />
    <asp:Label ID="LblTarihSaat" runat="server"></asp:Label>
</asp:Content>

