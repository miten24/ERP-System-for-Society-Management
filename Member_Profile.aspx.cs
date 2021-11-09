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
  public partial class Member_Profile : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblMPMName.Text = Session["MName"].ToString();
      lblMPUsername.Text = Session["MUsername"].ToString();
      Load_Data();
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
          lblMPName.Text = dt.Rows[0]["MName"].ToString();
          lblMPSCode.Text = dt.Rows[0]["SocietyCode"].ToString();
          lblMPSName.Text = dt.Rows[0]["SocietyName"].ToString();
          lblMPBlock.Text = dt.Rows[0]["MBlock"].ToString();
          lblMPHType.Text = dt.Rows[0]["HouseType"].ToString();
          lblMPTotalFM.Text = dt.Rows[0]["MTotalmember"].ToString();
          DateTime dt1 = Convert.ToDateTime(dt.Rows[0]["MBDate"].ToString());
          lblMPBDate.Text = String.Format("{0}/{1}/{2}", dt1.Month, dt1.Day, dt1.Year);
          lblMPPhoneNo.Text = dt.Rows[0]["MPhone"].ToString();
          lblMPEmail.Text = dt.Rows[0]["MEmail"].ToString();
          
        }
      }
    }
    protected void MLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
  }
}
