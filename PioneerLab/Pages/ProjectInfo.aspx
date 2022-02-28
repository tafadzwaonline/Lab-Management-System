<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ProjectInfo.aspx.cs" Inherits="PioneerLab.Pages.ProjectInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidateDate() {
            var startDate = dtStartDate.GetDate();

            var endDate = dtEndDate.GetDate();

            if ((Date.parse(endDate) <= Date.parse(startDate))) {
                alert("End Date should be greater than Start Date....!")
                //document.getElementById("AdvEndDate1").innerText = "End Date should be greater than From Date....!";
               // document.getElementById("dtEndDate").value = "";
            }
           
        };

        //function parseDate(str) {
        //    var mdy = str.split('/')
        //    console.log(mdy)
        //    return new Date(mdy[2], mdy[1] - 1, mdy[0]);
        //}

       
    </script>
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
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>
            <li><a id="menu1" href="#">Setup</a></li>
            <li class="active" id="menulink">Project Information</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Project Information</h1>
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

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
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
        <dx:ASPxFormLayout ID="flProjectsList" runat="server" Width="800" DataSourceID="ProjectsListDS" ClientInstanceName="flProjectsList">
            <Items>
                <dx:LayoutGroup Caption="Project Information" ColCount="6">
                    <Items>
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem Width="150" />
                        <dx:LayoutItem ShowCaption="False" FieldName="IsClosed" HorizontalAlign="Right" Height="40" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsClosed" runat="server" Text="Inactive" TextAlign="Right" ></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project Code" FieldName="ProjectCode" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtCode" ReadOnly="true" runat="server" Width="200">
                                        <ValidationSettings ValidationGroup="OnSave">
                                            <RequiredField IsRequired="true" ErrorText="Code is required!" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ashghal Code" FieldName="AshghalCode" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtAshghalCode" runat="server" Width="240"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Start Date" FieldName="StartDate" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtStartDate"  ClientInstanceName="dtStartDate"  runat="server" Width="230" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                          <ClientSideEvents  DateChanged= ValidateDate />
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="End Date" FieldName="EndDate" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dtEndDate"  ClientInstanceName="dtEndDate"  runat="server" Width="240" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy" >
                                        <ClientSideEvents  DateChanged= ValidateDate />
                                       
                                    </dx:ASPxDateEdit>
                                
                                </dx:LayoutItemNestedControlContainer>
                                
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project Name" FieldName="ProjectName" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtName" runat="server" Width="595">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Enter Project Name" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Location" FieldName="ProjectLocation" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtLocation" runat="server" Width="595"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project Type" FieldName="FKProjectTypeID" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbProjectTypeID" runat="server" Width="250" ValueField="ProjectTypeID" TextField="ProjectTypeName" DataSourceID="ProjectsTypesDS">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Project Type" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Project Consultant" FieldName="ProjectConsultant" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtProjectConsultant" runat="server" Width="595"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Contractor" FieldName="FKContractorID" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbContractorID" runat="server" Width="250" ValueField="ContractorID" TextField="ContractorName" DataSourceID="ContractorsListDS">
                                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="OnSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="true" ErrorText="Select Contractor" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Project Owner" FieldName="ProjectOwner" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtProjectOwner" runat="server" Width="595"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>

    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete"
        OnInserting="ProjectsListDS_Inserting" OnInserted="ProjectsListDS_Inserted"
        OnUpdating="ProjectsListDS_Updating" OnUpdated="ProjectsListDS_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.ProjectsTypes"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ContractorsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ContractorsListDB"
        DataObjectTypeName="BusinessLayer.ContractorsList" SelectMethod="GetAll"></asp:ObjectDataSource>
</asp:Content>
