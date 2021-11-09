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
  public partial class Admin_Remove_Committee_Member : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void societydl()
    {
      if (!IsPostBack)
      {
        con.Open();
        String s = "select SocietyCode from SocietyInfo";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();

        dlASCode.DataSource = dr;
        dlASCode.DataTextField = "SocietyCode";
        dlASCode.DataValueField = "SocietyCode";
        dlASCode.DataBind();
        dlASCode.Items.Insert(0, "Select Society Code");

        con.Close();
      }
    }
    /*protected void Committeedl()
    {
      if (!IsPostBack)
      {
        con.Open();
        String cs = "select CoCode from CommitteeInfo where SocietyCode=@pc";
        SqlCommand ccmd = new SqlCommand(cs, con);
        ccmd.Parameters.AddWithValue("@pc",dlASCode.SelectedValue.ToString());
        SqlDataReader cdr = ccmd.ExecuteReader();

        dlARCMCode.DataSource = cdr;
        dlARCMCode.DataTextField = "CoCode";
        dlARCMCode.DataValueField = "CoCode";
        dlARCMCode.DataBind();
        dlARCMCode.Items.Insert(0, "Select Committee Code");

        con.Close();
      }
    }*/
    protected void Page_Load(object sender, EventArgs e)
    {
      lblAdminName.Text = Session["AName"].ToString();
      societydl();
      //Committeedl();
    }
    protected void ALogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("AdminLogin.aspx");
    }

    

    protected void dlASCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (dlASCode.SelectedIndex != 0)
      {
        con.Open();
        String fetchdata = "select * from SocietyInfo where SocietyCode='" + dlASCode.SelectedValue.ToString() + "'";
        SqlCommand cmd4 = new SqlCommand(fetchdata, con);
        SqlDataReader dr2 = cmd4.ExecuteReader();
        
        while (dr2.Read())
        {
          txtARCMSN.Text = dr2["SocietyName"].ToString();
        
        }
        if (IsPostBack)
        {
          con.Close();
          con.Open();
          String cs = "select CoCode from CommitteeInfo where SocietyCode=@pc";
          SqlCommand ccmd = new SqlCommand(cs, con);
          ccmd.Parameters.AddWithValue("@pc", dlASCode.SelectedValue.ToString());
          SqlDataReader cdr = ccmd.ExecuteReader();
          
          dlARCMCode.DataSource = cdr;
          dlARCMCode.DataTextField = "CoCode";
          dlARCMCode.DataValueField = "CoCode";
          dlARCMCode.DataBind();
          dlARCMCode.Items.Insert(0, "Select Committee Code");
          con.Close();
          
        }

        con.Close();
      }
      else
      {
        txtARCMSN.Text = "";
        txtARCMName.Text = "";
        txtARCRole.Text = "";
      }
    }

    protected void dlARCMCode_SelectedIndexChanged(object sender, EventArgs e)
    {

        con.Open();
        String cfetchdata = "select * from CommitteeInfo where CoCode='" + dlARCMCode.SelectedValue.ToString() + "'";
        SqlCommand ccmd4 = new SqlCommand(cfetchdata, con);
        SqlDataReader cdr2 = ccmd4.ExecuteReader();

        while (cdr2.Read())
        {
          txtARCMName.Text = cdr2["CommitteeMName"].ToString();
          txtARCRole.Text = cdr2["CRole"].ToString();
        }
        con.Close();
      
    }



    protected void btnARCRemove_Click(object sender, EventArgs e)
    {
      if (rbRMNo.Checked == true)
      {
        lblARCflag.Text = "Please give the confirmation first".ToString();
      }
      else
      {
        String check_pass = "";
        con.Open();
        String q = "select APassword from AdminInfo where AName=@p1";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@p1", Session["AName"].ToString());
        cmd.ExecuteNonQuery();
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
          check_pass = rdr["APassword"].ToString();
        }
        con.Close();
        if (check_pass == txtARCPassword.Text)
        {
          con.Open();
          // delete members
          string s2 = "delete from CommitteeInfo where CoCode=@p4";
          SqlCommand cmd3 = new SqlCommand(s2, con);
          cmd3.Parameters.AddWithValue("@p4", dlARCMCode.SelectedItem.Value.ToString());
          cmd3.ExecuteNonQuery();
          lblARCflag.Text = "Deleted".ToString();
          dlARCMCode.SelectedIndex = 0;
          txtARCPassword.Text = "";
          txtARCMName.Text = "";
          txtARCRole.Text = "";
        }
        else
        {
          lblARCflag.Text = "Password is incorrect".ToString();
        }
      }
    }
  }
}
