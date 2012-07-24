<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="PostPreDefinedEntries.aspx.cs" Inherits="Finance_transaction_PostPreDefinedEntries" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CSS/grid.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../CSS/popupstyle.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="PnlPredefinedHistoryList" runat="server">
        <br />
        <table>
            <tr>
                <td align="left">
                    <asp:Label ID="Lblheading1" runat="server" Font-Bold="true" Text="Defined Entries"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="overflow: scroll;">
                        <asp:GridView ID="GdvPredefinedEntries" runat="server" AllowSorting="True" CssClass="GridViewStyle"
                            ShowHeaderWhenEmpty="true" EmptyDataText="No record found" Width="100%" AutoGenerateColumns="False"
                            OnPageIndexChanging="GdvPredefinedEntries_PageIndexChanging">
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkbxall" runat="server" AutoPostBack="true" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="checkbx" runat="server" AutoPostBack="true" OnCheckedChanged="chk_CheckChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EntryNo" HeaderText="Entry No" />
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="Planned" HeaderText="Planned" />
                                <asp:BoundField DataField="GLCode" HeaderText="G.L Code" />
                                <asp:BoundField DataField="SubGLCode" HeaderText="Sub G.L Code" />
                                <asp:BoundField DataField="ProfitCenter" HeaderText="Profit Center" />
                                <asp:BoundField DataField="CostCenter" HeaderText="Cost Center" />
                                <asp:BoundField DataField="DebitAmount" HeaderText="Debit Amount" />
                                <asp:BoundField DataField="CreditAmount" HeaderText="Credit Amount" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="PostedBy" HeaderText="Posted By" />
                                <asp:BoundField DataField="PostedOn" HeaderText="Posted On" DataFormatString="{0:d}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Lblheading2" runat="server" Font-Bold="true" Text="Selected Entries"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="overflow: scroll;">
                        <asp:GridView ID="GdvselectedEntries" runat="server" AllowSorting="True" CssClass="GridViewStyle"
                            PageSize="5" AllowPaging="True" Width="100%" AutoGenerateColumns="False" OnPageIndexChanging="GdvPredefinedEntries_PageIndexChanging">
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                                <asp:BoundField DataField="EntryNo" HeaderText="Entry No" />
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" />
                                <asp:BoundField DataField="Planned" HeaderText="Planned" />
                                <asp:BoundField DataField="GLCode" HeaderText="G.L Code" />
                                <asp:BoundField DataField="SubGLCode" HeaderText="Sub G.L Code" />
                                <asp:BoundField DataField="ProfitCenter" HeaderText="Profit Center" />
                                <asp:BoundField DataField="CostCenter" HeaderText="Cost Center" />
                                <asp:BoundField DataField="DebitAmount" HeaderText="Debit Amount" />
                                <asp:BoundField DataField="CreditAmount" HeaderText="Credit Amount" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="PostedBy" HeaderText="Posted By" />
                                <asp:BoundField DataField="PostedOn" HeaderText="Posted On" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="95%">
                        <tr>
                            <td width="8%">
                                Voucher Type<font color="red">*</font>
                            </td>
                            <td width="10%" align="left">
                                <asp:DropDownList ID="DdlVoucherType" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td width="8%" align="left">
                                Series<font color="red">*</font>
                            </td>
                            <td width="9%" align="left">
                                <asp:DropDownList ID="DdlVoucherSeries" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td width="7%" align="left">
                                Voucher Year
                            </td>
                            <td width="8%" align="left">
                                <asp:TextBox ID="TxtVoucherYear" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                            </td>
                            <td width="7%" align="left">
                                Voucher No#
                            </td>
                            <td width="7%" align="left">
                                <asp:TextBox ID="TxtVoucherNo" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                            </td>
                            <td width="8%" align="left">
                                Voucher Date<font color="red">*</font>
                            </td>
                            <td width="12%" align="left">
                                <asp:TextBox ID="TxtVoucherDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                                <asp:ImageButton ID="imgBtnVoucherDate" runat="server" ImageUrl="~/Images/cal.gif" />
                                <asp:CalendarExtender ID="CalVoucherDate" runat="server" PopupButtonID="imgBtnVoucherDate"
                                    Enabled="True" Format="MM/dd/yyyy" TargetControlID="TxtVoucherDate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="8%">
                                &nbsp;
                            </td>
                            <td width="10%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlVoucherType"
                                    Display="None" ErrorMessage="Please select voucher type" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" CssClass="customCalloutStyle"
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="8%">
                                &nbsp;
                            </td>
                            <td width="9%">
                                <asp:RequiredFieldValidator ID="Reqvoucherseries" runat="server" ControlToValidate="DdlVoucherSeries"
                                    Display="None" ErrorMessage="Please select voucher series" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" CssClass="customCalloutStyle"
                                    runat="server" Enabled="True" TargetControlID="Reqvoucherseries">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="7%">
                            </td>
                            <td width="8%">
                            </td>
                            <td width="7%">
                            </td>
                            <td width="7%">
                            </td>
                            <td width="8%">
                            </td>
                            <td width="12%">
                                <asp:RequiredFieldValidator ID="Reqvoucherdate" runat="server" ControlToValidate="TxtVoucherDate"
                                    Display="None" ErrorMessage="Please select voucher date" ForeColor="Red" SetFocusOnError="true"
                                    ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="Reqvoucherseries0_ValidatorCalloutExtender" CssClass="customCalloutStyle"
                                    runat="server" Enabled="True" TargetControlID="Reqvoucherdate">
                                </asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="8%">
                            </td>
                            <td width="10%">
                            </td>
                            <td width="8%">
                                <asp:ImageButton ID="Btnsave" runat="server" ImageUrl="~/Images/btnSave.png" OnClick="Btnsave_Click"
                                    Text="Save" ValidationGroup="btnsave" />
                            </td>
                            <td width="9%">
                                <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png"
                                    OnClientClick="window.close()" Text="Cancel" Style="font-weight: bold" />
                            </td>
                            <td width="7%">
                            </td>
                            <td width="8%">
                            </td>
                            <td width="7%">
                            </td>
                            <td width="7%">
                            </td>
                            <td width="8%">
                            </td>
                            <td width="12%">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
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
                            Post Pre-Defined Entries List</div>
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
                        <asp:GridView ID="gvAllPredefinedEntriesList" runat="server" AutoGenerateColumns="false"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="6" OnRowCommand="gvAllPredefinedEntriesList_RowCommand"
                            OnRowDataBound="gvAllPredefinedEntriesList_RowDataBound" OnPageIndexChanging="gvAllPredefinedEntriesList_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("ID") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EntryNo" HeaderText="Entry No" />
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy}" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy}" />
                                <asp:BoundField DataField="Planned" HeaderText="Planned" />
                                <asp:BoundField DataField="GLCode" HeaderText="G.L Code" />
                                <asp:BoundField DataField="SubGLCode" HeaderText="Sub G.L Code" />
                                <asp:BoundField DataField="ProfitCenter" HeaderText="Profit Center" />
                                <asp:BoundField DataField="CostCenter" HeaderText="Cost Center" />
                                <asp:BoundField DataField="DebitAmount" HeaderText="Debit Amount" />
                                <asp:BoundField DataField="CreditAmount" HeaderText="Credit Amount" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
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
</asp:Content>
