<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="PaymentManage.aspx.cs" Inherits="PioneerLab.Pages.PaymentManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        //function PrintReport() {
        //    window.open('ReportViwer.aspx?source=InvoiceList&id=0&Filter=' + gridInvoice.cpFilter, '_blank');

        //}
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
            <li class="active" id="menulink"> Payment Manage</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Payment Manage</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Visible="false" Text="New Payment" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
                                <ClientSideEvents click="PrintReport"/>
            </dx:ASPxButton>
        </div>
    </div>
     <div>
        <h5>Pending Payment</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingPayment" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingPayment"
            DataSourceID="PendingPaymentDS" KeyFieldName="JobOrderMasterID">
             <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnConvert') {window.location=('PaymentInfo.aspx?id=' + key + '&mode=Convert');}}" />
            <Columns>
                 <dx:GridViewCommandColumn VisibleIndex="0" Caption="Convert" Width="55">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnConvert" Text=" ">
                            <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Approve" ></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                 <dx:GridViewDataTextColumn FieldName="JobOrderNumber" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="50%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               <dx:GridViewDataTextColumn FieldName="No_of_PendingPayment" Caption="No of PendingPayment" VisibleIndex="2" CellStyle-HorizontalAlign="Left" Width="20%"> 
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               <dx:GridViewDataTextColumn FieldName="TotalPendingAmount" Caption="Total Pending Amount" VisibleIndex="3" CellStyle-HorizontalAlign="Left" Width="20%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               
                 <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="8%"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
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
        <h5>Payment History</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPaymentHistory" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPaymentHistory" OnBeforeGetCallbackResult="GdvPaymentHistory_BeforeGetCallbackResult"
            DataSourceID="PaymentHistoryDS" KeyFieldName="PaymentID" OnCellEditorInitialize="GdvPaymentHistory_CellEditorInitialize" OnCustomButtonInitialize="GdvPaymentHistory_CustomButtonInitialize" OnCommandButtonInitialize="GdvPaymentHistory_CommandButtonInitialize">
             <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Invoicee&id=' + key,'Invoicee');}" />
            <Columns>
               
                <dx:GridViewDataTextColumn FieldName="ReferenceNumber" Caption="Payment No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="PaymentDate" Caption="Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left" Width="10%">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                  <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="30%">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextField="JobOrderNumber" DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                        
                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataTextColumn FieldName="PaymentAmount" Caption="Payment Amount" VisibleIndex="4" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               
                <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="5" CellStyle-HorizontalAlign="Left" Width="40%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="9" ButtonType="Default" Width="8%"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                         <dx:GridViewCommandColumnCustomButton ID="btnView" Text=" " Image-ToolTip="" >
                         <Image Url="../images/vision-clipart-1-eye-8.png" Width="22" Height="22" ToolTip="View" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="ReceivedBy" Caption="Received By" VisibleIndex="8" CellStyle-HorizontalAlign="Left" Width="8%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
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
 
    <asp:ObjectDataSource ID="PaymentHistoryDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        SelectMethod="GetAllAgainstInvoicePayment" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.PaymentMaster" ></asp:ObjectDataSource>

     
      <asp:ObjectDataSource ID="PendingPaymentDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        DataObjectTypeName="BusinessLayer.ViewPendingPayment" SelectMethod="GetAllPendingPayment" ></asp:ObjectDataSource>
   
     <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveViewJobOrder"></asp:ObjectDataSource>

</asp:Content>
