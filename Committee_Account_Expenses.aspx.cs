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
  public partial class Committee_Account_Expenses : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      txtCAESCode.Text= Session["CSCode"].ToString();
      txtCAESName.Text= Session["CSName"].ToString(); 
      txtCAECCode.Text= Session["CoCode"].ToString();
      txtCAECMName.Text= Session["CName"].ToString();
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void btnCAEAddIncome_Click(object sender, EventArgs e)
    {
      con.Open();
      string si = "insert into SocietyExpenses (SocietyCode,SocietyName,CoCode,CommitteeMName,Date,Amount,Reason) values (@psc,@psn,@pco,@pcn,@pd,@pa,@pr)";
      SqlCommand sicmd = new SqlCommand(si, con);
      sicmd.Parameters.AddWithValue("@psc", txtCAESCode.Text);
      sicmd.Parameters.AddWithValue("@psn", txtCAESName.Text);
      sicmd.Parameters.AddWithValue("@pco", txtCAECCode.Text);
      sicmd.Parameters.AddWithValue("@pcn", txtCAECMName.Text);
      sicmd.Parameters.AddWithValue("@pd", txtCAEDate.Text);
      sicmd.Parameters.AddWithValue("@pa", txtCAEAmount.Text);
      sicmd.Parameters.AddWithValue("@pr", txtCAEReason.Text);
      sicmd.ExecuteNonQuery();
      con.Close();
      updateSocietyAccount(txtCAESCode.Text, int.Parse(txtCAEAmount.Text));
      lblCAEflag.Text = "Expenses Added";
      txtCAEAmount.Text = "";
      txtCAEDate.Text = "";
      txtCAEReason.Text = "";

    }
    protected void updateSocietyAccount(string sc, int amount)
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
        totalAmount = totalAmount - amount;
        drc.Close();
        updateAccountAmount(sc, totalAmount);
      }

    }
    protected void updateAccountAmount(string sc, int tamount)
    {
      string sa = "update SocietyAccount set TotalAmount=@pta where SocietyCode=@psc";
      SqlCommand stacmd = new SqlCommand(sa, con);
      stacmd.Parameters.AddWithValue("@pta", tamount);
      stacmd.Parameters.AddWithValue("@psc", sc);
      stacmd.ExecuteNonQuery();

    }
  }
}
