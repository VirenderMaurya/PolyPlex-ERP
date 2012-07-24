////////////////////////////////////Code developed and designed by lalit on 29 June 2012///////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_NonReturnableGatePass : System.Web.UI.Page
{

    #region Define Global variable here
    string logmessage = "";
    Common_Message commessage = new Common_Message();
    Common com = new Common();
    BLLCollection<FA_VendorMaster> colvendorlist = new BLLCollection<FA_VendorMaster>();
    FA_VendorMaster objvendor = new FA_VendorMaster();
    Proc_NonReturnableGatePass objnonreturnablegatepass = new Proc_NonReturnableGatePass();
    #endregion

    #region PageLoad Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                BindSearchDropDown("105");
                BindNRGP();
                BindValuation();
                BindTempTable();
                BindPlant();
                Log.GetLog().FillFinancialYear(TxtYear);
                Readonlycontrols();
                Log.PageHeading(this, "Non-Returnable Gate Pass Form");
            }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "Non Returnable GatePass Form- Page Load Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Bind Functions
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
            logmessage = "Non Returnable GatePass Form- BindMasterSearchBox Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
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
            logmessage = "Non Returnable GatePass Form- BindSearchDropDown Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
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
            logmessage = "Non Returnable GatePass Form- BindValuation -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void Readonlycontrols()
    {
        TxtYear.Attributes.Add("readonly", "true");
        TxtNRGPNo.Attributes.Add("readonly", "true");
        TxtNRGPDate.Attributes.Add("readonly", "true");
        TxtStorageLocation.Attributes.Add("readonly", "true");
        TxtMaterialCode.Attributes.Add("readonly", "true");
        TxtBatch.Attributes.Add("readonly", "true");
        //TxtBatch2.Attributes.Add("readonly", "true");
        TxtVendor.Attributes.Add("readonly", "true");
        TxtGateEntryDate.Attributes.Add("readonly", "true");
        //TxtPlant.Attributes.Add("readonly", "true");
    }
    protected void BindNRGP()
    {
        try
        {
            DataTable dt = com.executeProcedure("Sp_Proc_GetNRGPType");
            DdlNRGPType.DataSource = dt;
            DdlNRGPType.DataTextField = "NRGPType";
            DdlNRGPType.DataValueField = "AutoId";
            DdlNRGPType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlNRGPType.Items.Add(item);
            DdlNRGPType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "NonReturnable Gate Pass Form - BindNRGP - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindPO(string key)
    {
        try
        {
            DataTable dt = com.GetVal("@ponumber", key, "Sp_FA_GetPODetails_By_PoNo");
            Gdvlookup.DataSource = dt;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form - BindPO - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindVendorList(string vendorcode)
    {
        try
        {
            DataTable dtvendors = com.GetVal("@Vendorname", vendorcode, "SP_FA_GetVendorNameFromVendor_mst");
            Gdvlookup.DataSource = dtvendors;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable GatePass Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindLocation(string searchwhat)
    {
        try
        {
            DataTable dtlocation = new DataTable();
            dtlocation = com.GetVal("@locationname", searchwhat, "SP_Prod_GetStorageLocation_mst");
            Gdvlookup.DataSource = dtlocation;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable GatePass Form- BindLocation() -Error-" + ex.ToString();
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
            logmessage = "Non-Returnable GatePass Form- BindBatchNo() -Error-" + ex.ToString();
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
            logmessage = "Non-Returnable GatePass Form- BindMaterial() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void MakeDefaultMasterDrop()
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        ddl.SelectedValue = "";
    }
    #region BindTempTable
    private void BindTempTable()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LineNo", typeof(string));
            dt.Columns.Add("ValuationType", typeof(string));
            dt.Columns.Add("MaterialCode", typeof(string));
            dt.Columns.Add("Plant", typeof(string));
            dt.Columns.Add("StorageLocation", typeof(string));
            dt.Columns.Add("Batch", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("ApproxValue", typeof(string));
            GdvGatePass.DataSource = dt;
            GdvGatePass.DataBind();
            GdvGatePass.Columns[11].Visible = false;
        }
        catch (Exception ex)
        {
            logmessage = "NonReturnable GatePass Form- Bind Temp Table in page load-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
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
            logmessage = "Non-Returnable Gate Pass Form - BindPlant - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Button click events
    private void btn_search_Click(object sender, ImageClickEventArgs e)
    {
      try
        {
            bindsearch();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form - btn_search_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }

    }
    private void bindsearch()
    {
        HidPopUpType.Value = "";
        txtSearchList.Text = "";
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
            if (ddsearch.SelectedItem.Value == "NRGPNo")
            {
                lSearchList.Text = "Search By NonRGPNo";
                dt = objnonreturnablegatepass.SearchNRGP("NRGPNo", txtSearch.Text);
            }
            if (ddsearch.SelectedItem.Value == "Vendor")
            {
                lSearchList.Text = "Search By Vendor Code";
                dt = objnonreturnablegatepass.SearchNRGP("Vendor", txtSearch.Text);
            }
            if (ddsearch.SelectedItem.Value == "GateEntry")
            {
                lSearchList.Text = "Search By GateEntry";
                dt = objnonreturnablegatepass.SearchNRGP("GateEntry", txtSearch.Text);
            }

            gridMaster.Visible = true;
            Gdvlookup.Visible = false;
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ClearHeader();
            ClearDetails();
            btnSave.ImageUrl = "~/Images/btnSave.png";
            btnSave.Enabled = true;
            btnAddLine.ImageUrl = "~/Images/btnAddLinegreen.png";
            btnAddLine.Enabled = true;
            hidAutoIdHeader.Value = "";
        }
        catch (Exception ex)
        {
            logmessage = "NonReturnable Gate Pass Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnPONo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search By PO";
            HidPopUpType.Value = "po";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindPO("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form- ImgBtnPONo_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnVendor_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search By Vendor Code";
            HidPopUpType.Value = "vendor";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindVendorList("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form- ImgBtnVendor_Click event -Error-" + ex.ToString();
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
                    if (objnonreturnablegatepass.update_header_lineitem(TxtNRGPNo.Text, ViewState["lineno"].ToString(), TxtMaterialCode.Text, DdlPlant.SelectedValue, DdlValuationType.SelectedValue, TxtStorageLocation.Text, TxtBatch.Text, TxtQuantity.Text, TxtApproxValue.Text, TxtNRGPDate.Text, DdlNRGPType.SelectedValue, TxtVendor.Text, TxtGateEntryNo.Text, TxtGateEntryDate.Text, TxtVehicleNo.Text, TxtGoodReciept.Text, TxtGR.Text, TxtCreditNotes.Text, Session["userId"].ToString(), TxtYear.Text))
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
                    if (objnonreturnablegatepass.updateheader(TxtNRGPNo.Text, TxtNRGPDate.Text, DdlNRGPType.SelectedValue, TxtVendor.Text, TxtGateEntryNo.Text, TxtGateEntryDate.Text, TxtVehicleNo.Text, TxtGoodReciept.Text, TxtGR.Text, TxtCreditNotes.Text, Session["userId"].ToString(), TxtYear.Text))
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
                    dtdetails.Columns.Remove("ValuationTypeText");
                    dtdetails.Columns.Remove("PlantText");
                }
                if (dtdetails.Rows.Count > 0)
                {
                    bool saved = false;
                    saved = objnonreturnablegatepass.saveRecords(dtdetails, TxtYear.Text, TxtNRGPDate.Text, DdlNRGPType.SelectedValue, TxtVendor.Text, TxtGateEntryNo.Text, TxtGateEntryDate.Text, TxtVehicleNo.Text, TxtGoodReciept.Text, TxtGR.Text, TxtCreditNotes.Text, createdby);
                    if (saved)
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordSaved, 125, 300);
                        ClearHeader();
                        ClearDetails();
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
            logmessage = "Non-Returnable Gate Pass Form- btnSave_Click event -Error-" + ex.ToString();
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
                dt.Columns.Add("ValuationType", typeof(string));
                dt.Columns.Add("ValuationTypeText", typeof(string));
                dt.Columns.Add("MaterialCode", typeof(string));
                dt.Columns.Add("Plant", typeof(string));
                dt.Columns.Add("PlantText", typeof(string));
                dt.Columns.Add("StorageLocation", typeof(string));
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
            drow["ValuationType"] = DdlValuationType.SelectedValue;
            drow["ValuationTypeText"] = DdlValuationType.SelectedItem.Text;
            drow["MaterialCode"] = TxtMaterialCode.Text.Trim();
            drow["Plant"] = DdlPlant.SelectedValue;
            drow["PlantText"] = DdlPlant.SelectedItem.Text;
            drow["StorageLocation"] = TxtStorageLocation.Text.Trim();
            drow["BatchNo"] = TxtBatch.Text.Trim();
            drow["Quantity"] = TxtQuantity.Text.Trim();
            drow["Value"] = TxtApproxValue.Text.Trim();
            dt.Rows.Add(drow);
            ViewState["Details"] = dt;
            ViewState["LnNo"] = drow["LineNo"];
            GdvGatePass.DataSource = dt;
            GdvGatePass.DataBind();
            GdvGatePass.Columns[11].Visible = true;
            ClearDetails();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form- btnAddLine_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnStorageLocation_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search By Location Code";
            HidPopUpType.Value = "fromlocation";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindLocation("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form- ImgBtnStorageLocation_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnBatchNo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search By BatchNo";
            HidPopUpType.Value = "batchno";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindBatchNo("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form- ImgBtnBatchNo_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnMaterialCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search By MaterialCode";
            HidPopUpType.Value = "materialcode";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindMaterial("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form- ImgBtnMaterialCode_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnPlant_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            DataTable dt = null;
            if (ddlSearch.SelectedValue.ToString() == "NRGPNo")
            {
                lSearchList.Text = "Search By NRGPNo";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objnonreturnablegatepass.SearchNRGP("NRGPNo", txtSearchList.Text);
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
            }
            if (ddlSearch.SelectedValue.ToString() == "Vendor")
            {
                lSearchList.Text = "Search By Vendor Code";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objnonreturnablegatepass.SearchNRGP("Vendor", txtSearchList.Text);
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
            }
            if (ddlSearch.SelectedValue.ToString() == "GateEntry")
            {
                lSearchList.Text = "Search By GateEntry";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objnonreturnablegatepass.SearchNRGP("GateEntry", txtSearchList.Text);
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
            }
            if (HidPopUpType.Value == "vendor")
            {
                lSearchList.Text = "Search By Vendor Code";
                gridMaster.Visible = false;
                Gdvlookup.Visible = true;
                BindVendorList(txtSearchList.Text.Trim());
            }
            if (HidPopUpType.Value == "po")
            {
                lSearchList.Text = "Search By PO";
                gridMaster.Visible = false;
                Gdvlookup.Visible = true;
                BindPO(txtSearchList.Text.Trim());
            }
            if (HidPopUpType.Value == "batchno")
            {
                lSearchList.Text = "Search By BatchNo";
                gridMaster.Visible = false;
                Gdvlookup.Visible = true;
                BindBatchNo(txtSearchList.Text.Trim());
            }
            if (HidPopUpType.Value == "fromlocation")
            {
                lSearchList.Text = "Search By Location Code";
                gridMaster.Visible = false;
                Gdvlookup.Visible = true;
                BindLocation(txtSearchList.Text.Trim());
            }
            if (HidPopUpType.Value == "materialcode")
            {
                lSearchList.Text = "Search By Material Code";
                gridMaster.Visible = false;
                Gdvlookup.Visible = true;
                BindMaterial(txtSearchList.Text.Trim());
            }
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Non-Returnable Gate Pass Form- btnSearchlist_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region GridEvents
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
                if (HidPopUpType.Value == "fromlocation")
                {
                    string locationcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    string locationname = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    TxtStorageLocation.Text = locationcode;
                }
                if (HidPopUpType.Value == "vendor")
                {
                    string vendorcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    string vendorname = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    TxtVendor.Text = vendorcode;
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
            logmessage = "NonReturnable Gate Pass Form - Gdvlookup_RowCommand - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvlookup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Gdvlookup.PageIndex = e.NewPageIndex;
            if (HidPopUpType.Value == "vendor")
            {
                BindVendorList("");
            }
            if (HidPopUpType.Value == "po")
            {
                BindPO("");
            }
            if (HidPopUpType.Value == "batchno")
            {
                BindBatchNo("");
            }
            if (HidPopUpType.Value == "fromlocation")
            {
                BindLocation("");
            }
            if (HidPopUpType.Value == "materialcode")
            {
                BindMaterial("");
            }
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "NonReturnable Gate Pass Form - Gdvlookup_PageIndexChanging - Error-" + ex.ToString();
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
            logmessage = "NonReturnable Gate Pass Form - Gdvlookup_SelectedIndexChanged - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string id = gridMaster.SelectedDataKey.Value.ToString();
            #region clear controls
            ClearHeader();
            ClearDetails();
            #endregion
            #region BindHeaderdetails
            DataTable dtheader = com.GetVal("@Id", id, "Sp_Proc_NonRGP_GetHeaderDetails");
            if (dtheader != null)
            {
                if (dtheader.Rows.Count > 0)
                {
                    TxtNRGPDate.Text = dtheader.Rows[0]["NRGPDate"].ToString();
                    TxtNRGPNo.Text = dtheader.Rows[0]["NRGP Number"].ToString();
                    TxtYear.Text = dtheader.Rows[0]["Year"].ToString();
                    DdlNRGPType.SelectedValue = dtheader.Rows[0]["NRGPType"].ToString();
                    TxtVendor.Text = dtheader.Rows[0]["Vendor"].ToString();
                    TxtGateEntryNo.Text = dtheader.Rows[0]["GateEntry"].ToString();
                    TxtGateEntryDate.Text = dtheader.Rows[0]["GateEntryDate"].ToString();
                    TxtVehicleNo.Text = dtheader.Rows[0]["VechileNo"].ToString();
                    TxtGoodReciept.Text = dtheader.Rows[0]["GoodReceiptNo"].ToString();
                    TxtCreditNotes.Text = dtheader.Rows[0]["CreditNotes"].ToString();
                    TxtGR.Text = dtheader.Rows[0]["GoodReceipt"].ToString();
                    hidAutoIdHeader.Value = "1";
                    #region BindDetails
                    DataTable dtdetails = com.GetVal("@Id", TxtNRGPNo.Text, "Sp_Proc_NRGP_GetLineItemsDetails");
                    GdvGatePass.DataSource = dtdetails;
                    GdvGatePass.DataBind();
                    ViewState["NRGPNo"] = TxtNRGPNo.Text;
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
            logmessage = "NonReturnable Gate Pass Form - gridMaster_SelectedIndexChanged - Error-" + ex.ToString();
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
            logmessage = "NonReturnable Gate Pass Form - gridMaster_PageIndexChanging - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvGatePass_RowCommand(object sender, GridViewCommandEventArgs e)
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
                }
                else
                {
                    GdvGatePass.DataSource = dt;
                    GdvGatePass.DataBind();
                }
            }
            #endregion
            #region binding data when edit link is clicked
            if (e.CommandName == "editrow")
            {
                string NonRGPassno = ViewState["NRGPNo"].ToString();
                string lineno = e.CommandArgument.ToString();
                ViewState["lineno"] = lineno;
                DataTable dtlineitemdetails = objnonreturnablegatepass.NonRGP_GetLineItems_ByLineId(NonRGPassno, lineno);
                if (dtlineitemdetails != null)
                {
                    if (dtlineitemdetails.Rows.Count > 0)
                    {
                        TxtMaterialCode.Text = dtlineitemdetails.Rows[0]["MaterialCode"].ToString();
                        DdlPlant.SelectedValue = dtlineitemdetails.Rows[0]["Plant"].ToString();
                        DdlValuationType.SelectedValue = dtlineitemdetails.Rows[0]["ValuationType"].ToString();
                        TxtBatch.Text = dtlineitemdetails.Rows[0]["BatchNo"].ToString();
                        TxtStorageLocation.Text = dtlineitemdetails.Rows[0]["StorageLocation"].ToString();
                        TxtQuantity.Text = dtlineitemdetails.Rows[0]["Quantity"].ToString();
                        TxtApproxValue.Text = dtlineitemdetails.Rows[0]["Value"].ToString();
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
            logmessage = "NonReturnable Gate Pass Form - GdvGatePass_RowCommand - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvGatePass_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (hidAutoIdHeader.Value == "")
            {
                e.Row.Cells[0].Visible = false;
                // e.Row.Cells[12].Visible = true;
            }
            else if (hidAutoIdHeader.Value != "")
            {
                e.Row.Cells[0].Visible = true;
                // e.Row.Cells[12].Visible = false;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form- GdvGatePass_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Clear Events
    private void ClearDetails()
    {
        TxtBatch.Text = "";
        TxtMaterialCode.Text = "";
        TxtQuantity.Text = "";
        TxtApproxValue.Text = "";
        TxtStorageLocation.Text = "";
        DdlValuationType.SelectedValue = "0";
        DdlPlant.SelectedValue = "0";
    }
    private void ClearHeader()
    {
        TxtNRGPDate.Text = "";
        TxtNRGPNo.Text = "";
        DdlNRGPType.SelectedValue = "0";
        TxtVendor.Text = "";
        TxtGateEntryNo.Text = "";
        TxtGateEntryDate.Text = "";
        TxtVehicleNo.Text = "";
        TxtGoodReciept.Text = "";
        TxtGR.Text = "";
        TxtGoodReciept.Text = "";
        TxtCreditNotes.Text = "";
        BindTempTable();
    }
    #endregion

}