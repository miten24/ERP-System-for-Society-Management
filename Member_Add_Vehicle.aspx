<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member_Add_Vehicle.aspx.cs" Inherits="SocietyManagment.Member_Add_Vehicle" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Member| Add Vehicle </title>
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
                      <a href="Member_CommitteeList.aspx" class="nav-link">
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
                          <a href="Member_Vehicle_Info.aspx" class="nav-link ">
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
                          <a href="#" class="nav-link active">
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
                    <h1>Add New Vehicle</h1>
                  </div>
                  <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                      <li class="breadcrumb-item"><a href="Member_Panel.aspx">Home</a></li>
                      <li class="breadcrumb-item active">Parking</li>
                      <li class="breadcrumb-item active">Add Vehicle</li>
                    </ol>
                  </div>
                </div>
              </div><!-- /.container-fluid -->
            </section>
               <section class="content">
                <div class="container-fluid">
                        <div class="row">
                          <!-- left column -->
                          <div class="col-md-12">
                            <!-- general form elements -->
                            <div class="card card-primary">
                              <div class="card-header">
                                <h3 class="card-title">Enter Vehicle Details</h3>
                              </div>
                              <form role="form">
                                <div class="card-body">
                                  <div class="form-group">
                                    <div class="row">
                                      <div class="col-md-6">
                                          <label>Society Code</label>
                                          <asp:TextBox ID="txtCPAVSCode"  runat="server" class="form-control" placeholder="Assign Society Code" TextMode="SingleLine" required ReadOnly="True"></asp:TextBox>
                                       </div>
                                       <div class="col-md-6">
                                        <label>Society Name</label>
                                         <asp:TextBox ID="txtCPAVSName" runat="server" class="form-control" placeholder="Enter Society Name" TextMode="SingleLine" required ReadOnly="True"></asp:TextBox>
                                       </div>
                                     </div>
                                    </div>
                                   <div class="form-group">
                                    <div class="row">
                                      <div class="col-md-6">
                                          <label>Username</label>
                                          <asp:TextBox ID="txtCPAVUsername"  runat="server" class="form-control" placeholder="Enter the Username" TextMode="SingleLine" required ReadOnly="true"></asp:TextBox>
                                       </div>
                                      <div class="col-md-6">
                                          <label>Name</label>
                                          <asp:TextBox ID="txtCPAVName"  runat="server" class="form-control" placeholder="Enter the name" TextMode="SingleLine" required ReadOnly="true"></asp:TextBox>
                                       </div>
                                      
                                     </div>
                                    </div>
                                  <div class="form-group">
                                    <div class="row">
                                       <div class="col-md-6">
                                        <label>Select the Type of Vehicle</label>
                                         <asp:DropDownList ID="dlCPAVType" runat="server" class="form-control" required>
                                             <asp:ListItem>Select the Type of Vehicle</asp:ListItem>
                                             <asp:ListItem>2-Wheels</asp:ListItem>
                                             <asp:ListItem>4-Wheels</asp:ListItem>
                                           </asp:DropDownList>
                                          
                                       </div>
                                      <div class="col-md-6">
                                          <label>Vehicle Number</label>
                                          <asp:TextBox ID="txtCPAVNumber"  runat="server" class="form-control" placeholder="Enter the Number of Vehicle" TextMode="SingleLine" required></asp:TextBox>
                                       </div>
                                     </div>
                                    </div>
                                  <div class="form-group">
                                    <div class="row">
                                      
                                       <div class="col-md-12">
                                        <label>Model of Vehicle</label>
                                         <asp:TextBox ID="txtCPAVModel"  runat="server" class="form-control" placeholder="Enter the Number of Vehicle" TextMode="SingleLine" required></asp:TextBox>
                                       </div>
                                     </div>
                                    </div>
                                  
                                </div>
                                <!-- /.card-body -->

                               <div class="card-footer">
                                   <asp:Button ID="btnCPAVAdd" runat="server" class="btn btn-primary" Text="Add Vehicle" OnClick="btnCAddMember_Click" />
                                   <asp:Label ID="lblCPAVFlag" runat="server"  ForeColor="Red"></asp:Label>
                                </div>
                              </form>
                            </div>
                            <!-- /.card -->
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
