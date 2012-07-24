<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="InventoryItemInvoice.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../CSS/popupstyle.css" type="text/css" />
    <link href="../../CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

                

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <table style="width: 100%;">
            <tr>
                <td colspan="7" style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                </td>
            </tr>
            <tr valign="bottom" style="height: 20px">
                <td style="width: 16%">
                </td>
                <td style="width: 16%">
                </td>
                <td style="width: 16%">
                </td>
                <td style="width: 16%">
                </td>
                <td style="width: 16%">
                </td>
                <td style="width: 16%">
                </td>
                <td style="width: 4%">
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:Label ID="lblInfo" ForeColor="Red" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 5px">
                <td colspan="7">
                </td>
            </tr>
            <tr>
                
                <td align="right">
                    <asp:Label runat="server" Text="Sales Type:" ID="Label1"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtSalesType"></asp:TextBox>
                    <asp:ImageButton ID="imgSalesType" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                        TabIndex="8" CausesValidation="false" OnClick="imgSalesType_Click" />
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Year:" ID="Label4"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtYear"></asp:TextBox>
                </td>
                <td align="right" id ="TDLableSWBN" runat ="server">
                    <asp:Label runat="server" Text="Sales Waybill No.:" ID="Label2"></asp:Label>
                </td>
                <td id ="TDtxtSWBN" runat ="server">
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtSalesWaybillNo"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Invoice No.:" ID="Label5"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtInvoiceNo"></asp:TextBox>
                    <asp:ImageButton ID="imgInvoiceNo" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                        TabIndex="8" CausesValidation="false" OnClick="imgInvoiceNo_Click" />
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Date:" ID="lPIOrderNo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtDate"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Due Date:" ID="Label15"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDueDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton ID="imgDueDate" CausesValidation="false" runat="server" ImageUrl="~/Images/cal.gif"
                        TabIndex="0" />
                    <asp:CalendarExtender ID="calExtenderDueDate" runat="server" TargetControlID="txtDueDate"
                        PopupButtonID="imgDueDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Customer Code:" ID="Label11"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtCustomerCode"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Customer Name:" ID="Label6"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtCustomerName"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Sales Order No.:" ID="Label16"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtSalesOrderNo"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Sales Order Date:" ID="Label17"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtSalesOrderDate"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Currency:" ID="Label18"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtCurrency"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Exchange Rate:" ID="Label7"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtExchangeRate"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Fixed Amount:" ID="Label8"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtAmountInFX"></asp:TextBox>
                </td>
                <td align="right">
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
                <td>
                </td>
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
                <td colspan="6" style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                    <asp:Label runat="server" Text="" ID="lOrderLineDetails"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="7">
                    <div style="overflow: auto; width: 100%; position: relative;">
                        <asp:GridView ID="gvItemInventory" runat="server" AutoGenerateColumns="False" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found.">
                            <Columns>
                                <asp:BoundField DataField="MaterialDescription" HeaderText="Material Description">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UOM" HeaderText="UOM">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialCost" HeaderText="Material Cost">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SalesRate" HeaderText="Sales Rate">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C6C3C6" ForeColor="Black" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Base Amount:" ID="Label9"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtBaseAmount"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="VAT Amount:" ID="Label10"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtVATAmount"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Net Invoice Amount:" ID="Label12"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtNetInvoiceAmt"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" TabIndex="5" ImageUrl="~/Images/btnSave.png"
                        OnClick="ImgBtnSave_Click" />
                    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        TabIndex="5" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close();" />
                    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
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
                    <asp:HiddenField ID="HidSearch" runat="server" />
                    <asp:HiddenField ID="HidCustomerId" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidPopUpType" runat="server" />
                    <asp:HiddenField ID="hidSalesType" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidVat" runat="server" />
                    <asp:HiddenField ID="HidInvoiceId" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidSalesOrderId" runat="server" />
                    <asp:HiddenField ID="HidCurrencyId" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidAutoIdHeader" runat="server" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill the Invoice No."
            Display="None" ControlToValidate="txtInvoiceNo" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
            </asp:ValidatorCalloutExtender>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtExchangeRate"
            Display="None" ErrorMessage="Enter a valid Rate. (Only two digits are allowed after decimal.)"
            ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
            CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator1">
        </asp:ValidatorCalloutExtender>
        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
            FilterType="Custom, Numbers" TargetControlID="txtExchangeRate" ValidChars=".">
        </asp:FilteredTextBoxExtender>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAmountInFX"
            Display="None" ErrorMessage="Enter a valid fixed amount. (Only two digits are allowed after decimal.)"
            ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
            CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator2">
        </asp:ValidatorCalloutExtender>
        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
            FilterType="Custom, Numbers" TargetControlID="txtAmountInFX" ValidChars=".">
        </asp:FilteredTextBoxExtender>
    </div>
    <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="750px" CssClass="modalPopup"
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
                            Inventory Item List</div>
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
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Submit" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvInventoryItemList" runat="server" AutoGenerateColumns="true"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="5" OnRowDataBound="gvInventoryItemList_RowDataBound"
                            OnRowCommand="gvInventoryItemList_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                        </asp:GridView>
                        <asp:Label ID="lblTotalRecords" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label3"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <asp:Panel ID="PanelShowPopUpGrid" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
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
                            <asp:ImageButton ID="ImgBtnCancelPopUp" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="margin-left: 20px; margin-right: 20px">
            <table width="100%" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>
                        <div class="in_menu_head">
                            <asp:Label ID="lPopUpHeader" runat="server" Text="PopUp"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="0px" cellspacing="0px">
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label runat="server" Text="Search:" ID="lSearch"></asp:Label>
                                </td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtSearchFromPopup" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearchInPopUp" runat="server" TabIndex="10" Text="Submit" CausesValidation="false"
                                        OnClick="btnSearchInPopUp_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPopUpGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            PageSize="5" EnableColumnViewState="false" Width="100%" OnRowCommand="gvPopUpGrid_RowCommand"
                            OnRowDataBound="gvPopUpGrid_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="select"
                                                ImageUrl="~/Images/radioButton.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5px" />
                                    <ItemStyle HorizontalAlign="Center" Width="5px" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#242E4D" BorderColor="#242E4D" BorderStyle="Solid" BorderWidth="2px"
                                ForeColor="White" Height="15px" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="gridpager" HorizontalAlign="Left" />
                        </asp:GridView>
                        <asp:Label ID="lblTotalRecordsPopUp" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label9"
        PopupControlID="PanelShowPopUpGrid" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel2" CancelControlID="ImgBtnCancelPopUp" />
    <asp:Label ID="Label22" runat="server" Text=""></asp:Label>
</asp:Content>
