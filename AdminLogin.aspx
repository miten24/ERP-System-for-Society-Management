<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="SocietyManagment.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Admin Login</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div>
          <div class="login-box">
  <div class="login-logo">
    <a href="#" style="color:black"><b style="font-weight:600">All In One</b> Society</a>
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg">Sign in to Admin session</p>

        </div>
        <div class="input-group mb-3">
          <asp:TextBox ID="txtAUser" runat="server" type="text" class="form-control" placeholder="Username"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <asp:TextBox ID="txtAPass" runat="server" type="password" class="form-control" placeholder="Password" ></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
         <div class="col-8">
          </div>
          <!-- /.col -->
          <div class="col-4">
            <asp:Button ID="btnASignin" runat="server" type="submit" Text="Sign In" class="btn btn-primary btn-block" OnClick="btnASignin_Click"/>
          </div>
          <!-- /.col -->
        </div>

      <p class="mb-0">
        <a href="login.aspx" class="text-center">Are you a member?</a>
          <asp:DropDownList ID="DropDownList1" runat="server">
          </asp:DropDownList>
      </p>
    </form>
    </div>
    <!-- /.login-card-body -->
  </div>
</div>

            <!-- jQuery -->
            <script src="../../plugins/jquery/jquery.min.js"></script>
            <!-- Bootstrap 4 -->
            <script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
            <!-- AdminLTE App -->
            <script src="../../dist/js/adminlte.min.js"></script>
        </div>
    </form>
</body>
</html>
