<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Icerik" Runat="Server">
    <asp:DataList ID="DLHaberler" runat="server" Height="223px" Width="236px" RepeatColumns="2" OnItemDataBound="DLHaberler_ItemDataBound">
        <ItemTemplate>
            <table runat="server">
                <tr>
                    <td>
            <asp:HyperLink ID="HLKucukGorsel" runat="server">
                <asp:Image ID="ImgKucukGorsel" runat="server" Width="100" />
            </asp:HyperLink>
                    </td>
                    <td>
            <asp:HyperLink ID="HLBaslik" runat="server">Baslik</asp:HyperLink>
                        <br />
            <asp:Label ID="LblIcerik" runat="server">Icerik

            </asp:Label>
                        </td>
</tr>
                    </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

