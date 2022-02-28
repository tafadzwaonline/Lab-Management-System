﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ServicesVsConsumableMaterialsReport.aspx.cs" Inherits="PioneerLab.Pages.Reports.ServicesVsConsumableMaterialsReport" %>
<%--<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>--%>
<%@ Register Assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

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
            <li><a id="menu1" href="#">Report</a></li>
            <li class="active" id="menulink">Services Vs Consumable Materials</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Services Vs Consumable Materials</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
  
    <script type="text/javascript">
         function init(s) {
             var createFrameElement = s.viewer.printHelper.createFrameElement;
             s.viewer.printHelper.createFrameElement = function (name) {
                 var frameElement = createFrameElement.call(this, name);
                 if(ASPx.Browser.Chrome) {
                     frameElement.addEventListener("load", function (e) {
                         if (frameElement.contentDocument &&  frameElement.contentDocument.contentType !== "text/html")
                             frameElement.contentWindow.print();
                     });
                 }
                 return frameElement;
             }
        }

         var textSeparator = ",";
        function updateText() {
            var selectedItems = checkListBox.GetSelectedItems();
            checkComboBox.SetText(getSelectedItemsText(selectedItems));
        }
        function synchronizeListBoxValues(dropDown, args) {
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = getValuesByTexts(texts);
            checkListBox.SelectValues(values);
            updateText(); // for remove non-existing texts
        }
        function getSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                    texts.push(items[i].value);
            return texts.join(textSeparator);
        }
        function getValuesByTexts(texts) {
            var actualValues = [];
            var item;
            for(var i = 0; i < texts.length; i++) {
                item = checkListBox.FindItemByValue(texts[i]);
                if(item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }
    </script>

    <div style="position: relative; width: auto; background-repeat: repeat" id="divParms" runat="server">
        <div style="width: 1000px; float: left; position: relative; padding-left: 10px">
            <div id="divValidityDetails" runat="server" style="clear: left; ">
                 <table>
                    <tr>
                        <td style="width: 130px">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Date from" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 200px" colspan="2">
                            <dx:ASPxDateEdit ID="dtDateFrom" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                   <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                        </td>
                        <td style="width: 20px">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="to" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td style="width: 200px" colspan="2">
                            <dx:ASPxDateEdit ID="dtDateTo" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                   <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                        </td>
                        <td style="width: 20px">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="JO#" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                       <td>
                            <dx:ASPxComboBox ID="cmbJobOrderNo" runat="server" ValueField="JobOrderNumber" TextField="JobOrderNumber" DropDownStyle="DropDownList" Width="200"
                                    DataSourceID="JobOrderNoDS" ValueType="System.String" ClientInstanceName="cmbJobOrderNo">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnJobOrderNo" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Job Order #">  
                                <ClientSideEvents Click="function(s, e) { cmbJobOrderNo.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Service" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td style="width: 200px">
                            <dx:ASPxComboBox ID="cmbServiceName" runat="server" ValueField="TestID" TextField="TestName" DropDownStyle="DropDownList" Width="200"
                                    DataSourceID="ServiceNameDS" ValueType="System.Int32" ClientInstanceName="cmbServiceName">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                   <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="btnServiceName" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Service Name">  
                                <ClientSideEvents Click="function(s, e) { cmbServiceName.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                         <td style="width: 120px">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Consumable Number" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td style="width: 200px">
                            <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="ASPxDropDownEdit1" Width="200px" runat="server" AnimationType="None">
                            <DropDownWindowStyle BackColor="#EDEDED" />
                            <DropDownWindowTemplate>
                                <dx:ASPxListBox Width="100%" ID="listBox" ClientInstanceName="checkListBox" SelectionMode="CheckColumn" ValueType="System.Int32"
                                    runat="server" Height="200" EnableSelectAll="true" DataSourceID="ItemListDS" ValueField="ItemID" TextField="ItemName">
                                  <%--  <FilteringSettings ShowSearchUI="true"/>--%>
                                    <Border BorderStyle="None" />
                                    <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                    <ClientSideEvents SelectedIndexChanged="updateText" Init="updateText" />
                                </dx:ASPxListBox>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 4px">
                                            <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" style="float: right">
                                                <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </DropDownWindowTemplate>
                            <ClientSideEvents TextChanged="synchronizeListBoxValues" DropDown="synchronizeListBoxValues" />
                        </dx:ASPxDropDownEdit>
                        </td>
                        <td style="width: 10px"></td>
                        <td>
                            <dx:ASPxButton ID="btnGenerate" runat="server" Style="width: 80px"  OnClick="btnGenerate_Click" ValidationGroup="editForm" Text="Generate"></dx:ASPxButton>
                        </td> 
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
    <dx:ASPxLabel ID="lblError" runat="server" ClientInstanceName="lblError" Text=""></dx:ASPxLabel>
    <dx:ASPxDocumentViewer ID="ReportViewer1" runat="server" BackColor="Transparent" Height="800px" Width="100%" ZoomMode="Percent" ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote" ShowParameterPrompts="False" SettingsSplitter-SidePaneVisible="false" ToolBarItemBorderStyle="Solid">
        <ClientSideEvents Init="init" />
    </dx:ASPxDocumentViewer>

     <asp:ObjectDataSource ID="ServiceNameDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
    SelectMethod="GetAll"  DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="JobOrderNoDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
    SelectMethod="GetAll"  DataObjectTypeName="BusinessLayer.JobOrderMaster"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ItemListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ItemsListDB"
    SelectMethod="GetAll"  DataObjectTypeName="BusinessLayer.ItemsList"></asp:ObjectDataSource>
</asp:Content>
