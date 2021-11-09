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
  public partial class Committee_Society_Info : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      lblCSISName.Text = Session["CSName"].ToString();
      lblCSISCode.Text = Session["CSCode"].ToString();

      Load_data();
    }
    protected void Load_data()
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
        lblCSIBlocks.Text = dt.Rows[0]["NoOfBlocks"].ToString();

        DateTime dt1 = Convert.ToDateTime(dt.Rows[0]["EntryDate"].ToString());
        lblCSIUDate.Text = String.Format("{0}/{1}/{2}", dt1.Month, dt1.Day, dt1.Year);

        //lblCSIUDate.Text = dt.Rows[0]["EntryDate"].ToString();
        lblCSIAddress.Text = dt.Rows[0]["Address"].ToString();
        lblCSICity.Text = dt.Rows[0]["City"].ToString();
        lblCSIState.Text = dt.Rows[0]["State"].ToString();
      }
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
  }
}
