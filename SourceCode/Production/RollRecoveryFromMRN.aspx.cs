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
    Prod_RollRecoveryFromMRN objProd_RollRecoveryFromMRN = new Prod_RollRecoveryFromMRN();  
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();    
    string FlagInsert;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Roll Recovery From MRN";

            txtRecoverDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            FillFinancialYear();
            //int PalletNo = RandomNumber(100000000, 999999999);
            //txtMRNNo.Text = Convert.ToString(PalletNo);

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
            txtRecoverDate.Attributes.Add("style", "background:lightgray");
            txtInvoiceNo.Attributes.Add("style", "background:lightgray");
            txtOrderNo.Attributes.Add("style", "background:lightgray");            
            txtCustomerCode.Attributes.Add("style", "background:lightgray");
            txtCustomerName.Attributes.Add("style", "background:lightgray");           

            #endregion

            #region Blank Grid

            gvAllocateRolls.DataSource = "";
            gvAllocateRolls.DataBind();
            gvRollsRecovered.DataSource = "";
            gvRollsRecovered.DataBind();           

            #endregion
            
            txtYear.Attributes.Add("readonly", "true");
            txtMRNNo.Attributes.Add("readonly", "true");
            txtMRNDate.Attributes.Add("readonly", "true");
            txtRecoverDate.Attributes.Add("readonly", "true");
            txtCustomerCode.Attributes.Add("readonly", "true");
            txtCustomerName.Attributes.Add("readonly", "true");
            txtInvoiceNo.Attributes.Add("readonly", "true");
            txtOrderNo.Attributes.Add("readonly", "true");
            ImgBtnSave.Enabled = false;                       
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
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindRollsRecoveredList(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
        Get_AllMRNForRollsRecovery(txtSearchFromPopup.Text.Trim());        
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindRollsRecoveredList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
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

    protected void ImgBtnMRNNo_Click(object sender, ImageClickEventArgs e)
    {       
        Get_AllMRNForRollsRecovery("");
        lPopUpHeader.Text = "MRN No.";
        lSearch.Text = "Search By MRN No.: ";
        ModalPopupExtender2.Show();
    }

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
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
                HidMRNId.Value = Convert.ToString(e.CommandArgument);
                HidInvoiceId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                txtInvoiceNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;
                HidSalesOrderId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                txtOrderNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                HidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                txtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[8].Text;
                txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[9].Text;
                txtMRNDate.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                txtMRNNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;

                ImgBtnSave.Enabled = true;
                BindRollsAvailableInMRN(Convert.ToInt32(HidMRNId.Value));
            }
        }
        catch { }
    }

    protected void gvAllocateRolls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvRollsRecovered_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[0].Style.Add("display", "none");
                e.Row.Cells[2].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
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

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            if (dt.Rows.Count > 0)
            {
                if (HidIsChecked.Value == "Yes")
                {
                    objProd_RollRecoveryFromMRN.dtRollsRecoveryMRN = new DataTable();
                    objProd_RollRecoveryFromMRN.dtRollsRecoveryMRN = objProd_RollRecoveryFromMRN.Get_RollsRecoveredByMRNId(0);
                    DataRow objdrPILineItems;

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["RollRecoveryId"].ToString() == "" || dr["RollRecoveryId"].ToString() == "0")
                        {
                            try
                            {
                                objdrPILineItems = objProd_RollRecoveryFromMRN.dtRollsRecoveryMRN.NewRow();

                                objProd_RollRecoveryFromMRN.Year = txtYear.Text.Trim();
                                objProd_RollRecoveryFromMRN.MaterialReturnId = Convert.ToInt32(HidMRNId.Value);
                                objProd_RollRecoveryFromMRN.MRNDate = Convert.ToString(DateTime.ParseExact(txtRecoverDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture));
                                objProd_RollRecoveryFromMRN.RecoverDate = Convert.ToString(DateTime.ParseExact(txtMRNDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture));
                                objProd_RollRecoveryFromMRN.InvoiceId = Convert.ToInt32(HidInvoiceId.Value);
                                objProd_RollRecoveryFromMRN.SalesOrderId = Convert.ToInt32(HidSalesOrderId.Value);
                                objProd_RollRecoveryFromMRN.CustomerId = Convert.ToInt32(HidCustomerId.Value);
                                objProd_RollRecoveryFromMRN.InventoryId = Convert.ToInt32(dr["InventoryId"].ToString());
                                objdrPILineItems["RollNo"] = Convert.ToInt32(dr["RollNo"].ToString());
                                objdrPILineItems["SubFilmTypeId"] = Convert.ToInt32(dr["SubFilmTypeId"].ToString());
                                objdrPILineItems["Micron"] = dr["Micron"].ToString();
                                objdrPILineItems["Width"] = Convert.ToInt32(dr["Width"].ToString());
                                objdrPILineItems["Length"] = Convert.ToDouble(dr["Length"].ToString());
                                objdrPILineItems["Core"] = dr["Core"].ToString();
                                objdrPILineItems["Weight"] = Convert.ToDouble(dr["Weight"].ToString());
                                objProd_RollRecoveryFromMRN.IsActive = true;
                                objProd_RollRecoveryFromMRN.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());

                                objProd_RollRecoveryFromMRN.dtRollsRecoveryMRN.Rows.Add(objdrPILineItems);
                                objProd_RollRecoveryFromMRN.dtRollsRecoveryMRN.AcceptChanges();
                            }
                            catch
                            {
                                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                                return;
                            }
                        }
                    }
                    FlagInsert = objProd_RollRecoveryFromMRN.Insert_In_Prod_Glb_RollRecoveryFromMRN_Tran();
                    if (FlagInsert == "YES")
                    {
                        ClearForm();
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                    }
                    else if (FlagInsert == "NO")
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                        return;
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectLineFromLeftGrid, 125, 300);
                    return;
                }
            }
        }
        catch { }
    }

    protected void gvRollsRecoveredSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvRollsRecoveredSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvRollsRecoveredSearch = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvRollsRecoveredSearch.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvRollsRecoveredSearch.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidMRNId.Value = Convert.ToString(e.CommandArgument);
                HidInvoiceId.Value = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[4].Text;
                txtInvoiceNo.Text = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[7].Text;
                HidSalesOrderId.Value = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[5].Text;
                txtOrderNo.Text = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[8].Text;
                HidCustomerId.Value = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[6].Text;
                txtCustomerCode.Text = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[9].Text;
                txtCustomerName.Text = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[10].Text;
                txtMRNDate.Text = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[3].Text;
                txtMRNNo.Text = gvRollsRecoveredSearch.Rows[gvRollsRecoveredSearch.SelectedIndex].Cells[1].Text;

                ImgBtnSave.Enabled = true;
                BindRollsAvailableInMRN(Convert.ToInt32(HidMRNId.Value));
            }
        }
        catch { }
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        Get_AllMRNForRollsRecovery(txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void gvRollsRecoveredSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRollsRecoveredSearch.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindRollsRecoveredList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdProdRollRecoverMRN = ConfigurationManager.AppSettings["FormIdProdRollRecoverMRN"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProdRollRecoverMRN);

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

    //private int RandomNumber(int min, int max)
    //{
    //    Random random = new Random();
    //    return random.Next(min, max);
    //}

    #endregion

    #region Other Functions    

    #region Grid Structures    

    public void GetRollrecoveredGridStructure()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_RollRecoveryFromMRN.Get_RollsRecoveredByMRNId(0);
            if (dt.Rows.Count > 0)
            { 
                ViewState["SelectedRecords"] = dt;
                gvRollsRecovered.DataSource = dt;
                gvRollsRecovered.DataBind();
            }
            else
            {
                gvRollsRecovered.DataSource = "";
                gvRollsRecovered.DataBind();
            }
        }
        catch { }
    }

    #endregion    

    public void ClearForm()
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        ddlSearch.SelectedValue = "0";
        HidInvoiceId.Value = "";        
        txtInvoiceNo.Text = "";       
        txtOrderNo.Text = "";
        HidSalesOrderId.Value = "";
        HidCustomerId.Value = "";
        txtCustomerCode.Text = "";
        txtCustomerName.Text = "";
        HidMRNId.Value = "";
        txtMRNNo.Text = "";
        txtMRNDate.Text = "";
        txtRecoverDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

        FillFinancialYear();
        //int PalletNo = RandomNumber(100000000, 999999999);
        //txtMRNNo.Text = Convert.ToString(PalletNo);
        ImgBtnSave.Enabled = false;
        gvAllocateRolls.DataSource = "";
        gvAllocateRolls.DataBind();
        gvRollsRecovered.DataSource = "";
        gvRollsRecovered.DataBind();
    }

    private void Get_AllMRNForRollsRecovery(string SearchText)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_RollRecoveryFromMRN.Get_AllMRNForRollsRecovery(SearchText);
            if (dt.Rows.Count > 0)
            {
                gvPopUpGrid.DataSource = dt;
                gvPopUpGrid.AllowPaging = true;
                gvPopUpGrid.DataBind();
                lblTotalRecordsPopUp.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
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
            lblTotalRecordsPopUp.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    private void BindRollsAvailableInMRN(int MaterialReturnId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_RollRecoveryFromMRN.Get_RollsAvailableInMRN(MaterialReturnId);
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvAllocateRolls.DataSource = dt;
                gvAllocateRolls.DataBind();

                GetRollRecoveredGrid(MaterialReturnId);

                if (dt.Rows[0]["IsValueInMRN"].ToString() != "Exist")
                {
                    txtRecoverDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
                    FillFinancialYear();                    
                }
            }
            else
            {
                gvAllocateRolls.DataSource = "";
                gvAllocateRolls.DataBind();               
                GetRollRecoveredGrid(Convert.ToInt32(HidMRNId.Value));
                ImgBtnSave.Enabled = false;
                lblInfo.Text = objcommonmessage.RoleRecovered;
                ViewState["SelectedRecords"] = null;

            }
        }
        catch { }
    }

    public void GetRollRecoveredGrid(int MaterialReturnId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_RollRecoveryFromMRN.Get_RollsRecoveredByMRNId(MaterialReturnId);
            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvRollsRecovered.DataSource = dt;
                gvRollsRecovered.DataBind();
            }
            else
            {
                gvRollsRecovered.DataSource = "";
                gvRollsRecovered.DataBind();
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
                gvRollsRecovered.DataSource = dt;
                gvRollsRecovered.DataBind();
            }
            else
            {
                GetRollrecoveredGridStructure();
            }
        }
        catch { }
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        try
        {
            DataRow[] dr = dt.Select("MaterialReturnId = '" + gvRow.Cells[12].Text + "'");
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
                dt.Rows[dt.Rows.Count - 1]["RollRecoveryId"] = gvRow.Cells[15].Text;
                dt.AcceptChanges();
            }
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
            DataRow[] dr = dt.Select("MaterialReturnId = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }
            return dt;
        }
        catch
        {
            return dt = null;
        }
    }

    #region Fill All Recovered List Grid

    private void BindRollsRecoveredList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_RollRecoveryFromMRN.Get_RollsRecoveredList(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvRollsRecoveredSearch.DataSource = dt;
                gvRollsRecoveredSearch.AllowPaging = true;
                gvRollsRecoveredSearch.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvRollsRecoveredSearch.AllowPaging = false;
                gvRollsRecoveredSearch.DataSource = "";
                gvRollsRecoveredSearch.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    #endregion

    #endregion




    
}