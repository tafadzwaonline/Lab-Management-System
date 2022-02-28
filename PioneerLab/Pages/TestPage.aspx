<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="TestPage.aspx.cs" Inherits="PioneerLab.Pages.TestPage" %>

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
            <li class="active" id="menulink">Student Absent Types</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Accredition Status</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="New" CssClass="btn btn-primary glyphicon glyphicon-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridAccreditionList.AddNewRow();}" />
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvAccreditionList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridAccreditionList" DataSourceID="AccreditionListDS" KeyFieldName="AccreditionID">
           <%-- OnRowDeleting="GdvAccreditionList_RowDeleting" OnRowInserting="GdvAccreditionList_RowInserting" OnRowUpdating="GdvAccreditionList_RowUpdating" OnCustomErrorText="GdvAccreditionList_CustomErrorText">--%>
            <Columns>
                <dx:GridViewDataTextColumn FieldName="AccreditionName" Caption="Absent Type" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Is Locked" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>

                <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="20"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                    <%--<ClearFilterButton Visible="True" Image-Url="../images/grd_clear.png">
                        <Image Url="../images/grd_clear.png"></Image>
                    </ClearFilterButton>
                    <EditButton Visible="true">
                        <Image Url="../images/grd_edit.png"></Image>
                    </EditButton>
                    <DeleteButton Visible="true">
                        <Image Url="../images/grd_Delete.png"></Image>
                    </DeleteButton>
                    <CancelButton>
                        <Image Url="../images/grd_clear.png"></Image>
                    </CancelButton>
                    <UpdateButton>
                        <Image Url="../images/save.png"></Image>
                    </UpdateButton>--%>
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
    <%--<table style="padding-left: 20px; width: 700px">
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblCode" runat="server" Text="Customer Code"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtCode" runat="server">
                        <ValidationSettings ValidationGroup="OnSave">
                            <RequiredField IsRequired="true" ErrorText="Code is required!" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr style="height: 5px">
                <td colspan="5"></td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblName" runat="server" Text="Customer Name"></dx:ASPxLabel>
                </td>
                <td colspan="3">
                    <dx:ASPxTextBox ID="txtName" runat="server" Width="525"></dx:ASPxTextBox>
                </td>

            </tr>
            <tr style="height: 5px">
                <td colspan="5"></td>
            </tr>

            <tr>
                <td style="width: 10px"></td>

                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblTel" runat="server" Text="Telephone No"></dx:ASPxLabel>
                </td>
                <td style="width: 200px">
                    <dx:ASPxTextBox ID="txtTel" runat="server"></dx:ASPxTextBox>
                </td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblFax" runat="server" Text="Fax No"></dx:ASPxLabel>
                </td>
                <td style="width: 200px">
                    <dx:ASPxTextBox ID="txtFax" runat="server"></dx:ASPxTextBox>
                </td>
            </tr>
            <tr style="height: 5px">
                <td colspan="5"></td>
            </tr>

            <tr>
                <td style="width: 10px"></td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblPOBox" runat="server" Text="P.O. Box"></dx:ASPxLabel>
                </td>
                <td colspan="3">
                    <dx:ASPxTextBox ID="txtPOBox" runat="server"></dx:ASPxTextBox>
                </td>

            </tr>
            <tr style="height: 5px">
                <td colspan="5"></td>
            </tr>

            <tr>
                <td style="width: 10px"></td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblEmail" runat="server" Text="Email"></dx:ASPxLabel>
                </td>
                <td colspan="3">
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="525"></dx:ASPxTextBox>
                </td>

            </tr>
            <tr style="height: 5px">
                <td colspan="5"></td>
            </tr>

            <tr>
                <td style="width: 10px"></td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblwebsite" runat="server" Text="Website"></dx:ASPxLabel>
                </td>
                <td colspan="3">
                    <dx:ASPxTextBox ID="txtwebsite" runat="server" Width="525"></dx:ASPxTextBox>
                </td>

            </tr>
            <tr style="height: 5px">
                <td colspan="5"></td>
            </tr>

            <tr>
                <td style="width: 10px"></td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblContactName" runat="server" Text="Contact Name"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtContactName" runat="server"></dx:ASPxTextBox>
                </td>
                <td style="width: 140px">
                    <dx:ASPxLabel ID="lblContactMobileNumber" runat="server" Text="Mobile Number"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtContactMobileNumber" runat="server"></dx:ASPxTextBox>
                </td>
            </tr>
            <tr style="height: 5px">
                <td colspan="5"></td>
            </tr>

            <tr>
                <td style="width: 10px"></td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblAddress" runat="server" Text="Address"></dx:ASPxLabel>
                </td>
                <td colspan="3">
                    <dx:ASPxTextBox ID="txtAddress" runat="server" Width="525"></dx:ASPxTextBox>
                </td>

            </tr>
            <tr style="height: 5px">
                <td colspan="5"></td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblIsLocked" runat="server" Text="Is Locked"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxCheckBox ID="IsLocked" runat="server"></dx:ASPxCheckBox>
                </td>
                <td style="width: 120px">
                    <dx:ASPxLabel ID="lblPaymentMode" runat="server" Text="Payment Mode"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbPaymentMode" runat="server" ValueType="System.Int32" DropDownStyle="DropDownList">
                        <Items>
                            <dx:ListEditItem Text="CASH" Value="1" />
                            <dx:ListEditItem Text="Credit" Value="2" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr style="height: 10px">
                <td colspan="5"></td>
            </tr>
        </table>--%>
    <asp:ObjectDataSource ID="AccreditionListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.AccreditionListDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.AccreditionList"></asp:ObjectDataSource>
</asp:Content>
