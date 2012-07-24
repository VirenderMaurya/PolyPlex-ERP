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
    CreditDebitNoteProposal_Tran objCreditDebitNoteProposal_Tran = new CreditDebitNoteProposal_Tran();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();
    BLLCollection<CreditDebitNoteProposal_Tran> objBllcollection = new BLLCollection<CreditDebitNoteProposal_Tran>();
    string FlagInsertUpdate;
    double NetAmount, TotalAmount, TotalVatAmount;
    //int totalItems = 0;
    
    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Credit Debit Note Proposal";
            txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

            int PalletNo = RandomNumber(100000000, 999999999);
            txtCRDBProposalNo.Text = Convert.ToString(PalletNo);
            HidVat.Value = "4";

            #region Fill Master
            BindTypeMaster();
            BindSearchList();
            FillFinancialYear();

            #endregion

            #region Bind Blank Grid
            GetInvoiceDetailBetweenFromAndToDate();
            GetSelectedInvoiceDetailInCreditDebit(0);
            GetSelectedInvoicesByInvoiceId(0);
            #endregion

            #region Change Color of Readonly Fields

            txtSalesType.Attributes.Add("style", "background:lightgray");
            txtYear.Attributes.Add("style", "background:lightgray");
            txtCRDBProposalNo.Attributes.Add("style", "background:lightgray");
            txtDate.Attributes.Add("style", "background:lightgray");
            txtDocumentDate.Attributes.Add("style", "background:lightgray");
            txtFrom.Attributes.Add("style", "background:lightgray");
            txtTo.Attributes.Add("style", "background:lightgray");           
            txtVatAmount.Attributes.Add("style", "background:lightgray");           
            txtInvoiceNo.Attributes.Add("style", "background:lightgray");           
            txtCustomerCode.Attributes.Add("style", "background:lightgray");
            txtCustomerName.Attributes.Add("style", "background:lightgray");
            txtNetAmount.Attributes.Add("style", "background:lightgray");
            txtCurrency.Attributes.Add("style", "background:lightgray");
            txtInvoiceNo.Attributes.Add("style", "background:lightgray");
            txtGrandTotal.Attributes.Add("style", "background:lightgray");
            txtAmount.Attributes.Add("style", "background:lightgray");
            txtValue.Attributes.Add("style", "background:lightgray");
            txtVAT.Attributes.Add("style", "background:lightgray");

            #endregion

            TdMrnNoHeading.Attributes.Add("style", "visibility:hidden");
            TdMrnNo.Attributes.Add("style", "visibility:hidden");

            #region Readonly Fields

            txtYear.Attributes.Add("readonly", "true");
            txtSalesType.Attributes.Add("readonly", "true");
            txtDate.Attributes.Add("readonly", "true");
            txtCustomerCode.Attributes.Add("readonly", "true");
            txtCustomerName.Attributes.Add("readonly", "true");
            txtDocumentDate.Attributes.Add("readonly", "true");
            txtFrom.Attributes.Add("readonly", "true");
            txtTo.Attributes.Add("readonly", "true");
            txtCRDBProposalNo.Attributes.Add("readonly", "true");
            txtCurrency.Attributes.Add("readonly", "true");
            txtInvoiceNo.Attributes.Add("readonly", "true");
            txtVatAmount.Attributes.Add("readonly", "true");
            txtNetAmount.Attributes.Add("readonly", "true");
            txtGrandTotal.Attributes.Add("readonly", "true");
            txtValue.Attributes.Add("readonly", "true");
            txtVAT.Attributes.Add("readonly", "true");
            txtAmount.Attributes.Add("readonly", "true"); 
            #endregion
                       
            txtRate.Attributes.Add("onkeyup", "CalculateVatAndNetAmount();");
            ddlCreditDebit.Attributes.Add("onclick", "return VisibleMRNNo();");
        }
        if (HidIsNewToDate.Value == "Yes")
        {
            DataTable dt = objCreditDebitNoteProposal_Tran.Check_ExistCreditDebitRecord(Convert.ToInt32(hidCustomerId.Value),txtFrom.Text,txtTo.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                ddlCreditDebit.SelectedValue = dt.Rows[0]["CreditDebit"].ToString();
                hidSalesType.Value = dt.Rows[0]["SalesTypeId"].ToString();
                txtSalesType.Text = dt.Rows[0]["Sales Type"].ToString();
                txtYear.Text = dt.Rows[0]["Year"].ToString();
                txtCRDBProposalNo.Text = dt.Rows[0]["CRDBProposalNo"].ToString();
                txtDate.Text = dt.Rows[0]["Date"].ToString();
                ddlType.SelectedValue = dt.Rows[0]["Type"].ToString().Trim();
                txtMRNNo.Text = dt.Rows[0]["MRNNo"].ToString();
                hidCustomerId.Value = dt.Rows[0]["CustomerId"].ToString();
                txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                txtDocumentNo.Text = dt.Rows[0]["DocumentNo"].ToString();
                txtDocumentDate.Text = dt.Rows[0]["DocumentDate"].ToString();
                txtFrom.Text = dt.Rows[0]["FromDate"].ToString();
                txtTo.Text = dt.Rows[0]["ToDate"].ToString();
                txtPreamble.Text = dt.Rows[0]["Preamble"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                txtValue.Text = dt.Rows[0]["Value"].ToString();
                txtVAT.Text = dt.Rows[0]["Vat"].ToString();
                txtGrandTotal.Text = dt.Rows[0]["GrandTotal"].ToString();
                HidCBNId.Value = dt.Rows[0]["CBNId"].ToString(); 
            }
            GetInvoiceDetailBetweenFromAndToDate();
            HidIsNewToDate.Value = "";            
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
        ClearHeaderFields();
        ClearCalculativeFields();
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        ddlSearch.SelectedValue = "0";
        txtSearch.Text = "";
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        lblInfo.Text = "";
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        txtSearchList.Text = "";
        if (ddlSearch.SelectedValue != "0")
        {
            if (ddlSearch.SelectedValue.ToString() == "AllCreditNote")
            {
                GetAllCreditDebitList("1", txtSearch.Text.Trim());
            }
            else if (ddlSearch.SelectedValue.ToString() == "AllDebitNote")
            {
                GetAllCreditDebitList("2", txtSearch.Text.Trim());
            }
            lSearchList.Text = "Search By Cr/Db Proposal No.: ";
            ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void gvInvoiceDuringPeriod_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "&nbsp;")
                {
                    e.Row.Cells[4].Text = "0";
                }
            }
        }
        catch { }
    }

    protected void gvInvoiceDuringPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvInvoiceDuringPeriod.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                ClearCalculativeFields();
                GetSelectedInvoiceDetailInCreditDebit(Convert.ToInt32(e.CommandArgument));

            }
        }
        catch { }
    }

    protected void gvSelectedInvoiceDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[1].Style.Add("display", "none");
            e.Row.Cells[2].Style.Add("display", "none");
            e.Row.Cells[11].Style.Add("display", "none");
            e.Row.Cells[12].Style.Add("display", "none");
            e.Row.Cells[13].Style.Add("display", "none");
            e.Row.Cells[14].Style.Add("display", "none");
            e.Row.Cells[15].Style.Add("display", "none");            

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.GridView gvSelectedInvoiceDetail = (System.Web.UI.WebControls.GridView)sender;
                GridViewRow Gi;
                Gi = e.Row;

                if (e.Row.Cells[12].Text == "Yes")
                {
                    e.Row.Visible = false;
                }
                else if (e.Row.Cells[12].Text == "" || e.Row.Cells[12].Text == "&nbsp;")
                {
                    e.Row.Visible = true;
                }               
            }
        }        
        catch { }
    }

    protected void gvSelectedInvoiceDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvSelectedInvoiceDetail = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvSelectedInvoiceDetail.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvSelectedInvoiceDetail.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }                
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                ClearCalculativeFields();
                HidSelectedInvoiceDetailRowIndex.Value = Convert.ToString(row.RowIndex);
                txtQtyKg.Text = gvSelectedInvoiceDetail.Rows[gvSelectedInvoiceDetail.SelectedIndex].Cells[9].Text;
                txtCurrency.Text = gvSelectedInvoiceDetail.Rows[gvSelectedInvoiceDetail.SelectedIndex].Cells[10].Text;
                txtInvoiceNo.Text = gvSelectedInvoiceDetail.Rows[gvSelectedInvoiceDetail.SelectedIndex].Cells[2].Text;                
            }
        }
        catch { }
    }

    protected void gvSelectedInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[2].Style.Add("display", "none");
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[19].Style.Add("display", "none");
                e.Row.Cells[20].Style.Add("display", "none");
                e.Row.Cells[21].Style.Add("display", "none");
                e.Row.Cells[22].Style.Add("display", "none");
                e.Row.Cells[23].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblNAmount = (Label)e.Row.FindControl("lblNAmount");
                double NAmount = double.Parse(lblNAmount.Text);
                NetAmount += NAmount;               
                txtGrandTotal.Text = NetAmount.ToString();

                Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                double Amount = double.Parse(lblAmount.Text);
                TotalAmount += Amount;
                txtValue.Text = TotalAmount.ToString();

                Label lblVatAmount = (Label)e.Row.FindControl("lblVatAmount");
                double VatAmount = double.Parse(lblVatAmount.Text);
                TotalVatAmount += VatAmount;
                txtVAT.Text = TotalVatAmount.ToString();
            }
            
        }
        catch { }
    }

    protected void gvSelectedInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvSelectedInvoice = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvSelectedInvoice.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvSelectedInvoice.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidUpdateGridRecord.Value = "1";
                HidSelectedInvoiceRowIndex.Value = Convert.ToString(row.RowIndex);
                txtQtyKg.Text = gvSelectedInvoice.Rows[gvSelectedInvoice.SelectedIndex].Cells[12].Text;
                txtRate.Text = gvSelectedInvoice.Rows[gvSelectedInvoice.SelectedIndex].Cells[14].Text;
                txtAmount.Text = (gvSelectedInvoice.Rows[gvSelectedInvoice.SelectedIndex].FindControl("lblAmount") as Label).Text;
                txtVatAmount.Text = (gvSelectedInvoice.Rows[gvSelectedInvoice.SelectedIndex].FindControl("lblVatAmount") as Label).Text;
                txtNetAmount.Text = (gvSelectedInvoice.Rows[gvSelectedInvoice.SelectedIndex].FindControl("lblNAmount") as Label).Text; 
                txtCurrency.Text = gvSelectedInvoice.Rows[gvSelectedInvoice.SelectedIndex].Cells[13].Text;
                txtInvoiceNo.Text = gvSelectedInvoice.Rows[gvSelectedInvoice.SelectedIndex].Cells[3].Text;
                txtDescription.Text = gvSelectedInvoice.Rows[gvSelectedInvoice.SelectedIndex].Cells[18].Text;
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
                if (HidPopUpType.Value == "CustomerCode")
                {
                    hidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                }
                else if (HidPopUpType.Value == "SalesType")
                {
                    hidSalesType.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtSalesType.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text; 
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

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        if (HidPopUpType.Value == "CustomerCode")
        {
            FillAllCustomer(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "SalesType")
        {
            BindSalesTypeMaster(txtSearchFromPopup.Text.Trim());
        }                       
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void gvAllCreditDebit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {  
            e.Row.Cells[12].Style.Add("display", "none");
            e.Row.Cells[13].Style.Add("display", "none");
            e.Row.Cells[14].Style.Add("display", "none");
            e.Row.Cells[15].Style.Add("display", "none");
            e.Row.Cells[16].Style.Add("display", "none");
            e.Row.Cells[17].Style.Add("display", "none");
            e.Row.Cells[18].Style.Add("display", "none");
            e.Row.Cells[19].Style.Add("display", "none");
            e.Row.Cells[20].Style.Add("display", "none");
            e.Row.Cells[21].Style.Add("display", "none");
            e.Row.Cells[22].Style.Add("display", "none");
            e.Row.Cells[23].Style.Add("display", "none");  
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvAllCreditDebit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvAllCreditDebit = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvAllCreditDebit.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvAllCreditDebit.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                ddlCreditDebit.SelectedValue = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[13].Text;
                hidSalesType.Value = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[14].Text;
                txtSalesType.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[3].Text;
                txtYear.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[15].Text;
                txtCRDBProposalNo.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[1].Text;
                txtDate.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[4].Text;               
                ddlType.SelectedValue = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[16].Text.Trim();
                txtMRNNo.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[17].Text;
                hidCustomerId.Value = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[12].Text;
                txtCustomerCode.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[18].Text;
                txtCustomerName.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[6].Text;
                txtDocumentNo.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[19].Text;
                txtDocumentDate.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[20].Text;
                txtFrom.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[10].Text;
                txtTo.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[11].Text;
                txtPreamble.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[21].Text;
                txtRemarks.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[22].Text;
                txtValue.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[7].Text;
                txtVAT.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[8].Text;
                txtGrandTotal.Text = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[9].Text;
                HidCBNId.Value = gvAllCreditDebit.Rows[gvAllCreditDebit.SelectedIndex].Cells[23].Text;

                GetInvoiceDetailBetweenFromAndToDate();                
            }
        }
        catch { }
    }

    protected void imgCustomerCode_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "CustomerCode";
        lPopUpHeader.Text = "Customer";
        lSearch.Text = "Search By Customer: ";
        FillAllCustomer("");
        ModalPopupExtender2.Show();
    }

    protected void imgSalesType_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "SalesType";        
        lPopUpHeader.Text = "Type Of Sales";
        lSearch.Text = "Search By Name: ";
        BindSalesTypeMaster("");
        ModalPopupExtender2.Show();
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "CustomerCode")
        {
            FillAllCustomer(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "SalesType")
        {
            BindSalesTypeMaster(txtSearchFromPopup.Text.Trim());                        
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }   

    protected void ImgBtnSaveLine_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable objdtSelectedInvoiceDetailInCreditDebit = new DataTable();
            objdtSelectedInvoiceDetailInCreditDebit = (DataTable)ViewState["SelectedInvoiceDetailInCreditDebit"];

            DataTable objdtCreditDebitNoteLineItem = new DataTable();
            objdtCreditDebitNoteLineItem = (DataTable)ViewState["CreditDebitNoteLineItem"];

            if (objdtSelectedInvoiceDetailInCreditDebit.Rows.Count > 0)
            {
                if (Convert.ToDouble(txtQtyKg.Text.Trim()) > Convert.ToDouble(objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SOReqQuantityInKG"].ToString()))
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RequiredQuantity, 125, 300);
                }
                else
                {
                    if (HidUpdateGridRecord.Value == "")
                    {
                        DataRow objdrCreditDebitNoteLineItem = objdtCreditDebitNoteLineItem.NewRow();
                        objdrCreditDebitNoteLineItem["CBNLineItemId"] = 0;
                        if (HidCBNId.Value != "")
                        {
                            objdrCreditDebitNoteLineItem["CBNId"] = Convert.ToInt32(HidCBNId.Value); ;
                        }
                        else
                        {
                            objdrCreditDebitNoteLineItem["CBNId"] = 0;
                        }
                        objdrCreditDebitNoteLineItem["InvoiceId"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["Invoiceid"];
                        objdrCreditDebitNoteLineItem["InvoiceNo"] = txtInvoiceNo.Text.Trim(); ;
                        objdrCreditDebitNoteLineItem["SalesOrderId"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SalesOrderId"];
                        objdrCreditDebitNoteLineItem["SOLineItemId"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SOLineItemID"];
                        objdrCreditDebitNoteLineItem["SubFilmTypeId"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SubFilmType"];
                        objdrCreditDebitNoteLineItem["Micron"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SOMicron"];
                        objdrCreditDebitNoteLineItem["Core"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SOCore"];
                        objdrCreditDebitNoteLineItem["WidthInMM"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SOWidthInMM"];
                        objdrCreditDebitNoteLineItem["LengthInMtr"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SOLengthInMtr"];
                        objdrCreditDebitNoteLineItem["UnitPrice"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SOUnitPrice"];
                        objdrCreditDebitNoteLineItem["ReqQuantityInKG"] = Convert.ToDouble(txtQtyKg.Text.Trim());
                        objdrCreditDebitNoteLineItem["Currency"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["CurrencyId"];
                        objdrCreditDebitNoteLineItem["CurrencyName"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["Currency"];
                        objdrCreditDebitNoteLineItem["Rate"] = Convert.ToDouble(txtRate.Text.Trim());
                        objdrCreditDebitNoteLineItem["Amount"] = Convert.ToDouble(txtAmount.Text.Trim());
                        objdrCreditDebitNoteLineItem["VatAmount"] = Convert.ToDouble(txtVatAmount.Text.Trim());
                        objdrCreditDebitNoteLineItem["NetAmount"] = Convert.ToDouble(txtNetAmount.Text.Trim());
                        objdrCreditDebitNoteLineItem["Description"] = txtDescription.Text.Trim();
                        objdrCreditDebitNoteLineItem["ActiveStatus"] = true;
                        objdrCreditDebitNoteLineItem["IsUpdated"] = "No";
                        objdrCreditDebitNoteLineItem["SubFilmTypeName"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["SubFilmTypeName"];
                        objdrCreditDebitNoteLineItem["WidthInMMName"] = objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["WidthInMMName"];

                        objdtCreditDebitNoteLineItem.Rows.Add(objdrCreditDebitNoteLineItem);
                        objdtCreditDebitNoteLineItem.AcceptChanges();

                        #region Update Selected Row in Selected Invoice Detail

                        objdtSelectedInvoiceDetailInCreditDebit.Rows[Convert.ToInt32(HidSelectedInvoiceDetailRowIndex.Value)]["IsSelected"] = "Yes";
                        objdtSelectedInvoiceDetailInCreditDebit.AcceptChanges();
                        ViewState["SelectedInvoiceDetailInCreditDebit"] = objdtSelectedInvoiceDetailInCreditDebit;
                        gvSelectedInvoiceDetail.DataSource = objdtSelectedInvoiceDetailInCreditDebit;
                        gvSelectedInvoiceDetail.DataBind();

                        #endregion

                    }
                    else if (HidUpdateGridRecord.Value == "1")
                    {
                        objdtCreditDebitNoteLineItem.Rows[Convert.ToInt32(HidSelectedInvoiceRowIndex.Value)]["IsUpdated"] = "Yes";
                        objdtCreditDebitNoteLineItem.Rows[Convert.ToInt32(HidSelectedInvoiceRowIndex.Value)]["ReqQuantityInKG"] = Convert.ToDouble(txtQtyKg.Text.Trim());
                        objdtCreditDebitNoteLineItem.Rows[Convert.ToInt32(HidSelectedInvoiceRowIndex.Value)]["Rate"] = Convert.ToDouble(txtRate.Text.Trim());
                        objdtCreditDebitNoteLineItem.Rows[Convert.ToInt32(HidSelectedInvoiceRowIndex.Value)]["Amount"] = Convert.ToDouble(txtAmount.Text.Trim());
                        objdtCreditDebitNoteLineItem.Rows[Convert.ToInt32(HidSelectedInvoiceRowIndex.Value)]["VatAmount"] = Convert.ToDouble(txtVatAmount.Text.Trim());
                        objdtCreditDebitNoteLineItem.Rows[Convert.ToInt32(HidSelectedInvoiceRowIndex.Value)]["NetAmount"] = Convert.ToDouble(txtNetAmount.Text.Trim());
                        objdtCreditDebitNoteLineItem.Rows[Convert.ToInt32(HidSelectedInvoiceRowIndex.Value)]["Description"] = txtDescription.Text.Trim();
                        objdtCreditDebitNoteLineItem.Rows[Convert.ToInt32(HidSelectedInvoiceRowIndex.Value)]["ActiveStatus"] = true;
                        objdtCreditDebitNoteLineItem.AcceptChanges();
                    }
                    ViewState["CreditDebitNoteLineItem"] = objdtCreditDebitNoteLineItem;
                    gvSelectedInvoice.DataSource = objdtCreditDebitNoteLineItem;
                    gvSelectedInvoice.DataBind();
                    ClearCalculativeFields();
                    HidUpdateGridRecord.Value = "";
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectInvoiceDetail, 125, 300);
            }
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.ErrorToLineItem, 125, 300);
        }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Upadte Record Of Header & Line Item

            DataTable dtCreditDebitNoteLineItem = (DataTable)ViewState["CreditDebitNoteLineItem"];
            if (dtCreditDebitNoteLineItem.Rows.Count > 0)
            {
                try
                {
                    #region Insert/Update Records of Header

                    if (HidCBNId.Value == "")
                    {
                        objCreditDebitNoteProposal_Tran.CBNId = 0;
                    }
                    else
                    {
                        objCreditDebitNoteProposal_Tran.CBNId = Convert.ToInt32(HidCBNId.Value);
                    }

                    objCreditDebitNoteProposal_Tran.CreditDebit = ddlCreditDebit.SelectedValue.ToString();
                    objCreditDebitNoteProposal_Tran.SalesTypeId = Convert.ToInt32(hidSalesType.Value);
                    objCreditDebitNoteProposal_Tran.Year = txtYear.Text.Trim();
                    objCreditDebitNoteProposal_Tran.CRDBProposalNo = txtCRDBProposalNo.Text.Trim();
                    objCreditDebitNoteProposal_Tran.Date = DateTime.ParseExact(txtDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    objCreditDebitNoteProposal_Tran.Type = ddlType.SelectedValue.ToString();
                    objCreditDebitNoteProposal_Tran.MRNNo = txtMRNNo.Text.Trim();
                    objCreditDebitNoteProposal_Tran.CustomerId = Convert.ToInt32(hidCustomerId.Value);
                    objCreditDebitNoteProposal_Tran.DocumentNo = txtDocumentNo.Text.Trim();
                    objCreditDebitNoteProposal_Tran.DocumentDate = DateTime.ParseExact(txtDocumentDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    objCreditDebitNoteProposal_Tran.From = DateTime.ParseExact(txtFrom.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    objCreditDebitNoteProposal_Tran.To = DateTime.ParseExact(txtTo.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    objCreditDebitNoteProposal_Tran.Preamble = txtPreamble.Text.Trim();
                    objCreditDebitNoteProposal_Tran.Remarks = txtRemarks.Text.Trim();
                    if (txtValue.Text.Trim() != "")
                    {
                        objCreditDebitNoteProposal_Tran.Value = Convert.ToDouble(txtValue.Text.Trim());
                    }
                    else
                    {
                        objCreditDebitNoteProposal_Tran.Value = 0;
                    }                    
                    if (txtVAT.Text.Trim() != "")
                    {
                        objCreditDebitNoteProposal_Tran.Vat = Convert.ToDouble(txtVAT.Text.Trim());
                    }
                    else
                    {
                        objCreditDebitNoteProposal_Tran.Vat = 0;
                    }
                    if (txtGrandTotal.Text.Trim() != "")
                    {
                        objCreditDebitNoteProposal_Tran.GrandTotal = Convert.ToDouble(txtGrandTotal.Text.Trim());
                    }
                    else
                    {
                        objCreditDebitNoteProposal_Tran.GrandTotal = 0;
                    }
                    objCreditDebitNoteProposal_Tran.ActiveStatus = true;
                    objCreditDebitNoteProposal_Tran.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                    objCreditDebitNoteProposal_Tran.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                    #endregion

                    #region Insert/Update Records of LineItem

                    objCreditDebitNoteProposal_Tran.dtCDNPLineItems = new DataTable();
                    objCreditDebitNoteProposal_Tran.dtCDNPLineItems = objCreditDebitNoteProposal_Tran.Get_CreditDebitNote_LineItem_TransByInvoiceId(0);
                    DataRow objdrCDNPLineItems;

                    if (dtCreditDebitNoteLineItem.Rows.Count > 0)
                    {
                        foreach (DataRow objdrCreditDebitNoteLineItem in dtCreditDebitNoteLineItem.Rows)
                        {
                            try
                            {
                                if ((objdrCreditDebitNoteLineItem["CBNLineItemId"].ToString() == "0" && objdrCreditDebitNoteLineItem["IsUpdated"].ToString() == "No")
                                    || (objdrCreditDebitNoteLineItem["CBNLineItemId"].ToString() == "0" && objdrCreditDebitNoteLineItem["IsUpdated"].ToString() == "Yes")
                                    || (objdrCreditDebitNoteLineItem["CBNLineItemId"].ToString() != "0" && objdrCreditDebitNoteLineItem["IsUpdated"].ToString() == "Yes"))
                                {
                                    objdrCDNPLineItems = objCreditDebitNoteProposal_Tran.dtCDNPLineItems.NewRow();
                                    objdrCDNPLineItems["CBNLineItemId"] = Convert.ToInt32(objdrCreditDebitNoteLineItem["CBNLineItemId"].ToString());
                                    objdrCDNPLineItems["InvoiceId"] = Convert.ToInt32(objdrCreditDebitNoteLineItem["InvoiceId"].ToString());
                                    objdrCDNPLineItems["SalesOrderId"] = Convert.ToInt32(objdrCreditDebitNoteLineItem["SalesOrderId"].ToString());
                                    objdrCDNPLineItems["SOLineItemId"] = Convert.ToInt32(objdrCreditDebitNoteLineItem["SOLineItemId"].ToString());
                                    objdrCDNPLineItems["SubFilmTypeId"] = Convert.ToInt32(objdrCreditDebitNoteLineItem["SubFilmTypeId"].ToString());
                                    objdrCDNPLineItems["Micron"] = objdrCreditDebitNoteLineItem["Micron"].ToString();
                                    objdrCDNPLineItems["Core"] = objdrCreditDebitNoteLineItem["Core"].ToString();
                                    objdrCDNPLineItems["WidthInMM"] = Convert.ToInt32(objdrCreditDebitNoteLineItem["WidthInMM"].ToString());
                                    objdrCDNPLineItems["LengthInMtr"] = Convert.ToDouble(objdrCreditDebitNoteLineItem["LengthInMtr"].ToString());
                                    objdrCDNPLineItems["UnitPrice"] = Convert.ToDouble(objdrCreditDebitNoteLineItem["UnitPrice"].ToString());
                                    objdrCDNPLineItems["ReqQuantityInKG"] = Convert.ToDouble(objdrCreditDebitNoteLineItem["ReqQuantityInKG"].ToString());
                                    objdrCDNPLineItems["Currency"] = Convert.ToInt32(objdrCreditDebitNoteLineItem["Currency"].ToString());
                                    objdrCDNPLineItems["Rate"] = Convert.ToDouble(objdrCreditDebitNoteLineItem["Rate"].ToString());
                                    objdrCDNPLineItems["Amount"] = Convert.ToDouble(objdrCreditDebitNoteLineItem["Amount"].ToString());
                                    objdrCDNPLineItems["VatAmount"] = Convert.ToDouble(objdrCreditDebitNoteLineItem["VatAmount"].ToString());
                                    objdrCDNPLineItems["NetAmount"] = Convert.ToDouble(objdrCreditDebitNoteLineItem["NetAmount"].ToString());
                                    objdrCDNPLineItems["Description"] = objdrCreditDebitNoteLineItem["Description"].ToString();
                                    objdrCDNPLineItems["ActiveStatus"] = objdrCreditDebitNoteLineItem["ActiveStatus"].ToString();

                                    objCreditDebitNoteProposal_Tran.dtCDNPLineItems.Rows.Add(objdrCDNPLineItems);
                                    objCreditDebitNoteProposal_Tran.dtCDNPLineItems.AcceptChanges();
                                }
                            }
                            catch
                            {
                                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.LineItemNotSaved, 125, 300);
                                return;
                            }
                        }
                    }

                    #endregion

                    FlagInsertUpdate = objCreditDebitNoteProposal_Tran.InsertUpdate_In_Sal_Glb_CreditDebitNote_Tran();
                    if (FlagInsertUpdate == "YES")
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                        #region Clear All records after save

                        ClearHeaderFields();
                        ClearCalculativeFields();
                        GetInvoiceDetailBetweenFromAndToDate();
                        GetSelectedInvoiceDetailInCreditDebit(0);
                        GetSelectedInvoicesByInvoiceId(0);

                        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
                        ddlSearch.SelectedValue = "0";
                        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
                        txtSearch.Text = "";

                        #endregion
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                        return;
                    }
                    FlagInsertUpdate = "";
                }
                catch
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                    return;
                }                
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.AddLineItem, 125, 300);
                return;
            }

            #endregion
        }
        catch { }
    }

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdSalesCDNProposal = ConfigurationManager.AppSettings["FormIdSalesCDNProposal"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdSalesCDNProposal);

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
        catch { }
    }

    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    public void GetInvoiceDetailBetweenFromAndToDate()
    {
        try
        {
           DataTable dt = new DataTable();
            dt = objCreditDebitNoteProposal_Tran.Get_InvoiceDetailBetweenFromAndToDate(txtFrom.Text.Trim(),txtTo.Text.Trim(),txtCustomerCode.Text.Trim());
            if (dt.Rows.Count > 0)
            {                
                ViewState["SelectedRecords"] = dt;                
            }            
            gvInvoiceDuringPeriod.DataSource = dt;
            gvInvoiceDuringPeriod.DataBind();
            GetSelectedInvoiceDetailInCreditDebit(0);            
        }
        catch { }
    }

    public void GetSelectedInvoiceDetailInCreditDebit(int Invoiceid)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCreditDebitNoteProposal_Tran.Get_SelectedInvoiceDetailInCreditDebit(Invoiceid);
            ViewState["SelectedInvoiceDetailInCreditDebit"] = dt;
            gvSelectedInvoiceDetail.DataSource = dt;
            gvSelectedInvoiceDetail.DataBind();

            if (dt.Rows.Count > 0)  // Fill Selected Invoice grid if record exists
            {
                GetSelectedInvoicesByInvoiceId(Invoiceid);
            }
        }
        catch { }
    }

    public void GetSelectedInvoicesByInvoiceId(int Invoiceid)
    {
        try
        { 
            DataTable dt = new DataTable();
            dt = objCreditDebitNoteProposal_Tran.Get_CreditDebitNote_LineItem_TransByInvoiceId(Invoiceid);
            ViewState["CreditDebitNoteLineItem"] = dt;
            gvSelectedInvoice.DataSource = dt;
            gvSelectedInvoice.DataBind();
        }
        catch { }
    }    

    private void BindSalesTypeMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCreditDebitNoteProposal_Tran.GetSalesType_Mst(Searchtext);

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

    private void BindTypeMaster()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCreditDebitNoteProposal_Tran.Get_AllCreditDebitNoteType_Mst();

            ddlType.DataTextField = "CBNType";
            ddlType.DataValueField = "CBNTypeId";
            ddlType.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("-Select-", ""));
            }
            
        }
        catch (Exception ex)
        {
            
        }
    }

    private void FillAllCustomer(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllCustomer(Searchtext);

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

    public void ClearCalculativeFields()
    {
        txtQtyKg.Text = "";
        txtRate.Text = "";
        txtAmount.Text = "";
        txtVatAmount.Text = "";
        txtNetAmount.Text = "";
        txtCurrency.Text = "";
        txtInvoiceNo.Text = "";
        txtDescription.Text = "";
    }

    public void ClearHeaderFields()
    {
        ddlCreditDebit.SelectedValue = "";
        hidSalesType.Value = "";
        txtSalesType.Text = "";
        txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        int PalletNo = RandomNumber(100000000, 999999999);
        txtCRDBProposalNo.Text = Convert.ToString(PalletNo);  
        FillFinancialYear();
        ddlType.SelectedValue = "";
        txtMRNNo.Text = "";
        hidCustomerId.Value = "";
        txtCustomerCode.Text = "";
        txtCustomerName.Text = "";
        txtDocumentNo.Text = "";
        txtDocumentDate.Text = "";
        txtFrom.Text = "";
        txtTo.Text = "";
        txtPreamble.Text = "";
        txtRemarks.Text = "";
        txtValue.Text = "";
        txtVAT.Text = "";
        txtGrandTotal.Text = "";
        HidCBNId.Value = "";        
        #region Bind Blank Grid
        GetInvoiceDetailBetweenFromAndToDate();
        GetSelectedInvoiceDetailInCreditDebit(0);
        #endregion

    }

    private void GetAllCreditDebitList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCreditDebitNoteProposal_Tran.Get_AllCreditDebitList(ddlSearchValue, txtSearchValue);

            if (dt.Rows.Count > 0)
            {
                gvAllCreditDebit.DataSource = dt;
                gvAllCreditDebit.AllowPaging = true;
                gvAllCreditDebit.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvAllCreditDebit.AllowPaging = false;
                gvAllCreditDebit.DataSource = "";
                gvAllCreditDebit.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecordsPopUp.Text = objcommonmessage.NoRecordFound + ex.Message;
            gvAllCreditDebit.AllowPaging = false;
            gvAllCreditDebit.DataSource = "";
            gvAllCreditDebit.DataBind();
        }
    }

    #endregion

    #endregion


    
}