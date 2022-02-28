<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ReportGroup.aspx.cs" Inherits="PioneerLab.Pages.ReportGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function PrintReport() {
           
            window.open('ReportViwer.aspx?source=ServiceGroupList&id=0&Filter=' + gridServiceGroupList.cpFilter);
            
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
            <li class="active" id="menulink">Report Group</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Report Group</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" ClientInstanceName="btnAddNew" Text="Add New Accredition" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) {gridServiceGroupList.AddNewRow();}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" ClientInstanceName="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server" OnClick="btnPrint_Click"  >

                <ClientSideEvents click="PrintReport"/>
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvServiceGroupList" AutoGenerateColumns="false" Width="100%" OnInitNewRow="GdvServiceGroupList_InitNewRow" OnBeforeGetCallbackResult="GdvServiceGroupList_BeforeGetCallbackResult" OnCommandButtonInitialize="GdvServiceGroupList_CommandButtonInitialize" ClientInstanceName="gridServiceGroupList" DataSourceID="ServiceGroupDS" KeyFieldName="GroupID" >
            <Columns>
                  <dx:GridViewDataTextColumn FieldName="GroupNumber" Caption="Code" Width="350" VisibleIndex="1" ReadOnly="true" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="GroupName" Caption="Group Name" Width="450" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               

                <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="5%" 
                    ShowClearFilterButton="true"  ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                     
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit"  />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
            </SettingsCommandButton>
             <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom"  />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="ServiceGroupDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ReportGroupDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.ReportGroup"></asp:ObjectDataSource>
</asp:Content>
