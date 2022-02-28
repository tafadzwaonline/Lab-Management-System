<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="SampleReceive.aspx.cs" Inherits="PioneerLab.Pages.SampleReceive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%--<dx:ASPxLabel ID="lblUploadDirectory" runat="server" Text="~/Uploaded/Attachments" Visible="false"></dx:ASPxLabel>--%>
    <script>
        function PrintReport() {
            window.open('ReportViwer.aspx?source=SampleReceiptReport&id=0&Filter=' + gridCustomersList.cpFilter, '_blank');
        }

        var FilesGridEdited = false;

        function onFileUploadComplete(s, e) {
            if (e.callbackData) {
                gdvfiles.PerformCallback();
            }
        }

        function onSessionFileUploadComplete(s, e) {
            if (e.callbackData) {
                gdvSessionFiles.PerformCallback();
            }
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
    <script type="text/javascript">

        function Uploader_OnFileUploadComplete(args) {
            if (args.isValid) {
                txtWorkform.SetText(args.callbackData);
                cmbWorkform.PerformCallback();
            }
        }
        function Uploader_OnFilesUploadComplete(args) {
            UpdateUploadButton();
        }
        function UpdateUploadButton() {
            //btnUpload.SetEnabled(uploader.GetText(0) != "");
            uploader_Workbookfile.Upload(); //Uploads automatically
        }
        function UploadButton_Click(s, e) {
            //file.GetFileSelectorElement(0).click(); //uploader.GetFileInputElement(0).click(); ctl00$body$flTestExcelFiles$uplWorkbookfile
            document.getElementById("body_flSampleReceiveList_uplWorkbookfile_TextBox0_Input").click();
        }


        function Uploader_Report_OnFilesUploadComplete(args) {
            UploadReportInstant();
        }
        function UploadReportInstant() {
            uploader_Report.Upload(); //Uploads automatically
        }
        function Uploader_Report_OnFileUploadComplete(args) {
            if (args.isValid) {
                txtReport.SetText(args.callbackData);
                cmbReport.PerformCallback();
            }
        }
        function UploadReportButton_Click(s, e) {
            //file.GetFileSelectorElement(0).click(); //uploader.GetFileInputElement(0).click(); ctl00$body$flTestExcelFiles$uplWorkbookfile
            document.getElementById("body_flSampleReceiveList_uplReportfile_TextBox0_Input").click();
        }
        function PrintElem(elem) {
            Popup($(elem).html());
        }
        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=400,width=600');
            mywindow.document.write('<html><head><title>my div</title>');
            /*optional stylesheet*/ //mywindow.document.write('<link rel="stylesheet" href="main.css" type="text/css" />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10

            mywindow.print();
            mywindow.close();

            return true;
        }

        function grid_SelectionChanged(s, e) {   
            if (e.isChangedOnServer == true)
                return;
            
            //alert(e.isChangedOnServer);
            //var key = s.GetRowKey(e.visibleIndex);  
            //alert("Selected:" + key + "Checked:" + e.isSelected);
            var params = [ e.visibleIndex, e.isSelected ];
            gdvSampleTestList.PerformCallback(params);
        }  

    </script>
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
        var curentEditingIndex;
        var lastTest = null;
        function OnBatchEditEndEditing(s, e) {
            window.setTimeout(function () {
                var Total = 0;
                curentEditingIndex = e.visibleIndex;
                var indicies = s.batchEditHelper.GetDataItemVisibleIndices();
                for (var i = 0; i < indicies.length; i++) {

                    var Price = s.batchEditApi.GetCellValue(indicies[i], "Price");
                    var Qty = s.batchEditApi.GetCellValue(indicies[i], "Qty");

                    Total = Total + (Price * Qty);
                }
                //alert(Total);
                txtTotalTestPrices.SetText(Total);

                hfT.Set("TotalTestPrices", Total);
            }, 10)
        }

        function OnBatchEditStartEditing(s, e) {
            curentEditingIndex = e.visibleIndex;
            var currentTest = gdvSampleTestList.batchEditApi.GetCellValue(curentEditingIndex, "FKTestID");


            //if (currentTest != lastTest && e.focusedColumn.fieldName == "FKPriceUnitID" && currentTest != null) {
            if (e.focusedColumn.fieldName == "FKSubContractorID" && currentTest != null) {

                lastTest = currentTest;
                RefreshData(currentTest);
            }
            if (e.focusedColumn.fieldName == "FKTestID") {
                e.cancel = true;
            }


            var IsEnabled = gdvSampleTestList.batchEditApi.GetCellValue(e.visibleIndex, "Enabled");
            if (IsEnabled == false) {
                e.cancel = true;
            }
        }

        function RefreshData(value) {
            hf.Set("CurrentTest", value);
            SubContractorEditor.PerformCallback();
        }
        function OnValidate(s, e) {
            isValidRow = true;
            var WitnessColumnIndex = s.GetColumnById("Witness").index;
            var WitnessNameColumnIndex = s.GetColumnById("WitnessName").index;
            var SubcontractColumnIndex = s.GetColumnById("Subcontract").index;
            var FKSubContractorIDColumnIndex = s.GetColumnByField("FKSubContractorID").index;
            var QtyColumnIndex = s.GetColumnById("Qty").index;
            var MinQtyColumnIndex = s.GetColumnByField("MinQty").index;

            var WitnessValue = e.validationInfo[WitnessColumnIndex].value;
            var WitnessNameValue = e.validationInfo[WitnessNameColumnIndex].value;
            var SubcontractValue = e.validationInfo[SubcontractColumnIndex].value;
            var FKSubContractorValue = e.validationInfo[FKSubContractorIDColumnIndex].value;
            var QtyValue = e.validationInfo[QtyColumnIndex].value;
            var MinQtyValue = e.validationInfo[MinQtyColumnIndex].value;
                       
            isValidRow = e.validationInfo[WitnessColumnIndex].isValid;
            if ((WitnessValue == true) && (WitnessNameValue == null)) {
                e.validationInfo[WitnessNameColumnIndex].isValid = false;
                e.validationInfo[WitnessNameColumnIndex].errorText = "Required";
                isValidRow = false;
            }

            if (SubcontractValue == true && (FKSubContractorValue == null)) {
                e.validationInfo[FKSubContractorIDColumnIndex].isValid = false;
                e.validationInfo[FKSubContractorIDColumnIndex].errorText = "Required";
                isValidRow = false;
            }

            if ((QtyValue < MinQtyValue) && (QtyValue != null)) {
                e.validationInfo[QtyColumnIndex].isValid = false;
                e.validationInfo[QtyColumnIndex].errorText = "Minimum Quantity for this test is  " + MinQtyValue;
                isValidRow = false;
            }
            if (QtyValue == null) {
                e.validationInfo[QtyColumnIndex].isValid = false;
                e.validationInfo[QtyColumnIndex].errorText = "Required ";
                isValidRow = false;
            }

            if (isValidRow) {
                s.batchEditHelper.ApplyValidationInfo(e.visibleIndex, { isValid: isValidRow, dict: e.validationInfo });
            }
        }

       function OnBatchEditChangesCanceling(s, e) {  
           e.cancel = true; 
       }  

        function onSaveClick(s, e) {

            //var gdvCustomFields = ASPxClientGridView.Cast(gdvCustomFields);

            var isValidGrid = true;
            var grid = ASPxClientGridView.Cast(gdvSampleTestList);
            var indicies = grid.batchEditHelper.GetDataItemVisibleIndices();

            var selectedKeys = grid.GetSelectedKeysOnPage();

            for (var i = 0; i < indicies.length; i++) {
                for (var n = 0; n < selectedKeys.length; n++) {


                    var key = grid.GetRowKey(indicies[i]);
                    if (selectedKeys.includes(key)) {
                        var FKTestID = grid.batchEditApi.GetCellValue(indicies[i], "FKTestID");
                        var Witness = grid.batchEditApi.GetCellValue(indicies[i], "Witness");
                        var WitnessName = grid.batchEditApi.GetCellValue(indicies[i], "WitnessName");
                        var Subcontract = grid.batchEditApi.GetCellValue(indicies[i], "Subcontract");
                        var FKSubContractorID = grid.batchEditApi.GetCellValue(indicies[i], "FKSubContractorID");
                        var Qty = grid.batchEditApi.GetCellValue(indicies[i], "Qty");
                        var MinQty = grid.batchEditApi.GetCellValue(indicies[i], "MinQty");


                        var IsEnabled = grid.batchEditApi.GetCellValue(indicies[i], "Enabled");
                        if (IsEnabled == true) {

                            if ((Witness == true) && (WitnessName == null)) {
                                isValidGrid = false;
                                SetError(" Witness Name is not specified !!");
                                break;
                            }
                            if ((Subcontract == true) && (FKSubContractorID == null)) {
                                isValidGrid = false;
                                SetError(" Sub Contractor Name is not specified !!");
                                break;
                            }
                            //alert(Qty);
                            //alert(MinQty);
                            if ((Qty < MinQty)) {
                                //  alert(Qty);
                                //alert(MinQty);
                                isValidGrid = false;
                                SetError(" Minimum Quantity for this test is  " + MinQty);
                                break;
                            }
                            if ((Qty == null)) {
                                isValidGrid = false;
                                SetError(" Quantity is not specified  !!, Minimum Quantity for this test is  " + FKTestID + MinQty);
                                break;
                            }
                            else if ((Qty == undefined)) {
                                isValidGrid = false;
                                SetError(" Quantity is not specified 2 !!, Minimum Quantity for this test is  " + FKTestID + MinQty);
                                break;
                            }
                        }

                    }
                }
            }

            e.processOnServer = isValidGrid;

            if (isValidGrid == true) {
                e.processOnServer = true;
                gdvCustomFields.UpdateEdit();
                gdvSampleTestList.UpdateEdit();
                gdvCustomTableFields.UpdateEdit();
                window.setTimeout(function () { s.SetEnabled(false); }, 100)
            }
            else
                e.processOnServer = false
        }

        function SetError(s) {

            // $('#divError').show();
            document.getElementById('divError').className = 'alert alert-danger';
            //document.getElementById('LblError').innerText = s;
            alert(s);
            lblErrorMessage.SetText(s);

            $('.alert').show();
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
            <li class="active" id="menulink">Sample Receive</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Sample Receive</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">   
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div>
            <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="txtTotalTestPrices" runat="server" ClientInstanceName="txtTotalTestPrices" Text="0" ForeColor="White" ClientVisible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblTransID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblTransTypeID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblUploadDirectory" runat="server" Text="~/Uploaded/Attachments" Visible="false"></dx:ASPxLabel>

        </div>
        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary fa fa-save" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <%--<ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />--%>
                <ClientSideEvents Click="onSaveClick" />

            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default fa fa-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>

        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnDownload" runat="server" ToolTip="Print" Text="Download Work Files" EnableViewState="false" ClientVisible="false"
                CssClass="btn btn-round btn-info fa fa-file-excel-o" OnClick="BtnDownload_Click">
                <%--<ClientSideEvents Click="function(s,e){PrintElem('#divprint');}" />--%>
            </dx:ASPxButton>

        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnPrint" runat="server" ToolTip="Print" Text="Print" EnableViewState="false" Visible="false"
                CssClass="btn btn-round btn-info glyphicon glyphicon-print">
                <%--<ClientSideEvents Click="function(s,e){PrintElem('#divprint');}" />--%>
            </dx:ASPxButton>

        </div>
    </div>
    <div class="row" style="height: 20px"></div>
    <div class="btn-toolbar">

        <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblErroe2" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblErroe2"></dx:ASPxLabel>

        </div>
        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
            <dx:ASPxLabel ID="lblErrorMessage" runat="server" CssClass="Alert" ForeColor="Red" Text="" ClientInstanceName="lblErrorMessage"></dx:ASPxLabel>

            <%--<dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table"  ValidationGroup="OnSave"></dx:ASPxValidationSummary>--%>
        </div>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxLabel ID="lblFKMaterialTypeID" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>

    </div>
    <div id="divprint">
        <dx:ASPxFormLayout ID="flSampleReceiveList" runat="server" DataSourceID="SampleReceiveListDS" ClientInstanceName="flSampleReceiveList" ColCount="2">
            <Items>

                <dx:LayoutGroup Caption="Job Order Details" ColCount="6" ColSpan="2">
                    <Items>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>

                        <dx:LayoutItem Caption="Sample Number" FieldName="SampleNo" ColSpan="2" CaptionStyle-Font-Bold="true" HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSampleNo" Width="100" HorizontalAlign="Center" CaptionStyle-Font-Bold="true" Font-Bold="true" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>

                        <dx:LayoutItem Caption="Receive Date" FieldName="ReceiveDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtReceiveDate" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="RSS Number" FieldName="FKRSSMasterId" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbRSSNumber" DataSourceID="RSSMasterDS" runat="server" ValueType="System.Int64" ValueField="RSSMasterId" TextField="RSSNumber"
                                        AutoPostBack="true" DropDownStyle="DropDownList" OnSelectedIndexChanged="cmbRSSNumber_SelectedIndexChanged">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>

                        <dx:LayoutItem Caption="Job Order Number" FieldName="FKJobOrderMasterID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKJobOrderMasterID" runat="server" ValueField="JobOrderMasterID" DataSourceID="JobOrderMasterDS" ValueType="System.Int64" Width="250px"
                                        AutoPostBack="true" TextFormatString="{0} - ({2:dd MMM yyyy}) - {1}" DropDownStyle="DropDownList" OnSelectedIndexChanged="cmbFKJobOrderMasterID_SelectedIndexChanged">
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
                        <dx:LayoutItem Caption="Customer" FieldName="FKCustomerID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKCustomerID" runat="server" ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS"
                                        ValueType="System.Int32" ReadOnly="true" ClientEnabled="false" DropDownButton-ClientVisible="false" Width="220px">
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project" FieldName="FKProjectID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKProjectID" runat="server" ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS" OnDataBound="cmbFKProjectID_DataBound"
                                        ValueType="System.Int32" ReadOnly="true" ClientEnabled="false" DropDownButton-ClientVisible="false" AutoPostBack="true" Width="250px">
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Project" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Project Number" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtAshghalCode" runat="server" ReadOnly="true" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project Owner" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtProjectOwner" runat="server" ReadOnly="true" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Project Contractor" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtProjectContractor" runat="server" ReadOnly="true" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project Type" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtProjectType" runat="server" ReadOnly="true" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Project Location" FieldName="TestID" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtProjectLocation" runat="server" ReadOnly="true" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project Consultant" FieldName="TestID" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtProjectConsultant" runat="server" ReadOnly="true" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>


                        <dx:LayoutItem Caption="Consultant Name" FieldName="ConsultantName" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtConsultantName" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Consultant Mobile No" FieldName="ConsultantMobile" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtConsultantMobileNo" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Contact Person at Site" FieldName="SiteContactPerson" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSiteContactPerson" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Contact Person Mobile No" FieldName="SiteContactMobile" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSiteContactMobile" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Deliverer Name" FieldName="DelivererName" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtDelivererName" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Deliverer Mobile No" FieldName="DelivererMobile" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtDelivererMobile" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Supplier" FieldName="Supplier" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSupplier" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Source" FieldName="Source" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSource" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Sample Details" ColCount="6" ColSpan="2">
                    <Items>
                        <dx:LayoutItem Caption="Sampling Date" FieldName="SamplingDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtSamplingDate" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Sample Description" FieldName="SampleDescription" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSampleDescription" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Sample Location" FieldName="SampleLocation" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSampleLocation" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Sampled by" FieldName="SampledByID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox ID="tknSampledByID" runat="server" Width="330px" DataSourceID="SampledDS" ClientInstanceName="tknSalItems"
                                        TextField="Name" ValueField="Value" ItemValueType="System.Int32" AllowCustomTokens="false">
                                        <ListBoxStyle CssClass="HideScroll" />
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Sample By Name" FieldName="SampledByName" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSampledByName" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Site Ref No." FieldName="SiteRefNo" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSiteRefNo" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Sample brought in by" FieldName="SampleBroughtInByID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox ID="tknSampleBroughtInByID" runat="server" Width="330px" DataSourceID="SampledDS" ClientInstanceName="tknSalItems"
                                        TextField="Name" ValueField="Value" ItemValueType="System.Int32">
                                        <ListBoxStyle CssClass="HideScroll" />
                                    </dx:ASPxTokenBox>
                                    <%--<dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                        <Items>
                                            <dx:ListEditItem Text="Ex_Work" Value="1" Selected="true" />
                                            <dx:ListEditItem Text="FOB" Value="2" />
                                            <dx:ListEditItem Text="CF" Value="3" />
                                            <dx:ListEditItem Text="CIF" Value="4" />
                                        </Items>
                                    </dx:ASPxRadioButtonList>--%>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Brought in by Name" FieldName="SampleBroughtInByName" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSampleBroughtInByName" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Brought in Date" FieldName="SampleBroughtInDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtBroughtinDate" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Layer No." FieldName="LayerNo" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtLayerNo" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Other Details" ColCount="6" ColSpan="2">
                    <Items>
                        <dx:LayoutItem Caption="Service Section" FieldName="FKMaterialTypeID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKMaterialTypeID" runat="server" Width="250" ValueField="MaterialTypeID" TextField="MaterialName"
                                        DataSourceID="MaterialsTypesDS" AutoPostBack="true" OnSelectedIndexChanged="cmbMaterials_SelectedIndexChanged" ValueType="System.Int32">
                                        <ClearButton Visibility="True"></ClearButton>
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Material Group" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Material Details" FieldName="FKMaterialDetailsID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKMaterialDetailsID" runat="server" Width="200" ValueField="MaterialDetailsID" TextField="MaterialName"
                                        DataSourceID="MaterialsListDS" AutoPostBack="true" OnSelectedIndexChanged="cmbMaterials_SelectedIndexChanged" ValueType="System.Int32">
                                        <ClearButton Visibility="True"></ClearButton>
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Material Details" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Material Class" FieldName="MaterialClass" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtMaterialClass" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Received Qty" FieldName="ReceivedQty" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit SpinButtons-ShowIncrementButtons="false" NumberType="Integer" DisplayFormatString="N0"
                                        AllowMouseWheel="false" ID="txtReceivedQty" runat="server" Number="0">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Enter Received Qty" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Unit" FieldName="FKPriceUnitID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKPriceUnitID" runat="server" Width="200" ValueField="PriceUnitID" TextField="UnitName"
                                        DataSourceID="PriceUnitListDS" ValueType="System.Int32">
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Material Details" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Retention period" FieldName="RetentionPeriod" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <%--<dx:ASPxSpinEdit ID="txtRetentionperiod" SpinButtons-ShowIncrementButtons="false"  
                                                     AllowMouseWheel="false" NumberType="Integer" runat="server" Number="0"></dx:ASPxSpinEdit>
                                    --%>
                                    <dx:ASPxComboBox ID="txtRetentionperiod" runat="server" ValueType="System.Int32" DropDownStyle="DropDownList" AutoPostBack="true">
                                        <Items>
                                            <dx:ListEditItem Text="15 days" Value="1" />
                                            <dx:ListEditItem Text="30 days" Value="2" />
                                            <dx:ListEditItem Text="6 months" Value="3" />
                                        </Items>

                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Sample Condition" FieldName="SampleCondition" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSampleCondition" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Condition Details" FieldName="ConditionDetails" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtConditionDetails" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Sample Temperature" FieldName="SampleTemperature" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                        AllowMouseWheel="false" ID="txtSampleTemperature" runat="server" Number="0">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Additional Sample Information" Width="25%">
                    <Items>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridView runat="server" ID="gdvCustomFields" OnRowUpdating="gdvCustomFields_RowUpdating" AutoGenerateColumns="false" ClientInstanceName="gdvCustomFields"
                                        DataSourceID="SampleReceiveMaterialCustomFieldDS" KeyFieldName="SampleReceiveCFLinkID" Width="100%">
                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn FieldName="FkCustomFieldID" Caption="Field Name" VisibleIndex="1">
                                                <PropertiesComboBox ValueField="CustomFieldID" TextField="CustomFieldName" DataSourceID="MaterialTypesCustomFieldsDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataTextColumn FieldName="Value" Caption="Value" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>

                                        </Columns>
                                        <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Cell" BatchEditSettings-ShowConfirmOnLosingChanges="true" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" AllowSort="false" />
                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                        <Settings VerticalScrollableHeight="200" ColumnMinWidth="500" VerticalScrollBarMode="Auto" />
                                        <Styles StatusBar-CssClass="statusBar" />
                                        <Styles>
                                            <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                        </Styles>

                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Available Services" Width="75%">
                    <Items>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxHiddenField runat="server" ID="hf" ClientInstanceName="hf"></dx:ASPxHiddenField>
                                    <dx:ASPxHiddenField runat="server" ID="hfT" ClientInstanceName="hfT"></dx:ASPxHiddenField>


                                    <dx:ASPxGridView runat="server" ID="gdvSampleTestList" AutoGenerateColumns="false" ClientInstanceName="gdvSampleTestList" OnCustomJSProperties="gdvSampleTestList_CustomJSProperties" OnCommandButtonInitialize="gdvSampleTestList_CommandButtonInitialize"
                                        DataSourceID="SampleReceiveTestListDS" KeyFieldName="SampleReceiveTestID" Width="100%" OnRowUpdating="gdvSampleTestList_RowUpdating" OnCellEditorInitialize="gdvSampleTestList_CellEditorInitialize" OnRowValidating="gdvSampleTestList_RowValidating"
                                         OnCustomCallback="gdvSampleTestList_CustomCallback">
                                        <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
                                        <Columns>
                                            <dx:GridViewCommandColumn Name="Check" VisibleIndex="0" ButtonType="Default" Width="30" ShowSelectCheckbox="true">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataCheckColumn Name="Enabled" VisibleIndex="1" FieldName="IsEnabled" Width="0">
                                            </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Name="FKTestID" Caption="Services Name" VisibleIndex="2" ReadOnly="true" Width="150">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Std No" VisibleIndex="3" ReadOnly="true">
                                                <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="Witness" Name="Witness" Caption="Witness" VisibleIndex="4">
                                                <PropertiesComboBox ValueType="System.Boolean">
                                                    <Items>
                                                        <dx:ListEditItem Text="Yes" Value="true" />
                                                        <dx:ListEditItem Text="No" Value="false" />
                                                    </Items>
                                                </PropertiesComboBox>
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataTextColumn FieldName="WitnessName" Name="WitnessName" Caption="Wtns. Name" VisibleIndex="5">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="Subcontract" Name="Subcontract" Caption="Sub Contracted" VisibleIndex="6">
                                                <PropertiesComboBox ValueType="System.Boolean">
                                                    <Items>
                                                        <dx:ListEditItem Text="Yes" Value="true" />
                                                        <dx:ListEditItem Text="No" Value="false" />
                                                    </Items>
                                                </PropertiesComboBox>
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKSubContractorID" Caption="Sub Cont. Name" VisibleIndex="7">
                                                <PropertiesComboBox EnableCallbackMode="true" TextField="SubContractorName" ValueField="SubContractorID" OnItemRequestedByValue="OnItemRequestedByValue" OnItemsRequestedByFilterCondition="OnItemsRequestedByFilterCondition">
                                                </PropertiesComboBox>

                                                <%--<EditFormSettings Visible="False" />--%>
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" VisibleIndex="8" ReadOnly="true">
                                                <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Price" Caption="Price" VisibleIndex="9" Visible="false">
                                                <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2"
                                                    AllowMouseWheel="false">
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Price is missing!"></ValidationSettings>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>

                                            <dx:GridViewDataTextColumn  FieldName="MinQty" Name="MinQty" Caption="Min Qty" VisibleIndex="10" ReadOnly="true">
                                                <PropertiesTextEdit NullDisplayText="" DisplayFormatString="n0" />
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataSpinEditColumn FieldName="Qty" Name="Qty" Caption="Qty" VisibleIndex="11">
                                                <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false" NumberType="Integer" DisplayFormatString="N0"
                                                    AllowMouseWheel="false">
                                                    <%--<ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings> --%>                                                    
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                         
                                            <dx:GridViewDataSpinEditColumn FieldName="Price" Name="Price" Caption="Price" VisibleIndex="12" Width="0">
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="13">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn VisibleIndex="14" ButtonType="Default" ShowEditButton="false" ShowDeleteButton="false" ShowCancelButton="false" ShowUpdateButton="false" Width="0">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server" ClientVisible="false">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-list';}" Click="function (s, e) { popTestLists.Show();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>

                                            </dx:GridViewCommandColumn>

                                        </Columns>
                                        <SettingsCommandButton>
                                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                            <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                            <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                            <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                                            <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
                                        </SettingsCommandButton>
                                        <SettingsEditing Mode="Batch" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" AllowSort="false" />
                                        <SettingsLoadingPanel Mode="ShowAsPopup" Delay="0" />
                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                        <Settings VerticalScrollableHeight="200" ColumnMinWidth="500" VerticalScrollBarMode="Auto" />
                                        <Styles StatusBar-CssClass="statusBar" />
                                        <ClientSideEvents BatchEditStartEditing="OnBatchEditStartEditing" BatchEditEndEditing="OnBatchEditEndEditing" />
                                        <ClientSideEvents BatchEditRowValidating="OnValidate" BatchEditChangesCanceling="OnBatchEditChangesCanceling" />
                                        <Styles>
                                            <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                        </Styles>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>

                <dx:LayoutGroup Caption="Available Services" Visible="true" ColSpan="2">
                    <Items>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>

                                    <dx:ASPxGridView runat="server" ID="gdvCustomTableFields" OnRowUpdating="gdvCustomTableFields_RowUpdating" OnRowDeleting="gdvCustomTableFields_RowDeleting" OnRowInserting="gdvCustomTableFields_RowInserting" AutoGenerateColumns="false" ClientInstanceName="gdvCustomTableFields"
                                        DataSourceID="SampleReceiveMaterialTableCustomFieldDS" KeyFieldName="RowIndex" Width="100%" OnBatchUpdate="gdvCustomTableFields_BatchUpdate">
                                        <Columns>
                                            <dx:GridViewCommandColumn Name="CommandColumn" VisibleIndex="22" ButtonType="Image" ShowDeleteButton="true" ShowEditButton="true" ShowCancelButton="true" ShowNewButtonInHeader="true" ShowUpdateButton="true" CellStyle-HorizontalAlign="<%$ Resources:GlobalResource, align %>" Width="60">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton ID="BtnNew" runat="server" AutoPostBack="false" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" EnableTheming="false">
                                                        <ClientSideEvents Click="function (s, e) { gdvCustomTableFields.AddNewRow();}" />
                                                        <Image AlternateText="<%$ Resources:GlobalResource, EditFormNew %>" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" Url="../images/Add_New.png"></Image>
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>
                                                <%-- <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="Del" Text="Delete" Visibility="BrowsableRow">
                                                    <Image Url="../images/grd_Delete.png"></Image>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>--%>
                                            </dx:GridViewCommandColumn>
                                        </Columns>
                                        <SettingsCommandButton>
                                            <DeleteButton ButtonType="Image">
                                                <Image Url="../images/grd_Delete.png"></Image>
                                            </DeleteButton>
                                            <NewButton ButtonType="Image">
                                                <Image Url="../images/Add_New.png"></Image>
                                            </NewButton>
                                        </SettingsCommandButton>
                                        <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Cell" BatchEditSettings-ShowConfirmOnLosingChanges="true" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />

                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                        <Settings VerticalScrollableHeight="200" ColumnMinWidth="500" VerticalScrollBarMode="Auto" />
                                        <Styles StatusBar-CssClass="statusBar" />
                                        <%--<ClientSideEvents CustomButtonClick="onCustomDelete" />--%>
                                        <Styles>
                                            <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                        </Styles>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>

            </Items>
        </dx:ASPxFormLayout>          

        <div id="divattachfile" style="width: 100%; height: inherit" runat="server" visible ="false">
        <div class="hidden" id="divattachfilemsg" runat="server" style="width: 500px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="ASPxLabel1" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
        </div>
        <div class="table" style="padding-left: 10px; padding-right: 10px; padding-top: 10px">
            <div class="divrow">
                <div style="float: left; margin-right: 80px;">
                    <dx:ASPxUploadControl ID="UploadControl" runat="server" ClientInstanceName="UploadControl" Width="320"
                        NullText="Select multiple files..." UploadMode="Advanced" ShowUploadButton="True" ShowProgressPanel="True"
                        OnFileUploadComplete="UploadControl_FileUploadComplete" FileUploadMode="OnPageLoad">
                        <AdvancedModeSettings EnableMultiSelect="True" EnableFileList="True" EnableDragAndDrop="True">
                            <FileListItemStyle CssClass="pending dxucFileListItem"></FileListItemStyle>
                        </AdvancedModeSettings>
                        <%--<ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png">
                                    </ValidationSettings>--%>
                        <ValidationSettings
                            AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png"
                            MaxFileSize="10485760">
                        </ValidationSettings>
                        <ClientSideEvents FileUploadStart="function(s, e) { }" FileUploadComplete="onFileUploadComplete" />
                    </dx:ASPxUploadControl>
                    <br />
                    <br />
                    <p class="note">
                        <dx:ASPxLabel ID="AllowedFileExtensionsLabel" runat="server" Text="Allowed file extensions: .rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png" Font-Size="8pt">
                        </dx:ASPxLabel>
                        <br />
                        <dx:ASPxLabel ID="MaxFileSizeLabel" runat="server" Text="Maximum file size: 4 MB." Font-Size="8pt">
                        </dx:ASPxLabel>
                    </p>
                </div>
            </div>
            <div class="divrow">
                <dx:ASPxRoundPanel ID="FilContents" ClientInstanceName="gridpanel" runat="server" Width="400" Height="180" HeaderText="Attached Files">
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridView ID="gdvfiles" ClientInstanceName="gdvfiles" runat="server" DataSourceID="TransactionAttachmentsDS" KeyFieldName="FileID" Width="380" OnCustomCallback="gdvfiles_CustomCallback"  OnRowCommand="gdvfiles_RowCommand">
                                <Columns>
                                    <dx:GridViewDataHyperLinkColumn FieldName="FileName" Caption="File" Width="250">
                                        <DataItemTemplate>
                                            <a target='blank' style="display: block; text-wrap: avoid; width: 100px" onclick='return ShowScreenshotWindow(event, this);'><%#Eval("FileName") %></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataHyperLinkColumn>
                                    <dx:GridViewDataTextColumn FieldName="FileSize" Name="filesize" Caption="Size" Width="50">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Name="Delete" Width="30">
                                        <DataItemTemplate>
                                            <dx:ASPxButton ID="BtnDelete" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false" EnableViewState="false" CommandName="delete" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                <Image Url="../images/cross_icon.png" ToolTip="Remove"></Image>
                                            </dx:ASPxButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Name="Edit" Width="25">
                                        <DataItemTemplate>
                                             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <dx:ASPxButton ID="BtnEdit" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" EnableTheming="false" EnableViewState="false" CommandName="download" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                        <Image AlternateText="<%$ Resources:GlobalResource, EditFormUpdate %>" ToolTip="download" Url="../images/download4.jpg"></Image>
                                                    </dx:ASPxButton>
                                                 </ContentTemplate>
                                                <Triggers>
                                                    <asp:postbacktrigger controlid="BtnEdit" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <SettingsCommandButton>
                                    <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                    <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                    <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                </SettingsCommandButton>
                                <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="true" />
                                <SettingsPager PageSize="5" Mode="ShowPager"></SettingsPager>
                                <ClientSideEvents BeginCallback="function(s,e){FilesGridEdited=true;}" />
                            </dx:ASPxGridView>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </div>
        </div>
        </div>

        <div id="divsessionattachfile" style="width: 100%; height: inherit" runat="server">
            <div class="hidden" id="divsessionattachfilemsg" runat="server" style="width: 500px;">
                <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
            </div>
            <div class="table" style="padding-left: 10px; padding-right: 10px; padding-top: 10px">
                <div class="divrow">
                    <div style="float: left; margin-right: 80px;">
                        <dx:ASPxUploadControl ID="SessionUploadControl" runat="server" ClientInstanceName="SessionUploadControl" Width="320"
                            NullText="Select multiple session files..." UploadMode="Advanced" ShowUploadButton="True" ShowProgressPanel="True"
                            OnFileUploadComplete="UploadControl_SessionFileUploadComplete" FileUploadMode="OnPageLoad">
                            <AdvancedModeSettings EnableMultiSelect="True" EnableFileList="True" EnableDragAndDrop="True">
                                <FileListItemStyle CssClass="pending dxucFileListItem"></FileListItemStyle>
                            </AdvancedModeSettings>
                            <ValidationSettings
                                AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png"
                                MaxFileSize="10485760">
                            </ValidationSettings>
                            <ClientSideEvents FileUploadStart="function(s, e) { }" FileUploadComplete="onSessionFileUploadComplete" />
                        </dx:ASPxUploadControl>
                        <br />
                        <br />
                        <p class="note">
                            <dx:ASPxLabel ID="SessionAllowedFileExtensionsLabel" runat="server" Text="Allowed file extensions: .rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png" Font-Size="8pt">
                            </dx:ASPxLabel>
                            <br />
                            <dx:ASPxLabel ID="SessionMaxFileSizeLabel" runat="server" Text="Maximum file size: 4 MB." Font-Size="8pt">
                            </dx:ASPxLabel>
                        </p>
                    </div>
                </div>
                <div class="divrow">
                    <dx:ASPxRoundPanel ID="SessionFileContents" ClientInstanceName="gridpanel" runat="server" Width="400" Height="180" HeaderText="Session Attached Files">
                        <PanelCollection>
                            <dx:PanelContent>
                                <dx:ASPxGridView ID="gdvSessionFiles" ClientInstanceName="gdvSessionFiles" runat="server" DataSourceID="SessionAttachmentsDS" KeyFieldName="FileID" Width="380" OnCustomCallback="gdvSessionFiles_CustomCallback" OnRowCommand="gdvSessionFiles_RowCommand">
                                    <Columns>
                                        <dx:GridViewDataHyperLinkColumn FieldName="FileName" Caption="File" Width="250">
                                            <DataItemTemplate>
                                                <a target='blank' style="display: block; text-wrap: avoid; width: 100px" onclick='return ShowScreenshotWindow(event, this);'><%#Eval("FileName") %></a>
                                            </DataItemTemplate>
                                        </dx:GridViewDataHyperLinkColumn>
                                        <dx:GridViewDataTextColumn FieldName="FileSize" Name="filesize" Caption="Size" Width="50">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataColumn Name="Delete" Width="30">
                                            <DataItemTemplate>
                                                <dx:ASPxButton ID="BtnDelete" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false" EnableViewState="false" CommandName="delete" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                    <Image Url="../images/cross_icon.png" ToolTip="Remove"></Image>
                                                </dx:ASPxButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <SettingsCommandButton>
                                        <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                        <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                        <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                    </SettingsCommandButton>
                                    <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="true" />
                                    <SettingsPager PageSize="5" Mode="ShowPager"></SettingsPager>
                                    <ClientSideEvents BeginCallback="function(s,e){FilesGridEdited=true;}" />
                                </dx:ASPxGridView>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </div>
            </div>
        </div>        
    </div>   

    <asp:ObjectDataSource ID="SessionAttachmentsDS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAttachmentsWithNew" TypeName="PioneerLab.Pages.SessionAttachedFilesDB"
        ConflictDetection="CompareAllValues"
        DataObjectTypeName="BusinessLayer.AttachedFiles"
        DeleteMethod="DeleteData">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblTransID" DefaultValue="0" Name="transID" PropertyName="Text" Type="Int64" />
            <asp:ControlParameter ControlID="lblTransTypeID" PropertyName="Text" DefaultValue="22222" Name="transTypeID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="TransactionAttachmentsDS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAttachmentsWithNew" TypeName="BusinessLayer.Pages.AttachedFilesDB"
        ConflictDetection="CompareAllValues"
        DataObjectTypeName="BusinessLayer.AttachedFiles"
        DeleteMethod="DeleteData">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblTransID" DefaultValue="0" Name="transID" PropertyName="Text" Type="Int64" />
            <asp:ControlParameter ControlID="lblTransTypeID" PropertyName="Text" DefaultValue="22222" Name="transTypeID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SubcontractorsListDS" runat="server" TypeName="BusinessLayer.Pages.SubcontractorsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.SubcontractorsList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveNonExpiredJobOrder"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CustomersListDS" runat="server" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SampledDS" runat="server" TypeName="PioneerLab.Pages.SampleReceive" SelectMethod="GetSampledList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MaterialsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsDB"
        SelectMethod="GetByFKMaterialTypeID" DataObjectTypeName="BusinessLayer.MaterialsDetails">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flSampleReceiveList$cmbFKMaterialTypeID" PropertyName="Value" DefaultValue="0" Name="FKMaterialTypeID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="PriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SampleReceiveMaterialCustomFieldDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveMaterialCustomFieldDB"
        SelectMethod="GetNonTableFieldsByFKMaterialTypeIDWithSession" UpdateMethod="UpdateSampleMaterialCustomFieldWithSession" DataObjectTypeName="BusinessLayer.SampleReceiveMaterialCustomField">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flSampleReceiveList$cmbFKMaterialTypeID" PropertyName="Value" DefaultValue="0" Name="FKMaterialTypeID" Type="Int32" />
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="SampleID" Type="Int32" />
        </SelectParameters>

    </asp:ObjectDataSource>
    <%-- DataObjectTypeName="BusinessLayer.SampleReceiveMaterialTableCustomField"--%>

    <asp:ObjectDataSource ID="SampleReceiveMaterialTableCustomFieldDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveMaterialTableCustomFieldDB"
        SelectMethod="GetTableCustomFieldDynamicTable" UpdateMethod="UpdateDataWithSession" InsertMethod="InsertDataWithSession" DeleteMethod="Delete">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flSampleReceiveList$cmbFKMaterialTypeID" PropertyName="Value" DefaultValue="0" Name="FKMaterialTypeID" Type="Int32" />
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="SampleID" Type="Int64" />
        </SelectParameters>

    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="MaterialTypesCustomFieldsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialTypesCustomFieldsDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialTypesCustomFields"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SampleReceiveListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveListDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update"
        OnInserting="SampleReceiveListDS_Inserting" OnInserted="SampleReceiveListDS_Inserted"
        OnUpdating="SampleReceiveListDS_Updating" OnUpdated="SampleReceiveListDS_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SampleReceiveTestListDS" runat="server" DataObjectTypeName="BusinessLayer.SampleReceiveTestList" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveTestListDB"
        SelectMethod="GetByMasterIDFromSession"
        UpdateMethod="UpdateToSession">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
            <asp:ControlParameter ControlID="ctl00$body$flSampleReceiveList$cmbFKJobOrderMasterID" PropertyName="Value" Name="JobOrderMasterID" Type="Int64" />
            <asp:ControlParameter ControlID="ctl00$body$flSampleReceiveList$cmbFKMaterialTypeID" PropertyName="Value" Name="MaterialTypeID" Type="Int32" />
            <asp:ControlParameter ControlID="ctl00$body$flSampleReceiveList$cmbFKMaterialDetailsID" PropertyName="Value" Name="MaterialDetailsID" Type="Int32" />

        </SelectParameters>
        <%--<UpdateParameters> OnInserting="" OnInserted="" OnUpdating=""
            <asp:Parameter Type="Object" Name="entity" />
        </UpdateParameters>--%>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ServiceListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAllServiceByMaterial" DataObjectTypeName="BusinessLayer.TestsList">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flSampleReceiveList$cmbFKMaterialTypeID" PropertyName="Value" Name="MaterialTypeID" Type="Int32" />
            <asp:ControlParameter ControlID="ctl00$body$flSampleReceiveList$cmbFKMaterialDetailsID" PropertyName="Value" Name="MaterialDetailsID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="RSSMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.RSSMasterDB"
        DataObjectTypeName="BusinessLayer.RSSMaster" SelectMethod="GetNotSampled" DeleteMethod="Delete"></asp:ObjectDataSource>
</asp:Content>