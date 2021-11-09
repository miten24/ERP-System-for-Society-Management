using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace SocietyManagment
{
  public partial class Maintenance_Slip : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      loadData();
      string s = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
      lblRecipt.Text = s;
    }
    protected void loadData()
    {
      con.Open();
      string s= "Select * from SocietyMaintenance where SocietyCode=@pc and BlockNo=@pb and Month=@pm";
      SqlCommand cmd = new SqlCommand(s, con);
      cmd.Parameters.AddWithValue("@pc", Session["MSCode"].ToString());
      cmd.Parameters.AddWithValue("@pb", Session["MBlock"].ToString());
      cmd.Parameters.AddWithValue("@pm", Application["MMonth"].ToString());
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      con.Close();
      if (dt.Rows.Count > 0)
      {
        lblSocietyCode.Text = dt.Rows[0]["SocietyCode"].ToString();
        lblSocietyName.Text = dt.Rows[0]["SocietyName"].ToString();
        lblCommitteeCode.Text = dt.Rows[0]["CoCode"].ToString();
        lblCommitteeMName.Text = dt.Rows[0]["CommitteeMName"].ToString();
        lblBlock.Text = dt.Rows[0]["BlockNo"].ToString();
        lblMemberName.Text = dt.Rows[0]["MemberName"].ToString();
        lblMonth.Text = dt.Rows[0]["Month"].ToString();
        lblAmount.Text = dt.Rows[0]["Amount"].ToString();

        DateTime dt1 = Convert.ToDateTime(dt.Rows[0]["FilledDate"].ToString());
        lblDate.Text = String.Format("{0}/{1}/{2}", dt1.Month, dt1.Day, dt1.Year);
      }
      }
    public override void VerifyRenderingInServerForm(Control control)
    {
      base.VerifyRenderingInServerForm(control);

    }
    private void exportpdf()
    {
      Response.ContentType = "application/pdf";
      Response.AddHeader("content-disposition", "attachment;filename=MaintenanceReceipt.pdf");
      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      StringWriter sw = new StringWriter();
      HtmlTextWriter hw = new HtmlTextWriter(sw);
      
      Panel1.RenderControl(hw);
      StringReader sr = new StringReader(sw.ToString());
      Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
      HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
      PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
      pdfDoc.Open();
      htmlparser.Parse(sr);
      pdfDoc.Close();
      Response.Write(pdfDoc);
      Response.End();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
      exportpdf();
    }
  }
}
