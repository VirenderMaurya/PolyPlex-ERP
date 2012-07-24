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
    Proc_ServiceAcceptance objProc_ServiceAcceptance = new Proc_ServiceAcceptance();
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblInfo.Text = "";
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Service Acceptance";
            txtVoucherDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

            TDVoucherNo.Attributes.Add("style", "display:none");
            TDtxtVoucherNo.Attributes.Add("style", "display:none");

            #region Bind Masters

            BindSearchList();
            FillFinancialYear();

            #endregion            

            #region Get Line Item Grid Structure

            //Get_PackingCreation_Structure();

            #endregion

            #region Blank Grid

            gvServiceAcceptance.DataSource = "";
            gvServiceAcceptance.DataBind(); 

            #endregion           

            txtVoucherYear.Attributes.Add("readonly", "true");
            txtVoucherNo.Attributes.Add("readonly", "true");
            txtVoucherDate.Attributes.Add("readonly", "true");
            txtPONo.Attributes.Add("readonly", "true");
            txtVendor.Attributes.Add("readonly", "true");
            txtTaxInvoiceDate.Attributes.Add("readonly", "true");
            txtDueDate.Attributes.Add("readonly", "true");
            txtTotalPOValue.Attributes.Add("readonly", "true");
            txtTotalPOFXValue.Attributes.Add("readonly", "true");
            txtVATTotal.Attributes.Add("readonly", "true");
            txtGIATotalValue.Attributes.Add("readonly", "true");

            txtVoucherYear.Attributes.Add("style", "background:lightgray");            
            txtVoucherNo.Attributes.Add("style", "background:lightgray");
            txtVoucherDate.Attributes.Add("style", "background:lightgray");
            txtPONo.Attributes.Add("style", "background:lightgray");
            txtVendor.Attributes.Add("style", "background:lightgray");
            txtTaxInvoiceDate.Attributes.Add("style", "background:lightgray");
            txtDueDate.Attributes.Add("style", "background:lightgray");
            txtTotalPOValue.Attributes.Add("style", "background:lightgray");
            txtTotalPOFXValue.Attributes.Add("style", "background:lightgray");
            txtVATTotal.Attributes.Add("style", "background:lightgray");
            txtGIATotalValue.Attributes.Add("style", "background:lightgray");
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
        ClearGrid();
        ViewState["SelectedRecords"] = null;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        ddlSearch.SelectedValue = "0";
        txtSearch.Text = "";
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindAllServiceAcceptanceList(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
        BindAllServiceAcceptanceList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void imgPONo_Click(object sender, ImageClickEventArgs e)
    {
        FillAllPONo("");
        lPopUpHeader.Text = "PO No";
        lSearch.Text = "Search By PO No: ";
        ModalPopupExtender2.Show();
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        FillAllPONo(txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
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
                HidVendorId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                txtVendor.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;

                #region Bind Details Tab Grid
                HidIsForm.Value = "true";
                BindServiceAcceptanceGrid(Convert.ToInt32(HidPONo.Value), "Form");
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

    protected void gvServiceAcceptanceList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvServiceAcceptanceList = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvServiceAcceptanceList.SelectedIndex = row.RowIndex;

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvServiceAcceptanceList.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            HidAutoId.Value = Convert.ToString(e.CommandArgument);

            #region Bind Form
            HidIsForm.Value = "false";
            GetServiceAcceptanceHeader(Convert.ToInt32(HidAutoId.Value));
            BindServiceAcceptanceGrid(Convert.ToInt32(HidPONo.Value), "List");
            #endregion


            TDVoucherNo.Attributes.Add("style", "display:block");
            TDtxtVoucherNo.Attributes.Add("style", "display:block");
        }
    }

    protected void gvServiceAcceptanceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvServiceAcceptanceList.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllServiceAcceptanceList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvServiceAcceptance_RowDataBound(object sender, GridViewRowEventArgs e)
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
        CheckBox chkAll = (CheckBox)gvServiceAcceptance.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvServiceAcceptance.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvServiceAcceptance.Rows[i].Cells[0].FindControl("chk");
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
        CheckBox chkAll = (CheckBox)gvServiceAcceptance.HeaderRow.Cells[0].FindControl("chkAll");
        if (chkAll.Checked == true)
        {
            chkAll.Checked = false;
        }
        for (int i = 0; i < gvServiceAcceptance.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvServiceAcceptance.Rows[i].Cells[0].FindControl("chk");
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

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Upadte Record Of Header & Grid

            DataTable dtDetailsLineItem = (DataTable)ViewState["SelectedRecords"];

            if (dtDetailsLineItem.Rows.Count > 0)
            {
                #region Insert/Update Records Of Header

                if (HidAutoId.Value == "")
                {
                    objProc_ServiceAcceptance.AutoId = 0;
                }
                else
                {
                    objProc_ServiceAcceptance.AutoId = Convert.ToInt32(HidAutoId.Value);
                }
                objProc_ServiceAcceptance.VoucherYear = txtVoucherYear.Text.Trim();
                if (txtVoucherDate.Text.Trim() != "")
                {
                    objProc_ServiceAcceptance.VoucherDate = DateTime.ParseExact(txtVoucherDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_ServiceAcceptance.VoucherDate = "";
                }
                objProc_ServiceAcceptance.POId = Convert.ToInt32(HidPONo.Value);
                objProc_ServiceAcceptance.VendorId = Convert.ToInt32(HidVendorId.Value);
                objProc_ServiceAcceptance.TaxInvoiceNo = txtTaxInvoiceNo.Text.Trim();
                if (txtTaxInvoiceDate.Text.Trim() != "")
                {
                    objProc_ServiceAcceptance.TaxInvoiceDate = DateTime.ParseExact(txtTaxInvoiceDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_ServiceAcceptance.TaxInvoiceDate = "";
                }
                if (txtDueDate.Text.Trim() != "")
                {
                    objProc_ServiceAcceptance.DueDate = DateTime.ParseExact(txtDueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_ServiceAcceptance.DueDate = "";
                }
                if (txtTotalPOValue.Text.Trim() != "")
                {
                    objProc_ServiceAcceptance.TotalPOValue = Convert.ToDouble(txtTotalPOValue.Text.Trim());
                }
                else
                {
                    objProc_ServiceAcceptance.TotalPOValue = 0;
                }
                if (txtTotalPOFXValue.Text.Trim() != "")
                {
                    objProc_ServiceAcceptance.TotalPOFXValue = Convert.ToDouble(txtTotalPOFXValue.Text.Trim());
                }
                else
                {
                    objProc_ServiceAcceptance.TotalPOFXValue = 0;
                }
                if (txtVATTotal.Text.Trim() != "")
                {
                    objProc_ServiceAcceptance.VATTotal = Convert.ToDouble(txtVATTotal.Text.Trim());
                }
                else
                {
                    objProc_ServiceAcceptance.VATTotal = 0;
                }
                if (txtGIATotalValue.Text.Trim() != "")
                {
                    objProc_ServiceAcceptance.GIATotalValue = Convert.ToDouble(txtGIATotalValue.Text.Trim());
                }
                else
                {
                    objProc_ServiceAcceptance.GIATotalValue = 0;
                }
                objProc_ServiceAcceptance.ActiveStatus = Convert.ToBoolean(1);
                objProc_ServiceAcceptance.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objProc_ServiceAcceptance.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());



                #endregion

                #region Insert/Update Records of Details Tab LineItem

                objProc_ServiceAcceptance.dtLineItems = new DataTable();
                objProc_ServiceAcceptance.dtLineItems = objProc_ServiceAcceptance.GetProc_ServiceAcceptance_LineItems_Trans_Structure();
                DataRow objdrDetailsLineItems;

                if (dtDetailsLineItem.Rows.Count > 0)
                {
                    if (HidIsChecked.Value == "Yes")
                    {
                        foreach (DataRow objdrLineItem in dtDetailsLineItem.Rows)
                        {
                            if (objdrLineItem["IsUpdate"].ToString() == "True")
                            {
                                objdrDetailsLineItems = objProc_ServiceAcceptance.dtLineItems.NewRow();

                                if (HidAutoId.Value == "")
                                {
                                    objdrDetailsLineItems["ServiceAcceptanceId"] = 0;
                                }
                                else
                                {
                                    objdrDetailsLineItems["ServiceAcceptanceId"] = Convert.ToInt32(HidAutoId.Value);
                                }
                                objdrDetailsLineItems["POLineItemId"] = Convert.ToInt32(objdrLineItem["AutoId"].ToString());
                                if (HidIsForm.Value == "false")
                                {
                                    objdrDetailsLineItems["AutoId"] = objdrLineItem["ServiceAcceptanceLineItemId"].ToString();
                                    objdrDetailsLineItems["ActiveStatus"] = false;
                                }
                                else if (HidIsForm.Value == "true")
                                {
                                    objdrDetailsLineItems["AutoId"] = 0;
                                    objdrDetailsLineItems["ActiveStatus"] = objdrLineItem["Active"].ToString();
                                }
                                objProc_ServiceAcceptance.dtLineItems.Rows.Add(objdrDetailsLineItems);
                                objProc_ServiceAcceptance.dtLineItems.AcceptChanges();
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


                FlagInsertUpdate = objProc_ServiceAcceptance.InsertUpdate_In_Proc_ServiceAcceptance();
                if (FlagInsertUpdate == "0")
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                    #region Clear All records after save

                    ClearHeaderItems();
                    ClearGrid();
                    ViewState["SelectedRecords"] = null;

                    gvServiceAcceptance.DataSource = "";
                    gvServiceAcceptance.DataBind();

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
            string FormIdProcServiceAcceptance = ConfigurationManager.AppSettings["FormIdProcServiceAcceptance"].ToString();
            
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProcServiceAcceptance);

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
                    txtVoucherYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    txtVoucherYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch (Exception ex) { }
    }

    private void FillAllPONo(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_ServiceAcceptance.FillAllPONo(Searchtext);

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
        FillFinancialYear();
        txtVoucherNo.Text = "";
        txtVoucherDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        txtPONo.Text = "";
        HidPONo.Value = "";
        HidVendorId.Value = "";
        txtVendor.Text = "";        
        txtTaxInvoiceNo.Text = "";
        txtTaxInvoiceDate.Text = "";        
        txtDueDate.Text = "";
        txtTotalPOValue.Text = "";
        txtTotalPOFXValue.Text = "";       
        txtVATTotal.Text = "";
        txtGIATotalValue.Text = "";
        TDVoucherNo.Attributes.Add("style", "display:none");
        TDtxtVoucherNo.Attributes.Add("style", "display:none");
    }

    private void ClearGrid()
    {
        try
        {
            gvServiceAcceptance.DataSource = "";
            gvServiceAcceptance.DataBind();
        }
        catch { }
    }

    #endregion

    #region Fill Form Data

    protected void BindServiceAcceptanceGrid(int PONo, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_ServiceAcceptance.BindServiceAcceptanceGrid(PONo, SearchType);
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvServiceAcceptance.DataSource = dt;
                gvServiceAcceptance.DataBind();
            }
            else
            {
                gvServiceAcceptance.DataSource = "";
                gvServiceAcceptance.DataBind();
                ViewState["SelectedRecords"] = null;
            }
        }
        catch (Exception ex) { }
    }

    protected void GetServiceAcceptanceHeader(int AutoId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_ServiceAcceptance.BindServiceAcceptanceHeader(AutoId);
            if (dt.Rows.Count > 0)
            {
                HidAutoId.Value = dt.Rows[0]["AutoId"].ToString();
                txtVoucherYear.Text = dt.Rows[0]["VoucherYear"].ToString();
                txtVoucherNo.Text = dt.Rows[0]["VoucherNo"].ToString();
                txtVoucherDate.Text = dt.Rows[0]["VoucherDate"].ToString();
                txtPONo.Text = dt.Rows[0]["PONumber"].ToString();
                HidPONo.Value = dt.Rows[0]["POId"].ToString();
                HidVendorId.Value = dt.Rows[0]["VendorId"].ToString();
                txtVendor.Text = dt.Rows[0]["VendorCodeName"].ToString();
                txtTaxInvoiceNo.Text = dt.Rows[0]["TaxInvoiceNo"].ToString();
                txtTaxInvoiceDate.Text = dt.Rows[0]["TaxInvoiceDate"].ToString();
                txtDueDate.Text = dt.Rows[0]["DueDate"].ToString();
                txtTotalPOValue.Text = dt.Rows[0]["TotalPOValue"].ToString();
                txtTotalPOFXValue.Text = dt.Rows[0]["TotalPOFXValue"].ToString();
                txtVATTotal.Text = dt.Rows[0]["VATTotal"].ToString();
                txtGIATotalValue.Text = dt.Rows[0]["GIATotalValue"].ToString();                                
            }
        }
        catch (Exception ex) { }
    }

    private void BindAllServiceAcceptanceList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_ServiceAcceptance.BindAllServiceAcceptanceList(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvServiceAcceptanceList.DataSource = dt;
                gvServiceAcceptanceList.AllowPaging = true;
                gvServiceAcceptanceList.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvServiceAcceptanceList.AllowPaging = false;
                gvServiceAcceptanceList.DataSource = "";
                gvServiceAcceptanceList.DataBind();
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

            CheckBox chkAll = (CheckBox)gvServiceAcceptance.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvServiceAcceptance.Rows.Count; i++)
            {

                if (chkAll.Checked)
                {
                    dt = AddRow(gvServiceAcceptance.Rows[i], dt);
                    CheckBox chk = (CheckBox)gvServiceAcceptance.Rows[i].Cells[0].FindControl("chk");
                }
                else
                {
                    CheckBox chk = (CheckBox)gvServiceAcceptance.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        dt = AddRow(gvServiceAcceptance.Rows[i], dt);
                    }
                    else
                    {
                        dt = RemoveRow(gvServiceAcceptance.Rows[i], dt);
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