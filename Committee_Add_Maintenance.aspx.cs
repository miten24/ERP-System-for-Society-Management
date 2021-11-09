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
  public partial class Committee_Add_Maintenance : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      txtCAMSCode.Text = Session["CSCode"].ToString();
      txtCAMSName.Text = Session["CSName"].ToString();
      txtCAMCCode.Text = Session["CoCode"].ToString();
      txtCAMCName.Text = Session["CName"].ToString();
      if (!IsPostBack)
      {
        con.Open();
        String s = "select MBlock from MemberInfo where SocietyCode=@pc order by MBlock";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("@pc",Session["CSCode"].ToString());
        SqlDataReader dr = cmd.ExecuteReader();

        dlCAMBlock.DataSource = dr;
        dlCAMBlock.DataTextField = "MBlock";
        dlCAMBlock.DataValueField = "MBlock";
        dlCAMBlock.DataBind();
        dlCAMBlock.Items.Insert(0, "Select Block Number");
      }
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }

    protected void dlCAMBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (dlCAMBlock.SelectedIndex != 0)
      {
        con.Open();
        String fetchdata = "select * from MemberInfo where MBlock='" + dlCAMBlock.SelectedValue.ToString() + "' and SocietyCode=@pc1";
        SqlCommand cmd4 = new SqlCommand(fetchdata, con);
        cmd4.Parameters.AddWithValue("@pc1", Session["CSCode"].ToString());
        SqlDataReader dr = cmd4.ExecuteReader();
        while (dr.Read())
        {
          txtCAMMName.Text = dr["MName"].ToString();
        }
      }
      else
      {
        txtCAMMName.Text = "";
      }
    }

    protected void btnCAMAddM_Click(object sender, EventArgs e)
    {
      con.Open();
      string sam = "insert into SocietyMaintenance (SocietyCode,SocietyName,CoCode,CommitteeMName,BlockNo,MemberName,FilledDate,Month,Amount) values (@psc,@psn,@pco,@pcn,@pbn,@pmn,@pfd,@pm,@pa)";
      SqlCommand samcmd = new SqlCommand(sam, con);
      samcmd.Parameters.AddWithValue("@psc",txtCAMSCode.Text);
      samcmd.Parameters.AddWithValue("@psn",txtCAMSName.Text);
      samcmd.Parameters.AddWithValue("@pco",txtCAMCCode.Text);
      samcmd.Parameters.AddWithValue("@pcn",txtCAMCName.Text);
      samcmd.Parameters.AddWithValue("@pbn",dlCAMBlock.SelectedValue.ToString());
      samcmd.Parameters.AddWithValue("@pmn",txtCAMMName.Text);
      samcmd.Parameters.AddWithValue("@pfd",txtCAMFDate.Text);
      samcmd.Parameters.AddWithValue("@pm",txtCAMMonth.Text);
      samcmd.Parameters.AddWithValue("@pa",txtCAMAmount.Text);
      samcmd.ExecuteNonQuery();
      upateIncome(txtCAMSCode.Text,txtCAMSName.Text,txtCAMCCode.Text,txtCAMCName.Text,txtCAMFDate.Text,int.Parse(txtCAMAmount.Text),dlCAMBlock.SelectedValue.ToString());
      lblCAMflag.Text = "Maintenance Added";
      clear();
    }
    protected void upateIncome(string sc,string sn,string cc,string cn,string d,int a,string block)
    {
      string si = "insert into SocietyIncome (SocietyCode,SocietyName,CoCode,CommitteeMName,Date,Amount,Reason) values (@p1sc,@p1sn,@p1co,@p1cn,@p1d,@p1a,@p1r)";
      SqlCommand sicmd = new SqlCommand(si, con);
      sicmd.Parameters.AddWithValue("@p1sc", sc);
      sicmd.Parameters.AddWithValue("@p1sn", sn);
      sicmd.Parameters.AddWithValue("@p1co", cc);
      sicmd.Parameters.AddWithValue("@p1cn",cn);
      sicmd.Parameters.AddWithValue("@p1d", d);
      sicmd.Parameters.AddWithValue("@p1a", a);
      sicmd.Parameters.AddWithValue("@p1r", "Maintenance of Block No."+block);
      sicmd.ExecuteNonQuery();
      
      updateSocietyAccount(sc, a);
    }
    protected void updateSocietyAccount(string sc, int amount)
    {
      
      string s = "select TotalAmount from SocietyAccount where SocietyCode=@p1";
      SqlCommand scmd1 = new SqlCommand(s, con);
      scmd1.Parameters.AddWithValue("@p1", sc);
      scmd1.ExecuteNonQuery();
      SqlDataReader drc = scmd1.ExecuteReader();
      if (drc.Read())
      {
        int totalAmount = (int)drc["TotalAmount"];
        totalAmount = totalAmount + amount;
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
    protected void clear()
    {
      dlCAMBlock.SelectedIndex = 0;
      txtCAMMName.Text = "";
      txtCAMMonth.Text = "";
      txtCAMFDate.Text = "";
      txtCAMAmount.Text = "";
    }
  }
}
