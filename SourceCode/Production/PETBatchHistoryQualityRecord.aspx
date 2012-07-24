<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master" AutoEventWireup="true" CodeFile="PETBatchHistoryQualityRecord.aspx.cs" Inherits="Production_PETBatchHistoryQualityRecord" %>

<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 568px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
       <table ><tr style="height:10px;"><td></td></tr></table>
         <asp:Panel ID="pnlhead" runat="server" BorderWidth="1" BorderColor="#999999"></asp:Panel>
      <table ><tr style="height:20px;"><td></td></tr></table>

      <table width="100%" align="center"><tr><td>
  
   <table width="100%" align="center">
   

   <tr>
   <td>Voucher Year</td><td>Voucher No</td><td>Voucher Date</td>
  
   
   </tr>
   
   
   <tr>
   <td><asp:TextBox ID="txtVoucherYear" Width="70px" 
                 BackColor="Silver" runat="server" ></asp:TextBox></td><td><asp:TextBox ID="txtVoucherNo" 
                 BackColor="Silver" runat="server" Width="120px"></asp:TextBox></td><td><asp:TextBox ID="txtVoucherDate" 
                 BackColor="Silver" runat="server" Width="70px"></asp:TextBox></td>
  
   
   </tr>
   

   <tr>
   <td>Type</td><td>Silica(PPM)</td><td>EI Cycle Time Duration(HH)-(MM)</td>
  
   
   </tr>
   
   <tr>
   <td valign="top"> <asp:DropDownList ID="DdlVoucherType" runat="server" Width="100px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DdlVoucherType"
                                    Display="None" ErrorMessage="Please select voucher type" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator8">
                                </asp:ValidatorCalloutExtender>
                                    
                                    </td>
                                    <td valign="top"><asp:TextBox ID="txtSilica" runat="server"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender ID="fltr" TargetControlID="txtSilica" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSilica"
                                    Display="None" ErrorMessage="Please enter Silica" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
                                    </td>
                                    
                                    <td valign="top">
       <asp:TextBox ID="txtEICycletimeHH" runat="server" Width="44px" MaxLength="2"></asp:TextBox><asp:TextBox ID="txtEICycletimeMM" MaxLength="2" runat="server" Width="44px"></asp:TextBox>
       
         <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtEICycletimeHH" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEICycletimeHH"
                                    Display="None" ErrorMessage="Please enter EI cycle time HH" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator2">
                                </asp:ValidatorCalloutExtender>
                             

                                   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtEICycletimeMM" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEICycletimeMM"
                                    Display="None" ErrorMessage="Please enter EI cycle time Duration MM" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator3">
                                </asp:ValidatorCalloutExtender>
       </td>
 

   </tr>

   <tr> <td>EI Final Temp</td><td>BHT Filter(MIC)</td>
   <td>BA Trans.Time Duration(HH)-(MM)</td>
  
   </tr>
   <tr> 
      <td valign="top"><asp:TextBox ID="txtEIFinalTemp" runat="server"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtEIFinalTemp" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEIFinalTemp"
                                    Display="None" ErrorMessage="Please enter EI Final Temp." ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator4">
                                </asp:ValidatorCalloutExtender>
   
   </td>
    <td valign="top"><asp:TextBox ID="txtBHTFilter" runat="server"></asp:TextBox>
     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtBHTFilter" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBHTFilter"
                                    Display="None" ErrorMessage="Please enter BHT Filter " ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator5">
                                </asp:ValidatorCalloutExtender>
   </td>
   <td valign="top"><asp:TextBox ID="txtBATransHH" runat="server" Width="44px"></asp:TextBox><asp:TextBox ID="txtBATransMM" runat="server" Width="44px"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtBATransHH" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBATransHH"
                                    Display="None" ErrorMessage="Please enter BA Trans. Time Duration HH" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator6">
                                </asp:ValidatorCalloutExtender>
   

    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtBATransMM" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBATransMM"
                                    Display="None" ErrorMessage="Please enter BA Trans. Time Duration MM" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator7">
                                </asp:ValidatorCalloutExtender>
   
   </td>
</tr>
 <%--  </table>
  
  
  
   <table width="100%" align="center">--%>
   <tr> <td>FIN Prod. Temp.</td>
   <td>PC Reac.Time Duration(HH)-(MM)</td><td>BA Cutoff R.P.M.</td>
   </tr>
   
   <tr>
      <td valign="top"><asp:TextBox ID="txtFinProd" runat="server"></asp:TextBox>
  
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txtFinProd" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFinProd"
                                    Display="None" ErrorMessage="Please enter FIN Prod. Temp." ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator9">
                                </asp:ValidatorCalloutExtender>
   
   </td>
   <td valign="top">  <asp:TextBox ID="txtPCReacTiemHH" runat="server" Width="44px" MaxLength="2"></asp:TextBox>
       <asp:TextBox ID="txtPCReacTiemMM" runat="server" Width="44px" MaxLength="2"></asp:TextBox>
  
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtPCReacTiemHH" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPCReacTiemHH"
                                    Display="None" ErrorMessage="Please enter PC Reac. Time Duration HH" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator10">
                                </asp:ValidatorCalloutExtender>


                                  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtPCReacTiemMM" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPCReacTiemMM"
                                    Display="None" ErrorMessage="Please enter PC Reac. Time Duration MM" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator11">
                                </asp:ValidatorCalloutExtender>
   
   </td>
   <td valign="top"><asp:TextBox ID="txtBACutoffRPM" runat="server"></asp:TextBox>
  
                                  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtBACutoffRPM" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtBACutoffRPM"
                                    Display="None" ErrorMessage="Please enter BA Cutoff R.P.M." ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator12">
                                </asp:ValidatorCalloutExtender>
   
   </td>
 
  
   </tr>

   <tr>
   <td>BA Cutoff K.W.</td>
   <td>Casting Time Duration(HH)-(MM)</td>
   <td>IV(dl/gm)</td>
  
   </tr>

   <tr>  <td valign="top"><asp:TextBox ID="txtCutoffKW" runat="server"></asp:TextBox>
           <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtCutoffKW" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCutoffKW"
                                    Display="None" ErrorMessage="Please enter BA Cutoff K.W." ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator13">
                                </asp:ValidatorCalloutExtender>
   </td>
   <td valign="top"><asp:TextBox ID="txtCastingTimeHH" runat="server" Width="44px" MaxLength="2"></asp:TextBox>
       <asp:TextBox ID="txtCastingTimeMM" runat="server" Width="44px" MaxLength="2"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txtCastingTimeHH" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtCastingTimeHH"
                                    Display="None" ErrorMessage="Please enter casting time HH" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator14">
                                </asp:ValidatorCalloutExtender>

                               
                                 <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txtCastingTimeMM" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtCastingTimeMM"
                                    Display="None" ErrorMessage="Please enter casting time MM" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator15">
                                </asp:ValidatorCalloutExtender>
   
   </td> <td valign="top"><asp:TextBox ID="txtIV" runat="server"></asp:TextBox>
          <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txtIV" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtIV"
                                    Display="None" ErrorMessage="Please enter IV" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator16">
                                </asp:ValidatorCalloutExtender>
   
   </td>
 </tr>
   <%--</table>
     

      <table width="100%" align="center">--%>
   <tr>
    <td>COOH(Meg/Kg)</td>
   <td>ASH(Wt %)</td>
   <td>DEG(Wt %)</td>
 
   </tr>

   <tr>
     <td valign="top"><asp:TextBox ID="txtCOOH" runat="server"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" TargetControlID="txtCOOH" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtCOOH"
                                    Display="None" ErrorMessage="Please enter COOH" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator17">
                                </asp:ValidatorCalloutExtender>
   
   </td>
   <td valign="top"><asp:TextBox ID="txtASH" runat="server"></asp:TextBox>
     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txtASH" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtASH"
                                    Display="None" ErrorMessage="Please enter ASH" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator18">
                                </asp:ValidatorCalloutExtender>
   
   </td>
   <td valign="top"><asp:TextBox ID="txtDEG" runat="server"></asp:TextBox>
     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txtDEG" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtDEG"
                                    Display="None" ErrorMessage="Please enter DEG" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator19">
                                </asp:ValidatorCalloutExtender>
   </td>
 
 
   </tr>

   <tr>  <td>MP(Deg C)</td>
   <td>No. of Chips/gm</td>
   <td>Colour Visual</td></tr>

   <tr>  <td valign="top"><asp:TextBox ID="txtMP" runat="server"></asp:TextBox>
      <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txtMP" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtMP"
                                    Display="None" ErrorMessage="Please enter M.P." ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator20">
                                </asp:ValidatorCalloutExtender>
   
   
   </td>
   <td valign="top"><asp:TextBox ID="txtNumberofChips" runat="server"></asp:TextBox>
     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" TargetControlID="txtNumberofChips" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtNumberofChips"
                                    Display="None" ErrorMessage="Please enter number of chips" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator21">
                                </asp:ValidatorCalloutExtender>
   </td>
   <td valign="top"><asp:TextBox ID="txtColorVisual" runat="server"></asp:TextBox>
    

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtColorVisual"
                                    Display="None" ErrorMessage="Please enter colour visual" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator22">
                                </asp:ValidatorCalloutExtender>
   
   </td>  </tr>
   <tr><td>L *</td>
   <td>a *</td>
   <td>b *</td>
    
   </tr>
   <tr>  
   <td valign="top"><asp:TextBox ID="txtL" runat="server"></asp:TextBox>
   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" TargetControlID="txtL" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtL"
                                    Display="None" ErrorMessage="Please enter L" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator23">
                                </asp:ValidatorCalloutExtender>
   
   </td>
   <td valign="top"><asp:TextBox ID="txta" runat="server"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" TargetControlID="txta" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txta"
                                    Display="None" ErrorMessage="Please enter a" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator24">
                                </asp:ValidatorCalloutExtender>
   </td>
   <td valign="top"><asp:TextBox ID="txtb" runat="server"></asp:TextBox>
      <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" TargetControlID="txtb" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtb"
                                    Display="None" ErrorMessage="Please enter b" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator25">
                                </asp:ValidatorCalloutExtender>
   
   </td>
  </tr>
    <tr> <td>Grade</td>
       <td>Moisture %</td>
   <td>Oligomer %</td>
   </tr>
   <tr>   <td valign="top"><asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
     
    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtGrade"
                                    Display="None" ErrorMessage="Please enter grade" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender26" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator26">
                                </asp:ValidatorCalloutExtender>
     </td>
       <td valign="top"><asp:TextBox ID="txtMoisture" runat="server"></asp:TextBox>
           <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" TargetControlID="txtMoisture" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtMoisture"
                                    Display="None" ErrorMessage="Please enter moisture" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender27" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator27">
                                </asp:ValidatorCalloutExtender>
       
       </td>
   <td valign="top"><asp:TextBox ID="txtOligomer" runat="server"></asp:TextBox>
       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" TargetControlID="txtOligomer" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtOligomer"
                                    Display="None" ErrorMessage="Please enter Oligomer" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender28" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator28">
                                </asp:ValidatorCalloutExtender>
   
   </td>
   </tr>

   <tr>
   <td colspan="2">Remarks</td><td>Time</td></tr>
   <tr><td valign="top" colspan="2">
              <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Rows="3" runat="server" 
                  Width="534px"></asp:TextBox>
             
              
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtRemarks"
                                    Display="None" ErrorMessage="Please enter remarks" ForeColor="Red"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender29" runat="server" Enabled="True"
                                   PopupPosition="TopRight" Width="50" TargetControlID="RequiredFieldValidator29">
                                </asp:ValidatorCalloutExtender>
              
               </td><td valign="top"><timesel:TimeSelector ID="TimePickerVoucher" DisplaySeconds="false" 
                                    runat="server" SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector></td></tr>
   </table>
   </td></tr></table>

    
  <table width="100%"><tr align="center"><td></td><td>
    <table><tr><td width="30%">
    <asp:ImageButton ID="ImgBtnSave" ImageUrl="~/Images/btnSave.png" 
                      runat="server" Text="Save" onclick="ImgBtnSave_Click"  ValidationGroup="btnsave" />
   </td><td width="30%">
            <asp:ImageButton ID="ImgBtnCancel" ImageUrl="~/Images/btnCancel.png" 
                      runat="server" Text="Cancel" onclick="ImgBtnCancel_Click"  /></td><td width="30%">
            <asp:ImageButton ID="ImgBtnExit" ImageUrl="~/Images/btnExit.png" 
                      runat="server" Text="Exit" OnClientClick="window.close();"  /></td></tr></table>
   </td><td> </td></tr></table>
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
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Submit" 
                                        CausesValidation="false" onclick="btnSearchlist_Click" />
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
                                AutoGenerateColumns="False"  DataKeyNames="autoid"
                                OnSelectedIndexChanged="gridMaster_SelectedIndexChanged"  onpageindexchanging="gridMaster_PageIndexChanging" CssClass="GridViewStyle"
                              >
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
                                        <asp:BoundField DataField="VoucherYear" HeaderText="Voucher Year" />
                        <asp:BoundField DataField="VoucherNo" HeaderText="Voucher Nunmber" />
                        <asp:BoundField DataField="voucherDate" HeaderText="voucher Date" />
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



