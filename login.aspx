<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="SocietyManagment.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Digital society</title>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
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
  <style>
      #body1{
        background-image:url(sb2.png);
        background-repeat:no-repeat;
        background-size:100% 100%;
        background-attachment:fixed;
        
      }
  </style>
</head>
<body class="hold-transition login-page" id="body1">
    <form id="form1" runat="server">
        <div>
            <div class="login-box">
              <div class="login-logo">
                <a href="#" style="color:black"><b style="font-weight:600">Digital</b> Society</a>
              </div>
              <!-- /.login-logo -->
              <div class="card">
                <div class="card-body login-card-body">
                  <p class="login-box-msg">Sign in to Member Account</p>

                  <form action="#" method="post">
                    <div class="input-group mb-3">
                      <asp:TextBox ID="txtLSCode" runat="server" TextMode="SingleLine" class="form-control" placeholder="SocietyID" required></asp:TextBox>
                      <div class="input-group-append">
                        <div class="input-group-text">
                          <span class="fas fa-building"></span>
                        </div>
                      </div>
                    </div>
                    <div class="input-group mb-3">
                      <asp:TextBox ID="txtLUsername" runat="server"  class="form-control" placeholder="Username" required TextMode="SingleLine"></asp:TextBox>
                      <div class="input-group-append">
                        <div class="input-group-text">
                          <span class="fas fa-envelope"></span>
                        </div>
                      </div>
                    </div>
                    <div class="input-group mb-3">
                      <asp:TextBox ID="txtLPassword" runat="server" TextMode="Password" class="form-control" placeholder="Password" required></asp:TextBox>
                      <div class="input-group-append">
                        <div class="input-group-text">
                          <span class="fas fa-lock"></span>
                        </div>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-8">
                        <div class="icheck-primary">
                          <asp:CheckBox ID="remember" runat="server" />
                          <label for="remember">
                             I'm a Committee Member!
                          </label>
                        </div>
                      </div>
                      <!-- /.col -->
                      <div class="col-4">
                        <asp:Button ID="btnLSignIn" runat="server" Text="Sign In" class="btn btn-primary btn-block" OnClick="btnLSignIn_Click"/>
                      </div>
                      <!-- /.col -->
                    </div>
                  </form>


                  <p class="mb-1">
                    <a href="#">I forgot my password</a>
                  </p>
                  <p class="mb-0">
                    <a href="AdminLogin.aspx" class="text-center">Sign in as a Admin </a>
                  </p>
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
