using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagment
{
  public partial class Admin_TotalCommittee : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblAdminName.Text = Session["AName"].ToString();
    }
    protected void ALogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("AdminLogin.aspx");
    }
  }
}
