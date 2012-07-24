<%@ Page Title="" Language="C#" MasterPageFile="PolyplexMaster.master"
    AutoEventWireup="true" CodeFile="EntityConfiguration.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Sales_PerformaInvoice" %>

<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="CSS/popupstyle.css" type="text/css" />
    <link href="CSS/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        function openpopup(url) {            
            var w = screen.availWidth || screen.width;
            var h = screen.availHeight || screen.height;            
            var ConfigurationpopUpWindow = window.open(url, 'ConfigurationpopUpWindow', "width=950,height=450,top=" + (h - 500) / 2 + ",left=" + (w - 1005) / 2 + ",resizable=no,scrollbars=yes");
            return false;
        }       

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </asp:ToolkitScriptManager>
    <div style="height: auto; position: relative;">
        <table style="width: 100%;">
            
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
            
            <tr style="font-size:small; font-weight:bold;text-decoration:underline">
                <td align="right">
                    
                    <asp:Label ID="Label2" runat="server" Text="General"></asp:Label>
                    
                </td>
                <td>
                    
                </td>
                <td align="right">
                   
                    <asp:Label ID="Label3" runat="server" Text="Customer"></asp:Label>
                   
                </td>
                <td>
                    
                </td>
                <td align="right">
                   
                    <asp:Label ID="Label4" runat="server" Text="Sales"></asp:Label>
                   
                </td>
                <td>
                    
                </td>
                <td>
                </td>
            </tr>
            <tr style="font-size:11px">
                <td align="right">
                   
                    <asp:LinkButton ID="lnkBtnCountry" runat="server">Country</asp:LinkButton>
                   
                </td>
                <td>
                    
                </td>
                <td align="right">
                <asp:LinkButton ID="lnkBtnCustomerType" runat="server" >Customer Type</asp:LinkButton>
                </td>
                <td>
                </td>
                <td align="right">
                <asp:LinkButton ID="lnkBtnSalesType" runat="server">Sales Type</asp:LinkButton>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr style="font-size:11px">
                <td align="right">
                   
                <asp:LinkButton ID="lnkBtnPaymentTerms" runat="server">Payment Terms</asp:LinkButton>
                   
                </td>
                <td>
                    
                </td>
                <td align="right">
                <asp:LinkButton ID="lnkBtnFinalDestination" runat="server">Final Destination</asp:LinkButton>
                </td>
                <td>
                </td>
                <td align="right">
                <asp:LinkButton ID="lnkBtnSalesArea" runat="server">Sales Area</asp:LinkButton>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr style="font-size:11px">
                <td align="right">
                   
                <asp:LinkButton ID="lnkBtnFilmType" runat="server">Film Type</asp:LinkButton>
                   
                </td>
                <td>
                    
                </td>
                <td align="right">
                <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
                </td>
                <td>
                </td>
                <td align="right">
                <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr style="font-size:11px">
                <td align="right">
                   
                <asp:LinkButton ID="lnkBtnRegion" runat="server">Region</asp:LinkButton>
                   
                </td>
                <td>
                    
                </td>
                <td align="right">
                <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>
                </td>
                <td>
                </td>
                <td align="right">
                <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
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
        </table>
    </div>   
    
</asp:Content>
