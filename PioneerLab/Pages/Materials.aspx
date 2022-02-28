<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="Materials.aspx.cs" Inherits="PioneerLab.Pages.Materials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function PrintReport() {
           
             window.open('ReportViwer.aspx?source=MaterialList&id=0&Filter=' + gridMaterialsList.cpFilter);
            
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
            <li class="active" id="menulink">Material Information</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Material Information</h1>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Material" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                <ClientSideEvents Click="function (s, e) { gridMaterialsList.AddNewRow();}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
              <ClientSideEvents click="PrintReport"/>

            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvMaterialsList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridMaterialsList" DataSourceID="MaterialsListDS" KeyFieldName="MaterialDetailsID"
            OnRowInserting="GdvMaterialsList_RowInserting" OnCustomButtonInitialize="GdvMaterialsList_CustomButtonInitialize" OnBeforeGetCallbackResult="GdvMaterialsList_BeforeGetCallbackResult" OnCommandButtonInitialize="GdvMaterialsList_CommandButtonInitialize" OnRowUpdating="GdvMaterialsList_RowUpdating" OnRowInserted ="GdvMaterialsList_RowInserted"  OnRowUpdated="GdvMaterialsList_RowUpdated" OnCustomErrorText="GdvMaterialsList_CustomErrorText">
            <Columns>
                <%--<dx:GridViewDataTextColumn FieldName="EmpCode" Caption="Code"  VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataTextColumn FieldName="MaterialName" Caption="Material Name" Width="400" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="FKMaterialTypeID" Caption="Service Section" VisibleIndex="2">
                    <PropertiesComboBox ValueField="MaterialTypeID" TextField="MaterialName" DataSourceID="MaterialsTypesDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="MaterialUse" Caption="Material Use" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="StandardSpecs" Caption="Specification value" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="Specification No" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="6" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnView" Text=" " Image-ToolTip=""  >
                         <Image Url="../images/vision-clipart-1-eye-8.png" Width="22" Height="22" ToolTip="View" ></Image>

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
            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="PopupEditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <ClientSideEvents CustomButtonClick="function(s, e) {var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Material_Information&id=' + key);}" />

            <%--<SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true" />--%>
            <Templates>
                <EditForm>
                    <asp:Panel ID="PanEditForm" runat="server" OnInit="PanEditForm_Init">
                        <table style="padding-left: 20px; width: 700px">
                            <%--<tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblCode" runat="server" Text="Material Code"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtCode" runat="server" Text='<%#Eval("EmpCode") %>'></dx:ASPxTextBox>
                                </td>

                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>--%>
                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px"></td>
                                <td></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblIsLocked" runat="server" Text=""></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="IsLocked" runat="server" Value='<%#Eval("IsLocked") %>' Text="Inactive"></dx:ASPxCheckBox>
                                </td>

                            </tr>
                            <tr style="height: 10px">
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblName" runat="server" Text="Material Name"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtName" runat="server" Text='<%#Eval("MaterialName") %>'>
                                          <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="editForm">
                                            <RequiredField IsRequired="true" ErrorText="Enter Material Name" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblFKMaterialTypeID" runat="server" Text="Service Section"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbFKMaterialTypeID" runat="server" ValueField="MaterialTypeID" TextField="MaterialName"
                                        DataSourceID="MaterialsTypesDS" Value='<%#Eval("FKMaterialTypeID") %>' ValueType="System.Int32">
                                         <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="editForm">
                                            <RequiredField IsRequired="true" ErrorText="Enter Service Section" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>

                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblMaterialUse" runat="server" Text="Material Use"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMaterialUse" runat="server" Value='<%#Eval("MaterialUse") %>'></dx:ASPxTextBox>
                                </td>
                                <td style="width: 140px">
                                    <dx:ASPxLabel ID="lblMaterialDescription" runat="server" Text="Material Description"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMaterialDescription" runat="server" Value='<%#Eval("MaterialDescription") %>'></dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td colspan="5"></td>
                            </tr>

                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px">
                                    <dx:ASPxLabel ID="lblStandardSpecs" runat="server" Text="Specification value"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtStandardSpecs" runat="server" Value='<%#Eval("StandardSpecs") %>'></dx:ASPxTextBox>
                                </td>
                                <td style="width: 140px">
                                    <dx:ASPxLabel ID="lblStandardNumber" runat="server" Text="Specification No"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtStandardNumber" runat="server" Value='<%#Eval("StandardNumber") %>'></dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td colspan="5"></td>
                            </tr>

                            <tr style="height: 3px">
                                <td style="width: 10px"></td>
                                <td style="width: 120px"></td>
                                <td colspan="3"><b>Available Services:</b></td>
                            </tr>
                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px"></td>
                                <td colspan="3">
                                    <dx:ASPxGridView runat="server" ID="GdvMaterialTestList" AutoGenerateColumns="false" ClientInstanceName="gridMaterialTestList"
                                        DataSourceID="MaterialsDetailsTestsDS" KeyFieldName="MaterialTestID" OnBeforePerformDataSelect="GdvMaterialTestList_BeforePerformDataSelect">
                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Service Name" Width="230" VisibleIndex="1">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a test!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a test" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                             <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Standard Number" Width="230" VisibleIndex="2">
                                                <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a test!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a test" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                        </Columns>
                                        <Styles>
                                            <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                        </Styles>
                                        <SettingsPager PageSize="5"></SettingsPager>
                                        <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  />
                                        <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
                                    </dx:ASPxGridView>
                                </td>


                            </tr>
                            <tr style="height: 15px">
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td style="width: 10px"></td>
                                <td style="width: 120px"></td>
                                <td>
                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNewDetail" Text="Add or Remove Services" CssClass="btn btn-round btn-primary fa fa-list" runat="server">
                                        <ClientSideEvents Click="function (s, e) { popTestLists.Show();}" />
                                    </dx:ASPxButton>
                                </td>
                                <td colspan="2">
                                    <table cellpadding="0" cellspacing="0" style="text-align: end; float: right">
                                        <tr>
                                            <td>
                                                <dx:ASPxButton ID="BtnSaveEditForm" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnSave %>" CommandName="CmdSave" AutoPostBack="false" Cursor="pointer"
                                                    EnableTheming="false" Text="Save" CommandArgument='<%#Eval("MaterialDetailsID") %>' ValidationGroup="editForm" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk">
                                                 <%--<ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
                                                 --%>  
                                                    <ClientSideEvents Click="function(s,e) {if(ASPxClientEdit.ValidateGroup('editForm')) {gridMaterialsList.UpdateEdit();}}" />
                                                     
                                                   <%-- <ClientSideEvents Click="function(s,e) {gridMaterialsList.UpdateEdit();}" />--%>
                                                </dx:ASPxButton>
                                            </td>
                                            <td width="5"></td>
                                            <td>
                                                <dx:ASPxButton ID="BtnCancel" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Close" AutoPostBack="false">
                                                    <ClientSideEvents Click="function(s, e) { gridMaterialsList.CancelEdit(); }" />
                                                </dx:ASPxButton>
                                            </td>
                                            <td width="10"></td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td colspan="5"></td>
                            </tr>
                        </table>
                    </asp:Panel>

                </EditForm>
                <%--<DetailRow>
                    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                        <div class="btn-group" role="group" aria-label="First group">
                            <dx:ASPxButton AutoPostBack="false" ID="btnAddNewDetail" Text="Add New Custom Field" CssClass="btn btn-round btn-primary fa fa-plus" runat="server">
                                <ClientSideEvents Click="function (s, e) { popTestLists.Show();}" />
                            </dx:ASPxButton>
                        </div>
                    </div>
                    <div class="row" style="height: 10px"></div>
                    <div class="btn-toolbar">
                        <dx:ASPxGridView runat="server" ID="GdvMaterialTestList" AutoGenerateColumns="false" ClientInstanceName="gridMaterialTestList"
                            DataSourceID="MaterialsDetailsTestsDS" KeyFieldName="MaterialTestID" OnBeforePerformDataSelect="GdvMaterialTestList_BeforePerformDataSelect">
                            <Columns>
                                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Test Name" Width="400" VisibleIndex="1">
                                    <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a test!">
                                            <RequiredField IsRequired="true" ErrorText="Select a test" />
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>

                            </Columns>
                            <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                        </dx:ASPxGridView>
                    </div>
                </DetailRow>--%>
            </Templates>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div>
        <dx:ASPxPopupControl ID="popTestLists" runat="server" CloseAction="OuterMouseClick" OnWindowCallback="popTestLists_WindowCallback"
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Available Services List" ClientInstanceName="popTestLists">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
                    <div style=" display:none ;overflow: auto; height: 400px">
                        <dx:ASPxCheckBoxList ID="lstTests" runat="server" ClientInstanceName="lstTests" DataSourceID="TestsListDS" ValueType="System.Int32"
                            TextField="TestName" ValueField="TestID" Width="500" OnDataBound="lstTests_DataBound">
                        </dx:ASPxCheckBoxList>
                    </div>
                     <dx:ASPxGridView runat="server" ID="GdvLabTestsList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridLabTestsList"
                        DataSourceID="TestsListDS" KeyFieldName="TestID" OnDataBound="GdvLabTestsList_DataBound" >
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
                         <SettingsBehavior AutoFilterRowInputDelay="50000"  />
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

    <asp:ObjectDataSource ID="MaterialsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.MaterialsDetails"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes"></asp:ObjectDataSource>


    <asp:ObjectDataSource ID="MaterialsDetailsTestsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsDetailsTestsDB"
        SelectMethod="GetByFKMaterialDetailsIDWithSession" UpdateMethod="UpdateList" OnUpdating="MaterialsDetailsTestsDS_Updating" OnUpdated="MaterialsDetailsTestsDS_Updated">
        <SelectParameters>
            <asp:SessionParameter SessionField="FKMaterialDetailsID" Name="FKMaterialDetailsID" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>


</asp:Content>
