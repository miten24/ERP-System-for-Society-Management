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
  public partial class Committee_Society_Parking_Info : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      if (!IsPostBack)
      {
        con.Open();
        string q= "select * from ParkingDetails where SocietyCode=@p1";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@p1", Session["CSCode"].ToString());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        if(dt.Rows.Count > 0)
        {
          txtCP4Wheel.Text= dt.Rows[0]["FourWheels"].ToString();
          txtCP2Wheel.Text= dt.Rows[0]["TwoWheels"].ToString();
        }
      }
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnCPAdd_Click(object sender, EventArgs e)
    {
      con.Open();
      string qs = "select * from ParkingDetails where SocietyCode=@p1";
      SqlCommand cmds = new SqlCommand(qs, con);
      cmds.Parameters.AddWithValue("@p1", Session["CSCode"].ToString());
      SqlDataAdapter das = new SqlDataAdapter(cmds);
      DataTable dts = new DataTable();
      das.Fill(dts);
      con.Close();
      if(dts.Rows.Count >0)
      {
        con.Open();
        string qu = "UPDATE ParkingDetails SET FourWheels=@pf,TwoWheels=@pt  where SocietyCode=@p1";
        SqlCommand cmdu = new SqlCommand(qu, con);
        cmdu.Parameters.AddWithValue("@pf", txtCP4Wheel.Text);
        cmdu.Parameters.AddWithValue("@pt", txtCP2Wheel.Text);
        cmdu.Parameters.AddWithValue("@p1",Session["CSCode"]);
        cmdu.ExecuteNonQuery();
        lblCPFlag.Text = "Updated";
        con.Close();
      }
      else
      {
        con.Open();
        String qi = "insert into ParkingDetails (SocietyCode,SocietyName,FourWheels,TwoWheels) values (@p1,@p2,@p3,@p4)";
        SqlCommand cmdi = new SqlCommand(qi, con);
        cmdi.Parameters.AddWithValue("@p1", Session["CSCode"].ToString());
        cmdi.Parameters.AddWithValue("@p2", Session["CSCode"].ToString());
        cmdi.Parameters.AddWithValue("@p3", txtCP4Wheel.Text);
        cmdi.Parameters.AddWithValue("@p4", txtCP2Wheel.Text);
        cmdi.ExecuteNonQuery();
        lblCPFlag.Text = "Updated";
        con.Close();
      }

    }
  }
}
