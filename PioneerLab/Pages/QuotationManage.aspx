<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="QuotationManage.aspx.cs" Inherits="PioneerLab.Pages.QuotationManage" %>

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
            <li class="active" id="menulink">Customer Quotation</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Customer Quotation</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
    <div>
        <h5>Pending to Quote</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvCustomerEnquiry" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridCustomerEnquiry"
            DataSourceID="EnquiryMasterDS" KeyFieldName="EnquiryMasterID">
            <Columns>

                <dx:GridViewDataTextColumn FieldName="EnquiryCode" Caption="Enquiry No" Width="200" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="Entry Date" Width="200" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" Width="330" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <%--<PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS">
                    </PropertiesComboBox>--%>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProjectName" Caption="Project" Width="330" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                   <%-- <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS">
                    </PropertiesComboBox>--%>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>

                <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Default" Width="20" Caption="Convert" CellStyle-HorizontalAlign="Center"
                    ShowClearFilterButton="true">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnConvert" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" CssClass="glyphicon glyphicon-transfer"></Style>
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
            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.location =('Quotation.aspx?cid=' + key);}" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div class="row" style="height: 5px"></div>
    <div>
        <h5>Pending to Approve</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvQuotation" AutoGenerateColumns="false" Width="100%"  ClientInstanceName="gridQuotation"
            DataSourceID="PendingQuotationMasterDS" KeyFieldName="QuotationMasterID" OnCellEditorInitialize="GdvQuotation_CellEditorInitialize"
             OnCommandButtonInitialize="GdvQuotation_CommandButtonInitialize" OnCustomButtonInitialize="GdvQuotation_CustomButtonInitialize">
            <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnApprove') {window.location=('Quotation.aspx?id=' + key + '&mode=confirm');}}" />
            <Columns>

                <dx:GridViewCommandColumn VisibleIndex="0" Caption="Approve" Width="55">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnApprove" Text=" " >
                           <%-- <Styles>
                                <Style Font-Size="Medium" ForeColor="Blue" CssClass="glyphicon glyphicon-check"></Style>
                            </Styles>--%>
                            <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Approve" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="QuotationNo" Caption="Quotation No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="Entry Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                 <dx:GridViewDataDateColumn FieldName="ExpiryDate" Caption="Expiry Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                     <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProjectName" Caption="Project" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <%-- <dx:GridViewDataDateColumn FieldName="FKEnquiryMasterID" Caption="FKEnquiryMasterID" VisibleIndex="1" Width="0" Visible="false" CellStyle-HorizontalAlign="Left">
                </dx:GridViewDataDateColumn>--%>
                <%--<dx:GridViewDataComboBoxColumn FieldName="StatusID" Caption="Status" VisibleIndex="1">
                    <PropertiesComboBox ValueType="System.Int32">
                        <Items>
                            <dx:ListEditItem Text="New" Value="0" />
                            <dx:ListEditItem Text="Approved" Value="1" />
                            <dx:ListEditItem Text="Rejected" Value="2" />
                        </Items>
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>--%>
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
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn"/>
            <SettingsPager AlwaysShowPager="false" Mode="ShowAllRecords"></SettingsPager>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups" style="display: none">
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Quotation" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px">
    </div>
    <div>
        <h5>Quotations History</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvQuotationHistory" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridQuotationHistory" OnRowCommand="GdvQuotationHistory_RowCommand"
            DataSourceID="QuotationMasterDS" KeyFieldName="QuotationMasterID" >
            <%--<ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnView') {window.location=('Quotation.aspx?id=' + key + '&mode=View')}; if (e.buttonID == 'btnprintR') {window.open('ReportViwer.aspx?source=QuotationReport2&id=' + key)}; if (e.buttonID == 'btnRevise') {window.location=('Quotation.aspx?id=' + key + '&mode=revise')}}" />--%>
            <Columns>
                <%--<dx:GridViewCommandColumn VisibleIndex="0">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnApprove" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" ForeColor="Blue" CssClass="glyphicon glyphicon-check"></Style>
                            </Styles>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>--%>
                <dx:GridViewDataTextColumn FieldName="QuotationNo" Caption="Quotation No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="Entry Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                  <dx:GridViewDataDateColumn FieldName="ExpiryDate" Caption="Expiry Date" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                      <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProjectName" Caption="Project" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                   
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EnquiryCode" Caption="Enquiry" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                    
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="StatusID" Caption="Status" VisibleIndex="7">
                    <PropertiesComboBox ValueType="System.Int32">
                        <Items>
                            <dx:ListEditItem Text="New" Value="0" />
                            <dx:ListEditItem Text="Approved" Value="1" />
                            <dx:ListEditItem Text="Rejected" Value="2" />
                        </Items>
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                 <dx:GridViewDataComboBoxColumn FieldName="ValidityStatus" Caption="Validity Status" VisibleIndex="8">
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewCommandColumn VisibleIndex="9" ButtonType="Default" Width="90" ShowClearFilterButton="true" Visible="false" >
                      <CustomButtons  >
                        <dx:GridViewCommandColumnCustomButton ID="btnView" Text=" " Image-ToolTip=""  >
                         <Image Url="../images/vision-clipart-1-eye-8.png" Width="20" Height="20" ToolTip="View" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnRevise" Text=" ">
                             <Image Url="../images/share_button_final_179539-2.png" Width="16" Height="16" ToolTip="Revise" ></Image>

                           <%-- <Styles>
                                <Style Font-Size="Medium" CssClass="glyphicon glyphicon-share"></Style>
                            </Styles>--%>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                     <CustomButtons >
                         
                        <dx:GridViewCommandColumnCustomButton  ID="btnprintR" Text=" " Image-ToolTip=""  >
                            
                         <Image Url="../images/print.png" Width="16" Height="16" ToolTip="Print Not Active Please Call ACT Team" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataColumn VisibleIndex="10" Width="70">
                           
                            <DataItemTemplate>
                                <table cellpadding="0" cellspacing="2">
                                    <tr>
                                       
                                        <td>
                                         
                                            <dx:ASPxButton ID="btnView2"  runat="server" ToolTip="view" Cursor="pointer" Width="18px" OnClick="btnView2_Click" Enabled='<%# Convert.ToBoolean(Eval("ViewStatus")) %>'
                                                CommandName="View" CommandArgument='<%# Eval("QuotationMasterID") %>' EnableTheming="False" RenderMode="Link" >
                                                <Image Url="../images/vision-clipart-1-eye-8.png" ToolTip="view"  Width="20" Height="20"></Image>
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnRevise2"  runat="server" ToolTip="Revise" Cursor="pointer" Width="18px" Enabled='<%#Convert.ToBoolean( Eval("ApproveStatus") )%>'
                                                CommandName="Revise" CommandArgument='<%# Eval("QuotationMasterID") %>' EnableTheming="False" RenderMode="Link" >
                                                <Image Url="../images/share_button_final_179539-2.png" ToolTip="Revise" Width="16" Height="16"></Image>
                                                 <%--<ClientSideEvents Click=="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnView') { if (e.buttonID == 'btnRevise') {window.location=('Quotation.aspx?id=' + key + '&mode=revise')}}" />--%>
                                           </dx:ASPxButton>
                                        </td>
                                        <td >
                                            <dx:ASPxButton ID="btnprintR2"  runat="server" ToolTip="Print" Cursor="pointer" Width="18px" 
                                                CommandName="Print" CommandArgument='<%# Eval("QuotationMasterID") %>' EnableTheming="False" RenderMode="Link" >
                                                <Image Url="../images/print.png" ToolTip="Print" Width="16" Height="16"></Image>
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
            </Columns>
            <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn"/>
            <SettingsPager AlwaysShowPager="true" Mode="ShowPager" PageSize="10"></SettingsPager>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="QuotationMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationMasterDB"
        DataObjectTypeName="BusinessLayer.ViewGetAllQuotationMasterHistory" SelectMethod="GetAllHistory" DeleteMethod="Delete"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="PendingQuotationMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.QuotationMasterDB"
        DataObjectTypeName="BusinessLayer.ViewNewQuotationMaster" SelectMethod="GetAllNew" DeleteMethod="Delete"></asp:ObjectDataSource>
   
    <asp:ObjectDataSource ID="EnquiryMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EnquiryMasterDB"
        DataObjectTypeName="BusinessLayer.ViewBendingEnquiryMaster" SelectMethod="GetAllPending"></asp:ObjectDataSource>

        <asp:ObjectDataSource ID="AllEnquiryMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EnquiryMasterDB"
        DataObjectTypeName="BusinessLayer.EnquiryMaster" SelectMethod="GetAll"></asp:ObjectDataSource>

</asp:Content>
