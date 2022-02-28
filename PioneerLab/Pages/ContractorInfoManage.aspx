<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ContractorInfoManage.aspx.cs" Inherits="PioneerLab.Pages.ContractorInfoManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function PrintReport() {
            window.open('ReportViwer.aspx?source=ContractorsInformationList&id=0&Filter=' + gridContractorsList.cpFilter, '_blank');

        }
    </script>
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
            <li class="active" id="menulink">Contractors Information</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Contractors Information</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Contractor" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick ="btnAddNew_Click" >
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
                                <ClientSideEvents click="PrintReport"/>
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvContractorsList" OnCustomButtonInitialize="GdvContractorsList_CustomButtonInitialize" OnCommandButtonInitialize="GdvContractorsList_CommandButtonInitialize" SettingsResizing-ColumnResizeMode="NextColumn"  AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridContractorsList" 
            DataSourceID="ContractorsListDS" KeyFieldName="ContractorID"  OnCellEditorInitialize ="GdvContractorsList_CellEditorInitialize" OnBeforeGetCallbackResult="GdvContractorsList_BeforeGetCallbackResult" >
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ContractorCode" Caption="Contractor number"  Width="150 " VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true"  ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ContractorName" Caption="Contractor Name" Width="220" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true"  ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PhoneNumber" Caption="Phone Number"  Width="150" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" Width="200"  VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Location" Caption="Location" Width="200" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="6" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>

                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true" >
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnView" Text=" " Image-ToolTip=""  >
                         <Image Url="../images/vision-clipart-1-eye-8.png" Width="22" Height="22" ToolTip="View" ></Image>

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
             <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <SettingsBehavior AutoFilterRowInputDelay="50000" AllowEllipsisInText="true" />
            <Settings UseFixedTableLayout="false"  />
            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Contractor&id=' + key);}" />
            <%--<SettingsResizing ColumnResizeMode="NextColumn" Visualization="Live"/>--%>
            <%--<ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.location =('Quotation.aspx?cid=' + key);}" />--%>

        </dx:ASPxGridView>
    </div>

        <asp:ObjectDataSource ID="ContractorsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ContractorsListDB"
         DataObjectTypeName="BusinessLayer.ContractorsList" SelectMethod="GetAll"  DeleteMethod="Delete">
    </asp:ObjectDataSource>

</asp:Content>
