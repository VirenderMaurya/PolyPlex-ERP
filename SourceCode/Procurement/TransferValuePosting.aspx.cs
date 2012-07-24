////////////////////////////////////Code developed and designed by lalit on 27 June 2012///////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_TransferValuePosting : System.Web.UI.Page
{
    #region Defind Global here
    string logmessage = "";
    Common_Message commessage = new Common_Message();
    Common com = new Common();
    Proc_TransferValuePosting objtransfervalueposting = new Proc_TransferValuePosting();
    #endregion

    #region PageLoad event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ReadOnlyControls();
            BindSearchDropDown("70");
            BindTempTable();
            BindUOM();
            BindValuation();
            BindPlant();
            BindType();
            Log.GetLog().FillFinancialYear(TxtYear);
            Log.PageHeading(this, "Transer Value Posting Form");
        }
        BindMasterSearchBox();
       
    }
    #endregion
   
    #region Button click event
    private void BindSearchDropDown(string formid)
    {
        try
        {
            DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
            DataTable dt = com.fillSearch(formid);
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- BindSearchDropDown Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void ReadOnlyControls()
    {
        TxtYear.Attributes.Add("readonly", "true");
        TxtTransferNo.Attributes.Add("readonly", "true");
        TxtTransferDate.Attributes.Add("readonly", "true");
        TxtStorageLocation.Attributes.Add("readonly", "true");
        TxtMaterialCode.Attributes.Add("readonly", "true");
        TxtBatch.Attributes.Add("readonly", "true");
        TxtRequestedBy.Attributes.Add("readonly", "true");
        TxtApprovedBy.Attributes.Add("readonly", "true");
        //TxtBatch2.Attributes.Add("readonly", "true");
    }
    private void BindMasterSearchBox()
    {
        try
        {
            ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
            btn_add.Click += new ImageClickEventHandler(btn_add_Click);
            btn_add.CausesValidation = false;
            ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
            btn_search.CausesValidation = false;
            btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        }
        catch (Exception ex)
        {
            logmessage = "Transer Value Posting Form- BindMasterSearchBox Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        bindsearch();
    }
    private void bindsearch()
    {
        try
        {
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddsearch.SelectedValue == "")
            {
                string message = "Please select any search criteria.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            }
            else
            {
                DataTable dt = null;
                if (ddsearch.SelectedItem.Value == "RequestedBy")
                {
                    lSearchList.Text = "Search By Requested By";
                    dt = objtransfervalueposting.SearchTransferValuePosting("RequestedBy", txtSearch.Text);
                }
                if (ddsearch.SelectedItem.Value == "ApprovedBy")
                {
                    lSearchList.Text = "Search By Approved By";
                    dt = objtransfervalueposting.SearchTransferValuePosting("RequestedBy", txtSearch.Text);
                }
                if (ddsearch.SelectedItem.Value == "TransferNo")
                {
                    lSearchList.Text = "Search By Transfer No";
                    dt = objtransfervalueposting.SearchTransferValuePosting("RequestedBy", txtSearch.Text);
                }
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- btn_search_Click Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ClearField();
            hidAutoIdHeader.Value = "";
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnAddLine_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = null;
            int LineNo;
            if (ViewState["LnNo"] != null)
            {
                LineNo = Convert.ToInt32(ViewState["LnNo"]);
            }
            else
            {
                LineNo = 10;
            }
            if (ViewState["Details"] != null)
            {
                dt = (DataTable)ViewState["Details"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("LineNo", typeof(string));
                dt.Columns.Add("MaterialCode", typeof(string));
                dt.Columns.Add("UOM", typeof(string));
                dt.Columns.Add("UOMText", typeof(string));
                dt.Columns.Add("ValuationType", typeof(string));
                dt.Columns.Add("ValuationTypeText", typeof(string));
                dt.Columns.Add("Plant", typeof(string));
                dt.Columns.Add("PlantText", typeof(string));
                dt.Columns.Add("Storage", typeof(string));
                dt.Columns.Add("BatchNo", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));
                dt.Columns.Add("Value", typeof(string));
            }
            DataRow drow = dt.NewRow();
            if (ViewState["Details"] != null)
            {
                drow["LineNo"] = 10 + LineNo;
            }
            else
            {
                drow["LineNo"] = LineNo;
            }
            drow["MaterialCode"] = TxtMaterialCode.Text.Trim();
            drow["BatchNo"] = TxtBatch.Text.Trim();
            drow["UOM"] = DdlUOM.SelectedValue;
            drow["UOMText"] = DdlUOM.SelectedItem.Text;
            drow["Plant"] = DdlPlant.SelectedValue;
            drow["PlantText"] = DdlPlant.SelectedItem.Text;
            drow["Storage"] = TxtStorageLocation.Text;
            drow["ValuationType"] = DdlValuationType.SelectedValue;
            drow["ValuationTypeText"] = DdlValuationType.SelectedItem.Text;
            drow["Quantity"] = TxtQuantity.Text.Trim();
            drow["Value"] = TxtValue.Text.Trim();
            dt.Rows.Add(drow);
            ViewState["Details"] = dt;
            ViewState["LnNo"] = drow["LineNo"];
            Gdvtransfer.DataSource = dt;
            Gdvtransfer.DataBind();
            Gdvtransfer.Columns[13].Visible = true;
            cleardetails();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- btnAddLine_Click Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Update record
            if (btnSave.ImageUrl == "~/Images/btn_update.png")
            {
                #region update line item
                if (ViewState["lineno"] != null)
                {
                    if (objtransfervalueposting.updatelineitem(TxtTransferNo.Text, ViewState["lineno"].ToString(), TxtMaterialCode.Text, DdlUOM.SelectedValue, DdlValuationType.SelectedValue, TxtBatch.Text, TxtQuantity.Text, TxtValue.Text, TxtTransferDate.Text, DdlType.SelectedValue, TxtStorageLocation.Text, DdlPlant.SelectedValue, TxtRequestedBy.Text, TxtApprovedBy.Text, Session["userId"].ToString(), TxtYear.Text))
                    {
                        ViewState["lineno"] = null;
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.UpdatedRecord, 125, 300);
                        return;
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordNotUpdated, 125, 300);
                        return;
                    }
                }
                else
                {
                    #region update headeritem only
                    if (objtransfervalueposting.updateheader(TxtTransferNo.Text, TxtTransferDate.Text, DdlType.SelectedValue, TxtRequestedBy.Text, TxtApprovedBy.Text, Session["userId"].ToString(), TxtYear.Text))
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.UpdatedRecord, 125, 300);
                        return;
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
            #region Insert record
            else
            {
                DataTable dtdetails = new DataTable();
                string createdby = Session["userId"].ToString();
                if (ViewState["Details"] != null)
                {
                    dtdetails = (DataTable)ViewState["Details"];
                    dtdetails.Columns.Remove("UOMText");
                    dtdetails.Columns.Remove("ValuationTypeText");
                    dtdetails.Columns.Remove("PlantText");
                }
                if (dtdetails.Rows.Count > 0)
                {
                    bool saved = false;
                    saved = objtransfervalueposting.saveRecords(dtdetails, TxtTransferDate.Text, TxtYear.Text, DdlType.SelectedValue, TxtRequestedBy.Text, TxtApprovedBy.Text, createdby);
                    if (saved)
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordSaved, 125, 300);
                        ClearField();
                        ViewState["Details"] = null;
                        ViewState["LnNo"] = null;
                        return;
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, commessage.RecordNotSaved, 125, 300);
                        return;
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, commessage.SelectLineItem, 125, 300);
                    return;
                }
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- btnSave_Click Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Bind function
    protected void BindValuation()
    {
        try
        {
            DataTable dt = com.executeProcedure("SP_Prod_GetValuation_mst");
            DdlValuationType.DataSource = dt;
            DdlValuationType.DataTextField = "ValuationType";
            DdlValuationType.DataValueField = "AutoId";
            DdlValuationType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlValuationType.Items.Add(item);
            DdlValuationType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form-BindValuation-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindType()
    {
        try
        {
            DataTable dt = com.executeProcedure("Sp_Proc_GetStockType");
            DdlType.DataSource = dt;
            DdlType.DataTextField = "StockTypeDesc";
            DdlType.DataValueField = "AutoId";
            DdlType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlType.Items.Add(item);
            DdlType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- BindType -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindPlant()
    {
        try
        {
            DataTable dt = com.executeProcedure("Sp_Get_Proc_Plant_Mst");
            DdlPlant.DataSource = dt;
            DdlPlant.DataTextField = "PlantCode";
            DdlPlant.DataValueField = "autoid";
            DdlPlant.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlPlant.Items.Add(item);
            DdlPlant.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- BindPlant -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindEmployee(string searchwhat)
    {
        try
        {
            DataTable dtemployee = new DataTable();
            dtemployee = com.GetVal("@search", searchwhat, "SP_Prod_GetEmployeemster_mst");
            Gdvlookup.DataSource = dtemployee;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- BindEmployee -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindMaterial(string searchwhat)
    {
        try
        {
            DataTable dtmaterial = new DataTable();
            dtmaterial = com.GetVal("@search", searchwhat, "SP_Prod_GetMaterial_mst");
            Gdvlookup.DataSource = dtmaterial;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- BindMaterial -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindBatchNo(string searchwhat)
    {
        try
        {
            DataTable dtbatchno = new DataTable();
            dtbatchno = com.GetVal("@search", searchwhat, "SP_Prod_GetBatch_mst");
            Gdvlookup.DataSource = dtbatchno;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- BindBatchNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindUOM()
    {
        try
        {
            DataTable dt = com.executeProcedure("SP_Prod_GetUOM_mst");
            DdlUOM.DataSource = dt;
            DdlUOM.DataTextField = "Description";
            DdlUOM.DataValueField = "AutoId";
            DdlUOM.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlUOM.Items.Add(item);
            DdlUOM.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form-BindingUOM-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindLocation(string searchwhat)
    {
        DataTable dtlocation = new DataTable();
        dtlocation = com.GetVal("@locationname", searchwhat, "SP_Prod_GetStorageLocation_mst");
        Gdvlookup.DataSource = dtlocation;
        Gdvlookup.DataBind();
    }
    #endregion

    #region BindTempTable
    private void BindTempTable()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LineNo", typeof(string));
            dt.Columns.Add("MaterialCode", typeof(string));
            dt.Columns.Add("Batch", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("Plant", typeof(string));
            dt.Columns.Add("ValuationType", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            Gdvtransfer.DataSource = dt;
            Gdvtransfer.DataBind();
            Gdvtransfer.Columns[13].Visible = false;
        }
        catch (Exception ex)
        {
            logmessage = "Transer value posting Form- Bind Temp Table in page load-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Grid Events

    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string id = gridMaster.SelectedDataKey.Value.ToString();
            #region clear controls
            cleardetails();
            ClearField();
            #endregion
            #region BindHeaderdetails
            DataTable dtheader = com.GetVal("@Id", id, "Sp_Proc_TransferValuePosting_GetHeaderDetails");
            if (dtheader != null)
            {
                if (dtheader.Rows.Count > 0)
                {
                    TxtTransferDate.Text = dtheader.Rows[0]["TransferDate"].ToString();
                    TxtTransferNo.Text = dtheader.Rows[0]["TransferNumber"].ToString();
                    TxtYear.Text = dtheader.Rows[0]["Year"].ToString();
                    TxtRequestedBy.Text = dtheader.Rows[0]["RequestedBy"].ToString();
                    TxtApprovedBy.Text = dtheader.Rows[0]["ApprovedBy"].ToString();
                    DdlType.SelectedValue = dtheader.Rows[0]["Type"].ToString();
                    hidAutoIdHeader.Value = "1";
                    #region BindDetails
                    DataTable dtdetails = com.GetVal("@Id", TxtTransferNo.Text, "Sp_Proc_TransferValuePosting_GetLineItemsDetails");
                    Gdvtransfer.DataSource = dtdetails;
                    Gdvtransfer.DataBind();
                    ViewState["transferno"] = TxtTransferNo.Text;
                    btnSave.ImageUrl = "~/Images/btn_update.png";
                    btnAddLine.ImageUrl = "~/Images/btnAddLineGrey.png";
                    btnAddLine.Enabled = false;
                    #endregion
                }
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- gridMaster_SelectedIndexChanged -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvlookup_RowCommand(object sender, GridViewCommandEventArgs e)
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
                if (HidPopUpType.Value == "storagelocation")
                {
                    string locationcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    string locationname = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    TxtStorageLocation.Text = locationcode;
                }
                if (HidPopUpType.Value == "requestedby")
                {
                    string empcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtRequestedBy.Text = empcode;
                }
                if (HidPopUpType.Value == "approvedby")
                {
                    string empcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtApprovedBy.Text = empcode;
                }
                if (HidPopUpType.Value == "materialcode")
                {
                    string materialcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtMaterialCode.Text = materialcode;
                }
                if (HidPopUpType.Value == "batchno")
                {
                    string batchcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtBatch.Text = batchcode;
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Transfer ValuePosting Form-Gdvlookup_RowCommand-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvtransfer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            #region Row Deleting in temp table
            if (e.CommandName == "del")
            {
                int lineno = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["Details"];
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
                    BindTempTable();
                    //GdvStorageLocationMovement.DataSource = null;
                    //GdvStorageLocationMovement.DataBind();
                }
                else
                {
                    Gdvtransfer.DataSource = dt;
                    Gdvtransfer.DataBind();
                }
            }
            #endregion
            #region Edit row after serach button clicked, bind data for update
            if (e.CommandName == "editrow")
            {
                string transferno = ViewState["transferno"].ToString();
                string lineno = e.CommandArgument.ToString();
                ViewState["lineno"] = lineno;
                DataTable dtlineitemdetails = objtransfervalueposting.TransferValuePosting_GetLineItems_ByLineId(transferno, lineno);
                if (dtlineitemdetails != null)
                {
                    if (dtlineitemdetails.Rows.Count > 0)
                    {
                        TxtMaterialCode.Text = dtlineitemdetails.Rows[0]["MaterialCode"].ToString();
                        DdlUOM.SelectedValue = dtlineitemdetails.Rows[0]["UOM"].ToString();
                        DdlValuationType.SelectedValue = dtlineitemdetails.Rows[0]["ValuationType"].ToString();
                        TxtBatch.Text = dtlineitemdetails.Rows[0]["BatchNo"].ToString();
                        TxtQuantity.Text = dtlineitemdetails.Rows[0]["Quantity"].ToString();
                        TxtValue.Text = dtlineitemdetails.Rows[0]["Value"].ToString();
                        DdlPlant.SelectedValue = dtlineitemdetails.Rows[0]["Plant"].ToString();
                        TxtStorageLocation.Text = dtlineitemdetails.Rows[0]["Storage"].ToString();
                        btnSave.ImageUrl = "~/Images/btn_update.png";
                        btnAddLine.ImageUrl = "~/Images/btnAddLineGrey.png";
                        btnAddLine.Enabled = false;
                    }
                }
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Transfer Value Posting Form- Gdvtransfer_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvtransfer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (hidAutoIdHeader.Value == "")
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[10].Visible = true;
            }
            else if (hidAutoIdHeader.Value != "")
            {
                e.Row.Cells[0].Visible = true;
                e.Row.Cells[10].Visible = false;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- Gdvtransfer_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvlookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (HidPopUpType.Value == "bankgl")
            //{

            //}
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- Gdvlookup_SelectedIndexChanged -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvlookup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Gdvlookup.PageIndex = e.NewPageIndex;
            if ( HidPopUpType.Value == "requestedby")
            {
                lSearchList.Text = "Search By Requested By";
                BindEmployee("");
            }
            if (HidPopUpType.Value == "approvedby")
            {
                lSearchList.Text = "Search By Approved By";
                BindEmployee("");
            }
            if (HidPopUpType.Value == "materialcode")
            {
                lSearchList.Text = "Search By Material Code";
                BindMaterial("");
            }
            if (HidPopUpType.Value == "storagelocation")
            {
                lSearchList.Text = "Search By Location Code";
                BindLocation("");
            }
            if (HidPopUpType.Value == "batchno")
            {
                lSearchList.Text = "Search By Batch No";
                BindBatchNo("");
            }
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- Gdvlookup_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gridMaster.PageIndex = e.NewPageIndex;
            bindsearch();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- gridMaster_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Clear events
    private void ClearField()
    {
        TxtApprovedBy.Text = "";
        TxtBatch.Text = "";
        // TxtBatch2.Text = "";
        TxtMaterialCode.Text = "";
        TxtQuantity.Text = "";
        TxtRequestedBy.Text = "";
        TxtStorageLocation.Text = "";
        TxtTransferDate.Text = "";
        TxtTransferNo.Text = "";
        DdlUOM.SelectedValue = "0";
        TxtValue.Text = "";
        DdlPlant.SelectedValue = "0";
        DdlType.SelectedValue = "0";
        DdlValuationType.SelectedValue = "0";
        ViewState["Details"] = null;
        Gdvtransfer.DataSource = null;
        Gdvtransfer.DataBind();
        BindTempTable();
        btnSave.ImageUrl = "~/Images/btnSave.png";
        btnSave.Enabled = true;
        btnAddLine.ImageUrl = "~/Images/btnAddLinegreen.png";
        btnAddLine.Enabled = true;
    }
    private void cleardetails()
    {
        DdlUOM.SelectedValue = "0";
        TxtMaterialCode.Text = "";
        DdlValuationType.SelectedValue = "0";
        DdlPlant.SelectedValue = "0";
        TxtBatch.Text = "";
        TxtStorageLocation.Text = "";
        TxtMaterialCode.Text = "";
        TxtQuantity.Text = "";
        TxtValue.Text = "";
    }
    #endregion

    #region Button Click events
    protected void ImgBtnRequestedBy_Click(object sender, ImageClickEventArgs e)
    {
       try
        {
            lSearchList.Text = "Search By Requested By";
            MakeDefaultMasterDrop();
            HidPopUpType.Value = "requestedby";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindEmployee("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- ImgBtnRequestedBy_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void MakeDefaultMasterDrop()
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        ddl.SelectedValue = "";
    }
    protected void ImgBtnApprovedBy_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search By Approved By";
            MakeDefaultMasterDrop();
            HidPopUpType.Value = "approvedby";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindEmployee("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- ImgBtnApprovedBy_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnMaterialCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search By Material Code";
            MakeDefaultMasterDrop();
            HidPopUpType.Value = "materialcode";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindMaterial("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- ImgBtnMaterialCode_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnBatchNo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search By Batch No";
            MakeDefaultMasterDrop();
            HidPopUpType.Value = "batchno";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindBatchNo("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- ImgBtnBatchNo_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            DataTable dt = null;
            string key = txtSearchList.Text.Trim();
            if (ddlSearch.SelectedValue.ToString() == "RequestedBy")
            {
                lSearchList.Text = "Search By Requested By";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objtransfervalueposting.SearchTransferValuePosting("RequestedBy", key);
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
            }
            if (ddlSearch.SelectedValue.ToString() == "ApprovedBy")
            {
                lSearchList.Text = "Search By Approved By";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objtransfervalueposting.SearchTransferValuePosting("ApprovedBy", key);
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
            }
            if (ddlSearch.SelectedValue.ToString() == "TransferNo")
            {
                lSearchList.Text = "Search By Transfer No";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objtransfervalueposting.SearchTransferValuePosting("TransferNo", key);
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
            }
            if (HidPopUpType.Value == "storagelocation")
            {
                lSearchList.Text = "Search By Storage Location Code";
                BindLocation(key);
            }
            if (HidPopUpType.Value == "requestedby")
            {
                lSearchList.Text = "Search By Requested By";
                BindEmployee(key);
            }
            if (HidPopUpType.Value == "approvedby")
            {
                lSearchList.Text = "Search By Approved By";
                BindEmployee(key);
            }
            if (HidPopUpType.Value == "materialcode")
            {
                lSearchList.Text = "Search By Material Code";
                BindMaterial(key);
            }
            if (HidPopUpType.Value == "batchno")
            {
                lSearchList.Text = "Search By Batch No";
                BindBatchNo(key);
            }
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- btnSearchlist_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgbtnStorageLocation_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search By Location Code";
            HidPopUpType.Value = "storagelocation";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindLocation("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Transfer value posting Form- ImgbtnStorageLocation_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

}