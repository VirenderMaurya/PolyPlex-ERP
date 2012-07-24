<%@ Page Title="" Language="C#" MasterPageFile="~/Sales/PolyplexMasterTwoSection.master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="ProformaInvoice.aspx.cs"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controls/ProformaInvoiceTasks.ascx" tagname="ProformaInvoiceTasks" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" language="javascript">

        function CalculateWidthInInch() {

            if (window.document.getElementById('<%=ddlWidthinMM.ClientID %>').value != "") {

                var numWidthinMM = parseFloat(window.document.getElementById('<%=ddlWidthinMM.ClientID %>').value) * 0.0393700787;
                document.getElementById('<%=txtWidthinInch.ClientID %>').value = numWidthinMM.toFixed(2);
            }
            else {
                document.getElementById('<%=txtWidthinInch.ClientID %>').value = "0";
            }
        }

        function CalculateLengthInFeet() {

            if (window.document.getElementById('<%=txtLengthinMtr.ClientID %>').value != "") {

                var numLengthInFeet = parseFloat(window.document.getElementById('<%=txtLengthinMtr.ClientID %>').value) / 0.3038;
                document.getElementById('<%=txtlengthinFt.ClientID %>').value = numLengthInFeet.toFixed(2);
            }
            else {
                document.getElementById('<%=txtlengthinFt.ClientID %>').value = "0";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="overflow: auto; height: auto; position: relative;">
        <table style="width: 100%;">
            <tr valign="bottom">
                <td style="height: 20px">
                    <asp:Label ID="lblInfo" ForeColor="Red" runat="server"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TabContainer ID="TCPerformaInvoice" runat="server" Width="100%" 
                        ActiveTabIndex="1">
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Header" ID="TPHeader">
                            <ContentTemplate>
                                <table width="99%" cellspacing="6px">
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
                                            <asp:Label ID="Label1" runat="server" Text=" PI Type:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPIType" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Text=" PI Year:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPiYear" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right" id="TDPINo" runat="server">
                                            <asp:Label ID="Label51" runat="server" Text=" PI No:"></asp:Label>
                                        </td>
                                        <td id="TDtxtPINo" runat="server">
                                            <asp:TextBox ID="txtPiNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label52" runat="server" Text=" PI Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPiDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label53" runat="server" Text=" Customer Code:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerCode" runat="server" TabIndex="27" Width="80%" ValidationGroup="1"></asp:TextBox>
                                            <asp:ImageButton
                                                ID="imgCustomerCode" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                                TabIndex="8" OnClick="imgCustomerCode_Click" CausesValidation="False" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label54" runat="server" Text=" Consignee:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConsignee" runat="server" TabIndex="27" Width="80%" ValidationGroup="1"></asp:TextBox>
                                            <asp:ImageButton
                                                ID="imgConsignee" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                                TabIndex="8" OnClick="imgConsignee_Click" CausesValidation="False" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label55" runat="server" Text=" Delivery To:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDeliveryTo" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label96" runat="server" Text=" Customer Name:"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtCustomerName" runat="server" TabIndex="27" Width="94%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label58" runat="server" Text=" Final Destination:"></asp:Label><span
                                                style="color: Red; font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFinalDestination" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label59" runat="server" Text=" Delivery Tolerance:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDeliveryTolerance" runat="server" Width="84%">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label60" runat="server" Text=" Terms of Delivery:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTermsofDelivery" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:ImageButton
                                                ID="imgTermsofDelivery" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                                TabIndex="8" OnClick="imgTermsofDelivery_Click" CausesValidation="False" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label61" runat="server" Text=" Logistics:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLogistic" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label62" runat="server" Text=" Currency:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCurrency" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label63" runat="server" Text=" Payment Mode:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPaymentMode" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label64" runat="server" Text=" Certificates:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCertificates" runat="server" Width="84%">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label65" runat="server" Text=" No. of Shipments:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoofShipments" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                                FilterType="Numbers" TargetControlID="txtNoofShipments">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label66" runat="server" Text=" Packing Standard:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPackingStandard" runat="server" Width="84%">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label67" runat="server" Text=" Remittance Days:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRemittanceDays" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                                FilterType="Numbers" TargetControlID="txtRemittanceDays">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label68" runat="server" Text=" Credit Days:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCreditDays" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True"
                                                FilterType="Numbers" TargetControlID="txtCreditDays">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label69" runat="server" Text=" Film Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFilmType" runat="server" Width="84%">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" Text=" Customer Order No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerOrderNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" Text=" Customer Article No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerArticleNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" Text=" Customer Part No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerPartNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label95" runat="server" Text=" Customer Order Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerOrderDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox><asp:ImageButton
                                                    ID="imgBtnCustomerOrderDate" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                        ID="calExtenderCustomerOrderDate" runat="server" TargetControlID="txtCustomerOrderDate"
                                                        PopupButtonID="imgBtnCustomerOrderDate" Format="MM/dd/yyyy" Enabled="True">
                                                    </asp:CalendarExtender>
                                            </td>
                                        <td align="right">
                                            <asp:Label ID="Label70" runat="server" Text=" Unit of Sales:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnitofSale" runat="server" ValidationGroup="1" 
                                                Width="84%">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text=" Sales Area:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                            </td>
                                        <td>
                                               
                                            <asp:DropDownList ID="ddlSalesArea" runat="server" ValidationGroup="1"  AutoPostBack ="true" 
                                                Width="84%" onselectedindexchanged="ddlSalesArea_SelectedIndexChanged">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                               
                                        </td>
                                        <td>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" Text=" Sales Organization:"></asp:Label><span style="color: Red;
                                                font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSalesOrganization" runat="server" Width="84%" AutoPostBack ="true" 
                                                ValidationGroup="1" 
                                                onselectedindexchanged="ddlSalesOrganization_SelectedIndexChanged">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" Text=" Distribution Channel:"></asp:Label>
                                            <span style="color: Red; font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDistributionChannel" runat="server" Width="84%"  AutoPostBack ="True"
                                                ValidationGroup="1" 
                                                onselectedindexchanged="ddlDistributionChannel_SelectedIndexChanged">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" Text="Profit Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtProfitCenter" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label71" runat="server" Text=" Special Instruction:"></asp:Label>
                                        </td>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtSpecialInstruction" MaxLength="250" runat="server" TabIndex="40"
                                                TextMode="MultiLine" Width="96%"></asp:TextBox>
                                        </td>
                                        <td>
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
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="center">
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
                                <div>
                                    <asp:RequiredFieldValidator ID="RFVPIType" runat="server" ErrorMessage=" PI Type is mandatory."
                                        Display="None" ControlToValidate="ddlPIType" ValidationGroup="1" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCLPIType" runat="server" Enabled="True" TargetControlID="RFVPIType">
                                        </asp:ValidatorCalloutExtender>
                                     <asp:RequiredFieldValidator ID="RFVCustomerCode" ValidationGroup="1" runat="server"
                                        ErrorMessage="CustomerCode is mandatory." Display="None" ControlToValidate="txtCustomerCode"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCECustomerCode" runat="server" Enabled="True" TargetControlID="RFVCustomerCode">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVConsignee" ValidationGroup="1" runat="server"
                                        ErrorMessage="Consignee is mandatory." Display="None" ControlToValidate="txtConsignee"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCEConsignee" runat="server" Enabled="True" TargetControlID="RFVConsignee"
                                            PopupPosition="BottomLeft">
                                        </asp:ValidatorCalloutExtender>

                                    <asp:RequiredFieldValidator ID="RFVDeliveryTo" runat="server" ErrorMessage="DeliveryTo is mandatory."
                                        Display="None" ControlToValidate="ddlDeliveryTo" ValidationGroup="1" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCEDeliveryTo" runat="server" Enabled="True" TargetControlID="RFVDeliveryTo">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVFinalDestination" runat="server" ErrorMessage="FinalDestination is mandatory."
                                        Display="None" ControlToValidate="ddlFinalDestination" ValidationGroup="1" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCEFinalDestination" runat="server" Enabled="True" TargetControlID="RFVFinalDestination">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVLogistic" runat="server" ErrorMessage="Logistic is mandatory."
                                        Display="None" ControlToValidate="ddlLogistic" ValidationGroup="1" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCELogistic" runat="server" Enabled="True" TargetControlID="RFVLogistic">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVCurrency" ValidationGroup="1" runat="server" ErrorMessage="Currency is mandatory."
                                        Display="None" ControlToValidate="ddlCurrency" SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCECurrency" runat="server" Enabled="True" TargetControlID="RFVCurrency">
                                        </asp:ValidatorCalloutExtender>
                                    
                                    <asp:RequiredFieldValidator ID="RFVPaymentMode" ValidationGroup="1" runat="server"
                                        ErrorMessage="PaymentMode is mandatory." Display="None" ControlToValidate="ddlPaymentMode"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCEPaymentMode" runat="server" Enabled="True" TargetControlID="RFVPaymentMode"
                                            PopupPosition="TopLeft">
                                        </asp:ValidatorCalloutExtender>

                                    <asp:RequiredFieldValidator ID="RFVUnitofSale" runat="server" ErrorMessage="UnitofSale is mandatory."
                                        Display="None" ControlToValidate="ddlUnitofSale" ValidationGroup="1" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="VCEUnitofSale" runat="server" Enabled="True" TargetControlID="RFVUnitofSale">
                                        </asp:ValidatorCalloutExtender>                                   
                                    
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="1" runat="server"
                                        ErrorMessage="Sales Area is mandatory." Display="None" ControlToValidate="ddlSalesArea"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1"
                                            PopupPosition="Left">
                                        </asp:ValidatorCalloutExtender>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="1" runat="server"
                                        ErrorMessage="Sales Organization is mandatory." Display="None" ControlToValidate="ddlSalesOrganization"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender9" runat="server" Enabled="True" 
                                        TargetControlID="RequiredFieldValidator2">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="1" runat="server"
                                        ErrorMessage="Distribution Channel is mandatory." Display="None" ControlToValidate="ddlDistributionChannel"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender10" runat="server" Enabled="True" 
                                        TargetControlID="RequiredFieldValidator3">
                                        </asp:ValidatorCalloutExtender>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="LineItems" ID="TPLineItem">
                            <ContentTemplate>
                                <table width="99%" cellspacing="8px">
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
                                            <asp:Label ID="Label24" runat="server" Text=" Line No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLineNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            
                                            <asp:Label ID="Label72" runat="server" Text=" Micron:"></asp:Label>
                                            <span style="color: Red; font-weight: bold">*</span>
                                        </td>
                                        <td>
                                           <asp:TextBox ID="txtMicron" runat="server" TabIndex="27" ValidationGroup="2" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label25" runat="server" Text="Sub Film Type:"></asp:Label>
                                            <span style="color: Red; font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            
                                            <asp:DropDownList ID="ddlSubFilmType" runat="server" ValidationGroup="2" Width="84%">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label74" runat="server" Text=" Core:"></asp:Label>
                                            <span style="color: Red; font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCore" runat="server" TabIndex="27" ValidationGroup="2" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label75" runat="server" Text=" Width(MM):"></asp:Label>
                                            <span style="color: Red; font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlWidthinMM" runat="server" ValidationGroup="2" AutoPostBack ="True"
                                                Width="84%" onselectedindexchanged="ddlWidthinMM_SelectedIndexChanged">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label76" runat="server" Text=" Width(Inch):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWidthinInch" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label77" runat="server" Text=" Length(Mtr):"></asp:Label>
                                            <span style="color: Red; font-weight: bold">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLengthinMtr" runat="server" AutoPostBack="True" ValidationGroup="2"
                                                TabIndex="27" Width="80%" OnTextChanged="txtLengthinMtr_TextChanged"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True"
                                                FilterType="Custom, Numbers" TargetControlID="txtLengthinMtr" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                                CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator2">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLengthinMtr"
                                                Display="None" ErrorMessage="Enter a valid length. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label78" runat="server" Text=" Length(Ft):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtlengthinFt" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label79" runat="server" Text=" Unit Price:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUnitPrice" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" Enabled="True"
                                                FilterType="Custom, Numbers" TargetControlID="txtUnitPrice" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" PopupPosition="Left"
                                                runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator3">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUnitPrice"
                                                Display="None" ErrorMessage="Enter a valid price. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label80" runat="server" Text=" No. of Roles:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoofRoles" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True"
                                                FilterType="Numbers" TargetControlID="txtNoofRoles">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label81" runat="server" Text=" Required Quantity (Kg):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRequiredQuantity" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="flteradjvat" runat="server" Enabled="True" FilterType="Custom, Numbers"
                                                TargetControlID="txtRequiredQuantity" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" PopupPosition="Left"
                                                runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator4">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRequiredQuantity"
                                                Display="None" ErrorMessage="Enter a valid quantity. (Only three digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label82" runat="server" Text=" Estimated Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEstimatedDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:ImageButton ID="imgBtnEstimatedDate" ValidationGroup="aa" runat="server" ImageUrl="~/images/cal.gif" />
                                            <asp:CalendarExtender ID="ceEstimatedDate" runat="server" TargetControlID="txtEstimatedDate"
                                                PopupButtonID="imgBtnEstimatedDate" Format="MM/dd/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label83" runat="server" Text=" Application:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApplication" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label84" runat="server" Text=" COF (Min):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCofMin" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" Enabled="True"
                                                FilterType="Custom, Numbers" TargetControlID="txtCofMin" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" PopupPosition="Left"
                                                runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator5">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCofMin"
                                                Display="None" ErrorMessage="Enter a valid Cof Min. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label85" runat="server" Text=" COF (Max):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCofMax" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" Enabled="True"
                                                FilterType="Custom, Numbers" TargetControlID="txtCofMax" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" PopupPosition="Left"
                                                runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator6">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtCofMax"
                                                Display="None" ErrorMessage="Enter a valid Cof Max. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label86" runat="server" Text=" OD (Min):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOdMin" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" Enabled="True"
                                                FilterType="Custom, Numbers" TargetControlID="txtOdMin" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator7">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtOdMin"
                                                Display="None" ErrorMessage="Enter a valid Cof Min. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label87" runat="server" Text=" OD (Avg):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOdAvg" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" Enabled="True"
                                                FilterType="Custom, Numbers" TargetControlID="txtOdAvg" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" PopupPosition="Left"
                                                runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator8">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtOdAvg"
                                                Display="None" ErrorMessage="Enter a valid OD Avg. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label88" runat="server" Text=" OD (Max):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOdMax" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" Enabled="True"
                                                FilterType="Custom, Numbers" TargetControlID="txtOdMax" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" PopupPosition="Left"
                                                runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator9">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtOdMax"
                                                Display="None" ErrorMessage="Enter a valid OD Max. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label89" runat="server" Text=" Shipment No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtShipmentNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                        <asp:Label ID="Label97" runat="server" Text=" Pallet Type:"></asp:Label>
                                            </td>
                                        <td>
                                        <asp:TextBox ID="txtPalletType" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                           </td>
                                        <td align="right">
                                        <asp:Label ID="Label98" runat="server" Text=" No. of Rolls in Pallet:"></asp:Label>
                                            </td>
                                        <td>
                                        <asp:TextBox ID="txtNoofRolesinPallet" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" Enabled="True"
                                                    FilterType="Numbers" TargetControlID="txtNoofRolesinPallet">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        <td>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label93" runat="server" Text=" Include:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkInclude" runat="server" TabIndex="36" />
                                        </td>
                                        <td align="right">
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
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
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <asp:ImageButton ID="ImgBtnAddLine" runat="server" Text="Cancel" ValidationGroup="2" TabIndex="5" ImageUrl="~/Images/btnAddLine.png"
                        OnClick="ImgBtnAddLine_Click" />
                                        </td>
                                        <td>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td runat="server" align="center" colspan="7" 
                                            style="border-bottom: solid 1px gray;
                                                border-collapse: collapse; color: #024B81; font-weight: bold; font-size: x-small;">
                                            Line Items
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" colspan="7">
                                            <div style="overflow: auto; height: 100%; width: 900px; position: relative;">
                                                <asp:GridView ID="gvLineItems" runat="server" AutoGenerateColumns="False" 
                                                    CssClass="GridViewStyle" EmptyDataText="No Record Found." 
                                                    OnRowCommand="gvLineItems_RowCommand" OnRowDataBound="gvLineItems_RowDataBound" 
                                                    OnRowDeleting="gvLineItems_RowDeleting" ShowHeaderWhenEmpty="True" Width="100%">
                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                                                        CommandArgument='<%#Eval("PerformaInvoiceID") %>' CommandName="select" 
                                                                        ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                                                </center>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="LineItemID" HeaderText="LineItemID">
                                                        <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LineNo" HeaderText="LineNo">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="SubFilmTypeName" HeaderText="SubFilmType">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Micron" HeaderText="Micron">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Core" HeaderText="Core">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="WidthInMMName" HeaderText="WidthInMM">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="WidthInInch" HeaderText="WidthInInch">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="LengthInMtr" HeaderText="LengthInMtr">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LengthInFt" HeaderText="LengthInFt">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NoOfRolls" HeaderText="NoOfRolls">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="ReqQuantityInKG" HeaderText="ReqQuantityInKG">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EstimatedDate" DataFormatString="{0:MM/dd/yyyy}" 
                                                            HeaderText="EstimatedDate">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Application" HeaderText="Application">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COFMin" HeaderText="COFMin">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COFMax" HeaderText="COFMax">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="ODMin" HeaderText="ODMin">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ODAvg" HeaderText="ODAvg">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ODMax" HeaderText="ODMax">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ShipmentNo" HeaderText="ShipmentNo">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Include" HeaderText="Include">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="PalletType" HeaderText="PalletType">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NoofRollsInPallet" HeaderText="NoofRollsInPallet">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ActiveStatus" HeaderText="ActiveStatus">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ibtnDelete" runat="server" CausesValidation="false" 
                                                                    CommandName="Delete" ImageUrl="~/Images/delete.gif" 
                                                                    OnClientClick="javascript:return confirm('Are you sure to delete?');" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="10px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="SubFilmType" HeaderText="SubFilmType">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="WidthInMM" HeaderText="WidthInMM">
                                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:BoundField>

                                                    </Columns>
                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                                                        Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                                    <PagerStyle BackColor="#C6C3C6" CssClass="PagerStyle" ForeColor="Black" 
                                                        HorizontalAlign="Left" />
                                                    <RowStyle CssClass="RowStyle" />
                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                </asp:GridView>
                                            </div>
                                            <asp:HiddenField ID="hidLineItemId" runat="server" />
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
                                <div>
                                    
                                    <asp:RequiredFieldValidator ID="RFVMicron" ValidationGroup="2" runat="server" ErrorMessage="Micron is mandatory."
                                        Display="None" ControlToValidate="txtMicron" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="VCEMicron" PopupPosition="Left" runat="server"
                                        Enabled="True" TargetControlID="RFVMicron">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVType" runat="server" ErrorMessage="Sub Film Type is mandatory."
                                        Display="None" ControlToValidate="ddlSubFilmType" ValidationGroup="2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="VCEType" runat="server" Enabled="True" PopupPosition="Left"
                                        TargetControlID="RFVType">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVCore" ValidationGroup="2" runat="server" ErrorMessage="Core is mandatory."
                                        Display="None" ControlToValidate="txtCore" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="VCECore" runat="server" Enabled="True" TargetControlID="RFVCore">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVWidthInMM" ValidationGroup="2" runat="server"
                                        ErrorMessage="Width (In MM) is mandatory." Display="None" ControlToValidate="ddlWidthinMM"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="VCEWidthInMM" runat="server" Enabled="True" TargetControlID="RFVWidthInMM">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVLengthInMtr" ValidationGroup="2" runat="server"
                                        ErrorMessage="Length (In Mtr) is mandatory." Display="None" ControlToValidate="txtLengthinMtr"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="VCELengthInMtr" runat="server" Enabled="True" TargetControlID="RFVLengthInMtr">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hidCustomerId" runat="server" />
                    <asp:HiddenField ID="hidConsigneeId" runat="server" />
                    <asp:HiddenField ID="hidTermsOfDeliveryId" runat="server" />
                    <asp:HiddenField ID="HidAddLineBtn" runat="server" />
                    <asp:HiddenField ID="HidUpdateGridRecord" runat="server" />
                    <asp:HiddenField ID="hidRowIndex" runat="server" />
                    <asp:HiddenField ID="hidIsDelete" runat="server" />
                    <asp:HiddenField ID="HidPerformaInvoiceId" runat="server" />
                    <asp:HiddenField ID="HidNewValue" runat="server" />
                    <asp:HiddenField ID="HidPopUpType" runat="server" />
                    <asp:HiddenField ID="HidProfitCenterId" runat="server" />
                    <asp:HiddenField ID="HidMaterialCode" runat="server" />
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
                            Proforma Invoice List</div>
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
                        <asp:GridView ID="gvProformaInvoice" runat="server" AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            OnRowCommand="gvProformaInvoice_RowCommand" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvProformaInvoice_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("PerformaInvoiceID") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PINo" HeaderText="PI No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PIType" HeaderText="PI Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PINewDate" HeaderText="PI Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerCode" HeaderText="Customer">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ConsigneeName" HeaderText="Consignee">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeliveryToName" HeaderText="Delivery To">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CurrencyCode" HeaderText="Currency">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>                                
                                <asp:BoundField DataField="LogisticName" HeaderText="Logistics">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FinalDestinationName" HeaderText="Final Destination">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StatusCode" HeaderText="Status Code">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
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
                        <asp:GridView ID="gvPopUpGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            PageSize="5" EnableColumnViewState="false" Width="100%" OnRowCommand="gvPopUpGrid_RowCommand"
                            OnRowDataBound="gvPopUpGrid_RowDataBound" OnPageIndexChanging="gvPopUpGrid_PageIndexChanging">
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
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
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
    <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" OnClick="ImgBtnSave_Click"
        TabIndex="5" ImageUrl="~/Images/btnSave.png" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
        OnClientClick="window.close();" TabIndex="5" ImageUrl="~/Images/btnCancel.png" />
</asp:Content>
<asp:Content ID="ContentTasks" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">  
    
    <uc2:ProformaInvoiceTasks ID="ProformaInvoiceTasks1" runat="server" />
    
    </asp:Content>
