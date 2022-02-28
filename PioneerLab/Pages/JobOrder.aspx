﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="JobOrder.aspx.cs" Inherits="PioneerLab.Pages.JobOrder" %>

<%--<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>--%>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v18.2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <script type="text/javascript">
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

        function ValidateDate() {
            var startDate = dtTransactionDate.GetDate();

            var ExpiryDate = dtExpiryDate.GetDate();

            if ((Date.parse(ExpiryDate) <= Date.parse(startDate))) {
                alert("Expiry Date should be greater than Received Date....!")
                //document.getElementById("AdvEndDate1").innerText = "End Date should be greater than From Date....!";
                // document.getElementById("dtEndDate").value = "";
            }

        };

        function GoToServer(s, e) {
            //var onserver = true;
            // alert(onserver);

            e.processOnServer = onserver;
            onserver = false
        }

        function OnEndCallback(s, e) {  
            //gridJobOrderDetailsList.Refresh();
            location.reload();
        }  

    </script>
    <style type="text/css">
        .hideList {
            display:none;
        }
             </style>
    <%--<style type="text/css">
        table.dxeTextBoxSys, table.dxeMemoSys, table.dxeButtonEditSys,table.dxeEditAreaSys, table.dxeButtonEdit,
         td.dxeButtonEditButton,table.dxeListBox_MetropolisBlue{
            border-radius: 5px;
            -moz-border-radius: 5px;
            -khtml-border-radius: 5px;
            -webkit-border-radius: 5px;
        }
    </style>--%>
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
            <li class="active" id="menulink">Job Order</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Job Order</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary fa fa-floppy-o" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
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
        <%--<div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnSaveVersion" runat="server" EnableTheming="false" Text="Save New Version" CssClass="btn btn-round btn-primary fa fa-clipboard" ValidationGroup="OnSave" OnClick="BtnSaveVersion_Click">
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>--%>
        <div class="btn-group" role="group" aria-label="First group" style="float: right">
            <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
                <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
                <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
            </div>

        </div>
    </div>
    <div class="row" style="height: 3px"></div>
    <div class="btn-toolbar">


        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
            <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup="OnSave"></dx:ASPxValidationSummary>
        </div>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
         <dx:ASPxLabel ID="lblQutaionMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>

        <dx:ASPxLabel ID="lblActiveMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxFormLayout ID="flJobOrderMaster" runat="server" DataSourceID="JobOrderMasterDS" ClientInstanceName="flJobOrderMaster">
            <Items>
                <dx:LayoutGroup ShowCaption="False" ColCount="8">
                    <Items>
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem Width="100" />

                        <dx:LayoutItem ShowCaption="False" FieldName="IsActive" HorizontalAlign="Right" Height="40">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsActive" runat="server" Text="Active" TextAlign="Right"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="JobOrder No" FieldName="JobOrderNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtJobOrderNumber" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Date" FieldName="TransactionDate" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtTransactionDate" ClientEnabled ="false" DropDownButton-ClientVisible="false" ClientInstanceName="dtTransactionDate"  ReadOnly="true" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Customer Quotation" FieldName="FKQuotationMasterID" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKQuotationMasterID" runat="server" Width="200" ValueField="QuotationMasterID" DataSourceID="QuotationMasterDS" ValueType="System.Int64"
                                        OnSelectedIndexChanged="cmbFKQuotationMasterID_SelectedIndexChanged" AutoPostBack="true" TextFormatString="{0} - ({1:d}) - {2} - {3}" CssClass="textbox" DropDownStyle="DropDownList">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer Quotation" />
                                        </ValidationSettings>
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="QuotationNo" Caption="Quotation No" Width="100" />
                                            <dx:ListBoxColumn FieldName="EntryDate" Caption="Date" Width="68" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem ShowCaption="False"  ColSpan="2" >
                            <LayoutItemNestedControlCollection >
                                <dx:LayoutItemNestedControlContainer  >
                                  <dx:ASPxButton ID="btnAddQuotation"   runat="server" Text="Add More Quotation"  CssClass="btn-primary fa fa-mail-forward">
                                        <ClientSideEvents Click="function (s, e) { PopQutaion.Show();}" />
                                  </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Customer" FieldName="FKCustomerID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKCustomerID" runat="server" Width="550" ValueField="CustomerID" TextField="CustomerName"
                                        DataSourceID="CustomersListDS" ValueType="System.Int32" ReadOnly="true" ClientEnabled ="false" DropDownButton-ClientVisible="false" >
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="order Ref No" FieldName="LPONumber" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtLPONumber" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Project" FieldName="FKProjectID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKProjectID" runat="server" Width="550" ValueField="ProjectID" ClientEnabled ="false" DropDownButton-ClientVisible="false"  TextField="ProjectName"
                                        DataSourceID="ProjectsListDS" ValueType="System.Int32" ReadOnly="true">
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Project" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Expiry Date" FieldName="ExpiryDate" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtExpiryDate" runat="server" ClientInstanceName="dtExpiryDate" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Enter Expiry Date!" />

                                        </ValidationSettings>
                                          <ClientSideEvents  DateChanged= ValidateDate />

                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <%--<dx:EmptyLayoutItem ColSpan="2" />--%>

                        <dx:LayoutItem Caption="Remarks" FieldName="Remarks" ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo ID="txtRemarks" runat="server" Width="525" Height="40"></dx:ASPxMemo>
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

                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup ShowCaption="False" ColCount="8">
                    <Items>
                        <dx:LayoutItem Caption=" " ColSpan="8">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridView runat="server" ID="GdvJobOrderDetailsList" AutoGenerateColumns="false" ClientInstanceName="gridJobOrderDetailsList" OnCellEditorInitialize="GdvJobOrderDetailsList_CellEditorInitialize"
                                        DataSourceID="JobOrderDetailsDS" KeyFieldName="JobOrderDetailsID" OnRowUpdating="GdvJobOrderDetailsList_RowUpdating" Width="100%" OnCustomButtonInitialize="GdvJobOrderDetailsList_CustomButtonInitialize">
                                        <Columns>
                                             <dx:GridViewCommandColumn VisibleIndex="0" Width="2%">
                                                <CustomButtons>
                                                    <dx:GridViewCommandColumnCustomButton ID="btnWarning" Text=" " Visibility="Invisible" >
                                                        <Styles>
                                                            <Style Font-Size="Medium" ForeColor="Orange" CssClass="glyphicon glyphicon-question-sign"></Style>
                                                        </Styles>
                                                    </dx:GridViewCommandColumnCustomButton>
                                                </CustomButtons>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKMaterialTypeID" Caption="Service Section" VisibleIndex="1" ReadOnly="true" Width="10%">
                                                <PropertiesComboBox ValueField="MaterialTypeID" TextField="MaterialName" DataSourceID="MaterialsTypesDS" DropDownRows="1"  ListBoxStyle-CssClass="hideList">
                                                    <DropDownButton ClientVisible="false" Enabled="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKMaterialDetailsID" Caption="Material Details" VisibleIndex="2" ReadOnly="true" Width="10%">
                                                <PropertiesComboBox ValueField="MaterialDetailsID" TextField="MaterialName" DataSourceID="AllMaterialsListDS" DropDownRows="1"  ListBoxStyle-CssClass="hideList">
                                                    <DropDownButton ClientVisible="false" Enabled="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Services Name" VisibleIndex="3" ReadOnly="true" Width="10%">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS" DropDownRows="1" ListBoxStyle-CssClass="hideList">
                                                    <DropDownButton ClientVisible="false" Enabled="false"></DropDownButton>
                                                    
                                                </PropertiesComboBox>
                                                <Settings  AutoFilterCondition="Contains"/>
                                                <EditFormSettings Visible="False" />
                                              </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Standard Number" VisibleIndex="4" ReadOnly="true"  Width="8%">
                                                <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1"  ListBoxStyle-CssClass="hideList">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>

                                            <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" VisibleIndex="5" ReadOnly="true"  Width="8%" >
                                                <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS"  ListBoxStyle-CssClass="hideList">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Price" Caption="Price" ReadOnly="true" VisibleIndex="6" CellStyle-HorizontalAlign="Left" Width="8%">
                                                <PropertiesSpinEdit DecimalPlaces="2" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2">
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Price is missing!"></ValidationSettings>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>

                                            <dx:GridViewDataSpinEditColumn FieldName="MinQty" Caption="Minimum Qty" VisibleIndex="7" CellStyle-HorizontalAlign="Left" Width="8%">
                                                <PropertiesSpinEdit  SpinButtons-ShowIncrementButtons="false" NumberType="Integer" DisplayFormatString="N0">
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="8" CellStyle-HorizontalAlign="Left" Width="12%">
                                            <Settings AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            
                                            <dx:GridViewDataTextColumn FieldName="Status" Visible="false" Caption="" Width="0" VisibleIndex="9" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataCheckColumn FieldName="IsEnable" Caption="Enable/Disable" Width="100" VisibleIndex="10" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <dx:ASPxCheckBox ID="chk" runat="server" AutoPostBack="false" ClientInstanceName="ChangeAccount" Value='<%# Bind("IsEnable") %>' OnInit="chk_Init">
                                                    </dx:ASPxCheckBox>
                                                </DataItemTemplate>    
                                                <PropertiesCheckEdit></PropertiesCheckEdit>
                                            </dx:GridViewDataCheckColumn>
                                                                                        
                                            <dx:GridViewCommandColumn VisibleIndex="11" ButtonType="Default" Width="4%"
                                                ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server" ClientVisible="false">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-list';}" Click="function (s, e) { popTestLists.Show();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>
                                                <CustomButtons>
                                                    <dx:GridViewCommandColumnCustomButton ID="btnWorkOrder" Text=" ">
                                                        <Styles>
                                                            <Style Font-Size="Medium" CssClass="glyphicon glyphicon-list-alt"></Style>
                                                        </Styles>
                                                    </dx:GridViewCommandColumnCustomButton>
                                                </CustomButtons>
                                            </dx:GridViewCommandColumn>
                                            
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
                                        <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom"  />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior ConfirmDelete="True" ColumnResizeMode="NextColumn"  />
                                        <Settings ShowFilterRow="True"/>
                                        
                                       <%-- <Settings VerticalScrollableHeight="950" VerticalScrollBarMode="Visible"  />
                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>--%>
                                        <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); vi.SetValue(e.visibleIndex);vid.SetValue(key);if(e.buttonID == 'btnWorkOrder'){ gridWorkOrderList.PerformCallback();popupWorkOrder.Show();}ASPxClientEdit.ClearEditorsInContainerById('contentDiv'); }" />
                                    </dx:ASPxGridView>
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
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="" Font-Bold="true" Font-Size="Large" ForeColor="red" ClientInstanceName="ASPxLabel2"></dx:ASPxLabel>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                
                <dx:LayoutGroup ShowCaption="False" ColCount="8">
                    <Items>

                        <dx:LayoutItem Caption="Receive Credit Limit" FieldName="ReceiveCreditLimit" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtReceiveCreditLimit"   runat="server" MinValue="0" Number="0"  DisplayFormatString="n2"  SpinButtons-ShowIncrementButtons="false"
                                                     AllowMouseWheel="false"></dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Report Credit Limit" FieldName="ReportCreditLimit" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtReportCreditLimit"   runat="server" Number="0" MinValue="0" SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                     AllowMouseWheel="false" ></dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="No. of unpaid bills" FieldName="UnpaidReceiveLimit" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtUnpaidReceiveLimit"  runat="server" MinValue="0" DecimalPlaces="0" Number="0" SpinButtons-ShowIncrementButtons="false"
                                                     AllowMouseWheel="false" NumberType="Integer"></dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>
    <div>
        <dx:ASPxPopupControl ID="PopQutaion" runat="server" CloseAction="CloseButton" OnWindowCallback="PopQutaion_WindowCallback"
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Add Quotaion" ClientInstanceName="PopQutaion">
           
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                  <div class="divrow" id="Div1">
                        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" ClientInstanceName="cpnl">
                            <PanelCollection>
                                <dx:PanelContent>


             <dx:ASPxFormLayout ID="flCustomerJobOrderMaster" runat="server" DataSourceID="CustomerJobOrderMasterDS" ClientInstanceName="flCustomerJobOrderMaster">
            <Items>
               
                <dx:LayoutGroup ShowCaption="False" ColCount="4">
                    <Items>
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem Width="100" />

                      

                        <dx:LayoutItem Caption="Customer Quotation"  ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="CmbQuotation" runat="server" Width="200" ValueField="QuotationMasterID" DataSourceID="CustomerQuotaionDS" ValueType="System.Int64"
                                        OnSelectedIndexChanged="CmbQuotation_SelectedIndexChanged" AutoPostBack="true" TextFormatString="{0} - ({1:d})" CssClass="textbox" DropDownStyle="DropDownList">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer Quotation" />
                                        </ValidationSettings>
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="QuotationNo" Caption="Quotation No" Width="100" />
                                            <dx:ListBoxColumn FieldName="EntryDate" Caption="Date" Width="68" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />

                                        </Columns>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         

                        <dx:LayoutItem Caption="Customer"   ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbCustomer" ClientEnabled ="false"  runat="server" Width="550" ValueField="CustomerID" TextField="CustomerName"
                                        DataSourceID="CustomersListDS" ValueType="System.Int32" ReadOnly="true">
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Customer" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                       

                        <dx:LayoutItem Caption="Project"  ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbProject" runat="server" Width="550" ValueField="ProjectID" ClientEnabled ="false"  TextField="ProjectName"
                                        DataSourceID="ProjectsListDS" ValueType="System.Int32" ReadOnly="true">
                                        <%--<ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Project" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--<dx:EmptyLayoutItem ColSpan="2" />--%>

                   
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup ShowCaption="False" ColCount="4">
                    <Items>
                        <dx:LayoutItem Caption=" " ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridView runat="server" ID="GdvCustomerQuotaion" AutoGenerateColumns="false" ClientInstanceName="gdvCustomerQuotaion" OnCellEditorInitialize="GdvCustomerQuotaion_CellEditorInitialize"
                                        DataSourceID="CustomerJobOrderDetailsDS" KeyFieldName="JobOrderDetailsID"  Width="100%" OnCustomButtonInitialize="GdvCustomerQuotaion_CustomButtonInitialize">
                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKMaterialTypeID" Caption="Service Section" VisibleIndex="1" ReadOnly="true">
                                                <PropertiesComboBox ValueField="MaterialTypeID" TextField="MaterialName" DataSourceID="MaterialsTypesDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKMaterialDetailsID" Caption="Material Details" VisibleIndex="2" ReadOnly="true">
                                                <PropertiesComboBox ValueField="MaterialDetailsID" TextField="MaterialName" DataSourceID="AllMaterialsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Services Name" VisibleIndex="3" ReadOnly="true">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Standard Number" VisibleIndex="4" ReadOnly="true">
                                                <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>

                                            <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" VisibleIndex="5" ReadOnly="true">
                                                <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Price" Caption="Price" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit DecimalPlaces="2" SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2">
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Price is missing!"></ValidationSettings>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>

                                            <dx:GridViewDataSpinEditColumn FieldName="MinQty" Caption="Minimum Qty" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit   SpinButtons-ShowIncrementButtons="false" NumberType="Integer" >
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="8" CellStyle-HorizontalAlign="Left">
                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataSpinEditColumn FieldName="IsEnable" Caption="Enable/Disable" VisibleIndex="9" CellStyle-HorizontalAlign="Center">
                                                <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false" DisplayFormatString="n2">                                                    
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>

                                            <dx:GridViewCommandColumn VisibleIndex="10" ButtonType="Default" Width="60"
                                                ShowClearFilterButton="true" ShowEditButton="false" ShowDeleteButton="false" ShowCancelButton="false" ShowUpdateButton="false">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server" ClientVisible="false">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-list';}" Click="function (s, e) { popTestLists.Show();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>
                                                <CustomButtons>
                                                    <dx:GridViewCommandColumnCustomButton ID="btnCustomerWorkOrder" Text=" " Visibility="Invisible">
                                                        <Styles>
                                                            <Style Font-Size="Medium" CssClass="glyphicon glyphicon-list-alt" ></Style>
                                                        </Styles>
                                                    </dx:GridViewCommandColumnCustomButton>
                                                </CustomButtons>
                                            </dx:GridViewCommandColumn>
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
                                        <SettingsPager PageSize="5"></SettingsPager>
                                        <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                                        <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); vi.SetValue(e.visibleIndex);vid.SetValue(key); gridWorkOrderList.PerformCallback();ASPxClientEdit.ClearEditorsInContainerById('contentDiv'); }" />
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <%--<dx:LayoutItem Caption=" " ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="" Font-Bold="true" Font-Size="Large" ForeColor="red" ClientInstanceName="ASPxLabel2"></dx:ASPxLabel>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                    </Items>
                </dx:LayoutGroup>
               
            </Items>
        </dx:ASPxFormLayout>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxCallbackPanel>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <dx:ASPxButton ID="btnAddQuotaion" runat="server" Text="Add Quotaion" CssClass="btn btn-round btn-primary fa fa-floppy-disk" OnClick="btnAddQuotaion_Click">
                    </dx:ASPxButton>
                </div>
                       <div>
                           
                       </div>    
                            
            </FooterTemplate>

            <%--<ClientSideEvents PopUp="function(s, e) { PopQutaion.PerformCallback(); }" />--%>
        </dx:ASPxPopupControl>
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
        <dx:ASPxPopupControl ID="popupWorkOrder" runat="server" CloseAction="CloseButton" OnWindowCallback="popTestLists_WindowCallback"
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
                        <dx:ASPxTextBox ID="vid" runat="server" ClientInstanceName="vid" ClientVisible="false" Text="0"></dx:ASPxTextBox>
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
                                                                <dx:ASPxSpinEdit ID="txtRegularWorkHrs"  SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                     AllowMouseWheel="false" NumberType="Integer"  ClientInstanceName="txtRegularWorkHrs" runat="server" ClientEnabled="false">
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
                                                                <dx:ASPxSpinEdit ID="txtRamadanWorkHrs" SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                     AllowMouseWheel="false" NumberType="Integer"   ClientInstanceName="txtRamadanWorkHrs" runat="server" ClientEnabled="false">
                                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSavedet" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="" />
                                        </ValidationSettings>
                                                                </dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Monthly Rate" FieldName="MonthlyRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtMonthlyRate" SpinButtons-ShowIncrementButtons="false"
                                                     AllowMouseWheel="false"     ClientInstanceName="txtMonthlyRate" runat="server" ClientEnabled="false">
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
                                                                <dx:ASPxTextBox ID="txtUnitOfAddition" ClientInstanceName="txtUnitOfAddition" runat="server" ClientEnabled="false">
                                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSavedet" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="" />
                                        </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <dx:LayoutItem Caption="Extra Working Hour Rate" FieldName="ExtraWorkHourRate" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="txtExtraWorkHourRate" SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
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
                                                                <dx:ASPxSpinEdit ID="txtNightShiftPerc" SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                                     AllowMouseWheel="false" NumberType="Integer"   ClientInstanceName="txtNightShiftPerc" runat="server" ClientEnabled="false"></dx:ASPxSpinEdit>
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

                                                                        <dx:ASPxButton ID="btnUpdateWorkOrder" EnableTheming="false" ValidationGroup="OnSavedet"  ClientInstanceName="btnUpdateWorkOrder" ClientVisible="false" runat="server"
                                                                            CssClass="btn btn-mini btn-round btn-primary fa fa-floppy-o" Height="35" Width="60" OnClick="btnUpdateWorkOrder_Click">
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
                                                                    DataSourceID="WorkOrderListDS" KeyFieldName="WorkOrderID" Width="100%" OnCustomCallback="GdvWorkOrderList_CustomCallback">
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="WorkOrder No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                                                        <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataDateColumn FieldName="StartDate" Caption="Start Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                                                            <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                                                                             </PropertiesDateEdit>
                                                                        </dx:GridViewDataDateColumn>
                                                                        <dx:GridViewDataDateColumn FieldName="EndDate" Caption="End Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                                                                        
                                                                        <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                                                                         </PropertiesDateEdit></dx:GridViewDataDateColumn>
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
                                                                                        Click="function (s, e) { SetWorkorderControls(true);sid.SetValue(0);ASPxClientEdit.ClearEditorsInContainerById('contentDiv');onserver = true; }" />
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
                                                                    <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
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
    <dx:ASPxCallback ID="cb" runat="server" ClientInstanceName="cb" OnCallback="cb_Callback" ClientSideEvents-EndCallback="OnEndCallback">
    </dx:ASPxCallback>

    <asp:ObjectDataSource ID="QuotationMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationMasterDB"
        DataObjectTypeName="BusinessLayer.QuotationMaster" SelectMethod="GetActivePending">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="jobOrderMasterId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="CustomerQuotaionDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationMasterDB"
        DataObjectTypeName="BusinessLayer.QuotationMaster" SelectMethod="GetActivePendingByCustomerAndProject">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="jobOrderMasterId" Type="Int32" />
     
            <%--<asp:SessionParameter SessionField="QuotaionMasterId"  DefaultValue="0" Name="QuotaionMasterId" Type="Int32" />--%>
        </SelectParameters>
         </asp:ObjectDataSource>
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

    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete"
        OnInserting="JobOrderMasterDS_Inserting" OnInserted="JobOrderMasterDS_Inserted"
        OnUpdating="JobOrderMasterDS_Updating" OnUpdated="JobOrderMasterDS_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="CustomerJobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete"
        OnInserting="JobOrderMasterDS_Inserting" OnInserted="JobOrderMasterDS_Inserted"
        OnUpdating="JobOrderMasterDS_Updating" OnUpdated="JobOrderMasterDS_Updated">
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
    <asp:ObjectDataSource ID="JobOrderDetailsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderDetailsDB"
        SelectMethod="GetByMasterIDFromSession" InsertMethod="InsertList" OnInserting="JobOrderDetailsDS_Inserting" OnInserted="JobOrderDetailsDS_Inserted"
        UpdateMethod="UpdateToSession" OnUpdating="JobOrderDetailsDS_Updating">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Type="Object" Name="entity" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CustomerJobOrderDetailsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderDetailsDB"
        SelectMethod="GetByCustomerMasterIDFromSession" InsertMethod="InsertList" OnInserting="JobOrderDetailsDS_Inserting" OnInserted="JobOrderDetailsDS_Inserted"
        UpdateMethod="UpdateToSession" OnUpdating="JobOrderDetailsDS_Updating">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblQutaionMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
       
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="WorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        SelectMethod="GetByIDFromSession">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$popupWorkOrder$sid" PropertyName="Text" DefaultValue="0" Name="id" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="WorkOrderListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        SelectMethod="GetByMasterIDFromSession" InsertMethod="InsertToSession" UpdateMethod="UpdateToSession" DeleteMethod="DeleteFromSession"
        OnInserting="WorkOrderListDS_Inserting" OnUpdating="WorkOrderListDS_Updating">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$popupWorkOrder$vid" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
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
