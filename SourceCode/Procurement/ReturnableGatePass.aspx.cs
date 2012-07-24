////////////////////////////////////Code developed and designed by lalit on 27 June 2012///////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_ReturnableGatePass : System.Web.UI.Page
{
   
    #region Define Global variable here
    string logmessage = "";
    Common_Message commessage = new Common_Message();
    Common com = new Common();
    BLLCollection<FA_VendorMaster> colvendorlist = new BLLCollection<FA_VendorMaster>();
    FA_VendorMaster objvendor = new FA_VendorMaster();
    Proc_ReturnableGatePass objreturnablegatepass = new Proc_ReturnableGatePass();
    #endregion

    #region Pageload event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindSearchDropDown("139");
            BindRGP();
            BindPlant();
            BindTempTable();
            BindPackedType();
            Log.GetLog().FillFinancialYear(TxtYear);
            Readonlycontrols();
            Log.PageHeading(this, "Returnable Gate Pass Form");
         }
        BindMasterSearchBox();
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
            logmessage = "Returnable GatePass Form- BindMasterSearchBox Method -Error-" + ex.ToString();
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
            logmessage = "Returnable GatePass Form- BindSearchDropDown Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindRGP()
    {
        try
        {
            DataTable dt = com.executeProcedure("Sp_Proc_GetRGPType");
            DdlRGPType.DataSource = dt;
            DdlRGPType.DataTextField = "RGPType";
            DdlRGPType.DataValueField = "AutoId";
            DdlRGPType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlRGPType.Items.Add(item);
            DdlRGPType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form - BindRGP - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindPackedType()
    {
        try
        {
            DataTable dt = com.executeProcedure("Sp_Proc_GetPackedType");
            DdlPacked.DataSource = dt;
            DdlPacked.DataTextField = "IsPacked";
            DdlPacked.DataValueField = "AutoId";
            DdlPacked.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlPacked.Items.Add(item);
            DdlPacked.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form - BindPackedType - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void Readonlycontrols()
    {
        TxtYear.Attributes.Add("readonly", "true");
        TxtRGPNo.Attributes.Add("readonly", "true");
        TxtRGPDate.Attributes.Add("readonly", "true");
        TxtStorageLocation.Attributes.Add("readonly", "true");
        TxtMaterialCode.Attributes.Add("readonly", "true");
        TxtBatch.Attributes.Add("readonly", "true");
        TxtVendor.Attributes.Add("readonly", "true");
        TxtGateEntryDate.Attributes.Add("readonly", "true");
        TxtPONumber.Attributes.Add("readonly", "true");
        TxtEstimatedDateOfReturn.Attributes.Add("readonly", "true");
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
            logmessage = "Returnable Gate Pass Form - BindPO - Error-" + ex.ToString();
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
            logmessage = "Returnable GatePass Form- BindVendorList() -Error-" + ex.ToString();
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
            logmessage = "Returnable GatePass Form- BindLocation() -Error-" + ex.ToString();
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
            dt.Columns.Add("PurchaseOrder", typeof(string));
            dt.Columns.Add("MaterialCode", typeof(string));
            dt.Columns.Add("Plant", typeof(string));
            dt.Columns.Add("BatchNo", typeof(string));
            dt.Columns.Add("StorageLocation", typeof(string));
            dt.Columns.Add("EstimatedDateOfReturn", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("ApproxValue", typeof(string));
            dt.Columns.Add("Packed", typeof(string));
            dt.Columns.Add("GrossWeight", typeof(string));
            dt.Columns.Add("NetWeight", typeof(string));
            dt.Columns.Add("SerialNo", typeof(string));
            GdvGatePass.DataSource = dt;
            GdvGatePass.DataBind();
            GdvGatePass.Columns[15].Visible = false;
        }
        catch (Exception ex)
        {
            logmessage = "Returnable GatePass Form- BindTempTable() -Error-" + ex.ToString();
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
            logmessage = "Returnable Gate Pass Form - BindPlant - Error-" + ex.ToString();
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
            logmessage = "Returnable Gate Pass Form - BindBatchNo - Error-" + ex.ToString();
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
            logmessage = "Returnable Gate Pass Form - BindMaterial - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Button Click Event
    private void btn_search_Click(object sender, ImageClickEventArgs e)
    {
       try
        {
            bindsearch();
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form - btn_search_Click - Error-" + ex.ToString();
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
            if (ddsearch.SelectedItem.Value == "RGPNo")
            {
                lSearchList.Text = "Search By RGPNo";
                dt = objreturnablegatepass.SearchRGP("RGPNo", txtSearch.Text);
            }
            if (ddsearch.SelectedItem.Value == "Vendor")
            {
                lSearchList.Text = "Search By Vendor Code";
                dt = objreturnablegatepass.SearchRGP("Vendor", txtSearch.Text);
            }
            if (ddsearch.SelectedItem.Value == "GateEntry")
            {
                lSearchList.Text = "Search By GateEntry";
                dt = objreturnablegatepass.SearchRGP("GateEntry", txtSearch.Text);
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
            ClearField();
            hidAutoIdHeader.Value = "";
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnPONo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search By PONo";
            MakeDefaultMasterDrop();
            HidPopUpType.Value = "po";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindPO("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form - ImgBtnPONo_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnVendor_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            HidPopUpType.Value = "vendor";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindVendorList("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form - ImgBtnVendor_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    
    

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            DataTable dt = null;
            if (ddlSearch.SelectedValue.ToString() == "RGPNo")
            {
                lSearchList.Text = "Search By RGPNo";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objreturnablegatepass.SearchRGP("RGPNo", txtSearchList.Text);
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
            }
            if (ddlSearch.SelectedValue.ToString() == "Vendor")
            {
                lSearchList.Text = "Search By Vendor Code";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objreturnablegatepass.SearchRGP("Vendor", txtSearchList.Text);
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
            }
            if (ddlSearch.SelectedValue.ToString() == "GateEntry")
            {
                lSearchList.Text = "Search By GateEntry";
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                dt = objreturnablegatepass.SearchRGP("GateEntry", txtSearchList.Text);
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
            logmessage = "Returnable Gate Pass Form- btnSearchlist_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnStorageLocation_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search By Location";
            MakeDefaultMasterDrop();
            HidPopUpType.Value = "fromlocation";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindLocation("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form- ImgBtnStorageLocation_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnBatchNo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search By BatchNo";
            MakeDefaultMasterDrop();
            HidPopUpType.Value = "batchno";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindBatchNo("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form- ImgBtnBatchNo_Click event -Error-" + ex.ToString();
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
            logmessage = "Returnable Gate Pass Form- ImgBtnMaterialCode_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Update records
            if (btnSave.ImageUrl == "~/Images/btn_update.png")
            {
                #region update line item
                if (ViewState["lineno"] != null)
                {
                    if (objreturnablegatepass.update_header_lineitem(TxtRGPNo.Text, ViewState["lineno"].ToString(), TxtPONumber.Text, TxtMaterialCode.Text, DdlPlant.SelectedValue, TxtStorageLocation.Text, TxtBatch.Text, TxtEstimatedDateOfReturn.Text, TxtQuantity.Text, TxtApproxValue.Text, DdlPacked.SelectedValue, TxtGrossWeight.Text, TxtNetWeight.Text, TxtSerialNumber.Text, TxtRGPDate.Text, DdlRGPType.SelectedValue, TxtVendor.Text, TxtGateEntryNo.Text, TxtGateEntryDate.Text, TxtVehicleNo.Text, TxtGoodReciept.Text, Session["userId"].ToString(), TxtYear.Text))
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
                    if (objreturnablegatepass.updateheader(TxtRGPNo.Text, TxtRGPDate.Text, DdlRGPType.SelectedValue, TxtVendor.Text, TxtGateEntryNo.Text, TxtGateEntryDate.Text, TxtVehicleNo.Text, TxtGoodReciept.Text, Session["userId"].ToString(), TxtYear.Text))
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
                    dtdetails.Columns.Remove("PlantText");
                }
                if (dtdetails.Rows.Count > 0)
                {
                    bool saved = false;
                    saved = objreturnablegatepass.saveRecords(dtdetails, TxtYear.Text, TxtRGPDate.Text, DdlRGPType.SelectedValue, TxtVendor.Text, TxtGateEntryNo.Text, TxtGateEntryDate.Text, TxtVehicleNo.Text, TxtGoodReciept.Text, createdby);
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
            logmessage = "Returnable Gate Pass Form- btnSave_Click event -Error-" + ex.ToString();
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
                dt.Columns.Add("PurchaseOrder", typeof(string));
                dt.Columns.Add("MaterialCode", typeof(string));
                dt.Columns.Add("Plant", typeof(string));
                dt.Columns.Add("PlantText", typeof(string));
                dt.Columns.Add("BatchNo", typeof(string));
                dt.Columns.Add("StorageLocation", typeof(string));
                dt.Columns.Add("EstimatedDateOfReturn", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));
                dt.Columns.Add("ApproxValue", typeof(string));
                dt.Columns.Add("Packed", typeof(string));
                dt.Columns.Add("GrossWeight", typeof(string));
                dt.Columns.Add("NetWeight", typeof(string));
                dt.Columns.Add("SerialNo", typeof(string));

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
            drow["PurchaseOrder"] = TxtPONumber.Text;
            drow["MaterialCode"] = TxtMaterialCode.Text.Trim();
            drow["Plant"] = DdlPlant.SelectedValue;
            drow["PlantText"] = DdlPlant.SelectedItem.Text;
            drow["BatchNo"] = TxtBatch.Text.Trim();
            drow["StorageLocation"] = TxtStorageLocation.Text.Trim();
            drow["EstimatedDateOfReturn"] = TxtEstimatedDateOfReturn.Text;
            drow["Quantity"] = TxtQuantity.Text.Trim();
            drow["ApproxValue"] = TxtApproxValue.Text.Trim();
            drow["Packed"] = DdlPacked.SelectedValue;
            drow["GrossWeight"] = TxtGrossWeight.Text;
            drow["NetWeight"] = TxtNetWeight.Text;
            drow["SerialNo"] = TxtSerialNumber.Text;
            dt.Rows.Add(drow);
            ViewState["Details"] = dt;
            ViewState["LnNo"] = drow["LineNo"];
            GdvGatePass.DataSource = dt;
            GdvGatePass.DataBind();
            GdvGatePass.Columns[15].Visible = true;
            cleardetails();
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form- btnAddLine_Click event -Error-" + ex.ToString();
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
                if (HidPopUpType.Value == "po")
                {
                    string ponumber = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtPONumber.Text = ponumber;
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Returnable Gate Pass Form - Gdvlookup_RowCommand - Error-" + ex.ToString();
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
            logmessage = "Returnable Gate Pass Form - Gdvlookup_PageIndexChanging - Error-" + ex.ToString();
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
            logmessage = "Returnable Gate Pass Form - Gdvlookup_SelectedIndexChanged - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
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
            DataTable dtheader = com.GetVal("@Id", id, "Sp_Proc_RGP_GetHeaderDetails");
            if (dtheader != null)
            {
                if (dtheader.Rows.Count > 0)
                {
                    TxtRGPDate.Text = dtheader.Rows[0]["RGPDate"].ToString();
                    TxtRGPNo.Text = dtheader.Rows[0]["RGP Number"].ToString();
                    TxtYear.Text = dtheader.Rows[0]["Year"].ToString();
                    DdlRGPType.SelectedValue = dtheader.Rows[0]["RGPType"].ToString();
                    TxtVendor.Text = dtheader.Rows[0]["Vendor"].ToString();
                    TxtGateEntryNo.Text = dtheader.Rows[0]["GateEntry"].ToString();
                    TxtGateEntryDate.Text = dtheader.Rows[0]["GateEntryDate"].ToString();
                    TxtVehicleNo.Text = dtheader.Rows[0]["VechileNo"].ToString();
                    TxtGoodReciept.Text = dtheader.Rows[0]["GoodReceiptNo"].ToString();
                    hidAutoIdHeader.Value = "1";
                    #region BindDetails
                    DataTable dtdetails = com.GetVal("@Id", TxtRGPNo.Text, "Sp_Proc_RGP_GetLineItemsDetails");
                    GdvGatePass.DataSource = dtdetails;
                    GdvGatePass.DataBind();
                    ViewState["transferno"] = TxtRGPNo.Text;
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
            logmessage = "Returnable Gate Pass Form - gridMaster_SelectedIndexChanged - Error-" + ex.ToString();
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
            logmessage = "Returnable Gate Pass Form - gridMaster_PageIndexChanging - Error-" + ex.ToString();
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
                string transferno = ViewState["transferno"].ToString();
                string lineno = e.CommandArgument.ToString();
                ViewState["lineno"] = lineno;
                DataTable dtlineitemdetails = objreturnablegatepass.RGP_GetLineItems_ByLineId(transferno, lineno);
                if (dtlineitemdetails != null)
                {
                    if (dtlineitemdetails.Rows.Count > 0)
                    {
                        TxtMaterialCode.Text = dtlineitemdetails.Rows[0]["MaterialCode"].ToString();
                        TxtPONumber.Text = dtlineitemdetails.Rows[0]["PurchaseOrder"].ToString();
                        DdlPlant.SelectedValue = dtlineitemdetails.Rows[0]["Plant"].ToString();
                        TxtBatch.Text = dtlineitemdetails.Rows[0]["BatchNo"].ToString();
                        TxtStorageLocation.Text = dtlineitemdetails.Rows[0]["StorageLocation"].ToString();
                        TxtEstimatedDateOfReturn.Text = dtlineitemdetails.Rows[0]["EstimatedDateOfReturn"].ToString();
                        TxtQuantity.Text = dtlineitemdetails.Rows[0]["Quantity"].ToString();
                        TxtApproxValue.Text = dtlineitemdetails.Rows[0]["ApproxValue"].ToString();
                        DdlPacked.SelectedValue = dtlineitemdetails.Rows[0]["Packed"].ToString();
                        TxtGrossWeight.Text = dtlineitemdetails.Rows[0]["GrossWeight"].ToString();
                        TxtNetWeight.Text = dtlineitemdetails.Rows[0]["NetWeight"].ToString();
                        TxtSerialNumber.Text = dtlineitemdetails.Rows[0]["SerialNumber"].ToString();
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
            logmessage = "Returnable Gate Pass Form - GdvGatePass_RowCommand - Error-" + ex.ToString();
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

    #region ClearEvents
    private void ClearField()
    {
        TxtBatch.Text = "";
        TxtMaterialCode.Text = "";
        TxtQuantity.Text = "";
        TxtStorageLocation.Text = "";
        TxtRGPDate.Text = "";
        TxtRGPNo.Text = "";
        TxtGateEntryNo.Text = "";
        TxtVendor.Text = "";
        TxtPONumber.Text = "";
        DdlPlant.SelectedValue = "0";
        TxtEstimatedDateOfReturn.Text = "";
        TxtApproxValue.Text = "";
        DdlPacked.SelectedValue = "0";
        TxtGrossWeight.Text = "";
        TxtNetWeight.Text = "";
        TxtSerialNumber.Text = "";
        DdlRGPType.SelectedValue = "0";
        TxtGateEntryDate.Text = "";
        BindTempTable();
        btnSave.ImageUrl = "~/Images/btnSave.png";
        btnSave.Enabled = true;
        btnAddLine.ImageUrl = "~/Images/btnAddLinegreen.png";
        btnAddLine.Enabled = true;
    }
    private void cleardetails()
    {
        TxtBatch.Text = "";
        TxtMaterialCode.Text = "";
        TxtQuantity.Text = "";
        TxtStorageLocation.Text = "";
        DdlPlant.SelectedValue = "0";
        TxtEstimatedDateOfReturn.Text = "";
        TxtPONumber.Text = "";
        DdlPlant.SelectedValue = "0";
        TxtApproxValue.Text = "";
        DdlPacked.SelectedValue = "0";
        TxtGrossWeight.Text = "";
        TxtNetWeight.Text = "";
        TxtSerialNumber.Text = "";
    }
    #endregion
     
}