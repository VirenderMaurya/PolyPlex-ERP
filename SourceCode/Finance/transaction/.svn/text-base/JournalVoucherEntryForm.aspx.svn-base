<%@ Page Title="Journal Voucher Entry Form" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="JournalVoucherEntryForm.aspx.cs" Inherits="Finance_transaction_JournalVoucherEntryForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../../CSS/popupstyle.css" type="text/css" />
    <link href="../../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="0" 
        Width="100%">
        <asp:TabPanel ID="TabPanelMain" runat="server" Width="100%" CssClass="tabControl">
            <HeaderTemplate>
                Main</HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel ID="updpanel" runat="server">
                    <ContentTemplate>
                        <table cellpadding="1px" cellspacing="1px" width="100%">
                            <tr>
                                <td align="right" colspan="1" width="13%">
                                </td>
                                <td width="8%">
                                </td>
                                <td align="right" width="15%">
                                </td>
                                <td width="8%">
                                </td>
                                <td align="right" width="4%">
                                </td>
                                <td width="6%">
                                </td>
                                <td align="right" width="15%">
                                </td>
                                <td width="12%">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="1" width="13%">
                                    Voucher Type
                                </td>
                                <td width="8%">
                                    <asp:DropDownList ID="DdlVoucherType" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" width="15%">
                                    Series
                                </td>
                                <td width="8%">
                                    <asp:DropDownList ID="DdlVoucherSeries" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" width="4%">
                                    Year
                                </td>
                                <td width="6%">
                                    <asp:TextBox ID="TxtYear" runat="server" BackColor="Silver" Width="100px"></asp:TextBox>
                                </td>
                                <td align="left" width="15%">
                                    Voucher Date
                                </td>
                                <td width="12%">
                                    <asp:TextBox ID="TxtVoucherDate" runat="server" Width="70px" BackColor="Silver"></asp:TextBox>
                                    <asp:ImageButton ID="imgBtnVoucherDate" runat="server" ImageUrl="~/Images/cal.gif" />
                                    <asp:RequiredFieldValidator ID="reqvoucherdate" runat="server" ControlToValidate="TxtVoucherDate"
                                        Display="None" SetFocusOnError="true" ErrorMessage="Please select voucher date"
                                        ForeColor="Red" ValidationGroup="voucherheader"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="valcalvoucherdate" runat="server" CssClass="customCalloutStyle" Enabled="True" TargetControlID="reqvoucherdate">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:CalendarExtender ID="CalVoucherDate" runat="server" PopupButtonID="imgBtnVoucherDate"
                                        Enabled="True" Format="MM/dd/yyyy" TargetControlID="TxtVoucherDate">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="1" width="13%">
                                </td>
                                <td width="8%">
                                </td>
                                <td align="right" width="15%">
                                </td>
                                <td width="8%">
                                </td>
                                <td align="right" width="4%">
                                </td>
                                <td width="6%">
                                </td>
                                <td align="right" width="15%">
                                </td>
                                <td width="12%">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="13%">
                                    Currency
                                </td>
                                <td width="8%">
                                    <asp:DropDownList ID="DdlCurrencyType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlCurrencyType_SelectedIndexChanged"
                                        Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" width="15%">
                                    Exchange Rate
                                </td>
                                <td width="8%">
                                    <asp:TextBox ID="TxtExchangeRate" runat="server" Width="100px"></asp:TextBox><asp:FilteredTextBoxExtender
                                        ID="Filterextender" runat="server" Enabled="True" FilterType="Custom, Numbers"
                                        TargetControlID="TxtExchangeRate" ValidChars=".">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                                <td width="4%" align="right">
                                    <asp:CheckBox ID="ChkBxMarkReversal" runat="server" TextAlign="Left" />
                                </td>
                                <td width="6%">
                                    Mark Reversal
                                </td>
                                <td width="15%" align="left">
                                    VoucherNo
                                </td>
                                <td width="12%">
                                    <asp:TextBox ID="TxtVoucherNo" runat="server" ReadOnly="True" Width="100px" BackColor="Silver"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="pddtpnl2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PnlDescription" runat="server" BorderColor="Black" Width="100%" BorderWidth="1px">
                            <asp:GridView ID="GdvDescription" runat="server" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="No Record found"
                                AutoGenerateColumns="False" Width="100%" OnRowCommand="GdvDescription_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Line#">
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
                                            <asp:Label ID="Lblslcode" runat="server" Text='<%#Eval("SLCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Debit Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbldebitamount" runat="server" Text='<%#Eval("Debit Amount") %>'>
                                            </asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblcreditamount" runat="server" Text='<%#Eval("Credit Amount") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Profit Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblprofitcenter" runat="server" Text='<%#Eval("Profit Center") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblcostcenter" runat="server" Text='<%#Eval("Cost center") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblasset" runat="server" Text='<%#Eval("Asset") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblfxamount" runat="server" Text='<%#Eval("FxAmount") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblchequeno" runat="server" Text='<%#Eval("ChequeNo") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblchequedate" runat="server" Text='<%#Eval("ChequeDate") %>'></asp:Label></ItemTemplate>
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
                                            <asp:Label ID="Lblnarration" runat="server" Text='<%#Eval("Narration") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="ImgDelete" runat="server" CommandName="del"
                                                CommandArgument='<%#Eval("Line#") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                            </asp:GridView>
                            <asp:GridView ID="GdvDescriptionEdit" runat="server" AutoGenerateColumns="False"
                                OnRowCommand="GdvDescriptionEdit_RowCommand" PageSize="3" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LblEdit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("LineNo") %>'
                                                CommandName="editform" Text="Edit"></asp:LinkButton></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Line#">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbllinenoedit" runat="server" Text='<%#Eval("LineNo") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="G.L Code">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblglcodeedit" runat="server" Text='<%#Eval("GlCode") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.L Code">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblslcodeedit" runat="server" Text='<%#Eval("GlSubCode") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Debit Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbldebitamountedit" runat="server" Text='<%#Eval("DebitAmount") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblcreditamountedit" runat="server" Text='<%#Eval("CreditAmount") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Profit Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblprofitcenteredit" runat="server" Text='<%#Eval("ProfitCenter") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblcostcenteredit" runat="server" Text='<%#Eval("CostCenter") %>'></asp:Label></ItemTemplate>
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
                                    Asset # <font color="red">*</font>
                                </td>
                                <td width="8%">
                                    <asp:TextBox ID="TxtAsset" runat="server" Width="100px"></asp:TextBox>
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
                                    <asp:DropDownList ID="DdlSubGLCode" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%">
                                </td>
                                <td width="8%">
                                    <asp:RequiredFieldValidator ID="Requiredasset" runat="server" ControlToValidate="TxtAsset"
                                        Display="None" ErrorMessage="Please enter asset" ForeColor="Red" SetFocusOnError="true"
                                        ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                        TargetControlID="Requiredasset">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td width="10%">
                                </td>
                                <td width="8%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlGLCode"
                                        Display="None" ErrorMessage="Please select general ledger code" ForeColor="Red"
                                        InitialValue="0" SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td width="10%">
                                </td>
                                <td width="8%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlCostCenter"
                                        Display="None" ErrorMessage="Please select cost center" ForeColor="Red" InitialValue="0"
                                        SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td width="10%">
                                </td>
                                <td width="8%">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlSubGLCode"
                                        Display="None" ErrorMessage="Please select sub code" ForeColor="Red" InitialValue="0"
                                        SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%">
                                    Employee Code
                                </td>
                                <td width="8%">
                                    <asp:TextBox ID="TxtEmpCode" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="TxtEmpCode_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="TxtEmpCode">
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
                                        SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" CssClass="customCalloutStyle" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator6">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td width="10%">
                                    Fx. Amount
                                </td>
                                <td width="8%">
                                    <asp:TextBox ID="TxtFxAmount" runat="server" Width="100px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="Filteredextender" runat="server" Enabled="True"
                                        FilterType="Custom, Numbers" TargetControlID="TxtFxAmount" ValidChars=".">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                                <td width="10%">
                                    Debit Amount
                                </td>
                                <td width="8%">
                                    <asp:TextBox ID="TxtDebitAmount" runat="server" Width="100px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="TxtDebitAmount_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtDebitAmount"
                                        ValidChars=".">
                                    </asp:FilteredTextBoxExtender>
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
                                    Credit Amount
                                </td>
                                <td width="8%">
                                    <asp:TextBox ID="TxtCreditAmount" runat="server" Width="100px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="TxtCreditAmount_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtCreditAmount"
                                        ValidChars=".">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                                <td width="10%">
                                    Cheque No
                                </td>
                                <td width="8%">
                                    <asp:TextBox ID="TxtChequeNo" runat="server" Width="100px"></asp:TextBox>
                                </td>
                                <td width="10%">
                                    Cheque Date
                                </td>
                                <td width="8%">
                                    <asp:TextBox ID="TxtChequeDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                                    <asp:ImageButton ID="ImageBtnChequeDate" runat="server" ImageUrl="~/Images/cal.gif" />
                                    <asp:CalendarExtender ID="TxtChequeDate_CalendarExtender" runat="server" Enabled="True"
                                        Format="MM/dd/yyyy" PopupButtonID="ImageBtnChequeDate" TargetControlID="TxtChequeDate">
                                    </asp:CalendarExtender>
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
                                    Project
                                </td>
                                <td width="8%">
                                    <asp:DropDownList ID="DdlProject" runat="server" Width="130px">
                                    </asp:DropDownList>
                                </td>
                                <td width="10%">
                                    Sub- Project
                                </td>
                                <td width="8%">
                                    <asp:DropDownList ID="DdlSubProject" runat="server" Width="130px">
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
                                    <asp:TextBox ID="TxtNarration" runat="server" Height="70px" MaxLength="250" TextMode="MultiLine"
                                        Width="700px"></asp:TextBox>
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
                                </td>
                                <td width="8%">
                                    Total Debit
                                </td>
                                <td width="10%">
                                    <asp:TextBox ID="TxtTotalDebit" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
                                </td>
                                <td width="8%">
                                    Total Credit
                                </td>
                                <td width="10%">
                                    <asp:TextBox ID="TxtTotalCredit" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
                                </td>
                                <td width="8%">
                                    &nbsp;
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
                                    <%--<asp:ImageButton ID="BtnSave" ImageUrl="~/Images/btnSave.png" runat="server" OnClick="BtnSave_Click"
                                        Text="Save" ValidationGroup="voucherheader" />--%>
                                </td>
                                <td width="10%">
                                    <asp:ImageButton ID="BtnAddLine" runat="server" ImageUrl="~/Images/btnAddLinegreen.png"
                                        OnClick="BtnAddLine_Click" Text="Add Line" ValidationGroup="addgroup"/>
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
                        <asp:BoundField DataField="TaxInvoiceDate" DataFormatString="{0:d}" HeaderText="Tax Invoice Date" />
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
                                <asp:ImageButton ID="ImgDelete" runat="server" CommandArgument='<%#Eval("VatLineNo") %>'
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
                            <asp:TextBox ID="TxtVendorCode" runat="server" Width="150px" BackColor="Silver"></asp:TextBox>
                            <asp:ImageButton
                                ID="ImageButton3" runat="server" ImageUrl="~/images/select.gif" OnClick="ImgBtnCode_Click"
                                CausesValidation="False" /><asp:RequiredFieldValidator ID="reqvendorcodevat" SetFocusOnError="True"
                                    Display="None" ErrorMessage="Please select vendor code" ForeColor="Red" runat="server"
                                    ControlToValidate="TxtVendorCode" ValidationGroup="vatdetails"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                        ID="valcaloutvendorcode" runat="server" CssClass="customCalloutStyle" Enabled="True" TargetControlID="reqvendorcodevat">
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
                                    ID="ValidatorCalloutExtender4" runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RequiredFieldValidator5">
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
                            Rate
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRate" runat="server" Width="80px"></asp:TextBox><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender8" TargetControlID="TxtRate" runat="server" FilterType="Custom, Numbers"
                                Enabled="True" ValidChars=".">
                            </asp:FilteredTextBoxExtender>
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
                                ID="FilteredTextBoxExtender9" TargetControlID="TxtTaxAmount" runat="server" FilterType="Custom, Numbers"
                                Enabled="True" ValidChars=".">
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
                                ID="Calextendtaxinvoicedate" runat="server" Format="MM/dd/yyyy" TargetControlID="TxtTaxInvoiceDate"
                                Enabled="True" PopupButtonID="Imgtaxinvoicedate">
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
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanelWHTDetails" runat="server" Width="100%" CssClass="tabControl">
            <HeaderTemplate>
                WHT Details</HeaderTemplate>
            <ContentTemplate>
                <asp:GridView ID="GdvWhtDetails" runat="server" PageSize="3" Width="100%" AutoGenerateColumns="False"
                    OnRowDataBound="GdvWhtDetails_RowDataBound" DataKeyNames="VendorCode,VendorName"
                    OnRowCommand="GdvWhtDetails_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkwhtlineno" runat="server" Text="Edit" CommandName="editrow"
                                    CommandArgument='<%#Eval("WHTLineNo") %>'></asp:LinkButton></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="WHTLineNo" HeaderText="WHT LineNo" />
                        <asp:BoundField DataField="WHTGroup" HeaderText="WHT Group" />
                        <asp:BoundField DataField="WhtType" HeaderText="Type Of Payment" />
                        <asp:BoundField DataField="WHTAmount" HeaderText="WHT Amount" />
                        <asp:BoundField DataField="WHTRate" HeaderText="WHT Rate" />
                        <asp:BoundField DataField="BaseAmount" HeaderText="Base Amount" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="ImgDelete" runat="server" CommandName="del"
                                    CommandArgument='<%#Eval("WHTLineNo") %>' /></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                </asp:GridView>
                <br />
                <table width="100%" id="tbljournalwhtdetails">
                    <tr>
                        <td width="25%">
                        </td>
                        <td align="right" width="15%">
                            Vendor Code<font color="red">*</font>
                        </td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="TxtVendorCode_WHTTab" runat="server" Width="150px" BackColor="Silver"></asp:TextBox><asp:ImageButton
                                ID="ImgBtnCode" runat="server" ImageUrl="~/images/select.gif" OnClick="ImgBtnCode_ClickWHT"
                                CausesValidation="False" /><asp:RequiredFieldValidator ID="reqvendorcode" ErrorMessage="Please select vendor code"
                                    Display="None" SetFocusOnError="True" ForeColor="Red" runat="server" ControlToValidate="TxtVendorCode_WHTTab"
                                    ValidationGroup="whtdetails"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                        ID="valcaloutvendorcodewhttab" CssClass="customCalloutStyle" runat="server" Enabled="True" TargetControlID="reqvendorcode">
                                    </asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="TxtVendorCode_WHTTab"
                                runat="server" FilterType="Numbers" Enabled="True">
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
                            Vendor Name<font color="red">*</font>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="TxtVenderName_WHTTab" runat="server" Width="250px" BackColor="Silver"></asp:TextBox><asp:RequiredFieldValidator
                                ID="reqvendorname" ForeColor="Red" Display="None" SetFocusOnError="True" ErrorMessage="Please select vendor name"
                                runat="server" ControlToValidate="TxtVenderName_WHTTab" ValidationGroup="whtdetails"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                    ID="ValidatorCalloutExtender1" runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="reqvendorname">
                                </asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="TxtVenderName_WHTTab"
                                runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" "
                                Enabled="True">
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
                            <asp:TextBox ID="TxtBaseAmount_WHTTab" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender3" TargetControlID="TxtBaseAmount_WHTTab" runat="server"
                                FilterType="Custom, Numbers" ValidChars="." Enabled="True">
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
                            WHT Group
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="TxtWHTGroup" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender4" TargetControlID="TxtWHTGroup" runat="server" FilterType="Numbers"
                                Enabled="True">
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
                            WHT Type
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="DdlWhtType" runat="server">
                            </asp:DropDownList>
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
                            WHT Rate
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="TxtWhtrate" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender5" TargetControlID="TxtWhtrate" runat="server" FilterType="Custom, Numbers"
                                ValidChars="." Enabled="True">
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
                            WHT Amount
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="TxtWhtAmount" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender6" TargetControlID="TxtWhtAmount" runat="server" FilterType="Custom, Numbers"
                                ValidChars="." Enabled="True">
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
                            <asp:ImageButton ID="BtnAddWhtDetails" ImageUrl="~/Images/btnAddLinegreen.png" runat="server"
                                Text="Add Line" ValidationGroup="whtdetails" OnClick="BtnAddWhtDetails_Click" />
                        </td>
                        <td width="8%">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanelTravelDetails" runat="server" Width="100%" CssClass="tabControl">
            <HeaderTemplate>
                Travel Details</HeaderTemplate>
            <ContentTemplate>
                <asp:GridView ID="GdvTravelDetails" runat="server" PageSize="5" Width="100%" AutoGenerateColumns="False"
                    OnRowCommand="GdvTravelDetails_RowCommand" OnRowDataBound="GdvTravelDetails_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnktravellineno" runat="server" Text="Edit" CommandName="editrow"
                                    CommandArgument='<%#Eval("TravelLineNo") %>'>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TravelLineNo" HeaderText="Travel LineNo" />
                        <asp:BoundField DataField="EmpCode" HeaderText="Employee Code" />
                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                        <asp:BoundField DataField="CountryClass" HeaderText="Country Class" />
                        <asp:BoundField DataField="NoOfDays" HeaderText="No Of Days" />
                        <asp:BoundField DataField="DA" HeaderText="D.A" />
                        <asp:BoundField DataField="FromDate" DataFormatString="{0:d}" HeaderText="From Date" />
                        <asp:BoundField DataField="ToDate" DataFormatString="{0:d}" HeaderText="To Date" />
                        <asp:BoundField DataField="OtherCost" HeaderText="Other Cost" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="ImgDelete" runat="server" CommandName="del"
                                    CommandArgument='<%#Eval("TravelLineNo") %>' /></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                </asp:GridView>
                <br />
                <table width="100%" id="tbljournaltravaldetails">
                    <tr>
                        <td width="25%">
                        </td>
                        <td align="right" width="15%">
                            Employee Code<font color="red">*</font>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="TxtEmpCode_travaldetailstab" runat="server" Width="150px" BackColor="Silver"></asp:TextBox>
                              <asp:ImageButton ID="ImgEmployee" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                                OnClick="ImgBtnApprovedBy_Click" />
                            <asp:RequiredFieldValidator
                                ID="reqtraveldetails" ForeColor="Red" ErrorMessage="Please select employee code"
                                SetFocusOnError="True" Display="None" runat="server" ControlToValidate="TxtEmpCode_travaldetailstab"
                                ValidationGroup="traveldetails"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                    ID="ValidatorCalloutExtender2" CssClass="customCalloutStyle" runat="server" Enabled="True" TargetControlID="reqtraveldetails">
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
                            Employee Name<font color="red">*</font>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="TxtEmployeeName" runat="server" Width="250px" BackColor="Silver"></asp:TextBox><asp:RequiredFieldValidator
                                ID="reqemployee" Display="None" SetFocusOnError="True" ForeColor="Red" ErrorMessage="Please select employee name"
                                runat="server" ControlToValidate="TxtEmployeeName" ValidationGroup="traveldetails"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                    ID="ValidatorCalloutExtender3" CssClass="customCalloutStyle" runat="server" Enabled="True" TargetControlID="reqemployee">
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
                            Country Class
                        </td>
                        <td width="35%">
                            <asp:DropDownList ID="Ddlcountryclass" runat="server" Width="150px">
                            </asp:DropDownList>
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
                            No. Of Days
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="TxtNoOfDays" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender10" TargetControlID="TxtNoOfDays" runat="server" FilterType="Numbers"
                                Enabled="True">
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
                            From Date
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="Txtfromdate_travaldetails" BackColor="Silver" runat="server" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender
                                ID="CalendarExtender3" PopupButtonID="Imgbtnfromdatetraveldetails" runat="server"
                                Format="MM/dd/yyyy" TargetControlID="Txtfromdate_travaldetails" Enabled="True">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="Imgbtnfromdatetraveldetails" runat="server" ImageUrl="~/Images/cal.gif" />
                        </td>
                        <td width="8%">
                            To Date
                        </td>
                        <td>
                            <asp:TextBox ID="Txttodate_travaldetails" BackColor="Silver" runat="server" Width="100px"></asp:TextBox><asp:CalendarExtender
                                ID="CalendarExtender4" PopupButtonID="Imgtodatetraveldetails" runat="server"
                                Format="MM/dd/yyyy" TargetControlID="Txttodate_travaldetails" Enabled="True">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="Imgtodatetraveldetails" runat="server" ImageUrl="~/Images/cal.gif" />
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
                            D.A
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="TxtDA_traveldetails" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender11" TargetControlID="TxtDA_traveldetails" runat="server"
                                FilterType="Custom, Numbers" ValidChars="." Enabled="True">
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
                            Other Cost
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="TxtOtherCost_traveldetails" runat="server" Width="150px"></asp:TextBox><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender12" TargetControlID="TxtOtherCost_traveldetails" runat="server"
                                FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td width="8%">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <asp:UpdatePanel ID="updtnl" runat="server">
                            <ContentTemplate>
                                <td width="25%">
                                </td>
                                <td align="right" width="15%">
                                </td>
                                <td width="25%">
                                    <asp:ImageButton ImageUrl="~/Images/btnAddLinegreen.png" ID="BtnAddtraveldetails" runat="server" Text="Add Line" ValidationGroup="traveldetails" OnClick="BtnAddtraveldetails_Click" />
                                </td>
                                <td width="8%">
                                </td>
                                <td>
                                </td>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
      
    </asp:TabContainer>
      <asp:ImageButton ID="BtnSave" ImageUrl="~/Images/btnSave.png" runat="server" OnClick="BtnSave_Click"
                                        Text="Save" ValidationGroup="voucherheader" />
                                        <asp:HiddenField ID="HidPopUpType" runat="server" />
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
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GdvSearch" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                            PageSize="8" EmptyDataText="No  Result match your search criteria." ShowHeaderWhenEmpty="True"
                            OnPageIndexChanging="GdvSearch_PageIndexChanging" OnRowCommand="GdvSearch_RowCommand"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False" CommandArgument='<%#Eval("VoucherNo") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VoucherNo.">
                                    <ItemTemplate>
                                        <asp:Label ID="LblVoucherNo" runat="server" Text='<%#Eval("VoucherNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Voucher Type">
                                    <ItemTemplate>
                                        <asp:Label ID="LblVoucherType" runat="server" Text='<%#Eval("VoucherType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Voucher Series">
                                    <ItemTemplate>
                                        <asp:Label ID="LblVoucherSeries" runat="server" Text='<%#Eval("VoucherSeries") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Voucher Year">
                                    <ItemTemplate>
                                        <asp:Label ID="LblVoucherYear" runat="server" Text='<%#Eval("VoucherYear") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="Voucher Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblVoucherDate" runat="server" Text='<%#Eval("VoucherDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                <asp:BoundField DataField="VoucherDate" HeaderText="Voucher Date" DataFormatString="{0:d}" />
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                        </asp:GridView>
                        <asp:GridView ID="GdvVendorList" runat="server" AllowPaging="True" PageSize="1" Visible="false"
                            AutoGenerateColumns="false" DataKeyNames="FIVendorCode" EmptyDataText="No  Result match your search criteria."
                            OnSelectedIndexChanged="gridMaster_SelectedIndexChanged" OnPageIndexChanging="GdvVendorList_PageIndexChanging"
                            ShowHeaderWhenEmpty="True" Width="100%">
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
                                        <asp:Label ID="lblcity" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                        </asp:GridView>
                           <asp:GridView ID="Gdvlookup" runat="server" AllowPaging="True" PageSize="6" OnRowCommand="Gdvlookup_RowCommand"
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
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImageButton2" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>
