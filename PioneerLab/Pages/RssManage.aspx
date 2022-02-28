<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="RssManage.aspx.cs" Inherits="PioneerLab.Pages.RssManage" %>

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
            <li class="active" id="menulink">Request For Site Services</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Request For Site Services</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
     
<div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New R.S.S" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvRSS"  AutoGenerateColumns="false" Width="100%" OnCustomErrorText="GdvRSS_CustomErrorText" ClientInstanceName="gridRSS" 
            DataSourceID="RSSMasterDS" KeyFieldName="RSSMasterId" OnCellEditorInitialize="GdvRSS_CellEditorInitialize" OnCustomButtonInitialize="GdvRSS_CustomButtonInitialize" OnCommandButtonInitialize="GdvRSS_CommandButtonInitialize">
            <Columns>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="300" CellStyle-HorizontalAlign="Left">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - {1} - {2} " DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                       

                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="RSSNumber" Caption="Request No" VisibleIndex="2" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="RSSDate" Caption="Request Date" Width="150" VisibleIndex="3"    CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit  DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                    </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                 <dx:GridViewDataTextColumn FieldName="SiteLocation" Caption="Site Location" Width="150" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                
                <dx:GridViewDataTextColumn FieldName="SampleNo" Caption="Sample No" Width="150" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataCheckColumn FieldName="IsSampled" Caption="Is Sampled" Width="150" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnprintR" Text=" " Image-ToolTip=""  >
                         <Image Url="../images/print.png" Width="16" Height="16" ToolTip="print" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                     
                     
                </dx:GridViewCommandColumn>
                <%--<dx:GridViewDataColumn VisibleIndex="10" Width="70">
                          
                            <DataItemTemplate>
                                <table cellpadding="0" cellspacing="2">
                                    <tr>
                                        <td>
                                          
                                            <asp:ImageButton ID="btnPrint" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnPrint %>" Cursor="pointer" EnableTheming="false"
                                                RenderMode="Link" CommandName="CmdPrint" Visible="True" ImageUrl="../images/printer.png" Width="18px"
                                                AlternateText="<%$ Resources:GlobalResource, BtnPrint %>" ></asp:ImageButton>
                                                <%--OnClientClick="window.open('ReportViwer.aspx?source=RSSReport&id=' + '<%# Eval("RSSMasterId") %>' )"--%>
                                                
                                       <%-- </td>
                                        <td>
                                            <dx:ASPxButton ID="btnEdit"  runat="server" ToolTip="<%$ Resources:GlobalResource, BtnEdit %>" Cursor="pointer" Width="18px"
                                                CommandName="Edit" CommandArgument='<%# Eval("RSSMasterId") %>' Enabled='<%# !Convert.ToBoolean(Eval("IsSampled")) %>'  EnableTheming="False" RenderMode="Link" meta:resourcekey="btnEditResource1">
                                                <Image Url="../images/grd_edit.png" ToolTip="<%$ Resources:GlobalResource, BtnEdit %>" AlternateText="<%$ Resources:GlobalResource, BtnEdit %>"></Image>
                                            </dx:ASPxButton>
                                        </td>
                                      
                                        <td style="display: none">
                                            <dx:ASPxButton ID="btnDelete" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnDelete %>" Cursor="pointer" EnableTheming="False" RenderMode="Link"
                                                CommandName="Delete" CommandArgument='<%# Eval("RSSMasterId") %>' meta:resourcekey="btnDeleteResource1" Width="18px"
                                                Visible='<%# !Convert.ToBoolean(Eval("IsSampled")) %>'>
                                                <Image Url="../images/grd_Delete.png" ToolTip="<%$ Resources:GlobalResource, BtnDelete %>" AlternateText="<%$ Resources:GlobalResource, BtnDelete %>"></Image>
                                                <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure you want to delete ?'); }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>--%>
                 
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True" />
            <SettingsPager PageSize="20"></SettingsPager>

            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnprintR') {window.open('ReportViwer.aspx?source=RSSReport&id=' + key)}; }" />
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <asp:ObjectDataSource ID="RSSMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.RSSMasterDB"
        DataObjectTypeName="BusinessLayer.RSSMaster" SelectMethod="GetAllFromView" DeleteMethod="Delete"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrderFromView"></asp:ObjectDataSource>

</asp:Content>
