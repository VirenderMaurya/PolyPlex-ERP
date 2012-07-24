using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_transaction_PostExpenseforwarding : System.Web.UI.Page
{

    #region Define Global variable
    string logmessage = "";
    Common com = new Common();
    FA_PostExpenseForwarding objpostexpense = new FA_PostExpenseForwarding();
    BLLCollection<FA_PostExpenseForwarding> colpostexpense = new BLLCollection<FA_PostExpenseForwarding>();
    FA_VoucherType objVoucherType = new FA_VoucherType();
    BLLCollection<FA_VoucherType> col = new BLLCollection<FA_VoucherType>();
    BLLCollection<FA_VoucherSeries> colseries = new BLLCollection<FA_VoucherSeries>();
    FA_VoucherSeries objVoucherSeries = new FA_VoucherSeries();
    Common_Message commessage = new Common_Message();
    #endregion

    #region PageLoad event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                BindExpenseForwarding("0");
                BindSearchDropDown("54");
                readonlycontrols();
                Log.PageHeading(this, "Post Expense forwarding");
                BindVoucherType();
                BindVoucherSeries();
                Log.GetLog().FillFinancialYear(TxtVoucherYear);
            }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "Post Expense forwarding Form- Page_Load - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region bind functions

    private void BindMasterSearchBox()
    {
        try
        {
            ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
            btn_add.Click += new ImageClickEventHandler(btn_add_Click);
            btn_add.CausesValidation = false;
            ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
            btn_search.CausesValidation = false;
            btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        }
        catch (Exception ex)
        {
            logmessage = "Post Expense forwarding Form- BindMasterSearchBox Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void readonlycontrols()
    {
        TxtVoucherNo.Attributes.Add("readonly", "true");
        TxtVoucherDate.Attributes.Add("readonly", "true");
        TxtVoucherYear.Attributes.Add("readonly", "true");
        Txtforwardingno.Attributes.Add("readonly", "true");
    }
    private void BindSearchDropDown(string formid)
    {
        try
        {
            DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
            DataTable dt = com.fillSearch(formid);
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Post Expense forwarding - BindSearchDropDown Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void GetAllBillNo(string billno)
    {
        try
        {
            colpostexpense = objpostexpense.BindBillNo(billno);
            gridMaster.Visible = true;
            gridMaster.DataSource = colpostexpense;
            gridMaster.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- GetAllBillNo - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindExpenseVoucherId(string voucherid)
    {
        try
        {
            //colpostexpense = objpostexpense.BindVoucherId(voucherid);
            //GdvExpenseVoucherList.DataSource = colpostexpense;
            //GdvExpenseVoucherList.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Expense forwarding Form- (BindExpenseVoucherId) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindExpense_By_BillNo(string billno)
    {
        try
        {
            colpostexpense = objpostexpense.BindByBillNo(billno);
            GdvExpenseforwarding.DataSource = colpostexpense;
            GdvExpenseforwarding.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Expense forwarding Form- (BindExpense_By_BillNo) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindVoucherType()
    {
        try
        {
            col = objVoucherType.Get_VoucherType();
            DdlVoucherType.DataSource = col;
            DdlVoucherType.DataTextField = "VoucherType";
            DdlVoucherType.DataValueField = "Id";
            DdlVoucherType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlVoucherType.Items.Add(item);
            DdlVoucherType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Post-expense forwarding Form-BindVoucherType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindVoucherSeries()
    {
        try
        {
            colseries = objVoucherSeries.Get_VoucherSeries();
            DdlVoucherSeries.DataSource = colseries;
            DdlVoucherSeries.DataTextField = "VoucherSeries";
            DdlVoucherSeries.DataValueField = "Id";
            DdlVoucherSeries.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlVoucherSeries.Items.Add(item);
            DdlVoucherSeries.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Post expense forwarding Form-BindVoucherSeries -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindExpenseForwarding(string voucherid)
    {
        try
        {
            colpostexpense = objpostexpense.GetExpenseForwarding(voucherid);
            GdvExpenseforwarding.DataSource = colpostexpense;
            GdvExpenseforwarding.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Post expense forwarding Form- BindExpenseForwarding  -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void MakeDefaultMasterDrop()
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        ddl.SelectedValue = "";
    }
    #endregion
    
    #region button click events
    private void ClearField()
    {
        try
        {
            BindExpenseForwarding("0");
            DdlVoucherSeries.SelectedValue = "0";
            DdlVoucherType.SelectedValue = "0";
            Txtforwardingno.Text = "";
            TxtVoucherNo.Text = "";
            Log.GetLog().FillFinancialYear(TxtVoucherYear);
        }
        catch (Exception ex)
        {
            logmessage = "Post Expense forwarding Form- ClearField - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ClearField();
        }
        catch (Exception ex)
        {
            logmessage = "Post Expense forwarding Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
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
                if (ddsearch.SelectedItem.Value == "BillNo")
                {
                    lSearchList.Text = "Search by Bill No";
                    string Billno = txtSearch.Text.Trim();
                    txtSearch.Text = Billno;
                    ViewState["Billno"] = Billno;
                    GdvExpenseVoucherList.Visible = false;
                    GetAllBillNo(Billno);
                }
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            logmessage = "Post Expense forwarding Form- btn_search_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            if (ddlSearch.SelectedItem.Value == "BillNo")
            {
                lSearchList.Text = "Search by Bill No";
                GdvExpenseVoucherList.Visible = false;
                GetAllBillNo(txtSearchList.Text.Trim());
            }
            if (HidPopUpType.Value == "expenselist")
            {
                lSearchList.Text = "Search by Voucher Id";
                BindExpenseVoucherId(txtSearchList.Text.Trim());
            }
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Post-PreDefined Form- btnSearchlist_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            string voucherid = "";
            int inserted = 0, updated = 0;
            string vouchertype = DdlVoucherType.SelectedValue;
            string voucherseries = DdlVoucherSeries.SelectedValue;
            string voucheryear = TxtVoucherYear.Text;
            string voucherdate = TxtVoucherDate.Text;
            bool check = false;
            foreach (GridViewRow row in GdvExpenseforwarding.Rows)
            {
                CheckBox chkbx = (CheckBox)(row.FindControl("chkbx"));

                if (chkbx.Checked)
                {
                    check = true;
                    voucherid = ((Label)row.FindControl("lblvrid")).Text;
                    string lineitemid = ((Label)row.FindControl("lblitemid")).Text;
                    //string invoiceid= row.Cells[2].ToString();
                    //string expensetype= row.Cells[3].ToString();
                    //string billno= row.Cells[4].ToString();
                    //string billdate= row.Cells[5].ToString();
                    //string fyear= row.Cells[6].ToString();
                    //string remarks= row.Cells[7].ToString();
                    //string currency= row.Cells[8].ToString();
                    //string foreignexchangeamt= row.Cells[9].ToString();
                    //string foreignexchangerate= row.Cells[10].ToString();
                    //string amountusd= row.Cells[11].ToString();
                    inserted = objpostexpense.insertexpenseforwarding(voucherid, vouchertype, voucherseries, voucheryear, voucherdate, Session["userid"].ToString(), lineitemid);
                    if (inserted == 1)
                    {
                        #region update header table to make that voucherid inactive means vr id has been sent for payment
                        updated = objpostexpense.updateexpenseforwarding(voucherid, lineitemid);
                        #endregion
                    }
                }
            }
            if (check == false)
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please select atleast one record", 125, 300);
                return;
            }
            if (updated == 1)
            {
                BindExpenseForwarding(ViewState["vid"].ToString());
                ClearField();
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordSaved, 125, 300);
                return;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Post Expense forwarding Form- Btnsave_Click - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MakeDefaultMasterDrop();
            lSearchList.Text = "Search by VoucherId";
            HidPopUpType.Value = "expenselist";
            gridMaster.Visible = false;
            GdvExpenseVoucherList.Visible = true;
            BindExpenseVoucherId("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Expense forwarding Form- (ImgBtnCode_Click)searching for Vendor  -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion

    #region Grid events
    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            gridMaster.PageIndex = e.NewPageIndex;
            GetAllBillNo("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Post Expense forwarding Form- gridMaster_PageIndexChanging - Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVoucherList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int index = GdvExpenseVoucherList.SelectedIndex;
            Txtforwardingno.Text = ((Label)(GdvExpenseVoucherList.Rows[index].FindControl("lblvoucherno"))).Text.ToString();
            string voucherid = ((Label)(GdvExpenseVoucherList.Rows[index].FindControl("lblid"))).Text.ToString();
            ViewState["vid"] = voucherid;
            BindExpenseForwarding(voucherid);
        }
        catch (Exception ex)
        {
            logmessage = "Expense forwarding Form- (GdvVoucherList_SelectedIndexChanged) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string DataKey = gridMaster.SelectedDataKey.Values[1].ToString();
            BindExpense_By_BillNo(DataKey);
        }
        catch (Exception ex)
        {
            logmessage = "Expense forwarding Form- (gridMaster_SelectedIndexChanged) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVoucherList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvExpenseVoucherList.PageIndex = e.NewPageIndex;
            BindExpenseVoucherId("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Expense forwarding Form- (GdvVoucherList_PageIndexChanging) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    #endregion
     
}
