<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="PaymentInfo.aspx.cs" Inherits="PioneerLab.Pages.PaymentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .statusBar a:first-child {
            display: none;
        }

        .statusBar {
            display: none;
        }
    </style>
    <style type="text/css">
        .HideScroll > tbody > tr > td > div {
            overflow: hidden !important;
        }
    </style>
    <script>
       
      
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
            <li><a id="menu1" href="#">Transaction</a></li>
            <li class="active" id="menulink">Payment </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Payment</h1>
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
            <dx:ASPxLabel ID="lblAlowUpdate" runat="server" ClientInstanceName="lblAlowUpdate" ForeColor="White" Text="false" Visible="true"></dx:ASPxLabel>

            <dx:ASPxButton ID="btnSave" ValidationGroup="OnSave" CausesValidation="true" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk"  OnClick="btnSave_Click" Style="width: 80px" AutoPostBack="false" runat="server" Text="Save">
            </dx:ASPxButton>

        </div>

        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" AutoPostBack="false" Style="width: 80px" OnClick="btnCancel_Click" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Text="Back">
                <ClientSideEvents Click="function(s,e){ if ( confirm('Are you sure you want to cancel all changes?') == true) {}}" />
            </dx:ASPxButton>
        </div>
    </div>
      <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="LblErrorMessage" runat="server" CssClass="Alert" Text="" ClientInstanceName="LblErrorMessage"></dx:ASPxLabel>
        </div>
    <div class="row" style="height: 10px">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxLabel ID="lblQid" runat="server" Text="0"  ClientVisible="false" ClientInstanceName="lblQid"></dx:ASPxLabel>

    </div>

    <div class="btn-toolbar">
        <dx:ASPxFormLayout ID="flPayment" runat="server" DataSourceID="PaymentDS" ClientInstanceName="flPayment">
            <Items>
                <dx:LayoutGroup ShowCaption="False" ColCount="6" Border-BorderStyle="None">
                    <Items>

                        <dx:LayoutItem Caption="Payment Number" FieldName="ReferenceNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtReferenceNumber"  runat="server"  >
                                           <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Insert Invoice Number" />
                                        </ValidationSettings>
                                     
                                    </dx:ASPxTextBox>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                       
                        <dx:LayoutItem Caption="Payment Date" FieldName="PaymentDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtPaymentDate" ClientInstanceName="dtPaymentDate" ClientEnabled="false" DropDownButton-ClientVisible="false" runat="server" DisplayFormatString="dd MMM yyyy hh:mm tt" EditFormatString="dd MMM yyyy hh:mm tt" ReadOnly="true"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                      
                      
                         <dx:LayoutItem Caption="Job Order Number" FieldName="FKJobOrderMasterID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbJobOrderMaster" runat="server" ValueField="JobOrderMasterID" DataSourceID="JobOrderMasterDS" ValueType="System.Int64" Width="400px"
                                        AutoPostBack="true" ClientEnabled="false" TextFormatString="{0} - ({2:dd MMM yyyy}) - {3} - {4}" DropDownStyle="DropDownList"   DropDownButton-ClientVisible="false" >
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Job Order"  />
                                        </ValidationSettings>
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="100" />
                                            <dx:ListBoxColumn FieldName="LPONumber" Caption="LPO Number" Width="100" />
                                            <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                        </Columns>
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Job Order Number" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                     
                          <dx:LayoutItem Caption="Paid Amount"  ColSpan="2" FieldName="PaymentAmount">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtPaidAmount" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtPaymentAmount" runat="server" >
                                                                </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Payment Type" FieldName="PaymentType"  ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbPaymentType" runat="server" ValueType="System.Int32" DropDownStyle="DropDownList" AutoPostBack="true" OnSelectedIndexChanged="cmbPaymentType_SelectedIndexChanged">
                                        <Items>
                                            <dx:ListEditItem Text="Against invoice" Value="0" />
                                            <dx:ListEditItem Text="In Advance" Value="1" />
                                        </Items>
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Creditor Mode" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                   
                        
                        
                         <dx:LayoutItem Caption="Customer" FieldName="FKCustomerID" Visible="false"  ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKCustomerID" runat="server" ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS"
                                        ValueType="System.Int32" ReadOnly="true" ClientEnabled="false" DropDownButton-ClientVisible="false" Width="250px">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                        <dx:LayoutItem Caption="Remarks" FieldName="Remarks" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo ID="txtRemarks" runat="server" Width="600" Height="40"></dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                       
                          
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>
   
        <div class="divrow" style="height: 10px">
        </div>
        <div style="display: table; min-width: 1000px">
            <dx:ASPxGridView runat="server" ID="GdvInvoice" AutoGenerateColumns="false" Width="1030px" ClientInstanceName="gridInvoice" 
            DataSourceID="InvoiceDS" KeyFieldName="InvoiceId" OnRowCommand="gdvInvoice_RowCommand">
            <Columns>
                 <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="250" CellStyle-HorizontalAlign="Left">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextField="JobOrderNumber" DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                        
                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="InvoiceNumber" Caption="Invoice No" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="InvoiceDate" Caption="Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
               
               <dx:GridViewDataTextColumn FieldName="NetAmount" Caption="Net Amount" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="InvoiceBalance" Caption="Balance" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
            <dx:GridViewDataColumn VisibleIndex="7" Width="60px" Caption="">
                        <DataItemTemplate>
                            <table >
                                <tr>
                                    <td>
                                        <dx:ASPxButton ID="btnSelect" runat="server" ToolTip="" Cursor="pointer" CommandName="cmdSelect" EnableViewState="false"
                                            CommandArgument='<%# Eval("InvoiceId") %>' EnableTheming="False" RenderMode="Link">
                                            <Image Url="../images/select.png"></Image>
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </DataItemTemplate>
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataColumn>
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
        <div class="divrow" style="height: 5px">
        </div>
        <div style="display: table; min-width: 1000px">
            <dx:ASPxGridView ID="GdvInvoiceSelected" runat="server" AutoGenerateColumns="False" DataSourceID="SelectedInvoiceDS" KeyFieldName="InvoiceId"
                EnableRowsCache="False" Width="1030px" ClientInstanceName="gridSelected" OnRowUpdating="GdvInvoiceSelected_RowUpdating" OnRowDeleting="GdvInvoiceSelected_RowDeleting">
                <Columns>
                    <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="250" CellStyle-HorizontalAlign="Left" ReadOnly="true">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - {1} - {2} " DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                        
                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="InvoiceNumber" Caption="Invoice No" VisibleIndex="2" CellStyle-HorizontalAlign="Left" ReadOnly="true">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="InvoiceDate" Caption="Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left" ReadOnly="true">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
               
               <dx:GridViewDataTextColumn FieldName="NetAmount" Caption="Net Amount" VisibleIndex="4" CellStyle-HorizontalAlign="Left" ReadOnly="true">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="InvoiceBalance" Caption="Balance" VisibleIndex="5" CellStyle-HorizontalAlign="Left" ReadOnly="true">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="PaidAmount" Caption="Paid Amount" FieldName="PaidAmount" VisibleIndex="6" Width="120px" >
                        <%--<EditItemTemplate>
                            <dx:ASPxTextBox ID="txtAllocatedAmt" Width="100%" runat="server" Value='<%# Eval("PaidAmount")%>'>
                                <ClientSideEvents KeyDown="function(s, e) { 
                                    if(ASPxClientUtils.GetKeyCode(e.htmlEvent) ===  ASPxKey.Tab) { gridSelected.UpdateEdit(); return ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);}                
                                    }" />
                            </dx:ASPxTextBox>
                        </EditItemTemplate>--%>
                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>

                  
                   <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Default" Width="60"
                     ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
               
            </dx:GridViewCommandColumn>
                </Columns>
                  <SettingsEditing Mode="Inline"></SettingsEditing>
            <SettingsCommandButton>
                 <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                    <EditButton Text=" "   Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                    <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                    <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                   <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
                 </SettingsCommandButton>
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="PaidAmount" SummaryType="Sum" DisplayFormat="{0:n2}" />
                </TotalSummary>
                <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                <Settings ShowFooter="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" />
                <SettingsBehavior AutoFilterRowInputDelay="50000" AllowSort="false" AllowSelectSingleRowOnly="true"  />
                <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                <ClientSideEvents EndCallback="function(s,e){if(typeof s.cpDiffAmt != 'undefined' && s.cpDiffAmt != ''){txtDiff.SetText(s.cpDiffAmt);}}" />
                <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
            </dx:ASPxGridView>
        </div>
    
    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="PaymentDS" runat="server" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        SelectMethod="GetByID" InsertMethod="Insert"  UpdateMethod="Update" OnUpdating="PaymentDS_Updating" OnUpdated="PaymentDS_Updated" 
        OnInserting="PaymentDS_Inserting" OnInserted="PaymentDS_Inserted">
         <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
     </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="InvoiceDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.InvoiceDB"
        SelectMethod="GetViewInvoicesBalanceByJobOrderId"  DataObjectTypeName="BusinessLayer.ViewInvoicesBalance"  >
         <SelectParameters>
          <asp:ControlParameter ControlID="ctl00$body$flPayment$cmbJobOrderMaster" PropertyName="Value" DefaultValue="0" Name="JobOrderMasterID" Type="Int32" />
             </SelectParameters>
     </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="SelectedInvoiceDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentDetailsDB"
        SelectMethod="GetInvoicesFromSession"  DataObjectTypeName="BusinessLayer.ViewInvoicesBalance"  UpdateMethod="UpdateToSession" DeleteMethod="DeleteToSession">
          <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="MasterId" Type="Int32" />
        </SelectParameters>
     </asp:ObjectDataSource>
       <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrderFromView"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAll" DeleteMethod="Delete"></asp:ObjectDataSource>


</asp:Content>
