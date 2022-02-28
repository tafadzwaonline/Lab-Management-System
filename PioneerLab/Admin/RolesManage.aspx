<%@ Page Title="Roles" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RolesManage.aspx.cs" Inherits="PioneerLab.Admin.RolesManage" %>

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
            <li class="active" id="menulink">Roles Manage</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Roles Manage
			
        </h1>
    </div>
    <!-- /.page-header -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">



    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton AutoPostBack="false" ID="Button1" Text="Add New" CssClass="btn btn-primary" runat="server">
                <ClientSideEvents Init="function (s, e) {s.GetTextContainer().className += 'glyphicon glyphicon-plus';}" Click="function (s, e) { gridroles.AddNewRow();}" />
            </dx:ASPxButton>

        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView ID="GdvRoles" runat="server" ClientInstanceName="gridroles"
            AutoGenerateColumns="False" KeyFieldName="RoleID" DataSourceID="RolesDS" Width="100%" OnRowDeleting="GdvRoles_RowDeleting" OnRowInserting="GdvRoles_RowInserting" OnRowUpdating="GdvRoles_RowUpdating" OnCustomErrorText="GdvRoles_CustomErrorText">
            <Columns>
                <dx:GridViewDataTextColumn Name="Code" Caption="Code" FieldName="Code" VisibleIndex="1" Width="80">
                    <PropertiesTextEdit>
                        <ValidationSettings ValidateOnLeave="true" Display="Dynamic" ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Name="RoleEName" Caption="English Name" FieldName="RoleEName" VisibleIndex="2" Width="200">
                    <PropertiesTextEdit>
                        <ValidationSettings ValidateOnLeave="true" Display="Dynamic" ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Enter English Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Name="RoleAName" Caption="Arabic Name" FieldName="RoleAName" VisibleIndex="3" Width="200">
                    <PropertiesTextEdit>
                        <ValidationSettings ValidateOnLeave="true" Display="Dynamic" ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Enter Arabic Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="UserType" Caption="User Type" VisibleIndex="4" Width="100">
                    <PropertiesComboBox>
                        <Items>
                            <dx:ListEditItem Text="Admin" Value="1" />
                            <dx:ListEditItem Text="Normal" Value="2" />
                        </Items>
                        <ValidationSettings ValidateOnLeave="true" Display="Dynamic" ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Width="250" PropertiesComboBox-ValueField="CategoryMasterID" PropertiesComboBox-DataSourceID="CategoryMasterDS" PropertiesComboBox-TextFormatString="{0} - {1}" Name="CategoryMasterID" Caption="Category Master" FieldName="FKModuleID" VisibleIndex="5">
                    <PropertiesComboBox>
                        <Columns>
                            <dx:ListBoxColumn Name="CategoryMasterNameAr" Caption="Category Master Arabic Name" FieldName="CategoryMasterNameAr" />
                            <dx:ListBoxColumn Name="CategoryMasterNameEn" Caption="Category Master English Name" FieldName="CategoryMasterNameEn" />

                        </Columns>
                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Select Category" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn Name="Notes" Caption="Notes" FieldName="Notes" VisibleIndex="6" Width="200">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Image" Width="60" ShowEditButton="true" ShowDeleteButton="true"/>
            </Columns>

            <ClientSideEvents EndCallback="function(s, e) {if(s.cpDeleteError != ''){lblError.SetText(s.cpDeleteError);}else{lblError.SetText('');}}" />
            <SettingsEditing Mode="Inline" NewItemRowPosition="Top" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
            <SettingsPager PageSize="10" AlwaysShowPager="false"></SettingsPager>
            <Styles>

                <AlternatingRow Enabled="True">
                </AlternatingRow>
            </Styles>
            <SettingsCommandButton>
                <EditButton>
                    <Image Url="../images/grd_edit.png">
                    </Image>
                </EditButton>
                <DeleteButton>
                    <Image Url="../images/grd_Delete.png">
                    </Image>
                </DeleteButton>
                <CancelButton>
                    <Image Url="../images/grd_clear.png">
                    </Image>
                </CancelButton>
                <UpdateButton>
                    <Image Url="../images/save.png">
                    </Image>
                </UpdateButton>
            </SettingsCommandButton>
        </dx:ASPxGridView>
        <asp:ObjectDataSource runat="server" ID="RolesDS" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLayer.Admin.RolesDB"></asp:ObjectDataSource>
        <asp:ObjectDataSource runat="server" ID="CategoryMasterDS" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLayer.Admin.CategoryMasterDB"></asp:ObjectDataSource>
</div>
</asp:Content>
