<%@ Page Title="" Language="C#" MasterPageFile="~/Sales/PolyplexMaster.master" AutoEventWireup="true"
    CodeFile="AdvAgainstPO.aspx.cs" Inherits="Sales_AdvAgainstPO" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
    <link rel="Stylesheet" href="../CSS/grid.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <br />
    <br />
    <table width="100%">
        <tr>
            <td>
                <center>
                    <table width="98%" style="border: 1px solid grey">
                        <tr>
                            <td width="14%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="14%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="14%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Voucher No.:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtVoucherno" runat="server" Width="120px" Enabled="false"></asp:TextBox></div>
                            </td>
                            <td>
                                <div align="right">
                                    Voucher Date:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtvoucherdate" Enabled="false" Width="100px" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtvoucherdate_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtvoucherdate" PopupButtonID="ImageButton2">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="false" /></div>
                            </td>
                            <td>
                                <div align="right">
                                    Year:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtYear" Enabled="false" Width="120px" runat="server"></asp:TextBox></div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Bank G L Code:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtbankGLCode" Enabled="false" Width="100px" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="img_Customer_lookup" runat="server" ImageUrl="~/Images/select.gif"
                                        CausesValidation="false" OnClick="img_Customer_lookup_Click" />
                                </div>
                            </td>
                            <td colspan="2">
                                <div align="left">
                                    <asp:RequiredFieldValidator ID="rfv_txtbankGLCode" runat="server" ErrorMessage="Bank GL code is Required."
                                        Display="None" ControlToValidate="txtbankGLCode"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfv_txtbankGLCode_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfv_txtbankGLCode" CssClass="customCalloutStyle"
                                        PopupPosition="TopRight">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:Label ID="lbl_bankname" runat="server" Font-Bold="True"></asp:Label></div>
                            </td>
                            <td>
                                <div align="right">
                                    Currency:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:DropDownList ID="dd_currency" runat="server" Width="120px">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="Revlocalbankcharges" runat="server" ControlToValidate="txt_localbankCharges"
                                    Display="None" ErrorMessage="Enter a valid Amount. (Only two digits are allowed after decimal.)"
                                    ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" CssClass="customCalloutStyle"
                                    Enabled="True" TargetControlID="Revlocalbankcharges">
                                </asp:ValidatorCalloutExtender>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Foreign Bank Charges(Fx):<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtForeignBankCharges" Width="120px" runat="server"></asp:TextBox></div>
                            </td>
                            <td>
                                <div align="right">
                                    Exchange Rate:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtExchangeRate" Width="120px" runat="server"></asp:TextBox></div>
                            </td>
                            <td>
                                <div align="right">
                                    Local Bank Charges:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txt_localbankCharges" Width="120px" runat="server"></asp:TextBox></div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Fx Bank Charges LC:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txt_fxbankchargesLC" Width="120px" runat="server"></asp:TextBox></div>
                            </td>
                            <td>
                                <div align="right">
                                    Cheque No.:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txt_chequeNo" Width="120px" runat="server"></asp:TextBox></div>
                            </td>
                            <td>
                                <div align="right">
                                    Cheque Date:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txt_chequedate" Enabled="false" Width="100px" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txt_chequedate"
                                        PopupButtonID="ImageButton1">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="false" /></div>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RevForeignbankcharges" runat="server" ControlToValidate="txtForeignBankCharges"
                                    Display="None" ErrorMessage="Enter a valid Amount. (Only two digits are allowed after decimal.)"
                                    ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="RevForeignbankcharges_ValidatorCalloutExtender"
                                    runat="server" CssClass="customCalloutStyle" Enabled="True" TargetControlID="RevForeignbankcharges">
                                </asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_fxbankchargesLC"
                                    Display="None" ErrorMessage="Enter a valid Amount. (Only two digits are allowed after decimal.)"
                                    ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="RegularExpressionValidator1_ValidatorCalloutExtender"
                                    runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator1">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Cheque Number is required." ControlToValidate="txt_chequeNo" 
                                    Display="None"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1" CssClass="customCalloutStyle">
                                </asp:ValidatorCalloutExtender>
                                
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="Local Bank Charges is required." ControlToValidate="txt_localbankCharges" 
                                    Display="None"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2" CssClass="customCalloutStyle">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="Cheque Date is required." ControlToValidate="txt_chequedate" 
                                    Display="None"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3" CssClass="customCalloutStyle">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <table width="98%" style="border: 1px solid grey">
                        <tr>
                            <td width="50%" style="vertical-align: top">
                                <asp:Panel ID="pnl_grid" runat="server" Width="100%" Height="100%">
                                    <div style="overflow: auto">
                                        <asp:GridView ID="Grid_lineItems" runat="server" AutoGenerateColumns="False" Width="100%"
                                            AllowPaging="True" PageSize="4" ShowHeaderWhenEmpty="True" EmptyDataText="No Line Items added."
                                            CssClass="GridViewStyle" DataKeyNames="Autoid" OnRowDeleting="Grid_lineItems_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="PONo" HeaderText="PO No."></asp:BoundField>
                                                <asp:BoundField DataField="PODate" DataFormatString="{0:d}" HeaderText="Date"></asp:BoundField>
                                                <asp:BoundField DataField="VendorCode" HeaderText="Vendor"></asp:BoundField>
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
                                </asp:Panel>
                            </td>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td width="20%">
                                        </td>
                                        <td width="30%">
                                            <div align="left">
                                                Advance Paid Against PO:</div>
                                        </td>
                                        <td>
                                            <div align="left">
                                                <asp:TextBox ID="txt_Advancepaidagainstpo" Width="120px" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                                        </td>
                                        <td width="30%">
                                            <div align="left">
                                                PO value in LC:</div>
                                        </td>
                                        <td>
                                            <div align="left">
                                                <asp:TextBox ID="txt_POValueinLC" Width="120px" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                                        </td>
                                        <td width="30%">
                                            <div align="left">
                                                PO Value already paid:</div>
                                        </td>
                                        <td>
                                            <div align="left">
                                                <asp:TextBox ID="txt_POValueAlreadyPaid" Width="120px" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                                        </td>
                                        <td width="30%">
                                            <div align="left">
                                                Payment Terms in PO:</div>
                                        </td>
                                        <td>
                                            <div align="left">
                                                <asp:TextBox ID="txt_PaymntTermsinPO" Width="120px" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                                        </td>
                                        <td width="30%">
                                            <div align="left">
                                                Exchange Rate in PO:</div>
                                        </td>
                                        <td>
                                            <div align="left">
                                                <asp:TextBox ID="txt_ExchangeRateinPO" Width="120px" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                                        </td>
                                        <td width="30%">
                                            <div align="left">
                                                Fx Value in PO:</div>
                                        </td>
                                        <td>
                                            <div align="left">
                                                <asp:TextBox ID="txt_FxValueinPO" Width="120px" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                                        </td>
                                        <td width="30%">
                                            <div align="left">
                                                Fx +/- :</div>
                                        </td>
                                        <td>
                                            <div align="left">
                                                <asp:TextBox ID="txt_FXPlusMinus" Width="120px" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <table width="98%" style="border: 1px solid grey">
                        <tr>
                            <td>
                                <div align="right">
                                    P.O.#:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtPO" runat="server" Enabled="false" Width="100px"></asp:TextBox>
                                    <asp:ImageButton ID="img_PO_lookup" runat="server" CausesValidation="false" ImageUrl="~/Images/select.gif"
                                        OnClick="img_PO_lookup_Click" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ErrorMessage="Please select a Purchase Order." ControlToValidate="txtPO" Display="None"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4" CssClass="customCalloutStyle">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </td>
                            <td>
                                <div align="right">
                                    Vendor:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txt_Vendor" runat="server" Width="120px" Enabled="false"></asp:TextBox>
                                </div>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Fx Value:<span style="color: Red">*</span></div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="FxValue" runat="server" Width="120px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="FxValue" Display="None" 
                                        ErrorMessage="Please insert FxValue."></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender0" 
                                        runat="server" CssClass="customCalloutStyle" Enabled="True" 
                                        TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FxValue"
                                    Display="None" ErrorMessage="Enter a valid Amount. (Only two digits are allowed after decimal.)"
                                    ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                    runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator2">
                                </asp:ValidatorCalloutExtender>
                                </div>
                            </td>
                            <td>
                                <div align="right">
                                    Value in LC:</div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txt_ValueinLC" runat="server" Width="120px" Enabled="false"></asp:TextBox>
                                </div>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            
                        </tr>
                        <tr>
                            
                            <td>
                            </td>
                            <td>
                            </td>
                            <td colspan="2">
                                <div align="left">
                                    <asp:ImageButton ID="btn_AddLine" runat="server" ImageUrl="~/Images/btnAddLinegreen.gif" />&nbsp;&nbsp;&nbsp;
                                    <asp:ImageButton ID="btn_SaveLine" runat="server" ImageUrl="~/Images/btnSaveLinegreen.gif"
                                        OnClick="btn_SaveLine_Click" /></div>
                            </td>
                        </tr>
                    </table>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="33%">
                        </td>
                        <td>
                            <div align="left">
                                <asp:ImageButton ID="btn_Save" runat="server" ImageUrl="~/Images/btnSave.png" OnClick="btn_Save_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btn_Cancel" runat="server" ImageUrl="~/Images/btnCancel.png" />&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btn_Exit" runat="server" ImageUrl="~/Images/btnExit.png" OnClientClick="window.close();" /></div>
                        </td>
                        <td width="33%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
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
                            <asp:Label ID="lPopUpHeader" runat="server" Text="GL Group"></asp:Label></div>
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
                        &nbsp; &nbsp;<asp:ImageButton ID="Img_btn_search_lookup_GL" runat="server" ImageUrl="~/Images/Search-32.png"
                            Height="20px" Width="20px" CausesValidation="False" OnClick="Img_btn_search_lookup_GL_Click" />
                        <br />
                        <asp:Panel ID="Panel6" runat="server" Height="245px" Width="605px" ScrollBars="Auto">
                            <asp:GridView ID="GdvBankList" runat="server" AllowPaging="True" Width="100%" EmptyDataText="No  Result match your search criteria."
                                AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" CssClass="GridViewStyle"
                                PageSize="7" DataKeyNames="GeneralLedgerCode,GLDescription" OnSelectedIndexChanged="GdvBankList_SelectedIndexChanged"
                                OnPageIndexChanging="GdvBankList_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GL Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGlcode" runat="server" Text='<%#Eval("GeneralLedgerCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bank Name">
                                        <ItemTemplate>
                                            <asp:Label ID="GLDescription" runat="server" Text='<%#Eval("GLDescription") %>'></asp:Label>
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
    <asp:Panel ID="Panel1" runat="server" Height="400px" Width="650px" CssClass="modalPopup">
        <asp:Panel ID="Panel2" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" /></div>
                    </td>
                    <td valign="top">
                        <div style="float: right; padding: 10px 10px 0 0">
                            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="margin-left: 20px; margin-right: 20px">
            <table width="100%" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>
                        <div class="in_menu_head">
                            <asp:Label ID="Label1" runat="server" Text="Purchase Order"></asp:Label></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtPOSearch" runat="server"></asp:TextBox>
                        &nbsp; &nbsp;<asp:ImageButton ID="btn_search_lookup_PO" runat="server" ImageUrl="~/Images/Search-32.png"
                            Height="20px" Width="20px" CausesValidation="False" OnClick="btn_search_lookup_PO_Click" />
                        <br />
                        <asp:Panel ID="Panel3" runat="server" Height="220px" Width="605px" ScrollBars="Auto">
                            <asp:GridView ID="grid_PO" runat="server" AllowPaging="True" Width="100%" EmptyDataText="No  Result match your search criteria."
                                AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" CssClass="GridViewStyle"
                                DataKeyNames="Autoid" OnSelectedIndexChanged="grid_PO_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO Number">
                                        <ItemTemplate>
                                            <asp:Label ID="PONumber" runat="server" Text='<%#Eval("PONumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="PODate" DataFormatString="{0:d}" runat="server" Text='<%#Eval("PODate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor">
                                        <ItemTemplate>
                                            <asp:Label ID="VendorCode" runat="server" Text='<%#Eval("VendorCode") %>'></asp:Label>
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
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label3"
        PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel2" CancelControlID="ImageButton3" />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label><asp:HiddenField ID="hf_POid"
        runat="server" />
    <asp:HiddenField ID="hf_PODate" runat="server" />
</asp:Content>
