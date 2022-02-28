<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="JobOrderManage.aspx.cs" Inherits="PioneerLab.Pages.JobOrderManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        ShowAttachmentWindow = function (evt, link) {
            ShowAttachment(link.href);
            evt.cancelBubble = true;
            return false;
        }
        ShowAttachment = function (src) {
            var screenLeft = document.all && !document.opera ? window.screenLeft : window.screenX;
            var screenWidth = screen.availWidth;
            var screenHeight = screen.availHeight;
            var zeroX = Math.floor((screenLeft < 0 ? 0 : screenLeft) / screenWidth) * screenWidth;

            var windowWidth = 525;
            var windowHeight = 580;
            var windowX = parseInt((screenWidth - windowWidth) / 2);
            var windowY = parseInt((screenHeight - windowHeight) / 2);
            if (windowX + windowWidth > screenWidth)
                windowX = 0;
            if (windowY + windowHeight > screenHeight)
                windowY = 0;

            windowX += zeroX;
            //alert("left=" + windowX + ",top=" + windowY + ",width=" + windowWidth + ",height=" + windowHeight );
            var popupwnd = window.open(src, '_blank', "left=" + windowX + ",top=" + windowY + ",width=" + windowWidth + ",height=" + windowHeight + ", scrollbars=no, resizable=no", true);
            if (popupwnd != null && popupwnd.document != null && popupwnd.document.body != null) {
                popupwnd.document.body.style.margin = "0px";
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
            <li class="active" id="menulink">Customer Job Order</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Customer Job Order</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New JobOrder" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
     <div>
        <h5>Pending to Approve</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvJobOrder" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridJobOrder" OnHtmlRowCreated="GdvJobOrder_HtmlRowCreated"
            DataSourceID="JobOrderMasterDS" KeyFieldName="JobOrderMasterID" OnCellEditorInitialize="GdvJobOrder_CellEditorInitialize" OnCustomButtonInitialize="GdvJobOrder_CustomButtonInitialize" OnCommandButtonInitialize="GdvJobOrder_CommandButtonInitialize">
            <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnApprove') {window.location=('JobOrder.aspx?id=' + key + '&mode=confirm');}}" />
            
            <Columns>
                 <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" onclick='return ShowAttachmentWindow(event, this);' href="../Pages/Attachments.aspx?TransTypeID=11111&TransID=<%# Eval("JobOrderMasterID") %>" title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                 <dx:GridViewCommandColumn VisibleIndex="1" Caption="Approve" Width="55">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnApprove" Text=" ">
                            <%--<Styles>
                                <Style Font-Size="Medium" ForeColor="Blue" CssClass="glyphicon glyphicon-check"></Style>
                            </Styles>--%>
                            <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Approve" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="JobOrderNumber" Caption="Job Order No" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="TransactionDate" Caption="Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <%--<dx:GridViewDataCheckColumn FieldName="IsClosed" Caption="Is Closed" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>--%>
                <dx:GridViewDataCheckColumn FieldName="IsActive" Caption="Active" Width="100" VisibleIndex="6" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>
                 <dx:GridViewDataCheckColumn FieldName="StatusID" Visible="false" Caption="StatusID" Width="100" VisibleIndex="8" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewCommandColumn VisibleIndex="9" ButtonType="Default" Width="60"
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

    <div>
        <h5>Approved Job Order</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvApprovedJobOrder" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridJobOrder" OnHtmlRowCreated="GdvJobOrder_HtmlRowCreated"
            DataSourceID="ApprovedJobOrderMasterDS" KeyFieldName="JobOrderMasterID" OnCellEditorInitialize="GdvApprovedJobOrder_CellEditorInitialize" OnCommandButtonInitialize="GdvJobOrder_CommandButtonInitialize" OnCustomButtonInitialize="GdvApprovedJobOrder_CustomButtonInitialize">
            <Columns>
                 <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" onclick='return ShowAttachmentWindow(event, this);' href="../Pages/Attachments.aspx?TransTypeID=11111&TransID=<%# Eval("JobOrderMasterID") %>" title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                
                <dx:GridViewDataTextColumn FieldName="JobOrderNumber" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="TransactionDate" Caption="Date" Width="400" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <%--<dx:GridViewDataCheckColumn FieldName="IsClosed" Caption="Is Closed" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>--%>
                <dx:GridViewDataCheckColumn FieldName="IsActive" Caption="Active" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible"/>
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn"/>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

     <div>
        <h5>Expired Job Order</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvExpiredJobOrder" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridJobOrder" OnHtmlRowCreated="GdvJobOrder_HtmlRowCreated"
            DataSourceID="ExpiredJobOrderMasterDS" KeyFieldName="JobOrderMasterID" OnCellEditorInitialize="GdvExpiredJobOrder_CellEditorInitialize" OnCustomErrorText="GdvExpiredJobOrder_CustomErrorText" OnCustomButtonInitialize="GdvExpiredJobOrder_CustomButtonInitialize" OnCommandButtonInitialize="GdvJobOrder_CommandButtonInitialize">
           <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnView') {window.location=('JobOrder.aspx?id=' + key + '&mode=Expired');}}" />
           
             <Columns>
                   <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" onclick='return ShowAttachmentWindow(event, this);' href="../Pages/Attachments.aspx?TransTypeID=11111&TransID=<%# Eval("JobOrderMasterID") %>" title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn FieldName="JobOrderNumber" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="TransactionDate" Caption="Date"  VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="ExpiryDate" Caption="ExpiryDate"  VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <%--<dx:GridViewDataCheckColumn FieldName="IsClosed" Caption="Is Closed" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>--%>
                <dx:GridViewDataCheckColumn FieldName="IsActive" Caption="Active" Width="100" VisibleIndex="6" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Default" Width="40"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
                <dx:GridViewCommandColumn VisibleIndex="8" Caption="View" Width="40" Visible="false">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnView" Text=" ">
                           <%-- <Styles>
                                <Style Font-Size="Medium" ForeColor="Blue" CssClass="../images/vision-clipart-1-eye-8.png"></Style>
                            </Styles>--%>
                             <Image Url="../images/vision-clipart-1-eye-8.png" Width="20" Height="20" ToolTip="View" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
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
