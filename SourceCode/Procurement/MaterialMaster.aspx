<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MastersPage.master" AutoEventWireup="true"
    CodeFile="MaterialMaster.aspx.cs" Inherits="Production_MaterialMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .txtbx
        {
            width: 130px;
            border: 1px solid grey;
            font-family: Arial;
            font-size: 12px;
        }
        
        .valid
        {
            color: Red;
            font-weight: bold;
            font-size: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeading" runat="Server">
    Material Master
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScript" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
            <ajaxToolkit:TabContainer runat="server" ActiveTabIndex="1" TabStripPlacement="Top"
                ID="TabContCustomer" CssClass="myTabs" Width="100%">
                <ajaxToolkit:TabPanel runat="server" HeaderText="Basic" ID="tabBasic" Height="440px">
                    <ContentTemplate>
                        <table width="100%" cellpadding="3px">
                            <tr>
                                <td width="25%">
                                    &nbsp;
                                </td>
                                <td width="25%">
                                </td>
                                <td width="25%">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Material Code:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtMaterialCode" CssClass="txtbx" runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div align="right">
                                        Material Type:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddMaterialType" CssClass="txtbx" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Category(as per DOA):</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtCategory" CssClass="txtbx" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        G L Category (By A/c):</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="TextBox1" CssClass="txtbx" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Characteristic Group:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddCharacteristicGroup" CssClass="txtbx" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Material Description:</div>
                                </td>
                                <td colspan="3">
                                    <div align="left">
                                        <asp:TextBox ID="txtMaterialDesc" CssClass="txtbx" Width="380px" TextMode="MultiLine"
                                            runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Long Description:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtLongDesc" CssClass="txtbx" Width="380px" TextMode="MultiLine"
                                            runat="server"></asp:TextBox></div>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        UOM:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:DropDownList ID="ddUom" CssClass="txtbx" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        Machine Part:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtMachinePart" CssClass="txtbx" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Material Group:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtMaterialGroup" CssClass="txtbx" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        Import Duty:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtImportDuty" CssClass="txtbx" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        Old Material Code:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtOldMaterialCode" CssClass="txtbx" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div align="right">
                                        H S Code:</div>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:TextBox ID="txtHSCode" CssClass="txtbx" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:CheckBox ID="chk_batchIndicator" Text="Batch Indicator" runat="server" /></div>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:CheckBox ID="chk_SupplierWiseInventory" Text="Supplier Wise Inventory" runat="server" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:CheckBox ID="chk_shelfLifeIndicator" Text="Shelf Life Indicator" runat="server" /></div>
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <div align="right">
                                                    Shelf life in Days:</div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="txtShelflifeindays" CssClass="txtbx" Width="50px" runat="server"></asp:TextBox></div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <div align="left">
                                        <asp:CheckBox ID="chk_Active" Text="Active" runat="server" /></div>
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
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="MRP" ID="tabMrp" Height="440px">
                    <ContentTemplate>
                        <table width="100%" cellpadding="3px">
                            <tr>
                                <td>
                                    <div align="center">
                                        <strong>Material Code:</strong>&nbsp;&nbsp;<asp:TextBox ID="txtMaterialCode_MRP" CssClass="txtbx"
                                            runat="server"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr> 
                                <td>
                                    <div>
                                        <asp:Panel ID="pnldivMRP" runat="server">
                                        </asp:Panel>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                &nbsp;
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
                                                <div align="right">
                                                    Plant:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:DropDownList ID="DropDownList1" CssClass="txtbx" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    MRP Group:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:DropDownList ID="DropDownList2" CssClass="txtbx" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    Re_Order Paint:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox2" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="right">
                                                    MRP Controller:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:DropDownList ID="DropDownList3" CssClass="txtbx" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    Maximum Stock:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox3" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    Minimum Stock:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox4" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="right">
                                                    Lot Size:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox5" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    Quality Check:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox6" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    Purchasing Group:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:DropDownList ID="DropDownList4" CssClass="txtbx" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="right">
                                                    Department Code:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox7" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    Machine Code:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox8" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    ABC Indicator:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:DropDownList ID="DropDownList5" CssClass="txtbx" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="right">
                                                    Monthly Purchase:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:CheckBox ID="chkMonthlyPurchase" runat="server" />
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    Storage Location:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox9" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    Bin:
                                                </div>
                                            </td>
                                            <td>
                                                <div align="left">
                                                    <asp:TextBox ID="TextBox10" CssClass="txtbx" runat="server"></asp:TextBox>
                                                </div>
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
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Basic" ID="tabCharacGroup" Height="440px">
                    <ContentTemplate>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPreSaveUpdate" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphNextCancel" runat="Server">
</asp:Content>
