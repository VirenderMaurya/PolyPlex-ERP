#region /////////////////// Designed and Developed by Lalit Joshi 10th May 2012///////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_transaction_InvoiceVerification : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    BLLCollection<FA_VoucherSeries> colseries = new BLLCollection<FA_VoucherSeries>();
    FA_VoucherSeries objVoucherSeries = new FA_VoucherSeries();
    BLLCollection<FA_Currencymaster> colcurrencymaster = new BLLCollection<FA_Currencymaster>();
    FA_Currencymaster objcurrencymaster = new FA_Currencymaster();
    BLLCollection<FA_VendorMaster> colvendorlist = new BLLCollection<FA_VendorMaster>();
    FA_VendorMaster objvendor = new FA_VendorMaster();
    Common com = new Common();
    Common_Message commessage = new Common_Message();
    FA_InvoiceVerification objinvoiceverif = new FA_InvoiceVerification();
    BLLCollection<FA_InvoiceVerification> colinvoice = new BLLCollection<FA_InvoiceVerification>();
    #endregion

    #region Pageload Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                BindSearchDropDown("113");
                BindVoucherSeries();
                BindCurrency();
                BindIVType();
                readonlycontrols();
                Log.PageHeading(this, "Invoice Verification Form");
                Log.GetLog().FillFinancialYear(TxtVoucherYear);
            }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- Page_Load Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Bind Events
    private void BindMasterSearchBox()
    {
        try
        {
            ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
            btn_search.CausesValidation = false;
            btn_search.Click += new ImageClickEventHandler(btn_search_Click);
            ImageButton btnAdd = (ImageButton)Master.FindControl("btnAdd");
            btnAdd.CausesValidation = false;
            btnAdd.Click += new ImageClickEventHandler(btnAdd_Click);
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- BindMasterSearchBox Method -Error-" + ex.ToString();
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
            logmessage = "Invoice Verification Form- BindSearchDropDown Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void readonlycontrols()
    {
        try
        {
            TxtVoucherYear.Attributes.Add("readonly", "true");
            TxtVoucherNo.Attributes.Add("readonly", "true");
            TxtVoucherDate.Attributes.Add("readonly", "true");
            TxtVendor.Attributes.Add("readonly", "true");
            TxtPO.Attributes.Add("readonly", "true");
            TxtGR.Attributes.Add("readonly", "true");
            TxtDueDate.Attributes.Add("readonly", "true");
            TxtTaxInvoiceDate.Attributes.Add("readonly", "true");
            TxtPOinLC.Attributes.Add("readonly", "true");
            TxtPOFXalreadycreated.Attributes.Add("readonly", "true");
            TxtPaymentTermsinPO.Attributes.Add("readonly", "true");
            TxtExRateinPO.Attributes.Add("readonly", "true");
            TxtFXValueinPO.Attributes.Add("readonly", "true");
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- readonlycontrols Method -Error-" + ex.ToString();
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
            logmessage = "Invoice Verification Form-BindingVoucherSeries-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindCurrency()
    {
        try
        {
            colcurrencymaster = objcurrencymaster.GetCurrencyList();
            DdlCurrency.DataSource = colcurrencymaster;
            DdlCurrency.DataTextField = "CurrencyName";
            DdlCurrency.DataValueField = "CurrencyName";
            DdlCurrency.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlCurrency.Items.Add(item);
            DdlCurrency.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form-BindingCurrency-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindIVType()
    {
        try
        {
            DataTable dtivtype = new DataTable();
            dtivtype = com.executeProcedure("Sp_FA_Get_IVType");
            DdlIVType.DataTextField = "IVName";
            DdlIVType.DataValueField = "Id";
            DdlIVType.DataSource = dtivtype;
            DdlIVType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlIVType.Items.Add(item);
            DdlIVType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form-BindIVType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindVendorList()
    {
        try
        {
            colvendorlist = objvendor.GetVendorList_ByVendorCode("0");
            GdvVendorList.DataSource = colvendorlist;
            GdvVendorList.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindPO()
    {
        try
        {
            DataTable dt = com.executeProcedure("Sp_FA_GetPODetails");
            gridMaster.Visible = false;
            GdvGR.Visible = false;
            GdvVendorList.Visible = false;
            GdvPONO.DataSource = dt;
            GdvPONO.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- BindPO() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void ClearItems()
    {
        TxtAdjValue.Text = "";
        TxtAdjVat.Text = "";
        TxtDueDate.Text = "";
        TxtExchangeRate.Text = "";
        TxtExRateinPO.Text = "";
        TxtFxValue.Text = "";
        TxtFXValueinPO.Text = "";
        TxtGR.Text = "";
        TxtImpDuty.Text = "";
        TxtPaymentTermsinPO.Text = "";
        TxtPO.Text = "";
        TxtPOFXalreadycreated.Text = "";
        TxtPOinLC.Text = "";
        txtSearchList.Text = "";
        TxtTaxInvoice.Text = "";
        TxtTaxInvoiceDate.Text = "";
        TxtValueinLC.Text = "";
        TxtVat.Text = "";
        TxtVendor.Text = "";
        TxtVoucherDate.Text = "";
        TxtVoucherNo.Text = "";
        DdlCurrency.SelectedValue = "0";
        DdlIVType.SelectedValue = "0";
        DdlVoucherSeries.SelectedValue = "0";
        Log.GetLog().FillFinancialYear(TxtVoucherYear);
    }
    protected void BindGR()
    {
        try
        {
            DataTable dt = com.executeProcedure("Sp_Com_Get_GRNo");
            GdvGR.DataSource = dt;
            GdvGR.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- BindGR() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Button Click Events
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Btnsave.ImageUrl = "~/Images/btnSave.png";
        ClearItems();
    }
    void btn_search_Click(object sender, ImageClickEventArgs e)
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
                if (ddsearch.SelectedItem.Value == "VoucherNo")
                {
                    lSearchList.Text = "Search by VoucherNo";
                    colinvoice = objinvoiceverif.GetAllVoucherno(txtSearch.Text.Trim());
                }
                gridMaster.Visible = true;
                GdvGR.Visible = false;
                GdvPONO.Visible = false;
                GdvVendorList.Visible = false;
                gridMaster.DataSource = colinvoice;
                gridMaster.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- btn_search_Click Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            #region local variables
            double POValueinLC = 0.0, POFXAlreadyCreated = 0.0, ExRateinPO = 0.0, FXValueinPO = 0.0,
            Vat = 0.0, AdjValue = 0.0, AdjVat = 0.0, ImpDuty = 0.0, FXValue = 0.0, ExchangeRate = 0.0,
            ValueInLC = 0.0;
            #endregion
            #region update event
            if (Btnsave.ImageUrl == "~/Images/btn_update.png")
            {
                if (TxtPOinLC.Text != "")
                {
                    POValueinLC = Convert.ToDouble(TxtPOinLC.Text);
                }

                if (TxtPOFXalreadycreated.Text != "")
                {
                    POFXAlreadyCreated = Convert.ToDouble(TxtPOFXalreadycreated.Text);
                }
                if (TxtExRateinPO.Text != "")
                {
                    ExRateinPO = Convert.ToDouble(TxtExRateinPO.Text);
                }
                if (TxtFXValueinPO.Text != "")
                {
                    FXValueinPO = Convert.ToDouble(TxtFXValueinPO.Text);
                }
                if (TxtVat.Text != "")
                {
                    Vat = Convert.ToDouble(TxtVat.Text);
                }
                if (TxtAdjValue.Text != "")
                {
                    AdjValue = Convert.ToDouble(TxtAdjValue.Text);
                }
                if (TxtAdjVat.Text != "")
                {
                    AdjVat = Convert.ToDouble(TxtAdjVat.Text);
                }
                if (TxtImpDuty.Text != "")
                {
                    ImpDuty = Convert.ToDouble(TxtImpDuty.Text);
                }
                if (TxtFxValue.Text != "")
                {
                    FXValue = Convert.ToDouble(TxtFxValue.Text);
                }
                if (TxtExchangeRate.Text != "")
                {
                    ExchangeRate = Convert.ToDouble(TxtExchangeRate.Text);
                }
                if (TxtValueinLC.Text != "")
                {
                    ValueInLC = Convert.ToDouble(TxtValueinLC.Text);
                }
                string modifiedby = Session["userId"].ToString();
                int updated = objinvoiceverif.UpdateInvoiceVerification(TxtVoucherNo.Text, DdlVoucherSeries.SelectedValue, TxtVoucherYear.Text, DdlIVType.SelectedValue,
                             TxtVoucherDate.Text, TxtGR.Text, TxtPO.Text, TxtVendor.Text, POValueinLC, TxtTaxInvoice.Text, TxtTaxInvoiceDate.Text, TxtDueDate.Text,
                            POFXAlreadyCreated, TxtPaymentTermsinPO.Text, ExRateinPO, FXValueinPO, Vat, AdjValue, AdjVat, ImpDuty, FXValue, DdlCurrency.SelectedValue,
                             ExchangeRate, ValueInLC, modifiedby);
                if (updated == 1)
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.UpdatedRecord, 125, 300);
                    return;
                }
            }
            #endregion
            #region insert event
            else
            {
                objinvoiceverif.VoucherSeries = DdlVoucherSeries.SelectedValue;
                objinvoiceverif.VoucherYear = TxtVoucherYear.Text;
                objinvoiceverif.IVType = DdlIVType.SelectedValue;
                objinvoiceverif.VoucherDate = TxtVoucherDate.Text;
                objinvoiceverif.GR = TxtGR.Text;
                objinvoiceverif.PO = TxtPO.Text;
                objinvoiceverif.Vendor = TxtVendor.Text;
                if (TxtPOinLC.Text != "")
                {
                    POValueinLC = Convert.ToDouble(TxtPOinLC.Text);
                }
                objinvoiceverif.POValueInLC = POValueinLC;
                objinvoiceverif.TaxInvoice = TxtTaxInvoice.Text;
                objinvoiceverif.TaxInvoiceDate = TxtTaxInvoiceDate.Text;
                objinvoiceverif.DueDate = TxtDueDate.Text;
                if (TxtPOFXalreadycreated.Text != "")
                {
                    POFXAlreadyCreated = Convert.ToDouble(TxtPOFXalreadycreated.Text);
                }
                objinvoiceverif.POFxValueAlreadyCreated = POFXAlreadyCreated;
                objinvoiceverif.PaymentTermsInPO = TxtPaymentTermsinPO.Text;
                if (TxtExRateinPO.Text != "")
                {
                    ExRateinPO = Convert.ToDouble(TxtExRateinPO.Text);
                }
                objinvoiceverif.ExchangerateInPO = ExRateinPO;
                if (TxtFXValueinPO.Text != "")
                {
                    FXValueinPO = Convert.ToDouble(TxtFXValueinPO.Text);
                }
                objinvoiceverif.FxValueInPO = FXValueinPO;
                if (TxtVat.Text != "")
                {
                    Vat = Convert.ToDouble(TxtVat.Text);
                }
                objinvoiceverif.Vat = Vat;
                if (TxtAdjValue.Text != "")
                {
                    AdjValue = Convert.ToDouble(TxtAdjValue.Text);
                }
                objinvoiceverif.AdjValue = AdjValue;
                if (TxtAdjVat.Text != "")
                {
                    AdjVat = Convert.ToDouble(TxtAdjVat.Text);
                }
                objinvoiceverif.VatAdj = AdjVat;
                if (TxtImpDuty.Text != "")
                {
                    ImpDuty = Convert.ToDouble(TxtImpDuty.Text);
                }
                objinvoiceverif.ImportDuty = ImpDuty;
                if (TxtFxValue.Text != "")
                {
                    FXValue = Convert.ToDouble(TxtFxValue.Text);
                }
                objinvoiceverif.FxValue = FXValue;
                objinvoiceverif.Currency = DdlCurrency.SelectedValue;
                if (TxtExchangeRate.Text != "")
                {
                    ExchangeRate = Convert.ToDouble(TxtExchangeRate.Text);
                }
                objinvoiceverif.ExchangeRate = ExchangeRate;
                if (TxtValueinLC.Text != "")
                {
                    ValueInLC = Convert.ToDouble(TxtValueinLC.Text);
                }
                objinvoiceverif.ValueInLC = ValueInLC;
                objinvoiceverif.CreatedBy = Session["userid"].ToString();
                int inserted = objinvoiceverif.InsertInvoiceVerification();
                if (inserted == 1)
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordSaved, 125, 300);
                    return;
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, commessage.RecordNotSaved, 125, 300);
                    return;
                }
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- Btnsave_Click Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridVendorlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string DataKey = GdvVendorList.SelectedDataKey.Value.ToString();
            TxtVendor.Text = DataKey;
            int index = GdvVendorList.SelectedIndex;
            TxtVendor.Text = ((Label)(GdvVendorList.Rows[index].FindControl("lblvendorcode"))).Text.ToString();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- gridVendorlist_SelectedIndexChanged -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvPONO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string DataKey = GdvPONO.SelectedDataKey.Value.ToString();
            TxtPO.Text = DataKey;
            int index = GdvPONO.SelectedIndex;
            TxtPOinLC.Text = GdvPONO.Rows[index].Cells[2].Text;
            TxtPOFXalreadycreated.Text = GdvPONO.Rows[index].Cells[5].Text;
            TxtPaymentTermsinPO.Text = GdvPONO.Rows[index].Cells[3].Text;
            TxtExRateinPO.Text = GdvPONO.Rows[index].Cells[4].Text;

        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- Select event for(GdvPONO_SelectedIndexChanged) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            string key = txtSearchList.Text.Trim();
            if (GdvVendorList.Visible == true)
            {
                lSearchList.Text = "Search by Vendor Code";
                colvendorlist = objvendor.GetVendorList_ByVendorCode(key);
                GdvVendorList.Visible = true;
                GdvVendorList.DataSource = colvendorlist;
                GdvVendorList.DataBind();
            }
            if (GdvGR.Visible == true)
            {
                lSearchList.Text = "Search by GR Number";
                GdvGR.Visible = true;
                DataTable dt = com.GetVal("@grnumber", key, "Sp_Com_Get_GRNo_ByGRNo");
                GdvGR.DataSource = dt;
                GdvGR.DataBind();
            }
            if (GdvPONO.Visible == true)
            {
                lSearchList.Text = "Search by PO Number";
                DataTable dt = com.GetVal("@ponumber", key, "Sp_FA_GetPODetails_By_PoNo");
                GdvPONO.Visible = true;
                GdvPONO.DataSource = dt;
                GdvPONO.DataBind();
            }
            if (gridMaster.Visible == true)
            {
                colinvoice = objinvoiceverif.GetAllVoucherno(key);
                gridMaster.Visible = true;
                gridMaster.DataSource = colinvoice;
                gridMaster.DataBind();
            }
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- btnSearchlist_Click Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search by Vendor Code";
            txtSearchList.Text = "";
            GdvPONO.Visible = false;
            GdvGR.Visible = false;
            gridMaster.Visible = false;
            GdvVendorList.Visible = true;
            BindVendorList();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- Search Vendor By Keyword(ImgBtnCode_Click) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void ImgBtnGR_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search by GR Number";
            txtSearchList.Text = "";
            GdvVendorList.Visible = false;
            GdvPONO.Visible = false;
            GdvVendorList.Visible = false;
            gridMaster.Visible = false;
            GdvGR.Visible = true;
            BindGR();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- ImgBtnGR_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnPO_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lSearchList.Text = "Search by PO Number";
            txtSearchList.Text = "";
            GdvVendorList.Visible = false;
            GdvGR.Visible = false;
            gridMaster.Visible = false;
            GdvPONO.Visible = true;
            BindPO();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- ImgBtnGR_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region GridEvents
    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gridMaster.PageIndex = e.NewPageIndex;
            colinvoice = objinvoiceverif.GetAllVoucherno("");
            gridMaster.DataSource = colinvoice;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- gridMaster_PageIndexChanging Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string voucherno = gridMaster.SelectedDataKey.Value.ToString();
            ViewState["vno"] = voucherno;
            objinvoiceverif = objinvoiceverif.GetInvoiceVerification_HeaderInfo_By_Voucherno(voucherno);
            DdlVoucherSeries.SelectedValue = objinvoiceverif.VoucherSeries;
            TxtVoucherNo.Text = voucherno;
            TxtVoucherYear.Text = objinvoiceverif.VoucherYear;
            DdlIVType.SelectedValue = objinvoiceverif.IVType;
            TxtVoucherDate.Text = objinvoiceverif.VoucherDate;
            TxtGR.Text = objinvoiceverif.GR;
            TxtPO.Text = objinvoiceverif.PO;
            TxtVendor.Text = objinvoiceverif.Vendor;
            TxtPOinLC.Text = objinvoiceverif.POValueInLC.ToString();
            TxtTaxInvoice.Text = objinvoiceverif.TaxInvoice;
            TxtTaxInvoiceDate.Text = objinvoiceverif.TaxInvoiceDate;
            TxtDueDate.Text = objinvoiceverif.DueDate;
            TxtPOFXalreadycreated.Text = objinvoiceverif.POFxValueAlreadyCreated.ToString();
            objinvoiceverif.PaymentTermsInPO = TxtPaymentTermsinPO.Text;
            TxtExRateinPO.Text = objinvoiceverif.ExchangerateInPO.ToString();
            TxtFXValueinPO.Text = objinvoiceverif.FxValueInPO.ToString();
            TxtVat.Text = objinvoiceverif.Vat.ToString();
            TxtAdjValue.Text = objinvoiceverif.AdjValue.ToString();
            TxtAdjVat.Text = objinvoiceverif.VatAdj.ToString();
            TxtImpDuty.Text = objinvoiceverif.ImportDuty.ToString();
            TxtFxValue.Text = objinvoiceverif.FxValue.ToString();
            DdlCurrency.SelectedValue = objinvoiceverif.Currency;
            TxtExchangeRate.Text = objinvoiceverif.ExchangeRate.ToString();
            TxtValueinLC.Text = objinvoiceverif.ValueInLC.ToString();
            Btnsave.ImageUrl = "~/Images/btn_update.png";
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- gridMaster_SelectedIndexChanged Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void GdvGR_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string DataKey = GdvGR.SelectedDataKey.Value.ToString();
            TxtGR.Text = DataKey;
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- Select event for(GdvGR_SelectedIndexChanged) -Error-" + ex.ToString();
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
            logmessage = "Invoice Verification Form- GdvVendorList_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvPONO_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvPONO.PageIndex = e.NewPageIndex;
            BindPO();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- GdvPONO_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvGR_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvGR.PageIndex = e.NewPageIndex;
            BindGR();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- GdvGR_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

}