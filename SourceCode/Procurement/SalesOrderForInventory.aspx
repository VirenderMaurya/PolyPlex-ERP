<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/PolyplexMaster.master" AutoEventWireup="true" CodeFile="SalesOrderForInventory.aspx.cs" Inherits="Procurement_SalesOrderForInventory" %>


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

 <table width="100%"> <tr style="height:25%"><td></td></tr></table>

  <table width="100%">
   <tr>
  <td width="12%" align="right"> Sale Type :</td><td><asp:DropDownList ID="ddlsalesType" runat="server"></asp:DropDownList><br />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlsalesType"
                                    Display="None" ErrorMessage="Please select sale type" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
  </td>
  <td  width="15%" align="right"> Year :</td><td><asp:TextBox ID="txtYear" runat="server" BackColor="Silver" Width="70px"></asp:TextBox></td>
  <td  width="10%" align="right"> Order :</td><td><asp:TextBox ID="txtOrder" BackColor="Silver" Width="70px"  runat="server"></asp:TextBox> 
   
  </td>
  
  
  </tr>
  
  <%--</table>

   

    <table width="100%">--%> <tr><td  width="10%"  align="right"> Date :</td><td><asp:TextBox ID="txtDate" BackColor="Silver" Width="70px"  runat="server"></asp:TextBox></td>
  <td  align="right"> Customer :</td><td> <table><tr><td> <asp:TextBox ID="txtcustomer" 
            runat="server" Width="75px" BackColor="Silver"></asp:TextBox> </td><td><asp:ImageButton ID="imgCustomerCode" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                                TabIndex="8" OnClick="imgCustomerCode_Click" CausesValidation="False" /></td></tr></table> </td>
  <td  align="right"> Consignee :</td><td><table><tr><td><asp:TextBox ID="txtConsignee" runat="server" BackColor="Silver" Width="70px"></asp:TextBox></td><td><asp:ImageButton ID="imgConsignee" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                                TabIndex="8" OnClick="imgConsignee_Click" CausesValidation="False" /></td></tr></table> </td>
 
  </tr>
  <%--</table>

    <table width="100%"> --%><tr> <td  align="right"> Delivery To :</td><td><asp:DropDownList ID="ddlDeliveryto" runat="server"></asp:DropDownList><br /> 

   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDeliveryto"
                                    Display="None" ErrorMessage="Please select Delivery to" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator3">
                                </asp:ValidatorCalloutExtender>
   
  </td>
    <td  align="right"> Mat Type :</td><td><asp:DropDownList ID="ddlMattype" runat="server"></asp:DropDownList>
  <br />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMattype"
                                    Display="None" ErrorMessage="Please select Mat type" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator4">
                                </asp:ValidatorCalloutExtender>
  
  </td>
  
  <td  align="right"> Customer Ord./Ref. :</td><td><asp:TextBox ID="txtCustomerOrder" 
            runat="server" Width="200px" ></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtCustomerOrder" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender></td>
 
  </tr>
  
  <%--</table>


   <table width="100%">--%> <tr>
    <td  align="right"> Customer Ord./Ref. Date :</td><td>
  <table><tr><td> <asp:TextBox ID="txtCustomerOrderdate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox></td><td><asp:ImageButton ID="imgBtnCustomerOrderDate" ValidationGroup="aa" runat="server"
                                                ImageUrl="~/Images/cal.gif" /></td></tr></table>
  <asp:CalendarExtender ID="calExtenderCustomerOrderDate"
                                                    runat="server" TargetControlID="txtCustomerOrderDate" PopupButtonID="imgBtnCustomerOrderDate"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender></td>
  <td  align="right"> Currency :</td><td><asp:DropDownList ID="ddlcurrency" runat="server"></asp:DropDownList> <br />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlcurrency"
                                    Display="None" ErrorMessage="Please select Currency" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator5">
                                </asp:ValidatorCalloutExtender>
  
  </td>
 
  <td  align="right"> VAT Rate :</td><td><asp:TextBox ID="txtVatRate" runat="server"  Width="70px"></asp:TextBox>
  <br />
  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtVatRate"
                                    Display="None" ErrorMessage="Please enter the vat rate" ForeColor="Red" 
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator8">
                                </asp:ValidatorCalloutExtender>
  
   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtVatRate" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender></td>

                                    </tr>
                                     <tr>
  <td  align="right"> Final Destination :</td><td><asp:DropDownList ID="ddlfinalDestination" runat="server"></asp:DropDownList><br />
  
  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlfinalDestination"
                                    Display="None" ErrorMessage="Please select final destination" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator7">
                                </asp:ValidatorCalloutExtender>
   </td>
  <td  align="right"> Pay. Terms :</td><td><table><tr><td><asp:TextBox ID="txtPayterms" BackColor="Silver" runat="server"></asp:TextBox></td><td><asp:ImageButton ID="ImageButton3" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                                TabIndex="8" OnClick="imgPaymentTerms_Click" CausesValidation="False" /></td></tr></table>  
   
  </td>
  <td  align="right"> Divry. Terms :</td><td>
  <table><tr><td>  <asp:TextBox ID="txtDivryTerms" BackColor="Silver" Width="200px"  runat="server"></asp:TextBox></td><td><asp:ImageButton ID="imgTermsofDelivery" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                                TabIndex="8" OnClick="imgTermsofDelivery_Click" CausesValidation="False" /></td></tr></table>
</td>
 
  </tr>
  <tr> <td align="right">Mode Of Payment:</td><td><asp:DropDownList ID="ddlModeofPayment" runat="server"></asp:DropDownList><br />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlModeofPayment"
                                    Display="None" ErrorMessage="Please select mode of payment" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator6">
                                </asp:ValidatorCalloutExtender>
   </td></tr>
  </table><table width="100%">
 <tr> <td width="2.5%"></td> <td valign="top" align="right">Special Instructions :</td><td colspan="4">
      <asp:TextBox ID="txtSpecialIntruction" TextMode="MultiLine" Columns="10" 
          Rows="2" runat="server" Width="929px"></asp:TextBox></td></tr></table>
 <table width="100%">
   <tr>
   <td align="left" width="10%">
    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                 </td>
    </tr>
 <tr><td>
          <asp:GridView ID="gvSalesOrder" runat="server" AllowPaging="True" PageSize="5" Width="100%"
                            Visible="false"     EmptyDataText="No record found" ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False"  DataKeyNames="line"
                                
               OnSelectedIndexChanged="gvSalesOrder_SelectedIndexChanged"  
               OnPageIndexChanging="gvSalesOrder_PageIndexChanging" CssClass="GridViewStyle" onrowcommand="gvSalesOrder_RowCommand"
                              >
                                <Columns>
                                  
                                  <%--  <asp:TemplateField HeaderText="Line">
                                        <ItemTemplate>
                                      <center>
                                      <asp:LinkButton ID="lnkLine" runat="server" Text='<%# Eval("Line") %>' CommandName="Select"></asp:LinkButton>
                                      </center>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                           
                        <asp:BoundField DataField="Line" HeaderText="Line" />
                            <asp:BoundField DataField="MaterialCode" HeaderText="Material Code" />
                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                             
                             <asp:BoundField DataField="UOM" HeaderText="UOM" />
                              <asp:BoundField DataField="Rate" HeaderText="Rate" />
                              
                             
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


                               <asp:GridView ID="gvSales" Visible="false" runat="server" Width="100%"
                                EmptyDataText="No record found" ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False"  
                                
               OnSelectedIndexChanged="gvSalesOrder_SelectedIndexChanged"  
               OnPageIndexChanging="gvSalesOrder_PageIndexChanging" CssClass="GridViewStyle" onrowcommand="gvSalesOrder_RowCommand"
                              >
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
                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                             
                             <asp:BoundField DataField="UOM" HeaderText="UOM" />
                              <asp:BoundField DataField="Rate" HeaderText="Rate" />
                              
                             
                            
                                  </Columns> 
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                            </asp:GridView>
 </td></tr></table>
  <table width="100%"> <tr>
  <td  align="right"> Material Code :</td><td>
      <asp:DropDownList ID="ddlMaterialCode" runat="server" AutoPostBack="True" 
          onselectedindexchanged="ddlMaterialCode_SelectedIndexChanged"></asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMaterialCode"
                                    Display="None" ErrorMessage="Please select material code" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator2">
                                </asp:ValidatorCalloutExtender>
  </td>
  <td  align="right"> Quantity :</td><td><asp:TextBox ID="txtQUantity" runat="server"  Width="70px"></asp:TextBox><asp:TextBox ID="txtUOM" BackColor="Silver" runat="server"  Width="70px"></asp:TextBox>
  
      <asp:FilteredTextBoxExtender ID="fltr" TargetControlID="txtQUantity" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtQUantity"
                                    Display="None" ErrorMessage="Please enter the quantity" ForeColor="Red" 
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator9">
                                </asp:ValidatorCalloutExtender>
  
  </td>


  <td  align="right"> Rate :</td><td><asp:TextBox ID="txtRate"  runat="server"></asp:TextBox> 
     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtRate" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtRate"
                                    Display="None" ErrorMessage="Please enter the rate" ForeColor="Red" 
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator10">
                                </asp:ValidatorCalloutExtender>
  
  </td>

  </tr></table>
    <table width="100%"> <tr style="height:35%"><td></td></tr></table>
    <table width="100%"><tr align="right"><td width="30%">
       <asp:ImageButton ID="ImgBtnAddLine" ImageUrl="~/Images/btnAddLinegreen.png" 
                      runat="server" Text="Add Line"  ValidationGroup="btnsave" 
            onclick="ImgBtnAddLine_Click"  />
   </td></tr></table>

   <table width="100%"> <tr style="height:35%"><td></td></tr></table>
 

 
    <table width="100%"><tr align="center"><td></td><td>
    <table><tr><td width="30%">
    <asp:ImageButton ID="ImgBtnSave" ImageUrl="~/Images/btnSave.png" 
                      runat="server" Text="Save" onclick="ImgBtnSave_Click"  />
   </td><td width="30%">
            <asp:ImageButton ID="ImgBtnCancel" ImageUrl="~/Images/btnCancel.png" 
                      runat="server" Text="Cancel" onclick="ImgBtnCancel_Click"  /></td><td width="30%">
            <asp:ImageButton ID="ImgBtnExit" ImageUrl="~/Images/btnExit.png" 
                      runat="server" Text="Exit" OnClientClick="window.close();" 
                /></td></tr></table>
   </td><td> </td></tr></table>
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
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Submit" 
                                        CausesValidation="false" onclick="btnSearchlist_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                    <tr>
                        <td>
             
                            <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" PageSize="5" Width="100%"
                                EmptyDataText="No Result match your search criteria." ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False"  DataKeyNames="Orderid"
                                OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"  onpageindexchanging="gridMaster_PageIndexChanging" CssClass="GridViewStyle"
                              >
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
                      
                         <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                        
                                <asp:BoundField DataField="Sales" HeaderText="Sales Type" />
                            <asp:BoundField DataField="CCode" HeaderText="Customer Code" />
                             <asp:BoundField DataField="Date" HeaderText="Date" />
                            
                                   
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
                    <td>   <asp:HiddenField ID="hidCustomerId" runat="server" />
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


