<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InvoiceTasks.ascx.cs" Inherits="Controls_InvoiceTasks" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="width: 280px; margin: 0px auto 0px auto">
            <div style="font-weight: bold; font-size: 12px; font-family: Arial; color: #222e51">
                Last 5 Invoices</div>
            <asp:GridView ID="grid_Invoices" runat="server" AutoGenerateColumns="False" DataKeyNames="Invoiceid" ShowHeaderWhenEmpty="true"
                BorderColor="#0099FF" BorderStyle="Solid" Width="275px" GridLines="Vertical"
                CellPadding="2" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:TemplateField HeaderText="Invoice No">
                        <ItemTemplate>
                            <a href="JavaScript:newPopup('Sales/Invoice.aspx?invid=<%#Eval("Invoiceid") %>')"
                                style="text-decoration: none; color: #222e51">
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:Label></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="InvoiceDate" DataFormatString="{0:d}" HeaderText="Date"
                        SortExpression="InvoiceDate" />
                    <asp:BoundField DataField="InvoiceType" HeaderText="Type" SortExpression="InvoiceType" />
                    <asp:BoundField DataField="CustomerCode" HeaderText="Customer" SortExpression="CustomerCode" />
                </Columns>
                <HeaderStyle BackColor="#8FD44C" BorderColor="#009900" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" CssClass="TaskGridHeader" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=10.1.0.157;Initial Catalog=PolyplexERP;Persist Security Info=True;User ID=sa;Password=pipl?123"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT TOP (5) InvoiceNo, Invoiceid, InvoiceDate, CustomerCode, InvoiceType FROM View_InvoiceTran ORDER BY Invoiceid DESC">
            </asp:SqlDataSource>
            <br />
            <br />
            <div style="font-weight: bold; font-size: 12px; font-family: Arial; color: #222e51">
                Generic Info</div>
            <div style="width: 275px">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="16%" style="vertical-align: top">
                            <table cellpadding="0" cellspacing="0" style="font-size: 10px">
                                <tr>
                                    <td style="height: 45px; border-left: 1px solid #0099FF; border-top: 1px solid #0099FF">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 16px; border-bottom: 1px solid black; border-left: 1px solid black;
                                        border-top: 1px solid black" class="TasksideInfo">
                                        &nbsp;Last Day
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 16px; border-bottom: 1px solid black; border-left: 1px solid black"
                                        class="TasksideInfo">
                                        &nbsp;LastWeek
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid black; border-left: 1px solid black"
                                        class="TasksideInfo">
                                        &nbsp;MTD
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="28%" style="vertical-align: top">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr class="TaskGridHeader">
                                    <td colspan="2" style="border-top: 1px solid #0099FF; border-left: 1px solid #0099FF;
                                        border-right: 1px solid #0099FF; height: 15px">
                                        <center>
                                            Sales Order</center>
                                    </td>
                                </tr>
                                <tr class="TaskGridHeader">
                                    <td width="50%" style="border: 1px solid #0099FF; height: 20px">
                                        <center>
                                            Total No</center>
                                    </td>
                                    <td style="border-bottom: 1px solid #0099FF; border-right: 1px solid #0099FF; border-top: 1px solid #0099FF">
                                        <center>
                                            Amount</center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="gridSO" runat="server" ShowHeader="false" Width="100%" GridLines="vertical"
                                            AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="TotalNo">
                                                    <ItemStyle HorizontalAlign="Center" Width="40%" Height="15px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Amount">
                                                    <ItemStyle HorizontalAlign="Center" Height="15px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="28%" style="vertical-align: top">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr class="TaskGridHeader">
                                    <td colspan="2" style="border-top: 1px solid #0099FF; border-right: 1px solid #0099FF;
                                        height: 15px">
                                        <center>
                                            Dispatches</center>
                                    </td>
                                </tr>
                                <tr class="TaskGridHeader">
                                    <td width="50%" style="border-bottom: 1px solid #0099FF; border-right: 1px solid #0099FF;
                                        border-top: 1px solid #0099FF; height: 20px">
                                        <center>
                                            Total No</center>
                                    </td>
                                    <td style="border-bottom: 1px solid #0099FF; border-right: 1px solid #0099FF; border-top: 1px solid #0099FF">
                                        <center>
                                            Amount</center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="gridDispatches" runat="server" AutoGenerateColumns="false" GridLines="vertical"
                                            Width="100%" ShowHeader="false">
                                            <Columns>
                                                <asp:BoundField DataField="TotalNo">
                                                    <ItemStyle HorizontalAlign="Center" Width="40%" Height="15px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Amount">
                                                    <ItemStyle HorizontalAlign="Center" Height="15px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align: top">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr class="TaskGridHeader">
                                    <td colspan="2" style="border-top: 1px solid #0099FF; border-right: 1px solid #0099FF;
                                        border-top: 1px solid #0099FF; height: 15px">
                                        <center>
                                            Invoices</center>
                                    </td>
                                </tr>
                                <tr class="TaskGridHeader">
                                    <td width="50%" style="border-bottom: 1px solid #0099FF; border-right: 1px solid #0099FF;
                                        border-top: 1px solid #0099FF; height: 20px">
                                        <center>
                                            Total No</center>
                                    </td>
                                    <td style="border-bottom: 1px solid #0099FF; border-right: 1px solid #0099FF; border-top: 1px solid #0099FF">
                                        <center>
                                            Amount</center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="gridInvoices" runat="server" ShowHeader="false" Width="100%" GridLines="vertical"
                                            AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="TotalNo">
                                                    <ItemStyle HorizontalAlign="Center" Width="40%" Height="15px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Amount">
                                                    <ItemStyle HorizontalAlign="Center" Height="15px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>