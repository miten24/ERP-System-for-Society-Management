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
  public partial class Committee_Account_Maintenance : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnADDM_Click(object sender, EventArgs e)
    {
      Response.Redirect("Committee_Add_Maintenance.aspx");
    }

    protected void btnSEEM_Click(object sender, EventArgs e)
    {
      Response.Redirect("Committee_Maintenance_Status.aspx");
    }
  }
}
