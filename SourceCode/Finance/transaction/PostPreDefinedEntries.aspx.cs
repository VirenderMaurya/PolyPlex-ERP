#region Designed and Developend by Lalit Joshi on 5 June 2012////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Finance_transaction_PostPreDefinedEntries : System.Web.UI.Page
{
    #region Define Global variable
    string logmessage = "";
    Common_mst objCommon_mst = new Common_mst();
    Common_Message objcommonmessage = new Common_Message();
    FA_PredefinedEntries objpredefinedhistory = new FA_PredefinedEntries();
    BLLCollection<FA_PredefinedEntries> colpredefinedhistory = new BLLCollection<FA_PredefinedEntries>();
    FA_VoucherType objVoucherType = new FA_VoucherType();
    BLLCollection<FA_VoucherType> col = new BLLCollection<FA_VoucherType>();
    BLLCollection<FA_VoucherSeries> colseries = new BLLCollection<FA_VoucherSeries>();
    FA_VoucherSeries objVoucherSeries = new FA_VoucherSeries();
    PostPreDefinedEntries objpostpredefined = new PostPreDefinedEntries();
    FA_PostPredefinedEntriesHistory objpostpredefinedhistory = new FA_PostPredefinedEntriesHistory();

    Common_Message commessage = new Common_Message();
    #endregion

    #region PageLoad event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                readonlycontrols();
                Log.PageHeading(this, "Post Pre-Defined Entries");
                BindSearchList();
                BindAllPredefinedHistory();
                BindVoucherType();
                BindVoucherSeries();
                Log.GetLog().FillFinancialYear(TxtVoucherYear);
            }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- Pageload event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region bindfunctions
    private void BindMasterSearchBox()
    {
        try
        {
            ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
            btn_add.Click += new ImageClickEventHandler(btn_add_Click);
            btn_add.CausesValidation = false;
            ImageButton imgbtnSearch = (ImageButton)Master.FindControl("imgbtnSearch");
            imgbtnSearch.CausesValidation = false;
            imgbtnSearch.Click += new ImageClickEventHandler(imgbtnSearch_Click);
        }
        catch (Exception ex)
        {
            logmessage = "Post Pre-Defined Entries Form- BindMasterSearchBox Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindAllPredefinedHistory()
    {
        try
        {
            DataTable dt = new DataTable();
            colpredefinedhistory = objpredefinedhistory.GetAllPredefinedHistory();
            dt.Columns.Add("EntryNo", typeof(string));
            dt.Columns.Add("StartDate", typeof(string));
            dt.Columns.Add("EndDate", typeof(string));
            dt.Columns.Add("Planned", typeof(string));
            dt.Columns.Add("GLCode", typeof(string));
            dt.Columns.Add("SubGLCode", typeof(string));
            dt.Columns.Add("ProfitCenter", typeof(string));
            dt.Columns.Add("CostCenter", typeof(string));
            dt.Columns.Add("DebitAmount", typeof(string));
            dt.Columns.Add("CreditAmount", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("PostedBy", typeof(string));
            dt.Columns.Add("PostedOn", typeof(string));

            foreach (FA_PredefinedEntries p in colpredefinedhistory)
            {
                DataRow drow = dt.NewRow();
                drow["EntryNo"] = p.EntryNo;
                drow["StartDate"] = p.StartDate;
                drow["EndDate"] = p.EndDate;
                drow["Planned"] = p.Planned;
                drow["GLCode"] = p.GLCode;
                drow["SubGLCode"] = p.SubGLCode;
                drow["ProfitCenter"] = p.ProfitCenter;
                drow["CostCenter"] = p.CostCenter;
                drow["DebitAmount"] = p.DebitAmount;
                drow["CreditAmount"] = p.CreditAmount;
                drow["Description"] = p.Description;
                drow["PostedBy"] = p.PostedBy;
                drow["PostedOn"] = p.PostedOn;
                dt.Rows.Add(drow);
            }

            ViewState["Entries"] = dt;
            GdvPredefinedEntries.DataSource = colpredefinedhistory;
            GdvPredefinedEntries.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form-BindAllPredefinedHistory-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    public void BindSelectedGrid()
    {
        try
        {
            DataTable dt = (DataTable)ViewState["Entries"];
            if (dt.Rows.Count > 0)
            {
                GdvselectedEntries.DataSource = dt;
                GdvselectedEntries.DataBind();
                foreach (GridViewRow row in GdvselectedEntries.Rows)
                {
                    row.Cells[11].Visible = false;
                    row.Cells[12].Visible = false;
                }
                GdvselectedEntries.HeaderRow.Cells[11].Visible = false;
                GdvselectedEntries.HeaderRow.Cells[12].Visible = false;
            }
            else
            {
                BindSelectedGridStructure();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Post Pre-Defined Entries Form- BindSelectedGrid Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    public void BindSelectedGridStructure()
    {
        try
        {
            DataTable dt = new DataTable();
            objpredefinedhistory = objpredefinedhistory.GetPredefinedEntries_ById(0);
            if (dt.Rows.Count > 0)
            {
                ViewState["Entries"] = dt;
                GdvselectedEntries.DataSource = dt;
                GdvselectedEntries.DataBind();
                foreach (GridViewRow row in GdvselectedEntries.Rows)
                {
                    row.Cells[11].Visible = false;
                    row.Cells[12].Visible = false;
                }
            }
            else
            {
                GdvselectedEntries.DataSource = "";
                GdvselectedEntries.DataBind();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Post Pre-Defined Entries Form- BindSelectedGridStructure Method -Error-" + ex.ToString();
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
            logmessage = "Post-Predefined entry Form-BindingVoucherType-Error-" + ex.ToString();
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
    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdFAPostPreDefinedEntry = ConfigurationManager.AppSettings["FormIdFAPostPreDefinedEntry"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdFAPostPreDefinedEntry);

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
            logmessage = "Journal Voucher Form- BindSearchList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void readonlycontrols()
    {
        TxtVoucherNo.Attributes.Add("readonly", "true");
        TxtVoucherDate.Attributes.Add("readonly", "true");
        TxtVoucherYear.Attributes.Add("readonly", "true");
    }
    private void GetData()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["Entries"];
            CheckBox chkAll = (CheckBox)GdvPredefinedEntries.HeaderRow.Cells[0].FindControl("chkbxAll");
            for (int i = 0; i < GdvPredefinedEntries.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    dt = AddRow(GdvPredefinedEntries.Rows[i], dt);
                }
                else
                {
                    CheckBox chk = (CheckBox)GdvPredefinedEntries.Rows[i].Cells[0].FindControl("checkbx");
                    int index = GdvPredefinedEntries.Rows[i].RowIndex;
                    if (chk.Checked)
                    {
                        dt = AddRow(GdvPredefinedEntries.Rows[i], dt);
                    }
                    else
                    {
                        dt = RemoveRow(GdvPredefinedEntries.Rows[i], dt);
                    }
                }

            }
            ViewState["Entries"] = dt;
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- GetData -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        try
        {
            DataRow[] dr = dt.Select("EntryNo = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["EntryNo"] = gvRow.Cells[1].Text;
                dt.Rows[dt.Rows.Count - 1]["StartDAte"] = gvRow.Cells[2].Text;
                dt.Rows[dt.Rows.Count - 1]["EndDate"] = gvRow.Cells[3].Text;
                dt.Rows[dt.Rows.Count - 1]["Planned"] = gvRow.Cells[4].Text;
                dt.Rows[dt.Rows.Count - 1]["GLCode"] = gvRow.Cells[5].Text;
                dt.Rows[dt.Rows.Count - 1]["SubGLCode"] = gvRow.Cells[6].Text;
                dt.Rows[dt.Rows.Count - 1]["ProfitCenter"] = gvRow.Cells[7].Text;
                dt.Rows[dt.Rows.Count - 1]["CostCenter"] = gvRow.Cells[8].Text;
                dt.Rows[dt.Rows.Count - 1]["DebitAmount"] = gvRow.Cells[9].Text;
                dt.Rows[dt.Rows.Count - 1]["CreditAmount"] = gvRow.Cells[10].Text;
                dt.Rows[dt.Rows.Count - 1]["Description"] = gvRow.Cells[11].Text;
                dt.Rows[dt.Rows.Count - 1]["PostedBy"] = gvRow.Cells[11].Text;
                dt.Rows[dt.Rows.Count - 1]["PostedOn"] = gvRow.Cells[12].Text;
                dt.AcceptChanges();
            }
           
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- AddRow -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return dt;
    }
    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        try
        {
            DataRow[] dr = dt.Select("EntryNo = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Journal Voucher Form- RemoveRow -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return dt;
    }
    private void clearall()
    {
        DdlVoucherSeries.SelectedValue = "0";
        DdlVoucherType.SelectedValue = "0";
        TxtVoucherDate.Text = "";
        TxtVoucherNo.Text = "";
        GdvselectedEntries.DataSource = null;
        GdvselectedEntries.DataBind();
    }
    #endregion

    #region gridevents
    protected void GdvPredefinedEntries_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvPredefinedEntries.PageIndex = e.NewPageIndex;
            BindAllPredefinedHistory();
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form-GdvPredefinedEntries_PageIndexChanging-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void Get_FA_GetAllPostPredefinedEntries(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objpredefinedhistory.Get_FA_GetAllPostPredefinedEntries(ddlSearchValue, txtSearchValue);

            if (dt.Rows.Count > 0)
            {
                gvAllPredefinedEntriesList.DataSource = dt;
                gvAllPredefinedEntriesList.AllowPaging = true;
                gvAllPredefinedEntriesList.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvAllPredefinedEntriesList.AllowPaging = false;
                gvAllPredefinedEntriesList.DataSource = "";
                gvAllPredefinedEntriesList.DataBind();
            }
        }
        catch (Exception ex)
        {
            gvAllPredefinedEntriesList.AllowPaging = false;
            gvAllPredefinedEntriesList.DataSource = "";
            gvAllPredefinedEntriesList.DataBind();
            logmessage = "Post-PreDefined Form- Get_FA_GetAllPostPredefinedEntries -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvAllPredefinedEntriesList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[1].Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- gvAllPredefinedEntriesList_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvAllPredefinedEntriesList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvAllPredefinedEntriesList = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvAllPredefinedEntriesList.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvAllPredefinedEntriesList.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                int Id = Convert.ToInt32(e.CommandArgument);
                DataTable dt = objpredefinedhistory.Get_FA_GetAllPostPredefinedEntriesById(Id);
                if (dt.Rows.Count > 0)
                {
                    ViewState["Entries"] = dt;
                    GdvPredefinedEntries.DataSource = dt;
                    GdvPredefinedEntries.DataBind();
                }
                dt = null;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- gvAllPredefinedEntriesList_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvAllPredefinedEntriesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAllPredefinedEntriesList.PageIndex = e.NewPageIndex;
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddlSearch.SelectedValue != "0")
            {
                if (ddlSearch.SelectedValue.ToString() == "EntryNo")
                {
                    Get_FA_GetAllPostPredefinedEntries("EntryNo", txtSearch.Text.Trim());
                    lSearchList.Text = "Search By EntryNo.: ";
                }
                else if (ddlSearch.SelectedValue.ToString() == "Planned")
                {
                    Get_FA_GetAllPostPredefinedEntries("Planned", txtSearch.Text.Trim());
                    lSearchList.Text = "Search By Planned: ";
                }
                ModalPopupExtender2.Show();

            }
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- gvAllPredefinedEntriesList_PageIndexChanging - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region click events
    protected void btn_add_Click(object sender, EventArgs e)
    {
        clearall();
    }
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddlSearch.SelectedValue != "0")
            {
                if (ddlSearch.SelectedValue.ToString() == "EntryNo")
                {
                    Get_FA_GetAllPostPredefinedEntries("EntryNo", txtSearch.Text.Trim());
                    lSearchList.Text = "Search By EntryNo.: ";
                }
                else if (ddlSearch.SelectedValue.ToString() == "Planned")
                {
                    Get_FA_GetAllPostPredefinedEntries("Planned", txtSearch.Text.Trim());
                    lSearchList.Text = "Search By Planned: ";
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
            logmessage = "Post-PreDefined Form- imgbtnSearch_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void chk_CheckChanged(object sender, EventArgs e)
    {
        GetData();
        BindSelectedGrid();
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            if (ddlSearch.SelectedValue.ToString() == "EntryNo")
            {
                Get_FA_GetAllPostPredefinedEntries("EntryNo", txtSearchList.Text.Trim());
                lSearchList.Text = "Search By EntryNo.: ";
            }
            else if (ddlSearch.SelectedValue.ToString() == "Planned")
            {
                Get_FA_GetAllPostPredefinedEntries("Planned", txtSearchList.Text.Trim());
                lSearchList.Text = "Search By Planned: ";
            }
            ModalPopupExtender2.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- btnSearchlist_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void chkAll_CheckChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkAll = (CheckBox)GdvPredefinedEntries.HeaderRow.Cells[0].FindControl("chkbxall");
            for (int i = 0; i < GdvPredefinedEntries.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GdvPredefinedEntries.Rows[i].Cells[0].FindControl("checkbx");
                if (chkAll.Checked == true)
                {
                    chk.Checked = true;
                }
                if (chkAll.Checked == false)
                {
                    chk.Checked = false;
                }
            }
            GetData();
            BindSelectedGrid();
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- chkAll_CheckChanged - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            int historyinserted = 0, inserted = 0, entryno = 0;
            objpostpredefined.VoucherType = DdlVoucherType.SelectedValue;
            objpostpredefined.VoucherSeries = DdlVoucherSeries.SelectedValue;
            objpostpredefined.VoucherYear = TxtVoucherYear.Text;
            objpostpredefined.VoucherDate = TxtVoucherDate.Text;
            if (GdvselectedEntries.Rows.Count > 0)
            {

                foreach (GridViewRow row in GdvselectedEntries.Rows)
                {
                    if (row.Cells[0].Text != "")
                    {
                        objpostpredefined.EntryNo = Convert.ToInt32(row.Cells[0].Text);
                        entryno = objpostpredefined.EntryNo;
                    }
                    objpostpredefined.StartDate = row.Cells[1].Text;
                    objpostpredefined.EndDate = row.Cells[2].Text;
                    string postedby = Session["userid"].ToString();
                    objpostpredefined.PostedBy = postedby;
                    inserted = objpostpredefined.insertPostprededineddetails(objpostpredefined.EntryNo, objpostpredefined.StartDate, objpostpredefined.EndDate, objpostpredefined.PostedBy, objpostpredefined.VoucherType, objpostpredefined.VoucherSeries, objpostpredefined.VoucherYear, objpostpredefined.VoucherDate, objpostpredefined.Planned);
                }
                if (inserted == 1)
                {
                    objpostpredefinedhistory.EntryNo = entryno;
                    objpostpredefinedhistory.PostedBy = Session["userid"].ToString();
                    historyinserted = objpostpredefinedhistory.insertPostprededinedHistorydetails();
                    if (historyinserted == 1)
                    {
                        BindAllPredefinedHistory();
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);
                        GdvselectedEntries.DataSource = null;
                        GdvselectedEntries.DataBind();
                        return;
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, commessage.RecordNotSaved, 125, 300);
                    return;
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, "Please select entries", 125, 300);
                return;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- Btnsave_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
}

