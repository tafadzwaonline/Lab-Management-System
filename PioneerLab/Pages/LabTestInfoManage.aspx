<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="LabTestInfoManage.aspx.cs" Inherits="PioneerLab.Pages.LabTestInfoManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function PrintReport() {
            window.open('ReportViwer.aspx?source=ServiceInformationList&id=0&Filter=' + gridLabTestsList.cpFilter);
        }

        function ShowPopup(Image) {
            popupOpt.ShowAtElement();
            if (Image != "") {
                var imgSrc = "../Uploaded/Tests/" + Image;
                var ImageElement = document.getElementById('<%=previewImage.ClientID%>');
                ImageElement.src = imgSrc;
            }
            else {
                var ImageElement = document.getElementById('<%=previewImage.ClientID%>');
                ImageElement.src = "../images/emptyimage.png"
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
            <li><a id="menu1" href="#">Setup</a></li>
            <li class="active" id="menulink">Service Information</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Service Information</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Service" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
                <ClientSideEvents click="PrintReport"/>

            </dx:ASPxButton>
        </div>
    </div>

            <dx:ASPxPopupControl ID="popupOptions" runat="server" HeaderText="" ShowHeader="false" ShowPageScrollbarWhenModal="true" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Above"
                                    CloseAction="OuterMouseClick" AllowDragging="True" Left="1500" Top="100" ClientInstanceName="popupOpt" Width="150" Height="" PopupAlignCorrection="Auto" ShowCloseButton="false"
                                    PopupAnimationType="None">
                                    <ContentCollection>
                                        <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                                            <div>
                                                <div>
                                                     <img src="../images/emptyimage.png" ClientInstanceName="previewImage" class="img-circle img-offline" style="width: 132px; height: 120px;  margin: 0px;" id="previewImage" runat="server" alt="" />
                                                    <%--<dx:ASPxTextBox ID="vi" runat="server" ClientInstanceName="vi" ClientVisible="false"  Text=""></dx:ASPxTextBox>--%>
                                                </div>                                             
                                             
                                            </div>
                                        </dx:PopupControlContentControl>
                                    </ContentCollection>
                                </dx:ASPxPopupControl>                   
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvLabTestsList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridLabTestsList"
            DataSourceID="TestsListDS" KeyFieldName="TestID" OnCellEditorInitialize="GdvLabTestsList_CellEditorInitialize" OnBeforeGetCallbackResult="GdvLabTestsList_BeforeGetCallbackResult" OnCustomButtonInitialize="GdvLabTestsList_CustomButtonInitialize" OnCommandButtonInitialize="GdvLabTestsList_CommandButtonInitialize" >
            <Columns>
                   <dx:GridViewDataTextColumn FieldName="AshghalTestNumber" Caption="Ashghal Test Number" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TestName" Caption="Service Name" Width="400" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ShortName" Caption="Short Name" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="Standard Number" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
             

                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>

                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="60"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>

                 <dx:GridViewDataColumn Name="Edit" VisibleIndex="8" Width="25">
                                        <DataItemTemplate>
                                           
                                            <a href="javascript:void(0)" onclick="ShowPopup('<%#Eval("Image")%>');">
                                                 <img src="../images/grd_preview.gif" title="View Image" alt="View Image"></img>
                                             </a>                                                                                 


                                            
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
             <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        DataObjectTypeName="BusinessLayer.TestsList" SelectMethod="GetAll" DeleteMethod="Delete"></asp:ObjectDataSource>

</asp:Content>
