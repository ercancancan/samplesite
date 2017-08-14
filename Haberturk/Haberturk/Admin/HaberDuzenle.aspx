<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeFile="HaberDuzenle.aspx.cs" Inherits="Admin_HaberDuzenle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 152px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td class="auto-style1"> Kategori </td>&nbsp
            <td>
                <asp:DropDownList ID="DDLKategori" runat="server">
                </asp:DropDownList>
            </td>
            </tr>
        <tr>
                <td>

                </td>
                <td></td>
         

        <tr>
            <td>Başlık</td>
            &nbsp
            <td>
                <asp:TextBox ID="TxtBaslik" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td><td></td>
        </tr>
        <tr>
            <td>Icerik</td>
            <td>
                <asp:TextBox ID="TxtIcerik" runat="server" Height="115px" TextMode="MultiLine" Width="217px"></asp:TextBox>
            </td>
        </tr>
        <tr><td>&nbsp</td><td></td></tr>
        <tr>
            <td>Kucuk Gorsek</td>
            <td>
                <asp:FileUpload ID="FUKucukGorsel" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        
      <tr>
          <td>
       &nbsp
        
          </td>
          <td>
               <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click" />
              &nbsp &nbsp
              <asp:Button ID="BtnVazgec" runat="server" Text="Vazgeç" OnClick="BtnVazgec_Click" />

          </td>
      </tr>  
            <asp:Label ID="LblSes" runat="server"></asp:Label>
    </table>
    </div>
    </form>
</body>
</html>
