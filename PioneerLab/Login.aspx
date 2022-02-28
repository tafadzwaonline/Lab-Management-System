<%@ Page Language="C#" AutoEventWireup="true" Inherits="Login" CodeBehind="Login.aspx.cs" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta charset="utf-8" />
    <title>Login Page - Lab System Management</title>

    <meta name="description" content="User login page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

    <!-- bootstrap & fontawesome -->
    <link rel="stylesheet" href="../Content/assets/css/bootstrap.css" />
    <link rel="stylesheet" href="../Content/assets/css/font-awesome.css" />

    <!-- text fonts -->
    <link rel="stylesheet" href="../Content/assets/css/ace-fonts.css" />

    <!-- ace styles -->
    <link rel="stylesheet" href="../Content/assets/css/ace.css" />

    <!--[if lte IE 9]>
			<link rel="stylesheet" href="Content/assets/css/ace-part2.css" />
		<![endif]-->
    <link rel="stylesheet" href="../Content/assets/css/ace-rtl.css" />

    <!--[if lte IE 9]>
		  <link rel="stylesheet" href="../Content/assets/css/ace-ie.css" />
		<![endif]-->

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="../Content/assets/js/html5shiv.js"></script>
		<script src="../Content/assets/js/respond.js"></script>
		<![endif]-->
    <style type="text/css">
        .Space label {
            margin-left: 20px;
        }
    </style>
</head>

<body class="login-layout light-login">
    <form id="loginFrom" runat="server" method="post">
        <div class="main-container">
            <div class="main-content">
                <div class="row">
                    <div class="col-sm-10 col-sm-offset-1">
                        <div class="login-container">
                            <div class="center">
                                <h1>
                                    <i class="">
                                    
                                </h1>
                                <h4 class="blue" id="id-company-text">&copy; Owned by Kahwai laboratory</h4>
                            </div>

                            <div class="space-6"></div>

                            <div class="position-relative">
                                <div id="login-box" class="login-box visible widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header blue lighter bigger">
                                                <i class="ace-icon fa fa-user green"></i>
                                                Please Enter Your Information
                                            </h4>

                                            <div class="space-6"></div>

                                            <form>
                                                <fieldset>
                                                    <label class="block clearfix" >
                                                        <span class="lbl"></span>
                                                        <span class="block input-icon input-icon-right" >

                                                            <asp:RadioButtonList CssClass="Space" ID="ddlUserType" runat="server" RepeatDirection="Horizontal" Visible="false" >

                                                                <asp:ListItem Text="Admin" Value="1" Selected="True">
                                                                </asp:ListItem>
                                                                <asp:ListItem Text="Teacher" Value="2">
                                                                </asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <%--<asp:DropDownList CssClass="form-control" ID="ddlUserType" runat="server"
                                                                ForeColor="Black">
                                                                <asp:ListItem Text="Teacher" Value="2" Selected="True">
                                                                </asp:ListItem>
                                                                <asp:ListItem Text="Admin" Value="1">
                                                                </asp:ListItem>

                                                                <asp:ListItem Text="Student" Value="3">
                                                                </asp:ListItem>
                                                            </asp:DropDownList>--%>
                                                        </span>
                                                    </label>
                                                    <label class="block clearfix">
                                                        <span class="lbl">User Name</span>
                                                        <span class="block input-icon input-icon-right">
                                                            <input runat="server" id="txtUser" type="text" class="form-control" placeholder="Username" />
                                                            <i class="ace-icon fa fa-user"></i>
                                                        </span>
                                                    </label>

                                                    <label class="block clearfix">
                                                        <span class="lbl">Password</span>
                                                        <span class="block input-icon input-icon-right">
                                                            <input runat="server" id="txtPass" type="password" class="form-control" placeholder="Password" />
                                                            <i class="ace-icon fa fa-lock"></i>
                                                        </span>
                                                    </label>
                                                    <label class="block clearfix">
                                                        <span class="lbl">Database</span>
                                                        <span class="block input-icon input-icon-right">
                                                            <%--  <dx:ASPxComboBox ID="cmbYears" Width="301" Height="34" ClientInstanceName="cmbyears" placeholder="Username"  CssClass="form-control" DataSourceID="DatabasesDS"
                                                                runat="server" AutoGenerateColumns="False"
                                                                IncrementalFilteringMode="Contains" ValueType="System.Int32" ValueField="AcademicYearId" SelectedIndex="0">
                                                                <Columns>
                                                                    <dx:ListBoxColumn FieldName="AcademicYearDesc" Caption="" Name="" />
                                                                </Columns>
                                                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="true" ErrorText="Select Academic Year" />
                                                                </ValidationSettings>
                                                            </dx:ASPxComboBox>--%>
                                                            <asp:DropDownList CssClass="form-control" ID="ddlDatabases" runat="server"
                                                                DataTextField="DatabaseDescription" DataValueField="DatabaseId" ForeColor="Black" OnSelectedIndexChanged="ddlDatabases_SelectedIndexChanged" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <i class="ace-icon"></i>
                                                        </span>
                                                    </label>

                                                    <div class="space"></div>

                                                    <div class="clearfix">

                                                        <span class="lbl">
                                                            <asp:Label ID="lblerror" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                        </span>
                                                        <button runat="server" id="loginButton" onserverclick="loginButton_ServerClick" type="submit"
                                                            class="width-35 pull-right btn btn-sm btn-primary">
                                                            <i class="ace-icon fa fa-key"></i>
                                                            <span class="bigger-110">Login</span>
                                                        </button>

                                                        <%--  <dx:ASPxButton runat="server" ID="btnLLogin" Text="Login" OnClick="loginButton_ServerClick"
                                                            CssClass="width-35 pull-right btn btn-sm btn-primary" ValidationGroup="savegrp" Height="35">
                                                            <ClientSideEvents Init="function (s, e) {s.GetTextContainer().className += 'ace-icon fa fa-key';}" />
                                                        </dx:ASPxButton>--%>
                                                    </div>
                                        </div>

                                        <%--<div class="clearfix">
                                                        <label class="inline">
                                                            <input type="checkbox" class="ace" />
                                                            <span class="lbl">Remember Me</span>
                                                        </label>

                                                        <asp:Button runat="server" ID="Button1" OnClick="loginButton_ServerClick" Text="Login" CssClass="width-35 pull-right btn btn-sm btn-primary"></asp:Button>
                                                    </div>--%>

                                        <div class="space-4"></div>
                                        </fieldset>
    </form>

    <%--<div class="social-or-login center">
												<span class="bigger-110">Or Login Using</span>
											</div>

											<div class="space-6"></div>

											<div class="social-login center">
												<a class="btn btn-primary">
													<i class="ace-icon fa fa-facebook"></i>
												</a>

												<a class="btn btn-info">
													<i class="ace-icon fa fa-twitter"></i>
												</a>

												<a class="btn btn-danger">
													<i class="ace-icon fa fa-google-plus"></i>
												</a>
											</div>--%>
                                    </div>
                                <!-- /.widget-main -->

                                <div class="toolbar clearfix">
                                </div>
                            </div>
                            <!-- /.widget-body -->
                        </div>
                        <!-- /.login-box -->

                    </div>
                    <!-- /.position-relative -->

                    <%--<div class="navbar-fixed-top align-right">
								<br />
								&nbsp;
								<a id="btn-login-dark" href="#">Dark</a>
								&nbsp;
								<span class="blue">/</span>
								&nbsp;
								<a id="btn-login-blur" href="#">Blur</a>
								&nbsp;
								<span class="blue">/</span>
								&nbsp;
								<a id="btn-login-light" href="#">Light</a>
								&nbsp; &nbsp; &nbsp;
							</div>--%>
                </div>
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
        </div>
        <!-- /.main-content -->
        </div>
        <!-- /.main-container -->

        <!-- basic scripts -->

        <!--[if !IE]> -->
        <script type="text/javascript">
            window.jQuery || document.write("<script src='../Content/assets/js/jquery.js'>" + "<" + "/script>");
        </script>

        <!-- <![endif]-->

        <!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='../Content/assets/js/jquery1x.js'>"+"<"+"/script>");
</script>
<![endif]-->
        <script type="text/javascript">
            if ('ontouchstart' in document.documentElement) document.write("<script src='../Content/assets/js/jquery.mobile.custom.js'>" + "<" + "/script>");
        </script>

        <!-- inline scripts related to this page -->
        <script type="text/javascript">
            jQuery(function ($) {
                $(document).on('click', '.toolbar a[data-target]', function (e) {
                    e.preventDefault();
                    var target = $(this).data('target');
                    $('.widget-box.visible').removeClass('visible');//hide others
                    $(target).addClass('visible');//show target
                });
            });



            //you don't need this, just used for changing background
            jQuery(function ($) {
                $('#btn-login-dark').on('click', function (e) {
                    $('body').attr('class', 'login-layout');
                    $('#id-text2').attr('class', 'white');
                    $('#id-company-text').attr('class', 'blue');

                    e.preventDefault();
                });
                $('#btn-login-light').on('click', function (e) {
                    $('body').attr('class', 'login-layout light-login');
                    $('#id-text2').attr('class', 'grey');
                    $('#id-company-text').attr('class', 'blue');

                    e.preventDefault();
                });
                $('#btn-login-blur').on('click', function (e) {
                    $('body').attr('class', 'login-layout blur-login');
                    $('#id-text2').attr('class', 'white');
                    $('#id-company-text').attr('class', 'light-blue');

                    e.preventDefault();
                });

            });
        </script>
        <asp:ObjectDataSource runat="server" ID="DatabasesDS" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLayer.Admin.DatabasesDB"></asp:ObjectDataSource>


    </form>
</body>
</html>
