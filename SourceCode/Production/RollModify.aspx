<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master" AutoEventWireup="true" CodeFile="RollModify.aspx.cs" Inherits="Production_RollModify" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <div>
    <br /><br />
    <table width="100%">
    <tr>
    <td width="10%"></td><td width="10%"></td><td width="10%"></td><td width="10%"></td>
        <td width="10%">Batch No
                    </td><td width="10%">
                <asp:TextBox ID="TxtBatchNo" runat="server" BackColor="Silver" Width="80px"></asp:TextBox>
                </td><td width="10%">
                <asp:ImageButton
                                    ID="ImageButton3" runat="server" ImageUrl="~/images/select.gif" OnClick="ImgBtnCode_Click"
                                    CausesValidation="False" />
                    </td><td width="10%"></td><td width="10%"></td><td width="10%"></td>
    </tr>
    <tr>
    <td width="10%"></td><td width="10%">Machine
        <span style="color: Red; font-weight: bold">*</span></td>
        <td width="10%">
                    <asp:DropDownList runat="server"  ID="ddlMachine" >
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td><td width="10%">Date
                    <span style="color: Red; font-weight: bold">*</span></td><td width="10%">
                    <asp:TextBox ID="txtDate" runat="server" TabIndex="27" Width="80px" BackColor="Silver" 
                        ></asp:TextBox>
                    <asp:CalendarExtender ID="calExtenderDocumentDate" runat="server" TargetControlID="txtDate"
                        PopupButtonID="imgBtnDocumentDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </td><td width="10%">Shift</td>
        <td width="10%">
                    <asp:DropDownList runat="server"  ID="DdlShift" >
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td><td width="10%">SetNo</td><td width="10%">
                    <asp:DropDownList runat="server"  ID="DdlSetNo" >
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
        <td width="10%"></td>
    </tr>
    <tr>
    <td width="10%"></td><td width="10%"></td><td width="10%"></td>
        <td align="center" colspan="4">--Input Feed--</td>
        <td width="10%"></td><td width="10%"></td><td width="10%"></td>
    </tr>
    <tr>
    <td width="10%"></td><td width="10%"></td><td width="10%">Type</td><td width="10%">
        Micron</td>
        <td width="10%">Width
                </td><td width="10%">Length
                </td><td width="10%">Qty
                </td>
        <td width="10%"></td><td width="10%"></td><td width="10%"></td>
    </tr>
    <tr>
    <td width="10%"></td><td width="10%"></td><td width="10%">
                    <asp:DropDownList runat="server"  ID="DdlType" >
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td><td width="10%">
                    <asp:TextBox runat="server" Width="50px" 
                        ID="txtMicron"></asp:TextBox>
                          <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender18" 
            TargetControlID="txtMicron" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                </td>
        <td width="10%">
                    <asp:TextBox  runat="server" Width="50px" 
                        ID="txtWidth"></asp:TextBox>
                        <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender19" 
            TargetControlID="txtWidth" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                </td><td width="10%">
                    <asp:TextBox runat="server"  Width="50px" 
                        ID="txtLength"></asp:TextBox>
                           <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender20" 
            TargetControlID="txtLength" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                </td><td width="10%">
                    <asp:TextBox runat="server" Width="50px" 
                        ID="txtQty"></asp:TextBox>
                         <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender21" 
            TargetControlID="txtQty" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                </td>
        <td width="10%"></td><td width="10%"></td><td width="10%"></td>
    </tr>
    <tr>
    <td width="10%"></td><td width="10%"></td><td align="center" colspan="3" 
            style="width: 20%">--Used Total--</td><td align="center" colspan="3" 
            style="width: 20%">--Input Balance--</td><td width="10%"></td><td width="10%">
        </td>
    </tr>
    <tr>
    <td width="10%"></td><td width="10%"></td><td width="10%">Width</td><td width="10%">Length</td>
        <td width="10%">Quantity</td><td width="10%">Width</td><td width="10%">Length</td>
        <td width="10%">Quantity</td><td width="10%"></td><td width="10%"></td>
    </tr>
    <tr>
    <td width="10%"></td><td width="10%"></td><td width="10%">
                    <asp:TextBox Enabled="false" runat="server" Width="50px" 
                        ID="TxtUsedTotalWidth"></asp:TextBox>
                </td><td width="10%">
                    <asp:TextBox Enabled="false" runat="server" Width="50px" 
                        ID="TxtUsedTotalLength"></asp:TextBox>
                </td>
        <td width="10%">
                    <asp:TextBox Enabled="false" runat="server" Width="50px" 
                        ID="TxtUsedTotalQuantity"></asp:TextBox>
                </td><td width="10%">
                    <asp:TextBox Enabled="false" runat="server" Width="50px" 
                        ID="TxtInputBalanceWidth"></asp:TextBox>
                </td><td width="10%">
                    <asp:TextBox Enabled="false" runat="server" Width="50px" 
                        ID="TxtInputBalanceLength"></asp:TextBox>
                </td>
        <td width="10%">
                    <asp:TextBox Enabled="false" runat="server" Width="50px" 
                        ID="TxtInputBalanceQuantity"></asp:TextBox>
                </td><td width="10%"></td><td width="10%"></td>
    </tr>
    </table>


       
        <asp:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="0" 
            Width="100%">
            <asp:TabPanel ID="TabPanelRollDetails" runat="server" Width="100%" CssClass="tabControl">
                <HeaderTemplate>
                    Roll Details
</HeaderTemplate>
                
<ContentTemplate>
                    <asp:UpdatePanel ID="RollDetailsPanel" runat="server"><ContentTemplate>
                            <div style="overflow: auto; width: 100%; position: relative;">
                            </div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text="Micron" ID="Micron"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtMicron2" Width="80px"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender1" 
            TargetControlID="txtMicron2" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Type" ID="Type"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtType2" Width="80px"></asp:TextBox>
                                         <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender2" 
            TargetControlID="txtType2" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Core" ID="Core"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtCore2" Width="80px"></asp:TextBox>
                                         <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender3" 
            TargetControlID="txtCore2" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Width" ID="Width"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtWidth2" Width="80px"></asp:TextBox>
                                          <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender4" 
            TargetControlID="txtWidth2" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text="Act. Length" ID="ActLength"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtActLength" Width="80px"></asp:TextBox>
                                         <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender5" 
            TargetControlID="txtActLength" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Act. Mic" ID="ActMic"></asp:Label>

                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtActMic" Width="80px"></asp:TextBox>
                                         <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender6" 
            TargetControlID="txtActMic" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="P.Cake Nos" ID="PCakeNos"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtPCakeNos" Width="80px"></asp:TextBox>
                                         <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender7" 
            TargetControlID="txtPCakeNos" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Qty(KG)" ID="Qty"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtQty2" Width="80px"></asp:TextBox>
                                           <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender8" 
            TargetControlID="txtQty2" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ActQty" runat="server" Text="Act Qty (KG)"></asp:Label>
                                    </td>
                                  
                                    <td>
                                    <asp:TextBox ID="txtActQty" runat="server" TabIndex="27" Width="80px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender9" 
            TargetControlID="txtActQty" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                    <asp:Label ID="Order" runat="server" Text="Order#"></asp:Label>
                                    </td>
                                    <td>
                                    <asp:TextBox ID="txtOrder" runat="server" TabIndex="27" Width="80px" 
                                            BackColor="Silver"></asp:TextBox>

                                        <asp:TextBox ID="TxtOrderLineItem" runat="server" BackColor="Silver" 
                                            Enabled="false" TabIndex="27" Width="50px"></asp:TextBox>
                                        <asp:ImageButton ID="ImgOrderNo" runat="server" Height="16px" 
                                            ImageUrl="~/images/select.gif" OnClick="imgOrderNo_Click" TabIndex="8" />
                                    </td>
                                    <td>
                                    <asp:Label ID="NoOfJoint" runat="server" Text="No Of Joints"></asp:Label>
                                    </td>
                                    <td>
                                    <asp:TextBox ID="txtNoOfJoint" runat="server" TabIndex="27" Width="80px"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender10" 
            TargetControlID="txtNoOfJoint" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Joint1" ID="Joint1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtJoint1" Width="80px"></asp:TextBox>
                                         <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender11" 
            TargetControlID="txtJoint1" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text="Joint2" ID="Joint2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtJoint2" Width="80px"></asp:TextBox>
                                          <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender12" 
            TargetControlID="txtJoint2" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Joint3" ID="Joint3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtJoint3" Width="80px"></asp:TextBox>
                                         <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender13" 
            TargetControlID="txtJoint3" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="OD Min" ID="ODMin"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtODMin" Width="80px"></asp:TextBox>
                                          <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender14" 
            TargetControlID="txtODMin" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="OD Avg" ID="ODAvg"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtODAvg" Width="80px"></asp:TextBox>
                                          <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender15" 
            TargetControlID="txtODAvg" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>OD Max
                                    </td>
                                    <td>
                                                                        <asp:TextBox ID="txtODMax" runat="server" 
    TabIndex="27" Width="80px"></asp:TextBox>
     <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender17" 
            TargetControlID="txtODMax" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                                    <td>Length</td>
                                    <td>
                                       <asp:TextBox ID="TxtRollDetailsLength" runat="server" Width="80px"></asp:TextBox></td>
                                        <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender16" 
            TargetControlID="TxtRollDetailsLength" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
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
                                        <asp:TextBox runat="server" TabIndex="27" ID="txtRemarks" Height="50px" 
                                            TextMode="MultiLine" Width="300px" MaxLength="250"></asp:TextBox>
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
                                        </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
</asp:UpdatePanel>

                
</ContentTemplate>
            
</asp:TabPanel>
         
          </asp:TabContainer>
        <table style="width: 100%;">
            <tr>
                <td>
                    </td>
                <td  align="right">
                 <asp:HiddenField ID="HidSalesOrderId" runat="server" />
                    </td>
                <td width="20%">    <asp:HiddenField ID="HidCustomerId" runat="server" />
                    </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td  align="right">
                                <asp:ImageButton ID="Btnsave" runat="server" ImageUrl="~/Images/btnSave.png" 
                                    OnClick="btnSave_Click" Text="Save"
                                    ValidationGroup="btnsave" />
                </td>
                <td align="center" width="20%">
                                <asp:ImageButton ID="ImgCancel" runat="server"  
                                    ImageUrl="~/Images/btnCancel.png" 
                        OnClientClick="window.close()" Text="Cancel" 
                                    style="font-weight: bold" />
                </td>
                <td class="style6">
                    </td>
            </tr>
        </table>
        <%--Control will come here --%>
    </div>
       <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
        Style="display: none">
        <asp:Panel ID="Panel3" runat="server" Style="cursor:pointer">
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
                  <asp:GridView ID="GdvBatchNo" runat="server" AllowPaging="True" PageSize="5"
                     DataKeyNames="BatchNo" ShowHeaderWhenEmpty="true" EmptyDataText="No Line Item Found"
                     OnSelectedIndexChanged="GdvBatchNo_SelectedIndexChanged" 
                    onpageindexchanging="GdvBatchNo_PageIndexChanging"
                    Width="100%" CssClass="GridViewStyle">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <center>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                        CommandName="Select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
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
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImageButton2" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
   
</asp:Content>

