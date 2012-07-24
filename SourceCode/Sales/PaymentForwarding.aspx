<%@ Page Title="" Language="C#" MasterPageFile="~/Sales/PolyplexMaster.master" AutoEventWireup="true"
    CodeFile="PaymentForwarding.aspx.cs" Inherits="Sales_PaymentForwarding" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
    <link rel="Stylesheet" href="../CSS/grid.css" type="text/css" />
    <script language="javascript" type="text/javascript">
        function add(event) {



            if (document.getElementById("<%=txtAmountinUSD.ClientID %>").value != "") {
                var numWidthinMM = parseFloat(document.getElementById("<%=TxtAmountinFX.ClientID %>").value) + parseFloat(document.getElementById("<%=txtAmountinUSD.ClientID %>").value);
                document.getElementById("<%=txt_totalAmount.ClientID %>").value = numWidthinMM.toFixed(2);
            }
            else {
                var n = document.getElementById("<%=TxtAmountinFX.ClientID %>").value;
                document.getElementById("<%=txt_totalAmount.ClientID %>").value = n;
            }



        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <div style="overflow: auto; height: auto; position: relative; margin: 0 25px 0 25px;">
        <table style="width: 100%;">
            <tr>
                <td colspan="3" width="50%">
                    &nbsp;
                </td>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3" width="50%">
                    &nbsp;
                </td>
                <td colspan="3">
                </td>
            </tr>
           
            <tr>
                <td colspan="6">
                    <table width="100%" style="border: 1px solid grey">
                        <tr>
                            <td width="25%">
                                <div align="right">
                                    Voucher No.:</div>
                            </td>
                            <td width="25%">
                                <div align="left">
                                    <asp:TextBox ID="txtVoucherno" runat="server" Enabled="false"></asp:TextBox></div>
                            </td>
                            <td width="15%">
                                <div align="right">
                                    Voucher Date:</div>
                            </td>
                            <td width="35%">
                                <div align="left">
                                    <asp:TextBox ID="txtvoucherdate" Enabled="false" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtvoucherdate_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtvoucherdate" PopupButtonID="ImageButton2">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="false" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Party Code:<span style="color: Red">*</span>
                                </div>
                            </td>
                            <td colspan="2">
                                <div align="left">
                                    <asp:TextBox ID="txtcustomercode" Enabled="false" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="img_Customer_lookup" runat="server" ImageUrl="~/Images/select.gif"
                                        OnClick="img_Customer_lookup_Click" CausesValidation="false" />
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Inv. Dt. From:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtFromDate" runat="server" Enabled="true" OnTextChanged="txtFromDate_TextChanged"
                                        AutoPostBack="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtFromDate" PopupButtonID="ImageButton3">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="false" />
                                </div>
                            </td>
                            <td>
                                <div align="right">
                                    To:</div>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" Enabled="true" OnTextChanged="txtToDate_TextChanged"
                                    AutoPostBack="True"></asp:TextBox>
                                <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtToDate" PopupButtonID="ImageButton4">
                                </asp:CalendarExtender>
                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Remarks:</div>
                            </td>
                            <td colspan="3">
                                <div align="left">
                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                </div>
                                &nbsp; &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:RequiredFieldValidator ID="rfv_customercode" runat="server" ErrorMessage="Party Code is Required."
                        Display="None" ControlToValidate="txtcustomercode"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfv_customercode_ValidatorCalloutExtender" runat="server"
                        Enabled="True" TargetControlID="rfv_customercode" CssClass="customCalloutStyle"
                        PopupPosition="TopRight">
                    </asp:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bill No. is Required."
                        Display="None" ControlToValidate="txtBillno"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator1" CssClass="customCalloutStyle" PopupPosition="TopRight">
                    </asp:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bill Date is Required."
                        Display="None" ControlToValidate="txtBillDate"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator2" CssClass="customCalloutStyle" PopupPosition="TopRight">
                    </asp:ValidatorCalloutExtender>
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
                <td colspan="6">
                    <div id="div_grids" runat="server" style="border: 1px solid grey; height: 200px">
                        <table width="100%" cellspacing="5px">
                            <tr>
                                <td width="30%">
                                    <span class="gridname">Invoice Available:</span>
                                </td>
                                <td>
                                    <span class="gridname">Selected:</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="overflow: auto">
                                        <asp:GridView ID="gdv_Invoiceavailable" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                            PageSize="4" Width="100%" CssClass="GridViewStyle" DataKeyNames="Invoiceid,InvoiceNo"
                                            EmptyDataText="No Invoice available within selected date range." ShowHeaderWhenEmpty="True"
                                            OnPageIndexChanging="gdv_Invoiceavailable_PageIndexChanging" OnSelectedIndexChanged="gdv_Invoiceavailable_SelectedIndexChanged">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("InvoiceId") %>'
                                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                                        </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No">
                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="InvoiceDate" DataFormatString="{0:d}" HeaderText="Invoice Date">
                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="RowStyle" />
                                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                                            <PagerStyle CssClass="PagerStyle" />
                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                            <HeaderStyle CssClass="HeaderStyle" />
                                        </asp:GridView>
                                    </div>
                                </td>
                                <td>
                                    <div style="overflow: auto">
                                        <asp:GridView ID="Grid_lineItems" runat="server" AutoGenerateColumns="False" Width="100%"
                                            AllowPaging="True" PageSize="4" ShowHeaderWhenEmpty="True" EmptyDataText="No Line Items added."
                                            CssClass="GridViewStyle" DataKeyNames="Invoiceid" 
                                            onrowdeleting="Grid_lineItems_RowDeleting" 
                                            >
                                            <Columns>
                                                <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No."></asp:BoundField>
                                                <asp:BoundField DataField="FxAmount" HeaderText="Fx Amount"></asp:BoundField>
                                                <asp:BoundField DataField="AmtinUSD" HeaderText="USD Amount"></asp:BoundField>
                                                <asp:BoundField DataField="FxRate" HeaderText="Rate"></asp:BoundField>
                                                <asp:BoundField DataField="CurrencyCode" HeaderText="Currency"></asp:BoundField>
                                                <asp:BoundField DataField="BillNo" HeaderText="Bill No."></asp:BoundField>
                                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/delete.gif" HeaderText="Undo Addition"
                                                    ShowDeleteButton="True" />
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
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <table width="100%" style="border: 1px solid grey">
                        <tr>
                            <td width="10%">
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="10%">
                            </td>
                            <td width="15%">
                                <div align="right">
                                    For Invoice No.:</div>
                            </td>
                            <td width="15%">
                                <div align="left">
                                    <asp:TextBox ID="txtforInvoiceNo" runat="server" Enabled="False"></asp:TextBox></div>
                            </td>
                            <td width="10%">
                                <asp:RequiredFieldValidator ID="rfv_invoice" runat="server" ControlToValidate="txtforInvoiceNo"
                                    Display="None" ErrorMessage="Select a Invoice from List."></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfv_invoice_ValidatorCalloutExtender" runat="server"
                                    Enabled="True" TargetControlID="rfv_invoice" CssClass="customCalloutStyle">
                                </asp:ValidatorCalloutExtender>
                                &nbsp;
                            </td>
                            <td width="15%">
                            </td>
                            <td width="10%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Expenses:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:DropDownList ID="ddlExpenses" runat="server" Width="130px">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                            </td>
                            <td>
                                <div align="right">
                                    Bill No.:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtBillno" runat="server"></asp:TextBox></div>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfv_billno" runat="server" 
                                    ControlToValidate="txtBillno" Display="None" 
                                    ErrorMessage="Select a Invoice from List."></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfv_billno_ValidatorCalloutExtender" 
                                    runat="server" CssClass="customCalloutStyle" Enabled="True" 
                                    TargetControlID="rfv_billno">
                                </asp:ValidatorCalloutExtender>
                                &nbsp;
                            </td>
                            <td>
                                <div align="right">
                                    Bill Date:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtBillDate" Width="100px" runat="server" Enabled="false"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtBillDate_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtBillDate" PopupButtonID="ImageButton5" PopupPosition="BottomRight">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="false" ImageUrl="~/Images/cal.gif" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Currency:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:DropDownList ID="ddlcurrency" runat="server" Width="130px">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                            </td>
                            <td>
                                <div align="right">
                                    Amt. in FX:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="TxtAmountinFX" runat="server" onkeyup="add(event);"></asp:TextBox></div>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="rev_amtinFX" runat="server" ErrorMessage="Enter a valid Amount. (Only two digits are allowed after decimal.)"
                                    ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$" ControlToValidate="TxtAmountinFX"
                                    Display="None"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="rev_amtinFX_ValidatorCalloutExtender" runat="server"
                                    CssClass="customCalloutStyle" Enabled="True" TargetControlID="rev_amtinFX">
                                </asp:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtAmountinFX"
                                    Display="None" ErrorMessage="Amount in FX is Required."></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" CssClass="customCalloutStyle"
                                    Enabled="True" PopupPosition="TopRight" TargetControlID="RequiredFieldValidator3">
                                </asp:ValidatorCalloutExtender>
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
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                <div align="right">
                                    FX Rate:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txt_fxrate" runat="server"></asp:TextBox></div>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_fxrate"
                                    Display="None" ErrorMessage="FX Rate is Required."></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" CssClass="customCalloutStyle"
                                    Enabled="True" PopupPosition="TopRight" TargetControlID="RequiredFieldValidator4">
                                </asp:ValidatorCalloutExtender>
                                &nbsp;
                            </td>
                            <td>
                                <div align="right">
                                    Amt. in USD:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtAmountinUSD" runat="server" onkeyup="add(event);"></asp:TextBox></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="Revamtinusd" runat="server" ErrorMessage="Enter a valid Amount. (Only two digits are allowed after decimal.)"
                                    ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$" ControlToValidate="txtAmountinUSD"
                                    Display="None"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" CssClass="customCalloutStyle"
                                    Enabled="True" TargetControlID="Revamtinusd">
                                </asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                <div align="right">
                                    Total Amount:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txt_totalAmount" runat="server" Enabled="false"></asp:TextBox></div>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:ImageButton ID="btn_addline" runat="server" ImageUrl="~/Images/btnAddLinegreen.gif"
                                    OnClick="btn_addline_Click" />
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
                            </td>
                            <td>
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
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
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
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <table width="100%">
                        <tr>
                            <td width="30%">
                            </td>
                            <td width="30%">
                            </td>
                            <td>
                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" 
                                    onclick="btnSave_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/btnCancel.png" CausesValidation="false" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" 
                                    CausesValidation="false" OnClientClick="window.close();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    <asp:Panel ID="Pnl_lookUp" runat="server" Height="400px" Width="650px" CssClass="modalPopup">
        <asp:Panel ID="Panel5" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" /></div>
                    </td>
                    <td valign="top">
                        <div style="float: right; padding: 10px 10px 0 0">
                            <asp:ImageButton ID="btn_cancel2" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="margin-left: 20px; margin-right: 20px">
            <table width="100%" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>
                        <div class="in_menu_head">
                            <asp:Label ID="lPopUpHeader" runat="server" Text="Vendor Master"></asp:Label></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSearchLook" runat="server"></asp:TextBox>
                        &nbsp; &nbsp;<asp:ImageButton ID="Img_btn_search_lookup" runat="server" ImageUrl="~/Images/Search-32.png"
                            Height="20px" Width="20px" CausesValidation="False" OnClick="Img_btn_search_lookup_Click" />
                        <br />
                        <br />
                        <br />
                        <asp:Panel ID="Panel6" runat="server" Height="220px" Width="605px" ScrollBars="Auto">
                            <asp:GridView ID="GdvVendorList" runat="server" AllowPaging="True" Width="100%" EmptyDataText="No  Result match your search criteria."
                                AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" CssClass="GridViewStyle"
                                DataKeyNames="VendorId,VendorCode" OnSelectedIndexChanged="GdvVendorList_SelectedIndexChanged">
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
                                            <asp:Label ID="lblvendorcode" runat="server" Text='<%#Eval("VendorCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvendorname" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor Group">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvendorgrp" runat="server" Text='<%#Eval("VendorGroup") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvendorcity" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvendorperson" runat="server" Text='<%#Eval("ContactPersonOne") %>'></asp:Label>
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
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label2"
        PopupControlID="Pnl_lookUp" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel5" CancelControlID="btn_cancel2" />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>



    <asp:Panel ID="Pnl_Grid_Master" runat="server" Height="445px" Width="650px" CssClass="modalPopup">
        <asp:Panel ID="Pnl_GridMasterDrag" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" /></div>
                    </td>
                    <td valign="top">
                        <div style="float: right; padding: 20px 20px 0 0">
                            <asp:ImageButton ID="btn_grid_master_close" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="margin-left: 20px; margin-right: 20px">
            <table width="100%" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>
                        <div class="in_menu_head">
                            Payment Forwarding Results</div>
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
                            <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" PageSize="7" Width="100%"
                                EmptyDataText="No Result match your search criteria." ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="vchrId"
                                 CssClass="GridViewStyle" 
                                onselectedindexchanged="gridMaster_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="vchrNo" HeaderText="Voucher No" />
                                    <asp:BoundField DataField="vchrDate" DataFormatString="{0:d}" HeaderText="Date" />
                                    <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                    <asp:BoundField DataField="VendorGroup" HeaderText="Vendor Group" />
                                    
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
    <asp:modalpopupextender ID="ModalPopupExtender1" runat="server" TargetControlID="LabelTarget"
        PopupControlID="Pnl_Grid_Master" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Pnl_GridMasterDrag" CancelControlID="btn_grid_master_close" />
    <asp:Label ID="LabelTarget" runat="server" Text=""></asp:Label>







    <div id="div_hiddenfields">
        <asp:HiddenField ID="hf_vendorId" runat="server" />
        <asp:HiddenField ID="hf_InvoiceId" runat="server" />
        <asp:HiddenField ID="hf_ExpenseId" runat="server" />
        <asp:HiddenField ID="hf_Currencyid" runat="server" />
       
        <asp:HiddenField ID="hf_invoiceDate" runat="server" />
    </div>
</asp:Content>
