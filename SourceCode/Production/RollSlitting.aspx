<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="RollSlitting.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Production_RollSlitting" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        //    <!- Java Code will come here >
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <div>
        <br />
        <br />
        <table style="width: 100%;">
            <tr valign="bottom">
                <td align="right" width="10%">
                    <asp:Label runat="server" Text="Machine:" ID="lblMachines"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td width="15%">
                    <asp:DropDownList runat="server" ID="ddlMachine">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" width="10%">
                    <asp:Label runat="server" Text="Date:" ID="lblDate"></asp:Label>
                    <span style="color: Red; font-weight: bold">*</span>
                </td>
                <td width="20%">
                    <asp:TextBox ID="txtDate" runat="server" TabIndex="27" Width="80px" BackColor="Silver"></asp:TextBox>
                    <asp:CalendarExtender ID="calExtenderDocumentDate" runat="server" TargetControlID="txtDate"
                        PopupButtonID="imgBtnDocumentDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td align="right" width="10%">
                    <asp:Label runat="server" Text="Shift:" ID="lblShift"></asp:Label>
                </td>
                <td width="15%">
                    <asp:DropDownList runat="server" ID="DdlShift">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" width="10%">
                    <asp:Label runat="server" Text="Set No:" ID="lblSetNo"></asp:Label>
                </td>
                <td width="10%">
                    <asp:DropDownList runat="server" ID="DdlSetNo">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="bottom">
                <td align="right" width="10%">
                </td>
                <td width="15%">
                </td>
                <td align="right" width="10%">
                </td>
                <td width="20%">
                </td>
                <td align="right" width="10%">
                </td>
                <td width="15%">
                </td>
                <td align="right" width="10%">
                </td>
                <td width="10%">
                </td>
            </tr>
            <tr valign="bottom">
                <td align="right" width="10%">
                    <asp:Label runat="server" Text="Arm Code:" ID="Label2"></asp:Label>
                </td>
                <td align="left" width="10%">
                    <asp:DropDownList ID="DdlArmcode" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right" width="10%">
                </td>
                <td width="20%">
                </td>
                <td align="right" width="10%">
                </td>
                <td width="15%">
                </td>
                <td align="right" width="10%">
                </td>
                <td width="10%">
                </td>
            </tr>
            <tr valign="bottom">
                <td align="right" width="10%">
                </td>
                <td width="15%">
                </td>
                <td align="center" colspan="4">
                    -Input Feed-
                </td>
                <td align="right" width="10%">
                </td>
                <td width="10%">
                </td>
            </tr>
            <tr valign="bottom">
                <td align="right" width="10%">
                </td>
                <td align="center" width="15%">
                    Type
                </td>
                <td align="right" width="10%">
                    Micron
                </td>
                <td align="center" width="20%">
                    Width
                </td>
                <td align="left" colspan="2" style="width: 25%" width="10%">
                    Length
                </td>
                <td align="left" width="10%">
                    Qty
                </td>
                <td width="10%">
                </td>
            </tr>
            <tr valign="bottom">
                <td align="right" width="10%">
                </td>
                <td align="center" width="15%">
                    <asp:DropDownList runat="server" ID="DdlType">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" width="10%">
                    <asp:TextBox runat="server" Width="50px" ID="txtMicron"></asp:TextBox>
                </td>
                <td align="center" width="20%">
                    <asp:TextBox runat="server" Width="50px" ID="txtWidth"></asp:TextBox>
                </td>
                <td align="left" colspan="2" style="width: 25%" width="10%">
                    <asp:TextBox runat="server" Width="50px" ID="txtLength"></asp:TextBox>
                </td>
                <td align="left" width="10%">
                    <asp:TextBox runat="server" Width="50px" ID="txtQty"></asp:TextBox>
                </td>
                <td width="10%">
                </td>
            </tr>
            <tr valign="bottom">
                <td align="right" width="10%">
                </td>
                <td width="15%">
                </td>
                <td align="right" width="10%">
                </td>
                <td width="20%">
                </td>
                <td align="right" width="10%">
                </td>
                <td width="15%">
                </td>
                <td align="right" width="10%">
                </td>
                <td width="10%">
                </td>
            </tr>
        </table>
        <asp:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="0" Width="100%">
            <asp:TabPanel ID="TabPanelRollDetails" runat="server" Width="100%" CssClass="tabControl">
                <HeaderTemplate>
                    Roll Details
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:UpdatePanel ID="RollDetailsPanel" runat="server">
                        <ContentTemplate>
                            <div style="overflow: auto; width: 100%; position: relative;">
                                <asp:GridView ID="gvRollDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                    CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                                    OnRowDataBound="gvRollDetails_RowDataBound" OnRowCommand="gvRollDetails_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="LineNo" HeaderText="Line No" />
                                        <asp:BoundField DataField="Micron" HeaderText="Micron" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                        <asp:BoundField DataField="core" HeaderText="Core" />
                                        <asp:BoundField DataField="Width" HeaderText="Width" />
                                        <asp:BoundField DataField="Length" HeaderText="Length" />
                                        <asp:BoundField DataField="Actual_Length" HeaderText="Act Length" />
                                        <asp:BoundField DataField="Actual_Micron" HeaderText="ActMic" />
                                        <asp:BoundField DataField="PCakesNos" HeaderText="PCake" Visible="false" />
                                        <asp:BoundField DataField="QtyInKg" HeaderText="Qty" Visible="false" />
                                        <asp:BoundField DataField="ActualQtyInKg" HeaderText="ActQty" Visible="false" />
                                        <asp:BoundField DataField="SalesOrdNo" HeaderText="SONo" Visible="false" />
                                        <asp:BoundField DataField="SalesOrdLineItemNo" HeaderText="LineItem" Visible="false" />
                                        <asp:BoundField DataField="NoOfJoints" HeaderText="Joints" Visible="false" />
                                        <asp:BoundField DataField="Joint1" HeaderText="Joint1" Visible="false" />
                                        <asp:BoundField DataField="Joint2" HeaderText="Joint2" Visible="false" />
                                        <asp:BoundField DataField="Joint3" HeaderText="Joint3" Visible="false" />
                                        <asp:BoundField DataField="ODMin" HeaderText="ODMin" Visible="false" />
                                        <asp:BoundField DataField="ODAvg" HeaderText="ODAverage" Visible="false" />
                                        <asp:BoundField DataField="ODMax" HeaderText="ODMax" Visible="false" />
                                        <asp:BoundField DataField="Grade" HeaderText="Grade" Visible="false" />
                                        <asp:BoundField DataField="RollCode" HeaderText="RollCode" Visible="false" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" Visible="false" />
                                        <asp:BoundField DataField="MachineArmCode" HeaderText="MachineArmCode" Visible="false" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" CommandArgument='<%#Eval("LineNo") %>'
                                                    CommandName="del" ImageUrl="~/Images/delete.gif" /></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="RowStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                </asp:GridView>
                            </div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text="Micron" ID="Micron"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtMicron2" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" TargetControlID="txtMicron2"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Type" ID="Type"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtType2" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txtType2"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Core" ID="Core"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtCore2" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txtCore2"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Width" ID="Width"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtWidth2" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txtWidth2"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text="Act. Length" ID="ActLength"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtActLength" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" TargetControlID="txtActLength"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Act. Mic" ID="ActMic"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtActMic" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" TargetControlID="txtActMic"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="P.Cake Nos" ID="PCakeNos"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtPCakeNos" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" TargetControlID="txtPCakeNos"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Qty(KG)" ID="Qty"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtQty2" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" TargetControlID="txtQty2"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ActQty" runat="server" Text="Act Qty (KG)"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActQty" runat="server" TabIndex="27" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" TargetControlID="txtActQty"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="Order" runat="server" Text="Order#"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOrder" runat="server" TabIndex="27" Width="80px" BackColor="Silver"></asp:TextBox>
                                        <asp:TextBox ID="TxtOrderLineItem" runat="server" BackColor="Silver" Enabled="false"
                                            TabIndex="27" Width="50px"></asp:TextBox>
                                        <asp:ImageButton ID="ImgOrderNo" runat="server" Height="16px" ImageUrl="~/images/select.gif"
                                            OnClick="imgOrderNo_Click" TabIndex="8" />
                                    </td>
                                    <td>
                                        <asp:Label ID="NoOfJoint" runat="server" Text="No Of Joints"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfJoint" runat="server" TabIndex="27" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" TargetControlID="txtNoOfJoint"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Joint1" ID="Joint1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtJoint1" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" TargetControlID="txtJoint1"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text="Joint2" ID="Joint2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtJoint2" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" TargetControlID="txtJoint2"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Joint3" ID="Joint3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtJoint3" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" TargetControlID="txtJoint3"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="OD Min" ID="ODMin"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtODMin" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" TargetControlID="txtODMin"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="OD Avg" ID="ODAvg"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtODAvg" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" TargetControlID="txtODAvg"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        OD Max
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtODMax" runat="server" TabIndex="27" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" TargetControlID="txtODMax"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        Length
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtRollDetailsLength" runat="server" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" TargetControlID="TxtRollDetailsLength"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
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
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr>
                                    <td width="10%">
                                        <asp:Label runat="server" Text="Grade" ID="Grade"></asp:Label>
                                    </td>
                                    <td width="19%">
                                        <asp:DropDownList ID="DdlGrade" runat="server">
                                            <asp:ListItem Value="">-Select-</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" width="10%">
                                        <asp:Label runat="server" Text="Remarks" ID="Remarks"></asp:Label>
                                    </td>
                                    <td align="left" rowspan="2" valign="top" width="30%">
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtRemarks" Height="50px" TextMode="MultiLine"
                                            Width="300px" MaxLength="250"></asp:TextBox>
                                    </td>
                                    <td width="20%">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="10%">
                                        <asp:Label runat="server" Text="Roll Code" ID="RollCode"></asp:Label>
                                    </td>
                                    <td width="19%">
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtRollCode" Width="80px"></asp:TextBox>
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="20%">
                                        <asp:ImageButton ID="BtnRollDetails" runat="server" ImageUrl="~/Images/btnAddLinegreen.gif"
                                            OnClick="BtnRollDetails_Click" Text="Add Line" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanelPrimaryInputPanel" runat="server" Width="100%" CssClass="tabControl">
                <HeaderTemplate>
                    Primary Input
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:UpdatePanel ID="PrimaryInputPanel" runat="server">
                        <ContentTemplate>
                            <div style="overflow: auto; width: 100%; position: relative;">
                                <asp:GridView ID="gvPrimaryInput" runat="server" AutoGenerateColumns="false" Width="100%"
                                    CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                                    OnRowDataBound="gvPrimaryInput_RowDataBound" OnRowCommand="gvPrimaryInput_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="LineNo" HeaderText="Line No" />
                                        <asp:BoundField DataField="JumboNo" HeaderText="Jumbo No" />
                                        <asp:BoundField DataField="ActualWeight" HeaderText="Actual Weight" />
                                        <asp:BoundField DataField="ActualLength" HeaderText="Actual Length" />
                                        <asp:BoundField DataField="AvailableWeight" HeaderText="Available Weight" />
                                        <asp:BoundField DataField="AvailableLength" HeaderText="Available Length" />
                                        <asp:BoundField DataField="FeedWeight" HeaderText="Feed Weight" />
                                        <asp:BoundField DataField="FeedLength" HeaderText="Feed Length" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" CommandArgument='<%#Eval("LineNo") %>'
                                                    CommandName="del" ImageUrl="~/Images/delete.gif" /></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="RowStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                </asp:GridView>
                            </div>
                            <table style="width: 100%;">
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
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="center" colspan="2">
                                        --Actual--
                                    </td>
                                    <td align="center" colspan="2">
                                        --Available--
                                    </td>
                                    <td align="center" colspan="2">
                                        --Feed--
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        Weight
                                    </td>
                                    <td>
                                        Length
                                    </td>
                                    <td>
                                        Weight
                                    </td>
                                    <td>
                                        Length
                                    </td>
                                    <td>
                                        Weight;
                                    </td>
                                    <td>
                                        Length
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Jumbo No :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPIJumboNo" runat="server" Enabled="true" TabIndex="27" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtPIJumboNo"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPIJumboActualWeight" runat="server" Enabled="true" TabIndex="27"
                                            Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtPIJumboActualWeight"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPIJumboActualLength" runat="server" Enabled="true" TabIndex="27"
                                            Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtPIJumboActualLength"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPIJumboAvailableWeight" runat="server" Enabled="true" TabIndex="27"
                                            Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtPIJumboAvailableWeight"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPIJumboAvailableLength" runat="server" Enabled="true" TabIndex="27"
                                            Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtPIJumboAvailableLength"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPIJumboFeedWeight" runat="server" Enabled="true" TabIndex="27"
                                            Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtPIJumboFeedWeight"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPIJumboFeedLength" runat="server" Enabled="true" TabIndex="27"
                                            Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txtPIJumboFeedLength"
                                            runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td />
                                    <td />
                                    <td />
                                    <td />
                                    <td />
                                    <td />
                                    <td>
                                        <asp:ImageButton ID="BtnAddPrimary" runat="server" ImageUrl="~/Images/btnAddLinegreen.gif"
                                            OnClick="BtnAddPrimary_Click" Text="Add Line" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                </caption>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanelSecondaryInputPanel" runat="server" Width="100%" CssClass="tabControl">
                <HeaderTemplate>
                    Secondary Input
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:UpdatePanel ID="SecondaryInputPanel" runat="server">
                        <ContentTemplate>
                            <div style="overflow: auto; width: 100%; position: relative;">
                                <asp:GridView ID="gvSecondaryInput" runat="server" AutoGenerateColumns="false" Width="100%"
                                    CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                                    OnRowDataBound="gvSecondaryInput_RowDataBound" OnRowCommand="gvSecondaryInput_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="LineNo" HeaderText="Line No" />
                                        <asp:BoundField DataField="JumboNo" HeaderText="Jumbo No" />
                                        <asp:BoundField DataField="ActualWeight" HeaderText="Actual Weight" />
                                        <asp:BoundField DataField="ActualLength" HeaderText="Actual Length" />
                                        <asp:BoundField DataField="AvailableWeight" HeaderText="Available Weight" />
                                        <asp:BoundField DataField="AvailableLength" HeaderText="Available Length" />
                                        <asp:BoundField DataField="FeedWeight" HeaderText="Feed Weight" />
                                        <asp:BoundField DataField="FeedLength" HeaderText="Feed Length" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" CommandArgument='<%#Eval("LineNo") %>'
                                                    CommandName="del" ImageUrl="~/Images/delete.gif" /></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="RowStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                </asp:GridView>
                            </div>
                            <table style="width: 100%;">
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
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="center" colspan="2">
                                        --Actual--
                                    </td>
                                    <td align="center" colspan="2">
                                        --Available--
                                    </td>
                                    <td align="center" colspan="2">
                                        --Feed--
                                    </td>
                                </tr>
                                <caption>
                                    Weight </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            Weight
                                        </td>
                                        <td>
                                            Length
                                        </td>
                                        <td>
                                            Weight
                                        </td>
                                        <td>
                                            Length
                                        </td>
                                        <td>
                                            Weight;
                                        </td>
                                        <td>
                                            Length
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Jumbo No :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSIJumboNo" runat="server" Enabled="true" TabIndex="27" Width="80px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtSIJumboNo"
                                                runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSIJumboActualWeight" runat="server" Enabled="true" TabIndex="27"
                                                Width="80px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtSIJumboActualWeight"
                                                runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSIJumboActualLength" runat="server" Enabled="true" TabIndex="27"
                                                Width="80px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txtSIJumboActualLength"
                                                runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSIJumboAvailableWeight" runat="server" Enabled="true" TabIndex="27"
                                                Width="80px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtSIJumboAvailableWeight"
                                                runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSIJumboAvailableLength" runat="server" Enabled="true" TabIndex="27"
                                                Width="80px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtSIJumboAvailableLength"
                                                runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSIJumboFeedWeight" runat="server" Enabled="true" TabIndex="27"
                                                Width="80px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txtSIJumboFeedWeight"
                                                runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSIJumboFeedLength" runat="server" Enabled="true" TabIndex="27"
                                                Width="80px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txtSIJumboFeedLength"
                                                runat="server" FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td />
                                        <td />
                                        <td />
                                        <td />
                                        <td />
                                        <td />
                                        <td>
                                            <asp:ImageButton ID="BtnAddSecondary" runat="server" ImageUrl="~/Images/btnAddLinegreen.gif"
                                                Text="Add Line" OnClick="BtnAddSecondary_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </caption>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
        <table style="width: 100%;">
            <tr>
                <td align="Center">
                </td>
                <td align="right">
                    Used Total Qty
                </td>
                <td align="Center" width="20%">
                </td>
                <td align="left" class="style6">
                    Input Balance Qty
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right">
                    <asp:TextBox Enabled="false" runat="server" TabIndex="27" ID="txtUsedTotalQty"></asp:TextBox>
                </td>
                <td width="20%">
                </td>
                <td class="style6">
                    <asp:TextBox Enabled="false" runat="server" TabIndex="27" ID="txtInputBalanceQty"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right">
                    <asp:HiddenField ID="HidSalesOrderId" runat="server" />
                </td>
                <td width="20%">
                    <asp:HiddenField ID="HidCustomerId" runat="server" />
                </td>
                <td class="style6">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right">
                    <asp:ImageButton ID="Btnsave" runat="server" ImageUrl="~/Images/btnSave.png" OnClick="btnSave_Click"
                        Text="Save" ValidationGroup="btnsave" />
                </td>
                <td align="center" width="20%">
                    <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png"
                        OnClientClick="window.close()" Text="Cancel" Style="font-weight: bold" />
                </td>
                <td class="style6">
                </td>
            </tr>
        </table>
        <%--Control will come here --%>
    </div>
    <asp:Panel ID="PanelShowPopUpGrid" runat="server" Height="400px" Width="750px" CssClass="modalPopup"
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
        <table width="100%" cellpadding="0px" cellspacing="0px">
            <tr>
                <td>
                    <div class="in_menu_head">
                        <%-- <asp:Label ID="lPopUpHeader" runat="server" Text=""></asp:Label>--%>
                        Search Result
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
                                    OnClick="btnSearchInPopUp_Click1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvPopUpGrid" runat="server" AutoGenerateColumns="false" Width="70%"
                        CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                        AllowPaging="true" PageSize="3" OnRowCommand="gvPopUpGrid_RowCommand" OnRowDataBound="gvPopUpGrid_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <center>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("SalesOrderId") %>'
                                            CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SONo" HeaderText="SO No"></asp:BoundField>
                            <asp:BoundField DataField="SODate" HeaderText="SO Date">
                                <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                <ItemStyle HorizontalAlign="Left" Width="300px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SOCustomer" HeaderText="SOCustomer"></asp:BoundField>
                            <asp:BoundField DataField="CustomerCode" HeaderText="Customer Code"></asp:BoundField>
                            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name"></asp:BoundField>
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
                    <div style="overflow: auto; height: 100%; width: 905px; position: relative;">
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelLineItem" runat="server" Height="400px" Width="750px" CssClass="modalPopup"
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
                            <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table width="100%" cellpadding="0px" cellspacing="0px">
            <tr>
                <td>
                    <div class="in_menu_head">
                        <%-- <asp:Label ID="lPopUpHeader" runat="server" Text=""></asp:Label>--%>
                        Search Result
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 20%">
                                <asp:Label runat="server" Text="Search:" ID="Label1"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox1" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" TabIndex="10" Text="Submit" CausesValidation="false"
                                    OnClick="btnSearchInPopUp_Click1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="overflow: auto; height: 100%; width: 905px; position: relative;">
                        <asp:GridView ID="gvSOLineItems" runat="server" AutoGenerateColumns="false" Width="50%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            OnRowCommand="gvSOLineItems_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("SOLineItemID") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LineNo" HeaderText="LineNo">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubFilmTypeName" HeaderText="SubFilmType">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOMicron" HeaderText="Micron">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOCore" HeaderText="Core">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WidthInMMName" HeaderText="WidthInMM">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOWidthInInch" HeaderText="WidthInInch">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOLengthInMtr" HeaderText="LengthInMtr">
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
        </table>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label9"
        PopupControlID="PanelShowPopUpGrid" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel2" CancelControlID="ImgBtnCancelPopUp" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label10"
        PopupControlID="PanelLineItem" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancelPopUp" />
    <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
</asp:Content>
