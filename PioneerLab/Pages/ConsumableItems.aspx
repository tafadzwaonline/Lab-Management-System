<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ConsumableItems.aspx.cs" Inherits="PioneerLab.Pages.ConsumableItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function PrintReport() {
             window.open("ReportViwer.aspx?source=Items&id=0&Filter=" + gridItemsList.cpFilter, '_blank');
            // window.open('ReportViwer.aspx?source=AccreditionList&id=0&Filter=' + gridAccreditionList.cpFilter);

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
            <li class="active" id="menulink">Consumable Items</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Consumable Items</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Item" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridItemsList.AddNewRow();}" />
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
        <dx:ASPxGridView runat="server" ID="GdvItemsList"  OnCommandButtonInitialize="GdvItemsList_CommandButtonInitialize" OnCustomButtonInitialize="GdvItemsList_CustomButtonInitialize" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridItemsList" OnBeforeGetCallbackResult="GdvItemsList_BeforeGetCallbackResult" DataSourceID="ItemsListDS" KeyFieldName="ItemID">
            <Columns>
                 <dx:GridViewDataTextColumn FieldName="ItemNumber" Caption="Item Number" Width="200" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                      <PropertiesTextEdit>
                                <ValidationSettings CausesValidation="true">
                                  <RegularExpression ErrorText="Only Number " ValidationExpression="^\d{1,8}([.]\d{1,4})?$" />
                                 </ValidationSettings>
                          </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ItemName" Caption="Item Name" Width="250" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="UnitOfMeasure" Caption="Unit Of Measure" Width="200" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Unit Of Measure is missing!"></ValidationSettings>
                                                </PropertiesTextEdit>
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               
                <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" Width="280" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>

                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="80"
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
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
            <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom"  />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Items&id=' + key);}" />

        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="ItemsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ItemsListDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.ItemsList"></asp:ObjectDataSource>
</asp:Content>
