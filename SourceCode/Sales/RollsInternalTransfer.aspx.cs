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
    RollsInternalTransfer objRollsInternalTransfer = new RollsInternalTransfer();    
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();      
    int FlagInsert;
    string str, SearchValueofList;
    static string MasterPageType;
    double totalWeight;
    int totalItems = 0;
    double Width, Length;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Rolls Internal Transfer";

            txtIssueDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            FillFinancialYear();
            int PalletNo = RandomNumber(100000000, 999999999);
            txtTransferNo.Text = Convert.ToString(PalletNo);

            #region Bind Masters

            BindSearchList();

            #endregion

            #region Bind Blank Grid
            
            GetRollAvailableGridStructure();
            BindRollIssuedGridStructure();

            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Change Color of Readonly Fields

            txtYear.Attributes.Add("style", "background:lightgray");
            txtTransferFrom.Attributes.Add("style", "background:lightgray");
            txtIssueDate.Attributes.Add("style", "background:lightgray");
            txtTransferTo.Attributes.Add("style", "background:lightgray");
            txtTransferNo.Attributes.Add("style", "background:lightgray");            
            txtNetWeight.Attributes.Add("style", "background:lightgray");
            txtLBS.Attributes.Add("style", "background:lightgray");

            #endregion            

            
            txtYear.Attributes.Add("readonly", "true");
            txtIssueDate.Attributes.Add("readonly", "true");
            txtTransferFrom.Attributes.Add("readonly", "true");
            txtTransferTo.Attributes.Add("readonly", "true");
            txtNetWeight.Attributes.Add("readonly", "true");
            txtLBS.Attributes.Add("readonly", "true");
            txtTransferNo.Attributes.Add("readonly", "true");            
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
        
        if (ddlSearch.SelectedValue != "0")
        {
            //BindperformInvoiceData(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            //lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            //ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void imgTransferFrom_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "TransferFrom";
        lPopUpHeader.Text = "Plant Master";
        lSearch.Text = "Search By Plant: ";
        FillAllPlantMaster("");
        ModalPopupExtender2.Show();
    }

    protected void imgTransferTo_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "TransferTo";
        lPopUpHeader.Text = "Plant Master";
        lSearch.Text = "Search By Plant: ";
        FillAllPlantMaster("");
        ModalPopupExtender2.Show();
    }

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {           
            e.Row.Cells[1].Style.Add("display", "none");
        }
        catch (Exception ex)
        { }
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

                if (HidPopUpType.Value == "TransferFrom")
                {
                    HidTransferFrom.Value = Convert.ToString(e.CommandArgument);
                    txtTransferFrom.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                }
                else if (HidPopUpType.Value == "TransferTo")
                {
                    HidTransferTo.Value = Convert.ToString(e.CommandArgument);
                    txtTransferTo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                }          
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
            }
        }
        catch (Exception ex)
        { }
    }

    protected void gvRollIssused_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[0].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
            }

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
        }
        catch { }
    }

    protected void imgbtnSearchInForm_Click(object sender, ImageClickEventArgs e)
    {
        try
        {     
            if (HidTransferFrom.Value != HidTransferTo.Value)
            {
                ImgBtnSave.Enabled = true;
                ImgBtnSave.ImageUrl = "../Images/btnSave.png";
                lblInfo.Text = "";
                BindRollAvailableGrid(Convert.ToInt32(HidTransferFrom.Value));
            }
            else
            {
                ImgBtnSave.Enabled = false;
                ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.CheckTransfer, 125, 300);
                return;                
            }
        }
        catch { }
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

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            if (dt.Rows.Count > 0)
            {
                if (HidIsChecked.Value == "Yes")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            objRollsInternalTransfer.Year = txtYear.Text.Trim();
                            objRollsInternalTransfer.IssueDate = txtIssueDate.Text.Trim();
                            objRollsInternalTransfer.TransferNo = txtTransferNo.Text.Trim();
                            objRollsInternalTransfer.TransferFromPlantId = Convert.ToInt32(HidTransferFrom.Value);
                            objRollsInternalTransfer.TransferToPlantId = Convert.ToInt32(HidTransferTo.Value);
                            objRollsInternalTransfer.InventoryId = Convert.ToInt32(dr["InventoryId"]);
                            objRollsInternalTransfer.RollNo = Convert.ToInt32(dr["RollNo"]);
                            objRollsInternalTransfer.SubFilmTypeId = Convert.ToInt32(dr["SubFilmTypeId"]);
                            objRollsInternalTransfer.Micron = Convert.ToString(dr["Micron"]);
                            objRollsInternalTransfer.Width = Convert.ToInt32(dr["Width"]);
                            objRollsInternalTransfer.Length = Convert.ToDouble(dr["Length"]);
                            objRollsInternalTransfer.Core = Convert.ToString(dr["Core"]);
                            objRollsInternalTransfer.Weight = Convert.ToDouble(dr["Weight"]);
                            objRollsInternalTransfer.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                            objRollsInternalTransfer.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                            objRollsInternalTransfer.ActiveStatus = Convert.ToBoolean(1);

                            if (dr["IsExistInRIT"].ToString() == "")
                            {
                                FlagInsert = objRollsInternalTransfer.InsertRollIssued();
                            }
                        }
                        catch
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                            return;
                        }
                    }
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
            string FormIdRollsInternalTransfer = ConfigurationManager.AppSettings["FormIdRollsInternalTransfer"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdRollsInternalTransfer);

            ddlSearch.DataTextField = "Options";
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();                
            }
            ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch { }
    }

    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    private void FillAllPlantMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllPlantMaster(Searchtext);

            if (dt.Rows.Count > 0)
            {
                lblTotalRecordsPopUp.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();

                gvPopUpGrid.AutoGenerateColumns = true;
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
        catch (Exception ex)
        {
            lblTotalRecordsPopUp.Text = objcommonmessage.NoRecordFound + ex.Message;
            gvPopUpGrid.AllowPaging = false;
            gvPopUpGrid.DataSource = "";
            gvPopUpGrid.DataBind();
        }
    }

    #region Bind Rolls Available and Issued Grid

    public void BindRollAvailableGrid(int TransferFromPlantId)
    {
        try
        {
            DataTable dt = new DataTable();            
            dt = objRollsInternalTransfer.Get_RollAvailableGridBySearchText(TransferFromPlantId, TxtType.Text.Trim(), txtMicron.Text.Trim(), txtCore.Text.Trim(),
                txtWidth.Text.Trim(), txtLength.Text.Trim());

            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;
                gvRollAvialable.DataSource = dt;
                gvRollAvialable.DataBind();
                GetRollIssuedGrid(Convert.ToInt32(HidTransferFrom.Value), Convert.ToInt32(HidTransferTo.Value));
            }
            else
            {
                GetRollAvailableGridStructure();
                ViewState["SelectedRecords"] = null;
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void GetRollIssuedGrid(int TransferFromPlantId, int TransferToPlantId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRollsInternalTransfer.Get_RollIssuedGridByTransferToPlantId(TransferFromPlantId, TransferToPlantId);
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

    public void BindRollIssuedGridStructure()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRollsInternalTransfer.Get_RollIssuedGridByTransferToPlantId(0,0);
            ViewState["SelectedRecords"] = dt;
            gvRollIssused.DataSource = dt;
            gvRollIssused.DataBind();            
        }
        catch { }
    }

    public void GetRollAvailableGridStructure()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRollsInternalTransfer.Get_RollAvailableGridBySearchText(0,"","","","","");
            if (dt.Rows.Count == 0)
            {
                gvRollAvialable.DataSource = dt;
                gvRollAvialable.DataBind();

                GetRollIssuedGrid(Convert.ToInt32(HidTransferFrom.Value), Convert.ToInt32(HidTransferTo.Value));
                ImgBtnSave.Enabled = false;
                ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
                lblInfo.Text = objcommonmessage.RollsTransfered;               
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
            dt.Rows[dt.Rows.Count - 1]["SubFilmTypeId"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["Micron"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Core"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[10].Text;
            dt.Rows[dt.Rows.Count - 1]["Length"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["Weight"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["SubFilmTypeName"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["WidthInMMName"] = gvRow.Cells[6].Text;
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

    #endregion

    public void ClearForm()
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        ddlSearch.SelectedValue = "0";
        FillFinancialYear();
        int PalletNo = RandomNumber(100000000, 999999999);
        txtTransferNo.Text = Convert.ToString(PalletNo);

        HidTransferFrom.Value = "";
        HidTransferTo.Value = "";
        txtTransferFrom.Text = "";
        txtTransferTo.Text = "";
        TxtType.Text = "";
        txtMicron.Text = "";
        txtCore.Text = "";
        txtWidth.Text = "";
        txtLength.Text = "";
        txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        HidSearch.Value = "";
        HidPopUpType.Value = "";
        HidType.Value = "";        
        txtNetWeight.Text = "";
        txtLBS.Text = "";
        ImgBtnSave.Enabled = false;
        ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
        gvRollAvialable.DataSource = "";
        gvRollAvialable.DataBind();
        gvRollIssused.DataSource = "";
        gvRollIssused.DataBind();
    }

    #endregion







    
}