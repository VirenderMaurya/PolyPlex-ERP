using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_MaterialIssueforSales : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    Common com = new Common();
    BLLCollection<Proc_ScarpReceived> objBLLScarpObj = new BLLCollection<Proc_ScarpReceived>();
    Proc_ScarpReceived objProcSCarp = new Proc_ScarpReceived();

    Common_mst objCommon_mst = new Common_mst();

    SalesMaterialIssue objSalesMaterial = new SalesMaterialIssue();

    BLLCollection<Proc_SalesOrderInventory> objBLLObj = new BLLCollection<Proc_SalesOrderInventory>();

    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();

    Proc_SalesOrderInventory objProc = new Proc_SalesOrderInventory();

    SalesMaterialIssue objProcMaterial = new SalesMaterialIssue();
    Common_Message commessage = new Common_Message();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
            Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lbl_PageHeader.Text = "Material Issue for Sales";
            DataTable dt = com.fillSearch("117");
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
            gvSalesMaterial.AllowPaging = false;
            gvSalesMaterial.Visible = true;
            gvSalesMaterial.DataSource = "";
            gvSalesMaterial.DataBind();
            BindSOTypeMaster();
            BindMaterialCode();

            BindPlant();
            BindValuetary();
            BindStorageLocation();
            txtDate.Attributes.Add("readonly", "true");
            txtYear.Attributes.Add("readonly", "true");
            txtIssue.Attributes.Add("readonly", "true");
            txtUOM.Attributes.Add("readonly", "true");

            txtDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
            txtYear.Text = DateTime.Now.Year.ToString() + "-" + (Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) + 1).ToString();
            ImgBtnSave.Enabled = false;
            ImgBtnAddLine.Visible = true;
            string strSeriesLastNamber = "";
            decimal LastNumber = GetLastOrderNumber() + 1;
            strSeriesLastNamber = LastNumber.ToString();
            if (strSeriesLastNamber == "0")
            {
                strSeriesLastNamber = "00001";
            }
            strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
            txtIssue.Text = strSeriesLastNamber;
        }
        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;
    }


    protected void BindPlant()
    {
        try
        {


            objBLLScarpObj = objProcSCarp.Get_Plant();
            ddlPlant.DataSource = objBLLScarpObj;
            ddlPlant.DataTextField = "PlantCode";
            ddlPlant.DataValueField = "autoid";
            ddlPlant.DataBind();
            ddlPlant.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form-Binding Plant-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void BindValuetary()
    {
        try
        {
            objBLLScarpObj = objProcSCarp.Get_Valuatory();
            ddlValuationType.DataSource = objBLLScarpObj;
            ddlValuationType.DataTextField = "Valuetype";
            ddlValuationType.DataValueField = "autoId";
            ddlValuationType.DataBind();
            ddlValuationType.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form-Binding Valuation type-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void BindStorageLocation()
    {
        try
        {
            objBLLScarpObj = objProcSCarp.Get_StorageLocation();
            ddlstorageLocation.DataSource = objBLLScarpObj;
            ddlstorageLocation.DataTextField = "StorageLocCode";
            ddlstorageLocation.DataValueField = "autoid";
            ddlstorageLocation.DataBind();
            ddlstorageLocation.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form-Binding Material Code-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        try
        {

            if (ddsearch.SelectedValue == "")
            {
                string message = "Please select any search criteria.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            }
            else
            {
                if (ddsearch.SelectedItem.Value == "SalesOrder")
                {
                    string id = txtSearch.Text;
                    if (id == "")
                    {
                        id = "0";
                    }
                    DataTable dt = com.GetVal("@SalesOrder", id, "Sp_Get_All_Proc_MaterialIssueforSales_Header_By_SalesOrder");
                    if (dt.Rows.Count > 0)
                    {
                        gridMaster.Visible = true;
                        // Gdvlookup.Visible = false;
                        gridMaster.DataSource = dt;
                        gridMaster.DataBind();
                        ModalPopupExtender1.Show();
                    }
                    //get datatable
                    //colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
                }
        

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Procurement/MaterialIssueforSales.aspx");
    }

    private string CustomPad(int iNoOfCharToPad, char sPadChar, string sString)
    {
        string sPadStr = "";

        if (sString.Length < iNoOfCharToPad)
        {
            for (int i = 0; i < iNoOfCharToPad - sString.Length; i++)
            {
                sPadStr += sPadChar;
            }
            sPadStr += sString;
        }
        else
        {
            sPadStr = sString;
        }

        return sPadStr;
    }


    protected void BindSOTypeMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_AllPIType();
            ddlsalesType.DataTextField = "PerfInvTypeName";
            ddlsalesType.DataValueField = "PerfInvTypeID";
            ddlsalesType.DataSource = colRCommontype;
            ddlsalesType.DataBind();
            ddlsalesType.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex) { }
    }

    protected void BindMaterialCode()
    {
        try
        {
            objBLLScarpObj = objProcSCarp.Get_MaterialCode();
            ddlMaterialCode.DataSource = objBLLScarpObj;
            ddlMaterialCode.DataTextField = "Code";
            ddlMaterialCode.DataValueField = "autoid";
            ddlMaterialCode.DataBind();
            ddlMaterialCode.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Inventory Sales Order Form-Binding Material Code-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected decimal GetLastOrderNumber()
    {
        decimal TopValueOrderNumber = objProcMaterial.GetLastIssueNumber();
        if (TopValueOrderNumber == 0)
        {
            TopValueOrderNumber = 0;
        }

        return TopValueOrderNumber;


    }

    protected void gvSalesOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["Details"];
            gvSalesMaterial.PageIndex = e.NewPageIndex;
            gvSalesMaterial.DataSource = dt;
            gvSalesMaterial.DataBind();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void gvSalesOrder_RowCommand(object sender, GridViewCommandEventArgs e)
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
                DataTable dt = (DataTable)ViewState["Details"];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    if (Convert.ToInt32(dt.Rows[i]["Line"]) == lineno)
                    {
                        dt.Rows[i].Delete();
                    }
                    i++;
                }
                if (dt.Rows.Count == 0)
                {
                    gvSalesMaterial.DataSource = null;
                    gvSalesMaterial.DataBind();
                }
                else
                {
                    ViewState["Details"] = dt;
                    gvSalesMaterial.DataSource = dt;
                    gvSalesMaterial.DataBind();
                }
            }
            #endregion


            if (e.CommandName == "Select")
            {
                GridView gvRawMaterial = (GridView)sender;
                GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                gvRawMaterial.SelectedIndex = row1.RowIndex;


                foreach (GridViewRow oldrow in gvRawMaterial.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgSelect");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("imgSelect");
                img.ImageUrl = "~/Images/chkbxcheck.png";
                int Autoid = Convert.ToInt32(e.CommandArgument.ToString());


                DataTable dt = com.GetVal("@Autoid", Autoid.ToString(), "Sp_Get_Proc_MaterialIssueforSales_Details_byAutoID");
               if (dt.Rows.Count > 0)
               {
                   ViewState["AUtoid"] = Autoid;
                   txtSOLine.Text = dt.Rows[0]["SOLine"].ToString();
                   ddlMaterialCode.SelectedValue = dt.Rows[0]["MaterialCodeid"].ToString();
                   ddlPlant.SelectedValue = dt.Rows[0]["Plantid"].ToString();
                   ddlValuationType.SelectedValue = dt.Rows[0]["Valuationtypeid"].ToString();
                   ddlstorageLocation.SelectedValue = dt.Rows[0]["storageLocationid"].ToString();
                   txtBatch.Text = dt.Rows[0]["Batch"].ToString();
                   txtStock.Text = dt.Rows[0]["stock"].ToString();
                   txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                   txtUOM.Text = dt.Rows[0]["UOM"].ToString();
                   txtValue.Text = dt.Rows[0]["MaterialValue"].ToString();
               }
            
            }

        }
        catch (Exception ex)
        {
            logmessage = "Material Issue for Sales Form- gvSalesOrder_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvSalesOrder_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        if (HidPopUpType.Value == "SalesOrder")
        {
            FillAllSalesOrder(txtSearchFromPopup.Text.Trim());
        }

        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
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

                if (HidPopUpType.Value == "SalesOrder")
                {
                    hidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtSaleOrder.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    txtSalesorderCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                    txtSalesOrderDesc.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;

                }

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
            e.Row.Cells[1].Style.Add("display", "none");
        }
        catch (Exception ex)
        {
        }
    }




    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = gridMaster.SelectedDataKey.Value.ToString();
        ViewState["AUtoid"] = id;
        //string id = ((Label)row.FindControl("lblRawMaterial")).Text;
        //  ViewState["MachineDataid"] = id;
        DataTable dt = com.GetVal("@SaleOrder", id, "Sp_Get_Proc_MaterialIssueforSales_Details_byOrderID");
        if (dt.Rows.Count > 0)
        {
            
             ddlsalesType.SelectedValue = dt.Rows[0]["SaleType"].ToString();
             txtYear.Text = dt.Rows[0]["YEAR"].ToString();
            txtIssue.Text = dt.Rows[0]["IssueID"].ToString();
            txtDate.Text = dt.Rows[0]["Date"].ToString();
            txtTruck.Text = dt.Rows[0]["Truck"].ToString();
            txtSaleOrder.Text = dt.Rows[0]["SaleOrder"].ToString();
            hidCustomerId.Value = dt.Rows[0]["SOCustomerID"].ToString();
            txtSalesorderCode.Text = dt.Rows[0]["SOCustomerCode"].ToString();
            txtSalesOrderDesc.Text = dt.Rows[0]["SOCustomerName"].ToString();

          

            ImgBtnSave.ImageUrl = "~/Images/btn_update.png";
            ImgBtnAddLine.Enabled = false;
            ImgBtnAddLine.Visible = false;
            ImgBtnSave.Enabled = true;
            gvSales.Visible = true;
            gvSales.DataSource = dt;
            gvSales.DataBind();
            gvSalesMaterial.Visible = false;

            if (gvSales.Rows.Count > 0)
            {
                // GridViewRow row in GdvMachineData.Rows
                foreach (GridViewRow row2 in gvSales.Rows)
                {
                
                    ImageButton imgSelect = (ImageButton)row2.FindControl("imgSelect");
                    imgSelect.Visible = true;
                }
            }
        }



    }

    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gridMaster.PageIndex = e.NewPageIndex;
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddsearch.SelectedItem.Value == "SalesOrder")
            {
                string id = txtSearch.Text;
                if (id == "")
                {
                    id = "0";
                }
                DataTable dt = com.GetVal("@SalesOrder", id, "Sp_Get_All_Proc_MaterialIssueforSales_Header_By_SalesOrder");
                if (dt.Rows.Count > 0)
                {
                    gridMaster.Visible = true;
                    // Gdvlookup.Visible = false;
                    gridMaster.DataSource = dt;
                    gridMaster.DataBind();
                    ModalPopupExtender1.Show();
                }
                //get datatable
                //colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        string id = txtSearchList.Text;

        if (id == "")
        {
            id = "0";
        }
        DataTable dt = com.GetVal("@OrderNo", id, "Sp_Get_Proc_InventorySalesOrder_Header_byOrderID");
        if (dt.Rows.Count > 0)
        {
            gridMaster.Visible = true;
            // Gdvlookup.Visible = false;
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
    }

    protected void imgSalesOrder_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "SalesOrder";
        lPopUpHeader.Text = "Sales Order";
        lSearch.Text = "Search By SalesOrder: ";
        FillAllSalesOrder("");
        ModalPopupExtender2.Show();
    }


    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "SalesOrder")
        {
            FillAllSalesOrder(txtSearchFromPopup.Text.Trim());
        }


        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }


    private void FillAllSalesOrder(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSalesMaterial.FillAllSalesOrder(Searchtext);

            if (dt.Rows.Count > 0)
            {
                lblTotalRecordsPopUp.Text = commessage.TotalRecord + dt.Rows.Count.ToString();

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
                lblTotalRecordsPopUp.Text = commessage.NoRecordFound;
                gvPopUpGrid.AllowPaging = false;
                gvPopUpGrid.DataSource = "";
                gvPopUpGrid.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecordsPopUp.Text = commessage.NoRecordFound + ex.Message;
            gvPopUpGrid.AllowPaging = false;
            gvPopUpGrid.DataSource = "";
            gvPopUpGrid.DataBind();
        }
    }

    protected void ddlMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ddlMaterialCode.SelectedValue.ToString();
        DataTable dt = com.GetVal("@MaterialCode", id, "Sp_Set_Proc_ScarpReceived_by_MaterialCode");
        if (dt.Rows.Count > 0)
        {
            txtUOM.Text = dt.Rows[0]["StockUnit"].ToString();
        }
    }
    protected void ImgBtnAddLine_Click(object sender, ImageClickEventArgs e)
    {
        int Line = 0;
        if (ViewState["Line"] != null)
        {
            Line = Convert.ToInt32(ViewState["Line"]);
        }
        else
        {
            //  Line = Convert.ToInt32(GetLastLineNumber());
            //  if (Line == 0)
            //   {
            Line = 10;
            //   }

        }
        DataTable dt = null;
        if (ViewState["Details"] != null)
        {
            dt = (DataTable)ViewState["Details"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("Line", typeof(int));
            dt.Columns.Add("MaterialCode", typeof(string));
            dt.Columns.Add("MaterialCodeID", typeof(string));
            dt.Columns.Add("ValuationType", typeof(string));
            dt.Columns.Add("ValuationTypeID", typeof(string));
            dt.Columns.Add("Plant", typeof(string));
            dt.Columns.Add("PlantID", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("StorageLocation", typeof(string));
            dt.Columns.Add("StorageLocationID", typeof(string));
            dt.Columns.Add("Stock", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("MaterialValue", typeof(string));
            dt.Columns.Add("SOLine", typeof(string));
            dt.Columns.Add("Batch", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("StatusBit", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            dt.Columns.Add("CreatedOn", typeof(string));
            dt.Columns.Add("LastModifiedBy", typeof(string));
            dt.Columns.Add("LastModifiedOn", typeof(string));

        }
        DataRow drow = dt.NewRow();
        if (ViewState["Details"] != null)
        {
            drow["Line"] = 10 + Line;
        }
        else
        {
            drow["Line"] = 10; //+ Line;
        }
        drow["MaterialCode"] = ddlMaterialCode.SelectedItem.Text;
        drow["MaterialCodeID"] = ddlMaterialCode.SelectedValue;
        drow["ValuationType"] = ddlValuationType.SelectedItem.Text;
        drow["ValuationTypeID"] = ddlValuationType.SelectedValue;

        drow["Plant"] = ddlPlant.SelectedItem.Text;
        drow["PlantID"] = ddlPlant.SelectedValue;
        drow["Quantity"] = txtQuantity.Text;

        drow["StorageLocation"] = ddlstorageLocation.SelectedItem.Text;

        drow["StorageLocationID"] = ddlstorageLocation.SelectedValue;
        drow["Status"] = "True";
        drow["StatusBit"] = "1";

        string userid = "0";
        if (Session["userid"] != null)
        {
            userid = Session["userid"].ToString();

        }
        drow["CreatedBy"] = userid;
        drow["CreatedOn"] = txtDate.Text.Trim();
        drow["LastModifiedBy"] = "0";
        drow["LastModifiedOn"] = "";
        drow["Stock"] = txtStock.Text;
        drow["UOM"] = txtUOM.Text;
        drow["MaterialValue"] = txtValue.Text;
        drow["SOLine"] = txtSOLine.Text;
        drow["Batch"] = txtBatch.Text;


        
        dt.Rows.Add(drow);
        ViewState["Details"] = dt;
        ViewState["Line"] = drow["Line"];
        gvSalesMaterial.Visible = true;
        gvSalesMaterial.DataSource = dt;
        gvSalesMaterial.DataBind();
        gvSalesMaterial.AllowPaging = true;
        txtSOLine.Text = "";
        BindMaterialCode();
        BindPlant();
        BindValuetary();
        BindStorageLocation();
        txtBatch.Text = "";
        txtStock.Text = "";
        txtQuantity.Text = "";
        txtUOM.Text = "";
        txtValue.Text = "";
        //ClearLineItems();
        ImgBtnSave.Enabled = true;
    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (ImgBtnSave.ImageUrl == "~/Images/btn_update.png")
        {
            if (ddlMaterialCode.SelectedValue == "0")
            {

                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please select atleast one  checkbox from grid", 125, 300);
                return;
            }


            if (ddlPlant.SelectedValue == "0")
            {

                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please select atleast one  checkbox from grid", 125, 300);
                return;
            }

            if (ddlValuationType.SelectedValue == "0")
            {

                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please select atleast one  checkbox from grid", 125, 300);
                return;
            }
            int Autoid = 0; ;
            if (ViewState["AUtoid"] != null)
            {
                Autoid = Convert.ToInt32(ViewState["AUtoid"].ToString());
            }
            string userid = "0";
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();

            }


            int updatedheader = objProcMaterial.UpdateMaterialSalesOrder(Autoid,Convert.ToInt32(txtIssue.Text), Convert.ToInt32(ddlsalesType.SelectedValue), txtYear.Text, txtDate.Text, Convert.ToInt32(txtTruck.Text), txtSaleOrder.Text, Convert.ToInt32(hidCustomerId.Value),txtSalesorderCode.Text,txtSalesOrderDesc.Text, 0, Convert.ToInt32(txtSOLine.Text), Convert.ToInt32(ddlMaterialCode.SelectedValue), Convert.ToInt32(ddlPlant.SelectedValue), Convert.ToInt32(ddlValuationType.SelectedValue), Convert.ToInt32(ddlstorageLocation.SelectedValue),Convert.ToInt32(txtBatch.Text), Convert.ToInt32(txtStock.Text), Convert.ToDecimal(txtQuantity.Text), txtUOM.Text,Convert.ToInt32(txtValue.Text), Convert.ToInt32(userid));
            if (updatedheader > 0)
            {

                ClearLineItems();
                ImgBtnSave.ImageUrl = "~/Images/btnSave.png";
                ImgBtnSave.Enabled = false;
                gvSales.Visible = false;
                gvSalesMaterial.Visible = true;
                gvSalesMaterial.AllowPaging = false;
                gvSalesMaterial.DataSource = "";
                gvSalesMaterial.DataBind();
                string strSeriesLastNamber = "";
                decimal LastNumber = GetLastOrderNumber() + 1;
                strSeriesLastNamber = LastNumber.ToString();
                if (strSeriesLastNamber == "0")
                {
                    strSeriesLastNamber = "00001";
                }
                strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
                txtIssue.Text = strSeriesLastNamber;

                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);

            }


        }

        else
        {
            if (ViewState["Details"] != null)
            {
                bool booInsert = false;
                DataTable dt = (DataTable)ViewState["Details"];
                if (dt.Rows.Count > 0)
                {
                    int iOrderNumber = 0;

                    iOrderNumber = Convert.ToInt32(txtIssue.Text);
                    string userid = "0";
                    if (Session["userid"] != null)
                    {
                        userid = Session["userid"].ToString();

                    }


                    string IssueID = objProcMaterial.Insert_In_MaterialIssue_Sales_Order_Header(Convert.ToInt32(ddlsalesType.SelectedValue), txtYear.Text, txtDate.Text, Convert.ToInt32(txtTruck.Text), txtSaleOrder.Text, Convert.ToInt32(hidCustomerId.Value), txtSalesorderCode.Text, txtSalesOrderDesc.Text, Convert.ToInt32(userid));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        if (Session["userid"] != null)
                        {
                            userid = Session["userid"].ToString();

                        }
                        //saveRecordsinMaterialIssueforSales(int IssueID, string Line, string SOLine, int MaterialCodeID, int PlantID, int ValuationTypeID, int StorageLocationID, string Batch, string Stock, string Quantity, string UOM, int value, int Createdby)
                        booInsert = objProcMaterial.saveRecordsinMaterialIssueforSales(Convert.ToInt32(IssueID), dt.Rows[i]["Line"].ToString(), dt.Rows[i]["SOLine"].ToString(), Convert.ToInt32(dt.Rows[i]["MaterialCodeID"].ToString()), Convert.ToInt32(dt.Rows[i]["PlantID"].ToString()), Convert.ToInt32(dt.Rows[i]["ValuationTypeID"].ToString()), Convert.ToInt32(dt.Rows[i]["StorageLocationID"].ToString()), dt.Rows[i]["Batch"].ToString(), dt.Rows[i]["Stock"].ToString(), dt.Rows[i]["Quantity"].ToString(), dt.Rows[i]["UOM"].ToString(), Convert.ToInt32(dt.Rows[i]["MaterialValue"].ToString()), Convert.ToInt32(dt.Rows[i]["CreatedBy"].ToString()));

                    }

                    if (booInsert == true)
                    {
                        ClearLineItems();
                        string strSeriesLastNamber = "";
                        decimal LastNumber = GetLastOrderNumber() + 1;
                        strSeriesLastNamber = LastNumber.ToString();
                        if (strSeriesLastNamber == "0")
                        {
                            strSeriesLastNamber = "00001";
                        }
                        strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
                        txtIssue.Text = strSeriesLastNamber;
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                    }
                }

            }
        }

        ViewState["Details"] = null;
    }



    protected void ClearLineItems()
    {
        gvSalesMaterial.AllowPaging = false;
        gvSalesMaterial.DataSource = "";
        gvSalesMaterial.DataBind();
        BindSOTypeMaster();
        BindMaterialCode();

        BindPlant();
        BindValuetary();
        BindStorageLocation();
        txtDate.Attributes.Add("readonly", "true");
        txtYear.Attributes.Add("readonly", "true");
        txtIssue.Attributes.Add("readonly", "true");
        txtUOM.Attributes.Add("readonly", "true");

        txtDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
        txtYear.Text = DateTime.Now.Year.ToString() + "-" + (Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) + 1).ToString();
        ImgBtnSave.Enabled = false;
        ImgBtnAddLine.Visible = true;

        txtTruck.Text = "";
        txtSaleOrder.Text = "";
        txtSalesorderCode.Text = "";
        txtSalesOrderDesc.Text = "";
        txtSOLine.Text = "";
        txtBatch.Text = "";
        txtStock.Text = "";
        txtQuantity.Text = "";
        txtUOM.Text = "";
        txtValue.Text = "";
    }

    protected void ImgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Procurement/MaterialIssueforSales.aspx");
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             