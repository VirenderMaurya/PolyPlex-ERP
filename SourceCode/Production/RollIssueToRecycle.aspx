<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master" AutoEventWireup="true" CodeFile="RollIssueToRecycle.aspx.cs" Inherits="Production_RollIssueToRecycle" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
  <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="overflow: auto; height: auto; position: relative;">
        <table style="width: 100%;">
            <tr>
                <td colspan="7" style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                    Machine Data
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <div style="overflow: auto; height: 100%; width: 1005px; position: relative;">
                        <asp:GridView ID="gvJumboIssueToRecycleInterm" runat="server" AutoGenerateColumns="False"
                            CssClass="GridViewStyle" EmptyDataText="No Record Found." ShowHeaderWhenEmpty="True"
                            Width="100%" onrowcommand="gvJumboIssueToRecycleInterm_RowCommand">
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="sel" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BatchNo" HeaderText="Batch No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Issue_Date" HeaderText="Issue Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Original_Weight_Kg" HeaderText="Original Weight (Kg)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Balance_Weight_Kg" HeaderText="Balance Weight (Kg)">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Production_Date" HeaderText="Production Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Original_Length_Mtr" HeaderText="Original Length (Mtr)">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Balance_Length_Mtr" HeaderText="Balance Length (Mtr)">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Issue_Length_Mtr" HeaderText="Issue Length (Mtr)">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Issue_Qty_Kg" HeaderText="Issue Qty (Kg)">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle BackColor="#C6C3C6" CssClass="PagerStyle" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </div>
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
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Batch No:" ID="Label3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtBatchNo"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/images/select.gif" Height="16px" TabIndex="8" CausesValidation ="false"
                        ID="ImgJumboNo" Style="width: 16px" onclick="ImgJumboNo_Click" ></asp:ImageButton>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Issue Date:" ID="Label2"></asp:Label>
                </td>
                <td>
                 <asp:TextBox ID="txtIssueDate" runat="server" BackColor="#c0c0c0" TabIndex="27" Width="74%"></asp:TextBox>
                </td>
                <td align="right">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr style="font-size: small">
                <td colspan="6">
                    &nbsp;</td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="LabelWeight" runat="server" Font-Bold="True" Text="Weight (Kg):"></asp:Label>
                &nbsp;&nbsp;
                    <asp:Label ID="Label88" runat="server" Text="Original:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOriginalWeight" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="Label89" runat="server" Text="Balance:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBalanceWeight" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" Text="Production Date:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProductionDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr style="font-size: small">
                <td colspan="6">
                    
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Length (Mtr):"></asp:Label>&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Original:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOriginalLength" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="Label9" runat="server" Text="Balance:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBalanceLength" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td>
                    
                </td>
                <td>
                    
                </td>
                <td>
                </td>
            </tr>
            <tr style=" height:5px">
                <td colspan="6">
                    
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Issue Length (Mtr):" ID="Label5"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtIssueLength"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="reqlength" runat="server"  SetFocusOnError="true" Display="None" ControlToValidate="txtIssueLength" ErrorMessage="Please enter Issue Length" ForeColor="Red"></asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender
                                            ID="ValCalloutissuedlength" runat="server" Enabled="True" TargetControlID="reqlength">
                                        </asp:ValidatorCalloutExtender>
                     <asp:FilteredTextBoxExtender
                                ID="TxtMetalizer_FilteredTextBoxExtender" 
            TargetControlID="txtIssueLength" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                </td>
                <td align="right">
                <asp:Label runat="server" Text="Issue Quantity (Kg):" ID="Label10"></asp:Label>
                </td>               
                <td>
                 <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtIssueQunatity"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="reqquantity" runat="server"  SetFocusOnError="true" Display="None" ControlToValidate="txtIssueQunatity" ErrorMessage="Please enter Issue Quantity" ForeColor="Red"></asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="reqquantity">
                                        </asp:ValidatorCalloutExtender>
                   <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender1" 
            TargetControlID="txtIssueQunatity" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                  <%--  <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" TabIndex="5"
                        ImageUrl="~/Images/btnSave.png" onclick="ImgBtnSave_Click" />--%>
                    </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td colspan="2" align="center">
               <%--    <asp:ImageButton ID="ImgSave" runat="server" Text="Save" 
                        ImageUrl="~/Images/btnSave.png" onclick="ImgSave_Click"/>--%>
                        <asp:ImageButton ID="ImgSave" runat="server"  
                        ImageUrl="~/Images/btnSave.png" onclick="ImgSave_Click1"/>

                    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        TabIndex="5" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close();" />
                    
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
                <asp:HiddenField ID="HidJumboIssueId" runat="server" />
                <asp:HiddenField ID="HidJumboIssueIntermId" runat="server" />
                </td>
                <td>
                <asp:HiddenField ID="HidJumboId" runat="server" />
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
    <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="750px" CssClass="modalPopup"
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
                            Jumbo Issue To Recycle/Scrap/Wrapping List</div>
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
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Submit" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTotalRecords" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    
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
                     <asp:GridView ID="gvPopUpGrid" runat="server" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="5" onrowcommand="gvPopUpGrid_RowCommand"  >
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoID") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
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
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C6C3C6" 
                                ForeColor="Black" />
                        </asp:GridView>
                        <asp:Label ID="lblTotalRecordsPopUp" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
   
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label7"
        PopupControlID="PanelShowPopUpGrid" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel2" CancelControlID="ImgBtnCancelPopUp" />
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
</asp:Content>

