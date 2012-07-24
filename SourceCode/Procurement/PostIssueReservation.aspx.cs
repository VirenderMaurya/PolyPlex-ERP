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
    Proc_PostIssueReservation objProc_PostIssueReservation = new Proc_PostIssueReservation();
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblInfo.Text = "";
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Post Issue Reservation";
            txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

            TDIssueNo.Attributes.Add("style", "display:none");
            TDtxtIssueNo.Attributes.Add("style", "display:none");

            #region Bind Masters

            BindSearchList();
            FillFinancialYear();

            #endregion   

            #region Bind Grid

            BindAllIssueReservationList();

            #endregion

            #region Blank Grid
            
            gvPostIssueReserLow.DataSource = "";
            gvPostIssueReserLow.DataBind(); 

            #endregion

            #region Readonly Fields
            txtIssueYear.Attributes.Add("readonly", "true");
            txtIssueNo.Attributes.Add("readonly", "true");
            txtIssueDate.Attributes.Add("readonly", "true");
            txtReservationNo.Attributes.Add("readonly", "true");
            #endregion

            #region Color Changed Controls
            txtIssueYear.Attributes.Add("style", "background:lightgray");
            txtIssueNo.Attributes.Add("style", "background:lightgray");
            txtIssueDate.Attributes.Add("style", "background:lightgray");
            txtReservationNo.Attributes.Add("style", "background:lightgray");
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
        lblInfo.Text = "";
        ClearGrid();
        ClearBottom();
        ViewState["SelectedRecords"] = null;
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchList.Text = "";
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindAllPostIssueReservationList(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
        BindAllPostIssueReservationList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvPostIssueReserHeader_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[4].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvPostIssueReserLow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
                e.Row.Cells[17].Style.Add("display", "none");
                e.Row.Cells[18].Style.Add("display", "none");
                e.Row.Cells[19].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvPostIssueReserHeader_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvPostIssueReserHeader = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvPostIssueReserHeader.SelectedIndex = row.RowIndex;

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvPostIssueReserHeader.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            #region Bind Form

            HidIssueReservationId.Value = Convert.ToString(e.CommandArgument);
            txtReservationNo.Text = gvPostIssueReserHeader.Rows[gvPostIssueReserHeader.SelectedIndex].Cells[1].Text;
            GetProc_IssueReservation_LineItems_Trans(Convert.ToInt32(HidIssueReservationId.Value),"Form");
            HidIsForm.Value = "true";
            #endregion
        }
    }

    protected void chkAll_CheckChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvPostIssueReserLow.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvPostIssueReserLow.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvPostIssueReserLow.Rows[i].Cells[0].FindControl("chk");
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
        //BindRollReturnedGrid();
    }

    protected void chk_CheckChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvPostIssueReserLow.HeaderRow.Cells[0].FindControl("chkAll");        
        if (chkAll.Checked == true)
        {
            chkAll.Checked = false;
        }
        for (int i = 0; i < gvPostIssueReserLow.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvPostIssueReserLow.Rows[i].Cells[0].FindControl("chk");
            chkAll.Checked = true;
            if (chk.Checked == false)
            {
                chkAll.Checked = false;
                break;
            }            
        }
        HidIsChecked.Value = "Yes";
        GetData();
        //BindRollReturnedGrid();
    }

    protected void gvPostIssueReservationList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[5].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvPostIssueReservationList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvPostIssueReservationList = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvPostIssueReservationList.SelectedIndex = row.RowIndex;

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvPostIssueReservationList.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            HidAutoId.Value = Convert.ToString(e.CommandArgument);

            #region Bind Form

            HidAutoId.Value = Convert.ToString(e.CommandArgument);

            txtIssueNo.Text = gvPostIssueReservationList.Rows[gvPostIssueReservationList.SelectedIndex].Cells[1].Text;
            txtIssueDate.Text = gvPostIssueReservationList.Rows[gvPostIssueReservationList.SelectedIndex].Cells[2].Text;
            txtIssueYear.Text = gvPostIssueReservationList.Rows[gvPostIssueReservationList.SelectedIndex].Cells[3].Text;
            txtReservationNo.Text = gvPostIssueReservationList.Rows[gvPostIssueReservationList.SelectedIndex].Cells[4].Text;
            HidIssueReservationId.Value = gvPostIssueReservationList.Rows[gvPostIssueReservationList.SelectedIndex].Cells[5].Text;

            HidIsForm.Value = "false";
            GetProc_IssueReservation_Header_Trans(Convert.ToInt32(HidIssueReservationId.Value));
            GetProc_IssueReservation_LineItems_Trans(Convert.ToInt32(HidAutoId.Value), "List");
            
            #endregion

            TDIssueNo.Attributes.Add("style", "display:block");
            TDtxtIssueNo.Attributes.Add("style", "display:block");
        }
    }

    protected void gvPostIssueReservationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPostIssueReservationList.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllPostIssueReservationList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }    

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Upadte Record Of Header & Line Item

            DataTable dtLineItem = (DataTable)ViewState["SelectedRecords"];
            if (dtLineItem.Rows.Count > 0)
            {
                #region Insert/Update Records Of Header

                if (HidAutoId.Value == "")
                {
                    objProc_PostIssueReservation.AutoId = 0;
                }
                else
                {
                    objProc_PostIssueReservation.AutoId = Convert.ToInt32(HidAutoId.Value);
                }
                objProc_PostIssueReservation.IssueYear = txtIssueYear.Text.Trim();
                if (txtIssueDate.Text.Trim() != "")
                {
                    objProc_PostIssueReservation.IssueDate = DateTime.ParseExact(txtIssueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_PostIssueReservation.IssueDate = "";
                }
                objProc_PostIssueReservation.ReservationId = Convert.ToInt32(HidIssueReservationId.Value);                
                objProc_PostIssueReservation.ActiveStatus = Convert.ToBoolean(1);
                objProc_PostIssueReservation.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objProc_PostIssueReservation.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                #endregion

                #region Insert/Update Records of LineItem

                objProc_PostIssueReservation.dtLineItems = new DataTable();
                objProc_PostIssueReservation.dtLineItems = objProc_PostIssueReservation.GetProc_PostIssueReservation_LineItems_Trans_Structure();
                DataRow objdrLineItems;

                if (dtLineItem.Rows.Count > 0)
                {
                    if (HidIsChecked.Value == "Yes")
                    {
                        foreach (DataRow objdrLineItem in dtLineItem.Rows)
                        {
                            if (objdrLineItem["IsUpdate"].ToString() == "True")
                            {
                                objdrLineItems = objProc_PostIssueReservation.dtLineItems.NewRow();
                                
                                if (HidAutoId.Value == "")
                                {
                                    objdrLineItems["PostIssReserId"] = 0;
                                }
                                else
                                {
                                    objdrLineItems["PostIssReserId"] = Convert.ToInt32(HidAutoId.Value);
                                }
                                objdrLineItems["IssResLineItemId"] = Convert.ToInt32(objdrLineItem["AutoId"].ToString());
                                if (HidIsForm.Value == "false")
                                {
                                    objdrLineItems["AutoId"] = objdrLineItem["PostReseLineItemId"].ToString();
                                    objdrLineItems["ActiveStatus"] = false;
                                }
                                else if (HidIsForm.Value == "true")
                                {
                                    objdrLineItems["AutoId"] = 0;
                                    objdrLineItems["ActiveStatus"] = objdrLineItem["ActiveStatus"].ToString();
                                }                                
                                objProc_PostIssueReservation.dtLineItems.Rows.Add(objdrLineItems);
                                objProc_PostIssueReservation.dtLineItems.AcceptChanges();
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

                FlagInsertUpdate = objProc_PostIssueReservation.InsertUpdate_In_Proc_PostIssueReservation();
                if (FlagInsertUpdate == "0")
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                    #region Clear All records after save

                    ClearBottom();
                    ClearGrid();
                    ViewState["LineItem"] = null;

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
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectLineItem, 125, 300);
                return;
            }

            #endregion
        }
        catch
        {
            if (ViewState["SelectedRecords"] == null)
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectIssueReservation, 125, 300);
                return;
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
            }
        }
    }

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdProcPostIssueReservation = ConfigurationManager.AppSettings["FormIdProcPostIssueReservation"].ToString();
            
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProcPostIssueReservation);

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
                    txtIssueYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    txtIssueYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch (Exception ex) { }
    }

    #endregion

    # region Function to Clear Form

    private void ClearBottom()
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            ddlSearch.SelectedValue = "0";
            HidAutoId.Value = "";
            HidIssueReservationId.Value = "";
            FillFinancialYear();
            txtIssueNo.Text = "";
            txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            txtReservationNo.Text = "";
            ImgBtnSave.Enabled = true;
            TDIssueNo.Attributes.Add("style", "display:none");
            TDtxtIssueNo.Attributes.Add("style", "display:none");
            gvPostIssueReserHeader.HeaderRow.Cells[0].Visible = true;
            for (int i = 0; i < gvPostIssueReserHeader.Rows.Count; i++)
            {
                gvPostIssueReserHeader.Rows[i].Cells[0].Visible = true;
            }
        }
        catch { }
    }

    private void ClearGrid()
    {
        try
        {           
            gvPostIssueReserLow.DataSource = "";
            gvPostIssueReserLow.DataBind();           
        }
        catch { }
    }

    #endregion

    #region Fill Form Data

    private void BindAllIssueReservationList()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_PostIssueReservation.BindAllIssueReservationList();
            if (dt.Rows.Count > 0)
            {
                gvPostIssueReserHeader.DataSource = dt;
                gvPostIssueReserHeader.AllowPaging = true;
                gvPostIssueReserHeader.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvPostIssueReserHeader.AllowPaging = false;
                gvPostIssueReserHeader.DataSource = "";
                gvPostIssueReserHeader.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    protected void GetProc_IssueReservation_LineItems_Trans(int AutoId, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_PostIssueReservation.GetProc_IssueReservation_LineItems_Trans(AutoId, SearchType);
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvPostIssueReserLow.DataSource = dt;
                gvPostIssueReserLow.DataBind();
                ImgBtnSave.Enabled = true;
            }
            else
            {
                gvPostIssueReserLow.DataSource = "";
                gvPostIssueReserLow.DataBind();
                ImgBtnSave.Enabled = false;
                lblInfo.Text = objcommonmessage.AllPostings;
                ViewState["SelectedRecords"] = null;
            }
        }
        catch (Exception ex) { }
    }

    protected void GetProc_IssueReservation_Header_Trans(int AutoId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_PostIssueReservation.Get_Proc_IssueReservation_Header_Trans(AutoId);

            ImageButton ImageButton1 = (ImageButton)gvPostIssueReserHeader.Rows[0].Cells[0].FindControl("ImageButton1");
            if (dt.Rows.Count > 0)
            {
                gvPostIssueReserHeader.DataSource = dt;
                gvPostIssueReserHeader.AllowPaging = true;
                gvPostIssueReserHeader.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
                if (HidIsForm.Value == "true")
                {                   
                    gvPostIssueReserHeader.HeaderRow.Cells[0].Visible = true;
                    gvPostIssueReserHeader.Rows[0].Cells[0].Visible = true;
                }
                else
                {
                    gvPostIssueReserHeader.HeaderRow.Cells[0].Visible = false;
                    gvPostIssueReserHeader.Rows[0].Cells[0].Visible = false;
                }
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvPostIssueReserHeader.AllowPaging = false;
                gvPostIssueReserHeader.DataSource = "";
                gvPostIssueReserHeader.DataBind();
            }          
        }
        catch (Exception ex) { }
    }

    private void BindAllPostIssueReservationList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_PostIssueReservation.BindAllPostIssueReservationList(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvPostIssueReservationList.DataSource = dt;
                gvPostIssueReservationList.AllowPaging = true;
                gvPostIssueReservationList.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvPostIssueReservationList.AllowPaging = false;
                gvPostIssueReservationList.DataSource = "";
                gvPostIssueReservationList.DataBind();
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

            CheckBox chkAll = (CheckBox)gvPostIssueReserLow.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvPostIssueReserLow.Rows.Count; i++) 
            {                
                
                if (chkAll.Checked)
                {                    
                    dt = AddRow(gvPostIssueReserLow.Rows[i], dt);                   
                    CheckBox chk = (CheckBox)gvPostIssueReserLow.Rows[i].Cells[0].FindControl("chk");
                }
                else
                {
                    CheckBox chk = (CheckBox)gvPostIssueReserLow.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        dt = AddRow(gvPostIssueReserLow.Rows[i], dt);
                    }
                    else
                    {
                        dt = RemoveRow(gvPostIssueReserLow.Rows[i], dt);
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
            dt.Rows[gvRow.RowIndex]["ActiveStatus"] = true;
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
                dt.Rows[gvRow.RowIndex]["ActiveStatus"] = false;               
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