<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MastersPage.master" AutoEventWireup="true"
    CodeFile="CustomerMaster.aspx.cs" Inherits="Sales_CustomerMaster" %>

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
    Customer Master
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScript" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
            <ajaxToolkit:TabContainer runat="server" ActiveTabIndex="3" TabStripPlacement="Top"
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
                                            Customer Code:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td style="width: 17%">
                                        <div align="left">
                                            <asp:TextBox ID="txtCustomerCode" CssClass="txtbx" runat="server" Enabled="False"
                                                ValidationGroup="save"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Name:<span style="color: Red">*</span></div>
                                    </td>
                                    <td style="width: 17%">
                                        <div align="left">
                                            <asp:TextBox ID="txtName" runat="server" ValidationGroup="save" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Customer Type:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:DropDownList ID="ddcustomertype" ValidationGroup="save" CssClass="txtbx" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Address:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtAddress" ValidationGroup="save" TextMode="MultiLine" CssClass="txtbx"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Country:<span style="color: Red">*</span></div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:DropDownList ID="ddCountry" ValidationGroup="save" CssClass="txtbx" runat="server">
                                            </asp:DropDownList>
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
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Telephone:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtTelephone" ValidationGroup="save" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Fax:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtFax" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Application:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtApplication" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Email:
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <div align="left">
                                            <asp:TextBox ID="txtEmail" Width="300px" CssClass="txtbx" runat="server"></asp:TextBox>
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
                                            Contact Person:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtContactPerson" ValidationGroup="save" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Designation:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Department:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtDepartment" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Contact Person Telephone:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtContactPerTelephone" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Contact Person Fax:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtContactPerFax" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Date of Birth:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtDOB" runat="server" Width="110px" CssClass="txtbx"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="Txt_Dob_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtDOB" PopupButtonID="ImageButton2">
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="False" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Contact Person Email:
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <div align="left">
                                            <asp:TextBox ID="txtContactPerEmail" Width="300px" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Anniversary:&nbsp;</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtAnniversary" runat="server" Width="110px" CssClass="txtbx"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtAnniversary" PopupButtonID="ImageButton3">
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/cal.gif" CausesValidation="False" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#160;&nbsp;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Account Dept Contact:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtAccountDeptcont" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Credit Limit:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCreditLimit" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Exim Limit:&nbsp;</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtEximLimit" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Account Dept Email:
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <div align="left">
                                            <asp:TextBox ID="txtAccountDeptEmail" Width="300px" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            &#160;</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <div>
                                <center>
                                    <asp:RequiredFieldValidator ID="rfvCCode" runat="server" ErrorMessage="Customer Code is Required."
                                        Display="None" ControlToValidate="txtCustomerCode"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="rfvCCode_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfvCCode" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Customer Name is Required."
                                        Display="None" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Customer Type is Required."
                                        Display="None" ControlToValidate="ddcustomertype"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Customer Address is Required."
                                        Display="None" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Customer Country is Required."
                                        Display="None" ControlToValidate="ddCountry"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Customer Telephone is Required."
                                        Display="None" ControlToValidate="txtTelephone"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Contact Person is Required."
                                        Display="None" ControlToValidate="txtContactPerson"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Incorrect Email Id."
                                        ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RegularExpressionValidator1_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Incorrect Email Id."
                                        ControlToValidate="txtContactPerEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RegularExpressionValidator2_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RegularExpressionValidator2" CssClass="customCalloutStyle">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Incorrect Email Id."
                                        ControlToValidate="txtAccountDeptEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RegularExpressionValidator3_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RegularExpressionValidator3" CssClass="customCalloutStyle">
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
                                                        <asp:BoundField DataField="CustomerBank" HeaderText="Customer Bank" />
                                                        <asp:BoundField DataField="CustomerRecoAccount" HeaderText="Customer Reco Account" />
                                                        <asp:BoundField DataField="CustomerBankCountry" HeaderText="Customer Bank Country" />
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
                                            Customer Bank:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCustomerBank" runat="server" ValidationGroup="acc" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Customer Reco Account:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCustomerRecoAcc" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Customer Bank Country:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCustomerBankCountry" runat="server" CssClass="txtbx"></asp:TextBox></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Customer Bank Key:
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCustomerBankKey" runat="server" CssClass="txtbx"></asp:TextBox>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Customer Bank Account:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCustomerBankAccount" runat="server" CssClass="txtbx"></asp:TextBox>
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
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Customer Bank is Required."
                                                Display="Dynamic" ControlToValidate="txtCustomerBank"></asp:RequiredFieldValidator>
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
                <ajaxToolkit:TabPanel runat="server" HeaderText="Sale" ID="tabSale" Height="440px">
                    <ContentTemplate>
                        <asp:Panel ID="pnl_sale" runat="server">
                            <br />
                            <br />
                            <table width="100%" cellpadding="3px">
                                <tr>
                                    <td colspan="6">
                                        <center>
                                            <asp:Panel ID="pnl_SaleLine" runat="server">
                                                <asp:GridView ID="gridSalLine" runat="server" AllowPaging="True" PageSize="4" Width="60%"
                                                    EmptyDataText="No Sales Details added." ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                                    DataKeyNames="ID" CssClass="GridViewStyle" OnSelectedIndexChanged="gridSalLine_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:ImageButton ID="imgSelect" runat="server" CausesValidation="False" CommandName="Select"
                                                                        ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="SalesAreaDesc" HeaderText="Sales Area" />
                                                        <asp:BoundField DataField="SalesTypeName" HeaderText="Sales Type" />
                                                        <asp:BoundField DataField="CurrencyCode" HeaderText="Currency" />
                                                        <asp:BoundField DataField="PaymentTermDesc" HeaderText="Payment Terms" />
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
                                    <td style="width: 16%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 17%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 16%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 17%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 16%">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Sales Area:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td style="width: 17%">
                                        <div align="left">
                                            <asp:DropDownList ID="ddSalesArea" ValidationGroup="sal" runat="server" CssClass="txtbx">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Sales Type:<span style="color: Red">*</span></div>
                                    </td>
                                    <td style="width: 17%">
                                        <div align="left">
                                            <asp:DropDownList ID="ddsalesType" runat="server" ValidationGroup="sal" CssClass="txtbx">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td style="width: 16%">
                                        <div align="right">
                                            Currency:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:DropDownList ID="ddCurrency" runat="server" ValidationGroup="sal" CssClass="txtbx">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
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
                                    <td>
                                        <div align="right">
                                            Level Of Trade:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtLevelOFTrade" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Final Detination:<span style="color: Red">*</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:DropDownList ID="ddFinalDestination" runat="server" ValidationGroup="sal" CssClass="txtbx">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Terms Of Delivery:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtTermsOfDelivery" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Groups:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtGroups" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Fumigation:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:CheckBox ID="chkFumination" runat="server" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            VAT:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtVAT" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Quality Certificate:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:CheckBox ID="chkQualityCertificate" runat="server" />
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Payment Mode:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtPaymentMode" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Delivery Tolerance:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtDeliveryTolerence" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Certificate Of Org:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:CheckBox ID="chkCertificateOfOrg" runat="server" />
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            GSP:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:CheckBox ID="chkGSP" runat="server" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Credit Days:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCreditDays" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Legalization:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtLegalization" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Packing:&nbsp;</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtPacking" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Sticker:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtSticker" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Invoicing Length:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtInvoiceLength" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Sales Office:&nbsp;</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtSalesOffice" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Cust Owner:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtCustOwner" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Pallets Stacking:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtPalletsStacking" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Length Tolerance:&nbsp;</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtLengthTolerence" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Agent Code:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtAgentCode" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Shipping Line Preference:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtShippingLinePrefrnce" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            PreShipping Inspection:&nbsp;</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtPreshippinginstructions" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="right">
                                            Packing Instruction:
                                        </div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtPackingInstruction" CssClass="txtbx" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="right">
                                            Specia lInstruction:</div>
                                    </td>
                                    <td>
                                        <div align="left">
                                            <asp:TextBox ID="txtSpInstruction" runat="server" CssClass="txtbx"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <div align="left">
                                        </div>
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
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <center>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select a Sales Area."
                                                Display="None" ControlToValidate="ddSalesArea"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select a Sales Type."
                                                Display="None" ControlToValidate="ddsalesType"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator10" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Select a Currency."
                                                Display="None" ControlToValidate="ddCurrency"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator11_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Select a Payment Term."
                                                Display="None" ControlToValidate="ddPaymentsTerms"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator12_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator12" CssClass="customCalloutStyle">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select a Final Destination."
                                                Display="None" ControlToValidate="ddFinalDestination"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator13_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator13" CssClass="customCalloutStyle">
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
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <div align="right">
                                            <asp:ImageButton ID="btn_addSaleInfo" runat="server" ImageUrl="~/Images/btnAdd.png"
                                                OnClick="btn_addSaleInfo_Click" ValidationGroup="sal" />
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

                 <ajaxToolkit:TabPanel runat="server" HeaderText="Consignee" ID="tabConsignee" Height="440px">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <br />
                            <br />
                            <table width="100%" cellpadding="3px">
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <asp:GridView ID="Gridconsignee" runat="server" AllowPaging="True" PageSize="4" Width="60%"
                                                    EmptyDataText="No consignee added." ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                                    DataKeyNames="ConsigneeToID" CssClass="GridViewStyle">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:ImageButton ID="imgSelect" runat="server" CausesValidation="False" CommandName="Select"
                                                                        ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ConsigneeCode" HeaderText="Consignee Code" />
                                                        <asp:BoundField DataField="ConsigneeToName" HeaderText="Consignee Name" />
                                                      
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
                                <tr><td></td><td>&nbsp;</td></tr>
                                <tr>
                                    <td width="50%" >
                                       <div align="right">Consignee Code:</div>
                                    </td>
                                    <td >
                                       <div align="left">
                                           <asp:TextBox ID="txtConsigneeCode" runat="server"></asp:TextBox></div>
                                    </td>
                                  
                                </tr>
                                  <tr>
                                    <td >
                                       <div align="right"> Consignee Name:</div>
                                    </td>
                                    <td >
                                       <div align="left"> <asp:TextBox ID="txtconsigneeName" runat="server"></asp:TextBox></div>
                                    </td>
                                  
                                </tr>
                                  <tr>
                                    <td >
                                        <div align="right">Active Status</div>
                                    </td>
                                    <td >
                                       <div align="left">
                                           <asp:CheckBox ID="chkActiveStatus" runat="server" /></div>
                                    </td>
                                  
                                </tr>
                                  <tr>
                                    <td >
                                        &nbsp;
                                    </td>
                                    <td >
                                        &nbsp;
                                    </td>
                                  
                                </tr>
                                  <tr>
                                    <td >
                                        &nbsp;
                                    </td>
                                    <td >
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
                <asp:Panel ID="Pnl_GridMasterDrag" runat="server" Style="cursor: move">
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
                                    Customer Master</div>
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
                                        DataKeyNames="CustomerId" Width="100%" EmptyDataText="No  Result match your search criteria."
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
                                            <asp:BoundField DataField="CustomerCode" HeaderText="Customer Code" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="Country" HeaderText="Country" />
                                            <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person" />
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
        ImageUrl="~/Images/btnCancel.png" OnClick="btn_cancel_Click" OnClientClick="userAction();" />
</asp:Content>
