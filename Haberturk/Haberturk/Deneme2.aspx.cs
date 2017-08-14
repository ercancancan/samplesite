using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Deneme2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void GetImage()
    {
        using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaberlerConnectionString"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Select KucukGorsel From Haberler", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();

            da.Fill(dt);
            if(dt.Rows.Count > 0 && dt.Rows[0][0] != string.Empty)
            {
                RptImg.DataSource = dt;
                RptImg.DataBind();
            }
            else
            {
                RptImg = null;
                RptImg.DataBind();
            }
            










        }
    }
}