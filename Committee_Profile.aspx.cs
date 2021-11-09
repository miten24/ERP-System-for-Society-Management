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
  public partial class Committee_Profile : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      lblCPCode.Text = Session["CoCode"].ToString();
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
          lblCPName.Text = dt.Rows[0]["CommitteeMName"].ToString();
          lblCPSCode.Text = dt.Rows[0]["SocietyCode"].ToString();
          lblCPSName.Text = dt.Rows[0]["SocietyName"].ToString();
          lblCPRole.Text = dt.Rows[0]["CRole"].ToString();
          DateTime dt1 = Convert.ToDateTime(dt.Rows[0]["BDate"].ToString());
          lblCPDate.Text = String.Format("{0}/{1}/{2}", dt1.Month, dt1.Day, dt1.Year);
          lblCPPhoneNo.Text = dt.Rows[0]["PhoneNumber"].ToString();
          lblCPEmail.Text = dt.Rows[0]["Email"].ToString();
        }
      }
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
  }
}
