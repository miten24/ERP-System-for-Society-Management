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
  public partial class Member_Societyinfo : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblMPMName.Text = Session["MName"].ToString();
      lblMSISName.Text = Session["MSName"].ToString();
      lblMSISCode.Text = Session["MSCode"].ToString();
      Load_data();
    }
    protected void MLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
    protected void Load_data()
    {
      con.Open();
      string q = "select * from SocietyInfo where SocietyCode=@p1";
      SqlCommand cmd = new SqlCommand(q, con);
      cmd.Parameters.AddWithValue("@p1", Session["MSCode"]);
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      con.Close();
      if (dt.Rows.Count > 0)
      {
        lblMSIBlocks.Text = dt.Rows[0]["NoOfBlocks"].ToString();


        DateTime dt1 = Convert.ToDateTime(dt.Rows[0]["EntryDate"].ToString());
        lblMSIUDate.Text = String.Format("{0}/{1}/{2}", dt1.Month, dt1.Day, dt1.Year);

        //lblCSIUDate.Text = dt.Rows[0]["EntryDate"].ToString();
        lblMSIAddress.Text = dt.Rows[0]["Address"].ToString();
        lblMSICity.Text = dt.Rows[0]["City"].ToString();
        lblMSIState.Text = dt.Rows[0]["State"].ToString();
      }
    }
    
  }
}
