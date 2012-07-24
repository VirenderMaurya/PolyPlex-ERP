<%@ Page Title="Metalizer Jumbo" Language="C#" MasterPageFile="~/Production/PolyplexMaster.master" AutoEventWireup="true" CodeFile="MetJumbo.aspx.cs" Inherits="Production_MetJumbo" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="timesel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="../CSS/popupstyle.css" type="text/css" />
<link href="../CSS/PolyplexMaster.css" rel="stylesheet" type="text/css" />
<link href="../CSS/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
    <table width="100%">
    <tr>
    <td width="10%" align="right"></td><td width="10%">
    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                 </td>
                             <td width="10%"></td>
                               <td width="10%">
                                   </td>
                             <td width="10%" align="right"></td><td width="10%">
                                 </td><td width="10%" align="right"></td><td width="10%">
                                 </td>
    </tr>
    <tr>
    <td width="10%" align="right"></td><td colspan="6">

      <div style="overflow: scroll; height: 100%; width: 500px">
                                <asp:GridView ID="GdvMachineData" runat="server" AllowSorting="True" CssClass="GridViewStyle"
                            ShowHeaderWhenEmpty="true" EmptyDataText="No record found from machine" AutoGenerateColumns="False"
                            OnPageIndexChanging="GdvMachineData_PageIndexChanging"  Width="480px"
                                    onrowcommand="GdvMachineData_RowCommand">
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                           <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                   <ItemTemplate>
                                        <asp:RadioButton ID="checkbx" runat="server" AutoPostBack="true"  OnCheckedChanged="chk_CheckChanged" />
                                    </ItemTemplate>
                            </asp:TemplateField>--%>
                              <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") %>'
                                                CommandName="sel" ImageUrl="~/Images/chkbxuncheck.png" Text="Select" />
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                   <ItemTemplate>
                                      <asp:Label ID="lbljumbono" runat="server" Text='<% #Eval("Id")%>'></asp:Label>
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="Jumbo Number" />
                            <asp:BoundField DataField="Metalizer" HeaderText="Metalizer" />
                            <asp:BoundField DataField="Micron" HeaderText="Micron" />
                            <asp:BoundField DataField="Type" HeaderText="Type" />
                            <asp:BoundField DataField="Core" HeaderText="Core" />
                            <asp:BoundField DataField="CreatedOn" DataFormatString="{0:d}" HeaderText="CreatedOn" />
                           </Columns>
                        </asp:GridView>
       </div>
        </td>
                             <td width="10%">
                                 </td>
    </tr>
    <tr>
    <td width="10%" align="right"></td><td width="10%">
                                 </td>
                             <td width="10%"></td>
                               <td width="10%">
                                   </td>
                             <td width="10%" align="right"></td><td width="10%">
                                 </td><td width="10%" align="right"></td><td width="10%">
                                 </td>
    </tr>
    <tr>
    <td width="10%" align="right">Metalizer</td><td width="10%">
                                 <asp:TextBox ID="TxtMetalizer" runat="server" 
            Width="80px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="TxtMetalizer_FilteredTextBoxExtender" 
            TargetControlID="TxtMetalizer" runat="server"
                                FilterType="Numbers"  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td width="10%">MET Jumbo Number</td>
                               <td width="10%">
                                 <asp:TextBox ID="TxtJumboNo" runat="server" 
            Width="80px" BackColor="Silver"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="TxtJumboNo_FilteredTextBoxExtender" 
            TargetControlID="TxtJumboNo" runat="server"
                                FilterType="Numbers"  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td width="10%" align="right">Date</td><td width="10%">
                                 <asp:TextBox ID="TxtDate" runat="server" Width="80px" BackColor="Silver"></asp:TextBox>
                                <%--<asp:ImageButton ID="Imgdate" runat="server" ImageUrl="~/Images/cal.gif" />--%>
                                 
                             </td><td width="10%" align="right">Shift</td><td width="10%">
                                 <asp:TextBox ID="TxtShift" runat="server" 
            Width="80px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="TxtShift_FilteredTextBoxExtender" 
            TargetControlID="TxtShift" runat="server"
                                FilterType="Numbers"  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
    </tr>
    </table>
    <asp:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="0" 
        Width="100%">
        <asp:TabPanel ID="TabPanelMain" runat="server" Width="100%" CssClass="tabControl">
            <HeaderTemplate>
            Met Jumbo Details</HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel ID="updpanel" runat="server">
                    <ContentTemplate>
               <table width="100%" cellpadding="1" cellspacing="1">
                    <tr>
               
               
                    <td align="right" width="20%">Micron</td><td width="10%">
                        <asp:TextBox ID="TxtMicron" runat="server" Width="50px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="req1" runat="server"  SetFocusOnError="true" Display="None" ControlToValidate="TxtMicron" ErrorMessage="Please enter Micron" ForeColor="Red"></asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender
                                            ID="Valcalloutbankacountno" runat="server" Enabled="True" TargetControlID="req1">
                                        </asp:ValidatorCalloutExtender>
                                 <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender14" TargetControlID="TxtMicron" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                        </td><td align="right" width="20%">Type</td><td width="10%">
                                <asp:DropDownList ID="DdlType" runat="server">
                                </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  SetFocusOnError="true" Display="None" ControlToValidate="DdlType" 
                                  ErrorMessage="Please select Type" ForeColor="Red" InitialValue="0">
                                  </asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
                        </td><td align="right" width="18%">Core</td><td >
                                <asp:TextBox ID="TxtCore" runat="server" Width="80px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="true" Display="None" ControlToValidate="TxtCore" 
                                  ErrorMessage="Please enter Core" ForeColor="Red">
                                  </asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                        </asp:ValidatorCalloutExtender>
            <asp:FilteredTextBoxExtender
                                ID="TxtCore_FilteredTextBoxExtender" TargetControlID="TxtCore" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Width</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtWidth" runat="server" Width="50px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="reqwidth" runat="server"  SetFocusOnError="true" Display="None" ControlToValidate="TxtWidth" 
                                  ErrorMessage="Please enter Width" ForeColor="Red">
                                  </asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="reqwidth">
                                        </asp:ValidatorCalloutExtender>
                                  <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender15" TargetControlID="TxtWidth" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="20%">
                                Length</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtLength" runat="server" Width="80px"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="reqlength" runat="server"  SetFocusOnError="true" Display="None" ControlToValidate="TxtLength" 
                                  ErrorMessage="Please enter length" ForeColor="Red">
                                  </asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="reqlength">
                                        </asp:ValidatorCalloutExtender>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtLength_FilteredTextBoxExtender" TargetControlID="TxtLength" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                Act.Mic</td>
                            <td >
                                <asp:TextBox ID="TxtActMic" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtActMic_FilteredTextBoxExtender" TargetControlID="TxtActMic" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                            
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Qty(Kg)</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtQtyKg" runat="server" Width="50px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender16" TargetControlID="TxtQtyKg" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="20%">
                                No Of Joints</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtNoOfJoints" runat="server" Width="50px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender17" TargetControlID="TxtNoOfJoints" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Joint1</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtJoint1" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="fltrweight" TargetControlID="TxtJoint1" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="20%">
                                Joint2</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtJoint2" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="fltrvalue" TargetControlID="TxtJoint2" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="18%">
                                Joint3</td>
                            <td >
                                <asp:TextBox ID="TxtJoint3" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtJoint3_FilteredTextBoxExtender" TargetControlID="TxtJoint3" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                OD Min</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtODMin" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtODMin_FilteredTextBoxExtender" TargetControlID="TxtODMin" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="20%">
                                OD Avg</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtODAvg" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtODAvg_FilteredTextBoxExtender" TargetControlID="TxtODAvg" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                OD Max</td>
                            <td >
                                <asp:TextBox ID="TxtODMax" runat="server" Width="80px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender18" TargetControlID="TxtODMax" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Grade</td>
                            <td width="10%">
                                <asp:DropDownList ID="DdlGrade" runat="server">
                                </asp:DropDownList>
                                </td>
                            <td align="right" width="20%">
                                Remarks</td>
                            <td width="10%" colspan="3">
                                <asp:TextBox ID="TxtObservations" runat="server" Height="40px" 
                                    TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Vaccum Start</td>
                            <td align="left" width="10%">
                          <timesel:TimeSelector ID="TimePickerVaccumStart" DisplaySeconds="false" 
                                    runat="server" SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector>
                                </td>
                            <td align="right" width="20%">
                                Heating Start</td>
                            <td align="left" width="10%">
                          <timesel:TimeSelector ID="TimePickerHeatingStart" DisplaySeconds="false" 
                                    runat="server" SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector>
                                </td>
                            <td align="right" width="18%">
                                Acceleration Time</td>
                            <td align="left" >
                          <timesel:TimeSelector ID="TimePickerAccelerationTime" DisplaySeconds="false" 
                                    runat="server" SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td align="right" width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td align="right" >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Met Start Time
                                </td>
                            <td width="10%">
                          <timesel:TimeSelector ID="TimePickerMetStartTime" DisplaySeconds="false" 
                                    runat="server" SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector>
                                </td>
                            <td align="right" width="20%">
                                Deacceleration
                                </td>
                            <td align="left" width="10%">
                          <timesel:TimeSelector ID="TimePickerDeacceleration" DisplaySeconds="false" 
                                    runat="server" SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector>
                                </td>
                            <td align="right" width="18%">
                                Met Stop Time</td>
                            <td align="left" >
                          <timesel:TimeSelector ID="TimePickerMetStoptime" DisplaySeconds="false" 
                                    runat="server" SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td align="right" width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td align="right" >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Vent Time</td>
                            <td width="10%">
                          <timesel:TimeSelector ID="TimePickerVentTime" DisplaySeconds="false" runat="server" 
                                    SelectedTimeFormat="TwentyFour">
                          </timesel:TimeSelector>
                                </td>
                            <td align="right" width="20%">
                                Speed</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtSpeed" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtSpeed_FilteredTextBoxExtender" TargetControlID="TxtSpeed" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                OTR</td>
                            <td >
                                <asp:TextBox ID="TxtOTR" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtOTR_FilteredTextBoxExtender" TargetControlID="TxtOTR" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                WVTR</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtWVTR" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender
                                ID="TxtWVTR_FilteredTextBoxExtender" TargetControlID="TxtWVTR" runat="server"
                                FilterType="Numbers" Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="20%">
                                Bend Strength</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtBendStrength" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender
                                ID="TxtBendStrength_FilteredTextBoxExtender" TargetControlID="TxtBendStrength" runat="server"
                                FilterType="Numbers" Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                Seal Strength Min</td>
                            <td >
                                <asp:TextBox ID="TxtSealStrengthMin" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtSealStrengthMin_FilteredTextBoxExtender" 
                                    TargetControlID="TxtSealStrengthMin" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Seal Strength Average</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtAverage" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender
                                ID="TxtAverage_FilteredTextBoxExtender" TargetControlID="TxtAverage" runat="server"
                                FilterType="Numbers" Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="20%">
                                Seal Strength Max</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtMax" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender
                                ID="TxtMax_FilteredTextBoxExtender" TargetControlID="TxtMax" runat="server"
                                FilterType="Numbers" Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                seal to seal</td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                seal to metal</td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                COF</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtCOFSealtoseal" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender
                                ID="TxtCOFSealtoseal_FilteredTextBoxExtender" 
                                    TargetControlID="TxtCOFSealtoseal" runat="server"
                                FilterType="Numbers" Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                <asp:TextBox ID="TxtCOFSealtometal" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtCOFSealtometal_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Numbers" 
                                    TargetControlID="TxtCOFSealtometal">
                                </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                Tape Test</td>
                            <td >
                                <asp:TextBox ID="TxtTapeTest" runat="server" Width="80px"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender
                                ID="TxtTapeTest_FilteredTextBoxExtender" TargetControlID="TxtTapeTest" runat="server"
                                FilterType="Numbers,Custom" ValidChars="." Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                Back Side</td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                Materlized Siide</td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                Treatment</td>
                            <td width="10%">
                                <asp:TextBox ID="TxtTreatmentBackSide" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender
                                ID="TxtTreatmentBackSide_FilteredTextBoxExtender" 
                                    TargetControlID="TxtTreatmentBackSide" runat="server"
                                FilterType="Numbers" Enabled="True">
                            </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                <asp:TextBox ID="TxtTreatmentMaterlizedside" runat="server" Width="80px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="TxtTreatmentMaterlizedside_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Numbers" 
                                    TargetControlID="TxtTreatmentMaterlizedside">
                                </asp:FilteredTextBoxExtender>
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                </td>
                            <td width="10%">
                                </td>
                            <td align="right" width="20%">
                                <asp:ImageButton ID="BtnSave" ImageUrl="~/Images/btnSave.png" runat="server" 
                                    Text="Save" onclick="BtnSave_Click" />
                                </td>
                            <td width="10%">
                               <asp:ImageButton ID="ImgCancel" runat="server" ImageUrl="~/Images/btnCancel.png" OnClientClick="window.close()" Text="Cancel" style="font-weight: bold" />
                            </td>
                            <td align="right" width="18%">
                                </td>
                            <td >
                                </td>
                        </tr>
                    </table>
                    </ContentTemplate>
               </asp:UpdatePanel>
            </ContentTemplate>
        </asp:TabPanel>
          <asp:TabPanel ID="TabPaneldetails" runat="server" Width="100%" CssClass="tabControl">
            <HeaderTemplate>
            Input Details</HeaderTemplate>
            <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                     <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%" colspan="6" style="width: 35%">
                <asp:GridView ID="GdvDetails" runat="server" AutoGenerateColumns="False" 
                    OnRowCommand="GdvDetails_RowCommand" 
                     ShowHeaderWhenEmpty="true" EmptyDataText="No Records found"
                    OnRowDataBound="GdvDetails_RowDataBound" PageSize="3" Width="100%">
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                     <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbatchno" runat="server" 
                                    CommandArgument='<%#Eval("BatchNo") %>' CommandName="editrow" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Batch No">
                            <ItemTemplate>
                                <asp:Label ID="LblBatchNo" runat="server" Text='<%#Eval("BatchNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Input Weigth">
                            <ItemTemplate>
                                <asp:Label ID="LblWeigth" runat="server" Text='<%#Eval("Weight") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Input Length">
                            <ItemTemplate>
                                <asp:Label ID="LblLength" runat="server" Text='<%#Eval("Length") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Input Width">
                            <ItemTemplate>
                                <asp:Label ID="LblWidth" runat="server" Text='<%#Eval("Width") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblActualWeigth" runat="server" Text='<%#Eval("ActualWeigth") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblActualLength" runat="server" Text='<%#Eval("ActualLength") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblAvailableWeigth" runat="server" Text='<%#Eval("AvailableWeigth") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblAvailableLength" runat="server" Text='<%#Eval("AvailableLength") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblFeedWeigth" runat="server" Text='<%#Eval("FeedWeigth") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblFeedLength" runat="server" Text='<%#Eval("FeedLength") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblThickness" runat="server" Text='<%#Eval("Thickness") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblCore" runat="server" Text='<%#Eval("Core") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblJoints" runat="server" Text='<%#Eval("Joints") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LblSupplierName" runat="server" Text='<%#Eval("SupplierName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgDelete" runat="server" 
                                    CommandArgument='<%#Eval("BatchNo") %>' CommandName="del" 
                                    ImageUrl="~/Images/delete.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
                         <tr>
                             <td width="25%">
                                 </td>
                             <td width="15%">
                                 </td>
                             <td width="20%" align="center" colspan="2" style="width: 35%">
                                 -- Actual--</td>
                             <td width="15%" align="center" colspan="2" style="width: 25%">
                                 --Available--</td>
                         </tr>
        <tr>
            <td width="25%" align="right">
                </td>
            <td width="15%">
                </td>
            <td width="20%" align="center">
                Weigth</td>
            <td width="15%" align="center">
                <%--<asp:TextBox ID="TxtSubType" runat="server" Width="80px"></asp:TextBox>--%>
            
                Length</td>
            <td width="15%" align="center">
                Weigth</td>
            <td width="10%" align="center">
                Length</td>
        </tr>
                         <tr>
                             <td align="right" width="25%">
                                 Batch#</td>
                             <td width="15%">
                                 <asp:TextBox ID="TxtBatch" runat="server" Width="80px" BackColor="Silver"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="fltrbatchno" TargetControlID="TxtBatch" runat="server"
                                FilterType="Numbers"  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="20%">
                                 <asp:TextBox ID="TxtActualWeigth" runat="server" Width="80px"></asp:TextBox>
                                   <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender1" TargetControlID="TxtActualWeigth" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="15%">
                                 <asp:TextBox ID="TxtActualLength" runat="server" Width="80px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender2" TargetControlID="TxtActualLength" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="15%">
                                 <asp:TextBox ID="TxtAvailableWeigth" runat="server" Width="80px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender3" TargetControlID="TxtAvailableWeigth" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="10%">
                                 <asp:TextBox ID="TxtAvailableLength" runat="server" Width="80px"></asp:TextBox>
                                   <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender4" TargetControlID="TxtAvailableLength" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" width="25%">
                                 </td>
                             <td width="15%">
                                 </td>
                             <td align="center" colspan="2" style="width: 35%" width="20%">
                                 --Feed--</td>
                             <td width="15%">
                                 </td>
                             <td width="10%">
                                 </td>
                         </tr>
                         <tr>
                             <td align="right" width="25%">
                                 </td>
                             <td width="15%">
                                 </td>
                             <td align="center" width="20%">
                                 Length</td>
                             <td align="center" width="15%">
                                 Weigth</td>
                             <td width="15%">
                                 </td>
                             <td width="10%">
                                 </td>
                         </tr>
                         <tr>
                             <td align="right" width="25%">
                                 </td>
                             <td width="15%">
                                 </td>
                             <td align="center" width="20%">
                                 <asp:TextBox ID="TxtFeedLength" runat="server" Width="80px"></asp:TextBox>
                                   <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender5" TargetControlID="TxtFeedLength" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="15%">
                                 <asp:TextBox ID="TxtFeedWeigth" runat="server" Width="80px"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender6" TargetControlID="TxtFeedWeigth" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td width="15%">
                                 </td>
                             <td width="10%">
                                 </td>
                         </tr>
                         <tr>
                             <td align="right" width="25%">
                                 Thickness</td>
                             <td align="center" width="15%">
                                 Width</td>
                             <td align="center" width="20%">
                                 Length</td>
                             <td align="center" width="15%">
                                 Weigth</td>
                             <td align="center" width="15%">
                                 Type</td>
                             <td align="center" width="10%">
                                 Core</td>
                         </tr>
                         <tr>
                             <td align="right" width="25%">
                                 <asp:TextBox ID="TxtThickness" runat="server" Width="80px"></asp:TextBox>
                                   <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender7" TargetControlID="TxtThickness" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="15%">
                                 <asp:TextBox ID="TxtWidthHeader" runat="server" Width="80px"></asp:TextBox>
                                   <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender8" TargetControlID="TxtWidthHeader" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="20%">
                                 <asp:TextBox ID="TxtLengthHeader" runat="server" Width="80px"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender9" TargetControlID="TxtLengthHeader" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="15%">
                                 <asp:TextBox ID="TxtDetailsWeigth" runat="server" Width="80px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender10" TargetControlID="TxtDetailsWeigth" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="15%">
                                 <asp:TextBox ID="TxtType" runat="server" Width="80px"></asp:TextBox>
                                   <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender11" TargetControlID="TxtType" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="center" width="10%">
                                 <asp:TextBox ID="TxtJoints" runat="server" Width="80px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender12" TargetControlID="TxtJoints" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" width="25%">
                                 </td>
                             <td width="15%" align="center">
                                 Joints</td>
                             <td align="right" width="20%">
                                 </td>
                             <td width="15%">
                                 </td>
                             <td width="15%">
                                 </td>
                             <td width="10%">
                                 </td>
                         </tr>
                         <tr>
                             <td align="right" width="25%">
                                 </td>
                             <td width="15%" align="center">
                                 <asp:TextBox ID="TxtJonts" runat="server" Width="80px"></asp:TextBox>
                                   <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender13" TargetControlID="TxtJoints" runat="server"
                                FilterType="Numbers,Custom" ValidChars="."  Enabled="True">
                            </asp:FilteredTextBoxExtender>
                             </td>
                             <td align="right" width="20%">
                                 Supplier Name</td>
                             <td colspan="3" style="width: 25%">
                                 <asp:TextBox ID="TxtSupplierName" runat="server" Width="250px"></asp:TextBox>
                             </td>
                         </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                </td>
            <td width="20%">  <asp:HiddenField ID="hidAutoIdHeader" runat="server" />
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
        <tr>
            <td width="25%">
                </td>
            <td width="15%">
                  <asp:ImageButton ID="ImgBtnAddMore" ImageUrl="~/Images/btnAddLinegreen.gif" 
                      runat="server" Text="Save" onclick="ImgBtnAddMore_Click" />
            </td>
            <td width="20%">
                </td>
            <td width="15%">
                </td>
            <td width="15%">
                </td>
            <td width="10%">
                </td>
        </tr>
    </table> 
                    </ContentTemplate>
            </asp:UpdatePanel>
                    
                
            </ContentTemplate>
            </asp:TabPanel>
       </asp:TabContainer>
    <%--  <asp:Panel ID="PanelShowPopUpGrid" runat="server" Height="400px" Width="650px" CssClass="modalPopup"
        Style="display: none">
        <asp:Panel ID="Panel2" runat="server" Style="cursor: pointer">
            <table width="100%">
                <tr>
                    <td>
                        <div style="margin: 10px 0px 10px 20px">
                            <img src="../Images/Polyplex Logo.png" height="40px" width="160px" alt="Polyplex"
                                style="border: 1px solid black" /></div>
                    </td>
                    <td valign="top">
                        <div style="float: right; padding: 10px 10px 0 0">
                            <asp:ImageButton ID="ImgBtnCancelPopUp" runat="server" AlternateText="Cancel" ImageUrl="~/Images/delete.gif" /></div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="margin-left: 20px; margin-right: 20px">
            <table width="100%" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>
                        <div class="in_menu_head">
                            <asp:Label ID="lPopUpHeader" runat="server" Text="PopUp"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="0px" cellspacing="0px">
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label runat="server" Text="Search:" ID="lSearch"></asp:Label>
                                </td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtSearchFromPopup" runat="server" TabIndex="27" Width="80%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearchInPopUp" runat="server" TabIndex="10" Text="Submit" CausesValidation="false"
                                        OnClick="btnSearchInPopUp_Click" />
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
        </div>
    </asp:Panel>
  <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label9"
        PopupControlID="PanelShowPopUpGrid" BackgroundCssClass="modalBackground" DropShadow="true"
        PopupDragHandleControlID="Panel2" CancelControlID="ImgBtnCancelPopUp" />
  <asp:Label ID="Label9" runat="server" Text=""></asp:Label>--%>
</asp:Content>

