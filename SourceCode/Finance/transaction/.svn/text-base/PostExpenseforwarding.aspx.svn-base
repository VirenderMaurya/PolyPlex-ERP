<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master" AutoEventWireup="true" CodeFile="PostExpenseforwarding.aspx.cs" Inherits="Finance_transaction_PostExpenseforwarding" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../CSS/grid.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/popupstyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:Panel ID="PnlPredefinedHistoryList" runat="server">
  <br />
  <table>
  <tr>
  <td align="left">
      <table width="100%">
          <tr>
              <td align="right" width="50%">
                  Forwarding No:
                  <asp:TextBox ID="Txtforwardingno" runat="server" BackColor="Silver"></asp:TextBox>
              </td>
              <td width="50%">
                  <asp:ImageButton ID="ImgBtnCode" runat="server" CausesValidation="False" 
                      ImageUrl="~/images/select.gif" OnClick="ImgBtnCode_Click" />
              </td>
          </tr>
      </table>
      </td>
  </tr>
      <tr>
          <td align="left">
              </td>
      </tr>
  <tr>
  <td>
  <div style="overflow: scroll;">
  <asp:GridView ID="GdvExpenseforwarding" runat="server"  CssClass="GridViewStyle"
   PageSize="5" AllowPaging="True" Width="100%" ShowHeaderWhenEmpty="true" EmptyDataText="No record found"
   AutoGenerateColumns="False" >
   <RowStyle CssClass="RowStyle" />    
   <SelectedRowStyle  CssClass="SelectedRowStyle" />
   <PagerStyle CssClass="PagerStyle" />
   <AlternatingRowStyle CssClass="AltRowStyle" />
    <HeaderStyle CssClass="HeaderStyle" />
    <Columns>
    <asp:TemplateField Visible="false">
    <ItemTemplate>
    <asp:Label ID="lblvrid" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
    <asp:CheckBox ID="chkbx" runat="server" />
    </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField Visible="false">
    <ItemTemplate>
    <asp:Label ID="lblitemid" runat="server" Text='<%#Eval("LineitemId")%>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <%--<asp:BoundField DataField="LineitemId" HeaderText="LineNo" />--%>
    <asp:BoundField DataField="InvoiceId" HeaderText="Invoice Id" />
    <asp:BoundField DataField="ExpenseType" HeaderText="Expense Type" />
    <asp:BoundField DataField="BillNo" HeaderText="Bill No." />
    <asp:BoundField DataField="BillDate" HeaderText="Bill Date" />
    <asp:BoundField DataField="FYear" HeaderText="Financial Year" />
    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
    <asp:BoundField DataField="Currency" HeaderText="Currency" />
    <asp:BoundField DataField="FxAmount" HeaderText="Foreign Exchange Amount" />
    <asp:BoundField DataField="FxRate" HeaderText="Foreign Exchange Rate" />
    <asp:BoundField DataField="AmountInUsed" HeaderText="Amount(USD)" />
    </Columns>
    </asp:GridView>
   
  </div> 
  </td>
  </tr>
  <tr>
  <td>
      <table width="95%">
          <tr>
              <td width="8%">
                  Voucher Type<font color="red">*</font></td>
              <td width="10%" align="left">
                  <asp:DropDownList ID="DdlVoucherType" runat="server">
                  </asp:DropDownList>
              </td>
              <td width="8%" align="left">
                  Series<font color="red">*</font></td>
              <td width="10%" align="left">
                  <asp:DropDownList ID="DdlVoucherSeries" runat="server">
                  </asp:DropDownList>
              </td>
              <td width="8%" align="left">
                  Voucher Year</td>
              <td width="8%" align="left">
                  <asp:TextBox ID="TxtVoucherYear" runat="server" BackColor="Silver" 
                      Width="70px"></asp:TextBox>
              </td>
              <td width="10%" align="left">
                  Voucher No#</td>
              <td width="8%" align="left">
                  <asp:TextBox ID="TxtVoucherNo" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
              </td>
              <td width="10%" align="left">
                  Voucher Date<font color="red">*</font></td>
              <td width="12%" align="left">
              <asp:TextBox ID="TxtVoucherDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
              <asp:ImageButton ID="imgBtnVoucherDate" runat="server" ImageUrl="~/Images/cal.gif" />
              <asp:CalendarExtender ID="CalVoucherDate" runat="server" PopupButtonID="imgBtnVoucherDate"
              Enabled="True" Format="MM/dd/yyyy" TargetControlID="TxtVoucherDate"></asp:CalendarExtender>
              </td>
          </tr>
          <tr>
              <td width="8%">
                  </td>
              <td width="10%">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                      ControlToValidate="DdlVoucherType" Display="None" 
                      ErrorMessage="Please select voucher type" ForeColor="Red" InitialValue="0" 
                      SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                  <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" CssClass="customCalloutStyle" runat="server" 
                      Enabled="True" TargetControlID="RequiredFieldValidator1">
                  </asp:ValidatorCalloutExtender>
              </td>
              <td width="8%">
                  </td>
              <td width="10%">
                  <asp:RequiredFieldValidator ID="Reqvoucherseries" runat="server" 
                      ControlToValidate="DdlVoucherSeries" Display="None" 
                      ErrorMessage="Please select voucher series" ForeColor="Red" InitialValue="0" 
                      SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                  <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" CssClass="customCalloutStyle" runat="server" 
                      Enabled="True" TargetControlID="Reqvoucherseries">
                  </asp:ValidatorCalloutExtender>
              </td>
              <td width="8%">
                  </td>
              <td width="8%">
                  </td>
              <td width="10%">
                  </td>
              <td width="8%">
                  </td>
              <td width="10%">
                  </td>
              <td width="12%">
                  <asp:RequiredFieldValidator ID="Reqvoucherdate" runat="server" 
                      ControlToValidate="TxtVoucherDate" Display="None" 
                      ErrorMessage="Please select voucher date" ForeColor="Red"  
                      SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                  <asp:ValidatorCalloutExtender ID="Reqvoucherseries0_ValidatorCalloutExtender" CssClass="customCalloutStyle"
                      runat="server" Enabled="True" TargetControlID="Reqvoucherdate">
                  </asp:ValidatorCalloutExtender>
              </td>
          </tr>
          <tr>
              <td width="8%">
             </td>
              <td width="10%">
            </td>
              <td width="8%">
                  <asp:ImageButton ID="Btnsave" ImageUrl="~/Images/btnSave.png" runat="server" onclick="Btnsave_Click" Text="Save" 
                   ValidationGroup="btnsave" />
              </td>
              <td width="10%">
                 <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close()" Text="Cancel" style="font-weight: bold" />
              </td>
              <td width="8%">
               </td>
              <td width="8%">
                  </td>
              <td width="10%">
                  </td>
              <td width="8%">
                  </td>
              <td width="10%">
                  </td>
              <td width="12%">
                  </td>
          </tr>
          <tr>
              <td width="8%">
                  </td>
              <td width="10%">
                  </td>
              <td width="8%">
                  </td>
              <td width="10%">
                  </td>
              <td width="8%">
                  <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Height="400px" 
                      Style="display: none" Width="650px">
                      <asp:Panel ID="Panel3" runat="server" Style="cursor:pointer">
                          <table width="100%">
                              <tr>
                                  <td>
                                      <div style="margin: 10px 0px 10px 20px">
                                          <img src="../../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex"
                                                                    style="border: 1px solid black" />
                                      </div>
                                  </td>
                                  <td valign="top">
                                      <div style="float: right; padding: 10px 10px 0 0">
                                          <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Cancel" 
                                              ImageUrl="~/Images/delete.gif" />
                                      </div>
                                  </td>
                              </tr>
                          </table>
                      </asp:Panel>
                      <div style="margin-left: 20px; margin-right: 20px">
                          <table cellpadding="0px" cellspacing="0px" width="100%">
                              <tr>
                                  <td>
                                      <div class="in_menu_head">
                                          Search Result</div>
                                  </td>
                              </tr>
                              <tr>
                    <td>
                        <br />
                        <table width="100%" cellpadding="0px" cellspacing="0px">
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label runat="server" Text="Search:" ID="lSearchList"></asp:Label>
                                </td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtSearchList" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Search" CausesValidation="false"
                                        OnClick="btnSearchlist_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                              <td>
                                  <asp:Panel ID="pnl_div" runat="server" Height="220px" ScrollBars="Auto" 
                                      Width="605px">
                                      <br />
                                      <asp:GridView ID="GdvExpenseVoucherList" runat="server" AllowPaging="True" 
                                          AutoGenerateColumns="false" DataKeyNames="Id" 
                                          EmptyDataText="No  Result match your search criteria." 
                                          onpageindexchanging="GdvVoucherList_PageIndexChanging" 
                                          OnSelectedIndexChanged="GdvVoucherList_SelectedIndexChanged" PageSize="1" 
                                          ShowHeaderWhenEmpty="True" Width="100%">
                                          <Columns>
                                              <asp:TemplateField HeaderText="Select">
                                                  <ItemTemplate>
                                                      <center>
                                                          <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                                              CommandName="Select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                                      </center>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Voucher Id">
                                                  <ItemTemplate>
                                                      <asp:Label ID="lblid" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Voucher No.">
                                                  <ItemTemplate>
                                                      <asp:Label ID="lblvoucherno" runat="server" Text='<%#Eval("VoucherNo") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Finencial Year">
                                                  <ItemTemplate>
                                                      <asp:Label ID="lblfyear" runat="server" Text='<%#Eval("FYear") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Voucher Date">
                                                  <ItemTemplate>
                                                      <asp:Label ID="lblvoucerdate" runat="server" Text='<%#Eval("VoucherDate") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                          </Columns>
                                          <RowStyle CssClass="RowStyle" />
                                          <SelectedRowStyle CssClass="SelectedRowStyle" />
                                          <PagerStyle CssClass="PagerStyle" />
                                          <AlternatingRowStyle CssClass="AltRowStyle" />
                                          <HeaderStyle CssClass="HeaderStyle" />
                                      </asp:GridView>
                                      <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" 
                                          AutoGenerateColumns="False" CssClass="GridViewStyle" 
                                          DataKeyNames="InvoiceId,BillNo" 
                                          EmptyDataText="No Result match your search criteria." 
                                          onpageindexchanging="gridMaster_PageIndexChanging" 
                                          OnSelectedIndexChanged="gridMaster_SelectedIndexChanged" PageSize="2" 
                                          ShowHeaderWhenEmpty="True" Visible="false" Width="100%">
                                          <Columns>
                                              <asp:TemplateField HeaderText="Select">
                                                  <ItemTemplate>
                                                      <center>
                                                          <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" 
                                                              CommandName="Select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                                      </center>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:BoundField DataField="InvoiceId" HeaderText="Invoice No" />
                                              <asp:BoundField DataField="BillNo" HeaderText="Bill Number" />
                                              <asp:BoundField DataField="BillDate" HeaderText="Bill Date" />
                                          </Columns>
                                          <RowStyle CssClass="RowStyle" />
                                          <SelectedRowStyle CssClass="SelectedRowStyle" />
                                          <PagerStyle CssClass="PagerStyle" />
                                          <AlternatingRowStyle CssClass="AltRowStyle" />
                                          <HeaderStyle CssClass="HeaderStyle" />
                                      </asp:GridView>
                                  </asp:Panel>
                                  <br />
                              </td>
                          </table>
                      </div>
                  </asp:Panel>
              </td>
              <td width="8%">
                  </td>
              <td width="10%">
                  </td>
              <td width="8%">
                  </td>
              <td width="10%">
                  </td>
              <td width="12%">
                  </td>
          </tr>
      </table>
      </td>
  </tr>
  </table>
     <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label8"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"
                PopupDragHandleControlID="Panel3" CancelControlID="ImageButton2" />
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
  </asp:Panel>
  <asp:HiddenField ID="HidPopUpType" runat="server" />
</asp:Content>

