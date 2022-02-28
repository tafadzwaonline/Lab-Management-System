<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="PriceUnit.aspx.cs" Inherits="PioneerLab.Pages.PriceUnit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script>
          function PrintReport() {

              window.open('ReportViwer.aspx?source=PriceUnitReport&id=0&Filter=' + gridPriceUnitList.cpFilter);

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
            <li class="active" id="menulink">Price Unit</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Price Unit</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Unit" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridPriceUnitList.AddNewRow();}" />
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
        <dx:ASPxGridView runat="server" ID="GdvPriceUnitList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPriceUnitList" OnBeforeGetCallbackResult="GdvPriceUnitList_BeforeGetCallbackResult" DataSourceID="PriceUnitListDS" KeyFieldName="PriceUnitID" OnCommandButtonInitialize="GdvPriceUnitList_CommandButtonInitialize">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="UnitName" Caption="Unit Name" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="UnitType" Caption="Unit Type"  Width="150" VisibleIndex="2" >
                    <PropertiesComboBox ValueType="System.Int32" DropDownStyle="DropDownList">
                        <Items>
                            <dx:ListEditItem Text="Time" Value="1" />
                            <dx:ListEditItem Text="Quantity" Value="0" />
                        </Items>
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="UnitDescription" Caption="Unit Description" Width="400" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
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
            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="PriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>
</asp:Content>
