using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Drawing;

public partial class Procurement_frmPO : System.Web.UI.Page
{
    Proc_PO cs = new Proc_PO();
    Common cmn = new Common();
    Common_mst objCommon_mst = new Common_mst();
    Common_Message objMsg = new Common_Message();
    static DataTable dtLineitems = new DataTable();
    static DataTable dtPrices = new DataTable();
    static DataTable dtDeliveryDays = new DataTable();
    string financial_year = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] == null)
            {
                Server.Transfer("../SessionExpired.aspx");
            }
            else
            {
                Label lblHeader = (Label)Master.FindControl("lbl_PageHeader");
                lblHeader.Text = "Purchase Order";
                DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
                DataTable dt = cmn.fillSearch("136");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));


                    }
                }

                fillAllDD();
                financial_year = getFinancialYear();
                txtPONumber.Text = AutogeneratePONo(financial_year);
                txtPONumber.Enabled = false;
                txtPOYear.Text = financial_year;
                txtPOYear.Enabled = false;
                makeEmptydtLineitems();
                gridPOLine.DataSource = dtLineitems;
                gridPOLine.DataBind();
                makeEmptydtPrices();
                GridPrices.DataSource = dtPrices;
                GridPrices.DataBind();
                makeEmptydtDeliveryDays();
                GridDeliveryDays.DataSource = dtDeliveryDays;
                GridDeliveryDays.DataBind();
                TabContCustomer.ActiveTabIndex = 0;
                btnUpdate.Visible = false;
                hfDetailsLineno.Value = "";
                hfpriceslineno.Value = "";
                hfdeliverydayslineno.Value = "";

            }
        }

        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;

        ImageButton btn_Search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_Search.Click += new ImageClickEventHandler(btn_Search_Click);
        btn_Search.CausesValidation = false;


    }

    void btn_Search_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        DataTable dt = cs.searchResults(ddsearch.SelectedValue, txtSearch.Text.Trim());
        gridMaster.DataSource = dt;
        gridMaster.DataBind();
        ModalPopupExtender1.Show();
    }

    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        int DataKey = int.Parse(gridMaster.SelectedDataKey.Value.ToString());
        fillDataToForm(DataKey);
        hfPOid.Value = DataKey.ToString();
        btnSave.Visible = false;
        btnUpdate.Visible = true;


    }

    protected void fillDataToForm(int c)
    {
        clearAll();
        displayRecord(c);


    }
    protected void displayRecord(int poid)
    {
        displayMainRecord(poid);
        dtLineitems = cs.getDetailData(poid);
        dtPrices = cs.getPricesData(poid);
        dtDeliveryDays = cs.getDeliveryDaysData(poid);
        gridPOLine.DataSource = dtLineitems;
        GridPrices.DataSource = dtPrices;
        GridDeliveryDays.DataSource = dtDeliveryDays;
        gridPOLine.DataBind();
        GridPrices.DataBind();
        GridDeliveryDays.DataBind();

    }

    protected void displayMainRecord(int poid)
    {
        DataTable dtheader = cs.getMainData(poid);
        ddPOType.SelectedValue = dtheader.Rows[0]["POType"].ToString();
        ddPOCategory.SelectedValue = dtheader.Rows[0]["POCategory"].ToString();
        txtPONumber.Text = dtheader.Rows[0]["PONumber"].ToString();
        txtPODate.Text = dtheader.Rows[0]["PODate"].ToString();
        txtPOYear.Text = dtheader.Rows[0]["VoucherYear"].ToString();
        txtVendor.Text = dtheader.Rows[0]["Vendor"].ToString();
        txtPaymentTerms.Text = dtheader.Rows[0]["PaymentTerms"].ToString();
        txtIncoTerms.Text = dtheader.Rows[0]["IncoCode"].ToString();
        ddCurrency.SelectedValue = dtheader.Rows[0]["Currency"].ToString();
        txtExchRate.Text = dtheader.Rows[0]["ExchangeRate"].ToString();
        chkExchangeRateFixed.Checked = bool.Parse(dtheader.Rows[0]["FixedExchRate"].ToString());
        txtVendorReference.Text = dtheader.Rows[0]["VendorReference"].ToString();
        txtOurReference.Text = dtheader.Rows[0]["OurReference"].ToString();
        txtQuotation.Text = dtheader.Rows[0]["QuotationNo"].ToString();
        txtQuotationDate.Text = dtheader.Rows[0]["QuotationDate"].ToString();
        txtFreight.Text = dtheader.Rows[0]["Freight"].ToString();
        txtInsaurance.Text = dtheader.Rows[0]["Insurance"].ToString();
        txtPacking.Text = dtheader.Rows[0]["Packing"].ToString();
        txtDiscount.Text = dtheader.Rows[0]["Discount"].ToString();
        txtHeaderText.Text = dtheader.Rows[0]["HeaderText"].ToString();
        txtSUTax.Text = dtheader.Rows[0]["VATAmount"].ToString();
        txtOtherCost.Text = dtheader.Rows[0]["OtherCost"].ToString();
        txtDeliveryPlant.Text = dtheader.Rows[0]["DeliveryPlant"].ToString();
        ddPurchasingGroup.SelectedValue = dtheader.Rows[0]["PurchasingGroup"].ToString();

    }

    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridMaster.PageIndex = e.NewPageIndex;
        DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        DataTable dt = cs.searchResults(ddsearch.SelectedValue, txtSearch.Text.Trim());
        gridMaster.DataSource = dt;
        gridMaster.DataBind();
        ModalPopupExtender1.Show();

    }
    protected void clearAll()
    {
        clearMain();
        clearLineBoxes();
        clearPrices();
        clearDeliveryDays();
       
       
    
    }

    protected void clearMain()
    {

        ddPOType.SelectedValue = "";
        ddPOCategory.SelectedValue = "";
        txtPONumber.Text = "";
        txtPOYear.Text = "";
        txtPODate.Text = DateTime.Now.Date.ToString();
        txtVendor.Text = "";
        txtPaymentTerms.Text = "";
        txtIncoTerms.Text = "";
        ddCurrency.SelectedValue = "";
        txtExchRate.Text = "";
        chkExchangeRateFixed.Checked = false;
        txtVendorReference.Text = "";
        txtOurReference.Text = "";
        txtQuotation.Text = "";
        txtQuotationDate.Text = "";
        txtFreight.Text = "";
        txtInsaurance.Text = "";
        txtPacking.Text = "";
        txtDiscount.Text = "";
        txtHeaderText.Text = "";
        txtSUTax.Text = "";
        txtOtherCost.Text = "";
        txtDeliveryPlant.Text = "";
        ddPurchasingGroup.SelectedIndex = 0;






    }

    protected void clearPrices()
    {

        txtPricesConditioncode.Text = "";
        ddpricescurrency.SelectedValue = "";
        txtpricesConditionvalue.Text = "";
        txtpricesvendor.Text = "";
        txtpricesamount.Text = "";
        txtpricesamountlc.Text = "";
        txtpricescalculationtype.Text = "";

    }
    protected void clearDeliveryDays()
    {

        txtDeliveryRequiredQuatity.Text = "";
        txtDeliveryTotal.Text = "";

    }


    void btn_add_Click(object sender, ImageClickEventArgs e)
    {


    }
    protected void makeEmptydtLineitems()
    {
        dtLineitems.Columns.Clear();
        dtLineitems.Columns.Add("LineItem");
        dtLineitems.Columns.Add("PRNumber");
        dtLineitems.Columns.Add("MaterialCode");
        dtLineitems.Columns.Add("POQuantity");
        dtLineitems.Columns.Add("UOM");
        dtLineitems.Columns.Add("Price");
        dtLineitems.Columns.Add("Amount");
        dtLineitems.Columns.Add("Plant");
        dtLineitems.Columns.Add("CostCenter");
        dtLineitems.Columns.Add("PRPrice");
        dtLineitems.Columns.Add("PRDLVDate");
        dtLineitems.Columns.Add("ValuationType");
        dtLineitems.Columns.Add("ProjectCode");
        dtLineitems.Columns.Add("SubProjectCode");
        dtLineitems.Columns.Add("BudgetCode");
        dtLineitems.Columns.Add("SubBudgetCode");
        dtLineitems.Columns.Add("MaterialDescription");
        dtLineitems.Columns.Add("Discount");
        dtLineitems.Columns.Add("AbsPercent");
        dtLineitems.Columns.Add("OtherCost");
        dtLineitems.Columns.Add("PackLine");
        dtLineitems.Columns.Add("POItemText");
        dtLineitems.Columns.Add("LeadTime");
        dtLineitems.Columns.Add("DelivryQuantity");
        dtLineitems.Columns.Add("MaterialCodeName");
    }

    protected void makeEmptydtPrices()
    {
        dtPrices.Columns.Clear();
        dtPrices.Columns.Add("POLNNo");
        dtPrices.Columns.Add("ConditionCode");
        dtPrices.Columns.Add("ConditionCurrency");
        dtPrices.Columns.Add("ConditionValue");
        dtPrices.Columns.Add("VendorCode");
        dtPrices.Columns.Add("Amount");
        dtPrices.Columns.Add("AmountLC");
    }
    protected void makeEmptydtDeliveryDays()
    {
        dtDeliveryDays.Columns.Clear();
        dtDeliveryDays.Columns.Add("POLineNo");
        dtDeliveryDays.Columns.Add("DeliveryDays");
        dtDeliveryDays.Columns.Add("Quantity");
    }

    protected string AutogeneratePONo(string financialYear)
    {
        int po_series;
        string po_no = "";
        try
        {
            po_series = cs.getPOSeries(financialYear);
            po_no = "PO" + financialYear + po_series.ToString().PadLeft(5, '0');
        }
        catch (Exception ex)
        {

        }
        return po_no;
    }

    protected string getFinancialYear()
    {
        string fin_yr = "";
        DataTable dt = new DataTable();
        string OrganizationId = ConfigurationManager.AppSettings["OrganizationId"].ToString();
        dt = objCommon_mst.Get_FinancialYear(OrganizationId);
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0]["FinancialStartMonth"].ToString()) > 1)
            {
                string EndFinancialYear = dt.Rows[0]["FinancialEndYear"].ToString().Substring(2);
                fin_yr = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
            }
            else
            {
                fin_yr = dt.Rows[0]["FinancialStartYear"].ToString();
            }
        }

        return fin_yr;

    }

    protected void fillAllDD()
    {
        fillCurrency(ddCurrency);
        fillCurrency(ddpricescurrency);
        fillPOType(ddPOType);
        fillPOCategory(ddPOCategory);
        fillValuation(ddValuation);
        fillProject(ddProject);
        fillSubProject(ddSubProject);


    }

    protected void fillCurrency(DropDownList curr)
    {
        DataTable dt = cmn.getCurrency();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["CurrencyCode"].ToString(), row["CurrencyID"].ToString()));
            }


        }
    }
    protected void fillPOType(DropDownList dd)
    {
        DataTable dt = cs.getPOType();
        dd.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                dd.Items.Add(new ListItem(row["POTypeDesc"].ToString(), row["AutoId"].ToString()));
            }


        }
    }
    protected void fillPOCategory(DropDownList dd)
    {
        DataTable dt = cs.getPOCategory();
        dd.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                dd.Items.Add(new ListItem(row["POCategory"].ToString(), row["AutoId"].ToString()));
            }


        }
    }
    protected void fillUOM(DropDownList dd)
    {
        DataTable dt = cs.getUOM();
        dd.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                dd.Items.Add(new ListItem(row["Description"].ToString(), row["AutoId"].ToString()));
            }


        }
    }
    protected void fillValuation(DropDownList dd)
    {
        DataTable dt = cs.getValuation();
        dd.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                dd.Items.Add(new ListItem(row["ValuationType"].ToString(), row["AutoId"].ToString()));
            }


        }
    }
    protected void fillProject(DropDownList dd)
    {
        DataTable dt = cs.getProject();
        dd.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                dd.Items.Add(new ListItem(row["ProjectName"].ToString(), row["Id"].ToString()));
            }


        }
    }
    protected void fillSubProject(DropDownList dd)
    {
        DataTable dt = cs.getSubProject();
        dd.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                dd.Items.Add(new ListItem(row["SubProjectName"].ToString(), row["SubprojectId"].ToString()));
            }


        }
    }

    protected void img_Customer_lookup_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = cs.makelookupgridVendor();

            GdvVendorList.DataSource = dt;
            GdvVendorList.DataBind();
            ModalPopupExtender2.Show();
        }
        catch (Exception ex)
        {
        }
    }
    protected void GdvVendorList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            hf_VendorId.Value = GdvVendorList.SelectedDataKey.Values[0].ToString();

            txtVendor.Text = GdvVendorList.SelectedDataKey.Values[1].ToString();
            txtVendor.Enabled = false;
        }
        catch (Exception ex)
        {

        }


    }
    protected void Img_btn_search_lookup_Click(object sender, ImageClickEventArgs e)
    {
        string keyword = txtSearchLook.Text.Trim();
        DataTable dt = cs.makelookupgridVendorwithSearch(keyword);

        GdvVendorList.DataSource = dt;
        GdvVendorList.DataBind();
        ModalPopupExtender2.Show();
    }
    protected void imgMaterialLook_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "Material";
        lPopUpHeader.Text = "Material Master";
        lSearch.Text = "Search By Material Code/Name: ";
        FillAllMaterial("");
        ModalPopupExtender3.Show();

    }
    private void FillAllMaterial(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllMaterialMaster(Searchtext);

            if (dt.Rows.Count > 0)
            {
                lblTotalRecordsPopUp.Text = objMsg.TotalRecord + dt.Rows.Count.ToString();

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
                lblTotalRecordsPopUp.Text = objMsg.NoRecordFound;
                gvPopUpGrid.AllowPaging = false;
                gvPopUpGrid.DataSource = "";
                gvPopUpGrid.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecordsPopUp.Text = objMsg.NoRecordFound + ex.Message;
            gvPopUpGrid.AllowPaging = false;
            gvPopUpGrid.DataSource = "";
            gvPopUpGrid.DataBind();
        }
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "Material")
        {
            FillAllMaterial(txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender3.Show();
    }


    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                if (HidPopUpType.Value == "Material")
                {
                    e.Row.Cells[4].Style.Add("display", "none");
                }
                e.Row.Cells[1].Style.Add("display", "none");
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

                if (HidPopUpType.Value == "Material")
                {
                    HidMaterialId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtMaterialCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text + " (" + gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text + ")";
                    HidUOMId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                    txtUOM.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                }

            }
        }
        catch { }
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        if (HidPopUpType.Value == "Material")
        {
            FillAllMaterial(txtSearchFromPopup.Text.Trim());
        }

        txtSearchFromPopup.Focus();
        ModalPopupExtender3.Show();
    }
    protected void btnAddLineMainPage_Click(object sender, ImageClickEventArgs e)
     {
        try
        {
            DataRow rowLine = dtLineitems.NewRow();
            if (hfDetailsLineno.Value == "")
            {
                rowLine["LineItem"] = getDetailsLineNo();
            }
            else
            {
                rowLine["LineItem"] = hfDetailsLineno.Value;

                DataRow[] row = dtLineitems.Select("LineItem=" + hfDetailsLineno.Value);

                if (row.Length > 0)
                {
                    foreach (DataRow dr in row)
                    {
                        dtLineitems.Rows.Remove(dr);
                    }
                }
              
            }
            


            

            rowLine["PRNumber"] = txtPRNumber.Text;
            rowLine["MaterialCode"] = HidMaterialId.Value;
            rowLine["POQuantity"] = txtQuantity.Text;
            rowLine["UOM"] = HidUOMId.Value;
            rowLine["Price"] = txtprice.Text;
            rowLine["Amount"] = txtAmount.Text;
            rowLine["Plant"] = txtPlant.Text;
            rowLine["CostCenter"] = txtCostCenter.Text;
            rowLine["PRPrice"] = txtPRPrice.Text; ;
            rowLine["PRDLVDate"] = txtPRDlvDate.Text;
            rowLine["ValuationType"] = ddValuation.SelectedValue;
            rowLine["ProjectCode"] = ddProject.SelectedValue;
            rowLine["SubProjectCode"] = ddSubProject.SelectedValue;
            rowLine["BudgetCode"] = txtBudgetCapexLine.Text;
            rowLine["SubBudgetCode"] = txtSubBudgetCapexLine.Text;
            rowLine["MaterialDescription"] = txtMaterialText.Text;
            rowLine["Discount"] = txtDiscountLine.Text;
            rowLine["AbsPercent"] = txtABS.Text;
            rowLine["OtherCost"] = txtOtherCostLine.Text;
            rowLine["PackLine"] = txtPackingline.Text;
            rowLine["POItemText"] = txtPOItemText.Text;
            rowLine["LeadTime"] = txtLeadTimeDays.Text;
            rowLine["DelivryQuantity"] = txtDeliveryQuantity.Text;
            rowLine["MaterialCodeName"] = txtMaterialCode.Text;

            dtLineitems.Rows.Add(rowLine);
            gridPOLine.DataSource = dtLineitems;
            gridPOLine.DataBind();
            clearLineBoxes();
            btnSave.CausesValidation = false;
        }
        catch { }
    }


    protected int getDetailsLineNo()
    {
        try
        {
            if (dtLineitems.Rows.Count > 0)
            {
                string expression = "LineItem = MAX(LineItem)";
                DataRow[] maxrow = dtLineitems.Select(expression);
                int maxid = int.Parse(maxrow[0]["LineItem"].ToString());
                return maxid + 10;
            }
            else
            {
                return 10;
            }
        }
        catch (Exception ex)
        {
            return 10;
        }
    }

    protected int getPriceLineNo()
    {
        try
        {
            if (dtPrices.Rows.Count > 0)
            {
                string expression = "POLNNo = MAX(POLNNo)";
                DataRow[] maxrow = dtPrices.Select(expression);
                int maxid = int.Parse(maxrow[0]["POLNNo"].ToString());
                return maxid + 10;
            }
            else
            {
                return 10;
            }
        }
        catch (Exception ex)
        {
            return 10;
        }
    }

    protected int getDeliveryDaysLineNo()
    {
        try
        {
            if (dtDeliveryDays.Rows.Count > 0)
            {
                string expression = "POLineNo = MAX(POLineNo)";
                DataRow[] maxrow = dtDeliveryDays.Select(expression);
                int maxid = int.Parse(maxrow[0]["POLineNo"].ToString());
                return maxid + 10;
            }
            else
            {
                return 10;
            }
        }
        catch (Exception ex)
        {
            return 10;
        }
    }

    protected void clearLineBoxes()
    {
        txtPRNumber.Text = "";
        txtQuantity.Text = "";
        txtUOM.Text = "";
        txtprice.Text = "";
        txtAmount.Text = "";
        txtPlant.Text = "";
        txtCostCenter.Text = "";
        txtPRPrice.Text = "";
        txtPRDlvDate.Text = "";
        ddValuation.SelectedValue = "";
        ddProject.SelectedValue = "";
        ddSubProject.SelectedValue = "";
        txtBudgetCapexLine.Text = "";
        txtSubBudgetCapexLine.Text = "";
        txtMaterialText.Text = "";
        txtDiscountLine.Text = "";
        txtABS.Text = "";
        txtOtherCostLine.Text = "";
        txtPackingline.Text = "";
        txtPOItemText.Text = "";
        txtLeadTimeDays.Text = "";
        txtDeliveryQuantity.Text = "";
        txtMaterialCode.Text = "";
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (dtLineitems.Rows.Count > 0 && dtPrices.Rows.Count > 0 && dtDeliveryDays.Rows.Count > 0)
        {
            bool isSaved = false;

            isSaved = cs.savePO(ddPOType.SelectedValue, ddPOCategory.SelectedValue, txtPOYear.Text,
            DateTime.Parse(txtPODate.Text.Trim()), hf_VendorId.Value, txtPaymentTerms.Text,
            txtIncoTerms.Text, ddCurrency.SelectedValue, double.Parse(txtExchRate.Text), chkExchangeRateFixed.Checked, txtVendorReference.Text, txtOurReference.Text, txtQuotation.Text,
            DateTime.Parse(txtQuotationDate.Text.Trim()), double.Parse(txtFreight.Text),
            double.Parse(txtInsaurance.Text), double.Parse(txtPacking.Text), double.Parse(txtDiscount.Text), txtHeaderText.Text, double.Parse(txtSUTax.Text), double.Parse(txtOtherCost.Text),
            txtDeliveryPlant.Text, ddPurchasingGroup.SelectedValue, Session["UserID"].ToString(), DateTime.Now,
            Session["UserID"].ToString(), DateTime.Now , true, dtLineitems, dtPrices, dtDeliveryDays);



            if (isSaved == true)
            {
                string message = objMsg.RecordSaved;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
                clearAll();
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                TabContCustomer.ActiveTabIndex = 0;
                hf_isNewRecord.Value = "false";


            }
            else
            {
                string message = objMsg.RecordNotSaved;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
            }
        }
        else
        {


            if (dtLineitems.Rows.Count <= 0)
            {
                string message = "Please add atleast one Purchase Order Detail.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                TabContCustomer.ActiveTabIndex = 1;
            }
            else if (dtPrices.Rows.Count <= 0)
            {
                string message = "Please add atleast one Price Information.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                TabContCustomer.ActiveTabIndex = 2;
            }
            if (dtDeliveryDays.Rows.Count <= 0)
            {
                string message = "Please add atleast one Delivery Days Detail.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                TabContCustomer.ActiveTabIndex = 1;
            }


        }

    }
    protected void btn_cancel_Click(object sender, ImageClickEventArgs e)
    {
        //if (hfConfirm.Value == "true")
        //{
        //    //int Cid = getPositionID(iFlag);
        //    //displayDetailsRecord(Cid);
        //    hf_isNewRecord.Value = "false";
        //    TabContCustomer.ActiveTabIndex = 0;
        //    cs.refreshCustomerDetails();
        //    int cid = cs.getPositionID(iFlag);
        //    fillDataToForm(cid);
        //    btn_save.Visible = false;
        //    btn_cancel.Visible = false;
        //    btn_nxt.Visible = true;
        //    btn_pre.Visible = true;
        //    btn_addSaleInfo.Visible = false;
        //    btnAddAccountingDetails.Visible = false;
        //    EnableAllControls(false);
        //    ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
        //    btn_Search.Enabled = true;
        //}

    }
    protected void btnAddLinePrices_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataRow rowLine = dtPrices.NewRow();

            rowLine["POLNNo"] = getPriceLineNo();
            rowLine["ConditionCode"] = txtPricesConditioncode.Text;
            rowLine["ConditionCurrency"] = ddpricescurrency.SelectedValue;
            rowLine["ConditionValue"] = txtpricesConditionvalue.Text;
            rowLine["VendorCode"] = txtpricesvendor.Text;
            rowLine["Amount"] = txtpricesamount.Text;
            rowLine["AmountLC"] = txtpricesamountlc.Text;


            dtPrices.Rows.Add(rowLine);
            GridPrices.DataSource = dtPrices;
            GridPrices.DataBind();
            clearPrices();
            btnSave.CausesValidation = false;
        }
        catch { }

    }
    protected void btnAddLineDeliveryDays_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataRow rowLine = dtDeliveryDays.NewRow();
            rowLine["POLineNo"] = getDeliveryDaysLineNo();
            rowLine["DeliveryDays"] = txtDeliveryTotal.Text;
            rowLine["Quantity"] = txtDeliveryRequiredQuatity.Text;



            dtDeliveryDays.Rows.Add(rowLine);
            GridDeliveryDays.DataSource = dtDeliveryDays;
            GridDeliveryDays.DataBind();
            clearDeliveryDays();
            btnSave.CausesValidation = false;
        }
        catch { }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (dtLineitems.Rows.Count > 0 && dtPrices.Rows.Count > 0 && dtDeliveryDays.Rows.Count > 0)
            {
                bool isSaved = false;

                isSaved = cs.updatePO(int.Parse(hfPOid.Value), ddPOType.SelectedValue, ddPOCategory.SelectedValue, txtPOYear.Text, DateTime.Parse(txtPODate.Text.Trim()), 
                hf_VendorId.Value, txtPaymentTerms.Text, txtIncoTerms.Text, ddCurrency.SelectedValue, double.Parse(txtExchRate.Text), chkExchangeRateFixed.Checked, txtVendorReference.Text,
                txtOurReference.Text, txtQuotation.Text,DateTime.Parse(txtQuotationDate.Text.Trim()), double.Parse(txtFreight.Text), double.Parse(txtInsaurance.Text), 
                double.Parse(txtPacking.Text), double.Parse(txtDiscount.Text), txtHeaderText.Text, double.Parse(txtSUTax.Text), double.Parse(txtOtherCost.Text),txtDeliveryPlant.Text,
                ddPurchasingGroup.SelectedValue, Session["UserID"].ToString(),DateTime.Now,Session["UserID"].ToString(), DateTime.Now, true, dtLineitems, dtPrices, dtDeliveryDays);


                if (isSaved == true)
                {
                    string message = objMsg.UpdatedRecord;
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
                    clearAll();
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    TabContCustomer.ActiveTabIndex = 0;



                }
                else
                {
                    string message = objMsg.RecordNotUpdated;
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                }
            }
            else
            {


                if (dtLineitems.Rows.Count <= 0)
                {
                    string message = "Please add atleast one Purchase Order Detail.";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                    TabContCustomer.ActiveTabIndex = 0;
                }
                else if (dtPrices.Rows.Count <= 0)
                {
                    string message = "Please add atleast one Price Information.";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                    TabContCustomer.ActiveTabIndex = 1;
                }
                if (dtDeliveryDays.Rows.Count <= 0)
                {
                    string message = "Please add atleast one Delivery Days Detail.";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                    TabContCustomer.ActiveTabIndex = 2;
                }


            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void gridPOLine_SelectedIndexChanged(object sender, EventArgs e)
    {

        int DataKey = int.Parse(gridPOLine.SelectedDataKey.Value.ToString());
        displayDetailsLineRecord(DataKey);

        foreach (GridViewRow oldrow in gridPOLine.Rows)
        {
            ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgAccgridsel");
            imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            oldrow.BackColor = Color.White;
        }
        ImageButton img = (ImageButton)gridPOLine.Rows[gridPOLine.SelectedIndex].FindControl("imgAccgridsel");
        img.ImageUrl = "~/Images/chkbxcheck.png";

        hfDetailsLineno.Value = DataKey.ToString();

        
          
    }

    protected void displayDetailsLineRecord(int lineNo)
    {


        string expression = "LineItem=" + lineNo;
        DataRow[] selRow = dtLineitems.Select(expression);

        txtPRNumber.Text = selRow[0]["PRNumber"].ToString();
        txtQuantity.Text = selRow[0]["POQuantity"].ToString();
        txtUOM.Text = selRow[0]["UOM"].ToString();
        txtprice.Text = selRow[0]["Price"].ToString();
        txtAmount.Text = selRow[0]["Amount"].ToString();
        txtPlant.Text = selRow[0]["Plant"].ToString();
        txtCostCenter.Text = selRow[0]["CostCenter"].ToString();
        txtPRPrice.Text = selRow[0]["PRPrice"].ToString();
        txtPRDlvDate.Text = selRow[0]["PRDLVDate"].ToString();
        ddValuation.SelectedValue = selRow[0]["ValuationType"].ToString();
        ddProject.SelectedValue = selRow[0]["ProjectCode"].ToString();
        ddSubProject.SelectedValue = selRow[0]["SubProjectCode"].ToString();
        txtBudgetCapexLine.Text = selRow[0]["BudgetCode"].ToString();
        txtSubBudgetCapexLine.Text = selRow[0]["SubBudgetCode"].ToString();
        txtMaterialText.Text = selRow[0]["MaterialDescription"].ToString();
        txtDiscountLine.Text = selRow[0]["Discount"].ToString();
        txtABS.Text = selRow[0]["AbsPercent"].ToString();
        txtOtherCostLine.Text = selRow[0]["OtherCost"].ToString();
        txtPackingline.Text = selRow[0]["PackLine"].ToString();
        txtPOItemText.Text = selRow[0]["POItemText"].ToString();
        txtLeadTimeDays.Text = selRow[0]["LeadTime"].ToString();
        txtDeliveryQuantity.Text = selRow[0]["DelivryQuantity"].ToString();
        txtMaterialCode.Text = selRow[0]["MaterialCodeName"].ToString();

    }

    
}