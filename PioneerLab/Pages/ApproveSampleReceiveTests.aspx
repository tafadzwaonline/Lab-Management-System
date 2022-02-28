<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ApproveSampleReceiveTests.aspx.cs" Inherits="PioneerLab.Pages.ApproveSampleReceiveTests" %>

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
            <li class="active" id="menulink">Approve Sample Receive Tests</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Approve Sample Receive Tests </h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div  class="btn-group" role="group" aria-label="First group">
        <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
   
            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary fa fa-save"  OnClick="BtnSave_Click">
               <ClientSideEvents Click="function(s,e){gridPendingCheckedSampleReceiveTests.UpdateEdit();gridPendingApproveSampleReceiveTests.UpdateEdit();gridSampleReceiveTests.UpdateEdit()}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default fa fa-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>
        </div> 

    <div class="row" style="height:20px"></div>
     <div>
        <h5>Pending To Checked</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingCheckedSampleReceiveTests"  AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingCheckedSampleReceiveTests"
            DataSourceID="PendingCheckedSampleReceiveTestsDS" KeyFieldName="SampleReceiveTestID" OnCellEditorInitialize="GdvPendingCheckedSampleReceiveTests_CellEditorInitialize">
           <Columns>
                <dx:GridViewDataComboBoxColumn FieldName="JobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="250" CellStyle-HorizontalAlign="Left">
                     <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - ({2:dd MMM yyyy}) - {1}"  DataSourceID="JobOrderMasterDS" Width="250px" ValueType="System.Int64">
                         <Columns>
                                            <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="100" />
                                            <dx:ListBoxColumn FieldName="LPONumber" Caption="LPO Number" Width="100" />
                                            <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                        </Columns>
                    </PropertiesComboBox>
                    <EditFormSettings Visible="False" />

                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="SampleNo" Caption="Sample No" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                    <EditFormSettings Visible="False" />

                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="SamplingDate" Caption="Sample Date" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                     <PropertiesTextEdit DisplayFormatString="dd MMM yyyy" ></PropertiesTextEdit>
                    <EditFormSettings Visible="False" />

                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Name="FKTestID"  Caption="Services Name" VisibleIndex="4" ReadOnly="true" Width="150">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName"  DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                    <EditFormSettings Visible="False" />

                  <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Std No" VisibleIndex="5" ReadOnly="true">
                 <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                   <DropDownButton ClientVisible="false"></DropDownButton>
                   </PropertiesComboBox>
                    <EditFormSettings Visible="False" />
                   <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                  
                <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" VisibleIndex="6" ReadOnly="true">
                        <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                 <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                           <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                   </ValidationSettings>
                         </PropertiesComboBox>
                            <EditFormSettings Visible="False" />
                     <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               

                <dx:GridViewDataSpinEditColumn FieldName="Qty" Name="Qty" Caption="Qty" VisibleIndex="7">
                                 <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                     AllowMouseWheel="false" >
                                                    <%--<ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings>--%>
                                       </PropertiesSpinEdit>
                    <EditFormSettings Visible="False" />

                             </dx:GridViewDataSpinEditColumn>
                                          
              
                
               <dx:GridViewDataCheckColumn FieldName="IsChecked" Name="IsChecked"  Caption="Checked" Width="60" VisibleIndex="8" CellStyle-HorizontalAlign="Center">
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
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
             <Styles StatusBar-CssClass="statusBar" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div class="row" style="height: 10px"></div>

    <div>
        <h5>Pending To Approve</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingApproveSampleReceiveTests" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingApproveSampleReceiveTests"
            DataSourceID="PendingApprovedSampleReceiveTestsDS" KeyFieldName="SampleReceiveTestID" OnCellEditorInitialize="GdvPendingApproveSampleReceiveTests_CellEditorInitialize">
             <Columns>
                <dx:GridViewDataComboBoxColumn FieldName="JobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="250" CellStyle-HorizontalAlign="Left">
                     <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - ({2:dd MMM yyyy}) - {1}"  DataSourceID="JobOrderMasterDS" Width="250px" ValueType="System.Int64">
                         <Columns>
                                            <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="100" />
                                            <dx:ListBoxColumn FieldName="LPONumber" Caption="LPO Number" Width="100" />
                                            <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                        </Columns>
                    </PropertiesComboBox>
                    <EditFormSettings Visible="False" />

                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="SampleNo" Caption="Sample No" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                    <EditFormSettings Visible="False" />

                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="SamplingDate" Caption="Sample Date" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                     <PropertiesTextEdit DisplayFormatString="dd MMM yyyy" ></PropertiesTextEdit>
                    <EditFormSettings Visible="False" />

                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Name="FKTestID"  Caption="Services Name" VisibleIndex="4" ReadOnly="true" Width="150">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName"  DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                    <EditFormSettings Visible="False" />

                  <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Std No" VisibleIndex="5" ReadOnly="true">
                 <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                   <DropDownButton ClientVisible="false"></DropDownButton>
                   </PropertiesComboBox>
                    <EditFormSettings Visible="False" />
                   <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                  
                <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" VisibleIndex="6" ReadOnly="true">
                        <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                 <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                           <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                   </ValidationSettings>
                         </PropertiesComboBox>
                            <EditFormSettings Visible="False" />
                     <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               

                <dx:GridViewDataSpinEditColumn FieldName="Qty" Name="Qty" Caption="Qty" VisibleIndex="7">
                                 <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                     AllowMouseWheel="false" >
                                                    <%--<ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings>--%>
                                       </PropertiesSpinEdit>
                    <EditFormSettings Visible="False" />

                             </dx:GridViewDataSpinEditColumn>
                                          
              
                
               <dx:GridViewDataCheckColumn FieldName="IsChecked" Name="IsChecked" ReadOnly="true"  Caption="Checked" Width="60" VisibleIndex="8" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                  <dx:GridViewDataCheckColumn FieldName="IsApproved" Name="IsApproved"  Caption="Approved" Width="60" VisibleIndex="9" CellStyle-HorizontalAlign="Center">
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
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
             <Styles StatusBar-CssClass="statusBar" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

     <div>
        <h5>Sample Receive Tests History</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvSampleReceiveTests" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridSampleReceiveTests"
            DataSourceID="CheckedApprovedSampleReceiveTestsDS" KeyFieldName="SampleReceiveTestID">
               
       <Columns>
                <dx:GridViewDataComboBoxColumn FieldName="JobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="250" CellStyle-HorizontalAlign="Left">
                     <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - ({2:dd MMM yyyy}) - {1}"  DataSourceID="JobOrderMasterDS" Width="250px" ValueType="System.Int64">
                         <Columns>
                                            <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="100" />
                                            <dx:ListBoxColumn FieldName="LPONumber" Caption="LPO Number" Width="100" />
                                            <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                        </Columns>
                    </PropertiesComboBox>
                    <EditFormSettings Visible="False" />

                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="SampleNo" Caption="Sample No" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                    <EditFormSettings Visible="False" />

                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="SamplingDate" Caption="Sample Date" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                     <PropertiesTextEdit DisplayFormatString="dd MMM yyyy" ></PropertiesTextEdit>
                    <EditFormSettings Visible="False" />

                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Name="FKTestID"  Caption="Services Name" VisibleIndex="4" ReadOnly="true" Width="150">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName"  DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                    <EditFormSettings Visible="False" />

                  <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Std No" VisibleIndex="5" ReadOnly="true">
                 <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                   <DropDownButton ClientVisible="false"></DropDownButton>
                   </PropertiesComboBox>
                    <EditFormSettings Visible="False" />
                   <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                  
                <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" VisibleIndex="6" ReadOnly="true">
                        <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                 <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                           <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                   </ValidationSettings>
                         </PropertiesComboBox>
                            <EditFormSettings Visible="False" />
                     <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               

                <dx:GridViewDataSpinEditColumn FieldName="Qty" Name="Qty" Caption="Qty" VisibleIndex="7">
                                 <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"  DisplayFormatString="n2"
                                     AllowMouseWheel="false" >
                                                    <%--<ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!"></ValidationSettings>--%>
                                       </PropertiesSpinEdit>
                    <EditFormSettings Visible="False" />

                             </dx:GridViewDataSpinEditColumn>
                                          
              
                
               <dx:GridViewDataCheckColumn FieldName="IsChecked" Name="IsChecked" ReadOnly="true"  Caption="Checked" Width="60" VisibleIndex="8" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                  <dx:GridViewDataCheckColumn FieldName="IsApproved" Name="IsApproved"  ReadOnly="true"   Caption="Approved" Width="60" VisibleIndex="9" CellStyle-HorizontalAlign="Center">
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
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
             <Styles StatusBar-CssClass="statusBar" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
   <asp:ObjectDataSource ID="PendingCheckedSampleReceiveTestsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveTestListDB"
        DataObjectTypeName="BusinessLayer.SampleReceiveTestList" SelectMethod="GetPendingCheckedSampleReceiveTests" UpdateMethod="UpdateCheckDetails">
    </asp:ObjectDataSource>
    
   <asp:ObjectDataSource ID="PendingApprovedSampleReceiveTestsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveTestListDB"
        DataObjectTypeName="BusinessLayer.SampleReceiveTestList" SelectMethod="GetPendingApprovedSampleReceiveTests"  UpdateMethod="UpdateApproveDetails" >
    </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="CheckedApprovedSampleReceiveTestsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveTestListDB"
        DataObjectTypeName="BusinessLayer.SampleReceiveTestList" SelectMethod="GetViewSampleReceiveTests" >
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrderFromView"></asp:ObjectDataSource>
 
    
        <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>

       <asp:ObjectDataSource ID="ApprovedJobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAllApproved" DeleteMethod="Delete"></asp:ObjectDataSource>
       
       <asp:ObjectDataSource ID="ExpiredJobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAllExpired" DeleteMethod="Delete"></asp:ObjectDataSource>
       
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrder"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="PriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>


</asp:Content>
