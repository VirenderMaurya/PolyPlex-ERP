<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SalesOrderTasks.ascx.cs"
    Inherits="Controls_HomePageTasksSales" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="width: 280px; margin: 0px auto 0px auto">
            <div style="font-weight: bold; font-size: 12px; font-family: Arial; color: #222e51">
                Last 5 Sales Orders</div>
            <asp:GridView ID="grid_SalesOrder" runat="server" AutoGenerateColumns="False" DataKeyNames="SalesOrderId"
                DataSourceID="SqlDataSource1" BorderColor="#0099FF" BorderStyle="Solid" Width="275px" ShowHeaderWhenEmpty="true"
                GridLines="Vertical" CellPadding="2">
                <Columns>
                    <asp:TemplateField HeaderText="Order No">
                        <ItemTemplate>
                           <%-- <a href="JavaScript:newPopup('SalesOrder.aspx?soid=<%#Eval("SalesOrderId") %>')"
                                style="text-decoration: none; color: #222e51">--%>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SONo") %>'></asp:Label></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SODate" DataFormatString="{0:d}" HeaderText="Date" SortExpression="SODate" />
                    <asp:BoundField DataField="PerfInvTypeName" HeaderText="Type" SortExpression="PerfInvTypeName" />
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer" SortExpression="CustomerName" />
                </Columns>
                <HeaderStyle BackColor="#8FD44C" BorderColor="#009900" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" CssClass="TaskGridHeader" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=10.1.0.157;Initial Catalog=PolyplexERP;Persist Security Info=True;User ID=sa;Password=pipl?123"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT TOP (5) SalesOrderId, SONo, SODate, CustomerName, PerfInvTypeName FROM View_SalesOrder ORDER BY SalesOrderId DESC">
            </asp:SqlDataSource>
            <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=PPSO4160L;Initial Catalog=PolyplexERP;Persist Security Info=True;User ID=sa;Password=password12"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT TOP (5) SalesOrderId, SONo, SODate, CustomerName, PerfInvTypeName FROM View_SalesOrder ORDER BY SalesOrderId DESC">
            </asp:SqlDataSource>--%>
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
                                    <td style="height: 38px; border-left: 1px solid #0099FF; border-top: 1px solid #0099FF">
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
                        <td style="vertical-align: top">
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
                        
                    </tr>
                </table>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
