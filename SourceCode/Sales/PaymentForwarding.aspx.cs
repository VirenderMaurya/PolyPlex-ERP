using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Drawing;

public partial class Sales_PaymentForwarding : System.Web.UI.Page
{
    Common cmn = new Common();
    Common_Message objMsg = new Common_Message();
    Common_mst objCommon_mst = new Common_mst();
    PaymentForwarding cs = new PaymentForwarding();
    static string financial_year = "";
    static DataTable dtinvoiceavailable = new DataTable();
    static DataTable dtlineitems = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
            Label lblHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblHeader.Text = "Payment Forwarding";
            DataTable dt = cmn.fillSearch("126");
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
            txtToDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat, objCommon_mst.FormatProvider);
            fillCurrency(ddlcurrency);
            fillExpenses(ddlExpenses);
            txtFromDate.Attributes.Add("readonly", "readonly");
            txtToDate.Attributes.Add("readonly", "readonly");
            div_grids.Visible = false;
            txtToDate_CalendarExtender.EndDate = DateTime.Now;
            dtinvoiceavailable.Columns.Clear();
            dtlineitems.Columns.Clear();
            makeEmptyLineItemGrid();
            btnSave.CausesValidation = true;


        }



        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");


    }

    void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");

            if (ddsearch.SelectedValue == "")
            {
                string message = "Please select any search criteria.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            }
            else
            {
                SqlDataSource1.SelectCommand = cs.makeGrid(ddsearch.SelectedValue, txtSearch.Text.Trim());
                gridMaster.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
        }
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
            v_no = "VPF" + financialYear + v_series.ToString().PadLeft(5, '0');
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

            hf_vendorId.Value = GdvVendorList.SelectedDataKey.Values[0].ToString();

            txtcustomercode.Text = GdvVendorList.SelectedDataKey.Values[1].ToString();
            txtcustomercode.Enabled = false;
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
    protected void fillExpenses(DropDownList exp)
    {
        DataTable dt = cmn.getExpenses();
        exp.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                exp.Items.Add(new ListItem(row["expname"].ToString(), row["expid"].ToString()));
            }


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



    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        makegridInvoiceAvailable();

    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            string message = "Please select a from Date.";
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
        }
        else
        {
            makegridInvoiceAvailable();
        }
    }

    protected void gdv_Invoiceavailable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdv_Invoiceavailable.PageIndex = e.NewPageIndex;
        makegridInvoiceAvailable();
    }

    protected void makegridInvoiceAvailable()
    {
        div_grids.Visible = true;
        dtinvoiceavailable = cs.gridInvoiceAvailable(DateTime.Parse(txtFromDate.Text).ToShortDateString(), DateTime.Parse(txtToDate.Text).ToShortDateString());
        gdv_Invoiceavailable.DataSource = dtinvoiceavailable;
        gdv_Invoiceavailable.DataBind();
        //dtlineitems.Clear();
        Grid_lineItems.DataSource = dtlineitems;
        Grid_lineItems.DataBind();



    }
    protected void gdv_Invoiceavailable_SelectedIndexChanged(object sender, EventArgs e)
    {
        string inv_no = gdv_Invoiceavailable.SelectedDataKey.Values[1].ToString();
        foreach (GridViewRow oldrow in gdv_Invoiceavailable.Rows)
        {
            ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
            imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            oldrow.BackColor = Color.White;
        }
        ImageButton img = (ImageButton)gdv_Invoiceavailable.Rows[gdv_Invoiceavailable.SelectedIndex].FindControl("ImageButton1");
        img.ImageUrl = "~/Images/chkbxcheck.png";
        txtforInvoiceNo.Text = inv_no;
        hf_InvoiceId.Value = gdv_Invoiceavailable.SelectedDataKey.Values[0].ToString();
        hf_invoiceDate.Value = gdv_Invoiceavailable.SelectedRow.Cells[2].Text;



    }
    protected void btn_addline_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataRow rowLine = dtlineitems.NewRow();
            rowLine["Invoiceid"] = hf_InvoiceId.Value;
            rowLine["ExpenseType"] = ddlExpenses.SelectedValue;
            rowLine["BillNo"] = txtBillno.Text.Trim();
            rowLine["BillDate"] = txtBillDate.Text.ToString();
            rowLine["Currency"] = ddlcurrency.SelectedValue;
            rowLine["FxAmount"] = TxtAmountinFX.Text.Trim();
            rowLine["FxRate"] = txt_fxrate.Text.Trim();
            rowLine["AmtinUSD"] = txtAmountinUSD.Text.Trim();

            rowLine["InvoiceNo"] = txtforInvoiceNo.Text.Trim();
            rowLine["expname"] = ddlExpenses.SelectedItem.ToString();
            rowLine["CurrencyCode"] = ddlcurrency.SelectedItem.ToString();
            rowLine["InvoiceDate"] = hf_invoiceDate.Value;
            dtlineitems.Rows.Add(rowLine);
            Grid_lineItems.DataSource = dtlineitems;
            Grid_lineItems.DataBind();
            clearLineBoxes();
            string sortexpression = "Invoiceid=" + hf_InvoiceId.Value;
            dtinvoiceavailable = DeleteSingleRow(dtinvoiceavailable, sortexpression);
            gdv_Invoiceavailable.DataSource = dtinvoiceavailable;
            gdv_Invoiceavailable.DataBind();
            btnSave.CausesValidation = false;
        }
        catch { }
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




    protected void makeEmptyLineItemGrid()
    {
        dtlineitems.Columns.Add("Invoiceid");
        dtlineitems.Columns.Add("ExpenseType");
        dtlineitems.Columns.Add("BillNo");
        dtlineitems.Columns.Add("BillDate");
        dtlineitems.Columns.Add("Currency");
        dtlineitems.Columns.Add("FxAmount");
        dtlineitems.Columns.Add("FxRate");
        dtlineitems.Columns.Add("AmtinUSD");
        dtlineitems.Columns.Add("InvoiceNo");
        dtlineitems.Columns.Add("expname");
        dtlineitems.Columns.Add("CurrencyCode");
        dtlineitems.Columns.Add("InvoiceDate");
        Grid_lineItems.DataSource = dtlineitems;
        Grid_lineItems.DataBind();
    }

    protected void clearLineBoxes()
    {
        txtforInvoiceNo.Text = "";
        ddlExpenses.SelectedValue = "";
        ddlcurrency.SelectedValue = "";
        txtBillno.Text = "";
        txtBillDate.Text = "";
        TxtAmountinFX.Text = "";
        txt_fxrate.Text = "";
        txtAmountinUSD.Text = "";
        txt_totalAmount.Text = "";
    }


    protected void Grid_lineItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            string invoiceid = Grid_lineItems.DataKeys[e.RowIndex].Values["Invoiceid"].ToString();
            string expression = "Invoiceid=" + invoiceid;
            DataRow[] row = dtlineitems.Select(expression);
            DataRow invrow = dtinvoiceavailable.NewRow();
            invrow["Invoiceid"] = row[0]["Invoiceid"].ToString();
            invrow["InvoiceNo"] = row[0]["InvoiceNo"].ToString();
            invrow["InvoiceDate"] = row[0]["InvoiceDate"].ToString();
            dtinvoiceavailable.Rows.Add(invrow);
            gdv_Invoiceavailable.DataSource = dtinvoiceavailable;
            gdv_Invoiceavailable.DataBind();

            string sortexpression = "Invoiceid=" + invoiceid;
            dtlineitems = DeleteSingleRow(dtlineitems, sortexpression);
            Grid_lineItems.DataSource = dtlineitems;
            Grid_lineItems.DataBind();

        }

        catch (Exception ex) { }

    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (cs.saveRecords(dtlineitems, DateTime.Parse(txtvoucherdate.Text), financial_year, int.Parse(hf_vendorId.Value), txtRemarks.Text, Session["UserID"].ToString(), DateTime.Now.Date.ToString(), DateTime.Now.Date.ToString()))
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

        txtcustomercode.Text = "";
        txtRemarks.Text = "";
        financial_year = getFinancialYear();
        txtVoucherno.Text = AutogenerateVoucherNo(financial_year);
        txtVoucherno.Enabled = false;
        txtvoucherdate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat, objCommon_mst.FormatProvider);
        txtToDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat, objCommon_mst.FormatProvider);
        txtFromDate.Attributes.Add("readonly", "readonly");
        txtToDate.Attributes.Add("readonly", "readonly");
        div_grids.Visible = false;
        txtToDate_CalendarExtender.EndDate = DateTime.Now;
        dtinvoiceavailable.Columns.Clear();
        dtlineitems.Columns.Clear();
        makeEmptyLineItemGrid();
        btnSave.CausesValidation = true;

    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string vchrId = gridMaster.SelectedDataKey.Value.ToString();
            DataTable headerDt = cs.getHeaderInfo(vchrId);
            txtVoucherno.Text = headerDt.Rows[0]["vchrNo"].ToString();
            txtvoucherdate.Text = headerDt.Rows[0]["vchrDate"].ToString();
            txtcustomercode.Text = headerDt.Rows[0]["VendorCode"].ToString();
            txtRemarks.Text = headerDt.Rows[0]["Remarks"].ToString();
            hf_vendorId.Value = headerDt.Rows[0]["VendorId"].ToString();
            dtlineitems.Clear();
            DataTable lineDt = cs.getLineInfo(vchrId);
            if (lineDt.Rows.Count > 0)
            {
                foreach (DataRow row in lineDt.Rows)
                {
                    DataRow newrow = dtlineitems.NewRow();
                    newrow["Invoiceid"] = row["Invoiceid"].ToString();
                    newrow["ExpenseType"] = row["ExpenseType"].ToString();
                    newrow["BillNo"] = row["BillNo"].ToString();
                    newrow["BillDate"] = row["BillDate"].ToString();
                    newrow["Currency"] = row["Currency"].ToString();
                    newrow["FxAmount"] = row["FxAmount"].ToString();
                    newrow["FxRate"] = row["FxRate"].ToString();
                    newrow["AmtinUSD"] = row["AmtinUSD"].ToString();
                    newrow["InvoiceNo"] = row["InvoiceNo"].ToString();
                    newrow["expname"] = row["expname"].ToString();
                    newrow["CurrencyCode"] = row["CurrencyCode"].ToString();
                    newrow["InvoiceDate"] = row["InvoiceDate"].ToString();
                    dtlineitems.Rows.Add(newrow);
                    
                    
                }
                Grid_lineItems.DataSource = dtlineitems;
                Grid_lineItems.DataBind();
                clearLineBoxes();
                div_grids.Visible = true;
            }




        }
        catch (Exception ex)
        {
        }
    }
    
}