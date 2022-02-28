<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attachments.aspx.cs" Inherits="PioneerLab.Pages.Attachments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onbeforeunload="RefreshParent">
    <form id="form1" runat="server">
        <div>
            <link href="../MasterPages/Test/css/style.default.css" rel="stylesheet" />

            <dx:ASPxLabel ID="lblTransID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblTransTypeID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblUploadDirectory" runat="server" Text="~/Uploaded/Attachments" Visible="false"></dx:ASPxLabel>
            <script type="text/javascript">

                var FilesGridEdited = false;

                function onFileUploadComplete(s, e) {
                    if (e.callbackData) {
                        gdvfiles.PerformCallback();
                        //FilesGridEdited = true;
                        //window.location = window.location;
                    }
                }

                ShowScreenshotWindow = function (evt, link) {
                    ShowScreenshot(link.href);
                    evt.cancelBubble = true;
                    return false;
                }
                ShowScreenshot = function (src) {
                    var screenLeft = document.all && !document.opera ? window.screenLeft : window.screenX;
                    var screenWidth = screen.availWidth;
                    var screenHeight = screen.availHeight;
                    var zeroX = Math.floor((screenLeft < 0 ? 0 : screenLeft) / screenWidth) * screenWidth;

                    var windowWidth = 575;
                    var windowHeight = 325;
                    var windowX = parseInt((screenWidth - windowWidth) / 2);
                    var windowY = parseInt((screenHeight - windowHeight) / 2);
                    if (windowX + windowWidth > screenWidth)
                        windowX = 0;
                    if (windowY + windowHeight > screenHeight)
                        windowY = 0;

                    windowX += zeroX;

                    var popupwnd = window.open(src, '_blank', "left=" + windowX + ",top=" + windowY + ",width=" + windowWidth + ",height=" + windowHeight + ", scrollbars=no, resizable=no", true);
                    if (popupwnd != null && popupwnd.document != null && popupwnd.document.body != null) {
                        popupwnd.document.body.style.margin = "0px";
                    }
                }

                function RefreshParent() {
                    //if (window.opener != null && !window.opener.closed && FilesGridEdited ==true) {
                    //    window.opener.location.reload();
                    //}
                }
                //window.onbeforeunload = RefreshParent;
                window.onunload = RefreshParent;
            </script>
            <div style="width: 100%; height: inherit">
                <div>
                    <div class="hidden" id="divmsg" runat="server" style="width: 500px;">
                        <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
                        <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
                    </div>
                </div>
                <div class="table" style="padding-left: 10px; padding-right: 10px; padding-top: 10px">
                    <div class="divrow">
                        <div>
                            <dx:ASPxLabel ID="lblKeywordsText" runat="server" Text="Keywords:"></dx:ASPxLabel>
                        </div>
                        <div>
                            <dx:ASPxMemo ID="txtKeywords" runat="server" Width="320" Height="40">
                                <ClientSideEvents TextChanged="function(s,e){FilesGridEdited=true;}" />
                            </dx:ASPxMemo>
                            <br />
                        </div>
                        <div style="float: left; margin-right: 80px;">
                            <dx:ASPxUploadControl ID="UploadControl" runat="server" ClientInstanceName="UploadControl" Width="320"
                                NullText="Select multiple files..." UploadMode="Advanced" ShowUploadButton="True" ShowProgressPanel="True"
                                OnFileUploadComplete="UploadControl_FileUploadComplete" FileUploadMode="OnPageLoad">
                                <AdvancedModeSettings EnableMultiSelect="True" EnableFileList="True" EnableDragAndDrop="True">
                                    <FileListItemStyle CssClass="pending dxucFileListItem"></FileListItemStyle>
                                </AdvancedModeSettings>
                                <%--<ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png">
                                        </ValidationSettings>--%>
                                <ValidationSettings
                                    AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png"
                                    MaxFileSize="10485760">
                                </ValidationSettings>
                                <ClientSideEvents FileUploadStart="function(s, e) { }"
                                    FileUploadComplete="onFileUploadComplete" />
                            </dx:ASPxUploadControl>
                            <br />
                            <br />
                            <p class="note">
                                <dx:ASPxLabel ID="AllowedFileExtensionsLabel" runat="server" Text="Allowed file extensions: .rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png" Font-Size="8pt">
                                </dx:ASPxLabel>
                                <br />
                                <dx:ASPxLabel ID="MaxFileSizeLabel" runat="server" Text="Maximum file size: 4 MB." Font-Size="8pt">
                                </dx:ASPxLabel>
                            </p>
                        </div>
                    </div>
                    <div class="divrow">
                        <dx:ASPxRoundPanel ID="FilContents" ClientInstanceName="gridpanel" runat="server" Width="400" Height="180" HeaderText="Attached Files">
                            <PanelCollection>
                                <dx:PanelContent>
                                    <dx:ASPxGridView ID="gdvfiles" ClientInstanceName="gdvfiles" runat="server" DataSourceID="TransactionAttachmentsDS" KeyFieldName="FileID" Width="380" OnCustomCallback="gdvfiles_CustomCallback"  OnRowCommand="gdvfiles_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataHyperLinkColumn FieldName="FileName" Caption="File" Width="250">
                                                <DataItemTemplate>
                                                    <a target='blank' style="display: block; text-wrap: avoid; width: 100px" onclick='return ShowScreenshotWindow(event, this);' ><%#Eval("FileName") %></a>
                                                </DataItemTemplate>
                                            </dx:GridViewDataHyperLinkColumn>
                                            <dx:GridViewDataTextColumn FieldName="FileSize" Name="filesize" Caption="Size" Width="50"><Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataColumn Name="Delete" Width="30" >
                                                <DataItemTemplate>
                                                    <dx:ASPxButton ID="BtnDelete" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false"  EnableViewState="false" CommandName="delete"  FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                        <Image Url="../images/cross_icon.png" ToolTip="Remove"></Image>
                                                    </dx:ASPxButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Name="Edit" Width="25">
                                                <DataItemTemplate>
                                                    <dx:ASPxButton ID="BtnEdit" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" EnableTheming="false"  EnableViewState="false" CommandName="download"  FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                        <Image AlternateText="<%$ Resources:GlobalResource, EditFormUpdate %>" ToolTip="download" Url="../images/download4.jpg"></Image>
                                                    </dx:ASPxButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                        </Columns>
                                        <SettingsCommandButton>
                                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                            <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                            <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                        </SettingsCommandButton>
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="true" />
                                        <SettingsPager PageSize="5" Mode="ShowPager"></SettingsPager>
                                        <ClientSideEvents BeginCallback="function(s,e){FilesGridEdited=true;}" />
                                    </dx:ASPxGridView>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </div>
                    <div class="divrow">
                        <div class="divrow" style="height: 15px"></div>
                        <div class="divrow" style="float: right">
                            <div class="divcell">
                                <dx:ASPxButton ID="btnAttachmentSave" Visible="false" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnSave %>" AutoPostBack="true" Cursor="pointer"
                                    EnableTheming="false" RenderMode="Link" OnClick="btnAttachmentSave_Click">
                                    <Image AlternateText="<%$ Resources:GlobalResource, BtnSave %>" ToolTip="<%$ Resources:GlobalResource, BtnSave %>" Url="../images/save_b.png"></Image>
                                </dx:ASPxButton>
                            </div>
                            <div class="divcell" style="width: 5px"></div>
                            <div class="divcell">
                                <dx:ASPxButton ID="btnAttachmentClose" visible="false" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnCancel %>" AutoPostBack="true" Cursor="pointer"
                                    EnableTheming="false" RenderMode="Link" OnClick="btnAttachmentClose_Click">
                                    <ClientSideEvents Click="function(s, e) {RefreshParent();window.open('', '_self', ''); window.close();}" />
                                    <Image AlternateText="<%$ Resources:GlobalResource, BtnCancel %>" ToolTip="<%$ Resources:GlobalResource, BtnCancel %>" Url="../images/Cancel.png"></Image>
                                </dx:ASPxButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                </div>
            </div>
            <asp:ObjectDataSource ID="TransactionAttachmentsDS" runat="server"
                OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAttachmentsWithNew" TypeName="BusinessLayer.Pages.AttachedFilesDB"
                ConflictDetection="CompareAllValues"
                DataObjectTypeName="BusinessLayer.AttachedFiles"
                DeleteMethod="DeleteData">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblTransID" DefaultValue="0" Name="transID" PropertyName="Text" Type="Int64" />
                    <asp:ControlParameter ControlID="lblTransTypeID" PropertyName="Text" DefaultValue="0" Name="transTypeID" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
    </form>
</body>
</html>
