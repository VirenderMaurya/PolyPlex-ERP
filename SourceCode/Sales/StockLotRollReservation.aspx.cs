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
    SAL_StockLotReservation objSAL_StockLotReservation = new SAL_StockLotReservation();    
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();      
    int FlagInsert;
    string SearchValueofList;
    static string MasterPageType;   

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Stock Lot Roll Reservation";  

            #region Bind Masters

            BindSearchList();

            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Change Color of Readonly Fields
            
            txtOrderNo.Attributes.Add("style", "background:lightgray");
            txtDate.Attributes.Add("style", "background:lightgray");
            txtDeliveryTo.Attributes.Add("style", "background:lightgray");   
            txtCustomerCode.Attributes.Add("style", "background:lightgray");
            txtCustomerName.Attributes.Add("style", "background:lightgray");
            txtConsignee.Attributes.Add("style", "background:lightgray");
            txtRollsRequired.Attributes.Add("style", "background:lightgray");
            txtRollsUploaded.Attributes.Add("style", "background:lightgray");
            txtRollsUploadQtyInKg.Attributes.Add("style", "background:lightgray");
            txtRollsInStock.Attributes.Add("style", "background:lightgray");
            txtRollsStockQtyInKg.Attributes.Add("style", "background:lightgray");
            txtRollsAlloted.Attributes.Add("style", "background:lightgray");
            txtRollsAllotedQtyInKg.Attributes.Add("style", "background:lightgray");

            #endregion

            lRollsAvailable.Text = "Rolls Available:";
            lRollsIssued.Text = "Rolls Issued:";

            txtOrderNo.Attributes.Add("readonly", "true");
            txtDate.Attributes.Add("readonly", "true");
            txtDeliveryTo.Attributes.Add("readonly", "true");
            txtCustomerCode.Attributes.Add("readonly", "true");
            txtCustomerName.Attributes.Add("readonly", "true");
            txtConsignee.Attributes.Add("readonly", "true");
            txtRollsRequired.Attributes.Add("readonly", "true");
            txtRollsUploaded.Attributes.Add("readonly", "true");
            txtRollsUploadQtyInKg.Attributes.Add("readonly", "true");
            txtRollsInStock.Attributes.Add("readonly", "true");
            txtRollsStockQtyInKg.Attributes.Add("readonly", "true");
            txtRollsAlloted.Attributes.Add("readonly", "true");
            txtRollsAllotedQtyInKg.Attributes.Add("readonly", "true");
                       
            ImgBtnSave.Enabled = false;
            ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";

            #region Blank Grid

            gvSOLineItems.DataSource = "";
            gvSOLineItems.DataBind();
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

            Get_SalesOrderForStockLotreservation(ddlSearch.SelectedValue.ToString(), SearchValueofList);
            txtSearch.Focus();
            ModalPopupExtender2.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void btnSearchInPopUp_Click1(object sender, EventArgs e)
    {
        string DDLValue = "";
        gvPopUpGrid.DataSource = null;
        gvPopUpGrid.AllowPaging = false;
        gvPopUpGrid.DataBind();

        if (MasterPageType == "Master")
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            DDLValue = ddlSearch.SelectedValue.ToString();
            Get_SalesOrderForStockLotreservation(DDLValue, txtSearchFromPopup.Text.Trim());
        }
        else if (MasterPageType == "Page")
        {
            Get_SalesOrderForStockLotreservation("OrderNo", txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
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
            Get_SalesOrderForStockLotreservation(DDLValue, txtSearchFromPopup.Text.Trim());
        }
        else if (MasterPageType == "Page")
        {
            Get_SalesOrderForStockLotreservation("OrderNo", txtSearchFromPopup.Text.Trim());
        }        
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void imgOrderNo_Click(object sender, ImageClickEventArgs e)
    {
        MasterPageType = "Page";
        lPopUpHeader.Text = "Order";
        lSearch.Text = "Search By Sales Order: ";
        Get_SalesOrderForStockLotreservation("OrderNo", "");
        ModalPopupExtender2.Show();
    }

    protected void chkAll_CheckChanged(object sender, EventArgs e)
    {
        if (HidLineNo.Value != "")
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
        else
        {
            CheckBox chkAll = (CheckBox)gvRollAvialable.HeaderRow.Cells[0].FindControl("chkAll");
            chkAll.Checked = false;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectLineItem, 125, 300);
        }
    }

    protected void chk_CheckChanged(object sender, EventArgs e)
    {
        if (HidLineNo.Value != "")
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
        else
        {
            for (int i = 0; i < gvRollAvialable.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvRollAvialable.Rows[i].Cells[0].FindControl("chk");
                chk.Checked = false;
            }
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectLineItem, 125, 300);
        }
    }  

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[3].Style.Add("display", "none");
            e.Row.Cells[6].Style.Add("display", "none");
            e.Row.Cells[8].Style.Add("display", "none");            
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

                HidSalesOrderId.Value = Convert.ToString(e.CommandArgument);  
                txtOrderNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                txtDate.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                HidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                txtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                HidConsigneeId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;
                txtConsignee.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                HidDeliveryTo.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[8].Text;
                txtDeliveryTo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[9].Text;                
                ImgBtnSave.Enabled = true;
                ImgBtnSave.ImageUrl = "../Images/btnSave.png";

                BindSOLineItemGrid(Convert.ToInt32(HidSalesOrderId.Value));

                #region For Role Allocation

                BindRollAvailableGrid(Convert.ToInt32(HidSalesOrderId.Value));
                 
                #endregion
            }
        }
        catch { }
    }

    protected void gvSOLineItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvSOLineItems = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvSOLineItems.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvSOLineItems.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidLineNo.Value = gvSOLineItems.Rows[gvSOLineItems.SelectedIndex].Cells[1].Text;                
                ImgBtnSave.Enabled = true;
                ImgBtnSave.ImageUrl = "../Images/btnSave.png";

                #region For Role Issued Grid by Line No

                #region For Role Allocation

                BindRollAvailableGrid(Convert.ToInt32(HidSalesOrderId.Value));

                #endregion
                GetRollIssuedGrid(Convert.ToInt32(HidSalesOrderId.Value), Convert.ToInt32(HidLineNo.Value));              

                #endregion
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

    protected void gvRollIssused_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                if (e.Row.RowType != DataControlRowType.EmptyDataRow)
                {
                    e.Row.Cells[0].Style.Add("display", "none");
                    e.Row.Cells[8].Style.Add("display", "none");
                    e.Row.Cells[9].Style.Add("display", "none");
                    e.Row.Cells[10].Style.Add("display", "none");
                    e.Row.Cells[11].Style.Add("display", "none");
                }
            }
            catch { }

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lblWeight = (Label)e.Row.FindControl("lblWeight");
            //    double Weight = double.Parse(lblWeight.Text);
            //    totalWeight += Weight;
            //    totalItems += 1;
            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label lblTotalWeight = (Label)e.Row.FindControl("lblTotalWeight");
            //    lblTotalWeight.Text = totalWeight.ToString();
            //    txtNetWeight.Text = totalWeight.ToString();
            //    double lbs = totalWeight * 2.20462262;
            //    txtLBS.Text = lbs.ToString();
            //}
            //if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            //{
            //    txtNetWeight.Text = "";
            //    txtLBS.Text = "";
            //}
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
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            objSAL_StockLotReservation.InventoryId = Convert.ToInt32(dr["InventoryId"]);
                            objSAL_StockLotReservation.SalesOrderId = Convert.ToInt32(HidSalesOrderId.Value);
                            objSAL_StockLotReservation.LineNo = Convert.ToInt32(HidLineNo.Value);
                            objSAL_StockLotReservation.CustomerId = Convert.ToInt32(HidCustomerId.Value);
                            objSAL_StockLotReservation.RollNo = Convert.ToInt32(dr["RollNo"]);
                            objSAL_StockLotReservation.SubFilmTypeId = Convert.ToInt32(dr["SubFilmTypeId"]);
                            objSAL_StockLotReservation.Micron = Convert.ToString(dr["Micron"]);
                            objSAL_StockLotReservation.Width = Convert.ToDouble(dr["Width"]);
                            objSAL_StockLotReservation.Length = Convert.ToDouble(dr["Length"]);
                            objSAL_StockLotReservation.Core = Convert.ToString(dr["Core"]);
                            objSAL_StockLotReservation.Weight = Convert.ToDouble(dr["Weight"]);
                            if (dr["IS_Pac"].ToString() != "" && dr["IS_Pac"].ToString() != "&nbsp")
                            {
                                objSAL_StockLotReservation.IS_Pac = Convert.ToBoolean(dr["IS_Pac"]);
                            }
                            else
                            {
                                objSAL_StockLotReservation.IS_Pac = Convert.ToBoolean(0);
                            }
                            if (dr["Is_Date"].ToString() != "" && dr["Is_Date"].ToString() != "&nbsp")
                            {
                                objSAL_StockLotReservation.Is_Date = Convert.ToBoolean(dr["Is_Date"]);
                            }
                            else
                            {
                                objSAL_StockLotReservation.Is_Date = Convert.ToBoolean(0);
                            }

                            if (dr["ftype"].ToString() != "&nbsp" && dr["ftype"].ToString() != "")
                            {
                                objSAL_StockLotReservation.ftype = Convert.ToString(dr["ftype"]);
                            }
                            else
                            {
                                objSAL_StockLotReservation.ftype = "";
                            }
                            objSAL_StockLotReservation.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                            objSAL_StockLotReservation.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                            objSAL_StockLotReservation.ActiveStatus = Convert.ToBoolean(1);

                            if (dr["IsExistInRAD"].ToString() == "")
                            {
                                objSAL_StockLotReservation.IsValueExistInRAD = Convert.ToBoolean(0);
                                FlagInsert = objSAL_StockLotReservation.InsertRollIssuedForStockLotReservation();                        
                            }
                        }
                        catch
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                            return;
                        }
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectLineFromLeftGrid, 125, 300);
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

    #endregion

    #region***************************************Functions***************************************
       
    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdStockLotRollReservation = ConfigurationManager.AppSettings["FormIdStockLotRollReservation"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdStockLotRollReservation);

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
            dt = objSAL_StockLotReservation.Get_AllRollAvailableForStockLotReservation();           

            if (dt.Rows.Count > 0)
            {
                ViewState["SelectedRecords"] = dt;               
                gvRollAvialable.DataSource = dt;
                gvRollAvialable.DataBind();
                lblInfo.Text = "";
            }
            else
            { 
                gvRollAvialable.DataSource = "";
                gvRollAvialable.DataBind();
                ViewState["SelectedRecords"] = null;                
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    public void GetRollIssuedGrid(int SalesOrderId, int LineNo)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSAL_StockLotReservation.Get_RollIssuedBySOIdForStockLotRollReserv(Convert.ToInt32(HidSalesOrderId.Value), LineNo);           
            if (dt.Rows.Count > 0)
            {               
                gvRollIssused.DataSource = dt;
                gvRollIssused.DataBind();
                ViewState["SelectedRecords"] = null;
                gvRollAvialable.DataSource = "";
                gvRollAvialable.DataBind();
                ImgBtnSave.Enabled = false;
                ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
                
                lblInfo.Text = objcommonmessage.RoleAllocated;
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

    #region Grid Structure    

    public void BindRollIssuedGridStructure()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSAL_StockLotReservation.Get_RollIssuedBySOIdForStockLotRollReserv(0, 0);           
            gvRollIssused.DataSource = dt;
            gvRollIssused.DataBind();           
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
            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[6].Text;
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
        HidSalesOrderId.Value = "";
        txtOrderNo.Text = "";
        txtDate.Text = "";
        HidDeliveryTo.Value = "";
        txtDeliveryTo.Text = "";
        HidCustomerId.Value = "";
        txtCustomerCode.Text = "";
        txtCustomerName.Text = "";
        HidConsigneeId.Value = "";
        txtConsignee.Text = "";
        txtRollsRequired.Text = "";
        txtRollsUploaded.Text = "";
        txtRollsUploadQtyInKg.Text = "";
        txtRollsInStock.Text = "";
        txtRollsStockQtyInKg.Text = "";
        txtRollsAlloted.Text = "";
        txtRollsAllotedQtyInKg.Text = "";
        HidIsChecked.Value = "";

        ImgBtnSave.Enabled = false;
        ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
        gvSOLineItems.DataSource = "";
        gvSOLineItems.DataBind();
        gvRollAvialable.DataSource = "";
        gvRollAvialable.DataBind();
        gvRollIssused.DataSource = "";
        gvRollIssused.DataBind();
    }

    private void Get_SalesOrderForStockLotreservation(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSAL_StockLotReservation.Get_SalesOrderForStockLotreservation(ddlSearchValue, txtSearchValue);

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

    private void BindSOLineItemGrid(int SalesOrderId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSAL_StockLotReservation.Get_SODeatilsBySOId(SalesOrderId);
            if (dt.Rows.Count > 0)
            {
                gvSOLineItems.DataSource = dt;
                gvSOLineItems.DataBind();
            }
            else
            {
                gvSOLineItems.DataSource = "";
                gvSOLineItems.DataBind();
            }
        }
        catch { }
    }

    #endregion 
    
    
}