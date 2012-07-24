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
    PerformaInvoice_Tran objPerformaInvoice_Tran = new PerformaInvoice_Tran();
    SalesOrder_Trans objSalesOrder_Trans = new SalesOrder_Trans();
    BLLCollection<SalesOrder_Trans> objBllcollection = new BLLCollection<SalesOrder_Trans>();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();
    IFormatProvider provider = new System.Globalization.CultureInfo("en-US", true);
    string FlagInsertUpdate, SaveStatus;
    int TotalCountingrid;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            try
            {
                Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
                lblPageHeader.Text = "Sales Order";
                TCSalesOrder.ActiveTabIndex = 0;
               
                TDOrderNo.Attributes.Add("style", "display:none");
                TDtxtOrderNo.Attributes.Add("style", "display:none");

                #region Binding Drop Down Function

                FillFinancialYear();
                BindSOTypeMaster();
                BindDeliveryToMaster();
                BindFinalDestinationMaster();
                BindLogisticMaster();
                BindCertificateMaster();
                BindUnitofSaleMaster();
                BindDeliveryToleranceMaster();
                BindCurrencyMaster();
                BindPaymodeMaster();
                BindPackingStandardMaster();
                BindFilmTypeMaster();
                BindStickerType();
                Get_All_SalesArea_Master();
                Get_All_Salesorganization_Master();
                Get_All_Distribution_Master();
                Get_All_SubFilmType_Mst();
                Get_All_Thickness_Mst();

                #endregion

                #region Bind Masters

                BindSearchList();

                #endregion

                TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
                txtSearch.Text = "";

                #region Table Structure

                Get_SalesOrder_LineItem(0);

                #endregion

                #region Change Color of Readonly Fields

                txtSOYear.Attributes.Add("style", "background:lightgray");
                txtOrderNo.Attributes.Add("style", "background:lightgray");
                txtSODate.Attributes.Add("style", "background:lightgray");
                txtCustomerCode.Attributes.Add("style", "background:lightgray");
                txtConsignee.Attributes.Add("style", "background:lightgray");
                txtCustomerName.Attributes.Add("style", "background:lightgray");
                txtPINo.Attributes.Add("style", "background:lightgray");
                txtTermsofDelivery.Attributes.Add("style", "background:lightgray");
                txtCustomerOrderDate.Attributes.Add("style", "background:lightgray");
                txtRevisionDate.Attributes.Add("style", "background:lightgray");
                txtCommittedETD.Attributes.Add("style", "background:lightgray");
                txtCommittedETA.Attributes.Add("style", "background:lightgray");
                txtRevisedETD.Attributes.Add("style", "background:lightgray");
                txtRevisedETA.Attributes.Add("style", "background:lightgray");
                txtLineNo.Attributes.Add("style", "background:lightgray");
                txtWidthinInch.Attributes.Add("style", "background:lightgray");
                txtlengthinFt.Attributes.Add("style", "background:lightgray");
                txtDeliveryDate.Attributes.Add("style", "background:lightgray");
                txtProfitCenter.Attributes.Add("style", "background:lightgray");
                txtUnitPrice.Attributes.Add("style", "background:lightgray");

                #endregion

                txtSODate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
                txtSOYear.Attributes.Add("readonly", "true");
                txtOrderNo.Attributes.Add("readonly", "true");
                txtCustomerName.Attributes.Add("readonly", "true");
                txtSODate.Attributes.Add("readonly", "true");
                txtCustomerOrderDate.Attributes.Add("readonly", "true");
                txtRevisionDate.Attributes.Add("readonly", "true");
                txtCommittedETD.Attributes.Add("readonly", "true");
                txtCommittedETA.Attributes.Add("readonly", "true");
                txtRevisedETD.Attributes.Add("readonly", "true");
                txtRevisedETA.Attributes.Add("readonly", "true");
                txtCustomerCode.Attributes.Add("readonly", "true");
                txtConsignee.Attributes.Add("readonly", "true");
                txtTermsofDelivery.Attributes.Add("readonly", "true");
                txtPINo.Attributes.Add("readonly", "true");

                txtLineNo.Attributes.Add("readonly", "true");
                txtDeliveryDate.Attributes.Add("readonly", "true");
                txtWidthinInch.Attributes.Add("readonly", "true");
                txtlengthinFt.Attributes.Add("readonly", "true");
                txtProfitCenter.Attributes.Add("readonly", "true");
                txtUnitPrice.Attributes.Add("readonly", "true");

                ddlWidthinMM.Attributes.Add("onclick", "CalculateWidthInInch();");
                txtLengthinMtr.Attributes.Add("onkeyup", "CalculateLengthInFeet();");
                
                /***************************Added by Shrikant*******************************/
                int soid = 0;
                try
                {
                    soid = Convert.ToInt32(Request.QueryString["soid"].ToString());
                }
                catch (Exception ex)
                {
                }
                if (soid != 0)
                {
                    Get_SalesOrder_Header(soid);
                    Get_SalesOrder_LineItem(soid);
                }
                /****************************************************************************/

            }
            catch { }

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
        ClearHeaderItems();
        ClearLineItems();
        ClearLineItemGrid();
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        ddlSearch.SelectedValue = "0";
        txtSearch.Text = "";
        TDOrderNo.Attributes.Add("style", "display:none");
        TDtxtOrderNo.Attributes.Add("style", "display:none");
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        txtSearchList.Text = "";
        if (ddlSearch.SelectedValue != "0")
        {
            BindSalesOrderData(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
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
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectCustomer, 125, 300);
            }
        }
        else if (HidPopUpType.Value == "TermsOfDelivery")
        {
            FillAllTermsOfDelivery(txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindSalesOrderData(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvLineItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            for (int i = 0; i < gvLineItems.Columns.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("Id", "R" + e.Row.RowIndex.ToString() + "C" + i.ToString());
            }

            e.Row.Cells[1].Style.Add("display", "none");
            e.Row.Cells[23].Style.Add("display", "none");
            e.Row.Cells[25].Style.Add("display", "none");
            e.Row.Cells[26].Style.Add("display", "none");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.GridView gvLineItems = (System.Web.UI.WebControls.GridView)sender;
                GridViewRow Gi;
                Gi = e.Row;

                if (e.Row.Cells[20].Text == "True")
                {
                    e.Row.Cells[20].Text = "Yes";
                }
                else if (e.Row.Cells[20].Text == "False")
                {
                    e.Row.Cells[20].Text = "No";
                }
                if (e.Row.Cells[23].Text == "False")
                {
                    e.Row.Visible = false;
                }
                else if (e.Row.Cells[23].Text == "True")
                {
                    e.Row.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvLineItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvLineItems = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvLineItems.SelectedIndex = row.RowIndex + 1;

        DataTable objdtSOLineItem = new DataTable();
        objdtSOLineItem = (DataTable)ViewState["SO_LineItem"];

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvLineItems.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            if (objdtSOLineItem.Rows.Count > 0)
            {
                hidRowIndex.Value = Convert.ToString(row.RowIndex);
                hidLineItemId.Value = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOLineItemID"].ToString();
                HidUpdateGridRecord.Value = "Yes";
                txtLineNo.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LineNo"].ToString();
                ddlSubFilmType.SelectedValue = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubFilmType"].ToString();
                txtMicron.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOMicron"].ToString();
                txtCore.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOCore"].ToString();
                ddlWidthinMM.SelectedValue = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOWidthInMM"].ToString();
                txtWidthinInch.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOWidthInInch"].ToString();
                txtLengthinMtr.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOLengthInMtr"].ToString();
                txtlengthinFt.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOLengthInFt"].ToString();
                txtUnitPrice.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOUnitPrice"].ToString();
                txtNoofRoles.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SONoOfRolls"].ToString();
                txtRequiredQuantity.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOReqQuantityInKG"].ToString();
                txtDeliveryDate.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SODeliveryDate"].ToString();
                txtApplication.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOApplication"].ToString();
                txtCofMin.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOCOFMin"].ToString();
                txtCofMax.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOCOFMax"].ToString();
                txtOdMin.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODMin"].ToString();
                txtOdAvg.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODAvg"].ToString();
                txtOdMax.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODMax"].ToString();
                if (objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOInclude"].ToString() == "True")
                {
                    chkInclude.Checked = true;
                }
                else
                {
                    chkInclude.Checked = false;
                }                
                txtPalletType.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PalletType"].ToString();
                txtNoofRolesinPallet.Text = objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoofRollsInPallet"].ToString();
                ImgBtnAddLine.ImageUrl = "../Images/btnUpdateLine.png";                
            }
        }
        else if (e.CommandName == "Delete")
        {
            if (Convert.ToInt32(objdtSOLineItem.Rows[gvLineItems.SelectedIndex - 1]["SOLineItemID"].ToString()) == 0)
            {
                int PreviousLineNo = Convert.ToInt32(objdtSOLineItem.Rows[gvLineItems.SelectedIndex - 1]["LineNo"]);
                int PreviousLineItemId = Convert.ToInt32(objdtSOLineItem.Rows[gvLineItems.SelectedIndex - 1]["SOLineItemID"]);
                objdtSOLineItem.Rows[gvLineItems.SelectedIndex - 1].Delete();
                if (PreviousLineItemId == 0)
                {
                    txtLineNo.Text = Convert.ToString(PreviousLineNo);
                }
                else
                {
                    int TotalRows = objdtSOLineItem.Rows.Count;
                    txtLineNo.Text = (Convert.ToInt32(objdtSOLineItem.Rows[TotalRows - 1]["LineNo"].ToString()) + 10).ToString();
                }
            }
            else if (Convert.ToInt32(objdtSOLineItem.Rows[gvLineItems.SelectedIndex - 1]["SOLineItemID"].ToString()) != 0)
            {
                objdtSOLineItem.Rows[gvLineItems.SelectedIndex - 1]["ActiveStatus"] = "False";
                objdtSOLineItem.Rows[gvLineItems.SelectedIndex - 1]["IsUpdate"] = "Yes";

                int TotalRows = objdtSOLineItem.Rows.Count;
                txtLineNo.Text = (Convert.ToInt32(objdtSOLineItem.Rows[TotalRows - 1]["LineNo"].ToString()) + 10).ToString();
            }

            objdtSOLineItem.AcceptChanges();
            ViewState["SO_LineItem"] = objdtSOLineItem;

            if (objdtSOLineItem.Rows.Count > 0)
            {
                gvLineItems.DataSource = objdtSOLineItem;
                gvLineItems.DataBind();
            }
            else
            {
                Get_SalesOrder_LineItem(0);
            }
        }        
    }

    protected void gvLineItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }    

    protected void txtLengthinMtr_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (ddlSubFilmType.SelectedValue != "" && txtMicron.Text.Trim() != "" && txtCore.Text.Trim() != "" && ddlWidthinMM.SelectedValue != "" && txtLengthinMtr.Text.Trim() != "")
        {
            dt = objPerformaInvoice_Tran.Get_GetPalletType(Convert.ToInt32(ddlSubFilmType.SelectedValue), txtMicron.Text.Trim(), txtCore.Text.Trim(),
                Convert.ToDouble(ddlWidthinMM.SelectedValue), Convert.ToDouble(txtLengthinMtr.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
                txtPalletType.Text = dt.Rows[0]["PalletType"].ToString();
                txtNoofRolesinPallet.Text = dt.Rows[0]["NoofRolls"].ToString();
                HidNewValue.Value = "";
            }
            else
            {
                if (txtPalletType.Text != "" && txtNoofRolesinPallet.Text != "")
                { var a = hidRowIndex.Value; }
                else
                {
                    txtPalletType.Text = "";
                    txtNoofRolesinPallet.Text = "0";
                }
                HidNewValue.Value = "";
                txtUnitPrice.Focus();
            }
        }
        else
        {
            txtPalletType.Text = "";
            txtNoofRolesinPallet.Text = "0";
            HidNewValue.Value = "";
            txtUnitPrice.Focus();
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
                    txtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                }
                else if (HidPopUpType.Value == "Consignee")
                {
                    hidConsigneeId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtConsignee.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                }
                else if (HidPopUpType.Value == "TermsOfDelivery")
                {
                    hidTermsOfDeliveryId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtTermsofDelivery.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                }
                else if (HidPopUpType.Value == "ProformaInvoice")
                {
                    HidPI.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtPINo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
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

    protected void imgCustomerCode_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "CustomerCode";
        lPopUpHeader.Text = "Customer";
        lSearch.Text = "Search By Customer: ";
        FillAllCustomer("");
        ModalPopupExtender2.Show();
    }

    protected void imgConsignee_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
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
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectCustomer, 125, 300);
        }
    }

    protected void imgTermsofDelivery_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "TermsOfDelivery";
        lPopUpHeader.Text = "Terms Of Delivery";
        lSearch.Text = "Search By Terms Of Delivery: ";
        FillAllTermsOfDelivery("");
        ModalPopupExtender2.Show();
    }

    protected void imgPINo_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "ProformaInvoice";
        lPopUpHeader.Text = "Proforma Invoice";
        lSearch.Text = "Search By Proforma Invoice No.: ";
        FillAllProformaInvoice("");
        ModalPopupExtender2.Show();
    }

    protected void gvSalesOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvSalesOrder = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvSalesOrder.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvSalesOrder.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidSalesOrderId.Value = Convert.ToString(e.CommandArgument);
                Get_SalesOrder_Header(Convert.ToInt32(HidSalesOrderId.Value));
                Get_SalesOrder_LineItem(Convert.ToInt32(HidSalesOrderId.Value));
            }
        }
        catch { }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Upadte Record Of Header & Line Item

            DataTable dtSOLineItem = (DataTable)ViewState["SO_LineItem"];
            if (dtSOLineItem.Rows.Count > 0)
            {
                try
                {
                    #region Insert/Update Records Of Header

                    if (HidSalesOrderId.Value == "")
                    {
                        HidNewValue.Value = "True";
                        objSalesOrder_Trans.SalesOrderId = 0;
                    }
                    else
                    {
                        HidNewValue.Value = "False";
                        objSalesOrder_Trans.SalesOrderId = Convert.ToInt32(HidSalesOrderId.Value);
                    }
                    objSalesOrder_Trans.SOTypeID = Convert.ToInt32(ddlSOType.SelectedValue.ToString());
                    objSalesOrder_Trans.Year = txtSOYear.Text.Trim();
                    objSalesOrder_Trans.SODate = DateTime.ParseExact(txtSODate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    objSalesOrder_Trans.SOCustomer = Convert.ToInt32(hidCustomerId.Value);
                    objSalesOrder_Trans.CustomerOrderNo = txtCustomerOrderNo.Text.Trim();
                    objSalesOrder_Trans.CustomerArticleNo = txtCustomerArticleNo.Text.Trim();
                    objSalesOrder_Trans.CustomerPartNo = txtCustomerPartNo.Text.Trim();
                    objSalesOrder_Trans.SOConsignee = Convert.ToInt32(hidConsigneeId.Value);
                    objSalesOrder_Trans.SODeliveryTo = Convert.ToInt32(ddlDeliveryTo.SelectedValue.ToString());

                    objSalesOrder_Trans.SOFinalDestination = Convert.ToInt32(ddlFinalDestination.SelectedValue.ToString());
                    if (ddlDeliveryTolerance.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.SODeliveryTolerance = Convert.ToInt32(ddlDeliveryTolerance.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.SODeliveryTolerance = 0;
                    }

                    if (hidTermsOfDeliveryId.Value != "")
                    {
                        objSalesOrder_Trans.TermsOfDelivery = Convert.ToInt32(hidTermsOfDeliveryId.Value);
                    }
                    else
                    {
                        objSalesOrder_Trans.TermsOfDelivery = 0;
                    }

                    objSalesOrder_Trans.SOLogistics = Convert.ToInt32(ddlLogistic.SelectedValue.ToString());
                    if (HidPI.Value != "")
                    {
                        objSalesOrder_Trans.PINo = Convert.ToInt32(HidPI.Value);
                    }
                    else
                    {
                        objSalesOrder_Trans.PINo = 0;
                    }
                    objSalesOrder_Trans.SOPaymentMode = Convert.ToInt32(ddlPaymentMode.SelectedValue.ToString());
                    if (ddlCertificates.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.SOCertificates = Convert.ToInt32(ddlCertificates.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOCertificates = 0;
                    }
                    objSalesOrder_Trans.SOCurrency = Convert.ToInt32(ddlCurrency.SelectedValue.ToString());
                    if (ddlPackingStandard.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.SOPackingStandard = Convert.ToInt32(ddlPackingStandard.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOPackingStandard = 0;
                    }
                    if (ddlFilmType.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.SOFilmType = Convert.ToInt32(ddlFilmType.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOFilmType = 0;
                    }
                    if (txtCreditDays.Text.Trim() != "")
                    {
                        objSalesOrder_Trans.SOCreditDays = Convert.ToInt32(txtCreditDays.Text.Trim());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOCreditDays = 0;
                    }
                    if (txtCreditDaysFrom.Text.Trim() != "")
                    {
                        objSalesOrder_Trans.SOCreditDaysFrom = Convert.ToInt32(txtCreditDaysFrom.Text.Trim());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOCreditDaysFrom = 0;
                    }
                    if (ddlUnitofSale.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.SOUnitOfSales = Convert.ToInt32(ddlUnitofSale.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOUnitOfSales = 0;
                    }

                    if (ddlSalesArea.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.SalesAreaId = Convert.ToInt32(ddlSalesArea.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.SalesAreaId = 0;
                    }
                    if (ddlSalesOrganization.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.SalesOrganizationId = Convert.ToInt32(ddlSalesOrganization.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.SalesOrganizationId = 0;
                    }
                    if (ddlDistributionChannel.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.DistributionChannelId = Convert.ToInt32(ddlDistributionChannel.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.DistributionChannelId = 0;
                    }
                    if (txtProfitCenter.Text.Trim() != "")
                    {
                        objSalesOrder_Trans.ProfitCenterId = Convert.ToInt32(HidProfitCenterId.Value);
                    }
                    else
                    {
                        objSalesOrder_Trans.ProfitCenterId = 0;
                    }

                    if (txtCustomerOrderDate.Text != "")
                    {
                        objSalesOrder_Trans.SOCustomerOrderDate = DateTime.ParseExact(txtCustomerOrderDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    }
                    else
                    {
                        objSalesOrder_Trans.SOCustomerOrderDate = ""; ;
                    }
                    if (chkConfirmed.Checked == true)
                    {
                        objSalesOrder_Trans.Confirmed = true;
                    }
                    else
                    {
                        objSalesOrder_Trans.Confirmed = false;
                    }
                    objSalesOrder_Trans.RevisionNo = txtRevisionNo.Text.Trim();
                    if (txtRevisionDate.Text != "")
                    {
                        objSalesOrder_Trans.RevisionDate = DateTime.ParseExact(txtRevisionDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    }
                    else
                    {
                        objSalesOrder_Trans.RevisionDate = "";
                    }

                    if (chkVat.Checked == true)
                    {
                        objSalesOrder_Trans.SOVAT = true;
                    }
                    else
                    {
                        objSalesOrder_Trans.SOVAT = false;
                    }
                    if (chkCertificateOfOrigin.Checked == true)
                    {
                        objSalesOrder_Trans.SOCertificateOfOrigin = true;
                    }
                    else
                    {
                        objSalesOrder_Trans.SOCertificateOfOrigin = false;
                    }
                    if (chkPartialShipment.Checked == true)
                    {
                        objSalesOrder_Trans.PartialShipment = true;
                    }
                    else
                    {
                        objSalesOrder_Trans.PartialShipment = false;
                    }
                    objSalesOrder_Trans.SOPaymentTerms = txtPaymentTerms.Text.Trim();
                    objSalesOrder_Trans.SOPaymentTerms1 = txtPaymentTerms1.Text.Trim();
                    objSalesOrder_Trans.SOPaymentTerms2 = txtPaymentTerms2.Text.Trim();
                    objSalesOrder_Trans.SOSpecailIntructions = txtSpecialInstruction.Text.Trim();
                    if (txtCommittedETD.Text != "")
                    {
                        objSalesOrder_Trans.CommittedETD = DateTime.ParseExact(txtCommittedETD.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    }
                    else
                    {
                        objSalesOrder_Trans.CommittedETD = "";
                    }
                    if (txtCommittedETA.Text != "")
                    {
                        objSalesOrder_Trans.CommittedETA = DateTime.ParseExact(txtCommittedETA.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    }
                    else
                    {
                        objSalesOrder_Trans.CommittedETA = "";
                    }
                    if (txtRevisedETD.Text != "")
                    {
                        objSalesOrder_Trans.RevisedETD = DateTime.ParseExact(txtRevisedETD.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    }
                    else
                    {
                        objSalesOrder_Trans.RevisedETD = "";
                    }
                    if (txtRevisedETA.Text != "")
                    {
                        objSalesOrder_Trans.RevisedETA = DateTime.ParseExact(txtRevisedETA.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    }
                    else
                    {
                        objSalesOrder_Trans.RevisedETA = "";
                    }

                    if (txtInvoiceLength.Text != "")
                    {
                        objSalesOrder_Trans.SOInvoiceLength = Convert.ToDouble(txtInvoiceLength.Text.Trim());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOInvoiceLength = 0;
                    }
                    if (chkAllowJoints.Checked == true)
                    {
                        objSalesOrder_Trans.AllowJoints = true;
                    }
                    else
                    {
                        objSalesOrder_Trans.AllowJoints = false;
                    }
                    if (ddlStickerType.SelectedValue.ToString() != "")
                    {
                        objSalesOrder_Trans.SOStickerType = Convert.ToInt32(ddlStickerType.SelectedValue.ToString());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOStickerType = 0;
                    }
                    if (txtServiceLength.Text != "")
                    {
                        objSalesOrder_Trans.SOServiceLength = Convert.ToDouble(txtServiceLength.Text.Trim());
                    }
                    else
                    {
                        objSalesOrder_Trans.SOServiceLength = 0;
                    }
                    if (txtMaxLenTolerance.Text != "")
                    {
                        objSalesOrder_Trans.MaxLengthTolerance = Convert.ToInt32(txtMaxLenTolerance.Text.Trim());
                    }
                    else
                    {
                        objSalesOrder_Trans.MaxLengthTolerance = 0;
                    }
                    if (chkFumigation.Checked == true)
                    {
                        objSalesOrder_Trans.SOFumigation = true;
                    }
                    else
                    {
                        objSalesOrder_Trans.SOFumigation = false;
                    }
                    objSalesOrder_Trans.COOCTH = txtCOOCTH.Text.Trim();
                    objSalesOrder_Trans.BOIIncentive = txtBioIncentive.Text.Trim();

                    objSalesOrder_Trans.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                    objSalesOrder_Trans.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                    #endregion

                    #region Insert/Update Records of LineItem

                    objSalesOrder_Trans.dtSOLineItems = new DataTable();
                    objSalesOrder_Trans.dtSOLineItems = objSalesOrder_Trans.Get_SearchOrderLineItem(0);
                    DataRow objdrSOLineItems;

                    if (dtSOLineItem.Rows.Count > 0)
                    {
                        foreach (DataRow objdrSOLineItem in dtSOLineItem.Rows)
                        {
                            try
                            {
                                if ((objdrSOLineItem["SOLineItemID"].ToString() == "0" && objdrSOLineItem["IsUpdate"].ToString() == "No") || 
                                    (objdrSOLineItem["SOLineItemID"].ToString() == "0" && objdrSOLineItem["IsUpdate"].ToString() == "Yes") || 
                                    (objdrSOLineItem["SOLineItemID"].ToString() != "0" && objdrSOLineItem["IsUpdate"].ToString() == "Yes"))
                                {
                                    objdrSOLineItems = objSalesOrder_Trans.dtSOLineItems.NewRow();

                                    objdrSOLineItems["SOLineItemID"] = Convert.ToInt32(objdrSOLineItem["SOLineItemID"].ToString());

                                    objdrSOLineItems["LineNo"] = Convert.ToInt32(objdrSOLineItem["LineNo"].ToString());
                                    objdrSOLineItems["SubFilmType"] = Convert.ToInt32(objdrSOLineItem["SubFilmType"].ToString());
                                    objdrSOLineItems["SOMicron"] = objdrSOLineItem["SOMicron"].ToString();
                                    objdrSOLineItems["SOCore"] = objdrSOLineItem["SOCore"].ToString();
                                    objdrSOLineItems["SOWidthInMM"] = Convert.ToInt32(objdrSOLineItem["SOWidthInMM"].ToString());
                                    objdrSOLineItems["SOWidthInInch"] = Convert.ToDouble(objdrSOLineItem["SOWidthInInch"].ToString());
                                    objdrSOLineItems["SOLengthInMtr"] = Convert.ToDouble(objdrSOLineItem["SOLengthInMtr"].ToString());
                                    objdrSOLineItems["SOLengthInFt"] = Convert.ToDouble(objdrSOLineItem["SOLengthInFt"].ToString());
                                    objdrSOLineItems["SOUnitPrice"] = Convert.ToDouble(objdrSOLineItem["SOUnitPrice"].ToString());
                                    objdrSOLineItems["SONoOfRolls"] = Convert.ToInt32(objdrSOLineItem["SONoOfRolls"].ToString());
                                    objdrSOLineItems["SOReqQuantityInKG"] = Convert.ToDouble(objdrSOLineItem["SOReqQuantityInKG"].ToString());
                                    objdrSOLineItems["SODeliveryDate"] = objdrSOLineItem["SODeliveryDate"].ToString();
                                    objdrSOLineItems["SOApplication"] = objdrSOLineItem["SOApplication"].ToString();
                                    objdrSOLineItems["SOCOFMin"] = Convert.ToDouble(objdrSOLineItem["SOCOFMin"].ToString());
                                    objdrSOLineItems["SOCOFMax"] = Convert.ToDouble(objdrSOLineItem["SOCOFMax"].ToString());
                                    objdrSOLineItems["SOODMin"] = Convert.ToDouble(objdrSOLineItem["SOODMin"].ToString());
                                    objdrSOLineItems["SOODAvg"] = Convert.ToDouble(objdrSOLineItem["SOODAvg"].ToString());
                                    objdrSOLineItems["SOODMax"] = Convert.ToDouble(objdrSOLineItem["SOODMax"].ToString());
                                    objdrSOLineItems["ShipmentNo"] = objdrSOLineItem["ShipmentNo"].ToString();
                                    objdrSOLineItems["SOInclude"] = Convert.ToBoolean(objdrSOLineItem["SOInclude"].ToString());
                                    
                                    objdrSOLineItems["ActiveStatus"] = Convert.ToBoolean(objdrSOLineItem["ActiveStatus"].ToString());
                                    objdrSOLineItems["PalletType"] = objdrSOLineItem["PalletType"].ToString();
                                    objdrSOLineItems["NoofRollsInPallet"] = Convert.ToInt32(objdrSOLineItem["NoofRollsInPallet"].ToString());

                                    objSalesOrder_Trans.dtSOLineItems.Rows.Add(objdrSOLineItems);
                                    objSalesOrder_Trans.dtSOLineItems.AcceptChanges();
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

                    FlagInsertUpdate = objSalesOrder_Trans.InsertUpdate_In_Glb_SalesOrder();
                    if (FlagInsertUpdate == "YES")
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                        #region Clear All records after save

                        ClearHeaderItems();
                        ClearLineItems();
                        txtLineNo.Text = "10";
                        Get_SalesOrder_LineItem(0);

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
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
        }
    }

    protected void ImgBtnAddLine_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable objdtSOLineItem = new DataTable();

            objdtSOLineItem = (DataTable)ViewState["SO_LineItem"];
            if (HidUpdateGridRecord.Value == "")
            {
                DataRow objdrSOLineItem = objdtSOLineItem.NewRow();
                objdrSOLineItem["SOLineItemID"] = 0;
                objdrSOLineItem["IsUpdate"] = "No";
                objdrSOLineItem["LineNo"] = Convert.ToInt32(txtLineNo.Text.Trim());
                if (HidSalesOrderId.Value != "")
                {
                    objdrSOLineItem["SalesOrderId"] = Convert.ToInt32(HidSalesOrderId.Value);
                }
                else
                {
                    objdrSOLineItem["SalesOrderId"] = 0;
                }
                if (ddlSubFilmType.SelectedValue.ToString() != "")
                {
                    objdrSOLineItem["SubFilmType"] = Convert.ToInt32(ddlSubFilmType.SelectedValue.ToString());
                    objdrSOLineItem["SubFilmTypeName"] = ddlSubFilmType.SelectedItem.Text;
                }
                else
                {
                    objdrSOLineItem["SubFilmType"] = 0;
                    objdrSOLineItem["SubFilmTypeName"] = "";
                }
                objdrSOLineItem["SOMicron"] = txtMicron.Text.Trim();
                objdrSOLineItem["SOCore"] = txtCore.Text.Trim();
                if (ddlWidthinMM.SelectedValue != "")
                {
                    objdrSOLineItem["SOWidthInMM"] = Convert.ToInt32(ddlWidthinMM.SelectedValue);
                    objdrSOLineItem["WidthInMMName"] = ddlWidthinMM.SelectedItem.Text;
                }
                else
                {
                    objdrSOLineItem["SOWidthInMM"] = 0;
                    objdrSOLineItem["WidthInMMName"] = "";
                }               

                objdrSOLineItem["SOWidthInInch"] = Convert.ToDouble(txtWidthinInch.Text.Trim());
                if (txtLengthinMtr.Text != "")
                {
                    objdrSOLineItem["SOLengthInMtr"] = Convert.ToDouble(txtLengthinMtr.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SOLengthInMtr"] = 0;
                }
                objdrSOLineItem["SOLengthInFt"] = Convert.ToDouble(txtlengthinFt.Text.Trim());
                if (txtUnitPrice.Text != "")
                {
                    objdrSOLineItem["SOUnitPrice"] = Convert.ToDouble(txtUnitPrice.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SOUnitPrice"] = 0;
                }
                if (txtNoofRoles.Text != "")
                {
                    objdrSOLineItem["SONoOfRolls"] = Convert.ToDouble(txtNoofRoles.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SONoOfRolls"] = 0;
                }
                if (txtRequiredQuantity.Text != "")
                {
                    objdrSOLineItem["SOReqQuantityInKG"] = Convert.ToDouble(txtRequiredQuantity.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SOReqQuantityInKG"] = 0;
                }
                if (txtDeliveryDate.Text != "")
                {
                    objdrSOLineItem["SODeliveryDate"] = txtDeliveryDate.Text.Trim();
                }
                else
                {
                    objdrSOLineItem["SODeliveryDate"] = "";
                }
                objdrSOLineItem["SOApplication"] = txtApplication.Text.Trim();
                if (txtCofMin.Text != "")
                {
                    objdrSOLineItem["SOCOFMin"] = Convert.ToDouble(txtCofMin.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SOCOFMin"] = 0;
                }
                if (txtCofMax.Text != "")
                {
                    objdrSOLineItem["SOCOFMax"] = Convert.ToDouble(txtCofMax.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SOCOFMax"] = 0;
                }
                if (txtOdMin.Text != "")
                {
                    objdrSOLineItem["SOODMin"] = Convert.ToDouble(txtOdMin.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SOODMin"] = 0;
                }
                if (txtOdAvg.Text != "")
                {
                    objdrSOLineItem["SOODAvg"] = Convert.ToDouble(txtOdAvg.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SOODAvg"] = 0;
                }
                if (txtOdMax.Text != "")
                {
                    objdrSOLineItem["SOODMax"] = Convert.ToDouble(txtOdMax.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["SOODMax"] = 0;
                }
                if (chkInclude.Checked == true)
                {
                    objdrSOLineItem["SOInclude"] = 1;
                }
                else
                {
                    objdrSOLineItem["SOInclude"] = 0;
                }
                
                objdrSOLineItem["ActiveStatus"] = true;
                if (txtPalletType.Text.Trim() != "")
                {
                    objdrSOLineItem["PalletType"] = txtPalletType.Text.Trim();
                }
                else
                {
                    objdrSOLineItem["PalletType"] = "";
                }
                if (txtNoofRolesinPallet.Text.Trim() != "")
                {
                    objdrSOLineItem["NoofRollsInPallet"] = Convert.ToInt32(txtNoofRolesinPallet.Text.Trim());
                }
                else
                {
                    objdrSOLineItem["NoofRollsInPallet"] = 0;
                }
                objdrSOLineItem["CreatedBy"] = Convert.ToInt32(Session["UserId"].ToString());
                objdtSOLineItem.Rows.Add(objdrSOLineItem);
            }
            else if (HidUpdateGridRecord.Value == "Yes")
            {
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["IsUpdate"] = "Yes";
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LineNo"] = Convert.ToInt32(txtLineNo.Text.Trim());
                if (HidSalesOrderId.Value != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SalesOrderId"] = Convert.ToInt32(HidSalesOrderId.Value);
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SalesOrderId"] = 0;
                }
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubFilmType"] = Convert.ToInt32(ddlSubFilmType.SelectedValue.ToString());
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubFilmTypeName"] = ddlSubFilmType.SelectedItem.Text;
                
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOMicron"] = txtMicron.Text.Trim();
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOCore"] = txtCore.Text.Trim();
                if (ddlWidthinMM.SelectedValue != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOWidthInMM"] = Convert.ToInt32(ddlWidthinMM.SelectedValue);
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInMMName"] = ddlWidthinMM.SelectedItem.Text;
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOWidthInMM"] = 0;
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInMMName"] = "";
                }               

                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOWidthInInch"] = Convert.ToDouble(txtWidthinInch.Text.Trim());
                if (txtLengthinMtr.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOLengthInMtr"] = Convert.ToDouble(txtLengthinMtr.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOLengthInMtr"] = 0;
                }
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOLengthInFt"] = Convert.ToDouble(txtlengthinFt.Text.Trim());
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOUnitPrice"] = txtUnitPrice.Text.Trim();
                if (txtNoofRoles.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SONoOfRolls"] = Convert.ToDouble(txtNoofRoles.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SONoOfRolls"] = 0;
                }
                if (txtRequiredQuantity.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOReqQuantityInKG"] = Convert.ToDouble(txtRequiredQuantity.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOReqQuantityInKG"] = 0;
                }
                if (txtDeliveryDate.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SODeliveryDate"] = txtDeliveryDate.Text.Trim();
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SODeliveryDate"] = "";
                }
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOApplication"] = txtApplication.Text.Trim();
                if (txtCofMin.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOCOFMin"] = Convert.ToDouble(txtCofMin.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOCOFMin"] = 0;
                }
                if (txtCofMax.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOCOFMax"] = Convert.ToDouble(txtCofMax.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOCOFMax"] = 0;
                }
                if (txtOdMin.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODMin"] = Convert.ToDouble(txtOdMin.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODMin"] = 0;
                }
                if (txtOdAvg.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODAvg"] = Convert.ToDouble(txtOdAvg.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODAvg"] = 0;
                }
                if (txtOdMax.Text != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODMax"] = Convert.ToDouble(txtOdMax.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOODMax"] = 0;
                }
                if (chkInclude.Checked == true)
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOInclude"] = 1;
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SOInclude"] = 0;
                }
                
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ActiveStatus"] = true;
                if (txtPalletType.Text.Trim() != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PalletType"] = txtPalletType.Text.Trim();
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PalletType"] = "";
                }
                if (txtNoofRolesinPallet.Text.Trim() != "")
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoofRollsInPallet"] = Convert.ToInt32(txtNoofRolesinPallet.Text.Trim());
                }
                else
                {
                    objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoofRollsInPallet"] = 0;
                }
                objdtSOLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["CreatedBy"] = Convert.ToInt32(Session["UserId"].ToString());
            }

            ViewState["SO_LineItem"] = objdtSOLineItem;
            int LineNoInGrid = Convert.ToInt32(objdtSOLineItem.Rows[0]["LineNo"].ToString());
            for (int i = 1; i < objdtSOLineItem.Rows.Count; i++)
            {
                if (Convert.ToInt32(objdtSOLineItem.Rows[i]["LineNo"].ToString()) > LineNoInGrid)
                {
                    LineNoInGrid = Convert.ToInt32(objdtSOLineItem.Rows[i]["LineNo"].ToString());
                }
            }
            txtLineNo.Text = (LineNoInGrid + 10).ToString();

            gvLineItems.DataSource = objdtSOLineItem;
            gvLineItems.DataBind();
            ClearLineItems();            
            TCSalesOrder.ActiveTabIndex = 1;
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.ErrorToLineItem, 125, 300);
        }
    }

    protected void gvSalesOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSalesOrder.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindSalesOrderData(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender1.Show();
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
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void ddlDistributionChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistributionChannel.SelectedValue != "" && ddlSalesArea.SelectedValue != "" && ddlSalesOrganization.SelectedValue != "")
        {
            DataTable dt = new DataTable();
            dt = objPerformaInvoice_Tran.Get_ProfitCenter(Convert.ToInt32(ddlSalesArea.SelectedValue), Convert.ToInt32(ddlSalesOrganization.SelectedValue),
                Convert.ToInt32(ddlDistributionChannel.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                HidProfitCenterId.Value = dt.Rows[0]["ProfitCenterId"].ToString();
                txtProfitCenter.Text = dt.Rows[0]["ProfitCenter"].ToString();
            }
            else
            {
                HidProfitCenterId.Value = "0";
                txtProfitCenter.Text = "";
            }
        }
    }

    protected void ddlSalesArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistributionChannel.SelectedValue != "" && ddlSalesArea.SelectedValue != "" && ddlSalesOrganization.SelectedValue != "")
        {
            DataTable dt = new DataTable();
            dt = objPerformaInvoice_Tran.Get_ProfitCenter(Convert.ToInt32(ddlSalesArea.SelectedValue), Convert.ToInt32(ddlSalesOrganization.SelectedValue),
                Convert.ToInt32(ddlDistributionChannel.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                HidProfitCenterId.Value = dt.Rows[0]["ProfitCenterId"].ToString();
                txtProfitCenter.Text = dt.Rows[0]["ProfitCenter"].ToString();
            }
            else
            {
                HidProfitCenterId.Value = "0";
                txtProfitCenter.Text = "";
            }
        }
    }

    protected void ddlSalesOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistributionChannel.SelectedValue != "" && ddlSalesArea.SelectedValue != "" && ddlSalesOrganization.SelectedValue != "")
        {
            DataTable dt = new DataTable();
            dt = objPerformaInvoice_Tran.Get_ProfitCenter(Convert.ToInt32(ddlSalesArea.SelectedValue), Convert.ToInt32(ddlSalesOrganization.SelectedValue),
                Convert.ToInt32(ddlDistributionChannel.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                HidProfitCenterId.Value = dt.Rows[0]["ProfitCenterId"].ToString();
                txtProfitCenter.Text = dt.Rows[0]["ProfitCenter"].ToString();
            }
            else
            {
                HidProfitCenterId.Value = "0";
                txtProfitCenter.Text = "";
            }
        }
    }

    protected void ddlWidthinMM_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWidthinMM.SelectedValue != "")
        {
            if (hidCustomerId.Value != "" && ddlSalesOrganization.SelectedValue != "" && ddlSalesArea.SelectedValue != "" && ddlWidthinMM.SelectedValue != "" && ddlFilmType.SelectedValue != "")
            {
                DataTable dt = new DataTable();
                dt = objPerformaInvoice_Tran.Get_UnitPricesFromMapping_Tran(Convert.ToInt32(ddlSalesArea.SelectedValue), Convert.ToInt32(ddlSalesOrganization.SelectedValue),
                    Convert.ToInt32(ddlWidthinMM.SelectedValue), Convert.ToInt32(hidCustomerId.Value), Convert.ToInt32(ddlFilmType.SelectedValue), 0);
                if (dt.Rows.Count > 0)
                {
                    txtUnitPrice.Text = dt.Rows[0]["Price"].ToString();
                }
                else
                {
                    txtUnitPrice.Text = "";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.MappingNotFoundForPrice, 125, 300);
                }
            }
            else if (ddlSalesOrganization.SelectedValue != "" && ddlSalesArea.SelectedValue != "" && ddlWidthinMM.SelectedValue != "" && ddlFilmType.SelectedValue != "")
            {
                DataTable dt = new DataTable();
                dt = objPerformaInvoice_Tran.Get_UnitPricesFromMapping_Tran(Convert.ToInt32(ddlSalesArea.SelectedValue), Convert.ToInt32(ddlSalesOrganization.SelectedValue),
                    Convert.ToInt32(ddlWidthinMM.SelectedValue), 0, Convert.ToInt32(ddlFilmType.SelectedValue), 0);
                if (dt.Rows.Count > 0)
                {
                    txtUnitPrice.Text = dt.Rows[0]["Price"].ToString();
                }
                else
                {
                    txtUnitPrice.Text = "";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.MappingNotFoundForPrice, 125, 300);
                }
            }
            else if (HidMaterialCode.Value != "" && ddlSalesOrganization.SelectedValue != "" && ddlSalesArea.SelectedValue != "")
            {
                DataTable dt = new DataTable();
                dt = objPerformaInvoice_Tran.Get_UnitPricesFromMapping_Tran(Convert.ToInt32(ddlSalesArea.SelectedValue), Convert.ToInt32(ddlSalesOrganization.SelectedValue),
                    0, 0, 0, Convert.ToInt32(HidMaterialCode.Value));
                if (dt.Rows.Count > 0)
                {
                    txtUnitPrice.Text = dt.Rows[0]["Price"].ToString();
                }
                else
                {
                    txtUnitPrice.Text = "";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.MappingNotFoundForPrice, 125, 300);
                }
            }
            else
            {
                txtUnitPrice.Text = "";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.MappingNotFoundForPrice, 125, 300);
            }
        }
        else
        {
            txtUnitPrice.Text = "";
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
            string FormIdSalesOrder = ConfigurationManager.AppSettings["FormIdSalesOrder"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdSalesOrder);

            ddlSearch.DataTextField = "Options";
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();
                ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
            }
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
                    txtSOYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    txtSOYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch (Exception ex) { }
    }

    protected void BindSOTypeMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_AllPIType();
            ddlSOType.DataTextField = "PerfInvTypeName";
            ddlSOType.DataValueField = "PerfInvTypeID";
            ddlSOType.DataSource = colRCommontype;
            ddlSOType.DataBind();
            ddlSOType.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindDeliveryToMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_AllDeliveryToType();
            ddlDeliveryTo.DataTextField = "DeliveryToName";
            ddlDeliveryTo.DataValueField = "DeliveryToID";
            ddlDeliveryTo.DataSource = colRCommontype;
            ddlDeliveryTo.DataBind();
            ddlDeliveryTo.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindFinalDestinationMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_AllFinalDestination();
            ddlFinalDestination.DataTextField = "FinalDestinationName";
            ddlFinalDestination.DataValueField = "FinalDestinationID";
            ddlFinalDestination.DataSource = colRCommontype;
            ddlFinalDestination.DataBind();
            ddlFinalDestination.Items.Insert(0, new ListItem("-Select-", ""));


        }
        catch (Exception ex) { }
    }

    protected void BindLogisticMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Glb_Logistic_Master();
            ddlLogistic.DataTextField = "LogisticName";
            ddlLogistic.DataValueField = "LogisticID";
            ddlLogistic.DataSource = colRCommontype;
            ddlLogistic.DataBind();
            ddlLogistic.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindCertificateMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Certificate_Master();
            ddlCertificates.DataTextField = "CertificateName";
            ddlCertificates.DataValueField = "CertificateID";
            ddlCertificates.DataSource = colRCommontype;
            ddlCertificates.DataBind();
            ddlCertificates.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindUnitofSaleMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_UnitOfSale_Master();
            ddlUnitofSale.DataTextField = "UnitSaleName";
            ddlUnitofSale.DataValueField = "UnitSaleID";
            ddlUnitofSale.DataSource = colRCommontype;
            ddlUnitofSale.DataBind();
            ddlUnitofSale.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindDeliveryToleranceMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_DeliveryTolerance_Master();
            ddlDeliveryTolerance.DataTextField = "DeliveryToleranceName";
            ddlDeliveryTolerance.DataValueField = "DeliveryToleranceID";
            ddlDeliveryTolerance.DataSource = colRCommontype;
            ddlDeliveryTolerance.DataBind();
            ddlDeliveryTolerance.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindCurrencyMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Currency_Master();
            ddlCurrency.DataTextField = "CurrencyCode";
            ddlCurrency.DataValueField = "CurrencyID";
            ddlCurrency.DataSource = colRCommontype;
            ddlCurrency.DataBind();
            ddlCurrency.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindPaymodeMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Paymode_Master();
            ddlPaymentMode.DataTextField = "PaymodeName";
            ddlPaymentMode.DataValueField = "PayModeID";
            ddlPaymentMode.DataSource = colRCommontype;
            ddlPaymentMode.DataBind();
            ddlPaymentMode.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindPackingStandardMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_PackingStandard_Master();
            ddlPackingStandard.DataTextField = "PackingStandardName";
            ddlPackingStandard.DataValueField = "PackingStandardID";
            ddlPackingStandard.DataSource = colRCommontype;
            ddlPackingStandard.DataBind();
            ddlPackingStandard.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    protected void BindFilmTypeMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_FilmType_Master();
            ddlFilmType.DataTextField = "FilmTypeName";
            ddlFilmType.DataValueField = "FilmTypeID";
            ddlFilmType.DataSource = colRCommontype;
            ddlFilmType.DataBind();
            ddlFilmType.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    public void BindStickerType()
    {
        colRCommontype = objCommon_mst.Get_StickerType();
        ddlStickerType.DataTextField = "StickerTypeName";
        ddlStickerType.DataValueField = "StickerTypeID";
        ddlStickerType.DataSource = colRCommontype;
        ddlStickerType.DataBind();
        ddlStickerType.Items.Insert(0, new ListItem("-Select-", ""));
    }

    protected void Get_All_SalesArea_Master()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_SalesArea_Master();
            ddlSalesArea.DataTextField = "SalesAreaCode";
            ddlSalesArea.DataValueField = "AutoId";
            ddlSalesArea.DataSource = colRCommontype;
            ddlSalesArea.DataBind();
            ddlSalesArea.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Salesorganization_Master()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Salesorganization_Master();
            ddlSalesOrganization.DataTextField = "SalesOrgCode";
            ddlSalesOrganization.DataValueField = "AutoId";
            ddlSalesOrganization.DataSource = colRCommontype;
            ddlSalesOrganization.DataBind();
            ddlSalesOrganization.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Distribution_Master()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Distribution_Master();
            ddlDistributionChannel.DataTextField = "Code";
            ddlDistributionChannel.DataValueField = "AutoId";
            ddlDistributionChannel.DataSource = colRCommontype;
            ddlDistributionChannel.DataBind();
            ddlDistributionChannel.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_SubFilmType_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_SubFilmType_Mst();
            ddlSubFilmType.DataTextField = "SubFilmTypeName";
            ddlSubFilmType.DataValueField = "SubFilmTypeId";
            ddlSubFilmType.DataSource = colRCommontype;
            ddlSubFilmType.DataBind();
            ddlSubFilmType.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Thickness_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Thickness_Mst();
            ddlWidthinMM.DataTextField = "Thickness";
            ddlWidthinMM.DataValueField = "ThicknessId";
            ddlWidthinMM.DataSource = colRCommontype;
            ddlWidthinMM.DataBind();
            ddlWidthinMM.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
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

    private void FillAllConsigneeByCustomerId(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllConsigneeByCustomerId(hidCustomerId.Value, Searchtext);

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

    private void FillAllTermsOfDelivery(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllTermsOfDelivery(Searchtext);

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

    private void FillAllProformaInvoice(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllProformaInvoice(Searchtext);

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

    #endregion

    #region Function to clear records

    public void ClearHeaderItems()
    {
        FillFinancialYear();
        HidSalesOrderId.Value = "";
        ddlSOType.SelectedValue = "";
        txtOrderNo.Text = "";
        txtSODate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        txtCustomerCode.Text = "";
        hidCustomerId.Value = "";
        txtCustomerName.Text = "";
        txtConsignee.Text = "";
        hidConsigneeId.Value = "";
        ddlDeliveryTo.SelectedValue = "";
        ddlFinalDestination.SelectedValue = "";
        ddlDeliveryTolerance.SelectedValue = "";
        txtTermsofDelivery.Text = "";
        hidTermsOfDeliveryId.Value = "";
        ddlLogistic.SelectedValue = "";
        txtPINo.Text = "";
        ddlPaymentMode.SelectedValue = "";
        ddlCertificates.SelectedValue = "";
        ddlCurrency.SelectedValue = "";
        ddlPackingStandard.SelectedValue = "";
        ddlFilmType.SelectedValue = "";
        txtCreditDays.Text = "";
        txtCreditDaysFrom.Text = "";
        ddlUnitofSale.SelectedValue = "";
        txtCustomerOrderNo.Text = "";
        txtCustomerArticleNo.Text = "";
        txtCustomerPartNo.Text = "";
        txtCustomerOrderDate.Text = "";
        chkConfirmed.Checked = false;
        txtRevisionNo.Text = "";
        txtRevisionDate.Text = "";
        chkVat.Checked = false;
        chkCertificateOfOrigin.Checked = false;
        chkPartialShipment.Checked = false;
        txtPaymentTerms.Text = "";
        txtPaymentTerms1.Text = "";
        txtPaymentTerms2.Text = "";
        txtSpecialInstruction.Text = "";
        txtCommittedETD.Text = "";
        txtCommittedETA.Text = "";
        txtRevisedETD.Text = "";
        txtRevisedETA.Text = "";
        txtInvoiceLength.Text = "";
        chkAllowJoints.Checked = false;
        ddlStickerType.SelectedValue = "";
        txtServiceLength.Text = "";
        txtMaxLenTolerance.Text = "";
        chkFumigation.Checked = false;
        txtCOOCTH.Text = "";
        txtBioIncentive.Text = "";
        ddlSalesArea.SelectedValue = "";
        ddlSalesOrganization.SelectedValue = "";
        ddlDistributionChannel.SelectedValue = "";
        HidProfitCenterId.Value = "";
        txtProfitCenter.Text = "";
    }

    public void ClearLineItems()
    {
        ddlSubFilmType.SelectedValue = "";
        txtMicron.Text = "";
        txtCore.Text = "";
        ddlWidthinMM.SelectedValue = "";
        txtWidthinInch.Text = "";
        txtLengthinMtr.Text = "";
        txtlengthinFt.Text = "";
        txtUnitPrice.Text = "";
        txtNoofRoles.Text = "";
        txtRequiredQuantity.Text = "";
        txtDeliveryDate.Text = "";
        txtApplication.Text = "";
        txtCofMin.Text = "";
        txtCofMax.Text = "";
        txtOdMin.Text = "";
        txtOdAvg.Text = "";
        txtOdMax.Text = "";
        
        txtPalletType.Text = "";
        txtNoofRolesinPallet.Text = "";
        chkInclude.Checked = false;
        HidUpdateGridRecord.Value = "";
        ImgBtnAddLine.ImageUrl = "../Images/btnAddLine.png";
    }

    public void ClearLineItemGrid()
    {
        try
        {
            ViewState["SO_LineItem"] = null;
            Get_SalesOrder_LineItem(0);
            txtLineNo.Text = "10";
            gvLineItems.AllowPaging = false;
            gvLineItems.DataSource = "";
            gvLineItems.DataBind();
        }
        catch { }
    }

    #endregion

    #region Function to fill Line Item records for Search

    private void BindSalesOrderData(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSalesOrder_Trans.Get_SalesOrderAllRecords(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvSalesOrder.DataSource = dt;
                gvSalesOrder.AllowPaging = true;
                gvSalesOrder.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvSalesOrder.AllowPaging = false;
                gvSalesOrder.DataSource = "";
                gvSalesOrder.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    #region Function to Fill Form Data

    protected void Get_SalesOrder_Header(int SalesOrderID)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSalesOrder_Trans.Get_SalesOrder_Header(SalesOrderID);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["SOTypeID"].ToString() != "0")
                {
                    ddlSOType.SelectedValue = dt.Rows[0]["SOTypeID"].ToString();
                }
                else
                {
                    ddlSOType.SelectedValue = "";
                }
                txtSOYear.Text = dt.Rows[0]["SOFYear"].ToString();

                txtOrderNo.Text = dt.Rows[0]["SONo"].ToString();
                TDOrderNo.Attributes.Add("style", "display:block");
                TDtxtOrderNo.Attributes.Add("style", "display:block");

                txtSODate.Text = dt.Rows[0]["SODate"].ToString();
                hidCustomerId.Value = dt.Rows[0]["SOCustomer"].ToString();
                txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                hidConsigneeId.Value = dt.Rows[0]["SOConsignee"].ToString();
                txtConsignee.Text = dt.Rows[0]["ConsigneeName"].ToString();
                if (dt.Rows[0]["SODeliveryTo"].ToString() != "0")
                {
                    ddlDeliveryTo.SelectedValue = dt.Rows[0]["SODeliveryTo"].ToString();
                }
                else
                {
                    ddlDeliveryTo.SelectedValue = "";
                }
                if (dt.Rows[0]["SOFinalDestination"].ToString() != "0")
                {
                    ddlFinalDestination.SelectedValue = dt.Rows[0]["SOFinalDestination"].ToString();
                }
                else
                {
                    ddlFinalDestination.SelectedValue = "0";
                }
                if (dt.Rows[0]["SODeliveryTolerance"].ToString() != "0")
                {
                    ddlDeliveryTolerance.SelectedValue = dt.Rows[0]["SODeliveryTolerance"].ToString();
                }
                else
                {
                    ddlDeliveryTolerance.SelectedValue = "";
                }
                hidTermsOfDeliveryId.Value = dt.Rows[0]["TermsOfDelivery"].ToString();
                txtTermsofDelivery.Text = dt.Rows[0]["TermsofDeliveryName"].ToString();
                if (dt.Rows[0]["SOLogistics"].ToString() != "0")
                {
                    ddlLogistic.SelectedValue = dt.Rows[0]["SOLogistics"].ToString();
                }
                else
                {
                    ddlLogistic.SelectedValue = "";
                }
                HidPI.Value = dt.Rows[0]["ProformaInvoiceId"].ToString();
                if (dt.Rows[0]["PINo"].ToString() != "")
                {
                    txtPINo.Text = dt.Rows[0]["PINo"].ToString();
                }
                else
                {
                    txtPINo.Text = "";
                }

                if (dt.Rows[0]["SOPaymentMode"].ToString() != "0")
                {
                    ddlPaymentMode.SelectedValue = dt.Rows[0]["SOPaymentMode"].ToString();
                }
                else
                {
                    ddlPaymentMode.SelectedValue = "";
                }
                if (dt.Rows[0]["SOCertificates"].ToString() != "0")
                {
                    ddlCertificates.SelectedValue = dt.Rows[0]["SOCertificates"].ToString();
                }
                else
                {
                    ddlCertificates.SelectedValue = "";
                }
                if (dt.Rows[0]["SOCurrency"].ToString() != "0")
                {
                    ddlCurrency.SelectedValue = dt.Rows[0]["SOCurrency"].ToString();
                }
                else
                {
                    ddlCurrency.SelectedValue = "";
                }
                if (dt.Rows[0]["SOPackingStandard"].ToString() != "0")
                {
                    ddlPackingStandard.SelectedValue = dt.Rows[0]["SOPackingStandard"].ToString();
                }
                else
                {
                    ddlPackingStandard.SelectedValue = "";
                }
                if (dt.Rows[0]["SOFilmType"].ToString() != "0")
                {
                    ddlFilmType.SelectedValue = dt.Rows[0]["SOFilmType"].ToString();
                }
                else
                {
                    ddlFilmType.SelectedValue = "";
                }
                txtCreditDays.Text = dt.Rows[0]["SOCreditDays"].ToString();
                txtCreditDaysFrom.Text = dt.Rows[0]["SOCreditDaysFrom"].ToString();
                if (dt.Rows[0]["SOUnitOfSales"].ToString() != "0")
                {
                    ddlUnitofSale.SelectedValue = dt.Rows[0]["SOUnitOfSales"].ToString();
                }
                else
                {
                    ddlUnitofSale.SelectedValue = "";
                }
                txtCustomerOrderNo.Text = dt.Rows[0]["CustomerOrderNo"].ToString();
                txtCustomerArticleNo.Text = dt.Rows[0]["CustomerArticleNo"].ToString();
                txtCustomerPartNo.Text = dt.Rows[0]["CustomerPartNo"].ToString();
                txtCustomerOrderDate.Text = dt.Rows[0]["SOCustomerOrderDate"].ToString();
                if (dt.Rows[0]["Confirmed"].ToString() == "True")
                {
                    chkConfirmed.Checked = true;
                }
                else
                {
                    chkConfirmed.Checked = false;
                }
                txtRevisionNo.Text = dt.Rows[0]["RevisionNo"].ToString();
                txtRevisionDate.Text = dt.Rows[0]["RevisionDate"].ToString();
                if (dt.Rows[0]["SOVAT"].ToString() == "True")
                {
                    chkVat.Checked = true;
                }
                else
                {
                    chkVat.Checked = false;
                }
                if (dt.Rows[0]["SOCertificateOfOrigin"].ToString() == "True")
                {
                    chkCertificateOfOrigin.Checked = true;
                }
                else
                {
                    chkCertificateOfOrigin.Checked = false;
                }
                if (dt.Rows[0]["PartialShipment"].ToString() == "True")
                {
                    chkPartialShipment.Checked = true;
                }
                else
                {
                    chkPartialShipment.Checked = false;
                }
                if (dt.Rows[0]["SalesAreaId"].ToString() != "0")
                {
                    ddlSalesArea.SelectedValue = dt.Rows[0]["SalesAreaId"].ToString();
                }
                else
                {
                    ddlSalesArea.SelectedValue = "";
                }
                if (dt.Rows[0]["SalesOrganizationId"].ToString() != "0")
                {
                    ddlSalesOrganization.SelectedValue = dt.Rows[0]["SalesOrganizationId"].ToString();
                }
                else
                {
                    ddlSalesOrganization.SelectedValue = "";
                }
                if (dt.Rows[0]["DistributionChannelId"].ToString() != "0")
                {
                    ddlDistributionChannel.SelectedValue = dt.Rows[0]["DistributionChannelId"].ToString();
                }
                else
                {
                    ddlDistributionChannel.SelectedValue = "";
                }
                HidProfitCenterId.Value = dt.Rows[0]["ProfitCenterId"].ToString();
                txtProfitCenter.Text = dt.Rows[0]["ProfitCenter"].ToString();
                txtPaymentTerms.Text = dt.Rows[0]["SOPaymentTerms"].ToString();
                txtPaymentTerms1.Text = dt.Rows[0]["SOPaymentTerms1"].ToString();
                txtPaymentTerms2.Text = dt.Rows[0]["SOPaymentTerms2"].ToString();
                txtSpecialInstruction.Text = dt.Rows[0]["SOSpecailIntructions"].ToString();
                txtCommittedETD.Text = dt.Rows[0]["CommittedETD"].ToString();
                txtCommittedETA.Text = dt.Rows[0]["CommittedETA"].ToString();
                txtRevisedETD.Text = dt.Rows[0]["RevisedETD"].ToString();
                txtRevisedETA.Text = dt.Rows[0]["RevisedETA"].ToString();
                txtInvoiceLength.Text = dt.Rows[0]["SOInvoiceLength"].ToString();
                if (dt.Rows[0]["AllowJoints"].ToString() == "True")
                {
                    chkAllowJoints.Checked = true;
                }
                else
                {
                    chkAllowJoints.Checked = false;
                }
                if (dt.Rows[0]["SOStickerType"].ToString() != "0")
                {
                    ddlStickerType.SelectedValue = dt.Rows[0]["SOStickerType"].ToString();
                }
                else
                {
                    ddlStickerType.SelectedValue = "";
                }

                txtServiceLength.Text = dt.Rows[0]["SOServiceLength"].ToString();
                txtMaxLenTolerance.Text = dt.Rows[0]["MaxLengthTolerance"].ToString();
                if (dt.Rows[0]["SOFumigation"].ToString() == "True")
                {
                    chkFumigation.Checked = true;
                }
                else
                {
                    chkFumigation.Checked = false;
                }
                txtCOOCTH.Text = dt.Rows[0]["COOCTH"].ToString();
                txtBioIncentive.Text = dt.Rows[0]["BOIIncentive"].ToString();

            }
        }
        catch (Exception ex) { }
    }

    private void Get_SalesOrder_LineItem(int SalesorderId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSalesOrder_Trans.Get_SearchOrderLineItem(SalesorderId);
            if (dt.Rows.Count > 0)
            {
                int TotalRows = dt.Rows.Count;
                txtLineNo.Text = (Convert.ToInt32(dt.Rows[TotalRows - 1]["LineNo"].ToString()) + 10).ToString();
            }
            else
            {
                txtLineNo.Text = "10";
            }
            ViewState["SO_LineItem"] = dt;
            gvLineItems.DataSource = dt;
            gvLineItems.DataBind();
        }
        catch (Exception ex) { }
    }

    #endregion

    #endregion

}