<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="CustomerEnquiryManage.aspx.cs" Inherits="PioneerLab.Pages.CustomerEnquiryManage" %>

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
            <li><a id="menu1" href="#">Transaction</a></li>
            <li class="active" id="menulink">Customer Enquiry</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Customer Enquiry</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
     
<div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Enquiry" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvCustomerEnquiry"  AutoGenerateColumns="false" Width="100%" OnCustomErrorText="GdvCustomerEnquiry_CustomErrorText" ClientInstanceName="gridCustomerEnquiry"
            DataSourceID="EnquiryMasterDS" KeyFieldName="EnquiryMasterID" OnCellEditorInitialize="GdvCustomerEnquiry_CellEditorInitialize" OnCustomButtonInitialize="GdvCustomerEnquiry_CustomButtonInitialize" OnCommandButtonInitialize="GdvCustomerEnquiry_CommandButtonInitialize">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="EnquiryCode" Caption="Enquiry No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="Entry Date" Width="400" VisibleIndex="2"    CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit  DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                    </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <%--<dx:GridViewDataCheckColumn FieldName="IsClosed" Caption="Inactive" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>--%>

                <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnNewVersion" Text=" " Image-ToolTip="" >
                         <Image Url="../images/Copy2.png" Width="16" Height="16" ToolTip="Copy" AlternateText="<%$ Resources:GlobalResource, BtnEdit %>"></Image>

                            <%--<Styles><Style Font-Size="Medium" CssClass="fa fa-copy" ></Style></Styles>--%>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <SettingsPager PageSize="20"></SettingsPager>

            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
             <ClientSideEvents  CustomButtonClick ="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.location =('CustomerEnquiry.aspx?cid=' + key);}" />
        </dx:ASPxGridView>
    </div>
    <asp:ObjectDataSource ID="EnquiryMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EnquiryMasterDB"
        DataObjectTypeName="BusinessLayer.EnquiryMaster" SelectMethod="GetAll" DeleteMethod="Delete"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>
</asp:Content>
