<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="TimeSheet.aspx.cs" Inherits="PioneerLab.Pages.TimeSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagePath" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
         <style>
        .statusBar a:first-child {
            display: none;
        }

        .statusBar {
            display: none;
        }
    </style>
        <script type="text/javascript">

            function CheckGridChanges(s, e) {
                if (gdvJobOrderWorkSheet.batchEditApi.HasChanges()) {
                    var x = confirm('Are you sure you want to perform this action? \n\n All unsaved grid data will be lost.\n\n');
                    if (x == true) {
                        gdvJobOrderWorkSheet.CancelEdit();

                        SetCombo(s, true);
                    }
                    else {
                        e.processOnServer = false;
                        SetCombo(s, false);
                    }
                }
                else {
                    SetCombo(s, true);
                }
            }
            function SetCombo(s, f) {

                var string = s.name.toLowerCase();
                if (string.indexOf("cmbJobOrder") !== -1)
                { if (f) cmbJobOrderi = s.GetSelectedIndex(); else s.SetSelectedIndex(cmbJobOrderi); }
                else if (string.indexOf("cmbworkOrder") !== -1)
                { if (f) cmbworkOrderi = s.GetSelectedIndex(); else s.SetSelectedIndex(cmbworkOrderi); }

            }
            function OnBatchEditEndEditing(s, e) {
                window.setTimeout(function () {
                    var mode = lblMode.GetValue();

                    var StartTime = s.batchEditApi.GetCellValue(e.visibleIndex, "StartTime");
                    var EndTime = s.batchEditApi.GetCellValue(e.visibleIndex, "EndTime");
                    var Breake = s.batchEditApi.GetCellValue(e.visibleIndex, "Breake");
                    
                    if (StartTime != null && EndTime!=null) {
                        var h = Math.abs((EndTime.getTime() - StartTime.getTime()) / 3600000)
                        if(Breake!=null)
                        h = h - Breake;
                        s.batchEditApi.SetCellValue(e.visibleIndex, "WorkHrs", h);

                        if (mode == "View") {

                              var IsApproved = s.batchEditApi.GetCellValue(e.visibleIndex, "IsApproved");
                            s.batchEditApi.SetCellValue(e.visibleIndex, "IsChecked", IsApproved);
                        }
                    }
                }, 10);

            }
            function OnBatchEditStartEditing(s, e) {
              
                var mode = lblMode.GetValue();
                        if (mode == "Check") {

                            if (e.focusedColumn.fieldName == "FkEmpID" || e.focusedColumn.fieldName == "StartTime" || e.focusedColumn.fieldName == "EndTime" || e.focusedColumn.fieldName == "Breake" ||
                                e.focusedColumn.fieldName == "WorkStatus" || e.focusedColumn.fieldName == "ShiftStatus" || e.focusedColumn.fieldName == "WorkHrs" || e.focusedColumn.fieldName == "IsRamadan" || e.focusedColumn.fieldName == "IsApproved" || e.focusedColumn.fieldName == "command") {
                                e.cancel = true;
                            }
                            var FkEmpID = s.batchEditApi.GetCellValue(e.visibleIndex, "FkEmpID");
                            var IsApproved = s.batchEditApi.GetCellValue(e.visibleIndex, "IsApproved");
                            if (FkEmpID == null || IsApproved==true)
                                e.cancel = true;

                            }
                            if (mode == "Approve" ) {
                                if (e.focusedColumn.fieldName == "FkEmpID" || e.focusedColumn.fieldName == "StartTime" || e.focusedColumn.fieldName == "EndTime" || e.focusedColumn.fieldName == "Breake" ||
                                e.focusedColumn.fieldName == "WorkStatus" || e.focusedColumn.fieldName == "ShiftStatus" || e.focusedColumn.fieldName == "WorkHrs" || e.focusedColumn.fieldName == "command")
                                {
                                    e.cancel = true;
                                }
                                var IsInvoiced = s.batchEditApi.GetCellValue(e.visibleIndex, "IsInvoiced");

                                if ( IsInvoiced == true)
                                    e.cancel = true;
                            }
                            if (mode == "false") {
                                
                                if (e.focusedColumn.fieldName == "IsChecked" || e.focusedColumn.fieldName == "IsApproved") {
                                    e.cancel = true;
                                }
                                var IsChecked = s.batchEditApi.GetCellValue(e.visibleIndex, "IsChecked");

                                if (IsChecked == true)
                                    e.cancel = true;
                            }
                    
                            if (mode == "View") {
                                if (e.focusedColumn.fieldName == "FkEmpID" || e.focusedColumn.fieldName == "StartTime" || e.focusedColumn.fieldName == "EndTime" || e.focusedColumn.fieldName == "Breake" ||
                                e.focusedColumn.fieldName == "WorkStatus" || e.focusedColumn.fieldName == "ShiftStatus" || e.focusedColumn.fieldName == "WorkHrs" || e.focusedColumn.fieldName == "IsRamadan" || e.focusedColumn.fieldName == "IsChecked" || e.focusedColumn.fieldName == "command") {
                                    e.cancel = true;
                                }
                                var IsInvoiced = s.batchEditApi.GetCellValue(e.visibleIndex, "IsInvoiced");

                                if (IsInvoiced == true)
                                    e.cancel = true;

                                var FkEmpID = s.batchEditApi.GetCellValue(e.visibleIndex, "FkEmpID");
                                var IsApproved = s.batchEditApi.GetCellValue(e.visibleIndex, "IsApproved");
                                if (FkEmpID == null)
                                    e.cancel = true;
                               
                                s.batchEditApi.SetCellValue(e.visibleIndex, "IsChecked", IsApproved);
                            }
                           // alert(mode);
                            if (mode == 0) {
                                
                                if (e.focusedColumn.fieldName == "IsChecked" || e.focusedColumn.fieldName == "IsApproved" )
                                    e.cancel = true;
                                }
                               
                            }
            function OnValidate(s, e) {
                isValidRow = true;
                var StartTimeColumnIndex = s.GetColumnById("StartTime").index;
                var EndTimeColumnIndex = s.GetColumnById("EndTime").index;
               

                var StartTimeValue = e.validationInfo[StartTimeColumnIndex].value;
                var EndTimeValue = e.validationInfo[EndTimeColumnIndex].value;
                if (StartTimeValue != null && EndTimeValue!=null) {
                    var h = Math.abs((EndTimeValue.getTime() - StartTimeValue.getTime()) / 3600000)
                    // alert(h);
                    isValidRow = e.validationInfo[EndTimeColumnIndex].isValid;
                    if (EndTimeValue.getTime() / 3600000 < StartTimeValue.getTime() / 3600000) {
                        e.validationInfo[EndTimeColumnIndex].isValid = false;
                        e.validationInfo[EndTimeColumnIndex].errorText = "end time should be large than start time";
                        isValidRow = false;
                    }

                }

                if (isValidRow) {
                    s.batchEditHelper.ApplyValidationInfo(e.visibleIndex, { isValid: isValidRow, dict: e.validationInfo });
                }
            }
            function CheckTime(s, e) {
                var StartTime = tdStartTime.GetValue();
                var EndTime = tdEndTime.GetValue();
              
                if (StartTime != null && EndTime != null) {
                   
                  
                    if (EndTime.getTime() / 3600000 < StartTime.getTime() / 3600000) {
                        alert("end time should be large than start time");
                    }

                }
            } 
            function ClearData(s, e) {
                e.isValidRow = true;
                s.batchEditApi.SetCellValue(e.visibleIndex, "FkEmpID","");
                s.batchEditApi.SetCellValue(e.visibleIndex, "StartTime",null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "EndTime", null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "Breake", null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "WorkStatus", null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "ShiftStatus", null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "IsRamadan", null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "StartTime", null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "WorkHrs", null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "IsChecked", null);
                s.batchEditApi.SetCellValue(e.visibleIndex, "IsApproved", null);
            }
            function Select(s, e) {

                var S = SelectAll.GetValue();
                var grid = ASPxClientGridView.Cast(gdvJobOrderWorkSheet);
                var indicies = grid.batchEditHelper.GetDataItemVisibleIndices();

                var mode = lblMode.GetValue();
                if (mode == "Check")
                {
                    for (var i = 0; i < indicies.length; i++) {
                        var FkEmpID = grid.batchEditApi.GetCellValue(indicies[i], "FkEmpID");
                        var IsApproved = grid.batchEditApi.GetCellValue(indicies[i], "IsApproved");
                       
                        if (FkEmpID != null && IsApproved !=true)
                        grid.batchEditApi.SetCellValue(indicies[i], "IsChecked", S);
                    }
                }
                if (mode == "Approve")
                    {
                    for (var i = 0; i < indicies.length; i++) {
                        var FkEmpID = grid.batchEditApi.GetCellValue(indicies[i], "FkEmpID");
                        var IsInvoiced = grid.batchEditApi.GetCellValue(indicies[i], "IsInvoiced");

                        if (FkEmpID != null && IsInvoiced !=true)
                        grid.batchEditApi.SetCellValue(indicies[i], "IsApproved", S);
                    }
                }

               
               
            }
            function ApplayData(s, e) {
                var grid = ASPxClientGridView.Cast(gdvJobOrderWorkSheet);
                var indicies = grid.batchEditHelper.GetDataItemVisibleIndices();

                var Technician = cmbTechnician.GetValue();
                var StartTime = tdStartTime.GetValue();
                var EndTime = tdEndTime.GetValue();
                var WorkStatus = cmbWorkStatus.GetValue();
                var ShiftStatus = cmbShiftStatus.GetValue();
                var Breake = txtBreak.GetValue();
                var IsRamadan = ckIsRamadan.GetValue();


                    for (var i = 0; i < indicies.length; i++) {
                        var FkEmpID = grid.batchEditApi.GetCellValue(indicies[i], "FkEmpID");
                        var STime = grid.batchEditApi.GetCellValue(indicies[i], "StartTime");
                        
                        if (FkEmpID == null || STime == null) {
                            grid.batchEditApi.SetCellValue(indicies[i], "FkEmpID", Technician);
                            grid.batchEditApi.SetCellValue(indicies[i], "StartTime", StartTime);
                            grid.batchEditApi.SetCellValue(indicies[i], "EndTime", EndTime);
                            grid.batchEditApi.SetCellValue(indicies[i], "WorkStatus", WorkStatus);
                            grid.batchEditApi.SetCellValue(indicies[i], "ShiftStatus", ShiftStatus);
                            grid.batchEditApi.SetCellValue(indicies[i], "Breake", Breake);
                            grid.batchEditApi.SetCellValue(indicies[i], "IsRamadan", IsRamadan);
                            if (StartTime != null && EndTime != null) {
                                var WorkHrs = Math.abs((EndTime.getTime() - StartTime.getTime()) / 3600000)
                                if (Breake!=null)
                                 WorkHrs = WorkHrs - Breake;
                                grid.batchEditApi.SetCellValue(indicies[i], "WorkHrs", WorkHrs);

                            }
                        }
                    }
                    gdvJobOrderWorkSheet.UpdateEdit();

                }
            
        </script>

        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>
            <li><a id="menu1" href="#">Transaction</a></li>
            <li class="active" id="menulink">Work Order Time Sheet</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Work Order Time Sheet</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
     <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
         <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblMode" runat="server" ClientInstanceName="lblMode" Text="0" ForeColor="White" Width="0"></dx:ASPxLabel>


    </div>
            <div class="btn-group" role="group" aria-label="First group">
         <dx:ASPxLabel ID="lblAlowUpdate" runat="server" ClientInstanceName="lblAlowUpdate" ForeColor="White" Text="false" Visible="true"></dx:ASPxLabel>

              <dx:ASPxButton ID="btnSave" ValidationGroup="savegrp" CausesValidation="true" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" Style="width: 80px" AutoPostBack="false" OnClick="btnSave_Click"  runat="server" Text="Save">
                   <ClientSideEvents Click="function(s,e) {gdvJobOrderWorkSheet.UpdateEdit();}" />
              </dx:ASPxButton>
                                  
            </div>
                           
            <div class="btn-group" role="group" aria-label="First group">
               <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" AutoPostBack="false" Style="width: 80px" OnClick="btnCancel_Click" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Text="Back">
                     <ClientSideEvents Click="function(s,e){ if ( confirm('Are you sure you want to cancel all changes?') == true) {gdvJobOrderWorkSheet.CancelEdit()}}" />
                  </dx:ASPxButton>
             </div>
          <div class="btn-group" role="group" aria-label="First group" style="float: right">
            <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
                <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
                <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
            </div>

        </div>
         </div>
        
  
         <div style="height: 10px" ></div>
    <div class="btn-toolbar">
      

        <table cellpadding="0" cellspacing="0">

            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
                                <dx:ASPxLabel ID="lblJobOrder" runat="server" Text="Job Order" Width="120"></dx:ASPxLabel>
                            </td>
                            <td colspan="3">
                               
                                 <dx:ASPxComboBox ID="cmbJobOrder" runat="server" ValueField="JobOrderDetailsID"  AutoPostBack="true"  DataSourceID="JobOrderDS" ValueType="System.Int64" Width="550px"
                                       TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}"  DropDownButton-ClientVisible="false" ClientEnabled="false" >
                                       <%-- <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Job Order" />
                                        </ValidationSettings>--%>
                                   <Columns>
                                            <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                            <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                            <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                            <dx:ListBoxColumn FieldName="ServiceSection" Caption="Service Section" Width="100" />
                                            <dx:ListBoxColumn FieldName="MaterialDetails" Caption="Material Details" Width="100" />
                                            <dx:ListBoxColumn FieldName="ServicesName" Caption="Services Name" Width="100" />

                                        </Columns>
                                </dx:ASPxComboBox>
                              
                            </td>
                            <td>
                                <dx:ASPxLabel ID="lblWorkOrder" runat="server" Text="Work Order" Width="120"></dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbWorkOrder" Width="280" ClientInstanceName="cmbworkOrder" DataSourceID="WorkOrderDS"  CssClass="textbox" OnSelectedIndexChanged="cmbWorkOrder_SelectedIndexChanged"
                                    runat="server"  AutoPostBack="true"  DropDownButton-ClientVisible="false" ClientEnabled="false"
                                    IncrementalFilteringMode="Contains" TextFormatString="{0} -{1}" ValueType="System.Int64" ValueField="WorkOrderID">
                                    <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="true" />
                                    </ValidationSettings>--%>
                                      <Columns>
                                            <dx:ListBoxColumn FieldName="WorkOrderNo" Caption="Work Order No" Width="100" />
                                            <dx:ListBoxColumn FieldName="SiteName" Caption="SiteName" Width="150" />
                                        </Columns>
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px"></td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="lblDate" runat="server" Text="From" Width="120"></dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxDateEdit ID="dtFromdate" Width="150" runat="server" CssClass="textbox"  DisplayFormatString="dd MMM yyyy " EditFormatString="dd MMM yyyy ">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp">
                                        <RequiredField IsRequired="true" ErrorText="Enter Date" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </td>
                            <td>
                                <dx:ASPxLabel ID="lblToDate" runat="server" Text="To" Width="80"></dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxDateEdit ID="dtTodate" Width="150" runat="server" CssClass="textbox" ReadOnly="false" DisplayFormatString="dd MMM yyyy " EditFormatString="dd MMM yyyy">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp">
                                        <RequiredField IsRequired="true" ErrorText="Enter Date" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </td>
                            <td style="height: 7px;width:5px"></td>
                            </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                             <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" CssClass=" btn-success fa fa-search" ClientVisible="true" Style="margin-left: 10px" Width="120 " Height="30"  ValidationGroup="savegrp" OnClick="btnSearch_Click">
                                  <ClientSideEvents Click="function(s, e) {lpanel.Show(); e.processOnServer = true;}" /> 
                                </dx:ASPxButton>
                                <%--CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk"--%>
                            </td>
                            <td>
                                <dx:ASPxButton ID="btnInvoice" runat="server" Text="Process To Invoice" CssClass="btn-success fa fa-share" ClientVisible="true" Style="margin-left: 10px"  Width="120" Height="30" ValidationGroup="savegrp">
                                </dx:ASPxButton>
                            </td>
                        </tr>


                    </table>
                </td>


            </tr>

            <tr>
                <td style="height: 7px"></td>
                 </tr>
            
        </table>
        <table id="tbApplay" runat="server">
            <tr>
                 <td>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Technician" Width="60"></dx:ASPxLabel>
                 </td>
                <td>
                      <dx:ASPxComboBox ID="CmbTechnician" Width="170" ClientInstanceName="cmbTechnician" DataSourceID="EmpListDS"  CssClass="textbox"  AutoPostBack="false"
                                    runat="server" 
                                    IncrementalFilteringMode="Contains" TextFormatString="{0} -{1}" ValueType="System.Int64" ValueField="EmpID" TextField="EmpName">
                                   
                                </dx:ASPxComboBox>
                </td>
                 <td style="text-align:center">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Start Time" Width="70"  ></dx:ASPxLabel>
                 </td>
                <td>
                    <dx:ASPxTimeEdit runat="server" Width="70" ID="tdStartTime" ClientInstanceName="tdStartTime"></dx:ASPxTimeEdit>
                </td>
                 <td style="text-align:center">
                     <dx:ASPxLabel ID="ASPxLabel1" Width="70" runat="server" Text="End Time" ></dx:ASPxLabel>
                 </td>
                <td>
                    <dx:ASPxTimeEdit ID="tdEndTime" Width="70" runat="server" ClientInstanceName="tdEndTime">
                        <ClientSideEvents  DateChanged="CheckTime"/>
                    </dx:ASPxTimeEdit>
                </td>
                   <td style="text-align:center">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="WorkStatus" Width="70"></dx:ASPxLabel>
                 </td>
                <td>
                      <dx:ASPxComboBox ID="cmbWorkStatus" Width="65" ClientInstanceName="cmbWorkStatus" 
                                    runat="server" >
                                   <Items >
                                       
                                        <dx:ListEditItem Text="Duty" Value="Duty" />
                                        <dx:ListEditItem Text="Holiday" Value="Holiday" />
                                   </Items>
                                </dx:ASPxComboBox>
                </td>
                  <td style="text-align:center">
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Shift Status" Width="70"></dx:ASPxLabel>
                 </td>
                <td>
                      <dx:ASPxComboBox ID="cmbShiftStatus" Width="65" ClientInstanceName="cmbShiftStatus" 
                                    runat="server" >
                                   <Items >
                                       
                                        <dx:ListEditItem Text="Day" Value="1" />
                                        <dx:ListEditItem Text="Nigth" Value="2" />
                                   </Items>
                                </dx:ASPxComboBox>
                </td>
                <td style="text-align:center">
                     <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Break" Width="70"></dx:ASPxLabel>
                 </td>
                <td >
                    <dx:ASPxTextBox ID="txtBreak" Width="40" runat="server" ClientInstanceName="txtBreak" >
                        <ValidationSettings CausesValidation="true">
                                    <RegularExpression ErrorText="Invalid  Value (Eg: 25.34)" ValidationExpression="^\d{1,8}([.]\d{1,4})?$" />
                               </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                 <%--<td>
                     <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Is Ramadan" Width="50"></dx:ASPxLabel>
                 </td>--%>
                <td>
                    <dx:ASPxCheckBox ID="ckIsRamadan" ClientInstanceName="ckIsRamadan" TextAlign="Left" Text="Is Ramadan" runat="server">
                    </dx:ASPxCheckBox>
                </td>
                <td style="width:10px"></td>
                <td> <dx:ASPxButton ID="btnApplay" runat="server" Text="Applay" CssClass=" btn-success fa fa-edit" ClientVisible="true" Style="margin-left: 10px" Width="90 " Height="30"   >
                    <ClientSideEvents Click="ApplayData"/>
                                </dx:ASPxButton></td>
            </tr>
        </table>
   </div>
     <div>
      <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lpanel"
            Modal="True">
        </dx:ASPxLoadingPanel>
        </div>
        <div class="btn-toolbar">
                <dx:ASPxGridView runat="server" ID="GdvJobOrderWorkSheet" DataSourceID="JobOrderWorkSheetDS" AutoGenerateColumns="false"   Width="100%" ClientInstanceName="gdvJobOrderWorkSheet"
                    KeyFieldName="WorkOrderTimeSheetId" OnCustomButtonInitialize="GdvJobOrderWorkSheet_CustomButtonInitialize" >
                    <Columns>
                        <dx:GridViewDataComboBoxColumn FieldName="FkEmpID"  Name="FkEmpID" Caption="Technician" Width="160" VisibleIndex="0" CellStyle-HorizontalAlign="Left">
                            <PropertiesComboBox ValueField="EmpID" TextField="EmpName" DataSourceID="EmpListDS">
                            </PropertiesComboBox>
                         <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataDateColumn FieldName="StartDate" name="StartDate" ReadOnly="true" Caption="Start Date" Width="70" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                            <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="StartTime" Name="StartTime" Caption="Start Time" Width="70" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true"  Caption="End Date" Width="70" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                              <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="EndTime" Name="EndTime" Caption="End Time" Width="70" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                            <PropertiesTimeEdit EditFormat="Time" DisplayFormatInEditMode="true" DisplayFormatString="hh:mm tt" EditFormatString="hh:mm tt"></PropertiesTimeEdit>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataTextColumn FieldName="Day" Caption="Day"   ReadOnly="true" Width="95" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                        <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="WorkStatus" Name="WorkStatus" Caption="Work Status" Width="90" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                              <PropertiesComboBox TextField="WorkStatus" ValueField="Work Status" ValueType="System.String">
                                            <Items>
                                                <dx:ListEditItem Text="Duty" Value="Duty" />
                                                <dx:ListEditItem Text="Holiday" Value="Holiday" />
                                            </Items>
                                        </PropertiesComboBox>
                         <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                         <dx:GridViewDataComboBoxColumn FieldName="ShiftStatus" Name="ShiftStatus" Caption="Shift Status" Width="70" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                              <PropertiesComboBox TextField="ShiftStatus" ValueField="Shift Status" ValueType="System.String">
                                            <Items>
                                                <dx:ListEditItem Text="Day" Value="1" />
                                                <dx:ListEditItem Text="Nigth" Value="2" />
                                            </Items>
                                        </PropertiesComboBox>
                         <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="Breake" Name="Breake" Caption="Break" Width="50" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                            <PropertiesTextEdit>
                               <ValidationSettings CausesValidation="true">
                                    <RegularExpression ErrorText="Invalid  Value (Eg: 25.34)" ValidationExpression="^\d{1,8}([.]\d{1,4})?$" />
                               </ValidationSettings>
                             </PropertiesTextEdit>
                        <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="IsRamadan" Name="IsRamadan" Caption="Ramadan" Width="60" VisibleIndex="8" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                         <dx:GridViewDataTextColumn FieldName="WorkHrs" Name="WorkHrs" Caption="Work Hours" Width="80" VisibleIndex="9" CellStyle-HorizontalAlign="Left">
                            <PropertiesTextEdit>
                                <ValidationSettings CausesValidation="true">
                                  <RegularExpression ErrorText="Invalid  Value (Eg: 25.34)" ValidationExpression="^\d{1,8}([.]\d{1,4})?$" />
                                 </ValidationSettings>
                             </PropertiesTextEdit>
                        <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                           <dx:GridViewDataCheckColumn FieldName="IsChecked" name="IsChecked" Caption="Checked" Width="60" VisibleIndex="10" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                
                 <dx:GridViewDataCheckColumn FieldName="IsApproved" Name="IsApproved" Caption="Approved" Width="65" VisibleIndex="11" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                
                        <dx:GridViewDataCheckColumn FieldName="IsInvoiced" ReadOnly="true" Caption="Invoiced" Width="60" VisibleIndex="12" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn FieldName="InvoiceNumber" ReadOnly="true" Caption="Invoice No." Width="50" VisibleIndex="13" CellStyle-HorizontalAlign="Left">
                        <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                       
                           
                <dx:GridViewCommandColumn VisibleIndex="14" Name="command" ButtonType="Default" Width="30" ShowDeleteButton="false" >
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnClear" Text=" ">
                            <Styles >
                                <Style Font-Size="Medium" ForeColor="Blue" CssClass="glyphicon glyphicon-remove"></Style>
                            </Styles>
                       </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>

                    </Columns>
                     <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
                    <SettingsEditing Mode="Batch">
                        <BatchEditSettings StartEditAction="Click" AllowValidationOnEndEdit="true" EditMode="Cell" ShowConfirmOnLosingChanges="true" AllowEndEditOnValidationError="true" />
                    </SettingsEditing>
                    <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" AllowSort="false"/>
                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                    <Styles StatusBar-CssClass="statusBar" />
                    <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
                     <%--<Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible" />--%>
                     <ClientSideEvents BatchEditRowValidating="OnValidate" BatchEditStartEditing="OnBatchEditStartEditing"  BatchEditEndEditing="OnBatchEditEndEditing" CustomButtonClick="ClearData" />
                </dx:ASPxGridView>
        </div>
        
     <div class="btn-toolbar"  style="text-align: right ; float: right;margin:auto" runat="server"  >
                                       <dx:ASPxCheckBox ID="SelectAll" runat="server" Font-Bold="true" Text="Select All" ClientInstanceName="SelectAll" TextAlign="Right"  Visible="false" >
                                        <ClientSideEvents  CheckedChanged ="Select" />
                                    </dx:ASPxCheckBox>
       </div>      
           <div style="height:30px"></div>                      
        
      <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups" style="text-align: right; float: right" runat="server" id="divConfirmSection" visible="false">
        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="btnApprove" runat="server" CssClass="btn btn-round btn-success glyphicon glyphicon-ok-sign" Text="Approve" OnClick="btnApprove_Click">
                <ClientSideEvents Click="function(s,e){e.processOnServer=confirm('Are you sure to approve this job order?')==true;}" />
            </dx:ASPxButton>
        </div>
       <%-- <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="btnReject" runat="server" CssClass="btn btn-round btn-danger glyphicon glyphicon-remove-sign" Text="Reject" OnClick="Action_Click">
                <ClientSideEvents Click="function(s,e){e.processOnServer=confirm('Are you sure to reject this quotation?')==true;}" />
            </dx:ASPxButton>
        </div>--%>
        
    </div>
    <asp:ObjectDataSource ID="JobOrderWorkSheetDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderTimeSheetDB"
        DataObjectTypeName="BusinessLayer.WorkOrderTimeSheet" SelectMethod="GetAllActive" UpdateMethod="UpdateMappingWithSession" OnUpdated="JobOrderWorkSheetDS_Updated" DeleteMethod="Delete">
        <SelectParameters>
             <asp:ControlParameter ControlID="dtFromdate" PropertyName="Value"  Name="StartDate" Type="DateTime" />
            <asp:ControlParameter ControlID="dtTodate" PropertyName="Value"  Name="EndDate" Type="DateTime" />
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="WorkOrderID" Type="Int64" />
               <asp:ControlParameter ControlID="lblMode" PropertyName="Text" DefaultValue="0" Name="mode" Type="string" />

        </SelectParameters>
    </asp:ObjectDataSource>
  
   

    <asp:ObjectDataSource ID="EmpListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EmployeesListDB"
        DataObjectTypeName="BusinessLayer.EmployeesList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrderFromView"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="WorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderListDB" SelectMethod="GetbyMasterId" >
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbJobOrder" PropertyName="Value"  Name="JobOrderDetailsID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
