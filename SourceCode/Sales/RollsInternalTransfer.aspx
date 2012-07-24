﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Sales/PolyplexMaster.master" AutoEventWireup="true"
    CodeFile="RollsInternalTransfer.aspx.cs" MaintainScrollPositionOnPostback="true"
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
                    <asp:Label runat="server" Text="Year:" ID="Label2"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtYear"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Issue Date:" ID="Label4"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtIssueDate"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Transfer No.:" ID="Label1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtTransferNo"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Transfer From:" ID="Label5"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtTransferFrom" ValidationGroup="1"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/images/select.gif" Height="16px" TabIndex="8"
                        ID="imgTransferFrom" OnClick="imgTransferFrom_Click"></asp:ImageButton>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Transfer To:" ID="Label6"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtTransferTo" ValidationGroup="1"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/images/select.gif" Height="16px" TabIndex="8"
                        ID="imgTransferTo" Style="width: 16px" OnClick="imgTransferTo_Click"></asp:ImageButton>
                </td>
                <td align="right">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Type:" ID="Label11"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="TxtType"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Micron:" ID="Label10"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtMicron"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Core:" ID="Label13"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtCore"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Width (In MM):" ID="Label7"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtWidth"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="txtWidth" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Length (In Mtr):" ID="Label14"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtLength"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" FilterType="Custom, Numbers"
                            TargetControlID="txtLength" ValidChars=".">
                        </asp:FilteredTextBoxExtender>
                </td>
                <td>
                <asp:ImageButton ID="imgbtnSearchInForm" runat="server" ImageUrl="../images/Search-32.png"
                        Height="24px" Width="24px" ValidationGroup="1" OnClick="imgbtnSearchInForm_Click" />                    
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
                <td colspan="3" style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                    <asp:Label runat="server" Text="Rolls Available in WareHouse:" ID="lRollsAvailableinWH"></asp:Label>
                </td>
                <td colspan="3" style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                    <asp:Label runat="server" Text="Rolls Issued:" ID="lRollsIssued"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="3">
                    <div style="overflow: auto; width: 100%; position: relative;">
                        <asp:GridView ID="gvRollAvialable" runat="server" AutoGenerateColumns="false" Width="100%"
                            AllowPaging="false" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            OnRowDataBound="gvRollAvialable_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" OnCheckedChanged="chk_CheckChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InventoryId" HeaderText="InventoryId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RollNo" HeaderText="RollNo">
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
                                <asp:BoundField DataField="Weight" HeaderText="Weight">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="SubFilmTypeId" HeaderText="SubFilmTypeId">
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
                <td colspan="3">
                    <div style="overflow: auto; width: 100%; position: relative;">
                        <asp:GridView ID="gvRollIssused" runat="server" AutoGenerateColumns="false" Width="100%"
                            AllowPaging="false" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            OnRowDataBound="gvRollIssused_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="InventoryId" HeaderText="idRoll">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RollNo" HeaderText="RollNo">
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
                                <asp:TemplateField HeaderText="Weight">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWeight" runat="server" Text='<%# Eval("Weight")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalWeight" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SubFilmTypeId" HeaderText="SubFilmTypeId">
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
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Net Weight:" ID="Label12"></asp:Label>
                </td>
                <td valign="top">
                    <asp:TextBox runat="server" TabIndex="27" Width="22%" ID="txtNetWeight"></asp:TextBox>
                    <asp:Label runat="server" Text="(KG)" ID="Label3"></asp:Label>
                    <asp:TextBox runat="server" TabIndex="27" Width="22%" ID="txtLBS"></asp:TextBox>
                    <asp:Label runat="server" Text="(LBS)" ID="Label8"></asp:Label>
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
                <td>
                </td>
                <td>
                </td>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" TabIndex="5"
                        ImageUrl="~/Images/btnSave.png" OnClick="ImgBtnSave_Click" />
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
                    <asp:HiddenField ID="HidTransferFrom" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidPopUpType" runat="server" />
                    <asp:HiddenField ID="HidTransferTo" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="HidType" runat="server" />
                    <asp:HiddenField ID="HidIsChecked" runat="server" />
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
        <asp:RequiredFieldValidator ID="RFVTransferFrom" runat="server" ErrorMessage="Please select transfer from."
            Display="None" ControlToValidate="txtTransferFrom" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="VCLTransferFrom" runat="server" Enabled="True" TargetControlID="RFVTransferFrom">
            </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RFVTransferTo" runat="server" ErrorMessage="Please select transfer to."
            Display="None" ControlToValidate="txtTransferTo" ValidationGroup="1" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                ID="VCETransferTo" runat="server" Enabled="True" TargetControlID="RFVTransferTo">
            </asp:ValidatorCalloutExtender>
    </div>
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
                                    <asp:Button ID="btnSearchInPopUp" runat="server" TabIndex="10" Text="Submit" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPopUpGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            PageSize="5" EnableColumnViewState="false" Width="100%" OnRowCommand="gvPopUpGrid_RowCommand"
                            OnRowDataBound="gvPopUpGrid_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
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
</asp:Content>
