<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/EmptyMaster.master" AutoEventWireup="true"
    CodeFile="RecyclePlantData.aspx.cs" Inherits="Production_RecyclePlantData" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/grid.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <AjaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </AjaxToolkit:ToolkitScriptManager>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <div>
        <center>
            <asp:Panel ID="pnlMachine" runat="server" Width="500px" Style="overflow: auto" GroupingText="Machine Data">
                <asp:GridView ID="gridMachineData" runat="server" AutoGenerateColumns="False" DataKeyNames="AutoId"
                    Width="100%" EmptyDataText="No Machine Data found." PageSize="7" CssClass="GridViewStyle"
                    ShowHeaderWhenEmpty="True" 
                    OnSelectedIndexChanged="gridMachineData_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Select" />
                        <asp:BoundField DataField="Date" DataFormatString="{0:d}" HeaderText="Date" />
                        <asp:BoundField DataField="Line1_Chips_Prod_MT" HeaderText="Chips Production(Line 1)" />
                        <asp:BoundField DataField="Line2_Chips_Prod_MT" HeaderText="Chips Production(Line 2)" />
                        <asp:BoundField DataField="Line3_Chips_Prod_MT" HeaderText="Chips Production(Line 3)" />
                    </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                </asp:GridView>
            </asp:Panel>
        </center>
    </div>
    <table width="100%" cellpadding="3px">
        <tr>
            <td width="30%">
                <div align="right">
                    <asp:ImageButton ID="btn_new" runat="server" ImageUrl="~/Images/btnAdd.png" OnClick="btn_new_Click" /></div>
            </td>
            <td width="20%">
            </td>
            <td width="20%">
            </td>
            <td width="20%">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    <strong>Date</strong></div>
            </td>
            <td>
                <div align="left">
                    <asp:TextBox ID="txtDate" runat="server" Enabled="false"></asp:TextBox>
                    <AjaxToolkit:CalendarExtender ID="Calendarpopup" runat="server" Enabled="True" TargetControlID="txtDate"
                        PopupButtonID="imgcalander">
                    </AjaxToolkit:CalendarExtender>
                    <asp:ImageButton ID="imgcalander" runat="server" ImageUrl="~/Images/cal.gif" /></div>
            </td>
            <td>
                <div align="left">
                    <asp:ImageButton ID="btn_search" runat="server" ImageUrl="~/Images/Search-32.png"
                        Height="24px" Width="24px" OnClick="btn_search_Click" /></div>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="pnlData" runat="server">
                    <table cellpadding="3px" width="100%">
                        <tr>
                            <td width="30%">
                                &nbsp;
                            </td>
                            <td width="20%">
                                <div align="left">
                                    <strong>Line-1</strong>
                                </div>
                            </td>
                            <td width="20%">
                                <div align="left">
                                    <strong>Line-2</strong>
                                </div>
                            </td>
                            <td width="20%">
                                <div align="left">
                                    <strong>Line-3</strong>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Chips Production(MT):
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtcp1" Width="120px" runat="server" Text="0"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtcp2" Width="120px" runat="server" Text="0"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtcp3" Width="120px" runat="server" Text="0"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Chips Consumption(MT):
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtcc1" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtcc2" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtcc3" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Lumps Production(MT):
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtlp1" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtlp2" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtlp3" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Oversize/ Undersize Chips(MT):
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtouc1" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtouc2" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtouc3" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Lumps Consumed(MT):
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtlc1" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtlc2" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtlc3" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Total Down Time(hh:mm):
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txttdtHr1" Width="55px" Text="0" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:TextBox
                                        ID="txttdtMm1" Width="55px" Text="0" runat="server"></asp:TextBox>
                                    <asp:RangeValidator ID="RV1" runat="server" ErrorMessage="Value from 0 to 59 is allowed"
                                        Display="None" ControlToValidate="txttdtMm1" MaximumValue="59" MinimumValue="0"
                                        SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                                    <AjaxToolkit:ValidatorCalloutExtender ID="RV1_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="RV1" CssClass="customCalloutStyle">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txttdtHr2" Width="55px" Text="0" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:TextBox
                                        ID="txttdtMm2" Width="55px" Text="0" runat="server"></asp:TextBox>
                                    <asp:RangeValidator ID="RV2" runat="server" ErrorMessage="Value from 0 to 59 is allowed"
                                        Display="None" ControlToValidate="txttdtMm2" MaximumValue="59" MinimumValue="0"
                                        SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                                    <AjaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                        Enabled="True" TargetControlID="RV2" CssClass="customCalloutStyle">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txttdtHr3" Width="55px" Text="0" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:TextBox
                                        ID="txttdtMm3" Width="55px" Text="0" runat="server"></asp:TextBox>
                                    <asp:RangeValidator ID="RV3" runat="server" ErrorMessage="Value from 0 to 59 is allowed"
                                        Display="None" ControlToValidate="txttdtMm3" MaximumValue="59" MinimumValue="0"
                                        SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                                    <AjaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                        Enabled="True" TargetControlID="RV3" CssClass="customCalloutStyle">
                                    </AjaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    I.V:
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtIv1" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtIv2" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtIv3" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    CPG:
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtCpg1" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtCpg2" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtCpg3" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    End Group:
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txteg1" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txteg2" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txteg3" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align="right">
                                    Ash Content:
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtac1" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtac2" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div align="left">
                                    <asp:TextBox ID="txtac3" Width="120px" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp; &nbsp;
                <asp:ImageButton ID="btn_save" runat="server" ImageUrl="~/Images/btnSave.png" OnClick="btn_save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btn_cancel" runat="server" ImageUrl="~/Images/btnCancel.png"
                    OnClick="btn_cancel_Click" />
                <AjaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" TargetControlID="btn_cancel"
                    ConfirmText="Confirm Exit without saving changes?" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hf_IsNewRecord" runat="server" />
                <asp:HiddenField ID="hf_autoid" runat="server" />
                <asp:HiddenField ID="hf_MachineAutoid" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlrev" runat="server">
                </asp:Panel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:Panel ID="Pnl_Grid_Master" runat="server" Height="445px" Width="650px" CssClass="modalPopup"
        Style="display: none">
        <asp:Panel ID="Pnl_GridMasterDrag" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" /></div>
                    </td>
                    <td valign="top">
                        <div style="float: right; padding: 20px 20px 0 0">
                            <asp:ImageButton ID="btn_grid_master_close" runat="server" AlternateText="Cancel"
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
                            Customer Master</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Date:&nbsp;<asp:Label ID="lblDateGrid" runat="server" Text="Label"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnl_div" runat="server" Height="245px" Width="605px" ScrollBars="Auto">
                            <asp:GridView ID="gridMaster" runat="server" AutoGenerateColumns="false" DataKeyNames="AutoId"
                                Width="100%" EmptyDataText="No  Result found for Selected Date." PageSize="7"
                                CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="gridMaster_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Images/chkbxuncheck.png" Text="Select" /></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Line1_Chips_Prod_MT" HeaderText="Chips Production(Line 1)" />
                                    <asp:BoundField DataField="Line2_Chips_Prod_MT" HeaderText="Chips Production(Line 2)" />
                                    <asp:BoundField DataField="Line3_Chips_Prod_MT" HeaderText="Chips Production(Line 3)" />
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
                </tr>
            </table>
        </div>
    </asp:Panel>
    <AjaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LabelTarget"
        PopupControlID="Pnl_Grid_Master" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Pnl_GridMasterDrag" CancelControlID="btn_grid_master_close" />
    <asp:Label ID="LabelTarget" runat="server" Text=""></asp:Label>
</asp:Content>
