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
  public partial class Committee_Panel : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected int RemainingBlock()
    {
      String str = "select * from MemberInfo where SocietyCode =@p1";
      SqlCommand cmd = new SqlCommand(str, con);
      cmd.Parameters.AddWithValue("@p1", Session["CSCode"].ToString());
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      con.Close();
      int fb = dt.Rows.Count;
      con.Open();
      String st = "select * from SocietyInfo where SocietyCode =@p2";
      SqlCommand cmd1 = new SqlCommand(st, con);
      cmd1.Parameters.AddWithValue("@p2", Session["CSCode"].ToString());
      SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
      DataTable dt1 = new DataTable();
      da1.Fill(dt1);
      con.Close();
      int tb = 0;
      if (dt1.Rows.Count > 0)
      {
        tb = (int)dt1.Rows[0]["NoOfBlocks"];
      }
      return (tb - fb);
    }
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
      lblCommitteeMName.Text = Session["CName"].ToString();
      con.Open();

      lblRBlock.Text = RemainingBlock().ToString();
      lblTmember.Text = countofQuery("select * from MemberInfo where SocietyCode='"+Session["CSCode"]+"'").ToString();
      lblNoOfVehicles.Text = countofQuery("select * from VehicleDetails Where SocietyCode='" + Session["CSCode"] + "'").ToString();
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
  }
}
