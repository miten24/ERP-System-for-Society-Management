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
  public partial class Committee_Add_Member : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      txtCAMSCode.Text = Session["CSCode"].ToString();
      txtCAMSName.Text = Session["CSName"].ToString();
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
    bool checkAvaibility()
    {
      
      SqlCommand cmd = new SqlCommand("select * from MemberInfo where (MUsername=@p1 or MBlock=@p2) and SocietyCode=@pc",con);
      cmd.Parameters.AddWithValue("@p1", txtCAMUsername.Text);
      cmd.Parameters.AddWithValue("@p2", txtCAMBloackNo.Text);
      cmd.Parameters.AddWithValue("@pc",Session["CSCode"].ToString());
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      if (dt.Rows.Count > 0)
      {
        return false;
      }
      return true;
    }
    void clear()
    {
      txtCAMSCode.Text = "";
      txtCAMSName.Text = "";
      txtCAMName.Text = "";
      txtCAMBDate.Text = "";
      txtCAMFamilyMember.Text = "";
      txtCAMPhone.Text="";
      txtCAMEmail.Text="";
      txtCAMHouseType.Text="";
      txtCAMBloackNo.Text="";
      txtCAMUsername.Text="";
      txtCAMPassword.Text="";
    }
    protected void btnCAddMember_Click(object sender, EventArgs e)
    {
      con.Open();
      if (Int32.Parse(txtCAMFamilyMember.Text) > 0)
      {
        if (checkAvaibility() == true)
        {
          
          String str = "insert into MemberInfo (SocietyCode,SocietyName,MName,MBDate,MTotalmember,MPhone,MEmail,HouseType,MBlock,MUsername,MPassword) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
          SqlCommand cmd1 = new SqlCommand(str, con);
          cmd1.Parameters.AddWithValue("@p1",txtCAMSCode.Text);
          cmd1.Parameters.AddWithValue("@p2",txtCAMSName.Text);
          cmd1.Parameters.AddWithValue("@p3",txtCAMName.Text);
          cmd1.Parameters.AddWithValue("@p4",txtCAMBDate.Text);
          cmd1.Parameters.AddWithValue("@p5",txtCAMFamilyMember.Text);
          cmd1.Parameters.AddWithValue("@p6",txtCAMPhone.Text);
          cmd1.Parameters.AddWithValue("@p7",txtCAMEmail.Text);
          cmd1.Parameters.AddWithValue("@p8",txtCAMHouseType.Text);
          cmd1.Parameters.AddWithValue("@p9",txtCAMBloackNo.Text);
          cmd1.Parameters.AddWithValue("@p10",txtCAMUsername.Text);
          cmd1.Parameters.AddWithValue("@p11",txtCAMPassword.Text);
          cmd1.ExecuteNonQuery();
          con.Close();
          clear();
          lblCAMflag.ForeColor = System.Drawing.Color.Green;
          lblCAMflag.Text = "New Member Added to the Society.".ToString();
        }
        else
        {
          txtCAMUsername.Text = "";
          lblCAMflag.ForeColor = System.Drawing.Color.Red;
          lblCAMflag.Text = "This Username is Already taken or block no added".ToString();
        }
      }
      else
      {
        lblCAMflag.ForeColor = System.Drawing.Color.Red;
        lblCAMflag.Text = "Enter valid Number of Family Member";
        txtCAMFamilyMember.Text = "";
      }
    }
  }
}
