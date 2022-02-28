<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ValidityDetails.aspx.cs" Inherits="PioneerLab.Pages.ValidityDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function PrintReport() {
            window.open('ReportViwer.aspx?source=ValidityDetailsReport&id=0&Filter=' + gridValidityList.cpFilter, '_blank');

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
            <li class="active" id="menulink">Validity List Details</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Validity List Details</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="True"></dx:ASPxLabel>

    </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New List" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridValidityList.AddNewRow();}" />
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
        <dx:ASPxGridView runat="server" ID="GdvValidityList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridValidityList" OnBeforeGetCallbackResult="GdvValidityList_BeforeGetCallbackResult" DataSourceID="ValidityListDS" 
            OnInitNewRow="GdvValidityList_InitNewRow" KeyFieldName="ValidityID" OnCommandButtonInitialize="GdvValidityList_CommandButtonInitialize" OnCustomButtonInitialize="GdvValidityList_CustomButtonInitialize">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ValidityCode" Name="Code" ReadOnly="true" Caption="Code" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ValidityName" Caption="List Name" Width="400" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKLabID" Caption="Lab Section" VisibleIndex="3">
                    <PropertiesComboBox ValueField="LabID" TextField="LabName" DataSourceID="LabsListDS">
                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Select Lab Section" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>

                <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                     <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnprintR" Text=" " Image-ToolTip="" >
                         <Image Url="../images/print.png" Width="16" Height="16" ToolTip="print" ></Image>

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
            <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true" />
            <Templates>
                <DetailRow>
                    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                        <div class="btn-group" role="group" aria-label="First group">
                            <dx:ASPxButton AutoPostBack="false" ID="btnAddNewDetail" Text="Add New Certificate" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                                <ClientSideEvents Click="function (s, e) {if(lblAdd.GetText()=='True'){ gridValidityListDetails.AddNewRow();}}" />
                            </dx:ASPxButton>
                        </div>
                    </div>
                    <div class="row" style="height: 10px"></div>
                    <div class="btn-toolbar">
                        <dx:ASPxGridView runat="server" ID="GdvValidityListDetails" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridValidityListDetails" DataSourceID="ValidityListDetailsDS" KeyFieldName="ValidityDetailsID"
                            OnBeforePerformDataSelect="GdvValidityListDetails_BeforePerformDataSelect"  OnCustomErrorText="GdvValidityListDetails_CustomErrorText" OnCommandButtonInitialize="GdvValidityListDetails_CommandButtonInitialize" OnRowInserting="GdvValidityListDetails_RowInserting" OnRowUpdating="GdvValidityListDetails_RowUpdating" OnInitNewRow="GdvValidityListDetails_InitNewRow">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="CertificateName" Caption="Certificate Name" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CertificateSerialNumber" Caption="Certificate Serial Number" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="IDNumber" Caption="Equiment Sr no" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EnteredBy" Caption="Entered By" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="Entry Date" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                                     <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="ExpiryDate" Caption="Expiry Date" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                                     <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                 <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CalibratedBy" Caption="Calibrated By" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn FieldName="Status" Caption="Status" VisibleIndex="8" CellStyle-HorizontalAlign="Left">
                                </dx:GridViewDataTextColumn>
                                 
                                <%--<dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Is Locked" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                                </dx:GridViewDataCheckColumn>--%>

                                <dx:GridViewCommandColumn VisibleIndex="9" ButtonType="Default" Width="60"
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
                            <SettingsEditing Mode="PopupEditForm" NewItemRowPosition="Bottom" />
                            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                            <Templates>
                                <EditForm>
                                    <asp:Panel ID="PanEditForm" runat="server">
                                        <table style="padding-left: 20px; width: 700px">
                                            <%--<tr> Serial No Section
                                            <td style="width: 10px"></td>
                                            <td style="width: 120px">
                                                <dx:ASPxLabel ID="lblCode" runat="server" Text="Employee Code"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtCode" runat="server" Text='<%#Eval("EmpCode") %>'></dx:ASPxTextBox>
                                            </td>

                                        </tr>
                                        <tr style="height: 3px">
                                            <td colspan="5"></td>
                                        </tr>--%>
                                            <tr>
                                                <td style="width: 10px"></td>
                                                <td style="width: 140px">
                                                    <dx:ASPxLabel ID="lblCertificateName" runat="server" Text="Certificate Name"></dx:ASPxLabel>
                                                </td>
                                                <td style="width: 320px">
                                                    <dx:ASPxTextBox ID="txtCertificateName" runat="server" Width="300" Text='<%#Eval("CertificateName") %>'></dx:ASPxTextBox>
                                                </td>
                                                  
                                                 <td style="width: 120px">
                                                    <dx:ASPxLabel ID="lblCertificateSerialNumber" runat="server" Text="Certificate Sr no"></dx:ASPxLabel>
                                                </td>
                                                <td >
                                                    <dx:ASPxTextBox ID="txtCertificateSerialNumber" runat="server" Width="100" Text='<%#Eval("CertificateSerialNumber") %>'></dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 3px">
                                                <td colspan="5"></td>
                                            </tr>

                                            <tr>
                                                <td style="width: 10px"></td>
                                                <td style="width: 120px">
                                                    <dx:ASPxLabel ID="lblIDNumber" runat="server" Text="Equiment Sr no"></dx:ASPxLabel>
                                                </td>
                                                <td style="width: 200px">
                                                    <dx:ASPxTextBox ID="txtIDNumber" runat="server" Text='<%#Eval("IDNumber") %>'></dx:ASPxTextBox>
                                                </td>
                                                <td style="width: 120px">
                                                    <dx:ASPxLabel ID="lblEnteredBy" runat="server" Text="Entered By"></dx:ASPxLabel>
                                                </td>
                                                <td style="width: 200px">
                                                    <dx:ASPxTextBox ID="txtEnteredBy" runat="server" Text='<%#Eval("EnteredBy") %>' ReadOnly="true"></dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 3px">
                                                <td colspan="5"></td>
                                            </tr>

                                            <tr>
                                                <td style="width: 10px"></td>
                                                <td style="width: 120px">
                                                    <dx:ASPxLabel ID="lblEntryDate" runat="server" Text="Entry Date"></dx:ASPxLabel>
                                                </td>
                                                <td>
                                                    <dx:ASPxDateEdit ID="dtEntryDate"  DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy" DropDownButton-Enabled="false" runat="server" Value='<%#Eval("EntryDate") %>' ReadOnly="true"></dx:ASPxDateEdit>
                                                </td>
                                                <td style="width: 140px">
                                                    <dx:ASPxLabel ID="lblExpiryDate" runat="server" Text="Expiry Date"></dx:ASPxLabel>
                                                </td>
                                                <td>
                                                    <dx:ASPxDateEdit ID="dtExpiryDate" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy" runat="server" Value='<%#Eval("ExpiryDate") %>'></dx:ASPxDateEdit>
                                                </td>
                                            </tr>

                                            <tr style="height: 3px">
                                                <td colspan="5"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px"></td>
                                                <td style="width: 120px">
                                                    <dx:ASPxLabel ID="lblResponsible" runat="server" Text="Responsible"></dx:ASPxLabel>
                                                </td>
                                                <td >
                                                    <%--<dx:ASPxTextBox ID="txtResponsible" runat="server" Width="525" Text='<%#Eval("Responsible") %>'></dx:ASPxTextBox>--%>
                                                    <dx:ASPxComboBox ID="cmbResponsible" runat="server" ValueField="EmpName" TextField="EmpName" DropDownStyle="DropDownList" 
                                                        DataSourceID="EmployeesListDS" Value='<%#Eval("Responsible") %>' ValueType="System.String">
                                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="true" ErrorText="Select Responsible Person!" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                    <%--<dx:ASPxComboBox ID="cmbFKEmpID" runat="server" ValueField="EmpID" TextField="EmpName"
                                                        DataSourceID="EmployeesListDS" Value='<%#Eval("FKEmpID") %>' ValueType="System.Int32">
                                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="true" ErrorText="Select Responsible Person!" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>--%>
                                                </td>
                                                <td style="width: 120px">
                                                    <dx:ASPxLabel ID="lblCalibratedBy" runat="server" Text="Calibrated By"></dx:ASPxLabel>
                                                </td>
                                                <td style="width: 200px">
                                                    <dx:ASPxTextBox ID="txtCalibratedBy" runat="server"   Text='<%#Eval("CalibratedBy") %>'></dx:ASPxTextBox>
                                                </td>

                                            </tr>
                                            <tr style="height: 3px">
                                                <td colspan="5"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px"></td>
                                                <td style="width: 120px">
                                                    <dx:ASPxLabel ID="lblRemarks" runat="server" Text="Remarks"></dx:ASPxLabel>
                                                </td>
                                                <td colspan="3">
                                                    <dx:ASPxMemo ID="txtRemarks" runat="server" Width="525" Height="40" Text='<%#Eval("Remarks") %>'></dx:ASPxMemo>
                                                </td>

                                            </tr>
                                            <tr style="height: 3px">
                                                <td colspan="5"></td>
                                            </tr>
                                            <%--<tr>
                                            <td style="width: 10px"></td>
                                            <td style="width: 120px">
                                                <dx:ASPxLabel ID="lblIsLocked" runat="server" Text="Is Locked"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxCheckBox ID="IsLocked" runat="server" Value='<%#Eval("IsLocked") %>'></dx:ASPxCheckBox>
                                            </td>

                                        </tr>--%>
                                            <tr style="height: 15px">
                                                <td colspan="5"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px"></td>
                                                <td colspan="4">
                                                    <table cellpadding="0" cellspacing="0" style="text-align: end; float: right">
                                                        <tr>
                                                            <td>

                                                                <dx:ASPxButton ID="BtnSaveEditForm" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnSave %>" CommandName="CmdSave" AutoPostBack="false" Cursor="pointer"
                                                                    EnableTheming="false" Text="Save" CommandArgument='<%#Eval("ValidityDetailsID") %>' ValidationGroup="editForm" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk">
                                                                    <ClientSideEvents Click="function(s,e) {if(ASPxClientEdit.ValidateGroup('editForm')) {gridValidityListDetails.UpdateEdit();}}" />
                                                                </dx:ASPxButton>
                                                            </td>
                                                            <td width="5"></td>
                                                            <td>
                                                                <dx:ASPxButton ID="BtnCancel" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Close" AutoPostBack="false">
                                                                    <ClientSideEvents Click="function(s, e) { gridValidityListDetails.CancelEdit(); }" />
                                                                </dx:ASPxButton>
                                                            </td>
                                                            <td width="10"></td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px">
                                                <td colspan="5"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                </EditForm>

                            </Templates>
                            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
                        </dx:ASPxGridView>
                    </div>
                </DetailRow>
            </Templates>
            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=ValidityDetailsReport&id=' + key);}" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <asp:ObjectDataSource ID="EmployeesListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EmployeesListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.EmployeesList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ValidityListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ValidityListDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.ValidityList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LabsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.LabsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.LabsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ValidityListDetailsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ValidityListDetailsDB"
        SelectMethod="GetByFKValidityID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.ValidityListDetails">
        <SelectParameters>
            <asp:SessionParameter SessionField="FKValidityID" Name="FKValidityID" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
