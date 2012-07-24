<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/PolyplexMaster.master" AutoEventWireup="true" CodeFile="ScarpReceived.aspx.cs" Inherits="Procurement_ScarpReceived" %>


<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
        <table ><tr style="height:10px;"><td></td></tr></table>
         <asp:Panel ID="pnlhead" runat="server" BorderWidth="1" BorderColor="#999999"></asp:Panel>
      <table ><tr style="height:20px;"><td></td></tr></table>

      
 <table width="100%"> <tr style="height:35%"><td></td></tr></table>

  <table width="100%"> <tr><td width="20%" align="right"> Year :</td><td><asp:TextBox ID="txtYear" runat="server" BackColor="Silver" Width="70px"></asp:TextBox></td>
  <td width="20%" align="right"> Entry :</td><td><asp:TextBox ID="txtEntry" BackColor="Silver" runat="server"></asp:TextBox> 
  
  </td>
  <td width="20%" align="right"> Entry Date :</td><td><asp:TextBox ID="txtEntryDate" BackColor="Silver" Width="70px"  runat="server"></asp:TextBox></td>
  </tr></table><table width="100%"> <tr style="height:35%"><td></td></tr></table>
 <table width="100%">
 
 <tr><td>
           <asp:GridView ID="gvScarpData" Visible="false" runat="server" AllowPaging="True" PageSize="5" Width="100%"
                                EmptyDataText="No record found" ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False"  DataKeyNames="line"
                                
               OnSelectedIndexChanged="gvScarpData_SelectedIndexChanged"  
               OnPageIndexChanging="gvScarpData_PageIndexChanging" CssClass="GridViewStyle" onrowcommand="gvScarpData_RowCommand"
                              >
                                <Columns>
                                  
                            <asp:BoundField DataField="Line" HeaderText="Line" />
                             <asp:BoundField DataField="MaterialCode" HeaderText="Material Code" />
                              <asp:BoundField DataField="ValuationType" HeaderText="Valuation Type" />
                              <asp:BoundField DataField="Plant" HeaderText="Plant" />
                              
                              <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                              <asp:BoundField DataField="StorageLocation" HeaderText="Storage Location" />
                              <asp:BoundField DataField="Status" HeaderText="Status" />
                               <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgDelete" runat="server" CommandArgument='<%#Eval("Line") %>'
                                    CommandName="del" ImageUrl="~/Images/delete.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                                  </Columns> 
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                            </asp:GridView>

  <asp:GridView ID="gvScarp" Visible="false" runat="server"  Width="100%"
                                EmptyDataText="No record found" ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False"  DataKeyNames="line"
                                
               OnSelectedIndexChanged="gvScarpData_SelectedIndexChanged"  
               OnPageIndexChanging="gvScarpData_PageIndexChanging" CssClass="GridViewStyle" onrowcommand="gvScarpData_RowCommand"
                              >
                                <Columns>
                                     <asp:TemplateField  HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="imgSelect" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoID") %>' CommandName="Select"
                                                ImageUrl="~/Images/chkbxuncheck.png" Visible="false" Text="Select" /></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:BoundField DataField="Line" HeaderText="Line" />
                             <asp:BoundField DataField="MaterialCode" HeaderText="Material Code" />
                              <asp:BoundField DataField="ValuationType" HeaderText="Valuation Type" />
                              <asp:BoundField DataField="Plant" HeaderText="Plant" />
                              
                              <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                              <asp:BoundField DataField="StorageLocation" HeaderText="Storage Location" />
                              <asp:BoundField DataField="Status" HeaderText="Status" />
                             
                                  </Columns> 
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                            </asp:GridView>

 </td></tr></table>

  <table width="100%"> <tr style="height:35%"><td></td></tr></table>
    <table width="100%">
        <tr>
         
            <td width="20%" align="right">
               Material Code :
            </td>
            <td width="20%" align="left">
            <asp:DropDownList ID="ddlMaterialcode" runat="server" Width="90px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlMaterialcode_SelectedIndexChanged">
                </asp:DropDownList>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMaterialcode"
                                    Display="None" ErrorMessage="Please select material code" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator3">
                                </asp:ValidatorCalloutExtender>
            </td>
            <td width="20%" align="right">
                Plant :
            </td>
            <td width="20%" align="left">
                <asp:DropDownList ID="ddlPlant" runat="server" Width="90px">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPlant"
                                    Display="None" ErrorMessage="Please select plant" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
            </td>
             <td width="20%" align="right">
                Valuation Type :
            </td>
            <td width="20%" align="left">
                <asp:DropDownList ID="ddlvaluation" runat="server" Width="90px">
                </asp:DropDownList>
               
            </td>
        </tr>

             <tr>
         
            <td width="20%" align="right">
              Storage Location :
            </td>
            <td width="20%" align="left">
            <asp:DropDownList ID="ddlStorageLocation" runat="server" Width="90px">
                </asp:DropDownList>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStorageLocation"
                                    Display="None" ErrorMessage="Please select storage location" ForeColor="Red" InitialValue="0"
                                    SetFocusOnError="true" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator2">
                                </asp:ValidatorCalloutExtender>
            </td>
            <td width="20%" align="right">
               Quantity :
            </td>
            <td width="20%" align="left">
               <asp:TextBox ID="txtQUantity"  runat="server"></asp:TextBox>
                 <asp:FilteredTextBoxExtender ID="fltr" TargetControlID="txtQuantity" runat="server"
                                        FilterType="Custom, Numbers" ValidChars="."  Enabled="True">
                                    </asp:FilteredTextBoxExtender>
            </td>
             <td width="20%" align="right">
              Stock UOM:
            </td>
            <td width="20%" align="left">
              <asp:TextBox ID="txtstock" BackColor="Silver"  runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%"> <tr style="height:35%"><td></td></tr></table>
    <table width="100%"><tr align="right"><td width="30%">
       <asp:ImageButton ID="ImgBtnAddLine" ImageUrl="~/Images/btnAddLinegreen.png" 
                      runat="server" Text="Add Line"  ValidationGroup="btnsave" 
            onclick="ImgBtnAddLine_Click"  />
   </td></tr></table>

   <table width="100%"> <tr style="height:35%"><td></td></tr></table>
    <table width="100%"><tr align="center"><td></td><td>
    <table><tr><td width="30%">
    <asp:ImageButton ID="ImgBtnSave" ImageUrl="~/Images/btnSave.png" 
                      runat="server" Text="Save" onclick="ImgBtnSave_Click"  />
   </td><td width="30%">
            <asp:ImageButton ID="ImgBtnCancel" ImageUrl="~/Images/btnCancel.png" 
                      runat="server" Text="Cancel" onclick="ImgBtnCancel_Click"  /></td><td width="30%">
            <asp:ImageButton ID="ImgBtnExit" ImageUrl="~/Images/btnExit.png" 
                      runat="server" Text="Exit" OnClientClick="window.close();" 
                /></td></tr></table>
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
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Submit" 
                                        CausesValidation="false" onclick="btnSearchlist_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                    <tr>
                        <td>
             
                            <asp:GridView ID="gridMaster" runat="server" AllowPaging="True" PageSize="5" Width="100%"
                                EmptyDataText="No Result match your search criteria." ShowHeaderWhenEmpty="True"
                                AutoGenerateColumns="False"  DataKeyNames="ScrapID"
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
                           <%--     <asp:Label ID="lblPETPlant" runat="server" Text='<% #Eval("autoid")%>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                                <asp:BoundField DataField="Entry" HeaderText="Entry" />
                             <asp:BoundField DataField="YEAR" HeaderText="Year" />
                            
                              <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" />
                              
                         
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

