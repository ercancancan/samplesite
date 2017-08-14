<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Haberler.aspx.cs" Inherits="Admin_Haberler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="HaberDuzenle.aspx">Haber Ekle</a>
        <asp:DataGrid ID="DGHaber" runat="server" AutoGenerateColumns="false" Height="156px" OnItemCommand="DGHaber_ItemCommand" OnSelectedIndexChanged="DGHaber_SelectedIndexChanged" Width="180px" OnItemDataBound="DGHaber_ItemDataBound">
            <Columns>
                <asp:TemplateColumn>
                    <HeaderTemplate>Baslık</HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HLBaslik" runat="server"><%# Eval("Baslik") %></asp:HyperLink>
                    </ItemTemplate>
                    
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="LblSil" runat="server" CommandName="Sil" OnClientClick="javascript:return confirm('Emin Misiniz?')" CommandArgument='<%# Eval("HaberId") %>'>
                            Sil
                        </asp:LinkButton>
                                                </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn>
                   
                    <HeaderTemplate>
                        Admin
                    </HeaderTemplate>
                    <ItemTemplate>
                        
                        <asp:Label ID="LblAdmin" runat="server"><%#Eval("Admin")%></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>

        </asp:DataGrid>
        
         <asp:Label ID="LblSes" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
