<%@ Page Title="Customer Call Service" Language="C#" MasterPageFile="~/Sales/PolyplexMaster.master" AutoEventWireup="true" CodeFile="CustomerCallService.aspx.cs" Inherits="Sales_CustomerCallService" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
<link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
<link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
       <asp:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="1" 
        Width="100%">
        <asp:TabPanel ID="TabPanelMain" runat="server" Width="100%" CssClass="tabControl">
            <HeaderTemplate>
            Header Information</HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel ID="updpanel" runat="server">
                    <ContentTemplate>
                  <table width="100%" cellpadding="1" cellspacing="1">
                    <tr>
                    <td align="right" width="15%">CSCR Type</td><td width="10%">
                        <asp:TextBox ID="TxtCSCRType" runat="server" Width="50px"></asp:TextBox>
                        </td><td align="right" width="35%">Year</td><td width="10%">
                        <asp:TextBox ID="TxtYear" runat="server" Width="80px" BackColor="Silver"></asp:TextBox>
                        </td><td align="right" width="18%">Number</td><td class="style1">
                        <asp:TextBox ID="TxtNumber" runat="server" Width="80px" BackColor="Silver"></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                CSCR Date</td>
                            <td width="10%">
                        <asp:TextBox ID="TxtCSCRDate" runat="server" Width="70px" BackColor="Silver"></asp:TextBox>
                          <asp:CalendarExtender ID="calcscrdate" PopupButtonID="imgcscr" runat="server"
                                Format="MM/dd/yyyy" TargetControlID="TxtCSCRDate" Enabled="True">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="imgcscr" runat="server" ImageUrl="~/Images/cal.gif" />
                                </td>
                            <td align="right" width="35%">
                                (C)omplaint/(O)bservation</td>
                            <td width="10%">
                        <asp:TextBox ID="TxtCSCRObservation" runat="server" Width="50px"></asp:TextBox>
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Customer Code</td>
                            <td colspan="3" style="width: 20%">
                                <asp:TextBox ID="TxtCustomerCode" runat="server" Width="80px" 
                                    BackColor="Silver"></asp:TextBox>
                                <asp:ImageButton ID="imgCustomerCode" runat="server" CausesValidation="false" 
                                    Height="16px" ImageUrl="~/images/select.gif" OnClick="imgCustomerCode_Click" 
                                    TabIndex="8" />
                            <asp:Label ID="lblcustomername" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="18%">
                                Final Customer</td>
                            <td class="style1">
                                <asp:TextBox ID="TxtFinalCustomer" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Contact Person</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtContactPerson" runat="server" Width="80px"></asp:TextBox>
                            </td>
                            <td align="right" width="35%">
                                weight</td>
                            <td width="10%">
                                <asp:TextBox ID="Txtweight" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="fltrweight" TargetControlID="Txtweight" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="18%">
                                Value</td>
                            <td class="style1">
                                <asp:TextBox ID="TxtValue" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="fltrvalue" TargetControlID="TxtValue" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Currency</td>
                            <td width="10%">
                                <asp:DropDownList ID="DdlCurrency" runat="server">
                                </asp:DropDownList>
                                </td>
                            <td align="right" width="35%">
                                Sample Recieved</td>
                            <td width="10%">
                                <asp:CheckBox ID="Chksamplerecieved" runat="server" />
                                </td>
                            <td align="right" width="18%">
                                Credit Notes</td>
                            <td class="style1">
                                <asp:TextBox ID="TxtCreditNotes" runat="server" Width="80px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Nature of Complaint</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtNatureOfCompaint" runat="server" Width="80px" 
                                    BackColor="Silver"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnComplaint" runat="server" CausesValidation="False" 
                                    ImageUrl="~/images/select.gif" OnClick="ImgBtnComplaint_Click" 
                                    style="width: 16px" />
                            </td>
                            <td align="right" width="35%">
                                Customer Claim #</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtCustomerClaim" runat="server" Width="80px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="fltrclaim" TargetControlID="TxtCustomerClaim" runat="server"
                                FilterType="Numbers,Custom"  ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                Photo Recieved</td>
                            <td class="style1">
                                <asp:CheckBox ID="Chkphotorecieved" runat="server" />
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Area Of Complaint</td>
                            <td width="10%">
                                <asp:DropDownList ID="DdlAreaofComplaint" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="35%">
                                OUR D.A No</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtOurDANo" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="fltrdano" TargetControlID="TxtOurDANo" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="18%">
                                No. Of Rolls</td>
                            <td class="style1">
                                <asp:TextBox ID="TxtNoofRolls" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender1" TargetControlID="TxtNoofRolls" runat="server"
                                FilterType="Numbers"  Enabled="True">
                            </asp:FilteredTextBoxExtender>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                First Response</td>
                            <td align="left" width="10%">
                                <asp:TextBox ID="TxtFirstResponse" runat="server" Width="70px" 
                                    BackColor="Silver"></asp:TextBox>                                
                            
                                <asp:CalendarExtender ID="calfirstresp" runat="server" Enabled="True" 
                                    Format="MM/dd/yyyy" PopupButtonID="imgfirstresponse" TargetControlID="TxtFirstResponse">
                                </asp:CalendarExtender>
                                <asp:ImageButton ID="imgfirstresponse" runat="server" ImageUrl="~/Images/cal.gif" />
                            
                                </td>
                            <td align="right" width="35%">
                                First Dely By</td>
                            <td align="left" width="10%">
                                <asp:DropDownList ID="DdlFirstDelyBy" runat="server">
                                <asp:ListItem  Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem  Text="A" Value="1"></asp:ListItem>
                                <asp:ListItem  Text="B" Value="2"></asp:ListItem>
                                <asp:ListItem  Text="C" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="18%">
                                Second Response</td>
                            <td align="left" class="style1">
                                <asp:TextBox ID="TxtSecondResponse" runat="server" Width="70px" 
                                    BackColor="Silver"></asp:TextBox>
                                                        
                                                                                                                                 <asp:ImageButton ID="Imgsecresp" runat="server" ImageUrl="~/Images/cal.gif" />
                            
                                 
                                 
                                 
                                 
                                 
                                 <asp:CalendarExtender ID="calsecondresp" runat="server" Enabled="True" 
                                    Format="MM/dd/yyyy" PopupButtonID="Imgsecresp" TargetControlID="TxtSecondResponse">
                                </asp:CalendarExtender>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td align="left" width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td align="right" width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td align="right" class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Second Dely By</td>
                            <td width="10%">
                                <asp:DropDownList ID="DdlSecondDelyBy" runat="server">
                                <asp:ListItem  Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem  Text="A" Value="1"></asp:ListItem>
                                <asp:ListItem  Text="B" Value="2"></asp:ListItem>
                                <asp:ListItem  Text="C" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="35%">
                                Third Response</td>
                            <td align="left" width="10%">
                                <asp:TextBox ID="TxtThirdResponse" runat="server" Width="70px" 
                                    BackColor="Silver"></asp:TextBox>
                                                                                                <asp:ImageButton ID="Imgthirdresp" runat="server" ImageUrl="~/Images/cal.gif" />
                            
                                  
                                  <asp:CalendarExtender ID="calexthirdresp" runat="server" Enabled="True" 
                                    Format="MM/dd/yyyy" PopupButtonID="Imgthirdresp" TargetControlID="TxtThirdResponse">
                                </asp:CalendarExtender>
                            </td>
                            <td align="right" width="18%">
                                Third Dely By</td>
                            <td align="left" class="style1">
                                <asp:DropDownList ID="DdlThirdDelyBy" runat="server">
                                <asp:ListItem  Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem  Text="A" Value="1"></asp:ListItem>
                                <asp:ListItem  Text="B" Value="2"></asp:ListItem>
                                <asp:ListItem  Text="C" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td align="right" width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td align="right" class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                T.S. Observations</td>
                            <td colspan="3" style="width: 20%">
                                <asp:TextBox ID="TxtObservations" runat="server" Height="50px" 
                                    TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            <td align="right" width="18%">
                                OPLS</td>
                            <td class="style1">
                                <asp:TextBox ID="TxtOLPS" runat="server" Width="80px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%" align="center">
                                Action Plan</td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                Action Taken</td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="width: 50%">
                                <asp:TextBox ID="TxtActioPlan" runat="server" MaxLength="250" Height="50px" 
                                    TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            <td width="10%" align="center" colspan="3">
                                <asp:TextBox ID="TxtActionTaken" runat="server" MaxLength="250" Height="50px" 
                                    Width="300px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Return Quality</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtReturnQuality" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender
                                ID="fltrreturnquan" TargetControlID="TxtReturnQuality" runat="server"
                                FilterType="Numbers" Enabled="True">
                            </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="35%">
                                Return Value</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtReturnValue" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="fltrreturnvalue" TargetControlID="TxtReturnValue" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                               <asp:HiddenField ID="hidcomplaintid" runat="server" />
                                </td>
                            <td width="10%">
                             <asp:HiddenField ID="HidPopUpType" runat="server" />
                             
                                </td>
                            <td align="right" width="35%">
                                </td>
                            <td width="10%">
                             <asp:HiddenField ID="hidCustomerId" runat="server" />
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="35%">
                                <asp:ImageButton ID="BtnSave" ImageUrl="~/Images/btnSave.png" runat="server" 
                                    Text="Save" onclick="BtnSave_Click" />
                                </td>
                            <td width="10%">
                               <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close()" Text="Cancel" style="font-weight: bold" />
                            </td>
                            <td align="right" width="18%">
                                </td>
                            <td class="style1">
                                </td>
                        </tr>
                    </table>
                    </ContentTemplate>
               </asp:UpdatePanel>
            </ContentTemplate>
        </asp:TabPanel>
          <asp:TabPanel ID="TabPaneldetails" runat="server" Width="100%" CssClass="tabControl">
            <HeaderTemplate>
            Details</HeaderTemplate>
            <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                     <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td width="25%" align="right">
                Complaint Description</td>
            <td colspan="4">
                <asp:TextBox ID="TxtComplaintDescription" runat="server" Width="350px" 
                    Height="60px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td width="10%">
            </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                Expected Date of Completion</td>
            <td width="15%">
                <asp:TextBox ID="TxtExpectedDateofCompletion" runat="server" BackColor="Silver" 
                    Width="80px"></asp:TextBox>
                       <asp:CalendarExtender ID="calexpectedate" PopupButtonID="Imgexpdate" runat="server"
                                Format="MM/dd/yyyy" TargetControlID="TxtExpectedDateofCompletion" Enabled="True">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="Imgexpdate" runat="server" ImageUrl="~/Images/cal.gif" />
            </td>
            <td width="20%" align="right">
                Responsible Person</td>
            <td colspan="3" style="width: 25%">
                <asp:TextBox ID="TxtResponsiblePerson" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                Completion Date</td>
            <td width="15%">
                <asp:TextBox ID="TxtCompletionDate" runat="server" BackColor="Silver" 
                    Width="80px"></asp:TextBox>
           <asp:CalendarExtender ID="Calcompletiondate" PopupButtonID="Imgcompletiondate" runat="server"
            Format="MM/dd/yyyy" TargetControlID="TxtCompletionDate" Enabled="True">
           </asp:CalendarExtender>
           <asp:ImageButton ID="Imgcompletiondate" runat="server" ImageUrl="~/Images/cal.gif" />
            </td>
            <td width="20%" align="right">
                Status</td>
            <td width="15%">
                <asp:DropDownList ID="DdlStatus" runat="server">
                </asp:DropDownList>
            </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                Remarks</td>
            <td colspan="4">
                <asp:TextBox ID="TxtRemarks" runat="server" Height="60px" TextMode="MultiLine" 
                    Width="350px" MaxLength="250"></asp:TextBox>
            </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" colspan="6" style="width: 35%">
                <asp:GridView ID="GdvDetails" runat="server" AutoGenerateColumns="False" 
                    OnRowCommand="GdvDetails_RowCommand" 
                    OnRowDataBound="GdvDetails_RowDataBound" PageSize="3" Width="100%">
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                     <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkccrlineno" runat="server" 
                                    CommandArgument='<%#Eval("CCRNo") %>' CommandName="editrow" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CCRLineNo">
                            <ItemTemplate>
                                <asp:Label ID="Lblccrlineno" runat="server" Text='<%#Eval("CCRNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice No">
                            <ItemTemplate>
                                <asp:Label ID="LblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Full Invoice">
                            <ItemTemplate>
                                <asp:Label ID="LblFullInvoice" runat="server" Text='<%#Eval("FullInvoice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Batch No">
                            <ItemTemplate>
                                <asp:Label ID="LblBatchNo" runat="server" Text='<%#Eval("BatchNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubType">
                            <ItemTemplate>
                                <asp:Label ID="LblSubType" runat="server" Text='<%#Eval("SubType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Micron">
                            <ItemTemplate>
                                <asp:Label ID="LblMicron" runat="server" Text='<%#Eval("Micron") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Length">
                            <ItemTemplate>
                                <asp:Label ID="LblLength" runat="server" Text='<%#Eval("Length") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Width">
                            <ItemTemplate>
                                <asp:Label ID="LblWidth" runat="server" Text='<%#Eval("Width") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Weigth">
                            <ItemTemplate>
                                <asp:Label ID="LblWeigth" runat="server" Text='<%#Eval("Weigth") %>'></asp:Label>
                            </ItemTemplate>
                              </asp:TemplateField>
                         <asp:TemplateField HeaderText="Complaint Description"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblComplaintDescription" runat="server" Text='<%#Eval("ComplaintDescription") %>'></asp:Label>
                            </ItemTemplate>
                              </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expected Date of Completion"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblExpDateofCompletion" runat="server" Text='<%#Eval("ExpDateofCompletion") %>'></asp:Label>
                            </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Responsible Person"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblResponsiblePerson" runat="server" Text='<%#Eval("ResponsiblePerson") %>'></asp:Label>
                            </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Completion Date"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblCompletionDate" runat="server" Text='<%#Eval("CompletionDate") %>'></asp:Label>
                            </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                            </ItemTemplate>
                           </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgDelete" runat="server" 
                                    CommandArgument='<%#Eval("CCRNo") %>' CommandName="del" 
                                    ImageUrl="~/Images/delete.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                Invoice No</td>
            <td width="15%">
                <asp:TextBox ID="TxtInvioce" runat="server" Width="80px"></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="fltrinvoice" TargetControlID="TxtInvioce" runat="server"
            FilterType="Numbers" Enabled="True"></asp:FilteredTextBoxExtender>
            </td>
            <td width="20%" align="right">
                Full Invoice</td>
            <td width="15%">
                <asp:TextBox ID="TxtFullInvoice" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                Batch#</td>
            <td width="15%">
                <asp:TextBox ID="TxtBatch" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td width="20%" align="right">
                Sub-Type</td>
            <td width="15%">
                <%--<asp:TextBox ID="TxtSubType" runat="server" Width="80px"></asp:TextBox>--%>
                <asp:DropDownList ID="DdlSubtype" runat="server">
                </asp:DropDownList>
            
            </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                Micron</td>
            <td width="15%">
            <asp:TextBox ID="TxtMicron" runat="server" Width="80px"></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="fltrmicron" TargetControlID="TxtMicron" runat="server"
            FilterType="Numbers,Custom" ValidChars="." Enabled="True"></asp:FilteredTextBoxExtender>
            </td>
            <td width="20%" align="right">
                Width</td>
            <td width="15%">
                <asp:TextBox ID="TxtWidth" runat="server" Width="80px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fltrwidth" TargetControlID="TxtWidth" runat="server"
          FilterType="Numbers,Custom" ValidChars="." Enabled="True"></asp:FilteredTextBoxExtender>
            </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                Length</td>
            <td width="15%">
                <asp:TextBox ID="TxtLength" runat="server" Width="80px"></asp:TextBox>
                   <asp:FilteredTextBoxExtender ID="fltrlength" TargetControlID="TxtLength" runat="server"
          FilterType="Numbers,Custom" ValidChars="." Enabled="True"></asp:FilteredTextBoxExtender>
            </td>
            <td width="20%" align="right">
                Weight</td>
            <td width="15%">
                <asp:TextBox ID="TxtWeightDetails" runat="server" Width="80px"></asp:TextBox>
                     <asp:FilteredTextBoxExtender ID="fltrweightdetails" 
                    TargetControlID="TxtWeightDetails" runat="server"
          FilterType="Numbers,Custom" ValidChars="." Enabled="True"></asp:FilteredTextBoxExtender>
            </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                  <asp:ImageButton ID="ImgBtnAddMore" ImageUrl="~/Images/btnAddLinegreen.gif" 
                      runat="server" Text="Save" onclick="ImgBtnAddMore_Click" />
            </td>
            <td width="20%">
             <asp:HiddenField ID="hidAutoIdHeader" runat="server" />
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
    </table> 
                    </ContentTemplate>
            </asp:UpdatePanel>
                    
                
            </ContentTemplate>
            </asp:TabPanel>
       </asp:TabContainer>
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
                        <asp:GridView ID="gvPopUpGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            PageSize="5" EnableColumnViewState="false" Width="100%" OnRowCommand="gvPopUpGrid_RowCommand"
                            OnRowDataBound="gvPopUpGrid_RowDataBound" OnPageIndexChanging="gvPopUpGrid_PageIndexChanging">
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

