<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="TermsConditions.aspx.cs" Inherits="PioneerLab.Pages.TermsConditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function PrintReport() {
             window.open('ReportViwer.aspx?source=Terms_Conditions&id=0&Filter=' + gridTermsConditionsList.cpFilter, '_blank');

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
            <li class="active" id="menulink">Terms & Conditions</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Terms & Conditions</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Terms & Condition" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridTermsConditionsList.AddNewRow();}" />
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
        <dx:ASPxGridView runat="server" ID="GdvTermsConditionsList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridTermsConditionsList" OnBeforeGetCallbackResult="GdvTermsConditionsList_BeforeGetCallbackResult"
             DataSourceID="TermsConditionsListDS" KeyFieldName="TermConditionID" OnCommandButtonInitialize="GdvTermsConditionsList_CommandButtonInitialize"
            OnRowInserting="GdvTermsConditionsList_RowInserting" OnRowUpdating="GdvTermsConditionsList_RowUpdating">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="TermName" Caption="Terms & Condition Name" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataMemoColumn FieldName="Description" Caption="Description" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                </dx:GridViewDataMemoColumn>
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
             <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="PopupEditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <Templates>
                <EditForm>
                    <asp:Panel ID="PanEditForm" runat="server">
                        <table style="padding-left: 20px; width: 700px">
                  
                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblName" runat="server" Text="Term Name"></dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtName" runat="server" Width="480" Text='<%#Eval("TermName") %>'>
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
                                    <dx:ASPxLabel ID="lblDescription" runat="server" Text="Description"></dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxMemo ID="txtDescription" runat="server" Width="525" Height="250" Text='<%#Eval("Description") %>'></dx:ASPxMemo>
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
                                                    EnableTheming="false" Text="Save" CommandArgument='<%#Eval("TermConditionID") %>' ValidationGroup="editForm" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk">
                                                    <ClientSideEvents Click="function(s,e) {if(ASPxClientEdit.ValidateGroup('editForm')) {gridTermsConditionsList.UpdateEdit();}}" />
                                                </dx:ASPxButton>
                                            </td>
                                            <td width="5"></td>
                                            <td>
                                                <dx:ASPxButton ID="BtnCancel" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Close" AutoPostBack="false">
                                                    <ClientSideEvents Click="function(s, e) { gridTermsConditionsList.CancelEdit(); }" />
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
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="TermsConditionsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TermsConditionListDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.TermsConditionList"></asp:ObjectDataSource>

</asp:Content>
