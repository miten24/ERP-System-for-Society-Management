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
  public partial class Member_Panel : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected int countofQuery(String s)
    {
      con.Open();
      SqlCommand cmd2 = new SqlCommand(s, con);
      SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
      DataTable dt2 = new DataTable();
      da2.Fill(dt2);
      con.Close();
      return dt2.Rows.Count;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      lblMPMName.Text = Session["MName"].ToString();
      
      lblMVehicle.Text = countofQuery("select * from VehicleDetails where SocietyCode='"+ Session["MSCode"] +"' and Username='"+Session["MUsername"] +"'").ToString();
      lblCList.Text = countofQuery("select * from CommitteeInfo where SocietyCode='" + Session["MSCode"] + "'").ToString();
      lblMList.Text = countofQuery("select * from MemberInfo where SocietyCode='" + Session["MSCode"] + "'").ToString();
    }
    protected void MLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
  }

}
