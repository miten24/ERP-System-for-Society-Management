using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagment
{
  public partial class Member_SAccount_Maintenance : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      lblMPMName.Text = Session["MName"].ToString();
    }
    protected void MLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnSEEM_Click(object sender, EventArgs e)
    {
      Response.Redirect("Member_Maintenance_Status.aspx");
    }

    protected void btnADDM_Click(object sender, EventArgs e)
    {
      Response.Redirect("Member_Maintenance_Print_Slip.aspx");
    }
  }
}
