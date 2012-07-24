/////////////////// Designed and Developed by Lalit Joshi 29th May 2012///////////////////////////////////////////////////////
///////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Finance_Predefinedentries : System.Web.UI.Page
{
    #region Defind Global Objects
    string logmessage = "";
    BLLCollection<FA_ProfitCentermaster> colprofitcenter = new BLLCollection<FA_ProfitCentermaster>();
    FA_ProfitCentermaster objprofitcentermaster = new FA_ProfitCentermaster();
    BLLCollection<FA_CostCentermaster> colcostcenter = new BLLCollection<FA_CostCentermaster>();
    FA_CostCentermaster objcostcentermaster = new FA_CostCentermaster();
    FA_GLMaster objglmaster = new FA_GLMaster();
    BLLCollection<FA_GLMaster> colglmaster = new BLLCollection<FA_GLMaster>();
    FA_SLMaster objslmaster = new FA_SLMaster();
    BLLCollection<FA_SLMaster> colslmaster = new BLLCollection<FA_SLMaster>();
    FA_PredefinedEntries objpredef = new FA_PredefinedEntries();
    BLLCollection<FA_PredefinedEntries> colpredefined = new BLLCollection<FA_PredefinedEntries>();
    Common com = new Common();
    Common_Message commessage = new Common_Message();
    Common_mst objCommon_mst = new Common_mst();
    #endregion

    #region pageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
       
        ImageButton imgbutton = (ImageButton)Master.FindControl("imgbtnSearch");
        imgbutton.Click += new ImageClickEventHandler(btn_Search_Click);
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        if (!IsPostBack)
        {
            TxtEndDate.Attributes.Add("readonly", "true");
            TxtStartDate.Attributes.Add("readonly", "true");
            TxtEntry.Attributes.Add("readonly", "true");
            Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lbl_PageHeader.Text = "Pre-Defined Entries";
            BindTempTable();
            BindCostCenter();
            BindGLCode();
            BindSLCode();
            BindPlanning();
            BindProfitCenter();
            BindSearchList();
        }
    }
    #endregion

    #region Defined Functions
    private void BindTempTable()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Line#", typeof(string));
            dt.Columns.Add("G.L.Code", typeof(string));
            dt.Columns.Add("S.L.Code", typeof(string));
            dt.Columns.Add("Start Date", typeof(string));
            dt.Columns.Add("End Date", typeof(string));
            dt.Columns.Add("Debit Amount", typeof(string));
            dt.Columns.Add("Credit Amount", typeof(string));
            dt.Columns.Add("LnNo", typeof(string));
            DataRow drow = dt.NewRow();
            drow["Line#"] = "";
            drow["G.L.Code"] = "";
            drow["S.L.Code"] = "";
            drow["Start Date"] = "";
            drow["End Date"] = "";
            drow["Debit Amount"] = "";
            drow["Credit Amount"] = "";
            drow["LnNo"] = "";
            dt.Rows.Add(drow);
            GdvDescription.Visible = true;
            GdvDescription.DataSource = dt;
            GdvDescription.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "PreDefined Entries Form- Bind Temp Table in page load-Error-" + ex.ToString();
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
            logmessage = "PreDefined Entries Form-BindingProfitCenter-Error-" + ex.ToString();
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
            logmessage = "PreDefined Entries Form-BindingCostCenter-Error-" + ex.ToString();
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
            logmessage = "PreDefined Entries Form-BindingGLCode-Error-" + ex.ToString();
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
            logmessage = "PreDefined Entries Form-BindingSubGLCode-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindPlanning()
    {
        try
        {
            DataTable dtplanninglist = new DataTable();
            dtplanninglist = com.executeProcedure("Sp_Com_GetPlanningList");
            DdlPlanned.DataSource = dtplanninglist;
            DdlPlanned.DataTextField = "PlanName";
            DdlPlanned.DataValueField = "PlanName";
            DdlPlanned.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlPlanned.Items.Add(item);
            DdlPlanned.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "PreDefined Entries Form-BindingPlanning-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdProformaInvoice = ConfigurationManager.AppSettings["FormIdPredefinedentries"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProformaInvoice);

            ddlSearch.DataTextField = "Options";
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();
                ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }
        catch (Exception ex)
        {
            logmessage = "Predefined Entry Form-Binding Search list-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void clearfields()
    {
        Txtdescription.Text = "";
        TxtCreditAmount.Text = "";
        TxtDebitAmount.Text = "";
        TxtEndDate.Text = "";
        TxtEntry.Text = "";
        TxtStartDate.Text = "";
        DdlCostCenter.SelectedValue = "0";
        DdlGLCode.SelectedValue = "0";
        DdlPlanned.SelectedValue = "0";
        DdlProfitCenter.SelectedValue = "0";
        DdlSubGLCode.SelectedValue = "0";
    }
    private void BindPredefinedEntries(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            colpredefined = objpredef.Get_PredefinedAllRecords(ddlSearchValue, txtSearchValue);
            gdvsearchlist.DataSource = colpredefined;
            gdvsearchlist.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Predefined entries form-BindPredefinedEntries-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region GridEvents
    protected void GdvDescriptionmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
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
                    GdvDescriptionmain.DataSource = null;
                    GdvDescriptionmain.DataBind();
                    BindTempTable();
                    TxtTotalAmount.Text = "";
                }
                else
                {
                    GdvDescriptionmain.DataSource = dt;
                    GdvDescriptionmain.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Predefined entries form - Deleting listitem from temp grid - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gdvsearchlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "select")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["Id"] = id;
                objpredef = objpredef.GetPredefinedEntries_ById(id);
                TxtEntry.Text = objpredef.EntryNo.ToString();
                TxtStartDate.Text = objpredef.StartDate;
                TxtEndDate.Text = objpredef.EndDate;
                DdlPlanned.SelectedValue = objpredef.Planned;
                DdlGLCode.SelectedValue = objpredef.GLCode;
                DdlProfitCenter.SelectedValue = objpredef.ProfitCenter;
                DdlSubGLCode.SelectedValue = objpredef.SubGLCode;
                DdlCostCenter.SelectedValue = objpredef.CostCenter;
                TxtDebitAmount.Text = objpredef.DebitAmount.ToString();
                TxtCreditAmount.Text = objpredef.CreditAmount.ToString();
                Txtdescription.Text = objpredef.Description;
                BtnSave.Text = "Update";
                BtnAddLine.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Predefined entries form - gdvsearchlist_RowCommand - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Button Events
    protected void BtnAddLine_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt = null;
            int LineNo;
            string startdate = "";
            string enddate = "";
            double DebitAmount = 0.0, CreditAmount = 0.0;
            double totaldebitamount = 0.0, totalcreditamount = 0.0;
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
                dt.Columns.Add("LineNo", typeof(int));
                dt.Columns.Add("GLCode", typeof(string));
                dt.Columns.Add("SLCode", typeof(string));
                dt.Columns.Add("StartDate", typeof(string));
                dt.Columns.Add("EndDate", typeof(string));
                dt.Columns.Add("DebitAmount", typeof(double));
                dt.Columns.Add("CreditAmount", typeof(double));
                dt.Columns.Add("Planned", typeof(string));
                dt.Columns.Add("ProfitCenter", typeof(string));
                dt.Columns.Add("CostCenter", typeof(string));
                dt.Columns.Add("Description", typeof(string));
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
            drow["GLCode"] = DdlGLCode.SelectedValue;
            drow["SLCode"] = DdlSubGLCode.SelectedValue;

            startdate = TxtStartDate.Text;
            drow["StartDate"] = startdate;
            enddate = TxtEndDate.Text;
            drow["EndDate"] = enddate;
            if (TxtDebitAmount.Text != "")
            {
                DebitAmount = Convert.ToDouble(TxtDebitAmount.Text);
            }
            if (TxtCreditAmount.Text != "")
            {
                CreditAmount = Convert.ToDouble(TxtCreditAmount.Text);
            }
            drow["DebitAmount"] = DebitAmount;
            drow["CreditAmount"] = CreditAmount;
            drow["Planned"] = DdlPlanned.SelectedValue;
            drow["ProfitCenter"] = DdlProfitCenter.SelectedValue;
            drow["CostCenter"] = DdlCostCenter.SelectedValue;
            drow["Description"] = Txtdescription.Text;
            dt.Rows.Add(drow);
            ViewState["Details"] = dt;
            ViewState["LnNo"] = drow["LineNo"];
            #region Fill total value of Debit Amount if debit amount is filled by user
            if (TxtDebitAmount.Text != "")
            {
                if (ViewState["totaldebitamount"] != null)
                {
                    totaldebitamount = Convert.ToDouble(ViewState["totaldebitamount"]) + Convert.ToDouble(TxtDebitAmount.Text);
                    ViewState["totaldebitamount"] = totaldebitamount;
                }
                else
                {
                    totaldebitamount = Convert.ToDouble(TxtDebitAmount.Text);
                    ViewState["totaldebitamount"] = totaldebitamount;
                }
                TxtTotalAmount.Text = totaldebitamount.ToString();
            }
            #endregion
            #region Fill total value of Credit Amount if credit amount is filled by user
            if (TxtCreditAmount.Text != "")
            {
                if (ViewState["totalcreditamount"] != null)
                {
                    totalcreditamount = Convert.ToDouble(ViewState["totalcreditamount"]) + Convert.ToDouble(TxtCreditAmount.Text);
                    ViewState["totalcreditamount"] = totalcreditamount.ToString();
                }
                else
                {
                    totalcreditamount = Convert.ToDouble(TxtCreditAmount.Text);
                    ViewState["totalcreditamount"] = totalcreditamount;
                }
                TxtTotalAmount.Text = totalcreditamount.ToString();
            }
            #endregion
            GdvDescription.Visible = false;
            GdvDescriptionmain.DataSource = dt;
            GdvDescriptionmain.DataBind();
            clearfields();
        }
        catch (Exception ex)
        {
            logmessage = "Predefined entry Form-Adding line Numbers-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
           
            #region Update record
            if (BtnSave.Text == "Update")
            {
                objpredef.StartDate = TxtStartDate.Text;
                objpredef.EndDate = TxtEndDate.Text;
                objpredef.Planned = DdlPlanned.SelectedValue;
                objpredef.GLCode = DdlGLCode.SelectedValue;
                objpredef.ProfitCenter = DdlProfitCenter.SelectedValue;
                objpredef.SubGLCode = DdlSubGLCode.SelectedValue;
                objpredef.CostCenter = DdlCostCenter.SelectedValue;
                if (TxtDebitAmount.Text != "")
                {
                    objpredef.DebitAmount = Convert.ToDouble(TxtDebitAmount.Text);
                }
                if (TxtCreditAmount.Text != "")
                {
                    objpredef.CreditAmount = Convert.ToDouble(TxtCreditAmount.Text);
                }
                objpredef.Description = Txtdescription.Text;
                int updated = objpredef.UpdatePredefinedEntries(Convert.ToInt32(ViewState["Id"]));
                if (updated == 1)
                {
                    ViewState["Id"] = null;
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);
                    return;
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, commessage.RecordNotUpdated, 125, 300);
                    return;
                }
            }
            #endregion
            #region Insert record
            else
            {
                if (GdvDescriptionmain.Rows.Count > 0)
                {
                    double debitamount = 0.0, creditamount = 0.0;
                    int entryno = 0, inserted = 0;
                    foreach (GridViewRow row in GdvDescriptionmain.Rows)
                    {
                        #region Get value from grid 
                        string lineno = ((Label)row.FindControl("Lbllineno")).Text;
                        string startdate = ((Label)row.FindControl("Lblstartdate")).Text;
                        string enddate = ((Label)row.FindControl("Lblenddate")).Text;
                        string planned = ((Label)row.FindControl("Lblplanned")).Text;
                        string glcode = ((Label)row.FindControl("Lblglcode")).Text;
                        string profitcenter = ((Label)row.FindControl("Lblprofitcenter")).Text;
                        string subglcode = ((Label)row.FindControl("Lblslcode")).Text;
                        string costcenter = ((Label)row.FindControl("Lblcostcenter")).Text;
                        debitamount = Convert.ToDouble(((Label)row.FindControl("Lbldebitamount")).Text);
                        creditamount = Convert.ToDouble(((Label)row.FindControl("Lblcreditamount")).Text);
                        string description = ((Label)row.FindControl("Lbldescription")).Text;
                        #endregion
                        #region Assign value to properties
                        objpredef.StartDate = startdate;
                        objpredef.EndDate = enddate;
                        objpredef.Planned = planned;
                        objpredef.GLCode = glcode;
                        objpredef.ProfitCenter = profitcenter;
                        objpredef.SubGLCode = subglcode;
                        objpredef.CostCenter = costcenter;
                        objpredef.DebitAmount = debitamount;
                        objpredef.CreditAmount = creditamount;
                        objpredef.Description = description;
                        objpredef.LineNo = Convert.ToInt32(lineno);
                        #endregion
                        #region GetlastEntryId
                        int lastentryno = objpredef.GetLastEntryNo();
                        if (lastentryno != 0)
                        {
                            if (row.RowIndex != 0)
                            {
                                entryno = lastentryno;
                            }
                        }
                        objpredef.EntryNo = entryno;
                        #endregion
                        inserted = objpredef.insertprededineddetails();
                    }
                    #region if record save then return 1 and show a message
                    if (inserted == 1)
                    {
                        ViewState["Details"] = null;
                        GdvDescriptionmain.DataSource = null;
                        GdvDescriptionmain.DataBind();
                        BindTempTable();
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);
                        return;
                    }
                    #endregion
                    #region if any error then show an error message
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, commessage.RecordNotSaved, 125, 300);
                        return;
                    }
                    #endregion
                }
                #region if no line item is filled by user then show a message to fill line items
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.AddLineItem, 125, 300);
                    return;
                }
                #endregion
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "Predefined entries form-saving predefined entries-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddlSearch.SelectedValue != "0")
            {
                BindPredefinedEntries(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
                ModalPopupExtender1.Show();
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.SelectValue, 125, 300);
            }
        }
        catch (Exception ex)
        {
            logmessage = "Predefined entries form - Searching items - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        clearfields();
        BtnSave.Text = "Save";
        BtnAddLine.Enabled = true;
    }
    #endregion

    #region Selected index changed event
    protected void DdlPlanned_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime startdt = new DateTime();
        DateTime enddt = new DateTime();
        if (TxtStartDate.Text != "")
        {
            startdt = Convert.ToDateTime(TxtStartDate.Text);
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, "Please select start date", 125, 300);
            return;
        }
        if (TxtEndDate.Text != "")
        {
            enddt = Convert.ToDateTime(TxtEndDate.Text);
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, "Please select end date", 125, 300);
            return;
        }
        TimeSpan t = enddt - startdt;
        int daysdiff = t.Days;
        if (daysdiff > 0)
        {
            if (DdlPlanned.SelectedItem.Text == "Monthly")
            {
                if (daysdiff >= 30)
                {
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, "No of days are less in monthly plan", 125, 300);
                    TxtStartDate.Text = "";
                    TxtEndDate.Text = "";
                    DdlPlanned.SelectedValue = "0";
                    return;
                }
            }
            if (DdlPlanned.SelectedItem.Text == "Quarterly")
            {
                if (daysdiff >= 90)
                {
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, "No of days are less in Quarter plan", 125, 300);
                    TxtStartDate.Text = "";
                    TxtEndDate.Text = "";
                    DdlPlanned.SelectedValue = "0";
                    return;
                }
            }
            if (DdlPlanned.SelectedItem.Text == "Half Yearly")
            {
                if (daysdiff >= 180)
                {
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, "No of days are less in half year plan", 125, 300);
                    TxtStartDate.Text = "";
                    TxtEndDate.Text = "";
                    DdlPlanned.SelectedValue = "0";
                    return;
                }
            }
            if (DdlPlanned.SelectedItem.Text == "Yearly")
            {
                if (daysdiff >= 365)
                {
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, "No of days are less in year plan", 125, 300);
                    TxtStartDate.Text = "";
                    TxtEndDate.Text = "";
                    DdlPlanned.SelectedValue = "0";
                    return;
                }
            }

        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, "Start date should always less than End date", 125, 300);
            TxtStartDate.Text = "";
            TxtEndDate.Text = "";
            DdlPlanned.SelectedValue = "0";
            return;
        }


    }
    #endregion
    
}