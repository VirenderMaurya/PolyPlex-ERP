<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Finance_transaction_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/grid.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="scriptmanager1" runat="server">
     </asp:ScriptManager>
     <table>
      <tr>
               
                <td align="left" width="5%">
                    Start Date</td>
                <td width="12%" align="left">
                <asp:TextBox ID="TxtStartDate" runat="server" Width="70px" BackColor="Silver"></asp:TextBox>
                <asp:ImageButton ID="imgBtnStartDate" runat="server" ImageUrl="~/Images/cal.gif" />
                    <asp:CalendarExtender ID="CalTxtStartDate" runat="server" PopupButtonID="imgBtnStartDate"
                    Enabled="True" Format="MM/dd/yyyy" TargetControlID="TxtStartDate"></asp:CalendarExtender>
                    </td>
                 <td align="left" width="5%">
                     End Date</td>
                <td width="12%" align="left">
                    
                    <asp:TextBox ID="TxtEndDate" runat="server" Width="70px" BackColor="Silver"></asp:TextBox>
                    <asp:ImageButton ID="Imgbtnenddate" runat="server" ImageUrl="~/Images/cal.gif" />
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Imgbtnenddate" 
                    Enabled="True" Format="MM/dd/yyyy" TargetControlID="TxtEndDate"></asp:CalendarExtender>
                </td>
                

            </tr>
                 
     </table>
        <br />
        <asp:GridView ID="gdvsearchlist" runat="server" AutoGenerateColumns="false" 
         Width="100%" onrowcommand="gdvsearchlist_RowCommand1" 
            CssClass="GridViewStyle" AllowPaging="true" PageSize="1"
            onpageindexchanging="gdvsearchlist_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <center>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                CommandArgument='<%#Eval("LineNo") %>' CommandName="select" 
                                ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                        </center>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EntryNo" HeaderText="EntryNo">
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="StartDate" HeaderText="Start Date">
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" HeaderText="End Date">
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="LineNo" HeaderText="LineNo">
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
            </Columns>
         <RowStyle CssClass="RowStyle" />    
         <SelectedRowStyle  CssClass="SelectedRowStyle" />
         <PagerStyle CssClass="PagerStyle" />
         <AlternatingRowStyle CssClass="AltRowStyle" />
         <HeaderStyle CssClass="HeaderStyle" />
         </asp:GridView>
    
   </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <br />
    <br />
    <br />
   <%-- <table cellpadding="1" cellspacing="1" width="100%">
        <caption>
        </caption>
        <tr>
            <td width="15%">
                Asset # <font color="red">*</font>
            </td>
            <td width="8%">
                <asp:TextBox ID="TxtAsset" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td width="10%">
                G.LCode<font color="red">*</font>
            </td>
            <td width="8%">
                <asp:DropDownList ID="DdlGLCode" runat="server">
                </asp:DropDownList>
            </td>
            <td width="10%">
                Cost Center<font color="red">*</font>
            </td>
            <td width="8%">
                <asp:DropDownList ID="DdlCostCenter" runat="server">
                </asp:DropDownList>
            </td>
            <td width="10%">
                Sub-Code<font color="red">*</font>
            </td>
            <td width="8%">
                <asp:DropDownList ID="DdlSubGLCode" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="8%">
                <asp:RequiredFieldValidator ID="Requiredasset" runat="server" 
                    ControlToValidate="TxtAsset" Display="None" ErrorMessage="Please enter asset" 
                    ForeColor="Red" SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
                    Enabled="True" TargetControlID="Requiredasset">
                </asp:ValidatorCalloutExtender>
            </td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="DdlGLCode" Display="None" 
                    ErrorMessage="Please select general ledger code" ForeColor="Red" 
                    InitialValue="0" SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" 
                    Enabled="True" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
            </td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="DdlCostCenter" Display="None" 
                    ErrorMessage="Please select cost center" ForeColor="Red" InitialValue="0" 
                    SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" 
                    Enabled="True" TargetControlID="RequiredFieldValidator2">
                </asp:ValidatorCalloutExtender>
            </td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="DdlSubGLCode" Display="None" 
                    ErrorMessage="Please select sub code" ForeColor="Red" InitialValue="0" 
                    SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" 
                    Enabled="True" TargetControlID="RequiredFieldValidator3">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td width="15%">
                Employee Code</td>
            <td width="8%">
                <asp:TextBox ID="TxtEmpCode" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="TxtEmpCode_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtEmpCode">
                </asp:FilteredTextBoxExtender>
            </td>
            <td width="10%">
                Profit Center<font color="red">*</font></td>
            <td width="8%">
                <asp:DropDownList ID="DdlProfitCenter" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="DdlProfitCenter" Display="None" 
                    ErrorMessage="Please enter profit center" ForeColor="Red" InitialValue="0" 
                    SetFocusOnError="true" ValidationGroup="addgroup"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" 
                    Enabled="True" TargetControlID="RequiredFieldValidator6">
                </asp:ValidatorCalloutExtender>
            </td>
            <td width="10%">
                Fx. Amount</td>
            <td width="8%">
                <asp:TextBox ID="TxtFxAmount" runat="server" Width="100px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="Filteredextender" runat="server" 
                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtFxAmount" 
                    ValidChars=".">
                </asp:FilteredTextBoxExtender>
            </td>
            <td width="10%">
                Debit Amount</td>
            <td width="8%">
                <asp:TextBox ID="TxtDebitAmount" runat="server" Width="100px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="TxtDebitAmount_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="TxtDebitAmount" ValidChars=".">
                </asp:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td width="15%">
            </td>
            <td width="8%">
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
        </tr>
        <tr>
            <td width="15%">
                Credit Amount</td>
            <td width="8%">
                <asp:TextBox ID="TxtCreditAmount" runat="server" Width="100px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="TxtCreditAmount_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="TxtCreditAmount" ValidChars=".">
                </asp:FilteredTextBoxExtender>
            </td>
            <td width="10%">
                Cheque No</td>
            <td width="8%">
                <asp:TextBox ID="TxtChequeNo" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td width="10%">
                Cheque Date
            </td>
            <td width="8%">
                <asp:TextBox ID="TxtChequeDate" runat="server" BackColor="Silver" Width="70px"></asp:TextBox>
                <asp:ImageButton ID="ImageBtnChequeDate" runat="server" 
                    ImageUrl="~/Images/cal.gif" />
                <asp:CalendarExtender ID="TxtChequeDate_CalendarExtender" runat="server" 
                    Enabled="True" Format="MM/dd/yyyy" PopupButtonID="ImageBtnChequeDate" 
                    TargetControlID="TxtChequeDate">
                </asp:CalendarExtender>
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
        </tr>
        <tr>
            <td width="15%">
            </td>
            <td width="8%">
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
        </tr>
        <tr>
            <td width="15%">
                Project</td>
            <td width="8%">
                <asp:DropDownList ID="DdlProject" runat="server" Width="130px">
                </asp:DropDownList>
            </td>
            <td width="10%">
                Sub- Project</td>
            <td width="8%">
                <asp:DropDownList ID="DdlSubProject" runat="server" Width="130px">
                </asp:DropDownList>
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
            <td width="10%">
            </td>
            <td width="8%">
            </td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                Narration</td>
            <td colspan="7">
                <asp:TextBox ID="TxtNarration" runat="server" Height="70px" MaxLength="250" 
                    TextMode="MultiLine" Width="700px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                Total Debit</td>
            <td width="10%">
                <asp:TextBox ID="TxtTotalDebit" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
            </td>
            <td width="8%">
                Total Credit</td>
            <td width="10%">
                <asp:TextBox ID="TxtTotalCredit" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
            </td>
            <td width="8%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td width="8%">
                <asp:Button ID="BtnSave" runat="server" Font-Bold="True" 
                    OnClick="BtnSave_Click" Text="Save" ValidationGroup="voucherheader" 
                    Width="80px" />
            </td>
            <td width="10%">
                <asp:Button ID="BtnAddLine" runat="server" Font-Bold="True" 
                    OnClick="BtnAddLine_Click" Text="Add Line" ValidationGroup="addgroup" 
                    Width="80px" />
            </td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
        </tr>
    </table>--%>
    </form>
</body>
</html>
