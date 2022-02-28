<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="WorkOrderManage.aspx.cs" Inherits="PioneerLab.Pages.WorkOrderManage" %>

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
            <li class="active" id="menulink">Work Order Manage</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Work Order_Entry </h1>
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
      <%--  <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>--%>
      <%--  <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
            </dx:ASPxButton>
        </div>--%>
    </div>
     <div>
        <h1>Pending Entry</h1>
    </div>
    <div style="border-style:solid ;border-width:1px;border-color:lightgray;padding:7px 4px 4px 7px">
        <h4> Active</h4>

    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvActiveWorkOrder" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder" OnCommandButtonInitialize="GdvActiveWorkOrder_CommandButtonInitialize"
            DataSourceID="PendingActiveWorkOrderDS"  KeyFieldName="WorkOrderID" OnCellEditorInitialize="GdvActiveWorkOrder_CellEditorInitialize" OnCustomErrorText="GdvActiveWorkOrder_CustomErrorText">
            
           <Columns>
                 <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="Work Order No" VisibleIndex="1" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="2" Width="400" CellStyle-HorizontalAlign="Left">
                     <PropertiesComboBox ValueField="JobOrderDetailsID" TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}"  DataSourceID="JobOrderDS" ValueType="System.Int64">
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
              
                 <dx:GridViewDataTextColumn FieldName="SiteName" Caption="Site Name" VisibleIndex="3" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="120" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                         <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                     </dx:GridViewDataDateColumn>
               <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date"  Width="120" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                     <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>  
               </dx:GridViewDataDateColumn>
               
                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"    VerticalScrollBarMode="Visible" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div class="row" style="height: 10px"></div>

    <h4> Expired</h4>
        <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingExpiredWorkOrder" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder" OnCommandButtonInitialize="GdvActiveWorkOrder_CommandButtonInitialize"
            DataSourceID="PendingExpiredWorkOrderDS" KeyFieldName="WorkOrderID" OnCellEditorInitialize="GdvActiveWorkOrder_CellEditorInitialize" OnCustomErrorText="GdvActiveWorkOrder_CustomErrorText">
            
            <Columns>
                <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="Work Order No" VisibleIndex="1" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="2" Width="400" CellStyle-HorizontalAlign="Left">
                     <PropertiesComboBox ValueField="JobOrderDetailsID" TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}"  DataSourceID="JobOrderDS" ValueType="System.Int64">
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
               
                 <dx:GridViewDataTextColumn FieldName="SiteName" Caption="Site Name" VisibleIndex="3" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="120" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
               <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date" Width="120" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                   <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
               
                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    
        </div>
    <div class="row" style="height: 10px"></div>

    <div>
        <h1>Completed Entry</h1>
    </div>
     <div style="border-style:solid ;border-width:1px;border-color:lightgray;padding:7px 4px 4px 7px">
        <h4>Active</h4>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="ASPxGridView1" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder" OnCommandButtonInitialize="GdvActiveWorkOrder_CommandButtonInitialize"
            DataSourceID="FinshedActiveWorkOrderDS" KeyFieldName="WorkOrderID" OnCellEditorInitialize="GdvActiveWorkOrder_CellEditorInitialize" OnCustomErrorText="GdvActiveWorkOrder_CustomErrorText">
            
           <Columns>
                <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="Work Order No" VisibleIndex="1" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="2" Width="400" CellStyle-HorizontalAlign="Left">
                     <PropertiesComboBox ValueField="JobOrderDetailsID" TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}"  DataSourceID="JobOrderDS" ValueType="System.Int64">
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
               
                 <dx:GridViewDataTextColumn FieldName="SiteName" Caption="Site Name" VisibleIndex="3" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="120" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
               <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date" Width="120" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                   <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
               
                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div class="row" style="height: 10px"></div>

         <h4>Expired</h4>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvFinishedExpiredWorkOrder" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder" OnCommandButtonInitialize="GdvActiveWorkOrder_CommandButtonInitialize"
            DataSourceID="FinishedExpiredWorkOrderDS" KeyFieldName="WorkOrderID" OnCellEditorInitialize="GdvActiveWorkOrder_CellEditorInitialize" OnCustomErrorText="GdvActiveWorkOrder_CustomErrorText">
            
            <Columns>
               <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="Work Order No" VisibleIndex="1" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="2" Width="400" CellStyle-HorizontalAlign="Left">
                     <PropertiesComboBox ValueField="JobOrderDetailsID" TextFormatString="{0} - {1} - {2} - {3} - {4} - {5}"  DataSourceID="JobOrderDS" ValueType="System.Int64">
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
                
                 <dx:GridViewDataTextColumn FieldName="SiteName" Caption="Site Name" VisibleIndex="3" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="120" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
               <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date" Width="120" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                   <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
               
                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
         </div>

   <asp:ObjectDataSource ID="PendingActiveWorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderListDB" SelectMethod="GetAllPendingActive" >
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="FinshedActiveWorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderListDB" SelectMethod="GetAllFinishedActive" >
    </asp:ObjectDataSource>
   
   <asp:ObjectDataSource ID="PendingExpiredWorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderListDB" SelectMethod="GetAllPendingExpired" >
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="FinishedExpiredWorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderListDB" SelectMethod="GetAllFinishedExpired" >
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrderFromView"></asp:ObjectDataSource>
 
    <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAllPending" DeleteMethod="Delete"></asp:ObjectDataSource>

        <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>

       <asp:ObjectDataSource ID="ApprovedJobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAllApproved" DeleteMethod="Delete"></asp:ObjectDataSource>
       
       <asp:ObjectDataSource ID="ExpiredJobOrderMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetAllExpired" DeleteMethod="Delete"></asp:ObjectDataSource>
       
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>
</asp:Content>
