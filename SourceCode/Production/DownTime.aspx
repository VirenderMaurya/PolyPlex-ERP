<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="DownTime.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
       

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="height: auto; position: relative;">
        <table style="width: 100%;">
            <tr>
                <td colspan ="7" style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                    Machine Data:
                </td>
            </tr>
            
            <tr>
                <td colspan="7">
                    <div style="overflow: auto; height: 100%; width: 1005px; position: relative;">
                        <asp:GridView ID="gvDownTimeGridInterm" runat="server" AutoGenerateColumns="False"
                            CssClass="GridViewStyle" EmptyDataText="No Record Found." ShowHeaderWhenEmpty="True"
                            Width="100%" onpageindexchanging="gvDownTimeGridInterm_PageIndexChanging" 
                            onrowcommand="gvDownTimeGridInterm_RowCommand">
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoID") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ProcessTypeName" HeaderText="Process Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PlantName" HeaderText="Plant Name">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LineCode" HeaderText="Line Code">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AreaName" HeaderText="Area Name">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeptName" HeaderText="Department">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MachineName" HeaderText="Machine">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubMachineName" HeaderText="SubMachine">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="KKName" HeaderText="KK Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProbDesc" HeaderText="Prob Desc">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EndDate" HeaderText="End Date">
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
                    <asp:Label runat="server" Text="Process Type:" ID="Label6"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProcessType" runat="server" Width="82%" ValidationGroup="1">
                        <asp:ListItem Value="">-Select-</asp:ListItem>
                        <asp:ListItem Value="1">PET</asp:ListItem>
                        <asp:ListItem Value="2">MET</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Plant:" ID="Label8"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPlant" runat="server" Width="82%" ValidationGroup="1">
                        <asp:ListItem>-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" id="TCVocherNo" runat="server">
                    <asp:Label runat="server" Text="Voucher No.:" ID="Label9"></asp:Label>
                </td>
                <td id="TCtxtVocherNo" runat="server">
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtVoucherNo"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Voucher Date:" ID="Label10"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtVoucherDate"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Line:" ID="Label11"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlLine" runat="server" Width="82%" ValidationGroup="1">
                        <asp:ListItem>-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Area:" ID="Label12"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlArea" runat="server" Width="82%" ValidationGroup="1">
                        <asp:ListItem>-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Department:" ID="Label13"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="82%" ValidationGroup="1">
                        <asp:ListItem>-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Machine:" ID="Label14"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMachine" runat="server" Width="82%" ValidationGroup="1">
                        <asp:ListItem>-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Sub Machine:" ID="Label15"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubMachineId" runat="server" Width="82%" ValidationGroup="1">
                        <asp:ListItem>-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="KK Type:" ID="Label16"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlKKType" runat="server" Width="82%" ValidationGroup="1">
                        <asp:ListItem>-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Problem Code:" ID="Label17"></asp:Label>
                </td>
                <td colspan="3">
                   <asp:DropDownList ID="ddlProblemCode" runat="server" Width="94%" ValidationGroup="1">
                        <asp:ListItem>-Select-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="Start Date:" ID="Label19"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                        ID="imgBtnStartDate" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                            ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" PopupButtonID="imgBtnStartDate"
                            Format="MM/dd/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Start Time:" ID="Label20"></asp:Label>
                </td>
                <td>
                    <timesel:TimeSelector ID="tsStartTime" DisplaySeconds="False" runat="server" SelectedTimeFormat="TwentyFour"
                        AmPm="PM" BorderColor="Silver" Hour="0" Minute="0" Second="0" Date="" 
                        MinuteIncrement="1">
                    </timesel:TimeSelector>
                </td>
                <td align="right">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label runat="server" Text="End Date:" ID="Label21"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                        ID="ImageButtonEndDate" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                            ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate" PopupButtonID="ImageButtonEndDate"
                            Format="MM/dd/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="End Time:" ID="Label22"></asp:Label>
                </td>
                <td>
                    <timesel:TimeSelector ID="tsEndTime" DisplaySeconds="False" runat="server" SelectedTimeFormat="TwentyFour"
                        AmPm="PM" BorderColor="Silver" Hour="0" Minute="0" Second="0" Date="" 
                        MinuteIncrement="1">
                    </timesel:TimeSelector>
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Total Hours ((D)hh:mm:ss):" ID="Label23"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TabIndex="27" Width="80%" ID="txtTotalHours"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                    <asp:CheckBox ID="chkHasItAffected" runat="server" Text="Has it affected the process." />
                </td>
                <td align="right">
                    <asp:Label runat="server" Text="Detail of Observations:" ID="Label24"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" TabIndex="27" Width="96%" TextMode="MultiLine" ID="txtDetailofObservations"></asp:TextBox>
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
                </td>
                <td>
                </td>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" TabIndex="5"
                        ImageUrl="~/Images/btnSave.png" OnClick="ImgBtnSave_Click" />
                    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        TabIndex="5" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close();" />
                    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
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
                    <asp:HiddenField ID="HidDownTimeId" runat="server" />
                    <asp:HiddenField ID="HidDownTimeIntermId" runat="server" />
                </td>
                <td>
                <asp:HiddenField ID="HidYear" runat="server" />
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
                            PET/MET DownTime List</div>
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
                                    <asp:Button ID="btnSearchlist" runat="server" TabIndex="10" Text="Submit" CausesValidation="false" onclick="btnSearchlist_Click"  />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPetMetDownTimeAll" runat="server" AutoGenerateColumns="false"
                            Width="100%" CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="3" 
                            onpageindexchanging="gvPetMetDownTimeAll_PageIndexChanging" 
                            onrowcommand="gvPetMetDownTimeAll_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("AutoID") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ProcessTypeName" HeaderText="Process Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PlantName" HeaderText="Plant Name">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LineCode" HeaderText="Line Code">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AreaName" HeaderText="Area Name">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeptName" HeaderText="Department">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MachineName" HeaderText="Machine">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubMachineName" HeaderText="SubMachine">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="KKName" HeaderText="KK Type">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProbDesc" HeaderText="Prob Desc">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EndDate" HeaderText="End Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                        </asp:GridView>
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
</asp:Content>
