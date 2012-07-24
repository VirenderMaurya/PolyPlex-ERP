<%@ Page Title="" Language="C#" MasterPageFile="~/Sales/PolyplexMaster.master" AutoEventWireup="true"
    CodeFile="TestShri.aspx.cs" Inherits="Sales_TestShri" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<link href="../CSS/myTabs.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ToolkitScriptManager ID="tert" runat="server"></asp:ToolkitScriptManager>
<asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
    <asp:TabContainer ID="TabContainer1" runat="server" CssClass="miTabs" 
        Width="400px" ForeColor="Black">
        <asp:TabPanel ID="tp1" runat="server" HeaderText="Hello1">
            <ContentTemplate>
            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1<br />
            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1<br />
            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1<br />
            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1<br />
            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1<br />
            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1<br />
            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1<br />
            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1
<br />            Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1
      <br />      Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1
            <br />Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1
            Hello1<br />Hello1Hello1Hello1Hello1Hello1Hello1Hello1Hello1
            Hello1Hello1<br />Hello1Hello1Hello1Hello1Hello1Hello1Hello1
            Hello1Hello1Hello1<br />Hello1Hello1Hello1Hello1Hello1Hello1
            Hello1Hello1Hello1Hello1<br />Hello1Hello1Hello1Hello1Hello1
            Hello1Hello1Hello1Hello1Hello1<br />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Hello2">
            <ContentTemplate>
            Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2Hello2
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Hello3">
            <ContentTemplate>
            Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3Hello3
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
