<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="Equipments.aspx.cs" Inherits="PioneerLab.Pages.Equipments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function PrintReport() {
             window.open('ReportViwer.aspx?source=EquipmentList&id=0&Filter=' + gridEquipmentsList.cpFilter, '_blank');

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
            <li class="active" id="menulink">Equipment Information</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Equipment Information</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Equipment" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridEquipmentsList.AddNewRow();}" />
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
        <dx:ASPxGridView runat="server" ID="GdvEquipmentsList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridEquipmentsList" DataSourceID="EquipmentsListDS" KeyFieldName="EquipmentID"
            OnRowInserting="GdvEquipmentsList_RowInserting" OnRowUpdating="GdvEquipmentsList_RowUpdating" OnCustomErrorText="GdvEquipmentsList_CustomErrorText" OnBeforeGetCallbackResult="GdvEquipmentsList_BeforeGetCallbackResult" OnCommandButtonInitialize="GdvEquipmentsList_CommandButtonInitialize" OnCustomButtonInitialize="GdvEquipmentsList_CustomButtonInitialize">
            <Columns>
                <%--<dx:GridViewDataTextColumn FieldName="EmpCode" Caption="Code"  VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataTextColumn FieldName="EquipmentName" Caption="Equipment Name" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKLabID" Caption="Lab Section" VisibleIndex="2">
                    <PropertiesComboBox ValueField="LabID" TextField="LabName" DataSourceID="LabsListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataDateColumn FieldName="CalibrationDate" Caption="Calibration Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left"
                    PropertiesDateEdit-DisplayFormatString="dd MMM yyyy" PropertiesDateEdit-EditFormatString="dd MMM yyyy">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="ExpiryDate" Caption="Expiry Date" VisibleIndex="4" CellStyle-HorizontalAlign="Left"
                    PropertiesDateEdit-DisplayFormatString="dd MMM yyyy" PropertiesDateEdit-EditFormatString="dd MMM yyyy">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKEmpID" Caption="Responsible" VisibleIndex="5">
                    <PropertiesComboBox ValueField="EmpID" TextField="EmpName" DataSourceID="EmployeesListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="CalibratedBy" Caption="Calibrated By" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="8" ButtonType="Default" Width="80"
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
            <SettingsEditing Mode="PopupEditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <Templates>
                <EditForm>
                    <asp:Panel ID="PanEditForm" runat="server">
                        <table style="padding-left: 20px; width: 700px">
                            <%--<tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblCode" runat="server" Text="Equipment Code"></dx:ASPxLabel>
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
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblName" runat="server" Text="Equipment Name"></dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtName" runat="server" Width="480" Text='<%#Eval("EquipmentName") %>'>
                                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>

                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>

                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblFKLabID" runat="server" Text="Lab Section"></dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxComboBox ID="cmbFKLabID" runat="server" ValueField="LabID" TextField="LabName"
                                        DataSourceID="LabsListDS" Value='<%#Eval("FKLabID") %>' ValueType="System.Int32">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Lab Section!" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>

                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>

                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblCalibrationDate" runat="server" Text="Calibration Date"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="dtCalibrationDate" runat="server" Value='<%#Eval("CalibrationDate") %>'></dx:ASPxDateEdit>
                                </td>
                                <td style="width: 140px">
                                    <dx:ASPxLabel ID="lblExpiryDate" runat="server" Text="Expiry Date"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="dtExpiryDate" runat="server" Value='<%#Eval("ExpiryDate") %>'></dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblFKEmpID" runat="server" Text="Responsible"></dx:ASPxLabel>
                                </td>
                                <td >
                                    <dx:ASPxComboBox ID="cmbFKEmpID" runat="server" ValueField="EmpID" TextField="EmpName"
                                        DataSourceID="EmployeesListDS" Value='<%#Eval("FKEmpID") %>' ValueType="System.Int32">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Responsible Person!" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                                 <td style="width: 140px">
                                    <dx:ASPxLabel ID="lblCalibratedBy" runat="server" Text="Calibrated By"></dx:ASPxLabel>
                                </td>
                                <td>
                                     <dx:ASPxTextBox ID="txtCalibratedBy" runat="server"  Text='<%#Eval("CalibratedBy") %>'>
                                        
                                    </dx:ASPxTextBox>
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
                                                    EnableTheming="false" Text="Save" CommandArgument='<%#Eval("EquipmentID") %>' ValidationGroup="editForm" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk">
                                                    <ClientSideEvents Click="function(s,e) {if(ASPxClientEdit.ValidateGroup('editForm')) {gridEquipmentsList.UpdateEdit();}}" />
                                                </dx:ASPxButton>
                                            </td>
                                            <td width="5"></td>
                                            <td>
                                                <dx:ASPxButton ID="BtnCancel" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Close" AutoPostBack="false">
                                                    <ClientSideEvents Click="function(s, e) { gridEquipmentsList.CancelEdit(); }" />
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

            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Equipments&id=' + key);}" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="EquipmentsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EquipmentsListDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.EquipmentsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LabsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.LabsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.LabsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="EmployeesListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EmployeesListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.EmployeesList"></asp:ObjectDataSource>

</asp:Content>
