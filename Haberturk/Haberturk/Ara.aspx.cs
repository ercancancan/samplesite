using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Ara : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (IsPostBack == false)
        {
          
           
            string kelime = Request.QueryString["ara"];

            if (string.IsNullOrEmpty(kelime))
            {
                Response.Redirect("Default.aspx");
            }
         
           
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
            conn.Open();
            //   SqlDataAdapter daara = new SqlDataAdapter("SELECT * FROM Haberler WHERE Baslik LIKE '% @kelime %'", conn);
            SqlDataAdapter daara = new SqlDataAdapter("SELECT * FROM Haberler WHERE Baslik LIKE '%" + kelime + "%'", conn);
            //SqlDataAdapter daara = new SqlDataAdapter("SELECT * FROM Haberler WHERE Baslik LIKE '%" + kelime + "%'", conn);
            daara.SelectCommand.Parameters.Add("@kelime", SqlDbType.VarChar).Value = kelime.ToString();
            SqlCommand cmd = new SqlCommand();
            DataTable dtara = new DataTable();
            daara.Fill(dtara);
            if (dtara.Rows.Count == 0)
            {
                
                LblAramaBulunamadı.Text = "Aranan haber bulunamadı";

            }
            else
            {
                repeaterAra.DataSource = dtara;
                repeaterAra.DataBind();
            }
            conn.Close(); 


        }

        else
        {
            return;
            //Response.Redirect("Default.aspx");

        }


        //if(!IsPostBack)
        //{
        //    string kelime = Request.QueryString["ara"].ToString();
        //    kelime = "";
        //    LblAra.Text = "Aradıgınız Kelime bulunamadı";
        //}
        //else
        //{
        //    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
        //    conn.Open();
        //    string kelime = Request.QueryString["ara"].ToString();

        //    //   SqlDataAdapter daara = new SqlDataAdapter("SELECT * FROM Haberler WHERE Baslik LIKE '% @kelime %'", conn);
        //    SqlDataAdapter daara = new SqlDataAdapter("SELECT * FROM Haberler WHERE Baslik LIKE '%" + @kelime + "%'", conn);
        //    //SqlDataAdapter daara = new SqlDataAdapter("SELECT * FROM Haberler WHERE Baslik LIKE '%" + kelime + "%'", conn);
        //    daara.SelectCommand.Parameters.Add("@kelime", SqlDbType.VarChar).Value = kelime.ToString();
        //    SqlCommand cmd = new SqlCommand();
        //    DataTable dtara = new DataTable();
        //    daara.Fill(dtara);
        //    RptAra.DataSource = dtara;
        //    RptAra.DataBind();
        //}




    }
    protected void RptAra_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView haber = (DataRowView)e.Item.DataItem;
        HyperLink hlbaslik = (HyperLink)e.Item.FindControl("HypAra");
        //  hlbaslik.Text = haber["Baslik"].ToString();
        //hlbaslik.NavigateUrl = "Haber.aspx?HaberId=" + haber["HaberId"].ToString();
    }
}