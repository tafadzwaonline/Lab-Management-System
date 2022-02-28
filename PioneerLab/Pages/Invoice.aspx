<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="Invoice.aspx.cs" Inherits="PioneerLab.Pages.Invoice" %>

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
            <li class="active" id="menulink">Customer Invoice</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Customer Invoice</h1>
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

              <dx:ASPxButton ID="btnSave" ValidationGroup="savegrp" CausesValidation="true" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" Style="width: 80px" AutoPostBack="false"  runat="server"  Text="Save">
                   <ClientSideEvents Click="function(s,e) {gdvJobOrderWorkSheet.UpdateEdit();}" />
              </dx:ASPxButton>
                                  
            </div>
                           
            <div class="btn-group" role="group" aria-label="First group">
               <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" AutoPostBack="false" Style="width: 80px" OnClick="btnCancel_Click" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Text="Back">
                     <ClientSideEvents Click="function(s,e){ if ( confirm('Are you sure you want to cancel all changes?') == true) {gdvJobOrderWorkSheet.CancelEdit()}}" />
                  </dx:ASPxButton>
             </div>
    </div>
    <div class="row" style="height: 10px">

    </div>

         <div class="btn-toolbar">
        <dx:ASPxFormLayout ID="flInvoice" runat="server" DataSourceID="InvoiceDS" ClientInstanceName="flInvoice" >
            <Items>
                <dx:LayoutGroup ShowCaption="False" ColCount="8" Border-BorderStyle="None">
                    <Items>
                       
                        <dx:LayoutItem Caption="Invoice Number" FieldName="InvoiceNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtInvoiceNumber" Width="150" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Date" FieldName="InvoiceDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtInvoiceDate" ClientInstanceName="dtInvoiceDate" ClientEnabled="false" DropDownButton-ClientVisible="false" Width="200" runat="server" DisplayFormatString="dd/MM/yyyy hh:mm tt" EditFormatString="dd/MM/yyyy hh:mm tt" ReadOnly="true"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption=" Ref. No" FieldName="InvoiceRefNo" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtInvoiceRefNo" Width="200" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Customer" FieldName="FKCustomerID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKCustomerID" runat="server" Width="390" ValueField="CustomerID" TextField="CustomerName"
                                        DataSourceID="CustomersListDS" ValueType="System.Int32"  >
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                       
                          <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                         <dx:LayoutItem Caption=" Sample receive tests"  ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxHiddenField runat="server" ID="hf" ClientInstanceName="hf"></dx:ASPxHiddenField>

                                    <dx:ASPxGridView runat="server" ID="GdvSampleReceiveTests" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridSampleReceiveTests"
                                                DataSourceID="SampleReceiveTestsDS" KeyFieldName="SampleReceiveTestID">
               
                                           <Columns>
                                                    <dx:GridViewDataComboBoxColumn FieldName="JobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="250" CellStyle-HorizontalAlign="Left">
                                                         <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - ({2:dd-MM-yyyy}) - {1}"  DataSourceID="JobOrderMasterDS" Width="250px" ValueType="System.Int64">
                                                             <Columns>
                                                                                <dx:ListBoxColumn FieldName="JobOrderMasterID" Caption="Job Order No" Width="100" />
                                                                                <dx:ListBoxColumn FieldName="LPONumber" Caption="LPO Number" Width="100" />
                                                                                <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                                                                <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                                                                <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                                                            </Columns>
                                                        </PropertiesComboBox>
                                                        <EditFormSettings Visible="False" />

                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SampleNo" Caption="Sample No" VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                                                        <EditFormSettings Visible="False" />

                                                    </dx:GridViewDataTextColumn>
                                                     <dx:GridViewDataTextColumn FieldName="SamplingDate" Caption="Sample Date" VisibleIndex="1" Width="150" CellStyle-HorizontalAlign="Left">
                                                         <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy" ></PropertiesTextEdit>
                                                        <EditFormSettings Visible="False" />

                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Name="FKTestID"  Caption="Services Name" VisibleIndex="1" ReadOnly="true" Width="150">
                                                                                    <PropertiesComboBox ValueField="TestID" TextField="TestName"  DataSourceID="TestsListDS" DropDownRows="1">
                                                                                        <DropDownButton ClientVisible="false"></DropDownButton>
                                                                                    </PropertiesComboBox>
                                                        <EditFormSettings Visible="False" />

                                                     </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Std No" VisibleIndex="1" ReadOnly="true">
                                                     <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                                                       <DropDownButton ClientVisible="false"></DropDownButton>
                                                       </PropertiesComboBox>
                                                        <EditFormSettings Visible="False" />
                                                      </dx:GridViewDataComboBoxColumn>
                  
                                                    <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" VisibleIndex="1" ReadOnly="true">
                                                            <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                                                     <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                                               <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                                       </ValidationSettings>
                                                             </PropertiesComboBox>
                                                                <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataComboBoxColumn>
               

                                                    <dx:GridViewDataSpinEditColumn FieldName="Qty" Name="Qty" Caption="Qty" VisibleIndex="1">
                                                                     <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                                         AllowMouseWheel="false" >
                                                                                        <%--<ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings>--%>
                                                                           </PropertiesSpinEdit>
                                                        <EditFormSettings Visible="False" />

                                                                 </dx:GridViewDataSpinEditColumn>
                                          
              
                
                                                   <dx:GridViewDataCheckColumn FieldName="IsChecked" Name="IsChecked" ReadOnly="true"  Caption="Checked" Width="60" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                            </dx:GridViewDataCheckColumn>
                                                      <dx:GridViewDataCheckColumn FieldName="IsApproved" Name="IsApproved"  ReadOnly="true"   Caption="Approved" Width="60" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                            </dx:GridViewDataCheckColumn>
                                                      <dx:GridViewDataCheckColumn FieldName="IsInvoiced" Name="IsInvoiced"   Caption="Convert" Width="60" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                            </dx:GridViewDataCheckColumn>
                                                </Columns>
                                                <SettingsCommandButton>
                                                    <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                                    <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                                    <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                                </SettingsCommandButton>
                                                <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible" />
                                                <SettingsEditing Mode="Batch"  NewItemRowPosition="Bottom" />
                                                <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                                <SettingsBehavior ConfirmDelete="True" ColumnResizeMode="Control"/>
                                                 <Styles StatusBar-CssClass="statusBar" />

                                            </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />

                        <dx:LayoutItem Caption="Total Quotation" CaptionStyle-Font-Bold="true" HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="lblTotalQuotaion" runat="server" Text="" Font-Bold="true" ClientInstanceName="lblTotalQuotaion"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                          <dx:EmptyLayoutItem ColSpan="8"/>
                        
                        <dx:LayoutItem Caption="Work order List"  ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem ShowCaption="False" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxHiddenField runat="server" ID="ASPxHiddenField1" ClientInstanceName="hf"></dx:ASPxHiddenField>
                                    <dx:ASPxGridView runat="server" ID="GdvWorkOrderHistory" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder"
                                            DataSourceID="WorkOrderDS" KeyFieldName="WorkOrderID" >
               
                                           <Columns>
               
                                                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="1" Width="350" CellStyle-HorizontalAlign="Left">
                                                     <PropertiesComboBox ValueField="JobOrderDetailsID" TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}"  DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                         <Columns>
                                                                            <dx:ListBoxColumn FieldName="JobOrderMasterID" Caption="Job Order No" Width="60" />
                                                                            <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                                            <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                                            <dx:ListBoxColumn FieldName="ServiceSection" Caption="Service Section" Width="100" />
                                                                            <dx:ListBoxColumn FieldName="MaterialDetails" Caption="Material Details" Width="100" />
                                                                            <dx:ListBoxColumn FieldName="ServicesName" Caption="Services Name" Width="100" />

                                                                        </Columns>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="Work Order No" VisibleIndex="1" Width="150" CellStyle-HorizontalAlign="Left">
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn FieldName="SiteName" Caption="Site Name" VisibleIndex="1" Width="150" CellStyle-HorizontalAlign="Left">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="120" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                                         <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" >
                                                     </PropertiesDateEdit>
                                                     </dx:GridViewDataDateColumn>
                                               <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date"  Width="120" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                                                     <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" >
                                                     </PropertiesDateEdit>  
                                               </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataCheckColumn FieldName="IsChecked" ReadOnly="true" Caption="Checked" Width="60" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                        </dx:GridViewDataCheckColumn>
                
                                                 <dx:GridViewDataCheckColumn FieldName="IsApproved" ReadOnly="true" Caption="Approved" Width="80" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                                                        </dx:GridViewDataCheckColumn>
                 <dx:GridViewDataCheckColumn FieldName="IsInvoiced" Name="IsInvoiced"   Caption="Convert" Width="60" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                            </dx:GridViewDataCheckColumn>
                                              
                                            </Columns>
                                            <SettingsCommandButton>
                                                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                            </SettingsCommandButton>
                                            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible" />
                                            <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom" />
                                            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                            <SettingsBehavior ConfirmDelete="True" ColumnResizeMode="Control"/>
                                                 <Styles StatusBar-CssClass="statusBar" />

                                        </dx:ASPxGridView>
                                    
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                             <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem  />

                        <dx:LayoutItem Caption="Total Quotation" CaptionStyle-Font-Bold="true" HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="" Font-Bold="true" ClientInstanceName="lblTotalQuotaion"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    
                        <dx:EmptyLayoutItem  ColSpan="8"/>
                    

                        <dx:LayoutItem Caption="Total Quotation" CaptionStyle-Font-Bold="true" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="" Font-Bold="true" ClientInstanceName="lblTotalQuotaion"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        
                        <dx:LayoutItem Caption="Total Quotation" CaptionStyle-Font-Bold="true" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="" Font-Bold="true" ClientInstanceName="lblTotalQuotaion"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        
                        <dx:LayoutItem Caption="Total Quotation" CaptionStyle-Font-Bold="true" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="" Font-Bold="true" ClientInstanceName="lblTotalQuotaion"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
             </div>
    <div>
    </div>
     <div>
    </div>
  
  
      <asp:ObjectDataSource ID="SampleReceiveTestsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveTestListDB"
        DataObjectTypeName="BusinessLayer.SampleReceiveTestList" SelectMethod="GetViewSampleReceiveTestsByCustomer" >
           <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flInvoice$cmbFKCustomerID" PropertyName="Value" DefaultValue="0" Name="FKCustomerID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="PriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>


     <asp:ObjectDataSource ID="WorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderList" SelectMethod="GetAllWorkOrderbyCustomer" >
          <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flInvoice$cmbFKCustomerID" PropertyName="Value" DefaultValue="0" Name="FKCustomerID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrderFromView"></asp:ObjectDataSource>
 
    <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAllPending" DeleteMethod="Delete"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="InvoiceDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.InvoiceDB"
        DataObjectTypeName="BusinessLayer.Invoice" SelectMethod="GetAll" ></asp:ObjectDataSource>

        <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>

       <asp:ObjectDataSource ID="ApprovedJobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAllApproved" DeleteMethod="Delete"></asp:ObjectDataSource>
       
       <asp:ObjectDataSource ID="ExpiredJobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAllExpired" DeleteMethod="Delete"></asp:ObjectDataSource>
       
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>
</asp:Content>
