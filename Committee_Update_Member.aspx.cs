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
  public partial class Committee_Update_Member : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      lblCommitteeMName.Text = Session["CName"].ToString();
      if (!IsPostBack)
      {
        con.Open();
        String s = "select MBlock from MemberInfo where SocietyCode=@p1";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("@p1",Session["CSCode"]);
        SqlDataReader dr = cmd.ExecuteReader();


        dlCUMBlock.DataSource = dr;
        dlCUMBlock.DataTextField = "MBlock";
        dlCUMBlock.DataValueField = "MBlock";
        dlCUMBlock.DataBind();
        dlCUMBlock.Items.Insert(0, "Select Block Number");

      }
    }
    protected void CLogout_Click(Object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("login.aspx");
    }
    protected void Clear()
    {
      txtCUMMName.Text = "";
      txtCUMBDate.Text = "";
      txtCUMTFamily.Text = "";
      txtCUMHouseType.Text = "";
      txtCUMPhone.Text = "";
      txtCUMEmail.Text = "";
      dlCUMBlock.SelectedIndex = 0;
    }
    protected void dlCUMBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (dlCUMBlock.SelectedIndex != 0)
      {
        con.Open();
        String fetchdata = "select * from MemberInfo where MBlock='" + dlCUMBlock.SelectedValue.ToString() + "'";
        SqlCommand cmd3 = new SqlCommand(fetchdata, con);
        SqlDataReader dr2 = cmd3.ExecuteReader();
        while (dr2.Read())
        {
          txtCUMMName.Text = dr2["MName"].ToString();
          //bdate
         // DateTime dt1 = Convert.ToDateTime(dr2["MBDate"].ToString());
         // txtCUMBDate.Text = String.Format("{0}/{1}/{2}", dt1.Month, dt1.Day, dt1.Year);
          txtCUMBDate.Text = DateTime.Parse(dr2["MBDate"].ToString()).ToShortDateString();
          txtCUMTFamily.Text = dr2["MTotalmember"].ToString();
          txtCUMHouseType.Text = dr2["HouseType"].ToString();
          txtCUMPhone.Text = dr2["MPhone"].ToString();
          txtCUMEmail.Text = dr2["MEmail"].ToString();
        }
      }
      else
      {
        Clear();
      }
    }

    protected void btnCUMUpdate_Click(object sender, EventArgs e)
    {
      con.Open();
      String q = "UPDATE MemberInfo SET MName=@p1,MBDate=@p2,MTotalmember=@p3,HouseType=@p4,MPhone=@p5,MEmail=@p6 WHERE MBlock=@p7 and SocietyCode=@p8";
      SqlCommand cmd2 = new SqlCommand(q, con);
      cmd2.Parameters.AddWithValue("@p1", txtCUMMName.Text);
      cmd2.Parameters.AddWithValue("@p2", txtCUMBDate.Text);
      cmd2.Parameters.AddWithValue("@p3", txtCUMTFamily.Text);
      cmd2.Parameters.AddWithValue("@p4", txtCUMHouseType.Text);
      cmd2.Parameters.AddWithValue("@p5", txtCUMPhone.Text);
      cmd2.Parameters.AddWithValue("@p6", txtCUMEmail.Text);
      cmd2.Parameters.AddWithValue("@p7", dlCUMBlock.SelectedItem.Value.ToString());
      cmd2.Parameters.AddWithValue("@p8",Session["CSCode"]);
      cmd2.ExecuteNonQuery();
      lblCUMflag.Text = "Updated successfuly".ToString();
      Clear();
    }
  }
}
