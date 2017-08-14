using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Haber : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
        int haberid = 0;

        try
        {
            haberid = int.Parse(Request.QueryString["HaberId"]);
        }
        catch 
        {

            Response.Redirect("Default.aspx");

        }

        SqlCommand cmd = new SqlCommand("Select * From Haberler Where HaberId=@HaberId", conn);
        cmd.Parameters.Add("@HaberId", SqlDbType.Int).Value = haberid;
        conn.Open();
        
        SqlDataReader dr = cmd.ExecuteReader();
    
        if (dr.Read())
        {

            LblBaslik.Text = dr["Baslik"].ToString();
            LblIcerik.Text = dr["Icerik"].ToString();
            LblTarihSaat.Text = dr["TarihSaat"].ToString();
            //string path = "Images/" + dr["KucukGorsel"].ToString();
          
            //    ImgKucukGorsel.ImageUrl = "Images/" + dr["KucukGorsel"].ToString();
            string path = Server.MapPath("Images/" + dr["KucukGorsel"].ToString());

            ImgKucukGorsel.ImageUrl = "Images/" + dr["KucukGorsel"].ToString();
            if (System.IO.File.Exists(path))
            {
                ImgKucukGorsel.ImageUrl = "Images/" + dr["KucukGorsel"].ToString();
            }
            else
                ImgKucukGorsel.ImageUrl = "Images/s.jpg";


        }
        else
            LblBaslik.Text = "Haber Bulunamadı";
        dr.Close();
        conn.Close();
    }
}