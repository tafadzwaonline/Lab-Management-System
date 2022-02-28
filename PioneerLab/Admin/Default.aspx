<%@ Page Title="Links Manage" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PioneerLab.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagePath" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>

            <li><a id="menu1" href="#">Setup</a></li>
            <%--<li><a id="menu2" href="#">General</a></li>--%>
            <li class="active" id="menulink">Admin</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Users</h1>
    </div>
    <!-- /.page-header -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">

</asp:Content>
