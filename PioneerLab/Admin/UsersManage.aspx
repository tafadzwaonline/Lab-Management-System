<%@ Page Title="Users Manage" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UsersManage.aspx.cs" Inherits="PioneerLab.Admin.UsersManage" %>

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
            <li class="active" id="menulink">Users Manage</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Users
			
        </h1>
    </div>
    <!-- /.page-header -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton AutoPostBack="true" ID="btnNew" Text="Add New" CssClass="btn btn-primary" runat="server" OnClick="btnNew_Click">
                <ClientSideEvents Init="function (s, e) {s.GetTextContainer().className += 'glyphicon glyphicon-plus';}" />
            </dx:ASPxButton>

        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvUsers" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridusers"
            DataSourceID="UsersDS" KeyFieldName="UserID" OnRowCommand="GdvUsers_RowCommand" OnCustomErrorText="GdvUsers_CustomErrorText">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="2" meta:resourcekey="gdvCode">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EName" Caption="English Name" VisibleIndex="3" meta:resourcekey="gdvNameEn" CellStyle-HorizontalAlign="Left">
                    <CellStyle HorizontalAlign="Left"></CellStyle>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="AName" Caption="Arabic Name" VisibleIndex="4" meta:resourcekey="gdvNameAr" CellStyle-HorizontalAlign="Right">
                    <CellStyle HorizontalAlign="Right"></CellStyle>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Mail" VisibleIndex="5">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsActive" VisibleIndex="6" Width="80">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Image" Width="10" ShowClearFilterButton="True"/>
                <dx:GridViewDataColumn VisibleIndex="8" Name="Command" Visible="true">
                    <DataItemTemplate>
                        <table cellpadding="0" cellspacing="2">
                            <tr>
                                <td>
                                    <dx:ASPxButton ID="BtnEdit" runat="server" RenderMode="Link" EnableTheming="false" meta:resourcekey="BtnEdit"
                                        CommandName="CmdEdit" CommandArgument='<%#Eval("UserID") %>'>
                                        <Image Url="../images/grd_edit.png" ToolTip="<%$ Resources:GlobalResource, BtnEdit %>" AlternateText="<%$ Resources:GlobalResource, BtnEdit %>"></Image>
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="BtnDelete" runat="server" Cursor="pointer"
                                        RenderMode="Link" EnableTheming="false" CommandName="CmdDelete" CommandArgument='<%#Eval("UserID") %>'>
                                        <ClientSideEvents Click="function(s, e) {  e.processOnServer = confirm('Do you want to continue?');}" />
                                        <Image Url="../images/grd_Delete.png" ToolTip="<%$ Resources:GlobalResource, BtnDelete %>" AlternateText="<%$ Resources:GlobalResource, BtnDelete %>"></Image>
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <ClientSideEvents EndCallback="function(s, e) {if(s.cpDeleteError != ''){lblError.SetText(s.cpDeleteError);}else{lblError.SetText('');}}" />
            <Settings ShowFilterRow="True" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" EnableRowHotTrack="True" />
            <SettingsPager Mode="ShowPager" PageSize="10"></SettingsPager>
            <Styles>
                <AlternatingRow Enabled="True">
                </AlternatingRow>
            </Styles>
            <SettingsCommandButton>
                <ClearFilterButton Text="">
                    <Image Url="../images/grd_clear.png" AlternateText="Clear">
                    </Image>
                </ClearFilterButton>
            </SettingsCommandButton>

        </dx:ASPxGridView>
    </div>
    <asp:ObjectDataSource ID="UsersDS" runat="server" SelectMethod="GetUnRemoved"
        TypeName="BusinessLayer.Admin.UsersDB" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
</asp:Content>
