<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="MaterialGroups.aspx.cs" Inherits="PioneerLab.Pages.MaterialGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function PrintReport() {
             window.open('ReportViwer.aspx?source=ServiceSectionList&id=0&Filter=' + gridMaterialsTypes.cpFilter, '_blank');

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
            <li class="active" id="menulink">Service Section</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Service Section</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="true"></dx:ASPxLabel>

    </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Service Section" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridMaterialsTypes.AddNewRow();}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
                <ClientSideEvents  Click="PrintReport"/>
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvMaterialsTypes" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridMaterialsTypes" OnBeforeGetCallbackResult="GdvMaterialsTypes_BeforeGetCallbackResult" DataSourceID="MaterialsTypesDS" KeyFieldName="MaterialTypeID" OnCommandButtonInitialize="GdvMaterialsTypes_CommandButtonInitialize">
            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=ServiceSection&id=' + key);}" />
           
             <Columns>
                <dx:GridViewDataTextColumn FieldName="MaterialName" Caption="Service Section Name" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKLabID" Caption="Lab Section" VisibleIndex="2">
                    <PropertiesComboBox ValueField="LabID" TextField="LabName" DataSourceID="LabsListDS">
                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Select Lab Section" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="3" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>

                <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnView" Text=" " Image-ToolTip="" >
                         <Image Url="../images/vision-clipart-1-eye-8.png" Width="22" Height="22" ToolTip="View" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="Inline" NewItemRowPosition="Top" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true" />
            <Templates>
                <DetailRow>
                    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                        <div class="btn-group" role="group" aria-label="First group">
                            <dx:ASPxButton AutoPostBack="false" ID="btnAddNewDetail" Text="Add New Custom Field" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                                <ClientSideEvents Click="function (s, e) {if(lblAdd.GetText()=='True') gridMaterialTypesCustomFields.AddNewRow();}" />
                            </dx:ASPxButton>
                        </div>
                    </div>
                    <div class="row" style="height: 10px"></div>
                    <div class="btn-toolbar">
                        <dx:ASPxGridView runat="server" ID="GdvMaterialTypesCustomFields" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridMaterialTypesCustomFields" DataSourceID="MaterialTypesCustomFieldsDS" KeyFieldName="CustomFieldID"
                            OnBeforePerformDataSelect="GdvMaterialTypesCustomFields_BeforePerformDataSelect" OnRowInserting="GdvMaterialTypesCustomFields_RowInserting" OnRowUpdating="GdvMaterialTypesCustomFields_RowUpdating" OnCommandButtonInitialize="GdvMaterialTypesCustomFields_CommandButtonInitialize">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="CustomFieldName" Caption="Field Name" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataTextColumn FieldName="DataType" Caption="Type" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>--%>
                                <dx:GridViewDataComboBoxColumn FieldName="DataType" Caption="Type" VisibleIndex="2">
                                    <PropertiesComboBox ValueField="DataType" ValueType="System.Int32" DropDownStyle="DropDownList">
                                        <Items>
                                            <dx:ListEditItem Text="Integer" Value="1" />
                                            <dx:ListEditItem Text="Decimal" Value="2" />
                                            <dx:ListEditItem Text="String" Value="3" />
                                            <dx:ListEditItem Text="Boolean" Value="4" />
                                            <dx:ListEditItem Text="Date" Value="6" />

                                        </Items>
                                        <ValidationSettings RequiredField-IsRequired="true"  ></ValidationSettings>
                                    </PropertiesComboBox>
                                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataCheckColumn FieldName="IsRequired" Caption="Is Required" Width="100" VisibleIndex="3">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="4">
                                </dx:GridViewDataCheckColumn>

                                <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Default" Width="60"
                                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsCommandButton>
                                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                                <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
                            </SettingsCommandButton>
                            <SettingsEditing Mode="Inline" NewItemRowPosition="Top" />
                            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
                            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
                        </dx:ASPxGridView>
                    </div>
                    <div class="row" style="height: 5px"></div>
                    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                        <div class="btn-group" role="group" aria-label="First group">
                            <dx:ASPxButton AutoPostBack="false" ID="btnAddNewTableDetail" Text="Add New Custom Table Field" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                                <ClientSideEvents Click="function (s, e) { if(lblAdd.GetText()=='True') gridMaterialTypesCustomTableFields.AddNewRow();}" />
                            </dx:ASPxButton>
                        </div>
                    </div>
                    <div class="row" style="height: 10px"></div>
                    <div class="btn-toolbar">
                        <dx:ASPxGridView runat="server" ID="GdvMaterialTypesCustomTableFields" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridMaterialTypesCustomTableFields" DataSourceID="MaterialTypesCustomTableFieldsDS" KeyFieldName="CustomFieldID"
                            OnBeforePerformDataSelect="GdvMaterialTypesCustomFields_BeforePerformDataSelect" OnRowInserting="GdvMaterialTypesCustomFields_RowInserting" OnRowUpdating="GdvMaterialTypesCustomFields_RowUpdating">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="CustomFieldName" Caption="Field Name" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataTextColumn FieldName="DataType" Caption="Type" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>--%>
                                <%--<dx:GridViewDataComboBoxColumn FieldName="DataType" Caption="Type" VisibleIndex="1">
                                    <PropertiesComboBox ValueField="DataType" ValueType="System.Int32" DropDownStyle="DropDownList">
                                        <Items>
                                            <dx:ListEditItem Text="Table" Value="5" />
                                        </Items>
                                    </PropertiesComboBox>
                                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>--%>
                                <dx:GridViewDataCheckColumn FieldName="IsRequired" Caption="Is Required" Width="100" VisibleIndex="2">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="3">
                                </dx:GridViewDataCheckColumn>

                                <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="60"
                                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsCommandButton>
                                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                                <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
                            </SettingsCommandButton>
                            <SettingsEditing Mode="Inline" NewItemRowPosition="Top" />
                            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn"/>
                            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
                        </dx:ASPxGridView>
                    </div>
                </DetailRow>
            </Templates>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.MaterialsTypes"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LabsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.LabsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.LabsList"></asp:ObjectDataSource>
<%--    <asp:ObjectDataSource ID="MaterialTypesCustomFieldsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialTypesCustomFieldsDB"
        SelectMethod="GetByFKMaterialTypeID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.MaterialTypesCustomFields">
        <SelectParameters>
            <asp:SessionParameter SessionField="FKMaterialTypeID" Name="FKMaterialTypeID" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:ObjectDataSource>--%>
    <asp:ObjectDataSource ID="MaterialTypesCustomFieldsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialTypesCustomFieldsDB"
        SelectMethod="GetNonTableFieldsByFKMaterialTypeID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.MaterialTypesCustomFields">
        <SelectParameters>
            <asp:SessionParameter SessionField="FKMaterialTypeID" Name="FKMaterialTypeID" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:ObjectDataSource>  
      <asp:ObjectDataSource ID="MaterialTypesCustomTableFieldsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialTypesCustomFieldsDB"
        SelectMethod="GetTableFieldsByFKMaterialTypeID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.MaterialTypesCustomFields">
        <SelectParameters>
            <asp:SessionParameter SessionField="FKMaterialTypeID" Name="FKMaterialTypeID" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
