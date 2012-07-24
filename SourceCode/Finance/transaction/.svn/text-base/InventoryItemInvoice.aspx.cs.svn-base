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
    CreditDebitNoteProposal_Tran objCreditDebitNoteProposal_Tran = new CreditDebitNoteProposal_Tran();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();
    FA_InventoryItemInvoice objFA_InventoryItemInvoice = new FA_InventoryItemInvoice();
    int FlagInsert;
    string str, SearchValueofList;
    static string MasterPageType;
    double totalWeight;
    int totalItems = 0;
    double Width, Length;
    string FlagInsertUpdate, SaveStatus;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Inventory Item Invoice";

            TDLableSWBN.Attributes.Add("style", "display:none");
            TDtxtSWBN.Attributes.Add("style", "display:none");
           
            HidVat.Value = "4";
            txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

            #region Bind Masters
            
            BindSearchList();
            FillFinancialYear();


            #endregion

            #region Bind Blank Grid

            Get_ItemInventoryDetail(0);           
           
            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Change Color of Readonly Fields
           
            txtSalesWaybillNo.Attributes.Add("style", "background:lightgray");
            txtSalesType.Attributes.Add("style", "background:lightgray");
            txtYear.Attributes.Add("style", "background:lightgray");
            txtInvoiceNo.Attributes.Add("style", "background:lightgray");
            txtDate.Attributes.Add("style", "background:lightgray");
            txtDueDate.Attributes.Add("style", "background:lightgray");
            txtCustomerCode.Attributes.Add("style", "background:lightgray");
            txtCustomerName.Attributes.Add("style", "background:lightgray");
            txtSalesOrderNo.Attributes.Add("style", "background:lightgray");
            txtSalesOrderDate.Attributes.Add("style", "background:lightgray");
            txtCurrency.Attributes.Add("style", "background:lightgray");
            txtBaseAmount.Attributes.Add("style", "background:lightgray");
            txtVATAmount.Attributes.Add("style", "background:lightgray");
            txtNetInvoiceAmt.Attributes.Add("style", "background:lightgray");

            #endregion            

            txtSalesWaybillNo.Attributes.Add("readonly", "true");
            txtSalesType.Attributes.Add("readonly", "true");
            txtYear.Attributes.Add("readonly", "true");
            txtInvoiceNo.Attributes.Add("readonly", "true");
            txtDate.Attributes.Add("readonly", "true");
            txtDueDate.Attributes.Add("readonly", "true");
            txtCustomerCode.Attributes.Add("readonly", "true");
            txtCustomerName.Attributes.Add("readonly", "true");
            txtSalesOrderNo.Attributes.Add("readonly", "true");
            txtSalesOrderDate.Attributes.Add("readonly", "true");
            txtCurrency.Attributes.Add("readonly", "true");
            txtBaseAmount.Attributes.Add("readonly", "true");
            txtVATAmount.Attributes.Add("readonly", "true");
            txtNetInvoiceAmt.Attributes.Add("readonly", "true"); 
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
        ClearForm();
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            Get_AllItemInventoryInvoice(txtSearch.Text.Trim());
            lSearchList.Text = "Search By SalesWayBill No.: ";     
            ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }
    
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Upadte Record Of Header & Line Item

            DataTable dtLineItem = (DataTable)ViewState["LineItem"];

            #region Insert/Update Records Of Header

            if (HidAutoIdHeader.Value == "")
            {
                objFA_InventoryItemInvoice.AutoId= 0;
            }
            else
            {
                objFA_InventoryItemInvoice.AutoId = Convert.ToInt32(HidAutoIdHeader.Value);
            }
            objFA_InventoryItemInvoice.SalesWayBillNo = txtSalesWaybillNo.Text.Trim();
            objFA_InventoryItemInvoice.SalesTypeId = Convert.ToInt32(hidSalesType.Value);
            objFA_InventoryItemInvoice.Year = txtYear.Text.Trim();
            objFA_InventoryItemInvoice.InvoiceId = Convert.ToInt32(HidInvoiceId.Value);
            objFA_InventoryItemInvoice.Date = DateTime.ParseExact(txtDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            objFA_InventoryItemInvoice.DueDate = DateTime.ParseExact(txtDueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            objFA_InventoryItemInvoice.CustomerId = Convert.ToInt32(HidCustomerId.Value);
            objFA_InventoryItemInvoice.SalesOrderId = Convert.ToInt32(HidSalesOrderId.Value);
            objFA_InventoryItemInvoice.SalesOrderDate = DateTime.ParseExact(txtSalesOrderDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            objFA_InventoryItemInvoice.CurrencyId = Convert.ToInt32(HidCurrencyId.Value);
            objFA_InventoryItemInvoice.ExchangeRate = Convert.ToDouble (txtExchangeRate.Text.Trim());
            objFA_InventoryItemInvoice.FixedAmount = Convert.ToDouble(txtAmountInFX.Text.Trim());
            if (txtBaseAmount.Text.Trim() != "")
            {
                objFA_InventoryItemInvoice.BaseAmount = Convert.ToDouble(txtBaseAmount.Text.Trim());
            }
            else
            {
                objFA_InventoryItemInvoice.BaseAmount = 0;
            }
            if (txtVATAmount.Text.Trim() != "")
            {
                objFA_InventoryItemInvoice.VatAmount = Convert.ToDouble(txtVATAmount.Text.Trim());
            }
            else
            {
                objFA_InventoryItemInvoice.VatAmount = 0;
            }
            if (txtNetInvoiceAmt.Text.Trim() != "")
            {
                objFA_InventoryItemInvoice.NetInvoiceAmount = Convert.ToDouble(txtNetInvoiceAmt.Text.Trim());
            }
            else
            {
                objFA_InventoryItemInvoice.NetInvoiceAmount = 0;
            }
            objFA_InventoryItemInvoice.ActiveStatus = true;
            objFA_InventoryItemInvoice.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
            objFA_InventoryItemInvoice.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

            #endregion

            #region Insert/Update Records of LineItem

            objFA_InventoryItemInvoice.dtItemInventory = new DataTable();
            objFA_InventoryItemInvoice.dtItemInventory = objFA_InventoryItemInvoice.Get_ItemInventoryDetail (0);
            DataRow objdrItemInventory;

            if (dtLineItem.Rows.Count > 0)
            {
                foreach (DataRow objdrLineItem in dtLineItem.Rows)
                {
                    try
                    {
                        objdrItemInventory = objFA_InventoryItemInvoice.dtItemInventory.NewRow();
                        objdrItemInventory["AutoId"] = Convert.ToInt32 (objdrLineItem["AutoId"].ToString());
                        objdrItemInventory["MaterialDescription"] = objdrLineItem["MaterialDescription"].ToString();
                        objdrItemInventory["Quantity"] =Convert.ToDouble (objdrLineItem["Quantity"].ToString());
                        objdrItemInventory["UOM"] = objdrLineItem["UOM"].ToString();
                        objdrItemInventory["MaterialCost"] = Convert.ToDouble (objdrLineItem["MaterialCost"].ToString());
                        objdrItemInventory["SaleRate"] = Convert.ToDouble (objdrLineItem["SaleRate"].ToString());
                        objFA_InventoryItemInvoice.dtItemInventory.Rows.Add(objdrItemInventory);
                        objFA_InventoryItemInvoice.dtItemInventory.AcceptChanges();
                    }
                    catch
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.LineItemNotSaved, 125, 300);
                        return;
                    }
                }
            }

            #endregion

            FlagInsertUpdate = objFA_InventoryItemInvoice.InsertUpdate_In_FA_Glb_ItemInventoryInvoice_Tran();
            if (FlagInsertUpdate == "YES")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                #region Clear All records after save

                ClearHeaderControls();
                Get_ItemInventoryDetail(0);

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

            #endregion
        }
        catch { }
    }

    protected void imgSalesType_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "SalesType";
        lPopUpHeader.Text = "Type Of Sales";
        lSearch.Text = "Search By Name: ";
        BindSalesTypeMaster("");
        ModalPopupExtender2.Show();
    }

    protected void imgInvoiceNo_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "InvoiceId";
        BindAllInvoices("");
        lPopUpHeader.Text = "Invoice";
        lSearch.Text = "Search By Invoice No: ";
        ModalPopupExtender2.Show();
    }

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (HidPopUpType.Value == "SalesType")
            {
                if (e.Row.RowType != DataControlRowType.EmptyDataRow)
                {
                    e.Row.Cells[1].Style.Add("display", "none");
                }
            }
            else if (HidPopUpType.Value == "InvoiceId")
            {
                if (e.Row.RowType != DataControlRowType.EmptyDataRow)
                {
                    e.Row.Cells[1].Style.Add("display", "none");
                    e.Row.Cells[3].Style.Add("display", "none");
                    e.Row.Cells[5].Style.Add("display", "none");
                    e.Row.Cells[8].Style.Add("display", "none");
                    e.Row.Cells[9].Style.Add("display", "none");
                    e.Row.Cells[10].Style.Add("display", "none");
                }
            }
        }
        catch (Exception ex)
        {
        }
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

                if (HidPopUpType.Value == "SalesType")
                {
                    hidSalesType.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtSalesType.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                }
                else if (HidPopUpType.Value == "InvoiceId")
                {
                    HidInvoiceId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    HidSalesOrderId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                    HidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                    txtInvoiceNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    txtSalesOrderNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                    txtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;
                    txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                    txtSalesOrderDate.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[8].Text;
                    txtCurrency.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[9].Text;
                    HidCurrencyId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[10].Text;
                }
            }
        }
        catch { }
    }

    protected void gvInventoryItemList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
                e.Row.Cells[18].Style.Add("display", "none");
                e.Row.Cells[19].Style.Add("display", "none");
                e.Row.Cells[20].Style.Add("display", "none");
                e.Row.Cells[21].Style.Add("display", "none");
                e.Row.Cells[22].Style.Add("display", "none");
                e.Row.Cells[23].Style.Add("display", "none");
                e.Row.Cells[24].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvInventoryItemList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvInventoryItemList = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvInventoryItemList.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvInventoryItemList.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidAutoIdHeader.Value = Convert.ToString( e.CommandArgument);
                txtSalesWaybillNo.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[2].Text;
                hidSalesType.Value = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[3].Text;
                txtSalesType.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[18].Text;
                txtDate.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[6].Text;
                HidInvoiceId.Value = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[5].Text;
                txtInvoiceNo.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[24].Text;
                txtDueDate.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[7].Text;
                HidCustomerId.Value = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[8].Text;
                txtCustomerCode.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[19].Text;
                txtCustomerName.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[20].Text;
                HidSalesOrderId.Value = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[9].Text;
                txtSalesOrderNo.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[21].Text;
                txtSalesOrderDate.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[22].Text;
                HidCurrencyId.Value = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[12].Text;
                txtCurrency.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[23].Text;
                txtExchangeRate.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[13].Text;
                txtAmountInFX.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[14].Text;
                txtBaseAmount.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[15].Text;
                txtVATAmount.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[16].Text;
                txtNetInvoiceAmt.Text = gvInventoryItemList.Rows[gvInventoryItemList.SelectedIndex].Cells[17].Text;
                TDLableSWBN.Attributes.Add("style", "display:block");
                TDtxtSWBN.Attributes.Add("style", "display:block"); 

                Get_ItemInventoryDetail(Convert.ToInt32 (HidAutoIdHeader.Value));
            }
        }
        catch { }
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "SalesType")
        {
            BindSalesTypeMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "InvoiceId")
        {
            BindAllInvoices(txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    #endregion

    #region***************************************Functions***************************************
       

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdFAInventoryItemInvoice = ConfigurationManager.AppSettings["FormIdFAInventoryItemInvoice"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdFAInventoryItemInvoice);

            ddlSearch.DataTextField = "Options";
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();                
            }
            ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch { }
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
                    txtYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    txtYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch { }
    }

    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    
    public void ClearForm()
    {        
        txtCustomerName.Text = "";
        gvItemInventory.DataSource = "";
        gvItemInventory.DataBind();        
    }

    private void BindSalesTypeMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCreditDebitNoteProposal_Tran.GetSalesType_Mst(Searchtext);

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

    private void BindAllInvoices(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objFA_InventoryItemInvoice.Get_AllInvoice(Searchtext);

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

    protected void Get_ItemInventoryDetail(int AutoIdHeader)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objFA_InventoryItemInvoice.Get_ItemInventoryDetail(AutoIdHeader);            
            ViewState["LineItem"] = dt;
            gvItemInventory.DataSource = dt;
            gvItemInventory.DataBind();
        }
        catch (Exception ex) { }
    }

    private void Get_AllItemInventoryInvoice(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objFA_InventoryItemInvoice.Get_AllItemInventoryInvoice(Searchtext);

            if (dt.Rows.Count > 0)
            {
                gvInventoryItemList.DataSource = dt;
                gvInventoryItemList.AllowPaging = true;
                gvInventoryItemList.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvInventoryItemList.AllowPaging = false;
                gvInventoryItemList.DataSource = "";
                gvInventoryItemList.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecordsPopUp.Text = objcommonmessage.NoRecordFound + ex.Message;
            gvInventoryItemList.AllowPaging = false;
            gvInventoryItemList.DataSource = "";
            gvInventoryItemList.DataBind();
        }
    }

    public void ClearHeaderControls()
    {
        try
        {
            TDLableSWBN.Attributes.Add("style", "display:none");
            TDtxtSWBN.Attributes.Add("style", "display:none"); 
            txtSalesWaybillNo.Text = "";
            hidSalesType.Value = "";
            txtSalesType.Text = "";
            txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            FillFinancialYear();
            HidInvoiceId.Value = "";
            txtInvoiceNo.Text = "";
            txtDueDate.Text = "";
            HidCustomerId.Value = "";
            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            HidSalesOrderId.Value = "";
            txtSalesOrderNo.Text = "";
            txtSalesOrderDate.Text = "";
            HidCurrencyId.Value = "";
            txtCurrency.Text = "";
            txtExchangeRate.Text = "";
            txtAmountInFX.Text = "";
            txtBaseAmount.Text = "";
            txtVATAmount.Text = "";
            txtNetInvoiceAmt.Text = "";
            ViewState["LineItem"] = null;            
        }
        catch { }
    }

    #endregion





    
}