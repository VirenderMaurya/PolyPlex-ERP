<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="GoodsReceipt.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="overflow: auto; height: auto; position: relative;">
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
                    <asp:Label runat="server" Text="GR Year:" ID="Label53"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGRYear" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right" id="TDGRNo" runat="server">
                    <asp:Label runat="server" Text="GR No.:" ID="Label4"></asp:Label>
                </td>
                <td id="TDtxtGRNo" runat="server">
                    <asp:TextBox ID="txtGRNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="GR Date:" ID="Label6"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGRDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="PO No.:" ID="Label2"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPONo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/images/select.gif" Height="16px" TabIndex="8"
                        ID="imgPONo" OnClick="imgPONo_Click"></asp:ImageButton>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Vendor:" ID="Label11"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtVendor" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Gate Entry No.:" ID="Label12"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtGateEntryNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Gate Entry Date:" ID="Label13"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGateEntryDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox><asp:ImageButton
                        ID="ImageButton2" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                            ID="CalendarExtender2" runat="server" TargetControlID="txtGateEntryDate" PopupButtonID="ImageButton2"
                            Format="MM/dd/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Tax Invoice No.:" ID="Label14"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTaxInvoiceNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Tax Invoice Date:" ID="Label15"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTaxInvoiceDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox><asp:ImageButton
                        ID="ImageButton3" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                            ID="CalendarExtender3" runat="server" TargetControlID="txtTaxInvoiceDate" PopupButtonID="ImageButton3"
                            Format="MM/dd/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Sales Order:" ID="Label16"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSalesOrder" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Vehicle No.:" ID="Label17"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVehicleNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Due Date:" ID="Label18"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDueDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox><asp:ImageButton
                        ID="ImageButton4" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                            ID="CalendarExtender4" runat="server" TargetControlID="txtDueDate" PopupButtonID="ImageButton4"
                            Format="MM/dd/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Bill of Entry No.:" ID="Label19"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBillofEntryNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Bill of Entry Date:" ID="Label20"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBillofEntryDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox><asp:ImageButton
                        ID="ImageButton5" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                            ID="CalendarExtender5" runat="server" TargetControlID="txtBillofEntryDate" PopupButtonID="ImageButton5"
                            Format="MM/dd/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Exchange Rate:" ID="Label22"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExchangeRate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
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
                <td colspan="7">
                    <asp:TabContainer ID="TCGoodsReceipt" runat="server" Width="100%" 
                        ActiveTabIndex="0">
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Details" ID="TPDetails">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
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
                                    <tr style="font-size: small">
                                        <td colspan="6">
                                            <div style="overflow: auto; height: 100%; width: 905px; position: relative;">
                                                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" 
                                                    EmptyDataText="No Record Found." onrowdatabound="gvDetails_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" OnCheckedChanged="chk_CheckChanged" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AutoId" HeaderText="AutoId">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PRNumber" HeaderText="PR No.">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MaterialCode" HeaderText="Material Code">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MaterialName" HeaderText="Material">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ValuationType" HeaderText="ValuationTypeId">
                                                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ValuationTypeName" HeaderText="ValuationType">
                                                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="POQuantity" HeaderText="PO Quantity">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UOM" HeaderText="Base UOM">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UOMName" HeaderText="Base UOM">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UOMName" HeaderText="Order UOM">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="Price" HeaderText="Price">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Amount" HeaderText="Base Amount">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalanceQtyOrderUOM" HeaderText="Balance Qty. Order UOM">
                                                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ReceivedInOrderUOM" HeaderText="Received In Order UOM">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AcceptedInOrderUOM" HeaderText="Accepted In Order UOM">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AcceptedInStockUOM" HeaderText="Accepted In Stock UOM">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Currency" HeaderText="Currency">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ExchangeRate" HeaderText="PO Exchange Rate">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ExchangeRate" HeaderText="Exchange Rate">
                                                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="StorageLocation" HeaderText="Storage Location">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Discount" HeaderText="Discount">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Freight" HeaderText="Freight">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Insurance" HeaderText="Insurance">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Packing" HeaderText="Packing">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="OtherCost" HeaderText="Other Cost">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LineDiscount" HeaderText="Line Discount">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="LineofCost" HeaderText="Line of Cost">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PackLine" HeaderText="Line Packing">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LineVAT" HeaderText="Line VAT">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FXValue" HeaderText="FX Value">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ImportDuty" HeaderText="Import Duty">
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
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Material Cost:" ID="Label21"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMaterialCost" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" Text="VAT Total:" ID="Label26"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVATTotal" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" Text="GIA Total Value:" ID="Label29"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGIATotalValue" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
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
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Other Details" ID="TPOtherDetails">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
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
                                        <td align="right">
                                            <asp:Label runat="server" Text="Batch No.:" ID="Label1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBatchNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Vendor Batch No.:" ID="Label3"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVendorBatchNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Quantity Accepted Stock UOM:" ID="Label7"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityAcceptedStockUOM" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Manufacture Date:" ID="Label8"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtManufactureDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox><asp:ImageButton
                                                ID="ImageButton6" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="CalendarExtender1" runat="server" TargetControlID="txtManufactureDate" PopupButtonID="ImageButton6"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Expiration Date:" ID="Label9"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExpirationDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox><asp:ImageButton
                                                ID="ImageButton7" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="CalendarExtender6" runat="server" TargetControlID="txtExpirationDate" PopupButtonID="ImageButton7"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Life In Days:" ID="Label10"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLifeInDays" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                                FilterType="Numbers" TargetControlID="txtLifeInDays">
                                            </asp:FilteredTextBoxExtender>
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
                                            <asp:ImageButton ID="ImgBtnAddLine" runat="server" Text="Cancel" TabIndex="5" ImageUrl="~/Images/btnAddLine.png"
                                                OnClick="ImgBtnAddLine_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px">
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
                                    <tr style="font-size: small">
                                        <td colspan="6">
                                            <div style="overflow: auto; height: 100%; width: 905px; position: relative;">
                                                <asp:GridView ID="gvOtherDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                                                    OnRowCommand="gvOtherDetails_RowCommand">
                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("LineItemID") %>'
                                                                        CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="BatchNo" HeaderText="Batch No">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="VendorBatchNo" HeaderText="Vendor Batch No">
                                                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="QuantityAcceptedStockUOM" HeaderText="Batch Quantity">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ManufactureDate" HeaderText="Manufactured Date" DataFormatString="{0:MM/dd/yyyy}">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ExpirationDate" HeaderText="Expiry Date" DataFormatString="{0:MM/dd/yyyy}">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LifeInDays" HeaderText="Life In Days">
                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                        NextPageText="Next" PreviousPageText="Previous" />
                                                    <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C6C3C6" ForeColor="Black" />
                                                    <RowStyle CssClass="RowStyle" />
                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Total Stock UOM:" ID="Label27"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalStockUOM" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Balance Quantity:" ID="Label28"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBalanceQuantity" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </td>
            </tr>
            <tr style="height: 20px">
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
                <td colspan="7" align="center">
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" TabIndex="5"
                        ImageUrl="~/Images/btnSave.png" OnClick="ImgBtnSave_Click" />
                    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        TabIndex="5" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close();" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="HidPONo" runat="server" />
                    <asp:HiddenField ID="HidIsChecked" runat="server" />
                    
                </td>
                <td>
                    <asp:HiddenField ID="HidVendorId" runat="server" />
                    <asp:HiddenField ID="HidIsForm" runat="server" />
                </td>
                <td>
                </td>
                <td>
                    <asp:HiddenField ID="HidUpdateGridRecord" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidAutoId" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hidRowIndex" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hidLineItemId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="1" runat="server"
            ErrorMessage="PO No. is mandatory." Display="None" ControlToValidate="txtPONo"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="1" runat="server"
            ErrorMessage="Vendor is mandatory." Display="None" ControlToValidate="txtVendor"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="1" runat="server"
            ErrorMessage="Gate Entry No. is mandatory." Display="None" ControlToValidate="txtGateEntryNo"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender3" runat="server" Enabled="True" PopupPosition="Left"
                TargetControlID="RequiredFieldValidator3">
            </asp:ValidatorCalloutExtender>
    </div>
    <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
        Style="display: none">
        <asp:Panel ID="Panel3" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex"
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
                            Goods Receipt List</div>
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
                        <asp:GridView ID="gvGoodsReceiptList" runat="server" AutoGenerateColumns="false"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="3" OnPageIndexChanging="gvGoodsReceiptList_PageIndexChanging"
                            OnRowCommand="gvGoodsReceiptList_RowCommand">
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="gridpager" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="GRNo" HeaderText="GR Number">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GRDate" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GRYear" HeaderText="Year">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PONumber" HeaderText="PO Number">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VendorCodeName" HeaderText="Vendor">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
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
                        <asp:Label ID="lblTotalRecords" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label5"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <asp:Panel ID="PanelShowPopUpGrid" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
        Style="display: none">
        <asp:Panel ID="Panel2" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex"
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
                        <asp:GridView ID="gvPopUpGrid" runat="server" AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="5" OnPageIndexChanging="gvPopUpGrid_PageIndexChanging"
                            OnRowCommand="gvPopUpGrid_RowCommand" OnRowDataBound="gvPopUpGrid_RowDataBound">
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
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C6C3C6" ForeColor="Black" />
                        </asp:GridView>
                        <asp:Label ID="lblTotalRecordsPopUp" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label25"
        PopupControlID="PanelShowPopUpGrid" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel2" CancelControlID="ImgBtnCancelPopUp" />
    <asp:Label ID="Label25" runat="server" Text=""></asp:Label>
</asp:Content>
