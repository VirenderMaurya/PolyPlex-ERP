/////////////////// Designed and Developed by Lalit Joshi 12th May 2012///////////////////////////////////////////////////////
///////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Drawing;

public partial class Finance_transaction_JournalVoucherEntryForm : System.Web.UI.Page
{

    #region Defind Global Objects
    FA_SLMaster objslmaster = new FA_SLMaster();
    Common com = new Common();
    BLLCollection<FA_SLMaster> colslmaster = new BLLCollection<FA_SLMaster>();
    FA_VoucherType objVoucherType = new FA_VoucherType();
    BLLCollection<FA_VoucherType> col = new BLLCollection<FA_VoucherType>();
    BLLCollection<FA_VoucherSeries> colseries = new BLLCollection<FA_VoucherSeries>();
    FA_VoucherSeries objVoucherSeries = new FA_VoucherSeries();
    FA_GLMaster objglmaster = new FA_GLMaster();
    BLLCollection<FA_GLMaster> colglmaster = new BLLCollection<FA_GLMaster>();
    FA_GLGroupMaster objglgroupmaster = new FA_GLGroupMaster();
    BLLCollection<FA_GLGroupMaster> colglgroupmaster = new BLLCollection<FA_GLGroupMaster>();
    BLLCollection<FA_Currencymaster> colcurrencymaster = new BLLCollection<FA_Currencymaster>();
    FA_Currencymaster objcurrencymaster = new FA_Currencymaster();
    BLLCollection<FA_ProfitCentermaster> colprofitcenter = new BLLCollection<FA_ProfitCentermaster>();
    FA_ProfitCentermaster objprofitcentermaster = new FA_ProfitCentermaster();
    BLLCollection<FA_CostCentermaster> colcostcenter = new BLLCollection<FA_CostCentermaster>();
    FA_CostCentermaster objcostcentermaster = new FA_CostCentermaster();
    BLLCollection<FA_ProjectCode> colprojectcode = new BLLCollection<FA_ProjectCode>();
    FA_ProjectCode objprojectcode = new FA_ProjectCode();
    BLLCollection<FA_SubProjectmst> colsubprojectcode = new BLLCollection<FA_SubProjectmst>();
    FA_SubProjectmst objsubprojectcode = new FA_SubProjectmst();
    BLLCollection<FA_WHTType> colwhttype = new BLLCollection<FA_WHTType>();
    FA_WHTType objwhttype = new FA_WHTType();
    BLLCollection<FA_CountryClass> colcountryclass = new BLLCollection<FA_CountryClass>();
    FA_CountryClass objcountryclass = new FA_CountryClass();
    FA_JournalVoucher objjournalvoucher = new FA_JournalVoucher();
    BLLCollection<FA_JournalVoucher> coljornalvoucher = new BLLCollection<FA_JournalVoucher>();
    FA_Journal_WHT objjournalvoucher_wht = new FA_Journal_WHT();
    BLLCollection<FA_Journal_WHT> coljournalwht = new BLLCollection<FA_Journal_WHT>();
    FA_Journal_Vat objjournalvoucher_vat = new FA_Journal_Vat();
    BLLCollection<FA_Journal_Vat> colvatdetails = new BLLCollection<FA_Journal_Vat>();
    FA_Journal_traveldetail objjournalvoucher_travel = new FA_Journal_traveldetail();
    BLLCollection<FA_Journal_traveldetail> coltraveldetails = new BLLCollection<FA_Journal_traveldetail>();
    FA_JournalVoucherToMarkReversalHistory objvouchermarkhistory = new FA_JournalVoucherToMarkReversalHistory();
    BLLCollection<FA_VendorMaster> colvendorlist = new BLLCollection<FA_VendorMaster>();
    FA_VendorMaster objvendor = new FA_VendorMaster();
    Common_Message objmessage = new Common_Message();
    string logmessage = "";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {
         if (!Page.IsPostBack)
            {
                Log.GetLog().FillFinancialYear(TxtYear);
                TxtVoucherDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
                Log.PageHeading(this, "Journal Voucher Entry Form");
                BindTempTable();
                BindVoucherType();
                BindSLCode();
                BindVoucherSeries();
                BindGLCode();
                BindCurrency();
                BindProfitCenter();
                BindCostCenter();
                BindProjectCode();
                BindSubProjectCode();
                BindWHTType();
                BindCountryClass();
                BindSearch();
          }
            readonlycontrols();
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-PageLoadEvent-Error-"+ ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    #endregion
    
    #region Defined Functions
    #region Bind functions
    protected void BindSLCode()
    {
        try
        {
            colslmaster = objslmaster.GetSLCodeList();
            DdlSubGLCode.DataSource = colslmaster;
            DdlSubGLCode.DataTextField = "SubSidiaryLedgerCode";
            DdlSubGLCode.DataValueField = "AutoId";
            DdlSubGLCode.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlSubGLCode.Items.Add(item);
            DdlSubGLCode.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Entry Form-BindingSubGLCode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindSearch()
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            ddlSearch.Items.Insert(0, new ListItem("-----Select-----", ""));
            ddlSearch.Items.Insert(1, new ListItem("Mark Reversal", "Mark Reversal"));
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingSearchGrid-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindVoucherType()
    {
        try
        {
            col = objVoucherType.Get_VoucherType();
            DdlVoucherType.DataSource = col;
            DdlVoucherType.DataTextField = "VoucherType";
            DdlVoucherType.DataValueField = "Id";
            DdlVoucherType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlVoucherType.Items.Add(item);
            DdlVoucherType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingVoucherType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindVoucherSeries()
    {
        try
        {
            colseries = objVoucherSeries.Get_VoucherSeries();
            DdlVoucherSeries.DataSource = colseries;
            DdlVoucherSeries.DataTextField = "VoucherSeries";
            DdlVoucherSeries.DataValueField = "Id";
            DdlVoucherSeries.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlVoucherSeries.Items.Add(item);
            DdlVoucherSeries.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingVoucherSeries-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindGLCode()
    {
        try
        {
            colglmaster = objglmaster.GetGLCodeList();
            DdlGLCode.DataSource = colglmaster;
            DdlGLCode.DataTextField = "GeneralLedgerCode";
            DdlGLCode.DataValueField = "AutoId";
            DdlGLCode.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlGLCode.Items.Add(item);
            DdlGLCode.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingGLCode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindCurrency()
    {
        try
        {
            colcurrencymaster = objcurrencymaster.GetCurrencyList();
            DdlCurrencyType.DataSource = colcurrencymaster;
            DdlCurrencyType.DataTextField = "CurrencyName";
            DdlCurrencyType.DataValueField = "CurrencyId";
            DdlCurrencyType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlCurrencyType.Items.Add(item);
            DdlCurrencyType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingCurrency-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindProfitCenter()
    {
        try
        {
            colprofitcenter = objprofitcentermaster.GetProfitCenter();
            DdlProfitCenter.DataSource = colprofitcenter;
            DdlProfitCenter.DataTextField = "ProfitCenterName";
            DdlProfitCenter.DataValueField = "Id";
            DdlProfitCenter.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlProfitCenter.Items.Add(item);
            DdlProfitCenter.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingProfitCenter-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindCostCenter()
    {
        try
        {
            colcostcenter = objcostcentermaster.GetCostCenter();
            DdlCostCenter.DataSource = colcostcenter;
            DdlCostCenter.DataTextField = "CostCenterCode";
            DdlCostCenter.DataValueField = "Id";
            DdlCostCenter.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlCostCenter.Items.Add(item);
            DdlCostCenter.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingCostCenter-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindProjectCode()
    {
        try
        {
            colprojectcode = objprojectcode.GetProjectCode();
            DdlProject.DataSource = colprojectcode;
            DdlProject.DataTextField = "ProjectName";
            DdlProject.DataValueField = "ProjectCode";
            DdlProject.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlProject.Items.Add(item);
            DdlProject.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingProjectCode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindSubProjectCode()
    {
        try
        {
            colsubprojectcode = objsubprojectcode.GetSubProject();
            DdlSubProject.DataSource = colsubprojectcode;
            DdlSubProject.DataTextField = "SubProjectName";
            DdlSubProject.DataValueField = "SubProjectCode";
            DdlSubProject.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlSubProject.Items.Add(item);
            DdlSubProject.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingProjectSubCode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindWHTType()
    {
        try
        {
            colwhttype = objwhttype.GetWHTType();
            DdlWhtType.DataSource = colwhttype;
            DdlWhtType.DataTextField = "WHTDescription";
            DdlWhtType.DataValueField = "WHTId";
            DdlWhtType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlWhtType.Items.Add(item);
            DdlWhtType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingWHTType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindCountryClass()
    {
        try
        {
            colcountryclass = objcountryclass.GetAllCountries();
            Ddlcountryclass.DataSource = colcountryclass;
            Ddlcountryclass.DataTextField = "CountryName";
            Ddlcountryclass.DataValueField = "CountryId";
            Ddlcountryclass.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            Ddlcountryclass.Items.Add(item);
            Ddlcountryclass.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-BindingCountryClass-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion  
    #region Generate Auto No
    protected int AutogenerateVoucherNo()
    {
        string lastvno = "";
        int lastno;
        try
        {
            lastvno = objjournalvoucher.GetLastVoucherNo();
            if (lastvno == "")
            {
                lastno = Convert.ToInt32("10000");
            }
            else
            {
                lastno = Convert.ToInt32(lastvno);
                lastno = lastno + 1;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- Generting Auto Generate Voucher No-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return 0;
        }
        return Convert.ToInt32(lastno);
    }
    #endregion
    #region BindTempTable
    private void BindTempTable()
    {
        try
        {
            coljornalvoucher = objjournalvoucher.GetBy_VoucherIDCol("0");
            GdvDescription.Visible = true;
            GdvDescription.DataSource = coljornalvoucher;
            GdvDescription.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- Bind Temp Table in page load-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
    private void MakeDefaultMasterDrop()
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        ddl.SelectedValue = "";
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
            logmessage = "Journal Voucher Form-BindEmployee-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindVatDetails(string voucherno)
    {
        try
        {
            colvatdetails = objjournalvoucher_vat.VatDetails_ByVoucherNo(voucherno);
            GdvVatDetails.DataSource = colvatdetails;
            GdvVatDetails.DataBind();
            if (GdvVatDetails.Rows.Count > 0)
            {
                foreach (GridViewRow row in GdvVatDetails.Rows)
                {
                    row.Cells[0].Visible = true;
                    row.Cells[9].Visible = false;
                }
                GdvVatDetails.HeaderRow.Cells[0].Visible = true;
                GdvVatDetails.HeaderRow.Cells[9].Visible = false;
               // BtnAdd_VatDetails.Text = "Update Line";
                BtnAdd_VatDetails.ImageUrl = "~/Images/btn_update.png";
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- BindVatDetails -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindWHTDetails(string voucherno)
    {
        try
        {
            coljournalwht = objjournalvoucher_wht.GetWHTDetailsBy_Vrno(voucherno);
            GdvWhtDetails.DataSource = coljournalwht;
            GdvWhtDetails.DataBind();
            if (GdvWhtDetails.Rows.Count > 0)
            {
                foreach (GridViewRow row in GdvWhtDetails.Rows)
                {
                    row.Cells[0].Visible = true;
                    row.Cells[7].Visible = false;
                }
                GdvWhtDetails.HeaderRow.Cells[0].Visible = true;
                GdvWhtDetails.HeaderRow.Cells[7].Visible = false;
               // BtnAddWhtDetails.Text = "Update Line";
                BtnAddWhtDetails.ImageUrl ="~/Images/btn_update.png";
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- BindWHTDetails -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindTravelDetails(string voucherno)
    {
        try
        {
            coltraveldetails = objjournalvoucher_travel.TravelDetails_ByVocherNo(voucherno);
            GdvTravelDetails.DataSource = coltraveldetails;
            GdvTravelDetails.DataBind();
            if (GdvTravelDetails.Rows.Count > 0)
            {
                foreach (GridViewRow row in GdvTravelDetails.Rows)
                {
                    row.Cells[0].Visible = true;
                    row.Cells[10].Visible = false;
                }
                GdvTravelDetails.HeaderRow.Cells[10].Visible = false;
                GdvTravelDetails.HeaderRow.Cells[0].Visible = true;
               // BtnAddtraveldetails.Text = "Update Line";
                BtnAddtraveldetails.ImageUrl = "~/Images/btn_update.png";
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- BindTravelDetails -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }

    }
    private void BindVendorList()
    {
        try
        {
            GdvVendorList.DataSource = null;
            GdvVendorList.DataBind();
            colvendorlist = objvendor.GetVendorList_ByVendorCode("0");
            GdvVendorList.Visible = true;
            GdvVendorList.DataSource = colvendorlist;
            GdvVendorList.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindMasterSearchBox()
    {
        try
        {
            ImageButton imgbutton = (ImageButton)Master.FindControl("imgbtnSearch");
            imgbutton.Click += new ImageClickEventHandler(btn_Search_Click);
            ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
            btn_add.Click += new ImageClickEventHandler(btn_add_Click);
            btn_add.CausesValidation = false;
            imgbutton.CausesValidation = false;
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- BindMasterSearchBox -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void readonlycontrols()
    {
        TxtVoucherDate.Attributes.Add("readonly", "true");
        TxtChequeDate.Attributes.Add("readonly", "true");
        TxtYear.Attributes.Add("readonly", "true");
        TxtVendorCode.Attributes.Add("readonly", "true");
        TxtVendorName.Attributes.Add("readonly", "true");
        TxtVendorCode_WHTTab.Attributes.Add("readonly", "true");
        TxtVenderName_WHTTab.Attributes.Add("readonly", "true");
        TxtTaxInvoiceDate.Attributes.Add("readonly", "true");
        Txtfromdate_travaldetails.Attributes.Add("readonly", "true");
        Txttodate_travaldetails.Attributes.Add("readonly", "true");
    }
    #region Clear Control Event
    protected void ClearMainDetails()
    {
        TxtAsset.Text = "";
        TxtEmpCode.Text = "";
        DdlSubGLCode.SelectedValue= "0";
        TxtFxAmount.Text = "";
        TxtDebitAmount.Text = "";
        TxtCreditAmount.Text = "";
        TxtChequeNo.Text = "";
        TxtChequeDate.Text = "";
        TxtNarration.Text = "";
        DdlGLCode.SelectedValue = "0";
        DdlCostCenter.SelectedValue = "0";
        DdlCurrencyType.SelectedValue = "0";
        DdlProfitCenter.SelectedValue = "0";
        DdlVoucherType.SelectedValue = "0";
        DdlVoucherSeries.SelectedValue = "0";
        DdlProject.SelectedValue = "0";
        DdlSubProject.SelectedValue = "0";
    }
    protected void ClearDetails()
    {
        TxtAsset.Text = "";
        TxtEmpCode.Text = "";
        DdlSubGLCode.SelectedValue = "0";
        TxtFxAmount.Text = "";
        TxtDebitAmount.Text = "";
        TxtCreditAmount.Text = "";
        TxtChequeNo.Text = "";
        TxtChequeDate.Text = "";
        TxtNarration.Text = "";
        DdlGLCode.SelectedValue = "0";
        DdlCostCenter.SelectedValue = "0";
        DdlProfitCenter.SelectedValue = "0";
        DdlProject.SelectedValue = "0";
        DdlSubProject.SelectedValue = "0";
    }
    protected void ClearTravelDetails()
    {
        TxtEmpCode_travaldetailstab.Text = "";
        TxtEmployeeName.Text = "";
        TxtNoOfDays.Text = "";
        Txtfromdate_travaldetails.Text = "";
        Txttodate_travaldetails.Text = "";
        TxtDA_traveldetails.Text = "";
        TxtOtherCost_traveldetails.Text = "";
        Ddlcountryclass.SelectedValue = "0";
    }
    protected void FreeGridInstances()
    {
        GdvTravelDetails.DataSource = null;
        GdvTravelDetails.DataBind();
        GdvVatDetails.DataSource = null;
        GdvVatDetails.DataBind();
        GdvWhtDetails.DataSource = null;
        GdvWhtDetails.DataBind();
        GdvDescriptionEdit.DataSource = null;
        GdvDescriptionEdit.DataBind();
        GdvSearch.DataSource = null;
        GdvSearch.DataBind();
        GdvVendorList.DataSource = null;
        GdvVendorList.DataBind();
     
    }
    protected void ClearWHTDetails()
    {
        TxtVendorCode_WHTTab.Text = "";
        TxtVenderName_WHTTab.Text = "";
        TxtBaseAmount_WHTTab.Text = "";        
        TxtWHTGroup.Text = "";
        TxtWhtrate.Text = "";
        TxtWhtAmount.Text = "";
        
    }
    protected void ClearVatDetails()
    {
        TxtVendorCode.Text = "";
        TxtVendorName.Text = "";
        TxtBaseAmount.Text = "";
        TxtTaxAmount.Text = "";
        TxtTaxInvoice.Text = "";
        TxtTaxInvoiceDate.Text = "";
        TxtRate.Text = "";
    }
    protected void Clearallsession()
    {
        try
        {
            
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-Remoing Sessions-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
    #endregion
    
    #region GridEvents
    protected void GdvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
       try
        {
           ClearTravelDetails();
           ClearVatDetails();
           ClearWHTDetails();
            if (e.CommandName == "select")
            {
                string voucherno = Convert.ToString(e.CommandArgument);
                objjournalvoucher = objjournalvoucher.GetBy_VoucherID(voucherno);
                #region Bind Main Details
                TxtYear.Text = objjournalvoucher.VoucherYear;
                TxtVoucherDate.Text = objjournalvoucher.VoucherDate.ToString("MM/dd/yyyy");
                TxtExchangeRate.Text = objjournalvoucher.ExchangeRate.ToString();
                ViewState["OldStatusMarkReversal"] = objjournalvoucher.MarkReversal;
                if (objjournalvoucher.MarkReversal == true)
                {
                    ChkBxMarkReversal.Checked = true;
                }
                DdlVoucherType.SelectedValue = objjournalvoucher.VoucherType.ToString();
                DdlVoucherSeries.SelectedValue = objjournalvoucher.VoucherSeries.ToString();
                if (objjournalvoucher.Currency != "")
                {
                    DdlCurrencyType.SelectedValue = objjournalvoucher.Currency;
                }
                TxtVoucherNo.Text = objjournalvoucher.VoucherNo;
                coljornalvoucher = objjournalvoucher.GetBy_VoucherIDCol(voucherno);
                GdvDescription.DataSource = null;
                GdvDescription.DataBind();
                GdvDescriptionEdit.Visible = true;
                GdvDescriptionEdit.DataSource = coljornalvoucher;
                GdvDescriptionEdit.DataBind();
                #endregion
                                
                #region BindVatDetails
                BindVatDetails(voucherno);
                #endregion
                
                #region BindWHTDetails
                BindWHTDetails(voucherno);         
                #endregion
                
                #region BindTravelDetails
                BindTravelDetails(voucherno);
                #endregion

                BtnSave.ImageUrl = "~/Images/btnSaveGrey.png";
                BtnSave.Enabled = false;
                BtnAddLine.ImageUrl = "~/Images/btnAddLineGrey.png";
                BtnAddLine.Enabled = false;
                GdvDescription.Visible = false;
                if (GdvVatDetails.Rows.Count > 0)
                {
                    BtnAdd_VatDetails.ImageUrl = "~/Images/btn_update.png";
                    BtnAdd_VatDetails.Enabled = true;
                }
                else
                {
                    BtnAdd_VatDetails.ImageUrl = "~/Images/btnAddLineGrey.png";
                    BtnAdd_VatDetails.Enabled = false;
                }
                if (GdvTravelDetails.Rows.Count > 0)
                {
                    BtnAddtraveldetails.ImageUrl = "~/Images/btn_update.png";
                    BtnAddtraveldetails.Enabled = true;
                }
                else
                {
                    BtnAddtraveldetails.ImageUrl = "~/Images/btnAddLineGrey.png";
                    BtnAddtraveldetails.Enabled = false;
                }
                if (GdvWhtDetails.Rows.Count > 0)
                {
                    BtnAddWhtDetails.ImageUrl = "~/Images/btn_update.png";
                    BtnAddWhtDetails.Enabled = true;
                }
                else
                {
                    BtnAddWhtDetails.ImageUrl = "~/Images/btnAddLineGrey.png";
                    BtnAddWhtDetails.Enabled = false;
                }
           }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvSearch_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvDescriptionEdit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        double totaldebitamountadd = 0.0, totaldebitamount = 0.0;
        double totalcreditamountadd = 0.0, totalcreditamount = 0.0;
        try
        {
            if (e.CommandName == "editform")
            {
                string lineno = (e.CommandArgument).ToString();
                if (lineno != "")
                {
                    objjournalvoucher = objjournalvoucher.GetBy_LineNo(lineno,TxtVoucherNo.Text.Trim());
                    DdlGLCode.SelectedValue = objjournalvoucher.GlCode;
                    DdlProfitCenter.SelectedValue = objjournalvoucher.ProfitCenter;
                    DdlCostCenter.SelectedValue = objjournalvoucher.CostCenter;
                    TxtAsset.Text = objjournalvoucher.Asset;
                   //TxtSubCode.Text = objjournalvoucher.GlSubCode;
                    DdlSubGLCode.SelectedValue = objjournalvoucher.GlSubCode;
                    TxtEmpCode.Text = objjournalvoucher.EmpCode;
                    TxtFxAmount.Text = objjournalvoucher.Fxamount.ToString();
                    TxtDebitAmount.Text = objjournalvoucher.DebitAmount.ToString();
                    TxtCreditAmount.Text = objjournalvoucher.CreditAmount.ToString();
                    TxtChequeNo.Text = objjournalvoucher.ChequeNo;
                    if (objjournalvoucher.ChequeDate.ToString() == "1/1/0001 12:00:00 AM")
                    {
                        TxtChequeDate.Text = "";
                    }
                    else
                    {
                        TxtChequeDate.Text = objjournalvoucher.ChequeDate.ToString("MM/dd/yyyy");
                    }
                    
                    TxtNarration.Text = objjournalvoucher.VoucherDescription;
                    DdlProject.SelectedValue = objjournalvoucher.Project.ToString();
                    DdlSubProject.SelectedValue = objjournalvoucher.SubProject.ToString();
                    //BtnSave.Text = "Update";
                    BtnSave.Enabled = true;
                    BtnSave.ImageUrl = "~/Images/btn_update.png";
                    BtnAddLine.ImageUrl = "~/Images/btnAddLineGrey.png";
                    BtnAddLine.Enabled = false;
                    
                    foreach (GridViewRow row in GdvDescriptionEdit.Rows)
                    {
                        totaldebitamount = Convert.ToDouble(((Label)row.FindControl("Lbldebitamountedit")).Text);
                        totaldebitamount = totaldebitamount + totaldebitamountadd;
                        totaldebitamountadd = totaldebitamount;
                        totalcreditamount = Convert.ToDouble(((Label)row.FindControl("Lblcreditamountedit")).Text);
                        totalcreditamount = totalcreditamount + totalcreditamountadd;
                        totalcreditamountadd = totalcreditamount;
                     
                    }

                    //GridViewRow drow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                    //ImageButton img = (ImageButton)drow.FindControl("ImageButton1");
                    //img.ImageUrl = "~/Images/chkbxcheck.png";
                   // drow.BackColor = Color.LightSlateGray;
                    TxtTotalDebit.Text = totaldebitamount.ToString();
                    TxtTotalCredit.Text = totalcreditamount.ToString();
                    ViewState["LineNo"] = lineno;
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvDescriptionEdit_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string DataKey = GdvVendorList.SelectedDataKey.Value.ToString();
            TxtVendorCode.Text = DataKey;
            TxtVendorCode_WHTTab.Text = DataKey;
            int index = GdvVendorList.SelectedIndex;
            TxtVendorName.Text = ((Label)(GdvVendorList.Rows[index].FindControl("lblvendorname"))).Text.ToString();
            TxtVenderName_WHTTab.Text = ((Label)(GdvVendorList.Rows[index].FindControl("lblvendorname"))).Text.ToString();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- Select event for vendor id and name(gridMaster_SelectedIndexChanged) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVatDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[0].Visible = false;
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvVatDetails_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVatDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            #region Row Deleting in temp table
            if (e.CommandName == "del")
            {
                int lineno = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["VatDetails"];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    if (Convert.ToInt32(dt.Rows[i]["VatLineNo"]) == lineno)
                    {
                        dt.Rows[i].Delete();
                    }
                    i++;
                }
                if (dt.Rows.Count == 0)
                {
                    GdvVatDetails.DataSource = null;
                    GdvVatDetails.DataBind();
                }
                else
                {
                    GdvVatDetails.DataSource = dt;
                    GdvVatDetails.DataBind();
                }
            }
            #endregion
            #region Row Editing after mark reversal is selected
            if (e.CommandName == "editrow")
            {
                string lineno = e.CommandArgument.ToString();
                ViewState["vatlinenoforupdating"] = lineno;
                objjournalvoucher_vat = objjournalvoucher_vat.IsVatDetailsExist(TxtVoucherNo.Text, lineno);
                TxtVendorCode.Text = objjournalvoucher_vat.VendorCode;
                TxtVendorName.Text = objjournalvoucher_vat.VendorName;
                if (objjournalvoucher_vat.BaseAmount == 0.0)
                {
                    TxtBaseAmount.Text = "";
                }
                else
                {
                    TxtBaseAmount.Text = objjournalvoucher_vat.BaseAmount.ToString();
                }
                if (objjournalvoucher_vat.VAmount == 0.0)
                {
                    TxtTaxAmount.Text = "";
                }
                else
                {
                    TxtTaxAmount.Text = objjournalvoucher_vat.VAmount.ToString();
                }
                if (objjournalvoucher_vat.TaxInvoice == null)
                {
                    TxtTaxInvoice.Text = "";
                }
                else
                {
                    TxtTaxInvoice.Text = objjournalvoucher_vat.TaxInvoice.ToString();
                }
                if (objjournalvoucher_vat.TaxInvoiceDate.ToString() == "1/1/0001 12:00:00 AM")
                {
                    TxtTaxInvoiceDate.Text = "";
                }
                else
                {
                    TxtTaxInvoiceDate.Text = objjournalvoucher_vat.TaxInvoiceDate.ToString("MM/dd/yyyy");
                }
                if (objjournalvoucher_vat.Rate == 0.0)
                {
                    TxtRate.Text = "";
                }
                else
                {
                    TxtRate.Text = objjournalvoucher_vat.Rate.ToString();
                }

                if (objjournalvoucher_vat.VendorCode != null)
                {
                  //  BtnAdd_VatDetails.Text = "Update Line";
                    BtnAdd_VatDetails.ImageUrl = "~/Images/btn_update.png";
                }
                else
                {
                    BtnAdd_VatDetails.ImageUrl = "~/Images/btnAddLineGrey.png";
                    BtnAdd_VatDetails.Enabled = false;
                }
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvVatDetails_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvWhtDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[0].Visible = false;
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvWhtDetails_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvWhtDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            #region Row Deleting in Temp Table
            if (e.CommandName == "del")
            {
                int lineno = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["WHTDetails"];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    if (Convert.ToInt32(dt.Rows[i]["WHTLineNo"]) == lineno)
                    {
                        dt.Rows[i].Delete();
                    }
                    i++;
                }
                if (dt.Rows.Count == 0)
                {
                    GdvWhtDetails.DataSource = null;
                    GdvWhtDetails.DataBind();
                }
                else
                {
                    GdvWhtDetails.DataSource = dt;
                    GdvWhtDetails.DataBind();
                }
            }
            #endregion
            #region Row Editing after Mark reversal is selected
            if (e.CommandName == "editrow")
            {
                string lineno = e.CommandArgument.ToString();
                ViewState["whtlinenoforupdating"] = lineno;
                objjournalvoucher_wht = objjournalvoucher_wht.IsWHTDetailsExist(TxtVoucherNo.Text, lineno);
                TxtVendorCode_WHTTab.Text = objjournalvoucher_wht.VendorCode;
                TxtVenderName_WHTTab.Text = objjournalvoucher_wht.VendorName;
                if (objjournalvoucher_wht.BaseAmount == 0.0)
                {
                    TxtBaseAmount_WHTTab.Text = "";
                }
                else
                {
                    TxtBaseAmount_WHTTab.Text = objjournalvoucher_wht.BaseAmount.ToString();
                }
                if (objjournalvoucher_wht.WhtGroup == 0.0)
                {
                    TxtWHTGroup.Text = "";
                }
                else
                {
                    TxtWHTGroup.Text = objjournalvoucher_wht.WhtGroup.ToString();
                }
                DdlWhtType.SelectedValue = objjournalvoucher_wht.WhtType;
                if (objjournalvoucher_wht.WhtRate == 0.0)
                {
                    TxtWhtrate.Text = "";
                }
                else
                {
                    TxtWhtrate.Text = objjournalvoucher_wht.WhtRate.ToString();
                }

                if (objjournalvoucher_wht.VendorCode != null)
                {
                  //  BtnAddWhtDetails.Text = "Update Item";
                    BtnAddWhtDetails.ImageUrl = "~/Images/btn_update.png";
                }
                else
                {
                    BtnAddWhtDetails.ImageUrl = "~/Images/btnAddLineGrey.png";
                    BtnAddWhtDetails.Enabled = false;
                }
                TxtWhtAmount.Text = objjournalvoucher_wht.WhtAmount.ToString();
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvWhtDetails_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvTravelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[0].Visible = false;
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvTravelDetails_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvTravelDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            #region Row Deleting in Temp Table
            if (e.CommandName == "del")
            {
                int lineno = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["TravelsDetails"];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    if (Convert.ToInt32(dt.Rows[i]["TravelLineNo"]) == lineno)
                    {
                        dt.Rows[i].Delete();
                    }
                    i++;
                }
                if (dt.Rows.Count == 0)
                {
                    GdvTravelDetails.DataSource = null;
                    GdvTravelDetails.DataBind();
                }
                else
                {
                    GdvTravelDetails.DataSource = dt;
                    GdvTravelDetails.DataBind();
                }
            }
            #endregion
            #region Row Editing after Mark reversal is selected
            if (e.CommandName == "editrow")
            {
                string travellineno = e.CommandArgument.ToString();
                string voucherno = TxtVoucherNo.Text;
                ViewState["travellinenoforupdating"] = travellineno;
                objjournalvoucher_travel = objjournalvoucher_travel.IsTravelDetailsExist(voucherno, travellineno);
                TxtEmpCode_travaldetailstab.Text = objjournalvoucher_travel.EmpCode;
                TxtEmployeeName.Text = objjournalvoucher_travel.EmpName;
                Ddlcountryclass.SelectedValue = objjournalvoucher_travel.CountryClass.ToString();
                if (objjournalvoucher_travel.NoOfDays != 0)
                {
                    TxtNoOfDays.Text = objjournalvoucher_travel.NoOfDays.ToString();
                }
                if (objjournalvoucher_travel.FromDate.ToString() != "1/1/0001 12:00:00 AM")
                {
                    Txtfromdate_travaldetails.Text = objjournalvoucher_travel.FromDate.ToString("MM/dd/yyyy");
                }
                if (objjournalvoucher_travel.ToDate.ToString() != "1/1/0001 12:00:00 AM")
                {
                    Txttodate_travaldetails.Text = objjournalvoucher_travel.ToDate.ToString("MM/dd/yyyy");
                }
                if (objjournalvoucher_travel.DA == 0.0)
                {
                    TxtDA_traveldetails.Text = "";
                }
                else
                {
                    TxtDA_traveldetails.Text = objjournalvoucher_travel.DA.ToString();
                }
                if (objjournalvoucher_travel.OtherCost == 0.0)
                {
                    TxtOtherCost_traveldetails.Text = "";
                }
                else
                {
                    TxtOtherCost_traveldetails.Text = objjournalvoucher_travel.OtherCost.ToString();
                }
                if (objjournalvoucher_travel.EmpCode != null)
                {
                   // BtnAddtraveldetails.Text = "Update Line";
                    BtnAddtraveldetails.ImageUrl ="~/Images/btn_update.png";
                }
                else
                {
                    BtnAddtraveldetails.ImageUrl = "~/Images/btnAddLineGrey.png";
                    BtnAddtraveldetails.Enabled = false;
                }

            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvTravelDetails_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvSearch.PageIndex = e.NewPageIndex;
            DropDownList ddsearch = (DropDownList)Master.FindControl("dd_search");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            coljornalvoucher = objjournalvoucher.Search_JournalVoucher(txtSearch.Text.Trim());
            GdvSearch.DataSource = coljornalvoucher;
            GdvSearch.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvSearch_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVendorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvVendorList.PageIndex = e.NewPageIndex;
            BindVendorList();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GdvVendorList_PageIndexChanging -Error-" + ex.ToString();
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

                //if (HidPopUpType.Value == "requestedby")
                //{
                string empcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                string empname = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                TxtEmpCode_travaldetailstab.Text = empcode;
                TxtEmployeeName.Text = empname;

                // }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form - Gdvlookup_RowCommand Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvlookup_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void Gdvlookup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Gdvlookup.PageIndex = e.NewPageIndex;
            BindEmployee("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- Gdvlookup_PageIndexChanging Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvDescription_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Row Deleting in Temp Table
        if (e.CommandName == "del")
        {
            int lineno = Convert.ToInt32(e.CommandArgument);
            DataTable dt = (DataTable)ViewState["Journal"];
            int i = 0;
            while (i < dt.Rows.Count)
            {
                if (Convert.ToInt32(dt.Rows[i]["Line#"]) == lineno)
                {
                    dt.Rows[i].Delete();
                }
                i++;
            }
            if (dt.Rows.Count == 0)
            {
                GdvDescription.DataSource = null;
                GdvDescription.DataBind();
            }
            else
            {
                GdvDescription.DataSource = dt;
                GdvDescription.DataBind();
            }
        }
        #endregion
    }
    #endregion

    #region Button Events
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "vendor")
        {
            string vendorid = txtSearchList.Text.Trim();
            colvendorlist = objvendor.GetVendorList_ByVendorCode(vendorid);
            GdvVendorList.Visible = true;
            Gdvlookup.Visible = false;
            GdvVendorList.DataSource = colvendorlist;
            GdvVendorList.DataBind();

        }
        if (HidPopUpType.Value == "searchgrid")
        {
            string voucherno = txtSearchList.Text.Trim();
            coljornalvoucher = objjournalvoucher.Search_JournalVoucher(voucherno);
            GdvVendorList.Visible = false;
            GdvSearch.Visible = true;
            Gdvlookup.Visible = false;
            GdvSearch.DataSource = coljornalvoucher;
            GdvSearch.DataBind();
            foreach (GridViewRow oldrow in GdvSearch.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton5");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                oldrow.BackColor = Color.White;
            }
        }
        if (HidPopUpType.Value == "employee")
        {
            Gdvlookup.Visible = true;
            GdvVendorList.Visible = false;
            GdvSearch.Visible = false;
            BindEmployee(txtSearchList.Text.Trim());
        }
        ModalPopupExtender1.Show();

    }
    protected void ImgBtnApprovedBy_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search By Employee";
            HidPopUpType.Value = "employee";
            Gdvlookup.Visible = true;
            BindEmployee("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form - ImgBtnApprovedBy_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMainDetails();
            ClearTravelDetails();
            ClearVatDetails();
            ClearWHTDetails();
            FreeGridInstances();
            BindTempTable();
            BtnAddLine.Enabled = true;
            BtnAddLine.ImageUrl ="~/Images/btnAddLinegreen.png";
            BtnAddtraveldetails.Enabled = true;
            BtnAddtraveldetails.ImageUrl = "~/Images/btnAddLinegreen.png"; 
            BtnAdd_VatDetails.ImageUrl = "~/Images/btnAddLinegreen.png";
            BtnAdd_VatDetails.Enabled = true;
            BtnSave.Enabled = true;
            BtnSave.ImageUrl = "~/Images/btnSave.png";
            BtnAddWhtDetails.ImageUrl = "~/Images/btnAddLinegreen.png";
            BtnAddWhtDetails.Enabled = true;
            TxtVoucherNo.Text = "";
            TxtExchangeRate.Text = "";
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        double exchangerate = 0.0;
        DateTime voucherdate = new DateTime();
        if (TxtExchangeRate.Text != "")
        {
            exchangerate = Convert.ToDouble(TxtExchangeRate.Text);
        }
        bool markrev = ChkBxMarkReversal.Checked;
        try
        {
            #region Update Record
           // if (BtnSave.Text == "Update")
            if (BtnSave.ImageUrl == "~/Images/btn_update.png")
            {
                bool oldvaluemarkreversal = (bool)ViewState["OldStatusMarkReversal"];
                #region Update item in Journal Voucher Header table
                if (TxtVoucherDate.Text != "")
                {
                    voucherdate = DateTime.ParseExact(TxtVoucherDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    voucherdate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                int updatedheader = objjournalvoucher.UpdateJournalVoucher_Headerdetails(DdlVoucherType.SelectedItem.Value, DdlVoucherSeries.SelectedItem.Value, TxtYear.Text, TxtVoucherNo.Text, voucherdate, markrev, Session["userId"].ToString(), DdlCurrencyType.SelectedItem.Value, exchangerate);
                #endregion
                #region Update item in Journal Voucher Transaction table
                if (ViewState["LineNo"] != null)
                {
                    string lineno = ViewState["LineNo"].ToString();
                    DateTime chequedate = new DateTime();
                    if (updatedheader == 1)
                    {
                        if (TxtChequeDate.Text != "")
                        {
                            chequedate = DateTime.ParseExact(TxtChequeDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            chequedate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        }
                        double debitamount = 0.0, creditamount = 0.0, fxamount = 0.0;
                        if (TxtDebitAmount.Text != "")
                        {
                            debitamount = Convert.ToDouble(TxtDebitAmount.Text);
                        }
                        if (TxtCreditAmount.Text != "")
                        {
                            creditamount = Convert.ToDouble(TxtCreditAmount.Text);
                        }
                        if (TxtFxAmount.Text != "")
                        {
                            fxamount = Convert.ToDouble(TxtFxAmount.Text);
                        }
                        objjournalvoucher.UpdateJournalVoucher_Details(TxtVoucherNo.Text, lineno, DdlGLCode.SelectedValue, DdlSubGLCode.SelectedValue, DdlProfitCenter.SelectedValue, DdlCostCenter.SelectedValue, debitamount, creditamount, TxtChequeNo.Text, chequedate, Session["userid"].ToString(), TxtAsset.Text, TxtEmpCode.Text, fxamount, DdlProject.SelectedValue, DdlSubProject.SelectedValue, TxtNarration.Text);
                    }
                }
                #endregion
                #region If markreversal value is changed then make a entry in markreversal history table
                if (oldvaluemarkreversal != ChkBxMarkReversal.Checked)
                {
                    objvouchermarkhistory.VoucherNo = TxtVoucherNo.Text;
                    objvouchermarkhistory.MarkReversalStatus = ChkBxMarkReversal.Checked;
                    objvouchermarkhistory.CreatedBy = Session["userid"].ToString();
                    objvouchermarkhistory.insert();
                }
                #endregion
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Voucher Details Updated", 125, 300);
            }
            //if (BtnAdd_VatDetails.Text == "Update Line")
            //{
            //   #region Update Vat Details
            //   double baseamount = 0.0, taxamount = 0.0,rate=0.0;
            //   DateTime taxinvoicedate = new DateTime();
            //   if (TxtBaseAmount.Text != "")
            //   {
            //       baseamount =Convert.ToDouble(TxtBaseAmount.Text);
            //   }
            //   if (TxtTaxAmount.Text != "")
            //   {
            //       taxamount = Convert.ToDouble(TxtTaxAmount.Text);
            //   }
            //   //if (TxtRate.Text != "")
            //   //{
            //   //    rate = Convert.ToDouble(TxtRate.Text);
            //   //}
             
            //   if (TxtTaxInvoiceDate.Text != "")
            //   {
            //       taxinvoicedate = DateTime.ParseExact(TxtTaxInvoiceDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //   }
            //   else
            //   {
            //       taxinvoicedate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //   }

               
            //   #endregion
            //}


            #endregion
            #region insert record
            else
            {
                int isinserted_Journalentery;
                objjournalvoucher.VoucherType = DdlVoucherType.SelectedItem.Value;
                objjournalvoucher.VoucherSeries = DdlVoucherSeries.SelectedItem.Value;
                objjournalvoucher.VoucherYear = TxtYear.Text;
                if (TxtVoucherDate.Text != "")
                {
                    voucherdate = DateTime.ParseExact(TxtVoucherDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    voucherdate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                objjournalvoucher.VoucherDate = voucherdate;
                objjournalvoucher.MarkReversal = markrev;
                objjournalvoucher.Currency = DdlCurrencyType.SelectedItem.Value;
                objjournalvoucher.ExchangeRate = exchangerate;
                objjournalvoucher.VoucherNo = TxtVoucherNo.Text;
                DateTime dtcreateddate = DateTime.Now;
                ViewState["nowdate"] = dtcreateddate;
                #region if Main details is filled
                if (GdvDescription.Rows.Count > 0)
                {
                    foreach (GridViewRow row in GdvDescription.Rows)
                    {
                        double fxamount = 0.0;
                        int project = 0, subproject = 0;
                        DateTime chequedate = new DateTime();
                        if (((Label)row.FindControl("Lbllineno")).Text != "")
                        {
                            int lineno = Convert.ToInt32(((Label)row.FindControl("Lbllineno")).Text);

                            string glcode = ((Label)row.FindControl("Lblglcode")).Text;
                            string slcode = ((Label)row.FindControl("Lblslcode")).Text;
                            double debitamount = Convert.ToDouble(((Label)row.FindControl("Lbldebitamount")).Text);
                            double creditamount = Convert.ToDouble(((Label)row.FindControl("Lblcreditamount")).Text);
                            string profitcenter = ((Label)row.FindControl("Lblprofitcenter")).Text;
                            string costcenter = ((Label)row.FindControl("Lblcostcenter")).Text;
                            string asset = ((Label)row.FindControl("Lblasset")).Text;
                            string empcode = ((Label)row.FindControl("Lblempcode")).Text;
                            if (((Label)row.FindControl("Lblfxamount")).Text != "")
                            {
                                fxamount = Convert.ToDouble(((Label)row.FindControl("Lblfxamount")).Text);
                            }
                            else
                            {
                                fxamount = 0.0;
                            }
                            string chequeno = ((Label)row.FindControl("Lblchequeno")).Text;
                            if (((Label)row.FindControl("Lblchequedate")).Text != "")
                            {
                                chequedate = DateTime.ParseExact(((Label)row.FindControl("Lblchequedate")).Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                chequedate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            }
                            if (((Label)row.FindControl("Lblproject")).Text != "")
                            {
                                project = Convert.ToInt32(((Label)row.FindControl("Lblproject")).Text);
                            }
                            if (((Label)row.FindControl("Lblsubproject")).Text != "")
                            {
                                subproject = Convert.ToInt32(((Label)row.FindControl("Lblsubproject")).Text);
                            }
                            string voucherdescription = ((Label)row.FindControl("Lblnarration")).Text;
                            objjournalvoucher.LineNo = lineno;
                            objjournalvoucher.Asset = asset;
                            objjournalvoucher.EmpCode = empcode;
                            objjournalvoucher.Fxamount = fxamount;
                            objjournalvoucher.Project = project;
                            objjournalvoucher.SubProject = subproject;
                            objjournalvoucher.VoucherNo = TxtVoucherNo.Text;
                            objjournalvoucher.VoucherDescription = voucherdescription;
                            objjournalvoucher.GlCode = glcode;
                            objjournalvoucher.GlSubCode = slcode;
                            objjournalvoucher.DebitAmount = debitamount;
                            objjournalvoucher.CreditAmount = creditamount;
                            objjournalvoucher.CostCenter = costcenter;
                            objjournalvoucher.ProfitCenter = profitcenter;
                            objjournalvoucher.ChequeNo = chequeno;
                            objjournalvoucher.ChequeDate = chequedate;
                            objjournalvoucher.CreatedBy = Session["userid"].ToString();
                            objjournalvoucher.CreatedDate =Convert.ToDateTime(ViewState["nowdate"]);
                            isinserted_Journalentery = objjournalvoucher.insertjournaldetails();
                            ViewState["Journal"] = null;
                        }
                        else
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please enter voucher details", 125, 300);
                            return;
                        }
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.AddLineItem, 125, 300);
                    return;
                }
                #endregion
                #region if Vatdetails is filled
                if (GdvVatDetails.Rows.Count > 0)
                {
                    DateTime TaxInvdate = new DateTime();
                    foreach (GridViewRow row in GdvVatDetails.Rows)
                    {
                        int lineno = 0;
                        double baseamount = 0.0, vamount = 0.0, rate=0.0;
                        string voucherno = objjournalvoucher.GetLastVoucherNo();
                        int vatlineno = Convert.ToInt32(((Label)row.FindControl("Lblvatlineno")).Text);
                        string vendorcode = (((Label)row.FindControl("LblVCode")).Text);
                        string vendorname = (((Label)row.FindControl("Lblvendorname")).Text);
                        if (((Label)row.FindControl("LblBAmt")).Text != "")
                        {
                           baseamount = Convert.ToDouble(((Label)row.FindControl("LblBAmt")).Text);
                        }
                        if (((Label)row.FindControl("LblVAmt")).Text != "")
                        {
                           vamount = Convert.ToDouble(((Label)row.FindControl("LblVAmt")).Text);
                        }
                        if (((Label)row.FindControl("Lblrate")).Text != "")
                        {
                           rate = Convert.ToDouble(((Label)row.FindControl("Lblrate")).Text);
                        }
                        string taxinvoice = (((Label)row.FindControl("LblTaxInv")).Text);
                       // if (((Label)row.FindControl("LblTaxInvdate")).Text != "")
                        if(row.Cells[6].Text!="&nbsp;")
                        {
                            TaxInvdate = DateTime.ParseExact((row.Cells[6].Text), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            TaxInvdate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        objjournalvoucher_vat.LineNo = lineno;
                        objjournalvoucher_vat.VoucherNo = voucherno;
                        objjournalvoucher_vat.VatLineNo = vatlineno;
                        objjournalvoucher_vat.VendorCode = vendorcode;
                        objjournalvoucher_vat.VendorName = vendorname;
                        objjournalvoucher_vat.BaseAmount = baseamount;
                        objjournalvoucher_vat.VAmount = vamount;
                        objjournalvoucher_vat.TaxInvoice = taxinvoice;
                        objjournalvoucher_vat.TaxInvoiceDate = TaxInvdate;
                        objjournalvoucher_vat.Rate = rate;
                        objjournalvoucher_vat.CreatedBy = Session["userid"].ToString();
                        objjournalvoucher_vat.Active = true;
                        int vatinserted= objjournalvoucher_vat.insertjournal_Vatdetails();
                        ViewState["VatDetails"] = null;
                    }
                }
                #endregion
                #region if whtdetails is filled
                if (GdvWhtDetails.Rows.Count > 0)
                {
                    double baseamount = 0.0, whtrate = 0.0, whtamount = 0.0;
                    int whtgroup = 0;
                    foreach (GridViewRow row in GdvWhtDetails.Rows)
                    {
                        string voucherno = objjournalvoucher.GetLastVoucherNo();
                        int lineno = 0;
                        int whtlineno = Convert.ToInt32(row.Cells[1].Text.Trim());
                        
                        if (row.Cells[2].Text != "" && row.Cells[2].Text != "&nbsp;")
                        {
                            whtgroup = Convert.ToInt32(row.Cells[2].Text.Trim());
                        }
                        string whttype = row.Cells[3].Text.Trim();
                        if (row.Cells[4].Text.Trim() != "" && row.Cells[4].Text.Trim() != "&nbsp;")
                        {
                            whtamount = Convert.ToDouble(row.Cells[4].Text.Trim());
                        }
                        if (row.Cells[5].Text.Trim() != "" && row.Cells[5].Text.Trim() != "&nbsp;")
                        {
                            whtrate = Convert.ToDouble(row.Cells[5].Text.Trim());
                        }
                        if (row.Cells[6].Text.Trim() != "" && row.Cells[6].Text.Trim() != "&nbsp;")
                        {
                            baseamount = Convert.ToDouble(row.Cells[6].Text.Trim());
                        }
                         // int index = Convert.ToInt32(e.CommandArgument);s
                          string vendorcode = GdvWhtDetails.DataKeys[row.RowIndex]["VendorCode"].ToString();
                          string vendorname = GdvWhtDetails.DataKeys[row.RowIndex]["VendorName"].ToString();
                         // string vendorcode = GdvWhtDetails.DataKeyName
                         // string vendorname = GdvWhtDetails.SelectedDataKey.Values[1].ToString();

                        objjournalvoucher_wht.VoucherNo = voucherno;
                        objjournalvoucher_wht.LineNo = lineno;
                        objjournalvoucher_wht.WhtLineNo = whtlineno;
                        objjournalvoucher_wht.VendorCode = vendorcode;
                        objjournalvoucher_wht.VendorName = vendorname;
                        objjournalvoucher_wht.WhtGroup = whtgroup;
                        objjournalvoucher_wht.WhtType = whttype;
                        objjournalvoucher_wht.BaseAmount = baseamount;
                        objjournalvoucher_wht.WhtRate = whtrate;
                        objjournalvoucher_wht.WhtAmount = whtamount;
                        objjournalvoucher_wht.CreatedBy = Session["userid"].ToString();
                        objjournalvoucher_wht.Active = true;
                        int insertedwht = objjournalvoucher_wht.insertjournal_Whtdetails();
                        ViewState["WHTDetails"] = null;
                    }
                }
                #endregion
                #region if travel details is filled
                if (GdvTravelDetails.Rows.Count > 0)
                {
                    int lineno = 0, countryclass = 0, noofdays = 0;
                    double DA = 0.0, othercost = 0.0;
                    DateTime fromdate = new DateTime();
                    DateTime todate = new DateTime();
                    foreach (GridViewRow row in GdvTravelDetails.Rows)
                    {
                        int travellineno = Convert.ToInt32(row.Cells[1].Text);
                        string empcode = row.Cells[2].Text.Trim();
                        string empname = row.Cells[3].Text.Trim();
                        if (row.Cells[4].Text.Trim() != "" && row.Cells[4].Text.Trim() != "&nbsp;")
                        {
                            countryclass = Convert.ToInt32(row.Cells[4].Text.Trim());
                        }
                        if (row.Cells[5].Text.Trim() != "" && row.Cells[5].Text.Trim() != "&nbsp;")
                        {
                            noofdays = Convert.ToInt32(row.Cells[5].Text.Trim());
                        }
                        if (row.Cells[6].Text.Trim() != "" && row.Cells[6].Text.Trim() != "&nbsp;")
                        {
                            DA = Convert.ToDouble(row.Cells[6].Text.Trim());
                        }
                        if (row.Cells[7].Text.Trim() != "" && row.Cells[7].Text.Trim() != "&nbsp;")
                        {
                            fromdate = DateTime.ParseExact(row.Cells[7].Text.Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            fromdate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (row.Cells[8].Text.Trim() != "" && row.Cells[8].Text.Trim() != "&nbsp;")
                        {
                            todate = DateTime.ParseExact(row.Cells[8].Text.Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            todate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (row.Cells[9].Text.Trim() != "" && row.Cells[9].Text.Trim() != "&nbsp;")
                        {
                            othercost = Convert.ToDouble(row.Cells[9].Text.Trim());
                        }
                        objjournalvoucher_travel.VoucherNo = objjournalvoucher.GetLastVoucherNo();
                        objjournalvoucher_travel.LineNo = lineno;
                        objjournalvoucher_travel.TravelLineNo = travellineno;
                        objjournalvoucher_travel.EmpCode = empcode;
                        objjournalvoucher_travel.EmpName = empname;
                        objjournalvoucher_travel.CountryClass = countryclass;
                        objjournalvoucher_travel.NoOfDays = noofdays;
                        objjournalvoucher_travel.FromDate = fromdate;
                        objjournalvoucher_travel.ToDate = todate;
                        objjournalvoucher_travel.DA = DA;
                        objjournalvoucher_travel.OtherCost = othercost;
                        objjournalvoucher_travel.CreatedBy = Session["userid"].ToString();
                        objjournalvoucher_travel.Active = true;
                        objjournalvoucher_travel.insertjournal_Traveldetails();


                    }
                }

                #endregion
                #region clear main form data
                ClearMainDetails();
                #endregion
                #region remove all sessions from memory
               // Clearallsession();
                #endregion
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info,objmessage.RecordSaved, 125, 300);
                FreeGridInstances();
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- Inserting/Updating Journal Voucher Form-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
           lSearchList.Text = "Search by Vendor code";
           MakeDefaultMasterDrop();
           HidPopUpType.Value = "vendor";
           Gdvlookup.Visible = false;
           GdvSearch.Visible = false;
           GdvVendorList.Visible = true;
           BindVendorList();
           ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- Search Vendor By Keyword(ImgBtnCode_Click) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnCode_ClickWHT(object sender, ImageClickEventArgs e)
    {
        try
        {
           string Vendorcode = TxtVendorCode_WHTTab.Text;
           if (Vendorcode == "")
           {
               Vendorcode = "0";
           }
           colvendorlist = objvendor.GetVendorList_ByVendorCode(Vendorcode);
           GdvSearch.Visible = false;
           Gdvlookup.Visible = false;
           GdvVendorList.Visible = true;
           GdvVendorList.DataSource = colvendorlist;
           GdvVendorList.DataBind();
           ModalPopupExtender1.Show();
            
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- Search Vendor By Keyword(ImgBtnCodeWHT_Click) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    } 
    protected void BtnAddtraveldetails_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime fromdate = new DateTime();
            DateTime todate = new DateTime();
            #region Update item

           // if (BtnAddtraveldetails.Text == "Update Line")
            if(BtnAddtraveldetails.ImageUrl=="~/Images/btn_update.png")
            {
                objjournalvoucher_travel.CountryClass = Convert.ToInt32(Ddlcountryclass.SelectedValue);
                if (TxtNoOfDays.Text != "")
                {
                    objjournalvoucher_travel.NoOfDays = Convert.ToInt32(TxtNoOfDays.Text);
                }

                if (Txtfromdate_travaldetails.Text != "")
                {
                    fromdate = DateTime.ParseExact(Txtfromdate_travaldetails.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    fromdate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }

                if (Txttodate_travaldetails.Text != "")
                {
                    todate = DateTime.ParseExact(Txttodate_travaldetails.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    todate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }

                objjournalvoucher_travel.FromDate = fromdate;
                objjournalvoucher_travel.ToDate = todate;
                if (TxtDA_traveldetails.Text != "")
                {
                    objjournalvoucher_travel.DA = Convert.ToDouble(TxtDA_traveldetails.Text);
                }
                if (TxtOtherCost_traveldetails.Text != "")
                {
                    objjournalvoucher_travel.OtherCost = Convert.ToDouble(TxtOtherCost_traveldetails.Text);
                }
                objjournalvoucher_travel.CreatedBy = Session["userid"].ToString();
                objjournalvoucher_travel.VoucherNo = TxtVoucherNo.Text;
                if (ViewState["travellinenoforupdating"] != null)
                {
                    objjournalvoucher_travel.TravelLineNo = Convert.ToInt32(ViewState["travellinenoforupdating"]);
                }
                int updated = objjournalvoucher_travel.UpdateJournal_TravelDetails();
                if (updated == 1)
                {
                    BindTravelDetails(TxtVoucherNo.Text);
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.UpdatedRecord, 125, 300);
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.RecordNotUpdated, 125, 300);
                }
            }
            #endregion
            else
            {
                DataTable dttraveldetails = null;
                int TravelLineNo, NoOfDays = 0;
                string EmpCode, EmpName, CountryClass;
                double DA = 0.0;
                string FromDate, ToDate;

                if (ViewState["TravelLineNo"] != null)
                {
                    TravelLineNo = Convert.ToInt32(ViewState["TravelLineNo"]);
                }
                else
                {
                    TravelLineNo = 10;
                }
                EmpCode = TxtEmpCode_travaldetailstab.Text;
                EmpName = TxtEmployeeName.Text;
                CountryClass = Ddlcountryclass.SelectedValue;
                if (TxtNoOfDays.Text != "")
                {
                    NoOfDays = Convert.ToInt32(TxtNoOfDays.Text);
                }
                FromDate = Txtfromdate_travaldetails.Text;
                ToDate = Txttodate_travaldetails.Text;
                if (TxtDA_traveldetails.Text != "")
                {
                    DA = Convert.ToDouble(TxtDA_traveldetails.Text);
                }
                if (ViewState["TravelsDetails"] != null)
                {
                    dttraveldetails = (DataTable)ViewState["TravelsDetails"];
                }
                else
                {
                    dttraveldetails = new DataTable();
                    dttraveldetails.Columns.Add("TravelLineNo", typeof(int));
                    dttraveldetails.Columns.Add("EmpCode", typeof(string));
                    dttraveldetails.Columns.Add("EmpName", typeof(string));
                    dttraveldetails.Columns.Add("CountryClass", typeof(string));
                    dttraveldetails.Columns.Add("NoOfDays", typeof(int));
                    dttraveldetails.Columns.Add("DA", typeof(double));
                    dttraveldetails.Columns.Add("FromDate", typeof(string));
                    dttraveldetails.Columns.Add("ToDate", typeof(string));
                    dttraveldetails.Columns.Add("OtherCost", typeof(string));
                }
                DataRow drow = dttraveldetails.NewRow();
                if (ViewState["TravelLineNo"] != null)
                {
                    drow["TravelLineNo"] = 10 + TravelLineNo;  //need to ask 
                }
                else
                {
                    drow["TravelLineNo"] = TravelLineNo;  //need to ask 
                }
                drow["EmpCode"] = EmpCode;
                drow["EmpName"] = EmpName;
                drow["CountryClass"] = CountryClass;
                drow["NoOfDays"] = NoOfDays;
                drow["FromDate"] = FromDate;
                drow["ToDate"] = ToDate;
                drow["DA"] = DA;
                drow["OtherCost"] = DA;
                dttraveldetails.Rows.Add(drow);
                ViewState["TravelsDetails"] = dttraveldetails;
                ViewState["TravelLineNo"] = drow["TravelLineNo"];
                GdvTravelDetails.DataSource = dttraveldetails;
                GdvTravelDetails.DataBind();
                ClearTravelDetails();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-Adding Line Item in TravelDetails Tab-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BtnAddWhtDetails_Click(object sender, EventArgs e)
    {
        try
        {
            #region Update item
           // if (BtnAddWhtDetails.Text == "Update Item")
            if (BtnAddWhtDetails.ImageUrl == "~/Images/btn_update.png")
            {
                objjournalvoucher_wht.VoucherNo = TxtVoucherNo.Text;
                if (TxtWHTGroup.Text != "")
                {
                    objjournalvoucher_wht.WhtGroup = Convert.ToInt32(TxtWHTGroup.Text);
                }
                objjournalvoucher_wht.WhtType = DdlWhtType.SelectedValue;
                if (TxtBaseAmount_WHTTab.Text != "")
                {
                    objjournalvoucher_wht.BaseAmount = Convert.ToDouble(TxtBaseAmount_WHTTab.Text);
                }
                if (TxtWhtrate.Text != "")
                {
                    objjournalvoucher_wht.WhtRate = Convert.ToDouble(TxtWhtrate.Text);
                }
                if (TxtWhtAmount.Text != "")
                {
                    objjournalvoucher_wht.WhtAmount = Convert.ToDouble(TxtWhtAmount.Text);
                }
                objjournalvoucher_wht.CreatedBy = Session["userid"].ToString();

                if (ViewState["whtlinenoforupdating"] != null)
                {
                    objjournalvoucher_wht.WhtLineNo = Convert.ToInt32(ViewState["whtlinenoforupdating"]);
                }
                objjournalvoucher_wht.VendorCode = TxtVendorCode.Text;
                objjournalvoucher_wht.VendorName = TxtVendorName.Text;
                int updated=objjournalvoucher_wht.UpdateJournal_Whtdetails();
                if (updated == 1)
                {
                    BindWHTDetails(TxtVoucherNo.Text);
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.UpdatedRecord, 125, 300);
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.RecordNotUpdated, 125, 300);
                }
            }
            #endregion
            else
            {
                DataTable dtwhtdetails = null;
                int WHTLineNo;
                string VendorCode, VendorName, WHTGroup, WHTType, WHTRate;
                double WHTAmount = 0.0, BaseAmount = 0.0;
                if (ViewState["WHTLnNo"] != null)
                {
                    WHTLineNo = Convert.ToInt32(ViewState["WHTLnNo"]);
                }
                else
                {
                    WHTLineNo = 10;
                }
                VendorCode = TxtVendorCode_WHTTab.Text;
                VendorName = TxtVenderName_WHTTab.Text;
                WHTGroup = TxtWHTGroup.Text;
                WHTType = DdlWhtType.SelectedItem.Value;
                if (TxtBaseAmount_WHTTab.Text != "")
                {
                    BaseAmount = Convert.ToDouble(TxtBaseAmount_WHTTab.Text);
                }
                WHTRate = TxtWhtrate.Text;
                if (TxtWhtAmount.Text != "")
                {
                    WHTAmount = Convert.ToDouble(TxtWhtAmount.Text);
                }
                if (ViewState["WHTDetails"] != null)
                {
                    dtwhtdetails = (DataTable)ViewState["WHTDetails"];
                }
                else
                {
                    dtwhtdetails = new DataTable();
                    dtwhtdetails.Columns.Add("WHTLineNo", typeof(int));
                    dtwhtdetails.Columns.Add("WHTGroup", typeof(string));
                    dtwhtdetails.Columns.Add("WhtType", typeof(string));
                    dtwhtdetails.Columns.Add("WHTAmount", typeof(double));
                    dtwhtdetails.Columns.Add("WHTRate", typeof(string));
                    dtwhtdetails.Columns.Add("BaseAmount", typeof(double));
                    dtwhtdetails.Columns.Add("VendorCode", typeof(string));
                    dtwhtdetails.Columns.Add("VendorName", typeof(string));
                  
                }
                DataRow drow = dtwhtdetails.NewRow();
                if (ViewState["WHTLnNo"] != null)
                {
                    drow["WHTLineNo"] = 10 + WHTLineNo;
                }
                else
                {
                    drow["WHTLineNo"] = WHTLineNo;
                }
           
                drow["WHTGroup"] = WHTGroup;
                drow["WhtType"] = WHTType;
                drow["WHTAmount"] = WHTAmount;
                drow["WHTRate"] = WHTRate;
                drow["BaseAmount"] = BaseAmount;
                drow["VendorCode"] = VendorCode;
                drow["VendorName"] = VendorName;
                dtwhtdetails.Rows.Add(drow);
                ViewState["WHTDetails"] = dtwhtdetails;
                ViewState["WHTLnNo"] = drow["WHTLineNo"];
                GdvWhtDetails.DataSource = dtwhtdetails;
                GdvWhtDetails.DataBind();

                ClearWHTDetails();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-Adding Line Item in WHT Tab-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BtnAdd_VatDetails_Click(object sender, EventArgs e)
    {
        try
        {
            #region Update item
          //  if (BtnAdd_VatDetails.Text == "Update Line")
            if (BtnAdd_VatDetails.ImageUrl == "~/Images/btn_update.png")
            {
                DateTime invoicedate = new DateTime();
                if (TxtBaseAmount.Text != "")
                {
                    objjournalvoucher_vat.BaseAmount = Convert.ToDouble(TxtBaseAmount.Text);
                }

                if (TxtTaxAmount.Text != "")
                {
                    objjournalvoucher_vat.VAmount = Convert.ToDouble(TxtTaxAmount.Text);
                }
                objjournalvoucher_vat.TaxInvoice = TxtTaxInvoice.Text;

                if (TxtTaxInvoiceDate.Text != "")
                {
                    invoicedate = DateTime.ParseExact(TxtTaxInvoiceDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    invoicedate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                objjournalvoucher_vat.TaxInvoiceDate = invoicedate;

                if (TxtRate.Text != "")
                {
                    objjournalvoucher_vat.Rate = Convert.ToDouble(TxtRate.Text);
                }
                objjournalvoucher_vat.VoucherNo = TxtVoucherNo.Text;
                if (ViewState["vatlinenoforupdating"] != null)
                {
                    objjournalvoucher_vat.VatLineNo = Convert.ToInt32(ViewState["vatlinenoforupdating"]);
                }
                objjournalvoucher_vat.CreatedBy = Session["userid"].ToString();
                int updated = objjournalvoucher_vat.UpdateJournalVatdetails();
                if (updated == 1)
                {
                    BindVatDetails(TxtVoucherNo.Text);
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.UpdatedRecord, 125, 300);
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.RecordNotUpdated, 125, 300);
                }

            }
            #endregion
            else
            {
                DataTable dt = null;
                int VatLineNo;
                string VendorCode, TaxIncoice;
                double BaseAmount = 0.0, VAmount = 0.0;
                string TaxInvoiceDate;
                if (ViewState["VatLnNo"] != null)
                {
                    VatLineNo = Convert.ToInt32(ViewState["VatLnNo"]);
                }
                else
                {
                    VatLineNo = 10;
                }
                if (TxtTaxAmount.Text != "")
                {
                    VAmount = Convert.ToDouble(TxtTaxAmount.Text);
                }
                VendorCode = TxtVendorCode.Text;
                TaxIncoice = TxtTaxInvoice.Text;
                if (TxtBaseAmount.Text != "")
                {
                    BaseAmount = Convert.ToDouble(TxtBaseAmount.Text);
                }
                TaxInvoiceDate = TxtTaxInvoiceDate.Text;
                if (ViewState["VatDetails"] != null)
                {
                    dt = (DataTable)ViewState["VatDetails"];
                }
                else
                {
                    dt = new DataTable();
                    dt.Columns.Add("VatLineNo", typeof(int));
                    dt.Columns.Add("VendorCode", typeof(string));
                    dt.Columns.Add("BaseAmount", typeof(double));
                    dt.Columns.Add("VAmount", typeof(double));
                    dt.Columns.Add("TaxInvoice", typeof(string));
                    dt.Columns.Add("TaxInvoiceDate", typeof(string));
                    dt.Columns.Add("VendorName", typeof(string));
                    dt.Columns.Add("Rate", typeof(string));
                }
                DataRow drow = dt.NewRow();
                if (ViewState["VatDetails"] != null)
                {
                    drow["VatLineNo"] = 10 + VatLineNo;
                }
                else
                {
                    drow["VatLineNo"] = VatLineNo;
                }
                drow["VendorCode"] = VendorCode;
                drow["BaseAmount"] = BaseAmount;
                drow["VAmount"] = VAmount;
                drow["TaxInvoice"] = TaxIncoice;
                drow["TaxInvoiceDate"] = TaxInvoiceDate;
                drow["VendorName"] = TxtVendorName.Text;
                drow["Rate"] = TxtRate.Text;
                dt.Rows.Add(drow);
                ViewState["VatDetails"] = dt;
                ViewState["VatLnNo"] = drow["VatLineNo"];
                GdvVatDetails.DataSource = dt;
                GdvVatDetails.DataBind();
                ClearVatDetails();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-Adding Vat lines Numbers-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void btn_Search_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClearDetails();
            ClearMainDetails();
            DropDownList ddsearch = (DropDownList)Master.FindControl("dd_search");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            coljornalvoucher = objjournalvoucher.Search_JournalVoucher(txtSearch.Text.Trim());
            GdvVendorList.Visible = false;
            GdvSearch.Visible = true;
            Gdvlookup.Visible = false;
            lSearchList.Text = "Search by Voucher Id";
            HidPopUpType.Value = "searchgrid";
            GdvSearch.DataSource = coljornalvoucher;
            GdvSearch.DataBind();
            foreach (GridViewRow oldrow in GdvSearch.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton5");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                oldrow.BackColor = Color.White;
            }
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-SearchingforkeywordinTopofPage-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    
    
    protected void BtnAddLine_Click(object sender, EventArgs e)
    {
        try
        {
            int GLCode, SLCode, LineNo;
            string GLGroupCode, GLGroupName;
            double DebitAmount = 0.0, CreditAmount = 0.0, PCenter, Ccenter;
            bool IsEmployeecodeSelected = false;
            DataTable dt = null;
            #region Check if GLCode has subsidary Ledger flag checked then SLCode is mandatory
            GLCode = Convert.ToInt32(DdlGLCode.SelectedValue);
            bool slcodechecked = false;
            objglmaster = objglmaster.GetGLCode_ById(GLCode);
            slcodechecked = objglmaster.Subglflag;
            GLGroupCode = objglmaster.GroupCode;
            if (slcodechecked == true)
            {
                if (DdlSubGLCode.SelectedValue  == "0")
                {
                    string message = "You have selected G.L code which has Subsidary Ledger. Please select Sub-Code also";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, message, 125, 300);
                    return;
                }
            }
            #endregion
            #region If the GL code is an income or an expenditure group then this entry for Cost center code is mandatory.
            objglgroupmaster = objglgroupmaster.GetGLGroupName_ById(Convert.ToInt32(GLGroupCode));
            GLGroupName = objglgroupmaster.GLGroupName;
            if (GLGroupName == "Income" || GLGroupName == "Expenditure")
            {
                if (DdlCostCenter.SelectedItem.Text == "----Select----")
                {
                    string message = "You have selected G.L code which has Income/Expenditure Group. Please enter Cost Center Code also.";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, message, 125, 300);
                    return;
                }
            }
            #endregion
            #region If Employee code is checked in GL code then the employee code is mandatory
            IsEmployeecodeSelected = objglmaster.EmployeeCode;
            if (IsEmployeecodeSelected == true)
            {
                if (TxtEmpCode.Text == "")
                {
                    string message = "Employee code is mandatory for this G.L Code.";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, message, 125, 300);
                    return;
                }
            }
            #endregion
            #region Sub-Project Code is mandatory if project code is selected
            if (DdlProject.SelectedItem.Text != "----Select----")
            {
                if (DdlSubProject.SelectedItem.Text == "----Select----")
                {
                    string message = "Please select SubProject.";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, message, 125, 300);
                    return;
                }
            }
            #endregion

            if (ViewState["MainLineNo"] != null)
            {
                //LineNo = Convert.ToInt32(ViewState["MainLineNo"]) + 10; changed by lalit 25
                LineNo = Convert.ToInt32(ViewState["MainLineNo"])+10;
            }
            else
            {
                //#region Get Last line no from detail table            changed by lalit 25
                //int lineno = objjournalvoucher.GetLastLineNo();
                //lineno = lineno + 10;
                //LineNo = lineno;
                //#endregion
                LineNo=10;
            }
            GLCode = Convert.ToInt32(DdlGLCode.SelectedValue);
            SLCode = Convert.ToInt32(DdlSubGLCode.SelectedValue);
            if (TxtDebitAmount.Text != "")
            {
                DebitAmount = Convert.ToDouble(TxtDebitAmount.Text);
            }
            if (TxtCreditAmount.Text != "")
            {
                CreditAmount = Convert.ToDouble(TxtCreditAmount.Text);
            }

            PCenter = Convert.ToDouble(DdlProfitCenter.SelectedItem.Value);
            Ccenter = Convert.ToDouble(DdlCostCenter.SelectedItem.Value);
            if (ViewState["Journal"] != null)
            {
                dt = (DataTable)ViewState["Journal"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Line#", typeof(int));
                dt.Columns.Add("GLCode", typeof(int));
                dt.Columns.Add("SLCode", typeof(int));
                dt.Columns.Add("Debit Amount", typeof(double));
                dt.Columns.Add("Credit Amount", typeof(double));
                dt.Columns.Add("Profit Center", typeof(double));
                dt.Columns.Add("Cost center", typeof(double));
                dt.Columns.Add("Asset", typeof(string));
                dt.Columns.Add("FxAmount", typeof(double));
                dt.Columns.Add("ChequeNo", typeof(string));
                dt.Columns.Add("ChequeDate", typeof(string));
                dt.Columns.Add("Project", typeof(string));
                dt.Columns.Add("SubProject", typeof(string));
                dt.Columns.Add("EmpCode", typeof(string));
                dt.Columns.Add("Narration", typeof(string));
            }
            DataRow drow = dt.NewRow();
            if (ViewState["MainLineNo"] != null)
            {
                drow["Line#"] = LineNo;
            }
            else
            {
                drow["Line#"] = LineNo;  //need to ask 
            }
            drow["GLCode"] = GLCode;
            drow["SLCode"] = SLCode;
            drow["Debit Amount"] = DebitAmount;
            drow["Credit Amount"] = CreditAmount;
            drow["Profit Center"] = PCenter;
            drow["Cost center"] = Ccenter;
            drow["Asset"] = TxtAsset.Text;
            if (TxtFxAmount.Text != "")
            {
                drow["FxAmount"] = TxtFxAmount.Text;
            }
            drow["ChequeNo"] = TxtChequeNo.Text;
            if (TxtChequeDate.Text != "")
            {
                drow["ChequeDate"] = TxtChequeDate.Text;
            }
            drow["Project"] = DdlProject.SelectedValue;
            drow["SubProject"] = DdlSubProject.SelectedValue;
            drow["EmpCode"] = TxtEmpCode.Text;
            drow["Narration"] = TxtNarration.Text;
            dt.Rows.Add(drow);
            ViewState["Journal"] = dt;
            ViewState["MainLineNo"] = drow["Line#"];
            GdvDescription.Visible = true;
            GdvDescription.DataSource = dt;
            GdvDescription.DataBind();
            if (TxtTotalDebit.Text != "")
            {
                TxtTotalDebit.Text = (DebitAmount + Convert.ToDouble(TxtTotalDebit.Text)).ToString();
            }
            else
            {
                TxtTotalDebit.Text = DebitAmount.ToString();
            }
            if (TxtTotalCredit.Text != "")
            {
                TxtTotalCredit.Text = (CreditAmount + Convert.ToDouble(TxtTotalCredit.Text)).ToString();
            }
            else
            {
                TxtTotalCredit.Text = CreditAmount.ToString();
            }
            ClearDetails();
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-Adding Line Item in Main Tab-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region DropDown Selected Index Changed Events
    protected void DdlCurrencyType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DdlCurrencyType.SelectedItem.Text == "Dollar")
            {
                TxtExchangeRate.Text = "1";

            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form--Writing Exchange Rate on the selection of Currency drop down --Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void DdlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int projectid = Convert.ToInt32(DdlProject.SelectedValue);
            colsubprojectcode = objsubprojectcode.GetSubProject_ByProjectId(projectid);
            DdlSubProject.DataSource = colsubprojectcode;
            DdlSubProject.DataTextField = "SubProjectName";
            DdlSubProject.DataValueField = "SubProjectCode";
            DdlSubProject.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlSubProject.Items.Add(item);
            DdlSubProject.SelectedValue = "0";

        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form-Binding SubProject on basis of Project-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
       
}