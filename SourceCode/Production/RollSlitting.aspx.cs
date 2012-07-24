using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Production_RollSlitting : System.Web.UI.Page
{
    Common com = new Common();
    string logmessage = "";
    Prod_ReservationRoll objProd_RollReservation = new Prod_ReservationRoll();
    Prod_RollSlitting objrollslitting = new Prod_RollSlitting();
    Common_Message objcommonmessage = new Common_Message();
    static string MasterPageType;

    protected void Page_Load(object sender, EventArgs e)
    {
        TxtOrderLineItem.Attributes.Add("readonly", "true");
        txtOrder.Attributes.Add("readonly", "true");
        if (!Page.IsPostBack)
        {
            Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lbl_PageHeader.Text = "Roll Slitting";
            BindMachineName();
            BindShiftName();
            BindSubType();
            BindSetNo();
            BindGrade();
            ArmCode();
            txtDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
        }
    }

    
    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[3].Style.Add("display", "none");
            e.Row.Cells[6].Style.Add("display", "none");
            e.Row.Cells[8].Style.Add("display", "none");
        }
        catch { }
    }

    protected void gvPopUpGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvPopUpGrid = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvPopUpGrid.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvPopUpGrid.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidSalesOrderId.Value = Convert.ToString(e.CommandArgument);
                txtOrder.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                txtDate.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                HidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                Btnsave.Enabled = true;               
                BindSOLineItemGrid(Convert.ToInt32(HidSalesOrderId.Value));
                ModalPopupExtender1.Show();
            }
        }
        catch { }
    }

    private void BindSOLineItemGrid(int SalesOrderId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_RollReservation.Get_SODeatilsBySOId(SalesOrderId);
            if (dt.Rows.Count > 0)
            {
                gvSOLineItems.DataSource = dt;
                gvSOLineItems.DataBind();
            }
            else
            {
                gvSOLineItems.DataSource = "";
                gvSOLineItems.DataBind();
            }
        }
        catch { }
    }
    protected void gvSOLineItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvSOLineItems = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvSOLineItems.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                TxtOrderLineItem.Text = gvSOLineItems.Rows[gvSOLineItems.SelectedIndex].Cells[1].Text;
            }
        }
        catch { }
    }
    protected void btnSearchInPopUp_Click1(object sender, EventArgs e)
    {
        string DDLValue = "";
        gvPopUpGrid.DataSource = null;
        gvPopUpGrid.AllowPaging = false;
        gvPopUpGrid.DataBind();

        if (MasterPageType == "Master")
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            DDLValue = ddlSearch.SelectedValue.ToString();
            Get_SalesOrderForStockLotreservation(DDLValue, txtSearchFromPopup.Text.Trim());
        }
        else if (MasterPageType == "Page")
        {
            Get_SalesOrderForStockLotreservation("OrderNo", txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
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
    protected void ArmCode()
    {
        try
        {  
            DataTable dt = new DataTable();
            dt = com.executeProcedure("Sp_Prod_GetMachineArm");
            DdlArmcode.DataSource = dt;
            DdlArmcode.DataTextField = "ArmCode";
            DdlArmcode.DataValueField = "autoid";
            DdlArmcode.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlArmcode.Items.Add(item);
            DdlArmcode.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Roll Slitting Form-DdlArmcode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnAddLine_Click(object sender, EventArgs e)
    {

    }
    protected void btnSaveLine_Click(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable dtRollsDetails=null,dtprimaryinput=null,dtsecondaryinput=null;
         if(ViewState["RollsDetails"]!=null)
         {
            dtRollsDetails = (DataTable)ViewState["RollsDetails"];
            dtRollsDetails.Columns.Add("ActiveStatus");
            for (int i = 0; i < dtRollsDetails.Rows.Count; i++)
            {
                dtRollsDetails.Rows[i]["ActiveStatus"] = "1";
            }
            dtRollsDetails.AcceptChanges();
         }
         if(ViewState["PrimaryInput"]!=null)
         {
           dtprimaryinput = (DataTable)ViewState["PrimaryInput"];
           dtprimaryinput.Columns.Remove("LineNo");
           dtprimaryinput.AcceptChanges();
           dtprimaryinput.Columns.Add("ActiveStatus");
           for (int i = 0; i < dtprimaryinput.Rows.Count; i++)
           {
               dtprimaryinput.Rows[i]["ActiveStatus"] = "1";
           }
           dtprimaryinput.AcceptChanges();
         }
          if(ViewState["SecondaryInput"]!=null)
          {
             dtsecondaryinput = (DataTable)ViewState["SecondaryInput"];
             dtsecondaryinput.Columns.Add("ActiveStatus");
             for (int i = 0; i < dtsecondaryinput.Rows.Count; i++)
             {
                 dtsecondaryinput.Rows[i]["ActiveStatus"] = "1";
             }
             dtsecondaryinput.AcceptChanges();
          }

          if (objrollslitting.saveRecords(dtRollsDetails, dtprimaryinput, dtsecondaryinput,ddlMachine.SelectedValue, txtDate.Text.Trim(), DdlShift.SelectedValue, DdlSetNo.SelectedValue, DdlType.SelectedValue, txtMicron.Text.Trim(), txtWidth.Text.Trim(), txtLength.Text.Trim(), txtQty.Text.Trim(), Session["userid"].ToString()))
          {
              ViewState["RollsDetails"]=null;
              ViewState["PrimaryInput"]=null;
              ViewState["SecondaryInput"] = null;
              cleardetails();
              MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
              return;
          }
          else
          {
              MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
              return;
          }
    }
    protected void cleardetails()
    {
        txtActLength.Text = "";
        txtActMic.Text = "";
        txtActQty.Text = "";
        txtCore2.Text = "";
        txtDate.Text = "";
        txtInputBalanceQty.Text = "";
        txtJoint1.Text = "";
        txtJoint2.Text = "";
        txtJoint3.Text = "";
        txtLength.Text = "";
        txtMicron.Text = "";
        txtMicron2.Text = "";
        txtNoOfJoint.Text = "";
        txtODAvg.Text = "";
        txtODMax.Text = "";
        txtODMin.Text = "";
        txtOrder.Text = "";
        TxtOrderLineItem.Text = "";
        txtPCakeNos.Text = "";
        txtPIJumboActualLength.Text = "";
        txtPIJumboActualWeight.Text = "";
        txtPIJumboAvailableLength.Text = "";
        txtPIJumboAvailableWeight.Text = "";
        txtPIJumboFeedLength.Text = "";
        txtPIJumboFeedWeight.Text = "";
        txtPIJumboNo.Text = "";
        txtQty.Text = "";
        txtQty2.Text = "";
        txtRemarks.Text = "";
        txtRollCode.Text = "";
        TxtRollDetailsLength.Text = "";
        txtSearchFromPopup.Text = "";
        txtSIJumboActualLength.Text = "";
        txtSIJumboActualWeight.Text = "";
        txtSIJumboAvailableLength.Text = "";
        txtSIJumboAvailableWeight.Text = "";
        txtSIJumboFeedLength.Text = "";
        txtSIJumboFeedWeight.Text = "";
        txtSIJumboNo.Text = "";
        txtType2.Text = "";
        txtUsedTotalQty.Text = "";
        txtWidth.Text = "";
        txtWidth2.Text="";
        gvPrimaryInput.DataSource = null;
        gvPrimaryInput.DataBind();
        gvRollDetails.DataSource = null;
        gvRollDetails.DataBind();
        gvSecondaryInput.DataSource = null;
        gvSecondaryInput.DataBind();        
            
       }
    
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnExit_Click(object sender, EventArgs e)
    {

    }
    protected void btnSIAdd_Click(object sender, EventArgs e)
    {

    }
    protected void btnSIOver_Click(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
    protected void btnOver_Click(object sender, EventArgs e)
    {

    }
    protected void gvRollDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Row Deleting in temp table
        if (e.CommandName == "del")
        {
            int lineno = Convert.ToInt32(e.CommandArgument);
            DataTable dt = (DataTable)ViewState["RollsDetails"];
            int i = 0;
            while (i < dt.Rows.Count)
            {
                if (Convert.ToInt32(dt.Rows[i]["LineNo"]) == lineno)
                {
                    dt.Rows[i].Delete();
                }
                i++;
            }
            if (dt.Rows.Count == 0)
            {
                gvRollDetails.DataSource = null;
                gvRollDetails.DataBind();
            }
            else
            {
                gvRollDetails.DataSource = dt;
                gvRollDetails.DataBind();
            }
        }
        #endregion
    }
    protected void gvRollDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvPrimaryInput_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Row Deleting in temp table
        if (e.CommandName == "del")
        {
            int lineno = Convert.ToInt32(e.CommandArgument);
            DataTable dt = (DataTable)ViewState["PrimaryInput"];
            int i = 0;
            while (i < dt.Rows.Count)
            {
                if (Convert.ToInt32(dt.Rows[i]["LineNo"]) == lineno)
                {
                    dt.Rows[i].Delete();
                }
                i++;
            }
            if (dt.Rows.Count == 0)
            {
                gvPrimaryInput.DataSource = null;
                gvPrimaryInput.DataBind();
            }
            else
            {
                gvPrimaryInput.DataSource = dt;
                gvPrimaryInput.DataBind();
            }
        }
        #endregion
    }
    protected void gvPrimaryInput_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvSecondaryInput_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Row Deleting in temp table
        if (e.CommandName == "del")
        {
            int lineno = Convert.ToInt32(e.CommandArgument);
            DataTable dt = (DataTable)ViewState["SecondaryInput"];
            int i = 0;
            while (i < dt.Rows.Count)
            {
                if (Convert.ToInt32(dt.Rows[i]["LineNo"]) == lineno)
                {
                    dt.Rows[i].Delete();
                }
                i++;
            }
            if (dt.Rows.Count == 0)
            {
                gvSecondaryInput.DataSource = null;
                gvSecondaryInput.DataBind();
            }
            else
            {
                gvSecondaryInput.DataSource = dt;
                gvSecondaryInput.DataBind();
            }
        }
        #endregion
    }
    protected void gvSecondaryInput_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
<<<<<<< .mine
    
=======

    protected void BtnRollDetails_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = null;
        int LineNo = 0;
        if (ViewState["DetailsLineNo"] != null)
        {
            LineNo = Convert.ToInt32(ViewState["DetailsLineNo"]) + 10;
        }
        else
        {
            LineNo = 10;
        }
        if (ViewState["RollsDetails"] != null)
        {
            dt = (DataTable)ViewState["RollsDetails"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("LineNo", typeof(int));
            dt.Columns.Add("Micron", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Core", typeof(string));
            dt.Columns.Add("Width", typeof(string));
            dt.Columns.Add("Length", typeof(string));
            dt.Columns.Add("Actual_Length", typeof(string));
            dt.Columns.Add("Actual_Micron", typeof(string));
            dt.Columns.Add("PCakesNos", typeof(string));
            dt.Columns.Add("QtyInKg", typeof(string));
            dt.Columns.Add("ActualQtyInKg", typeof(string));
            dt.Columns.Add("SalesOrdNo", typeof(string));
            dt.Columns.Add("SalesOrdLineItemNo", typeof(string));
            dt.Columns.Add("NoOfJoints", typeof(string));
            dt.Columns.Add("Joint1", typeof(string));
            dt.Columns.Add("Joint2", typeof(string));
            dt.Columns.Add("Joint3", typeof(string));
            dt.Columns.Add("ODMin", typeof(string));
            dt.Columns.Add("ODAvg", typeof(string));
            dt.Columns.Add("ODMax", typeof(string));
            dt.Columns.Add("Grade", typeof(string));
            dt.Columns.Add("RollCode", typeof(string));
            dt.Columns.Add("Remarks", typeof(string));
            dt.Columns.Add("MachineArmCode", typeof(string));
        }
        DataRow drow = dt.NewRow();
        if (ViewState["DetailsLineNo"] != null)
        {
            drow["LineNo"] = LineNo;
        }
        else
        {
            drow["LineNo"] = LineNo;  //need to ask 
        }
        drow["Micron"] = txtMicron2.Text;
        drow["Type"] = txtType2.Text;
        drow["Core"] = txtCore2.Text;
        drow["Width"] = txtWidth2.Text;
        drow["Length"] = TxtRollDetailsLength.Text;
        drow["Actual_Length"] = txtActLength.Text;
        drow["Actual_Micron"] = txtActMic.Text;
        drow["PCakesNos"] = txtPCakeNos.Text;
        drow["QtyInKg"] = txtQty2.Text;
        drow["ActualQtyInKg"] = txtActQty.Text;
        drow["SalesOrdNo"] = txtOrder.Text;
        drow["SalesOrdLineItemNo"] = TxtOrderLineItem.Text;
        drow["NoOfJoints"] = txtNoOfJoint.Text;
        drow["Joint1"] = txtJoint1.Text;
        drow["Joint2"] = txtJoint2.Text;
        drow["Joint3"] = txtJoint3.Text;
        drow["ODMin"] = txtODMin.Text;
        drow["ODAvg"] = txtODAvg.Text;
        drow["ODMax"] = txtODMax.Text;
        drow["Grade"] = DdlGrade.SelectedValue;
        drow["RollCode"] = txtRollCode.Text;
        drow["Remarks"] = txtRemarks.Text;
        drow["MachineArmCode"] = DdlArmcode.SelectedValue;
        
        dt.Rows.Add(drow);
        ViewState["RollsDetails"] = dt;
        ViewState["DetailsLineNo"] = drow["LineNo"];
        gvRollDetails.DataSource = dt;
        gvRollDetails.DataBind();
    }
    protected void Btnsave_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void BtnAddPrimary_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = null;
        int LineNo = 0;
        if (ViewState["PrimaryLineNo"] != null)
        {
            LineNo = Convert.ToInt32(ViewState["PrimaryLineNo"]) + 10;
        }
        else
        {
            LineNo = 10;
        }
        if (ViewState["PrimaryInput"] != null)
        {
            dt = (DataTable)ViewState["PrimaryInput"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("LineNo", typeof(string));
            dt.Columns.Add("JumboNo", typeof(string));
            dt.Columns.Add("ActualWeight", typeof(string));
            dt.Columns.Add("ActualLength", typeof(string));
            dt.Columns.Add("AvailableWeight", typeof(string));
            dt.Columns.Add("AvailableLength", typeof(string));
            dt.Columns.Add("FeedLength", typeof(string));
            dt.Columns.Add("FeedWeight", typeof(string));
          
        }
        DataRow drow = dt.NewRow();
        if (ViewState["PrimaryLineNo"] != null)
        {
            drow["LineNo"] = LineNo;
        }
        else
        {
            drow["LineNo"] = LineNo;  //need to ask 
        }
        drow["JumboNo"] = txtPIJumboNo.Text;
        drow["ActualWeight"] = txtPIJumboActualWeight.Text;
        drow["ActualLength"] = txtPIJumboActualLength.Text;
        drow["AvailableWeight"] =txtPIJumboAvailableWeight.Text;
        drow["AvailableLength"] = txtPIJumboAvailableLength.Text;
        drow["FeedWeight"] = txtPIJumboFeedWeight.Text;
        drow["FeedLength"] = txtPIJumboFeedLength.Text;
        dt.Rows.Add(drow);
        ViewState["PrimaryInput"] = dt;
        ViewState["PrimaryLineNo"] = drow["LineNo"];
        gvPrimaryInput.DataSource = dt;
        gvPrimaryInput.DataBind();
    }
    protected void imgOrderNo_Click(object sender, ImageClickEventArgs e)
    {
        MasterPageType = "Page";
        lSearch.Text = "Search By Sales Order: ";
        Get_SalesOrderForStockLotreservation("OrderNo", "");
        ModalPopupExtender2.Show();
    }
    private void Get_SalesOrderForStockLotreservation(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_RollReservation.Get_SalesOrderForRollreservation(ddlSearchValue, txtSearchValue);

            if (dt.Rows.Count > 0)
            {
                lblTotalRecordsPopUp.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
                gvPopUpGrid.AllowPaging = true;
                gvPopUpGrid.DataSource = dt;
                gvPopUpGrid.DataBind();
            }
            else
            {
                lblTotalRecordsPopUp.Text = objcommonmessage.NoRecordFound;
                gvPopUpGrid.AllowPaging = false;
                gvPopUpGrid.DataSource = "";
                gvPopUpGrid.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void BtnAddSecondary_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = null;
        int LineNo = 0;
        if (ViewState["SecondaryLineNo"] != null)
        {
            LineNo = Convert.ToInt32(ViewState["SecondaryLineNo"]) + 10;
        }
        else
        {
            LineNo = 10;
        }
        if (ViewState["SecondaryInput"] != null)
        {
            dt = (DataTable)ViewState["SecondaryInput"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("LineNo", typeof(string));
            dt.Columns.Add("JumboNo", typeof(string));
            dt.Columns.Add("ActualWeight", typeof(string));
            dt.Columns.Add("ActualLength", typeof(string));
            dt.Columns.Add("AvailableWeight", typeof(string));
            dt.Columns.Add("AvailableLength", typeof(string));
            dt.Columns.Add("FeedWeight", typeof(string));
            dt.Columns.Add("FeedLength", typeof(string));
        }
        DataRow drow = dt.NewRow();
        if (ViewState["SecondaryLineNo"] != null)
        {
            drow["LineNo"] = LineNo;
        }
        else
        {
            drow["LineNo"] = LineNo;  //need to ask 
        }
        drow["JumboNo"] = txtSIJumboNo.Text;
        drow["ActualWeight"] = txtSIJumboActualWeight.Text;
        drow["ActualLength"] = txtSIJumboActualLength.Text;
        drow["AvailableWeight"] = txtSIJumboAvailableWeight.Text;
        drow["AvailableLength"] = txtSIJumboAvailableLength.Text;
        drow["FeedWeight"] = txtSIJumboFeedWeight.Text;
        drow["FeedLength"] = txtSIJumboFeedLength.Text;
        dt.Rows.Add(drow);
        ViewState["SecondaryInput"] = dt;
        ViewState["SecondaryLineNo"] = drow["LineNo"];
        gvSecondaryInput.DataSource = dt;
        gvSecondaryInput.DataBind();
    }
>>>>>>> .r889
}