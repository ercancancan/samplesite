<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Deneme2.aspx.cs" Inherits="Deneme2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Icerik" Runat="Server">

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
       <link href="themes/1/js-image-slider.css" rel="stylesheet" type="text/css" />
    <script src="themes/1/js-image-slider.js" type="text/javascript"></script>
    <link href="generic.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <div id="sliderFrame">
        <div id="slider">
            <asp:Repeater runat="server" ID="RptImg">
                <ItemTemplate>
                    <asp:Image runat ="server" ID="Img" ImageUrl='<%#Eval("KucukGorsel") %>' />
                
                </ItemTemplate>
            </asp:Repeater>
            <a href="http://www.menucool.com/javascript-image-slider" target="_blank">
                <img src="images/image-slider-1.jpg" alt="dfghjk" />
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
</body>
</html>

</asp:Content>

