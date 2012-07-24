using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Sales_CustomerMaster : System.Web.UI.Page
{
    MastersCustomer cs = new MastersCustomer();
    Common cmn = new Common();
    Common_Message objMsg = new Common_Message();
    static DataTable dtAccountingitems = new DataTable();
    static DataTable dtSalesitems = new DataTable();
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
                DataTable dt = cmn.fillSearch("59");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));


                    }
                }

                fillAllDD();
                makeEmptydtAccountingItem();
                makeEmptydtSalesItem();
                TabContCustomer.ActiveTabIndex = 0;
                cs.refreshCustomerDetails();
                int cid = cs.getPositionID(iFlag);
                fillDataToForm(cid);
                btn_save.Visible = false;
                btn_cancel.Visible = false;
                btn_nxt.Visible = true;
                btn_pre.Visible = true;
                btn_addSaleInfo.Visible = false;
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
                btn_addSaleInfo.Visible = true;
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
    protected void fillAllDD()
    {
        fillCurrency(ddCurrency);
        fillCountry(ddCountry);
        fillCustomerType(ddcustomertype);
        fillSalesArea(ddSalesArea);
        fillSalesType(ddsalesType);
        fillFinalDestination(ddFinalDestination);
        fillPaymentTerms(ddPaymentsTerms);

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
                txtCustomerCode.Text = cs.getCustomerCode();
                hf_Cid.Value = "";
                btn_save.Visible = true;
                btn_cancel.Visible = true;
                btn_nxt.Visible = false;
                btn_pre.Visible = false;
                btn_addSaleInfo.Visible = true;
                btnAddAccountingDetails.Visible = true;
                EnableAllControls(true);
                ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
                btn_Search.Enabled = false;
                dtSalesitems.Clear();
                dtAccountingitems.Clear();
                gridAccountingLine.DataSource = dtAccountingitems;
                gridAccountingLine.DataBind();
                gridSalLine.DataSource = dtSalesitems;
                gridSalLine.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    ~Sales_CustomerMaster()
    {

    }

    protected void displayDetailsRecord(int Id)
    {

        string expression = "CustomerID=" + Id;
        DataRow[] selRow = cs.getCustomerDetailsTable().Select(expression);
        txtCustomerCode.Text = selRow[0]["CustomerCode"].ToString();
        txtName.Text = selRow[0]["Name"].ToString();
        txtAddress.Text = selRow[0]["Address"].ToString();
        ddCountry.SelectedValue = selRow[0]["Country"].ToString();
        txtRegion.Text = selRow[0]["Region"].ToString();
        txtTelephone.Text = selRow[0]["Telephone"].ToString();
        txtFax.Text = selRow[0]["Fax"].ToString();
        txtEmail.Text = selRow[0]["Email"].ToString();
        ddcustomertype.SelectedValue = selRow[0]["CustomerType"].ToString();
        txtApplication.Text = selRow[0]["Application"].ToString();
        txtContactPerson.Text = selRow[0]["ContactPerson"].ToString();
        txtDesignation.Text = selRow[0]["Designation"].ToString();
        txtDepartment.Text = selRow[0]["Department"].ToString();
        txtContactPerTelephone.Text = selRow[0]["CTelephone"].ToString();
        txtContactPerFax.Text = selRow[0]["CFax"].ToString();
        txtContactPerEmail.Text = selRow[0]["CEmail"].ToString();
        txtDOB.Text = selRow[0]["DOB"].ToString();
        txtAnniversary.Text = selRow[0]["Anniversary"].ToString();
        txtAccountDeptcont.Text = selRow[0]["AccountDeptCont"].ToString();
        txtAccountDeptEmail.Text = selRow[0]["AccountDeptEmail"].ToString();
        txtCreditLimit.Text = selRow[0]["CreditLimit"].ToString();
        txtEximLimit.Text = selRow[0]["EXIMLimit"].ToString();



    }

    protected void makeEmptydtAccountingItem()
    {
        dtAccountingitems.Columns.Clear();
        dtAccountingitems.Columns.Add("ID");
        dtAccountingitems.Columns.Add("AccountingUnit");
        dtAccountingitems.Columns.Add("CustomerBank");
        dtAccountingitems.Columns.Add("CustomerRecoAccount");
        dtAccountingitems.Columns.Add("CustomerBankCountry");
        dtAccountingitems.Columns.Add("CustomerBankKey");
        dtAccountingitems.Columns.Add("CustomerBankAccount");
        dtAccountingitems.Columns.Add("AccountHolder");
    }

    protected void makeEmptydtSalesItem()
    {
        dtSalesitems.Columns.Clear();
        dtSalesitems.Columns.Add("ID");
        dtSalesitems.Columns.Add("SalesArea");
        dtSalesitems.Columns.Add("SalesType");
        dtSalesitems.Columns.Add("Currency");
        dtSalesitems.Columns.Add("PaymentTerms");
        dtSalesitems.Columns.Add("LevelofTrade");
        dtSalesitems.Columns.Add("FinalDestination");
        dtSalesitems.Columns.Add("TermsOfDelivery");
        dtSalesitems.Columns.Add("Groups");
        dtSalesitems.Columns.Add("Fumination");
        dtSalesitems.Columns.Add("VAT");
        dtSalesitems.Columns.Add("QualityCertificate");
        dtSalesitems.Columns.Add("PaymentMode");
        dtSalesitems.Columns.Add("DeliveryTolerance");
        dtSalesitems.Columns.Add("CertificateOfOrg");
        dtSalesitems.Columns.Add("GSP");
        dtSalesitems.Columns.Add("CreditDays");
        dtSalesitems.Columns.Add("Legalization");
        dtSalesitems.Columns.Add("Packing");
        dtSalesitems.Columns.Add("Sticker");
        dtSalesitems.Columns.Add("InvoicingLength");
        dtSalesitems.Columns.Add("SalesOffice");
        dtSalesitems.Columns.Add("CustOwner");
        dtSalesitems.Columns.Add("PalletsStacking");
        dtSalesitems.Columns.Add("LengthTolerance");
        dtSalesitems.Columns.Add("AgentCode");
        dtSalesitems.Columns.Add("ShippingLinePreference");
        dtSalesitems.Columns.Add("PreShippingInspection");
        dtSalesitems.Columns.Add("PackingInstruction");
        dtSalesitems.Columns.Add("SpecialInstruction");
        dtSalesitems.Columns.Add("LocationID");


        dtSalesitems.Columns.Add("SalesAreaDesc");
        dtSalesitems.Columns.Add("SalesTypeName");
        dtSalesitems.Columns.Add("CurrencyCode");
        dtSalesitems.Columns.Add("PaymentTermDesc");
        dtSalesitems.Columns.Add("FinalDestCode");

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

    protected void btnAddAccountingDetails_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataRow newrow = dtAccountingitems.NewRow();
            newrow["ID"] = getSnoAccLine();
            newrow["AccountingUnit"] = txtAccountingUnit.Text;
            newrow["CustomerBank"] = txtCustomerBank.Text;
            newrow["CustomerRecoAccount"] = txtCustomerRecoAcc.Text;
            newrow["CustomerBankCountry"] = txtCustomerBankCountry.Text;
            newrow["CustomerBankKey"] = txtCustomerBankKey.Text;
            newrow["CustomerBankAccount"] = txtCustomerBankAccount.Text;
            newrow["AccountHolder"] = txtAccountHolder.Text;
            dtAccountingitems.Rows.Add(newrow);
            gridAccountingLine.DataSource = dtAccountingitems;
            gridAccountingLine.DataBind();
            clearAccountingLine();

        }
        catch (Exception ex)
        {
        }

    }

    

    protected void AddRowtoAccountingLine(DataRow r)
    {
        DataRow newrow = dtAccountingitems.NewRow();
        newrow["ID"] = r["SeriesNo"];
        newrow["AccountingUnit"] = r["AccountingUnit"];
        newrow["CustomerBank"] = r["CustomerBank"];
        newrow["CustomerRecoAccount"] = r["CustomerRecoAccount"];
        newrow["CustomerBankCountry"] = r["CustomerBankCountry"];
        newrow["CustomerBankKey"] = r["CustomerBankKey"];
        newrow["CustomerBankAccount"] = r["CustomerBankAccount"];
        newrow["AccountHolder"] = r["AccountHolder"];
        dtAccountingitems.Rows.Add(newrow);
    }

    protected void AddRowtoSalesLine(DataRow r)
    {
        DataRow newrow = dtSalesitems.NewRow();
        newrow["ID"] = r["SeriesNo"];
        newrow["SalesArea"] = r["SalesArea"];
        newrow["SalesType"] = r["SalesType"];
        newrow["Currency"] = r["Currency"];
        newrow["PaymentTerms"] = r["PaymentTerms"];
        newrow["LevelofTrade"] = r["LevelofTrade"];
        newrow["FinalDestination"] = r["FinalDestination"];
        newrow["TermsOfDelivery"] = r["TermsOfDelivery"];
        newrow["Groups"] = r["Groups"];
        newrow["Fumination"] = r["Fumination"];
        newrow["VAT"] = r["VAT"];
        newrow["QualityCertificate"] = r["QualityCertificate"];
        newrow["PaymentMode"] = r["PaymentMode"];
        newrow["DeliveryTolerance"] = r["DeliveryTolerance"];
        newrow["CertificateOfOrg"] = r["CertificateOfOrg"];
        newrow["GSP"] = r["GSP"];
        newrow["CreditDays"] = r["CreditDays"];
        newrow["Legalization"] = r["Legalization"];
        newrow["Packing"] = r["Packing"];
        newrow["Sticker"] = r["Sticker"];
        newrow["InvoicingLength"] = r["InvoicingLength"];
        newrow["SalesOffice"] = r["SalesOffice"];
        newrow["CustOwner"] = r["CustOwner"];
        newrow["PalletsStacking"] = r["PalletsStacking"];
        newrow["LengthTolerance"] = r["LengthTolerance"];
        newrow["AgentCode"] = r["AgentCode"];
        newrow["ShippingLinePreference"] = r["ShippingLinePreference"];
        newrow["PreShippingInspection"] = r["PreShippingInspection"];
        newrow["PackingInstruction"] = r["PackingInstruction"];
        newrow["SpecialInstruction"] = r["SpecialInstruction"];
        newrow["LocationID"] = r["LocationID"];

        newrow["SalesAreaDesc"] = r["SalesAreaDesc"];
        newrow["SalesTypeName"] = r["SalesTypeName"];
        newrow["CurrencyCode"] = r["CurrencyCode"];
        newrow["PaymentTermDesc"] = r["PaymentTermDesc"];
        newrow["FinalDestCode"] = r["FinalDestCode"];
        dtSalesitems.Rows.Add(newrow);
    }

    protected void clearAccountingLine()
    {
        txtAccountingUnit.Text = "";
        txtCustomerBank.Text = "";
        txtCustomerRecoAcc.Text = "";
        txtCustomerBankCountry.Text = "";
        txtCustomerBankKey.Text = "";
        txtCustomerBankAccount.Text = "";
        txtAccountHolder.Text = "";
    }

    protected void btn_addSaleInfo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataRow newrow = dtSalesitems.NewRow();
            newrow["ID"] = getSnoSaleLine();
            newrow["SalesArea"] = ddSalesArea.SelectedValue;
            newrow["SalesType"] = ddsalesType.SelectedValue;
            newrow["Currency"] = ddCurrency.SelectedValue;
            newrow["PaymentTerms"] = ddPaymentsTerms.SelectedValue;
            newrow["LevelofTrade"] = txtLevelOFTrade.Text;
            newrow["FinalDestination"] = ddFinalDestination.SelectedValue;
            newrow["TermsOfDelivery"] = txtTermsOfDelivery.Text;
            newrow["Groups"] = txtGroups.Text;
            newrow["Fumination"] = chkFumination.Checked.ToString();
            newrow["VAT"] = txtVAT.Text;
            newrow["QualityCertificate"] = chkQualityCertificate.Checked.ToString();
            newrow["PaymentMode"] = txtPaymentMode.Text;
            newrow["DeliveryTolerance"] = txtDeliveryTolerence.Text;
            newrow["CertificateOfOrg"] = chkCertificateOfOrg.Checked.ToString();
            newrow["GSP"] = chkGSP.Checked.ToString();
            newrow["CreditDays"] = txtCreditDays.Text;
            newrow["Legalization"] = txtLegalization.Text;
            newrow["Packing"] = txtPacking.Text;
            newrow["Sticker"] = txtSticker.Text;
            newrow["InvoicingLength"] = txtInvoiceLength.Text;
            newrow["SalesOffice"] = txtSalesOffice.Text;
            newrow["CustOwner"] = txtCustOwner.Text;
            newrow["PalletsStacking"] = txtPalletsStacking.Text;
            newrow["LengthTolerance"] = txtLengthTolerence.Text;
            newrow["AgentCode"] = txtAgentCode.Text;
            newrow["ShippingLinePreference"] = txtShippingLinePrefrnce.Text;
            newrow["PreShippingInspection"] = txtPreshippinginstructions.Text;
            newrow["PackingInstruction"] = txtPackingInstruction.Text;
            newrow["SpecialInstruction"] = txtSpInstruction.Text;
            newrow["LocationID"] = Session["Location"].ToString();

            newrow["SalesAreaDesc"] = ddSalesArea.SelectedItem.ToString();
            newrow["SalesTypeName"] = ddsalesType.SelectedItem.ToString();
            newrow["CurrencyCode"] = ddCurrency.SelectedItem.ToString();
            newrow["PaymentTermDesc"] = ddPaymentsTerms.SelectedItem.ToString();
            newrow["FinalDestCode"] = ddFinalDestination.SelectedItem.ToString();

            dtSalesitems.Rows.Add(newrow);
            gridSalLine.DataSource = dtSalesitems;
            gridSalLine.DataBind();
            clearSalesLine();

        }
        catch (Exception ex)
        {
        }

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
            if (dtSalesitems.Rows.Count > 0)
            {
                string expression = "ID = MAX(ID)";
                DataRow[] maxrow = dtSalesitems.Select(expression);
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

    protected void clearSalesLine()
    {
        ddSalesArea.SelectedValue = "";
        ddsalesType.SelectedValue = "";
        ddCurrency.SelectedValue = "";
        ddPaymentsTerms.SelectedValue = "";
        txtLevelOFTrade.Text = "";
        ddFinalDestination.SelectedValue = "";
        txtTermsOfDelivery.Text = "";
        txtGroups.Text = "";
        chkFumination.Checked = false;
        txtVAT.Text = "";
        chkQualityCertificate.Checked = false;
        txtPaymentMode.Text = "";
        txtDeliveryTolerence.Text = "";
        chkCertificateOfOrg.Checked = false;
        chkGSP.Checked = false;
        txtCreditDays.Text = "";
        txtLegalization.Text = "";
        txtPacking.Text = "";
        txtSticker.Text = "";
        txtInvoiceLength.Text = "";
        txtSalesOffice.Text = "";
        txtCustOwner.Text = "";
        txtPalletsStacking.Text = "";
        txtLengthTolerence.Text = "";
        txtAgentCode.Text = "";
        txtShippingLinePrefrnce.Text = "";
        txtPreshippinginstructions.Text = "";
        txtPackingInstruction.Text = "";
        txtSpInstruction.Text = "";
    }

    protected void clearDetails()
    {
        txtCustomerCode.Text = "";
        txtName.Text = "";
        txtAddress.Text = "";
        ddCountry.SelectedValue = "";
        txtRegion.Text = "";
        txtTelephone.Text = "";
        txtFax.Text = "";
        txtEmail.Text = "";
        ddcustomertype.SelectedValue = "";
        txtApplication.Text = "";
        txtContactPerson.Text = "";
        txtDesignation.Text = "";
        txtDepartment.Text = "";
        txtContactPerTelephone.Text = "";
        txtContactPerFax.Text = "";
        txtContactPerEmail.Text = "";
        txtDOB.Text = "";
        txtAnniversary.Text = "";
        txtAccountDeptcont.Text = "";
        txtAccountDeptEmail.Text = "";
        txtCreditLimit.Text = "";
        txtEximLimit.Text = "";

    }

    protected void clearAll()
    {
        clearDetails();
        clearSalesLine();
        clearAccountingLine();
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
    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {

        if (dtAccountingitems.Rows.Count > 0 && dtSalesitems.Rows.Count > 0)
        {
            bool isSaved = false;
            if (hf_isNewRecord.Value == "true")
            {
                isSaved = cs.saveCustomerMaster(txtName.Text, txtAddress.Text, ddCountry.SelectedValue, txtRegion.Text, txtTelephone.Text, txtFax.Text, txtEmail.Text, ddcustomertype.SelectedValue,
            txtApplication.Text, txtContactPerson.Text, txtDesignation.Text, txtDepartment.Text, txtContactPerTelephone.Text, txtContactPerFax.Text, txtContactPerEmail.Text, txtDOB.Text,
            txtAnniversary.Text, txtAccountDeptcont.Text, txtAccountDeptEmail.Text, txtCreditLimit.Text, txtEximLimit.Text, Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider),
            Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider), "true", Session["Location"].ToString(), dtAccountingitems, dtSalesitems);
            }
            else if (hf_isNewRecord.Value == "false")
            {
                isSaved = cs.updateCustomerMaster(hf_Cid.Value, txtCustomerCode.Text.Trim(), txtName.Text, txtAddress.Text, ddCountry.SelectedValue, txtRegion.Text, txtTelephone.Text, txtFax.Text, txtEmail.Text, ddcustomertype.SelectedValue,
            txtApplication.Text, txtContactPerson.Text, txtDesignation.Text, txtDepartment.Text, txtContactPerTelephone.Text, txtContactPerFax.Text, txtContactPerEmail.Text, txtDOB.Text,
            txtAnniversary.Text, txtAccountDeptcont.Text, txtAccountDeptEmail.Text, txtCreditLimit.Text, txtEximLimit.Text, Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider),
            Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider), "true", Session["Location"].ToString(), dtAccountingitems, dtSalesitems);

            }


            if (isSaved == true)
            {
                string message = objMsg.RecordSaved;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
                clearAll();
                TabContCustomer.ActiveTabIndex = 0;
                cs.refreshCustomerDetails();
                iFlag = 0;
                int cid = cs.getPositionID(iFlag);
                fillDataToForm(cid);
                btn_save.Visible = false;
                btn_cancel.Visible = false;
                btn_nxt.Visible = true;
                btn_pre.Visible = true;
                btn_addSaleInfo.Visible = false;
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
            else if (dtSalesitems.Rows.Count <= 0)
            {
                string message = "Please add atleast one Sales Information.";
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
            cs.refreshCustomerDetails();
            int cid = cs.getPositionID(iFlag);
            fillDataToForm(cid);
            btn_save.Visible = false;
            btn_cancel.Visible = false;
            btn_nxt.Visible = true;
            btn_pre.Visible = true;
            btn_addSaleInfo.Visible = false;
            btnAddAccountingDetails.Visible = false;
            EnableAllControls(false);
            ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
            btn_Search.Enabled = true;
        }


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

        foreach (Control ctrl in pnl_sale.Controls)
            if (ctrl is TextBox)

                ((TextBox)ctrl).Enabled = status;

            else if (ctrl is CheckBox)

                ((CheckBox)ctrl).Enabled = status;

            else if (ctrl is DropDownList)

                ((DropDownList)ctrl).Enabled = status;

        txtCustomerCode.Enabled = false;
        txtDOB.Enabled = false;
        txtAnniversary.Enabled = false;

    }

    protected void fillDataToForm(int c)
    {
        clearAll();
        displayDetailsRecord(c);
        hf_Cid.Value = c.ToString();
        DataTable dtacc = cs.getCustomerAccounting(c.ToString());
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
        DataTable dtsal = cs.getCustomerSales(c.ToString());
        dtSalesitems.Clear();
        if (dtsal.Rows.Count > 0)
        {
            foreach (DataRow r in dtsal.Rows)
            {
                AddRowtoSalesLine(r);
            }
        }

        gridSalLine.DataSource = dtSalesitems;
        gridSalLine.DataBind();

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

    protected void fillCountry(DropDownList curr)
    {
        DataTable dt = cmn.getCountry();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["Description"].ToString(), row["Id"].ToString()));
            }


        }
    }

    protected void fillCustomerType(DropDownList curr)
    {
        DataTable dt = cs.getCustType();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["TypeDesc"].ToString(), row["Id"].ToString()));
            }


        }
    }

    protected void fillSalesArea(DropDownList curr)
    {
        DataTable dt = cs.getSalesArea();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["SalesAreaDesc"].ToString(), row["AutoId"].ToString()));
            }


        }
    }

    protected void fillSalesType(DropDownList curr)
    {
        DataTable dt = cs.getSalesType();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["Name"].ToString(), row["SalesTypeId"].ToString()));
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

    protected void fillFinalDestination(DropDownList curr)
    {
        DataTable dt = cs.getFinalDestination();
        curr.Items.Add(new ListItem("--Select--", ""));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                curr.Items.Add(new ListItem(row["FinalDestCode"].ToString(), row["FinalDestinationID"].ToString()));
            }


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

    protected void displayaccountingRecord(int Id)
    {

        string expression = "ID=" + Id;
        DataRow[] selRow = dtAccountingitems.Select(expression);
        txtAccountingUnit.Text = selRow[0]["AccountingUnit"].ToString();
        txtCustomerBank.Text = selRow[0]["CustomerBank"].ToString();
        txtCustomerRecoAcc.Text = selRow[0]["CustomerRecoAccount"].ToString();
        txtCustomerBankCountry.Text = selRow[0]["CustomerBankCountry"].ToString();
        txtCustomerBankKey.Text = selRow[0]["CustomerBankKey"].ToString();
        txtCustomerBankAccount.Text = selRow[0]["CustomerBankAccount"].ToString();
        txtAccountHolder.Text = selRow[0]["AccountHolder"].ToString();



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
    protected void gridSalLine_SelectedIndexChanged(object sender, EventArgs e)
    {


        int DataKey = int.Parse(gridSalLine.SelectedDataKey.Value.ToString());
        displaySaleRecord(DataKey);

        foreach (GridViewRow oldrow in gridSalLine.Rows)
        {
            ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgSelect");
            imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            oldrow.BackColor = Color.White;
        }
        ImageButton img = (ImageButton)gridSalLine.Rows[gridSalLine.SelectedIndex].FindControl("imgSelect");
        img.ImageUrl = "~/Images/chkbxcheck.png";
        if (btn_addSaleInfo.Visible == true)
        {
            dtSalesitems = DeleteSingleRow(dtSalesitems, "ID=" + DataKey);
            gridSalLine.DataSource = dtSalesitems;
            gridSalLine.DataBind();
        }
    }
    protected void displaySaleRecord(int Id)
    {

        string expression = "ID=" + Id;
        DataRow[] selRow = dtSalesitems.Select(expression);

        ddSalesArea.SelectedValue = selRow[0]["SalesArea"].ToString();
        ddsalesType.SelectedValue = selRow[0]["SalesType"].ToString();
        ddCurrency.SelectedValue = selRow[0]["Currency"].ToString();
        ddPaymentsTerms.SelectedValue = selRow[0]["PaymentTerms"].ToString();
        txtLevelOFTrade.Text = selRow[0]["LevelofTrade"].ToString();
        ddFinalDestination.SelectedValue = selRow[0]["FinalDestination"].ToString();
        txtTermsOfDelivery.Text = selRow[0]["TermsOfDelivery"].ToString();
        txtGroups.Text = selRow[0]["Groups"].ToString();
        if (selRow[0]["Fumination"].ToString() == "True")
            chkFumination.Checked = true;
        else
            chkFumination.Checked = false;
        txtVAT.Text = selRow[0]["VAT"].ToString();
        if (selRow[0]["QualityCertificate"].ToString() == "True")
            chkQualityCertificate.Checked = true;
        else
            chkQualityCertificate.Checked = false;

        txtPaymentMode.Text = selRow[0]["PaymentMode"].ToString();
        txtDeliveryTolerence.Text = selRow[0]["DeliveryTolerance"].ToString();

        if (selRow[0]["CertificateOfOrg"].ToString() == "True")
            chkCertificateOfOrg.Checked = true;
        else
            chkCertificateOfOrg.Checked = false;

        if (selRow[0]["GSP"].ToString() == "True")
            chkGSP.Checked = true;
        else
            chkGSP.Checked = false;


        txtCreditDays.Text = selRow[0]["CreditDays"].ToString();
        txtLegalization.Text = selRow[0]["Legalization"].ToString();
        txtPacking.Text = selRow[0]["Packing"].ToString();
        txtSticker.Text = selRow[0]["Sticker"].ToString();
        txtInvoiceLength.Text = selRow[0]["InvoicingLength"].ToString();
        txtSalesOffice.Text = selRow[0]["SalesOffice"].ToString();
        txtCustOwner.Text = selRow[0]["CustOwner"].ToString();
        txtPalletsStacking.Text = selRow[0]["PalletsStacking"].ToString();
        txtLengthTolerence.Text = selRow[0]["LengthTolerance"].ToString();
        txtAgentCode.Text = selRow[0]["AgentCode"].ToString();
        txtShippingLinePrefrnce.Text = selRow[0]["ShippingLinePreference"].ToString();
        txtPreshippinginstructions.Text = selRow[0]["PreShippingInspection"].ToString();
        txtPackingInstruction.Text = selRow[0]["PackingInstruction"].ToString();
        txtSpInstruction.Text = selRow[0]["SpecialInstruction"].ToString();

    }


}