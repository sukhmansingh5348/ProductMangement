<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProductMangement.Login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="~/LoginTemplate/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/css/util.css">
    <link rel="stylesheet" type="text/css" href="~/LoginTemplate/css/main.css">
    <!--===============================================================================================-->

</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-l-85 p-r-85 p-t-55 p-b-55">
                <form class="login100-form validate-form flex-sb flex-w"  runat="server">
                    <span class="login100-form-title p-b-32">Account Login
                    </span>

                    <span class="txt1 p-b-11">Username
                    </span>
                    <div class="wrap-input100 validate-input m-b-36" data-validate="Username is required">
                        <asp:TextBox ID="Username" class="input100" runat="server" placeholder="User Name"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Password
                    </span>
                    <div class="wrap-input100 validate-input m-b-12" data-validate="Password is required">
                        <span class="btn-show-pass">
                            <i class="fa fa-eye"></i>
                        </span>
                        <asp:TextBox ID="password" class="input100" runat="server" placeholder="Password" TextMode="password"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="container-login100-form-btn">
                        <asp:Button ID="loginBtn" runat="server" class="login100-form-btn" Text="Login" OnClick="loginBtn_Click" />
                    </div>
                    <div class="clearfix">
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>


    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="~/LoginTemplate/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/LoginTemplate/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/LoginTemplate/vendor/bootstrap/js/popper.js"></script>
    <script src="~/LoginTemplate/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/LoginTemplate/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/LoginTemplate/vendor/daterangepicker/moment.min.js"></script>
    <script src="~/LoginTemplate/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="~/LoginTemplate/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="~/LoginTemplate/js/main.js"></script>
</body>
</html>
