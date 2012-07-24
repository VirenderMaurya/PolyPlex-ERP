<%@ Page Title="NonReturnable Gate Pass" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="NonReturnableGatePass.aspx.cs" Inherits="Procurement_NonReturnableGatePass" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
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
                            Year
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtYear" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                        </td>
                        <td width="10%" align="right">
                            NRGP Number
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtNRGPNo" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                        </td>
                        <td width="15%" align="right">
                            NRGP Date
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtNRGPDate" runat="server" BackColor="Silver" Width="65px"></asp:TextBox>
                            <asp:ImageButton ID="ImgNRGPDate" CausesValidation="false" runat="server" ImageUrl="~/Images/cal.gif" />
                            <asp:CalendarExtender ID="CalTransferDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="ImgNRGPDate"
                                TargetControlID="TxtNRGPDate">
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
                            NRGP Type
                        </td>
                        <td width="15%">
                            <asp:DropDownList ID="DdlNRGPType" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td width="10%" align="right">
                            Vendor
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtVendor" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnVendor" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                                OnClick="ImgBtnVendor_Click" />
                        </td>
                        <td align="right" width="15%">
                            Gate Entry
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtGateEntryNo" runat="server" Width="80px"></asp:TextBox>
                        </td>
                    </tr>
                    </caption> </tr>
                    <tr>
                        <td width="15%">
                        </td>
                        <td width="15%">
                            &nbsp;
                        </td>
                        <td width="10%">
                        </td>
                        <td width="15%">
                            <asp:RequiredFieldValidator ID="reqvendor" runat="server" ControlToValidate="TxtVendor"
                                Display="None" ErrorMessage="Please select Vendor" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="valcaloutrequestedby" runat="server" CssClass="customCalloutStyle"
                                Enabled="True" TargetControlID="reqvendor">
                            </asp:ValidatorCalloutExtender>
                        </td>
                        <td width="15%">
                        </td>
                        <td width="15%">
                            <asp:RequiredFieldValidator ID="reqgateentry" runat="server" ControlToValidate="TxtGateEntryNo"
                                Display="None" ErrorMessage="Please select Gate Entry" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="valcalloutgateentry" runat="server" PopupPosition="Left"
                                CssClass="customCalloutStyle" Enabled="True" TargetControlID="reqgateentry">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            Gate Entry Date
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtGateEntryDate" runat="server" BackColor="Silver" Width="65px"></asp:TextBox>
                            <asp:CalendarExtender ID="TxtGateEntryDate_CalendarExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="ImgGateEntryDate" TargetControlID="TxtGateEntryDate">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="ImgGateEntryDate" runat="server" CausesValidation="false" ImageUrl="~/Images/cal.gif" />
                        </td>
                        <td width="10%" align="right">
                            Vehicle No
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtVehicleNo" runat="server" Width="80px"></asp:TextBox>
                        </td>
                        <td width="15%" align="right">
                            Good Reciept
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtGoodReciept" runat="server" Width="80px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">
                            &nbsp;
                        </td>
                        <td width="15%">
                            &nbsp;
                        </td>
                        <td align="right" width="10%">
                            &nbsp;
                        </td>
                        <td width="15%">
                            &nbsp;
                        </td>
                        <td align="right" width="15%">
                            &nbsp;
                        </td>
                        <td width="15%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            &nbsp; GR #
                        </td>
                        <td width="15%" align="left">
                            <asp:TextBox ID="TxtGR" runat="server" Width="80px"></asp:TextBox>
                        </td>
                        <td width="10%" align="right">
                            &nbsp; Credit Note#
                        </td>
                        <td width="15%" align="left">
                            &nbsp;<asp:TextBox ID="TxtCreditNotes" runat="server" Width="80px"></asp:TextBox>
                        </td>
                        <td width="15%">
                            &nbsp;
                        </td>
                        <td width="15%">
                            &nbsp;
                        </td>
                    </tr>
                    </caption>
                    <caption>
                        <br />
                        <tr>
                            <td width="10%" align="center" colspan="6">
                                <br />
                                <asp:GridView ID="GdvGatePass" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                    EmptyDataText="No records found" OnRowCommand="GdvGatePass_RowCommand" OnRowDataBound="GdvGatePass_RowDataBound"
                                    PageSize="3" ShowHeaderWhenEmpty="true" Width="80%">
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnklineno" runat="server" CommandArgument='<%#Eval("LineNo") %>'
                                                    CommandName="editrow" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Line No">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbllineno" runat="server" Text='<%#Eval("LineNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblValuationType" runat="server" Text='<%#Eval("ValuationType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valuation Type">
                                            <ItemTemplate>
                                                <asp:Label ID="LblValuationTypeId" runat="server" Text='<%#Eval("ValuationTypeText") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material Code">
                                            <ItemTemplate>
                                                <asp:Label ID="LblMCode" runat="server" Text='<%#Eval("MaterialCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblPlant" runat="server" Text='<%#Eval("Plant") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plant">
                                            <ItemTemplate>
                                                <asp:Label ID="LblPlantId" runat="server" Text='<%#Eval("PlantText") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Storage Location">
                                            <ItemTemplate>
                                                <asp:Label ID="LblStorageLocation" runat="server" Text='<%#Eval("StorageLocation") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Batch">
                                            <ItemTemplate>
                                                <asp:Label ID="LblBatch" runat="server" Text='<%#Eval("BatchNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="LblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approx Value">
                                            <ItemTemplate>
                                                <asp:Label ID="LblApproxValue" runat="server" Text='<%#Eval("Value") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("LineNo") %>'
                                                    CommandName="del" ImageUrl="~/Images/delete.gif" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <RowStyle CssClass="RowStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                </asp:GridView>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Material Code
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtMaterialCode" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnMaterialCode" runat="server" CausesValidation="False"
                                    ImageUrl="~/images/select.gif" OnClick="ImgBtnMaterialCode_Click" />
                            </td>
                            <td align="right" width="10%">
                                Plant
                            </td>
                            <td width="15%">
                                <asp:DropDownList ID="DdlPlant" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="15%">
                                Valuation Type
                            </td>
                            <td width="15%">
                                <asp:DropDownList ID="DdlValuationType" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqmaterialcode" runat="server" ControlToValidate="TxtMaterialCode"
                                    Display="None" ErrorMessage="Please select Material Code" ForeColor="Red" SetFocusOnError="true"
                                    ValidationGroup="addline"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="valcalloutmaterialcode" runat="server" CssClass="customCalloutStyle"
                                    PopupPosition="Right" Enabled="True" TargetControlID="reqmaterialcode">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="10%">
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqplant" runat="server" ControlToValidate="DdlPlant"
                                    Display="None" ErrorMessage="Please select Plant No" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="addline"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="reqplant0_ValidatorCalloutExtender" runat="server"
                                    CssClass="customCalloutStyle" PopupPosition="Left" Enabled="True" TargetControlID="reqplant">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="15%">
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Batch No
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtBatch" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnBatchNo" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                                    OnClick="ImgBtnBatchNo_Click" />
                            </td>
                            <td width="10%" align="right">
                                Storage Location
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtStorageLocation" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnStorageLocation" runat="server" CausesValidation="False"
                                    ImageUrl="~/images/select.gif" OnClick="ImgBtnStorageLocation_Click" />
                            </td>
                            <td align="right" width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqbatch" runat="server" ControlToValidate="TxtBatch"
                                    Display="None" ErrorMessage="Please select Batch No" ForeColor="Red" ValidationGroup="addline"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="reqbatchno0_ValidatorCalloutExtender" runat="server"
                                    CssClass="customCalloutStyle" Enabled="True" TargetControlID="reqbatch" PopupPosition="Right">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqStorageLocation" runat="server" ControlToValidate="TxtStorageLocation"
                                    Display="None" ValidationGroup="addline" ErrorMessage="Please select Storage Location"
                                    ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="S_ValidatorCalloutExtender" TargetControlID="reqStorageLocation"
                                    runat="server" CssClass="customCalloutStyle" Enabled="True">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td align="right" width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Quantity
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtQuantity" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtQuantity_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtQuantity" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="10%">
                                &nbsp;Value
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtApproxValue" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                    FilterType="Custom, Numbers" TargetControlID="TxtApproxValue" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                &nbsp;
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
                            <td width="15%">
                            </td>
                            <td width="15%">
                            </td>
                            <td width="10%">
                                <asp:ImageButton ID="btnAddLine" runat="server" ValidationGroup="addline" CssClass="Button"
                                    ImageUrl="~/Images/btnAddLinegreen.png" OnClick="btnAddLine_Click" Text="Save" />
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
                                                    <asp:GridView ID="Gdvlookup" runat="server" AllowPaging="True" EmptyDataText="No  Result match your search criteria."
                                                        OnPageIndexChanging="Gdvlookup_PageIndexChanging" OnRowCommand="Gdvlookup_RowCommand"
                                                        OnSelectedIndexChanged="Gdvlookup_SelectedIndexChanged" PageSize="6" ShowHeaderWhenEmpty="True"
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
                                                    <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CssClass="GridViewStyle" DataKeyNames="Id" EmptyDataText="No Result match your search criteria."
                                                        OnPageIndexChanging="gridMaster_PageIndexChanging" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"
                                                        PageSize="6" ShowHeaderWhenEmpty="True" Visible="false" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Select">
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" CommandName="Select"
                                                                            ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                                                    </center>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                                            <asp:BoundField DataField="NRGP Number" HeaderText="Non-RGP Number" />
                                                            <asp:BoundField DataField="NRGPDate" DataFormatString="{0:d}" HeaderText="Non-RGP Date" />
                                                            <asp:BoundField DataField="Vendor" HeaderText="Vendor" />
                                                            <asp:BoundField DataField="GateEntry" HeaderText="Gate Entry" />
                                                            <asp:BoundField DataField="GateEntryDate" DataFormatString="{0:d}" HeaderText="Gate Entry Date" />
                                                        </Columns>
                                                        <RowStyle CssClass="RowStyle" />
                                                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                        <PagerStyle CssClass="PagerStyle" />
                                                        <AlternatingRowStyle CssClass="AltRowStyle" />
                                                        <HeaderStyle CssClass="HeaderStyle" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                    </caption>
                </table>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1"
                PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="True"
                PopupDragHandleControlID="Panel3" CancelControlID="ImageButton2" DynamicServicePath=""
                Enabled="True" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:HiddenField ID="HidPopUpType" runat="server" />
            </td>
            <td width="10%">
            </td>
            <td width="15%">
            </td>
            <td width="15%">
            </td>
            <td width="15%">
            </td>
            </tr> </caption> </table>
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
                        <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png"
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
