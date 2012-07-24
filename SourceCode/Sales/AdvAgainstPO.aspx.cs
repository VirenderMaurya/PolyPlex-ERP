using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Sales_AdvAgainstPO : System.Web.UI.Page
{
    Common cmn = new Common();
    Common_mst objCommon_mst = new Common_mst();
    AdvAgainstPO cs = new AdvAgainstPO();
    static DataTable dtlineitems = new DataTable();
    Common_Message objMsg = new Common_Message();

    static string financial_year = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
            Label lblHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblHeader.Text = "Advance Against PO";
            DataTable dt = cmn.fillSearch("174");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));


                }
            }
            financial_year = getFinancialYear();
            txtVoucherno.Text = AutogenerateVoucherNo(financial_year);
            txtVoucherno.Enabled = false;
            txtvoucherdate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat, objCommon_mst.FormatProvider);
            txtYear.Text = financial_year;
            fillCurrency(dd_currency);          
            dtlineitems.Columns.Clear();
            makeEmptyLineItemGrid();
            btn_Save.CausesValidation = true;


        }



        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");


    }

    void btn_search_Click(object sender, ImageClickEventArgs e)
    {
       
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
    protected string AutogenerateVoucherNo(string financialYear)
    {
        int v_series;
        string v_no = "";
        try
        {
            v_series = cs.getVoucherSeries(financialYear);
            v_no = "APO" + financialYear + v_series.ToString().PadLeft(5, '0');
        }
        catch (Exception ex)
        {

        }
        return v_no;
    }
    protected void img_Customer_lookup_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = cs.makelookupgridBank();

            GdvBankList.DataSource = dt;
            GdvBankList.DataBind();
            ModalPopupExtender2.Show();
        }
        catch (Exception ex)
        {
        }
    }

    protected void GdvBankList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            txtbankGLCode.Text = GdvBankList.SelectedDataKey.Values[0].ToString();
            lbl_bankname.Text = GdvBankList.SelectedDataKey.Values[1].ToString();
        }
        catch (Exception ex)
        {

        }
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
    protected void img_PO_lookup_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = cs.makelookupgridPO();

            grid_PO.DataSource = dt;
            grid_PO.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
        }

    }
    protected void btn_search_lookup_PO_Click(object sender, ImageClickEventArgs e)
    {
        string keyword = TxtPOSearch.Text.Trim();
        DataTable dt = cs.makelookupgridBankwithSearch(keyword);

        grid_PO.DataSource = dt;
        grid_PO.DataBind();
        ModalPopupExtender1.Show();

    }
    protected void Img_btn_search_lookup_GL_Click(object sender, ImageClickEventArgs e)
    {
        string keyword = txtSearchLook.Text.Trim();
        DataTable dt = cs.makelookupgridBankwithSearch(keyword);

        GdvBankList.DataSource = dt;
        GdvBankList.DataBind();
        ModalPopupExtender2.Show();
    }
    protected void grid_PO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string autoid = grid_PO.SelectedDataKey.Values[0].ToString();
            DataTable dtPO = cs.getPOValues(autoid);
            if (dtPO.Rows.Count > 0)
            {
                hf_POid.Value = autoid;
                hf_PODate.Value = dtPO.Rows[0]["PODate"].ToString();
                txtPO.Text = dtPO.Rows[0]["PONumber"].ToString();
                txt_Vendor.Text = dtPO.Rows[0]["VendorCode"].ToString();
                txt_PaymntTermsinPO.Text = dtPO.Rows[0]["PaymentTerms"].ToString();
                txt_POValueinLC.Text = dtPO.Rows[0]["AmountLC"].ToString();
                FxValue.Text = dtPO.Rows[0]["TotalValue"].ToString();
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void btn_SaveLine_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataRow rowLine = dtlineitems.NewRow();
            rowLine["Autoid"] = hf_POid.Value;
            rowLine["PONo"] = txtPO.Text.Trim();
            rowLine["PODate"] = hf_PODate.Value;
            rowLine["VendorCode"] = txt_Vendor.Text.Trim();
            dtlineitems.Rows.Add(rowLine);
            Grid_lineItems.DataSource = dtlineitems;
            Grid_lineItems.DataBind();
            clearLineBoxes();
            btn_Save.CausesValidation = false;
        }
        catch { }

    }
    protected void clearLineBoxes()
    {
        txtPO.Text = "";
        FxValue.Text = "";
        txt_Vendor.Text = "";
        txt_ValueinLC.Text = "";
        txt_Advancepaidagainstpo.Text = "";
        txt_POValueinLC.Text = "";
        txt_POValueAlreadyPaid.Text = "";
        txt_PaymntTermsinPO.Text = "";
        txt_ExchangeRateinPO.Text = "";
        txt_FxValueinPO.Text = "";
        txt_FXPlusMinus.Text = "";
    }

    protected void makeEmptyLineItemGrid()
    {
        dtlineitems.Columns.Add("Autoid");
        dtlineitems.Columns.Add("PONo");
        dtlineitems.Columns.Add("PODate");
        dtlineitems.Columns.Add("VendorCode");
        Grid_lineItems.DataSource = dtlineitems;
        Grid_lineItems.DataBind();
    }
    protected void Grid_lineItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            string Autoid = Grid_lineItems.DataKeys[e.RowIndex].Values["Autoid"].ToString();
            string expression = "Autoid=" + Autoid;
            dtlineitems = DeleteSingleRow(dtlineitems, expression);
            Grid_lineItems.DataSource = dtlineitems;
            Grid_lineItems.DataBind();

        }

        catch (Exception ex) { }
    }

    protected DataTable DeleteSingleRow(DataTable dt, string expression)
    {
        DataRow[] row = dt.Select(expression);

        if (row.Length > 0)
        {
            foreach (DataRow dr in row)
            {
                dt.Rows.Remove(dr);

            }
        }
        return dt;

    }
    protected void btn_Save_Click(object sender, ImageClickEventArgs e)
    {
        if (cs.saveRecords(dtlineitems, DateTime.Parse(txtvoucherdate.Text), financial_year, txtbankGLCode.Text, dd_currency.SelectedValue.ToString(), txtExchangeRate.Text, txt_localbankCharges.Text, txtForeignBankCharges.Text, txt_fxbankchargesLC.Text, txt_chequeNo.Text, DateTime.Parse(txt_chequedate.Text), Session["UserID"].ToString(), DateTime.Now.Date.ToString(), Session["UserID"].ToString(), DateTime.Now.Date.ToString()))
        {
            string message = objMsg.RecordSaved;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            clearAll();

        }
        else
        {
            string message = objMsg.RecordNotSaved;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
        }
    }

    protected void clearAll()
    {
        financial_year = getFinancialYear();
        txtVoucherno.Text = AutogenerateVoucherNo(financial_year);
        txtVoucherno.Enabled = false;
        txtvoucherdate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat, objCommon_mst.FormatProvider);
        dtlineitems.Columns.Clear();
        makeEmptyLineItemGrid();
        btn_Save.CausesValidation = true;
        txtbankGLCode.Text = "";
        lbl_bankname.Text = "";
        dd_currency.SelectedValue = "";
        txtExchangeRate.Text = "";
        txt_localbankCharges.Text = "";
        txtForeignBankCharges.Text = "";
        txt_fxbankchargesLC.Text = "";
        txt_chequedate.Text = "";
        txt_chequeNo.Text = "";
        clearLineBoxes();

    }
    
    protected void GdvBankList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GdvBankList.PageIndex = e.NewPageIndex;
       
        DataTable dt = cs.makelookupgridBank();

        GdvBankList.DataSource = dt;
        GdvBankList.DataBind();
        ModalPopupExtender2.Show();
    }
}