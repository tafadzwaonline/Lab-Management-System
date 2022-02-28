<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="WorkOrderTimeSheet.aspx.cs" Inherits="PioneerLab.Pages.WorkOrderTimeSheet" %>

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


                    var StartTime = s.batchEditApi.GetCellValue(e.visibleIndex, "StartTime");
                    var EndTime = s.batchEditApi.GetCellValue(e.visibleIndex, "EndTime");
                    var Breake = s.batchEditApi.GetCellValue(e.visibleIndex, "Breake");

                    var h = Math.abs((EndTime.getTime() - StartTime.getTime()) / 3600000)
                    total = h  - Breake;
                    s.batchEditApi.SetCellValue(e.visibleIndex, "WorkHrs", total);
                   
                }, 10);

            }
            function OnValidate(s, e) {
                isValidRow = true;
                var StartTimeColumnIndex = s.GetColumnById("StartTime").index;
                var EndTimeColumnIndex = s.GetColumnById("EndTime").index;
               

                var StartTimeValue = e.validationInfo[StartTimeColumnIndex].value;
                var EndTimeValue = e.validationInfo[EndTimeColumnIndex].value;
               
                var h = Math.abs((EndTimeValue.getTime() - StartTimeValue.getTime()) / 3600000)
               // alert(h);
                isValidRow = e.validationInfo[EndTimeColumnIndex].isValid;
                if (EndTimeValue.getTime() / 3600000 < StartTimeValue.getTime() / 3600000) {
                    e.validationInfo[EndTimeColumnIndex].isValid = false;
                    e.validationInfo[EndTimeColumnIndex].errorText = "end time should be large than start time";
                    isValidRow = false;
                }

                

                if (isValidRow) {
                    s.batchEditHelper.ApplyValidationInfo(e.visibleIndex, { isValid: isValidRow, dict: e.validationInfo });
                }
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

    </div>
            <div class="btn-group" role="group" aria-label="First group">

              <dx:ASPxButton ID="btnSave" ValidationGroup="savegrp" CausesValidation="true" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" Style="width: 80px" AutoPostBack="false"  runat="server"  Text="Save">
                   <ClientSideEvents Click="function(s,e) {gdvJobOrderWorkSheet.UpdateEdit();}" />
              </dx:ASPxButton>
                                  
            </div>
                           
            <div class="btn-group" role="group" aria-label="First group">
               <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" AutoPostBack="false" Style="width: 80px" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Text="Cancel">
                     <ClientSideEvents Click="function(s,e){ if ( confirm('Are you sure you want to cancel all changes?') == true) {gdvJobOrderWorkSheet.CancelEdit()}}" />
                  </dx:ASPxButton>
             </div>
         </div>
        
    <div class="row" style="height: 20px"></div>
         
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
                                       TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}" DropDownStyle="DropDownList" >
                                       <%-- <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Job Order" />
                                        </ValidationSettings>--%>
                                   <Columns>
                                            <dx:ListBoxColumn FieldName="JobOrderMasterID" Caption="Job Order No" Width="60" />
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
                                    runat="server"  AutoPostBack="true"
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
                                <dx:ASPxDateEdit ID="dtFromdate" Width="150" runat="server" CssClass="textbox" ReadOnly="true">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp">
                                        <RequiredField IsRequired="true" ErrorText="Enter Date" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </td>
                            <td>
                                <dx:ASPxLabel ID="lblToDate" runat="server" Text="To" Width="80"></dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxDateEdit ID="dtTodate" Width="150" runat="server" CssClass="textbox" ReadOnly="true">
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
    <div>
     <%--   <h5>Active Work Order</h5>--%>
    </div>
        <div class="btn-toolbar">
                <dx:ASPxGridView runat="server" ID="GdvJobOrderWorkSheet" AutoGenerateColumns="false" DataSourceID="JobOrderWorkSheetDS" Width="100%" ClientInstanceName="gdvJobOrderWorkSheet"
                    KeyFieldName="WorkOrderTimeSheetId" >
                    <Columns>
                        <dx:GridViewDataComboBoxColumn FieldName="FkEmpID" Caption="Technician" Width="120" VisibleIndex="0" CellStyle-HorizontalAlign="Left">
                            <PropertiesComboBox ValueField="EmpID" TextField="EmpName" DataSourceID="EmpListDS">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="80" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="StartTime" Name="StartTime" Caption="Start Time" Width="80" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date" Width="80" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="EndTime" Name="EndTime" Caption="End Time" Width="80" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                            <PropertiesTimeEdit EditFormat="Time" DisplayFormatInEditMode="true" DisplayFormatString="hh:mm tt" EditFormatString="hh:mm tt"></PropertiesTimeEdit>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataTextColumn FieldName="Day" Caption="Day"  ReadOnly="true" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="WorkStatus" Caption="Work Status" Width="150" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                              <PropertiesComboBox TextField="WorkStatus" ValueField="Work Status" ValueType="System.String">
                                            <Items>
                                                <dx:ListEditItem Text="Duty" Value="Duty" />
                                                <dx:ListEditItem Text="Holiday" Value="Holiday" />
                                            </Items>
                                           
                                        </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="Breake" Name="Breake" Caption="Break" Width="100" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                            <PropertiesTextEdit>
                               <ValidationSettings CausesValidation="true">
                                    <RegularExpression ErrorText="Invalid  Value (Eg: 25.34)" ValidationExpression="^\d{1,8}([.]\d{1,4})?$" />
                               </ValidationSettings>
                             </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="IsRamadan" Caption="Ramadan" Width="70" VisibleIndex="8" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                         <dx:GridViewDataTextColumn FieldName="WorkHrs" Name="WorkHrs" Caption="Work Hours" Width="100" VisibleIndex="9" CellStyle-HorizontalAlign="Left">
                            <PropertiesTextEdit>
                                <ValidationSettings CausesValidation="true">
                                  <RegularExpression ErrorText="Invalid  Value (Eg: 25.34)" ValidationExpression="^\d{1,8}([.]\d{1,4})?$" />
                                 </ValidationSettings>
                             </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataCheckColumn FieldName="IsInvoiced" ReadOnly="true" Caption="Invoiced" Width="60" VisibleIndex="10" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn FieldName="InvoiceNumber" ReadOnly="true" Caption="Invoice No." Width="90" VisibleIndex="11" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataTextColumn>
                       

                    </Columns>
                    <SettingsEditing Mode="Batch">
                        <BatchEditSettings StartEditAction="Click" AllowValidationOnEndEdit="true" EditMode="Cell" ShowConfirmOnLosingChanges="true" AllowEndEditOnValidationError="true" />
                    </SettingsEditing>
                    <SettingsBehavior ConfirmDelete="True" ColumnResizeMode="Control"/>
                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                    <Styles StatusBar-CssClass="statusBar" />
                     <%--<Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible" />--%>
                     <ClientSideEvents BatchEditRowValidating="OnValidate" BatchEditEndEditing="OnBatchEditEndEditing" />
                </dx:ASPxGridView>
        </div>
     <%--     <div>
        <h5>Expired Work Order</h5>
    </div>
        <div class="btn-toolbar">
                <dx:ASPxGridView runat="server" ID="GdvExpiredJobOrderWorkSheet" AutoGenerateColumns="false" DataSourceID="ExpiredJobOrderWorkSheetDS" Width="100%" ClientInstanceName="gdvexpiredJobOrderWorkSheet"
                    KeyFieldName="WorkOrderTimeSheetId"  >
                    <Columns>
                        <dx:GridViewDataComboBoxColumn FieldName="FkEmpID" Caption="Technician" Width="120" VisibleIndex="0" CellStyle-HorizontalAlign="Left">
                            <PropertiesComboBox ValueField="EmpID" TextField="EmpName" DataSourceID="EmpListDS">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="80" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="StartTime" Caption="Start Time" Width="80" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date" Width="80" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="EndTime" Caption="End Time" Width="80" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                            <PropertiesTimeEdit EditFormat="Time" DisplayFormatInEditMode="true" DisplayFormatString="hh:mm tt" EditFormatString="hh:mm tt"></PropertiesTimeEdit>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataTextColumn FieldName="Day" Caption="Day"  ReadOnly="true" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="WorkStatus" Caption="Work Status" Width="150" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                              <PropertiesComboBox TextField="WorkStatus" ValueField="Work Status" ValueType="System.String">
                                            <Items>
                                                <dx:ListEditItem Text="Duty" Value="Duty" />
                                                <dx:ListEditItem Text="Holiday" Value="Holiday" />
                                            </Items>
                                           
                                        </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="Breake" Caption="Break" Width="100" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                            <PropertiesTextEdit>
                               <ValidationSettings CausesValidation="true">
                                    <RegularExpression ErrorText="Invalid  Value (Eg: 25.34)" ValidationExpression="^\d{1,8}([.]\d{1,4})?$" />
                               </ValidationSettings>
                             </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="IsRamadan" Caption="Ramadan" Width="70" VisibleIndex="8" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                         <dx:GridViewDataTextColumn FieldName="WorkHrs" Caption="Work Hours" Width="100" VisibleIndex="9" CellStyle-HorizontalAlign="Left">
                            <PropertiesTextEdit>
                                <ValidationSettings CausesValidation="true">
                                  <RegularExpression ErrorText="Invalid  Value (Eg: 25.34)" ValidationExpression="^\d{1,8}([.]\d{1,4})?$" />
                                 </ValidationSettings>
                             </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataCheckColumn FieldName="IsInvoiced" ReadOnly="true" Caption="Invoiced" Width="60" VisibleIndex="10" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn FieldName="InvoiceNumber" ReadOnly="true" Caption="Invoice No." Width="90" VisibleIndex="11" CellStyle-HorizontalAlign="Left">
                        </dx:GridViewDataTextColumn>
                       

                    </Columns>
                    <SettingsEditing Mode="inline">
                        <BatchEditSettings StartEditAction="Click" AllowValidationOnEndEdit="true" EditMode="Cell" ShowConfirmOnLosingChanges="true" AllowEndEditOnValidationError="true" />
                    </SettingsEditing>
                    <SettingsBehavior ConfirmDelete="True" ColumnResizeMode="Control"/>
                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                    <Styles StatusBar-CssClass="statusBar" />
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible" />


                </dx:ASPxGridView>
        </div>--%> 
    </div>
    <asp:ObjectDataSource ID="JobOrderWorkSheetDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderTimeSheetDB"
        DataObjectTypeName="BusinessLayer.WorkOrderTimeSheet" SelectMethod="GetAllActive" UpdateMethod="UpdateMappingWithSession">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="WorkOrderID" Type="Int32" />

        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ExpiredJobOrderWorkSheetDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderTimeSheetDB"
        DataObjectTypeName="BusinessLayer.WorkOrderTimeSheet" SelectMethod="GetAllExpired" >
         <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="WorkOrderID" Type="Int32" />

        </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="ColumnMappingDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestExcelMappingDB"
        SelectMethod="GetMappingListByMasterIDWithSession" UpdateMethod="UpdateMappingWithSession" DataObjectTypeName="BusinessLayer.ViewExcelCellFieldMapping">
       
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
