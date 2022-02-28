<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="WorkOrderData.aspx.cs" Inherits="PioneerLab.Pages.WorkOrderData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
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
            <li class="active" id="menulink">Work Order Data</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Work Order Data</h1>
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

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary fa fa-floppy-o" ValidationGroup="OnSave" OnClick="BtnSave_Click">
            </dx:ASPxButton>
        </div>
        <%-- <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="BtnAddQutaion" runat="server" EnableTheming="false" Text="Add Quotaion" CssClass="btn btn-round btn-primary 	fa fa-share-square-o"  OnClick="BtnUpdate_Click">
            </dx:ASPxButton>
        </div>--%>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default fa fa-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>
        </div>  
      <div class="btn-group" role="group" aria-label="First group" style="float: right">
            <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
                <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
                <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
            </div>

        </div> 
             
        </div>
     <div class="row" style="height: 3px"></div>
       <div class="btn-toolbar">
                        <dx:ASPxTextBox ID="WOid" runat="server" ClientInstanceName="WOid" ClientVisible="false" Text="0"></dx:ASPxTextBox>
                    </div>
                    <div class="divrow" id="contentDiv">
                        

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
                                                                <dx:ASPxDateEdit ID="dtStartDate" ClientInstanceName="dtStartDate" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="End Date" FieldName="EndDate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxDateEdit ID="dtEndDate" ClientInstanceName="dtEndDate"  runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>

                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Site Name" FieldName="SiteName" ColSpan="4">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtSiteName" runat="server" ClientInstanceName="txtSiteName" ></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="ShiftStatus" FieldName="ShiftStatus" ColSpan="4">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxComboBox ID="cmbShiftStatus" runat="server" ClientInstanceName="cmbShiftStatus" ValueType="System.Int32"
                                                                    DropDownStyle="DropDownList" >
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
                                                                <dx:ASPxSpinEdit ID="txtRegularWorkHrs"  SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                     AllowMouseWheel="false" NumberType="Integer"  ClientInstanceName="txtRegularWorkHrs" runat="server" ></dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Ramadan Working Hours" FieldName="RamadanWorkHrs" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtRamadanWorkHrs" SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                     AllowMouseWheel="false" NumberType="Integer"   ClientInstanceName="txtRamadanWorkHrs" runat="server" ></dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Monthly Rate" FieldName="MonthlyRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtMonthlyRate" SpinButtons-ShowIncrementButtons="false"
                                                     AllowMouseWheel="false"     ClientInstanceName="txtMonthlyRate" runat="server" ></dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Unit Of Addition" FieldName="UnitOfAddition" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtUnitOfAddition" ClientInstanceName="txtUnitOfAddition" runat="server" ></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Extra Working Hour Rate" FieldName="ExtraWorkHourRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtExtraWorkHourRate" SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                     AllowMouseWheel="false" NumberType="Integer"  ClientInstanceName="txtExtraWorkHourRate" runat="server" ></dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Night Shift Percentage" FieldName="NightShiftPerc" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtNightShiftPerc" SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                     AllowMouseWheel="false" NumberType="Integer"   ClientInstanceName="txtNightShiftPerc" runat="server" ></dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                     <dx:LayoutItem Caption="Description" FieldName="Description" ColSpan="4">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="txtDescription" runat="server" Width="520" ClientInstanceName="txtDescription" ></dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                     <dx:EmptyLayoutItem ColSpan="3" ></dx:EmptyLayoutItem>
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
                <dx:ASPxLabel ID="lblErrorMessage" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>

                                                                      <%--  <dx:ASPxButton ID="btnUpdateWorkOrder" EnableTheming="false" ClientInstanceName="btnUpdateWorkOrder" ClientVisible="false" runat="server"
                                                                            CssClass="btn btn-mini btn-round btn-primary fa fa-floppy-o" Height="35" Width="60" OnClick="btnUpdateWorkOrder_Click">
                                                                        </dx:ASPxButton>

                                                                    </div>
                                                                    <div style="display: inline-block;">

                                                                        <dx:ASPxButton ID="btnCancelUpdateWorkOrder" ClientInstanceName="btnCancelUpdate" ClientVisible="false" runat="server"
                                                                            CssClass="btn btn-mini btn-sm btn-round btn-primary fa fa-remove" Height="35" Width="60">
                                                                            <ClientSideEvents Click="function (s, e) { SetWorkorderControls(false);sid.SetValue(0);}" />
                                                                        </dx:ASPxButton>--%>
                                                                    </div>
                                                                </div>


                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>
                                            
                                        </Items>
                                    </dx:ASPxFormLayout>
                              
                    </div>
                 
                    <div style="width: 100%; height: 5px"></div>

                    <div>
                    </div>

     <asp:ObjectDataSource ID="WorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}"
          OnUpdating="WorkOrderDS_Updating" OnUpdated="WorkOrderDS_Updated" UpdateMethod="Update"  TypeName="BusinessLayer.Pages.WorkOrderListDB"
        SelectMethod="GetByID">
        <SelectParameters>
            <asp:ControlParameter ControlID="WOid" PropertyName="Text" DefaultValue="0" Name="id" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
             
</asp:Content>
