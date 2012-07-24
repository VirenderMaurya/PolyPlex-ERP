<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="MaterialIssueforSales.aspx.cs" Inherits="Procurement_MaterialIssueforSales" %>

<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 568px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
      <table ><tr style="height:10px;"><td></td></tr></table>
         <asp:Panel ID="pnlhead" runat="server" BorderWidth="1" BorderColor="#999999"></asp:Panel>
      <table ><tr style="height:20px;"><td></td></tr></table>

    <table width="100%">
        <tr style="height: 25%">
            <td>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="20%" align="right">
                Sale Type :
            </td>
            <td>
                <asp:DropDownList ID="ddlsalesType" runat="server">
                </asp:DropDownList> <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlsalesType"
                                    Display="None" ErrorMessage="Please select sale type" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator5">
                                </asp:ValidatorCalloutExtender>
            </td>
            <td width="20%" align="right">
                Year :
            </td>
            <td>
                <asp:TextBox ID="txtYear" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
            </td>
            <td width="20%" align="right">
                Issue :
            </td>
            <td>
                <asp:TextBox ID="txtIssue" BackColor="Silver" runat="server"></asp:TextBox>
            </td>
            <td width="20%" align="right">
                Date :
            </td>
            <td>
                <asp:TextBox ID="txtDate" BackColor="Silver" Width="70px" runat="server"></asp:TextBox>
            </td>
            <td width="20%" align="right">
                Truck :
            </td>
            <td>
                <asp:TextBox ID="txtTruck" Width="70px" runat="server"></asp:TextBox>  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtTruck" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTruck"
                                    Display="None" ErrorMessage="Please enter the truck" ForeColor="Red" 
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator6">
                                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
    
        <tr>
            <td width="13%" align="right">
                Sale Order :
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSaleOrder" runat="server" BackColor="Silver" Width="136px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="imgSalesOrder" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                TabIndex="8" OnClick="imgSalesOrder_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
            <td colspan="6">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSalesorderCode" BackColor="Silver" runat="server"></asp:TextBox>
                      
                            <asp:TextBox ID="txtSalesOrderDesc" BackColor="Silver" runat="server" 
                                Width="311px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table width="100%">
        <tr>
            <td align="left" width="10%">
                <asp:Label ID="lblmessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvSalesMaterial" Visible="false" runat="server" AllowPaging="True" PageSize="5"
                    Width="100%" EmptyDataText="No record found" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    DataKeyNames="line" OnSelectedIndexChanged="gvSalesOrder_SelectedIndexChanged"
                    OnPageIndexChanging="gvSalesOrder_PageIndexChanging" CssClass="GridViewStyle"
                    OnRowCommand="gvSalesOrder_RowCommand">
                    <Columns>
                        
                        <asp:BoundField DataField="Line" HeaderText="Line" />
                        <asp:BoundField DataField="MaterialCode" HeaderText="Material Code" />
                        <asp:BoundField DataField="Plant" HeaderText="Plant" />
                        <asp:BoundField DataField="ValuationType" HeaderText="Valuation Type" />
                        <asp:BoundField DataField="StorageLocation" HeaderText="Storage Location" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="UOM" HeaderText="UOM" />
                        <asp:BoundField DataField="MaterialValue" HeaderText="MaterialValue" />


                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgDelete" runat="server" CommandArgument='<%#Eval("Line") %>'
                                    CommandName="del" ImageUrl="~/Images/delete.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                </asp:GridView>


                    <asp:GridView ID="gvSales" Visible="false" runat="server" 
                    Width="100%" EmptyDataText="No record found" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    DataKeyNames="line" OnSelectedIndexChanged="gvSalesOrder_SelectedIndexChanged"
                    OnPageIndexChanging="gvSalesOrder_PageIndexChanging" CssClass="GridViewStyle"
                    OnRowCommand="gvSalesOrder_RowCommand">
                    <Columns>
                          <asp:TemplateField  HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="imgSelect" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoID") %>' CommandName="Select"
                                                ImageUrl="~/Images/chkbxuncheck.png" Visible="false" Text="Select" /></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        <asp:BoundField DataField="Line" HeaderText="Line" />
                        <asp:BoundField DataField="MaterialCode" HeaderText="Material Code" />
                        <asp:BoundField DataField="Plant" HeaderText="Plant" />
                        <asp:BoundField DataField="ValuationType" HeaderText="Valuation Type" />
                        <asp:BoundField DataField="StorageLocation" HeaderText="Storage Location" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="UOM" HeaderText="UOM" />
                        <asp:BoundField DataField="MaterialValue" HeaderText="MaterialValue" />


                   
                    </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>



    <table width="100%">
        <tr>
            <td width="26%" align="right">
                SO Line:
            </td>
            <td>
                <asp:TextBox ID="txtSOLine" runat="server"  Width="70px"></asp:TextBox>
                   <asp:FilteredTextBoxExtender ID="fltr" TargetControlID="txtSOLine" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
            </td>
            <td width="20%" align="right">
                Material Code :
            </td>
            <td>
                <asp:DropDownList ID="ddlMaterialCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMaterialCode_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMaterialCode"
                                    Display="None" ErrorMessage="Please select material code" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator2">
                                </asp:ValidatorCalloutExtender>
            </td>
            <td width="20%" align="right">
                Plant :
            </td>
            <td>
                <asp:DropDownList ID="ddlPlant" runat="server">
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPlant"
                                    Display="None" ErrorMessage="Please select plant" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
            </td>
            <td width="20%" align="right">
                Valuation Type :
            </td>
            <td>
                <asp:DropDownList ID="ddlValuationType" runat="server">
                </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlValuationType"
                                    Display="None" ErrorMessage="Please select valuation type" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                               PopupPosition="TopRight" Width="50"     TargetControlID="RequiredFieldValidator3">
                                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
   
        <tr>
            <td align="right">
                Location:
            </td>
            <td>
           <asp:DropDownList ID="ddlstorageLocation" runat="server" >
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlstorageLocation"
                                    Display="None" ErrorMessage="Please select storage location" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator4">
                                </asp:ValidatorCalloutExtender>
            </td>
            <td width="10%" align="right">
              Batch:
            </td>
            <td>
               <asp:TextBox ID="txtBatch"  runat="server"></asp:TextBox> <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtBatch" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
            </td>
            <td width="10%" align="right">
                Stock:
            </td>
            <td>
               <asp:TextBox ID="txtStock"   runat="server" Width="80px"></asp:TextBox>  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtStock" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
            </td>
            <td width="20%" align="right">
                Quantity:
            </td>
            <td>
            <table><tr><td> <asp:TextBox ID="txtQuantity"  runat="server" Width="78px"></asp:TextBox>
             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtQuantity" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender></td><td>  <asp:TextBox ID="txtUOM" BackColor="Silver"   runat="server" Width="51px"></asp:TextBox></td></tr></table>
            
            
            </td>
              <td width="20%" align="right">
                Value:
            </td>
            <td>
             <asp:TextBox ID="txtValue"  runat="server"></asp:TextBox>
               <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtValue" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 35%">
            <td>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr align="right">
            <td width="30%">
                <asp:ImageButton ID="ImgBtnAddLine" ImageUrl="~/Images/btnAddLinegreen.png" runat="server"
                    Text="Add Line" ValidationGroup="btnsave" OnClick="ImgBtnAddLine_Click" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 35%">
            <td>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr align="center">
            <td>
            </td>
            <td>
                <table>
                    <tr>
                        <td width="30%">
                            <asp:ImageButton ID="ImgBtnSave" ImageUrl="~/Images/btnSave.png" runat="server" Text="Save"
                                OnClick="ImgBtnSave_Click" />
                        </td>
                        <td width="30%">
                            <asp:ImageButton ID="ImgBtnCancel" ImageUrl="~/Images/btnCancel.png" runat="server"
                                Text="Cancel" OnClick="ImgBtnCancel_Click" />
                        </td>
                        <td width="30%">
                            <asp:ImageButton ID="ImgBtnExit" ImageUrl="~/Images/btnExit.png" runat="server" Text="Exit"
                                OnClientClick="window.close();" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
        Style="display: none">
        <asp:Panel ID="Panel3" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex"
                                style="border: 1px solid black" /></div>
                    </td>
                    <td valign="top">
                        <div style="float: right; padding: 10px 10px 0 0">
                            <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="margin-left: 20px; margin-right: 20px">
            <table width="100%" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>
                        <div class="in_menu_head">
                            Search Result</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
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
                        <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" PageSize="5" Width="100%"
                            EmptyDataText="No Result match your search criteria." ShowHeaderWhenEmpty="True"
                            AutoGenerateColumns="False" DataKeyNames="SaleOrder" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"
                            OnPageIndexChanging="gridMaster_PageIndexChanging" CssClass="GridViewStyle">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Select"
                                                ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="Lbljumbono" runat="server" CommandName="sel" CommandArgument='<% #Eval("METJumboNo")%>'></asp:LinkButton>--%>
                                        <%--     <asp:Label ID="lblPETPlant" runat="server" Text='<% #Eval("autoid")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SaleOrder" HeaderText="Sales Order" />
                                <asp:BoundField DataField="SOCustomerCode" HeaderText="Customer Code" />
                                <asp:BoundField DataField="SOCustomerName" HeaderText="Customer Name" />
                                
                                
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="True"
        PopupDragHandleControlID="Panel3" CancelControlID="ImageButton2" DynamicServicePath=""
        Enabled="True" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:HiddenField ID="HidPopUpType" runat="server" />
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
                                <td style="width: 27%">
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
                        <asp:HiddenField ID="hidCustomerId" runat="server" />
                        <asp:GridView ID="gvPopUpGrid" runat="server" AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="5" OnRowCommand="gvPopUpGrid_RowCommand" OnRowDataBound="gvPopUpGrid_RowDataBound"
                            OnPageIndexChanging="gvPopUpGrid_PageIndexChanging">
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
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C6C3C6" ForeColor="Black" />
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
    <asp:HiddenField ID="hidTermsOfDeliveryId" runat="server" />
    <asp:HiddenField ID="hidConsigneeId" runat="server" />
    <asp:HiddenField ID="hidPaymenttermsId" runat="server" />
</asp:Content>
