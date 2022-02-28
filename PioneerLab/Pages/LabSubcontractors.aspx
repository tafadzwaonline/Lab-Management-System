<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="LabSubcontractors.aspx.cs" Inherits="PioneerLab.Pages.LabSubcontractors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script>
          function PrintReport() {
              window.open('ReportViwer.aspx?source=LabSubcontractors&id=0&Filter=' + gridSubcontractorsList.cpFilter, '_blank');

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
            <li class="active" id="menulink">Lab Subcontractors</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Lab Subcontractors</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Subcontractor" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridSubcontractorsList.AddNewRow();}" />
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
        <dx:ASPxGridView runat="server" ID="GdvSubcontractorsList" OnCustomErrorText="GdvSubcontractorsList_CustomErrorText" OnBeforeGetCallbackResult="GdvSubcontractorsList_BeforeGetCallbackResult" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridSubcontractorsList" DataSourceID="SubcontractorsListDS" KeyFieldName="SubContractorID" OnCommandButtonInitialize="GdvSubcontractorsList_CommandButtonInitialize">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="SubContractorCode" Caption="CR#" Width="60" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="SubContractorName" Caption="Subcontractor Name" Width="280" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataDateColumn FieldName="AccreditationExpiryDate" Caption="Accreditation Expiry Date" Width="300" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit> </dx:GridViewDataDateColumn>
                 <dx:GridViewDataMemoColumn FieldName="Address" Caption="Location/Address" Width="300" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                </dx:GridViewDataMemoColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewCommandColumn  ButtonType="Default" Width="60" VisibleIndex="6"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsPager Mode="ShowAllRecords"/>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
            </SettingsCommandButton>
             <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom"  />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="SubcontractorsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SubcontractorsListDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.SubcontractorsList"></asp:ObjectDataSource>
</asp:Content>
