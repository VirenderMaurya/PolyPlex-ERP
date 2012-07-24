<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master" AutoEventWireup="true" CodeFile="CPChipsQuality.aspx.cs" Inherits="Production_CPChipsQuality" %>




<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
        <table ><tr style="height:10px;"><td></td></tr></table>
         <asp:Panel ID="pnlhead" runat="server" BorderWidth="1" BorderColor="#999999"></asp:Panel>
      <table ><tr style="height:20px;"><td></td></tr></table>

    <table width="100%" align="center">
        <tr>
         <td align="right">Voucher Year:</td><td><asp:TextBox ID="txtVoucherYear" BackColor="Silver" runat="server"></asp:TextBox>
         </td>
         
         <td align="right">Voucher No:</td><td><asp:TextBox ID="txtVoucherNo" BackColor="Silver" runat="server"></asp:TextBox>
         </td>
         
         <td align="right">Voucher Date:</td><td><asp:TextBox ID="txtVoucherDate" BackColor="Silver" runat="server"></asp:TextBox>
         </td>
        </tr>


           <tr>
         <td align="right">Time:</td><td>
            <timesel:TimeSelector ID="TimePickerVoucher" DisplaySeconds="false" 
                                    runat="server" SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector>
         </td>
         
         <td align="right">Type:</td><td>   <asp:DropDownList ID="DdlVoucherType" runat="server" Width="100px">
                                    </asp:DropDownList> <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DdlVoucherType"
                                    Display="None" ErrorMessage="Please select voucher type" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator8">
                                </asp:ValidatorCalloutExtender>
  
         </td>
         
         <td align="right">IV-LAB(dl/gm):</td><td><asp:TextBox ID="txtLab"  runat="server"></asp:TextBox>

          <asp:FilteredTextBoxExtender ID="fltr" TargetControlID="txtLab" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLab"
                                    Display="None" ErrorMessage="Please enter IV-LAB" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
         </td>
        </tr>

           <tr>
         <td align="right">IV-TOV(dl/gm):</td><td><asp:TextBox ID="txtTOV"  runat="server"></asp:TextBox>
         
          <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtTOV" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTOV"
                                    Display="None" ErrorMessage="Please enter IV-TOV" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator2">
                                </asp:ValidatorCalloutExtender>
         </td>
         
         <td align="right">COOH(Meg/Kg):</td><td><asp:TextBox ID="txtCOOH"  runat="server"></asp:TextBox>  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtCOOH" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCOOH"
                                    Display="None" ErrorMessage="Please enter COOH" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator3">
                                </asp:ValidatorCalloutExtender>
         </td>
         
         <td align="right">ASH %:</td><td><asp:TextBox ID="txtASH"  runat="server"></asp:TextBox>
          <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtASH" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtASH"
                                    Display="None" ErrorMessage="Please enter ASH" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator4">
                                </asp:ValidatorCalloutExtender>
         </td>
        </tr>
           <tr>
         <td align="right">DEG %:</td><td><asp:TextBox ID="txtDEG"  runat="server"></asp:TextBox>
           <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtDEG" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDEG"
                                    Display="None" ErrorMessage="Please enter DEG" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator5">
                                </asp:ValidatorCalloutExtender>
         </td>
         
         <td align="right">Chips/gm:</td><td><asp:TextBox ID="txtChips"  runat="server"></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtChips" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtChips"
                                    Display="None" ErrorMessage="Please enter Chips" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator6">
                                </asp:ValidatorCalloutExtender>
         </td>
         
         <td align="right">Colour Visual:</td><td><asp:TextBox ID="txtVisual"  runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtVisual"
                                    Display="None" ErrorMessage="Please enter colour visual" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator7">
                                </asp:ValidatorCalloutExtender>
         </td>
        </tr>
           <tr>
         <td align="right">L *:</td><td><asp:TextBox ID="txtL"  runat="server"></asp:TextBox>
           <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtL" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtL"
                                    Display="None" ErrorMessage="Please enter L *" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator9">
                                </asp:ValidatorCalloutExtender>
         </td>
         
         <td align="right">a *:</td><td><asp:TextBox ID="txta" runat="server"></asp:TextBox>
         <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txta" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txta"
                                    Display="None" ErrorMessage="Please enter a *" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator10">
                                </asp:ValidatorCalloutExtender>
         </td>
         
         <td align="right">b *:</td><td><asp:TextBox ID="txtb"  runat="server"></asp:TextBox>
             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtb" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtb"
                                    Display="None" ErrorMessage="Please enter b *" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator11">
                                </asp:ValidatorCalloutExtender>
         </td>
        </tr>
          <tr>
         <td align="right">Remarks:</td><td colspan="5"><asp:TextBox ID="txtRemarks" 
                  runat="server" TextMode="MultiLine" Rows="3" Width="538px"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtRemarks"
                                    Display="None" ErrorMessage="Please enter remarks" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator12">
                                </asp:ValidatorCalloutExtender>
         </td>
         
         
        </tr>
    </table>

   
     


  <table width="100%"><tr align="center"><td></td><td>
    <table><tr><td width="30%">
    <asp:ImageButton ID="ImgBtnSave" ImageUrl="~/Images/btnSave.png" 
                      runat="server" Text="Save" onclick="ImgBtnSave_Click"  ValidationGroup="btnsave" />
   </td><td width="30%">
            <asp:ImageButton ID="ImgBtnCancel" ImageUrl="~/Images/btnCancel.png" 
                      runat="server" Text="Cancel" onclick="ImgBtnCancel_Click"  /></td><td width="30%">
            <asp:ImageButton ID="ImgBtnExit" ImageUrl="~/Images/btnExit.png" 
                      runat="server" Text="Exit" OnClientClick="window.close();"  /></td></tr></table>
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
                <%--            <asp:GridView ID="Gdvlookup" runat="server" AllowPaging="True" PageSize="5" OnRowCommand="Gdvlookup_RowCommand"
                              EmptyDataText="No  Result match your search criteria."
                                OnSelectedIndexChanged="Gdvlookup_SelectedIndexChanged" OnPageIndexChanging="Gdvlookup_PageIndexChanging"
                                ShowHeaderWhenEmpty="True" Width="100%">
                                 <Columns>
                             <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>                                    
                                </asp:TemplateField>                                
                            </Columns>
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>--%>
                            <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" PageSize="5" Width="100%"
                                EmptyDataText="No Result match your search criteria." ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False"  DataKeyNames="autoid"
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
                               
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                                     <asp:BoundField DataField="VoucherYear" HeaderText="Voucher Year" />
                        <asp:BoundField DataField="VoucherNo" HeaderText="Voucher Nunmber" />
                        <asp:BoundField DataField="voucherDate" HeaderText="voucher Date" />
                                   
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
</asp:Content>


