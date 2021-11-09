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
  public partial class Committee_Edit_Profile : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      txtCEPCCode.Text = Session["CoCode"].ToString();
      Load_Data();
    }
    protected void Load_Data()
    {
      if (!IsPostBack)
      {
        con.Open();
        string q = "select * from CommitteeInfo where CoCode=@p1";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@p1", Session["CoCode"]);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {

          txtCEPSCode.Text = dt.Rows[0]["SocietyCode"].ToString();
          txtCEPSName.Text = dt.Rows[0]["SocietyName"].ToString();
          
          txtCEPCName.Text = dt.Rows[0]["CommitteeMName"].ToString();
          txtCEPRole.Text = dt.Rows[0]["CRole"].ToString();
          txtCEPPhoneNo.Text = dt.Rows[0]["PhoneNumber"].ToString();
          txtCEPEmail.Text = dt.Rows[0]["Email"].ToString();
        }
      }
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnCEPCancel_Click(object sender, EventArgs e)
    {
      Response.Redirect("Committee_Profile.aspx");
    }

    protected void btnCEPSave_Click(object sender, EventArgs e)
    {
      if (txtCEPCName.Text == "" || txtCEPRole.Text == "" || txtCEPDate.Text == "" || txtCEPPhoneNo.Text == "" || txtCEPEmail.Text == "")
      {
        lblCEPflag.Text = "Please Fill all the details.";
      }
      else
      {
        con.Open();
        string uq = "UPDATE CommitteeInfo SET CommitteeMName=@pn,BDate=@pd,CRole=@pr,PhoneNumber=@ppn,Email=@pe Where CoCode=@p7";
        SqlCommand cmdu = new SqlCommand(uq, con);
        cmdu.Parameters.AddWithValue("@pn", txtCEPCName.Text);
        cmdu.Parameters.AddWithValue("@pd", txtCEPDate.Text);
        cmdu.Parameters.AddWithValue("@pr", txtCEPRole.Text);
        cmdu.Parameters.AddWithValue("@ppn", txtCEPPhoneNo.Text);
        cmdu.Parameters.AddWithValue("@pe", txtCEPEmail.Text);
        cmdu.Parameters.AddWithValue("@p7", txtCEPCCode.Text);
        cmdu.ExecuteNonQuery();
        Session["CName"] = txtCEPCName.Text;
        con.Close();
        Response.Redirect("Committee_Profile.aspx");
      }
    }
  }
}
