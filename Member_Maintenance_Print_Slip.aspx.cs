using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagment
{
  public partial class Member_Maintenance_Print_Slip : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblMPMName.Text = Session["MName"].ToString();
    }
    protected void MLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnMPrint_Click(object sender, EventArgs e)
    {
      con.Open();
      string s = "select * from SocietyMaintenance where SocietyCode=@p1 and BlockNo=@p2 and Month=@pm";
      SqlCommand cmd = new SqlCommand(s, con);
      cmd.Parameters.AddWithValue("@p1", Session["MSCode"].ToString());
      cmd.Parameters.AddWithValue("@p2", Session["MBlock"].ToString());
      cmd.Parameters.AddWithValue("@pm", txtCMSMonth.Text);
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      con.Close();
      if (dt.Rows.Count > 0)
      {
        lblCheckPflag.Text = " ";
        Application["MMonth"]= txtCMSMonth.Text;
        string url = "Maintenance_Slip.aspx";
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.open('");
        sb.Append(url);
        sb.Append("');");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(),"script", sb.ToString());
      }
      else
      {
        lblCheckPflag.Text = "Your Maintenance is pending.";
      }
    }
  }
}
