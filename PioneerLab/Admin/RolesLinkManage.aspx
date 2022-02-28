<%@ Page Title="RoleLinks" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RolesLinkManage.aspx.cs" Inherits="PioneerLab.Admin.RolesLinkManage" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Content/JS/Common.js" lang="javascript" type="text/javascript"></script>
    <script src="../Content/JS/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Content/JS/jquery.min.js"></script>
    <script src="../Content/JS/jquery.tinyscrollbar.min.js"></script>
    <style type="text/css">
        input[type="checkbox"] {
            width: 30px;
        }
    </style>
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
            <%--          <li><a id="menu2" href="#">General</a></li>--%>
            <li class="active" id="menulink">Role Link Data</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Role Link Data
			
        </h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div style="width: 100%; overflow: auto">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td height="15"></td>
            </tr>
            <tr>
                <td height="30">
                    <table cellpadding="0" cellspacing="0" height="30">
                        <tr>
                            <td>
                                <div style="margin: 0 10px 0 0; width: 100px">
                                    <%--<dx:ASPxButton ID="BtnSave" runat="server" Border-BorderWidth="0" RenderMode="Link" OnClick="BtnSave_Click"
                                Text="<%$ Resources:GlobalResource, BtnSave %>" CssClass="Button-img" EnableTheming="False">
                                <Image Url="../images/save.png" UrlPressed="../images/save-over.png" UrlHottracked="../images/save-over.png" />
                            </dx:ASPxButton>--%>
                                    <dx:ASPxButton ID="btnSave" CausesValidation="true" CssClass="btn btn-primary" Style="width: 80px" runat="server" OnClick="BtnSave_Click" Text="Save"></dx:ASPxButton>
                                </div>
                            </td>
                            <td>
                                <div style="margin: 0 10px; width: 100px">
                                    <%--<dx:ASPxButton ID="BtnPageCancel" runat="server" Border-BorderWidth="0" RenderMode="Link" OnClick="BtnPageCancel_Click"
                                Text="<%$ Resources:GlobalResource, BtnCancel %>" CssClass="Button-img" EnableTheming="False" CausesValidation="false" HorizontalAlign="Center">
                                <Image Url="../images/grd_Delete.png" />
                            </dx:ASPxButton>--%>
                                    <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" Style="width: 80px" CssClass="btn btn-default" OnClick="BtnPageCancel_Click" Text="Close"></dx:ASPxButton>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="15"></td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <%--<tr>
                        <td height="15">
                            <dx:ASPxLabel ID="LblPageTitle" runat="server" Text="Users" meta:resourcekey="LblPageTitle" CssClass="Title" EnableTheming="false" RenderMode="Link"></dx:ASPxLabel>
                        </td>
                    </tr>--%>
                        <tr>
                            <td style="height: 15px" class="Alert">
                                <div runat="server" id="Error" visible="false" class="alert alert-block alert-success" style="width: 800px;">
                                    <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
                                    <button type="button" class="close" data-dismiss="alert">
                                        <i class="ace-icon fa fa-times"></i>
                                    </button>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lable" style="width: 70px;">Modules 
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlModule" runat="server" Width="250" Height="25px" DataTextField="CategoryMasterNameEn"
                                                            DataValueField="CategoryMasterID" CssClass="Drop-Down"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px" colspan="3"></td>
                                                </tr>
                                                <tr>
                                                    <td class="lable" style="width: 70px;">Roles 
                                                    </td>
                                                    <td style="width: 170px;">
                                                        <asp:DropDownList ID="ddlRoles" Height="25px" runat="server" Width="250" DataTextField="RoleEName" AutoPostBack="true"
                                                            DataValueField="RoleID" CssClass="Drop-Down" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px" colspan="3"></td>
                                                </tr>
                                                <tr>
                                                    <td class="lable" style="width: 70px;">Category 
                                                    </td>
                                                    <td style="width: 170px;">
                                                        <asp:DropDownList ID="ddlLinkCategory" Height="25px" runat="server" Width="250" AutoPostBack="true"
                                                            DataTextField="LinkCategoryEName" DataValueField="LinkCategoryID"
                                                            OnSelectedIndexChanged="ddlLinkCategory_SelectedIndexChanged" CssClass="Drop-Down">
                                                        </asp:DropDownList>

                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 15px"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="850" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <asp:GridView ID="GrdLinks" runat="server" AutoGenerateColumns="False" CssClass="grid-view" Width="98%" OnRowDataBound="GrdLinks_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="LinksId" InsertVisible="False" SortExpression="LinksId"
                                                                    Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("LinksId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Link Name" SortExpression="LinksEName" ControlStyle-Width="220px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="TxtLinkName" Height="25px" runat="server" Text='<%# Bind("LinksEName") %>' CssClass="textbox"
                                                                            Width="500" Font-Size="Small"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Order" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40" ControlStyle-Width="30px" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlOrder" runat="server" CssClass="text-box">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="50" ItemStyle-Width="50" ControlStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelectRow" runat="server" Text="All" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="50px" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Add" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40">
                                                                    <HeaderTemplate>
                                                                        <span style="text-align: center;">Add</span>
                                                                        <asp:CheckBox ID="chkAllAdd" runat="server" Style="text-align: left" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkAdd" runat="server" Checked="false" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40">
                                                                    <HeaderTemplate>
                                                                        <span style="text-align: center;">Edit</span>
                                                                        <asp:CheckBox ID="chkAllEdit" runat="server" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkEdit" runat="server" Checked="false" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50">
                                                                    <HeaderTemplate>
                                                                        <span style="text-align: center;">Delete</span><asp:CheckBox ID="chkAllDelete" runat="server" onclick="SelectAll('<%= cbSelectAllDelete.CLientID %>','5')" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkDelete" runat="server" Checked="false" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="View">
                                                                    <HeaderTemplate>
                                                                        <span style="text-align: center;">View</span><asp:CheckBox ID="chkAllView" runat="server" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkView" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <EmptyDataTemplate>
                                                                No Links Exist
                                                            </EmptyDataTemplate>
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle CssClass="header" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#EFF3FB" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                        </asp:GridView>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" height="50" colspan="2"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>

                                <asp:ObjectDataSource ID="UsersDS" runat="server" SelectMethod="GetAll"
                                    TypeName="BusinessLayer.Admin.UsersDB" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
