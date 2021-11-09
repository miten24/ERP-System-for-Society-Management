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
  public partial class Admin_AddCM : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblAdminName.Text = Session["AName"].ToString();
      if (!IsPostBack)
      {
        con.Open();
        String s = "select SocietyCode from SocietyInfo";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        
        DlACSocietyCode.DataSource = dr;
        DlACSocietyCode.DataTextField = "SocietyCode";
        DlACSocietyCode.DataValueField = "SocietyCode";
        DlACSocietyCode.DataBind();
        DlACSocietyCode.Items.Insert(0, "Select Society Code");
      }
    }

    protected void ALogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("AdminLogin.aspx");
    }

    protected void btnACCAdd_Click(object sender, EventArgs e)
    {
      con.Open();
      String q = "select * from CommitteeInfo where CoCode=@p1";
      SqlCommand cmd = new SqlCommand(q,con);
      cmd.Parameters.AddWithValue("@p1",txtACCMCode.Text);
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      con.Close();
      if (dt.Rows.Count > 0)
      {
        txtACCMCode.Text = "";
        lblACFlag.ForeColor = System.Drawing.Color.Red;
        lblACFlag.Text = "This Code is Already taken".ToString();
      }
      else
      {
        con.Open();
        String str = "insert into CommitteeInfo (SocietyCode,SocietyName,CommitteeMName,CoCode,BDate,CRole,PhoneNumber,Email,Username,Password) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";
        SqlCommand cmd1 = new SqlCommand(str, con);
        cmd1.Parameters.AddWithValue("@p1",DlACSocietyCode.SelectedValue);
        cmd1.Parameters.AddWithValue("@p2",txtACSName.Text);
        cmd1.Parameters.AddWithValue("@p3",txtACMName.Text);
        cmd1.Parameters.AddWithValue("@p4",txtACCMCode.Text);
        cmd1.Parameters.AddWithValue("@p5",txtACBDate.Text);
        cmd1.Parameters.AddWithValue("@p6",txtACRole.Text);
        cmd1.Parameters.AddWithValue("@p7",txtACPNumber.Text);
        cmd1.Parameters.AddWithValue("@p8",txtACEmail.Text);
        cmd1.Parameters.AddWithValue("@p9",txtACUsername.Text);
        cmd1.Parameters.AddWithValue("@p10",txtACPassword.Text);
        cmd1.ExecuteNonQuery();
        con.Close();
        DlACSocietyCode.SelectedIndex = 0;
        txtACSName.Text = "";
        txtACMName.Text = "";
        txtACCMCode.Text = "";
        txtACBDate.Text = "";
        txtACRole.Text = "";
        txtACPNumber.Text = "";
        txtACEmail.Text = "";
        txtACUsername.Text = "";
        txtACPassword.Text = "";
        lblACFlag.ForeColor = System.Drawing.Color.Green;
        lblACFlag.Text = "New Committee Member Added Successfully.".ToString();
        
      }
    }

    protected void DlACSocietyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (DlACSocietyCode.SelectedIndex != 0)
      {
        con.Open();
        String fetchdata = "select * from SocietyInfo where SocietyCode='"+DlACSocietyCode.SelectedValue.ToString()+"'";
        SqlCommand cmd2 = new SqlCommand(fetchdata, con);
        SqlDataReader dr2 = cmd2.ExecuteReader();
        while (dr2.Read())
        {
          txtACSName.Text = dr2["SocietyName"].ToString();
        }
      }
      else
      {
        txtACSName.Text ="";
      }
    }
  }
}
