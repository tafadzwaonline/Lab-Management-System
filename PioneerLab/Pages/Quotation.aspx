<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="Quotation.aspx.cs" Inherits="PioneerLab.Pages.Quotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .statusBar a:first-child {
            display: none;
        }

        .statusBar {
            display: none;
        }
    </style>
    <script>
        window.onbeforeunload = confirmExit;
        function confirmExit() {
            return "You are about to exit the system! , Are you sure you want to leave now?";
        }
        $(function () {
            $("a").click(function () {
                window.onbeforeunload = null;
            });
            $("input").click(function () {
                window.onbeforeunload = null;
            });
        });
    </script>
    <script>
        var nextRowIndex = null;
        var columnIndex;
        function GetNextRowIndex() {
            var visibleIndices = GetGridVisibleIndices();

            var oldIndices = visibleIndices.filter(function (entry) { return entry >= 0 }).sort(function (a, b) { return a - b });
           // var newIndices = visibleIndices.filter(function (entry) { return entry < 0 }).sort(function (a, b) { return b - a });

            if (currentRowIndex >= 0) {
                var arrayIndex = oldIndices.findIndex(function (entry) { return entry > currentRowIndex; });
               //alert(arrayIndex);

                //if (arrayIndex == -1) {
                //    arrayIndex = newIndices.findIndex(function (entry) { return entry < 0; });
                //    //alert(arrayIndex);

                //    if (arrayIndex != -1)
                //        nextRowIndex = newIndices[arrayIndex];
                //}
                //else {
                nextRowIndex = oldIndices[arrayIndex];
               // alert(nextRowIndex);
                    topRowIndex = oldIndices[oldIndices.length - 1];
                //}
            }
            else {
                var arrayIndex = newIndices.findIndex(function (entry) { return entry < currentRowIndex; });
                if (arrayIndex != -1)
                    nextRowIndex = newIndices[arrayIndex];
            }
            //alert(nextRowIndex)
            return nextRowIndex;

        }

        function GetGridVisibleIndices() {
            var grid = ASPxClientGridView.Cast(gridQuotationDetailsList);
            var indicies = grid.batchEditHelper.GetDataItemVisibleIndices();
            var visibleIndicies = [];

            indicies.forEach(function (entry) {
                var key = grid.GetRowKey(entry);
                visibleIndicies.push(entry);
            });
            //return indicies;

            return visibleIndicies
        }
        function OnDescKeyDown(s, e) {
            if (ASPxClientUtils.GetKeyCode(e.htmlEvent) == ASPx.Key.Tab || ASPxClientUtils.GetKeyCode(e.htmlEvent) == ASPx.Key.Enter) {

                var nextRowIndex = GetNextRowIndex();
              
                window.setTimeout(function () {
                    gridQuotationDetailsList.batchEditApi.StartEdit(nextRowIndex, 9);
                }, 100);
               
                    if (nextRowIndex == topRowIndex)
                        cancelEndEdit = true;                    
            }
        }

        var rowIndex, colIndex;
        function OnInit(s, e) {
            //alert();
            //var grid = ASPxClientGridView.Cast(gridQuotationDetailsList);
            //var readOnlyIndexes = grid.cpReadOnlyColumns;
            //ASPxClientUtils.AttachEventToElement(s.GetMainElement(), "keydown", function (event) {
            //    //alert(event.keyCode);
            //    if (event.keyCode == 13) {
            //        if (ASPxClientUtils.IsExists(columnIndex) && ASPxClientUtils.IsExists(rowIndex)) {
            //            ASPxClientUtils.PreventEventAndBubble(event);
            //            if (rowIndex < grid.GetVisibleRowsOnPage() + grid.GetTopVisibleIndex() - 1)
            //                rowIndex++;
            //            else {
            //                rowIndex = grid.GetTopVisibleIndex();
            //                if (columnIndex < grid.GetColumnCount() - 1)
            //                    columnIndex++;
            //                else
            //                    columnIndex = 0;
            //                while (readOnlyIndexes.indexOf(columnIndex) > -1)
            //                    columnIndex++;
            //            }
            //           // alert(columnIndex);
            //            grid.batchEditApi.StartEdit(rowIndex, 9);
            //        }
            //    }
            //});
        }

    </script>
    <script type="text/javascript">

        var curentEditingIndex;
        var lastTest = null;
        var currentRowIndex = 0;
        var topRowIndex = 0;

        function OnBatchEditStartEditing(s, e) {
            
            rowIndex = e.visibleIndex
            columnIndex = e.focusedColumn.index
            currentRowIndex = e.visibleIndex;
            columnIndex = e.focusedColumn.index
           // alert(currentRowIndex);
            curentEditingIndex = e.visibleIndex;
            var currentTest = gridQuotationDetailsList.batchEditApi.GetCellValue(curentEditingIndex, "FKTestID");
            var UnitTypes = gridQuotationDetailsList.batchEditApi.GetCellValue(curentEditingIndex, "UnitType");
            if (UnitTypes == 1) {


                if (e.focusedColumn.fieldName == "Price" || e.focusedColumn.fieldName == "MinQty" || e.focusedColumn.fieldName == "FKPriceUnitID") {
                    e.cancel = true;
                }

            }

            //if (currentTest != lastTest && e.focusedColumn.fieldName == "FKPriceUnitID" && currentTest != null) {
            if (e.focusedColumn.fieldName == "FKPriceUnitID" && currentTest != null) {
                lastTest = currentTest;
                RefreshData(currentTest);
            }
            if (e.focusedColumn.fieldName == "FKTestID") {
                e.cancel = true;
            }




        }

        function OnBatchEditEndEditing(s, e) {
            window.setTimeout(function () {
               
                var Total = 0;
                // alert(Total);
                var indicies = s.batchEditHelper.GetDataItemVisibleIndices();
                for (var i = 0; i < indicies.length; i++) {
                    var key = s.GetRowKey(indicies[i]);
                    var price = s.batchEditApi.GetCellValue(indicies[i], "Price");
                    //alert(price);
                    Total += price;
                }
                
                //alert(Total);
                //alert(cbShowTotal.GetChecked());
                if (cbShowTotal.GetChecked() == true) {
                    lblTotalQuotaion.SetText(Total);
                }
            }, 10)
        }

        function getTotal(s, e) {
            var grid = ASPxClientGridView.Cast(gridQuotationDetailsList);
            var indicies = grid.batchEditHelper.GetDataItemVisibleIndices();


            var Total = 0;
            for (var i = 0; i < indicies.length; i++) {
                var price = grid.batchEditApi.GetCellValue(indicies[i], "Price");
                Total += price;
                //alert(Total);
            }
            // document.getElementById("lblTotalQuotaion").value(Total);
            lblTotalQuotaion.SetText(Total);

        }
        function RefreshData(value) {
            hf.Set("CurrentTest", value);
            PriceUnitEditor.PerformCallback();
        }

        function OnRowClick(s,e) {
            var key = s.GetRowKey(e.visibleIndex)
         
            Qid.SetValue(key);
            popupWorkOrder.PerformCallback(key);
           // alert();
        }
      
        function SetPrice(s, e) {

            var DefaultPrice = s.GetSelectedItem().GetColumnText('DefaultPrice');
            var MinimumPrice = s.GetSelectedItem().GetColumnText("MinimumPrice");
           var UnitType = s.GetSelectedItem().GetColumnText('UnitType');
            gridQuotationDetailsList.batchEditApi.SetCellValue(curentEditingIndex, "MinPrice", MinimumPrice);
            gridQuotationDetailsList.batchEditApi.SetCellValue(curentEditingIndex, "DefPrice", DefaultPrice);
            gridQuotationDetailsList.batchEditApi.SetCellValue(curentEditingIndex, "UnitType", UnitType);


            btnWorkOrder = "btn" + curentEditingIndex;
            if (UnitType == 1) {
                gridQuotationDetailsList.batchEditApi.SetCellValue(curentEditingIndex, "Price", "");
                gridQuotationDetailsList.batchEditApi.SetCellValue(curentEditingIndex, "MinQty", "");

                //var commandColumnCell = document.getElementById(gridQuotationDetailsList.ClientInstanceName + "_DXDataRow" + curentEditingIndex);
                //var commandButtons = commandColumnCell.getElementById("btnWorkOrder");
                //commandButtons[1].style.visibility = true;

                //////var rowId = gridQuotationDetailsList.name + '_DXDataRow' + curentEditingIndex;
                //////alert(rowId);
                //////var rowElement = document.getElementById(rowId);
                //////var elements = rowElement.getElementsByClassName('glyphicon glyphicon-list-alt');
                //////alert(elements);
                //////alert(elements.length);
                //////if (elements && elements.length === 1) {
                //////    var copyButton = elements[0];
                //////    alert(copyButton);
                //////    copyButton.style.SetVisible = true ? 'inline-block' : 'none';
                //////}
                
               // alert(elements);

                //var Command = gridQuotationDetailsList.batchEditApi.GetRowKey(curentEditingIndex, "Command");
                //alert(Command);
                //Command.getElementsByName(btnWorkOrder).ClientVisible = true;
                ////btnWorkOrder.ClientVisible = "True";
                //Command.getElementsByName(btnWorkOrder).style.visibility = "visible"
            }
            else {
                alert(btnWorkOrder);

                btnWorkOrder.ClientVisible = "false";
            }


            //var commandColumnCell = document.getElementById(gridQuotationDetailsList.ClientInstanceName + "_DXDataRow" + curentEditingIndex);
            //alert(commandColumnCell);
            //var commandButtons = commandColumnCell.getElementById("btnWorkOrder");
            //commandButtons[1].style.display = true;


        }

        function SetExpiryDate() {
            var EntryDate = dtEntryDate.GetDate();
            var ExpiryDays = txtExpireIn.GetValue();

            var ExpiryDate = new Date(
                                 EntryDate.getFullYear(),
                                 EntryDate.getMonth(),
                                 EntryDate.getDate() + ExpiryDays,
                                 EntryDate.getHours(),
                                 EntryDate.getMinutes(),
                                 EntryDate.getSeconds());

            dtExpiryDate.SetDate(ExpiryDate)

        }
        
 
        function ONSaveClick(s, e) {
            var isValidGrid = true;
            

                if (!ASPxClientEdit.ValidateGroup('OnSave'))
                {
                    document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();
                    e.processOnServer = false;
                }
                else
                {
                    var grid = ASPxClientGridView.Cast(gridQuotationDetailsList);
                    var indicies = grid.batchEditHelper.GetDataItemVisibleIndices();
                    for (var i = 0; i < indicies.length; i++)
                    {
                        var Price = grid.batchEditApi.GetCellValue(indicies[i], "Price");
                        var UnitType = grid.batchEditApi.GetCellValue(indicies[i], "UnitType");
                        var test = grid.batchEditApi.GetCellValue(indicies[i], "MaterialsTypesName");

                       // alert(Price);
                        if (Price == null && UnitType != 1 && test!=null)
                        {
                            alert(test);
                            alert(i);
                            alert(UnitType);
                            isValidGrid = false;
                            SetError("Price is missing!!");
                            break;
                        }
                    }

                    e.processOnServer = isValidGrid;
                    if (isValidGrid) {
                        lpanel.Show();
                        gridQuotationDetailsList.UpdateEdit();
                        window.setTimeout(function () { s.SetEnabled(false); }, 100)
                    }
                }
            
            }
                    //window.location.href = 'JvManage.aspx?SID=' + getQueryString('SRC')
                   
                


        function SetError(s) {

            document.getElementById('divError').className = 'alert alert-danger';
            alert(s);
            LblError.SetText(s);
            $('.alert').show();


        }
        var onserver = true;

        function GoToServer(s, e) {
            gridQuotationDetailsList.UpdateEdit();

            //var onserver = true;
           // alert(onserver);

            e.processOnServer = onserver;
            onserver = false
        }
    </script>
    <script>
        function SetWorkorderControls(flag) {
            //txtWorkOrderNo.SetEnabled(flag);
            //txtFKAgreementID.SetEnabled(flag);
            //dtTransDate.SetEnabled(flag);
            dtStartDate.SetEnabled(flag);
            dtEndDate.SetEnabled(flag);
            txtSiteName.SetEnabled(flag);
            cmbShiftStatus.SetEnabled(flag);
            txtRegularWorkHrs.SetEnabled(flag);
            txtRamadanWorkHrs.SetEnabled(flag);
            txtMonthlyRate.SetEnabled(flag);
            txtUnitOfAddition.SetEnabled(flag);
            txtExtraWorkHourRate.SetEnabled(flag);
            txtNightShiftPerc.SetEnabled(flag);
            btnUpdateWorkOrder.SetVisible(flag);
            btnCancelUpdate.SetVisible(flag);
        }
    </script>
    <%--<style type="text/css">
        table.dxeTextBoxSys, table.dxeMemoSys, table.dxeButtonEditSys,table.dxeEditAreaSys, table.dxeButtonEdit,
         td.dxeButtonEditButton,table.dxeListBox_MetropolisBlue{
            border-radius: 5px;
            -moz-border-radius: 5px;
            -khtml-border-radius: 5px;
            -webkit-border-radius: 5px;
        }
    </style>--%>
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
            <li><a id="menu1" href="#">Transactions</a></li>
            <li class="active" id="menulink">Quotation</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Quotation</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">
             <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary fa fa-floppy-o" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <ClientSideEvents Click="ONSaveClick" /></dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default fa fa-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>
        </div>
        <%--<div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnSaveVersion" runat="server" EnableTheming="false" Text="Save New Version" CssClass="btn btn-round btn-primary fa fa-clipboard" ValidationGroup="OnSave" OnClick="BtnSaveVersion_Click" >
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>--%>
    </div>
    <div class="row" style="height: 20px"></div>
    <div class="btn-toolbar">

        <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
        </div>
        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
            <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup="OnSave"></dx:ASPxValidationSummary>
        </div>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" ClientInstanceName="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        
        <dx:ASPxFormLayout ID="flQuotationMaster" runat="server" DataSourceID="QuotationMasterDS" ClientInstanceName="flQuotationMaster" OnDataBound="flQuotationMaster_DataBound">
            <Items>
                <dx:LayoutGroup ShowCaption="False" ColCount="8">
                    <Items>
                        <%--<dx:LayoutItem Caption="Is Closed" FieldName="IsClosed" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsClosed" runat="server"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Quotation No" FieldName="QuotationNo" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtQuotationNo" Width="70" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Date" FieldName="EntryDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtEntryDate" ClientInstanceName="dtEntryDate" ClientEnabled="false" DropDownButton-ClientVisible="false" Width="150" runat="server" DisplayFormatString="dd MMM yyyy hh:mm tt" EditFormatString="dd MMM yyyy hh:mm tt" ReadOnly="true"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%-- <dx:LayoutItem Caption="Expiry Date" FieldName="ExpiryDate"  ClientVisible="false" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtExpiryDate" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Expiry Date" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Expires In" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxSpinEdit ID="txtExpireIn" ClientInstanceName="txtExpireIn" runat="server" Number="7" SpinButtons-ShowIncrementButtons="false"
                                                    AllowMouseWheel="false" NumberType="Integer" Width="40">
                                                    <ClientSideEvents NumberChanged="SetExpiryDate" />
                                                </dx:ASPxSpinEdit>
                                            </td>
                                            <td style="width: 50px">
                                                <dx:ASPxLabel runat="server" Width="20" Text="days"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                    </table>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Expiry Date" FieldName="ExpiryDate" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtExpiryDate" runat="server" ClientEnabled="false" DropDownButton-ClientVisible="false" ClientInstanceName="dtExpiryDate" Width="130" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy" ReadOnly="true"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Customer Enquiry" FieldName="FKEnquiryMasterID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKEnquiryMasterID" DropDownButton-ClientVisible="false" ClientEnabled="false" runat="server" Width="180" ValueField="EnquiryMasterID" TextField="EnquiryMasterID" DataSourceID="EnquiryMasterDS"
                                        OnSelectedIndexChanged="cmbFKEnquiryMasterID_SelectedIndexChanged" AutoPostBack="true" ValueType="System.Int64" TextFormatString="{0} - ({3:d}) - {4}" ReadOnly="true">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer Enquiry" />
                                        </ValidationSettings>
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="EnquiryCode" Caption="Enquiry No" Width="100" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                            <dx:ListBoxColumn FieldName="EntryDate" Caption="Date" Width="68" />
                                            <dx:ListBoxColumn FieldName="CustomerReference" Caption="Customer Ref" Width="150" />

                                        </Columns>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>


                        <dx:LayoutItem Caption="Customer" FieldName="FKCustomerID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKCustomerID" runat="server" Width="390" ValueField="CustomerID" TextField="CustomerName"
                                        DataSourceID="CustomersListDS" ValueType="System.Int32" ReadOnly="true" ClientEnabled="false" DropDownButton-ClientVisible="false">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project" FieldName="FKProjectID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKProjectID" ClientEnabled="false" DropDownButton-ClientVisible="false" runat="server" Width="450" ValueField="ProjectID" TextField="ProjectName"
                                        DataSourceID="ProjectsListDS" ValueType="System.Int32" ReadOnly="true">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Project" />
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
                        <dx:LayoutItem Caption="Status" FieldName="StatusID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbStatusID" runat="server" ValueType="System.Int32" DropDownStyle="DropDownList"
                                        ReadOnly="true" DropDownRows="1">
                                        <Items>
                                            <dx:ListEditItem Text="New" Value="0" />
                                            <dx:ListEditItem Text="Approved" Value="1" />
                                            <dx:ListEditItem Text="Rejected" Value="2" />

                                        </Items>
                                        <DropDownButton ClientVisible="false"></DropDownButton>
                                        <ListBoxStyle CssClass="HideScroll" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Payment Terms" FieldName="PaymentTerms" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbPaymentTerms" runat="server" DataSourceID="PaymentTermsDS" Width="600px" DropDownStyle="DropDown">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Payment Terms" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Terms & Conditions" FieldName="FKTermsConditionsID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKTermsConditionsID" runat="server" ValueField="TermConditionID" TextField="TermName"
                                        DataSourceID="TermsConditionsDS" ValueType="System.Int32">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Terms & Condition" />
                                        </ValidationSettings>
                                        <ClearButton Visibility="True"></ClearButton>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />

                        <dx:LayoutItem ShowCaption="False" FieldName="ShowTotal" HorizontalAlign="Right" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="cbShowTotal" runat="server" Text="Show Total" TextAlign="Right" ClientInstanceName="cbShowTotal">
                                        <ClientSideEvents CheckedChanged="getTotal" />
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="8" Visible="false">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNewDetail" Text="Add or Remove Services" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                                        <ClientSideEvents Click="function (s, e) { popTestLists.Show();}" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxHiddenField runat="server" ID="hf" ClientInstanceName="hf"></dx:ASPxHiddenField>
                                   
                                    <dx:ASPxGridView runat="server" ID="GdvQuotationDetailsList" AutoGenerateColumns="false" ClientInstanceName="gridQuotationDetailsList" OnCellEditorInitialize="GdvQuotationDetailsList_CellEditorInitialize"
                                        DataSourceID="QuotationDetailsDS" KeyFieldName="QuotationDetailsID" OnRowUpdating="GdvQuotationDetailsList_RowUpdating" Width="100%"  OnCustomButtonInitialize="GdvQuotationDetailsList_CustomButtonInitialize">
                                        <Columns>
                                            <dx:GridViewCommandColumn VisibleIndex="0">
                                                <CustomButtons>
                                                    <dx:GridViewCommandColumnCustomButton ID="btnWarning" Text=" " Visibility="Invisible">
                                                        <%--<Styles>
                                                            <Style Font-Size="Medium" ForeColor="Orange" CssClass="glyphicon glyphicon-question-sign"></Style>
                                                        </Styles>--%>
                                                        <Image Url="../images/warning.png" Width="15" Height="22" ToolTip="Warning: This quotation contains one or more services with price less than the minimum price!"></Image>

                                                    </dx:GridViewCommandColumnCustomButton>
                                                    <dx:GridViewCommandColumnCustomButton ID="btnError" Text=" " Visibility="Invisible">
                                                        <Styles>
                                                            <Style Font-Size="Medium" ForeColor="Red" CssClass="glyphicon glyphicon-exclamation-sign"></Style>
                                                        </Styles>
                                                    </dx:GridViewCommandColumnCustomButton>
                                                </CustomButtons>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn FieldName="MaterialsTypesName"  Name="MaterialsTypesName" Caption="Service Section" Width="120" VisibleIndex="1" ReadOnly="true">
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="MaterialsDetailsName" Caption="Material Details" Width="120" VisibleIndex="2" ReadOnly="true">
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                           <dx:GridViewDataTextColumn FieldName="TestName" Name="FKTestID" Caption="Services Name" Width="120" VisibleIndex="3">
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FKTestID" Name="FKTestID" Caption="FKTestID" Width="0" VisibleIndex="3">
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="Standard Number" Width="120" VisibleIndex="4" ReadOnly="true">
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Name="FKPriceUnitID" Caption="Unit" Width="70" VisibleIndex="5">

                                                <PropertiesComboBox ValueField="PriceUnitID" TextFormatString="{0}" EnableCallbackMode="true" Width="100" CallbackPageSize="20" IncrementalFilteringMode="Contains" OnItemRequestedByValue="OnItemRequestedByValue" OnItemsRequestedByFilterCondition="OnItemsRequestedByFilterCondition">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="UnitName" Name="MinimumPrice" Visible="true" />
                                                        <dx:ListBoxColumn FieldName="MinimumPrice" Name="MinimumPrice" Visible="true" Width="0" />
                                                        <dx:ListBoxColumn FieldName="DefaultPrice" Name="DefaultPrice" Visible="true" Width="0" />
                                                        <dx:ListBoxColumn FieldName="UnitType" Name="UnitType" Visible="true" Width="0" />


                                                    </Columns>
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                    </ValidationSettings>
                                                    <ClientSideEvents ValueChanged="SetPrice" />
                                                </PropertiesComboBox>
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="MinimumPrice" Name="MinPrice" Caption="Min Price" ReadOnly="true" Width="70" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                    AllowMouseWheel="false">
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                             <dx:GridViewDataSpinEditColumn FieldName="UnitType" Name="UnitType" Caption="UnitType" Width="0" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                                                
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="DefaultPrice" Caption="Default Price" Name="DefPrice" ReadOnly="true"  Width="90" VisibleIndex="8" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                    AllowMouseWheel="false">
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Price" Caption="Price" Name="Price" Width="70" VisibleIndex="9" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit DecimalPlaces="2" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                    AllowMouseWheel="false">
                                                  <%--  <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Price is missing!" />
                                                    </ValidationSettings>--%>
                                                <ClientSideEvents  KeyDown="OnDescKeyDown" />

                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>

                                            <dx:GridViewDataSpinEditColumn FieldName="MinQty" Name="MinQty" Caption="Min Qty" Width="70" VisibleIndex="10" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false" NumberType="Integer"  DisplayFormatString="N0"
                                                    AllowMouseWheel="false">
                                                <%--<ClientSideEvents  KeyDown="OnDescKeyDown" />--%>

                                                    <%--<ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings>--%>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>

                                            <%--<dx:GridViewDataDateColumn FieldName="ExpiryDate" Caption="Expiry Date" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                                <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></PropertiesDateEdit>
                                            </dx:GridViewDataDateColumn>--%>
                                            <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" Width="100" VisibleIndex="11" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataColumn Name="Command" Caption="" Width="40px" VisibleIndex="12" meta:resourcekey="GridViewDataColumnResource1">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server" ClientVisible="false">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-list';}" Click="function (s, e) { popTestLists.Show();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>
                                                <DataItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>

                                                                <dx:ASPxButton ID="btnWorkOrder" CssClass="glyphicon glyphicon-list-alt" Font-Size="Medium" ClientVisible="true" runat="server" Cursor="pointer" EnableTheming="false"
                                                                    RenderMode="Link" CommandName="WorkOrder" ToolTip="Work Order" Visible='<%#Convert.ToBoolean(Eval("UnitType")) %>' Width="18px" OnInit="btnWorkOrder_Init" AutoPostBack="false" >
                                                                    <ClientSideEvents Click="function (s, e) { popupWorkOrder.Show();}" />
                                                                    
                                                                </dx:ASPxButton>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <%--<dx:GridViewCommandColumn VisibleIndex="11" ButtonType="Default" Width="40"
                                                ShowClearFilterButton="true" ShowEditButton="false" ShowDeleteButton="false"  ShowUpdateButton="false">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server" ClientVisible="false">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-list';}" Click="function (s, e) { popTestLists.Show();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>
                                                <CustomButtons>
                                                    <dx:GridViewCommandColumnCustomButton  ID="btnWorkOrder" Text=" " >
                                                        
                                                        <Styles>
                                                            <Style Font-Size="Medium" CssClass="glyphicon glyphicon-list-alt" ></Style>
                                                        </Styles>
                                                    </dx:GridViewCommandColumnCustomButton>
                                                </CustomButtons>
                                                <DataItemTemplate>
                                <table cellpadding="0" cellspacing="2">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnPrint" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnPrint %>" Cursor="pointer" EnableTheming="false"
                                                RenderMode="Link" CommandName="CmdPrint" Visible="True" ImageUrl="../images/printer.png" Width="18px" AlternateText="<%$ Resources:GlobalResource, BtnPrint %>"
                                                OnClientClick='<%# string.Format("PrintStkReport(\"StkDirectPurchaseInvoice\",{0},{1});",Eval("PurchaseInvoiceID"), Eval("FKStkSourceDetID")) %>'></asp:ImageButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnEdit" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnEdit %>" Cursor="pointer"
                                                CommandName="cmdEdit" CommandArgument='<%# Eval("PurchaseInvoiceID") %>' EnableTheming="False" RenderMode="Link" meta:resourcekey="btnEditResource1">
                                                <Image Url="../images/grd_edit.png" ToolTip="<%$ Resources:GlobalResource, BtnEdit %>" AlternateText="<%$ Resources:GlobalResource, BtnEdit %>"></Image>
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </DataItemTemplate>
                                            </dx:GridViewCommandColumn>--%>
                                        </Columns>
                                        <SettingsCommandButton>
                                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                            <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                            <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                            <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                                            <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
                                        </SettingsCommandButton>
                                        <Styles>
                                            <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                        </Styles>
                                        <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom" />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" AllowSort="false"/>
                                        <ClientSideEvents  Init="OnInit" RowClick="OnRowClick" BatchEditStartEditing="OnBatchEditStartEditing" BatchEditEndEditing="OnBatchEditEndEditing" EndCallback="function(s, e) {if(s.cpDeleteError != ''){lblWarning.SetText(s.cpDeleteError);}else{lblWarning.SetText('');} if(s.cpError != ''){lblcpError.SetText(s.cpError);}else{lblcpError.SetText('');} }" />
                                        <ClientSideEvents  CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); vi.SetValue(e.visibleIndex);Qid.SetValue(key); gridWorkOrderList.PerformCallback();if(e.buttonID == 'btnWorkOrder'){popupWorkOrder.Show()};ASPxClientEdit.ClearEditorsInContainerById('contentDiv'); }" />
                                        <Styles StatusBar-CssClass="statusBar" />
                                        <Settings VerticalScrollableHeight="950" VerticalScrollBarMode="Visible"  />
                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem Width="50" />

                        <dx:LayoutItem Caption="Total Quotation" CaptionStyle-Font-Bold="true" HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="lblTotalQuotaion" runat="server" Text="" Font-Bold="true" ClientInstanceName="lblTotalQuotaion"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption=" " ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="lblWarning" runat="server" Text="" Font-Bold="true" ForeColor="Orange" ClientInstanceName="lblWarning"></dx:ASPxLabel>
                                    
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="lblcpError" runat="server" Text="" Font-Bold="true" ForeColor="Red" ClientInstanceName="lblcpError"></dx:ASPxLabel>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>
     <div>
      <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lpanel"
            Modal="True">
        </dx:ASPxLoadingPanel>
        </div>
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups" style="text-align: right; float: right" runat="server" id="divConfirmSection" visible="false">
        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="btnApprove" runat="server" CssClass="btn btn-round btn-success glyphicon glyphicon-ok-sign" Text="Save And Approve" OnClick="Action_Click">
                <ClientSideEvents Click="function(s,e){lpanel.Show(); e.processOnServer=confirm('Are you sure to approve this quotation?')==true;  gridQuotationDetailsList.UpdateEdit();}" />
            </dx:ASPxButton>
           
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="btnReject" runat="server" CssClass="btn btn-round btn-danger glyphicon glyphicon-remove-sign" Text="Reject" OnClick="Action_Click">
                <ClientSideEvents Click="function(s,e){e.processOnServer=confirm('Are you sure to reject this quotation?')==true;  gridQuotationDetailsList.UpdateEdit();}" />
            </dx:ASPxButton>
        </div>
        
        <%--<div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnSaveVersion" runat="server" EnableTheming="false" Text="Save New Version" CssClass="btn btn-round btn-primary fa fa-clipboard" ValidationGroup="OnSave" OnClick="BtnSaveVersion_Click" >
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>--%>
    </div>
    <div>
        <dx:ASPxLabel ID="lblMessageError" runat="server" CssClass="Alert" Text="" Font-Bold="true" ForeColor="Red" ClientInstanceName="lblError"></dx:ASPxLabel>
    </div>
    <div>
         <dx:ASPxLabel ID="lblErrorMessage" runat="server" Text="" Font-Bold="true" ForeColor="red" ClientInstanceName="lblErrorMessage" Width="300px"></dx:ASPxLabel>

    </div>
    <div>
        <dx:ASPxPopupControl ID="popTestLists" runat="server" CloseAction="CloseButton" OnWindowCallback="popTestLists_WindowCallback"
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Available Services List" ClientInstanceName="popTestLists">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
                    <div style="display: none; overflow: auto; height: 400px">
                        <dx:ASPxCheckBoxList ID="lstTests" runat="server" ClientInstanceName="lstTests" DataSourceID="TestsListDS" ValueType="System.Int32"
                            TextField="TestName" ValueField="TestID" Width="500" OnDataBound="lstTests_DataBound">
                        </dx:ASPxCheckBoxList>
                    </div>
                    <dx:ASPxGridView runat="server" ID="GdvLabTestsList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridLabTestsList"
                        DataSourceID="TestsListDS" KeyFieldName="TestID" OnDataBound="GdvLabTestsList_DataBound">
                        <Columns>

                            <dx:GridViewDataTextColumn FieldName="TestName" Caption="Service Name" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                <Settings AutoFilterCondition="Contains" />
                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ShortName" Caption="Short Name" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="Standard Number" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="AshghalTestNumber" Caption="Ashghal Test Number" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>

                            <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Default" Width="60" ShowClearFilterButton="true" ShowSelectCheckbox="true">
                            </dx:GridViewCommandColumn>
                        </Columns>
                        <SettingsCommandButton>
                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                        </SettingsCommandButton>
                        <Settings ShowFilterRow="True" />
                        <SettingsBehavior AutoFilterRowInputDelay="50000" ColumnResizeMode="NextColumn" />
                    </dx:ASPxGridView>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <dx:ASPxButton ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" OnClick="btnUpdate_Click">
                        <%--<ClientSideEvents Click="function(s, e) { popTestLists.PerformCallback(); }" />--%>
                    </dx:ASPxButton>
                </div>
            </FooterTemplate>
            <ClientSideEvents PopUp="function(s, e) { popTestLists.PerformCallback(); }" />
        </dx:ASPxPopupControl>
    </div>

     <div>
        <dx:ASPxPopupControl ID="popAlert" runat="server" CloseAction="CloseButton" OnWindowCallback="popTestLists_WindowCallback"
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Available Services List" ClientInstanceName="popTestLists">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                    <div style="display: none; overflow: auto; height: 400px">
                        <dx:ASPxLabel ID="lblmessage" runat="server" Text="Work order mandatory" Font-Bold="true" ForeColor="red" ClientInstanceName="lblErrorMessage" Width="300px"></dx:ASPxLabel>

                    </div>
                    
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <dx:ASPxButton ID="btnUpdate" runat="server" Text="Ok" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" >
                        <ClientSideEvents Click="function(s, e) { popTestLists.h(); }" />
                    </dx:ASPxButton>
                </div>
            </FooterTemplate>
            <ClientSideEvents PopUp="function(s, e) { popTestLists.Hide(); }" />
        </dx:ASPxPopupControl>
    </div>
    <div>
        <dx:ASPxPopupControl ID="popupWorkOrder" runat="server" CloseAction="CloseButton" OnWindowCallback="popupWorkOrder_WindowCallback"
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Work Order List" ClientInstanceName="popupWorkOrder">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <div class="divrow">
                        <%--<asp:Image ID="pjmaskg" runat="server" Width="100" ImageUrl="http://pjmasks.com/files/large/29c5ffff6cb53ed336295118f3797c6e.png" />
                        <asp:Image ID="pjmaskc" runat="server" Width="100" ImageUrl="http://pjmasks.com/files/large/3b984b68702760c5da2cab7dd9a4879f.png" />
                        <asp:Image ID="pjmasko" runat="server" Width="100" ImageUrl="http://pjmasks.com/files/large/b85d664536e16507711482dec9b43c8a.png" />
                        <asp:Image ID="Image1" runat="server" Width="100" ImageUrl="http://pjmasks.com/files/large/b40cbfcd083430d93eebbbd6b4ba7a3a.png" />
                        <asp:Image ID="Image2" runat="server" Width="100" ImageUrl="http://pjmasks.com/files/large/9f9b158bc0c91bc68b4fa7d328699baf.png" />
                        <asp:Image ID="Image3" runat="server" Width="100" ImageUrl="http://pjmasks.com/files/large/9eb01ac7ca52a28e4ab66d8b38379477.png" />
                        <asp:Image ID="Image4" runat="server" Width="100" ImageUrl="http://pjmasks.com/files/large/707d72e2ed15f2fc3c98ffdb51e45e9b.png" />--%>

                        <dx:ASPxValidationSummary ID="ASPxValidationSummary2" runat="server" ValidationGroup="options"></dx:ASPxValidationSummary>
                        <dx:ASPxTextBox ID="vi" runat="server" ClientInstanceName="vi" ClientVisible="false" Text=""></dx:ASPxTextBox>
                        <dx:ASPxTextBox ID="Qid" runat="server" ClientInstanceName="Qid" ClientVisible="false" Text="0"></dx:ASPxTextBox>
                        <dx:ASPxTextBox ID="sid" runat="server" ClientInstanceName="sid" ClientVisible="false" Text="0"></dx:ASPxTextBox>
                        <dx:ASPxButton ID="flRefresh" runat="server" ClientInstanceName="flRefresh" ClientVisible="false" OnClick="flRefresh_Click" AutoPostBack="false"></dx:ASPxButton>
                    </div>
                    <div class="divrow" id="contentDiv">
                        <dx:ASPxCallbackPanel ID="cpnl" runat="server" ClientInstanceName="cpnl">
                            <PanelCollection>
                                <dx:PanelContent>


                                    <dx:ASPxFormLayout ID="flWorkOrder" runat="server" DataSourceID="WorkOrderDS" ClientInstanceName="flJobOrderMaster">
                                        <Items>
                                            <dx:LayoutGroup Caption="Work Order Details" ColCount="4">
                                                <Items>
                                                    <dx:LayoutItem Caption="WorkOrder No" FieldName="WorkOrderNo" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtWorkOrderNo" runat="server" ClientInstanceName="txtWorkOrderNo" ClientEnabled="false"></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Date" FieldName="TransDate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxDateEdit ID="dtTransDate" ClientInstanceName="dtTransDate" ClientEnabled="false" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <%--<dx:LayoutItem Caption="Agreement No" FieldName="FKAgreementID" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtFKAgreementID" ClientInstanceName="txtFKAgreementID" runat="server" ClientEnabled="false"></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>--%>

                                                    <dx:LayoutItem Caption="Start Date" FieldName="StartDate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxDateEdit ID="dtStartDate" ClientInstanceName="dtStartDate" ClientEnabled="false" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                      <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSavedet" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="" />
                                        </ValidationSettings>
                                                                </dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="End Date" FieldName="EndDate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxDateEdit ID="dtEndDate" ClientInstanceName="dtEndDate" ClientEnabled="false" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                      <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSavedet" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="" />
                                        </ValidationSettings>
                                                                </dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>

                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Site Name" FieldName="SiteName" ColSpan="4">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtSiteName" runat="server" ClientInstanceName="txtSiteName" ClientEnabled="false"></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="ShiftStatus" FieldName="ShiftStatus" ColSpan="4">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxComboBox ID="cmbShiftStatus" runat="server" ClientInstanceName="cmbShiftStatus" ValueType="System.Int32"
                                                                    DropDownStyle="DropDownList" ClientEnabled="false">
                                                                    <Items>
                                                                        <dx:ListEditItem Text="Day" Value="1" />
                                                                        <dx:ListEditItem Text="Night" Value="2" />
                                                                    </Items>
                                                                </dx:ASPxComboBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>


                                                    <dx:LayoutItem Caption="Regular Working Hours" FieldName="RegularWorkHrs" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtRegularWorkHrs" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                                    AllowMouseWheel="false" NumberType="Integer" ClientInstanceName="txtRegularWorkHrs" runat="server" ClientEnabled="false">
                                                                      <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSavedet" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="" />
                                        </ValidationSettings>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Ramadan Working Hours" FieldName="RamadanWorkHrs" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtRamadanWorkHrs" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtRamadanWorkHrs" runat="server" ClientEnabled="false">

                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Monthly Rate" FieldName="MonthlyRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtMonthlyRate" SpinButtons-ShowIncrementButtons="false"
                                                                    AllowMouseWheel="false"  ClientInstanceName="txtMonthlyRate" runat="server" ClientEnabled="false">
                                                                      <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSavedet" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="" />
                                        </ValidationSettings>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Unit Of Addition" FieldName="UnitOfAddition" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtUnitOfAddition" ClientInstanceName="txtUnitOfAddition" runat="server" ClientEnabled="false">  <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSavedet" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="" />
                                        </ValidationSettings></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Extra Working Hour Rate" FieldName="ExtraWorkHourRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtExtraWorkHourRate" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                                    AllowMouseWheel="false"  ClientInstanceName="txtExtraWorkHourRate" runat="server" ClientEnabled="false">
                                                                      <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSavedet" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="true" ErrorText="" />
                                                                        </ValidationSettings>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Night Shift Percentage" FieldName="NightShiftPerc" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtNightShiftPerc" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                                    AllowMouseWheel="false" ClientInstanceName="txtNightShiftPerc" runat="server" ClientEnabled="false">
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                     <dx:LayoutItem Caption="Description" FieldName="Description" ColSpan="4">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtDescription" runat="server" Width="520px" ClientInstanceName="txtDescription" ></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                   <dx:EmptyLayoutItem ColSpan="3"></dx:EmptyLayoutItem>
                                                    <dx:LayoutItem Caption="" HorizontalAlign="Right">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <%--<table>
                                                        <tr>
                                                            <td >

                                                            </td>
                                                            <td>

                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                                <div style="width: 100%; text-align: right">
                                                                    <div style="display: inline-block;">
                                                                        <dx:ASPxButton ID="btnUpdateWorkOrder" EnableTheming="false" ClientInstanceName="btnUpdateWorkOrder" ClientVisible="false" runat="server"
                                                                            CssClass="btn btn-mini btn-round btn-primary fa fa-floppy-o" Height="35" Width="60" ValidationGroup="OnSavedet"  OnClick="btnUpdateWorkOrder_Click">
                                                                            <ClientSideEvents  Click="GoToServer"/>
                                                                        </dx:ASPxButton>

                                                                    </div>
                                                                    <div style="display: inline-block;">

                                                                        <dx:ASPxButton ID="btnCancelUpdateWorkOrder" ClientInstanceName="btnCancelUpdate" ClientVisible="false" runat="server"
                                                                            CssClass="btn btn-mini btn-sm btn-round btn-primary fa fa-remove" Height="35" Width="60">
                                                                            <ClientSideEvents Click="function (s, e) { SetWorkorderControls(false);sid.SetValue(0);}" />
                                                                        </dx:ASPxButton>
                                                                    </div>
                                                                </div>


                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>
                                            <dx:LayoutGroup Caption="Work Order List">
                                                <Items>
                                                    <dx:LayoutItem ShowCaption="False" FieldName="IsActive">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxGridView runat="server" ID="GdvWorkOrderList" AutoGenerateColumns="false" ClientInstanceName="gridWorkOrderList"
                                                                    DataSourceID="WorkOrderListDS" KeyFieldName="QuotationWorkOrderID" Width="100%" OnCustomCallback="GdvWorkOrderList_CustomCallback">
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="WorkOrder No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                                                        <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataDateColumn FieldName="StartDate" Caption="Start Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                                                            <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                                                                        </PropertiesDateEdit>
                                                                        </dx:GridViewDataDateColumn>
                                                                        <dx:GridViewDataDateColumn FieldName="EndDate" Caption="End Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                                                                            <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                                                                        </PropertiesDateEdit>
                                                                        </dx:GridViewDataDateColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="SiteName" Caption="Site Name" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                                                                        <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataComboBoxColumn FieldName="ShiftStatus" Caption="Shift Status" VisibleIndex="5">
                                                                            <PropertiesComboBox ValueType="System.Int32" DropDownStyle="DropDownList">
                                                                                <Items>
                                                                                    <dx:ListEditItem Text="Day" Value="1" />
                                                                                    <dx:ListEditItem Text="Night" Value="2" />
                                                                                </Items>
                                                                            </PropertiesComboBox>
                                                                         <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                                                        <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="60"
                                                                            ShowClearFilterButton="true" ShowEditButton="false" ShowDeleteButton="true" ShowCancelButton="false" ShowUpdateButton="false">
                                                                            <HeaderCaptionTemplate>
                                                                                <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server">
                                                                                    <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-plus';}"
            
                                                                                        Click="function (s, e) {  SetWorkorderControls(true);sid.SetValue(0);ASPxClientEdit.ClearEditorsInContainerById('contentDiv'); onserver = true;}" />
                                                                                    <BackgroundImage HorizontalPosition="center" />
                                                                                </dx:ASPxButton>
                                                                            </HeaderCaptionTemplate>
                                                                            <CustomButtons>
                                                                                <dx:GridViewCommandColumnCustomButton ID="WorkOrderEdit" Text=" ">
                                                                                    <Styles>
                                                                                        <Style Font-Size="Medium" CssClass="glyphicon glyphicon-edit"></Style>
                                                                                    </Styles>
                                                                                </dx:GridViewCommandColumnCustomButton>
                                                                            </CustomButtons>
                                                                        </dx:GridViewCommandColumn>
                                                                    </Columns>
                                                                    <SettingsCommandButton>
                                                                        <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                                                        <%--<EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />--%>
                                                                        <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                                                        <%--<CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />--%>
                                                                        <%--<UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />--%>
                                                                    </SettingsCommandButton>
                                                                    <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); sid.SetValue(key); cpnl.PerformCallback();}" />

                                                                    <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                                                                    <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                                                    <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
                                                                </dx:ASPxGridView>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>
                                        </Items>
                                    </dx:ASPxFormLayout>
                                </dx:PanelContent>
                            </PanelCollection>
                            <ClientSideEvents EndCallback="function(s,e){SetWorkorderControls(true);}" />
                        </dx:ASPxCallbackPanel>
                    </div>
                    <div style="width: 100%">
                        <div style="display: inline-block;">
                            Service Section:

                        </div>
                        <div style="display: inline-block;">
                            Material Details:

                        </div>
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
    <asp:ObjectDataSource ID="EnquiryMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EnquiryMasterDB"
        DataObjectTypeName="BusinessLayer.EnquiryMaster" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="AllMaterialsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsDetails"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MaterialsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsDetails">
        <%--<SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flQuotationMaster$cmbFKMaterialTypeID" PropertyName="Value" DefaultValue="0" Name="FKMaterialTypeID" Type="Int32" />
        </SelectParameters>--%>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="PaymentTermsDS" runat="server" TypeName="BusinessLayer.Pages.QuotationMasterDB" SelectMethod="GetPaymentTermsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TermsConditionsDS" runat="server" TypeName="BusinessLayer.Pages.TermsConditionListDB"
        DataObjectTypeName="BusinessLayer.TermsConditionList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="QuotationMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationMasterDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete"
        OnInserting="QuotationMasterDS_Inserting" OnInserted="QuotationMasterDS_Inserted"
        OnUpdating="QuotationMasterDS_Updating" OnUpdated="QuotationMasterDS_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="PriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestPriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="QuotationDetailsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationDetailsDB"
        SelectMethod="GetByMasterIDFromSession" InsertMethod="InsertList" OnInserting="QuotationDetailsDS_Inserting" OnInserted="QuotationDetailsDS_Inserted"
        UpdateMethod="UpdateToSession" OnUpdating="QuotationDetailsDS_Updating" >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Type="Object" Name="entity" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="WorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationWorkOrderListDB"
        SelectMethod="GetByIDFromSession">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$popupWorkOrder$sid" PropertyName="Text" DefaultValue="0" Name="id" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="WorkOrderListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationWorkOrderListDB"
        SelectMethod="GetByMasterIDFromSession" InsertMethod="InsertToSession" UpdateMethod="UpdateToSession" DeleteMethod="DeleteFromSession"
        OnInserting="WorkOrderListDS_Inserting" OnUpdating="WorkOrderListDS_Updating" >
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$popupWorkOrder$Qid" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="mainMasterId" Type="Int32" />

        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Type="Object" Name="entity" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Type="Object" Name="entity" />
        </UpdateParameters>
    </asp:ObjectDataSource>

       
</asp:Content>
