<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="TxtAdi" runat="server"></asp:TextBox>
        <asp:TextBox ID="TxtSifre" runat="server"></asp:TextBox>
        <asp:Button ID="BtnGiris" runat="server" OnClick="BtnGiris_Click" />
        <asp:Label ID="LblText" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
