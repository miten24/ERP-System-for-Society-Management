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
  public partial class Admin_RemoveSociety : System.Web.UI.Page
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
       
        dlRScode.DataSource = dr;
        dlRScode.DataTextField = "SocietyCode";
        dlRScode.DataValueField = "SocietyCode";
        dlRScode.DataBind();
        dlRScode.Items.Insert(0, "Select Society Code");
      }
    }
    protected void ALogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("AdminLogin.aspx");
    }

    protected void btnRSRemove_Click(object sender, EventArgs e)
    {
      if (rbRSNo.Checked == true)
      {
        lblRSflag.Text = "Please give the confirmation first".ToString();
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
        if (check_pass == txtRSAdminPass.Text)
        {
          
          findcity(dlRScode.SelectedValue.ToString());
          con.Open();
          // delete society
          string s = "delete from SocietyInfo where SocietyCode=@p2";
          SqlCommand cmd1 = new SqlCommand(s, con);
          cmd1.Parameters.AddWithValue("@p2", dlRScode.SelectedItem.Value.ToString());
          cmd1.ExecuteNonQuery();
          
          //delete Committee member
          string s1 = "delete from CommitteeInfo where SocietyCode=@p3";
          SqlCommand cmd2 = new SqlCommand(s1, con);
          cmd2.Parameters.AddWithValue("@p3", dlRScode.SelectedItem.Value.ToString());
          cmd2.ExecuteNonQuery();

          // delete members
           string s2 = "delete from MemberInfo where SocietyCode=@p4";
           SqlCommand cmd3 = new SqlCommand(s2, con);
           cmd3.Parameters.AddWithValue("@p4", dlRScode.SelectedItem.Value.ToString());
           cmd3.ExecuteNonQuery();
          
          //delete vehicle Deatils
          string sv = "delete from VehicleDetails where SocietyCode=@pcv";
          SqlCommand rvcmd = new SqlCommand(sv, con);
          rvcmd.Parameters.AddWithValue("@pcv", dlRScode.SelectedItem.Value.ToString());
          rvcmd.ExecuteNonQuery();


          //delete society Account info
          updateSocietyAccount(dlRScode.SelectedItem.Value.ToString());
          lblRSflag.Text = "Deleted".ToString();
          dlRScode.SelectedIndex = 0;
          txtRSAdminPass.Text = "";
          txtRSName.Text = "";

          
        }
        else
        {
          lblRSflag.Text = "Password is incorrect".ToString();
        }
      }

    }
    protected void findcity(string scode)
    {
      con.Open();
      string fc = "select * from SocietyInfo where SocietyCode=@psfc";
      SqlCommand cmdfc = new SqlCommand(fc, con);
      cmdfc.Parameters.AddWithValue("@psfc", scode);
      cmdfc.ExecuteNonQuery();
      SqlDataReader drfc = cmdfc.ExecuteReader();
      if (drfc.Read())
      {
        string cityofs = drfc["City"].ToString();
        updateCityWiseSociety(cityofs);
      }
      

    }
    protected void updateCityWiseSociety(string c)
    {
      con.Close();
      con.Open();
      string sr = "select * from CityWiseSociety where City=@pcws";
      SqlCommand cmds = new SqlCommand(sr, con);
      cmds.Parameters.AddWithValue("@pcws", c);
      cmds.ExecuteNonQuery();
      SqlDataReader drs = cmds.ExecuteReader();
      if (drs.Read())
      {
        int n = (int)drs["NoOfSociety"];
        if (n == 1)
        {
          removenoofsociety(c);
        }
        else
        {
          n = n - 1;
          updatenoofsociety(c, n);
        }
        
      }

    }
    protected void removenoofsociety(string c)
    {
      con.Close();
      con.Open();
      string cqr = " delete from CityWiseSociety where City=@prc";
      SqlCommand cmdcqr = new SqlCommand(cqr, con);
      cmdcqr.Parameters.AddWithValue("@prc", c);
      cmdcqr.ExecuteNonQuery();
      con.Close();
    }
    protected void updatenoofsociety(string c, int n)
    {
      con.Close();
      con.Open();
      string cqu = "update CityWiseSociety set NoOfSociety=@pun where City=@puc";
      SqlCommand cmdcqu = new SqlCommand(cqu, con);
      cmdcqu.Parameters.AddWithValue("@puc", c);
      cmdcqu.Parameters.AddWithValue("@pun", n);
      cmdcqu.ExecuteNonQuery();
      con.Close();
    }
    protected void Clear()
    {
      txtRSAdminPass.Text = "";
      txtRSName.Text = "";
    }

    protected void dlRScode_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (dlRScode.SelectedIndex != 0)
      {
        con.Open();
        String fetchdata = "select * from SocietyInfo where SocietyCode='"+dlRScode.SelectedValue.ToString()+"'";
        SqlCommand cmd4 = new SqlCommand(fetchdata, con);
        SqlDataReader dr = cmd4.ExecuteReader();
        while (dr.Read())
        {
          txtRSName.Text = dr["SocietyName"].ToString();
        }
      }
      else
      {
        Clear();
      }
    }
    protected void updateSocietyAccount(string sc)
    {
      
      string dsa = "delete from SocietyAccount where SocietyCode=@psc";
      SqlCommand dsacmd = new SqlCommand(dsa, con);
      dsacmd.Parameters.AddWithValue("@psc", sc);
      dsacmd.ExecuteNonQuery();
      string dsi = "delete from SocietyIncome where SocietyCode=@psc1";
      SqlCommand dsicmd = new SqlCommand(dsi, con);
      dsicmd.Parameters.AddWithValue("@psc1", sc);
      dsicmd.ExecuteNonQuery();
      string dso = "delete from SocietyExpenses where SocietyCode=@psc2";
      SqlCommand dsocmd = new SqlCommand(dso, con);
      dsocmd.Parameters.AddWithValue("@psc2", sc);
      dsocmd.ExecuteNonQuery();
    }
  }
}


