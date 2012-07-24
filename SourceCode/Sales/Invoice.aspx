<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sales/PolyplexMasterTwoSection.master"
    CodeFile="Invoice.aspx.cs" Inherits="Pages_Invoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/Controls/InvoiceTasks.ascx" TagName="Sales" TagPrefix="InvTasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">

        function CheckLength(txt, maxLen, textboxid) {
            try {
                if (txt.value.length > (maxLen - 1)) {
                    document.getElementById(textboxid).value = maxLen - txt.value.length;
                    return false;
                }
            } catch (e) {
            }
        }



        function limitText(limitField, limitCount, limitNum) {
            if (limitField.value.length > limitNum) {
                limitField.value = limitField.value.substring(0, limitNum);
            } else {
                limitCount.value = limitNum - limitField.value.length;
            }
        }

    </script>
    <style type="text/css">
        .TaskGridHeader
        {
            background-image: url('../images/nav_link_hover.png');
            background-repeat: repeat-x;
            font-family: Arial;
            font-size: 11px;
            font-weight: bold;
        }
        .TasksideInfo
        {
            background-image: url('../images/nav_link_hover.png');
            background-repeat: repeat-x;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <AjaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </AjaxToolkit:ToolkitScriptManager>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <div style="overflow: auto; height: auto; position: relative;">
        <table style="width: 100%;">
            <tr valign="bottom">
                <td style="height: 20px">
                    <asp:Label ID="lblInfo" ForeColor="Red" runat="server"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <AjaxToolkit:TabContainer ID="TCInvoice" runat="server" Width="100%" ActiveTabIndex="0"
                        CssClass="myTabs">
                        <AjaxToolkit:TabPanel runat="server" CssClass="tabControl" HeaderText="Main Details"
                            ID="TPMaindetails">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
                                        <td style="width: 16%">
                                            &nbsp;&nbsp;
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
                                            Type:<span style="color: Red">*</span>
                                        </td>
                                        <td colspan="2">
                                            <table width="100%" cellpadding="0px" cellspacing="0px">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txt_Type" Width="35px" runat="server"></asp:TextBox>
                                                        &nbsp; Year:<span style="color: Red">*</span><asp:TextBox ID="txt_year" Width="50px"
                                                            runat="server" TabIndex="1"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        Invoice Number:<span style="color: Red">*</span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_InvNumber" Width="130px" runat="server" TabIndex="2"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Date:<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_invDate" runat="server" Width="105px" TabIndex="3" Enabled="False"></asp:TextBox><AjaxToolkit:CalendarExtender
                                                ID="Txt_invDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="Txt_invDate"
                                                PopupButtonID="ImageButton1">
                                            </AjaxToolkit:CalendarExtender>
                                            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cal.gif"
                                                CausesValidation="False" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Q Sr. Invoice:<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_QSrInv" runat="server" Width="130px" TabIndex="4"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Order No:<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_orderno" runat="server" Width="110px" TabIndex="5" Enabled="false"></asp:TextBox><asp:ImageButton
                                                ID="imgOrderNo" runat="server" Height="16px" ImageUrl="~/images/select.gif" OnClick="imgOrderNo_Click"
                                                CausesValidation="False" />
                                        </td>
                                        <td align="right">
                                            PI No.:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_PINo" runat="server" Width="130px" TabIndex="6" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Exporter Code:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" Width="130px" ID="Txt_ExporterCode" TabIndex="7"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td align="right">
                                            Country Final Destination:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" Width="130px" ID="Txt_CFD" TabIndex="8" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Party Code:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_PartyCode" runat="server" Width="110px" TabIndex="9" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Consignee Code:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_ConsigneeCode" runat="server" Width="130px" TabIndex="10" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Delivery Code:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_DeliveryCode" runat="server" Width="130px" TabIndex="11" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Buy&#39;s Order#
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_BuysOrder" runat="server" Width="130px" TabIndex="12" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Buyer&#39;s Order Dt:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_BuysOrderDate" runat="server" Width="110px" TabIndex="13" Enabled="False"></asp:TextBox><AjaxToolkit:CalendarExtender
                                                ID="Txt_BuysOrderDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="Txt_BuysOrderDate"
                                                PopupButtonID="ImageButton2">
                                            </AjaxToolkit:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/cal.gif" CausesValidation="False" />
                                        </td>
                                        <td align="right">
                                            Currency:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" Width="130px" ID="TxtCurrency" TabIndex="14" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            ETD:<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_ETD" runat="server" Width="110px" TabIndex="15" Enabled="False"></asp:TextBox><AjaxToolkit:CalendarExtender
                                                ID="Txt_ETD_CalendarExtender" runat="server" Enabled="True" PopupButtonID="ImageButton3"
                                                TargetControlID="Txt_ETD">
                                            </AjaxToolkit:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/cal.gif" CausesValidation="False" />
                                        </td>
                                        <td align="right">
                                            ETA:<span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_ETA" runat="server" Width="110px" TabIndex="16" Enabled="False"></asp:TextBox><AjaxToolkit:CalendarExtender
                                                ID="Txt_ETA_CalendarExtender" runat="server" Enabled="True" TargetControlID="Txt_ETA"
                                                PopupButtonID="ImageButton4">
                                            </AjaxToolkit:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/cal.gif" CausesValidation="False" />
                                        </td>
                                        <td align="right">
                                            Print in Gauge, Inch:
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chk_Print_in_G_I" runat="server" TabIndex="17" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Print Width:
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chk_PrintWidth" runat="server" TabIndex="18" />
                                        </td>
                                        <td align="right">
                                            Print Buyer:
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chk_PrintBuyers" runat="server" TabIndex="19" />
                                        </td>
                                        <td align="right">
                                            To Order Consignee:
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="Chk_to_order_Consignee" runat="server" TabIndex="20" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Bill of Loading
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_Bill_of_loading" runat="server" Width="130px" TabIndex="21"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Bill of Loading Dt:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_Bill_of_loading_date" runat="server" Width="110px" TabIndex="22"
                                                Enabled="False"></asp:TextBox><AjaxToolkit:CalendarExtender ID="Txt_Bill_of_loading_date_CalendarExtender"
                                                    runat="server" Enabled="True" TargetControlID="Txt_Bill_of_loading_date" PopupButtonID="ImageButton5">
                                                </AjaxToolkit:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/cal.gif" CausesValidation="False" />
                                        </td>
                                        <td align="right">
                                            Container No.:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_containerno" runat="server" Width="130px" TabIndex="23"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Shipping Line:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_ShippingLine" runat="server" Width="130px" TabIndex="24"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Export Entry No.:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_ExportEntryNumber" runat="server" Width="130px" TabIndex="25"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Export Entry Dt.:<td>
                                                <asp:TextBox ID="Txt_ExportEntryDate" runat="server" Width="110px" TabIndex="26"
                                                    Enabled="False"></asp:TextBox><AjaxToolkit:CalendarExtender ID="Txt_ExportEntryDate_CalendarExtender"
                                                        runat="server" Enabled="True" TargetControlID="Txt_ExportEntryDate" PopupButtonID="ImageButton6">
                                                    </AjaxToolkit:CalendarExtender>
                                                <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/cal.gif" CausesValidation="False" />
                                            </td>
                                            <td>
                                            </td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            FOB / CIF:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_FOB_CIF" runat="server" Width="130px" TabIndex="27"></asp:TextBox>
                                        </td>
                                        <td align="right">
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
                                        <td align="right">
                                            Inland Transport:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_InlandTransport" runat="server" Width="130px" TabIndex="28"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Frieght:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_Frieght" runat="server" Width="130px" TabIndex="29"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Insurance:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_Insaurance" runat="server" Width="130px" TabIndex="30"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Vessel / Flight No.:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_Vessel_flight_no" runat="server" Width="130px" TabIndex="31"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Pre-Carriage By:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_pre_carriage_by" runat="server" Width="130px" TabIndex="32"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Place of Rect. By Pre-Carriage:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_Place_of_Rect" runat="server" Width="130px" TabIndex="33"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Port of Loading:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_Port_of_loading" runat="server" Width="130px" TabIndex="34"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Port of Discharge:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_Port_oif_Discharge" runat="server" Width="130px" TabIndex="35"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Final Destination:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_final_destination" runat="server" Width="130px" TabIndex="36"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;&nbsp;
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
                                            <table width="100%">
                                                <tr>
                                                    <td width="8%">
                                                    </td>
                                                    <td>
                                                        <div style="margin: 5px auto 5px auto">
                                                            <asp:Panel ID="Panel1" runat="server" GroupingText="Packing Details">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="text-align: right">
                                                                            &#160;&#160;
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td style="text-align: right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: right">
                                                                            Net Weight:
                                                                        </td>
                                                                        <td>
                                                                            <div style="vertical-align: super">
                                                                                <asp:TextBox ID="Txt_NetWeight_KG" runat="server" Width="80px" TabIndex="37"></asp:TextBox>
                                                                                &#160;(KG) &#160;
                                                                                <asp:TextBox ID="Txt_netWeight_LBS" runat="server" Width="80px" TabIndex="38"></asp:TextBox>&#160;(LBS)</div>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td style="text-align: right">
                                                                            Gross Weight:
                                                                        </td>
                                                                        <td>
                                                                            <div style="vertical-align: super">
                                                                                <asp:TextBox ID="Txt_Gross_Weight_KG" runat="server" Width="80px" TabIndex="39"></asp:TextBox>&#160;(KG)
                                                                                &#160;
                                                                                <asp:TextBox ID="Txt_Gross_Weight_LBS" runat="server" Width="80px" TabIndex="40"></asp:TextBox>&#160;(LBS)</div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: right">
                                                                            Mark No.1:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Txt_Mark_No1" runat="server" Width="192px" TabIndex="45"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td style="text-align: right">
                                                                            Mark No.2:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Txt_Mark_No2" runat="server" Width="192px" TabIndex="46"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: right">
                                                                            Mark No.3
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Txt_Mark_No3" runat="server" Width="192px" TabIndex="47"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td style="text-align: right">
                                                                            No. and Kind of PKG
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Txt_NoAndKingofPKG" runat="server" Width="192px" TabIndex="48"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &#160;&#160;
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
                                                            </asp:Panel>
                                                        </div>
                                                    </td>
                                                    <td width="8%">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;&nbsp;
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
                                <asp:RequiredFieldValidator ID="rfv_type" runat="server" ErrorMessage="Invoice Type is Required."
                                    Display="None" ControlToValidate="txt_Type"></asp:RequiredFieldValidator><AjaxToolkit:ValidatorCalloutExtender
                                        ID="rfv_type_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv_type"
                                        CssClass="customCalloutStyle" PopupPosition="TopRight">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv_year" runat="server" ErrorMessage="Invoice Year is Required."
                                    Display="None" ControlToValidate="txt_year"></asp:RequiredFieldValidator><AjaxToolkit:ValidatorCalloutExtender
                                        ID="rfv_year_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv_year"
                                        CssClass="customCalloutStyle" PopupPosition="TopRight">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv_invno" runat="server" ErrorMessage="Invoice Number is Required."
                                    Display="None" ControlToValidate="Txt_InvNumber"></asp:RequiredFieldValidator><AjaxToolkit:ValidatorCalloutExtender
                                        ID="rfv_invno_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv_invno"
                                        CssClass="customCalloutStyle" PopupPosition="TopRight">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv_invdate" runat="server" ErrorMessage="Invoice Date is Required."
                                    Display="None" ControlToValidate="Txt_invDate"></asp:RequiredFieldValidator><AjaxToolkit:ValidatorCalloutExtender
                                        ID="rfv_invdate_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv_invdate"
                                        CssClass="customCalloutStyle" PopupPosition="TopRight">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv_QsrInvoice" runat="server" ErrorMessage="Q. Sr. Invoice is Required."
                                    Display="None" ControlToValidate="Txt_QSrInv"></asp:RequiredFieldValidator><AjaxToolkit:ValidatorCalloutExtender
                                        ID="rfv_QsrInvoice_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv_QsrInvoice"
                                        CssClass="customCalloutStyle" PopupPosition="TopRight">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv_orderNo" runat="server" ErrorMessage="Please Select Sales Order Number."
                                    Display="None" ControlToValidate="Txt_orderno"></asp:RequiredFieldValidator><AjaxToolkit:ValidatorCalloutExtender
                                        ID="rfv_orderNo_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv_orderNo"
                                        CssClass="customCalloutStyle" PopupPosition="TopRight">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv_ETA" runat="server" ErrorMessage="ETA is Required."
                                    Display="None" ControlToValidate="Txt_ETA"></asp:RequiredFieldValidator><AjaxToolkit:ValidatorCalloutExtender
                                        ID="rfv_ETA_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv_ETA"
                                        CssClass="customCalloutStyle" PopupPosition="TopRight">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv_ETD" runat="server" ErrorMessage="ETD is Required."
                                    Display="None" ControlToValidate="Txt_ETD"></asp:RequiredFieldValidator><AjaxToolkit:ValidatorCalloutExtender
                                        ID="rfv_ETD_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="rfv_ETD"
                                        CssClass="customCalloutStyle" PopupPosition="TopRight">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                            </ContentTemplate>
                        </AjaxToolkit:TabPanel>
                        <AjaxToolkit:TabPanel runat="server" CssClass="tabControl" HeaderText="Additional Info."
                            ID="TPAdditionalInfo">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr>
                                        <td width="15%">
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td width="15%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="text-align: left">
                                            Terms of Delivery and Payment:
                                        </td>
                                        <td rowspan="3">
                                            <asp:TextBox ID="Txt_terms_of_deliveryPayment" runat="server" TextMode="MultiLine"
                                                Width="350px" TabIndex="1" onKeyDown="limitText(this,this.form.countdown1,200);"
                                                onKeyUp="limitText(this,this.form.countdown1,200);"></asp:TextBox><br />
                                        </td>
                                        <td rowspan="3">
                                            <font size="1px">(Maximum characters: 200)<br />
                                                You have
                                                <input name="countdown1" readonly="readonly" size="3" style="font-size: 10px" type="text"
                                                    value="200"> </input>
                                                characters left.</font>
                                        </td>
                                    </tr>
                                    <tr>
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
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="text-align: right">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="text-align: left">
                                            Description of Goods:
                                        </td>
                                        <td rowspan="3">
                                            <asp:TextBox ID="Txt_Description_of_goods" runat="server" TextMode="MultiLine" Width="350px"
                                                TabIndex="3" onKeyDown="limitText(this,this.form.countdown2,200);" onKeyUp="limitText(this,this.form.countdown2,200);"></asp:TextBox>
                                            <br>
                                        </td>
                                        <td rowspan="3">
                                            <font size="1px">(Maximum characters: 200)<br />
                                                You have
                                                <input name="countdown2" readonly="readonly" size="3" style="font-size: 10px" type="text"
                                                    value="200"> </input>
                                                characters left.</font>
                                        </td>
                                    </tr>
                                    <tr>
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
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="text-align: left">
                                            Footer Description:
                                        </td>
                                        <td rowspan="3">
                                            <asp:TextBox ID="txt_footerdescription" runat="server" TextMode="MultiLine" Width="350px"
                                                TabIndex="4" onKeyDown="limitText(this,this.form.countdown3,200);" onKeyUp="limitText(this,this.form.countdown3,200);"></asp:TextBox>
                                        </td>
                                        <td rowspan="3">
                                            <font size="1px">(Maximum characters: 200)<br />
                                                You have
                                                <input name="countdown3" readonly="readonly" size="3" style="font-size: 10px" type="text"
                                                    value="200"> </input>
                                                characters left.</font>
                                        </td>
                                    </tr>
                                    <tr>
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
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="text-align: left">
                                            Special Instruction:
                                        </td>
                                        <td rowspan="3">
                                            <asp:TextBox ID="txt_specialInstruction" runat="server" TextMode="MultiLine" Width="350px"
                                                TabIndex="5" onKeyDown="limitText(this,this.form.countdown4,200);" onKeyUp="limitText(this,this.form.countdown4,200);"></asp:TextBox>
                                        </td>
                                        <td rowspan="3">
                                            <font size="1px">(Maximum characters: 200)<br />
                                                You have
                                                <input name="countdown4" readonly="readonly" size="3" style="font-size: 10px" type="text"
                                                    value="200"> </input>
                                                characters left.</font>
                                        </td>
                                    </tr>
                                    <tr>
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
                                        <td style="text-align: left">
                                            Footer Packing:
                                        </td>
                                        <td rowspan="3">
                                            <asp:TextBox ID="Txt_footer_packing" runat="server" TextMode="MultiLine" Width="350px"
                                                TabIndex="6" onKeyDown="limitText(this,this.form.countdown5,200);" onKeyUp="limitText(this,this.form.countdown5,200);"></asp:TextBox>
                                        </td>
                                        <td rowspan="3">
                                            <font size="1px">(Maximum characters: 200)<br />
                                                You have
                                                <input name="countdown5" readonly="readonly" size="3" style="font-size: 10px" type="text"
                                                    value="200"> </input>
                                                characters left.</font>
                                        </td>
                                    </tr>
                                    <tr>
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
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </AjaxToolkit:TabPanel>
                    </AjaxToolkit:TabContainer>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_SOid" runat="server" Text="" Visible="false"></asp:Label><asp:Label
                        ID="lbl_PIID" runat="server" Text="" Visible="false"></asp:Label><asp:Label ID="lbl_customerid"
                            runat="server" Text="" Visible="false"></asp:Label><asp:Label ID="lbl_ConsigneeID"
                                runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lbl_deliveryID" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lbl_currencyId" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lbl_FinalDestID" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="Panel2" runat="server" Height="400px" Width="650px" CssClass="modalPopup">
        <asp:Panel ID="Panel3" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" /></div>
                    </td>
                    <td valign="top">
                        <div style="float: right; padding: 10px 10px 0 0">
                            <asp:ImageButton ID="Button1" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="margin-left: 20px; margin-right: 20px">
            <table width="100%" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>
                        <div class="in_menu_head">
                            Invoice</div>
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
                                AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="Invoiceid"
                                OnSelectedIndexChanged="gridMaster_SelectedIndexChanged" CssClass="GridViewStyle"
                                OnPageIndexChanged="gridMaster_PageIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                    <asp:BoundField DataField="InvoiceDate" DataFormatString="{0:d}" HeaderText="Invoice Date" />
                                    <asp:BoundField DataField="CustomerCode" HeaderText="CustomerCode" />
                                    <asp:BoundField DataField="InvoiceYear" HeaderText="Invoice Year" />
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
    <AjaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1"
        PopupControlID="Panel2" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="Button1" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="lPopUpHeader" runat="server" Text=""></asp:Label></div>
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
                            Height="20px" Width="20px" CausesValidation="False" OnClick="Img_btn_search_lookup_Click1" />
                        <br />
                        <br />
                        <asp:Panel ID="Panel6" runat="server" Height="245px" Width="605px" ScrollBars="Auto">
                            <asp:GridView ID="GridLookup" runat="server" AllowPaging="True" Width="100%" EmptyDataText="No  Result match your search criteria."
                                ShowHeaderWhenEmpty="True" DataKeyNames="SalesOrderId" CssClass="GridViewStyle"
                                AutoGenerateColumns="false" PageSize="7" OnSelectedIndexChanged="GridLookup_SelectedIndexChanged"
                                OnPageIndexChanged="GridLookup_PageIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SONo" HeaderText="Sales Order No" />
                                    <asp:BoundField DataField="SODate" DataFormatString="{0:d}" HeaderText="Date" />
                                    <asp:BoundField DataField="SOFYear" HeaderText="Year" />
                                    <asp:BoundField DataField="CustomerCode" HeaderText="Customer" />
                                    <asp:BoundField DataField="ConsigneeCode" HeaderText="Consignee" />
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
    <AjaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label2"
        PopupControlID="Pnl_lookUp" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel5" CancelControlID="btn_cancel2" />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Contentbutton" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ImageButton ID="btnUpdate" runat="server" AlternateText="Update" ImageUrl="~/Images/btn_update.png"
        OnClick="btnUpdate_Click" />
    <asp:ImageButton ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click"
        ImageUrl="~/Images/btnSave.png" />&nbsp;&nbsp;
    <asp:ImageButton ID="BtnCancel" runat="server" Text="Cancel" ImageUrl="~/Images/btnCancel.png"
        OnClick="BtnCancel_Click" />&nbsp;&nbsp;
    <asp:ImageButton ID="Btn_Exit" runat="server" Text="Exit" ImageUrl="~/Images/btnExit.png"
        OnClientClick="window.close();" />
    &nbsp;
</asp:Content>
<asp:Content ID="ContentTasks" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <InvTasks:Sales ID="InvTasks" runat="server" /></asp:Content>

