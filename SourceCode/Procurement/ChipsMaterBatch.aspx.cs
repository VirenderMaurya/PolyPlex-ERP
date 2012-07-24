using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Sales_PerformaInvoice : System.Web.UI.Page
{
    #region***************************************Variables***************************************

    Common_mst objCommon_mst = new Common_mst();
    Common_Message objcommonmessage = new Common_Message();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();
    Proc_ChipsMasterBatch objProc_ChipsMasterBatch = new Proc_ChipsMasterBatch();
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblInfo.Text = "";
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Chips Master Batch";

            TDBatchNo.Attributes.Add("style", "display:none");
            TDtxtBatchNo.Attributes.Add("style", "display:none");

            #region Bind Masters

            BindSearchList();
            FillFinancialYear();
            Get_All_Prod_Process_Mst();
            Get_All_Prod_Batch_Mst();
            Get_All_Prod_StorageLocation_Mst();
            Get_All_Proc_VendorBatch_Mst();

            #endregion

            #region Get Line Item Grid Structure

            GetProc_ChipsMasterBatch_LineItems_Trans(0);

            #endregion

            #region Blank Grid

            gvMasterBatchPrep.DataSource = "";
            gvMasterBatchPrep.DataBind();

            #endregion
            txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            txtBatchNo.Attributes.Add("readonly", "true");
            txtBatchNo.Attributes.Add("style", "background:lightgray");
            txtDate.Attributes.Add("readonly", "true");
            txtDate.Attributes.Add("style", "background:lightgray");
            txtMaterialCode.Attributes.Add("readonly", "true");
            txtMaterialCode.Attributes.Add("style", "background:lightgray");
            txtMaterialName.Attributes.Add("readonly", "true");
            txtMaterialName.Attributes.Add("style", "background:lightgray");
            txtValuationType.Attributes.Add("readonly", "true");
            txtValuationType.Attributes.Add("style", "background:lightgray");
            txtQuantity.Attributes.Add("readonly", "true");
            txtQuantity.Attributes.Add("style", "background:lightgray");
            txtCurrentStock.Attributes.Add("readonly", "true");
            txtCurrentStock.Attributes.Add("style", "background:lightgray");

        }
        ImageButton btnAdd = (ImageButton)Master.FindControl("btnAdd");
        btnAdd.CausesValidation = false;
        btnAdd.Click += new ImageClickEventHandler(btnAdd_Click);

        ImageButton imgbtnSearch = (ImageButton)Master.FindControl("imgbtnSearch");
        imgbtnSearch.CausesValidation = false;
        imgbtnSearch.Click += new ImageClickEventHandler(imgbtnSearch_Click);
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        ClearHeaderItems();
        ClearLineItems();
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindAllChipsMasterBatch(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllChipsMasterBatch(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "MaterialCode")
        {
            FillAllMaterialCode(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "ValuationType")
        {
            FillAllValuationTypeMaster(txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
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

                if (HidPopUpType.Value == "MaterialCode")
                {
                    HidMaterialId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtMaterialCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    txtMaterialName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                }
                else if (HidPopUpType.Value == "ValuationType")
                {
                    HidValuationTypeId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtValuationType.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                }
            }
        }
        catch { }
    }

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        if (HidPopUpType.Value == "MaterialCode")
        {
            FillAllMaterialCode(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "ValuationType")
        {
            FillAllValuationTypeMaster(txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void imgMaterialCode_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "MaterialCode";
        lPopUpHeader.Text = "Material";
        lSearch.Text = "Search By Material Code/Name: ";
        FillAllMaterialCode("");
        ModalPopupExtender2.Show();
    }

    protected void imgBtnValuationType_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "ValuationType";
        lPopUpHeader.Text = "Valuation Type";
        lSearch.Text = "Search By Valuation Type: ";
        FillAllValuationTypeMaster("");
        ModalPopupExtender2.Show();
    }

    protected void gvMasterBatchPrep_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[2].Style.Add("display", "none");
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.GridView gvLineItems = (System.Web.UI.WebControls.GridView)sender;
                GridViewRow Gi;
                Gi = e.Row;

                if (e.Row.Cells[11].Text == "P")
                {
                    e.Row.Cells[11].Text = "Preparation";
                }
                else if (e.Row.Cells[11].Text == "D")
                {
                    e.Row.Cells[11].Text = "Dilution";
                }
            }
        }
        catch { }
    }

    protected void gvMasterBatchPrep_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvMasterBatchPrep = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvMasterBatchPrep.SelectedIndex = row.RowIndex + 1;

        DataTable objdtLineItem = new DataTable();
        objdtLineItem = (DataTable)ViewState["LineItem"];

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvMasterBatchPrep.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            if (objdtLineItem.Rows.Count > 0)
            {
                hidRowIndex.Value = Convert.ToString(row.RowIndex);
                hidLineItemId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LineItemID"].ToString();
                HidUpdateGridRecord.Value = "Yes";
                HidMaterialId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialCodeId"].ToString();
                txtMaterialCode.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialCode"].ToString();
                txtMaterialName.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialName"].ToString();
                ddlVendorBatch.SelectedValue = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["VendorBatchId"].ToString();
                HidValuationTypeId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ValuationTypeId"].ToString();
                txtValuationType.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ValuationType"].ToString();
                ddlStorageLocation.SelectedValue = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["StorageLocationId"].ToString();
                txtQuantity.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Quantity"].ToString();
                if (objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PreparationDilution"].ToString() == "P" ||
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PreparationDilution"].ToString() == "Preparation")
                {
                    rdPreparation.Checked = true;
                    rdDilution.Checked = false;
                }
                if (objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PreparationDilution"].ToString() == "D" ||
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PreparationDilution"].ToString() == "Dilution")
                {
                    rdPreparation.Checked = false;
                    rdDilution.Checked = true;
                }
                //txtCurrentStock.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["CurrentStock"].ToString();
                ImgBtnAddLine.ImageUrl = "../Images/btnUpdateLine.png";
            }
        }
    }

    protected void gvAllChipsMasterBatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[4].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvAllChipsMasterBatch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvAllChipsMasterBatch = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvAllChipsMasterBatch.SelectedIndex = row.RowIndex;

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvAllChipsMasterBatch.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            HidChipsMasterBatchId.Value = Convert.ToString(e.CommandArgument);
            if (gvAllChipsMasterBatch.Rows[gvAllChipsMasterBatch.SelectedIndex].Cells[1].Text != "0")
            {
                ddlProcessCode.SelectedValue = gvAllChipsMasterBatch.Rows[gvAllChipsMasterBatch.SelectedIndex].Cells[1].Text;
            }
            else
            {
                ddlProcessCode.SelectedValue = "";
            }
            txtBatchNo.Text = gvAllChipsMasterBatch.Rows[gvAllChipsMasterBatch.SelectedIndex].Cells[3].Text;
            if (gvAllChipsMasterBatch.Rows[gvAllChipsMasterBatch.SelectedIndex].Cells[4].Text != "0")
            {
                ddlMasterBatchCode.SelectedValue = gvAllChipsMasterBatch.Rows[gvAllChipsMasterBatch.SelectedIndex].Cells[4].Text;
            }
            else
            {
                ddlMasterBatchCode.SelectedValue = "";
            }

            TDBatchNo.Attributes.Add("style", "display:block");
            TDtxtBatchNo.Attributes.Add("style", "display:block");

            #region Bind Line Items
            GetProc_ChipsMasterBatch_LineItems_Trans(Convert.ToInt32(HidChipsMasterBatchId.Value));
            #endregion

        }
    }

    protected void gvAllChipsMasterBatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAllChipsMasterBatch.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllChipsMasterBatch(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }    

    protected void ImgBtnAddLine_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable objdtLineItem = new DataTable();
            objdtLineItem = (DataTable)ViewState["LineItem"];

            if (HidUpdateGridRecord.Value == "") //For Insert new record
            {
                DataRow objdrLineItem = objdtLineItem.NewRow();
                objdrLineItem["LineItemID"] = 0;
                objdrLineItem["IsUpdate"] = "";
                if (HidChipsMasterBatchId.Value != "")
                {
                    objdrLineItem["ChipsMasterBatchId"] = Convert.ToInt32(HidChipsMasterBatchId.Value);
                }
                else
                {
                    objdrLineItem["ChipsMasterBatchId"] = 0;
                }
                objdrLineItem["MaterialCodeId"] = Convert.ToInt32(HidMaterialId.Value);
                objdrLineItem["MaterialCode"] = txtMaterialCode.Text.Trim();
                objdrLineItem["MaterialName"] = txtMaterialName.Text.Trim();
                objdrLineItem["VendorBatchId"] = Convert.ToInt32(ddlVendorBatch.SelectedValue);
                objdrLineItem["VendorBatchName"] = ddlVendorBatch.SelectedItem.Text.Trim();
                objdrLineItem["ValuationTypeId"] = Convert.ToInt32(HidValuationTypeId.Value);
                objdrLineItem["ValuationType"] = txtValuationType.Text.Trim();
                objdrLineItem["StorageLocationId"] = Convert.ToInt32(ddlStorageLocation.SelectedValue);
                objdrLineItem["StorageLocationName"] = ddlStorageLocation.SelectedItem.Text.Trim();
                if (txtQuantity.Text.Trim() != "")
                {
                    objdrLineItem["Quantity"] = Convert.ToDouble(txtQuantity.Text.Trim());
                }
                else
                {
                    objdrLineItem["Quantity"] = 0;
                }
                if (rdPreparation.Checked == true)
                {
                    objdrLineItem["PreparationDilution"] = "P";
                }
                else if (rdDilution.Checked == true)
                {
                    objdrLineItem["PreparationDilution"] = "D";
                }
                else
                {
                    objdrLineItem["PreparationDilution"] = "";
                }
                if (txtCurrentStock.Text.Trim() != "")
                {
                    objdrLineItem["CurrentStock"] = Convert.ToDouble(txtCurrentStock.Text.Trim());
                }
                else
                {
                    objdrLineItem["CurrentStock"] = 0;
                }
                objdrLineItem["ActiveStatus"] = true;
                objdtLineItem.Rows.Add(objdrLineItem);

            }
            else if (HidUpdateGridRecord.Value == "Yes") //For Update record
            {
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["IsUpdate"] = "Yes";
                if (HidChipsMasterBatchId.Value != "")
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ChipsMasterBatchId"] = Convert.ToInt32(HidChipsMasterBatchId.Value);
                }
                else
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ChipsMasterBatchId"] = 0;
                }
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialCodeId"] = Convert.ToInt32(HidMaterialId.Value);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialCode"] = txtMaterialCode.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialName"] = txtMaterialName.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["VendorBatchId"] = Convert.ToInt32(ddlVendorBatch.SelectedValue);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["VendorBatchName"] = ddlVendorBatch.SelectedItem.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ValuationTypeId"] = Convert.ToInt32(HidValuationTypeId.Value);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ValuationType"] = txtValuationType.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["StorageLocationId"] = Convert.ToInt32(ddlStorageLocation.SelectedValue);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["StorageLocationName"] = ddlStorageLocation.SelectedItem.Text.Trim();
                if (txtQuantity.Text.Trim() != "")
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Quantity"] = Convert.ToDouble(txtQuantity.Text.Trim());
                }
                else
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Quantity"] = 0;
                }
                if (rdPreparation.Checked == true)
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PreparationDilution"] = "P";
                }
                else if (rdDilution.Checked == true)
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PreparationDilution"] = "D";
                }
                else
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PreparationDilution"] = "";
                }
                if (txtCurrentStock.Text.Trim() != "")
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["CurrentStock"] = Convert.ToDouble(txtCurrentStock.Text.Trim());
                }
                else
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["CurrentStock"] = 0;
                }
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ActiveStatus"] = true;
                objdtLineItem.AcceptChanges();
            }

            ViewState["LineItem"] = objdtLineItem;
            gvMasterBatchPrep.DataSource = objdtLineItem;
            gvMasterBatchPrep.DataBind();
            ClearLineItems();

        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.ErrorToLineItem, 125, 300);
        }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Upadte Record Of Header & Line Item

            DataTable dtLineItem = (DataTable)ViewState["LineItem"];
            if (dtLineItem.Rows.Count > 0)
            {
                #region Insert/Update Records Of Header

                if (HidChipsMasterBatchId.Value == "")
                {
                    objProc_ChipsMasterBatch.ChipsMasterBatchId = 0;
                }
                else
                {
                    objProc_ChipsMasterBatch.ChipsMasterBatchId = Convert.ToInt32(HidChipsMasterBatchId.Value);
                }
                objProc_ChipsMasterBatch.Year = HidFinYear.Value;
                if (ddlProcessCode.SelectedValue != "")
                {
                    objProc_ChipsMasterBatch.ProcessCodeId = Convert.ToInt32(ddlProcessCode.SelectedValue);
                }
                else
                {
                    objProc_ChipsMasterBatch.ProcessCodeId = 0;
                }
                if (ddlMasterBatchCode.SelectedValue != "")
                {
                    objProc_ChipsMasterBatch.MasterBatchId = Convert.ToInt32(ddlMasterBatchCode.SelectedValue);
                }
                else
                {
                    objProc_ChipsMasterBatch.MasterBatchId = 0;
                }
                if (txtDate.Text.Trim() != "")
                {
                    objProc_ChipsMasterBatch.Date = DateTime.ParseExact(txtDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_ChipsMasterBatch.Date = "";
                }
                objProc_ChipsMasterBatch.ActiveStatus = Convert.ToBoolean(1);
                objProc_ChipsMasterBatch.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objProc_ChipsMasterBatch.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                #endregion

                #region Insert/Update Records of LineItem

                objProc_ChipsMasterBatch.dtLineItems = new DataTable();
                objProc_ChipsMasterBatch.dtLineItems = objProc_ChipsMasterBatch.GetProc_ChipsMasterBatch_LineItems_Structure();
                DataRow objdrLineItems;

                if (dtLineItem.Rows.Count > 0)
                {
                    foreach (DataRow objdrLineItem in dtLineItem.Rows)
                    {
                        try
                        {
                            if ((objdrLineItem["LineItemID"].ToString() == "0" && objdrLineItem["IsUpdate"].ToString() == "") || (objdrLineItem["LineItemID"].ToString() != "0" &&
                                objdrLineItem["IsUpdate"].ToString() == "Yes"))
                            {
                                objdrLineItems = objProc_ChipsMasterBatch.dtLineItems.NewRow();

                                objdrLineItems["LineItemID"] = Convert.ToInt32(objdrLineItem["LineItemID"].ToString());
                                objdrLineItems["MaterialCodeId"] = Convert.ToInt32(objdrLineItem["MaterialCodeId"].ToString());
                                if (HidChipsMasterBatchId.Value == "")
                                {
                                    objdrLineItems["ChipsMasterBatchId"] = 0;
                                }
                                else
                                {
                                    objdrLineItems["ChipsMasterBatchId"] = Convert.ToInt32(HidChipsMasterBatchId.Value);
                                }

                                objdrLineItems["VendorBatchId"] = Convert.ToInt32(objdrLineItem["VendorBatchId"].ToString());
                                objdrLineItems["ValuationTypeId"] = Convert.ToInt32(objdrLineItem["ValuationTypeId"].ToString());
                                objdrLineItems["StorageLocationId"] = Convert.ToInt32(objdrLineItem["StorageLocationId"].ToString());
                                objdrLineItems["Quantity"] = Convert.ToDouble(objdrLineItem["Quantity"].ToString());
                                objdrLineItems["PreparationDilution"] = objdrLineItem["PreparationDilution"].ToString();
                                objdrLineItems["CurrentStock"] = Convert.ToDouble(objdrLineItem["CurrentStock"].ToString());
                                objdrLineItems["ActiveStatus"] = objdrLineItem["ActiveStatus"].ToString();

                                objProc_ChipsMasterBatch.dtLineItems.Rows.Add(objdrLineItems);
                                objProc_ChipsMasterBatch.dtLineItems.AcceptChanges();
                            }
                        }
                        catch
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.LineItemNotSaved, 125, 300);
                            return;
                        }
                    }
                }

                #endregion

                FlagInsertUpdate = objProc_ChipsMasterBatch.InsertUpdate_In_Proc_ChipsMasterBatch();
                if (FlagInsertUpdate == "YES")
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                    #region Clear All records after save

                    ClearHeaderItems();
                    ClearLineItems();
                    ViewState["LineItem"] = null;

                    gvMasterBatchPrep.DataSource = "";
                    gvMasterBatchPrep.DataBind();

                    DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
                    ddlSearch.SelectedValue = "0";
                    TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
                    txtSearch.Text = "";

                    #endregion
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                    return;
                }
                FlagInsertUpdate = "";
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.AddLineItem, 125, 300);
                return;
            }

            #endregion
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
        }
    }

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdProcChipsMaterBatch = ConfigurationManager.AppSettings["FormIdProcChipsMaterBatch"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProcChipsMaterBatch);

            ddlSearch.DataTextField = "Options";
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();
                ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }
        catch (Exception ex) { }
    }

    protected void FillFinancialYear()
    {
        try
        {
            DataTable dt = new DataTable();
            string OrganizationId = ConfigurationManager.AppSettings["OrganizationId"].ToString();
            dt = objCommon_mst.Get_FinancialYear(OrganizationId);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["FinancialStartMonth"].ToString()) > 1)
                {
                    string EndFinancialYear = dt.Rows[0]["FinancialEndYear"].ToString().Substring(2);
                    HidFinYear.Value = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    HidFinYear.Value = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch (Exception ex) { }
    }

    protected void Get_All_Prod_Process_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Process_Mst("");
            ddlProcessCode.DataTextField = "ProcessName";
            ddlProcessCode.DataValueField = "AutoId";
            ddlProcessCode.DataSource = colRCommontype;
            ddlProcessCode.DataBind();
            ddlProcessCode.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void Get_All_Prod_Batch_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Batch_Mst("");
            ddlMasterBatchCode.DataTextField = "BatchName";
            ddlMasterBatchCode.DataValueField = "AutoId";
            ddlMasterBatchCode.DataSource = colRCommontype;
            ddlMasterBatchCode.DataBind();
            ddlMasterBatchCode.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void Get_All_Prod_StorageLocation_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_StorageLocation_Mst("");
            ddlStorageLocation.DataTextField = "StorageLocationName";
            ddlStorageLocation.DataValueField = "AutoId";
            ddlStorageLocation.DataSource = colRCommontype;
            ddlStorageLocation.DataBind();
            ddlStorageLocation.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void Get_All_Proc_VendorBatch_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Proc_VendorBatch_Mst("");
            ddlVendorBatch.DataTextField = "VendorBatchName";
            ddlVendorBatch.DataValueField = "AutoId";
            ddlVendorBatch.DataSource = colRCommontype;
            ddlVendorBatch.DataBind();
            ddlVendorBatch.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    private void FillAllMaterialCode(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllMaterialMaster(Searchtext);

            if (dt.Rows.Count > 0)
            {
                lblTotalRecordsPopUp.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();

                gvPopUpGrid.AutoGenerateColumns = true;
                gvPopUpGrid.AllowPaging = true;
                gvPopUpGrid.DataSource = dt;

                if (gvPopUpGrid.PageIndex > (dt.Rows.Count / gvPopUpGrid.PageSize))
                {
                    gvPopUpGrid.SetPageIndex(0);
                }
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
            lblTotalRecordsPopUp.Text = objcommonmessage.NoRecordFound + ex.Message;
            gvPopUpGrid.AllowPaging = false;
            gvPopUpGrid.DataSource = "";
            gvPopUpGrid.DataBind();
        }
    }

    private void FillAllValuationTypeMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllValuationTypeMaster(Searchtext);

            if (dt.Rows.Count > 0)
            {
                lblTotalRecordsPopUp.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();

                gvPopUpGrid.AutoGenerateColumns = true;
                gvPopUpGrid.AllowPaging = true;
                gvPopUpGrid.DataSource = dt;

                if (gvPopUpGrid.PageIndex > (dt.Rows.Count / gvPopUpGrid.PageSize))
                {
                    gvPopUpGrid.SetPageIndex(0);
                }
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
            lblTotalRecordsPopUp.Text = objcommonmessage.NoRecordFound + ex.Message;
            gvPopUpGrid.AllowPaging = false;
            gvPopUpGrid.DataSource = "";
            gvPopUpGrid.DataBind();
        }
    }    

    #endregion

    #region Clear Fields

    public void ClearHeaderItems()
    {
        ddlProcessCode.SelectedValue = "";
        txtBatchNo.Text = "";
        txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        ddlMasterBatchCode.SelectedValue = "";
        FillFinancialYear();
        HidChipsMasterBatchId.Value = "";
        TDBatchNo.Attributes.Add("style", "display:none");
        TDtxtBatchNo.Attributes.Add("style", "display:none");
    }

    public void ClearLineItems()
    {
        HidUpdateGridRecord.Value = "";
        HidMaterialId.Value = "";
        txtMaterialCode.Text = "";
        txtMaterialName.Text = "";
        ddlVendorBatch.SelectedValue = "";
        HidValuationTypeId.Value = "";
        txtValuationType.Text = "";
        ddlStorageLocation.SelectedValue = "";
        txtQuantity.Text = "";
        rdPreparation.Checked = false;
        rdDilution.Checked = false;
        txtCurrentStock.Text = "";
        hidRowIndex.Value = "";
        ImgBtnAddLine.ImageUrl = "../Images/btnAddLine.png";
    }

    #endregion

    #region Fill Form Data

    protected void GetProc_ChipsMasterBatch_LineItems_Trans(int ChipsMasterBatchId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_ChipsMasterBatch.GetProc_ChipsMasterBatch_LineItems_Trans(ChipsMasterBatchId);
            ViewState["LineItem"] = dt;
            gvMasterBatchPrep.DataSource = dt;
            gvMasterBatchPrep.DataBind();
        }
        catch (Exception ex) { }
    }

    private void BindAllChipsMasterBatch(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_ChipsMasterBatch.BindAllChipsMasterBatch(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvAllChipsMasterBatch.DataSource = dt;
                gvAllChipsMasterBatch.AllowPaging = true;
                gvAllChipsMasterBatch.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvAllChipsMasterBatch.AllowPaging = false;
                gvAllChipsMasterBatch.DataSource = "";
                gvAllChipsMasterBatch.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    #endregion
   
}