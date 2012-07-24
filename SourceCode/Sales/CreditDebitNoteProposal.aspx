<%@ Page Title="" Language="C#" MasterPageFile="~/Sales/PolyplexMaster.master" AutoEventWireup="true"
    CodeFile="CreditDebitNoteProposal.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        function VisibleMRNNo() {
            if (document.getElementById('<%= ddlCreditDebit.ClientID %>').value == "" || document.getElementById('<%= ddlCreditDebit.ClientID %>').value == "2") {
                document.getElementById('<%= TdMrnNoHeading.ClientID %>').style.visibility = 'hidden';
                document.getElementById('<%= TdMrnNo.ClientID %>').style.visibility = 'hidden';
            }
            else {
                document.getElementById('<%= TdMrnNoHeading.ClientID %>').style.visibility = 'visible';
                document.getElementById('<%= TdMrnNo.ClientID %>').style.visibility = 'visible';
            }
            return false;
        }

        function FillInvoiceGridBetweenDate() {
            if (document.getElementById('<%=txtFrom.ClientID %>').value != "" && document.getElementById('<%=txtTo.ClientID %>').value != "" && document.getElementById('<%=txtCustomerCode.ClientID %>').value != "") {

                if (document.getElementById('<%=txtFrom.ClientID %>').value > document.getElementById('<%=txtTo.ClientID %>').value) {
                    alert('From date can not be greater than to date.');
                }
                else {
                    document.getElementById('<%=HidIsNewToDate.ClientID %>').value = "Yes";
                    document.forms[0].submit();
                }
            }
            else {
                if (document.getElementById('<%=txtCustomerCode.ClientID %>').value == "") {
                    document.getElementById('<%=txtFrom.ClientID %>').value = "";
                    document.getElementById('<%=txtTo.ClientID %>').value = "";
                    alert('Select the customer first.');
                    return false;
                }
            }
        }

        function CalculateVatAndNetAmount() {

            if (window.document.getElementById('<%=HidVat.ClientID %>').value == "") {

                document.getElementById('<%=HidVat.ClientID %>').value = "0";
            }
            else {
                if (document.getElementById('<%=txtQtyKg.ClientID %>').value != "" && document.getElementById('<%=txtRate.ClientID %>').value != "") {

                    document.getElementById('<%=txtAmount.ClientID %>').value = (parseFloat(document.getElementById('<%=txtQtyKg.ClientID %>').value) * parseFloat(document.getElementById('<%=txtRate.ClientID %>').value)).toFixed(2);
                    document.getElementById('<%=txtVatAmount.ClientID %>').value = parseFloat(parseFloat(document.getElementById('<%=txtAmount.ClientID %>').value) * parseFloat(document.getElementById('<%=HidVat.ClientID %>').value)) / 100;
                    document.getElementById('<%=txtNetAmount.ClientID %>').value = (parseFloat(document.getElementById('<%=txtAmount.ClientID %>').value) + parseFloat(document.getElementById('<%=txtVatAmount.ClientID %>').value)).toFixed(2);
                }
            }
        }
           

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
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Credit/Debit:" ID="Label2"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:DropDownList runat="server" Width="84%" ID="ddlCreditDebit">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                        <asp:ListItem Value="1">Credit</asp:ListItem>
                        <asp:ListItem Value="2">Debit</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Sales Type:" ID="Label3"></asp:Label>
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
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="CR/DB Proposal No.:" ID="Label1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtCRDBProposalNo"></asp:TextBox>
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
                    <asp:Label runat="server" Text="Date:" ID="Label5"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Type:" ID="Label6"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" Width="84%" ID="ddlType">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" id="TdMrnNoHeading" runat="server">
                    <asp:Label runat="server" Text="MRN No.:" ID="Label7"></asp:Label>
                </td>
                <td id="TdMrnNo" runat="server">
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtMRNNo"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Customer Code:" ID="Label8"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtCustomerCode"></asp:TextBox>
                    <asp:ImageButton ID="imgCustomerCode" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                        TabIndex="8" CausesValidation="false" OnClick="imgCustomerCode_Click" />
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Customer Name:" ID="Label9"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtCustomerName"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Document No:" ID="Label10"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtDocumentNo"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Document Date:" ID="Label11"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtDocumentDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnDocumentDate" CausesValidation="false" runat="server"
                        ImageUrl="~/Images/cal.gif" TabIndex="0" />
                    <asp:CalendarExtender ID="calExtenderDocumentDate" runat="server" TargetControlID="txtDocumentDate"
                        PopupButtonID="imgBtnDocumentDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="From:" ID="Label12"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtFrom" runat="server" TabIndex="27" Width="80%" onchange="FillInvoiceGridBetweenDate();"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnFrom" CausesValidation="false" runat="server" ImageUrl="~/Images/cal.gif"
                        TabIndex="0" />
                    <asp:CalendarExtender ID="calExtenderFrom" runat="server" TargetControlID="txtFrom"
                        PopupButtonID="imgBtnFrom" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="To:" ID="Label13"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtTo" runat="server" TabIndex="27" Width="80%" CausesValidation="false"
                        onchange="FillInvoiceGridBetweenDate();"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnTo" CausesValidation="false" runat="server" ImageUrl="~/Images/cal.gif"
                        TabIndex="0" />
                    <asp:CalendarExtender ID="calExtenderTo" runat="server" TargetControlID="txtTo" PopupButtonID="imgBtnTo"
                        Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Preamble:" ID="Label14"></asp:Label>
                </td>
                <td colspan="5">
                    <asp:TextBox runat="server" TextMode="MultiLine" TabIndex="40" Width="96%" ID="txtPreamble"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Remarks:" ID="Label15"></asp:Label>
                </td>
                <td colspan="5">
                    <asp:TextBox runat="server" TextMode="MultiLine" TabIndex="40" Width="96%" ID="txtRemarks"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Value:" ID="Label16"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtValue"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="VAT:" ID="Label17"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtVAT"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Grand Total:" ID="Label18"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtGrandTotal"></asp:TextBox>
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
                <td colspan="3" class="gridname">
                    Invoices During the Above Period:
                </td>
                <td colspan="3" class="gridname">
                    Selected Invoices:
                </td>
                <td>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="3">
                    <div style="overflow: auto; width: 100%; position: relative;">
                        <asp:GridView ID="gvInvoiceDuringPeriod" runat="server" AutoGenerateColumns="false"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            OnRowDataBound="gvInvoiceDuringPeriod_RowDataBound" OnRowCommand="gvInvoiceDuringPeriod_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Invoiceid") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InvoiceNo" HeaderText="InvoiceNo">
                                    <HeaderStyle HorizontalAlign="Center" Width="400px" />
                                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InvoiceDate" HeaderText="InvoiceDate">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalQuantity" HeaderText="TotalQuantity">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InvoiceAmount" HeaderText="InvoiceAmount">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
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
                <td colspan="3">
                    <div style="overflow: auto; width: 412px; position: relative;">
                        <asp:GridView ID="gvSelectedInvoice" runat="server" AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            OnRowDataBound="gvSelectedInvoice_RowDataBound" OnRowCommand="gvSelectedInvoice_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("CBNLineItemId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="CBNLineItemId" HeaderText="CBNLineItemId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="CBNId" HeaderText="CBNId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SalesOrderId" HeaderText="SalesOrderId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOLineItemId" HeaderText="SOLineItemId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubFilmTypeName" HeaderText="SubFilmType">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Micron" HeaderText="Micron">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Core" HeaderText="Core">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WidthInMMName" HeaderText="Width (MM)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LengthInMtr" HeaderText="Length (Mtr)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReqQuantityInKG" HeaderText="Req. Quantity (Kg)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CurrencyName" HeaderText="Currency">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Rate" HeaderText="Rate">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vat Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVatAmount" runat="server" Text='<%# Eval("VatAmount")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Net Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNAmount" runat="server" Text='<%# Eval("NetAmount")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Description" HeaderText="Description">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IsUpdated" HeaderText="IsUpdated">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Currency" HeaderText="CurrencyId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ActiveStatus" HeaderText="ActiveStatus">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubFilmTypeId" HeaderText="SubFilmTypeId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WidthInMM" HeaderText="Width (MM)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <%-- <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtnDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                            ImageUrl="~/Images/delete.gif" OnClientClick="javascript:return confirm('Are you sure to delete?');" /></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="10px" />
                                    <ItemStyle HorizontalAlign="Left" Width="10px" />
                                </asp:TemplateField>--%>
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
                <td colspan="3" class="gridname">
                    Selected Invoice Detail:
                </td>
                <td colspan="3">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <div style="overflow: auto; width: 100%; position: relative;">
                        <asp:GridView ID="gvSelectedInvoiceDetail" runat="server" ShowHeaderWhenEmpty="True"
                            EmptyDataText="No Record Found." AutoGenerateColumns="false" Width="100%" CssClass="GridViewStyle"
                            OnRowDataBound="gvSelectedInvoiceDetail_RowDataBound" OnRowCommand="gvSelectedInvoiceDetail_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("SOLineItemID") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Invoiceid" HeaderText="Invoiceid">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubFilmTypeName" HeaderText="SubFilmType">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOMicron" HeaderText="Micron">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOCore" HeaderText="Core">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WidthInMMName" HeaderText="Width (MM)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOLengthInMtr" HeaderText="Length (Mtr)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOUnitPrice" HeaderText="UnitPrice">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOReqQuantityInKG" HeaderText="Req. Quantity (Kg)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Currency" HeaderText="Currency">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SalesOrderId" HeaderText="SalesOrderId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IsSelected" HeaderText="IsSelected">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CurrencyId" HeaderText="CurrencyId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubFilmType" HeaderText="SubFilmType">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOWidthInMM" HeaderText="WidthInMM">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
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
                <td colspan="3" valign="top">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" Text="Qty (Kg):" ID="Label19"></asp:Label>
                                <span style="color: Red; font-weight: bold">*</span>
                            </td>
                            <td>
                                <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtQtyKg"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                    FilterType="Custom, Numbers" TargetControlID="txtQtyKg" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" Text="Rate:" ID="Label20"></asp:Label>
                                <span style="color: Red; font-weight: bold">*</span>
                            </td>
                            <td>
                                <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtRate"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                    FilterType="Custom, Numbers" TargetControlID="txtRate" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" Text="Amount:" ID="Label24"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtAmount"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" Text="VAT Amount:" ID="Label25"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtVatAmount"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" Text="NET Amount:" ID="Label26"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtNetAmount"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" Text="Currency:" ID="Label21"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtCurrency"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" Text="Invoice No.:" ID="Label23"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtInvoiceNo"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" Text="Description:" ID="Label27"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox runat="server" TabIndex="27" TextMode="MultiLine" Width="100%" ID="txtDescription"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <%--<asp:Button ID="btnSaveLine" runat="server" TabIndex="10" ValidationGroup="2" Text="Save Line"
                                    OnClick="btnSaveLine_Click" />--%>
                                 <asp:ImageButton ID="ImgBtnSaveLine" runat="server" Text="Save" ValidationGroup="2" 
                                 TabIndex="5" ImageUrl="~/Images/btnSaveLinegreen.gif" 
                                    onclick="ImgBtnSaveLine_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
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
                <td>
                </td>
                <td>
                </td>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" OnClick="ImgBtnSave_Click"
                        TabIndex="5" ImageUrl="~/Images/btnSave.png" />
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
                <td>
                    <asp:HiddenField ID="hidCustomerId" runat="server" />
                    <asp:HiddenField ID="HidIsNewToDate" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hidSalesType" runat="server" />
                    <asp:HiddenField ID="HidPopUpType" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidUpdateGridRecord" runat="server" />
                    <asp:HiddenField ID="HidCBNId" runat="server" />
                    <asp:HiddenField ID="HidSelectedInvoiceDetailRowIndex" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidSelectedInvoiceRowIndex" runat="server" />
                    <asp:HiddenField ID="HidVat" runat="server" />
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:RequiredFieldValidator ID="RFVCreditDebit" runat="server" ErrorMessage="Credit/Debit is mandatory."
            Display="None" ControlToValidate="ddlCreditDebit" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="VCLCreditDebit" runat="server" Enabled="True" TargetControlID="RFVCreditDebit">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Sales Type is mandatory."
            Display="None" ControlToValidate="txtSalesType" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Customer is mandatory."
            Display="None" ControlToValidate="txtCustomerCode" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Document No. is mandatory."
            Display="None" ControlToValidate="txtDocumentNo" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender3" runat="server" Enabled="True" PopupPosition="Left"
                TargetControlID="RequiredFieldValidator3">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Document Date is mandatory."
            Display="None" ControlToValidate="txtDocumentDate" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="From Date is mandatory."
            Display="None" ControlToValidate="txtFrom" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="To Date is mandatory."
            Display="None" ControlToValidate="txtTo" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender6" runat="server" PopupPosition="Left" Enabled="True"
                TargetControlID="RequiredFieldValidator6">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Quantity (Kg) is mandatory."
            Display="None" ControlToValidate="txtQtyKg" ValidationGroup="2" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Rate is mandatory."
            Display="None" ControlToValidate="txtRate" ValidationGroup="2" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender8" runat="server" PopupPosition="Left" Enabled="True"
                TargetControlID="RequiredFieldValidator8">
            </asp:ValidatorCalloutExtender>
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
                            OnRowDataBound="gvPopUpGrid_RowDataBound" OnPageIndexChanging="gvPopUpGrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="select"
                                                ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
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
    <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="800px" CssClass="modalPopup"
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
                            All Credit/Debit List</div>
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
                        <asp:GridView ID="gvAllCreditDebit" runat="server" AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="5" OnRowCommand="gvAllCreditDebit_RowCommand" OnRowDataBound="gvAllCreditDebit_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="select"
                                                ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CRDBProposalNo" HeaderText="CR/DB Proposal No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreditDebitName" HeaderText="Credit/Debit">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Sales Type" HeaderText="Sales Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Date" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TypeName" HeaderText="Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Value" HeaderText="Value">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vat" HeaderText="Vat">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GrandTotal" HeaderText="GrandTotal">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FromDate" HeaderText="From Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ToDate" HeaderText="To Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerId" HeaderText="CustomerId">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreditDebit" HeaderText="CreditDebit">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SalesTypeId" HeaderText="SalesTypeId">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Year" HeaderText="Year">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Type" HeaderText="Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MRNNo" HeaderText="MRNNo">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerCode" HeaderText="CustomerCode">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DocumentNo" HeaderText="DocumentNo">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DocumentDate" HeaderText="DocumentDate">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Preamble" HeaderText="Preamble">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CBNId" HeaderText="CBNId">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
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
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label28"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label28" runat="server" Text=""></asp:Label>
</asp:Content>
