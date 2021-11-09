using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagment
{

  public partial class Login : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLSignIn_Click(object sender, EventArgs e)
    {
      if (remember.Checked)
      {
        con.Open();
        String Query = "select * from CommitteeInfo where SocietyCode=@p1 and Username=@p2 and Password=@p3";
        SqlCommand cmd = new SqlCommand(Query, con);
        cmd.Parameters.AddWithValue("@p1", txtLSCode.Text);
        cmd.Parameters.AddWithValue("@p2", txtLUsername.Text);
        cmd.Parameters.AddWithValue("p3", txtLPassword.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
          txtLUsername.Text = "";
          Session["CName"] = dt.Rows[0]["CommitteeMName"].ToString();
          Session["CSCode"] = dt.Rows[0]["SocietyCode"].ToString();
          Session["CSName"] = dt.Rows[0]["SocietyName"].ToString();
          Session["CoCode"] = dt.Rows[0]["CoCode"].ToString();
          Response.Redirect("Committee_Panel.aspx");
        }
        else
        {
          txtLUsername.Text = "";
          txtLPassword.Text = "";
          txtLSCode.Text = "";
          ScriptManager.RegisterStartupScript(Page, typeof(Page), "PopUp", "alert('Invalid Username or Password or SocietyCode')", true);
        }
      }
      else
      {
        con.Open();
        String Query = "select * from MemberInfo where SocietyCode=@p1 and MUsername=@p2 and MPassword=@p3";
        SqlCommand cmd = new SqlCommand(Query, con);
        cmd.Parameters.AddWithValue("@p1", txtLSCode.Text);
        cmd.Parameters.AddWithValue("@p2", txtLUsername.Text);
        cmd.Parameters.AddWithValue("p3", txtLPassword.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
          txtLUsername.Text = "";
          Session["MName"] = dt.Rows[0]["MName"].ToString();
          Session["MBlock"] = dt.Rows[0]["MBlock"].ToString();
          Session["MSCode"] = dt.Rows[0]["SocietyCode"].ToString();
          Session["MSName"] = dt.Rows[0]["SocietyName"].ToString();
          Session["MUsername"] = dt.Rows[0]["MUsername"].ToString();
          Response.Redirect("Member_Panel.aspx");
        }
        else
        {
          txtLUsername.Text = "";
          txtLPassword.Text = "";
          txtLSCode.Text = "";
          ScriptManager.RegisterStartupScript(Page, typeof(Page), "PopUp", "alert('Invalid Username or Password or SocietyCode')", true);
        }
      }
    }
  }
}
