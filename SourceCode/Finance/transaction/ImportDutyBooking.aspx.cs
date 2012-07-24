using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_transaction_ImportDutyBooking : System.Web.UI.Page
{
    #region Defind Global here
    string logmessage = "";
    FA_GLMaster objglmaster = new FA_GLMaster();
    BLLCollection<FA_GLMaster> colglmaster = new BLLCollection<FA_GLMaster>();
    Common com = new Common();
    BLLCollection<FA_VendorMaster> colvendorlist = new BLLCollection<FA_VendorMaster>();
    FA_VendorMaster objvendor = new FA_VendorMaster();
    BLLCollection<FA_SLMaster> colslmaster = new BLLCollection<FA_SLMaster>();
    FA_SLMaster objslmaster = new FA_SLMaster();
    FA_ImportDutyBooking objimportduty = new FA_ImportDutyBooking();
    BLLCollection<FA_ImportDutyBooking> colimportdutybooking = new BLLCollection<FA_ImportDutyBooking>();
    Common_Message commessage = new Common_Message();
    #endregion
   
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                BindSearchDropDown("113");
                colimportdutybooking = objimportduty.GetImportDuty_DetailsInfo_By_Voucherno("0");
                GdvPODetails.DataSource = colimportdutybooking;
                GdvPODetails.DataBind();
                BindSLCode();
                Log.PageHeading(this, "Import Duty Booking Form");
                Log.GetLog().FillFinancialYear(TxtVoucherYear);
                readonlycontrols();
            }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Booking Form - Page_Load Method -Error-" + ex.ToString();
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
            logmessage = "Import Duty Booking Form - BindMasterSearchBox Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void readonlycontrols()
    {
        try
        {
            TxtChequeDate.Attributes.Add("readonly", "true");
            TxtGLCode.Attributes.Add("readonly", "true");
            TxtPONo.Attributes.Add("readonly", "true");
            TxtVendor.Attributes.Add("readonly", "true");
            TxtVoucherDate.Attributes.Add("readonly", "true");
            TxtVoucherNo.Attributes.Add("readonly", "true");
            TxtVoucherYear.Attributes.Add("readonly", "true");
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Booking Form - readonlycontrols Method -Error-" + ex.ToString();
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
            logmessage = "Import Duty Booking Form - BindSearchDropDown Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ClearAll();
        }
        catch (Exception ex)
        {
            logmessage = "Import duty booking Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindSLCode()
    {
        try
        {
            colslmaster = objslmaster.GetSLCodeList();
            DldSlCode.DataSource = colslmaster;
            DldSlCode.DataTextField = "Description";
            DldSlCode.DataValueField = "SubSidiaryLedgerCode";
            DldSlCode.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DldSlCode.Items.Add(item);
            DldSlCode.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form-BindingSubGLCode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Defined Functions
    private void ClearAll()
    {
        TxtChequeDate.Text = "";
        TxtChequeNo.Text = "";
        TxtGLCode.Text = "";
        TxtInputVatSLCode.Text = "";
        TxtPONo.Text = "";
        TxtTotal1.Text = "";
        TxtTotal2.Text = "";
        TxtVendor.Text = "";
        TxtVoucherDate.Text = "";
        TxtVoucherNo.Text = "";
        GdvPODetails.DataSource = null;
        GdvPODetails.DataBind();
        Gdvlookup.DataSource = null;
        Gdvlookup.DataBind();
        DldSlCode.SelectedValue = "0";
        Btnaddmore.ImageUrl = "~/Images/btnAdd.png";
        Btnaddmore.Enabled = true;
        Btnsave.ImageUrl = "~/Images/btnSave.png";
        Btnsave.Enabled = true;
        colimportdutybooking = objimportduty.GetImportDuty_DetailsInfo_By_Voucherno("0");
        GdvPODetails.DataSource = colimportdutybooking;
        GdvPODetails.DataBind();
    }
    private void MakeDefaultMasterDrop()
    {
        try
        {
            DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
            ddl.SelectedValue = "";
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- MakeDefaultMasterDrop -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindBankGL()
    {
        try
        {
            DataTable dtbankgl = new DataTable();
            dtbankgl = objglmaster.GetGLCode_By_GLGroupName("Bank");
            Gdvlookup.DataSource = dtbankgl;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- BindBankGL -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindPO()
    {
        try
        {
            DataTable dt = com.executeProcedure("Sp_FA_GetPODetails");
            Gdvlookup.DataSource = dt;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- BindPO() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindVendorList()
    {
        try
        {
            colvendorlist = objvendor.GetVendorList_ByVendorCode("0");
            Gdvlookup.DataSource = colvendorlist;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Import duty Booking Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Button Click Events
    protected void ImgBtnGL_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search by GL Code.";
            HidPopUpType.Value = "bankgl";
            Gdvlookup.Visible = true;
            BindBankGL();
            gridMaster.Visible = false;
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- ImgBtnGL_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnPO_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search by PO No.";
            HidPopUpType.Value = "po";
            Gdvlookup.Visible = true;
            BindPO();
            gridMaster.Visible = false;
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- ImgBtnPO_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnVendorCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search by Vendor Code";
            HidPopUpType.Value = "vendor";
            BindVendorList();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- ImgBtnVendorCode_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Btnaddmore_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = null;
            int LineNo;
            string PONo;
            double DutyAmount = 0.0, ImportVat = 0.0;

            if (ViewState["POLnNo"] != null)
            {
                LineNo = Convert.ToInt32(ViewState["POLnNo"]);
            }
            else
            {
                LineNo = 10;
            }

            PONo = TxtPONo.Text;
            if (ViewState["DutyAmout"] != null)
            {
                DutyAmount = Convert.ToDouble(ViewState["DutyAmout"]);
            }
            if (ViewState["ImportVAT"] != null)
            {
                ImportVat = Convert.ToDouble(ViewState["ImportVAT"]);
            }

            if (ViewState["PODetails"] != null)
            {
                dt = (DataTable)ViewState["PODetails"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("PONO", typeof(int));
                dt.Columns.Add("LineNo", typeof(string));
                dt.Columns.Add("DutyAmount", typeof(double));
                dt.Columns.Add("ImportVAT", typeof(double));
                dt.Columns.Add("MisLeAdj", typeof(string));
            }
            DataRow drow = dt.NewRow();
            if (ViewState["POLnNo"] != null)
            {
                drow["LineNo"] = 10 + LineNo;
            }
            else
            {
                drow["LineNo"] = LineNo;
            }
            drow["PONO"] = PONo;
            drow["DutyAmount"] = DutyAmount;
            drow["ImportVAT"] = ImportVat;
            drow["MisLeAdj"] = "2323";
            dt.Rows.Add(drow);
            ViewState["PODetails"] = dt;
            ViewState["POLnNo"] = drow["LineNo"];
            GdvPODetails.DataSource = dt;
            GdvPODetails.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- Btnaddmore_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Update item
           // if (Btnsave.Text == "Update")
            if(Btnsave.ImageUrl=="~/Images/btn_update.png")
            {
              int updated= objimportduty.updateimportdutybooking(ViewState["vno"].ToString(), TxtGLCode.Text, DldSlCode.SelectedValue, TxtInputVatSLCode.Text, TxtChequeNo.Text, TxtChequeDate.Text, Session["userid"].ToString());
              if (updated == 1)
              {
                  MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.UpdatedRecord, 125, 300);
                  return;
              }
            }
            #endregion 
            #region Insert item
            objimportduty.VoucherYear = TxtVoucherYear.Text;
            objimportduty.VoucherNo = TxtVoucherNo.Text;
            objimportduty.VoucherDate = TxtVoucherDate.Text;
            objimportduty.GlCode = TxtGLCode.Text;
            objimportduty.GlSubCode = DldSlCode.SelectedValue;
            objimportduty.InputSubCode = TxtInputVatSLCode.Text;
            objimportduty.ChequeNo = TxtChequeNo.Text;
            objimportduty.ChequeDate = TxtChequeDate.Text;
            int lineno = 0, inserted = 0;
            string PONo = "";
            double dutyamount = 0.0, ImportVat = 0.0, MisAdj = 0.0;
            DateTime dtcreateddate = DateTime.Now;
            ViewState["nowdate"] = dtcreateddate;
            if (GdvPODetails.Rows.Count > 0)
            {
                foreach (GridViewRow row in GdvPODetails.Rows)
                {
                    if (row.Cells[1].Text != "")
                    {
                        lineno = Convert.ToInt32(row.Cells[2].Text);
                    }
                    objimportduty.LineNo = lineno;
                    if (row.Cells[0].Text != "")
                    {
                        PONo = row.Cells[0].Text;
                    }
                    objimportduty.PONO = PONo;
                    if (row.Cells[2].Text != "")
                    {
                        dutyamount = Convert.ToDouble(row.Cells[2].Text);
                    }
                    objimportduty.DutyAmount = dutyamount;
                    if (row.Cells[3].Text != "")
                    {
                        ImportVat = Convert.ToDouble(row.Cells[3].Text);
                    }
                    objimportduty.ImportVat = ImportVat;
                    if (row.Cells[4].Text != "")
                    {
                        MisAdj = Convert.ToDouble(row.Cells[4].Text);
                    }
                    objimportduty.MisLeAdj = MisAdj;
                    objimportduty.CreatedBy = Session["userid"].ToString();
                    objimportduty.CreatedDate = Convert.ToDateTime(ViewState["nowdate"]);
                    inserted = objimportduty.insertimportdutybooking();
                }
                if (inserted == 2)
                {
                    ClearAll();
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordSaved, 125, 300);
                    return;
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please enter PO details", 125, 300);
                return;
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Booking Form-Saving Import duty booking form-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
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
                    lSearchList.Text = "Search by Voucher No.";
                    colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
                }
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                gridMaster.DataSource = colimportdutybooking;
                gridMaster.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- btn_search_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            string key = txtSearchList.Text.Trim();
            if (HidPopUpType.Value == "bankgl")
            {
                lSearchList.Text = "Search by GL No.";
                gridMaster.Visible = false;
                Gdvlookup.Visible = true;
                DataTable dtbankgl = new DataTable();
                dtbankgl = objglmaster.GetGLCode_By_GLGroupName_ByGlcode("Bank", key);
                Gdvlookup.DataSource = dtbankgl;
                Gdvlookup.DataBind();
            }
            if (HidPopUpType.Value == "po")
            {
                lSearchList.Text = "Search by PO No.";
                DataTable dt = com.GetVal("@ponumber", key, "Sp_FA_GetPODetails_By_PoNo");
                Gdvlookup.DataSource = dt;
                Gdvlookup.DataBind();
            }
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            if (ddsearch.SelectedItem.Value == "VoucherNo")
            {
                lSearchList.Text = "Search by Voucher No.";
                colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(key);
                Gdvlookup.Visible = false;
                gridMaster.DataSource = colimportdutybooking;
                gridMaster.DataBind();
            }
            ModalPopupExtender1.Show();
        }

        catch (Exception ex)
        {
            logmessage = "Import Duty Form- btnSearchlist_Click -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region GridEvents
    protected void Gdvlookup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Gdvlookup.PageIndex = e.NewPageIndex;
            if (HidPopUpType.Value == "bankgl")
            {
                BindBankGL();
            }
            if (HidPopUpType.Value == "po")
            {
                BindPO();
            }
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- Gdvlookup_PageIndexChanging -Error-" + ex.ToString();
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
                if (HidPopUpType.Value == "bankgl")
                {
                    string glcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtGLCode.Text = glcode;
                    colslmaster = objslmaster.GetSL_ByGLCode(glcode);
                    DldSlCode.DataTextField = "SubSidiaryLedgerCode";
                    DldSlCode.DataValueField = "SubSidiaryLedgerCode";
                    DldSlCode.DataSource = colslmaster;
                    DldSlCode.DataBind();
                    ListItem item = new ListItem();
                    item.Text = "----Select----";
                    item.Value = "0";
                    DldSlCode.Items.Add(item);
                    DldSlCode.SelectedValue = "0";

                }
                if (HidPopUpType.Value == "vendor")
                {
                    string vendorcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtVendor.Text = vendorcode;

                }
                if (HidPopUpType.Value == "po")
                {
                    string po = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtPONo.Text = po;
                    TxtVendor.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;
                    lblvendorname.Text = objvendor.GetVendorName_By_VendorCode(TxtVendor.Text);
                    ViewState["DutyAmout"] = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    ViewState["ImportVAT"] = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Booking Form-Gdvlookup_RowCommand-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvlookup_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string voucherno = gridMaster.SelectedDataKey.Value.ToString();
            ViewState["vno"] = voucherno;
            objimportduty = objimportduty.GetImportDuty_HeaderInfo_By_Voucherno(voucherno);
            TxtChequeDate.Text = objimportduty.ChequeDate;
            TxtChequeNo.Text = objimportduty.ChequeNo;
            TxtGLCode.Text = objimportduty.GlCode;
            TxtInputVatSLCode.Text = objimportduty.InputSubCode;
            TxtPONo.Text = objimportduty.PONO;
            DldSlCode.SelectedValue = objimportduty.GlSubCode;
            TxtVoucherDate.Text = objimportduty.VoucherDate;
            TxtVoucherNo.Text = objimportduty.VoucherNo;
            TxtVoucherYear.Text = objimportduty.VoucherYear;
            colimportdutybooking = objimportduty.GetImportDuty_DetailsInfo_By_Voucherno(voucherno);
            GdvPODetails.DataSource = colimportdutybooking;
            GdvPODetails.DataBind();
            Btnaddmore.Enabled = false;
            Btnaddmore.ImageUrl = "~/Images/btnAddLineGrey.png";
            Btnsave.ImageUrl = "~/Images/btn_update.png";
            Btnsave.CausesValidation = false;
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- gridMaster_SelectedIndexChanged -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gridMaster.PageIndex = e.NewPageIndex;
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddsearch.SelectedItem.Value == "VoucherNo")
            {
                colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
            }
            gridMaster.Visible = true;
            gridMaster.DataSource = colimportdutybooking;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Import Duty Form- gridMaster_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
}