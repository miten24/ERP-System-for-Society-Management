<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member_CommitteeList.aspx.cs" Inherits="SocietyManagment.Member_CommitteeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Member| Committee Member List</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Tempusdominus Bbootstrap 4 -->
  <link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- JQVMap -->
  <link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/adminlte.min.css">
  <!-- overlayScrollbars -->
  <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css">
  <!-- Daterange picker -->
  <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css">
  <!-- summernote -->
  <link rel="stylesheet" href="plugins/summernote/summernote-bs4.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">

</head>
<body class="hold-transition sidebar-mini layout-fixed">
    <form id="form1" runat="server">
        <div>
          <div class="wrapper">
            <!-- Navbar -->
            <nav class="main-header navbar navbar-expand navbar-white navbar-light">
              <!-- Left navbar links -->
              <ul class="navbar-nav">
                <li class="nav-item">
                  <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
                </li>
                <li class="nav-item d-none d-sm-inline-block">
                  <a href="Member_Panel.aspx" class="nav-link">Home</a>
                </li>
                <li class="nav-item d-none d-sm-inline-block">
                  <a href="#" class="nav-link">Contact</a>
                </li>
              </ul>

        
            </nav>
            <!-- /.navbar -->  

            <!-- Main Sidebar Container -->
            <aside class="main-sidebar sidebar-dark-primary elevation-4">
              <!-- Brand Logo -->
              <a href="#" class="brand-link">
                <img src="dist/img/MemberLogo2.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3"
                     style="opacity: .8">
                <span class="brand-text font-weight-light">Member Panel</span>
              </a>

              <!-- Sidebar -->
              <div class="sidebar">
                <!-- Sidebar user panel (optional) -->
                <div class="user-panel mt-3 pb-3 mb-3 d-flex">
                  <div class="info">
                    <a href="#" class="d-block">
                      <asp:Label ID="lblMPMName" runat="server" Text="Name here"></asp:Label></a>
                  </div>
                </div>

                <!-- Sidebar Menu -->
                <nav class="mt-2">
                  <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                    <!-- Add icons to the links using the .nav-icon class
                         with font-awesome or any other icon font library -->
                    <li class="nav-item">
                      <a href="Member_Panel.aspx" class="nav-link">
                        <i class="nav-icon fas fa-tachometer-alt"></i>
                        <p>
                          Dashboard
                        </p>
                      </a>
                    </li>
                    <li class="nav-item">
                      <a href="Member_Profile.aspx" class="nav-link">
                        <i class="nav-icon fas fa-user-circle"></i>
                        <p>
                          Profile
                        </p>
                      </a>
                    </li>
                    <li class="nav-item">
                      <a href="Member_Societyinfo.aspx" class="nav-link">
                        <i class="nav-icon fas fa-building"></i>
                        <p>
                          Society Info
                        </p>
                      </a>
                    </li>
                     <li class="nav-item">
                      <a href="#" class="nav-link active">
                        <i class="nav-icon fas fa-users"></i>
                        <p>
                          Committee Member List
                        </p>
                      </a>
                    </li>
                    <li class="nav-item">
                      <a href="Member_Society_MemberList.aspx" class="nav-link">
                        <i class="nav-icon fas fa-address-card"></i>
                        <p>
                          Society Member List
                        </p>
                      </a>
                    </li>
                    <li class="nav-item has-treeview">
                      <a href="#" class="nav-link">
                        <i class="nav-icon fas fa-university"></i>
                          <p>Society Account
                          <i class="fas fa-angle-left right"></i>
                        </p>
                      </a>
                       <ul class="nav nav-treeview">
                        <li class="nav-item">
                          <a href="Member_SAccount_Info.aspx" class="nav-link">
                            <i class="far fa-circle nav-icon"></i>
                            <p>Society Account</p>
                          </a>
                        </li>
                      </ul>
                      <ul class="nav nav-treeview">
                        <li class="nav-item">
                          <a href="Member_SAccount_Maintenance.aspx" class="nav-link">
                            <i class="far fa-circle nav-icon"></i>
                            <p>Maintenance</p>
                          </a>
                        </li>
                      </ul>
                      
                    </li>
                      <li class="nav-item has-treeview">
                      <a href="#" class="nav-link">
                        <i class="nav-icon fas fa-car"></i>
                          <p>Parking
                          <i class="fas fa-angle-left right"></i>
                        </p>
                      </a>
                       <ul class="nav nav-treeview">
                        <li class="nav-item">
                          <a href="Member_Vehicle_Info.aspx" class="nav-link">
                            <i class="far fa-circle nav-icon"></i>
                            <p>My Vehicles</p>
                          </a>
                        </li>
                      </ul>
                      <ul class="nav nav-treeview">
                        <li class="nav-item">
                          <a href="Member_Other_Vehicles.aspx" class="nav-link">
                            <i class="far fa-circle nav-icon"></i>
                            <p>Other Vehicles</p>
                          </a>
                        </li>
                      </ul>
                      <ul class="nav nav-treeview">
                        <li class="nav-item">
                          <a href="Member_Add_Vehicle.aspx" class="nav-link">
                            <i class="far fa-circle nav-icon"></i>
                            <p>Add New Vehicles</p>
                          </a>
                        </li>
                      </ul>
                      <ul class="nav nav-treeview">
                        <li class="nav-item">
                          <a href="Member_Update_Remove_Vehicle.aspx" class="nav-link">
                            <i class="far fa-circle nav-icon"></i>
                            <p>Update/Remove Vehicles</p>
                          </a>
                        </li>
                      </ul>
                    </li>
                 
                    <div class="user-panel mt-3 pb-3 mb-3 d-flex"></div>
                    <li class="nav-item">
                      <asp:LinkButton ID="MLogout" runat="server" class="nav-link" onClick="MLogout_Click">
                        <i class="nav-icon fas fa-share"></i>
                          <p>Logout</p>
                      </asp:LinkButton>
                      
                  </li>
                  </ul>
                </nav>
                <!-- /.sidebar-menu -->
              </div>
              <!-- /.sidebar -->
            </aside>
             <!--/ Main Sidebar Container -->
            
            <!-- Content -->
             <div class="content-wrapper">
              <section class="content-header">
              <div class="container-fluid">
                <div class="row mb-2">
                  <div class="col-sm-6">
                    <h1>Committee Member List</h1>
                  </div>
                  <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                      <li class="breadcrumb-item"><a href="Member_Panel.aspx">Home</a></li>
                      <li class="breadcrumb-item active">Committee Members</li>
                    </ol>
                  </div>
                </div>
              </div><!-- /.container-fluid -->
            </section>
          <section class="content">
          <div class="container-fluid">
            <div class="row"> 
              <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" class="table table-bordered table-hover">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="CoCode" HeaderText="Committe Member Code" SortExpression="CoCode" />
                    <asp:BoundField DataField="CRole" HeaderText="Role" SortExpression="CRole" />
                    <asp:BoundField DataField="CommitteeMName" HeaderText="Name" SortExpression="CommitteeMName" />
                    <asp:BoundField DataField="BDate" HeaderText="Birth Date" SortExpression="BDate" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone No." SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
              </asp:GridView>
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [CoCode], [CRole], [CommitteeMName], [BDate], [PhoneNumber], [Email] FROM [CommitteeInfo] WHERE ([SocietyCode] = @SocietyCode)">
                  <SelectParameters>
                      <asp:SessionParameter Name="SocietyCode" SessionField="MSCode" Type="String" />
                  </SelectParameters>
              </asp:SqlDataSource>
              </div>
            </div>
            
        </div>
        </section>
      </div>
            
            <!--/ Content -->

            <!-- footer -->
              <footer class="main-footer">
               Copyright &copy; <strong>2020-2021 </strong>
                  
              <div class="float-right d-none d-sm-inline-block">
                <b><a href="">India</a></b> 
              </div>
            </footer>
            <!-- footer -->


          </div>
              <!-- jQuery -->
              <script src="plugins/jquery/jquery.min.js"></script>
              <!-- jQuery UI 1.11.4 -->
              <script src="plugins/jquery-ui/jquery-ui.min.js"></script>
              <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
              <script>
                $.widget.bridge('uibutton', $.ui.button)
              </script>
              <!-- Bootstrap 4 -->
              <script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
              <!-- ChartJS -->
              <script src="plugins/chart.js/Chart.min.js"></script>
              <!-- Sparkline -->
              <script src="plugins/sparklines/sparkline.js"></script>
              <!-- JQVMap -->
              <script src="plugins/jqvmap/jquery.vmap.min.js"></script>
              <script src="plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
              <!-- jQuery Knob Chart -->
              <script src="plugins/jquery-knob/jquery.knob.min.js"></script>
              <!-- daterangepicker -->
              <script src="plugins/moment/moment.min.js"></script>
              <script src="plugins/daterangepicker/daterangepicker.js"></script>
              <!-- Tempusdominus Bootstrap 4 -->
              <script src="plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
              <!-- Summernote -->
              <script src="plugins/summernote/summernote-bs4.min.js"></script>
              <!-- overlayScrollbars -->
              <script src="plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
              <!-- AdminLTE App -->
              <script src="dist/js/adminlte.js"></script>
              <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
              <script src="dist/js/pages/dashboard.js"></script>
              <!-- AdminLTE for demo purposes -->
              <script src="dist/js/demo.js"></script>
        </div>
    </form>
</body>
</html>
