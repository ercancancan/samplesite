using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;


public partial class AraSon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
       

        int queryCount = Request.QueryString.Count;
        var sorgu = "";
        if(queryCount>1)
        {
            for (int i = 0; i < queryCount; i++)
            {
                sorgu += "Baslik LIKE '%" + Request.QueryString[i] + "%' or ";


            }
            sorgu = sorgu.Substring(0, sorgu.Length - 3);

        }
        else
        {
            sorgu = "Baslik LIKE '%" + Request.QueryString[0] + "%'";
        }
        SqlCommand cmd = new SqlCommand("Select * From Haberler WHERE" + sorgu, conn);

        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if(dr.Read())
        {
            DLAramaSon.DataSource = dr;
            DLAramaSon.DataBind();
        }
        else
        {
            Response.Redirect("Error.aspx");
        }
        conn.Close();
    }
}