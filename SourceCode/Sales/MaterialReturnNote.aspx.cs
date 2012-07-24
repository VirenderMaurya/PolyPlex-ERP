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
    MaterialReturnNote objMaterialReturnNote = new MaterialReturnNote();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();    
    int FlagInsert;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Material Return Note";

            txtMRNDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            FillFinancialYear();
            int PalletNo = RandomNumber(100000000, 999999999);
            txtMRNNo.Text = Convert.ToString(PalletNo);

            #region Bind Masters

            BindSearchList();

            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Change Color of Readonly Fields

            txtYear.Attributes.Add("style", "background:lightgray");           
            txtMRNNo.Attributes.Add("style", "background:lightgray");
            txtMRNDate.Attributes.Add("style", "background:lightgray");
            txtInvoiceNo.Attributes.Add("style", "background:lightgray");
            txtOrderNo.Attributes.Add("style", "background:lightgray");            
            txtCustomerCode.Attributes.Add("style", "background:lightgray");
            txtCustomerName.Attributes.Add("style", "background:lightgray");           

            #endregion

            #region Blank Grid

            gvAllocateRolls.DataSource = "";
            gvAllocateRolls.DataBind();
            gvRollsReturned.DataSource = "";
            gvRollsReturned.DataBind();           

            #endregion
            
            txtYear.Attributes.Add("readonly", "true");
            txtMRNNo.Attributes.Add("readonly", "true");
            txtMRNDate.Attributes.Add("readonly", "true");            
            txtCustomerCode.Attributes.Add("readonly", "true");
            txtCustomerName.Attributes.Add("readonly", "true");
            txtInvoiceNo.Attributes.Add("readonly", "true");
            txtOrderNo.Attributes.Add("readonly", "true");
            ImgBtnSave.Enabled = false;
            ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";      
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
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        ddlSearch.SelectedValue = "0";
        txtSearch.Text = "";
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        txtSearchList.Text = "";
        if (ddlSearch.SelectedValue != "0")
        {
            BindMaterialReturnNoteList(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString()+": ";
            ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "InvoiceId")
        {
            FillOrderNoAndInvoiveNoOfPackingCreation("InvoiceId", txtSearchFromPopup.Text.Trim());            
        }
        else if (HidPopUpType.Value == "SalesOrderId")
        {
            FillOrderNoAndInvoiveNoOfPackingCreation("SalesOrderId", txtSearchFromPopup.Text.Trim());             
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindMaterialReturnNoteList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());  
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvAllocateRolls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            for (int i = 0; i < gvAllocateRolls.Columns.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("Id", "R" + e.Row.RowIndex.ToString() + "C" + i.ToString());
            }

            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void chkAll_CheckChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvAllocateRolls.HeaderRow.Cells[0].FindControl("chkAll");        
        for (int i = 0; i < gvAllocateRolls.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvAllocateRolls.Rows[i].Cells[0].FindControl("chk");
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
        BindRollReturnedGrid();
    }

    protected void chk_CheckChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvAllocateRolls.HeaderRow.Cells[0].FindControl("chkAll");
        if (chkAll.Checked == true)
        {
            chkAll.Checked = false;
        }
        HidIsChecked.Value = "Yes";
        GetData();
        BindRollReturnedGrid();
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];            
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    objMaterialReturnNote.Year = txtYear.Text.Trim();
                    objMaterialReturnNote.MRNNo = txtMRNNo.Text.Trim();
                    objMaterialReturnNote.MRNDate = Convert.ToString(DateTime.ParseExact(txtMRNDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture));
                    objMaterialReturnNote.InvoiceId = Convert.ToInt32(HidInvoiceId.Value);
                    objMaterialReturnNote.SalesOrderId = Convert.ToInt32(HidSalesOrderId.Value);
                    objMaterialReturnNote.Customer = Convert.ToInt32(HidCustomer.Value);
                    objMaterialReturnNote.InventoryId = Convert.ToInt32(dr["InventoryId"].ToString());
                    objMaterialReturnNote.RollNo = Convert.ToInt32(dr["RollNo"].ToString());
                    objMaterialReturnNote.SubFilmTypeId = Convert.ToInt32(dr["SubFilmTypeId"].ToString());
                    objMaterialReturnNote.Micron = dr["Micron"].ToString();
                    objMaterialReturnNote.Width = Convert.ToInt32(dr["Width"].ToString());
                    objMaterialReturnNote.Length = Convert.ToDouble(dr["Length"].ToString());
                    objMaterialReturnNote.Core = dr["Core"].ToString();
                    objMaterialReturnNote.Weight = Convert.ToDouble(dr["Weight"].ToString());
                    objMaterialReturnNote.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                    objMaterialReturnNote.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                    if (dr["MaterialReturnId"].ToString() == "" || dr["MaterialReturnId"].ToString() == "0")
                    {                        
                        FlagInsert = objMaterialReturnNote.Insert_In_Sal_Glb_MaterialReturnNote_Tran();
                    }                                       
                }
                catch {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300); 
                    return;
                }
            }
            if (FlagInsert == -1)
            {
                ClearForm();
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
            }
        }
        catch { }

    }

    protected void gvRollsReturned_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            for (int i = 0; i < gvRollsReturned.Columns.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("Id", "R" + e.Row.RowIndex.ToString() + "C" + i.ToString());
            }
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[0].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
            }
        }
        catch { }
    }    

    protected void gvRollsReturnedSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                for (int i = 0; i < gvRollsReturnedSearch.Columns.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("Id", "R" + e.Row.RowIndex.ToString() + "C" + i.ToString());
                }
            }
            catch { }

            e.Row.Cells[1].Style.Add("display", "none");
            e.Row.Cells[3].Style.Add("display", "none");           
        }
        catch { }
    }   

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                for (int i = 0; i < gvPopUpGrid.Columns.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("Id", "R" + e.Row.RowIndex.ToString() + "C" + i.ToString());
                }
            }
            catch { }

            e.Row.Cells[5].Style.Add("display", "none");
            e.Row.Cells[6].Style.Add("display", "none");
            e.Row.Cells[7].Style.Add("display", "none");            
        }
        catch { }
    }

    protected void gvRollsReturnedSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvRollsReturnedSearch = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvRollsReturnedSearch.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvRollsReturnedSearch.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidInvoiceId.Value = Convert.ToString(e.CommandArgument);
                HidSalesOrderId.Value = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[1].Text;
                HidCustomer.Value = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[3].Text;

                txtYear.Text = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[8].Text;
                txtMRNNo.Text = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[6].Text;
                txtMRNDate.Text = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[7].Text;
                txtInvoiceNo.Text = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[9].Text;
                txtOrderNo.Text = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[2].Text;
                txtCustomerCode.Text = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[4].Text;
                txtCustomerName.Text = gvRollsReturnedSearch.Rows[gvRollsReturnedSearch.SelectedIndex].Cells[5].Text;
                                
                ImgBtnSave.Enabled = true;
                ImgBtnSave.ImageUrl = "../Images/btnSave.png";
                BindAllocateRollsGrid(HidInvoiceId.Value);
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

                HidInvoiceId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;
                txtInvoiceNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                HidSalesOrderId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                txtOrderNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                HidCustomer.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                txtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                                
                ImgBtnSave.Enabled = true;
                ImgBtnSave.ImageUrl = "../Images/btnSave.png";
                BindAllocateRollsGrid(HidInvoiceId.Value);
            }
        }
        catch { }
    }

    protected void gvRollsReturnedSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRollsReturnedSearch.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindMaterialReturnNoteList(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender1.Show();
        }
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        if (HidPopUpType.Value == "InvoiceId")
        {
            FillOrderNoAndInvoiveNoOfPackingCreation("InvoiceId", txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "SalesOrderId")
        {
            FillOrderNoAndInvoiveNoOfPackingCreation("SalesOrderId", txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void imgInvoiceNo_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "InvoiceId";
        FillOrderNoAndInvoiveNoOfPackingCreation("InvoiceId","");
        lPopUpHeader.Text = "Invoice";
        lSearch.Text = "Search By Invoice No: ";
        ModalPopupExtender2.Show();
    }

    protected void imgOrderNo_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "SalesOrderId";
        FillOrderNoAndInvoiveNoOfPackingCreation("SalesOrderId","");
        lPopUpHeader.Text = "Order";
        lSearch.Text = "Search By Order No: ";
        ModalPopupExtender2.Show();
    }    

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdMaterialReturnNote = ConfigurationManager.AppSettings["FormIdMaterialReturnNote"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdMaterialReturnNote);

            ddlSearch.DataTextField = "Options"; 
            ddlSearch.DataValueField = "Value"; 
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();
                ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));               
            }
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

    #endregion

    #region Other Functions

    private void BindAllocateRollsGrid(string InvoiceId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objMaterialReturnNote.Get_AllocatedRollsByInvoiceId(Convert.ToInt32(InvoiceId));
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvAllocateRolls.DataSource = dt;
                gvAllocateRolls.DataBind();

                GetRollReturnedGrid(HidInvoiceId.Value);

                if (dt.Rows[0]["IsValueInMRN"].ToString() != "Exist")
                {                    
                    txtMRNDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
                    FillFinancialYear();
                    int PalletNo = RandomNumber(100000000, 999999999);
                    txtMRNNo.Text = Convert.ToString(PalletNo);
                }                
            }
            else
            {                
                gvAllocateRolls.DataSource = "";
                gvAllocateRolls.DataBind();
                FillHeaderInformation(HidInvoiceId.Value);
                GetRollReturnedGrid(HidInvoiceId.Value);
                ImgBtnSave.Enabled = false;
                ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
                lblInfo.Text = objcommonmessage.CheckSavedRecordInMRN;
                ViewState["SelectedRecords"] = null;
                
            }
        }
        catch { }
    }

    #region Grid Structures    

    public void GetRollReturnedGridStructure()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objMaterialReturnNote.Get_ReturnedRollsByInvoiceId(0);
            if (dt.Rows.Count > 0)
            { 
                ViewState["SelectedRecords"] = dt;
                gvRollsReturned.DataSource = dt;
                gvRollsReturned.DataBind();
            }
            else
            {                
                gvRollsReturned.DataSource = "";
                gvRollsReturned.DataBind();
            }
        }
        catch { }
    }

    #endregion

    public void GetRollReturnedGrid(string InvoiceId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objMaterialReturnNote.Get_ReturnedRollsByInvoiceId(Convert.ToInt32(InvoiceId));
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvRollsReturned.DataSource = dt;
                gvRollsReturned.DataBind();
            }
            else
            {
                gvRollsReturned.DataSource = "";
                gvRollsReturned.DataBind();
            }
        }
        catch { }
    }

    public void FillHeaderInformation(string InvoiceId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objMaterialReturnNote.Get_MaterialReturnNoteHeaderInfByInvoiceId(Convert.ToInt32(InvoiceId));
            if (dt.Rows.Count > 0)
            {
                HidInvoiceId.Value = dt.Rows[0]["InvoiceId"].ToString();
                HidSalesOrderId.Value = dt.Rows[0]["SalesOrderId"].ToString();
                HidCustomer.Value = dt.Rows[0]["Customer"].ToString();

                txtYear.Text = dt.Rows[0]["YEAR"].ToString();
                txtMRNNo.Text = dt.Rows[0]["MRNNo"].ToString();
                txtMRNDate.Text = dt.Rows[0]["MRNDate"].ToString();
                txtInvoiceNo.Text = dt.Rows[0]["InvoiceNo"].ToString();
                txtOrderNo.Text = dt.Rows[0]["OrderNo"].ToString();
                txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();                
            }
        }
        catch { }
    }

    private void GetData()
    {
        try
        {
            DataTable dt;
            dt = (DataTable)ViewState["SelectedRecords"];

            CheckBox chkAll = (CheckBox)gvAllocateRolls.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvAllocateRolls.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    dt = AddRow(gvAllocateRolls.Rows[i], dt);
                    dt.Rows[i]["CreatedByName"] = Session["UserName"].ToString();
                    CheckBox chk = (CheckBox)gvAllocateRolls.Rows[i].Cells[0].FindControl("chk");                    
                }
                else
                {                   
                    CheckBox chk = (CheckBox)gvAllocateRolls.Rows[i].Cells[0].FindControl("chk");                   
                    if (chk.Checked)
                    {
                        dt = AddRow(gvAllocateRolls.Rows[i], dt);                        
                    }
                    else
                    {
                        dt = RemoveRow(gvAllocateRolls.Rows[i], dt);                       
                    }
                }
            }
            ViewState["SelectedRecords"] = dt;
        }
        catch { }
    }

    private void BindRollReturnedGrid()
    {
        try
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            if (dt.Rows.Count > 0)
            {
                gvRollsReturned.DataSource = dt;
                gvRollsReturned.DataBind();
            }
            else
            {
                GetRollReturnedGridStructure();
            }
        }
        catch { }

    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        try
        {
            DataRow[] dr = dt.Select("InventoryId = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["InventoryId"] = gvRow.Cells[1].Text;
                dt.Rows[dt.Rows.Count - 1]["RollNo"] = gvRow.Cells[2].Text;
                dt.Rows[dt.Rows.Count - 1]["SubFilmTypeName"] = gvRow.Cells[3].Text;
                dt.Rows[dt.Rows.Count - 1]["Micron"] = gvRow.Cells[4].Text;
                dt.Rows[dt.Rows.Count - 1]["WidthInMMName"] = gvRow.Cells[5].Text;
                dt.Rows[dt.Rows.Count - 1]["Length"] = gvRow.Cells[6].Text;
                dt.Rows[dt.Rows.Count - 1]["Core"] = gvRow.Cells[7].Text;
                dt.Rows[dt.Rows.Count - 1]["Weight"] = gvRow.Cells[8].Text;               
                if (gvRow.Cells[9].Text != "")
                {
                    dt.Rows[dt.Rows.Count - 1]["CreatedBy"] = Session["UserId"].ToString();
                }
                if (gvRow.Cells[10].Text != "" && gvRow.Cells[10].Text != "&nbsp;")
                {
                    dt.Rows[dt.Rows.Count - 1]["CreatedByName"] = gvRow.Cells[10].Text;
                }
                else
                {
                    dt.Rows[dt.Rows.Count - 1]["CreatedByName"] = Session["UserName"].ToString();
                }               
                dt.Rows[dt.Rows.Count - 1]["CreatedOn"] = DateTime.Now.ToString(objCommon_mst.DateFormat);
                dt.Rows[dt.Rows.Count - 1]["MaterialReturnId"] = gvRow.Cells[12].Text;
                dt.Rows[dt.Rows.Count - 1]["SubFilmTypeId"] = gvRow.Cells[13].Text;
                dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[14].Text;
                dt.AcceptChanges();
            }            
            return dt;
        }
        catch { 
            return dt=null;
        }

    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        try
        {
            DataRow[] dr = dt.Select("InventoryId = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }
            return dt;
        }
        catch {
            return dt = null;
        }
    }

    public void ClearForm()
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        ddlSearch.SelectedValue = "0";
        HidInvoiceId.Value = "";        
        txtInvoiceNo.Text = "";       
        txtOrderNo.Text = "";
        HidSalesOrderId.Value = "";
        HidCustomer.Value = "";
        txtCustomerCode.Text = "";
        txtCustomerName.Text = "";

        txtMRNDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        FillFinancialYear();
        int PalletNo = RandomNumber(100000000, 999999999);
        txtMRNNo.Text = Convert.ToString(PalletNo);
        ImgBtnSave.Enabled = false;
        ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
        gvAllocateRolls.DataSource = "";
        gvAllocateRolls.DataBind();
        gvRollsReturned.DataSource = "";
        gvRollsReturned.DataBind();
    }

    private void BindMaterialReturnNoteList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objMaterialReturnNote.Get_MaterialReturnNoteList(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvRollsReturnedSearch.DataSource = dt;
                gvRollsReturnedSearch.AllowPaging = true;
                gvRollsReturnedSearch.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvRollsReturnedSearch.AllowPaging = false;
                gvRollsReturnedSearch.DataSource = "";
                gvRollsReturnedSearch.DataBind();               
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    private void FillOrderNoAndInvoiveNoOfPackingCreation(string SearchType,string SearchText)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillOrderNoAndInvoiveNoOfPackingCreation(SearchType, SearchText);

            if (dt.Rows.Count > 0)
            {
                lblTotalRecordsPopUp.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
                if (gvPopUpGrid.Columns.Count < 2)
                {
                    BoundField BF1 = new BoundField();
                    BF1.HeaderText = "OrderNo";
                    BF1.DataField = "OrderNo".Trim();
                    BF1.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF1.ItemStyle.Width = Unit.Parse("200px");
                    BF1.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF1.HeaderStyle.Width = Unit.Parse("200px");

                    BoundField BF2 = new BoundField();
                    BF2.HeaderText = "InvoiceNo";
                    BF2.DataField = "InvoiceNo".Trim();
                    BF2.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF2.ItemStyle.Width = Unit.Parse("200px");
                    BF2.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF2.HeaderStyle.Width = Unit.Parse("200px");

                    BoundField BF3 = new BoundField();
                    BF3.HeaderText = "CustomerCode";
                    BF3.DataField = "CustomerCode".Trim();
                    BF3.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF3.ItemStyle.Width = Unit.Parse("200px");
                    BF3.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF3.HeaderStyle.Width = Unit.Parse("200px");

                    BoundField BF4 = new BoundField();
                    BF4.HeaderText = "CustomerName";
                    BF4.DataField = "CustomerName".Trim();
                    BF4.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF4.ItemStyle.Width = Unit.Parse("200px");
                    BF4.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF4.HeaderStyle.Width = Unit.Parse("200px");

                    BoundField BF5 = new BoundField();
                    BF5.HeaderText = "SalesOrderId";
                    BF5.DataField = "SalesOrderId".Trim();
                    BF5.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF5.ItemStyle.Width = Unit.Parse("200px");
                    BF5.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF5.HeaderStyle.Width = Unit.Parse("200px");

                    BoundField BF6 = new BoundField();
                    BF6.HeaderText = "InvoiceId";
                    BF6.DataField = "InvoiceId".Trim();
                    BF6.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF6.ItemStyle.Width = Unit.Parse("200px");
                    BF6.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF6.HeaderStyle.Width = Unit.Parse("200px");

                    BoundField BF7 = new BoundField();
                    BF7.HeaderText = "CustomerId";
                    BF7.DataField = "CustomerId".Trim();
                    BF7.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF7.ItemStyle.Width = Unit.Parse("200px");
                    BF7.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    BF7.HeaderStyle.Width = Unit.Parse("200px");

                    gvPopUpGrid.Columns.Add(BF1);
                    gvPopUpGrid.Columns.Add(BF2);
                    gvPopUpGrid.Columns.Add(BF3);
                    gvPopUpGrid.Columns.Add(BF4);
                    gvPopUpGrid.Columns.Add(BF5);
                    gvPopUpGrid.Columns.Add(BF6);
                    gvPopUpGrid.Columns.Add(BF7);

                }
                gvPopUpGrid.AutoGenerateColumns = false;
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
        catch {}
    }

    #endregion

    #endregion    
    
}