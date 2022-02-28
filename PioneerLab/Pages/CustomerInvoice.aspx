<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="CustomerInvoice.aspx.cs" Inherits="PioneerLab.Pages.CustomerInvoice" %>

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
        var TotalA = 0;
        var TotalB = 0;

        function OnBatchEditEnd(s, e) {
            window.setTimeout(function () {
                TotalA = 0;
                var indicies = s.batchEditHelper.GetDataItemVisibleIndices();
                for (var i = 0; i < indicies.length; i++) {
                    var key = s.GetRowKey(indicies[i]);
                    
                    var price = s.batchEditApi.GetCellValue(indicies[i], "Price");
                    var Qty = s.batchEditApi.GetCellValue(indicies[i], "Qty");
                    var Amount = price * Qty;

                    var IsInvoiced = s.batchEditApi.GetCellValue(indicies[i], "IsInvoiced");

                    if (IsInvoiced == true) {
                        TotalA += Amount;
                        txtSRTTotal.SetText(TotalA);
                        txtInvoiceTotal.SetText(TotalA + TotalB);
                        var discount = txtDiscount.GetValue();
                        txtNetAmount.SetText(TotalA + TotalB - discount);
                        txtNetAmount.SetText(TotalA + TotalB);
                    }
                  

                }

               
            }, 10)
        }

        function OnBatchEditEndEditing(s, e) {
            window.setTimeout(function () {
                TotalB = 0;
                var indicies = s.batchEditHelper.GetDataItemVisibleIndices();
                for (var i = 0; i < indicies.length; i++) {
                    var key = s.GetRowKey(indicies[i]);
                    var DueAmount = s.batchEditApi.GetCellValue(indicies[i], "DueAmount");
                    var IsInvoiced = s.batchEditApi.GetCellValue(indicies[i], "IsInvoiced");
                    if (IsInvoiced == true)
                    {
                        TotalB += DueAmount;
                        txtInvoiceTotal.SetText(TotalA + TotalB);
                        txtTSTotal.SetText(TotalB);
                        var discount = txtDiscount.GetValue();
                        txtNetAmount.SetText(TotalA + TotalB - discount);
                    }
                }
               

            }, 10)
        }


        var curentEditingIndex;

        function OnBatchEditStartEditing(s, e) {
            lblError.SetText("");
            curentEditingIndex = e.visibleIndex;

            var IsEnabled = s.batchEditApi.GetCellValue(e.visibleIndex, "Enabled");
            var IsInvoiced = s.batchEditApi.GetCellValue(e.visibleIndex, "IsInvoiced");

            if (IsEnabled == false && IsInvoiced==false) {
                e.cancel = true;
                lblError.SetText("Time Sheet Must be Approved to be Converted!!");
            }
            //if ( IsInvoiced == true) {
            //    e.cancel = true;
            //}


        }

        function OnStartEditing(s, e) {
            //curentEditingIndex = e.visibleIndex;
            //var IsInvoiced = s.batchEditApi.GetCellValue(e.visibleIndex, "IsInvoiced");
            //if (IsInvoiced == true) {
            //    e.cancel = true;
            //}


        }
        function SetDiscountAmount(s, e) {
            var Total = txtInvoiceTotal.GetValue();
            var discount = txtDiscount.GetValue();
            var discountp = (discount * 100) / Total;

            txtDiscountP.SetNumber(discountp);
            var NetAmount = Total - discount;
            if (Total >= discount)
                txtNetAmount.SetValue(NetAmount);
            else {
                txtNetAmount.SetValue();
                txtDiscount.SetValue();
                txtDiscountP.SetValue();

            }
            }

        function SetAmount(s, e) {

            var Total = txtInvoiceTotal.GetValue();
            var discountp = txtDiscountP.GetValue();
            var discount = (discountp / 100) * Total;
            txtDiscount.SetNumber(discount);
            var discount = txtDiscount.GetValue();
            if (Total >= discount)
            txtNetAmount.SetValue(Total - discount);
            else {
                txtNetAmount.SetValue();
                txtDiscount.SetValue();
                txtDiscountP.SetValue();

            }
        }
        
        function SelectSR(s, e) {
            var S = SelectAllSR.GetValue();
            if (S == false) {
                TotalA = 0;
            }
            var gridSampleReceive = ASPxClientGridView.Cast(gridSampleReceiveTests);
            var indicies = gridSampleReceive.batchEditHelper.GetDataItemVisibleIndices();

            for (var i = 0; i < indicies.length; i++) {
                var IsInvoiced = gridSampleReceive.batchEditApi.SetCellValue(indicies[i], "IsInvoiced");
                
                    gridSampleReceive.batchEditApi.SetCellValue(indicies[i], "IsInvoiced", S);
            }
            for (var i = 0; i < indicies.length; i++) {

                var price = gridSampleReceive.batchEditApi.GetCellValue(indicies[i], "Price");
                var Qty = gridSampleReceive.batchEditApi.GetCellValue(indicies[i], "Qty");
                var Amount = price * Qty;

                var IsInvoiced = gridSampleReceive.batchEditApi.GetCellValue(indicies[i], "IsInvoiced");

                if (IsInvoiced == true) {
                    TotalA += Amount;
                  
                }


            }
            txtSRTTotal.SetText(TotalA);
            txtInvoiceTotal.SetText(TotalA + TotalB);
            var discount = txtDiscount.GetValue();
            txtNetAmount.SetText(TotalA + TotalB - discount);
            txtNetAmount.SetText(TotalA + TotalB);
           
           
             
        }
        function SelectWO(s, e) {

            var S = SelectAllWO.GetValue();
            if (S == false) {
                TotalB = 0;
            }
           
            var gridWO = ASPxClientGridView.Cast(gridWorkOrder);
            var indicies = gridWO.batchEditHelper.GetDataItemVisibleIndices();
            for (var i = 0; i < indicies.length; i++) {
                var IsEnabled = gridWO.batchEditApi.GetCellValue(indicies[i], "Enabled");
                var IsInvoiced = gridWO.batchEditApi.GetCellValue(indicies[i], "IsInvoiced");
                if (IsInvoiced != false || IsEnabled != false)
                    gridWO.batchEditApi.SetCellValue(indicies[i], "IsInvoiced", S);

            }
            for (var i = 0; i < indicies.length; i++) {
                var DueAmount = gridWO.batchEditApi.GetCellValue(indicies[i], "DueAmount");
                var IsInvoiced = gridWO.batchEditApi.GetCellValue(indicies[i], "IsInvoiced");
                if (IsInvoiced == true) {
                    TotalB += DueAmount;
                   
                }
            }
            txtInvoiceTotal.SetText(TotalA + TotalB);
            txtTSTotal.SetText(TotalB);
            var discount = txtDiscount.GetValue();
            txtNetAmount.SetText(TotalA + TotalB - discount);

        }
        function CheckSelect(s, e) {
            
            if (ASPxClientEdit.AreEditorsValid()) {
               
                gridSampleReceiveTests.UpdateEdit();
                gridWorkOrder.UpdateEdit();

                var count = 0;
                var gridSampleReceive = ASPxClientGridView.Cast(gridSampleReceiveTests);
                var indicies1 = gridSampleReceive.batchEditHelper.GetDataItemVisibleIndices();

                var gridWO = ASPxClientGridView.Cast(gridWorkOrder);
                var indicies2 = gridWO.batchEditHelper.GetDataItemVisibleIndices();


                for (var i = 0; i < indicies1.length; i++) {
                    var IsChecked = gridSampleReceive.batchEditApi.GetCellValue(indicies1[i], "IsInvoiced");

                    if (IsChecked == true) {
                        count++;
                    }
                }


                for (var i = 0; i < indicies2.length; i++) {
                    var IsChecked = gridWO.batchEditApi.GetCellValue(indicies2[i], "IsInvoiced");

                    if (IsChecked == true) {
                        count++;
                    }
                }

                if (count > 0) {
                    if (Page_ClientValidate("OnSave"))
                        e.processOnServer = true


                }
                else {
                    e.processOnServer = false;
                    alert("Pleace select item ");
                }
            }
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
            <dx:ASPxLabel ID="lblAlowUpdate" runat="server" ClientInstanceName="lblAlowUpdate" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>

            <dx:ASPxButton ID="btnSave" ValidationGroup="OnSave"  CausesValidation="true" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk"  OnClick="btnSave_Click" Style="width: 80px" AutoPostBack="false" runat="server" Text="Save">
                <ClientSideEvents Click="CheckSelect" />
            </dx:ASPxButton>

        </div>

        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" AutoPostBack="false" Style="width: 80px" OnClick="btnCancel_Click" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Text="Back">
                <ClientSideEvents Click="function(s,e){ if ( confirm('Are you sure you want to cancel all changes?') == true) {gridSampleReceiveTests.CancelEdit();gridWorkOrder.CancelEdit()}}" />
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
        <dx:ASPxFormLayout ID="flInvoice" runat="server" DataSourceID="InvoiceDS" ClientInstanceName="flInvoice">
            <Items>
                <dx:LayoutGroup ShowCaption="False" ColCount="8" Border-BorderStyle="None">
                    <Items>

                        <dx:LayoutItem Caption="Invoice Number" FieldName="InvoiceNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtInvoiceNumber" Width="120" runat="server" OnValueChanged="txtInvoiceNumber_TextChanged" OnTextChanged="txtInvoiceNumber_TextChanged" ReadOnly="true">
                                           <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Insert Invoice Number" />
                                        </ValidationSettings>
                                     
                                    </dx:ASPxTextBox>
        <dx:ASPxLabel ID="lblErrorMassage" runat="server" Text="The invoice number is present"  Visible="false" ></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption="Last Invoice Number" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtLastInvoiceNumber" Width="120" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Invoice Date" FieldName="InvoiceDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtInvoiceDate" ClientInstanceName="dtInvoiceDate" ClientEnabled="false" DropDownButton-ClientVisible="false" Width="160" runat="server" DisplayFormatString="dd MMM yyyy hh:mm tt" EditFormatString="dd MMM yyyy hh:mm tt" ReadOnly="true"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" Ref. No" FieldName="InvoiceRefNo" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtInvoiceRefNo" Width="130" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Job Order Number" FieldName="FKJobOrderMasterID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbJobOrderMaster" runat="server" ValueField="JobOrderMasterID" DataSourceID="JobOrderMasterDS" ValueType="System.Int64" Width="440px"
                                        AutoPostBack="true" TextFormatString="{0} - ({2:dd MMM yyyy}) - {3} - {4}" DropDownStyle="DropDownList"   DropDownButton-ClientVisible="false" >
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Job Order" />
                                        </ValidationSettings>
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="100" />
                                            <dx:ListBoxColumn FieldName="LPONumber" Caption="LPO Number" Width="100" />
                                            <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Customer"  ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKCustomerID" runat="server" ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS"
                                        ValueType="System.Int32" ReadOnly="true" ClientEnabled="false" DropDownButton-ClientVisible="false" Width="160px">
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project"  ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKProjectID" runat="server" ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS" 
                                        ValueType="System.Int32" ReadOnly="true" ClientEnabled="false" DropDownButton-ClientVisible="false" AutoPostBack="true" Width="130px">
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Project" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="From Date"  ColSpan="2" FieldName="InvoiceStartDate">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   <dx:ASPxDateEdit ID="dtFromdate" ClientInstanceName="dtFromdate" Width="150" DisplayFormatString="dd MMM yyyy" OnDateChanged="dtFromdate_DateChanged" AutoPostBack="false" runat="server" CssClass="textbox" >
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave"  Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select date" />
                                        </ValidationSettings>
                                </dx:ASPxDateEdit>
                                    
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="To Date"  ColSpan="2" FieldName="InvoiceEndDate">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                  <dx:ASPxDateEdit ID="dtTodate" Width="150" ClientInstanceName="dtTodate" DisplayFormatString="dd MMM yyyy" OnDateChanged="dtFromdate_DateChanged" AutoPostBack="false" runat="server" CssClass="textbox"  >
                                       <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select date" />
                                        </ValidationSettings>
                                </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                          <dx:LayoutItem Caption="Report Type"  ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <asp:CheckBoxList ID="ckbReport" runat="server">
                                      <asp:ListItem Text="Show Reported Tests" Value="Reported" Selected="True"></asp:ListItem>
                                      <asp:ListItem Text="Show Unrepoted Tests" Value="Unrepoted" Selected="True"></asp:ListItem>

                                    </asp:CheckBoxList>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem ShowCaption="False"  ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                  <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" CssClass=" btn-success fa fa-search" ClientVisible="true" Style="margin-left: 10px" Width="120 " Height="30"  ValidationGroup="savegrp"  OnClick="btnSearch_Click">
                                       <ClientSideEvents Click="function(s, e) {lpanel.Show(); e.processOnServer = true;}" />
                                </dx:ASPxButton>
                           <div>
      <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lpanel"
            Modal="True">
        </dx:ASPxLoadingPanel>
        </div>
   

      
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                           
                        <dx:LayoutItem Caption=" Sample receive tests" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxHiddenField runat="server" ID="hf" ClientInstanceName="hf"></dx:ASPxHiddenField>

                                    <dx:ASPxGridView runat="server" ID="GdvSampleReceiveTests" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridSampleReceiveTests"  OnBatchUpdate="GdvSampleReceiveTests_BatchUpdate"
                                        KeyFieldName="SampleReceiveTestID" >

                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn FieldName="JobOrderMasterID" ReadOnly="true" Caption="Job Order No" VisibleIndex="1" Width="250" CellStyle-HorizontalAlign="Left">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}"   DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ServiceSection" Caption="Service Section" Width="100" />
                                                        <dx:ListBoxColumn FieldName="MaterialDetails" Caption="Material Details" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ServicesName" Caption="Services Name" Width="100" />

                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                           
                                            <dx:GridViewDataTextColumn FieldName="SampleNo" Caption="Sample No" ReadOnly="true" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                                                <EditFormSettings Visible="False" />

                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ReceiveDate" ReadOnly="true" Caption="Receive Date" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                                                <PropertiesTextEdit DisplayFormatString="dd MMM yyyy"></PropertiesTextEdit>
                                                <EditFormSettings Visible="False" />

                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" ReadOnly="true" Name="FKTestID" Caption="Services Name" VisibleIndex="4"  Width="150">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" ReadOnly="true" Caption="Std No" VisibleIndex="5" >
                                                <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>

                                            <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" ReadOnly="true" Caption="Unit" VisibleIndex="6" >
                                                <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Price" ReadOnly="true" Name="Price" Caption="Price"  VisibleIndex="7" >
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Qty" ReadOnly="true" Name="Qty" Caption="Qty" VisibleIndex="8">
                                                <PropertiesSpinEdit NumberType="Integer" DisplayFormatString="N0"></PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataCheckColumn FieldName="IsChecked" Name="IsChecked"  ReadOnly="true" Caption="Checked" Width="60" VisibleIndex="9" CellStyle-HorizontalAlign="Center">
                                            </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataCheckColumn FieldName="IsApproved" Name="IsApproved" ReadOnly="true" Caption="Approved" Width="60" VisibleIndex="10" CellStyle-HorizontalAlign="Center">
                                            </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataCheckColumn FieldName="IsInvoiced" Name="IsInvoiced" Caption="Convert" Width="60" VisibleIndex="11" CellStyle-HorizontalAlign="Center">
                                            </dx:GridViewDataCheckColumn>
                                        </Columns>
                                        <SettingsCommandButton>
                                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                            <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                            <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                        </SettingsCommandButton>
                                        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
                                        <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom" />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" AllowSort="false"/>
                                        <Styles StatusBar-CssClass="statusBar" />
                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                        <ClientSideEvents BatchEditEndEditing="OnBatchEditEnd" BatchEditStartEditing="OnStartEditing"/>
                                        <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                           <dx:LayoutItem ShowCaption="False" CaptionStyle-Font-Bold="true"  HorizontalAlign="Right" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   
                                    <dx:ASPxCheckBox ID="SelectAllSR" runat="server" Text="Select All" ClientInstanceName="SelectAllSR" TextAlign="Right"  >
                                        <ClientSideEvents  CheckedChanged ="SelectSR" />
                                    </dx:ASPxCheckBox>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Total" CaptionStyle-Font-Bold="true" FieldName="SRTTotal" HorizontalAlign="Right" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                      <dx:ASPxSpinEdit ID="txtSRTTotal" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtSRTTotal" runat="server" ReadOnly="true" ClientEnabled="false">
                                                                </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem ColSpan="8" />

                        <dx:LayoutItem Caption="Work order List" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem ShowCaption="False" CaptionStyle-Font-Bold="true"  HorizontalAlign="Right" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="lblError" runat="server" Text="" ForeColor="OrangeRed" Font-Bold="true" ClientInstanceName="lblError"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxHiddenField runat="server" ID="ASPxHiddenField1" ClientInstanceName="hf"></dx:ASPxHiddenField>

                                    <dx:ASPxGridView runat="server" ID="GdvWorkOrderHistory" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder"
                                       KeyFieldName="WorkOrderID" OnBatchUpdate="GdvWorkOrderHistory_BatchUpdate"  >

                                        <Columns>
                                             <dx:GridViewDataTextColumn FieldName="WorkOrderNo" ReadOnly="true" Caption="Work Order No" VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="2" Width="250" CellStyle-HorizontalAlign="Left" ReadOnly="true">
                                                <PropertiesComboBox ValueField="JobOrderDetailsID"  TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}" DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ServiceSection" Caption="Service Section" Width="100" />
                                                        <dx:ListBoxColumn FieldName="MaterialDetails" Caption="Material Details" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ServicesName" Caption="Services Name" Width="100" />

                                                    </Columns>
                                                </PropertiesComboBox>
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                           
                                            <dx:GridViewDataTextColumn FieldName="WorkOrderID" ReadOnly="true" Name="WorkOrderID" Caption="" VisibleIndex="3" Width="0" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="SiteName" ReadOnly="true" Caption="Site Name" VisibleIndex="4" Width="150" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                                                <PropertiesDateEdit DisplayFormatString="dd MMM yyyy">
                                                </PropertiesDateEdit>
                                            </dx:GridViewDataDateColumn>
                                            <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date" Width="100" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                                                <PropertiesDateEdit DisplayFormatString="dd MMM yyyy">
                                                </PropertiesDateEdit>
                                            </dx:GridViewDataDateColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="DueAmount"  ReadOnly="true" Name="DueAmount" Caption="Due amount" VisibleIndex="7" Width="100" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> 
                                                <PropertiesSpinEdit DecimalPlaces="2" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                    AllowMouseWheel="false">
                                                 
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                           <%-- <dx:GridViewCommandColumn Name="Showdetails" Caption="Show details" Width="80px" VisibleIndex="1" meta:resourcekey="GridViewDataColumnResource1">
                                                 <CustomButtons>
                                                            <dx:GridViewCommandColumnCustomButton ID="btnPaySlip" Text=" ">
                                                                 <Image Url="../images/payslip_icon.png" Width="20" Height="20" ToolTip="View" ></Image>
                                                            </dx:GridViewCommandColumnCustomButton>
                                                        </CustomButtons>
                                               
                                            </dx:GridViewCommandColumn>--%>
                                            <dx:GridViewDataCheckColumn FieldName="IsChecked"  Name="IsChecked" ReadOnly="true" Caption="Checked" Width="60" VisibleIndex="8" CellStyle-HorizontalAlign="Center">
                                            </dx:GridViewDataCheckColumn>

                                            <dx:GridViewDataCheckColumn FieldName="IsApproved" ReadOnly="true" Caption="Approved" Width="80" VisibleIndex="9" CellStyle-HorizontalAlign="Center">
                                            </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataCheckColumn FieldName="IsInvoiced" Name="IsInvoiced" Caption="Convert" Width="60" VisibleIndex="10" CellStyle-HorizontalAlign="Center">
                                            </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataCheckColumn Name="Enabled" VisibleIndex="0" FieldName="IsEnabled" Width="0">
                                            </dx:GridViewDataCheckColumn>
                                        </Columns>
                                        <SettingsCommandButton>
                                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                            <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                            <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                        </SettingsCommandButton>
                                        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
                                        <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom" />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" AllowSort="false"/>
                                        <Styles StatusBar-CssClass="statusBar" />
                                        <ClientSideEvents BatchEditEndEditing="OnBatchEditEndEditing" BatchEditStartEditing="OnBatchEditStartEditing"   />
                                        <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  popupPaySlip.Show();  popupPaySlip.PerformCallback(key);}" />
                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
           <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
                                    </dx:ASPxGridView>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>

                        </dx:LayoutItem>
                         <dx:EmptyLayoutItem ColSpan="8" />

                          <dx:LayoutItem ShowCaption="False" CaptionStyle-Font-Bold="true"  HorizontalAlign="Right" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   
                                    <dx:ASPxCheckBox ID="SelectAllWO" runat="server" Text="Select All" ClientInstanceName="SelectAllWO" TextAlign="Right"  >
                                        <ClientSideEvents  CheckedChanged ="SelectWO" />
                                    </dx:ASPxCheckBox>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    
                      
                        <dx:LayoutItem Caption="Total " CaptionStyle-Font-Bold="true" FieldName="TSTotal" HorizontalAlign="Right" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                     <dx:ASPxSpinEdit ID="txtTSTotal" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtTSTotal" runat="server" ReadOnly="true" ClientEnabled="false">
                                                                </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem ColSpan="8" />

                          <dx:LayoutItem Caption="Provide Description " CaptionStyle-Font-Bold="true" FieldName="ProvideDescription"  ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                     <dx:ASPxTextBox ID="txtDescription" SpinButtons-ShowIncrementButtons="false" Width="750"
                                                                    AllowMouseWheel="false" runat="server" >
                                         <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Enter Description !" />
                                        </ValidationSettings>
                                                                </dx:ASPxTextBox>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        

                       
                        <dx:EmptyLayoutItem ColSpan="8" />


                        <dx:LayoutItem Caption="Invoice Total" CaptionStyle-Font-Bold="true" ColSpan="2" FieldName="InvoiceTotal">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtInvoiceTotal" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtInvoiceTotal" runat="server" ReadOnly="true" ClientEnabled="false">
                                                                </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        

                        <dx:LayoutItem Caption="Discount" CaptionStyle-Font-Bold="true" ColSpan="1" FieldName="Disount" >
                            <LayoutItemNestedControlCollection>

                                <dx:LayoutItemNestedControlContainer>
                                    <table>
                                        <tr>
                                            <td style="width:80px">
                                                <dx:ASPxSpinEdit ID="txtDiscount" ClientInstanceName="txtDiscount" runat="server"  SpinButtons-ShowIncrementButtons="false"
                                                    AllowMouseWheel="false" NumberType="Float" Width="70" >
                                                    <ClientSideEvents ValueChanged="SetDiscountAmount" />
                                                </dx:ASPxSpinEdit>
                                            </td>
                                            
                                            <td style="width: 70px">
                                                  <dx:ASPxSpinEdit ID="txtDiscountP" ClientInstanceName="txtDiscountP" runat="server"  SpinButtons-ShowIncrementButtons="false"
                                                    AllowMouseWheel="false"   Width="60">
                                                    <ClientSideEvents ValueChanged="SetAmount" />
                                                </dx:ASPxSpinEdit>
                                            </td>
                                            <td style="width:20px">
                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Width="20" Text="%"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                    </table>

                                </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        

                        <dx:LayoutItem Caption="Net Amount" CaptionStyle-Font-Bold="true"  ColSpan="2" FieldName="NetAmount">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                      <dx:ASPxSpinEdit ID="txtNetAmount" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtNetAmount" runat="server" ReadOnly="true" ClientEnabled="false">
                                                                </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                          <dx:LayoutItem ShowCaption="False" CaptionStyle-Font-Bold="true"  HorizontalAlign="Right" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="Error" runat="server" Text="" ForeColor="OrangeRed" Font-Bold="true" ClientInstanceName="Error"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="" Font-Bold="true" Font-Size="Large" ForeColor="red" ClientInstanceName="ASPxLabel2"></dx:ASPxLabel>
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
        
        <dx:ASPxPopupControl ID="popupPaySlip" runat="server" CloseAction="CloseButton"
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" OnWindowCallback="popupPaySlip_WindowCallback" AllowDragging="True" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Pay Slip" ClientInstanceName="popupPaySlip">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <div class="divrow">
                    </div>
                    <div class="divrow" id="contentDiv">
                        <dx:ASPxCallbackPanel ID="cpnl" runat="server" ClientInstanceName="cpnl">
                            <PanelCollection>
                                <dx:PanelContent>
                                    <dx:ASPxFormLayout ID="flTimesheetPaySlip" runat="server" DataSourceID="TimesheetPaySlipDS" ClientInstanceName="flTimesheetPaySlip">
                                        <Items>
                                            <dx:LayoutGroup Caption="Time Sheet Pay Slip" ColCount="4">
                                                <Items>

                                                    <dx:LayoutItem Caption="Job Order Number" FieldName="JobOrderMasterID" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxComboBox ID="cmbFKJobOrderMasterID" runat="server" ValueField="JobOrderMasterID" DataSourceID="JobOrderMasterDS" ValueType="System.Int64" Width="250px"
                                                                    AutoPostBack="true" TextFormatString="{0} - ({2:dd MMM yyyy}) - {1}" DropDownStyle="DropDownList" ReadOnly="true" DropDownButton-ClientVisible="false">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="100" />
                                                                        <dx:ListBoxColumn FieldName="LPONumber" Caption="LPO Number" Width="100" />
                                                                        <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                                                        <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                                                        <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                                                    </Columns>

<DropDownButton ClientVisible="False"></DropDownButton>
                                                                </dx:ASPxComboBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="WorkOrder No" FieldName="WorkOrderNo" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtWorkOrderNo" runat="server" ClientInstanceName="txtWorkOrderNo" ClientEnabled="false" ReadOnly="true"></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Start Date" FieldName="StartDate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxDateEdit ID="dtStartDate" ClientInstanceName="dtStartDate" ClientEnabled="false" runat="server" ReadOnly="true" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="End Date" FieldName="EndDate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxDateEdit ID="dtEndDate" ClientInstanceName="dtEndDate" ClientEnabled="false" runat="server" ReadOnly="true" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>

                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="No. of working days" FieldName="NoOfWorkingDays" ColSpan="4">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtNoOfWorkingDays" runat="server" ClientInstanceName="txtNoOfWorkingDayse" ReadOnly="true" ClientEnabled="false"></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>


                                                    <dx:LayoutItem Caption="Regular Working Hours" FieldName="NormalWorkingHours" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtNormalWorkingHours" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                                    AllowMouseWheel="false" NumberType="Integer" ClientInstanceName="txtNormalWorkingHours" ReadOnly="true" runat="server" ClientEnabled="false">
<SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Hourly Rate" FieldName="HourlyRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtRate" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtHourlyRate" runat="server" ReadOnly="true" ClientEnabled="false">
<SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Ramadan Working Hours" FieldName="RamadanWorkingHours" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtRamadanWorkHrs" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                                    AllowMouseWheel="false" NumberType="Integer" ClientInstanceName="txtRamadanWorkHrs " ReadOnly="true" runat="server" ClientEnabled="false">
<SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Hourly Rate" FieldName="HourlyRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtHourlyRate" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtHourlyRate" runat="server" ReadOnly="true" ClientEnabled="false">
                                                                          <SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Extra Working Hour Rate" FieldName="OTWorkingHours" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtOTWorkingHours" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                                    AllowMouseWheel="false" NumberType="Integer" ClientInstanceName="txtOTWorkingHours" ReadOnly="true" runat="server" ClientEnabled="false">
                                                                                <SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Rate" FieldName="OTRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtOTRate" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtOTRate" runat="server" ReadOnly="true" ClientEnabled="false">
                                                                    <SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Total Amount" FieldName="DueAmount" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtDueAmount" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                                    AllowMouseWheel="false" NumberType="Integer" ClientInstanceName="txtDueAmount" ReadOnly="true" runat="server" ClientEnabled="false">
                                                                 <SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                  
                                                </Items>
                                            </dx:LayoutGroup>

                                        </Items>
                                    </dx:ASPxFormLayout>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxCallbackPanel>
                    </div>

                    <div style="width: 100%; height: 5px"></div>

                    <div>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <%--<dx:ASPxButton ID="btnUpdateWorkOrder" runat="server" Text="Update" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-save" OnClick="btnUpdate_Click">
                        <ClientSideEvents Click="function(s, e) { popTestLists.PerformCallback(); }" />
                    </dx:ASPxButton>--%>
                </div>
            </FooterTemplate>
            <%--<ClientSideEvents PopUp="function(s, e) { popTestLists.PerformCallback(); }" />--%>
        </dx:ASPxPopupControl>
    </div>


    <asp:ObjectDataSource ID="SampleReceiveTestsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveTestListDB"
        DataObjectTypeName="BusinessLayer.ViewSampleReceiveTests" SelectMethod="GetViewSampleReceiveTestsByJobOrderMasterID" >
        <SelectParameters>
            <asp:ControlParameter ControlID="flInvoice$dtFromdate" PropertyName="Value"  Name="FromDate" Type="DateTime" />
            <asp:ControlParameter ControlID="flInvoice$dtTodate" PropertyName="Value"  Name="ToDate" Type="DateTime" />
            <asp:ControlParameter ControlID="flInvoice$cmbJobOrderMaster" PropertyName="Value" DefaultValue="0" Name="JobOrderMasterID" Type="Int32" />
             <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />

        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="PriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>


    <asp:ObjectDataSource ID="WorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderList" SelectMethod="GetAllWorkOrderbyJobOrderMasterID"  >
        <SelectParameters>
              <asp:ControlParameter ControlID="flInvoice$dtFromdate" PropertyName="Value"  Name="FromDate" Type="DateTime" />
            <asp:ControlParameter ControlID="flInvoice$dtTodate" PropertyName="Value"  Name="ToDate" Type="DateTime" />
            <asp:ControlParameter ControlID="ctl00$body$flInvoice$cmbJobOrderMaster" PropertyName="Value" DefaultValue="0" Name="JobOrderMasterID" Type="Int32" />
             <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrderFromView"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAll" DeleteMethod="Delete"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="InvoiceDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.InvoiceDB"
      SelectMethod="GetByID" >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>

    
    <asp:ObjectDataSource ID="TimesheetPaySlipDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        SelectMethod="GetByIdFromView">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblQid" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ProjectsListDS" runat="server" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

</asp:Content>
