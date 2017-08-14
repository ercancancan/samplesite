<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ara.aspx.cs" Inherits="Ara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Icerik" Runat="Server">
    <asp:Label ID="LblAra" runat="server"></asp:Label>
    <asp:Repeater ID="repeaterAra" runat="server" OnItemDataBound="RptAra_ItemDataBound">

        <ItemTemplate>
            <a href="Haber.aspx?HaberId=<%# Eval("HaberId") %>">

  <%#Eval("Baslik") %>
            </a>
        
            <br />

        </ItemTemplate>
        
     
        
    </asp:Repeater>
    
    <asp:Label ID="LblAramaBulunamadı" runat="server"></asp:Label>
</asp:Content>

