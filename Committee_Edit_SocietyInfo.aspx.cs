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
  public partial class Committee_Edit_SocietyInfo : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      txtCESICode.Text = Session["CSCode"].ToString();
      txtCESIName.Text = Session["CSName"].ToString();
      Load_data();
    }
    protected void Load_data()
    {
      if (!IsPostBack)
      {
        con.Open();
        string q = "select * from SocietyInfo where SocietyCode=@p1";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@p1", Session["CSCode"]);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
          
          txtCESINoOfBlock.Text = dt.Rows[0]["NoOfBlocks"].ToString();
          //lblCSIUDate.Text = dt.Rows[0]["EntryDate"].ToString();
          txtCESIAddress.Text = dt.Rows[0]["Address"].ToString();
          txtCESICity.Text = dt.Rows[0]["City"].ToString();
          txtCESIState.Text = dt.Rows[0]["State"].ToString();
        }
      }
      
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnCESICancel_Click(object sender, EventArgs e)
    {
      Response.Redirect("Committee_Society_Info.aspx");
    }

    protected void btnCESISave_Click(object sender, EventArgs e)
    {
      
      if(txtCESIName.Text=="" || txtCESINoOfBlock.Text=="" || txtCESIDate.Text == "" || txtCESIAddress.Text == "" || txtCESICity.Text == "" || txtCESIState.Text == "")
      {
        lblCESIflag.Text = "Please Fill all the details.";
      }
      else
      {
        
        con.Open();
        string uq = "UPDATE SocietyInfo SET NoOfBlocks=@pb,EntryDate=@pd,Address=@pa,City=@pc,State=@ps Where SocietyCode=@p7";
        SqlCommand cmdu = new SqlCommand(uq, con);
        cmdu.Parameters.AddWithValue("@pb", txtCESINoOfBlock.Text);
        cmdu.Parameters.AddWithValue("@pd", txtCESIDate.Text);
        cmdu.Parameters.AddWithValue("@pa", txtCESIAddress.Text);
        cmdu.Parameters.AddWithValue("@pc", txtCESICity.Text);
        cmdu.Parameters.AddWithValue("@ps", txtCESIState.Text);
        cmdu.Parameters.AddWithValue("@p7", txtCESICode.Text);
        cmdu.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Committee_Society_Info.aspx");
      }
    }
  }
}
