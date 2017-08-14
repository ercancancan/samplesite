<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Deneme.aspx.cs" Inherits="Deneme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Icerik" Runat="Server">
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="Bilgisayar" Value="Bilgisayar">
                <asp:MenuItem Text="Notbook" Value="Notbook"></asp:MenuItem>
                <asp:MenuItem Text="Diz Üstü" Value="Diz Üstü"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Telefon" Value="Telefon">
                <asp:MenuItem Text="Iphone" Value="Iphone"></asp:MenuItem>
                <asp:MenuItem Text="Samsung" Value="Samsung"></asp:MenuItem>
            </asp:MenuItem>
        </Items>

    </asp:Menu>
    
   <div id="sliderFrame">
        <div id="slider">
            <a href="http://www.menucool.com/javascript-image-slider" target="_blank">
                <img src="images/image-slider-1.jpg" alt="Welcome to Menucool.com" />
            </a>
            <img src="images/image-slider-2.jpg" />
            <img src="images/image-slider-3.jpg" alt="" />
            <img src="images/image-slider-4.jpg" alt="#htmlcaption" />
            <img src="images/image-slider-5.jpg" />
        </div>
        <div id="htmlcaption" style="display: none;">
            <em>HTML</em> caption. Link to <a href="http://www.google.com/">Google</a>.
        </div>
    </div>
    
</asp:Content>

