using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select * From Haberler order by HaberId DESC", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DLHaberler.DataSource = dt;
        
        DLHaberler.DataBind();
      
        conn.Close();
       
    }
    protected void DLHaberler_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataRowView haber = (DataRowView)e.Item.DataItem;
        Image imgkucukgorsel = (Image)e.Item.FindControl("ImgKucukGorsel");

        string path = Server.MapPath("Images/" + haber["KucukGorsel"].ToString());

        imgkucukgorsel.ImageUrl = "Images/" + haber["KucukGorsel"].ToString();
        if (System.IO.File.Exists(path))
        {
            imgkucukgorsel.ImageUrl = "Images/" + haber["KucukGorsel"].ToString();
        }
        else
            imgkucukgorsel.ImageUrl = "Images/s.jpg";
       
        HyperLink hlkucukgorsel = (HyperLink)e.Item.FindControl("HLKucukGorsel");
        hlkucukgorsel.NavigateUrl = "Haber.aspx?HaberId=" + haber["HaberId"].ToString();

        HyperLink baslik = (HyperLink)e.Item.FindControl("HLBaslik");
        baslik.Text = haber["Baslik"].ToString();
        baslik.NavigateUrl = "Haber.aspx?HaberId=" + haber["HaberId"].ToString();



        //Label icerik = (Label)e.Item.FindControl("LblIcerik");
        //icerik.Text = haber["Icerik"].ToString();

   
        

        
        Label icerik = (Label)e.Item.FindControl("LblIcerik");
       // icerik.Text = haber["Icerik"].ToString();
      //icerik.Text = haber["Icerik"].ToString().Substring(0,2) + ".."; 

        icerik.Text = StringHelper.TrimDescription(haber["Icerik"].ToString(), 50) + "...";
      //  icerik.Text = haber["Icerik"].ToString().TrimText(50);
        //icerik.Text = StringHelper.yazTarım(haber["Icerik"].ToString());
           
     

    }
}