<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_RemoveSociety.aspx.cs" Inherits="SocietyManagment.Admin_RemoveSociety" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Admin| Remove Society</title>
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
                  <a href="Admin_panel.aspx" class="nav-link">Home</a>
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
                <img src="dist/img/AdminLTELogo.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3"
                     style="opacity: .8">
                <span class="brand-text font-weight-light">Admin Panel</span>
              </a>

              <!-- Sidebar -->
              <div class="sidebar">
                <!-- Sidebar user panel (optional) -->
                <div class="user-panel mt-3 pb-3 mb-3 d-flex">
                  
                  <div class="info">
                    <a href="#" class="d-block">
                      <asp:Label ID="lblAdminName" runat="server"></asp:Label></a>
                  </div>
                </div>

                <!-- Sidebar Menu -->
                <nav class="mt-2">
                  <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                    <!-- Add icons to the links using the .nav-icon class
                         with font-awesome or any other icon font library -->
                    <li class="nav-item">
                      <a href="Admin_panel.aspx" class="nav-link">
                        <i class="nav-icon fas fa-tachometer-alt"></i>
                        <p>
                          Dashboard
                        </p>
                      </a>
                    </li>
                    <li class="nav-item">
                      <a href="Admin_AddSociety.aspx" class="nav-link">
                        <i class="nav-icon fas fa-building"></i>
                        <p>Add Society</p>
                      </a>
                    </li>
                      <li class="nav-item">
                    <a href="Admin_RemoveSociety.aspx" class="nav-link active">
                      <i class="nav-icon fas fa-trash"></i>
                      <p>Remove Society</p>
                    </a>
                  </li>
                    <li class="nav-item">
                    <a href="Admin_UpdateSocietyInfo.aspx" class="nav-link">
                      <i class="nav-icon fas fa-book"></i>
                      <p>Update Society Info</p>
                    </a>
                  </li>
                     <li class="nav-item">
                    <a href="Admin_AddCM.aspx" class="nav-link">
                      <i class="nav-icon fas fa-user-plus"></i>
                      <p>Add Committee Member</p>
                    </a>
                  </li>
                    <li class="nav-item">
                    <a href="Admin_Remove_Committee_Member.aspx" class="nav-link">
                      <i class="nav-icon fas fa-user-minus"></i>
                      <p>Remove Committee Member</p>
                    </a>
                  </li>
                 
                    <div class="user-panel mt-3 pb-3 mb-3 d-flex"></div>
                    <li class="nav-item">
                      <asp:LinkButton ID="ALogout" runat="server" class="nav-link" onClick="ALogout_Click">
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
                    <h1>Remove Society</h1>
                  </div>
                  <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                      <li class="breadcrumb-item"><a href="Admin_panel.aspx">Home</a></li>
                      <li class="breadcrumb-item active">Remove Society</li>
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
                                <h3 class="card-title">Remove Society</h3>
                              </div>
                              <!-- /.card-header -->
                              <!-- form start -->
                              <form role="form">
                                <div class="card-body">
                                  <div class="form-group">
                                    <div class="row">
                                      <div class="col-md-6">
                                          <label>Society Code</label>
                                          <asp:DropDownList ID="dlRScode" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="dlRScode_SelectedIndexChanged" ></asp:DropDownList>
                                       </div>
                                       <div class="col-md-6">
                                        <label>Society Name</label>
                                         <asp:TextBox ID="txtRSName" runat="server" class="form-control" placeholder="Enter Society Name" TextMode="SingleLine" required></asp:TextBox>
                                       </div>
                                     </div>
                                    </div>
                                  <div class="form-group">
                                    <div class="row">
                                       <div class="col-md-12">
                                        <label>Admin Password</label>
                                         <asp:TextBox ID="txtRSAdminPass" runat="server" class="form-control" placeholder="Enter Admin Password" TextMode="Password" required></asp:TextBox>
                                       </div>
                                     </div>
                                    </div>
                                   
                                  <div class="form-group">
                                    <div class="row">
                                       <div class="col-sm-6">
                                          <div class="form-group">
                                            <label>Are you sure?</label><br />
                                            <asp:RadioButton ID="rbRSYes" runat="server" GroupName="Confirm"  /> yes
                                            &nbsp;
                                            <asp:RadioButton ID="rbRSNo" runat="server" GroupName="Confirm" Checked="True" /> No
                                          </div>
                                     </div>
                                     </div>
                                    </div>
                                  <div class="form-group">
                                    <div class="row">
                                       <div class="col-md-12">
                                        <asp:Label ID="Label1" runat="server" Text="Once You delete the Society it will permenetly delete all the data along with details of Committee members and Society members." ForeColor="Green"></asp:Label>
                                       </div>
                                     </div>
                                    </div>
                                  
                                </div>
                                <!-- /.card-body -->
                               <div class="card-footer">
                                   <asp:Button ID="btnRSRemove" runat="server" class="btn btn-danger" Text="Remove" OnClick="btnRSRemove_Click" />
                                   <asp:Label ID="lblRSflag" runat="server" ForeColor="Red"></asp:Label>
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

