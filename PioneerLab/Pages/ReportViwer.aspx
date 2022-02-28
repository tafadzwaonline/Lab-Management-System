﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReportViwer.aspx.cs" Inherits="PioneerLab.Pages.ReportViwer" %>
<%@ Register Assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagePath" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
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
    </script>
    <dx:ASPxLabel ID="LblError" runat="server" Text="" ClientInstanceName="lblError" Font-Bold="True" Font-Size="Medium"></dx:ASPxLabel>
    <dx:ASPxDocumentViewer ID="ReportViewer1" runat="server" >
        <ClientSideEvents Init="init" />
    </dx:ASPxDocumentViewer>
</asp:Content>