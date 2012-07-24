<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="InputVatCorrection.aspx.cs" Inherits="Finance_transaction_InputVatCorrection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="pnlmain" runat="server">
      <table width="100%" id="Table1">
      <tr>
      <td align="center">Voucher#  <asp:TextBox ID="TxtVoucherNo" runat="server"></asp:TextBox>
      </td>
      </tr>
          <tr>
              <td align="center">
                  &nbsp;</td>
          </tr>
      </table>

    <%--<asp:GridView ID="GdvVatDetails" runat="server" AutoGenerateColumns="False" PageSize="3" ShowHeaderWhenEmpty="true" EmptyDataText="No record found"
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
            </asp:GridView>--%>
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
                                    ID="valcaloutvendorcode" runat="server" Enabled="True" TargetControlID="reqvendorcodevat">
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
                                ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
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
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
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
                        <asp:Button ID="BtnAdd_VatDetails" runat="server" Text="Add Line" Width="120px" Font-Bold="True"
                            ValidationGroup="vatdetails" OnClick="BtnAdd_VatDetails_Click" />
                    </td>
                    <td width="8%">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
    </asp:Panel> 
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
                    <asp:GridView ID="GdvVendorList" runat="server" AllowPaging="True" PageSize="1"
                    AutoGenerateColumns="false" DataKeyNames="FIVendorCode" 
                    EmptyDataText="No  Result match your search criteria." 
                    OnSelectedIndexChanged="gridMaster_SelectedIndexChanged" 
                    onpageindexchanging="GdvVendorList_PageIndexChanging"
                    ShowHeaderWhenEmpty="True" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <center>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                        CommandName="Select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
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
                      <SelectedRowStyle  CssClass="SelectedRowStyle" />
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
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImageButton2" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>
