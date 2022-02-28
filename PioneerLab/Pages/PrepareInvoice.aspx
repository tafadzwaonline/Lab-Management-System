<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="PrepareInvoice.aspx.cs" Inherits="PioneerLab.Pages.PrepareInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

    </script>
    <%--<style type="text/css">
        table.dxeTextBoxSys, table.dxeMemoSys, table.dxeButtonEditSys,table.dxeEditAreaSys, table.dxeButtonEdit,
         td.dxeButtonEditButton,table.dxeListBox_MetropolisBlue{
            border-radius: 5px;
            -moz-border-radius: 5px;
            -khtml-border-radius: 5px;
            -webkit-border-radius: 5px;
        }
    </style>--%>
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
            <li><a id="menu1" href="#">Transactions</a></li>
            <li class="active" id="menulink">Job Order</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Job Order</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups" style="display:none">
        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary fa fa-floppy-o" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default fa fa-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>
        </div>
        <%--<div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnSaveVersion" runat="server" EnableTheming="false" Text="Save New Version" CssClass="btn btn-round btn-primary fa fa-clipboard" ValidationGroup="OnSave" OnClick="BtnSaveVersion_Click">
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>--%>
        <div class="btn-group" role="group" aria-label="First group" style="float: right">
            <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
                <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
                <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
            </div>

        </div>
    </div>
    <div class="row" style="height: 3px"></div>
    <div class="btn-toolbar">


        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
            <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup="OnSave"></dx:ASPxValidationSummary>
        </div>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxLabel ID="lblActiveMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxFormLayout ID="flJobOrderMaster" runat="server" DataSourceID="JobOrderMasterDS" ClientInstanceName="flJobOrderMaster">
            <Items>
                <dx:LayoutGroup ShowCaption="False" ColCount="8">
                    <Items>
                        <%-- <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem Width="100" />

                        <dx:LayoutItem ShowCaption="False" FieldName="IsActive" HorizontalAlign="Right" Height="40">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsActive" runat="server" Text="Active" TextAlign="Right"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>


                        <dx:LayoutItem Caption="Customer" FieldName="FKCustomerID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKCustomerID" runat="server" Width="550" ValueField="CustomerID" TextField="CustomerName"
                                        DataSourceID="CustomersListDS" ValueType="System.Int32" >
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project" FieldName="FKProjectID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKProjectID" runat="server" Width="550" ValueField="ProjectID" TextField="ProjectName"
                                        DataSourceID="ProjectsListDS" ValueType="System.Int32" >
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Project" />
                                        </ValidationSettings>--%>
                                        <ClearButton Visibility="True"></ClearButton>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="From Date" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtExpiryDate" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="To Date" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtTransactionDate" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--<dx:EmptyLayoutItem ColSpan="2" />--%>

                        <dx:LayoutItem Caption=" " ColSpan="2" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxButton AutoPostBack="false" ID="btnSearch" Text="Search" CssClass="btn btn-round btn-primary fa fa-search" runat="server">
                                        <%--<ClientSideEvents Click="function (s, e) { popTestLists.Show();}" />--%>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup ShowCaption="False" ColCount="8">
                    <Items>
                        <dx:LayoutItem Caption=" " ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridView runat="server" ID="GdvJobOrderDetailsList" AutoGenerateColumns="false" ClientInstanceName="gridJobOrderDetailsList" OnCellEditorInitialize="GdvJobOrderDetailsList_CellEditorInitialize"
                                        DataSourceID="JobOrderDetailsDS" KeyFieldName="JobOrderDetailsID" OnRowUpdating="GdvJobOrderDetailsList_RowUpdating" Width="100%" OnCustomButtonInitialize="GdvJobOrderDetailsList_CustomButtonInitialize">
                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKMaterialTypeID" Caption="Service Section" VisibleIndex="1" ReadOnly="true">
                                                <PropertiesComboBox ValueField="MaterialTypeID" TextField="MaterialName" DataSourceID="MaterialsTypesDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKMaterialDetailsID" Caption="Material Details" VisibleIndex="2" ReadOnly="true">
                                                <PropertiesComboBox ValueField="MaterialDetailsID" TextField="MaterialName" DataSourceID="AllMaterialsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Services Name" VisibleIndex="3" ReadOnly="true">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Standard Number" VisibleIndex="4" ReadOnly="true">
                                                <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>

                                            <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" VisibleIndex="5" ReadOnly="true">
                                                <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Price" Caption="Price" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit DecimalPlaces="2"  SpinButtons-ShowIncrementButtons="false">
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Price is missing!"></ValidationSettings>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>

                                            <dx:GridViewDataSpinEditColumn FieldName="MinQty" Caption="Minimum Qty" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit DecimalPlaces="2"  SpinButtons-ShowIncrementButtons="false">
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="8" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn VisibleIndex="9" ButtonType="Default" Width="60"
                                                ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server" ClientVisible="false">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-list';}" Click="function (s, e) { popTestLists.Show();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>
                                                <CustomButtons>
                                                    <dx:GridViewCommandColumnCustomButton ID="btnWorkOrder" Text=" ">
                                                        <Styles>
                                                            <Style Font-Size="Medium" CssClass="glyphicon glyphicon-list-alt"></Style>
                                                        </Styles>
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
                                        <Styles>
                                            <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                        </Styles>
                                        <SettingsPager PageSize="5"></SettingsPager>
                                        <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
                                        <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); vi.SetValue(e.visibleIndex);vid.SetValue(key); gridWorkOrderList.PerformCallback();popupWorkOrder.Show();ASPxClientEdit.ClearEditorsInContainerById('contentDiv'); }" />
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup ShowCaption="False" ColCount="8">
                    <Items>

                        <dx:LayoutItem Caption="Invoice No" FieldName="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtWorkOrderNo" runat="server" ClientInstanceName="txtWorkOrderNo" ClientEnabled="false"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Invoice Date" FieldName="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtTransDate" ClientInstanceName="dtTransDate" ClientEnabled="false" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Invoice Amount" FieldName="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtFKAgreementID" ClientInstanceName="txtFKAgreementID" runat="server" ClientEnabled="false"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Remarks" FieldName="Remarks" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo ID="txtRemarks" runat="server" Width="800" Height="40"></dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption=" " ColSpan="2" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxButton AutoPostBack="false" ID="ASPxButton1" Text="Generate" CssClass="btn btn-round btn-primary fa fa-search" runat="server">
                                        <%--<ClientSideEvents Click="function (s, e) { popTestLists.Show();}" />--%>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>


    <asp:ObjectDataSource ID="QuotationMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationMasterDB"
        DataObjectTypeName="BusinessLayer.QuotationMaster" SelectMethod="GetActivePending">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="jobOrderMasterId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="AllMaterialsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsDetails"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MaterialsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsDetails">
        <%--<SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flQuotationMaster$cmbFKMaterialTypeID" PropertyName="Value" DefaultValue="0" Name="FKMaterialTypeID" Type="Int32" />
        </SelectParameters>--%>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="PriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestPriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="JobOrderDetailsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderDetailsDB"
        SelectMethod="GetByMasterIDFromSession" InsertMethod="InsertList" >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Type="Object" Name="entity" />
        </UpdateParameters>
    </asp:ObjectDataSource>

   
</asp:Content>
