<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="IssueReservation.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
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
                    <asp:Label runat="server" Text="Reservation Year:" ID="Label53"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtReservationYear"></asp:TextBox>
                </td>
                <td align="right" id="TDReservationNo" runat="server">
                    <asp:Label runat="server" Text="Reservation No.:" ID="Label4"></asp:Label>
                </td>
                <td id="TDtxtReservationNo" runat="server">
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtReservationNo"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Issue Reservation Date:" ID="Label6"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIssueReservationDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 5px">
                <td align="right">
                    <asp:Label runat="server" Text="Cost Center:" ID="Label2"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtCostCenter" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/images/select.gif" Height="16px" TabIndex="8"
                        ID="imgCostCenter" OnClick="imgCostCenter_Click"></asp:ImageButton>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Good Recipient:" ID="Label12"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGoodRecipient" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 5px">
                <td align="right">
                    <asp:Label runat="server" Text="Remarks:" ID="Label13"></asp:Label>
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtRemarks" runat="server" MaxLength="25" TabIndex="40" TextMode="MultiLine"
                        Width="95%"></asp:TextBox>
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
                <td colspan="7" style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                    Line Items:
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <div style="overflow: auto; height: 100%; width: 905px; position: relative;">
                        <asp:GridView ID="gvIssueReservation" runat="server" AutoGenerateColumns="false"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            OnRowCommand="gvIssueReservation_RowCommand" OnRowDataBound="gvIssueReservation_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LineNo" HeaderText="LineNo.">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BatchNo" HeaderText="Batch No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialName" HeaderText="Material">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UOM" HeaderText="UOM">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PlantName" HeaderText="Plant">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StorageLocation" HeaderText="Storage Location">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ValuationType" HeaderText="Valuation Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProjectName" HeaderText="Project">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubProject" HeaderText="Sub Project">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Purpose" HeaderText="Purpose">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialId" HeaderText="MaterialId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UOMId" HeaderText="UOMId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PlantID" HeaderText="PlantID">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StorageLocationId" HeaderText="StorageLocationI">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ValuationTypeId" HeaderText="ValuationTypeId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProjectId" HeaderText="ProjectId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubProjectId" HeaderText="SubProjectId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PurposeId" HeaderText="PurposeId">
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
            <tr style="height: 20px">
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
            <tr style="height: 5px">
                <td align="right">
                    <asp:Label runat="server" Text="Batch:" ID="Label9"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBatch" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Material:" ID="Label3"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtMaterial" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/images/select.gif" Height="16px" TabIndex="8" CausesValidation ="false"
                        ID="imgMaterial" OnClick="imgMaterial_Click"></asp:ImageButton>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Plant:" ID="Label1"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPlant" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/images/select.gif" Height="16px" TabIndex="8"  CausesValidation ="false"
                        ID="imgPlant" OnClick="imgPlant_Click"></asp:ImageButton>
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 5px">
                <td align="right">
                    <asp:Label runat="server" Text="Storage Location:" ID="Label8"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStorageLocation" CssClass="txtbx" Width="84%" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Valuation Type:" ID="Label7"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtValuationType" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnValuationType" runat="server" Height="16px" ImageUrl="~/images/select.gif" 
                        TabIndex="8" CausesValidation="False" OnClick="imgBtnValuationType_Click" />
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Project:" ID="Label17"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtProject" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton ID="imgProject" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                        TabIndex="8" CausesValidation="False" OnClick="imgProject_Click" />
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 5px">
                <td align="right">
                    <asp:Label runat="server" Text="Sub Project:" ID="Label10"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtSubProject" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton ID="imgSubProject" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                        TabIndex="8" CausesValidation="False" OnClick="imgSubProject_Click" />
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Purpose:" ID="Label11"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPurpose" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/images/select.gif" Height="16px" TabIndex="8"  CausesValidation ="false"
                        ID="imgPurpose" OnClick="imgPurpose_Click"></asp:ImageButton>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Quantity:" ID="Label15"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server" TabIndex="27" Width="80%" CausesValidation ="false"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" Enabled="True"
                        FilterType="Custom, Numbers" TargetControlID="txtQuantity" ValidChars=".">
                    </asp:FilteredTextBoxExtender>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" PopupPosition="Left"
                        runat="server" Enabled="True" CssClass="customCalloutStyle" TargetControlID="RegularExpressionValidator9">
                    </asp:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationGroup="2" SetFocusOnError="True" ControlToValidate="txtQuantity"
                        Display="None" ErrorMessage="Enter the valid quantity. (Only three digits are allowed after decimal.)"
                        ValidationExpression="^[0-9]+(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 5px">
                <td align="right">
                    <asp:Label runat="server" Text="Stock Quantity:" ID="Label14"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStockQuantity" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                    
                </td>
                <td align="right">
                </td>
                <td>
                </td>
                <td align="right">
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
                    <asp:ImageButton ID="ImgBtnAddLine" runat="server" Text="Cancel" TabIndex="5" ValidationGroup="2"
                        ImageUrl="~/Images/btnAddLine.png" OnClick="ImgBtnAddLine_Click" />
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 20px">
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
                <td colspan="7" align="center">
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" TabIndex="5"
                        ImageUrl="~/Images/btnSave.png" OnClick="ImgBtnSave_Click" />
                    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        TabIndex="5" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close();" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="HidCheckValue" runat="server" />
                    <asp:HiddenField ID="HidPlantId" runat="server" />
                    <asp:HiddenField ID="HidLineNo" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidPopUpType" runat="server" />
                    <asp:HiddenField ID="HidPurpose" runat="server" />
                    <asp:HiddenField ID="hidLineItemId" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidValuationTypeId" runat="server" />
                    <asp:HiddenField ID="HidProjectId" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidMaterialId" runat="server" />
                    <asp:HiddenField ID="HidSubProjectId" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidCostCenter" runat="server" />
                    <asp:HiddenField ID="HidUOMId" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidUpdateGridRecord" runat="server" />
                    <asp:HiddenField ID="HidUOMName" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hidRowIndex" runat="server" />
                    <asp:HiddenField ID="HidAutoId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="1" runat="server"
            ErrorMessage="Cost Center is mandatory." Display="None" ControlToValidate="txtCostCenter"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="2" runat="server"
            ErrorMessage="Material is mandatory." Display="None" ControlToValidate="txtMaterial"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="2" runat="server"
            ErrorMessage="Plant is mandatory." Display="None" ControlToValidate="txtPlant"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender3" runat="server" Enabled="True" PopupPosition="Left"
                TargetControlID="RequiredFieldValidator3">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="2" runat="server"
            ErrorMessage="Storage Location is mandatory." Display="None" ControlToValidate="ddlStorageLocation"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="2" runat="server"
            ErrorMessage="Valuation Type is mandatory." Display="None" ControlToValidate="txtValuationType"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="2" runat="server"
            ErrorMessage="Project is mandatory." Display="None" ControlToValidate="txtProject"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender6" runat="server" Enabled="True" PopupPosition="Left"
                TargetControlID="RequiredFieldValidator6">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="2" runat="server"
            ErrorMessage="Sub Project is mandatory." Display="None" ControlToValidate="txtSubProject"
            SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
            </asp:ValidatorCalloutExtender>
    </div>
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
                            Issue Reservation List</div>
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
                        <asp:GridView ID="gvIssueReservationList" runat="server" AutoGenerateColumns="false"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="3" OnRowCommand="gvIssueReservationList_RowCommand"
                            OnPageIndexChanging="gvIssueReservationList_PageIndexChanging">
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="gridpager" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ReservationNo" HeaderText="Reservation No.">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IssueReservationDate" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReservationYear" HeaderText="Year">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CostCenter" HeaderText="Cost Center">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GoodRecipient" HeaderText="Goods Recipient">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
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
                        <asp:Label ID="lblTotalRecords" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label5"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
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
                                <td style="width: 20%">
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
                        <asp:GridView ID="gvPopUpGrid" runat="server" AutoGenerateColumns="true" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="5" OnPageIndexChanging="gvPopUpGrid_PageIndexChanging"
                            OnRowCommand="gvPopUpGrid_RowCommand" OnRowDataBound="gvPopUpGrid_RowDataBound">
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
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label25"
        PopupControlID="PanelShowPopUpGrid" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel2" CancelControlID="ImgBtnCancelPopUp" />
    <asp:Label ID="Label25" runat="server" Text=""></asp:Label>
</asp:Content>
