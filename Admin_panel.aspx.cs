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
  public partial class Admin_panel : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected int countofQuery(String s)
    {
      con.Open();
      SqlCommand cmd = new SqlCommand(s, con);
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      con.Close();
      return dt.Rows.Count;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      lblAdminName.Text = Session["AName"].ToString();
      
      lblAPTSociety.Text = countofQuery("select * from SocietyInfo").ToString();
      lblAPTCommitteeM.Text = countofQuery("select * from CommitteeInfo").ToString();
      lblAPTMember.Text = countofQuery("select * from MemberInfo").ToString();
    }
    protected void ALogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("AdminLogin.aspx");
    }
  }
}
