<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="frmPO.aspx.cs" Inherits="Procurement_frmPO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .txtbox
        {
            width: 130px;
            border: 1px solid grey;
            font-family: Arial;
            font-size: 12px;
        }
        
        .valid
        {
            color: Red;
            font-weight: bold;
            font-size: 11px;
        }
    </style>
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScript" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
            <ajaxToolkit:TabContainer runat="server" ActiveTabIndex="0" TabStripPlacement="Top"
                ID="TabContCustomer" CssClass="myTabs" Width="100%">
                <ajaxToolkit:TabPanel runat="server" HeaderText="Main Page" ID="tabMainPage">
                    <ContentTemplate>
                        <table cellpadding="3px" width="100%">
                            <tr>
                                <td width="16%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        PO Type:<span style="color: Red">*</span>
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddPOType" CssClass="txtbox" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="ddPOType"
                                            Display="None" ErrorMessage="PO Type is Required."></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                                            CssClass="customCalloutStyle" Enabled="True" PopupPosition="TopRight" TargetControlID="rfv4">
                                        </ajaxToolkit:ValidatorCalloutExtender>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        PO Category:<span style="color: Red">*</span>
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddPOCategory" CssClass="txtbox" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Rfv1" runat="server" ControlToValidate="ddPOCategory"
                                            Display="None" ErrorMessage="PO Category is Required."></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                            CssClass="customCalloutStyle" Enabled="True" PopupPosition="TopRight" TargetControlID="Rfv1">
                                        </ajaxToolkit:ValidatorCalloutExtender>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        PO Number:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPONumber" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        PO Year:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPOYear" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        PO Date:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPODate" CssClass="txtbox" Width="110px" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender
                                            ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtPODate"
                                            PopupButtonID="ImageButton1">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="False" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Vendor:<span style="color: Red">*</span>
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtVendor" CssClass="txtbox" Width="110px" runat="server" Enabled="False"></asp:TextBox>
                                        <asp:ImageButton ID="img_Customer_lookup" runat="server" ImageUrl="~/Images/select.gif"
                                            OnClick="img_Customer_lookup_Click" CausesValidation="False" /><asp:RequiredFieldValidator
                                                ID="Rfv2" runat="server" ControlToValidate="txtVendor" Display="None" ErrorMessage="Vendor is Required."></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                            CssClass="customCalloutStyle" Enabled="True" PopupPosition="TopRight" TargetControlID="Rfv2">
                                        </ajaxToolkit:ValidatorCalloutExtender>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        Payment Terms:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPaymentTerms" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Inco Terms:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtIncoTerms" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Currency:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddCurrency" CssClass="txtbox" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        Exch. Rate:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtExchRate" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Exch. Rate Fixed:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:CheckBox ID="chkExchangeRateFixed" runat="server" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Vendor Reference:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtVendorReference" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Our Reference:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtOurReference" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Quotation:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtQuotation" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Quotation Date:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtQuotationDate" CssClass="txtbox" Width="110px" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender
                                            ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtQuotationDate"
                                            PopupButtonID="ImageButton2">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="False" /></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Freight:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtFreight" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Insurance:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtInsaurance" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Packing:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPacking" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Discount:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtDiscount" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Header Text:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtHeaderText" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        S.U Tax
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtSUTax" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Other Cost
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtOtherCost" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Delivery Plant:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtDeliveryPlant" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Purchasing Group:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddPurchasingGroup" CssClass="txtbox" runat="server">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem>Raw Materials</asp:ListItem>
                                            <asp:ListItem>Packing Materials</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <center>
                                        <asp:Panel ID="pnl_POLine" runat="server">
                                            <asp:GridView ID="gridPOLine" runat="server" AllowPaging="True" PageSize="4"
                                                Width="80%" EmptyDataText="No Line items added." 
                                                ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                                CssClass="GridViewStyle" DataKeyNames="LineItem"
                                                onselectedindexchanged="gridPOLine_SelectedIndexChanged">
                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <center>
                                                                <asp:ImageButton ID="imgAccgridsel" runat="server" CausesValidation="False" CommandName="Select"
                                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PRNumber" HeaderText="PR Number" />
                                                    <asp:BoundField DataField="MaterialCodeName" HeaderText="Material" />
                                                    <asp:BoundField DataField="POQuantity" HeaderText="Quantity" />
                                                     <asp:BoundField DataField="UOM" HeaderText="UOM" />
                                                      <asp:BoundField DataField="Price" HeaderText="Pro" />
                                                   

                                                    
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/delete.gif" HeaderText="Undo Addition"
                                                        ShowDeleteButton="True" />
                                                </Columns>
                                                <HeaderStyle CssClass="HeaderStyle" />
                                                <PagerStyle CssClass="PagerStyle" />
                                                <RowStyle CssClass="RowStyle" />
                                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        PR Number:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPRNumber" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Material Code:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtMaterialCode" CssClass="txtbox" runat="server" Width="110px"></asp:TextBox>
                                        <asp:ImageButton ID="imgMaterialLook" runat="server" ImageUrl="~/Images/select.gif"
                                            CausesValidation="False" OnClick="imgMaterialLook_Click" /></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Quantity:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtQuantity" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        UOM:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtUOM" CssClass="txtbox" runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        Price:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtprice" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Amount:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtAmount" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Plant:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPlant" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Cost Center:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtCostCenter" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        P.R Price:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPRPrice" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        PR DLV Date:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPRDlvDate" CssClass="txtbox" Width="110px" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender
                                            ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="txtPRDlvDate"
                                            PopupButtonID="ImageButton3">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="False" /></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Valuation:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList runat="server" CssClass="txtbox" ID="ddValuation">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        Project:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddProject" CssClass="txtbox" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Sub-Project:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddSubProject" CssClass="txtbox" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        Budget/ Capex:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtBudgetCapexLine" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Sub-Budget/ Capex:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtSubBudgetCapexLine" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Material Text:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtMaterialText" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Discount:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtDiscountLine" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Abs./%:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtABS" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Other Cost:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtOtherCostLine" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Packing:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPackingline" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        PO Item Text:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPOItemText" TextMode="MultiLine" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Lead Time(Days):
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtLeadTimeDays" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Delivery Quantity:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtDeliveryQuantity" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        &nbsp;&nbsp;</div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        &nbsp;&nbsp;</div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        <asp:ImageButton ID="btnAddLineMainPage" runat="server" 
                                            ImageUrl="~/Images/btnAddLinegreen.gif" onclick="btnAddLineMainPage_Click" /></div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Prices" ID="tabPrices">
                    <ContentTemplate>
                        <table width="100%" cellpadding="3px">
                            <tr>
                                <td width="12%">
                                    <div align="right">
                                        &nbsp;&nbsp;</div>
                                </td>
                                <td width="13%">
                                    <div align="left">
                                    </div>
                                </td>
                                <td width="12%">
                                    <div align="right">
                                    </div>
                                </td>
                                <td width="13%">
                                    <div align="left">
                                    </div>
                                </td>
                                <td width="12%">
                                    <div align="right">
                                    </div>
                                </td>
                                <td width="13%">
                                    <div align="left">
                                    </div>
                                </td>
                                <td width="12%">
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8">

                                <center>
                                        <asp:Panel ID="Panel1" runat="server">
                                            <asp:GridView ID="GridPrices" runat="server" AllowPaging="True" PageSize="4"
                                                Width="80%" EmptyDataText="No Line items added." ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                                CssClass="GridViewStyle" DataKeyNames="POLNNo">
                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <center>
                                                                <asp:ImageButton ID="imgAccgridsel" runat="server" CausesValidation="False" CommandName="Select"
                                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                  

                                                    <asp:BoundField DataField="ConditionCode" HeaderText="Condition Code" />
                                                    <asp:BoundField DataField="ConditionCurrency" HeaderText="Condition Currency" />
                                                    <asp:BoundField DataField="ConditionValue" HeaderText="Condition Value" />
                                                     <asp:BoundField DataField="VendorCode" HeaderText="Vendor Code" />
                                                      <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                                      <asp:BoundField DataField="AmountLC" HeaderText="AmountLC" />
                                                   

                                                    
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/delete.gif" HeaderText="Undo Addition"
                                                        ShowDeleteButton="True" />
                                                </Columns>
                                                <HeaderStyle CssClass="HeaderStyle" />
                                                <PagerStyle CssClass="PagerStyle" />
                                                <RowStyle CssClass="RowStyle" />
                                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Condition Code:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtPricesConditioncode" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Currency:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddpricescurrency" CssClass="txtbox" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        Condition Value:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtpricesConditionvalue" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Calculation Type:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtpricescalculationtype" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Amount:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtpricesamount" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Amount LC:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtpricesamountlc" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Vendor:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtpricesvendor" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:ImageButton ID="btnAddLinePrices" runat="server" 
                                            ImageUrl="~/Images/btnAddLinegreen.gif" onclick="btnAddLinePrices_Click" />
                                    </div>
                                </td>
                                <td>  <div align="right">
                                        </div>
                                </td>
                                <td>
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Delivery Days" ID="tabDeliveryDays">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td width="25%">
                                    &nbsp;&nbsp;
                                </td>
                                <td width="25%">
                                </td>
                                <td width="25%">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"><center>
                                        <asp:Panel ID="Panel3" runat="server">
                                            <asp:GridView ID="GridDeliveryDays" runat="server" AllowPaging="True" PageSize="4"
                                                Width="80%" EmptyDataText="No Line items added." ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                                CssClass="GridViewStyle" DataKeyNames="POLineNo">
                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <center>
                                                                <asp:ImageButton ID="imgAccgridsel" runat="server" CausesValidation="False" CommandName="Select"
                                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DeliveryDays" HeaderText="Delivery Days" />
                                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                   
                                                   
                                                  
                                                    
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/delete.gif" HeaderText="Undo Addition"
                                                        ShowDeleteButton="True" />
                                                </Columns>
                                                <HeaderStyle CssClass="HeaderStyle" />
                                                <PagerStyle CssClass="PagerStyle" />
                                                <RowStyle CssClass="RowStyle" />
                                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td width="25%">
                                    <div align="right">
                                        Required Quantity:
                                    </div>
                                </td>
                                <td width="25%">
                                    <div align="left">
                                        <asp:TextBox ID="txtDeliveryRequiredQuatity" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                                <td width="25%">
                                    <div align="right">
                                        Total Days:
                                    </div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtDeliveryTotal" CssClass="txtbox" runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td width="25%">&nbsp;
                                </td>
                                <td width="25%">
                                </td>
                                <td width="25%">
                                </td>
                                <td>
                                </td>
                            </tr>
                             <tr>
                                <td width="25%">
                                </td>
                                <td width="25%">
                                </td>
                                <td width="25%"><div align="right"> <asp:ImageButton ID="btnAddLineDeliveryDays" runat="server" 
                                            ImageUrl="~/Images/btnAddLinegreen.gif" 
                                        onclick="btnAddLineDeliveryDays_Click" /></div>
                                </td>
                                <td>
                                </td>
                            </tr>
                           
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
            <div>
                &nbsp;</div>
            <div style="margin-right: 80px; text-align: right">  
                <asp:ImageButton ID="btnUpdate" runat="server" CssClass="Button" ImageUrl="~/Images/btn_update.png"
                    Text="Update" onclick="btnUpdate_Click" />
                <asp:ImageButton ID="btnSave" runat="server" CssClass="Button" ImageUrl="~/Images/btnSave.png"
                    Text="Save" onclick="btnSave_Click" />&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png"
                        OnClientClick="window.close()" Style="font-weight: bold" Text="Cancel" />
            </div>
            <div>
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
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label2"
                    PopupControlID="Pnl_lookUp" BackgroundCssClass="modalBackground" DropShadow="true"
                    PopupDragHandleControlID="Panel5" CancelControlID="btn_cancel2" />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></div>
            <div>
                <asp:HiddenField ID="hf_VendorId" runat="server" />
                 <asp:HiddenField ID="hf_isNewRecord" runat="server" />
                <asp:HiddenField ID="HidPopUpType" runat="server" />
                <asp:HiddenField ID="HidMaterialId" runat="server" />
                <asp:HiddenField ID="HidUOMId" runat="server" /><asp:HiddenField ID="hfPOid" runat="server" /><asp:HiddenField ID="hfDetailsLineno" runat="server" />
                <asp:HiddenField ID="hfpriceslineno" runat="server" /><asp:HiddenField ID="hfdeliverydayslineno" runat="server" />
             
                
            </div>
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
                                    <asp:Label ID="Label1" runat="server" Text="PopUp"></asp:Label>
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
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="Label25"
                PopupControlID="PanelShowPopUpGrid" BackgroundCssClass="modalBackground" DropShadow="true"
                PopupDragHandleControlID="Panel2" CancelControlID="ImgBtnCancelPopUp" />
            <asp:Label ID="Label25" runat="server" Text=""></asp:Label>


             <asp:Panel ID="Pnl_Grid_Master" runat="server" Height="445px" Width="650px" CssClass="modalPopup"
                Style="display: none">
                <asp:Panel ID="Pnl_GridMasterDrag" runat="server" Style="cursor: pointer">
                    <table width="100%">
                        <tr>
                            <td>
                                <div style="margin: 10px 0px 10px 20px">
                                    <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" /></div>
                            </td>
                            <td valign="top">
                                <div style="float: right; padding: 20px 20px 0 0">
                                    <asp:ImageButton ID="btn_grid_master_close" runat="server" AlternateText="Cancel"
                                        ImageUrl="~/Images/delete.gif" /></div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div style="margin-left: 20px; margin-right: 20px">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td>
                                <div class="in_menu_head">
                                    Purchase Order</div>
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
                                    <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                        DataKeyNames="Autoid" Width="100%" EmptyDataText="No  Result match your search criteria."
                                        PageSize="7" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"
                                        OnPageIndexChanging="gridMaster_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                            ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PONumber" HeaderText="PO Number" />
                                            <asp:BoundField DataField="PODate" HeaderText="PO Date" />
                                            <asp:BoundField DataField="Vendor" HeaderText="Vendor" />
                                            <asp:BoundField DataField="Currency" HeaderText="Currency" />
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
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LabelTarget"
                PopupControlID="Pnl_Grid_Master" BackgroundCssClass="modalBackground" DropShadow="true"
                PopupDragHandleControlID="Pnl_GridMasterDrag" CancelControlID="btn_grid_master_close" />
            <asp:Label ID="LabelTarget" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
