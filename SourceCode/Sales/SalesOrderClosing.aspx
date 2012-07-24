<%@ Page Title="" Language="C#" MasterPageFile="~/Sales/PolyplexMaster.master" AutoEventWireup="true"
    CodeFile="SalesOrderClosing.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

                

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="overflow: auto; height: auto; position: relative;">
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
            <tr style="height: 5px">
                <td colspan="7">
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Order Type:" ID="Label2"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:DropDownList runat="server" ValidationGroup="1" Width="90%" ID="ddlOrderType">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Search Type:" ID="Label4"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:DropDownList runat="server" ValidationGroup="1" Width="90%" ID="ddlSearchType"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlSearchType_SelectedIndexChanged">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                        <asp:ListItem Value="1">Proforma Invoice</asp:ListItem>
                        <asp:ListItem Value="2">Sales Order</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="PI/SO No:" ID="LPISONo"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="70%" ID="txtPISONo"></asp:TextBox>
                    <asp:ImageButton ID="imgbtnSearchInForm" runat="server" ImageUrl="../images/Search-32.png"
                        Height="24px" Width="24px" ValidationGroup="1" OnClick="imgbtnSearchInForm_Click" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Order Date:" ID="Label5"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="86%" ID="txtOrderDate"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="PI/OrderNo:" ID="lPIOrderNo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="86%" ID="txtPIOrderNo" ValidationGroup="1"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Confirmed (Y/N):" ID="Label15"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="chkConfirmed"></asp:CheckBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Customer Order No.:" ID="Label11"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="86%" ID="txtCustomerOrderNo"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Customer Name:" ID="Label10"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" TabIndex="27" Width="100%" ID="txtCustomerName"></asp:TextBox>
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
                <td colspan="6" style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                    <asp:Label runat="server" Text="Order Line Details:" ID="lOrderLineDetails"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="7">
                    <div style="overflow: auto; width: 100%; position: relative;">
                        <asp:GridView ID="gvOrderLineDetails" runat="server" AutoGenerateColumns="False"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            OnRowDataBound="gvOrderLineDetails_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="LineItemID" HeaderText="LineItemID">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubFilmTypeName" HeaderText="SubFilmType">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
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
                                <asp:BoundField DataField="Length" HeaderText="Length (Mtr)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrderQuantity" HeaderText="Order Quantity">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CancelQuantity" HeaderText="Cancel Quantity">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DispatchQuantity" HeaderText="Dispatch Quantity">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReadyQuantity" HeaderText="Ready Quantity">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeliveryDate" HeaderText="Delivery Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubFilmType" HeaderText="SubFilmTypeId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Width" HeaderText="Width (MM)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C6C3C6" ForeColor="Black" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label21" runat="server" Text="Reason:"></asp:Label>
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtReason" runat="server" MaxLength="25" TabIndex="40" TextMode="MultiLine"
                        Width="96%"></asp:TextBox>
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
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" TabIndex="5" 
                        ImageUrl="~/Images/btnSave.png" onclick="ImgBtnSave_Click" />
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
                    <asp:HiddenField ID="HidSearch" runat="server" />
                    <asp:HiddenField ID="HidCustomerId" runat="server" />
                </td>
                <td>
                </td>
                <td>
                    <asp:HiddenField ID="HidType" runat="server" />
                    <asp:HiddenField ID="HidPISOId" runat="server" />
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
    </div>
    <div>
        <asp:RequiredFieldValidator ID="RFVOrderType" runat="server" ErrorMessage="Please select order type."
            Display="None" ControlToValidate="ddlOrderType" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="VCLOrderType" runat="server" Enabled="True" TargetControlID="RFVOrderType">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RFVSearchType" runat="server" ErrorMessage="Please select search type."
            Display="None" ControlToValidate="ddlSearchType" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="VCESearchType" runat="server" Enabled="True" TargetControlID="RFVSearchType">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RFVPISONo" runat="server" ErrorMessage="Please fill PI/SO No."
            Display="None" ControlToValidate="txtPISONo" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender PopupPosition="TopLeft" ID="VCEPISONo" runat="server"
            Enabled="True" TargetControlID="RFVPISONo">
        </asp:ValidatorCalloutExtender>
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
                            Sales Order Closed List</div>
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
                        <asp:GridView ID="gvClosedOrder" runat="server" AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                             AllowPaging="true" PageSize="5" onrowcommand="gvClosedOrder_RowCommand" 
                            onrowdatabound="gvClosedOrder_RowDataBound" >
                            <Columns>
                            <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>                                    
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="OrderTypeId" HeaderText="OrderTypeId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SearchTypeId" HeaderText="SearchTypeId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PISONo" HeaderText="PI/SO No.">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrderDate" HeaderText="Order Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerOrderNo" HeaderText="Customer Order No">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerCode" HeaderText="Customer Code">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                               <%-- <asp:BoundField DataField="OrderQuantity" HeaderText="Order Quantity">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField> --%>
                                <asp:BoundField DataField="PIOrderNo" HeaderText="PIOrderNo">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="Confirmed" HeaderText="Confirmed">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="Reason" HeaderText="Reason">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
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
