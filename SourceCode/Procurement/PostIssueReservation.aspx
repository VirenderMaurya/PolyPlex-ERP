<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="PostIssueReservation.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">


        function CheckGridRecords() {
            document.getElementById('<%= HidCheckValue.ClientID %>').value = "Yes";
            return false;
        }
        /*=======================================Validation for Check Item in CheckBox=================================================*/

        var TotalChkBx;
        var TargetBaseControl = null;

        window.onload = function () {
            TotalChkBx = parseInt('<%= this.gvPostIssueReserLow.Rows.Count %>');
            TargetBaseControl = document.getElementById('<%= this.gvPostIssueReserLow.ClientID %>');

        }

        function HeaderClick(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.gvPostIssueReserLow.ClientID %>');
            var TargetChildControl = "chkItem";

            var Inputs = TargetBaseControl.getElementsByTagName("input");  //Get all the control of the type INPUT in the base control.

            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0) {
                    Inputs[n].checked = CheckBox.checked;
                }
            }
            document.getElementById('<%= HidCheckValue.ClientID %>').value = "Yes";
        }

        /*=======================================Validation for Check Item through Button=============================================*/

        function TestCheckBox() {
            TotalChkBx = parseInt('<%= this.gvPostIssueReserLow.Rows.Count %>');
            TargetBaseControl = document.getElementById('<%= this.gvPostIssueReserLow.ClientID %>');
            if (TargetBaseControl == null) {
                return false;
            }

            var TargetChildControl = "chkItem";

            var Inputs = TargetBaseControl.getElementsByTagName("input");

            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[n].checked) {
                    return true;
                }
            }

            alert('Select atleast one roll.');
            return false;
        }


        /*=======================================Validation for Reset CheckBox through Button=============================================*/

        function ResetCheckBox() {
            TotalChkBx = parseInt('<%= this.gvPostIssueReserLow.Rows.Count %>');
            TargetBaseControl = document.getElementById('<%= this.gvPostIssueReserLow.ClientID %>');

            if (TargetBaseControl == null) {
                return false;
            }

            var TargetChildControl = "chkItem";
            var TargetHeadControl = "chkHeader";

            var Inputs = TargetBaseControl.getElementsByTagName("input");

            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)  // Reset Rows.
                {
                    Inputs[n].checked = false;
                }

                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetHeadControl, 0) >= 0)   // Reset Header.
                {
                    Inputs[n].checked = false;
                }
            }
            return false;
        }        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="overflow: auto; height: auto; position: relative;">
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
                <td colspan="7">
                    <asp:Label ID="lblInfo" ForeColor="Red" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 5px">
                <td colspan="7">
                </td>
            </tr>           
            
            <tr>
                <td colspan="7">
                    <div style="overflow: auto; height: 100%; width: 905px; position: relative;">
                        <asp:GridView ID="gvPostIssueReserHeader" runat="server" AllowPaging ="false"
                            AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" 
                            EmptyDataText="No Record Found." 
                            onrowdatabound="gvPostIssueReserHeader_RowDataBound" 
                            onrowcommand="gvPostIssueReserHeader_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ReservationNo" HeaderText="Reservation No.">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IssueReservationDate" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReservationYear" HeaderText="Year">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CostCenterId" HeaderText="CostCenterId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CostCenter" HeaderText="Cost Center">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GoodRecipient" HeaderText="Goods Recipient">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
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
            <tr style="height: 10px">
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
                <td colspan="7">
                    <div style="overflow: auto; height: 100%; width: 905px; position: relative;">
                        <asp:GridView ID="gvPostIssueReserLow" runat="server" DataKeyNames="AutoId"
                            AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" 
                            EmptyDataText="No Record Found." 
                            onrowdatabound="gvPostIssueReserLow_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" OnCheckedChanged="chk_CheckChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AutoId" HeaderText="AutoId">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LineNo" HeaderText="LineNo.">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BatchNo" HeaderText="Batch No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialName" HeaderText="Material">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UOM" HeaderText="UOM">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PlantName" HeaderText="Plant">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StorageLocation" HeaderText="Storage Location">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ValuationType" HeaderText="Valuation Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProjectName" HeaderText="Project">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubProject" HeaderText="Sub Project">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Purpose" HeaderText="Purpose">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialId" HeaderText="MaterialId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UOMId" HeaderText="UOMId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PlantID" HeaderText="PlantID">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StorageLocationId" HeaderText="StorageLocationI">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ValuationTypeId" HeaderText="ValuationTypeId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProjectId" HeaderText="ProjectId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubProjectId" HeaderText="SubProjectId">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PurposeId" HeaderText="PurposeId">
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
            <tr style="height: 5px">
                <td align="right">
                    <asp:Label runat="server" Text="Issue Year:" ID="Label3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIssueYear" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right" id ="TDIssueNo" runat ="server">
                    <asp:Label runat="server" Text="Issue No.:" ID="Label1"></asp:Label>
                </td>
                <td id ="TDtxtIssueNo" runat ="server">
                    <asp:TextBox ID="txtIssueNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Issue Date:" ID="Label8"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIssueDate" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 5px">
            <td align="right">
                    <asp:Label runat="server" Text="Reservation No.:" ID="Label7"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtReservationNo" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                </td>                
                <td align="right">
                    
                </td>
                <td>
                    
                </td>
               <td align="right">
                   
                </td>
                <td>
                   
                </td>
                <td>
                </td>
            </tr>
                        
            <tr style="height: 10px">
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
                <td colspan="7" align="center">
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" 
                        TabIndex="5" ImageUrl="~/Images/btnSave.png" onclick="ImgBtnSave_Click" />
                    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        TabIndex="5" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close();" />
                </td>
            </tr>
            <tr>
                <td>                   
                    <asp:HiddenField ID="HidIssueReservationId" runat="server" />
                </td>
                <td>                    
                    <asp:HiddenField ID="HidCheckValue" runat="server" />
                </td>
                <td>
                   <asp:HiddenField ID="HidAutoId" runat="server" />
                </td>
                <td>
                <asp:HiddenField ID="HidIsChecked" runat="server" />
                </td>
                <td>
                <asp:HiddenField ID="HidIsForm" runat="server" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="PnlShowSerach" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
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
                            Post Issue Reservation List</div>
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
                                        CausesValidation="false" onclick="btnSearchlist_Click"
                                        />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPostIssueReservationList" runat="server" AutoGenerateColumns="false"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="3" 
                            onpageindexchanging="gvPostIssueReservationList_PageIndexChanging" 
                            onrowcommand="gvPostIssueReservationList_RowCommand" 
                            onrowdatabound="gvPostIssueReservationList_RowDataBound">
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <PagerStyle CssClass="gridpager" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IssueNo" HeaderText="Issue No.">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IssueDate" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IssueYear" HeaderText="Year">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReservationNo" HeaderText="Reservation No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReservationId" HeaderText="ReservationId">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
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
                        <asp:Label ID="lblTotalRecords" runat="server" Text="Label"></asp:Label><br />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label5"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
</asp:Content>
