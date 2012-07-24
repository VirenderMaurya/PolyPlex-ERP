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
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();
    BLLCollection<CreditDebitNoteProposal_Tran> objBllcollection = new BLLCollection<CreditDebitNoteProposal_Tran>();
    FA_CreaditDebitNoteForm objFA_CreaditDebitNoteForm = new FA_CreaditDebitNoteForm();

    string FlagInsertUpdate;
    double NetAmount;
    int totalItems = 0;
    int FlagInsert;
    
    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Credit Debit Note";
            txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

            int PalletNo = RandomNumber(100000000, 999999999);
            txtCRDBNo.Text = Convert.ToString(PalletNo);

            #region Fill Master

            BindSearchList();
            FillFinancialYear();

            #endregion            

            #region Change Color of Readonly Fields

            txtSalesType.Attributes.Add("style", "background:lightgray");
            txtCreditDebit.Attributes.Add("style", "background:lightgray");
            txtYear.Attributes.Add("style", "background:lightgray");
            txtCRDBNo.Attributes.Add("style", "background:lightgray");            
            txtDate.Attributes.Add("style", "background:lightgray");
            txtCRDBProposalNo.Attributes.Add("style", "background:lightgray");
            txtType.Attributes.Add("style", "background:lightgray");
            txtCurrency.Attributes.Add("style", "background:lightgray");
            txtCustomerCode.Attributes.Add("style", "background:lightgray");
            txtCustomerName.Attributes.Add("style", "background:lightgray");
            txtSalesAmount.Attributes.Add("style", "background:lightgray");
            txtVATAmount.Attributes.Add("style", "background:lightgray");
            txtCommission.Attributes.Add("style", "background:lightgray");
            txtCashDiscount.Attributes.Add("style", "background:lightgray");
            txtNetAmount.Attributes.Add("style", "background:lightgray");
            
            #endregion
           
            #region Readonly Fields

            txtSalesType.Attributes.Add("readonly", "true");
            txtCreditDebit.Attributes.Add("readonly", "true");
            txtYear.Attributes.Add("readonly", "true");
            txtCRDBNo.Attributes.Add("readonly", "true");
            txtDate.Attributes.Add("readonly", "true");
            txtCRDBProposalNo.Attributes.Add("readonly", "true");
            txtType.Attributes.Add("readonly", "true");
            txtCurrency.Attributes.Add("readonly", "true"); 
            txtCustomerCode.Attributes.Add("readonly", "true");
            txtCustomerName.Attributes.Add("readonly", "true");
            txtSalesAmount.Attributes.Add("readonly", "true");
            txtVATAmount.Attributes.Add("readonly", "true");
            txtCommission.Attributes.Add("readonly", "true");
            txtCashDiscount.Attributes.Add("readonly", "true");
            txtNetAmount.Attributes.Add("readonly", "true");
           
            #endregion            

            //txtRate.Attributes.Add("onkeyup", "CalculateVatAndNetAmount();");                      
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
        lblInfo.Text = "";
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            if (ddlSearch.SelectedValue.ToString() == "CreditNotes")
            {
                GetAllCreditDebitList("1", txtSearch.Text.Trim());                
            }
            else if (ddlSearch.SelectedValue.ToString() == "DebitNotes")
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

    protected void imgCRDBProposalNo_Click(object sender, ImageClickEventArgs e)
    {
        lblInfo.Text = "";
        HidPopUpType.Value = "CRDBProposalNo";
        lPopUpHeader.Text = "Credit Debit Proposal No.";
        lSearch.Text = "Search By No.: ";
        FillAllCreditDebitProposalNo("");
        ModalPopupExtender2.Show();
    }

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (HidPopUpType.Value == "CRDBProposalNo")
            {
                if (e.Row.RowType != DataControlRowType.Pager)
                {                    
                    e.Row.Cells[1].Style.Add("display", "none");
                    e.Row.Cells[3].Style.Add("display", "none");
                    e.Row.Cells[4].Style.Add("display", "none");
                    e.Row.Cells[6].Style.Add("display", "none");
                    e.Row.Cells[7].Style.Add("display", "none");
                    e.Row.Cells[9].Style.Add("display", "none");
                    e.Row.Cells[10].Style.Add("display", "none");
                    e.Row.Cells[12].Style.Add("display", "none");
                    e.Row.Cells[13].Style.Add("display", "none");
                    e.Row.Cells[14].Style.Add("display", "none");
                    e.Row.Cells[15].Style.Add("display", "none");
                    e.Row.Cells[16].Style.Add("display", "none");
                    e.Row.Cells[19].Style.Add("display", "none");
                    e.Row.Cells[20].Style.Add("display", "none");
                }                          
            }
        }
        catch (Exception ex)
        {
        }
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
                if (HidPopUpType.Value == "CRDBProposalNo")
                {                    
                    DataTable dt = objFA_CreaditDebitNoteForm.Get_FA_CreditDebitNoteById(Convert.ToInt32 (e.CommandArgument));
                    if (dt.Rows.Count > 0)
                    {
                        HidCDNId.Value = dt.Rows[0]["CDNId"].ToString();
                        HidCBNProposalId.Value = Convert.ToString(e.CommandArgument);
                        txtCRDBProposalNo.Text = dt.Rows[0]["CRDBProposalNo"].ToString();
                        HidCreditDebitId.Value = dt.Rows[0]["CreditDebit"].ToString();
                        txtCreditDebit.Text = dt.Rows[0]["CreditDebitName"].ToString();
                        hidSalesType.Value = dt.Rows[0]["SalesTypeId"].ToString();
                        txtSalesType.Text = dt.Rows[0]["Sales Type"].ToString();
                        txtYear.Text = dt.Rows[0]["Year"].ToString();
                        txtDate.Text = dt.Rows[0]["Date"].ToString();
                        HidType.Value = dt.Rows[0]["Type"].ToString();
                        txtType.Text = dt.Rows[0]["TypeName"].ToString();
                        HidCurrency.Value = dt.Rows[0]["CurrencyId"].ToString();
                        txtCurrency.Text = dt.Rows[0]["Currency"].ToString();
                        txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        hidCustomerId.Value = dt.Rows[0]["CustomerID"].ToString();
                        txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                        txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                        txtProfitCenter.Text = dt.Rows[0]["ProfitCenter"].ToString();
                        txtSalesAmount.Text = dt.Rows[0]["SalesAmount"].ToString();
                        txtVATAmount.Text = dt.Rows[0]["VATAmount"].ToString();
                        txtCommission.Text = dt.Rows[0]["Commission"].ToString();
                        txtCashDiscount.Text = dt.Rows[0]["CashDiscount"].ToString();
                        txtNetAmount.Text = dt.Rows[0]["NetAmount"].ToString();
                        txtNotetoCustomerVendor.Text = dt.Rows[0]["NoteToCustomerVendor"].ToString();
                        lblInfo.Text = "Record already exists.";
                    }
                    else
                    {
                        HidCBNProposalId.Value = Convert.ToString(e.CommandArgument);
                        txtCRDBProposalNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                        txtCreditDebit.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                        hidSalesType.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                        txtSalesType.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                        txtYear.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[6].Text;
                        txtDate.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[18].Text;
                        HidType.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                        txtType.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[8].Text;
                        //txtCurrency.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                        //txtDescription.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text
                        hidCustomerId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[9].Text;
                        txtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[10].Text;
                        txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[11].Text;
                        txtProfitCenter.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[12].Text;
                        txtSalesAmount.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[13].Text;
                        txtVATAmount.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[14].Text;
                        txtCommission.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[15].Text;
                        txtCashDiscount.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[16].Text;
                        txtNetAmount.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[17].Text;
                        txtNotetoCustomerVendor.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[19].Text;
                        HidCreditDebitId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[20].Text;
                        lblInfo.Text = "";
                    }
                }
            }
        }
        catch { }
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

                DataTable dt = objFA_CreaditDebitNoteForm.Get_FA_CreditDebitNoteById(Convert.ToInt32 (e.CommandArgument));
                if (dt.Rows.Count > 0)
                {
                    HidCDNId.Value = dt.Rows[0]["CDNId"].ToString();
                    HidCBNProposalId.Value = Convert.ToString(e.CommandArgument);
                    txtCRDBProposalNo.Text = dt.Rows[0]["CRDBProposalNo"].ToString();
                    HidCreditDebitId.Value = dt.Rows[0]["CreditDebit"].ToString();
                    txtCreditDebit.Text = dt.Rows[0]["CreditDebitName"].ToString();
                    hidSalesType.Value = dt.Rows[0]["SalesTypeId"].ToString();
                    txtSalesType.Text = dt.Rows[0]["Sales Type"].ToString();
                    txtYear.Text = dt.Rows[0]["Year"].ToString();
                    txtDate.Text = dt.Rows[0]["Date"].ToString();
                    HidType.Value = dt.Rows[0]["Type"].ToString();
                    txtType.Text = dt.Rows[0]["TypeName"].ToString();
                    HidCurrency.Value = dt.Rows[0]["CurrencyId"].ToString();
                    txtCurrency.Text = dt.Rows[0]["Currency"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    hidCustomerId.Value = dt.Rows[0]["CustomerID"].ToString();
                    txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                    txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                    txtProfitCenter.Text = dt.Rows[0]["ProfitCenter"].ToString();
                    txtSalesAmount.Text = dt.Rows[0]["SalesAmount"].ToString();
                    txtVATAmount.Text = dt.Rows[0]["VATAmount"].ToString();
                    txtCommission.Text = dt.Rows[0]["Commission"].ToString();
                    txtCashDiscount.Text = dt.Rows[0]["CashDiscount"].ToString();
                    txtNetAmount.Text = dt.Rows[0]["NetAmount"].ToString();
                    txtNotetoCustomerVendor.Text = dt.Rows[0]["NoteToCustomerVendor"].ToString();
                    lblInfo.Text = "Record already exists.";
                }                
            }
        }
        catch { }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        { 
            if(HidCDNId.Value =="")
            {
                objFA_CreaditDebitNoteForm.CDNId= 0;
            }
            else
            {
                objFA_CreaditDebitNoteForm.CDNId=Convert.ToInt32 (HidCDNId.Value);
            }

               objFA_CreaditDebitNoteForm.CBDBProposalId = Convert.ToInt32 (HidCBNProposalId.Value);
               objFA_CreaditDebitNoteForm.CreditDebit = HidCreditDebitId.Value;
               objFA_CreaditDebitNoteForm.SalesTypeId = Convert.ToInt32 (hidSalesType.Value);
               objFA_CreaditDebitNoteForm.Year = txtYear.Text.Trim();
               objFA_CreaditDebitNoteForm.CRDBNo = txtCRDBNo.Text.Trim();
               objFA_CreaditDebitNoteForm.Date = DateTime.ParseExact(txtDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
               objFA_CreaditDebitNoteForm.Type = HidType.Value; 
               objFA_CreaditDebitNoteForm.CurrencyId = 1; 
               objFA_CreaditDebitNoteForm.Description = txtDescription.Text.Trim(); 
               objFA_CreaditDebitNoteForm.CustomerID = Convert.ToInt32 (hidCustomerId.Value );
               objFA_CreaditDebitNoteForm.ProfitCenter = Convert.ToDouble (txtProfitCenter.Text.Trim()); 
               objFA_CreaditDebitNoteForm.SalesAmount = Convert.ToDouble (txtSalesAmount.Text.Trim());
               objFA_CreaditDebitNoteForm.VATAmount = Convert.ToDouble (txtVATAmount.Text.Trim()); 
               objFA_CreaditDebitNoteForm.Commission =  Convert.ToDouble (txtCommission.Text.Trim());
               objFA_CreaditDebitNoteForm.CashDiscount = Convert.ToDouble (txtCashDiscount.Text.Trim()); 
               objFA_CreaditDebitNoteForm.NetAmount = Convert.ToDouble (txtNetAmount.Text.Trim());
               objFA_CreaditDebitNoteForm.NoteToCustomerVendor = txtNotetoCustomerVendor.Text.Trim(); 
               objFA_CreaditDebitNoteForm.ActiveStatus = true;
               objFA_CreaditDebitNoteForm.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
               objFA_CreaditDebitNoteForm.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

               FlagInsert = objFA_CreaditDebitNoteForm.InsertUpdate_In_Sal_Glb_CreditDebitNote_Tran();

               if (FlagInsert == -1)
               {
                   ClearForm();
                   MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
               }
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
            return;
        }
    }

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdFACreditDebit = ConfigurationManager.AppSettings["FormIdFACreditDebit"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdFACreditDebit);

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

    private void FillAllCreditDebitProposalNo(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objFA_CreaditDebitNoteForm.Get_CreditDebitNote_ByCDNNo(Searchtext);

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

    private void GetAllCreditDebitList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objFA_CreaditDebitNoteForm.Get_AllCreditDebitList(ddlSearchValue, txtSearchValue);

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

    public void ClearForm()
    {
        try
        {
            lblInfo.Text = "";
            HidCDNId.Value = "";
            HidCBNProposalId.Value = "";
            txtCRDBProposalNo.Text = "";
            txtCreditDebit.Text = "";
            hidSalesType.Value = "";
            txtSalesType.Text = "";
            txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            int PalletNo = RandomNumber(100000000, 999999999);
            txtCRDBNo.Text = Convert.ToString(PalletNo);
            FillFinancialYear();
            HidType.Value = "";
            txtType.Text = "";
            HidCurrency.Value = "";
            txtCurrency.Text = "";
            txtDescription.Text = "";
            hidCustomerId.Value = "";
            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            txtProfitCenter.Text = "";
            txtSalesAmount.Text = "";
            txtVATAmount.Text = "";
            txtCommission.Text = "";
            txtCashDiscount.Text = "";
            txtNetAmount.Text = "";
            txtNotetoCustomerVendor.Text = "";

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            ddlSearch.SelectedValue = "0";
            txtSearch.Text = "";

        }
        catch { }
    }

    #endregion

    #endregion



    
}