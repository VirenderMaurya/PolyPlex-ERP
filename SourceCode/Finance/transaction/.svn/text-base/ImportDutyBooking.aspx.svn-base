<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="ImportDutyBooking.aspx.cs" Inherits="Finance_transaction_ImportDutyBooking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CSS/grid.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/popupstyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <asp:Panel ID="pnlhead" runat="server" BorderWidth="1" BorderColor="#999999">
        <br />
        <div>
            <table width="100%">
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                        Voucher Year
                    </td>
                    <td align="left" width="15%">
                        <asp:TextBox ID="TxtVoucherYear" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    </td>
                    <td align="right" width="10%">
                        Voucher No#
                    </td>
                    <td align="left" width="10%">
                        <asp:TextBox ID="TxtVoucherNo" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    </td>
                    <td align="right" width="10%">
                        Voucher Date
                    </td>
                    <td align="left" width="13%">
                        <asp:TextBox ID="TxtVoucherDate" runat="server" BackColor="Silver" Width="60px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalexVoucherdate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                            PopupButtonID="Imgvoucherdate" TargetControlID="TxtVoucherDate">
                        </asp:CalendarExtender>
                        <asp:ImageButton ID="Imgvoucherdate" runat="server" CausesValidation="false" ImageUrl="~/Images/cal.gif" />
                        <asp:RequiredFieldValidator ID="Reqvdate" runat="server" ControlToValidate="TxtVoucherDate"
                            Display="None" ErrorMessage="Please enter voucher date" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="Valcalreqdate" runat="server" Enabled="True" CssClass="customCalloutStyle"
                            TargetControlID="Reqvdate">
                        </asp:ValidatorCalloutExtender>
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                    </td>
                    <td align="left" width="15%">
                    </td>
                    <td align="right" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                        Bank GL Code
                    </td>
                    <td align="left" width="15%">
                        <asp:TextBox ID="TxtGLCode" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <asp:ImageButton ID="ImgBtnGLCode" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                            OnClick="ImgBtnGL_Click" Style="width: 16px" />
                    </td>
                    <td align="right" width="10%">
                        SL Code
                    </td>
                    <td align="left" width="10%">
                        <%-- <asp:TextBox ID="TxtSLCode" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>--%>
                        <asp:DropDownList ID="DldSlCode" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                    </td>
                    <td align="left" width="15%">
                    </td>
                    <td align="right" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                        Input Vat SL Code
                    </td>
                    <td align="left" width="15%">
                        <asp:TextBox ID="TxtInputVatSLCode" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td align="right" width="10%">
                    </td>
                    <td align="left" width="10%">
                        <asp:Button ID="Btnaddmorepaymentmode" runat="server" Text="Add More Payment Mode"
                            Width="160px" />
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%" class="style1">
                    </td>
                    <td align="right" width="10%" class="style1">
                    </td>
                    <td align="left" width="15%" class="style1">
                    </td>
                    <td align="right" width="10%" class="style1">
                    </td>
                    <td align="left" width="10%" class="style1">
                    </td>
                    <td align="left" width="10%" class="style1">
                    </td>
                    <td align="left" width="13%" class="style1">
                    </td>
                    <td align="left" width="10%" class="style1">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                        <asp:TextBox ID="TextBox1" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td align="left" width="15%">
                    </td>
                    <td align="right" width="10%">
                        <asp:TextBox ID="TextBox2" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                        <asp:TextBox ID="TextBox3" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                        <asp:TextBox ID="TextBox4" runat="server" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                    </td>
                    <td align="left" width="15%">
                    </td>
                    <td align="right" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                        Cheque No
                    </td>
                    <td align="left" width="15%">
                        <asp:TextBox ID="TxtChequeNo" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td align="right" width="10%">
                        Cheque Date
                    </td>
                    <td align="left" width="10%">
                        <asp:TextBox ID="TxtChequeDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <asp:CalendarExtender ID="TxtChequeDate_CalendarExtender" runat="server" Enabled="True"
                            Format="MM/dd/yyyy" PopupButtonID="Imgbtnchequedate" TargetControlID="TxtChequeDate">
                        </asp:CalendarExtender>
                        <asp:ImageButton ID="Imgbtnchequedate" CausesValidation="false" runat="server" ImageUrl="~/Images/cal.gif" />
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%" class="style1">
                    </td>
                    <td align="right" width="10%" class="style1">
                    </td>
                    <td align="left" width="15%" class="style1">
                    </td>
                    <td align="right" width="10%" class="style1">
                    </td>
                    <td align="left" width="10%" class="style1">
                    </td>
                    <td align="left" width="10%" class="style1">
                    </td>
                    <td align="left" width="13%" class="style1">
                    </td>
                    <td align="left" width="10%" class="style1">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="10%">
                        PO Number<font color="red">*</font>
                    </td>
                    <td align="left" width="15%">
                        <asp:TextBox ID="TxtPONo" runat="server" Width="70px" BackColor="Silver"></asp:TextBox>
                        <asp:ImageButton ID="ImgBtnPO" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                            OnClick="ImgBtnPO_Click" Style="width: 16px" />
                        <asp:RequiredFieldValidator ID="ReqPONo" runat="server" ControlToValidate="TxtPONo"
                            Display="None" ErrorMessage="Please select PO" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" CssClass="customCalloutStyle"
                            runat="server" Enabled="True" TargetControlID="ReqPONo">
                        </asp:ValidatorCalloutExtender>
                    </td>
                    <td align="right" width="10%">
                        Vendor
                    </td>
                    <td align="left" width="10%">
                        <asp:TextBox ID="TxtVendor" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <%--<asp:ImageButton ID="ImgBtnVendorCode" runat="server" CausesValidation="False" 
                    ImageUrl="~/images/select.gif" onclick="ImgBtnVendorCode_Click"/>--%>
                    </td>
                    <td align="left" width="10%">
                        <asp:Label ID="lblvendorname" runat="server"></asp:Label>
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="15%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="center" width="10%" colspan="8">
                        <asp:GridView ID="GdvPODetails" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record found"
                            ShowHeaderWhenEmpty="true" Width="80%">
                            <Columns>
                                <asp:BoundField DataField="PONO" HeaderText="PO Number" />
                                <asp:BoundField DataField="LineNo" HeaderText="Line Number" />
                                <asp:BoundField DataField="DutyAmount" HeaderText="Duty Amount" />
                                <asp:BoundField DataField="ImportVat" HeaderText="Import VAT" />
                                <asp:BoundField DataField="MisLeAdj" HeaderText="Mes. Adj" />
                            </Columns>
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="right" width="15%">
                        Total
                    </td>
                    <td align="left" width="10%">
                        <asp:TextBox ID="TxtTotal1" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="TxtTotal1"
                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left" width="10%">
                        <asp:TextBox ID="TxtTotal2" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="TxtTotal2"
                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="15%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="15%">
                    </td>
                    <td align="left" width="10%">
                        <asp:ImageButton ID="Btnsave" ImageUrl="~/Images/btnSave.png" runat="server" Font-Bold="True"
                            Text="Save" OnClick="Btnsave_Click" />
                    </td>
                    <td align="left" width="10%">
                        <asp:ImageButton ID="Btnaddmore" ImageUrl="~/Images/btnAdd.png" runat="server" Font-Bold="True"
                            OnClick="Btnaddmore_Click" Text="Add More PO" />
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="15%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                    <td align="left" width="13%">
                    </td>
                    <td align="left" width="10%">
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
            Style="display: none">
            <asp:Panel ID="Panel3" runat="server" Style="cursor: pointer">
                <table width="100%">
                    <tr>
                        <td>
                            <div style="margin: 10px 0px 10px 20px">
                                <img src="../../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex"
                                    style="border: 1px solid black" /></div>
                        </td>
                        <td valign="top">
                            <div style="float: right; padding: 10px 10px 0 0">
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" AlternateText="Cancel"
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
                                Search Result</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0px" cellspacing="0px">
                                <tr>
                                    <td style="width: 20%">
                                        <asp:Label runat="server" Text="Search:" ID="lSearchList"></asp:Label>
                                    </td>
                                    <td style="width: 20%">
                                        <asp:TextBox ID="txtSearchList" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Search" CausesValidation="false"
                                            OnClick="btnSearchlist_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:GridView ID="Gdvlookup" runat="server" AllowPaging="True" PageSize="5" OnRowCommand="Gdvlookup_RowCommand"
                                EmptyDataText="No  Result match your search criteria." OnSelectedIndexChanged="Gdvlookup_SelectedIndexChanged"
                                OnPageIndexChanging="Gdvlookup_PageIndexChanging" ShowHeaderWhenEmpty="True"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                            </center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                            <asp:GridView ID="gridMaster" Visible="false" runat="server" AllowPaging="True" PageSize="5"
                                Width="100%" EmptyDataText="No Result match your search criteria." ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False" DataKeyNames="VoucherNo" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"
                                CssClass="GridViewStyle" OnPageIndexChanging="gridMaster_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="VoucherNo" HeaderText="Voucher No" />
                                    <asp:BoundField DataField="GLCode" HeaderText="Bank GL Code" />
                                    <asp:BoundField DataField="GlSubCode" HeaderText="Sub Ledger Code" />
                                </Columns>
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1"
            PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="True"
            PopupDragHandleControlID="Panel3" CancelControlID="ImageButton2" DynamicServicePath=""
            Enabled="True" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:HiddenField ID="HidPopUpType" runat="server" />
    </asp:Panel>
</asp:Content>
