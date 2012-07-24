<%@ Page Title="Payment to Vendor" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="Vendorpayment.aspx.cs" Inherits="Finance_transaction_Vendorpayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function Digitonly() 
        {
            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 8) || (event.keyCode == 190))
                return true;
            else
                return false;
        }
<link rel="stylesheet" type="text/css" href="../../CSS/tabcontiner.css" />

    </script>
    <link rel="stylesheet" type="text/css" href="../../CSS/grid.css" />
    <link rel="stylesheet" href="../../CSS/popupstyle.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <asp:UpdatePanel ID="updt" runat="server">
        <ContentTemplate>
            <asp:ToolkitScriptManager ID="tlscriptmanager" runat="server">
            </asp:ToolkitScriptManager>
            <table cellpadding="2" cellspacing="2" width="100%" border="0">
                <tr>
                    <td>
                        <asp:Panel ID="Pnlmain" runat="server" BorderWidth="1" BorderColor="#999999">
                            <table width="100%" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="lblType" runat="server" Text="Voucher Type"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:DropDownList ID="DdlVoucherType" runat="server" Width="90px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Reqvouchertype" SetFocusOnError="true" Display="None"
                                            runat="server" ControlToValidate="DdlVoucherType" ErrorMessage="Please select voucher type"
                                            InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="valcalloutvouchertype" runat="server" CssClass="customCalloutStyle"
                                            Enabled="True" TargetControlID="Reqvouchertype">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="lblOrder" runat="server" Text="Series"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:DropDownList ID="DdlVoucherSeries" runat="server" Width="90px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="lblDate" runat="server" Text="Year"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtYear" runat="server" Width="80px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Voucher No"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtVoucherNo" runat="server" Width="80px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="reqvoucherno" runat="server" ControlToValidate="TxtVoucherNo" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label2" runat="server" Text="Voucher Date"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtVoucherDate" runat="server" Width="80px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                        <asp:ImageButton ID="Imgtodatevoucherdate" runat="server" ImageUrl="~/Images/cal.gif" />
                                        <asp:CalendarExtender ID="CalVoucherDate" PopupButtonID="Imgtodatevoucherdate" runat="server"
                                            Format="dd/MM/yyyy" TargetControlID="TxtVoucherDate">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label3" runat="server" Text="Bank Acount No"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtBankAcountNo" runat="server" Width="80px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="req1" runat="server" SetFocusOnError="true" Display="None"
                                            ControlToValidate="TxtBankAcountNo" ErrorMessage="Please select bank account"
                                            ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender Width="50px" PopupPosition="TopRight" CssClass="customCalloutStyle"
                                            ID="Valcalloutbankacountno" runat="server" Enabled="True" TargetControlID="req1">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="lblConsignee" runat="server" Text="Vendor"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtVendorCode" runat="server" Width="80px" BackColor="Silver"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="req2" runat="server" ForeColor="Red" SetFocusOnError="true"
                                            Display="None" ErrorMessage="Please select vendor code" ControlToValidate="TxtVendorCode"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender CssClass="customCalloutStyle" ID="valcalloutvendorcode"
                                            runat="server" Enabled="True" TargetControlID="req2">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:ImageButton ID="ImgBtnCode" runat="server" ImageUrl="~/images/select.gif" OnClick="ImgBtnCode_Click"
                                            CausesValidation="False" />
                                        <%-- <asp:Panel id="PnlVendorlist" runat="server" style="display:none;" >
                                  
                                   </asp:Panel>--%>
                                        <asp:Panel ID="Panel1" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
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
                                                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
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
                                                            <table width="100%" cellpadding="0px" cellspacing="0px">
                                                                <tr>
                                                                    <td style="width: 20%">
                                                                        <asp:Label runat="server" Text="Search:" ID="lSearchList"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 20%">
                                                                        <asp:TextBox ID="txtSearchList" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Submit" CausesValidation="false"
                                                                            OnClick="btnSearchlist_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="pnl_div" runat="server" Height="220px" Width="605px" ScrollBars="Auto">
                                                            <br />
                                                                <asp:GridView ID="gridMaster" Visible="false" runat="server" AllowPaging="True" PageSize="5"
                                                                    Width="100%" EmptyDataText="No Result match your search criteria." ShowHeaderWhenEmpty="True"
                                                                    OnSelectedIndexChanged="gridMaster_SelectedIndexChanged" OnPageIndexChanging="gridMaster_PageIndexChanging"
                                                                    AutoGenerateColumns="False" DataKeyNames="InvoiceNo" CssClass="GridViewStyle">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Select">
                                                                            <ItemTemplate>
                                                                                <center>
                                                                                    <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Select"
                                                                                        ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                                                        <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" />
                                                                    </Columns>
                                                                    <RowStyle CssClass="RowStyle" />
                                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                                    <PagerStyle CssClass="PagerStyle" />
                                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                                </asp:GridView>
                                                                <asp:GridView ID="GdvVendorList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    DataKeyNames="FIVendorCode" EmptyDataText="No  Result match your search criteria."
                                                                    OnPageIndexChanging="GdvVendorList_PageIndexChanging" OnSelectedIndexChanged="GdvVendorList_SelectedIndexChanged"
                                                                    PageSize="1" ShowHeaderWhenEmpty="True" Width="100%">
                                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Select">
                                                                            <ItemTemplate>
                                                                                <center>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                                        ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                                                                </center>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Vendor Code">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblvendorcode" runat="server" Text='<%#Eval("FIVendorCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Vendor Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblvendorname" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="City">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblvendorcity" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                                    <PagerStyle CssClass="PagerStyle" />
                                                                    <RowStyle CssClass="RowStyle" />
                                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label5" runat="server" Text="Cheque No"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtChequeNo" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label4" runat="server" Text="Cheque Date"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtChequeDate" runat="server" Width="80px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                        <asp:ImageButton ID="Imgbtnchequedate" runat="server" ImageUrl="~/Images/cal.gif" />
                                        <asp:CalendarExtender ID="CalChequeDate" runat="server" PopupButtonID="Imgbtnchequedate"
                                            TargetControlID="TxtChequeDate" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="Label6" runat="server" Text="Currency"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <%--<asp:TextBox ID="TxtCurrency" runat="server" Width="140px"></asp:TextBox>--%>
                                        <asp:DropDownList ID="DdlCurency" runat="server" Width="90px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label7" runat="server" Text="Exchange Rate"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtExchangeRate" runat="server" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="Filterextender" TargetControlID="TxtExchangeRate"
                                            runat="server" FilterType="Custom, Numbers" Enabled="True" ValidChars=".">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 15%" align="right">
                                    </td>
                                    <td style="width: 15%" align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="Label9" runat="server" Text="Local Bank Charges"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtLocalBankCharges" runat="server" Width="80px" onkeydown="return Digitonly();"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="TxtLocalBankCharges"
                                            runat="server" FilterType="Custom, Numbers" Enabled="True" ValidChars=".">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label10" runat="server" Text="Foreign Bank Charges(FX)"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtForeignBankCharges" runat="server" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="TxtForeignBankCharges"
                                            runat="server" FilterType="Custom, Numbers" Enabled="True" ValidChars=".">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label11" runat="server" Text="Foreign Bank Charges in LC"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtForeignBankChargesInLC" runat="server" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="TxtForeignBankChargesInLC"
                                            runat="server" FilterType="Custom, Numbers" Enabled="True" ValidChars=".">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="Label12" runat="server" Text="Fx+-"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtFx" runat="server" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="TxtFx"
                                            runat="server" FilterType="Custom, Numbers" Enabled="True" ValidChars=".">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label15" runat="server" Text="Adj+-"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtAdj" runat="server" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="TxtAdj"
                                            runat="server" FilterType="Custom, Numbers" Enabled="True" ValidChars=".">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 15%" align="right">
                                    </td>
                                    <td style="width: 15%" align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="6">
                                        <asp:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="1">
                                            <asp:TabPanel ID="TabPanel" runat="server" CssClass="tabControl">
                                                <HeaderTemplate>
                                                    Invoices Due For Payment</HeaderTemplate>
                                                <ContentTemplate>
                                                    <asp:Panel ID="PnlGrid" runat="server">
                                                        <div style="overflow: scroll;">
                                                            <asp:GridView ID="GdvVendorInvoice" CssClass="GridViewStyle" runat="server" AllowSorting="True" PageSize="5"
                                                                AllowPaging="True" Width="100%" AutoGenerateColumns="False" OnPageIndexChanging="GdvVendorInvoice_PageIndexChanging">
                                                                <RowStyle CssClass="RowStyle" />
                                                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                                <PagerStyle CssClass="PagerStyle" />
                                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                <HeaderStyle CssClass="HeaderStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="RbtnSelect" runat="server" Visible="false" AutoPostBack="true"
                                                                                OnCheckedChanged="RbtnSelect_CheckedChanged" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo") %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="InvoiceDate" DataFormatString="{0:d}" HeaderText="Invoice Date">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AmountDueFx" HeaderText="Amount Due(Fx)">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Currency" HeaderText="Currency">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ExchangeRate" HeaderText="Exchange Rate">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AmountDueLC" HeaderText="Amount Due(LC)">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:d}">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid(Fx)">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DebitAdjFx" HeaderText="Debit Adj(Fx)">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AmountPaidLC" HeaderText="Amount Paid(LC)">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DebitAdjLC" HeaderText="Debit Adj(LC)">
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            Select</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBxSelect" CausesValidation="false" ImageUrl="~/Images/chkbxuncheck.png"
                                                                                runat="server" AutoPostBack="true" OnCheckedChanged="CheckBxSelect_CheckedChanged" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            WHT</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBxWHT" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBxWHT_CheckedChanged" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel1" runat="server" CssClass="tabControl">
                                                <HeaderTemplate>WHT</HeaderTemplate>
                                                <ContentTemplate>
                                                    <asp:Panel ID="Pnl" runat="server">
                                                        <br />
                                                         <table width="75%" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="20%">Vendor code </td>
                                                                <td width="25%">
                                                                    <asp:TextBox ID="Txt_TabPanel1_VendorCode" BackColor="Silver" runat="server" 
                                                                        ReadOnly="True" Width="80px"></asp:TextBox>
                                     <asp:ImageButton ID="ImgVendor" runat="server" ImageUrl="~/images/select.gif" OnClick="ImgBtnCode_Click"
                                                                     CausesValidation="False" />
                                                                    <asp:RequiredFieldValidator ID="req" runat="server" Display="None" ValidationGroup="wht" 
                                                                    ErrorMessage="Please select Vendor Code"
                                                                        ControlToValidate="Txt_TabPanel1_VendorCode"></asp:RequiredFieldValidator>
                                                  <asp:ValidatorCalloutExtender ID="valvendorcode" runat="server" CssClass="customCalloutStyle" 
                                                                        Enabled="True" TargetControlID="req">
                                                  </asp:ValidatorCalloutExtender>
                                                                    <asp:TextBox ID="Txt_TabPanel1_VendorName" BackColor="Silver" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">Base Amount</td>
                                                                <td width="25%">
                                                                    <asp:TextBox ID="TxtBaseAmount" runat="server"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="fltr" TargetControlID="TxtBaseAmount" runat="server"
                                                                        FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                                                                    </asp:FilteredTextBoxExtender>
                                                                </td>
                                                                <td width="10%">
                                                                    WHT Type
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="DdlWHTType" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">
                                                                    WHT Group
                                                                </td>
                                                                <td width="25%">
                                                                    <asp:TextBox ID="TxtWHTGroup" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                    WHT Rate
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="TxtWHTRate" runat="server"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="filtertxt" TargetControlID="TxtWHTRate" runat="server"
                                                                        FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                                                                    </asp:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">
                                                                    WHT Amount
                                                                </td>
                                                                <td width="25%">
                                                                    <asp:TextBox ID="Txt_TabPanel1_WHTAmount" runat="server"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="Filteredebitamount" TargetControlID="Txt_TabPanel1_WHTAmount"
                                                                        runat="server" FilterType="Custom, Numbers" Enabled="True" ValidChars=".">
                                                                    </asp:FilteredTextBoxExtender>
                                                                </td>
                                                                <td width="10%">
                                                                    &nbsp;</td>
                                                                <td width="20%">
                                                                    &nbsp;</td>
                                                            </tr>
                                                             <tr>
                                                                 <td width="20%">
                                                                     &nbsp;</td>
                                                                 <td width="25%">
                                                                     &nbsp;</td>
                                                                 <td width="10%">
                                                                     &nbsp;</td>
                                                                 <td width="20%">
                                                                     &nbsp;</td>
                                                             </tr>
                                                            <tr>
                                                                <td width="20%">
                                                                </td>
                                                                <td width="25%">
                                                        <asp:ImageButton ID="BtnAddLine" runat="server" CssClass="Button" ImageUrl="~/Images/btnAddLinegreen.png" OnClick="BtnAddLine_Click" Text="Save" 
                                                         ValidationGroup="wht" />
                                                         
<asp:ImageButton ID="ImgCancelwht" runat="server" ImageUrl="~/Images/btnCancel.png"
                          Text="Cancel" Style="font-weight: bold" CausesValidation="False" onclick="ImgCancelwht_Click" />
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div style="overflow: scroll;">
                                                                        <asp:GridView ID="GdvWHT" runat="server" AllowSorting="True" CssClass="GridViewStyle"
                                                                            CellPadding="3" PageSize="3" OnRowCommand="GdvWHTDetails_RowCommand" AllowPaging="True" Width="100%" AutoGenerateColumns="False">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="WHTLineNo" HeaderText="WHT Line No" Visible="False"/>
                                                                              
                                                                                <asp:BoundField DataField="VCode" HeaderText="VCode"/>
                                                                                
                                                                                <asp:TemplateField HeaderText="WHT Group">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblWHTGroup" runat="server" Text='<%#Eval("WHTGRP") %>'></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Type Of Payment">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblTypeofPayment" runat="server" Text='<%#Eval("TypeOfPayment") %>'></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Base Amount">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblBamt" runat="server" Text='<%#Eval("BAmt") %>'></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="WHT Rate">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblWhtrate" runat="server" Text='<%#Eval("WhtRate") %>'></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="WHT Amount">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblWHTAmount" runat="server" Text='<%#Eval("WHTAmount") %>'></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="WHTAmount" HeaderText="WHTAmount"/>
                                                                                 <asp:TemplateField>
                                                                                 <ItemTemplate>
                                                              <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("WHTLineNo") %>'
                                                                CommandName="del" ImageUrl="~/Images/delete.gif" /></ItemTemplate>
                                                              </asp:TemplateField>
                                                                            </Columns>
                                                                            <RowStyle CssClass="RowStyle" />
                                                                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                                            <PagerStyle CssClass="PagerStyle" />
                                                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                            <HeaderStyle CssClass="HeaderStyle" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                    </td>
                                    <td style="width: 15%" align="left">
                                    </td>
                                    <td style="width: 15%" align="right">
                                    </td>
                                    <td style="width: 15%" align="left">
                                    </td>
                                    <td style="width: 15%" align="right">
                                    </td>
                                    <td style="width: 15%" align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="Label115" runat="server" Text="Credit Memo"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtCreditMemo" runat="server" Width="80px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" align="right">
                                        <asp:Label ID="Label23" runat="server" Text="Total Value"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtTotalValue" runat="server" Width="80px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="Label19" runat="server" Text="WHT Amount"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtWHTAmount" runat="server" Width="80px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="Label59" runat="server" Text="Total Bank"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:TextBox ID="TxtTotalBank" runat="server" Width="80px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" align="right">
                                    </td>
                                    <td style="width: 15%" align="left">
                                    </td>
                                    <td style="width: 15%" align="right">
                                    </td>
                                    <td style="width: 15%" align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                    <asp:HiddenField ID="HidPopUpType" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:ImageButton ID="btnSave" ImageUrl="~/Images/btnSave.png" runat="server" Text="Save"
                            CssClass="Button" OnClick="btnSave_Click" />
                        <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="90px" OnClick="btnCancel_Click" />--%>
                        <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png"
                            OnClientClick="window.close()" Text="Cancel" Style="font-weight: bold" />
                        <%--<asp:Button ID="btnExit" runat="server" Text="Exit" Width="90px" OnClick="btnExit_Click" />--%>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"
                PopupDragHandleControlID="Panel3" CancelControlID="ImageButton2" />
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
