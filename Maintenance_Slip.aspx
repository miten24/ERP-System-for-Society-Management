<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Maintenance_Slip.aspx.cs" Inherits="SocietyManagment.Maintenance_Slip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <!-- Font Awesome -->
  <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 553px;
        }
        .auto-style4 {
            width: 553px;
            height: 26px;
        }
        .auto-style5 {
            width: 412px;
            height: 26px;
        }
        .auto-style6 {
            width: 100%;
        }
        .auto-style7 {
            width: 553px;
            height: 48px;
        }
        .auto-style8 {
            width: 412px;
            height: 48px;
        }
        .auto-style9 {
            height: 48px;
        }
        .auto-style10 {
            height: 41px;
        }
        .auto-style12 {
            width: 412px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          
            <asp:Panel ID="Panel1" runat="server">
                <table class="auto-style6">
                    <tr>
                        <td class="auto-style7">
                            <h1><i class="fas fa-building"></i>
                                <asp:Label ID="Label1" runat="server" Text="Digital Society"></asp:Label>
                            </h1>
                          
                        </td>
                        <td class="auto-style8"></td>
                        <td class="auto-style9"></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                    </tr>
                    <tr  style="background-color:whitesmoke">
                        <td class="auto-style1" colspan="3">
                            <center>
                                <asp:Label ID="Label4" runat="server" Text="Maintenance Receipt" Font-Size="XX-Large"></asp:Label>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="auto-style10">
                            <asp:Label ID="Label2" runat="server" Text="Society Name:" Font-Bold></asp:Label>&nbsp;
                            <asp:Label ID="lblSocietyName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="Label3" runat="server" Text="Society Code:" Font-Bold></asp:Label>&nbsp;
                            <asp:Label ID="lblSocietyCode" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label6" runat="server" Text="Recipt Number:" Font-Bold></asp:Label>&nbsp;
                          <asp:Label ID="lblRecipt" runat="server" ></asp:Label>
                        </td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label7" runat="server" Text="Committee Member Name:" Font-Bold></asp:Label>&nbsp;
                            <asp:Label ID="lblCommitteeMName" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="Label8" runat="server" Text="Committee Member Code:" Font-Bold></asp:Label>&nbsp;
                            <asp:Label ID="lblCommitteeCode" runat="server" ></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style4"></td>
                        <td class="auto-style5"></td>
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label9" runat="server" Text="Block No.:" Font-Bold></asp:Label> &nbsp;
                            <asp:Label ID="lblBlock" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="Label10" runat="server" Text="Member Name:" Font-Bold></asp:Label>&nbsp;
                            <asp:Label ID="lblMemberName" runat="server" ></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr style="background-color:azure">
                        <td colspan="3">
                            <asp:Label ID="Label11" runat="server" Text="Month:" Font-Bold></asp:Label>&nbsp;
                             <asp:Label ID="lblMonth" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="background-color:azure">
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr style="background-color:azure">
                        <td colspan="3">
                            <asp:Label ID="Label5" runat="server" Font-Bold="" Text="Filled Date: "></asp:Label>
                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="background-color:azure">
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr style="background-color:azure">
                        <td colspan="3">
                            <asp:Label ID="Label12" runat="server" Text="Amount:" Font-Bold></asp:Label>&nbsp;
                            <asp:Label ID="lblAmount" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Button ID="Button2" runat="server" Text="Download" OnClick="Button2_Click" />
            <br />
      
        </div>
    </form>
      
</body>
</html>
