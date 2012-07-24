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
    Proc_GoodsReceipt objProc_GoodsReceipt = new Proc_GoodsReceipt();
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblInfo.Text = "";
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Goods Receipt";
            TCGoodsReceipt.ActiveTabIndex = 0;
            TDGRNo.Attributes.Add("style", "display:none");
            TDtxtGRNo.Attributes.Add("style", "display:none");
            int PalletNo = RandomNumber(100000000, 999999999);
            txtBatchNo.Text = Convert.ToString(PalletNo);

            #region Bind Masters

            BindSearchList();
            FillFinancialYear();

            #endregion            

            #region Get Line Item Grid Structure

            GetProc_GoodsReceipt_OtherDetails_Trans(0);

            #endregion

            #region Blank Grid

            gvDetails.DataSource = "";
            gvDetails.DataBind();
            gvOtherDetails.DataSource = "";
            gvOtherDetails.DataBind();

            #endregion           
           
            txtGRDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

            #region ReadOnlyFields

            txtGRYear.Attributes.Add("readonly", "true");
            txtGRNo.Attributes.Add("readonly", "true");          
            txtGRDate.Attributes.Add("readonly", "true");           
            txtPONo.Attributes.Add("readonly", "true");
            txtVendor.Attributes.Add("readonly", "true");
            txtBillofEntryDate.Attributes.Add("readonly", "true");
            txtExchangeRate.Attributes.Add("readonly", "true");
            txtDueDate.Attributes.Add("readonly", "true");
            txtMaterialCost.Attributes.Add("readonly", "true");
            txtVATTotal.Attributes.Add("readonly", "true");
            txtGIATotalValue.Attributes.Add("readonly", "true");
            txtTotalStockUOM.Attributes.Add("readonly", "true");
            txtBalanceQuantity.Attributes.Add("readonly", "true");
            txtGateEntryDate.Attributes.Add("readonly", "true");
            txtTaxInvoiceDate.Attributes.Add("readonly", "true");
            txtBatchNo.Attributes.Add("readonly", "true");
            txtManufactureDate.Attributes.Add("readonly", "true");
            txtExpirationDate.Attributes.Add("readonly", "true");

            #endregion

            #region Gray Color Fields

            txtGRYear.Attributes.Add("style", "background:lightgray");
            txtGRNo.Attributes.Add("style", "background:lightgray");
            txtGRDate.Attributes.Add("style", "background:lightgray");
            txtPONo.Attributes.Add("style", "background:lightgray");
            txtVendor.Attributes.Add("style", "background:lightgray");
            txtBillofEntryDate.Attributes.Add("style", "background:lightgray");
            txtExchangeRate.Attributes.Add("style", "background:lightgray");
            txtDueDate.Attributes.Add("style", "background:lightgray");
            txtMaterialCost.Attributes.Add("style", "background:lightgray");
            txtVATTotal.Attributes.Add("style", "background:lightgray");
            txtGIATotalValue.Attributes.Add("style", "background:lightgray");
            txtTotalStockUOM.Attributes.Add("style", "background:lightgray");
            txtBalanceQuantity.Attributes.Add("style", "background:lightgray");
            txtGateEntryDate.Attributes.Add("style", "background:lightgray");
            txtTaxInvoiceDate.Attributes.Add("style", "background:lightgray");
            txtBatchNo.Attributes.Add("style", "background:lightgray");
            txtManufactureDate.Attributes.Add("style", "background:lightgray");
            txtExpirationDate.Attributes.Add("style", "background:lightgray");

            #endregion
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
        ClearAllGrid();
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        ddlSearch.SelectedValue = "0";
        txtSearch.Text = "";
        ViewState["LineItem"] = null;
        ViewState["SelectedRecords"] = null;
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindAllGoodsReceiptList(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
        BindAllGoodsReceiptList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        FillAllPONo(txtSearchFromPopup.Text.Trim());        
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void imgPONo_Click(object sender, ImageClickEventArgs e)
    {        
        FillAllPONo("");
        lPopUpHeader.Text = "PO No";
        lSearch.Text = "Search By PO No: ";
        ModalPopupExtender2.Show();
    }   

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
            }
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

                HidPONo.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                txtPONo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                txtExchangeRate.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                HidVendorId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                txtVendor.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;

                #region Bind Details Tab Grid     
                HidIsForm.Value = "true";
                BindDetailsTabGrid(Convert.ToInt32(HidPONo.Value), "Form");
                #endregion

            }
        }
        catch { }
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        FillAllPONo(txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void gvOtherDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvOtherDetails = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvOtherDetails.SelectedIndex = row.RowIndex + 1;

        DataTable objdtLineItem = new DataTable();
        objdtLineItem = (DataTable)ViewState["LineItem"];

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvOtherDetails.Rows)
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

                txtBatchNo.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["BatchNo"].ToString();
                txtVendorBatchNo.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["VendorBatchNo"].ToString();
                txtQuantityAcceptedStockUOM.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["QuantityAcceptedStockUOM"].ToString();
                txtManufactureDate.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ManufactureDate"].ToString();
                txtExpirationDate.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ExpirationDate"].ToString();
                txtLifeInDays.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LifeInDays"].ToString();
                ImgBtnAddLine.ImageUrl = "../Images/btnUpdateLine.png";
            }
        }
    }

    protected void gvGoodsReceiptList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvGoodsReceiptList = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvGoodsReceiptList.SelectedIndex = row.RowIndex;

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvGoodsReceiptList.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            HidAutoId.Value = Convert.ToString(e.CommandArgument);

            #region Bind Form
            HidIsForm.Value = "false";
            GetProc_GoodsReceipt_Header_Trans(Convert.ToInt32(HidAutoId.Value));
            BindDetailsTabGrid(Convert.ToInt32(HidPONo.Value), "List");
            GetProc_GoodsReceipt_OtherDetails_Trans(Convert.ToInt32(HidAutoId.Value));

            #endregion


            TDGRNo.Attributes.Add("style", "display:block");
            TDtxtGRNo.Attributes.Add("style", "display:block");
        }
    }

    protected void gvGoodsReceiptList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGoodsReceiptList.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllGoodsReceiptList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void chkAll_CheckChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvDetails.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvDetails.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvDetails.Rows[i].Cells[0].FindControl("chk");
            if (chkAll.Checked == true)
            {
                chk.Checked = true;
            }
            if (chkAll.Checked == false)
            {
                chk.Checked = false;
            }
        }
        HidIsChecked.Value = "Yes";
        GetData();        
    }

    protected void chk_CheckChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvDetails.HeaderRow.Cells[0].FindControl("chkAll");
        if (chkAll.Checked == true)
        {
            chkAll.Checked = false;
        }
        for (int i = 0; i < gvDetails.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvDetails.Rows[i].Cells[0].FindControl("chk");
            chkAll.Checked = true;
            if (chk.Checked == false)
            {
                chkAll.Checked = false;
                break;
            }
        }
        HidIsChecked.Value = "Yes";
        GetData();        
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
                if (HidAutoId.Value != "")
                {
                    objdrLineItem["GoodsReceiptId"] = Convert.ToInt32(HidAutoId.Value);
                }
                else
                {
                    objdrLineItem["GoodsReceiptId"] = 0;
                }
                objdrLineItem["BatchNo"] = txtBatchNo.Text.Trim();
                objdrLineItem["VendorBatchNo"] = txtVendorBatchNo.Text.Trim();
                objdrLineItem["QuantityAcceptedStockUOM"] = txtQuantityAcceptedStockUOM.Text.Trim();
                objdrLineItem["ManufactureDate"] = txtManufactureDate.Text.Trim();
                objdrLineItem["ExpirationDate"] = txtExpirationDate.Text.Trim();
                objdrLineItem["LifeInDays"] = Convert.ToInt32(txtLifeInDays.Text.Trim());
                objdrLineItem["ActiveStatus"] = true;
                objdtLineItem.Rows.Add(objdrLineItem);
            }
            else if (HidUpdateGridRecord.Value == "Yes") //For Update record
            {
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["IsUpdate"] = "Yes";
                if (HidAutoId.Value != "")
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["GoodsReceiptId"] = Convert.ToInt32(HidAutoId.Value);
                }
                else
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["GoodsReceiptId"] = 0;
                }
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["VendorBatchNo"] = txtVendorBatchNo.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["QuantityAcceptedStockUOM"] = txtQuantityAcceptedStockUOM.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ManufactureDate"] = txtManufactureDate.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ExpirationDate"] = txtExpirationDate.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LifeInDays"] = Convert.ToInt32(txtLifeInDays.Text.Trim());
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ActiveStatus"] = true;
                objdtLineItem.AcceptChanges();
            }
            ViewState["LineItem"] = objdtLineItem;
            gvOtherDetails.DataSource = objdtLineItem;
            gvOtherDetails.DataBind();
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
            DataTable dtDetailsLineItem = (DataTable)ViewState["SelectedRecords"];

            if (dtLineItem.Rows.Count > 0)
            {
                #region Insert/Update Records Of Header

                if (HidAutoId.Value == "")
                {
                    objProc_GoodsReceipt.AutoId = 0;
                }
                else
                {
                    objProc_GoodsReceipt.AutoId = Convert.ToInt32(HidAutoId.Value);
                }
                objProc_GoodsReceipt.GRYear = txtGRYear.Text.Trim();
                if (txtGRDate.Text.Trim() != "")
                {
                    objProc_GoodsReceipt.GRDate = DateTime.ParseExact(txtGRDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_GoodsReceipt.GRDate = "";
                }
                objProc_GoodsReceipt.POId = Convert.ToInt32(HidPONo.Value);
                if (HidVendorId.Value != "")
                {
                    objProc_GoodsReceipt.VendorId = Convert.ToInt32(HidVendorId.Value);
                }
                else
                {
                    objProc_GoodsReceipt.VendorId = 0;
                }
                objProc_GoodsReceipt.GateEntryNo = txtGateEntryNo.Text.Trim();
                if (txtGateEntryDate.Text.Trim() != "")
                {
                    objProc_GoodsReceipt.GateEntryDate = DateTime.ParseExact(txtGateEntryDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_GoodsReceipt.GateEntryDate = "";
                }
                objProc_GoodsReceipt.TaxInvoiceNo = txtTaxInvoiceNo.Text.Trim();
                if (txtTaxInvoiceDate.Text.Trim() != "")
                {
                    objProc_GoodsReceipt.TaxInvoiceDate = DateTime.ParseExact(txtTaxInvoiceDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_GoodsReceipt.TaxInvoiceDate = "";
                }
                objProc_GoodsReceipt.SalesOrder = txtSalesOrder.Text.Trim();
                objProc_GoodsReceipt.VehicleNo = txtVehicleNo.Text.Trim();
                if (txtDueDate.Text.Trim() != "")
                {
                    objProc_GoodsReceipt.DueDate = DateTime.ParseExact(txtDueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_GoodsReceipt.DueDate = "";
                }
                objProc_GoodsReceipt.BillofEntryNo = txtBillofEntryNo.Text.Trim();
                if (txtBillofEntryDate.Text.Trim() != "")
                {
                    objProc_GoodsReceipt.BillofEntryDate = DateTime.ParseExact(txtBillofEntryDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_GoodsReceipt.BillofEntryDate = "";
                }
                if (txtExchangeRate.Text != "")
                {
                    objProc_GoodsReceipt.ExchangeRate = Convert.ToDouble(txtExchangeRate.Text.Trim());
                }
                else
                {
                    objProc_GoodsReceipt.ExchangeRate = 0;
                }
                if (txtMaterialCost.Text != "")
                {
                    objProc_GoodsReceipt.MaterialCost = Convert.ToDouble(txtMaterialCost.Text.Trim());
                }
                else
                {
                    objProc_GoodsReceipt.MaterialCost = 0;
                }
                if (txtVATTotal.Text != "")
                {
                    objProc_GoodsReceipt.VATTotal = Convert.ToDouble(txtVATTotal.Text.Trim());
                }
                else
                {
                    objProc_GoodsReceipt.VATTotal = 0;
                }
                if (txtGIATotalValue.Text != "")
                {
                    objProc_GoodsReceipt.GIATotalValue = Convert.ToDouble(txtGIATotalValue.Text.Trim());
                }
                else
                {
                    objProc_GoodsReceipt.GIATotalValue = 0;
                }
                if (txtTotalStockUOM.Text != "")
                {
                    objProc_GoodsReceipt.TotalStockUOM = Convert.ToDouble(txtTotalStockUOM.Text.Trim());
                }
                else
                {
                    objProc_GoodsReceipt.TotalStockUOM = 0;
                }
                if (txtBalanceQuantity.Text != "")
                {
                    objProc_GoodsReceipt.BalanceQuantity = Convert.ToDouble(txtBalanceQuantity.Text.Trim());
                }
                else
                {
                    objProc_GoodsReceipt.BalanceQuantity = 0;
                }
                objProc_GoodsReceipt.ActiveStatus = Convert.ToBoolean(1);
                objProc_GoodsReceipt.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objProc_GoodsReceipt.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                #endregion

                #region Insert/Update Records of Details Tab LineItem

                objProc_GoodsReceipt.dtDetailsLineItems = new DataTable();
                objProc_GoodsReceipt.dtDetailsLineItems = objProc_GoodsReceipt.GetProc_GoodsReceipt_DetailsLineItems_Trans_Structure();
                DataRow objdrDetailsLineItems;

                if (dtDetailsLineItem.Rows.Count > 0)
                {
                    if (HidIsChecked.Value == "Yes")
                    {
                        foreach (DataRow objdrLineItem in dtDetailsLineItem.Rows)
                        {
                            if (objdrLineItem["IsUpdate"].ToString() == "True")
                            {
                                objdrDetailsLineItems = objProc_GoodsReceipt.dtDetailsLineItems.NewRow();

                                if (HidAutoId.Value == "")
                                {
                                    objdrDetailsLineItems["GoodsReceiptId"] = 0;
                                }
                                else
                                {
                                    objdrDetailsLineItems["GoodsReceiptId"] = Convert.ToInt32(HidAutoId.Value);
                                }
                                objdrDetailsLineItems["POLineItemId"] = Convert.ToInt32(objdrLineItem["AutoId"].ToString());
                                if (HidIsForm.Value == "false")
                                {
                                    objdrDetailsLineItems["AutoId"] = objdrLineItem["GRDetailsLineItemId"].ToString();
                                    objdrDetailsLineItems["ActiveStatus"] = false;
                                }
                                else if (HidIsForm.Value == "true")
                                {
                                    objdrDetailsLineItems["AutoId"] = 0;
                                    objdrDetailsLineItems["ActiveStatus"] = objdrLineItem["Active"].ToString();
                                }
                                objProc_GoodsReceipt.dtDetailsLineItems.Rows.Add(objdrDetailsLineItems);
                                objProc_GoodsReceipt.dtDetailsLineItems.AcceptChanges();
                            }
                        }
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectLineItem, 125, 300);
                        return;
                    }
                }

                #endregion

                #region Insert/Update Records of LineItem

                objProc_GoodsReceipt.dtLineItems = new DataTable();
                objProc_GoodsReceipt.dtLineItems = objProc_GoodsReceipt.GetProc_GoodsReceipt_OtherDetails_LineItems_Structure();
                DataRow objdrLineItems;

                if (dtLineItem.Rows.Count > 0)
                {
                    foreach (DataRow objdrLineItem in dtLineItem.Rows)
                    {
                        try
                        {
                            if ((objdrLineItem["LineItemID"].ToString() == "0" && objdrLineItem["IsUpdate"].ToString() == "") || (objdrLineItem["LineItemID"].ToString() != "0" &&
                                objdrLineItem["IsUpdate"].ToString() == "Yes") || (objdrLineItem["LineItemID"].ToString() == "0" && objdrLineItem["IsUpdate"].ToString() == "Yes"))
                            {
                                objdrLineItems = objProc_GoodsReceipt.dtLineItems.NewRow();

                                objdrLineItems["LineItemID"] = Convert.ToInt32(objdrLineItem["LineItemID"].ToString());                               
                                if (HidAutoId.Value == "")
                                {
                                    objdrLineItems["GoodsReceiptId"] = 0;
                                }
                                else
                                {
                                    objdrLineItems["GoodsReceiptId"] = Convert.ToInt32(HidAutoId.Value);
                                }

                                objdrLineItems["BatchNo"] = objdrLineItem["BatchNo"].ToString();
                                objdrLineItems["VendorBatchNo"] = objdrLineItem["VendorBatchNo"].ToString();
                                objdrLineItems["QuantityAcceptedStockUOM"] = objdrLineItem["QuantityAcceptedStockUOM"].ToString();
                                if (objdrLineItem["ManufactureDate"].ToString() != "")
                                {
                                    objdrLineItems["ManufactureDate"] = DateTime.ParseExact(objdrLineItem["ManufactureDate"].ToString(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                                }
                                else
                                {
                                    objdrLineItems["ManufactureDate"] = DBNull.Value;
                                }
                                if (objdrLineItem["ExpirationDate"].ToString() != "")
                                {
                                    objdrLineItems["ExpirationDate"] = DateTime.ParseExact(objdrLineItem["ExpirationDate"].ToString(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                                }
                                else
                                {
                                    objdrLineItems["ExpirationDate"] = DBNull.Value;
                                }
                                objdrLineItems["LifeInDays"] = Convert.ToInt32(objdrLineItem["LifeInDays"].ToString());
                                objdrLineItems["ActiveStatus"] = objdrLineItem["ActiveStatus"].ToString();

                                objProc_GoodsReceipt.dtLineItems.Rows.Add(objdrLineItems);
                                objProc_GoodsReceipt.dtLineItems.AcceptChanges();
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

                FlagInsertUpdate = objProc_GoodsReceipt.InsertUpdate_In_Proc_GoodsReceipt();
                if (FlagInsertUpdate == "0")
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                    #region Clear All records after save

                    ClearHeaderItems();
                    ClearLineItems();
                    ClearAllGrid();
                    ViewState["LineItem"] = null;
                    ViewState["SelectedRecords"] = null;

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

    #region  Fill Masters

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdProcGoodsReceipt = ConfigurationManager.AppSettings["FormIdProcGoodsReceipt"].ToString();
            
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProcGoodsReceipt);

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
                    txtGRYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    txtGRYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch (Exception ex) { }
    }    

    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    private void FillAllPONo(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_GoodsReceipt.FillAllPONo(Searchtext);

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

    #region Clear Form Data

    public void ClearHeaderItems()
    {
        HidAutoId.Value = "";
        txtGRYear.Text = "";
        txtGRNo.Text = "";
        txtGRDate.Text = "";
        txtPONo.Text = "";
        HidPONo.Value = "";
        txtVendor.Text = "";
        HidVendorId.Value = "";        
        txtGateEntryNo.Text = "";
        txtGateEntryDate.Text = "";
        txtTaxInvoiceNo.Text = "";
        txtTaxInvoiceDate.Text = "";
        txtSalesOrder.Text = "";
        txtVehicleNo.Text = "";
        txtDueDate.Text = "";
        txtBillofEntryNo.Text = "";
        txtBillofEntryDate.Text = "";
        txtExchangeRate.Text = "";
        txtMaterialCost.Text = "";
        txtVATTotal.Text = "";
        txtGIATotalValue.Text = "";
        txtTotalStockUOM.Text = "";
        txtBalanceQuantity.Text = "";
        TDGRNo.Attributes.Add("style", "display:none");
        TDtxtGRNo.Attributes.Add("style", "display:none");
    }

    public void ClearLineItems()
    {
        HidUpdateGridRecord.Value = "";
        int PalletNo = RandomNumber(100000000, 999999999);
        txtBatchNo.Text = Convert.ToString(PalletNo);
        txtVendorBatchNo.Text = "";
        txtQuantityAcceptedStockUOM.Text = "";
        txtManufactureDate.Text = "";
        txtExpirationDate.Text = "";
        txtLifeInDays.Text = "";
        hidRowIndex.Value = "";
        HidUpdateGridRecord.Value = "";
        hidLineItemId.Value = "";
        ImgBtnAddLine.ImageUrl = "../Images/btnAddLine.png";
    }

    private void ClearAllGrid()
    {
        try
        {
            gvDetails.DataSource = "";
            gvDetails.DataBind();
            gvOtherDetails.DataSource = "";
            gvOtherDetails.DataBind();
        }
        catch { }
    }

    #endregion
    
    #region Fill Form Data

    protected void BindDetailsTabGrid(int PONo, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_GoodsReceipt.BindDetailsTabGrid(PONo,SearchType);
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvDetails.DataSource = dt;
                gvDetails.DataBind();                
            }
            else
            {
                gvDetails.DataSource = "";
                gvDetails.DataBind();                
                ViewState["SelectedRecords"] = null;
            }           
        }
        catch (Exception ex) { }
    }

    protected void GetProc_GoodsReceipt_OtherDetails_Trans(int AutoId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_GoodsReceipt.GetProc_GoodsReceipt_OtherDetails_Trans(AutoId);
            ViewState["LineItem"] = dt;
            gvOtherDetails.DataSource = dt;
            gvOtherDetails.DataBind();
        }
        catch (Exception ex) { }
    }

    protected void GetProc_GoodsReceipt_Header_Trans(int AutoId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_GoodsReceipt.GetProc_GoodsReceipt_Header_Trans(AutoId);
            if (dt.Rows.Count > 0)
            {
                HidAutoId.Value = dt.Rows[0]["AutoId"].ToString();
                txtGRYear.Text = dt.Rows[0]["GRYear"].ToString();
                txtGRNo.Text = dt.Rows[0]["GRNo"].ToString();
                txtGRDate.Text = dt.Rows[0]["GRDate"].ToString();
                txtPONo.Text = dt.Rows[0]["PONumber"].ToString();
                HidPONo.Value = dt.Rows[0]["POId"].ToString();
                txtVendor.Text = dt.Rows[0]["VendorCodeName"].ToString();
                HidVendorId.Value = dt.Rows[0]["VendorId"].ToString();
                txtGateEntryNo.Text = dt.Rows[0]["GateEntryNo"].ToString();
                txtGateEntryDate.Text = dt.Rows[0]["GateEntryDate"].ToString();
                txtTaxInvoiceNo.Text = dt.Rows[0]["TaxInvoiceNo"].ToString();
                txtTaxInvoiceDate.Text = dt.Rows[0]["TaxInvoiceDate"].ToString();
                txtSalesOrder.Text = dt.Rows[0]["SalesOrder"].ToString();
                txtVehicleNo.Text = dt.Rows[0]["VehicleNo"].ToString();
                txtDueDate.Text = dt.Rows[0]["DueDate"].ToString();
                txtBillofEntryNo.Text = dt.Rows[0]["BillofEntryNo"].ToString();
                txtBillofEntryDate.Text = dt.Rows[0]["BillofEntryDate"].ToString();
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                txtMaterialCost.Text = dt.Rows[0]["MaterialCost"].ToString();
                txtVATTotal.Text = dt.Rows[0]["VATTotal"].ToString();
                txtGIATotalValue.Text = dt.Rows[0]["GIATotalValue"].ToString();
                txtTotalStockUOM.Text = dt.Rows[0]["TotalStockUOM"].ToString();
                txtBalanceQuantity.Text = dt.Rows[0]["BalanceQuantity"].ToString();
                TDGRNo.Attributes.Add("style", "display:block");
                TDtxtGRNo.Attributes.Add("style", "display:block");
            }
        }
        catch (Exception ex) { }
    }

    private void BindAllGoodsReceiptList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_GoodsReceipt.BindAllGoodsReceiptList(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvGoodsReceiptList.DataSource = dt;
                gvGoodsReceiptList.AllowPaging = true;
                gvGoodsReceiptList.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvGoodsReceiptList.AllowPaging = false;
                gvGoodsReceiptList.DataSource = "";
                gvGoodsReceiptList.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    private void GetData()
    {
        try
        {
            DataTable dt;
            dt = (DataTable)ViewState["SelectedRecords"];

            CheckBox chkAll = (CheckBox)gvDetails.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvDetails.Rows.Count; i++)
            {

                if (chkAll.Checked)
                {
                    dt = AddRow(gvDetails.Rows[i], dt);
                    CheckBox chk = (CheckBox)gvDetails.Rows[i].Cells[0].FindControl("chk");
                }
                else
                {
                    CheckBox chk = (CheckBox)gvDetails.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        dt = AddRow(gvDetails.Rows[i], dt);
                    }
                    else
                    {
                        dt = RemoveRow(gvDetails.Rows[i], dt);
                    }
                }
            }
            ViewState["SelectedRecords"] = dt;
        }
        catch { }
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        try
        {
            DataRow[] dr = dt.Select("AutoId = '" + gvRow.Cells[1].Text + "'");           
            dt.Rows[gvRow.RowIndex]["IsUpdate"] = "True";
            dt.Rows[gvRow.RowIndex]["Active"] = true;
            dt.AcceptChanges();
            return dt;
        }
        catch
        {
            return dt = null;
        }

    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        try
        {
            DataRow[] dr = dt.Select("AutoId = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length > 0)
            {
                if (HidIsForm.Value == "true")
                {
                    dt.Rows[gvRow.RowIndex]["IsUpdate"] = "False";
                }
                else
                {
                    dt.Rows[gvRow.RowIndex]["IsUpdate"] = "True";
                }
                dt.Rows[gvRow.RowIndex]["Active"] = false;
                dt.AcceptChanges();
            }
            return dt;
        }
        catch
        {
            return dt = null;
        }
    }

    #endregion
    
}