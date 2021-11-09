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
  public partial class Admin_AddSociety : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack){ 
      lblAdminName.Text = Session["AName"].ToString();

      con.Open();
      String s = "select DISTINCT State from CityState";
      SqlCommand cmd = new SqlCommand(s, con);
      SqlDataReader dr = cmd.ExecuteReader();

      dlAASState.DataSource = dr;
      dlAASState.DataTextField = "State";
      dlAASState.DataValueField = "State";
      dlAASState.DataBind();
      dlAASState.Items.Insert(0, "Select State");
      con.Close();
    }
      
      
    }
    protected void ALogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("AdminLogin.aspx");
    }

    protected void btnAddSociety_Click(object sender, EventArgs e)
    {
      con.Open();
      String s = "select * from SocietyInfo  where SocietyCode=@p1";
      SqlCommand cmd = new SqlCommand(s, con);
      cmd.Parameters.AddWithValue("@p1", txtASCode.Text);
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      con.Close();
      if (dt.Rows.Count > 0)
      {
        txtASCode.Text = "";
        lblASflag.ForeColor = System.Drawing.Color.Red;
        lblASflag.Text = "This Code is Already taken".ToString();
      }
      else
      {
        
        if (dlAASState.SelectedIndex != 0)
        {
          
          con.Open();
          String str = "insert into SocietyInfo (SocietyCode,SocietyName,NoOfBlocks,EntryDate,Address,City,State) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
          SqlCommand cmd1 = new SqlCommand(str, con);
          cmd1.Parameters.AddWithValue("@p1", txtASCode.Text);
          cmd1.Parameters.AddWithValue("@p2", txtASName.Text);
          cmd1.Parameters.AddWithValue("@p3", txtASBlock.Text);
          cmd1.Parameters.AddWithValue("@p4", txtASDate.Text);
          cmd1.Parameters.AddWithValue("@p5", txtASAddress.Text);
          cmd1.Parameters.AddWithValue("@p6", dlAASCity.SelectedValue.ToString());
          cmd1.Parameters.AddWithValue("@p7", dlAASState.SelectedValue.ToString());
          cmd1.ExecuteNonQuery();
          con.Close();
          updateSocietyAccount(txtASCode.Text, txtASName.Text);
          updateCityWiseSociety(dlAASCity.SelectedValue.ToString());
          txtASCode.Text = "";
          txtASName.Text = "";
          txtASBlock.Text = "";
          txtASDate.Text = "";
          txtASAddress.Text = "";
          dlAASCity.SelectedIndex = 0;
          dlAASState.SelectedIndex = 0;
          lblASflag.ForeColor = System.Drawing.Color.Green;
          lblASflag.Text = "New Society Added Successfully.".ToString();
          
        }
        else
        {
          lblASflag.Text = "Select State and City Correctly.";
        }

      }
    }
    protected void updateCityWiseSociety(String c)
    {
      con.Open();
      string cq = "select * from CityWiseSociety where City=@p1";
      SqlCommand cmdcq = new SqlCommand(cq, con);
      cmdcq.Parameters.AddWithValue("@p1", c);
      cmdcq.ExecuteNonQuery();
      SqlDataReader drc = cmdcq.ExecuteReader();
      if (drc.Read())
      {
        int n = (int)drc["NoOfSociety"];
        n = n + 1;
        drc.Close();
        updatenoofsociety(c, n);
      }
      
      else
      {
        con.Close();
        con.Open();
        string cqa = "insert into CityWiseSociety (City,NoOfSociety) values(@pc,@pn)";
        SqlCommand cmdcqa = new SqlCommand(cqa, con);
        cmdcqa.Parameters.AddWithValue("@pc", c);
        cmdcqa.Parameters.AddWithValue("@pn",1);
        cmdcqa.ExecuteNonQuery();
        con.Close();
      }
    }
    protected void updatenoofsociety(string c,int n)
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


    protected void dlAASState_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (dlAASState.SelectedIndex != 0)
      {
        if (IsPostBack)
        {
          con.Open();
          String sc = "select City from CityState where State=@p1";
          SqlCommand cmdc = new SqlCommand(sc, con);
          cmdc.Parameters.AddWithValue("@p1", dlAASState.SelectedValue);
          SqlDataReader drc = cmdc.ExecuteReader();
          dlAASCity.DataSource = drc;
          dlAASCity.DataTextField = "City";
          dlAASCity.DataValueField = "City";
          dlAASCity.DataBind();
          dlAASCity.Items.Insert(0, "Select City");
          con.Close();

        }
      }
    }
    protected void updateSocietyAccount(string sc,string sn)
    {
      con.Open();
      string susa = "insert into SocietyAccount (SocietyCode,SocietyName,TotalAmount) values (@psc,@psn,@pta)";
      SqlCommand usacmd = new SqlCommand(susa, con);
      usacmd.Parameters.AddWithValue("@psc",sc);
      usacmd.Parameters.AddWithValue("@psn",sn);
      usacmd.Parameters.AddWithValue("@pta", 0);
      usacmd.ExecuteNonQuery();
      con.Close();
    }
  }
}
