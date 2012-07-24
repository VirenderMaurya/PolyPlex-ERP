<%@ Page Title="Transfer Value Posting" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="TransferValuePosting.aspx.cs" Inherits="Procurement_TransferValuePosting" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 13px;
        }
    </style>
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
                            Transfer Number
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtTransferNo" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                        </td>
                        <td width="15%" align="right">
                            Transfer Date
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtTransferDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                            <asp:ImageButton ID="Imgtodatevoucherdate" CausesValidation="false" runat="server"
                                ImageUrl="~/Images/cal.gif" />
                            <asp:CalendarExtender ID="CalTransferDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="Imgtodatevoucherdate"
                                TargetControlID="TxtTransferDate">
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
                            Type
                        </td>
                        <td width="15%">
                            <asp:DropDownList ID="DdlType" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td width="10%" align="right">
                            Requested By
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtRequestedBy" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnRequestedBy" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                                OnClick="ImgBtnRequestedBy_Click" />
                        </td>
                        <td align="right" width="15%">
                            Approved By
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtApprovedBy" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnApprovedBy" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                                OnClick="ImgBtnApprovedBy_Click" />
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
                            <asp:RequiredFieldValidator ID="reqrequestedby" runat="server" ControlToValidate="TxtRequestedBy"
                                Display="None" ErrorMessage="Please select Requested By" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="valcaloutrequestedby" runat="server" CssClass="customCalloutStyle"
                                Enabled="True" TargetControlID="reqrequestedby">
                            </asp:ValidatorCalloutExtender>
                        </td>
                        <td width="15%">
                        </td>
                        <td width="15%">
                            <asp:RequiredFieldValidator ID="reqapprovedby" runat="server" ControlToValidate="TxtApprovedBy"
                                Display="None" ErrorMessage="Please select Approved By" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="valcalloutapprovedby" runat="server" CssClass="customCalloutStyle"
                                Enabled="True" PopupPosition="Left" TargetControlID="reqapprovedby">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <caption>
                        <br />
                        <tr>
                            <td width="10%" colspan="6" align="center">
                                <br />
                                <asp:GridView ID="Gdvtransfer" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                    EmptyDataText="No records found" OnRowCommand="Gdvtransfer_RowCommand" OnRowDataBound="Gdvtransfer_RowDataBound"
                                    PageSize="6" ShowHeaderWhenEmpty="true" Width="80%">
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnklineno" runat="server" CausesValidation="false" CommandArgument='<%#Eval("LineNo") %>'
                                                    CommandName="editrow" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Line No">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbllineno" runat="server" Text='<%#Eval("LineNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material Code">
                                            <ItemTemplate>
                                                <asp:Label ID="LblMCode" runat="server" Text='<%#Eval("MaterialCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UOM" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblUOM" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UOM">
                                            <ItemTemplate>
                                                <asp:Label ID="LblUOMText" runat="server" Text='<%#Eval("UOMText") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valuation Type" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblValuationType" runat="server" Text='<%#Eval("ValuationType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valuation Type">
                                            <ItemTemplate>
                                                <asp:Label ID="LblValuationTypeText" runat="server" Text='<%#Eval("ValuationTypeText") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plant" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblPlant" runat="server" Text='<%#Eval("Plant") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plant">
                                            <ItemTemplate>
                                                <asp:Label ID="LblPlantText" runat="server" Text='<%#Eval("PlantText") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Storage">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl" runat="server" Text='<%#Eval("Storage") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Value">
                                            <ItemTemplate>
                                                <asp:Label ID="LblValue" runat="server" Text='<%#Eval("Value") %>'></asp:Label>
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
                                UOM
                            </td>
                            <td width="15%">
                                <asp:DropDownList ID="DdlUOM" runat="server">
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
                                    Display="None" ErrorMessage="Please select Material Code" ForeColor="Red" ValidationGroup="addline"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="valcalloutmaterialcode" runat="server" CssClass="customCalloutStyle"
                                    Enabled="True" TargetControlID="reqmaterialcode">
                                </asp:ValidatorCalloutExtender>
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
                                Plant
                            </td>
                            <td width="15%">
                                <asp:DropDownList ID="DdlPlant" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="10%">
                                Storage Location
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtStorageLocation" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgbtnStorageLocation" runat="server" CausesValidation="False"
                                    ImageUrl="~/images/select.gif" OnClick="ImgbtnStorageLocation_Click" />
                            </td>
                            <td align="right" width="15%">
                                Quantity
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtQuantity" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtQuantity_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtQuantity" ValidChars=".">
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
                                <asp:RequiredFieldValidator ID="reqstoragelocation" runat="server" ControlToValidate="TxtStorageLocation"
                                    Display="None" ErrorMessage="Please select storage location" ForeColor="Red"
                                    ValidationGroup="addline" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" CssClass="customCalloutStyle"
                                    Enabled="True" TargetControlID="reqstoragelocation">
                                </asp:ValidatorCalloutExtender>
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
                                Batch No
                            </td>
                            <td width="15%" colspan="2" style="width: 20%">
                                <asp:TextBox ID="TxtBatch" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnBatchNo" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                                    OnClick="ImgBtnBatchNo_Click" />
                            </td>
                            <td width="15%">
                            </td>
                            <td align="right" width="15%">
                                Value
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtValue" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                    FilterType="Custom, Numbers" TargetControlID="TxtValue" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqbatchno" runat="server" ControlToValidate="TxtBatch"
                                    Display="None" ValidationGroup="addline" ErrorMessage="Please select Batch No"
                                    ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" CssClass="customCalloutStyle"
                                    Enabled="True" TargetControlID="reqbatchno">
                                </asp:ValidatorCalloutExtender>
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
                                                            <asp:BoundField DataField="TransferNumber" HeaderText="Transfer Number" />
                                                            <asp:BoundField DataField="RequestedBy" HeaderText="Requested By" />
                                                            <asp:BoundField DataField="ApprovedBy" HeaderText="Approved By" />
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
                                <asp:HiddenField ID="HiddenField1" runat="server" />
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
