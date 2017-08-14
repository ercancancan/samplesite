using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Admin_HaberDuzenle : System.Web.UI.Page
{
   
    private  SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);

    private int haberId = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Kullanici"] != null)
        {
            LblSes.Text = "Hoşgeldin" + Session["Kullanici"];
        }

        try
        {
            haberId = int.Parse(Request.QueryString["HaberId"]);
        }
        catch
        {

        };
        if (!Page.IsPostBack)
        {

            SqlDataAdapter da = new SqlDataAdapter("Select * From Kategoriler", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLKategori.DataSource = dt;
            DDLKategori.DataTextField = "Kategori";
            DDLKategori.DataValueField = "KategoriId";
            DDLKategori.DataBind();


            if (haberId != -1)
            {
                SqlCommand cmd = new SqlCommand("Select * From Haberler Where HaberId=@HaberId", conn);
                cmd.Parameters.Add("@HaberId", SqlDbType.Int).Value = haberId;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    DDLKategori.SelectedValue = dr["KategoriId"].ToString();
                    TxtBaslik.Text = dr["Baslik"].ToString();
                    TxtIcerik.Text = dr["Icerik"].ToString();

                }
                else
                    Response.Redirect("Haberler.aspx");
                dr.Close();
                conn.Close();

            }
        }
    }

    protected void BtnVazgec_Click(object sender, EventArgs e)
    {
        Response.Redirect("Haberler.aspx");
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        string kucukgorsel = "";
        if(FUKucukGorsel.HasFile)
        {
            kucukgorsel = Guid.NewGuid().ToString() + ".jpg";
            FUKucukGorsel.PostedFile.SaveAs(Server.MapPath("/Images/" + kucukgorsel));

        }
      
        string sql;

        if (haberId == -1)
        {
            if (kucukgorsel == "")
            {
                sql = "INSERT INTO Haberler (KategoriId,Baslik,Icerik,KucukGorsel,TarihSaat,Admin) VALUES (@KategoriId,@Baslik,@Icerik,'',@TarihSaat,'" + Session["Kullanici"] + "')";

            }
            else
            {
                sql = "INSERT INTO Haberler (KategoriId,Baslik,Icerik,KucukGorsel,TarihSaat,Admin) VALUES (@KategoriId,@Baslik,@Icerik,'" + kucukgorsel + "',@TarihSaat,'" + Session["Kullanici"] + "')";
            }

        }
        else
        {
            if (kucukgorsel == "")
            {
                //sql = "UPDATE Haberler SET KategoriId = @KategoriId, Baslik = @Baslik, Icerik = @Icerik, TarihSaat = @TarihSaat WHERE HaberId = @HaberId";

                sql = "UPDATE Haberler SET KategoriId = @KategoriId, Baslik = @Baslik, Icerik = @Icerik, TarihSaat = @TarihSaat, Admin = '" + Session["Kullanici"] + "' WHERE HaberId = @HaberId";
            }
            else
            {

                //sql = "UPDATE Haberler SET KategoriId=@KategoriId, Baslik=@Baslik, Icerik=@Icerik, KucukGorsel='" + kucukgorsel + "',TarihSaat=@TarihSaat  WHERE HaberId = @HaberId";

                sql = "UPDATE Haberler SET KategoriId=@KategoriId, Baslik=@Baslik, Icerik=@Icerik, KucukGorsel='" + kucukgorsel + "',TarihSaat=@TarihSaat, '" + Session["Kullanici"] + "' WHERE HaberId = @HaberId";
            }


        }
     
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@HaberId", SqlDbType.VarChar).Value = haberId;
        cmd.Parameters.Add("@KategoriId", SqlDbType.VarChar).Value = DDLKategori.SelectedValue;
        cmd.Parameters.Add("@Baslik", SqlDbType.VarChar).Value = TxtBaslik.Text;
        cmd.Parameters.Add("@Icerik", SqlDbType.VarChar).Value = TxtIcerik.Text;

        cmd.Parameters.Add("@TarihSaat", SqlDbType.DateTime).Value = DateTime.Now;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("Haberler.aspx");



    }
}