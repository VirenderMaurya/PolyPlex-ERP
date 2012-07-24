<%@ Page Title="Other Vendor Invoices" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="Otherpuchases.aspx.cs" Inherits="Finance_transaction_Otherpuchases" %>

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
        <table cellspacing="1" width="100%">
            <tr>
                <td align="left" width="10%">
                </td>
                <td align="left" width="10%">
                    Voucher Series
                </td>
                <td align="left" width="12%">
                    <asp:DropDownList ID="DdlVoucherSeries" runat="server" Width="90px">
                    </asp:DropDownList>
                </td>
                <td align="left" width="10%">
                    Year
                </td>
                <td align="left" width="7%">
                    <asp:TextBox ID="TxtYear" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                </td>
                <td align="left" width="8%">
                    Voucher No.
                </td>
                <td align="left" width="12%">
                    <asp:TextBox ID="TxtVoucherNo" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                </td>
                <td align="left" width="10%">
                    Vr.Date
                </td>
                <td align="left" width="12%">
                    <asp:TextBox ID="TxtVoucherDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    <asp:CalendarExtender ID="Calvoucherdate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                        PopupButtonID="ImgVDate" TargetControlID="TxtVoucherDate">
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="ImgVDate" runat="server" ImageUrl="~/Images/cal.gif" />
                </td>
            </tr>
            <tr>
                <td align="left" width="10%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="12%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="7%">
                </td>
                <td align="left" width="8%">
                </td>
                <td align="left" width="12%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="12%">
                </td>
            </tr>
            <tr>
                <td align="left" width="10%">
                </td>
                <td align="left" width="10%">
                    Vendor
                </td>
                <td align="left" width="12%">
                    <asp:TextBox ID="TxtVendor" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                        OnClick="ImgBtnCode_Click" />
                </td>
                <td align="left" width="10%">
                    Vendor Invoice No.
                </td>
                <td align="left" width="7%">
                    <asp:TextBox ID="TxtVendorInvoice" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td align="left" width="8%">
                    Invoice Date
                </td>
                <td align="left" width="12%">
                    <asp:TextBox ID="TxtInvoiceDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalInvoicedate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                        PopupButtonID="ImgIDate" TargetControlID="TxtInvoiceDate">
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="ImgIDate" runat="server" ImageUrl="~/Images/cal.gif" />
                </td>
                <td align="left" width="10%">
                    &nbsp;
                </td>
                <td align="left" width="12%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" width="10%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="12%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="7%">
                </td>
                <td align="left" width="8%">
                </td>
                <td align="left" width="12%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="12%">
                </td>
            </tr>
            <tr>
                <td align="left" width="10%">
                </td>
                <td align="left" width="10%">
                    Invoice/B/L Date
                </td>
                <td align="left" width="12%">
                    <asp:TextBox ID="TxtInvoiceBLDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalInvoiceBLDate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                        PopupButtonID="ImgBLDate" TargetControlID="TxtInvoiceBLDate">
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="ImgBLDate" runat="server" ImageUrl="~/Images/cal.gif" />
                </td>
                <td align="left" width="10%">
                    Credit Days
                </td>
                <td align="left" width="7%">
                    <asp:TextBox ID="TxtCreditDays" runat="server" Width="70px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                        FilterType="Numbers" TargetControlID="TxtCreditDays">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td align="left" width="8%">
                    Due Date
                </td>
                <td align="left" width="12%">
                    <asp:TextBox ID="TxtDueDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalDueDate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                        PopupButtonID="ImgDueDate" TargetControlID="TxtDueDate">
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="ImgDueDate" runat="server" ImageUrl="~/Images/cal.gif" />
                </td>
                <td align="left" width="10%">
                    Amount
                </td>
                <td align="left" width="12%">
                    <asp:TextBox ID="TxtAmount" runat="server" Width="70px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                        FilterType="Custom, Numbers" TargetControlID="TxtAmount" ValidChars=".">
                    </asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="left" width="10%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="12%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="7%">
                </td>
                <td align="left" width="8%">
                </td>
                <td align="left" width="12%">
                </td>
                <td align="left" width="10%">
                </td>
                <td align="left" width="12%">
                </td>
            </tr>
            <tr>
                <td align="left" width="10%">
                </td>
                <td align="left" width="10%">
                    Narration
                </td>
                <td align="left" colspan="8">
                    <asp:TextBox ID="TxtNarration" runat="server" Height="70px" MaxLength="250" TextMode="MultiLine"
                        Width="500px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlmain" runat="server">
        <table cellspacing="1" width="100%">
            <tr>
                <td align="left" width="10%" colspan="10">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnldetails" runat="server">
        <asp:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="0" Width="100%">
            <asp:TabPanel ID="TabPanelMain" runat="server" Width="100%" CssClass="tabControl">
                <HeaderTemplate>
                    Selection</HeaderTemplate>
                <ContentTemplate>
                    <asp:UpdatePanel ID="pddtpnl2" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="PnlDescription" runat="server" Width="100%">
                                <asp:GridView ID="GdvDescription" runat="server" ShowHeaderWhenEmpty="true" EmptyDataText="No Line Item Found"
                                    AutoGenerateColumns="False" Width="100%" OnRowCommand="GdvDescription_RowCommand"
                                    OnRowDataBound="GdvDescription_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDescriptionId" runat="server" Text="Edit" CommandName="editrow"
                                                    CommandArgument='<%#Eval("Line#") %>'></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LineNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbllineno" runat="server" Text='<%#Eval("Line#") %>'>
                                                </asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="G.L Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblglcode" runat="server" Text='<%#Eval("GLCode") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S.L Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblslcode" runat="server" Text='<%#Eval("SLCode") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Debit Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbldebitamount" runat="server" Text='<%#Eval("Debit Amount") %>'>
                                                </asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Profit Center" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblprofitcenter" runat="server" Text='<%#Eval("Profit Center") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cost Center" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblcostcenter" runat="server" Text='<%#Eval("Cost center") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblasset" runat="server" Text='<%#Eval("Asset") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblproject" runat="server" Text='<%#Eval("Project") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblsubproject" runat="server" Text='<%#Eval("SubProject") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblempcode" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblnarration" runat="server" Text='<%#Eval("VoucherDescr") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="ImgDelete" runat="server" CommandName="del"
                                                    CommandArgument='<%#Eval("Line#") %>' /></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="RowStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                </asp:GridView>
                            </asp:Panel>
                            <br />
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <caption>
                                </caption>
                                <tr>
                                    <td width="15%">
                                        Asset No. <font color="red">*</font>
                                    </td>
                                    <td width="8%">
                                        <asp:TextBox ID="TxtAsset" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td width="10%">
                                        G.LCode<font color="red">*</font>
                                    </td>
                                    <td width="8%">
                                        <asp:DropDownList ID="DdlGLCode" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10%">
                                        Cost Center<font color="red">*</font>
                                    </td>
                                    <td width="8%">
                                        <asp:DropDownList ID="DdlCostCenter" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10%">
                                        Sub-Code<font color="red">*</font>
                                    </td>
                                    <td width="8%">
                                        <asp:DropDownList ID="DdlSubGLCode" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">
                                    </td>
                                    <td width="8%">
                                        <asp:RequiredFieldValidator ID="Requiredasset" runat="server" ControlToValidate="TxtAsset"
                                            Display="None" ErrorMessage="Please enter asset" ForeColor="Red" SetFocusOnError="true"
                                            ValidationGroup="addgroup"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                ID="ValidatorCalloutExtender5" runat="server" CssClass="customCalloutStyle" Enabled="True"
                                                TargetControlID="Requiredasset">
                                            </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlGLCode"
                                            Display="None" ErrorMessage="Please select general ledger code" ForeColor="Red"
                                            InitialValue="0" SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                ID="ValidatorCalloutExtender6" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                                TargetControlID="RequiredFieldValidator1">
                                            </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlCostCenter"
                                            Display="None" ErrorMessage="Please select cost center" ForeColor="Red" InitialValue="0"
                                            SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                ID="ValidatorCalloutExtender7" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                                TargetControlID="RequiredFieldValidator2">
                                            </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlSubGLCode"
                                            Display="None" ErrorMessage="Please select sub code" ForeColor="Red" InitialValue="0"
                                            SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                ID="ValidatorCalloutExtender8" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                                TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">
                                        Employee Code
                                    </td>
                                    <td width="8%">
                                        <asp:TextBox ID="TxtEmpCode" runat="server" MaxLength="10" Width="80px"></asp:TextBox><asp:FilteredTextBoxExtender
                                            ID="TxtEmpCode_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"
                                            TargetControlID="TxtEmpCode">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td width="10%">
                                        Profit Center<font color="red">*</font>
                                    </td>
                                    <td width="8%">
                                        <asp:DropDownList ID="DdlProfitCenter" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DdlProfitCenter"
                                            Display="None" ErrorMessage="Please enter profit center" ForeColor="Red" InitialValue="0"
                                            SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                ID="ValidatorCalloutExtender9" runat="server" CssClass="customCalloutStyle" Enabled="True"
                                                TargetControlID="RequiredFieldValidator6">
                                            </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td width="10%">
                                        Debit Amount
                                    </td>
                                    <td width="8%">
                                        <asp:TextBox ID="TxtDebitAmount" runat="server" Width="80px"></asp:TextBox><asp:FilteredTextBoxExtender
                                            ID="TxtDebitAmount0_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers"
                                            TargetControlID="TxtDebitAmount" ValidChars=".">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td width="10%">
                                        &#160;&#160;
                                    </td>
                                    <td width="8%">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">
                                        Project
                                    </td>
                                    <td width="8%">
                                        <asp:DropDownList ID="DdlProject" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10%">
                                        Sub- Project
                                    </td>
                                    <td width="8%">
                                        <asp:DropDownList ID="DdlSubProject" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">
                                        Narration
                                    </td>
                                    <td colspan="7">
                                        <asp:TextBox ID="TxtDescriptionLineItem" runat="server" Height="70px" MaxLength="250"
                                            TextMode="MultiLine" Width="700px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                        <asp:ImageButton ID="BtnAddLine" ImageUrl="~/Images/btnAddLinegreen.png" runat="server"
                                            Font-Bold="True" OnClick="BtnAddLine_Click" Text="Add Line" ValidationGroup="addgroup" />
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="8%">
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanelVatDetails" runat="server" Width="100%" CssClass="tabControl">
                <HeaderTemplate>
                    VAT Details</HeaderTemplate>
                <ContentTemplate>
                    <br />
                    <asp:GridView ID="GdvVatDetails" runat="server" AutoGenerateColumns="False" PageSize="3"
                        Width="100%" OnRowDataBound="GdvVatDetails_RowDataBound" OnRowCommand="GdvVatDetails_RowCommand">
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkvatlineno" runat="server" Text="Edit" CommandName="editrow"
                                        CommandArgument='<%#Eval("VatLineNo") %>'></asp:LinkButton></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VatLineNo">
                                <ItemTemplate>
                                    <asp:Label ID="Lblvatlineno" runat="server" Text='<%#Eval("VatLineNo") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor Code">
                                <ItemTemplate>
                                    <asp:Label ID="LblVCode" runat="server" Text='<%#Eval("VendorCode") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Base Amount">
                                <ItemTemplate>
                                    <asp:Label ID="LblBAmt" runat="server" Text='<%#Eval("BaseAmount") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tax Amount">
                                <ItemTemplate>
                                    <asp:Label ID="LblVAmt" runat="server" Text='<%#Eval("VAmount") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tax Invoice">
                                <ItemTemplate>
                                    <asp:Label ID="LblTaxInv" runat="server" Text='<%#Eval("TaxInvoice") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TaxInvoiceDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Tax Invoice Date" />
                            <asp:TemplateField HeaderText="VendorName" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="Lblvendorname" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="Lblrate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgDelete" CausesValidation="false" runat="server" CommandArgument='<%#Eval("VatLineNo") %>'
                                        CommandName="del" ImageUrl="~/Images/delete.gif" /></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                    <br />
                    <table width="100%" id="tbljournalvatdetails">
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                                Vendor Code<font color="red">*</font>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="TxtVendorCode" runat="server" Width="150px" BackColor="Silver"></asp:TextBox><asp:ImageButton
                                    ID="ImageButton3" runat="server" ImageUrl="~/images/select.gif" OnClick="ImgBtnCode_Click"
                                    CausesValidation="False" /><asp:RequiredFieldValidator ID="reqvendorcodevat" SetFocusOnError="True"
                                        Display="None" ErrorMessage="Please select vendor code" ForeColor="Red" runat="server"
                                        ControlToValidate="TxtVendorCode" ValidationGroup="vatdetails"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="valcaloutvendorcode" runat="server" CssClass="customCalloutStyle" Enabled="True"
                                            TargetControlID="reqvendorcodevat">
                                        </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                            </td>
                            <td width="25%">
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                                Vendor Name<font color="red">*</font>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="TxtVendorName" runat="server" Width="250px" BackColor="Silver"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator5" SetFocusOnError="True" Display="None" ErrorMessage="Please enter vendor name"
                                    ForeColor="Red" runat="server" ControlToValidate="TxtVendorName" ValidationGroup="vatdetails"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                        ID="ValidatorCalloutExtender4" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                            </td>
                            <td width="35%">
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                                Base Amount
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="TxtBaseAmount" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                    ID="FilteredTextBoxExtender7" TargetControlID="TxtBaseAmount" runat="server"
                                    FilterType="Custom, Numbers" Enabled="True" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td width="8%">
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                            </td>
                            <td width="25%">
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                                Tax Amount
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="TxtTaxAmount" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                    ID="FilteredTextBoxExtender9" runat="server" Enabled="True" FilterType="Custom, Numbers"
                                    TargetControlID="TxtTaxAmount" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                            </td>
                            <td width="25%">
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                                Tax Invoice #
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="TxtTaxInvoice" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                            </td>
                            <td width="25%">
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                                Tax Invoice Date
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="TxtTaxInvoiceDate" runat="server" BackColor="Silver" Width="130px"></asp:TextBox><asp:CalendarExtender
                                    ID="Calextendtaxinvoicedate" runat="server" Enabled="True" Format="MM/dd/yyyy"
                                    PopupButtonID="Imgtaxinvoicedate" TargetControlID="TxtTaxInvoiceDate">
                                </asp:CalendarExtender>
                                <asp:ImageButton ID="Imgtaxinvoicedate" runat="server" ImageUrl="~/Images/cal.gif" />
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                            </td>
                            <td width="25%">
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                            </td>
                            <td align="right" width="15%">
                            </td>
                            <td width="25%">
                                <asp:ImageButton ID="BtnAdd_VatDetails" runat="server" Text="Add Line" ImageUrl="~/Images/btnAddLinegreen.png"
                                    ValidationGroup="vatdetails" OnClick="BtnAdd_VatDetails_Click" />
                            </td>
                            <td width="8%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
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
                            <table width="100%" cellpadding="0px" cellspacing="0px">
                                <tr>
                                    <td style="width: 20%">
                                        <asp:Label runat="server" Text="Search:" ID="labelsearchvendor"></asp:Label>
                                    </td>
                                    <td style="width: 20%">
                                        <asp:TextBox ID="txtSearchListvendor" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearchlistvendor" OnClick="btnSearchlistvendor_Click" runat="server"
                                            TabIndex="10" Text="Search" CausesValidation="false" />
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
                                OnSelectedIndexChanged="gridMaster_SelectedIndexChanged" OnPageIndexChanging="GdvVendorList_PageIndexChanging"
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
        <asp:ImageButton ID="BtnSave" ImageUrl="~/Images/btnSave.png" runat="server" Font-Bold="True"
            OnClick="BtnSave_Click" Text="Save" ValidationGroup="voucherheader" />
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Height="400px" Width="750px" CssClass="modalPopup"
        Style="display: none">
        <asp:Panel ID="Panel2" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex"
                                style="border: 1px solid black" /></div>
                    </td>
                    <td valign="top">
                        <div style="float: right; padding: 10px 10px 0 0">
                            <asp:ImageButton ID="ImgBtnCancel" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="margin-left: 20px; margin-right: 20px">
            <table width="100%" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>
                        <div class="in_menu_head">
                            Search List</div>
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
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" OnClick="btnSearchlist_Click"
                                        Text="Search" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:GridView ID="gvAllOtherPurchase" runat="server" AutoGenerateColumns="false"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="6" OnRowCommand="gvAllOtherPurchase_RowCommand"
                            OnPageIndexChanging="gvAllOtherPurchase_PageIndexChanging" OnRowDataBound="gvAllOtherPurchase_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("ID") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VoucherSeries" HeaderText="VoucherSeries">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Voucher_Year" HeaderText="Voucher Year">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VoucherNumber" HeaderText="Voucher Number">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VoucherDate" HeaderText="VoucherDate">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vendor" HeaderText="Vendor Code">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VendorName" HeaderText="Vendor Name">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VendorInvoice" HeaderText="VendorInvoice">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InvoiceDate" HeaderText="InvoiceDate">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InvoiceBLDate" HeaderText="InvoiceBLDate">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreditDays" HeaderText="CreditDays">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DueDate" HeaderText="DueDate">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Amount" HeaderText="Amount">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Description">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                        </asp:GridView>
                        <asp:Label ID="lblTotalRecords" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label15"
        PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel2" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label15" runat="server" Text=""></asp:Label>
    <asp:HiddenField ID="hidAutoIdHeader" runat="server" />
</asp:Content>
