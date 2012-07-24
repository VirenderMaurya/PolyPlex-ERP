<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="ChipsProductionCPBP.aspx.cs"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>
<%--<%@ Register src="../Controls/DateTimeChooser.ascx" tagname="DateTimeChooser" tagprefix="uc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="height: auto; position: relative;">
        <table style="width: 100%;">
            <tr valign="bottom">
                <td style="height: 20px">
                    <asp:Label ID="lblInfo" ForeColor="Red" runat="server"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TabContainer ID="TCPetJumbo" runat="server" Width="100%" 
                        ActiveTabIndex="0">
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Chips Countinuess Production Details"
                            ID="TPChipsCountinuess">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 4%">
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="INPUT:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label53" runat="server" Text="Process:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlProcess" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Text="Year:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtYear" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right" id="TDVoucherNo" runat="server">
                                            <asp:Label ID="Label1" runat="server" Text="Voucher No.:"></asp:Label>
                                        </td>
                                        <td id="TDtxtVoucherNo" runat="server">
                                            <asp:TextBox ID="txtVoucherNo" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" Text="Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" Text="Date From:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateFrom" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                                                ID="imgBtnDateFrom" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom" PopupButtonID="imgBtnDateFrom"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" Text="Time From:"></asp:Label>
                                        </td>
                                        <td>
                                            <timesel:TimeSelector ID="tsTimeFrom" DisplaySeconds="False" runat="server" SelectedTimeFormat="TwentyFour"
                                                AmPm="PM" BorderColor="Silver" Hour="0" Minute="0" Second="0" Date="">
                                            </timesel:TimeSelector>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" Text="Date To:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateTo" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                                                ID="imgBtnDateTo" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo" PopupButtonID="imgBtnDateTo"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text="Time To:"></asp:Label>
                                        </td>
                                        <td>
                                            <timesel:TimeSelector ID="tsTimeTo" DisplaySeconds="False" runat="server" SelectedTimeFormat="TwentyFour"
                                                AmPm="PM" BorderColor="Silver" Date="" Hour="0" Minute="0" Second="0">
                                            </timesel:TimeSelector>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label12" runat="server" Text="PTA:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPTA" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label13" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantity" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label14" runat="server" Text="MEG:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMEG" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label15" runat="server" Text="Virgin Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVirginQuantity" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label16" runat="server" Text="Batch EG:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBatchEG" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label17" runat="server" Text="Hot Well Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHotWellQuantity" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label18" runat="server" Text="ATA/ATO:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtATAATO" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label19" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityATA" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label20" runat="server" Text="Item Code 1:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemCode1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label21" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityItemCode1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label22" runat="server" Text="Item Code 2:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemCode2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label23" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityItemCode2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label26" runat="server" Text="Item Code 3:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemCode3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label27" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityItemCode3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label28" runat="server" Text="Item Code 4:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemCode4" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label29" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityItemCode4" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label30" runat="server" Text="Item Code 5:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemCode5" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label31" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityItemCode5" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label32" runat="server" Text="Item Code 6:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemCode6" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label33" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityItemCode6" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label34" runat="server" Text="Item Code 7:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemCode7" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label35" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityItemCode7" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label36" runat="server" Text="Item Code 8:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemCode8" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label37" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityItemCode8" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="OUTPUT:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label38" runat="server" Text="Output Code 1:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOutputCode1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label39" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityOutputCode1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label40" runat="server" Text="Output Code 2:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOutputCode2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label41" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityOutputCode2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label42" runat="server" Text="Output Code 3:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOutputCode3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label43" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityOutputCode3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label45" runat="server" Text="Output Code 4:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOutputCode4" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label46" runat="server" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantityOutputCode4" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label47" runat="server" Text="Crude MEG Quantity:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCrudeMEGQuantity" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label49" runat="server" Text="Water:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWater" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="right">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="WASTE:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label121" runat="server" Text="Lumps:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLumps" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label122" runat="server" Text="Over Size:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOverSize" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label123" runat="server" Text="Residue:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtResidue" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label124" runat="server" Text="PTA:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPTAWaste" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label125" runat="server" Text="Non Usable Chips:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNonUsableChips" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label126" runat="server" Text="MEG:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMEGWaste" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label127" runat="server" Text="Silica:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSilica" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label128" runat="server" Text="Catalyst:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCatalyst" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Break Down Details"
                            ID="TPBreakDownDetails">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 4%">
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label58" runat="server" Font-Bold="True" Text="BREAK DOWN ENTRY:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label60" runat="server" Text="Department:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" Width="82%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label61" runat="server" Text="Machine:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMachine" runat="server" Width="82%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label62" runat="server" Text="Sub-Machine:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubMachineId" runat="server" Width="82%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label63" runat="server" Text="KK Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlKKType" runat="server" Width="82%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label25" runat="server" Text="Problem Code:"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlProblemCode" runat="server" Width="94%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
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
                                        <td align="right">
                                            <asp:Label ID="Label65" runat="server" Text="Start Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStartDate" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                                                ID="imgBtnStartDate" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="CalendarExtender3" runat="server" TargetControlID="txtStartDate" PopupButtonID="imgBtnStartDate"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label24" runat="server" Text="End Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndDate" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                                                ID="ImageButtonEndDate" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="CalendarExtender4" runat="server" TargetControlID="txtEndDate" PopupButtonID="ImageButtonEndDate"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label44" runat="server" Text="Start Time:"></asp:Label>
                                        </td>
                                        <td>
                                            <timesel:TimeSelector ID="tsStartTime" DisplaySeconds="False" runat="server" SelectedTimeFormat="TwentyFour"
                                                AmPm="PM" BorderColor="Silver" Hour="0" Minute="0" Second="0" Date="">
                                            </timesel:TimeSelector>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label64" runat="server" Text="End Time:"></asp:Label>
                                        </td>
                                        <td>
                                            <timesel:TimeSelector ID="tsEndTime" DisplaySeconds="False" runat="server" SelectedTimeFormat="TwentyFour"
                                                AmPm="PM" BorderColor="Silver" Hour="0" Minute="0" Second="0" Date="">
                                            </timesel:TimeSelector>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td colspan="2">
                                            <asp:CheckBox ID="chkHasItAffected" runat="server" Text="Has it affected the process." />
                                        </td>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <asp:Label runat="server" Text="Details of Observation:" ID="Label48"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox runat="server" TabIndex="27" Width="96%" TextMode="MultiLine" ID="txtDetailofObservations"></asp:TextBox>
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
            <tr align="center">
                <td>
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" TabIndex="5"
                        ImageUrl="~/Images/btnSave.png" onclick="ImgBtnSave_Click"  />
                    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        OnClientClick="window.close();" TabIndex="5" ImageUrl="~/Images/btnCancel.png" />
                    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hidAutoId" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="750px" CssClass="modalPopup"
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
                            Chips Production CP/BP List</div>
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
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Submit" 
                                        CausesValidation="false" onclick="btnSearchlist_Click"
                                         />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvChipsProductionCPBPAll" runat="server" 
                            AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="3" 
                            onpageindexchanging="gvChipsProductionCPBPAll_PageIndexChanging" 
                            onrowcommand="gvChipsProductionCPBPAll_RowCommand" >
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VoucherNo" HeaderText="Voucher No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProcessName" HeaderText="Process Name">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Date" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Year" HeaderText="Year">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
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
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    
</asp:Content>--%>
