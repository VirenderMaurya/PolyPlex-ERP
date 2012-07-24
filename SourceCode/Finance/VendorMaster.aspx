<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MastersPage.master" AutoEventWireup="true"
    CodeFile="VendorMaster.aspx.cs" Inherits="Finance_VendorMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script type="text/javascript">
<!--
     function userAction() {
         var bConfirm = window.confirm("Confirm Exit without saving changes?");

         document.getElementById('<%=hfConfirm.ClientID%>').value = bConfirm;
     }
//-->
    </script>
    <style type="text/css">
        .txtbx
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeading" runat="Server">
    Vendor Master
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScript" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
            <ajaxToolkit:TabContainer runat="server" ActiveTabIndex="0" TabStripPlacement="Top"
                ID="TabContCustomer" CssClass="myTabs" Width="100%">
                <ajaxToolkit:TabPanel runat="server" HeaderText="General" ID="tabGeneral" Height="440px">
                    <ContentTemplate>
                        <asp:Panel ID="pnl_general" runat="server">
                            <br />
                            <br />
                            <table width="100%" cellpadding="3px">
                                <tr>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Vendor Code:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td style="width: 17%">
                                        <div align="left">
                                            <asp:TextBox ID="txtVendorCode" CssClass="txtbx" runat="server" Enabled="False" ValidationGroup="save"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Vendor Name:<span style="color: Red">*</span></div>
                                    </td>
                                    <td style="width: 17%">
                                        <div align="left">
                                            <asp:TextBox ID="txtVendorName" runat="server" ValidationGroup="save" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Vendor Group:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:DropDownList ID="ddvendorGroup" ValidationGroup="save" CssClass="txtbx" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Vendor Address:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtVendorAddress" ValidationGroup="save" TextMode="MultiLine" CssClass="txtbx"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Postal Code:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            City:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCity" CssClass="txtbx" runat="server" ValidationGroup="save"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Country:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCountry" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Region:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtRegion" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Telephone No:
                                        </div>
                                    </td>
                                    <td> <div align="left">
                                            <asp:TextBox ID="TxtTelephoneNo" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Telephone Extn.:
                                        </div>
                                    </td>
                                    <td>
                                         <div align="left">
                                            <asp:TextBox ID="txtTelephoneExtn" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Fax No:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtFaxNo" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Fax Extn.
                                        </div>
                                    </td>
                                    <td>
                                       <div align="left">
                                            <asp:TextBox ID="txtFaxExtn" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
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
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Company Email Address (1):
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <div align="left">
                                            <asp:TextBox ID="txtEmailaddd1" Width="300px" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
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
                                        <div align="right">
                                            Company Email Address (2):
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <div align="left">
                                            <asp:TextBox ID="txtEmailaddd2" Width="300px" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
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
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Contact Person one:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtContactPerson1" ValidationGroup="save" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Person one Contact No.:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtperson1no" runat="server" CssClass="txtbx"></asp:TextBox>
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
                                            Contact Person Two:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtContactPerson2" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Person Two Contact No.:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtperson2no" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Old FI Vendor Code:
                                        </div>
                                    </td>
                                    <td>
                                       <div align="left">
                                            <asp:TextBox ID="txtOldfivendorcode" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Type Company:
                                        </div>
                                    </td>
                                    <td>
                                         <div align="left">
                                            <asp:TextBox ID="txtTypeCompany" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <div>
                                <center>
                                    <asp:RequiredFieldValidator ID="rfvCCode" runat="server" ErrorMessage="Vendor Code is Required."
                                        Display="None" ControlToValidate="txtVendorCode"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="rfvCCode_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfvCCode" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vendor Name is Required." ControlToValidate="txtVendorName"
                                        Display="None"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vendor Group is Required."
                                        Display="None" ControlToValidate="ddvendorGroup"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vendor Address is Required."
                                        Display="None" ControlToValidate="txtVendorAddress"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="City is Required."
                                        Display="None" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                   
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Atleast One Contact Person is Required."
                                        Display="None" ControlToValidate="txtContactPerson1"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Incorrect Email Id."
                                        ControlToValidate="txtEmailaddd1" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RegularExpressionValidator1_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Incorrect Email Id."
                                        ControlToValidate="txtEmailaddd2" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RegularExpressionValidator2_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RegularExpressionValidator2" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                 
                                </center>
                            </div>
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Accounting" ID="tabAccounting" Height="440px">
                    <HeaderTemplate>
                        Accounting
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="pnl_accounting" runat="server">
                            <br />
                            <table width="100%" cellpadding="3px">
                                <tr>
                                    <td colspan="4">
                                        <center>
                                            <asp:Panel ID="pnl_accountingline" runat="server">
                                                <asp:GridView ID="gridAccountingLine" runat="server" AllowPaging="True" PageSize="4"
                                                    Width="60%" EmptyDataText="No Accounting Details added." ShowHeaderWhenEmpty="True"
                                                    AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="ID" OnSelectedIndexChanged="gridAccountingLine_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:ImageButton ID="imgAccgridsel" runat="server" CausesValidation="False" CommandName="Select"
                                                                        ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AccountingUnit" HeaderText="Accounting Unit" />
                                                        <asp:BoundField DataField="VendorBank" HeaderText="Vendor Bank" />
                                                        <asp:BoundField DataField="VendorRecoAccount" HeaderText="Vendor Reco Account" />
                                                        <asp:BoundField DataField="VendorBankCountry" HeaderText="Vendor Bank Country" />
                                                    </Columns>
                                                    <RowStyle CssClass="RowStyle" />
                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                    <PagerStyle CssClass="PagerStyle" />
                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 25%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 25%">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Accounting Unit:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtAccountingUnit" ValidationGroup="acc" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Vendor Bank:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtVendorBank" runat="server" ValidationGroup="acc" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Vendor Reco Account:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtVendorRecoAcc" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Vendor Bank Country:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtVendorBankCountry" runat="server" CssClass="txtbx"></asp:TextBox></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Vendor Bank Key:
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVendorBankKey" runat="server" CssClass="txtbx"></asp:TextBox>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Vendor Bank Account:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtVendorBankAccount" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Account Holder
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtAccountHolder" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                       <div align="right">
                                            Debit GL Code:
                                        </div>
                                    </td>
                                    <td>
                                         <div align="left">
                                            <asp:TextBox ID="txtDebitGLCode" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <center>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Accounting Unit is Required."
                                                Display="None" ControlToValidate="txtAccountingUnit"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Vendor Bank is Required."
                                                Display="Dynamic" ControlToValidate="txtVendorBank"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </center>
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
                                        <div align="right">
                                            <asp:ImageButton ID="btnAddAccountingDetails" runat="server" ImageUrl="~/Images/btnAdd.png"
                                                OnClick="btnAddAccountingDetails_Click" ValidationGroup="acc" />
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Purchase" ID="tabPurchase" Height="440px">
                    <ContentTemplate>
                        <asp:Panel ID="pnl_purchase" runat="server">
                            <br />
                            <br />
                            <table width="100%" cellpadding="3px">
                                <tr>
                                    <td colspan="4">
                                        <center>
                                            <asp:Panel ID="pnl_PurLine" runat="server">
                                                <asp:GridView ID="gridPurLine" runat="server" AllowPaging="True" PageSize="4" Width="60%"
                                                    EmptyDataText="No Purchase Details added." ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                                    DataKeyNames="ID" CssClass="GridViewStyle" OnSelectedIndexChanged="gridPurLine_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:ImageButton ID="imgSelect" runat="server" CausesValidation="False" CommandName="Select"
                                                                        ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PurchaseAreaDesc" HeaderText="Purchase Area" />
                                                        <asp:BoundField DataField="PaymentTermDesc" HeaderText="Payments Terms" />
                                                        <asp:BoundField DataField="IncoTerm" HeaderText="Inco Terms" />
                                                        <asp:BoundField DataField="CurrencyCode" HeaderText="ORDCurrency" />

                                                    </Columns>
                                                    <RowStyle CssClass="RowStyle" />
                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                    <PagerStyle CssClass="PagerStyle" />
                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 25%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 25%">
                                        &nbsp;
                                    </td>
                                    <td></td>
                                  
                                  
                                    
                                </tr>
                                <tr><td></td>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Purchase Area:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td style="width: 17%">
                                        <div align="left">
                                            <asp:DropDownList ID="ddPurchaseArea" ValidationGroup="sal" runat="server" CssClass="txtbx">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                  <td></td>
                                </tr>
                                <tr><td></td>
                                    <td>
                                        <div align="right">
                                            Payment Terms:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:DropDownList ID="ddPaymentsTerms" ValidationGroup="sal" runat="server" CssClass="txtbx">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                  <td></td>
                                </tr>
                                <tr><td></td>
                                    <td>
                                        <div align="right">
                                            Inco Term:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtincoterms" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr> <td>
                                        &nbsp;</td>
                                    <td>
                                       <div align="right">
                                            ORD Currency:<span style="color: Red">*</span>
                                        </div></td>
                                    <td>
                                       <div align="left">
                                            <asp:DropDownList ID="ddCurrency" runat="server" ValidationGroup="sal" CssClass="txtbx">
                                            </asp:DropDownList>
                                        </div></td>
                                   
                                    <td>
                                        &nbsp;</td>
                                    
                                </tr>
                                <tr><td></td>
                                    <td>
                                        <div align="right">
                                            ITex ID:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtItexid" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                   <td></td>
                                </tr>
                                <tr><td></td>
                                    <td>
                                        <div align="right">
                                            Nearest Sea Port:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtnearestseaport" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                   <td></td>
                                </tr>
                                <tr><td></td>
                                    <td>
                                        <div align="right">
                                            Nearest Air Port:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtnearestairport" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td><td></td>
                                   
                                </tr>
                                <tr><td></td>
                                    <td>
                                        <div align="right">
                                           VAT in Percentage:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtVatinPer" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                  <td></td>
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
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <center>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select a Purchase Area."
                                                Display="None" ControlToValidate="ddPurchaseArea"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select Payment Terms."
                                                Display="None" ControlToValidate="ddPaymentsTerms"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator10" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Select a Currency."
                                                Display="None" ControlToValidate="ddCurrency"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator11_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                           
                                        </center>
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
                                        <div align="right">
                                            <asp:ImageButton ID="btn_addPurchaseInfo" runat="server" ImageUrl="~/Images/btnAdd.png"
                                                OnClick="btn_addPurchaseInfo_Click" ValidationGroup="sal" />
                                        </div>
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
                                        &nbsp;
                                    </td>
                                   
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
            <asp:HiddenField ID="hf_Cid" runat="server" />
            <asp:HiddenField ID="hf_isNewRecord" runat="server" />
             <asp:HiddenField ID="hfConfirm" runat="server" />
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
                                    Vendor Master</div>
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
                                        DataKeyNames="VendorId" Width="100%" EmptyDataText="No  Result match your search criteria."
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
                                            <asp:BoundField DataField="VendorCode" HeaderText="Customer Code" />
                                            <asp:BoundField DataField="VendorName" HeaderText="Name" />
                                            <asp:BoundField DataField="City" HeaderText="City" />
                                            <asp:BoundField DataField="Country" HeaderText="Country" />
                                            
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
<asp:Content ID="con_button1" ContentPlaceHolderID="cphPreSaveUpdate" runat="server">
    <asp:ImageButton ID="btn_pre" runat="server" Text="Previous" ImageUrl="~/Images/btn_previous.png"
        OnClick="btn_pre_Click" CausesValidation="false" />
    <asp:ImageButton ID="btn_save" runat="server" Text="Save" ImageUrl="~/Images/btnSave.png"
        OnClick="btn_save_Click" ValidationGroup="save" />
</asp:Content>
<asp:Content ID="con_buttons2" ContentPlaceHolderID="cphNextCancel" runat="server">
    <asp:ImageButton ID="btn_nxt" CausesValidation="false" runat="server" Text="Next"
        ImageUrl="~/Images/btn_next.png" OnClick="btn_nxt_Click" />
    <asp:ImageButton ID="btn_cancel" runat="server" Text="Cancel" CausesValidation="false"
        ImageUrl="~/Images/btnCancel.png" OnClick="btn_cancel_Click" />
</asp:Content>
