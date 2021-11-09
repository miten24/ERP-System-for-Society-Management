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
  public partial class Admin_UpdateSocietyInfo : System.Web.UI.Page
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

        dlUScode.DataSource = dr;
        dlUScode.DataTextField = "SocietyCode";
        dlUScode.DataValueField = "SocietyCode";
        dlUScode.DataBind();
        dlUScode.Items.Insert(0, "Select Society Code");

      }
    }
    protected void ALogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("AdminLogin.aspx");
    }
    protected void Clear()
    {
      dlUScode.SelectedIndex = 0;
      txtUSName.Text = "";
      txtUSBlocks.Text = "";
      txtUSAddress.Text = "";
      txtUSCity.Text = "";
      txtUSDate.Text = "";
      txtUSState.Text = "";
    }
    

    protected void btnUSUpdate_Click(object sender, EventArgs e)
    {
      con.Open();
      String q = "UPDATE SocietyInfo SET SocietyName=@p1,NoOfBlocks=@p2,EntryDate=@p3,Address=@p4,City=@p5,State=@p6 WHERE SocietyCode=@p7";
      SqlCommand cmd2 = new SqlCommand(q, con);
      cmd2.Parameters.AddWithValue("@p1",txtUSName.Text);
      cmd2.Parameters.AddWithValue("@p2",txtUSBlocks.Text);
      cmd2.Parameters.AddWithValue("@p3",txtUSDate.Text);
      cmd2.Parameters.AddWithValue("@p4",txtUSAddress.Text);
      cmd2.Parameters.AddWithValue("@p5",txtUSCity.Text);
      cmd2.Parameters.AddWithValue("@p6",txtUSState.Text);
      cmd2.Parameters.AddWithValue("@p7", dlUScode.SelectedItem.Value.ToString());
      cmd2.ExecuteNonQuery();
      lblUSflag.Text = "Updated successfuly".ToString();
      Clear();
    }

    protected void dlUScode_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (dlUScode.SelectedIndex != 0)
      {
        con.Open();
        String fetchdata = "select * from SocietyInfo where SocietyCode='"+ dlUScode.SelectedValue.ToString()+"'";
        SqlCommand cmd3 = new SqlCommand(fetchdata,con);
        SqlDataReader dr2 = cmd3.ExecuteReader();
        while (dr2.Read())
        {
          txtUSName.Text = dr2["SocietyName"].ToString();
          txtUSBlocks.Text = dr2["NoOfBlocks"].ToString();
          txtUSDate.Text = dr2["EntryDate"].ToString();
          txtUSAddress.Text = dr2["Address"].ToString();
          txtUSCity.Text = dr2["City"].ToString();
          txtUSState.Text = dr2["State"].ToString();
        }
      }
      else
      {
        Clear();
      }
    }
  }
}
