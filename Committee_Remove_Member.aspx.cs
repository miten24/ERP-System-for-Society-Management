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
  public partial class Committee_Remove_Member : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      if (!IsPostBack)
      {
        con.Open();
        String s = "select MBlock from MemberInfo where SocietyCode=@p1";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("@p1",Session["CSCode"]);
        SqlDataReader dr = cmd.ExecuteReader();

        dlCRMMName.DataSource = dr;
        dlCRMMName.DataTextField = "MBlock";
        dlCRMMName.DataValueField = "MBlock";
        dlCRMMName.DataBind();
        dlCRMMName.Items.Insert(0, "Select Block Number");
      }
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void dlCRMMName_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (dlCRMMName.SelectedIndex != 0)
      {
        con.Open();
        String fetchdata = "select * from MemberInfo where MBlock='" + dlCRMMName.SelectedValue.ToString() + "'";
        SqlCommand cmd4 = new SqlCommand(fetchdata, con);
        SqlDataReader dr = cmd4.ExecuteReader();
        while (dr.Read())
        {
          txtCRMMUsername.Text = dr["MName"].ToString();
        }
      }
      else
      {
        txtCRMMUsername.Text = "";
        txtCRMPassword.Text = "";

      }
    }

    protected void btnCRMRemove_Click(object sender, EventArgs e)
    {
      if (rbRMNo.Checked == true)
      {
        lblCRMflag.Text = "Please give the confirmation first".ToString();
      }
      else
      {
        String check_pass = "";
        con.Open();
        String q = "select Password from CommitteeInfo where CommitteeMName=@p1";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@p1", Session["CName"].ToString());
        cmd.ExecuteNonQuery();
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
          check_pass = rdr["Password"].ToString();
        }
        con.Close();
        if (check_pass == txtCRMPassword.Text)
        {
          con.Open();
          
          // delete members
          string s2 = "delete from MemberInfo where MBlock=@p4 and MName=@p5";
          SqlCommand cmd3 = new SqlCommand(s2, con);
          cmd3.Parameters.AddWithValue("@p4", dlCRMMName.SelectedItem.Value.ToString());
          cmd3.Parameters.AddWithValue("@p5", txtCRMMUsername.Text);
          cmd3.ExecuteNonQuery();

          // delete Vehicle
          string sv = "delete from VehicleDetails where SocietyCode=@psv and MName=@puv";
          SqlCommand cmdv = new SqlCommand(sv, con);
          cmdv.Parameters.AddWithValue("@psv", Session["CSCode"].ToString());
          cmdv.Parameters.AddWithValue("@puv", txtCRMMUsername.Text);
          cmdv.ExecuteNonQuery();

          lblCRMflag.Text = "Deleted".ToString();
          dlCRMMName.SelectedIndex = 0;
          txtCRMPassword.Text = "";
          txtCRMMUsername.Text = "";
        }
        else
        {
          lblCRMflag.Text = "Password is incorrect".ToString();
        }
      }
     }
  }
}
