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
  public partial class Member_Edit_Profile : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblMPMName.Text = Session["MName"].ToString();
      txtMEPUsername.Text = Session["MUsername"].ToString();
      Load_Data();
    }
    protected void MLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
    protected void Load_Data()
    {
      if (!IsPostBack)
      {
        con.Open();
        string q = "select * from MemberInfo where MUsername=@p1";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@p1", Session["MUsername"]);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
          txtMEPMName.Text = dt.Rows[0]["MName"].ToString();
          txtMEPSCode.Text = dt.Rows[0]["SocietyCode"].ToString();
          txtMEPSName.Text = dt.Rows[0]["SocietyName"].ToString();
          txtMEPBlock.Text = dt.Rows[0]["MBlock"].ToString();
          txtMEPHType.Text = dt.Rows[0]["HouseType"].ToString();
          txtMEPTotalFM.Text = dt.Rows[0]["MTotalmember"].ToString();
          
          txtMEPPhoneNo.Text = dt.Rows[0]["MPhone"].ToString();
          txtMEPEmail.Text = dt.Rows[0]["MEmail"].ToString();

        }
      }
    }

    protected void btnMEPCancel_Click(object sender, EventArgs e)
    {
      Response.Redirect("Member_Profile.aspx");
    }

    protected void btnMEPSave_Click(object sender, EventArgs e)
    {
      if (txtMEPMName.Text == "" || txtMEPHType.Text == "" || txtMEPTotalFM.Text == "" || txtMEPBDate.Text == "" || txtMEPPhoneNo.Text == "" || txtMEPEmail.Text == "")
      {
        lblMEPflag.Text = "Please Fill all the details.";
      }
      else
      {
        con.Open();
        string uq = "UPDATE MemberInfo SET MName=@pn,MBDate=@pd,MTotalmember=@pfm,MPhone=@ppn,MEmail=@pe,HouseType=@pht Where MUsername=@p7";
        SqlCommand cmdu = new SqlCommand(uq, con);
        cmdu.Parameters.AddWithValue("@pn", txtMEPMName.Text);
        cmdu.Parameters.AddWithValue("@pd", txtMEPBDate.Text);
        cmdu.Parameters.AddWithValue("@pfm", txtMEPTotalFM.Text);
        cmdu.Parameters.AddWithValue("@ppn", txtMEPPhoneNo.Text);
        cmdu.Parameters.AddWithValue("@pe", txtMEPEmail.Text);
        cmdu.Parameters.AddWithValue("@pht", txtMEPHType.Text);
        cmdu.Parameters.AddWithValue("@p7",Session["MUsername"].ToString());
        
        cmdu.ExecuteNonQuery();
        Session["MName"] = txtMEPMName.Text;
        con.Close();
        Response.Redirect("Member_Profile.aspx");
      }
    }
  }
}
