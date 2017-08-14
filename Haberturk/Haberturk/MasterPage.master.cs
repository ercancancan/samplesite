using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select * From Kategoriler", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        RptKategori.DataSource = dt;
        RptKategori.DataBind();
    }
    protected void TxtAra_TextChanged(object sender, EventArgs e)
    {

    }
    protected void BtnAra_Click(object sender, EventArgs e)
    {
        Response.Redirect("Ara.aspx?ara=" + TxtAra.Text.Trim());
    }
}
