<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="RssInfo.aspx.cs" Inherits="PioneerLab.Pages.RssInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

    </script>
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
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>
            <li><a id="menu1" href="#">Transactions</a></li>
            <li class="active" id="menulink">Request For Site Services</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>R.S.S</h1>
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

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary fa fa-floppy-o" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default fa fa-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>

        </div>
    </div>
    <div class="row" style="height: 20px"></div>
    <div class="btn-toolbar">

        <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
        </div>
        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
            <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup="OnSave"></dx:ASPxValidationSummary>
        </div>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxFormLayout ID="flRSSMaster" runat="server" DataSourceID="RSSMasterDS" ClientInstanceName="flRSSMaster">
            <Items>
                <dx:LayoutGroup Caption="RSS Information" ColCount="6">
                    <Items>
                        <dx:LayoutItem Caption="Request No" FieldName="RSSNumber" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtRSSNumber" runat="server" ReadOnly="true"  Width="90"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Request Date" FieldName="RSSDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtRSSDate" runat="server" ClientEnabled="false" Width="110" DropDownButton-ClientVisible="false" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy" ReadOnly="true"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                      <dx:LayoutItem Caption="Job Order Number" FieldName="FKJobOrderMasterID" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKJobOrderMasterID" runat="server" ValueField="JobOrderMasterID" DataSourceID="JobOrderMasterDS" ValueType="System.Int64" Width="350px"
                                        AutoPostBack="true" TextFormatString="{0} - ({2:dd MMM yyyy}) - {3}-{2}" DropDownStyle="DropDownList" OnSelectedIndexChanged="cmbFKJobOrderMasterID_SelectedIndexChanged">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Job Order" />
                                        </ValidationSettings>
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="100" />
                                            <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                            <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                            <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                             <dx:LayoutItem Caption="Project Contractor"    ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtProjectContractor"   runat="server" ReadOnly="true" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project"  ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKProjectID" runat="server" ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS" OnDataBound="cmbFKProjectID_DataBound"
                                        ValueType="System.Int32" ReadOnly="true" ClientEnabled="false" DropDownButton-ClientVisible="false" AutoPostBack="true" Width="350px">
                                       
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                        <dx:LayoutItem Caption="Contact Person @ Site" FieldName="ContactPersonAtSite" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtContactPersonAtSite"  Width="350px" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                           
                       <dx:LayoutItem Caption="Date Of Request" FieldName="RequestDate" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtRequestDate" runat="server"  Width="350px" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                         <dx:LayoutItem Caption="Contact  Mobile" FieldName="ContactMobile" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtContactMobile" runat="server" Width="350px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         
                       
                       
                          <dx:LayoutItem Caption="Requested By" FieldName="RequestBy" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtRequestBy" runat="server"  Width="350px" ></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                       </Items>
                </dx:LayoutGroup>
                 <dx:LayoutGroup Caption="Ordering Information" ColCount="6" >
                            <Items>  
                     <dx:LayoutItem Caption="Request Test Date" FieldName="RequestTestDate" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtRequestTestDate" runat="server" Width="120px"   DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                       
                                  <dx:LayoutItem Caption="Test Time At Site" FieldName="TestTime" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   <dx:ASPxTimeEdit runat="server" Width="90px" ID="tdTestTime" ClientInstanceName="tdTestTime"></dx:ASPxTimeEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Site Location" FieldName="SiteLocation" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSiteLocation" runat="server" Width="350px" ></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                               
                     <dx:LayoutItem Caption="Technician Name" FieldName="FkEmpId" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   <dx:ASPxComboBox ID="CmbTechnician"  Width="400px" ClientInstanceName="cmbTechnician" DataSourceID="EmpListDS"  CssClass="textbox"  AutoPostBack="false"
                                    runat="server" 
                                    IncrementalFilteringMode="Contains" TextFormatString="{0} -{1}" ValueType="System.Int64" ValueField="EmpID" TextField="EmpName">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Technician Name" />
                                        </ValidationSettings>
                                </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                                 <dx:LayoutItem Caption="Note" FieldName="Note" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtNote" runat="server"  Width="910px" ></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                        
                    </Items>
                             </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Test Request Information" Width="75%">
                    <Items>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                     <dx:ASPxHiddenField runat="server" ID="hf" ClientInstanceName="hf"></dx:ASPxHiddenField> 

                                    <dx:ASPxGridView runat="server" ID="gdvRSSTestList" AutoGenerateColumns="false" ClientInstanceName="gdvRSSTestList" OnCustomJSProperties="gdvRSSTestList_CustomJSProperties" OnCommandButtonInitialize="gdvRSSTestList_CommandButtonInitialize"
                                        DataSourceID="RSSTestListDS" KeyFieldName="RSSDteailsId"  Width="100%" OnCellEditorInitialize="gdvRSSTestList_CellEditorInitialize" OnRowCommand="gdvRSSTestList_RowCommand"  >
                                        <Columns>
                                           
                                            <dx:GridViewCommandColumn Name="Check" VisibleIndex="0" ButtonType="Default" Width="30"  ShowSelectCheckbox="true">
                                            </dx:GridViewCommandColumn>
                                               <dx:GridViewDataCheckColumn Name="Enabled" VisibleIndex="1"  FieldName="IsEnabled" Width="0" >
                                            </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FkTestId" Name="FKTestID"  Caption="Services Name" VisibleIndex="2" ReadOnly="true" Width="450">
                                                <PropertiesComboBox ValueField="TestID" TextField="TestName"  DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="FkTestId" Caption="Std No" VisibleIndex="3" ReadOnly="true">
                                                <PropertiesComboBox ValueField="TestID" TextField="StandardNumber" DataSourceID="TestsListDS" DropDownRows="1">
                                                    <DropDownButton ClientVisible="false"></DropDownButton>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                                           
                                          
                                        </Columns>
                                        <SettingsCommandButton>
                                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                            <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                            <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                            <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                                            <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
                                        </SettingsCommandButton>
                                        <SettingsEditing Mode="Inline"  />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                                        <SettingsLoadingPanel Mode="ShowAsPopup" Delay ="0" />
                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                        <Settings VerticalScrollableHeight="200" ColumnMinWidth="500" VerticalScrollBarMode="Auto" />
                                        <Styles StatusBar-CssClass="statusBar" />
                                       
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                 </Items>
           
        </dx:ASPxFormLayout>
    </div>
    <div>
       
        
    </div>

     <asp:ObjectDataSource ID="RSSMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.RSSMasterDB"
         SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update" OnInserting="RSSMasterDS_Inserting" OnInserted="RSSMasterDS_Inserted" OnUpdated="RSSMasterDS_Updated" OnUpdating="RSSMasterDS_Updating" >
        <SelectParameters>
             <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int64" />
            </SelectParameters>
     </asp:ObjectDataSource>

      <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrder"></asp:ObjectDataSource>

      <asp:ObjectDataSource ID="RSSTestListDS" runat="server" DataObjectTypeName="BusinessLayer.RSSDetails" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.RSSDetailsDB"
        SelectMethod="GetByMasterIDFromSession"  UpdateMethod="UpdateToSession">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
            <asp:ControlParameter ControlID="ctl00$body$flRSSMaster$cmbFKJobOrderMasterID" PropertyName="Value" Name="JobOrderMasterID" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ProjectsListDS" runat="server" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="EmpListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EmployeesListDB"
        DataObjectTypeName="BusinessLayer.EmployeesList" SelectMethod="GetAll"></asp:ObjectDataSource>

      <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>

</asp:Content>
