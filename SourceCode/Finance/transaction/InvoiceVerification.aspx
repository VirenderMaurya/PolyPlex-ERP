<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="InvoiceVerification.aspx.cs" Inherits="Finance_transaction_InvoiceVerification" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CSS/grid.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/popupstyle.css" rel="stylesheet" type="text/css" />
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
                    <td align="right" width="6%">
                        Series
                    </td>
                    <td align="left" width="8%">
                        <asp:DropDownList ID="DdlVoucherSeries" runat="server" Width="100px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" width="8%">
                        Voucher Year
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtVoucherYear" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    </td>
                    <td align="right" width="8%">
                        Voucher No#
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtVoucherNo" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    </td>
                    <td align="right" width="12%">
                        IV Type
                    </td>
                    <td align="left" width="8%">
                        <asp:DropDownList ID="DdlIVType" runat="server" Width="100px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="right" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="right" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
                <tr>
                    <td align="right" width="6%">
                        Voucher Date<font color="red">*</font>
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtVoucherDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalexVoucherdate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                            PopupButtonID="Imgvoucherdate" TargetControlID="TxtVoucherDate">
                        </asp:CalendarExtender>
                        <asp:ImageButton ID="Imgvoucherdate" runat="server" ImageUrl="~/Images/cal.gif" />
                    </td>
                    <td align="right" width="8%">
                        GR#<font color="red">*</font>
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtGR" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <asp:ImageButton ID="ImgBtnGR" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                            OnClick="ImgBtnGR_Click" />
                    </td>
                    <td align="right" width="8%">
                        P.O<font color="red">*</font>
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtPO" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <asp:ImageButton ID="ImgBtnPO" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                            OnClick="ImgBtnPO_Click" />
                    </td>
                    <td align="right" width="12%">
                        PO Value in LC
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtPOinLC" runat="server" BackColor="#CCFFFF" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="right" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="right" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="right" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
                <tr>
                    <td align="right" width="6%">
                        Vendor<font color="red">*</font>
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtVendor" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <asp:ImageButton ID="ImgBtnVendor" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                            OnClick="ImgBtnCode_Click" />
                    </td>
                    <td align="right" width="8%">
                        Tax Invoice
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtTaxInvoice" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td align="right" width="8%">
                        Tax Invoice Date
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtTaxInvoiceDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <asp:CalendarExtender ID="Calexinvoicedate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                            PopupButtonID="Imgcalinvoicedate" TargetControlID="TxtTaxInvoiceDate">
                        </asp:CalendarExtender>
                        <asp:ImageButton ID="Imgcalinvoicedate" runat="server" ImageUrl="~/Images/cal.gif" />
                    </td>
                    <td align="right" width="12%">
                        PO FX Value already Credited
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtPOFXalreadycreated" runat="server" BackColor="#CCFFFF" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
                <tr>
                    <td align="right" width="6%">
                        Due Date
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtDueDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                        <asp:CalendarExtender ID="Calextduedate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                            PopupButtonID="ImgDuedate" TargetControlID="TxtDueDate">
                        </asp:CalendarExtender>
                        <asp:ImageButton ID="ImgDuedate" runat="server" ImageUrl="~/Images/cal.gif" />
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="right" width="12%">
                        Payment Terms in PO
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtPaymentTermsinPO" runat="server" BackColor="#CCFFFF" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="right" width="12%">
                        Exchange Rate in PO
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtExRateinPO" runat="server" BackColor="#CCFFFF" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="right" width="12%">
                        Fx value in PO
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtFXValueinPO" runat="server" BackColor="#CCFFFF" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
                <tr>
                    <td align="right" width="6%">
                        Vat
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtVat" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fltrvat" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="TxtVat" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="right" width="8%">
                        Adj.Value
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtAdjValue" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fltradjvalut" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="TxtAdjValue" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="right" width="8%">
                        Vat Adj.
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtAdjVat" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="flteradjvat" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="TxtAdjVat" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left" width="12%">
                        Imp.Duty
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtImpDuty" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="flterimpduty" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="TxtImpDuty" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
                <tr>
                    <td align="right" width="6%">
                        Fx.Value
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtFxValue" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fltrfxvalue" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="TxtFxValue" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="right" width="8%">
                        Currency
                    </td>
                    <td align="left" width="8%">
                        <asp:DropDownList ID="DdlCurrency" runat="server" Width="90px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" width="8%">
                        Exchange Rate
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtExchangeRate" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="flterexrate" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="TxtExchangeRate" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left" width="12%">
                        Value in LC
                    </td>
                    <td align="left" width="8%">
                        <asp:TextBox ID="TxtValueinLC" runat="server" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fltrvalueinlc" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="TxtValueinLC" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="6%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="8%">
                        <asp:ImageButton ID="Btnsave" ImageUrl="~/Images/btnSave.png" runat="server" CausesValidation="true"
                            Font-Bold="True" ValidationGroup="1" OnClick="Btnsave_Click" Text="Save" />
                    </td>
                    <td align="left" width="8%">
                        <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png"
                            OnClientClick="window.close()" Text="Cancel" Style="font-weight: bold" />
                    </td>
                    <td align="left" width="8%">
                    </td>
                    <td align="left" width="12%">
                    </td>
                    <td align="left" width="8%">
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <div>
                <asp:RequiredFieldValidator ID="RFVvoucherdate" runat="server" ErrorMessage="Please enter voucher date."
                    Display="None" ControlToValidate="TxtVoucherDate" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                        ID="VCLvoucherdate" runat="server" Enabled="True" CssClass="customCalloutStyle"
                        TargetControlID="RFVvoucherdate">
                    </asp:ValidatorCalloutExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Vendor."
                    Display="None" ControlToValidate="TxtVendor" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                        ID="ValidatorCalloutExtender1" runat="server" Enabled="True" CssClass="customCalloutStyle"
                        TargetControlID="RequiredFieldValidator1">
                    </asp:ValidatorCalloutExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select GR."
                    Display="None" ControlToValidate="TxtGR" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                        ID="ValidatorCalloutExtender2" runat="server" Enabled="True" CssClass="customCalloutStyle"
                        TargetControlID="RequiredFieldValidator2">
                    </asp:ValidatorCalloutExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select PO value."
                    Display="None" ControlToValidate="TxtPO" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                        ID="ValidatorCalloutExtender3" runat="server" Enabled="True" CssClass="customCalloutStyle"
                        TargetControlID="RequiredFieldValidator3">
                    </asp:ValidatorCalloutExtender>
            </div>
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
                                <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
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
                            <asp:GridView ID="GdvVendorList" runat="server" AllowPaging="True" PageSize="1" Visible="False"
                                AutoGenerateColumns="False" DataKeyNames="FIVendorCode" EmptyDataText="No  Result match your search criteria."
                                OnSelectedIndexChanged="gridVendorlist_SelectedIndexChanged" OnPageIndexChanging="GdvVendorList_PageIndexChanging"
                                ShowHeaderWhenEmpty="True" Width="100%">
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvendorcode" runat="server" Text='<%#Eval("FIVendorCode") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvendorname" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcity" runat="server" Text='<%#Eval("City") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                            <asp:GridView ID="GdvPONO" Width="100%" AllowPaging="true" PageSize="5" runat="server"
                                EmptyDataText="No  Result match your search criteria." DataKeyNames="PO Number"
                                ShowHeaderWhenEmpty="true" Visible="false" OnPageIndexChanging="GdvPONO_PageIndexChanging"
                                OnSelectedIndexChanged="GdvPONO_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                            <asp:GridView ID="GdvGR" Width="100%" AllowPaging="true" PageSize="5" runat="server"
                                EmptyDataText="No  Result match your search criteria." DataKeyNames="Gr.No" ShowHeaderWhenEmpty="true"
                                Visible="false" OnPageIndexChanging="GdvGR_PageIndexChanging" OnSelectedIndexChanged="GdvGR_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
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
                                    <asp:BoundField DataField="GR" HeaderText="GR" />
                                    <asp:BoundField DataField="PO" HeaderText="PO" />
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
    </asp:Panel>
</asp:Content>
