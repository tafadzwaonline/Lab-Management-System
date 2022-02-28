<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="InvoiceManage.aspx.cs" Inherits="PioneerLab.Pages.InvoiceManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function PrintReport() {
            //Note :- Stop All Print out
            //window.open('ReportViwer.aspx?source=InvoiceList&id=0&Filter=' + gridInvoice.cpFilter, '_blank');

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
            <li class="active" id="menulink"> Invoice Manage</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Invoice Manage</h1>
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
        <div class="btn-group" role="group" aria-label="First group" >
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Visible="false" Text="New Invoice" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
                                <ClientSideEvents click="PrintReport"/>
            </dx:ASPxButton>
        </div>
    </div>
     <div>
        <h5>Pending Invoice</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingInvoice" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingInvoice"
            DataSourceID="PendingInvoiceDS" KeyFieldName="JobOrderMasterID" >
             <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnConvert') {window.location=('CustomerInvoice.aspx?id=' + key + '&mode=Convert');}}" />
           
            <Columns>
                 <dx:GridViewCommandColumn VisibleIndex="0" Caption="Convert" Width="55">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnConvert" Text=" ">
                            <Image Url="../images/Convert-Icon.png" Width="22" Height="22" ToolTip="Convert" ></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="JobOrderNumber" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="TransactionDate" Caption="Date" Width="400" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                 <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProjectName" Caption="Project" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               <%-- <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>--%>
                <%--<dx:GridViewDataCheckColumn FieldName="IsClosed" Caption="Is Closed" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>--%>
                <dx:GridViewDataCheckColumn FieldName="IsActive" Caption="Active" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>
               
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible"/>
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn" AllowDragDrop="true" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div class="row" style="height: 10px"></div>

     <div>
        <h5>Idle Service</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvIdelService" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingInvoice"
            DataSourceID="IdelServiceDS" KeyFieldName="JobOrderMasterID" >
            <Columns>
                 
                <dx:GridViewDataTextColumn FieldName="JobOrderNumber" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="TransactionDate" Caption="Date" Width="400" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>

                </dx:GridViewDataDateColumn>
                 <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProjectName" Caption="Project" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               <%-- <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>--%>
                <%--<dx:GridViewDataCheckColumn FieldName="IsClosed" Caption="Is Closed" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>--%>
                <dx:GridViewDataCheckColumn FieldName="IsActive" Caption="Active" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>
              
            </Columns>
           
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible"/>
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn"/>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div class="row" style="height: 10px"></div>

    <div>
        <h5>Invoice List</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvInvoice" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridInvoice"  OnCustomErrorText="GdvInvoice_CustomErrorText" OnBeforeGetCallbackResult="GdvInvoice_BeforeGetCallbackResult"
            DataSourceID="InvoiceDS" KeyFieldName="InvoiceId"  OnCellEditorInitialize="GdvInvoice_CellEditorInitialize" OnCustomButtonInitialize="GdvInvoice_CustomButtonInitialize" OnCommandButtonInitialize="GdvInvoice_CommandButtonInitialize">
          <%--//Note :- Stop All Print out--%>
            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Invoice&id=' + key,'Invoice'); window.open('ReportViwer.aspx?source=InvoiceTimeSheetReport&id=' + key,'InvoiceTimeSheetReport'); window.open('ReportViwer.aspx?source=SampleResiveTestInvoiced&id=' + key,'SampleResiveTestInvoiced');}" />
            <%--<ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Invoice&id=' + key,'Invoice');}" />--%>
             <Columns>
                  <dx:GridViewDataTextColumn FieldName="JobOrderNumber" Caption="Job Order No" VisibleIndex="0" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="ProjectName" Caption="Project" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
             <%-- <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="30%">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextField="JobOrderNumber" DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                        
                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>--%>
                <dx:GridViewDataTextColumn FieldName="InvoiceNumber" Caption="Invoice No" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="InvoiceDate" Caption="Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
               
               <dx:GridViewDataTextColumn FieldName="NetAmount" Caption="Net Amount" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               
                <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                         <dx:GridViewCommandColumnCustomButton ID="btnView" Text=" " Image-ToolTip="" >
                         <Image Url="../images/vision-clipart-1-eye-8.png" Width="22" Height="22" ToolTip="Print Not Active Please Call ACT Team" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <SettingsPager AlwaysShowPager="true" PageSize="10"></SettingsPager>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>


        <asp:ObjectDataSource ID="CustomersListDS" runat="server" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="InvoiceDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.InvoiceDB"
        SelectMethod="GetAllFromView"  DataObjectTypeName="BusinessLayer.ViewGelAllInvoice"  DeleteMethod="Delete"></asp:ObjectDataSource>

      <asp:ObjectDataSource ID="PendingInvoiceDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.ViewJobOrderPendingToInvoicer" SelectMethod="GetAllPendingInvoice" ></asp:ObjectDataSource>
     
     <asp:ObjectDataSource ID="IdelServiceDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.ViewIdelJobOrder" SelectMethod="GetAllIdleJobOrder" ></asp:ObjectDataSource>

       <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveViewJobOrder"></asp:ObjectDataSource>

     
</asp:Content>
