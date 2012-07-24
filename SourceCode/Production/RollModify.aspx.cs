using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Production_RollModify : System.Web.UI.Page
{
    Common com = new Common();
    string logmessage = "";
    Common_Message objcommonmessage = new Common_Message();
    Prod_RollSlitting objprodrollslitting = new Prod_RollSlitting();
    BLLCollection<Prod_RollSlitting> colrollslitting = new BLLCollection<Prod_RollSlitting>();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
            TxtBatchNo.Attributes.Add("readonly", "true");
            txtDate.Attributes.Add("readonly", "true");
            txtOrder.Attributes.Add("readonly", "true");
            TxtOrderLineItem.Attributes.Add("readonly", "true");
            if (!IsPostBack)
            {
                Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
                lbl_PageHeader.Text = "Roll Modify";
                DataTable dt = com.fillSearch("200");
                if (dt.Rows.Count > 0)
                {
                    ddl.Items.Add(new ListItem("--Select--", ""));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                    }
                }
                BindMachineName();
                BindShiftName();
                BindSubType();
                BindSetNo();
                BindGrade();
                txtDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
            }
            ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
            btn_search.CausesValidation = false;
            btn_search.Click += new ImageClickEventHandler(btn_search_Click);
            ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
            btn_add.Click += new ImageClickEventHandler(btn_add_Click);
            btn_add.CausesValidation = false;
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- Page Load event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        try
        {

            if (ddsearch.SelectedValue == "")
            {
                string message = "Please select any search criteria.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            }
            else
            {
                BindBatchList(txtSearch.Text);
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- btn_search_Click -Error-" + ex.ToString();
           Log.GetLog().LogInformation(logmessage);
        }

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            Clearheader();
            ClearDetails();
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void Clearheader()
    {
        ddlMachine.SelectedValue = "0";
        DdlShift.SelectedValue = "0";
        DdlSetNo.SelectedValue = "0";
        TxtBatchNo.Text = "";
        DdlType.SelectedValue = "0";
        txtMicron.Text = "";
        txtLength.Text = "";
        txtWidth.Text = "";
        txtQty.Text = "";
    }
    private void ClearDetails()
    {
        txtMicron2.Text = "";
        txtType2.Text = "";
        txtCore2.Text="";
        txtWidth2.Text = "";
        txtActLength.Text = "";
        txtActMic.Text = "";
        txtActQty.Text = "";
        txtQty.Text = "";
        txtPCakeNos.Text = "";
        txtOrder.Text = "";
        TxtOrderLineItem.Text = "";
        txtJoint1.Text = "";
        txtJoint2.Text = "";
        txtJoint3.Text = "";
        txtNoOfJoint.Text = "";
        txtODAvg.Text = "";
        txtODMin.Text = "";
        txtODMax.Text = "";
        TxtRollDetailsLength.Text = "";
        DdlGrade.SelectedValue = "0";
        txtRollCode.Text = "";
        txtRemarks.Text = "";
    }
    private void BindMachineName()
    {
        try
        {
            DataTable dtmachine = com.executeProcedure("Sp_Prod_GetAllMachines");
            ddlMachine.DataSource = dtmachine;
            ddlMachine.DataTextField = "MachineName";
            ddlMachine.DataValueField = "autoid";
            ddlMachine.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            ddlMachine.Items.Add(item);
            ddlMachine.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Roll Slitting Form- BindMachineName -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }


    }
    private void BindSetNo()
    {
        try
        {
            DataTable dtset = com.executeProcedure("Sp_Prod_GetAllSetNo");
            DdlSetNo.DataSource = dtset;
            DdlSetNo.DataTextField = "SetNo";
            DdlSetNo.DataValueField = "autoid";
            DdlSetNo.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlSetNo.Items.Add(item);
            DdlSetNo.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Roll Slitting Form- BindSetNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindShiftName()
    {
        try
        {
            DataTable dtshift = com.executeProcedure("Sp_Get_Prod_Shift_Mst");
            DdlShift.DataSource = dtshift;
            DdlShift.DataTextField = "ShiftCode";
            DdlShift.DataValueField = "autoid";
            DdlShift.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlShift.Items.Add(item);
            DdlShift.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Roll Slitting Form- BindShiftName -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindSubType()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = com.executeProcedure("Sp_Get_SubFilmType_Mst");
            DdlType.DataSource = dt;
            DdlType.DataTextField = "SubFilmTypeName";
            DdlType.DataValueField = "SubFilmTypeId";
            DdlType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlType.Items.Add(item);
            DdlType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Roll Slitting-BindSubType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindGrade()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = com.executeProcedure("Sp_Get_Prod_Grade_Mst");
            DdlGrade.DataSource = dt;
            DdlGrade.DataTextField = "GradeCode";
            DdlGrade.DataValueField = "autoid";
            DdlGrade.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlGrade.Items.Add(item);
            DdlGrade.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Roll Slitting Form-BindGrade-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnCode_Click(object sender, ImageClickEventArgs e)
    {
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        try
        {
            GdvBatchNo.Visible = true;
            BindBatchList(txtSearch.Text.Trim());
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- ImgBtnCode_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindBatchList(string search)
    {
        try
        {
            //string BatchNo = TxtBatchNo.Text;
            DataTable dt = objprodrollslitting.GetAllBatchNo(search);
            GdvBatchNo.DataSource = dt;
            GdvBatchNo.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvBatchNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string DataKey = GdvBatchNo.SelectedDataKey.Value.ToString();
            TxtBatchNo.Text = DataKey;
            if (DataKey != "")
            {
                //get header details by batchno
                DataTable dt = com.GetVal("@batchno", DataKey, "Sp_Prod_GetRollSlittingHeader_By_BatchNo");
                if (dt.Rows.Count > 0)
                {
                    ddlMachine.SelectedValue = dt.Rows[0][1].ToString();
                    DdlShift.SelectedValue = dt.Rows[0][3].ToString();
                    DdlSetNo.SelectedValue = dt.Rows[0][4].ToString();
                    DdlType.SelectedValue = dt.Rows[0][5].ToString();
                    txtMicron.Text = dt.Rows[0][6].ToString();
                    txtWidth.Text = dt.Rows[0][7].ToString();
                    txtLength.Text = dt.Rows[0][8].ToString();
                    txtQty.Text = dt.Rows[0][9].ToString();
                    DisableHeader();

                    DataTable dtdetails = com.GetVal("@batchno", DataKey, "Sp_Prod_GetRollSlittingDetails_By_BatchNo");
                    if (dtdetails.Rows.Count > 0)
                    {
                        txtMicron2.Text = dtdetails.Rows[0]["Micron"].ToString();
                        txtType2.Text = dtdetails.Rows[0]["Type"].ToString();
                        txtCore2.Text = dtdetails.Rows[0]["Core"].ToString();
                        txtWidth2.Text = dtdetails.Rows[0]["Width"].ToString();
                        txtActLength.Text = dtdetails.Rows[0]["Actual_Length"].ToString();
                        txtActMic.Text = dtdetails.Rows[0]["Actual_Micron"].ToString();
                        txtPCakeNos.Text = dtdetails.Rows[0]["PCakesNos"].ToString();
                        txtQty2.Text = dtdetails.Rows[0]["QtyInKg"].ToString();
                        txtActQty.Text = dtdetails.Rows[0]["ActualQtyInKg"].ToString();
                        txtOrder.Text = dtdetails.Rows[0]["SalesOrdNo"].ToString();
                        TxtOrderLineItem.Text = dtdetails.Rows[0]["SalesOrdLineItemNo"].ToString();
                        txtNoOfJoint.Text = dtdetails.Rows[0]["NoOfJoints"].ToString();
                        txtJoint1.Text = dtdetails.Rows[0]["Joint1"].ToString();
                        txtJoint2.Text = dtdetails.Rows[0]["Joint2"].ToString();
                        txtJoint3.Text = dtdetails.Rows[0]["Joint3"].ToString();
                        txtODMin.Text = dtdetails.Rows[0]["ODMin"].ToString();
                        txtODAvg.Text = dtdetails.Rows[0]["ODAvg"].ToString();
                        txtODMax.Text = dtdetails.Rows[0]["ODMax"].ToString();
                        // TxtRollDetailsLength.Text = dtdetails.Rows[0]["RollCode"].ToString();;
                        DdlGrade.SelectedValue = dtdetails.Rows[0]["Grade"].ToString();
                        txtRollCode.Text = dtdetails.Rows[0]["RollCode"].ToString();
                        txtRemarks.Text = dtdetails.Rows[0]["Remarks"].ToString();
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.NoRecordFound, 125, 300);
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- GdvBatchNo_SelectedIndexChanged -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void DisableHeader()
    {
        ddlMachine.Enabled = false;
        DdlShift.Enabled = false;
        DdlSetNo.Enabled = false;
        DdlType.Enabled = false;
        txtMicron.Enabled = false;
        txtWidth.Enabled = false;
        txtLength.Enabled = false;
        txtLength.Enabled = false;
    }
    protected void GdvBatchNo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvBatchNo.PageIndex = e.NewPageIndex;
            BindBatchList("");
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- GdvBatchNo_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void imgOrderNo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            GdvBatchNo.Visible = true;
            BindBatchList(TxtBatchNo.Text);
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- ImgBtnCode_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (TxtBatchNo.Text == "")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please select BatchNo", 125, 300);
                return;
            }
            else
            {
                if (objprodrollslitting.UpdateRecords(TxtBatchNo.Text.Trim(), txtMicron2.Text, txtType2.Text.Trim(), txtCore2.Text.Trim(), txtWidth2.Text.Trim(), txtLength.Text.Trim(), txtActLength.Text.Trim(),
                                                   txtActMic.Text.Trim(), txtPCakeNos.Text.Trim(), txtQty2.Text.Trim(), txtActQty.Text.Trim()
                                                   , txtOrder.Text, TxtOrderLineItem.Text.Trim(), txtNoOfJoint.Text.Trim(),
                                                   txtJoint1.Text.Trim(), txtJoint2.Text.Trim(), txtJoint3.Text.Trim(), txtODMin.Text.Trim(),
                                                   txtODAvg.Text.Trim(), txtODMax.Text.Trim(), DdlGrade.SelectedValue, txtRollCode.Text.Trim(), txtRemarks.Text.Trim(), ""
                                                   , Session["userid"].ToString()))
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.UpdatedRecord, 125, 300);
                    return;
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotUpdated, 125, 300);
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            logmessage = "Roll Modify Form- GdvBatchNo_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    
}