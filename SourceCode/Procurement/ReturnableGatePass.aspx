<%@ Page Title="Returnable Gate Pass" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="ReturnableGatePass.aspx.cs" Inherits="Procurement_ReturnableGatePass" %>

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
                            Year
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtYear" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                        </td>
                        <td width="10%" align="right">
                            RGP Number
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtRGPNo" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                        </td>
                        <td width="15%" align="right">
                            RGP Date
                        </td>
                        <td width="15%">
                            <asp:TextBox ID="TxtRGPDate" runat="server" BackColor="Silver" Width="65px"></asp:TextBox>
                            <asp:ImageButton ID="Imgtodatevoucherdate" CausesValidation="false" runat="server"
                                ImageUrl="~/Images/cal.gif" />
                            <asp:CalendarExtender ID="CalTransferDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="Imgtodatevoucherdate"
                                TargetControlID="TxtRGPDate">
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
                            RGP Type
                        </td>
                        <td width="15%">
                            <asp:DropDownList ID="DdlRGPType" runat="server">
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
                                PopupButtonID="Imggatentrydate" TargetControlID="TxtGateEntryDate">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="Imggatentrydate" runat="server" CausesValidation="false" ImageUrl="~/Images/cal.gif" />
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
                    </caption>
                    <caption>
                        <br />
                        <tr>
                            <td align="center" colspan="6" width="10%">
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
                                        <asp:TemplateField HeaderText="PO No">
                                            <ItemTemplate>
                                                <asp:Label ID="LblPONo" runat="server" Text='<%#Eval("PurchaseOrder") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material Code">
                                            <ItemTemplate>
                                                <asp:Label ID="LblMCode" runat="server" Text='<%#Eval("MaterialCode") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="BatchNo">
                                            <ItemTemplate>
                                                <asp:Label ID="LblBatch" runat="server" Text='<%#Eval("BatchNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Storage Location">
                                            <ItemTemplate>
                                                <asp:Label ID="LblStorageLocation" runat="server" Text='<%#Eval("StorageLocation") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estimated Date of Return" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblEstimatedDateOfReturned" runat="server" Text='<%#Eval("EstimatedDateOfReturn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approx Value" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblApproxValue" runat="server" Text='<%#Eval("ApproxValue") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Packed" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblPacked" runat="server" Text='<%#Eval("Packed") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gross Weight" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblGrossWeight" runat="server" Text='<%#Eval("GrossWeight") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Net Weight" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblNetWeight" runat="server" Text='<%#Eval("NetWeight") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SerialNo" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSerialNo" runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
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
                                PO #
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtPONumber" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnPONo" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                                    OnClick="ImgBtnPONo_Click" />
                            </td>
                            <td align="right" width="10%">
                                Material Code
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtMaterialCode" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnMaterialCode0" runat="server" CausesValidation="False"
                                    ImageUrl="~/images/select.gif" OnClick="ImgBtnMaterialCode_Click" Style="width: 16px" />
                            </td>
                            <td align="right" width="15%">
                                Plant
                            </td>
                            <td width="15%">
                                <asp:DropDownList ID="DdlPlant" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="ReqPONo" runat="server" ControlToValidate="TxtPONumber"
                                    Display="None" ErrorMessage="Please select PO Number" ForeColor="Red" SetFocusOnError="true"
                                    ValidationGroup="addline"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ReqPONo0_ValidatorCalloutExtender" runat="server"
                                    CssClass="customCalloutStyle" Enabled="True" PopupPosition="Right" TargetControlID="ReqPONo">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="10%">
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqmaterialcode" runat="server" ControlToValidate="TxtMaterialCode"
                                    Display="None" ErrorMessage="Please select Material Code" ForeColor="Red" SetFocusOnError="true"
                                    ValidationGroup="addline"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="reqmaterialcode0_ValidatorCalloutExtender" runat="server"
                                    CssClass="customCalloutStyle" Enabled="True" PopupPosition="Left" TargetControlID="reqmaterialcode">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="15%">
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqplant" runat="server" ControlToValidate="DdlPlant"
                                    Display="None" ErrorMessage="Please select Plant No" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="addline"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="reqplant0_ValidatorCalloutExtender" runat="server"
                                    CssClass="customCalloutStyle" Enabled="True" PopupPosition="Left" TargetControlID="reqplant">
                                </asp:ValidatorCalloutExtender>
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
                                Batch No
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtBatch" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnBatchNo0" runat="server" CausesValidation="False" ImageUrl="~/images/select.gif"
                                    OnClick="ImgBtnBatchNo_Click" />
                            </td>
                            <td align="right" width="10%">
                                Storage Location
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtStorageLocation" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnStorageLocation" runat="server" CausesValidation="False"
                                    ImageUrl="~/images/select.gif" OnClick="ImgBtnStorageLocation_Click" />
                            </td>
                            <td align="right" width="15%">
                                &nbsp;Estimated Date of Return
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtEstimatedDateOfReturn" runat="server" BackColor="Silver" Width="65px"></asp:TextBox>
                                <asp:CalendarExtender ID="TxtEstimatedDateOfReturn_CalendarExtender" runat="server"
                                    Format="MM/dd/yyyy" PopupButtonID="ImgDateOfReturn" TargetControlID="TxtEstimatedDateOfReturn">
                                </asp:CalendarExtender>
                                <asp:ImageButton ID="ImgDateOfReturn" runat="server" CausesValidation="false" ImageUrl="~/Images/cal.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqbatch" runat="server" ControlToValidate="TxtBatch"
                                    Display="None" ErrorMessage="Please select Batch No" ForeColor="Red" SetFocusOnError="true"
                                    ValidationGroup="addline"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="reqbatch0_ValidatorCalloutExtender" runat="server"
                                    CssClass="customCalloutStyle" Enabled="True" PopupPosition="Right" TargetControlID="reqbatch">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="15%">
                                <asp:RequiredFieldValidator ID="reqStorageLocation" runat="server" ControlToValidate="TxtStorageLocation"
                                    Display="None" ErrorMessage="Please select Storage Location" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="addline"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="S_ValidatorCalloutExtender" runat="server" CssClass="customCalloutStyle"
                                    Enabled="True" TargetControlID="reqStorageLocation">
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
                                Approx Value
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtApproxValue" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                    FilterType="Custom, Numbers" TargetControlID="TxtApproxValue" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                Packed
                            </td>
                            <td width="15%">
                                <asp:DropDownList ID="DdlPacked" runat="server">
                                </asp:DropDownList>
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
                                Gross Weight
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtGrossWeight" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtGrossWeight_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtGrossWeight"
                                    ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="10%">
                                Net Weight
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtNetWeight" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtNetWeight_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtNetWeight" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                Serial Number
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TxtSerialNumber" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtSerialNumber_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtSerialNumber"
                                    ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
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
                                <asp:ImageButton ID="btnAddLine" runat="server" CssClass="Button" ImageUrl="~/Images/btnAddLinegreen.png"
                                    OnClick="btnAddLine_Click" Text="Save" ValidationGroup="addline" />
                            </td>
                            <td width="15%">
                                <asp:Panel ID="PnlShowSerach" runat="server" CssClass="modalPopup" Height="400px"
                                    Style="display: none" Width="650px">
                                    <asp:Panel ID="Panel3" runat="server" Style="cursor: pointer">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <div style="margin: 10px 0px 10px 20px">
                                                        <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex"
                                                            style="border: 1px solid black" />
                                                    </div>
                                                </td>
                                                <td valign="top">
                                                    <div style="float: right; padding: 10px 10px 0 0">
                                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" AlternateText="Cancel"
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0px" cellspacing="0px" width="100%">
                                                        <tr>
                                                            <td style="width: 20%">
                                                                <asp:Label ID="lSearchList" runat="server" Text="Search:"></asp:Label>
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:TextBox ID="txtSearchList" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnSearchlist" runat="server" CausesValidation="false" OnClick="btnSearchlist_Click"
                                                                    TabIndex="10" Text="Submit" />
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
                                                            <asp:BoundField DataField="RGP Number" HeaderText="RGP Number" />
                                                            <asp:BoundField DataField="RGPDate" DataFormatString="{0:d}" HeaderText="RGP Date" />
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
                                        </table>
                                    </div>
                                </asp:Panel>
                                <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                                    CancelControlID="ImageButton2" DropShadow="True" DynamicServicePath="" Enabled="True"
                                    PopupControlID="PnlShowSerach" PopupDragHandleControlID="Panel3" TargetControlID="Label1" />
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
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
