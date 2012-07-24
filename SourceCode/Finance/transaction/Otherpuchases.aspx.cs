/////////////////// Designed and Developed by Lalit Joshi 8 June 2012///////////////////////////////////////////////////////
///////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Configuration;

public partial class Finance_transaction_Otherpuchases : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    FA_SLMaster objslmaster = new FA_SLMaster();
    Common_mst objCommon_mst = new Common_mst();
    Common_Message objcommonmessage = new Common_Message();
    BLLCollection<FA_SLMaster> colslmaster = new BLLCollection<FA_SLMaster>();
    BLLCollection<FA_VoucherSeries> colseries = new BLLCollection<FA_VoucherSeries>();
    FA_VoucherSeries objVoucherSeries = new FA_VoucherSeries();
    FA_GLMaster objglmaster = new FA_GLMaster();
    BLLCollection<FA_GLMaster> colglmaster = new BLLCollection<FA_GLMaster>();
    FA_GLGroupMaster objglgroupmaster = new FA_GLGroupMaster();
    BLLCollection<FA_GLGroupMaster> colglgroupmaster = new BLLCollection<FA_GLGroupMaster>();
    BLLCollection<FA_ProfitCentermaster> colprofitcenter = new BLLCollection<FA_ProfitCentermaster>();
    FA_ProfitCentermaster objprofitcentermaster = new FA_ProfitCentermaster();
    BLLCollection<FA_CostCentermaster> colcostcenter = new BLLCollection<FA_CostCentermaster>();
    FA_CostCentermaster objcostcentermaster = new FA_CostCentermaster();
    BLLCollection<FA_ProjectCode> colprojectcode = new BLLCollection<FA_ProjectCode>();
    FA_ProjectCode objprojectcode = new FA_ProjectCode();
    BLLCollection<FA_SubProjectmst> colsubprojectcode = new BLLCollection<FA_SubProjectmst>();
    FA_SubProjectmst objsubprojectcode = new FA_SubProjectmst();
    //BLLCollection<FA_JournalVoucher> coljornalvoucher = new BLLCollection<FA_JournalVoucher>();
    //FA_JournalVoucher objjournalvoucher = new FA_JournalVoucher();
    //FA_Journal_WHT objjournalvoucher_wht = new FA_Journal_WHT();
    //FA_Journal_Vat objjournalvoucher_vat = new FA_Journal_Vat();
    //BLLCollection<FA_Journal_Vat> colvatdetails = new BLLCollection<FA_Journal_Vat>();
    BLLCollection<FA_VendorMaster> colvendorlist = new BLLCollection<FA_VendorMaster>();
    FA_VendorMaster objvendor = new FA_VendorMaster();
    Common_Message objmessage = new Common_Message();
    FA_JournalVoucher_OtherPurchases objotherpurchase = new FA_JournalVoucher_OtherPurchases();
    BLLCollection<FA_JournalVoucher_OtherPurchases> colotherpurchase = new BLLCollection<FA_JournalVoucher_OtherPurchases>();
    FA_Journal_OtherPurchases_Vat objotherpurchasevat = new FA_Journal_OtherPurchases_Vat();
    BLLCollection<FA_Journal_OtherPurchases_Vat> colotherpurchasevat = new BLLCollection<FA_Journal_OtherPurchases_Vat>();

    #endregion

    #region PageLoad event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                readonlycontrols();
                Log.GetLog().FillFinancialYear(TxtYear);
                TxtVoucherDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
                Log.PageHeading(this, "Other Purchase Form");
                BindSearchList();
                BindVoucherSeries();
                BindGLCode();
                BindSLCode();
                BindProfitCenter();
                BindProjectCode();
                BindSubProjectCode();
                BindCostCenter();
            }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- PageLoad -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region bindfunctions
    private void BindMasterSearchBox()
    {
        try
        {
            ImageButton imgbtnSearch = (ImageButton)Master.FindControl("imgbtnSearch");
            imgbtnSearch.CausesValidation = false;
            imgbtnSearch.Click += new ImageClickEventHandler(imgbtnSearch_Click);
            ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
            btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form - BindMasterSearchBox Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void readonlycontrols()
    {
        try
        {
            TxtDueDate.Attributes.Add("readonly", "true");
            TxtVendorName.Attributes.Add("readonly", "true");
            TxtVendorCode.Attributes.Add("readonly", "true");
            TxtTaxInvoiceDate.Attributes.Add("readonly", "true");
            TxtVoucherDate.Attributes.Add("readonly", "true");
            TxtVoucherNo.Attributes.Add("readonly", "true");
            TxtYear.Attributes.Add("readonly", "true");
            TxtVendor.Attributes.Add("readonly", "true");
            TxtVoucherDate.Attributes.Add("readonly", "true");
            TxtInvoiceDate.Attributes.Add("readonly", "true");
            TxtInvoiceBLDate.Attributes.Add("readonly", "true");
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- readonlycontrols -Error-" + ex.ToString();
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
            logmessage = "Other Purchase Form-BindingVoucherSeries-Error-" + ex.ToString();
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
            DdlGLCode.DataValueField = "GeneralLedgerCode";
            DdlGLCode.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlGLCode.Items.Add(item);
            DdlGLCode.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form-BindingGLCode-Error-" + ex.ToString();
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
            logmessage = "Other Purchase Form-BindingProfitCenter-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindCostCenter()
    {
        try
        {
            colcostcenter = objcostcentermaster.GetCostCenter();
            DdlCostCenter.DataSource = colcostcenter;
            DdlCostCenter.DataTextField = "CostCenterName";
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
            logmessage = "Other Purchase Form-BindingCostCenter-Error-" + ex.ToString();
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
            logmessage = "Other Purchase Form-BindingProjectCode-Error-" + ex.ToString();
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
            logmessage = "Other Purchase Form-BindingProjectSubCode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindSLCode()
    {
        try
        {
            colslmaster = objslmaster.GetSLCodeList();
            DdlSubGLCode.DataSource = colslmaster;
            DdlSubGLCode.DataTextField = "Description";
            DdlSubGLCode.DataValueField = "SubSidiaryLedgerCode";
            DdlSubGLCode.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlSubGLCode.Items.Add(item);
            DdlSubGLCode.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Other purchases Entry Form-BindingSubGLCode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindVatDetails(string voucherno)
    {
        try
        {
            colotherpurchasevat = objotherpurchasevat.VatDetails_Otherpurchase_ByVoucherNo(voucherno);
            GdvVatDetails.DataSource = colotherpurchasevat;
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
                BtnAdd_VatDetails.ImageUrl = "~/Images/btn_update.png";
                //BtnAdd_VatDetails.Text = "Update Line";
            }
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- BindVatDetails -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ClearDetails()
    {
        TxtAsset.Text = "";
        TxtEmpCode.Text = "";
        TxtDebitAmount.Text = "";
        TxtDescriptionLineItem.Text = "";
        DdlSubGLCode.SelectedValue = "0";
        TxtNarration.Text = "";
        DdlGLCode.SelectedValue = "0";
        DdlCostCenter.SelectedValue = "0";
        DdlProfitCenter.SelectedValue = "0";
        DdlProject.SelectedValue = "0";
        DdlSubProject.SelectedValue = "0";
    }
    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdFAOtherPurchases = ConfigurationManager.AppSettings["FormIdFAOtherPurchases"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdFAOtherPurchases);

            ddlSearch.DataTextField = "Options";
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();
            }
            ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- BindSearchList - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void ClearHeaderDetails()
    {
        DdlVoucherSeries.SelectedValue = "0";
        TxtVendor.Text = "";
        TxtVendorInvoice.Text = "";
        TxtInvoiceDate.Text = "";
        TxtInvoiceBLDate.Text = "";
        TxtCreditDays.Text = "";
        TxtDueDate.Text = "";
        TxtAmount.Text = "";
        TxtNarration.Text = "";
        GdvDescription.DataSource = null;
        GdvDescription.DataBind();
        GdvVatDetails.DataSource = null;
        GdvVatDetails.DataBind();
    }
    protected void ClearVatDetails()
    {
        TxtVendorCode.Text = "";
        TxtVendorName.Text = "";
        TxtBaseAmount.Text = "";
        TxtTaxAmount.Text = "";
        TxtTaxInvoice.Text = "";
        TxtTaxInvoiceDate.Text = "";
    }
    private void Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objotherpurchase.Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords(ddlSearchValue, txtSearchValue);

            if (dt.Rows.Count > 0)
            {
                gvAllOtherPurchase.DataSource = dt;
                gvAllOtherPurchase.AllowPaging = true;
                gvAllOtherPurchase.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvAllOtherPurchase.AllowPaging = false;
                gvAllOtherPurchase.DataSource = "";
                gvAllOtherPurchase.DataBind();
            }
        }
        catch (Exception ex)
        {
            gvAllOtherPurchase.AllowPaging = false;
            gvAllOtherPurchase.DataSource = "";
            gvAllOtherPurchase.DataBind();
            logmessage = "Other Purchase Form- Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region button click events
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            BtnAddLine.ImageUrl = "~/Images/btnAdd.png";
            BtnAddLine.Enabled = true;
            BtnSave.Enabled = true;
            BtnSave.ImageUrl = "~/Images/btnSave.png";
            BtnAdd_VatDetails.Enabled = true;
            BtnAdd_VatDetails.ImageUrl = "~/Images/btnAdd.png";
            ClearDetails();
            ClearHeaderDetails();
            ClearVatDetails();
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- btn_add_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddlSearch.SelectedValue != "0")
            {
                if (ddlSearch.SelectedValue.ToString() == "VoucherNo")
                {
                    Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords("VoucherNo", txtSearch.Text.Trim());
                    lSearchList.Text = "Search By Voucher No.: ";
                }
                else if (ddlSearch.SelectedValue.ToString() == "Vendor")
                {
                    Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords("Vendor", txtSearch.Text.Trim());
                    lSearchList.Text = "Search By Vendor: ";
                }
                ModalPopupExtender2.Show();
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
            }
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- imgbtnSearch_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BtnAdd_VatDetails_Click(object sender, EventArgs e)
    {
        try
        {
            #region Update item
            // if (BtnAdd_VatDetails.Text == "Update Line")
            if (BtnAdd_VatDetails.ImageUrl == "~/Images/btn_update.png")
            {
                if (TxtBaseAmount.Text != "")
                {
                    objotherpurchasevat.BaseAmount = Convert.ToDouble(TxtBaseAmount.Text);
                }
                if (TxtTaxAmount.Text != "")
                {
                    objotherpurchasevat.VAmount = Convert.ToDouble(TxtTaxAmount.Text);
                }
                objotherpurchasevat.TaxInvoice = TxtTaxInvoice.Text;
                objotherpurchasevat.TaxInvoiceDate = TxtTaxInvoiceDate.Text;
                objotherpurchasevat.VoucherNo = TxtVoucherNo.Text;
                if (ViewState["vatlinenoforupdating"] != null)
                {
                    objotherpurchasevat.VatLineNo = Convert.ToInt32(ViewState["vatlinenoforupdating"]);
                }
                objotherpurchasevat.CreatedBy = Session["userid"].ToString();
                int updated = objotherpurchasevat.UpdateJournalVatdetails();
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
            #region add line items
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
                dt.Rows.Add(drow);
                ViewState["VatDetails"] = dt;
                ViewState["VatLnNo"] = drow["VatLineNo"];
                GdvVatDetails.DataSource = dt;
                GdvVatDetails.DataBind();
                ClearVatDetails();
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form-Adding Vat lines Numbers-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BtnAddLine_Click(object sender, EventArgs e)
    {
        try
        {
            #region local variable
            int GLCode, SLCode, LineNo;
            string GLGroupCode, GLGroupName;
            double DebitAmount = 0.0, PCenter = 0.0, Ccenter = 0.0;
            bool IsEmployeecodeSelected = false;
            DataTable dt = null;
            #endregion
            #region Check if GLCode has subsidary Ledger flag checked then SLCode is mandatory
            GLCode = Convert.ToInt32(DdlGLCode.SelectedValue);
            bool slcodechecked = false;
            objglmaster = objglmaster.GetGLCode_ById(GLCode);
            slcodechecked = objglmaster.Subglflag;
            GLGroupCode = objglmaster.GroupCode;
            if (slcodechecked == true)
            {
                if (DdlSubGLCode.SelectedValue == "0")
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

            #region Insert Line
            if (ViewState["MainLineNo"] != null)
            {
                LineNo = Convert.ToInt32(ViewState["MainLineNo"]) + 10;
            }
            else
            {
                LineNo = 10;
            }
            GLCode = Convert.ToInt32(DdlGLCode.SelectedValue);
            SLCode = Convert.ToInt32(DdlSubGLCode.SelectedValue);
            PCenter = Convert.ToDouble(DdlProfitCenter.SelectedItem.Value);
            Ccenter = Convert.ToDouble(DdlCostCenter.SelectedItem.Value);
            if (ViewState["Journalpurchase"] != null)
            {
                dt = (DataTable)ViewState["Journalpurchase"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Line#", typeof(int));
                dt.Columns.Add("GLCode", typeof(int));
                dt.Columns.Add("SLCode", typeof(int));
                dt.Columns.Add("Debit Amount", typeof(double));
                dt.Columns.Add("Profit Center", typeof(string));
                dt.Columns.Add("Cost center", typeof(string));
                dt.Columns.Add("Asset", typeof(string));
                dt.Columns.Add("Project", typeof(string));
                dt.Columns.Add("SubProject", typeof(string));
                dt.Columns.Add("EmpCode", typeof(string));
                dt.Columns.Add("VoucherDescr", typeof(string));
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
            drow["Profit Center"] = PCenter;
            drow["Cost center"] = Ccenter;
            drow["Asset"] = TxtAsset.Text;
            drow["Project"] = DdlProject.SelectedValue;
            drow["SubProject"] = DdlSubProject.SelectedValue;
            drow["EmpCode"] = TxtEmpCode.Text;
            drow["VoucherDescr"] = TxtDescriptionLineItem.Text;
            dt.Rows.Add(drow);
            ViewState["Journalpurchase"] = dt;
            ViewState["MainLineNo"] = drow["Line#"];
            GdvDescription.DataSource = dt;
            GdvDescription.DataBind();
            ClearDetails();
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form-Adding Line Item in Main Tab-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Update Record
            // if (BtnSave.Text == "Update")
            if (BtnSave.ImageUrl == "~/Images/btn_update.png")
            {
                #region Update item in Journal Voucher Header table
                int updatedheader = objotherpurchase.UpdateJournalVoucher_Otherpurchase_Headerdetails(DdlVoucherSeries.SelectedItem.Value, TxtYear.Text, TxtVoucherNo.Text, TxtVoucherDate.Text, TxtVendorName.Text, TxtVendorInvoice.Text, TxtInvoiceDate.Text, TxtInvoiceBLDate.Text, TxtCreditDays.Text, TxtDueDate.Text, TxtAmount.Text, TxtNarration.Text, Session["userid"].ToString());
                if (updatedheader == 1)
                {
                    #region Update item in Journal Voucher Transaction table
                    if (ViewState["LineNo"] != null)
                    {
                        string lineno = ViewState["LineNo"].ToString();
                        double debitamount = 0.0;
                        if (TxtDebitAmount.Text != "")
                        {
                            debitamount = Convert.ToDouble(TxtDebitAmount.Text);
                        }
                        int detailsupdated = objotherpurchase.UpdateJournalVoucherOtherpurchase_Details(TxtVoucherNo.Text, lineno, DdlGLCode.SelectedValue, DdlSubGLCode.SelectedValue, DdlProfitCenter.SelectedValue, DdlCostCenter.SelectedValue, debitamount, TxtAsset.Text, TxtEmpCode.Text, DdlProject.SelectedValue, DdlSubProject.SelectedValue, TxtDescriptionLineItem.Text, Session["userid"].ToString(), TxtDescriptionLineItem.Text);

                        if (detailsupdated == 1)
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.UpdatedRecord, 125, 300);
                            return;
                        }
                    }
                    #endregion
                }
                #endregion

            }
            #endregion
            #region insert record
            else
            {
                int isinserted_Journalentery;
                objotherpurchase.VoucherSeries = DdlVoucherSeries.SelectedItem.Value;
                objotherpurchase.VoucherYear = TxtYear.Text.Trim();
                objotherpurchase.VoucherDate = TxtVoucherDate.Text.Trim();
                objotherpurchase.VoucherNo = TxtVoucherNo.Text.Trim();
                objotherpurchase.Vendor = TxtVendor.Text.Trim();
                objotherpurchase.VendorInvoice = TxtVendorInvoice.Text.Trim();
                objotherpurchase.VendorInvoiceDate = TxtInvoiceDate.Text.Trim();
                objotherpurchase.InvoiceBLDate = TxtInvoiceBLDate.Text.Trim();
                if (TxtCreditDays.Text != "")
                {
                    objotherpurchase.CreditDays = Convert.ToInt32(TxtCreditDays.Text);
                }
                objotherpurchase.DueDate = TxtDueDate.Text.Trim();
                if (TxtAmount.Text != "")
                {
                    objotherpurchase.Amount = Convert.ToDouble(TxtAmount.Text);
                }
                objotherpurchase.HeaderDesc = TxtNarration.Text;
                DateTime dtcreateddate = DateTime.Now;
                ViewState["currendtdate"] = dtcreateddate;
                #region if Main details is filled
                if (GdvDescription.Rows.Count > 0)
                {
                    foreach (GridViewRow row in GdvDescription.Rows)
                    {
                        int project = 0, subproject = 0;
                        if (((Label)row.FindControl("Lbllineno")).Text != "")
                        {
                            int lineno = Convert.ToInt32(((Label)row.FindControl("Lbllineno")).Text);

                            string glcode = ((Label)row.FindControl("Lblglcode")).Text;
                            string slcode = ((Label)row.FindControl("Lblslcode")).Text;
                            double debitamount = Convert.ToDouble(((Label)row.FindControl("Lbldebitamount")).Text);
                            string profitcenter = ((Label)row.FindControl("Lblprofitcenter")).Text;
                            string costcenter = ((Label)row.FindControl("Lblcostcenter")).Text;
                            string asset = ((Label)row.FindControl("Lblasset")).Text;
                            string empcode = ((Label)row.FindControl("Lblempcode")).Text;

                            if (((Label)row.FindControl("Lblproject")).Text != "")
                            {
                                project = Convert.ToInt32(((Label)row.FindControl("Lblproject")).Text);
                            }
                            if (((Label)row.FindControl("Lblsubproject")).Text != "")
                            {
                                subproject = Convert.ToInt32(((Label)row.FindControl("Lblsubproject")).Text);
                            }
                            string voucherdescription = ((Label)row.FindControl("Lblnarration")).Text;
                            objotherpurchase.VoucherDescription = voucherdescription;
                            objotherpurchase.LineNo = lineno;
                            objotherpurchase.Asset = asset;
                            objotherpurchase.EmpCode = empcode;
                            objotherpurchase.Project = project;
                            objotherpurchase.SubProject = subproject;
                            objotherpurchase.VoucherNo = TxtVoucherNo.Text;

                            objotherpurchase.GlCode = glcode;
                            objotherpurchase.GlSubCode = slcode;
                            objotherpurchase.DebitAmount = debitamount;
                            objotherpurchase.CostCenter = costcenter;
                            objotherpurchase.ProfitCenter = profitcenter;
                            objotherpurchase.CreatedBy = Session["userid"].ToString();
                            objotherpurchase.CreatedDate = Convert.ToDateTime(ViewState["currendtdate"]);
                            objotherpurchase.DetailDescription = TxtDescriptionLineItem.Text.Trim();
                            isinserted_Journalentery = objotherpurchase.insertjournal_otherpurchase_details();
                            ViewState["Journalpurchase"] = null;
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
                    //DateTime TaxInvdate = new DateTime();
                    foreach (GridViewRow row in GdvVatDetails.Rows)
                    {
                        int lineno = 0;
                        double baseamount = 0.0, vamount = 0.0, rate = 0.0;

                        string voucherno = objotherpurchase.GetLastVoucherNo_OtherPurchase();
                        ViewState["lastvoucherno"] = voucherno;
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
                        string taxinvoicedate = row.Cells[6].Text;
                        //if (row.Cells[6].Text != "&nbsp;")
                        //{
                        //    TaxInvdate = DateTime.ParseExact((row.Cells[6].Text), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        //}
                        //else
                        //{
                        //    TaxInvdate = DateTime.ParseExact("01/01/1900", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //}
                        objotherpurchasevat.LineNo = lineno;
                        objotherpurchasevat.VoucherNo = ViewState["lastvoucherno"].ToString();
                        objotherpurchasevat.VatLineNo = vatlineno;
                        objotherpurchasevat.VendorCode = vendorcode;
                        objotherpurchasevat.VendorName = vendorname;
                        objotherpurchasevat.BaseAmount = baseamount;
                        objotherpurchasevat.VAmount = vamount;
                        objotherpurchasevat.TaxInvoice = taxinvoice;
                        objotherpurchasevat.TaxInvoiceDate = taxinvoicedate;
                        objotherpurchasevat.Rate = rate;
                        objotherpurchasevat.CreatedBy = Session["userid"].ToString();
                        objotherpurchasevat.Active = true;
                        int vatinserted = objotherpurchasevat.insertjournal_Vatdetails_OtherPurchases();
                        ViewState["VatDetails"] = null;
                    }
                }
                #endregion

                #region clear main form data
                ClearDetails();
                ClearHeaderDetails();
                #endregion
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objmessage.RecordSaved, 125, 300);

            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- Inserting/Updating Other Purchase Form-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            // GdvSearch.Visible = false;
            GdvVendorList.Visible = true;
            BindVendorList("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- Search Vendor By Keyword(ImgBtnCode_Click) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            if (ddlSearch.SelectedValue.ToString() == "VoucherNo")
            {
                Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords("VoucherNo", txtSearchList.Text.Trim());
                lSearchList.Text = "Search By Voucher No.: ";
            }
            else if (ddlSearch.SelectedValue.ToString() == "Vendor")
            {
                Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords("Vendor", txtSearchList.Text.Trim());
                lSearchList.Text = "Search By Vendor: ";
            }
            ModalPopupExtender2.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- btnSearchlist_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSearchlistvendor_Click(object sender, EventArgs e)
    {
        try
        {
            labelsearchvendor.Text = "Search by vendor code";
            BindVendorList(txtSearchListvendor.Text.Trim());
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- btnSearchlistvendor_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindVendorList(string vendorcode)
    {
        try
        {
            colvendorlist = objvendor.GetVendorList_ByVendorCode(vendorcode);
            GdvVendorList.DataSource = colvendorlist;
            GdvVendorList.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region grid events
    protected void GdvVatDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView GdvVatDetails = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            GdvVatDetails.SelectedIndex = row.RowIndex;

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

                TxtVendorCode.Text = (GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].FindControl("LblVCode") as Label).Text;
                TxtVendorName.Text = (GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].FindControl("Lblvendorname") as Label).Text;
                if ((GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].FindControl("LblBAmt") as Label).Text == Convert.ToString(0.0))
                {
                    TxtBaseAmount.Text = "";
                }
                else
                {
                    TxtBaseAmount.Text = (GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].FindControl("LblBAmt") as Label).Text;
                }
                if ((GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].FindControl("LblVAmt") as Label).Text == Convert.ToString(0.0))
                {
                    TxtTaxAmount.Text = "";
                }
                else
                {
                    TxtTaxAmount.Text = (GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].FindControl("LblVAmt") as Label).Text;
                }
                if ((GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].FindControl("LblTaxInv") as Label).Text == "")
                {
                    TxtTaxInvoice.Text = "";
                }
                else
                {
                    TxtTaxInvoice.Text = (GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].FindControl("LblTaxInv") as Label).Text;
                }
                if (GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].Cells[6].Text == "1/1/0001 12:00:00 AM")
                {
                    TxtTaxInvoiceDate.Text = "";
                }
                else
                {
                    TxtTaxInvoiceDate.Text = GdvVatDetails.Rows[GdvVatDetails.SelectedIndex].Cells[6].Text;
                }
                // BtnAdd_VatDetails.Text = "Update Line";
                BtnAdd_VatDetails.ImageUrl = "~/Images/btn_update.png";
                BtnAdd_VatDetails.Enabled = true;
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- GdvVatDetails_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvDescription_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (hidAutoIdHeader.Value == "")
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[12].Visible = true;
            }
            else if (hidAutoIdHeader.Value != "")
            {
                e.Row.Cells[0].Visible = true;
                e.Row.Cells[12].Visible = false;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- GdvDescription_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvDescription_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView GdvDescription = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            GdvDescription.SelectedIndex = row.RowIndex;

            #region Row Deleting in Temp Table
            if (e.CommandName == "del")
            {
                int lineno = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["Journalpurchase"];
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
            #region Row Editing
            if (e.CommandName == "editrow")
            {
                ViewState["LineNo"] = e.CommandArgument.ToString();
                TxtAsset.Text = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblasset") as Label).Text.Trim();
                DdlGLCode.SelectedValue = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblglcode") as Label).Text.Trim();
                DdlCostCenter.SelectedValue = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblcostcenter") as Label).Text.Trim();
                DdlSubGLCode.SelectedValue = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblslcode") as Label).Text.Trim();
                TxtEmpCode.Text = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblempcode") as Label).Text.Trim();
                DdlProfitCenter.SelectedValue = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblprofitcenter") as Label).Text.Trim();
                TxtDebitAmount.Text = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lbldebitamount") as Label).Text.Trim();
                DdlProject.SelectedValue = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblproject") as Label).Text.Trim();
                DdlSubProject.SelectedValue = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblsubproject") as Label).Text.Trim();
                TxtDescriptionLineItem.Text = (GdvDescription.Rows[GdvDescription.SelectedIndex].FindControl("Lblnarration") as Label).Text.Trim();
                BtnSave.ImageUrl = "~/Images/btn_update.png";
                BtnSave.Enabled = true;
                BtnAddLine.Enabled = false;
                BtnAddLine.ImageUrl = "~/Images/btnAddLineGrey.png";
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- GdvDescription_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVatDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (hidAutoIdHeader.Value == "")
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[9].Visible = true;
            }
            else if (hidAutoIdHeader.Value != "")
            {
                e.Row.Cells[0].Visible = true;
                e.Row.Cells[9].Visible = false;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- GdvVatDetails_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string DataKey = GdvVendorList.SelectedDataKey.Value.ToString();
            TxtVendorCode.Text = DataKey;
            TxtVendor.Text = DataKey;
            int index = GdvVendorList.SelectedIndex;
            TxtVendorName.Text = ((Label)(GdvVendorList.Rows[index].FindControl("lblvendorcode"))).Text.ToString();
        }
        catch (Exception ex)
        {
            logmessage = "Invoice Verification Form- Select event for vendor id and name(gridMaster_SelectedIndexChanged) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //try
        //{
        //    GdvSearch.PageIndex = e.NewPageIndex;
        //    DropDownList ddsearch = (DropDownList)Master.FindControl("dd_search");
        //    TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        //    coljornalvoucher = objjournalvoucher.Search_JournalVoucher(txtSearch.Text.Trim());
        //    GdvSearch.DataSource = coljornalvoucher;
        //    GdvSearch.DataBind();
        //    ModalPopupExtender1.Show();
        //}
        //catch (Exception ex)
        //{
        //    logmessage = "Other Purchase Form- GdvSearch_PageIndexChanging -Error-" + ex.ToString();
        //    Log.GetLog().LogInformation(logmessage);
        //}
    }
    protected void GdvVendorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvVendorList.PageIndex = e.NewPageIndex;
            BindVendorList("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- GdvVendorList_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvAllOtherPurchase_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            gvAllOtherPurchase.PageIndex = e.NewPageIndex;
            if (ddlSearch.SelectedValue.ToString() == "VoucherNo")
            {
                Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords("VoucherNo", "");
                lSearchList.Text = "Search By Voucher No.: ";
            }
            else if (ddlSearch.SelectedValue.ToString() == "Vendor")
            {
                Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords("Vendor", "");
                lSearchList.Text = "Search By Vendor: ";
            }
            ModalPopupExtender2.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- gvAllOtherPurchase_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvAllOtherPurchase_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[1].Style.Add("display", "none");
            e.Row.Cells[2].Style.Add("display", "none");
            e.Row.Cells[3].Style.Add("display", "none");
            e.Row.Cells[9].Style.Add("display", "none");
            e.Row.Cells[10].Style.Add("display", "none");
            e.Row.Cells[11].Style.Add("display", "none");
            e.Row.Cells[12].Style.Add("display", "none");
            e.Row.Cells[13].Style.Add("display", "none");
            e.Row.Cells[14].Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- gvAllOtherPurchase_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvAllOtherPurchase_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvAllOtherPurchase = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvAllOtherPurchase.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvAllOtherPurchase.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                #region Header

                hidAutoIdHeader.Value = Convert.ToString(e.CommandArgument);
                DdlVoucherSeries.SelectedValue = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[1].Text.Trim();
                TxtYear.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[2].Text;
                TxtVoucherNo.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[3].Text;
                TxtVoucherDate.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[4].Text;
                TxtVendor.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[5].Text;
                TxtVendorInvoice.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[7].Text;
                if (gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[8].Text == "&nbsp;")
                {
                    TxtInvoiceDate.Text = "";
                }
                else
                {
                    TxtInvoiceDate.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[8].Text;
                }
                if (gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[9].Text == "&nbsp;")
                {
                    TxtInvoiceBLDate.Text = "";
                }
                else
                {
                    TxtInvoiceBLDate.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[9].Text;
                }
                TxtCreditDays.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[10].Text;
                if (gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[11].Text == "&nbsp;")
                {
                    TxtDueDate.Text = "";
                }
                else
                {
                    TxtDueDate.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[11].Text;
                }
                TxtAmount.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[12].Text;
                TxtNarration.Text = gvAllOtherPurchase.Rows[gvAllOtherPurchase.SelectedIndex].Cells[13].Text;

                #endregion

                #region Selection Tab
                DataTable dt = objotherpurchase.Get_FA_Glb_JournalVoucher_Otherpurchase_Details(TxtVoucherNo.Text);
                if (dt.Rows.Count > 0)
                {
                    GdvDescription.DataSource = dt;
                    GdvDescription.DataBind();
                }
                dt = null;
                #endregion

                #region Vat details
                dt = objotherpurchase.Get_FA_Glb_Journal_OtherPurchase_VATDetails(TxtVoucherNo.Text);
                if (dt.Rows.Count > 0)
                {
                    GdvVatDetails.DataSource = dt;
                    GdvVatDetails.DataBind();
                }
                dt = null;
                BtnSave.ImageUrl = "~/Images/btn_update.png"; ;
                BtnSave.Enabled = true;
                #endregion

            }
        }
        catch (Exception ex)
        {
            logmessage = "Other Purchase Form- gvAllOtherPurchase_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
}