<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/transaction/PolyplexMaster.master" AutoEventWireup="true" CodeFile="Predefinedentries.aspx.cs" Inherits="Finance_Predefinedentries" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>    
<div align="center" style="margin-top:1000">
<asp:Panel ID="Pnlmain" runat="server">
<asp:UpdatePanel ID="updpanel" runat="server">

 <ContentTemplate>
         <br />
        <asp:Panel ID="Pnlheader" runat="server" BorderColor="#999999" BorderWidth="1">
        <table cellpadding="1px" cellspacing="1px" width="100%">
           <tr>
    <td align="right" colspan="1" width="5%">
        </td>
    <td width="8%">
        </td>
             <td align="right" width="5%"></td>
          <td width="12%">
              </td>
                <td align="right" width="5%">
                    </td>
<td width="12%">
    </td>
                <td align="right" width="5%">
                    </td>
<td width="8%"></td>
               
            </tr>
    <tr>
                <td align="right" colspan="1" width="5%">
                    </td>
                <td width="8%">
                    </td>
                <td align="right" width="5%">
                    </td>
                <td width="12%">
                    </td>
                <td align="right" width="5%">
                    </td>
                <td width="12%">
                    </td>
                <td align="right" width="5%">
                    </td>
                <td width="8%">
                    </td>
       </tr>
    <tr>
           <td align="right" colspan="1" width="5%">
           </td>
           <td width="8%">
           </td>
           <td align="right" width="5%">
           </td>
           <td width="12%">
           </td>
           <td align="right" width="5%">
           </td>
           <td width="12%">
           </td>
           <td align="right" width="5%">
           </td>
           <td width="8%">
           </td>
       </tr>
               
    <tr>
               
                <td align="left" colspan="1" width="5%">
               
                    Entry</td><td width="8%" align="left">
                    

                    <asp:TextBox ID="TxtEntry" runat="server" Width="80px" BackColor="#CCCCCC"></asp:TextBox>
                    

                </td>
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
                <td align="left" width="5%">
                    
                    Planned</td>
                <td width="8%">
               <asp:DropDownList ID="DdlPlanned" runat="server" AutoPostBack="True" 
                      Width="100px" onselectedindexchanged="DdlPlanned_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                

            </tr>
                         
    <tr>
                

                <td align="right" colspan="1" width="5%">
                    

                    </td>
                

                <td width="8%">
                    

                    </td>
                

                <td align="right" width="5%">
                    

                    </td>
                

                <td width="12%" align="left">
                    

                    <asp:RequiredFieldValidator ID="reqstartdate" runat="server" 
                        ControlToValidate="TxtStartDate" Display="None" 
                        ErrorMessage="Please enter start date" ForeColor="Red" SetFocusOnError="true" 
                        ValidationGroup="btnadd"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="valcalvoucherdate" runat="server" 
                        Enabled="True" TargetControlID="reqstartdate">
                        
                        </asp:ValidatorCalloutExtender>
                    

                    </td>
                

                <td align="right" width="5%">
                    

                    </td>
                

                <td width="12%" align="left">
                    

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtEndDate" Display="None" 
                        ErrorMessage="Please enter end date" ForeColor="Red" SetFocusOnError="true" 
                        ValidationGroup="btnadd"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                        Enabled="True" TargetControlID="RequiredFieldValidator1">
                         
 </asp:ValidatorCalloutExtender>
                    

                    </td>
                

                <td align="right" width="5%">
                    

                    </td>
                

                <td width="8%">
                    

                    <asp:RequiredFieldValidator ID="Reqvalplanned" runat="server" 
                        ControlToValidate="DdlPlanned" Display="None" ErrorMessage="Please select plan" 
                        ForeColor="Red" InitialValue="0" SetFocusOnError="true" 
                        ValidationGroup="btnadd"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                        Enabled="True" TargetControlID="Reqvalplanned"></asp:ValidatorCalloutExtender>
                    

                    </td>
                

            </tr>
    <tr>
                <td align="right" colspan="1" width="5%">
                    </td>
                <td width="8%">
                    </td>
                <td align="right" width="5%">
                    </td>
                <td width="12%">
                    </td>
                <td align="right" width="5%">
                    </td>
                <td width="12%">
                    </td>
                <td align="right" width="5%">
                    </td>
                <td width="8%">
                    </td>
       </tr>

          <tr>
                

                <td align="left" colspan="8" width="8%">
                <asp:GridView ID="GdvDescription" runat="server" Visible="false"
                        BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="3px" 
                        CellPadding="3" CellSpacing="2" GridLines="None" PageSize="3" Width="100%">
                        <RowStyle CssClass="RowStyle" />    
                        <SelectedRowStyle  CssClass="SelectedRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                         <HeaderStyle CssClass="HeaderStyle" />
                 </asp:GridView>
                
                   <asp:GridView ID="GdvDescriptionmain" runat="server" AutoGenerateColumns="False" Width="100%"
           
                        onrowcommand="GdvDescriptionmain_RowCommand">
                        <RowStyle CssClass="RowStyle" />     
                        <SelectedRowStyle  CssClass="SelectedRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                         <HeaderStyle CssClass="HeaderStyle" />
              <Columns><asp:TemplateField HeaderText="Line#">
              <ItemTemplate><asp:Label ID="Lbllineno" runat="server" Text='<%#Eval("LineNo") %>'>
              </asp:Label>
              </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="G.L Code">
              <ItemTemplate><asp:Label ID="Lblglcode" runat="server" Text='<%#Eval("GLCode") %>'></asp:Label></ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="S.L Code"><ItemTemplate><asp:Label ID="Lblslcode" runat="server" Text='<%#Eval("SLCode") %>'></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Start Date" >
              <ItemTemplate><asp:Label ID="Lblstartdate" runat="server" Text='<%#Eval("StartDate") %>'></asp:Label></ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="End Date">
              <ItemTemplate><asp:Label ID="Lblenddate" runat="server" Text='<%#Eval("EndDate") %>'>
              </asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Debit Amount">
              <ItemTemplate><asp:Label ID="Lbldebitamount" runat="server" Text='<%#Eval("DebitAmount") %>'>
              </asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Credit Amount">
              <ItemTemplate><asp:Label ID="Lblcreditamount" runat="server" Text='<%#Eval("CreditAmount") %>'>
              </asp:Label>
              </ItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField Visible="false">
              <ItemTemplate><asp:Label ID="Lblplanned" runat="server" Text='<%#Eval("Planned") %>'>
              </asp:Label></ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField Visible="false">
              <ItemTemplate><asp:Label ID="Lblprofitcenter" runat="server" Text='<%#Eval("ProfitCenter") %>'>
              </asp:Label></ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField Visible="False">
              <ItemTemplate>
              <asp:Label ID="Lblcostcenter" runat="server" Text='<%#Eval("CostCenter") %>'></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField Visible="False">
              <ItemTemplate><asp:Label ID="Lbldescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
              </ItemTemplate></asp:TemplateField>
              <asp:TemplateField>
              <ItemTemplate>
              <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="ImgDelete" runat="server"  CommandName="del" CommandArgument='<%#Eval("LineNo") %>'/>
              </ItemTemplate>
              </asp:TemplateField>
              </Columns>
              </asp:GridView>
              </td>
             </tr>
          <tr>
              <td align="left" width="9%">
                 &nbsp;</td>
              <td width="8%">
               &nbsp;</td>
               <td align="left" width="10%">
               &nbsp;</td>
               <td width="7%">
               &nbsp;</td>
              <td width="10%" align="right">
                    

                    &nbsp;</td>
                

                <td width="6%">
                    

                    &nbsp;</td>
                

                <td width="8%" align="left">
                    

                    &nbsp;</td>
                

                <td width="8%">
                    

                    &nbsp;</td>
                

            </tr>
                         

        <tr>
            <td align="left" width="9%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
            <td align="left" width="10%">
                &nbsp;</td>
            <td width="7%">
                &nbsp;</td>
            <td align="right" width="10%">
                &nbsp;</td>
            <td width="6%">
                &nbsp;</td>
            <td align="left" width="8%">
                &nbsp;</td>
            <td width="8%">
                &nbsp;</td>
       </tr>
                         

        </table></asp:Panel>
        <br />
        <br />
        <asp:Panel ID="pnldetails" runat="server" BorderColor="#999999" BorderWidth="1">
        <br />
        <table width="80%" cellspacing="1" cellpadding="1"><tr><td width="10%">&nbsp;G.LCode<font 
                color="red">*</font></td><td width="8%" align="left">
                <asp:DropDownList ID="DdlGLCode" runat="server" Width="130px">
                </asp:DropDownList>   
                <asp:RequiredFieldValidator ID="Reqvalglcode" runat="server" ControlToValidate="DdlGLCode" Display="None"  SetFocusOnError="true" 
                ErrorMessage="Please select general ledger code" 
                ForeColor="Red" ValidationGroup="btnadd" InitialValue="0"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="Reqvalglcode">
             </asp:ValidatorCalloutExtender>
            </td><td width="10%">&nbsp;Profit Center<font 
                color="red">*</font></td><td width="8%">
            <asp:DropDownList ID="DdlProfitCenter" runat="server" Width="130px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="Reqvalprofitcenter" runat="server" ControlToValidate="DdlProfitCenter" Display="None" 
             ErrorMessage="Please select profit center"  SetFocusOnError="true"
            ForeColor="Red" ValidationGroup="btnadd" InitialValue="0"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="Reqvalprofitcenter">
             </asp:ValidatorCalloutExtender>
            </td><td width="10%">&nbsp;Sub GL Code</td><td width="8%">
            <asp:DropDownList ID="DdlSubGLCode" runat="server" Width="130px">
            </asp:DropDownList>
            </td></tr><tr><td width="10%">&#160;</td><td width="8%">&#160;</td><td width="10%">&#160;</td><td width="8%">&#160;</td><td width="10%">&#160;</td><td width="8%">&#160;</td>
                </tr>
            <tr>
                <td width="10%">
                    Cost Center<font color="red">*</font></td>
                <td width="8%" align="left">
                    <asp:DropDownList ID="DdlCostCenter" runat="server" Width="130px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlCostCenter" Display="None"  SetFocusOnError="true" 
                ErrorMessage="Please select cost center" 
                ForeColor="Red" ValidationGroup="btnadd" InitialValue="0"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
             </asp:ValidatorCalloutExtender>
                </td>
                <td width="10%">
                    Debit Amount</td>
                <td width="8%" align="left">
                    <asp:TextBox ID="TxtDebitAmount" runat="server" Width="100px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="TxtDebitAmount_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="TxtDebitAmount" ValidChars="."></asp:FilteredTextBoxExtender>
                </td>
                <td width="10%">
                    Credit Amount</td>
                <td width="8%" align="left">
                    <asp:TextBox ID="TxtCreditAmount" runat="server" Width="100px"></asp:TextBox>
                     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="TxtCreditAmount" ValidChars="."></asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
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
            <td width="10%">Description</td><td align="left" colspan="5">
                <asp:TextBox ID="Txtdescription" runat="server" Height="70px" TextMode="MultiLine" 
                    Width="500px"></asp:TextBox>
                </td></tr><tr><td width="10%">&#160;</td><td width="8%">&#160;</td><td width="10%">
            &nbsp;</td><td width="8%" align="left">
            Total Amount</td><td width="10%" align="left">
                <asp:TextBox ID="TxtTotalAmount" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
            </td><td width="8%">&#160;</td>
            </tr><tr><td width="10%">&#160;</td><td width="8%" align="left"><asp:Button ID="BtnSave" runat="server" Font-Bold="True" 
                                        OnClick="BtnSave_Click" Text="Save" ValidationGroup="voucherheader" 
                                        Width="80px" /></td><td width="10%" align="left">
                    <asp:Button ID="BtnAddLine" runat="server" Font-Bold="True" 
                                        OnClick="BtnAddLine_Click" Text="Add Line" ValidationGroup="btnadd" 
                                        Width="80px" /></td><td width="8%">&#160;</td><td width="10%">&#160;</td><td width="8%">&#160;</td>
            </tr></table>
        </asp:Panel>

         <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
        Style="display: none">
        <asp:Panel ID="Panel3" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 4px 0px 10px 20px">
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
                         Search List</div>
                    </td>
                </tr>

                <%--<tr>
                    <td>
                        <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width:20%">
                            <asp:Label runat="server" Text="Search:" ID="lSearch"></asp:Label>
                            </td>
                            <td  style="width:20%">
                              <asp:TextBox ID="txtSearchFromPopup" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                            </td>
                            <td>
                              <asp:Button ID="btnSearchInPopUp" runat="server" TabIndex="10" Text="Submit" 
                                    CausesValidation="false" />
                            </td>
                        </tr>
                        </table>
                    </td>
                    
                </tr>--%>

                <tr>
                    <td>
                        <asp:GridView ID="gdvsearchlist" onrowcommand="gdvsearchlist_RowCommand" runat="server" AutoGenerateColumns="false" Width="100%"  >
                         <RowStyle CssClass="RowStyle" />    
                        <SelectedRowStyle  CssClass="SelectedRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                         <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="select"
                                                CommandArgument='<%#Eval("Id") %>' ImageUrl="~/Images/radioButton.png"
                                                Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="EntryNo" HeaderText="EntryNo">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="LineNo" HeaderText="LineNo">
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
                                
                            </Columns>
                            <HeaderStyle BackColor="#242E4D" BorderColor="#242E4D" BorderStyle="Solid" BorderWidth="2px"
                                ForeColor="White" Height="15px" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="gridpager" HorizontalAlign="Left" />
                        </asp:GridView>
                        <%--<asp:Label ID="lblTotalRecords" runat="server" Text="Label"></asp:Label>--%>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label3"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
</ContentTemplate>
</asp:UpdatePanel>
 </asp:Panel>
 </div>
</asp:Content>

