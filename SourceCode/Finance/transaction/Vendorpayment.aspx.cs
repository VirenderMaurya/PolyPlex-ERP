#region /////////////////// Designed and Developed by Lalit Joshi 4th May 2012///////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Finance_transaction_Vendorpayment : System.Web.UI.Page
{
    #region Defind Global Objects
    Common com = new Common();
    Common_Message commessage = new Common_Message();
    FA_Glb_WHTType objwhttype = new FA_Glb_WHTType();
    BLLCollection<FA_Glb_WHTType> colwhttype = new BLLCollection<FA_Glb_WHTType>();
    FA_VoucherType objVoucherType = new FA_VoucherType();
    BLLCollection<FA_VoucherType> col = new BLLCollection<FA_VoucherType>();
    BLLCollection<FA_VoucherSeries> colseries = new BLLCollection<FA_VoucherSeries>();
    FA_VoucherSeries objVoucherSeries = new FA_VoucherSeries();
    BLLCollection<FA_VendorInvoice> colvendorinvoice = new BLLCollection<FA_VendorInvoice>();
    FA_VendorInvoice objvendorinvoice = new FA_VendorInvoice();
    BLLCollection<FA_Vendor_Invoice_WHT> colvendorinvoicewht = new BLLCollection<FA_Vendor_Invoice_WHT>();
    FA_Vendor_Invoice_WHT objvendorinvoicewht = new FA_Vendor_Invoice_WHT();
    FA_PaymentToVendor objpaymenttovendor = new FA_PaymentToVendor();
    BLLCollection<FA_VendorMaster> colvendorlist = new BLLCollection<FA_VendorMaster>();
    FA_VendorMaster objvendor = new FA_VendorMaster();
    BLLCollection<FA_Currencymaster> colcurrencymaster = new BLLCollection<FA_Currencymaster>();
    FA_Currencymaster objcurrencymaster = new FA_Currencymaster();
    double BaseAmount=0.0, WHTRate=0.0, WHTAmount=0.0, WHTGroup;
    string WHTType;
    string logmessage = "";
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
     
        try
        {
           if (!IsPostBack)
            {
                BindSearchDropDown("156");
                TabContainer.Visible = false;
                TxtVendorCode.Attributes.Add("readonly", "true");
                Txt_TabPanel1_VendorName.Attributes.Add("readonly", "true");
                BindVoucherType();
                BindVoucherSeries();
                BindCurrency();
                BindWHTType();
                Log.GetLog().FillFinancialYear(TxtYear);
                TabContainer.Tabs[1].Visible = false;
                Log.PageHeading(this, "Payment To Vendor Form");
           }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- PageLoad Event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region User Defined Functions
    #region Binding function
    protected void BindCurrency()
    {
        try
        {
            colcurrencymaster = objcurrencymaster.GetCurrencyList();
            DdlCurency.DataSource = colcurrencymaster;
            DdlCurency.DataTextField = "CurrencyName";
            DdlCurency.DataValueField = "CurrencyName";
            DdlCurency.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlCurency.Items.Add(item);
            DdlCurency.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- Binding Currency Drop Down -Error-" + ex.ToString();
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
            logmessage = "Payment To Vendor Form- Binding Voucher Type Drop Down -Error-" + ex.ToString();
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
            logmessage = "Payment To Vendor Form- Binding Voucher Series Drop Down -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
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
            logmessage = "Vendor Payment Form- BindMasterSearchBox Method -Error-" + ex.ToString();
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
            logmessage = "VendorPayment Form- BindSearchDropDown Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindWHTType()
    {
        try
        {
            colwhttype = objwhttype.GetAllWhtType();
            DdlWHTType.DataSource = colwhttype;
            DdlWHTType.DataTextField = "WhtType";
            DdlWHTType.DataValueField = "Id";
            DdlWHTType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlWHTType.Items.Add(item);
            DdlWHTType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- Binding WHT Drop Down -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
    private void getinvoicebyinvoiceno(string invoiceno)
    {
        try
        {
            colvendorinvoice = objvendorinvoice.Get_Invoices(invoiceno);
            gridMaster.Visible = true;
            GdvVendorList.Visible = false;
            gridMaster.DataSource = colvendorinvoice;
            gridMaster.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- getinvoicebyinvoiceno -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ClearField()
    {
        TxtYear.Text = "";
        TxtVoucherNo.Text = "";
        TxtVoucherDate.Text = "";
        TxtBankAcountNo.Text = "";
        TxtChequeNo.Text = "";
        TxtChequeDate.Text = "";
        TxtExchangeRate.Text = "";
        TxtLocalBankCharges.Text = "";
        TxtForeignBankCharges.Text = "";
        TxtForeignBankChargesInLC.Text = "";
        TxtFx.Text = "";
        TxtAdj.Text = "";
        DdlCurency.SelectedValue = "0";
        DdlVoucherSeries.SelectedValue = "0";
        DdlVoucherType.SelectedValue = "0";
        TabContainer.Visible = false;
        //TxtVendorCode.Text = "";
     }
    protected int AutogenerateVoucherNo()
    {
        string lastvno = "";
        int lastno;
        try
        {
            lastvno = objpaymenttovendor.GetLastVoucherNo();
            if (lastvno == "0")
            {
                lastno = Convert.ToInt32("100");
            }
            else
            {
                lastno = Convert.ToInt32(lastvno);
                lastno = lastno + 1;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- Auto Generate VoucherNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return 0;
        }
        return Convert.ToInt32(lastno);
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
            logmessage = "Payment To Vendor Form- BindVendorList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ClearField();
        }
        catch (Exception ex)
        {
            logmessage = "Payment to vendor Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void GetInvoiceListByVendor()
    {
        try
        {
            string vendorcode = TxtVendorCode.Text;
            if (vendorcode != "")
            {
                colvendorinvoice = objvendorinvoice.Get_VoucherInvoiceById(vendorcode);
                TabContainer.Visible = true;
                GdvVendorInvoice.DataSource = colvendorinvoice;
                GdvVendorInvoice.DataBind();
                if (GdvVendorInvoice.Rows.Count > 0)
                {
                    foreach (GridViewRow row in GdvVendorInvoice.Rows)
                    {
                        Label lblinvoiceno = (Label)row.FindControl("LblInvoiceNo");
                        int invoiceno = Convert.ToInt32(lblinvoiceno.Text);
                        int whtexist = objvendorinvoicewht.IsWHTExist_ByInvoiceId(invoiceno);
                        if (whtexist != 0)
                        {
                            CheckBox chkbxwht = (CheckBox)row.FindControl("CheckBxWHT");
                            chkbxwht.Checked = true;
                            chkbxwht.Enabled = false;
                        }
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info,"No invoices found for this vendor", 125, 300);
                    TabContainer.Tabs[1].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- (GetInvoiceListByVendor) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Button Events
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Assigning Variable value to save in Payment Header 
            int flaginserted;
            DateTime VoucherDate = new DateTime();
            DateTime ChequeDate = new DateTime();
            double ExchangeRate = 0.0, LocalBankCharges = 0.0, ForeignBankCharges = 0.0, ForeignBankChargesinLC = 0.0, FXPlusMinus = 0.0, AdjPlusMiuns = 0.0;
            string Vouchertype = DdlVoucherType.SelectedValue;
            string Voucherseries = DdlVoucherSeries.SelectedValue;
            string Year = TxtYear.Text;
            int VoucherNo = 0;
            //int VoucherNo = Convert.ToInt32(TxtVoucherNo.Text);
            if (TxtVoucherDate.Text != "")
            {
                VoucherDate = DateTime.ParseExact(TxtVoucherDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                VoucherDate = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            string BankACNo = TxtBankAcountNo.Text;
            //string Vendor = DdlVendor.SelectedItem.Text;
            string Vendor = TxtVendorCode.Text;
            string ChequeNo = TxtChequeNo.Text;
            if (TxtChequeDate.Text != "")
            {
                ChequeDate = DateTime.ParseExact(TxtChequeDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                ChequeDate = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            // string Currency = TxtCurrency.Text;
            string Currency = DdlCurency.SelectedItem.Text;
            if (TxtExchangeRate.Text != "")
            {
                ExchangeRate = Convert.ToDouble(TxtExchangeRate.Text);
            }
            if (TxtLocalBankCharges.Text != "")
            {
                LocalBankCharges = Convert.ToDouble(TxtLocalBankCharges.Text);
            }
            if (TxtForeignBankCharges.Text != "")
            {
                ForeignBankCharges = Convert.ToDouble(TxtForeignBankCharges.Text);
            }
            if (TxtForeignBankChargesInLC.Text != "")
            {
                ForeignBankChargesinLC = Convert.ToDouble(TxtForeignBankChargesInLC.Text);
            }
            if (TxtFx.Text != "")
            {
                FXPlusMinus = Convert.ToDouble(TxtFx.Text);
            }
            if (TxtAdj.Text != "")
            {
                AdjPlusMiuns = Convert.ToDouble(TxtAdj.Text);
            }
            #endregion
            bool check = false;
            foreach (GridViewRow row in GdvVendorInvoice.Rows)
            {
                CheckBox chkbxwht = (CheckBox)row.FindControl("CheckBxSelect");
                if (chkbxwht.Checked == true)
                {
                    #region check if wht tab open and wht not filled then show message to fill wht
                    if (TabContainer.Tabs[1].Visible == true)
                    {
                        if (GdvWHT.Rows.Count > 0)
                        {
                        }
                        else
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please enter WHT details", 125, 300);
                            return;
                        }
                    }
                    #endregion
                    check = true;
                    Label lblinvoiceno = (Label)row.FindControl("LblInvoiceNo");
                    int invoiceno = Convert.ToInt32(lblinvoiceno.Text);
                    #region Insert Payment header details to Payment Header transaction table
                    flaginserted = objpaymenttovendor.InsertPaymentheader(VoucherNo, Vouchertype, Year, Voucherseries, VoucherDate, Vendor, ChequeNo, ChequeDate, Currency, ExchangeRate, LocalBankCharges, ForeignBankCharges, ForeignBankChargesinLC, FXPlusMinus, AdjPlusMiuns, BankACNo, invoiceno);
                    #endregion
                    if (flaginserted == 1)
                    {
                     #region Update Status to Sent for Payment
                        int Flaginsert = objvendorinvoice.InsertVendorInvoice_PaymentSent(invoiceno, Session["userid"].ToString());
                     #endregion
                     #region Save WHTLine No if WHT tab is active
                        if (TabContainer.Tabs[1].Visible == true)
                        {
                            int WHTinseted = 0;
                            double whtgroup = 0.0, baseamount = 0.0, whtrate = 0.0;
                            foreach (GridViewRow drow in GdvWHT.Rows)
                            {
                                string lastvno = "";
                                lastvno = objpaymenttovendor.GetLastVoucherNo();
                                int voucherno = Convert.ToInt32(lastvno);
                                int invoice = Convert.ToInt32(ViewState["invoiceid"]);
                                Label lblwhtgroup = (Label)drow.FindControl("LblWHTGroup");
                                Label lblwhttype = (Label)drow.FindControl("LblTypeofPayment");
                                Label lblbaseamount = (Label)drow.FindControl("LblBamt");
                                Label lblwhtrate = (Label)drow.FindControl("LblWhtrate");
                                if (lblwhtgroup.Text != "")
                                {
                                    whtgroup = Convert.ToDouble(lblwhtgroup.Text);
                                }
                                string whttype = lblwhttype.Text;
                                if (lblbaseamount.Text != "")
                                {
                                    baseamount = Convert.ToDouble(lblbaseamount.Text);
                                }
                                if (lblwhtrate.Text != "")
                                {
                                    whtrate = Convert.ToDouble(lblwhtrate.Text);
                                }
                                WHTinseted = objvendorinvoicewht.insert(voucherno, invoiceno, whtgroup, whttype, baseamount, whtrate);
                                if (WHTinseted == 1)
                                {
                                    
                                }
                            }
                            GdvWHT.DataSource = null;
                            GdvWHT.DataBind();
                         
                        }
                        #endregion
                        if (Flaginsert == 1)
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Invoice sent for payment", 125, 300);
                            string vendorcode = TxtVendorCode.Text;
                            colvendorinvoice = objvendorinvoice.Get_VoucherInvoiceById(vendorcode);
                            TabContainer.Visible = true;
                            GdvVendorInvoice.DataSource = colvendorinvoice;
                            GdvVendorInvoice.DataBind();
                            TabContainer.ActiveTabIndex = 0;
                            TabContainer.Tabs[1].Visible = false;
                            //#region ClearField
                            //ClearField();
                            //#endregion
                        }
                        else
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, commessage.RecordNotSaved, 125, 300);
                            return;
                        }
                    }
                }
            }
            if (check == false)
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please select Invoice", 125, 300);
                return;
            }

        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- Save Button Click for Sending Invoices for payment -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void btn_search_Click(object sender, ImageClickEventArgs e)
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
                if (ddsearch.SelectedItem.Value == "VendorName")
                {
                    lSearchList.Text = "Search by Vendor";
                    string Vendorname = txtSearch.Text.Trim();
                    bindvendorname(Vendorname);
                }
                if (ddsearch.SelectedItem.Value == "InvoiceNo")
                {
                    lSearchList.Text = "Search by InvoiceNo";
                    string invoiceno = txtSearch.Text.Trim();
                    getinvoicebyinvoiceno(invoiceno);
                }
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- btn_search_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }

    }
    protected void ImgCancelwht_Click(object sender, ImageClickEventArgs e)
    {
        TabContainer.Tabs[1].Visible = false;
        GdvWHT.DataSource = null;
        GdvWHT.DataBind();
    }
    private void clearWHT()
    {
        Txt_TabPanel1_VendorCode.Text = "";
        Txt_TabPanel1_VendorName.Text = "";
        TxtBaseAmount.Text = "";
        TxtWHTGroup.Text = "";
        Txt_TabPanel1_WHTAmount.Text = "";
        TxtWHTRate.Text = "";
        DdlWHTType.SelectedValue = "0";
    }
    protected void BtnAddLine_Click(object sender, EventArgs e)
    {
      try
        {
            DataTable dt = null;
            int WhtLineNo;
            if (ViewState["WHTLineNo"] != null)
            {
                WhtLineNo = Convert.ToInt32(ViewState["WHTLineNo"]);
            }
            else
            {
                WhtLineNo = 10;
            }
            if (TxtBaseAmount.Text != "")
            {
                BaseAmount = Convert.ToDouble(TxtBaseAmount.Text);
            }
            WHTType = Txt_TabPanel1_WHTAmount.Text;
            if (TxtWHTGroup.Text != "")
            {
                WHTGroup = Convert.ToDouble(TxtWHTGroup.Text);
            }
            if (TxtWHTRate.Text != "")
            {
                WHTRate = Convert.ToDouble(TxtWHTRate.Text);
            }
            if (Txt_TabPanel1_WHTAmount.Text != "")
            {
                WHTAmount = Convert.ToDouble(Txt_TabPanel1_WHTAmount.Text);
            }
            if (ViewState["WHT"] != null)
            {
                dt = (DataTable)ViewState["WHT"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("WHTLineNo", typeof(int));
                dt.Columns.Add("VCode", typeof(string));
                dt.Columns.Add("WHTGRP", typeof(double));
                dt.Columns.Add("TypeOfPayment", typeof(string));
                dt.Columns.Add("BAmt", typeof(double));
                dt.Columns.Add("WhtRate", typeof(double));
                dt.Columns.Add("WHTAmount", typeof(double));
            }

            DataRow drow = dt.NewRow();
            if (ViewState["WHT"] != null)
            {
                drow["WHTLineNo"] = 10 + WhtLineNo;  //need to ask 
            }
            else
            {
                drow["WHTLineNo"] = WhtLineNo;  //need to ask 
            }
            drow["VCode"] = Txt_TabPanel1_VendorCode.Text;
            drow["WHTGRP"] = WHTGroup;
            drow["TypeOfPayment"] = DdlWHTType.SelectedItem.Text;
            drow["BAmt"] = BaseAmount;
            drow["WhtRate"] = WHTRate;
            drow["WHTAmount"] = WHTAmount;
            dt.Rows.Add(drow);
            ViewState["WHT"] = dt;
            ViewState["WHTLineNo"] = drow["WHTLineNo"];
            GdvWHT.DataSource = dt;
            GdvWHT.DataBind();
            clearWHT();
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- (BtnAddLine_Click) Adding WHT Line Item  -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvWHTDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView GdvWhtDetails = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            GdvWhtDetails.SelectedIndex = row.RowIndex;
            #region Row Deleting in temp table
            if (e.CommandName == "del")
            {
                int lineno = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["WHT"];
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
        }
        catch (Exception ex)
        {
            logmessage = "Vendor Payment Form- GdvWHTDetails_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
           lSearchList.Text = "Search by Vendor";
           MakeDefaultMasterDrop();
           HidPopUpType.Value = "vendor";
           gridMaster.Visible = false;
           BindVendorList();
           ModalPopupExtender1.Show();
         }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- (ImgBtnCode_Click)searching for Vendor  -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            if (ddlSearch.SelectedValue.ToString() == "VendorName")
            {
                lSearchList.Text = "Search by Vendor";
                bindvendorname(txtSearchList.Text.Trim());
            }
            if (ddlSearch.SelectedValue.ToString() == "InvoiceNo")
            {
                lSearchList.Text = "Search by InvoiceNo";
                HidPopUpType.Value = "invoiceno";
                string invoiceno = txtSearchList.Text.Trim();
                getinvoicebyinvoiceno(invoiceno);
            }
            if (HidPopUpType.Value == "vendor")
            {
                lSearchList.Text = "Search by Vendor";
                bindvendorname(txtSearchList.Text.Trim());
            }
           ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- (btnSearchlist_Click) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void bindvendorname(string key)
    {
        try
        {
            gridMaster.Visible = false;
            GdvVendorList.Visible = true;
            colvendorlist = objvendor.GetVendorList_ByVendorName(key);
            GdvVendorList.DataSource = colvendorlist;
            GdvVendorList.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- bindvendorname -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Selected Index Changed Events
    protected void CheckBxSelect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            double TotalBaseAmount = 0;
            double TotalWhtAmount = 0;
            foreach (GridViewRow dr in GdvVendorInvoice.Rows)
            {
                CheckBox chk = (CheckBox)dr.FindControl("CheckBxSelect");
                if (chk.Checked)
                {
                    Label lblinvoiceno = (Label)dr.FindControl("LblInvoiceNo");
                    int invoiceno = Convert.ToInt32(lblinvoiceno.Text);
                    TotalBaseAmount = objvendorinvoicewht.Get_BaseAmount_ById(invoiceno);
                    TotalWhtAmount = objvendorinvoicewht.Get_WHTAmount_ById(invoiceno);
                    TxtTotalValue.Text = TotalBaseAmount.ToString();
                    TxtWHTAmount.Text = TotalWhtAmount.ToString();
                    TxtTotalBank.Text = (TotalBaseAmount - TotalWhtAmount).ToString();

                    ImageButton imgbutton = (ImageButton)dr.FindControl("CheckBxSelect");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                 }
            }
                 
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- CheckBxSelect_CheckedChanged -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void CheckBxWHT_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            clearWHT();
            foreach (GridViewRow dr in GdvVendorInvoice.Rows)
            {
                CheckBox chkbx = (CheckBox)dr.FindControl("CheckBxWHT");
                if (chkbx.Checked)
                {
                    #region check if WHT exist for current invoice if invoice exist then hide WHT tab
                    int IsWHTExist = 0;
                    Label lblinvoiceno = (Label)dr.FindControl("LblInvoiceNo");
                    int invoiceno = Convert.ToInt32(lblinvoiceno.Text);
                    ViewState["invoiceid"] = invoiceno;
                    IsWHTExist = objvendorinvoicewht.IsWHTExist(invoiceno);
                    if (IsWHTExist != 0)
                    {
                        TabContainer.Tabs[1].Visible = false;
                    }
                    else
                    {
                        TabContainer.Tabs[1].Visible = true;
                    }
                    #endregion
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- CheckBxWHT_CheckedChanged(show hide WHT tab) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void RbtnSelect_CheckedChanged(object sender, EventArgs e)
    {
        #region Clear Fields
        TxtYear.Text = "";
        TxtVoucherNo.Text = "";
        TxtVoucherDate.Text = "";
        TxtBankAcountNo.Text = "";
        TxtChequeNo.Text = "";
        TxtChequeDate.Text = "";
        //TxtCurrency.Text = "";
        TxtExchangeRate.Text = "";
        TxtLocalBankCharges.Text = "";
        TxtForeignBankCharges.Text = "";
        TxtForeignBankChargesInLC.Text = "";
        TxtAdj.Text = "";
        TxtFx.Text = "";
        #endregion
    }
    
    #endregion

    #region GridEvents

    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
       string invoiceno = gridMaster.SelectedDataKey.Value.ToString();
       GetInvoicesByInvoiceNo(invoiceno);       
    }
    private void GetInvoicesByInvoiceNo(string invoiceno)
    {
        try
        {
            GdvVendorInvoice.DataSource = null;
            GdvVendorInvoice.DataBind();
            colvendorinvoice = objvendorinvoice.Get_VoucherInvoiceByInvoiceid(invoiceno);
            TabContainer.Visible = true;
            GdvVendorInvoice.DataSource = colvendorinvoice;
            GdvVendorInvoice.DataBind();
            if (GdvVendorInvoice.Rows.Count > 0)
            {
                foreach (GridViewRow row in GdvVendorInvoice.Rows)
                {
                    Label lblinvoiceno = (Label)row.FindControl("LblInvoiceNo");
                    int invoice = Convert.ToInt32(lblinvoiceno.Text);
                    int whtexist = objvendorinvoicewht.IsWHTExist_ByInvoiceId(invoice);
                    if (whtexist != 0)
                    {
                        CheckBox chkbxwht = (CheckBox)row.FindControl("CheckBxWHT");
                        chkbxwht.Checked = true;
                        chkbxwht.Enabled = false;
                    }
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "This invoice is not due for payment", 125, 300);
                return;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- GetInvoicesByInvoiceNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            gridMaster.PageIndex = e.NewPageIndex;
            string invoiceno = txtSearch.Text.Trim();
            colvendorinvoice = objvendorinvoice.Get_Invoices(invoiceno);
            gridMaster.DataSource = colvendorinvoice;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- gridMaster_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVendorList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GdvVendorInvoice.DataSource = null;
            GdvVendorInvoice.DataBind();
            string DataKey = GdvVendorList.SelectedDataKey.Value.ToString();
            TxtVendorCode.Text = DataKey;
            Txt_TabPanel1_VendorCode.Text = DataKey;
            int index = GdvVendorList.SelectedIndex;
            Txt_TabPanel1_VendorName.Text = ((Label)(GdvVendorList.Rows[index].FindControl("lblvendorname"))).Text.ToString();
            GetInvoiceListByVendor();
       }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- (gridMaster_SelectedIndexChanged)Selecting Item of search grid and binding due invoices for the vendor  -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVendorInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvVendorInvoice.PageIndex = e.NewPageIndex;
            GetInvoiceListByVendor();
        }
        catch (Exception ex)
        {
            logmessage = "Payment To Vendor Form- GdvVendorInvoice_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVendorInvoice_SelectedIndexChanged(object sender, EventArgs e)
    {

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
            logmessage = "Payment To Vendor Form- GdvVendorList_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void MakeDefaultMasterDrop()
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        ddl.SelectedValue = "";
    }
    #endregion
}