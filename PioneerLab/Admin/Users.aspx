<%@ Page Title="Users" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PioneerLab.Admin.Users" %>

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
            <%--          <li><a id="menu2" href="#">General</a></li>--%>
            <li class="active" id="menulink">User Data</li>

        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>User Data
			
        </h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
      <div class="btn-toolbar">
    <table>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" style="width: 100%; margin-top: 10px">
                    <tr>
                        <td colspan="6" style="height: 15px">
                            <table cellpadding="0" cellspacing="0" height="30">
                                <tr>
                                    <td>
                                        <div style="margin: 0 10px 0 0; width: 100px">
                                      <dx:ASPxLabel ID="lblUserId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>

                                            <dx:ASPxButton ID="btnSave" ValidationGroup="savegrp" CausesValidation="true" CssClass="btn btn-primary" Style="width: 80px" runat="server" OnClick="btnSave_Click" Text="Save"></dx:ASPxButton>
                                        </div>
                                    </td>
                                    <td class="Btn-sep"></td>
                                    <td>
                                        <div style="margin: 0 10px; width: 100px">

                                            <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" Style="width: 80px" CssClass="btn btn-default" OnClick="btnCancel_Click" Text="Cancel"></dx:ASPxButton>
                                        </div>
                                    </td>

                                </tr>
                            </table>
                        </td>

                        <td rowspan="3"></td>
                    </tr>

                    <tr>
                        <td colspan="6" class="Alert" style="margin-top:5px;">
                            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError" ForeColor="Red" ></dx:ASPxLabel>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="6">
                            <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup=""></dx:ASPxValidationSummary>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>

    <div style="height: 10px;"></div>

    <table style="width: 100%;">
        <tr>

            <td style="vertical-align: top;">
                <table>

                    <tr>
                        <td colspan="6" style="height: 7px"></td>
                    </tr>
                    <tr>

                        <td style="width: 120px;">
                            <dx:ASPxLabel ID="lblDate" runat="server" Text="User Name" meta:resourcekey="LblDate"></dx:ASPxLabel>
                        </td>

                        <td style="width: 250px;">
                            <dx:ASPxTextBox ID="txtCode" MaxLength="20" Width="150" runat="server" Height="21" CssClass="textbox">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <RequiredField IsRequired="true" ErrorText="Enter Code" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 30px;"></td>
                        <td style="width: 100px"></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 7px"></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;">
                            <dx:ASPxLabel ID="lblNotes" runat="server" Text="	English Name" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>
                        <td style="width: 250px;">
                            <dx:ASPxTextBox ID="txtEnglishName" MaxLength="80" Width="250px" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <RequiredField IsRequired="true" ErrorText="Enter English Name" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 30px;"></td>
                        <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Arabic Name" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>
                        <td style="width: 280px;">
                            <dx:ASPxTextBox ID="txtArabicName" MaxLength="80" Width="250px" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <RequiredField IsRequired="true" ErrorText="Enter Arabic Name" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 7px"></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Address" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>
                        <td style="width: 250px;">
                            <dx:ASPxTextBox ID="txtAddress" MaxLength="80" Width="250" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 30px;"></td>
                        <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Phone" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>
                        <td style="width: 250px;">
                            <dx:ASPxTextBox ID="txtPhone" MaxLength="20" Width="150" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <RegularExpression ValidationExpression="[0-9]+" ErrorText="Enter Correct Number" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 7px"></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Fax" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>

                        <td style="width: 250px;">
                            <dx:ASPxTextBox ID="txtFax" MaxLength="20" Width="150" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic">
                                    <RegularExpression ValidationExpression="[0-9]+" ErrorText="Enter Correct Number" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 30px;"></td>
                        <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Mobile" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>
                        <td style="width: 250px;">
                            <dx:ASPxTextBox ID="txtMobile" MaxLength="20" Width="150" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <RegularExpression ValidationExpression="[0-9]+" ErrorText="Enter Correct Number" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="6" style="height: 7px"></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Password" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>

                        <td style="width: 250px;">
                            <dx:ASPxTextBox ID="txtPassword" MaxLength="150" Width="150" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes" Password ="true" >
                                  <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" >
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 30px;"></td>
                        <td style="width: 100px"></td>
                        <td></td>




                    </tr>
                    <tr>
                        <td colspan="6" style="height: 7px"></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;">
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Is Active" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>

                        <td style="width: 250px;">
                            <dx:ASPxCheckBox ID="ChkIsActive" Checked="false" runat="server"></dx:ASPxCheckBox>
                        </td>
                        <td style="width: 30px;"></td>
                        <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Is Removed" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                        </td>
                        <td style="width: 250px;">
                            <dx:ASPxCheckBox ID="ChkIsRemoved" Checked="false" runat="server"></dx:ASPxCheckBox>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="6" style="height: 30px"></td>
                    </tr>
                    <tr>
                        <td align="left" class="lable">
                            <dx:ASPxLabel ID="lblRole" runat="server" Text="Role"></dx:ASPxLabel>
                        </td>
                        <td colspan="5" class="lableText">
                            <dx:ASPxCheckBoxList  ID="chBoxRoles" AutoPostBack="true" runat="server" Style="vertical-align: middle; width: 100%" TextField="RoleEName" ValueField="RoleID" DataTextField="RoleEName" DataValueField="RoleID"
                                Width="300px" RepeatDirection="Horizontal" RepeatLayout="Table"  padding="1px"  CssClass="dxeCheckBoxList_DevEx" RepeatColumns="4">
                                <Border BorderStyle="None" />
                            </dx:ASPxCheckBoxList>
                        </td>
                    </tr>
                   <%--// <dx:ASPxCheckBoxList ID="ASPxCheckBoxList1" runat="server" ValueType="System.String"></dx:ASPxCheckBoxList>--%>
                </table>
            </td>
        </tr>
    </table>
          </div>
    <div style="height:30px"></div>
   <div class="btn-toolbar">
       <table>
           <tr>
               <td style="width:750px">
          <dx:ASPxGridView runat="server" ID="GdvADMUserSettings" OnRowInserting="GdvADMUserSettings_RowInserting" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridADMUserSettings"
            DataSourceID="ADMUserSettingsDS" KeyFieldName="UserSettingsID" OnRowUpdating="GdvADMUserSettings_RowUpdating" >
            <Columns>
                <dx:GridViewDataComboBoxColumn FieldName="SettingsName" VisibleIndex="2" Caption="Settings Name" >
                    <PropertiesComboBox DataSourceID="SettingsNameDS" DropDownStyle="DropDown"  >
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="SettingsValue" Caption="Settings Value" VisibleIndex="3"  CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox>
                        <Items>
                            <dx:ListEditItem Text="Yes" Value="True" />
                            <dx:ListEditItem Text="No" Value="False"/>

                        </Items>
                    </PropertiesComboBox>
                    <CellStyle HorizontalAlign="Left"></CellStyle>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                  <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="60"
                     ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                 <HeaderCaptionTemplate>
                      <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server">
                          <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-plus';}" Click="function (s, e) { gridADMUserSettings.AddNewRow();}" />
                       <BackgroundImage HorizontalPosition="center" />
                  </dx:ASPxButton>
              </HeaderCaptionTemplate>
            </dx:GridViewCommandColumn>
               
            </Columns>
            <ClientSideEvents EndCallback="function(s, e) {if(s.cpDeleteError != ''){lblError.SetText(s.cpDeleteError);}else{lblError.SetText('');}}" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" EnableRowHotTrack="True" />
            <SettingsPager Mode="ShowPager" PageSize="10"></SettingsPager>
            <Styles>
                <AlternatingRow Enabled="True">
                </AlternatingRow>
            </Styles>
            <SettingsCommandButton>
                <ClearFilterButton Text="">
                    <Image Url="../images/grd_clear.png" AlternateText="Clear">
                    </Image>
                </ClearFilterButton>
            </SettingsCommandButton>
            <SettingsEditing Mode="Inline"></SettingsEditing>
            <SettingsCommandButton>
                 <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                    <EditButton Text=" "   Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                    <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                    <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                   <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
                 </SettingsCommandButton>
        </dx:ASPxGridView>
               </td>
           </tr>
       </table>
        
    </div>
    <asp:ObjectDataSource ID="ADMUserSettingsDS" runat="server" SelectMethod="GetAllUserSettings"
        TypeName="BusinessLayer.Admin.ADMUserSettingsDB" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" DataObjectTypeName="BusinessLayer.ADMUserSettings">
         <SelectParameters>
            <asp:ControlParameter ControlID="lblUserId" PropertyName="Text" DefaultValue="0" Name="UserId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SettingsNameDS" runat="server" TypeName="BusinessLayer.Admin.ADMUserSettingsDB" SelectMethod="GetSettingsNameList"></asp:ObjectDataSource>

</asp:Content>
