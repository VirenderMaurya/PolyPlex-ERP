<%@ Page Title="M.E.G Analysis" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master" AutoEventWireup="true" CodeFile="MEGAnalysis.aspx.cs" Inherits="Procurement_MEGAnalysis" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <asp:UpdatePanel ID="updt" runat="server">
        <ContentTemplate>
            <asp:ToolkitScriptManager ID="tlscriptmanager" runat="server">
            </asp:ToolkitScriptManager>
            <br />
            <asp:Panel ID="Pnlmain" runat="server" BorderWidth="1" BorderColor="#999999">
                <br />
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="15%">
                        </td>
                        <td width="15%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="15%">
                        </td>
                        <td width="15%">
                        </td>
                        <td width="15%">
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                           Voucher Year
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtYear" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                        </td>
                        <td width="10%" align="right">
                           Voucher Number
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtVoucherNo" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                        </td>
                        <td width="15%" align="right">
                           Voucher Date
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtVoucherDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                            <asp:ImageButton ID="Imgtodatevoucherdate" CausesValidation="false" runat="server"
                                ImageUrl="~/Images/cal.gif" />
                            <asp:CalendarExtender ID="CalTransferDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="Imgtodatevoucherdate"
                                TargetControlID="TxtVoucherDate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                        </td>
                        <td width="15%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="15%">
                        </td>
                        <td width="15%">
                        </td>
                        <td width="15%">
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            Vendor Code
                        </td>
                        <td colspan="4">
                        <asp:TextBox ID="TxtVendor" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnVendor" runat="server" CausesValidation="False" 
                                ImageUrl="~/images/select.gif" OnClick="ImgBtnVendor_Click" 
                                style="width: 16px" /> <asp:Label ID="Lblvendorname" runat="server"></asp:Label>
                        </td>
                        <td width="15%">
                         
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%" >
                        
                        </td>
                        <td width="15%" >
                            <asp:RequiredFieldValidator ID="reqvendor" runat="server" 
                                ControlToValidate="TxtVendor" Display="None" 
                                ErrorMessage="Please select Vendor" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="valcaloutrequestedby0" runat="server" 
                                CssClass="customCalloutStyle" Enabled="True" TargetControlID="reqvendor">
                            </asp:ValidatorCalloutExtender>
                            </td>
                        <td width="10%" align="right" >
                        
                        </td>
                        <td width="15%" >
                            </td>
                        <td align="right" width="15%" >
                           
                        </td>
                        <td width="15%" >
                            </td>
                    </tr>
                    </caption> </tr>
                    <caption>
                        <br />
                        <tr>
                            <td align="right" width="15%">
                                Tanker No
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtTankerNo" runat="server" Width="80px"></asp:TextBox>
                            </td>
                            <td align="right" width="10%">
                                GIA No
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtGIANo" runat="server" Width="80px"></asp:TextBox>
                            </td>
                            <td align="right" width="15%">
                                Invoice No
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtInvoiceNo" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtInvoiceNo_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                    TargetControlID="TxtInvoiceNo" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Appearance</td>
                            <td width="15%">
                              <%--  <asp:FilteredTextBoxExtender ID="fltrbaglotno" runat="server" 
                                    Enabled="True" TargetControlID="TxtBagLotNo" FilterType="Custom, Numbers" ValidChars=".">
                                </asp:FilteredTextBoxExtender>--%>
                                <asp:TextBox ID="TxtAppearance" runat="server" Width="80px"></asp:TextBox>
                            </td>
                            <td width="10%" align="right">
                                &nbsp;Alph as such</td>
                            <td width="15%">
                                <asp:TextBox ID="TxtAlpha" runat="server" Width="80px"></asp:TextBox>
                               
                            </td>
                            <td align="right" width="15%">
                                &nbsp;Moisture Wt%</td>
                            <td width="15%">
                                <asp:TextBox ID="TxtMoisture" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtMoisture_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                    TargetControlID="TxtMoisture" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Acidity(%) as Acetic acid</td>
                            <td width="15%">
                                <asp:TextBox ID="TxtAcidity" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtAcidity_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                    TargetControlID="TxtAcidity" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td width="10%" align="right">
                                &nbsp;</td>
                            <td width="15%">
                              <%--  <asp:FilteredTextBoxExtender ID="TxtAlpha_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                    TargetControlID="TxtAlpha" ValidChars=".">
                                </asp:FilteredTextBoxExtender>--%>
                            </td>
                            <td width="15%" align="right">
                            </td>
                            <td width="15%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                            <td align="center" colspan="2" style="width: 25%" width="10%">
                               <b>%Transmittance at</b></td>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                            <td align="right" width="10%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                350 NM</td>
                            <td width="15%">
                                <asp:TextBox ID="TxtNM1" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtNM1_FilteredTextBoxExtender" runat="server" 
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtNM1" 
                                    ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="10%">
                                275 NM</td>
                            <td width="15%">
                                <asp:TextBox ID="TxtNM2" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtNM2_FilteredTextBoxExtender" runat="server" 
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtNM2" 
                                    ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                220 NM</td>
                            <td width="15%">
                                <asp:TextBox ID="TxtNM3" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtNM3_FilteredTextBoxExtender" runat="server" 
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtNM3" 
                                    ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                            <td align="right" width="10%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Aldehyde(ppm)</td>
                            <td width="15%">
                                <asp:TextBox ID="TxtAldehyde" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="fltrhydem" runat="server" 
                                    Enabled="True" TargetControlID="TxtAldehyde" FilterType="Custom, Numbers" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="10%">
                                Specific Gravity</td>
                            <td width="15%">
                                <asp:TextBox ID="TxtSpecificGravity" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtSpecificGravity_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                    TargetControlID="TxtSpecificGravity" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                            <td width="10%">
                            </td>
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Remarks</td>
                            <td colspan="4">
                                <asp:TextBox ID="TxtRemarks" runat="server" TextMode="MultiLine" Width="500px" 
                                    Height="50px"></asp:TextBox>
                               
                            </td>
                            <td width="15%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                            <td width="10%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                            <td width="15%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                            <td width="10%">
                            </td>
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                                <asp:HiddenField ID="hidAutoIdHeader" runat="server" />
                            </td>
                            <td width="15%">
                                <asp:HiddenField ID="HidPopUpType" runat="server" />
                            </td>
                            <td width="10%">
                                <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
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
                                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" AlternateText="Cancel"
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
                                                                <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Search" CausesValidation="false"
                                                                    OnClick="btnSearchlist_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                     <asp:GridView ID="Gdvlookup" runat="server" AllowPaging="True" PageSize="6" OnRowCommand="Gdvlookup_RowCommand"
                                                        EmptyDataText="No  Result match your search criteria." OnSelectedIndexChanged="Gdvlookup_SelectedIndexChanged"
                                                        OnPageIndexChanging="Gdvlookup_PageIndexChanging" ShowHeaderWhenEmpty="True"
                                                        Width="100%">
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
                                                        <AlternatingRowStyle CssClass="AltRowStyle" />
                                                        <HeaderStyle CssClass="HeaderStyle" />
                                                        <PagerStyle CssClass="PagerStyle" />
                                                        <RowStyle CssClass="RowStyle" />
                                                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                    </asp:GridView>
                       <asp:GridView ID="gridMaster" Visible="false" runat="server" AllowPaging="True" PageSize="6"
                       Width="100%" EmptyDataText="No Result match your search criteria." ShowHeaderWhenEmpty="True"
                       AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"
                       CssClass="GridViewStyle" OnPageIndexChanging="gridMaster_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Select">
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Select"
                                                                            ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" Visible="false" />
                                                            <asp:BoundField DataField="VoucherNo" HeaderText="Voucher Number" />
                                                            <asp:BoundField DataField="VoucherDate" HeaderText="Voucher Date" />
                                                            <asp:BoundField DataField="VendorCode" HeaderText="Vendor Code" />
                                                            <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
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
                            </td>
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                        </tr>
                    </caption>
                </table>
                <br />
            </asp:Panel>
            <br />
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="10%">
                    </td>
                    <td width="20%">
                    </td>
                    <td width="10%">
                        <asp:ImageButton ID="btnSave" runat="server" CssClass="Button" ImageUrl="~/Images/btnSave.png"
                            OnClick="btnSave_Click" Text="Save" />
                    </td>
                    <td width="10%">
                        <asp:ImageButton ID="ImgCancel" CausesValidation="false" runat="server" ImageUrl="~/Images/btnCancel.png"
                            OnClientClick="window.close()" Style="font-weight: bold" Text="Cancel" />
                    </td>
                    <td width="10%">
                    </td>
                    <td width="20%">
                    </td>
                    <td width="10%">
                    </td>
                    <td width="10%">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

