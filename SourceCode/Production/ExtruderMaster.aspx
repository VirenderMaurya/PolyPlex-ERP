<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/CMaster.master" AutoEventWireup="true" CodeFile="ExtruderMaster.aspx.cs" Inherits="Production_ExtruderMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
<!--
        function userAction() {
            var bConfirm = window.confirm("Confirm Exit without saving changes?");

            document.getElementById('<%=hfConfirm.ClientID%>').value = bConfirm;
        }
//-->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeading" runat="Server">
    <asp:Label ID="lbl_Heading" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScript" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
            <asp:Panel ID="pnl_Master" runat="server" Height="200px">
            </asp:Panel>
            <asp:HiddenField ID="hf_IsNewRecord" runat="server" />
            <asp:HiddenField ID="hfConfirm" runat="server" />
            <asp:HiddenField ID="hf_code" runat="server" />
            <asp:Panel ID="Panel1" runat="server" Height="400px" Width="650px" CssClass="modalPopup" style="display:none">
                <asp:Panel ID="Panel3" runat="server" Style="cursor: pointer">
                    <table width="100%">
                        <tr>
                            <td>
                                <div style="margin: 10px 0px 10px 20px">
                                    <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" /></div>
                            </td>
                            <td valign="top">
                                <div style="float: right; padding: 10px 10px 0 0">
                                    <asp:ImageButton ID="Button1" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div style="margin-left: 20px; margin-right: 20px">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td>
                                <div class="in_menu_head">
                                    <asp:Label ID="lbl_gridHeading" runat="server" Text="Label"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnl_div" runat="server" Height="220px" Width="605px" ScrollBars="Auto">
                                    <%--*****Change Here (Data Key Name)*****--%>
                                    <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"
                                        Width="100%" EmptyDataText="No  Result match your search criteria." DataKeyNames="autoid"
                                        CssClass="GridViewStyle" PageSize="7" ShowHeaderWhenEmpty="True" 
                                        onpageindexchanging="gridMaster_PageIndexChanging" 
                                        onrowdatabound="gridMaster_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                            ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="RowStyle" />
                                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                                        <PagerStyle CssClass="PagerStyle" />
                                        <AlternatingRowStyle CssClass="AltRowStyle" />
                                        <HeaderStyle CssClass="HeaderStyle" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"
                PopupDragHandleControlID="Panel3" CancelControlID="Button1" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


