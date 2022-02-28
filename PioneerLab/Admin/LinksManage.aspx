<%@ Page Title="Links Manage" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LinksManage.aspx.cs" Inherits="PioneerLab.Admin.LinksManage" %>

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

            <li><a id="menu1" href="#">Setup</a></li>
            <%--<li><a id="menu2" href="#">General</a></li>--%>
            <li class="active" id="menulink">Links Manage</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Links Manage</h1>
    </div>
    <!-- /.page-header -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0" style="margin-top: 30px">
        <tr>
            <td height="30">
                <table cellpadding="0" cellspacing="0" height="30">
                    <tr>
                        <td width="70">
                            <dx:ASPxButton AutoPostBack="false" ID="Button1" Text="Add New" ValidationGroup="AddNew" CssClass="btn btn-default btn-bordered" runat="server">
                                <ClientSideEvents Click="function (s, e) { GdvCategoryMaster.AddNewRow();}" />
                                 <ClientSideEvents Init="function (s, e) {s.GetTextContainer().className += 'glyphicon glyphicon-plus';}" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="10"></td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="Alert">
                            <dx:ASPxLabel ID="lblCompanyId" Text="0" runat="server" Visible="false"></dx:ASPxLabel>
                            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td height="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lable divcell" style="width: 100px">
                            <dx:ASPxLabel ID="lblFlowModules" runat="server" Text="Modules" Theme="Moderno"></dx:ASPxLabel>
                        </td>
                        <td class="divcell" style="width: 350px">
                            <dx:ASPxComboBox ID="CmbFlowModules" ClientInstanceName="CmbFlowModules" Width="300px" DataSourceID="ModulesDS"
                                runat="server" AutoGenerateColumns="False" EnableCallbackMode="true" AutoPostBack="true"
                                IncrementalFilteringMode="Contains" ValueType="System.Int32" TextField="ModuleEName" ValueField="ModuleID">
                                <ValidationSettings ValidationGroup="AddNew">
                                    <RequiredField IsRequired="true" ErrorText="Select Module!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <dx:ASPxGridView ID="GdvCategoryMaster" runat="server"
                                AutoGenerateColumns="False" Width="100%" ClientInstanceName="GdvCategoryMaster"
                                DataSourceID="CategoryMasterDS" KeyFieldName="CategoryMasterID"
                                OnRowInserting="GdvCategoryMaster_RowInserting" OnRowUpdating="GdvCategoryMaster_RowUpdating"
                                OnCustomErrorText="GdvCategoryMaster_CustomErrorText">
                                <Styles>
                                    <AlternatingRow Enabled="True"></AlternatingRow>
                                </Styles>
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="OrderNo" Caption="OrderNo" VisibleIndex="0" Width="40" meta:resourcekey="gdvNameEn" CellStyle-HorizontalAlign="Left">
                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CategoryMasterNameEn" Caption="English Name" VisibleIndex="3" meta:resourcekey="gdvNameEn" CellStyle-HorizontalAlign="Left">
                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CategoryMasterNameAr" Caption="Arabic Name" VisibleIndex="4" meta:resourcekey="gdvNameAr" CellStyle-HorizontalAlign="Right">
                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Notes" Caption="Notes" VisibleIndex="4" meta:resourcekey="gdvNameAr">
                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Image" CellStyle-HorizontalAlign="<%$ Resources:GlobalResource, align %>" Width="60" ShowClearFilterButton="True" ShowEditButton="true" ShowDeleteButton="true" />
                                </Columns>
                                <ClientSideEvents EndCallback="function(s, e) {if(s.cpDeleteError != ''){lblError.SetText(s.cpDeleteError);}else{lblError.SetText('');}}" />
                                <Templates>
                                    <DetailRow>
                                        <table width="100%">
                                            <tr>
                                                <td class="Title">
                                                    <dx:ASPxLabel ID="LblDetailsTitle" runat="server" Text="Link Categories" RenderMode="Link" EnableTheming="false" CssClass="Title" meta:resourcekey="lblDetailsTitle"></dx:ASPxLabel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Alert">
                                                    <dx:ASPxLabel ID="LblErrorDet" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblErrorDet"></dx:ASPxLabel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxGridView ID="GdvLinkCategory" runat="server" Width="100%" DataSourceID="LinkCategoryDS" KeyFieldName="LinkCategoryID" ClientInstanceName="GdvLinkCategory"
                                                        OnBeforePerformDataSelect="GdvLinkCategory_BeforePerformDataSelect" OnCustomErrorText="GdvLinkCategory_CustomErrorText"
                                                        OnRowInserting="GdvLinkCategory_RowInserting" OnRowUpdating="GdvLinkCategory_RowUpdating">
                                                        <Styles>
                                                            <AlternatingRow Enabled="True"></AlternatingRow>
                                                        </Styles>
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="OrderNo" Caption="OrderNo" VisibleIndex="0" Width="40" meta:resourcekey="gdvNameEn" CellStyle-HorizontalAlign="Left">
                                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="LinkCategoryEName" Caption="English Name" VisibleIndex="3" meta:resourcekey="gdvNameEn" CellStyle-HorizontalAlign="Left">
                                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="LinkCategoryAName" Caption="Arabic Name" VisibleIndex="4" meta:resourcekey="gdvNameAr" CellStyle-HorizontalAlign="Right">
                                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Notes" Caption="Notes" VisibleIndex="4" meta:resourcekey="gdvNameAr">
                                                            <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                            <dx:GridViewCommandColumn VisibleIndex="8" ButtonType="Image" CellStyle-HorizontalAlign="<%$ Resources:GlobalResource, align %>" Width="60" ShowClearFilterButton="True" ShowEditButton="true" ShowDeleteButton="true">
                                                                <HeaderCaptionTemplate>
                                                                    <dx:ASPxButton ID="BtnNew" runat="server" AutoPostBack="false" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" EnableTheming="false" RenderMode="Link">
                                                                        <ClientSideEvents Click="function (s, e) { GdvLinkCategory.AddNewRow();}" />
                                                                        <Image AlternateText="<%$ Resources:GlobalResource, EditFormNew %>" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" Url="../images/Add_New.png">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </HeaderCaptionTemplate>
                                                            </dx:GridViewCommandColumn>
                                                        </Columns>
                                                        <Templates>
                                                            <DetailRow>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="Title">
                                                                            <dx:ASPxLabel ID="LblDetailsTitle" runat="server" Text="Links" RenderMode="Link" EnableTheming="false" CssClass="Title" meta:resourcekey="lblDetailsTitle"></dx:ASPxLabel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="Alert">
                                                                            <dx:ASPxLabel ID="LblErrorDet" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblErrorDet"></dx:ASPxLabel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <dx:ASPxGridView ID="GdvLinks" runat="server" Width="100%" DataSourceID="LinksDS" KeyFieldName="LinksID" ClientInstanceName="GdvLinks"
                                                                                OnRowInserting="GdvLinks_RowInserting" OnRowUpdating="GdvLinks_RowUpdating" OnRowDeleting="GdvLinks_RowDeleting"
                                                                                OnBeforePerformDataSelect="GdvLinks_BeforePerformDataSelect" OnRowValidating="GdvLinks_RowValidating"
                                                                                OnCustomErrorText="GdvLinks_CustomErrorText" AutoGenerateColumns="False">
                                                                                <Styles>
                                                                                    <AlternatingRow Enabled="True"></AlternatingRow>
                                                                                </Styles>
                                                                                <Columns>
                                                                                    <dx:GridViewDataTextColumn FieldName="OrderNo" Caption="OrderNo" VisibleIndex="0" Width="40" meta:resourcekey="gdvNameEn" CellStyle-HorizontalAlign="Left">
                                                                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="LinksEName" Caption="English Name" VisibleIndex="3" meta:resourcekey="gdvNameEn" CellStyle-HorizontalAlign="Left">
                                                                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="LinksAName" Caption="Arabic Name" VisibleIndex="4" meta:resourcekey="gdvNameAr" CellStyle-HorizontalAlign="Right">
                                                                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="Url" Caption="Url" VisibleIndex="4" meta:resourcekey="gdvNameAr">
                                                                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="Notes" Caption="Notes" VisibleIndex="4" meta:resourcekey="gdvNameAr">
                                                                                    <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataCheckColumn FieldName="MenuLink" Caption="Menu Link" VisibleIndex="4" meta:resourcekey="gdvNameAr">
                                                                                    </dx:GridViewDataCheckColumn>
                                                                                    <dx:GridViewDataCheckColumn FieldName="ActiveLink" Caption="Active Link" VisibleIndex="4" meta:resourcekey="gdvNameAr">
                                                                                    </dx:GridViewDataCheckColumn>
                                                                                    <dx:GridViewCommandColumn VisibleIndex="8" ButtonType="Image" CellStyle-HorizontalAlign="<%$ Resources:GlobalResource, align %>" Width="60" ShowClearFilterButton="True" ShowEditButton="true" ShowDeleteButton="true">
                                                                                        <HeaderCaptionTemplate>
                                                                                            <dx:ASPxButton ID="BtnNew" runat="server" AutoPostBack="false" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" EnableTheming="false" RenderMode="Link">
                                                                                                <ClientSideEvents Click="function (s, e) { GdvLinks.AddNewRow();}" />
                                                                                                <Image AlternateText="<%$ Resources:GlobalResource, EditFormNew %>" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" Url="../images/Add_New.png">
                                                                                                </Image>
                                                                                            </dx:ASPxButton>
                                                                                        </HeaderCaptionTemplate>
                                                                                    </dx:GridViewCommandColumn>
                                                                                </Columns>
                                                                                <Templates>
                                                                                    <EditForm>
                                                                                        <asp:Panel ID="PanEditForm" runat="server">
                                                                                            <table cellpadding="0" cellspacing="0" style="width: 550px;">
                                                                                                <tr>
                                                                                                    <td colspan="6" style="height: 5px"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6">
                                                                                                        <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup="editForm"></dx:ASPxValidationSummary>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6">
                                                                                                        <dx:ASPxLabel ID="lblError" runat="server" CssClass="Alert"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6" style="height: 5px"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="10"></td>
                                                                                                    <td class="lable" style="width: 80px; height: 21px">
                                                                                                        <dx:ASPxLabel ID="LblNameEn" runat="server" Text="English Name"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <dx:ASPxTextBox ID="TxtNameEn" MaxLength="30" runat="server" Width="150" Height="21" Text='<%#Eval("LinksEName") %>'>
                                                                                                            <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm">
                                                                                                                <RequiredField IsRequired="true" ErrorText="Enter English Name" />

                                                                                                            </ValidationSettings>
                                                                                                        </dx:ASPxTextBox>
                                                                                                    </td>

                                                                                                    <td class="lable" style="width: 80px; height: 21px">
                                                                                                        <dx:ASPxLabel ID="LblNameAr" runat="server" Text="Arabic Name"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <dx:ASPxTextBox ID="TxtNameAr" MaxLength="30" runat="server" Width="170" Height="21" Text='<%#Eval("LinksAName") %>'>

                                                                                                            <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm">
                                                                                                                <RequiredField IsRequired="true" ErrorText="Enter Arabic Name" />

                                                                                                            </ValidationSettings>
                                                                                                        </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6" style="height: 5px"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="10"></td>
                                                                                                    <td class="lable" style="width: 80px; height: 21px">
                                                                                                        <dx:ASPxLabel ID="LblUrl" runat="server" Text="Url"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td colspan="4">
                                                                                                        <dx:ASPxTextBox ID="TxtUrl" MaxLength="200" runat="server" Width="550" Height="21" Text='<%#Eval("Url") %>'>
                                                                                                            <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm">
                                                                                                                <RequiredField IsRequired="true" ErrorText="Enter Url" />

                                                                                                            </ValidationSettings>
                                                                                                        </dx:ASPxTextBox>
                                                                                                    </td>

                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6" style="height: 5px"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="10"></td>
                                                                                                    <td class="lable" style="width: 80px; height: 21px">
                                                                                                        <dx:ASPxLabel ID="LblNotes" runat="server" Text="Notes"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td colspan="4">
                                                                                                        <dx:ASPxTextBox ID="TxtNotes" MaxLength="30" runat="server" Width="550" Height="21" Text='<%#Eval("Notes") %>'>
                                                                                                        </dx:ASPxTextBox>
                                                                                                    </td>

                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6" style="height: 5px"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="10"></td>
                                                                                                    <td class="lable" style="width: 80px; height: 21px">
                                                                                                        <dx:ASPxLabel ID="LbllinkIcon" runat="server" Text="Link Icon"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <dx:ASPxTextBox ID="TxtIcon" MaxLength="30" runat="server" Width="150" Height="21" Text='<%#Eval("LinkIcon") %>'>
                                                                                                        </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                    <td class="lable" style="width: 80px; height: 21px">
                                                                                                        <dx:ASPxLabel ID="lblOrderNo" runat="server" Text="Order No"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <dx:ASPxSpinEdit ID="OrderNo" runat="server" NumberType="Integer" Value='<%#Eval("OrderNo") %>'></dx:ASPxSpinEdit>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6" style="height: 5px"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="10"></td>
                                                                                                    <td class="lable" style="width: 80px; height: 21px">
                                                                                                        <dx:ASPxLabel ID="lblIsMenuLink" runat="server" Text="Menu Link"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <dx:ASPxCheckBox ID="IsMenuLink" runat="server" Value='<%#Eval("MenuLink") %>'></dx:ASPxCheckBox>
                                                                                                    </td>

                                                                                                    <td class="lable" style="width: 80px; height: 21px">
                                                                                                        <dx:ASPxLabel ID="lblActiveLink" runat="server" Text="Active Link"></dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <dx:ASPxCheckBox ID="IsActiveLink" runat="server" Value='<%#Eval("ActiveLink") %>'></dx:ASPxCheckBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6" style="height: 15px"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="10"></td>
                                                                                                    <td colspan="5" align="right">
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>

                                                                                                                    <dx:ASPxButton ID="BtnSaveEditForm" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnSave %>" CommandName="CmdSave" AutoPostBack="false" Cursor="pointer"
                                                                                                                        EnableTheming="false" Text="Save" CommandArgument='<%#Eval("LinksID") %>' ValidationGroup="editForm" CssClass="btn btn-primary">
                                                                                                                        <ClientSideEvents Click="function(s,e) {if(ASPxClientEdit.ValidateGroup('editForm')) {GdvLinks.UpdateEdit();}}" />
                                                                                                                    </dx:ASPxButton>
                                                                                                                </td>
                                                                                                                <td width="5"></td>
                                                                                                                <td>
                                                                                                                    <dx:ASPxButton ID="BtnCancel" runat="server" CssClass="btn btn-default" Style="width: 80px" Text="Close" AutoPostBack="false">
                                                                                                                        <ClientSideEvents Click="function(s, e) { GdvLinks.CancelEdit(); }" />
                                                                                                                    </dx:ASPxButton>
                                                                                                                </td>
                                                                                                                <td width="10"></td>

                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6" style="height: 10px"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <tr>
                                                                                                    <td colspan="6">
                                                                                                        <dx:ASPxFormLayout ID="CopyTo" runat="server" AlignItemCaptionsInAllGroups="true" ColCount="2">
                                                                                                            <Items>
                                                                                                                <dx:LayoutGroup AlignItemCaptions="true" Caption="Copy Link To" ColCount="4" GroupBoxStyle-Caption-Paddings-PaddingLeft="20" GroupBoxDecoration="Box">
                                                                                                                    <Items>
                                                                                                                        <dx:LayoutItem Caption="Modules">
                                                                                                                            <LayoutItemNestedControlCollection>
                                                                                                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                                                                                                                    <dx:ASPxComboBox ID="CmbModules" ClientInstanceName="CmbModules" Width="150px" DataSourceID="ModulesDS"
                                                                                                                                        runat="server" AutoGenerateColumns="False" EnableCallbackMode="true" AutoPostBack="true" OnSelectedIndexChanged="CmbModules_SelectedIndexChanged"
                                                                                                                                        IncrementalFilteringMode="Contains" ValueType="System.Int32" TextField="ModuleEName" ValueField="ModuleID">
                                                                                                                                        <ButtonStyle CssClass="btn-default" />
                                                                                                                                    </dx:ASPxComboBox>
                                                                                                                                </dx:LayoutItemNestedControlContainer>
                                                                                                                            </LayoutItemNestedControlCollection>
                                                                                                                        </dx:LayoutItem>
                                                                                                                        <dx:LayoutItem Caption="Category Master">
                                                                                                                            <LayoutItemNestedControlCollection>
                                                                                                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                                                                                                                    <dx:ASPxComboBox ID="cmbCategoryMaster" OnLoad="cmbCategoryMaster_Load" ClientInstanceName="CmbCategoryMaster" Width="150px"
                                                                                                                                        runat="server" AutoGenerateColumns="False" EnableCallbackMode="true" AutoPostBack="true" OnSelectedIndexChanged="cmbCategoryMaster_SelectedIndexChanged"
                                                                                                                                        IncrementalFilteringMode="Contains" ValueType="System.Int32" TextField="CategoryMasterNameEn" ValueField="CategoryMasterID">
                                                                                                                                        <ButtonStyle CssClass="btn-default" />
                                                                                                                                        <%--<ValidationSettings ValidationGroup="AddNew">
                                                                                                                                                <RequiredField IsRequired="true" ErrorText="Select Module!" />
                                                                                                                                            </ValidationSettings>--%>
                                                                                                                                    </dx:ASPxComboBox>
                                                                                                                                </dx:LayoutItemNestedControlContainer>
                                                                                                                            </LayoutItemNestedControlCollection>
                                                                                                                        </dx:LayoutItem>
                                                                                                                        <dx:LayoutItem Caption="Link Category" ColSpan="2">
                                                                                                                            <LayoutItemNestedControlCollection>
                                                                                                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server" SupportsDisabledAttribute="True">
                                                                                                                                    <dx:ASPxComboBox ID="cmbLinkCategory" ClientInstanceName="cmbLinkCategory" Width="150px"
                                                                                                                                        runat="server" AutoGenerateColumns="False" EnableCallbackMode="true" AutoPostBack="true" OnLoad="cmbLinkCategory_Load"
                                                                                                                                        IncrementalFilteringMode="Contains" ValueType="System.Int32" TextField="LinkCategoryEName" ValueField="LinkCategoryID">
                                                                                                                                        <ButtonStyle CssClass="btn-default" />
                                                                                                                                        <%--<ValidationSettings ValidationGroup="AddNew">
                                                                                                                                                <RequiredField IsRequired="true" ErrorText="Select Module!" />
                                                                                                                                            </ValidationSettings>--%>
                                                                                                                                    </dx:ASPxComboBox>
                                                                                                                                </dx:LayoutItemNestedControlContainer>
                                                                                                                            </LayoutItemNestedControlCollection>
                                                                                                                            <CaptionStyle CssClass="caption"></CaptionStyle>
                                                                                                                        </dx:LayoutItem>

                                                                                                                        <dx:LayoutItem ShowCaption="False">
                                                                                                                            <LayoutItemNestedControlCollection>
                                                                                                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server" SupportsDisabledAttribute="True">
                                                                                                                                    <dx:ASPxLabel ID="msg" runat="server" Text="" ForeColor="Blue" Font-Bold="true" Font-Italic="true"></dx:ASPxLabel>
                                                                                                                                </dx:LayoutItemNestedControlContainer>
                                                                                                                            </LayoutItemNestedControlCollection>
                                                                                                                            <CaptionStyle CssClass="caption"></CaptionStyle>
                                                                                                                        </dx:LayoutItem>
                                                                                                                        <dx:EmptyLayoutItem />
                                                                                                                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right">
                                                                                                                            <LayoutItemNestedControlCollection>
                                                                                                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server" SupportsDisabledAttribute="True">
                                                                                                                                    <dx:ASPxButton ID="BtnCopy" runat="server" CssClass="btn-info-alt" ToolTip="<%$ Resources:GlobalResource, BtnSave %>" CommandName="Copy" AutoPostBack="true" Cursor="pointer"
                                                                                                                                        EnableTheming="false" Text="Copy" CommandArgument='<%#Eval("LinksID") %>' ValidationGroup="editForm" OnClick="BtnSaveEditForm1_Click" Width="120px">
                                                                                                                                    </dx:ASPxButton>
                                                                                                                                </dx:LayoutItemNestedControlContainer>
                                                                                                                            </LayoutItemNestedControlCollection>
                                                                                                                            <CaptionStyle CssClass="caption"></CaptionStyle>
                                                                                                                        </dx:LayoutItem>
                                                                                                                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Left">
                                                                                                                            <LayoutItemNestedControlCollection>
                                                                                                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server" SupportsDisabledAttribute="True">
                                                                                                                                    <dx:ASPxButton ID="BtnCut" runat="server" CssClass="btn-warning-alt" ToolTip="<%$ Resources:GlobalResource, BtnSave %>" CommandName="Move" AutoPostBack="true" Cursor="pointer"
                                                                                                                                        EnableTheming="false" Text="Move" CommandArgument='<%#Eval("LinksID") %>' ValidationGroup="editForm" OnClick="BtnSaveEditForm1_Click" Width="120px">
                                                                                                                                    </dx:ASPxButton>
                                                                                                                                </dx:LayoutItemNestedControlContainer>
                                                                                                                            </LayoutItemNestedControlCollection>
                                                                                                                            <CaptionStyle CssClass="caption"></CaptionStyle>
                                                                                                                        </dx:LayoutItem>

                                                                                                                    </Items>
                                                                                                                </dx:LayoutGroup>
                                                                                                            </Items>
                                                                                                        </dx:ASPxFormLayout>
                                                                                                        <%--<asp:ObjectDataSource ID="AllCategoryMasterDS" runat="server" SelectMethod="GetAll"
                                                                                                                TypeName="BusinessLayer.Admin.CategoryMasterDB" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>--%>
                                                                                                        <asp:ObjectDataSource ID="AllLinkCategoryDS" runat="server" SelectMethod="GetAll"
                                                                                                            TypeName="BusinessLayer.Admin.LinksCategoryDB" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </EditForm>
                                                                                </Templates>

                                                                                <ClientSideEvents EndCallback="function(s, e) {if(s.cpDeleteError != ''){lblErrorDet.SetText(s.cpDeleteError);}else{lblErrorDet.SetText('');}}" />
                                                                                <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                                                                <SettingsText PopupEditFormCaption="<%$ Resources:GlobalResource, BtnAddNew %>" />
                                                                                <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                                                                                <SettingsPager PageSize="20"></SettingsPager>
                                                                                <SettingsEditing Mode="PopupEditForm" NewItemRowPosition="Bottom" />
                                                                                <SettingsCommandButton>
                                                                                    <ClearFilterButton Image-Url="../images/grd_clear.png">
                                                                                        <Image Url="../images/grd_clear.png">
                                                                                        </Image>
                                                                                    </ClearFilterButton>
                                                                                    <EditButton>
                                                                                        <Image Url="../images/grd_edit.png">
                                                                                        </Image>
                                                                                    </EditButton>
                                                                                    <DeleteButton>
                                                                                        <Image Url="../images/grd_Delete.png">
                                                                                        </Image>
                                                                                    </DeleteButton>
                                                                                    <CancelButton>
                                                                                        <Image Url="../images/grd_clear.png">
                                                                                        </Image>
                                                                                    </CancelButton>
                                                                                    <UpdateButton>
                                                                                        <Image Url="../images/save.png">
                                                                                        </Image>
                                                                                    </UpdateButton>
                                                                                </SettingsCommandButton>
                                                                            </dx:ASPxGridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 20px"></tr>
                                                                    <tr>
                                                                        <td class="Title">
                                                                            <hr />
                                                                            <dx:ASPxLabel ID="LblModuleLinkTitle" runat="server" Text="Sources" RenderMode="Link" EnableTheming="false" CssClass="Title" meta:resourcekey="lblDetailsTitle"></dx:ASPxLabel>

                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 10px"></tr>
                                                                    <tr>
                                                                        <td class="Alert">
                                                                            <dx:ASPxLabel ID="LblErrorLink" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblErrorDet"></dx:ASPxLabel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 20px"></tr>
                                                                </table>
                                                            </DetailRow>
                                                        </Templates>

                                                        <ClientSideEvents EndCallback="function(s, e) {if(s.cpDeleteError != ''){lblErrorDet.SetText(s.cpDeleteError);}else{lblErrorDet.SetText('');}}" />
                                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                                        <SettingsText PopupEditFormCaption="<%$ Resources:GlobalResource, BtnAddNew %>" />
                                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                                                        <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true" />
                                                        <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                                                        <SettingsCommandButton>
                                                            <ClearFilterButton Image-Url="../images/grd_clear.png">
                                                                <Image Url="../images/grd_clear.png">
                                                                </Image>
                                                            </ClearFilterButton>
                                                            <EditButton>
                                                                <Image Url="../images/grd_edit.png">
                                                                </Image>
                                                            </EditButton>
                                                            <DeleteButton>
                                                                <Image Url="../images/grd_Delete.png">
                                                                </Image>
                                                            </DeleteButton>
                                                            <CancelButton>
                                                                <Image Url="../images/grd_clear.png">
                                                                </Image>
                                                            </CancelButton>
                                                            <UpdateButton>
                                                                <Image Url="../images/save.png">
                                                                </Image>
                                                            </UpdateButton>
                                                        </SettingsCommandButton>
                                                    </dx:ASPxGridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </DetailRow>


                                </Templates>
                                <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                <SettingsText PopupEditFormCaption="<%$ Resources:GlobalResource, BtnAddNew %>" />
                                <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                                <Settings ShowFilterRow="True" />
                                <SettingsText PopupEditFormCaption="Edit" />
                                <SettingsEditing Mode="Inline" />
                                <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true" />
                                <SettingsPopup EditForm-Modal="true">
                                    <EditForm Modal="True" HorizontalAlign="Center" VerticalAlign="Middle"></EditForm>
                                </SettingsPopup>
                                <SettingsCommandButton>
                                    <ClearFilterButton Image-Url="../images/grd_clear.png">
                                        <Image Url="../images/grd_clear.png">
                                        </Image>
                                    </ClearFilterButton>
                                    <EditButton>
                                        <Image Url="../images/grd_edit.png">
                                        </Image>
                                    </EditButton>
                                    <DeleteButton>
                                        <Image Url="../images/grd_Delete.png">
                                        </Image>
                                    </DeleteButton>
                                    <CancelButton>
                                        <Image Url="../images/grd_clear.png">
                                        </Image>
                                    </CancelButton>
                                    <UpdateButton>
                                        <Image Url="../images/save.png">
                                        </Image>
                                    </UpdateButton>
                                </SettingsCommandButton>
                            </dx:ASPxGridView>

                            <asp:ObjectDataSource ID="RolesDS" runat="server" SelectMethod="GetAll"
                                TypeName="BusinessLayer.Admin.RolesDB" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>

                            <asp:ObjectDataSource ID="ModulesDS" runat="server" SelectMethod="GetAll"
                                TypeName="BusinessLayer.Admin.ModuleDB" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>

                            <asp:ObjectDataSource ID="CategoryMasterDS" runat="server"
                                SelectMethod="GetByFKModuleID"
                                TypeName="BusinessLayer.Admin.CategoryMasterDB" OldValuesParameterFormatString="original_{0}"
                                DataObjectTypeName="BusinessLayer.ADMCategoryMaster"
                                DeleteMethod="Delete"
                                InsertMethod="Insert"
                                UpdateMethod="Update">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="CmbFlowModules" PropertyName="Value" Name="ID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="LinkCategoryDS" runat="server" SelectMethod="GetByCategoryMasterId"
                                TypeName="BusinessLayer.Admin.LinksCategoryDB" OldValuesParameterFormatString="original_{0}"
                                DataObjectTypeName="BusinessLayer.ADMLinkCategory"
                                DeleteMethod="Delete"
                                InsertMethod="Insert"
                                UpdateMethod="Update">
                                <SelectParameters>
                                    <asp:SessionParameter SessionField="FkMasterID" Name="id" Type="Int32"></asp:SessionParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="LinksDS" runat="server" SelectMethod="GetByFKCategoryId"
                                TypeName="BusinessLayer.Admin.LinksDB" OldValuesParameterFormatString="original_{0}"
                                DataObjectTypeName="BusinessLayer.ADMLinks"
                                DeleteMethod="Delete"
                                InsertMethod="Insert"
                                UpdateMethod="Update">
                                <SelectParameters>
                                    <asp:SessionParameter SessionField="FkCategoryID" Name="categoryId" Type="Int32"></asp:SessionParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
