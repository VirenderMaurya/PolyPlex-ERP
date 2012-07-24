<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="CSS/loginpage.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .logintxt
        {
            font-family: Arial;
            font-size: 14px;
            font-weight: bold;
            color: #444444;
        }
        body
        {
            background-image: url('images/home.gif');
            background-repeat: repeat-x;
        }
        .button
        {
            background-color: #B9DCFF;
            background-image: none;
            border: 1px solid rgba(0, 0, 0, 0.2);
            box-shadow: 0 2px 0 rgba(0, 0, 0, 0.1), 0 1px 0 rgba(255, 255, 255, 0.25) inset;
            color: Black;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.4);
            font-size: 14px;
            height: 30px;
            width: 80px;
            font-weight: bold;
            padding-bottom: 6px;
        }
        .lnkbtn
        {
            text-decoration: none;
            font-size: 12px;
            font-family: Arial;
        }
        .modalBackground
        {
            background-color: gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function OnSelectedIndexChange() {
            document.getElementById('<%=txtPassword.ClientID %>').focus();
        }

        function RefreshPage() {
            __doPostBack('txtcur', '');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="modal" id="divlogin">
            <div id="signin_content">
                <div class="title" style="background: none repeat scroll 0 0 #B9DCFF">
                    <table width="90%">
                        <tr>
                            <td>
                                <div class="logo" align="left">
                                    <img src="images/Polyplex Logo.png" alt="Polyplex" height="35px" width="130px" /></div>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="center" class="logintxt">
                                        <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table width="70%" cellpadding="5px">
                               
                                <tr>
                                    <td>
                                        <div align="left" class="logintxt">
                                            Login ID</div>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLoginID" AutoPostBack="true" TabIndex="1" CssClass="txtbx" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>
                                        <div align="left" class="logintxt">
                                            Password</div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" CssClass="txtbx" runat="server" TabIndex="2" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       <div align="left" class="logintxt">
                                           Language</div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td><asp:DropDownList ID="ddlanguage" CssClass="txtbx" runat="server" TabIndex="3">
                                    <asp:ListItem>-Select-</asp:ListItem>
                                    <asp:ListItem>English-US</asp:ListItem>
                                   
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left" class="logintxt">
                                            Environment</div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEnvironment" CssClass="txtbx" runat="server" TabIndex="4">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <div align="left" class="logintxt">
                                            Location</div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlLocation" CssClass="txtbx" runat="server" TabIndex="5">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtLoginID" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="BtnLogin" />
                            <asp:AsyncPostBackTrigger ControlID="lnkbtnForgotPassword" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="buttons">
                        <table width="85%">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="BtnLogin" runat="server" Text="Sign In" CausesValidation="false"
                                        OnClick="BtnLogin_Click" TabIndex="6" ImageUrl="images/btn_SignIn.png" />
                                </td>
                                <td>
                                    <div align="right">
                                        <asp:LinkButton ID="lnkbtnForgotPassword" runat="server" CssClass="lnkbtn" CausesValidation="false"
                                            TabIndex="7" OnClick="lnkbtnForgotPassword_Click">Forgot Password?</asp:LinkButton></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <ajaxToolkit:ModalPopupExtender ID="ModelPopupExtShow" runat="server" PopupControlID="divlogin"
            DropShadow="false" TargetControlID="hidShow" BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender>
        <asp:HiddenField ID="hidShow" runat="server" />
        <asp:Button ID="BtnOpen" runat="server" OnClick="BtnOpen_Click" Text="Show Popup" />
    </div>
    </form>
</body>
</html>
