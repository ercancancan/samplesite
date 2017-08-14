using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;


public partial class Kategori : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataDoldur();
        }



    }
    public void DataDoldur()
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
        conn.Open();
        int kategoriId;
        try
        {
            kategoriId = int.Parse(Request.QueryString["KategoriId"]);
        }
        catch
        {

            return;
        }
        SqlDataAdapter da = new SqlDataAdapter("Select * From Haberler Where KategoriId=@KategoriId ORDER BY TarihSaat DESC", conn);
        da.SelectCommand.Parameters.Add("@KategoriId", SqlDbType.VarChar).Value = kategoriId.ToString();

        DataTable dt = new DataTable();
        da.Fill(dt);
        DGHaberler.DataSource = dt;
        DGHaberler.AllowPaging = true;
        DGHaberler.PageSize = 10;

        DGHaberler.DataBind();
    }
    protected void DGHaberler_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView haber = (DataRowView)e.Item.DataItem;
            Image imgKucukGorsel = (Image)e.Item.FindControl("ImgKucukGorsel");

            string path = Server.MapPath("Images/" + haber["KucukGorsel"]).ToString() ;

            if (System.IO.File.Exists(path))
                imgKucukGorsel.ImageUrl = "Images/" + haber["KucukGorsel"].ToString();
            else
                imgKucukGorsel.ImageUrl = "Images/s.jpg";




            HyperLink hlKucukGorsel = (HyperLink)e.Item.FindControl("HLKucukGorsel");
            hlKucukGorsel.NavigateUrl = "Haber.aspx?HaberId=" + haber["HaberId"].ToString();
           // imgKucukGorsel.ImageUrl = "Haberler.aspx?HaberId=" + haber["HaberId"].ToString();

         
            HyperLink baslik = (HyperLink)e.Item.FindControl("HLBaslik");
            baslik.Text = haber["Baslik"].ToString();
            baslik.NavigateUrl = "Haber.aspx?HaberId=" + haber["HaberId"].ToString();

            Label icerik = (Label)e.Item.FindControl("LblIcerik");
           // icerik.Text = haber["Icerik"].ToString();

            icerik.Text = haber["Icerik"].ToString().TrimDescription(50) + "...";



            //if (icerik.Text.Substring(25) > 25))


            //{
            //    icerik.Text = haber["Icerik"].ToString();
            //}
            //else
            //{
            //    icerik.Text = haber["Icerik"].ToString().Substring(0, 25);
            //}


        }
    }
    protected void DGHaberler_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DGHaberler.CurrentPageIndex = e.NewPageIndex;
        DataDoldur();
    }
}