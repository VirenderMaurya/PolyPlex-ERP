<%@ Page Title="" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="PetJumbo.aspx.cs"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>
<%--<%@ Register src="../Controls/DateTimeChooser.ascx" tagname="DateTimeChooser" tagprefix="uc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="overflow: auto; height: auto; position: relative;">
        <table style="width: 100%;">
            <tr valign="bottom">
                <td style="height: 20px">
                    <asp:Label ID="lblInfo" ForeColor="Red" runat="server"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
            <td style="border-bottom: solid 1px gray; border-collapse: collapse;
                    color: #024B81; font-weight: bold; font-size: x-small;">
                    Machine Data:
                </td>
            </tr>
            <tr>
                <td>
                    <div style="overflow: auto; height: 100%; width: 1005px; position: relative;">
                        <asp:GridView ID="gvPetJumboFetchGridInterm" runat="server" 
                            AutoGenerateColumns="False" CssClass="GridViewStyle"
                            EmptyDataText="No Record Found." ShowHeaderWhenEmpty="True" Width="100%" 
                            onrowcommand="gvPetJumboFetchGridInterm_RowCommand" 
                            onpageindexchanging="gvPetJumboFetchGridInterm_PageIndexChanging">
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("PetJumboId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="JumboNo" HeaderText="Jumbo No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JumboDate" HeaderText="Jumbo Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ShiftCode" HeaderText="Shift Code">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LineCode" HeaderText="Line Code">
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
            <tr>
                <td>
                    <asp:TabContainer ID="TCPetJumbo" runat="server" Width="100%" 
                        ActiveTabIndex="0">
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Header" ID="TPMainDetail">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 4%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label53" runat="server" Text="Line:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLine" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" id ="TDJumboNo" runat ="server"  >
                                            <asp:Label ID="Label1" runat="server" Text="Jumbo No.:"></asp:Label>
                                        </td>
                                        <td  id ="TDtxtJumboNo" runat ="server">
                                            <asp:TextBox ID="txtJumboNo" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Text="Jumbo Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtJumboDate" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                                                ID="imgBtnJumboDate" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="calExtenderJumboDate" runat="server" TargetControlID="txtJumboDate" PopupButtonID="imgBtnJumboDate"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" Text="Shift:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShift" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" Text="Date In:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateIn" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                                                ID="imgBtnDateIn" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="CalendarExtender1" runat="server" TargetControlID="txtDateIn" PopupButtonID="imgBtnDateIn"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" Text="Time In:"></asp:Label>
                                        </td>
                                        <td>
                                            <timesel:TimeSelector ID="tsTimeIn" DisplaySeconds="False" runat="server" SelectedTimeFormat="TwentyFour"
                                                AmPm="PM" BorderColor="Silver" Hour="0" Minute="0" Second="0" Date="">
                                            </timesel:TimeSelector>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" Text="Date Out:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateOut" runat="server" TabIndex="27" Width="74%"></asp:TextBox><asp:ImageButton
                                                ID="imgBtnDateOut" ValidationGroup="aa" runat="server" ImageUrl="~/Images/cal.gif" /><asp:CalendarExtender
                                                    ID="CalendarExtender2" runat="server" TargetControlID="txtDateOut" PopupButtonID="imgBtnDateOut"
                                                    Format="MM/dd/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" Text="Time Out:"></asp:Label>
                                        </td>
                                        <td>
                                            <timesel:TimeSelector ID="tsTimeOut" DisplaySeconds="False" runat="server" SelectedTimeFormat="TwentyFour"
                                                AmPm="PM" BorderColor="Silver" Date="" Hour="0" Minute="0" Second="0">
                                            </timesel:TimeSelector>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" Text="Raw Material:"></asp:Label>
                                        </td>
                                        <td colspan="7">
                                            <asp:TextBox ID="txtRawMaterial" runat="server" TabIndex="27" Width="98%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label12" runat="server" Text="Thickness:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlThickness" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label13" runat="server" Text="Sub Film Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubFilmType" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label121" runat="server" Text="Run No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRunNo" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label122" runat="server" Text="Grade:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlGrade" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text="Break No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBreakNo" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label14" runat="server" Text="Electrod KW-1:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtElectrodKW1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label15" runat="server" Text="Avg. Guage:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAvgGuage" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label16" runat="server" Text="Core No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoreNo" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label17" runat="server" Text="Osicllation Width:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOscillationNo" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtOscillationNo"
                                                Display="None" ErrorMessage="Enter a valid width. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator2">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label18" runat="server" Text="Electrod KW-2:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtElectrodKW2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label19" runat="server" Text="Final Width:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFinalWidth" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFinalWidth"
                                                Display="None" ErrorMessage="Enter a valid width. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label20" runat="server" Text="Length:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLength" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtLength"
                                                Display="None" ErrorMessage="Enter a valid length. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" PopupPosition="Left" TargetControlID="RegularExpressionValidator3">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label21" runat="server" Text="Joint:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtJoint" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label22" runat="server" Text="Weight:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWeight" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtWeight"
                                                Display="None" ErrorMessage="Enter a valid weight. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator4">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label23" runat="server" Text="Friction S:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFrictionS" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label26" runat="server" Text="Friction K:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFrictionK" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label27" runat="server" Text="EL MD Left:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtELMDLeft" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label28" runat="server" Text="Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtELMDCenter" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label29" runat="server" Text="Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtELMDRight" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label30" runat="server" Text="Main Thick:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtELMDMainThick" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label31" runat="server" Text="EL TD Left:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtELTDLeft" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label32" runat="server" Text="Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtELTDCenter" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label33" runat="server" Text="Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtELTDRight" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label34" runat="server" Text="Co-ex Thick:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtELTDCoexThick" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label35" runat="server" Text="TS MD Left:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTSMDLeft" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label36" runat="server" Text="Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTSMDCenter" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label37" runat="server" Text="Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTSMDRight" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label38" runat="server" Text="Main RPM:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTSMDMainRPM" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label39" runat="server" Text="TS TD Left:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTSTDLeft" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label40" runat="server" Text="Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTSTDCenter" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label41" runat="server" Text="Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTSTDRight" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label42" runat="server" Text="Co-ex RPM:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTSTDCoexRPM" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label43" runat="server" Text="Haze:"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtHaze1" runat="server" TabIndex="27" Width="46%"></asp:TextBox>
                                            <asp:TextBox ID="txtHaze2" runat="server" TabIndex="27" Width="46%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label45" runat="server" Text="Tape Test Side Coated:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTapeTestSideCoated" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label46" runat="server" Text="Both Side:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBothSide" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label47" runat="server" Text="Break Down Voltage (KV):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBreakDownVoltage" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label49" runat="server" Text="Dynamic Min:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDynamicMin" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label50" runat="server" Text="Dynamic Max:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDynamicMax" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Shrinkage & Polarised Code"
                            ID="TPShrinkageAndPolarised">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 4%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label24" runat="server" Text="Peak To Peak:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPeakToPeak" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label25" runat="server" Text="F5 MD Avg.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtF5MDAvg" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label44" runat="server" Text="F5 TD Avg.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtF5TDAvg" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label48" runat="server" Text="CD Spread:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCDSpread" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label51" runat="server" Text="Young Modules MD:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtYoungModulesMD" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label52" runat="server" Text="F5 MD Left:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtF5MDLeft" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label54" runat="server" Text="F5 MD Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtF5MDRight" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label55" runat="server" Text="Young Modules TD:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtYoungModulesTD" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label57" runat="server" Text="F5 MD Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtF5MDCenter" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
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
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label58" runat="server" Font-Bold="True" Text="SHRINKAGE:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label60" runat="server" Text="MDL:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMDL" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label61" runat="server" Text="MDC:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMDC" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label62" runat="server" Text="MDR:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMDR" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label63" runat="server" Text="TDL:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTDL" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label64" runat="server" Text="TDC:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTDC" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label65" runat="server" Text="TDR:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTDR" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
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
                                    <tr style="height: 6px">
                                        <td colspan="8">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="4" valign="middle">
                                            <asp:Label ID="Label77" runat="server" Font-Bold="true" Text="Polrised Code:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPolarisedCode1" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label69" runat="server" Text="Total:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedTotal1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label70" runat="server" Text="Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedCenter1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label71" runat="server" Text="Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedRight1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPolarisedCode2" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label59" runat="server" Text="Left:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedLeft2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label66" runat="server" Text="Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedCenter2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label67" runat="server" Text="Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedRight2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPolarisedCode3" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label68" runat="server" Text="Left:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedLeft3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label72" runat="server" Text="Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedCenter3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label73" runat="server" Text="Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedRight3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPolarisedCode4" runat="server" Width="96%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label74" runat="server" Text="Left:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedLeft4" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label75" runat="server" Text="Center:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedCenter4" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label76" runat="server" Text="Right:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPolarisedRight4" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Jumbo Quality Analysis"
                            ID="TPJumboQualityAnalysis">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 4%">
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label56" runat="server" Font-Bold="True" Text="WINDING:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label94" runat="server" Text="Unflush:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUnflush" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label95" runat="server" Text="Rough Cutting:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRoughCutting" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label96" runat="server" Text="Telescoping:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTelescoping" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label93" runat="server" Text="Loose Winding:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLooseWinding" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label78" runat="server" Text="Wind Variation:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWindVariation" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label79" runat="server" Text="Trim Inside:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTrimInside" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label80" runat="server" Text="Fold Inside:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFoldInside" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label81" runat="server" Text="Trim Cut:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTrimCut" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label82" runat="server" Font-Bold="True" Text="WRINKLES/RIPPLES:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label83" runat="server" Text="Wrinkles In Top:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWrinklesInTop" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label84" runat="server" Text="Wrinkles In Buttom:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWrinklesInButtom" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label85" runat="server" Text="Hard Ripples on Top:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHardRipplesonTop" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label86" runat="server" Text="Hard Ripples in Between:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHardRipplesinBetween" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label87" runat="server" Font-Bold="True" Text="SCRATCH LINE:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label88" runat="server" Text="Accross Full Width:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAccrossFullWidthScratch" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label89" runat="server" Text="Only in Some Portion:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOnlyinSomePortionScratch" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
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
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label90" runat="server" Font-Bold="True" Text="HT WIRE MARKING:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label91" runat="server" Text="Accross Full Width:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAccrossFullWidthHT" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label92" runat="server" Text="Only in Some Portion:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOnlyinSomePortionHT" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
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
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label97" runat="server" Font-Bold="True" Text="GUAGE VARIATION:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label98" runat="server" Text="Die Reset Jumbo:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDieResetJumbo" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label99" runat="server" Text="Negative Band Visible on Winder:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNegativeBandVisibleonWinder" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label100" runat="server" Text="Guage Band Visible on Winder:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGuageBandVisibleonWinder" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label101" runat="server" Font-Bold="True" Text="PROCESS CONDITION CHANGED DURING PROCESSING:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <asp:TextBox ID="txtProcessConditionChanged" runat="server" TabIndex="27" Width="98%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label102" runat="server" Font-Bold="True" Text="SHADE VARIATION:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <asp:TextBox ID="txtShadeVariation" runat="server" TabIndex="27" Width="98%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label103" runat="server" Font-Bold="True" Text="MIXED MATERIAL:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label104" runat="server" Text="Different Microns:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDifferentMicrons" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label105" runat="server" Text="Coated & Uncoated:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoatedUncoated" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label106" runat="server" Text="Corona & Plan:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoronaPlan" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td colspan="8">
                                            <asp:Label ID="Label107" runat="server" Font-Bold="True" Text="FOREIGN MATERIAL:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label108" runat="server" Text="Black Dust Particle:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBlackDustParticle" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label109" runat="server" Text="Gels:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGels" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label110" runat="server" Text="Unmolten Particle:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUnmoltenParticle" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" CssClass="tabControl" HeaderText="Other Details" ID="TabPanel2">
                            <ContentTemplate>
                                <table width="99%">
                                    <tr style="height: 10px">
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 11%">
                                        </td>
                                        <td style="width: 13%">
                                        </td>
                                        <td style="width: 4%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label111" runat="server" Text="Remarks:"></asp:Label>
                                        </td>
                                        <td colspan="7">
                                            <asp:TextBox ID="txtRemarks1" runat="server" TabIndex="27" Width="98%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="7">
                                            <asp:TextBox ID="txtRemarks2" runat="server" TabIndex="27" Width="98%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label112" runat="server" Text="Jumbo Planned/Unplanned:"></asp:Label>
                                        </td>
                                        <td colspan="7">
                                            <asp:CheckBox ID="chkJumboPlannedUnplanned" runat="server" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label113" runat="server" Text="Reason for Unplanned:"></asp:Label>
                                        </td>
                                        <td colspan="7">
                                            <asp:TextBox ID="txtReasonforUnplanned" runat="server" TabIndex="27" Width="98%"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label114" runat="server" Text="Trim Weight per mtr:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTrimWeightpermtr" runat="server" TabIndex="27" Width="98%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label115" runat="server" Text="Jumbo Extrusion Qty:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtJumboExtrusionQty" runat="server" TabIndex="27" Width="98%"></asp:TextBox>
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
                                    <tr style="font-size: small; font-weight: bold" align="center">
                                        <td colspan="4">
                                            <asp:Label ID="Label137" runat="server" Font-Bold="True" Text="Main Silo"></asp:Label>
                                        </td>
                                        <td colspan="4">
                                            <asp:Label ID="Label119" runat="server" Font-Bold="True" Text="Co-Ex"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small; font-weight: bold" align="center">
                                        <td>
                                            <asp:Label ID="Label138" runat="server" Text="Material Code:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label142" runat="server" Text="%age:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label116" runat="server" Text="Grade:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label143" runat="server" Text="Vendor:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label117" runat="server" Text="Material Code:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label118" runat="server" Text="%age:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label144" runat="server" Text="Grade:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label145" runat="server" Text="Vendor:"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloMaterialCode1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloPercentage1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMainSiloPercentage1"
                                                Display="None" ErrorMessage="Enter a valid percentage. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                            <asp:ValidatorCalloutExtender ID="VCEWidthInMM" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator5">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloGrade1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMainSiloVendor1" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexMaterialCode1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexPercentage1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtCoexPercentage1"
                                                Display="None" ErrorMessage="Enter a valid percentage. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator6">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexGrade1" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCoexVendor1" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloMaterialCode2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloPercentage2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtMainSiloPercentage2"
                                                Display="None" ErrorMessage="Enter a valid percentage. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator7">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloGrade2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMainSiloVendor2" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexMaterialCode2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexPercentage2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtCoexPercentage2"
                                                Display="None" ErrorMessage="Enter a valid percentage. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator8">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexGrade2" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCoexVendor2" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloMaterialCode3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloPercentage3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtMainSiloPercentage3"
                                                Display="None" ErrorMessage="Enter a valid percentage. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator9">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMainSiloGrade3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMainSiloVendor3" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexMaterialCode3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexPercentage3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtCoexPercentage3"
                                                Display="None" ErrorMessage="Enter a valid percentage. (Only two digits are allowed after decimal.)"
                                                ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator10">
                                    </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCoexGrade3" runat="server" TabIndex="27" Width="90%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCoexVendor3" runat="server" Width="84%" ValidationGroup="1">
                                                <asp:ListItem>-Select-</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:ImageButton ID="ImgBtnSave" runat="server" Text="Save" ValidationGroup="1" TabIndex="5"
                        ImageUrl="~/Images/btnSave.png" onclick="ImgBtnSave_Click" />
                    <asp:ImageButton ID="ImageBtnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        OnClientClick="window.close();" TabIndex="5" ImageUrl="~/Images/btnCancel.png" />
                    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hidPetJumboId" runat="server" />
                    <asp:HiddenField ID="HidYear" runat="server" />
                    <asp:HiddenField ID="HidShrinkPolarisedID" runat="server" />
                    <asp:HiddenField ID="HidJumboQualityId" runat="server" />
                    <asp:HiddenField ID="HidOtherDetailsId" runat="server" />  
                    <asp:HiddenField ID="HidIntermediatePetJumboId" runat="server" />                 
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
                            PET List</div>
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
                        <asp:GridView ID="gvPetJumboAll" runat="server" AutoGenerateColumns="false" Width="100%"
                            CssClass="GridViewStyle" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found."
                            AllowPaging="true" PageSize="3" onrowcommand="gvPetJumboAll_RowCommand" 
                            onpageindexchanging="gvPetJumboAll_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("PetJumboId") %>'
                                                CommandName="select" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="JumboNo" HeaderText="Jumbo No">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JumboDate" HeaderText="Jumbo Date">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ShiftCode" HeaderText="Shift Code">
                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LineCode" HeaderText="Line Code">
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
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label3"
        PopupControlID="PnlShowSerach" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel3" CancelControlID="ImgBtnCancel" />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    
</asp:Content>--%>
