<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="PETPlantFeeding.aspx.cs" Inherits="Production_PETPlantFeeding" %>

<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <table width="100%">
        <tr style="height: 25%">
            <td>
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
                <asp:GridView ID="gvMachinData" runat="server" AllowPaging="True" PageSize="5" Width="100%"
                    EmptyDataText="No record found from machine." ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                    DataKeyNames="autoid" OnSelectedIndexChanged="gvMachinData_SelectedIndexChanged"
                    OnPageIndexChanging="gvMachinData_PageIndexChanging" CssClass="GridViewStyle"
                    OnRowCommand="gvMachinData_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <center>
                                    <asp:ImageButton ID="imgSelect" runat="server" CausesValidation="False" CommandName="Select"
                                        ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="Lbljumbono" runat="server" CommandName="sel" CommandArgument='<% #Eval("METJumboNo")%>'></asp:LinkButton>--%>
                                <asp:Label ID="lblPETPlant" runat="server" Text='<% #Eval("autoid")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Line" HeaderText="Line" />
                        <asp:BoundField DataField="Run_Hrs_HH_Min" HeaderText="Run Hrs (HH:MM)" />
                        <asp:BoundField DataField="Type_Thickness" HeaderText="Type/Thickness" />
                        <asp:BoundField DataField="Lumps_Waste_KG" HeaderText="Lumps Waste (KG)" />
                        <asp:BoundField DataField="Cast_Waste_KG" HeaderText="Cast Waste (KG)" />
                        <asp:BoundField DataField="Mono_Waste_KG" HeaderText="Mono Waste (KG)" />
                        <asp:BoundField DataField="Number_Of_Break" HeaderText="Break" />
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
        <tr style="height: 25%">
            <td>
            </td>
        </tr>
    </table>
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
            <td align="right">
                <asp:Label runat="server" Text="Date:" ID="Label5"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="TxtDate" runat="server" BackColor="Silver" Width="80%"></asp:TextBox>
            </td>
            <td align="right">
                <asp:Label runat="server" Text="Line:" ID="Label6"></asp:Label>
            </td>
            <td>
            <asp:DropDownList ID="ddlLine" runat="server" Width="84%">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLine"
                    Display="None" ErrorMessage="Please select line" ForeColor="Red" InitialValue="0"
                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                    TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
            </td>
            <td align="right">
                <asp:Label runat="server" Text="Run Hrs(Hr:MM):" ID="Label7"></asp:Label>
            </td>
            <td>
             <asp:TextBox ID="txtHrs" runat="server" MaxLength="2" Text="0" Width="37%"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtHrs"
                    runat="server" FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                </asp:FilteredTextBoxExtender>
                <asp:TextBox ID="txtMM" runat="server" MaxLength="2" Text="0" Width="36%"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtMM"
                    runat="server" FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                </asp:FilteredTextBoxExtender>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label runat="server" Text="Type/Thickness:" ID="Label2"></asp:Label>
            </td>
            <td>
            <asp:DropDownList ID="ddlThickness" runat="server" Width="84%">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlThickness"
                    Display="None" ErrorMessage="Please select Type/Thickness" ForeColor="Red" InitialValue="0"
                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                    TargetControlID="RequiredFieldValidator2">
                </asp:ValidatorCalloutExtender>
            </td>
            <td align="right">
                <asp:Label runat="server" Text="Lumps Waste(Kg):" ID="Label3"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="txtLumps" runat="server" Text="0" Width="80%"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fltr" TargetControlID="txtLumps" runat="server"
                    FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                </asp:FilteredTextBoxExtender>
            </td>
            <td align="right">
                <asp:Label runat="server" Text="Cast Waste(Kg):" ID="Label4"></asp:Label>
            </td>
            <td>

            <asp:TextBox ID="txtCast" runat="server" Text="0" Width="80%"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtCast"
                    runat="server" FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                </asp:FilteredTextBoxExtender>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label runat="server" Text="Mono Waste(Kg):" ID="Label8"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="txtMono" runat="server" Text="0" Width="80%"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtMono"
                    runat="server" FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                </asp:FilteredTextBoxExtender>
            </td>
            <td align="right">
                <asp:Label runat="server" Text="Number of Break:" ID="Label9"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="txtBreak" runat="server" Text="0" Width="80%"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtBreak"
                    runat="server" FilterType="Custom, Numbers" ValidChars="." Enabled="True">
                </asp:FilteredTextBoxExtender>
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
                <asp:Label runat="server" Text="Remarks:" ID="Label11"></asp:Label>
            </td>
            <td colspan="5">
            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="45px" Width="96%"></asp:TextBox>
            </td>
            
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
                                OnClick="ImgBtnSave_Click" ValidationGroup="btnsave" />
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
                            AutoGenerateColumns="False" DataKeyNames="autoid" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"
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
                                        <asp:Label ID="lblPETPlant" runat="server" Text='<% #Eval("autoid")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Line" HeaderText="Line" />
                                <asp:BoundField DataField="Run_Hrs_HH_Min" HeaderText="Run Hrs (HH:MM)" />
                                <asp:BoundField DataField="Type_Thickness" HeaderText="Type/Thickness" />
                                <asp:BoundField DataField="Lumps_Waste_KG" HeaderText="Lumps Waste (KG)" />
                                <asp:BoundField DataField="Cast_Waste_KG" HeaderText="Cast Waste (KG)" />
                                <asp:BoundField DataField="Mono_Waste_KG" HeaderText="Mono Waste (KG)" />
                                <asp:BoundField DataField="Number_Of_Break" HeaderText="Break" />
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
