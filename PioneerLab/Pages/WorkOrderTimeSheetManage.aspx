<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="WorkOrderTimeSheetManage.aspx.cs" Inherits="PioneerLab.Pages.WorkOrderTimeSheetManage" %>

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
        <h1>Work Order </h1>
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
    <div class="row" style="height: 10px"></div>
     <div>
        <h5>Pending To Checked</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingCheckedWorkOrder" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder" OnCommandButtonInitialize="GdvPendingCheckedWorkOrder_CommandButtonInitialize"
            DataSourceID="PendingCheckedWorkOrderDS" KeyFieldName="WorkOrderID" OnCellEditorInitialize="GdvActiveWorkOrder_CellEditorInitialize" OnCustomErrorText="GdvActiveWorkOrder_CustomErrorText" OnCustomButtonInitialize="GdvPendingCheckedWorkOrder_CustomButtonInitialize">
              <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  {window.location=('TimeSheet.aspx?id=' + key + '&mode=Check');}}" />
            
           <Columns>
               <dx:GridViewCommandColumn VisibleIndex="0" Caption="Check" Width="55">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnChecked" Text=" ">
                            <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Check" ></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="Work Order No" VisibleIndex="1" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="1" Width="350" CellStyle-HorizontalAlign="Left">
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
               
                 <dx:GridViewDataTextColumn FieldName="SiteName" Caption="Site Name" VisibleIndex="1" Width="200" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="130" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                         <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                     </dx:GridViewDataDateColumn>
               <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date"  Width="130" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                     <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>  
               </dx:GridViewDataDateColumn>
                
                <%--<dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>--%>
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
    <div class="row" style="height: 10px"></div>

    <div>
        <h5>Pending To Approve</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingApproveWorkOrder" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder" OnCommandButtonInitialize="GdvPendingCheckedWorkOrder_CommandButtonInitialize"
            DataSourceID="PendingApprovedWorkOrderDS" KeyFieldName="WorkOrderID" OnCellEditorInitialize="GdvActiveWorkOrder_CellEditorInitialize" OnCustomErrorText="GdvActiveWorkOrder_CustomErrorText" OnCustomButtonInitialize="GdvPendingCheckedWorkOrder_CustomButtonInitialize">
              <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  {window.location=('TimeSheet.aspx?id=' + key + '&mode=Approve');}}" />
             <Columns>
               <dx:GridViewCommandColumn VisibleIndex="0" Caption="Approve" Width="55">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnApprove" Text=" ">
                            <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Approve" ></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                  <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="Work Order No" VisibleIndex="1" Width="160" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="2" Width="350" CellStyle-HorizontalAlign="Left">
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
               
              <%-- <dx:GridViewDataCheckColumn FieldName="IsChecked" ReadOnly="true" Caption="Checked" Width="60" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
              --%>   
              <%--  <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>--%>
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

     <div>
        <h5>Work Order History</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvWorkOrderHistory" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWorkOrder" OnCommandButtonInitialize="GdvPendingCheckedWorkOrder_CommandButtonInitialize"
            DataSourceID="CheckedApprovedWorkOrderDS" KeyFieldName="WorkOrderID" OnCellEditorInitialize="GdvWorkOrderHistory_CellEditorInitialize" OnCustomErrorText="GdvActiveWorkOrder_CustomErrorText">
               
           <Columns>
                 <dx:GridViewDataTextColumn FieldName="WorkOrderNo" Caption="Work Order No" VisibleIndex="1" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderDetailsID" Caption="Job Order No" VisibleIndex="2" Width="350" CellStyle-HorizontalAlign="Left">
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
              
                 <dx:GridViewDataTextColumn FieldName="SiteName" Caption="Site Name" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate" ReadOnly="true" Caption="Start Date" Width="120" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                         <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                     </dx:GridViewDataDateColumn>
               <dx:GridViewDataDateColumn FieldName="EndDate" ReadOnly="true" Caption="End Date"  Width="120" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                     <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>  
               </dx:GridViewDataDateColumn>
               <%-- <dx:GridViewDataCheckColumn FieldName="IsChecked" ReadOnly="true" Caption="Checked" Width="60" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                
                 <dx:GridViewDataCheckColumn FieldName="IsApproved" ReadOnly="true" Caption="Approved" Width="80" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                        </dx:GridViewDataCheckColumn>
                --%>
                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
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
   <asp:ObjectDataSource ID="PendingCheckedWorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderListDB" SelectMethod="GetAllPendingCheckedFinishedExpiredWorkOrder" >
    </asp:ObjectDataSource>
    
   <asp:ObjectDataSource ID="PendingApprovedWorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderListDB" SelectMethod="GetAllPendingApproveFinishedExpiredWorkOrder" >
    </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="CheckedApprovedWorkOrderDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.WorkOrderListDB"
        DataObjectTypeName="BusinessLayer.WorkOrderListDB" SelectMethod="GetAllCheckedApproveFinishedExpiredWorkOrder" >
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
