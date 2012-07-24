using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Finance_VendorMaster : System.Web.UI.Page
{

    MasterVendor cs = new MasterVendor();
    Common cmn = new Common();
    Common_Message objMsg = new Common_Message();
    static DataTable dtAccountingitems = new DataTable();
    static DataTable dtPurchaseitems = new DataTable();
    static int iFlag = 0;



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
                DropDownList ddl = (DropDownList)Master.FindControl("dd_search");
                DataTable dt = cmn.fillSearch("155");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));


                    }
                }

                fillAllDD();
                makeEmptydtAccountingItem();
                makeEmptydtPurchaseItem();
                TabContCustomer.ActiveTabIndex = 0;
                cs.refreshVendorDetails();
                int cid = cs.getPositionID(iFlag);
                fillDataToForm(cid);
                btn_save.Visible = false;
                btn_cancel.Visible = false;
                btn_nxt.Visible = true;
                btn_pre.Visible = true;
                btn_addPurchaseInfo.Visible = false;
                btnAddAccountingDetails.Visible = false;
                hf_isNewRecord.Value = "false";
                EnableAllControls(false);


            }
        }
        ImageButton btn_add = (ImageButton)Master.FindControl("btn_Add");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;
        ImageButton btn_Edit = (ImageButton)Master.FindControl("btn_Edit");
        btn_Edit.Click += new ImageClickEventHandler(btn_Edit_Click);
        btn_Edit.CausesValidation = false;
        ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
        btn_Search.Click += new ImageClickEventHandler(btn_Search_Click);
        btn_Search.CausesValidation = false;

    }

    void btn_Search_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddsearch = (DropDownList)Master.FindControl("dd_search");
        TextBox txtSearch = (TextBox)Master.FindControl("txt_search");
        DataTable dt = cs.searchResults(ddsearch.SelectedValue, txtSearch.Text.Trim());
        gridMaster.DataSource = dt;
        gridMaster.DataBind();
        ModalPopupExtender1.Show();
    }
    void btn_Edit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            string[] usrright = cmn.getUserRights(Session["UserID"].ToString(), "59");
            if (usrright[2] == "0")
            {
                string message = objMsg.RightsToModify;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, message, 125, 300);
            }
            else
            {

                btn_save.Visible = true;
                btn_cancel.Visible = true;
                btn_nxt.Visible = false;
                btn_pre.Visible = false;
                btn_addPurchaseInfo.Visible = true;
                btnAddAccountingDetails.Visible = true;
                int cid = int.Parse(hf_Cid.Value);
                fillDataToForm(cid);
                EnableAllControls(true);
                ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
                btn_Search.Enabled = false;
                hf_isNewRecord.Value = "false";
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gridAccountingLine_SelectedIndexChanged(object sender, EventArgs e)
    {

        int DataKey = int.Parse(gridAccountingLine.SelectedDataKey.Value.ToString());
        displayaccountingRecord(DataKey);

        foreach (GridViewRow oldrow in gridAccountingLine.Rows)
        {
            ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgAccgridsel");
            imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            oldrow.BackColor = Color.White;
        }
        ImageButton img = (ImageButton)gridAccountingLine.Rows[gridAccountingLine.SelectedIndex].FindControl("imgAccgridsel");
        img.ImageUrl = "~/Images/chkbxcheck.png";

        if (btnAddAccountingDetails.Visible == true)
        {
            dtAccountingitems = DeleteSingleRow(dtAccountingitems, "ID=" + DataKey);
            gridAccountingLine.DataSource = dtAccountingitems;
            gridAccountingLine.DataBind();
        }

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

    protected void displayaccountingRecord(int Id)
    {

        string expression = "ID=" + Id;
        DataRow[] selRow = dtAccountingitems.Select(expression);
        txtAccountingUnit.Text = selRow[0]["AccountingUnit"].ToString();
        txtVendorBank.Text = selRow[0]["VendorBank"].ToString();
        txtVendorBankCountry.Text = selRow[0]["VendorBankCountry"].ToString();
        txtVendorBankKey.Text = selRow[0]["VendorBankKey"].ToString();
        txtVendorBankAccount.Text = selRow[0]["VendorBankAccount"].ToString();
        txtAccountHolder.Text = selRow[0]["AccountHolder"].ToString();
        txtVendorRecoAcc.Text = selRow[0]["VendorRecoAccount"].ToString();
        txtDebitGLCode.Text = selRow[0]["DebitGLCode"].ToString();

    }

    void btn_add_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            string[] usrright = cmn.getUserRights(Session["UserID"].ToString(), "59");
            if (usrright[1] == "0")
            {
                string message = objMsg.RightsToWrite;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, message, 125, 300);
            }
            else
            {
                hf_isNewRecord.Value = "true";
                clearAll();
                txtVendorCode.Text = cs.getVendorCode();
                hf_Cid.Value = "";
                btn_save.Visible = true;
                btn_cancel.Visible = true;
                btn_nxt.Visible = false;
                btn_pre.Visible = false;
                btn_addPurchaseInfo.Visible = true;
                btnAddAccountingDetails.Visible = true;
                EnableAllControls(true);
                ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
                btn_Search.Enabled = false;
                dtPurchaseitems.Clear();
                dtAccountingitems.Clear();
                gridAccountingLine.DataSource = dtAccountingitems;
                gridAccountingLine.DataBind();
                gridPurLine.DataSource = dtPurchaseitems;
                gridPurLine.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void fillDataToForm(int c)
    {
        clearAll();
        displayDetailsRecord(c);
        hf_Cid.Value = c.ToString();
        DataTable dtacc = cs.getVendorAccounting(c.ToString());
        dtAccountingitems.Clear();
        if (dtacc.Rows.Count > 0)
        {
            foreach (DataRow r in dtacc.Rows)
            {
                AddRowtoAccountingLine(r);
            }
        }

        gridAccountingLine.DataSource = dtAccountingitems;
        gridAccountingLine.DataBind();
        DataTable dtsal = cs.getVendorPurchase(c.ToString());
        dtPurchaseitems.Clear();
        if (dtsal.Rows.Count > 0)
        {
            foreach (DataRow r in dtsal.Rows)
            {
                AddRowtoPurchaseLine(r);
            }
        }

        gridPurLine.DataSource = dtPurchaseitems;
        gridPurLine.DataBind();

    }

    protected void AddRowtoAccountingLine(DataRow r)
    {
        try
        {
            DataRow newrow = dtAccountingitems.NewRow();
            newrow["ID"] = r["SeriesNo"];
            newrow["AccountingUnit"] = r["AccountingUnit"];
            newrow["VendorBank"] = r["VendorBank"];
            newrow["VendorBankCountry"] = r["VendorBankCountry"];
            newrow["VendorBankKey"] = r["VendorBankKey"];
            newrow["VendorBankAccount"] = r["VendorBankAccount"];
            newrow["AccountHolder"] = r["AccountHolder"];
            newrow["VendorRecoAccount"] = r["VendorRecoAccount"];
            newrow["DebitGLCode"] = r["DebitGLCode"];
            dtAccountingitems.Rows.Add(newrow);
        }
        catch (Exception ex)
        {
        }

       
    }

    protected void btnAddAccountingDetails_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataRow newrow = dtAccountingitems.NewRow();
            newrow["ID"] = getSnoAccLine();
            newrow["AccountingUnit"] = txtAccountingUnit.Text;
            newrow["VendorBank"] = txtVendorBank.Text;
            newrow["VendorBankCountry"] = txtVendorBankCountry.Text;
            newrow["VendorBankKey"] = txtVendorBankKey.Text;
            newrow["VendorBankAccount"] = txtVendorBankAccount.Text;
            newrow["AccountHolder"] = txtAccountHolder.Text;
            newrow["VendorRecoAccount"] = txtAccountHolder.Text;
            newrow["DebitGLCode"] = txtAccountHolder.Text;
            dtAccountingitems.Rows.Add(newrow);
            gridAccountingLine.DataSource = dtAccountingitems;
            gridAccountingLine.DataBind();
            clearAccountingLine();

        }
        catch (Exception ex)
        {
        }

    }

    protected void gridPurLine_SelectedIndexChanged(object sender, EventArgs e)
    {


        int DataKey = int.Parse(gridPurLine.SelectedDataKey.Value.ToString());
        displaySaleRecord(DataKey);

        foreach (GridViewRow oldrow in gridPurLine.Rows)
        {
            ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgSelect");
            imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            oldrow.BackColor = Color.White;
        }
        ImageButton img = (ImageButton)gridPurLine.Rows[gridPurLine.SelectedIndex].FindControl("imgSelect");
        img.ImageUrl = "~/Images/chkbxcheck.png";
        if (btn_addPurchaseInfo.Visible == true)
        {
            dtPurchaseitems = DeleteSingleRow(dtPurchaseitems, "ID=" + DataKey);
            gridPurLine.DataSource = dtPurchaseitems;
            gridPurLine.DataBind();
        }
    }

    protected void displaySaleRecord(int Id)
    {

        string expression = "ID=" + Id;
        DataRow[] selRow = dtPurchaseitems.Select(expression);


        ddPurchaseArea.SelectedValue = selRow[0]["PurchaseArea"].ToString();

        ddPaymentsTerms.SelectedValue = selRow[0]["PaymentTerms"].ToString();
        txtincoterms.Text = selRow[0]["IncoTerm"].ToString();
        ddCurrency.SelectedValue = selRow[0]["ORDCurrency"].ToString();
        txtItexid.Text = selRow[0]["ITexID"].ToString();
        txtnearestseaport.Text = selRow[0]["NearestSeaPort"].ToString();
        txtnearestairport.Text = selRow[0]["NearestAirPort"].ToString();
        txtVatinPer.Text = selRow[0]["VATInPercentage"].ToString();

      

    }



    protected int getSnoAccLine()
    {
        try
        {
            if (dtAccountingitems.Rows.Count > 0)
            {
                string expression = "ID = MAX(ID)";
                DataRow[] maxrow = dtAccountingitems.Select(expression);
                int maxid = int.Parse(maxrow[0]["ID"].ToString());
                return maxid + 1;
            }
            else
            {
                return 1;
            }
        }
        catch (Exception ex)
        {
            return 1;
        }
    }

    protected int getSnoSaleLine()
    {
        try
        {
            if (dtPurchaseitems.Rows.Count > 0)
            {
                string expression = "ID = MAX(ID)";
                DataRow[] maxrow = dtPurchaseitems.Select(expression);
                int maxid = int.Parse(maxrow[0]["ID"].ToString());
                return maxid + 1;
            }
            else
            {
                return 1;
            }
        }
        catch (Exception ex)
        {
            return 1;
        }
    }

    protected void AddRowtoPurchaseLine(DataRow r)
    {
        DataRow newrow = dtPurchaseitems.NewRow();
        newrow["ID"] = r["SeriesNo"];
        newrow["PurchaseArea"] = r["PurchaseArea"];
        newrow["PaymentTerms"] = r["PaymentTerms"];
        newrow["IncoTerm"] = r["IncoTerm"];
        newrow["ORDCurrency"] = r["ORDCurrency"];
        newrow["ITexID"] = r["ITexID"];
        newrow["NearestSeaPort"] = r["NearestSeaPort"];
        newrow["NearestAirPort"] = r["NearestAirPort"];
        newrow["VATInPercentage"] = r["VATInPercentage"];

        newrow["CurrencyCode"] = r["CurrencyCode"];
        newrow["PurchaseAreaDesc"] = r["PurchaseAreaDesc"];
        newrow["PaymentTermDesc"] = r["PaymentTermDesc"];
        dtPurchaseitems.Rows.Add(newrow);
    }

    protected void displayDetailsRecord(int Id)
    {
        try
        {

            string expression = "VendorId=" + Id;
            DataRow[] selRow = cs.getVendorDetailsTable().Select(expression);


            txtVendorCode.Text = selRow[0]["VendorCode"].ToString();
            ddvendorGroup.SelectedValue = selRow[0]["VendorGroup"].ToString();
            txtVendorName.Text = selRow[0]["VendorName"].ToString();
            txtVendorAddress.Text = selRow[0]["VendorAddress"].ToString();
            txtPostalCode.Text = selRow[0]["PostalCode"].ToString();
            txtCity.Text = selRow[0]["City"].ToString();
            txtCountry.Text = selRow[0]["Country"].ToString();
            txtRegion.Text = selRow[0]["Region"].ToString();
            TxtTelephoneNo.Text = selRow[0]["TelephoneNo"].ToString();
            txtTelephoneExtn.Text = selRow[0]["TelephoneExtn"].ToString();
            txtFaxNo.Text = selRow[0]["FAXNo"].ToString();
            txtFaxExtn.Text = selRow[0]["FAXExtn"].ToString();
            txtEmailaddd1.Text = selRow[0]["CompanyEmailAddress1"].ToString();
            txtEmailaddd2.Text = selRow[0]["CompanyEmailAddress2"].ToString();
            txtContactPerson1.Text = selRow[0]["ContactPersonOne"].ToString();
            txtperson1no.Text = selRow[0]["ContactPersonOneContactNo"].ToString();
            txtContactPerson2.Text = selRow[0]["ContactPersonTwo"].ToString();
            txtperson2no.Text = selRow[0]["ContactPersonTwoContactNo"].ToString();
            txtOldfivendorcode.Text = selRow[0]["OldFIVendorCode"].ToString();
            txtTypeCompany.Text = selRow[0]["TypeCompany"].ToString();
        }
        catch (Exception ex)
        {
        }

    }
    protected void clearAll()
    {
        clearDetails();
        clearPurchaseLine();
        clearAccountingLine();
    }

    protected void clearAccountingLine()
    {
        txtAccountingUnit.Text = "";
        txtVendorBank.Text = "";
        txtVendorBankCountry.Text = "";
        txtVendorBankKey.Text = "";
        txtVendorBankAccount.Text = "";
        txtAccountHolder.Text = "";
        txtVendorRecoAcc.Text = "";
        txtDebitGLCode.Text = "";
    }

    protected void clearPurchaseLine()
    {
        ddPurchaseArea.SelectedValue = "";

        ddPaymentsTerms.SelectedValue = "";
        txtincoterms.Text = "";
        ddCurrency.Text = "";
        txtItexid.Text = "";
        txtnearestseaport.Text = "";
        txtnearestairport.Text = "";
        txtVatinPer.Text = "";

    }

    protected void clearDetails()
    {
        txtVendorCode.Text = "";
        ddvendorGroup.SelectedValue = "";
        txtVendorName.Text = "";
        txtVendorAddress.Text = "";
        txtPostalCode.Text = "";
        txtCity.Text = "";
        txtCountry.Text = "";
        txtRegion.Text = "";
        TxtTelephoneNo.Text = "";
        txtTelephoneExtn.Text = "";
        txtFaxNo.Text = "";
        txtFaxExtn.Text = "";
        txtEmailaddd1.Text = "";
        txtEmailaddd2.Text = "";
        txtContactPerson1.Text = "";
        txtperson1no.Text = "";
        txtContactPerson2.Text = "";
        txtperson2no.Text = "";
        txtOldfivendorcode.Text = "";
        txtTypeCompany.Text = "";


    }

    protected void makeEmptydtPurchaseItem()
    {
        dtPurchaseitems.Columns.Clear();
        dtPurchaseitems.Columns.Add("ID");
        dtPurchaseitems.Columns.Add("PurchaseArea");
        dtPurchaseitems.Columns.Add("PaymentTerms");
        dtPurchaseitems.Columns.Add("IncoTerm");
        dtPurchaseitems.Columns.Add("ORDCurrency");
        dtPurchaseitems.Columns.Add("ITexID");
        dtPurchaseitems.Columns.Add("NearestSeaPort");
        dtPurchaseitems.Columns.Add("NearestAirPort");
        dtPurchaseitems.Columns.Add("VATInPercentage");

        dtPurchaseitems.Columns.Add("CurrencyCode");
        dtPurchaseitems.Columns.Add("PurchaseAreaDesc");
        dtPurchaseitems.Columns.Add("PaymentTermDesc");

    }

    protected void makeEmptydtAccountingItem()
    {
        dtAccountingitems.Columns.Clear();
        dtAccountingitems.Columns.Add("ID");
        dtAccountingitems.Columns.Add("AccountingUnit");
        dtAccountingitems.Columns.Add("VendorBank");
        dtAccountingitems.Columns.Add("VendorBankCountry");
        dtAccountingitems.Columns.Add("VendorBankKey");
        dtAccountingitems.Columns.Add("VendorBankAccount");
        dtAccountingitems.Columns.Add("AccountHolder");
        dtAccountingitems.Columns.Add("VendorRecoAccount");
        dtAccountingitems.Columns.Add("DebitGLCode");


       

    }

    private void EnableAllControls(bool status)
    {

        foreach (Control ctrl in pnl_general.Controls)
            if (ctrl is TextBox)

                ((TextBox)ctrl).Enabled = status;

            else if (ctrl is CheckBox)

                ((CheckBox)ctrl).Enabled = status;

            else if (ctrl is DropDownList)

                ((DropDownList)ctrl).Enabled = status;

        foreach (Control ctrl in pnl_accounting.Controls)
            if (ctrl is TextBox)

                ((TextBox)ctrl).Enabled = status;

            else if (ctrl is CheckBox)

                ((CheckBox)ctrl).Enabled = status;

            else if (ctrl is DropDownList)

                ((DropDownList)ctrl).Enabled = status;

        foreach (Control ctrl in pnl_purchase.Controls)
            if (ctrl is TextBox)

                ((TextBox)ctrl).Enabled = status;

            else if (ctrl is CheckBox)

                ((CheckBox)ctrl).Enabled = status;

            else if (ctrl is DropDownList)

                ((DropDownList)ctrl).Enabled = status;

        txtVendorCode.Enabled = false;
       

    }


    protected void fillAllDD()
    {
        fillCurrency(ddCurrency);
        fillVendorGroup(ddvendorGroup);
        fillPurchaseArea(ddPurchaseArea);
        fillPaymentTerms(ddPaymentsTerms);

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


    protected void fillPurchaseArea(DropDownList curr)
    {
        DataTable dt = cs.getPurchaseArea();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["PurchaseAreaDesc"].ToString(), row["AutoId"].ToString()));
            }


        }
    }


    protected void fillVendorGroup(DropDownList curr)
    {
        DataTable dt = cs.getVendorGroup();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["GroupDesc"].ToString(), row["Id"].ToString()));
            }


        }
    }
    protected void fillPaymentTerms(DropDownList curr)
    {
        DataTable dt = cs.getPaymentTerms();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["PaymentTermDesc"].ToString(), row["PaymentsTermsID"].ToString()));
            }


        }
    }

    protected void btn_nxt_Click(object sender, ImageClickEventArgs e)
    {

        iFlag = iFlag + 1;
        int cid = cs.getPositionID(iFlag);
        if (cid != 0)
        {
            btn_pre.ImageUrl = "~/Images/btn_previous.png";
            btn_pre.Enabled = true;

            fillDataToForm(cid);
        }
        else
        {
            iFlag = iFlag - 1;
            btn_nxt.ImageUrl = "~/Images/btnNextGrey.png";
            btn_nxt.Enabled = false;
        }
        TabContCustomer.ActiveTabIndex = 0;

    }

    protected void btn_pre_Click(object sender, ImageClickEventArgs e)
    {
        iFlag = iFlag - 1;
        int cid = cs.getPositionID(iFlag);
        if (cid != 0)
        {
            btn_nxt.ImageUrl = "~/Images/btn_next.png";
            btn_nxt.Enabled = true;
            fillDataToForm(cid);
        }
        else
        {
            iFlag = iFlag + 1;
            btn_pre.ImageUrl = "~/Images/btnPreviousGrey.png";
            btn_pre.Enabled = false;
        }
        TabContCustomer.ActiveTabIndex = 0;


    }

    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        int DataKey = int.Parse(gridMaster.SelectedDataKey.Value.ToString());
        fillDataToForm(DataKey);
        hf_Cid.Value = DataKey.ToString();


    }

    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridMaster.PageIndex = e.NewPageIndex;
        DropDownList ddsearch = (DropDownList)Master.FindControl("dd_search");
        TextBox txtSearch = (TextBox)Master.FindControl("txt_search");
        DataTable dt = cs.searchResults(ddsearch.SelectedValue, txtSearch.Text.Trim());
        gridMaster.DataSource = dt;
        gridMaster.DataBind();
        ModalPopupExtender1.Show();

    }
    protected void btn_addPurchaseInfo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataRow newrow = dtPurchaseitems.NewRow();
            newrow["ID"] = getSnoSaleLine();
            newrow["PurchaseArea"] = ddPurchaseArea.SelectedValue;
            newrow["PaymentTerms"] = ddPaymentsTerms.SelectedValue;
            newrow["IncoTerm"] = txtincoterms.Text;
            newrow["ORDCurrency"] = ddCurrency.SelectedValue;
            newrow["ITexID"] = txtItexid.Text;
            newrow["NearestSeaPort"] = txtnearestseaport.Text;
            newrow["NearestAirPort"] = txtnearestairport.Text;
            newrow["VATInPercentage"] = txtVatinPer.Text;


            newrow["CurrencyCode"] = ddCurrency.SelectedItem.ToString();
            newrow["PurchaseAreaDesc"] = ddPurchaseArea.SelectedItem.ToString();
            newrow["PaymentTermDesc"] = ddPaymentsTerms.SelectedItem.ToString();
           

            dtPurchaseitems.Rows.Add(newrow);
            gridPurLine.DataSource = dtPurchaseitems;
            gridPurLine.DataBind();
            clearPurchaseLine();

        }
        catch (Exception ex)
        {
        }

    }

    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {

        if (dtAccountingitems.Rows.Count > 0 && dtPurchaseitems.Rows.Count > 0)
        {
            bool isSaved = false;
            if (hf_isNewRecord.Value == "true")
            {
                isSaved = cs.saveVendorMaster(ddvendorGroup.SelectedValue, txtVendorName.Text, txtVendorAddress.Text, txtPostalCode.Text, txtCity.Text, txtCountry.Text, txtRegion.Text, TxtTelephoneNo.Text,
            txtTelephoneExtn.Text, txtFaxNo.Text, txtFaxExtn.Text, txtEmailaddd1.Text, txtEmailaddd2.Text, txtContactPerson1.Text, txtperson1no.Text, txtContactPerson2.Text,
            txtperson2no.Text, txtOldfivendorcode.Text, txtTypeCompany.Text,Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider),
            Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider), "true", dtAccountingitems, dtPurchaseitems);
            }
            else if (hf_isNewRecord.Value == "false")
            {
                isSaved = cs.updateVendorMaster(hf_Cid.Value, txtVendorCode.Text.Trim(), ddvendorGroup.SelectedValue, txtVendorName.Text, txtVendorAddress.Text, txtPostalCode.Text, txtCity.Text, txtCountry.Text, txtRegion.Text, TxtTelephoneNo.Text,
            txtTelephoneExtn.Text, txtFaxNo.Text, txtFaxExtn.Text, txtEmailaddd1.Text, txtEmailaddd2.Text, txtContactPerson1.Text, txtperson1no.Text, txtContactPerson2.Text,
            txtperson2no.Text, txtOldfivendorcode.Text, txtTypeCompany.Text, Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider),
            Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider), "true", dtAccountingitems, dtPurchaseitems);

            }


            if (isSaved == true)
            {
                string message = objMsg.RecordSaved;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
                clearAll();
                TabContCustomer.ActiveTabIndex = 0;
                cs.refreshVendorDetails();
                iFlag = 0;
                int cid = cs.getPositionID(iFlag);
                fillDataToForm(cid);
                btn_save.Visible = false;
                btn_cancel.Visible = false;
                btn_nxt.Visible = true;
                btn_pre.Visible = true;
                btn_addPurchaseInfo.Visible = false;
                btnAddAccountingDetails.Visible = false;
                hf_isNewRecord.Value = "false";
                EnableAllControls(false);
                ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
                btn_Search.Enabled = true;



            }
            else
            {
                string message = objMsg.RecordNotSaved;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
            }
        }
        else
        {


            if (dtAccountingitems.Rows.Count <= 0)
            {
                string message = "Please add atleast one Accounting Information.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                TabContCustomer.ActiveTabIndex = 1;
            }
            else if (dtPurchaseitems.Rows.Count <= 0)
            {
                string message = "Please add atleast one Purchase Information.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
                TabContCustomer.ActiveTabIndex = 2;
            }


        }

    }
    protected void btn_cancel_Click(object sender, ImageClickEventArgs e)
    {
        if (hfConfirm.Value == "true")
        {
            //int Cid = getPositionID(iFlag);
            //displayDetailsRecord(Cid);

            hf_isNewRecord.Value = "false";
            TabContCustomer.ActiveTabIndex = 0;
            cs.refreshVendorDetails();
            int cid = cs.getPositionID(iFlag);
            fillDataToForm(cid);
            btn_save.Visible = false;
            btn_cancel.Visible = false;
            btn_nxt.Visible = true;
            btn_pre.Visible = true;
            btn_addPurchaseInfo.Visible = false;
            btnAddAccountingDetails.Visible = false;
            EnableAllControls(false);
            ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
            btn_Search.Enabled = true;
        }


    }



}