<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kategori.aspx.cs" Inherits="Kategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Icerik" Runat="Server">
    <asp:DataGrid ID="DGHaberler" runat="server" AutoGenerateColumns="false" Height="172px" Width="260px" Border="0px" OnItemDataBound="DGHaberler_ItemDataBound" OnPageIndexChanged="DGHaberler_PageIndexChanged">
       <Columns>
           <asp:TemplateColumn>
               <ItemTemplate>
                   <table>
                       <tr>
                           <td>
                               <asp:HyperLink ID="HLKucukGorsel" runat="server">
                                   <asp:Image ID="ImgKucukGorsel" runat="server" />
                               </asp:HyperLink>
                           </td>

                          
                           <td>
                               <asp:HyperLink ID="HLBaslik" runat="server">
                                   Baslik
                               </asp:HyperLink>
                               <br />
                               <asp:Label ID="LblIcerik" runat="server" Text="Icerik"></asp:Label>


                           </td>
                       </tr>
                   </table>

               </ItemTemplate>
           </asp:TemplateColumn>
       </Columns>
        <PagerStyle Mode="NumericPages" />
    </asp:DataGrid>
</asp:Content>

