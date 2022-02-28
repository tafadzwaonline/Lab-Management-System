<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="CustomerEnquiry.aspx.cs" Inherits="PioneerLab.Pages.CustomerEnquiry" %>

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
         <script>
             window.onbeforeunload = confirmExit;
             function confirmExit() {
                 return "You are about to exit the system! , Are you sure you want to leave now?";
             }
             $(function () {
                 $("a").click(function () {
                     window.onbeforeunload = null;
                 });
                 $("input").click(function () {
                     window.onbeforeunload = null;
                 });
             });
    </script>
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>
            <li><a id="menu1" href="#">Transactions</a></li>
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
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>

        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary fa fa-floppy-o" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default fa fa-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>

        </div>
    </div>
    <div class="row" style="height: 20px"></div>
    <div class="btn-toolbar">

        <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
        </div>
        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
            <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup="OnSave"></dx:ASPxValidationSummary>
        </div>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxFormLayout ID="flEnquiryMaster" runat="server" DataSourceID="EnquiryMasterDS" ClientInstanceName="flEnquiryMaster">
            <Items>
                <dx:LayoutGroup ShowCaption="False" ColCount="6">
                    <Items>
                        <dx:LayoutItem Caption="Enquiry No" FieldName="EnquiryCode" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtEnquiryCode" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Date" FieldName="EntryDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtEntryDate" runat="server" ClientEnabled="false" DropDownButton-ClientVisible="false" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy" ReadOnly="true"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Enquiry Method" FieldName="EnquiryMethodID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbEnquiryMethodID" runat="server" ValueType="System.Int32" DropDownStyle="DropDownList" AutoPostBack="true">
                                        <Items>
                                            <dx:ListEditItem Text="Email" Value="1" />
                                            <dx:ListEditItem Text="Phone" Value="2" />
                                            <dx:ListEditItem Text="Fax" Value="3" />
                                            <dx:ListEditItem Text="Personal" Value="4" />
                                        </Items>
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Enquiry Method" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Customer Reference" FieldName="CustomerReference" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtCustomerReference" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Contact Person" FieldName="ContactPerson" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtContactPerson" runat="server">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Contact Person" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Contact Number" FieldName="ContactNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtContactNumber" runat="server">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Contact No" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Contact Job Title" FieldName="ContactJobTitle" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtContactJobTitle" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Contact Email" FieldName="ContactEmail" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtContactEmail" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Receiving Date" FieldName="ReceivingDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtReceivingDate" runat="server"  DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Creditor Mode" FieldName="CustomersList.PaymentMode" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbPaymentMode" runat="server" ValueType="System.Int32" DropDownStyle="DropDownList" AutoPostBack="true">
                                        <Items>
                                            <dx:ListEditItem Text="CASH" Value="1" />
                                            <dx:ListEditItem Text="Credit" Value="2" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Customer" FieldName="FKCustomerID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbFKCustomerID" runat="server" Width="250" ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS" ValueType="System.Int32">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                        <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td style="padding-left: 2px">
                                                <dx:ASPxButton AutoPostBack="false" ID="btnAddNewCustomer" CssClass="btn btn-mini btn-sm  btn-white" runat="server">
                                                    <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-plus';}" Click="function (s, e) { window.open('CustomerInfo.aspx','_blank');}" />
                                                    <BackgroundImage HorizontalPosition="center" />
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Project" FieldName="FKProjectID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbFKProjectID" runat="server" Width="220" ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS" ValueType="System.Int32">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                        <RequiredField IsRequired="true" ErrorText="Select Project" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td style="padding-left: 2px">
                                                <dx:ASPxButton AutoPostBack="false" ID="btnAddNewProject" CssClass="btn btn-mini btn-sm  btn-white" runat="server">
                                                    <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-plus';}" Click="function (s, e) { window.open('ProjectInfo.aspx','_blank');}" />
                                                    <BackgroundImage HorizontalPosition="center" />
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Remarks" FieldName="Remarks" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo ID="txtRemarks" runat="server" Width="525" Height="40"></dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Enterd By" FieldName="EnterdBy" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtEnterdBy" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption=" " ColSpan="6" Visible="false">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNewDetail" Text="Add or Remove Services" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                                        <ClientSideEvents Click="function (s, e) { popTestLists.Show();}" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridView runat="server" ID="GdvEnquiryDetailsList" Width="100%" AutoGenerateColumns="false" OnCustomErrorText="GdvEnquiryDetailsList_CustomErrorText" ClientInstanceName="gridEnquiryDetailsList" OnCellEditorInitialize="GdvEnquiryDetailsList_CellEditorInitialize"
                                        DataSourceID="EnquiryDetailsDS" KeyFieldName="EnquiryDetailsID" OnRowUpdating="GdvEnquiryDetailsList_RowUpdating" OnRowDeleting="GdvEnquiryDetailsList_RowDeleting">
                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKMaterialTypeID" Caption="Service Section" Width="150" VisibleIndex="1" ReadOnly="true">
                                                <PropertiesComboBox ValueField="MaterialTypeID" TextField="MaterialName" DataSourceID="MaterialsTypesDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKMaterialDetailsID" Caption="Material Details" Width="150" VisibleIndex="2" ReadOnly="true">
                                                <PropertiesComboBox ValueField="MaterialDetailsID" TextField="MaterialName" DataSourceID="AllMaterialsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Services Name" Width="150" VisibleIndex="3" ReadOnly="true">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Standard Number" Width="150" VisibleIndex="4" ReadOnly="true">
                                                <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>

                                            <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" Width="100" VisibleIndex="5">
                                                <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" Width="200" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Default" Width="30"
                                                ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-list';}" Click="function (s, e) { popTestLists.Show();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>

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
                                        <Settings VerticalScrollBarMode="Visible" />
                                        <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>

                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>
    <div>
       
        <dx:ASPxPopupControl ID="popTestLists" runat="server" CloseAction="CloseButton" OnWindowCallback="popTestLists_WindowCallback"
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Available Services List" ClientInstanceName="popTestLists">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
                    <div style="display: none; overflow: auto; height: 500px">
                        <dx:ASPxCheckBoxList ID="lstTests" runat="server" ClientInstanceName="lstTests" DataSourceID="TestsListDS" ValueType="System.Int32"
                            TextField="TestName" ValueField="TestID" Width="500" OnDataBound="lstTests_DataBound">
                        </dx:ASPxCheckBoxList>
                    </div>
                    <div style="width: 100%">
                        <div style="display: inline-block;">
                            Service Section:
                            <dx:ASPxComboBox ID="cmbFKMaterialTypeID" runat="server" ValueField="MaterialTypeID" TextField="MaterialName" DataSourceID="MaterialsTypesDS"
                                AutoPostBack="true" Width="240" OnSelectedIndexChanged="cmbFKMaterialTypeID_SelectedIndexChanged" ValueType="System.Int32">
                                <ClearButton Visibility="True" DisplayMode="Always"></ClearButton>
                            </dx:ASPxComboBox>
                        </div>
                        <div style="display: inline-block;">
                            Material Details:
                            <dx:ASPxComboBox ID="cmbFKMaterialDetailsID" runat="server" ValueField="MaterialDetailsID" TextField="MaterialName" DataSourceID="MaterialsListDS"
                                AutoPostBack="true" Width="240" ValueType="System.Int32">
                                <ClearButton Visibility="True" DisplayMode="Always"></ClearButton>
                                
                            </dx:ASPxComboBox>
                        </div>

                         <div style="display: inline-block;">
                            Unit :
                            <dx:ASPxComboBox ID="CmbUnit" runat="server" ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS"
                                AutoPostBack="true" Width="240" ValueType="System.Int32">
                                <ClearButton Visibility="True" DisplayMode="Always"></ClearButton>
                            </dx:ASPxComboBox>
                        </div>
                    </div>
                    <div style="width: 100%; height: 5px"></div>
                    <div>
                        <dx:ASPxGridView runat="server" ID="GdvLabTestsList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridLabTestsList"
                            DataSourceID="ServiceListDS" KeyFieldName="TestID" >
                            <Columns>

                                <dx:GridViewDataTextColumn FieldName="TestName" Caption="Service Name" Width="150" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                    <Settings AutoFilterCondition="Contains" />
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ShortName" Caption="Short Name" Width="100" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="Standard Number" Width="100" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AshghalTestNumber" Caption="Ashghal Test Number" Width="100" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>

                                <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Default" Width="80" ShowClearFilterButton="true" ShowSelectCheckbox="true">
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsCommandButton>
                                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                            </SettingsCommandButton>
                            <Settings ShowFilterRow="True" />
                            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
                             
                        </dx:ASPxGridView>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <dx:ASPxButton ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-save" OnClick="btnUpdate_Click">
                        <%--<ClientSideEvents Click="function(s, e) { popTestLists.PerformCallback(); }" />--%>
                    </dx:ASPxButton>
                </div>
            </FooterTemplate>
            <ClientSideEvents PopUp="function(s, e) { popTestLists.PerformCallback(); }" />
        </dx:ASPxPopupControl>
    </div>

    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAllByPaymentMode">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flEnquiryMaster$cmbPaymentMode" PropertyName="Value" DefaultValue="0" Name="PaymentMode" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="AllMaterialsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsDetails"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MaterialsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsDB"
        SelectMethod="GetByFKMaterialTypeID" DataObjectTypeName="BusinessLayer.MaterialsDetails">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$popTestLists$cmbFKMaterialTypeID" PropertyName="Value" DefaultValue="0" Name="FKMaterialTypeID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="EnquiryMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EnquiryMasterDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete"
        OnInserting="EnquiryMasterDS_Inserting" OnInserted="EnquiryMasterDS_Inserted"
        OnUpdating="EnquiryMasterDS_Updating" OnUpdated="EnquiryMasterDS_Updated">
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

    <asp:ObjectDataSource ID="ServiceListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAllServiceByMaterial" DataObjectTypeName="BusinessLayer.TestsList">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$popTestLists$cmbFKMaterialTypeID" PropertyName="Value" Name="MaterialTypeID" Type="Int32" />
            <asp:ControlParameter ControlID="ctl00$body$popTestLists$cmbFKMaterialDetailsID" PropertyName="Value" Name="MaterialDetailsID" Type="Int32" />
             <asp:ControlParameter ControlID="ctl00$body$popTestLists$CmbUnit" PropertyName="Value" Name="FKPriceUnitID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="EnquiryDetailsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EnquiryDetailsDB"
        SelectMethod="GetByMasterIDWithSession" InsertMethod="InsertList"  OnInserting="EnquiryDetailsDS_Inserting" OnInserted="EnquiryDetailsDS_Inserted"
        UpdateMethod="UpdateWithSession" OnUpdating="EnquiryDetailsDS_Updating" DeleteMethod="DeleteWithSession" OnDeleting="EnquiryDetailsDS_Deleting">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Type="Object" Name="entity" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Type="Object" Name="entity" />
        </DeleteParameters>
    </asp:ObjectDataSource>

</asp:Content>
