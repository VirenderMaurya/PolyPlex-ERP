using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_SalesOrderForInventory : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    Common com = new Common();
    BLLCollection<Proc_ScarpReceived> objBLLScarpObj = new BLLCollection<Proc_ScarpReceived>();
    Proc_ScarpReceived objProcSCarp = new Proc_ScarpReceived();

    Common_mst objCommon_mst = new Common_mst();

    BLLCollection<Proc_SalesOrderInventory> objBLLObj = new BLLCollection<Proc_SalesOrderInventory>();

    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();

    Proc_SalesOrderInventory objProc = new Proc_SalesOrderInventory();
    Common_Message commessage = new Common_Message();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
            Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lbl_PageHeader.Text = "Inventory Sales Order";
            DataTable dt = com.fillSearch("237");
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
            gvSalesOrder.Visible = true;
            gvSalesOrder.AllowPaging = false;
            gvSalesOrder.DataSource = "";
            gvSalesOrder.DataBind();
            BindSOTypeMaster();
            BindDeliveryToMaster();
            BindMaterialTypeMaster();
            BindCurrencyMaster();
            BindPaymodeMaster();
            BindFinalDestinationMaster();
            BindMaterialCode();
            txtDate.Attributes.Add("readonly", "true");
            txtYear.Attributes.Add("readonly", "true");
            txtcustomer.Attributes.Add("readonly", "true");
            txtConsignee.Attributes.Add("readonly", "true");
            txtUOM.Attributes.Add("readonly", "true");
            txtCustomerOrderdate.Attributes.Add("readonly", "true");
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
            txtOrder.Text = strSeriesLastNamber;
        }
        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;
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
                if (ddsearch.SelectedItem.Value == "OrderNo")
                {
                    string id = txtSearch.Text;
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
                    //get datatable
                    //colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
                }
                else if (ddsearch.SelectedItem.Value == "CustomerCode")
                {
                    string id = txtSearch.Text;
                    if (id == "")
                    {
                        id = "0";
                    }
                    DataTable dt = com.GetVal("@CustomerCode", id, "Sp_Get_Proc_InventorySalesOrder_Header_byCustomerCode");
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
        Response.Redirect("../Procurement/SalesOrderForInventory.aspx");
    }

    protected void gvSalesOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["Details"];
            gvSalesOrder.PageIndex = e.NewPageIndex;
            gvSalesOrder.DataSource = dt;
            gvSalesOrder.DataBind();
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
                    gvSalesOrder.DataSource = null;
                    gvSalesOrder.DataBind();
                }
                else
                {
                    ViewState["Details"] = dt;
                    gvSalesOrder.DataSource = dt;
                    gvSalesOrder.DataBind();
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


                DataTable dt = com.GetVal("@Autoid", Autoid.ToString(), "Sp_Get_Proc_InventorySalesOrder_Details_byAutoID");
                if (dt.Rows.Count > 0)
                {
                    ViewState["AUtoid"] = Autoid;
               
                    ddlMaterialCode.SelectedValue = dt.Rows[0]["MaterialCodeID"].ToString();

                    txtQUantity.Text = dt.Rows[0]["Quantity"].ToString();

                    txtUOM.Text = dt.Rows[0]["UOM"].ToString();

                    txtRate.Text = dt.Rows[0]["Rate"].ToString();
                }

            }


        }
        catch (Exception ex)
        {
            logmessage = "Sales Order for Inventory Form- gvSalesOrder_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvSalesOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {

        // if (BtnSave.Text == "Update")
        if (ImgBtnSave.ImageUrl == "~/Images/btn_update.png")
        {
            if (ddlMaterialCode.SelectedValue == "0")
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

         
            //     string OrderID = objProc.Insert_In_Inventory_Sales_Order_Header(Convert.ToInt32(ddlsalesType.SelectedValue), txtYear.Text,txtDate.Text,Convert.ToInt32(hidCustomerId.Value),Convert.ToInt32(hidConsigneeId.Value), Convert.ToInt32(ddlDeliveryto.SelectedValue), Convert.ToInt32(ddlMattype.SelectedValue), Convert.ToInt32(txtCustomerOrder.Text), txtCustomerOrderdate.Text, Convert.ToInt32(ddlcurrency.SelectedValue), Convert.ToInt32(txtVatRate.Text), Convert.ToInt32(ddlfinalDestination.SelectedValue), Convert.ToInt32(hidPaymenttermsId.Value), Convert.ToInt32(hidTermsOfDeliveryId.Value) ,Convert.ToInt32( ddlModeofPayment.SelectedValue), Convert.ToInt32(userid)); 

            int updatedheader = objProc.UpdateSalesOrder(Autoid, Convert.ToInt32(ddlsalesType.SelectedValue), txtYear.Text, txtDate.Text, Convert.ToInt32(hidCustomerId.Value), Convert.ToInt32(hidConsigneeId.Value), Convert.ToInt32(ddlDeliveryto.SelectedValue), Convert.ToInt32(ddlMattype.SelectedValue), Convert.ToInt32(txtCustomerOrder.Text), txtCustomerOrderdate.Text, Convert.ToInt32(ddlcurrency.SelectedValue), Convert.ToInt32(txtVatRate.Text), Convert.ToInt32(ddlfinalDestination.SelectedValue), Convert.ToInt32(hidPaymenttermsId.Value), Convert.ToInt32(hidTermsOfDeliveryId.Value), Convert.ToInt32(ddlModeofPayment.SelectedValue), txtSpecialIntruction.Text, Convert.ToInt32(txtOrder.Text), Convert.ToInt32(ddlMaterialCode.SelectedValue), txtUOM.Text, txtRate.Text, Convert.ToDecimal(txtQUantity.Text), Convert.ToInt32(userid));
            if (updatedheader > 0)
            {

                ClearLineItems();
                ImgBtnSave.ImageUrl = "~/Images/btnSave.png";
                ImgBtnSave.Enabled = false;
                gvSales.Visible = false;
                gvSalesOrder.Visible = true;
                gvSalesOrder.AllowPaging = false;
                gvSalesOrder.DataSource = "";
                gvSalesOrder.DataBind();
                string strSeriesLastNamber = "";
                decimal LastNumber = GetLastOrderNumber() + 1;
                strSeriesLastNamber = LastNumber.ToString();
                if (strSeriesLastNamber == "0")
                {
                    strSeriesLastNamber = "00001";
                }
                strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
                txtOrder.Text = strSeriesLastNamber;

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

                    iOrderNumber = Convert.ToInt32(txtOrder.Text);
                    string userid = "0";
                    if (Session["userid"] != null)
                    {
                        userid = Session["userid"].ToString();

                    }


                    string OrderID = objProc.Insert_In_Inventory_Sales_Order_Header(Convert.ToInt32(ddlsalesType.SelectedValue), txtYear.Text,txtDate.Text,Convert.ToInt32(hidCustomerId.Value),Convert.ToInt32(hidConsigneeId.Value), Convert.ToInt32(ddlDeliveryto.SelectedValue), Convert.ToInt32(ddlMattype.SelectedValue), Convert.ToInt32(txtCustomerOrder.Text), txtCustomerOrderdate.Text, Convert.ToInt32(ddlcurrency.SelectedValue), Convert.ToInt32(txtVatRate.Text), Convert.ToInt32(ddlfinalDestination.SelectedValue), Convert.ToInt32(hidPaymenttermsId.Value), Convert.ToInt32(hidTermsOfDeliveryId.Value) ,Convert.ToInt32( ddlModeofPayment.SelectedValue), txtSpecialIntruction.Text, Convert.ToInt32(userid)); 
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        if (Session["userid"] != null)
                        {
                            userid = Session["userid"].ToString();

                        }

                        booInsert = objProc.saveRecordsinSalesOrderInventory(Convert.ToInt32(OrderID), dt.Rows[i]["Line"].ToString(), dt.Rows[i]["MaterialCodeID"].ToString(), dt.Rows[i]["UOM"].ToString(), dt.Rows[i]["Rate"].ToString(), dt.Rows[i]["Quantity"].ToString(), dt.Rows[i]["StatusBit"].ToString(), dt.Rows[i]["CreatedBy"].ToString());

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
                        txtOrder.Text = strSeriesLastNamber;
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                    }
                }

            }
        }

        ViewState["Details"] = null;
    }
    protected void ImgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Procurement/SalesOrderForInventory.aspx");
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
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("Rate", typeof(string));
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

        drow["Quantity"] = txtQUantity.Text;
        drow["UOM"] = txtUOM.Text;
        drow["Rate"] = txtRate.Text;


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

        dt.Rows.Add(drow);
        ViewState["Details"] = dt;
        ViewState["Line"] = drow["Line"];
        gvSalesOrder.AllowPaging = true;
        gvSalesOrder.Visible = true;
        gvSalesOrder.DataSource = dt;
        gvSalesOrder.DataBind();
        BindMaterialCode();
        txtUOM.Attributes.Add("readonly", "true");
        txtUOM.Text = ""; 
        txtQUantity.Text = "";
        txtRate.Text = "";

        ImgBtnSave.Enabled = true;
    }


    protected void ClearLineItems()
    {
        BindMaterialCode();
        gvSalesOrder.AllowPaging = false;
        gvSalesOrder.DataSource = "";
        gvSalesOrder.DataBind();
        BindSOTypeMaster();
        BindDeliveryToMaster();
        BindMaterialTypeMaster();
        BindCurrencyMaster();
        BindPaymodeMaster();
        BindFinalDestinationMaster();
      
        txtDate.Attributes.Add("readonly", "true");
        txtYear.Attributes.Add("readonly", "true");
        txtcustomer.Attributes.Add("readonly", "true");
        txtcustomer.Text = "";
        txtConsignee.Attributes.Add("readonly", "true");
        txtConsignee.Text = "";
        txtUOM.Attributes.Add("readonly", "true");
        txtCustomerOrderdate.Attributes.Add("readonly", "true");
        txtDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
        txtCustomerOrderdate.Text = "";
        txtCustomerOrder.Text = "";
        txtPayterms.Text="";
        txtDivryTerms.Text = "";
        txtYear.Text = DateTime.Now.Year.ToString() + "-" + (Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) + 1).ToString();
        ImgBtnSave.Enabled = false;
        ImgBtnAddLine.Visible = true;
        txtVatRate.Text = "";
        txtSpecialIntruction.Text = "";

        txtRate.Text = "";
        txtQUantity.Text = "";
        txtUOM.Text = "";
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = gridMaster.SelectedDataKey.Value.ToString();
        ViewState["AUtoid"] = id;
        //string id = ((Label)row.FindControl("lblRawMaterial")).Text;
        //  ViewState["MachineDataid"] = id;
        DataTable dt = com.GetVal("@OrderNo", id, "Sp_Get_Proc_InventorySalesOrder_Details_byOrderID");
        if (dt.Rows.Count > 0)
        {
            ddlsalesType.SelectedValue = dt.Rows[0]["SalesType"].ToString();
            txtYear.Text = dt.Rows[0]["YEAR"].ToString();
            txtOrder.Text = dt.Rows[0]["OrderID"].ToString();
            txtDate.Text = dt.Rows[0]["Date"].ToString();
            txtcustomer.Text = dt.Rows[0]["CCode"].ToString();
            hidCustomerId.Value = dt.Rows[0]["CustomerCode"].ToString();
            txtConsignee.Text = dt.Rows[0]["ConsigneeName"].ToString();
            hidConsigneeId.Value = dt.Rows[0]["ConsigneeCode"].ToString();

            ddlDeliveryto.SelectedValue = dt.Rows[0]["DeliveryTo"].ToString();

            ddlMattype.SelectedValue = dt.Rows[0]["MatType"].ToString();
            txtCustomerOrder.Text = dt.Rows[0]["CustomerOrderNumber"].ToString();

            txtCustomerOrderdate.Text = dt.Rows[0]["CustomerOrderDate"].ToString();
            ddlcurrency.SelectedValue = dt.Rows[0]["CurrencyCode"].ToString();
            ddlModeofPayment.SelectedValue = dt.Rows[0]["PaymentMode"].ToString();


            txtVatRate.Text = dt.Rows[0]["VatRate"].ToString();

            ddlfinalDestination.SelectedValue = dt.Rows[0]["FinalDestination"].ToString();

            txtPayterms.Text = dt.Rows[0]["PaymentTermCode"].ToString();
            hidPaymenttermsId.Value = dt.Rows[0]["PaymentTerm"].ToString();

            txtDivryTerms.Text =  dt.Rows[0]["DeliveryTermsCode"].ToString();
            hidTermsOfDeliveryId.Value = dt.Rows[0]["DeliveryTerms"].ToString();

            //ddlModeofPayment.SelectedValue = dt.Rows[0]["PaymentMode"].ToString();

            //ddlMaterialCode.SelectedValue = dt.Rows[0]["MaterialCodeID"].ToString();

            //txtQUantity.Text = dt.Rows[0]["Quantity"].ToString();

            //txtUOM.Text = dt.Rows[0]["UOM"].ToString();

            //txtRate.Text = dt.Rows[0]["Rate"].ToString();

            txtSpecialIntruction.Text = dt.Rows[0]["SpecialInstruction"].ToString();

            ImgBtnSave.ImageUrl = "~/Images/btn_update.png";
            
            ImgBtnAddLine.Visible = false;
            ImgBtnSave.Enabled = true;
            gvSales.Visible = true;
            gvSalesOrder.Visible = false;
            gvSales.DataSource = dt;
            gvSales.DataBind();

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
            if (ddsearch.SelectedItem.Value == "OrderNo")
            {
                string id = txtSearch.Text;
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
                //get datatable
                //colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
            }
            else if (ddsearch.SelectedItem.Value == "CustomerCode")
            {
                string id = txtSearch.Text;
                if (id == "")
                {
                    id = "0";
                }
                DataTable dt = com.GetVal("@CustomerCode", id, "Sp_Get_Proc_InventorySalesOrder_Header_byCustomerCode");
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

    protected void BindDeliveryToMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_AllDeliveryToType();
            ddlDeliveryto.DataTextField = "DeliveryToName";
            ddlDeliveryto.DataValueField = "DeliveryToID";
            ddlDeliveryto.DataSource = colRCommontype;
            ddlDeliveryto.DataBind();
            ddlDeliveryto.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex) { }
    }

    protected void BindMaterialTypeMaster()
    {
        try
        {
            objBLLObj = objProc.Get_MaterialType();
            ddlMattype.DataTextField = "Code";
            ddlMattype.DataValueField = "Autoid";
            ddlMattype.DataSource = objBLLObj;
            ddlMattype.DataBind();
            ddlMattype.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex) { }
    }

    protected void imgCustomerCode_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "CustomerCode";
        lPopUpHeader.Text = "Customer";
        lSearch.Text = "Search By Customer: ";
        FillAllCustomer("");
        ModalPopupExtender2.Show();
    }

    protected void BindCurrencyMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Currency_Master();
            ddlcurrency.DataTextField = "CurrencyCode";
            ddlcurrency.DataValueField = "CurrencyID";
            ddlcurrency.DataSource = colRCommontype;
            ddlcurrency.DataBind();
            ddlcurrency.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex) { }
    }

    protected void BindPaymodeMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Paymode_Master();
            ddlModeofPayment.DataTextField = "PaymodeName";
            ddlModeofPayment.DataValueField = "PayModeID";
            ddlModeofPayment.DataSource = colRCommontype;
            ddlModeofPayment.DataBind();
            ddlModeofPayment.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex) { }
    }


    private void FillAllCustomer(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllCustomer(Searchtext);

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

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        if (HidPopUpType.Value == "CustomerCode")
        {
            FillAllCustomer(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "Consignee")
        {
            FillAllConsigneeByCustomerId(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "TermsOfDelivery")
        {
            FillAllTermsOfDelivery(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "TermsOfPayment")
        {
            FillAllPaymentTerms(txtSearchFromPopup.Text.Trim());
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

                if (HidPopUpType.Value == "CustomerCode")
                {
                    hidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtcustomer.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;

                }
                else if (HidPopUpType.Value == "Consignee")
                {
                    hidConsigneeId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtConsignee.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                }
                else if (HidPopUpType.Value == "TermsOfDelivery")
                {
                    hidTermsOfDeliveryId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtDivryTerms.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                }
                else if (HidPopUpType.Value == "TermsOfPayment")
                {
                    hidPaymenttermsId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtPayterms.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
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


    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "CustomerCode")
        {
            FillAllCustomer(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "Consignee")
        {
            if (hidCustomerId.Value != "")
            {
                FillAllConsigneeByCustomerId(txtSearchFromPopup.Text.Trim());
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.SelectCustomer, 125, 300);
            }
        }
        else if (HidPopUpType.Value == "TermsOfDelivery")
        {
            FillAllTermsOfDelivery(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "TermsOfPayment")
        {
            FillAllPaymentTerms(txtSearchFromPopup.Text.Trim());
        }

        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }
    protected void imgConsignee_Click(object sender, ImageClickEventArgs e)
    {
        if (hidCustomerId.Value != "")
        {
            HidPopUpType.Value = "Consignee";
            lPopUpHeader.Text = "Consignee";
            lSearch.Text = "Search By Consignee: ";
            FillAllConsigneeByCustomerId("");
            ModalPopupExtender2.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.SelectCustomer, 125, 300);
        }
    }


    private void FillAllConsigneeByCustomerId(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllConsigneeByCustomerId(hidCustomerId.Value, Searchtext);

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


    protected void BindFinalDestinationMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_AllFinalDestination();
            ddlfinalDestination.DataTextField = "FinalDestinationName";
            ddlfinalDestination.DataValueField = "FinalDestinationID";
            ddlfinalDestination.DataSource = colRCommontype;
            ddlfinalDestination.DataBind();
            ddlfinalDestination.Items.Insert(0, new ListItem("---Select---", "0"));


        }
        catch (Exception ex) { }
    }
    protected void imgTermsofDelivery_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "TermsOfDelivery";
        lPopUpHeader.Text = "Terms Of Delivery";
        lSearch.Text = "Search By Terms Of Delivery: ";
        FillAllTermsOfDelivery("");
        ModalPopupExtender2.Show();
    }



    //imgPaymentTerms_Click



    private void FillAllTermsOfDelivery(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllTermsOfDelivery(Searchtext);

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
    protected void imgPaymentTerms_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "TermsOfPayment";
        lPopUpHeader.Text = "Terms Of Payment";
        lSearch.Text = "Search By Terms Of Payment: ";
        FillAllPaymentTerms("");
        ModalPopupExtender2.Show();
    }

    private void FillAllPaymentTerms(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc.FillAllPaymentTerms(Searchtext);

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



    protected void ddlMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ddlMaterialCode.SelectedValue.ToString();
        DataTable dt = com.GetVal("@MaterialCode", id, "Sp_Set_Proc_ScarpReceived_by_MaterialCode");
        if (dt.Rows.Count > 0)
        {
            txtUOM.Text = dt.Rows[0]["StockUnit"].ToString();
        }
    }

    protected decimal GetLastOrderNumber()
    {
        decimal TopValueOrderNumber = objProc.GetLastOrderNumber();
        if (TopValueOrderNumber == 0)
        {
            TopValueOrderNumber = 0;
        }

        return TopValueOrderNumber;


    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               