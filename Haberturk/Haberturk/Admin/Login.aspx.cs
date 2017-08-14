using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }
    protected void BtnGiris_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select * From Kullanicilar Where KullaniciAdi=@Adi and Sifre=@Sifre", conn);
        cmd.Parameters.Add("@Adi", SqlDbType.VarChar).Value = TxtAdi.Text;
        cmd.Parameters.Add("@Sifre", SqlDbType.VarChar).Value = TxtSifre.Text;
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(TxtAdi.Text, false);
            Session.Add("Kullanici", TxtAdi.Text);

            Response.Redirect("/Admin/Haberler.aspx");
            
        }
        else

            LblText.Text = "Kullanıcı Bulunmadı";
       
    }
}