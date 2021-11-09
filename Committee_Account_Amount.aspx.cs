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
  public partial class Committee_Account_Amount : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      lblTamount.Text = TotalAmount(Session["CSCode"].ToString()).ToString();
    }
    protected int TotalAmount( string sc)
    {
      con.Open();
      string s = "select TotalAmount from SocietyAccount where SocietyCode=@p1";
      SqlCommand scmd1 = new SqlCommand(s, con);
      scmd1.Parameters.AddWithValue("@p1", sc);
      scmd1.ExecuteNonQuery();
      SqlDataReader drc = scmd1.ExecuteReader();
      if (drc.Read())
      {
        int totalAmount = (int)drc["TotalAmount"];
        return totalAmount;
        drc.Close();
      }
      else
      {
        return 0;
      }

      }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnIncomeH_Click(object sender, EventArgs e)
    {
      Response.Redirect("Committee_Income_History.aspx");

    }

    protected void btnExpenseH_Click(object sender, EventArgs e)
    {
      Response.Redirect("Committee_Expenses_History.aspx");
    }
  }
}
