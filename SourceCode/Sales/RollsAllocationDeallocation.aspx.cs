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
    RollAllocationDeallocation objRoll = new RollAllocationDeallocation();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();      
    int FlagInsert;
    string str, SearchValueofList, FlagInsertUpdate;
    static string MasterPageType;
    double totalWeight;
    int totalItems = 0;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "ROLLS Issue to Invoice";

            txtIssueDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            FillFinancialYear(); 

            #region Bind Masters

            BindSearchList();

            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Change Color of Readonly Fields

            txtYear.Attributes.Add("style", "background:lightgray");
            txtInvoiceNo.Attributes.Add("style", "background:lightgray");
            txtIssueDate.Attributes.Add("style", "background:lightgray");
            txtOrderNo.Attributes.Add("style", "background:lightgray");
            txtInvoiceType.Attributes.Add("style", "background:lightgray");
            txtCustomerCode.Attributes.Add("style", "background:lightgray");
            txtCustomerName.Attributes.Add("style", "background:lightgray");
            txtNetWeight.Attributes.Add("style", "background:lightgray");
            txtLBS.Attributes.Add("style", "background:lightgray");

            #endregion

            lRollsAvailable.Text = "Rolls Available in the Order:";
            lRollsIssued.Text = "Rolls Issued:";
           
            txtYear.Attributes.Add("readonly", "true");
            txtIssueDate.Attributes.Add("readonly", "true");            
            txtCustomerCode.Attributes.Add("readonly", "true");
            txtCustomerName.Attributes.Add("readonly", "true");
            txtNetWeight.Attributes.Add("readonly", "true");
            txtLBS.Attributes.Add("readonly", "true");
            txtOrderNo.Attributes.Add("readonly", "true");
            txtInvoiceType.Attributes.Add("readonly", "true");
            txtInvoiceNo.Attributes.Add("readonly", "true");
            ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
            ImgBtnSave.Enabled = false;

            #region Blank Grid

            gvRollAvialable.DataSource = "";
            gvRollAvialable.DataBind();
            gvRollIssused.DataSource = "";
            gvRollIssused.DataBind();

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
        ClearForm();
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        ddlSearch.SelectedValue = "0";
        txtSearch.Text = "";
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchValueofList = "";
        MasterPageType = "Master";

        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            if (txtSearch.Text.Trim() != "")
            {
                txtSearchFromPopup.Text = "";
                SearchValueofList = txtSearch.Text.Trim();
            }
            else if (txtSearchFromPopup.Text.Trim() != "")
            {
                txtSearch.Text = "";
                SearchValueofList = txtSearchFromPopup.Text.Trim();
            }
            lPopUpHeader.Text = ddlSearch.SelectedItem.ToString();
            lSearch.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            gvPopUpGrid.DataSource = "";
            gvPopUpGrid.AllowPaging = false;
            gvPopUpGrid.DataBind();
            
            BindRollAllocationDeallocationForPopup(ddlSearch.SelectedValue.ToString(), SearchValueofList);
            txtSearch.Focus();
            ModalPopupExtender2.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        string DDLValue = "";
        gvPopUpGrid.DataSource = null;
        gvPopUpGrid.AllowPaging = false;
        gvPopUpGrid.DataBind();

        if (MasterPageType == "Master")
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            DDLValue = ddlSearch.SelectedValue.ToString();
            BindRollAllocationDeallocationForPopup(DDLValue, txtSearchFromPopup.Text.Trim());
        }
        else if (MasterPageType == "Page")
        {
            if (HidPopUpType.Value == "InvoiceNo")
            {
                BindRollAllocationDeallocationForPopup("InvoiceNo", txtSearchFromPopup.Text.Trim());
            }
            else if (HidPopUpType.Value == "OrderNo")
            {
                BindRollAllocationDeallocationForPopup("OrderNo", txtSearchFromPopup.Text.Trim());
            }
        }        
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void chkAll_CheckChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvRollAvialable.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvRollAvialable.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvRollAvialable.Rows[i].Cells[0].FindControl("chk");
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
        BindRollIssuedGrid();
    }

    protected void chk_CheckChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvRollAvialable.HeaderRow.Cells[0].FindControl("chkAll");
        if (chkAll.Checked == true)
        {
            chkAll.Checked = false;
        }
        HidIsChecked.Value = "Yes";
        GetData();
        BindRollIssuedGrid();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //GetData();
            //gvRollAvialable.PageIndex = e.NewPageIndex;
            //BindRollGrid(Convert.ToInt32(HidSalesOrderId.Value));
        }
        catch { }

    }

    protected void gvRollIssused_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                if (e.Row.RowType != DataControlRowType.EmptyDataRow)
                {
                    e.Row.Cells[8].Style.Add("display", "none");
                    e.Row.Cells[9].Style.Add("display", "none");
                    e.Row.Cells[10].Style.Add("display", "none");
                    e.Row.Cells[11].Style.Add("display", "none");
                    e.Row.Cells[12].Style.Add("display", "none");
                }
            }
            catch { }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblWeight = (Label)e.Row.FindControl("lblWeight");
                double Weight = double.Parse(lblWeight.Text);
                totalWeight += Weight;
                totalItems += 1;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalWeight = (Label)e.Row.FindControl("lblTotalWeight");
                lblTotalWeight.Text = totalWeight.ToString();
                txtNetWeight.Text = totalWeight.ToString();
                double lbs = totalWeight * 2.20462262;
                txtLBS.Text = lbs.ToString();
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {                
                txtNetWeight.Text = "";               
                txtLBS.Text = "";
            }
        }
        catch { }
    }

    protected void gvRollAvialable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
            }
        }
        catch { }
    }    

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            for (int i = 0; i < gvPopUpGrid.Columns.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("Id", "R" + e.Row.RowIndex.ToString() + "C" + i.ToString());
            }

            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
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

                HidInvoiceId.Value = Convert.ToString(e.CommandArgument);
                txtInvoiceNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                txtInvoiceType.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                HidSalesOrderId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                txtOrderNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                HidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                txtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;
                txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                HidConsigneeId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[8].Text;
              
                ImgBtnSave.Enabled = true;
                ImgBtnSave.ImageUrl = "../Images/btnSave.png";

                #region For Role Allocation
                if (ddlAllocateDeallocate.SelectedValue == "1")
                {
                    BindRollAvailableGrid(Convert.ToInt32(HidSalesOrderId.Value));
                }
                #endregion

                #region For Role Deallocation
                else if (ddlAllocateDeallocate.SelectedValue == "0")
                {
                    BindRollIssuedInRoleAvailableGrid(Convert.ToInt32(HidSalesOrderId.Value));
                }
                #endregion
            }
        }
        catch { }
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchValueofList = "";
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        if (MasterPageType == "Master")
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");

            if (ddlSearch.SelectedValue != "0")
            {
                if (txtSearch.Text.Trim() != "")
                {
                    txtSearchFromPopup.Text = "";
                    SearchValueofList = txtSearch.Text.Trim();
                }
                else if (txtSearchFromPopup.Text.Trim() != "")
                {
                    txtSearch.Text = "";
                    SearchValueofList = txtSearchFromPopup.Text.Trim();
                }
            }
            lSearch.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            BindRollAllocationDeallocationForPopup(ddlSearch.SelectedValue.ToString(), SearchValueofList);
            txtSearch.Focus();
        }
        else if (MasterPageType == "Page")
        {
            if (HidPopUpType.Value == "InvoiceNo")
            {
                lPopUpHeader.Text = "Invoice";
                lSearch.Text = "Search By Invoice No: ";
                BindRollAllocationDeallocationForPopup("InvoiceNo", txtSearchFromPopup.Text.Trim());
            }
            else if (HidPopUpType.Value == "OrderNo")
            {
                lPopUpHeader.Text = "Order";
                lSearch.Text = "Search By Sales Order: ";
                BindRollAllocationDeallocationForPopup("OrderNo", txtSearchFromPopup.Text.Trim());
            }
        }
        ModalPopupExtender2.Show();
    }    

    protected void imgInvoiceNo_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        MasterPageType = "Page";
        HidPopUpType.Value = "InvoiceNo";
        lPopUpHeader.Text = "Invoice";
        lSearch.Text = "Search By Invoice No: ";
        BindRollAllocationDeallocationForPopup("InvoiceNo", "");        
        ModalPopupExtender2.Show();
    }

    protected void imgOrderNo_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        MasterPageType = "Page";
        HidPopUpType.Value = "OrderNo";
        lPopUpHeader.Text = "Order";
        lSearch.Text = "Search By Sales Order: ";
        BindRollAllocationDeallocationForPopup("OrderNo", "");        
        ModalPopupExtender2.Show();
    }    

    protected void ddlAllocateDeallocate_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblInfo.Text = "";
        if (ddlAllocateDeallocate.SelectedValue == "0")
        {
            lRollsAvailable.Text = "Rolls Issued:";
            lRollsIssued.Text = "Rolls Available in the Order:";
        }
        else
        {
            lRollsAvailable.Text = "Rolls Available in the Order:";
            lRollsIssued.Text = "Rolls Issued:";
        }
        FillFinancialYear();
        HidInvoiceId.Value = "";
        txtInvoiceNo.Text = "";
        txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);       
        HidSalesOrderId.Value = "";
        txtOrderNo.Text = "";
        txtInvoiceType.Text = "";
        HidCustomerId.Value = "";
        txtCustomerCode.Text = "";
        txtCustomerName.Text = "";
        HidConsigneeId.Value = "";
        txtNetWeight.Text = "";
        txtLBS.Text = "";

        ImgBtnSave.Enabled = false;
        ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png"; 
        gvRollAvialable.DataSource = "";
        gvRollAvialable.DataBind();
        gvRollIssused.DataSource = "";
        gvRollIssused.DataBind();
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            if (dt.Rows.Count > 0)
            {
                objRoll.dtLineItems = new DataTable();
                objRoll.dtLineItems = objRoll.Get_RollAllocateDeallocateGridStructure();
                DataRow objdrDetailsLineItems;

                objRoll.Year = txtYear.Text.Trim();
                if (txtIssueDate.Text.Trim() != "")
                {
                    objRoll.IssueDate = DateTime.ParseExact(txtIssueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objRoll.IssueDate = "";
                }
                objRoll.SalesOrderId = Convert.ToInt32(HidSalesOrderId.Value);
                objRoll.Invoiceid = Convert.ToInt32(HidInvoiceId.Value);
                objRoll.CustomerId = Convert.ToInt32(HidCustomerId.Value);
                objRoll.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objRoll.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString()); 


                if (HidIsChecked.Value == "Yes")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["IsExistInRAD"].ToString() == "")
                        {
                            objdrDetailsLineItems = objRoll.dtLineItems.NewRow();
                            objdrDetailsLineItems["AllocateDeallocateId"] = 0;                           
                            objdrDetailsLineItems["InventoryId"] = Convert.ToInt32(dr["InventoryId"]);                            
                            objdrDetailsLineItems["RollNo"] = Convert.ToInt32(dr["RollNo"]);
                            objdrDetailsLineItems["SubFilmTypeId"] = Convert.ToInt32(dr["SubFilmTypeId"]);
                            objdrDetailsLineItems["Micron"] = Convert.ToString(dr["Micron"]);
                            objdrDetailsLineItems["Width"] = Convert.ToInt32(dr["Width"]);
                            objdrDetailsLineItems["Length"] = Convert.ToDouble(dr["Length"]);
                            objdrDetailsLineItems["Core"] = Convert.ToString(dr["Core"]);
                            objdrDetailsLineItems["Weight"] = Convert.ToDouble(dr["Weight"]);
                            if (dr["IS_Pac"].ToString() != "" && dr["IS_Pac"].ToString() != "&nbsp")
                            {
                                objdrDetailsLineItems["IS_Pac"] = Convert.ToBoolean(dr["IS_Pac"]);
                            }
                            else
                            {
                                objdrDetailsLineItems["IS_Pac"] = Convert.ToBoolean(0);
                            }
                            if (dr["Is_Date"].ToString() != "" && dr["Is_Date"].ToString() != "&nbsp")
                            {
                                objdrDetailsLineItems["Is_Date"] = Convert.ToBoolean(dr["Is_Date"]);
                            }
                            else
                            {
                                objdrDetailsLineItems["Is_Date"] = Convert.ToBoolean(0);
                            }
                            if (ddlAllocateDeallocate.SelectedValue == "1")
                            {
                                objdrDetailsLineItems["Is_Allocate"] = Convert.ToBoolean(1);
                            }
                            else
                            {
                                objdrDetailsLineItems["Is_Allocate"] = Convert.ToBoolean(0);
                            }
                            if (dr["ftype"].ToString() != "&nbsp" && dr["ftype"].ToString() != "")
                            {
                                objdrDetailsLineItems["ftype"] = Convert.ToString(dr["ftype"]);
                            }
                            else
                            {
                                objdrDetailsLineItems["ftype"] = "";
                            }
                            objdrDetailsLineItems["IsPackingCreation"] = Convert.ToBoolean(0);                            
                            objdrDetailsLineItems["ActiveStatus"] = Convert.ToBoolean(1);
                            if (ddlAllocateDeallocate.SelectedValue == "1")
                            {
                                DataTable dtCheckPreviousValue = new DataTable();
                                dtCheckPreviousValue = objRoll.Get_RollAvailableExistingValueByInventoryId(Convert.ToInt32(dr["InventoryId"]), Convert.ToInt32(objRoll.SalesOrderId));
                                if (dtCheckPreviousValue.Rows.Count > 0)
                                {
                                    objdrDetailsLineItems["IsValueExistInRAD"] = Convert.ToBoolean(1);
                                }
                                else
                                {
                                    objdrDetailsLineItems["IsValueExistInRAD"] = Convert.ToBoolean(0);
                                }
                            }
                            else
                            {
                                objdrDetailsLineItems["IsValueExistInRAD"] = Convert.ToBoolean(1);
                            }
                            objRoll.dtLineItems.Rows.Add(objdrDetailsLineItems);
                            objRoll.dtLineItems.AcceptChanges();
                        }                                              
                    }                     

                    if (ddlAllocateDeallocate.SelectedValue == "1")
                    {
                        objRoll.AllocationType = "Allocate"; 
                    }
                    else if (ddlAllocateDeallocate.SelectedValue == "0")
                    {
                        objRoll.AllocationType = "Deallocate"; 
                    }
                    FlagInsertUpdate = objRoll.InsertUpdate_In_Sal_Glb_RollAllocationDeallocation_Tran();
                    if (FlagInsertUpdate == "0")
                    {
                        ClearForm();
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
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
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectLineFromLeftGrid, 125, 300);
                    return;
                }
            }            
        }
        catch
        {
            ClearForm();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
        }
    }    

    #endregion

    #region***************************************Functions***************************************

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
        catch (Exception ex) { }
    }

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdRollAllocation = ConfigurationManager.AppSettings["FormIdRollAllocation"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdRollAllocation);

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

    #region For Role Allocation

    public void BindRollAvailableGrid(int SalesOrderId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRoll.Get_RollAvailableGridBySalesOrderId(SalesOrderId, Convert.ToInt32(ddlAllocateDeallocate.SelectedValue.ToString()));           

            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;               
                gvRollAvialable.DataSource = dt;
                gvRollAvialable.DataBind();
                GetRollIssuedGrid(SalesOrderId);
            }
            else
            {
                gvRollAvialable.DataSource = "";
                gvRollAvialable.DataBind();
                GetRollIssuedGrid(Convert.ToInt32(HidSalesOrderId.Value));
                ImgBtnSave.Enabled = false;
                ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";

                if (ddlAllocateDeallocate.SelectedValue == "1")
                {
                    lblInfo.Text = objcommonmessage.RoleAllocated;
                }
                else
                {
                    lblInfo.Text = objcommonmessage.RoleDeallocated;
                }
                ViewState["SelectedRecords"] = null;
                ViewState["SelectedRecords"] = null;                
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    public void GetRollIssuedGrid(int SalesOrderId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRoll.Get_RollIssuedGridBySalesOrderId(Convert.ToInt32(HidSalesOrderId.Value), Convert.ToInt32(ddlAllocateDeallocate.SelectedValue.ToString()));           
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvRollIssused.DataSource = dt;
                gvRollIssused.DataBind();
            }
            else
            {
                BindRollIssuedGridStructure();
            }
        }
        catch { }
    }

    public void BindRollIssuedGrid()
    {
        try
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            if (dt.Rows.Count > 0)
            {
                gvRollIssused.DataSource = dt;
                gvRollIssused.DataBind();
            }
            else
            {
                BindRollIssuedGridStructure();
            }            
        }
        catch { }
    }

    #endregion

    #region For Role Deallocation

    public void BindRollIssuedInRoleAvailableGrid(int SalesOrderId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRoll.Get_RollAvailableGridBySalesOrderId(SalesOrderId, Convert.ToInt32(ddlAllocateDeallocate.SelectedValue.ToString()));

            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;                
                gvRollAvialable.DataSource = dt;
                gvRollAvialable.DataBind();
                GetRollIssuedGrid(SalesOrderId);
            }
            else
            {
                gvRollAvialable.DataSource = "";
                gvRollAvialable.DataBind();                
                GetRollIssuedGrid(Convert.ToInt32(HidSalesOrderId.Value));
                ImgBtnSave.Enabled = false;
                ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";

                if (ddlAllocateDeallocate.SelectedValue == "1")
                {
                    lblInfo.Text = objcommonmessage.RoleAllocated;
                }
                else
                {
                    lblInfo.Text = objcommonmessage.RoleDeallocated;
                }
                ViewState["SelectedRecords"] = null;
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    #endregion

    #region Grid Structure    

    public void BindRollIssuedGridStructure()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRoll.Get_RollIssuedGridBySalesOrderId(0, Convert.ToInt32(ddlAllocateDeallocate.SelectedValue.ToString()));
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvRollIssused.DataSource = dt;
                gvRollIssused.DataBind();
            }
            else
            {
                gvRollIssused.DataSource = "";
                gvRollIssused.DataBind();
            }
        }
        catch { }
    }

    #endregion

    private void GetData()
    {
        DataTable dt;
        dt = (DataTable)ViewState["SelectedRecords"];
        CheckBox chkAll = (CheckBox)gvRollAvialable.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvRollAvialable.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvRollAvialable.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvRollAvialable.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvRollAvialable.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvRollAvialable.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("InventoryId = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["InventoryId"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["RollNo"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["SubFilmTypeName"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["Weight"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Micron"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["WidthInMMName"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Length"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["Core"] = gvRow.Cells[8].Text;
            if (gvRow.Cells[9].Text == "&nbsp;")
            {
                dt.Rows[dt.Rows.Count - 1]["IS_Pac"] = 0;
            }
            else
            {
                dt.Rows[dt.Rows.Count - 1]["IS_Pac"] = gvRow.Cells[9].Text;
            }
            if (gvRow.Cells[10].Text == "&nbsp;")
            {
                dt.Rows[dt.Rows.Count - 1]["Is_Date"] = 0;
            }
            else
            {
                dt.Rows[dt.Rows.Count - 1]["Is_Date"] = gvRow.Cells[10].Text;
            }
            
            dt.Rows[dt.Rows.Count - 1]["ftype"] = gvRow.Cells[11].Text;
            dt.Rows[dt.Rows.Count - 1]["SubFilmTypeId"] = gvRow.Cells[12].Text;
            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[13].Text; 
            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("InventoryId = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
    }    

    public void ClearForm()
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        ddlSearch.SelectedValue = "0";
        FillFinancialYear();
        HidInvoiceId.Value = "";
        txtInvoiceNo.Text = "";
        txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        ddlAllocateDeallocate.SelectedValue = "1";
        HidSalesOrderId.Value = "";
        txtOrderNo.Text = "";
        txtInvoiceType.Text = "";
        HidCustomerId.Value = "";
        txtCustomerCode.Text = "";
        txtCustomerName.Text = "";
        HidConsigneeId.Value = "";
        txtNetWeight.Text = "";
        txtLBS.Text = "";

        ImgBtnSave.Enabled = false;
        ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
        gvRollAvialable.DataSource = "";
        gvRollAvialable.DataBind();
        gvRollIssused.DataSource = "";
        gvRollIssused.DataBind();
    }        

    private void BindRollAllocationDeallocationForPopup(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRoll.Get_InvoiceAllRecordForRoleAllocationDeallocation(ddlSearchValue, txtSearchValue);

            if (dt.Rows.Count > 0)
            {
                lblTotalRecordsPopUp.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
                gvPopUpGrid.AllowPaging = true;
                gvPopUpGrid.DataSource = dt;
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
            
        }
    }    

    #endregion 
    
}