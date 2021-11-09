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
  public partial class Member_Update_Remove_Vehicle : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblMPMName.Text = Session["MName"].ToString();
      if (!IsPostBack)
      {
        con.Open();
        String s = "select VehicleNo from VehicleDetails where SocietyCode=@p1 and Username=@p2";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("@p1",Session["MSCode"].ToString());
        cmd.Parameters.AddWithValue("@p2",Session["MUsername"].ToString());
        
        SqlDataReader dr = cmd.ExecuteReader();

        dlCURRVNO.DataSource = dr;
        dlCURRVNO.DataTextField = "VehicleNo";
        dlCURRVNO.DataValueField = "VehicleNo";
        dlCURRVNO.DataBind();
        dlCURRVNO.Items.Insert(0, "Select Registerd Vehicle");
        con.Close();
      }
      
    }
    protected void MLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void dlCURRVNO_SelectedIndexChanged(object sender, EventArgs e)
    {

      if (dlCURRVNO.SelectedIndex != 0)
      {
        con.Open();
        string lq = "select * from VehicleDetails where SocietyCode=@p1 and Username=@p2 and VehicleNo=@p3";
        SqlCommand lcmd = new SqlCommand(lq, con);
        lcmd.Parameters.AddWithValue("@p1", Session["MSCode"].ToString());
        lcmd.Parameters.AddWithValue("@p2", Session["MUsername"].ToString());
        lcmd.Parameters.AddWithValue("@p3",dlCURRVNO.SelectedValue);
        SqlDataReader dr2 = lcmd.ExecuteReader();
        while (dr2.Read())
        {
          txtCURVNumber.Text = dr2["VehicleNo"].ToString();
          txtCPAVModel.Text = dr2["ModelName"].ToString();
        }
        con.Close();
      }
      else
      {
        txtCURVNumber.Text = "";
        txtCPAVModel.Text = "";
      }
      

    }

    protected void btnCPUpdate_Click(object sender, EventArgs e)
    {
      if (dlCURVType.SelectedIndex != 0)
      {
        con.Open();
        string su = "UPDATE VehicleDetails SET TypeOfVehicle=@p1,VehicleNo=@p2,ModelName=@p3 where SocietyCode=@p4 and Username=@p5 and VehicleNo=@p6";
        SqlCommand cmdu = new SqlCommand(su, con);
        cmdu.Parameters.AddWithValue("@p1", dlCURVType.SelectedValue.ToString());
        cmdu.Parameters.AddWithValue("@p2", txtCURVNumber.Text);
        cmdu.Parameters.AddWithValue("@p3", txtCPAVModel.Text);
        cmdu.Parameters.AddWithValue("@p4", Session["MSCode"].ToString());
        cmdu.Parameters.AddWithValue("@p5", Session["MUsername"].ToString());
        cmdu.Parameters.AddWithValue("@p6", dlCURRVNO.SelectedValue.ToString());
        cmdu.ExecuteNonQuery();
        lblCPUFlag.Text = "Updated successfuly";
        dlCURRVNO.SelectedIndex = 0;
        dlCURVType.SelectedIndex = 0;
        txtCPAVModel.Text = "";
        txtCURVNumber.Text = "";
        con.Close();
      }
      else
      {
        lblCPUFlag.Text = "Select the type of vehicle";
      }
      
    }



    protected void ctnCPRemove_Click(object sender, EventArgs e)
    {
      if (dlCURRVNO.SelectedIndex != 0)
      {
        con.Open();
        string sr = "delete from VehicleDetails where SocietyCode=@prs and Username=@pru and VehicleNo=@prv";
        SqlCommand cmdr = new SqlCommand(sr, con);
        cmdr.Parameters.AddWithValue("@prs",Session["MSCode"].ToString());
        cmdr.Parameters.AddWithValue("@pru",Session["MUsername"].ToString());
        cmdr.Parameters.AddWithValue("@prv",dlCURRVNO.SelectedValue.ToString());
        cmdr.ExecuteNonQuery();
        lblCPUFlag.Text = "Deleted";
        txtCPAVModel.Text = "";
        txtCURVNumber.Text = "";
        dlCURRVNO.SelectedIndex = 0;
        dlCURVType.SelectedIndex = 0;
      }
      else
      {
        lblCPUFlag.Text = "Select correct values";
      }
    }
  }
}
