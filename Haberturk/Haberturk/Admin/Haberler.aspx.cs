using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Admin_Haberler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            DataDoldur();
            if(Session["Kullanici"] != null)
            {
                LblSes.Text = "Hoşgeldin" + Session["Kullanici"];
            }
        }
        

    }
    private void DataDoldur()
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select * From Haberler order by HaberId DESC", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DGHaber.DataSource = dt;
        DGHaber.DataBind();
       
        conn.Close();
    }
    protected void RptHaber_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
    }
    protected void DGHaber_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DGHaber_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        
        
        
      if (e.CommandName == "Sil")
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM Haberler WHERE HaberId=@HaberId", conn);
            cmd.Parameters.Add("@HaberId", SqlDbType.Int).Value = e.CommandArgument;
            conn.Open();
                cmd.ExecuteNonQuery();
            
            conn.Close();
            DataDoldur();
        }
    }
    protected void DGHaber_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView haber = (DataRowView)e.Item.DataItem;
            HyperLink hlbaslik = (HyperLink)e.Item.FindControl("HLBaslik");
            hlbaslik.Text = haber["Baslik"].ToString();
            hlbaslik.NavigateUrl = "HaberDuzenle.aspx?HaberId=" + haber["HaberId"].ToString();
        }
    }
}