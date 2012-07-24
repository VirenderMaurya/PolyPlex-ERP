<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/EmptyMaster.master" AutoEventWireup="true" CodeFile="POClose.aspx.cs" Inherits="Procurement_POClose" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .txtbox
        {
            width: 130px;
            border: 1px solid grey;
            font-family: Arial;
            font-size: 12px;
        }
        
        .valid
        {
            color: Red;
            font-weight: bold;
            font-size: 11px;
        }
    </style>
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScript" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
            <center>
                <table width="80%" cellpadding="3px">
                    <tr>
                        <td width="20%">
                            &nbsp;
                        </td>
                        <td width="20%">
                        </td>
                        <td width="20%">
                        </td>
                        <td width="20%">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                Purchase Order:</div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtPO" runat="server" Width="110px" CssClass="txtbx" Enabled="False"></asp:TextBox>
                                <asp:ImageButton ID="img_Customer_lookup" runat="server" CausesValidation="False"
                                    ImageUrl="~/Images/select.gif" OnClick="img_Customer_lookup_Click" />
                                <asp:RequiredFieldValidator ID="Rfv2" runat="server" ControlToValidate="txtPO" Display="None"
                                    ErrorMessage="Please select Purchase Order."></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                    CssClass="customCalloutStyle" Enabled="True" PopupPosition="TopRight" TargetControlID="Rfv2">
                                </ajaxToolkit:ValidatorCalloutExtender>
                            </div>
                        </td>
                        <td>
                        </td>
                        <td>
                            <div align="right">
                                PO Date:</div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtPODate" runat="server" CssClass="txtbx" Width="130px" Enabled="False"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                Vendor Name:</div>
                        </td>
                        <td colspan="2">
                            <div align="left">
                                <strong>
                                    <asp:Label ID="lblVendorName" runat="server" Text=""></asp:Label></strong></div>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="border: 1px solid black">
                            <center>
                                <asp:Panel ID="pnl_POLine" runat="server">
                                    <asp:GridView ID="gridPOLine" runat="server" AllowPaging="True" PageSize="4" Width="100%"
                                        EmptyDataText="Select Purchase Order." ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                        CssClass="GridViewStyle" DataKeyNames="LineItem">
                                        <AlternatingRowStyle CssClass="AltRowStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="PRNumber" HeaderText="PR Number" />
                                            <asp:BoundField DataField="MaterialCodeName" HeaderText="Material" />
                                            <asp:BoundField DataField="POQuantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="UOM" HeaderText="UOM" />
                                            <asp:BoundField DataField="Price" HeaderText="Pro" />
                                        </Columns>
                                        <HeaderStyle CssClass="HeaderStyle" />
                                        <PagerStyle CssClass="PagerStyle" />
                                        <RowStyle CssClass="RowStyle" />
                                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hf_POID" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ImageButton ID="btnSave" runat="server" CssClass="Button" ImageUrl="~/Images/btnSave.png"
                                Text="Save" onclick="btnSave_Click"  />&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnExit.png" OnClientClick="window.close()"
                                Style="font-weight: bold" Text="Cancel" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </center>
            <asp:Panel ID="Pnl_Grid_Master" runat="server" Height="445px" Width="650px" CssClass="modalPopup"
                Style="display: none">
                <asp:Panel ID="Pnl_GridMasterDrag" runat="server" Style="cursor: pointer">
                    <table width="100%">
                        <tr>
                            <td>
                                <div style="margin: 10px 0px 10px 20px">
                                    <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" /></div>
                            </td>
                            <td valign="top">
                                <div style="float: right; padding: 20px 20px 0 0">
                                    <asp:ImageButton ID="btn_grid_master_close" runat="server" AlternateText="Cancel"
                                        ImageUrl="~/Images/delete.gif" /></div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div style="margin-left: 20px; margin-right: 20px">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td>
                                <div class="in_menu_head">
                                    Purchase Order</div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnl_div" runat="server" Height="245px" Width="605px" ScrollBars="Auto">
                                    <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                        DataKeyNames="Autoid,PONumber,PODate,VendorName,PORelease" Width="100%" EmptyDataText="No  Result match your search criteria."
                                        PageSize="7" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"
                                        OnPageIndexChanging="gridMaster_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                            ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PONumber" HeaderText="PO Number" />
                                            <asp:BoundField DataField="PODate" HeaderText="PO Date" />
                                            <asp:BoundField DataField="VendorName" HeaderText="Vendor" />
                                            <asp:BoundField DataField="Currency" HeaderText="Currency" />
                                        </Columns>
                                        <RowStyle CssClass="RowStyle" />
                                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                                        <PagerStyle CssClass="PagerStyle" />
                                        <AlternatingRowStyle CssClass="AltRowStyle" />
                                        <HeaderStyle CssClass="HeaderStyle" />
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Polyplex_DB %>"
                                    ProviderName="<%$ ConnectionStrings:Polyplex_DB.ProviderName %>"></asp:SqlDataSource>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LabelTarget"
                PopupControlID="Pnl_Grid_Master" BackgroundCssClass="modalBackground" DropShadow="true"
                PopupDragHandleControlID="Pnl_GridMasterDrag" CancelControlID="btn_grid_master_close" />
            <asp:Label ID="LabelTarget" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


