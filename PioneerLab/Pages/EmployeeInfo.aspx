<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="EmployeeInfo.aspx.cs" Inherits="PioneerLab.Pages.EmployeeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function PrintReport() {
             window.open('ReportViwer.aspx?source=EmployeeList&id=0&Filter=' + gridEmployeesList.cpFilter, '_blank');

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
            <li class="active" id="menulink">Employee Information</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Employee Information</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Employee" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridEmployeesList.AddNewRow();}" />
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
        <dx:ASPxGridView runat="server" ID="GdvEmployeesList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridEmployeesList" DataSourceID="EmployeesListDS" KeyFieldName="EmpID"
            OnRowInserting="GdvEmployeesList_RowInserting" OnRowUpdating="GdvEmployeesList_RowUpdating" OnBeforeGetCallbackResult="GdvEmployeesList_BeforeGetCallbackResult" OnCommandButtonInitialize="GdvEmployeesList_CommandButtonInitialize" OnCustomButtonInitialize="GdvEmployeesList_CustomButtonInitialize">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="EmpCode" Caption="Employee Number" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmpName" Caption="Employee Name" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Profession" Caption="Profession" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="QID" Caption="QID" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PhoneNumber" Caption="Phone Number" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
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
            <SettingsEditing Mode="PopupEditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Templates>
                <EditForm >
                    <asp:Panel ID="PanEditForm" runat="server">
                        <table style="padding-left: 20px; width: 700px">

                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px"></td>
                                <td style="width: 200px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblIsLocked" runat="server" Text=""></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="IsLocked" runat="server" Value='<%#Eval("IsLocked") %>' Text="Inactive"></dx:ASPxCheckBox>
                                </td>

                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblCode" runat="server" Text="Employee Number"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtCode" runat="server" Text='<%#Eval("EmpCode") %>'>
                                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="editForm">
                                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
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
                                    <dx:ASPxLabel ID="lblName" runat="server" Text="Employee Name"></dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtName" runat="server" Width="524" Text='<%#Eval("EmpName") %>'>
                                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="editForm">
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
                                    <dx:ASPxLabel ID="lblProfession" runat="server" Text="Profession"></dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtProfession" runat="server" Width="524" Text='<%#Eval("Profession") %>'></dx:ASPxTextBox>
                                </td>

                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>

                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblQid" runat="server" Text="QID/Visa No"></dx:ASPxLabel>
                                </td>
                                <td style="width: 200px">
                                    <dx:ASPxTextBox ID="txtQid" runat="server" Text='<%#Eval("QID") %>'></dx:ASPxTextBox>
                                </td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblTel" runat="server" Text="Telephone No"></dx:ASPxLabel>
                                </td>
                                <td style="width: 200px">
                                    <dx:ASPxSpinEdit ID="txtTel" runat="server" Text='<%#Eval("PhoneNumber") %>' SpinButtons-ShowIncrementButtons="false"
                                                     AllowMouseWheel="false" NumberType="Integer"></dx:ASPxSpinEdit>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>

                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblNormalWH" runat="server" Text="Normal Work Hrs"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtNormalWH" runat="server" Text='<%#Eval("NormalWorkHrs") %>'></dx:ASPxTextBox>
                                </td>
                                <td style="width: 140px">
                                    <dx:ASPxLabel ID="lblRamadanWH" runat="server" Text="Ramadan Work Hrs"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtRamadanWH" runat="server" Text='<%#Eval("RamadanWorkHrs") %>'></dx:ASPxTextBox>
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
                                                    EnableTheming="false" Text="Save" CommandArgument='<%#Eval("EmpID") %>' ValidationGroup="editForm" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk">
                                                    <ClientSideEvents Click="function(s,e) {if(ASPxClientEdit.ValidateGroup('editForm')) {gridEmployeesList.UpdateEdit();}}" />
                                                </dx:ASPxButton>
                                            </td>
                                            <td width="5"></td>
                                            <td>
                                                <dx:ASPxButton ID="BtnCancel" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Close" AutoPostBack="false">
                                                    <ClientSideEvents Click="function(s, e) { gridEmployeesList.CancelEdit(); }" />
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
            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Employees&id=' + key);}" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="EmployeesListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EmployeesListDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.EmployeesList"></asp:ObjectDataSource>
</asp:Content>
