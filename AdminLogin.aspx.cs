using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace SocietyManagment
{
  public partial class AdminLogin : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void btnASignin_Click(object sender, EventArgs e)
    {
      con.Open();
      string query = "select * from AdminInfo where AUsername=@p1 and APassword=@p2";
      SqlCommand cmd = new SqlCommand(query,con);
      cmd.Parameters.AddWithValue("@p1", txtAUser.Text);
      cmd.Parameters.AddWithValue("@p2", txtAPass.Text);
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      con.Close();
      if (dt.Rows.Count> 0)
      {
        txtAUser.Text = "";
        Session["AName"] = dt.Rows[0]["AName"].ToString();
        Response.Redirect("Admin_panel.aspx");
      }
      else
      {
        txtAUser.Text = "";
        txtAPass.Text = "";
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "PopUp", "alert('Invalid Username or Password')", true);
      }
    }
  }
}
