<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Controls/HomePageTasksSales.ascx" TagName="Sales" TagPrefix="HomeSale" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function newPopup(url) {

            //popupWindow = window.open(url, 'popUpWindow', 'height=600,width=800,toolbar=no, location=0, status=no,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,directories=no,status=yes')

            var w = screen.availWidth || screen.width;
            var h = screen.availHeight || screen.height;
            var popupWindow = window.open(url, 'popUpWindow', "width=950,height=450,top=" + (h - 500) / 2 + ",left=" + (w - 1005) / 2 + ",resizable=no,scrollbars=yes");
        }

        function newPopuplarge(url) {

            //popupWindow = window.open(url, 'popUpWindow', 'height=600,width=800,toolbar=no, location=0, status=no,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,directories=no,status=yes')

            var w = screen.availWidth || screen.width;
            var h = screen.availHeight || screen.height;

            var popupWindow = window.open(url, 'popUpWindow', "width=1300,height=700,top=" + (h - 734) / 2 + ",left=" + (w - 1358) / 2 + ",resizable=no,scrollbars=yes");

        }

        function highlight(header) {

            Recolor();


            if (header == 'Transaction') {

                document.getElementById('div_trans').style.background = 'url("images/nav_link_hover.png") repeat-x scroll 0 0 green';
                document.getElementById('div_trans').scrollIntoView(true);

            }
            if (header == 'Form Print') {
                document.getElementById('div_formpri').style.background = 'url("images/nav_link_hover.png") repeat-x scroll 0 0 green';
                document.getElementById('div_formpri').scrollIntoView(true);
            }
            if (header == 'Reports') {
                document.getElementById('div_report').style.background = 'url("images/nav_link_hover.png") repeat-x scroll 0 0 green';
                document.getElementById('div_report').scrollIntoView(true);
            }
            if (header == 'Query') {
                document.getElementById('div_query').style.background = 'url("images/nav_link_hover.png") repeat-x scroll 0 0 green';
                document.getElementById('div_query').scrollIntoView(true);
            }
            if (header == 'Listing') {
                document.getElementById('div_listing').style.background = 'url("images/nav_link_hover.png") repeat-x scroll 0 0 green';
                document.getElementById('div_listing').scrollIntoView(true);
            }
            if (header == 'My User Management') {
                document.getElementById('div_myusrmgmt').style.background = 'url("images/nav_link_hover.png") repeat-x scroll 0 0 green';
                document.getElementById('div_myusrmgmt').scrollIntoView(true);
            }
            if (header == 'Master') {
                document.getElementById('div_master').style.background = 'url("images/nav_link_hover.png") repeat-x scroll 0 0 green';
                document.getElementById('div_master').scrollIntoView(true);

            }
            if (header == 'Entity Configuration') {
                document.getElementById('div_admin').style.background = 'url("images/nav_link_hover.png") repeat-x scroll 0 0 green';
                document.getElementById('div_admin').scrollIntoView(true);

            }          

        }

        function Recolor() {

            try {


                document.getElementById('div_trans').style.background = '#B9DCFF';
            }
            catch (e) {
            }
            try {

                document.getElementById('div_formpri').style.background = '#B9DCFF';
            } catch (e) { }
            try {
                document.getElementById('div_report').style.background = '#B9DCFF';
            } catch (e) { }
            try {
                document.getElementById('div_query').style.background = '#B9DCFF';
            } catch (e) {
            }
            try {
                document.getElementById('div_listing').style.background = '#B9DCFF';
            } catch (e) {
            }
            try {
                document.getElementById('div_master').style.background = '#B9DCFF';
            } catch (e) {
            }
            try { document.getElementById('div_myusrmgmt').style.background = '#B9DCFF'; } catch (e) {
            }
            try {
                document.getElementById('div_admin').style.background = '#B9DCFF';
            } catch (e) {
            }


        }
    </script>
    <style type="text/css">
        .pnl_in
        {
            background: -moz-linear-gradient(#FCFDFE, #F4F8FC) repeat scroll 0 0 #FCFDFE;
            border: 1px solid #C9DDF2;
            border-radius: 0px 0px 5px 5px;
            display: block;
            float: left;
            margin-top: 0px;
            vertical-align: top;
            width: 253px;
            font-family: Arial;
            padding-top: 10px;
            padding-left: 10px;
            padding-bottom: 10px;
            font-size: 12px;
        }
        .in_menu_head
        {
            background: url("images/newbtn_middle.png") repeat-x scroll 0 0 #B9DCFF;
            border: 1px solid #5A7F97;
            height: 22px;
            padding-top: 3px;
            padding-left: 10px;
            padding-bottom: 0px;
            font-size: 14px;
            font-weight: bold;
            text-align: left;
        }
        .accordionC
        {
            background-color: White;
            border-top: none;
            padding: 8px;
            padding-top: 10px;
            color: Black;
            text-decoration: none;
            font-family: Arial;
            font-size: 13px;
            color: black;
            text-align: left;
        }
        .accordionLink
        {
            color: Black;
            text-decoration: none;
            font-family: Arial;
            font-size: 12px;
        }
        .pnl_Container
        {
            vertical-align: top;
            height: 623px;
            overflow: auto;
        }
        .rt
        {
            background: url("images/btnCancel.png") repeat-x scroll 0 0 #B9DCFF;
        }
        #div_salestab:hover
        {
            background-image: url('images/nav_link_hover.png');
            background-repeat: repeat-x;
        }
        #div_FAtab:hover
        {
            background-image: url('images/nav_link_hover.png');
            background-repeat: repeat-x;
        }
        #div_Procurementtab:hover
        {
            background-image: url('images/nav_link_hover.png');
            background-repeat: repeat-x;
        }
        #div_Productiontab:hover
        {
            background-image: url('images/nav_link_hover.png');
            background-repeat: repeat-x;
        }
        
        .TaskGridHeader
        {
            background-image: url('images/nav_link_hover.png');
            background-repeat: repeat-x;
            font-family: Arial;
            font-size: 11px;
            font-weight: bold;
        }
        .TasksideInfo
        {
            background-image: url('images/nav_link_hover.png');
            background-repeat: repeat-x;
        }
    </style>
    <%-- <script language="javascript" type="text/javascript">


        function Openpane(paneIndex, eventElement) {

            var behavior = $get("MyAccordion").AccordionBehavior;

            behavior.set_SelectedIndex(paneIndex);
        }
         
    </script>--%>
    <link href="css/PolyplexMaster.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
    <div style="width: 100%">
        <div id="contentsMain" style="margin: 0px auto 0px auto; width: 1250px;">
            <div class="header">
                <table width="98%">
                    <tr>
                        <td>
                            <img src="images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex" />
                        </td>
                        <td>
                            <div align="center" style="font-size: 13px">
                                Location:&nbsp;
                                <asp:Label ID="lbl_location" runat="server" Text=""></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div align="right" style="font-size: 13px; font-weight: bold">
                                Welcome&nbsp;
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>&nbsp;|&nbsp;
                                <asp:LinkButton ID="lnk_logout" runat="server" ForeColor="Black" OnClick="lnk_logout_Click">Sign Out</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="menu" id="Div2" style="width: 300px;">
                <div class="subHeader">
                    <div>
                        ERP Authorization</div>
                </div>
                <div class="contentPanel" id="Div4">
                    <ajaxToolkit:Accordion ID="MyAccordion" runat="server" HeaderCssClass="accordionHeader"
                        SelectedIndex="-1" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionC"
                        SuppressHeaderPostbacks="false" FadeTransitions="false" FramesPerSecond="40"
                        TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" Width="300px"
                        Height="500px">
                        <Panes>
                            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                                <Header>
                                    <%--<asp:ImageButton ID="lnk_sales" AlternateText="Sales" Width="300px" CssClass="rt" onmouseover="this.src='images/btnAdd.png';" onmouseout="this.src='images/btnCancel.png';" runat="server" OnClick="lnk_sales_Click" />--%>
                                    <div class="accordionLink" id="div_salestab">
                                        <div style="margin: 0px; padding: 5px">
                                            <asp:LinkButton ID="lnk_sales" runat="server" CssClass="accordionLink" OnClick="lnk_sales_Click">Sales&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                        </div>
                                    </div>
                                </Header>
                                <Content>
                                    <asp:Panel ID="Pnl_sales" runat="server">
                                    </asp:Panel>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                <Header>
                                    <div class="accordionLink" id="div_FAtab">
                                        <div style="margin: 0px; padding: 5px">
                                            <asp:LinkButton ID="lnk_FA" runat="server" CssClass="accordionLink" OnClick="lnk_FA_Click">Financial Accounting&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                            <%--<asp:Button Width="290px" Height="30px" ID="lnk_FA" runat="server" class="accordionLink" OnClick="lnk_FA_Click" Text="TextFinancial Accounting" />--%>
                                        </div>
                                    </div>
                                </Header>
                                <Content>
                                    <asp:Panel ID="Pnl_Finan" runat="server">
                                    </asp:Panel>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                                <Header>
                                    <div class="accordionLink" id="div_Procurementtab">
                                        <div style="margin: 0px; padding: 5px">
                                            <asp:LinkButton ID="lnk_procurement" runat="server" CssClass="accordionLink" OnClick="lnk_procurement_Click">Procurement&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></div>
                                    </div>
                                </Header>
                                <Content>
                                    <asp:Panel ID="Pnl_procuremnt" runat="server">
                                    </asp:Panel>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                                <Header>
                                    <div class="accordionLink" id="div_Productiontab">
                                        <div style="margin: 0px; padding: 5px">
                                            <asp:LinkButton ID="lnk_production" runat="server" CssClass="accordionLink" OnClick="lnk_production_Click">Production&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></div>
                                    </div>
                                </Header>
                                <Content>
                                    <asp:Panel ID="Pnl_production" runat="server">
                                    </asp:Panel>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                                <Header>
                                    <div class="accordionLink" id="div_Admintab">
                                        <div style="margin: 0px; padding: 5px">
                                            <asp:LinkButton ID="lnk_admin" runat="server" CssClass="accordionLink" OnClick="lnk_admin_Click">Admin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></div>
                                    </div>
                                </Header>
                                <Content>
                                    <asp:Panel ID="Pnl_admin" runat="server">
                                    </asp:Panel>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                        </Panes>
                    </ajaxToolkit:Accordion>
                </div>
            </div>
            <div class="content1" id="content" style="width: 600px">
                <div class="subHeader">
                    <div>
                        <asp:Label ID="lbl_sub_header" runat="server" Text=""></asp:Label></div>
                </div>
                <div class="pnl_Container" id="pnl_cont">
                
                    <table width="560px" cellpadding="10px" style="margin-top: 40px">
                        <tr>
                            <td style="width: 50%; vertical-align: top">
                                <div id="div_in_trans" runat="server" style="width: 265px">
                                    <div class="in_menu_head" id="div_trans">
                                        Transactions</div>
                                    <asp:Panel ID="pnl_in_trans" CssClass="pnl_in" runat="server">
                                    </asp:Panel>
                                </div>
                            </td>
                            <td style="width: 50%; vertical-align: top;">
                                <div id="div_in_formpri" runat="server" style="width: 265px">
                                    <div class="in_menu_head" id="div_formpri">
                                        Form Printing</div>
                                    <asp:Panel ID="pnl_in_formpri" CssClass="pnl_in" runat="server">
                                    </asp:Panel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; vertical-align: top">
                                <div id="div_in_reports" runat="server" style="width: 265px">
                                    <div class="in_menu_head" id="div_report">
                                        Reports</div>
                                    <asp:Panel ID="pnl_in_reports" CssClass="pnl_in" runat="server">
                                    </asp:Panel>
                                </div>
                            </td>
                            <td style="width: 50%; vertical-align: top">
                                <div id="div_in_query" runat="server" style="width: 265px">
                                    <div class="in_menu_head" id="div_query">
                                        Query</div>
                                    <asp:Panel ID="pnl_in_query" CssClass="pnl_in" runat="server">
                                    </asp:Panel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; vertical-align: top">
                                <div id="div_in_listing" runat="server" style="width: 265px">
                                    <div class="in_menu_head" id="div_listing">
                                        Listing</div>
                                    <asp:Panel ID="pnl_in_listing" CssClass="pnl_in" runat="server">
                                    </asp:Panel>
                                </div>
                            </td>
                            <td style="width: 50%; vertical-align: top">
                                <div id="div_in_myusermanagement" runat="server" style="width: 265px">
                                    <div class="in_menu_head" id="div_myusrmgmt">
                                        My User Management</div>
                                    <asp:Panel ID="pnl_in_myusermanagement" CssClass="pnl_in" runat="server">
                                    </asp:Panel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; vertical-align: top">
                                <div id="div_in_master" runat="server" style="width: 265px">
                                    <div class="in_menu_head" id="div_master">
                                        Masters</div>
                                    <asp:Panel ID="pnl_in_master" CssClass="pnl_in" runat="server">
                                    </asp:Panel>
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; vertical-align: top">
                                <div id="div_in_admin" runat="server" style="width: 265px">
                                    <div class="in_menu_head" id="div_admin">
                                        Entity Configuration</div>
                                    <asp:Panel ID="pnl_in_admin" CssClass="pnl_in" runat="server">
                                    </asp:Panel>
                                </div>
                            </td>                           
                        </tr>   
                    </table>
                </div>
                
            </div>
            <div class="content1" style="width: 300px" id="Div1">
                <div class="subHeader">
                    <div>
                        Tasks</div>
                </div>
                <div class="divtasks" id="Tasks">
                    <HomeSale:Sales ID="SalesTasks" runat="server" />
                </div>
            </div>
            <div class="clear" align="right" style="padding-right: 10px">
                <asp:Label ID="lbl_Environment" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <asp:Label ID="Lbl_menu" Visible="false" runat="server" Text="Label"></asp:Label>
    <asp:HiddenField ID="HidUserId" runat="server" />
    </form>
</body>
</html>
