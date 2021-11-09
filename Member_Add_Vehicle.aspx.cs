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
  public partial class Member_Add_Vehicle : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblMPMName.Text = Session["MName"].ToString();
      if (!IsPostBack)
      {
        txtCPAVSCode.Text = Session["MSCode"].ToString();
        txtCPAVSName.Text = Session["MSName"].ToString();
        txtCPAVUsername.Text = Session["MUsername"].ToString();
        txtCPAVName.Text = Session["MName"].ToString();
      }
    }
    protected void MLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnCAddMember_Click(object sender, EventArgs e)
    {
      if (dlCPAVType.SelectedIndex != 0)
      {
        con.Open();
        string s= "insert into VehicleDetails (SocietyCode,SocietyName,Username,MName,TypeOfVehicle,VehicleNo,ModelName) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("@p1",Session["MSCode"].ToString());
        cmd.Parameters.AddWithValue("@p2",Session["MSName"].ToString());
        cmd.Parameters.AddWithValue("@p3",Session["MUsername"].ToString());
        cmd.Parameters.AddWithValue("@p4",Session["MName"].ToString());
        cmd.Parameters.AddWithValue("@p5",dlCPAVType.SelectedValue.ToString());
        cmd.Parameters.AddWithValue("@p6",txtCPAVNumber.Text);
        cmd.Parameters.AddWithValue("@p7",txtCPAVModel.Text);
        cmd.ExecuteNonQuery();
        lblCPAVFlag.ForeColor = System.Drawing.Color.Green;
        lblCPAVFlag.Text = "New Vehicle Added".ToString();
        dlCPAVType.SelectedIndex = 0;
        txtCPAVNumber.Text = "";
        txtCPAVModel.Text = "";
      }
      else
      {
        lblCPAVFlag.ForeColor = System.Drawing.Color.Red;
        lblCPAVFlag.Text = "Select the type of the Vehicle".ToString();
      }
    }
  }
}
