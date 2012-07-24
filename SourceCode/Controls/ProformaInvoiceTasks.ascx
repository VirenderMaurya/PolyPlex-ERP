<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProformaInvoiceTasks.ascx.cs"
    Inherits="Controls_HomePageTasksSales" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="width: 280px; margin: 0px auto 0px auto">
            <div style="font-weight: bold; font-size: 12px; font-family: Arial; color: #222e51">
                Last 5 Proforma Invoices</div>
            <asp:GridView ID="gvProformaInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="PerformaInvoiceID"
                DataSourceID="SqlDataSource1" BorderColor="#0099FF" BorderStyle="Solid" Width="275px" ShowHeaderWhenEmpty="true"
                GridLines="Vertical" CellPadding="2">
                <Columns>
                    <asp:TemplateField HeaderText="Order No">
                        <ItemTemplate>
                            <%--<a href="JavaScript:newPopup('Sales/ProformaInvoice.aspx?PIid=<%#Eval("PerformaInvoiceID") %>')"
                                style="text-decoration: none; color: #222e51">--%>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("PINo") %>'></asp:Label></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PIDate" DataFormatString="{0:d}" HeaderText="Date" SortExpression="PIDate" />
                    <asp:BoundField DataField="PIType" HeaderText="Type" SortExpression="PI Type" />
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer" SortExpression="CustomerName" />
                </Columns>
                <HeaderStyle BackColor="#8FD44C" BorderColor="#009900" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" CssClass="TaskGridHeader" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=10.1.0.157;Initial Catalog=PolyplexERP;Persist Security Info=True;User ID=sa;Password=pipl?123"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT TOP (5) PerformaInvoiceID,PINo,replace(CONVERT(VARCHAR(11),PIDate ,101),' ','/') AS PIDate,
                (SELECT PerfInvTypeName FROM Sal_PerformaInvoiceType_Mst WHERE PerfInvTypeID = P.PerfInvTypeID ) AS PIType
                ,(SELECT Name FROM Sal_Glb_Customer_Mst WHERE CustomerID=P.Customer) AS CustomerName from dbo.Sal_Glb_PerformaInvoiceHeader_Tran as P ORDER BY PerformaInvoiceID DESC">
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
                        <td  style="vertical-align: top">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr class="TaskGridHeader">
                                    <td colspan="2" style="border-top: 1px solid #0099FF; border-left: 1px solid #0099FF;
                                        border-right: 1px solid #0099FF; height: 15px">
                                        <center>
                                            Proforma Invoice</center>
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
                                        <asp:GridView ID="gvPI" runat="server" ShowHeader="false" Width="100%" GridLines="vertical"
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
