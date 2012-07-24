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
using System.Threading;

public partial class Sales_PerformaInvoice : System.Web.UI.Page
{
    #region***************************************Variables***************************************

    Common_mst objCommon_mst = new Common_mst();
    Common_Message objcommonmessage = new Common_Message();
    PerformaInvoice_Tran objPerformaInvoice_Tran = new PerformaInvoice_Tran();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();    
    string FlagInsertUpdate;
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
                lblPageHeader.Text = "Proforma Invoice";              
                TCPerformaInvoice.ActiveTabIndex = 0;              
                
                TDPINo.Attributes.Add("style", "display:none");
                TDtxtPINo.Attributes.Add("style", "display:none");                

                #region Binding Drop Down Function

                FillFinancialYear();
                BindPITypeMaster();
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
                
                Get_PerformaInvoice_LineItem(0);

                #endregion                
                
                #region Change Color of Readonly Fields

                txtPiYear.Attributes.Add("style", "background:lightgray");
                txtPiNo.Attributes.Add("style", "background:lightgray");
                txtPiDate.Attributes.Add("style", "background:lightgray");
                txtCustomerCode.Attributes.Add("style", "background:lightgray");
                txtConsignee.Attributes.Add("style", "background:lightgray");
                txtCustomerName.Attributes.Add("style", "background:lightgray");
                txtTermsofDelivery.Attributes.Add("style", "background:lightgray");
                txtCustomerOrderDate.Attributes.Add("style", "background:lightgray");
                txtLineNo.Attributes.Add("style", "background:lightgray");
                txtWidthinInch.Attributes.Add("style", "background:lightgray");
                txtlengthinFt.Attributes.Add("style", "background:lightgray");
                txtEstimatedDate.Attributes.Add("style", "background:lightgray");
                txtProfitCenter.Attributes.Add("style", "background:lightgray");
                txtUnitPrice.Attributes.Add("style", "background:lightgray");
                
                #endregion

                txtPiDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);               
                txtPiYear.Attributes.Add("readonly", "true");
                txtPiNo.Attributes.Add("readonly", "true");                
                txtCustomerName.Attributes.Add("readonly", "true");                
                txtPiDate.Attributes.Add("readonly", "true");
                txtCustomerOrderDate.Attributes.Add("readonly", "true");
                txtLineNo.Attributes.Add("readonly", "true");
                txtEstimatedDate.Attributes.Add("readonly", "true");
                txtWidthinInch.Attributes.Add("readonly", "true");
                txtlengthinFt.Attributes.Add("readonly", "true");
                txtCustomerCode.Attributes.Add("readonly", "true");
                txtConsignee.Attributes.Add("readonly", "true");
                txtTermsofDelivery.Attributes.Add("readonly", "true");
                txtProfitCenter.Attributes.Add("readonly", "true");
                txtUnitPrice.Attributes.Add("readonly", "true");

                ddlWidthinMM.Attributes.Add("onclick", "CalculateWidthInInch();");
                txtLengthinMtr.Attributes.Add("onkeyup", "CalculateLengthInFeet();");

                int PIid = 0;
                try
                {
                    PIid = Convert.ToInt32(Request.QueryString["PIid"].ToString());
                }
                catch (Exception ex)
                {
                }
                if (PIid != 0)
                {

                    Get_PerformaInvoice_Header(PIid);
                    Get_PerformaInvoice_LineItem(PIid);
                }
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
        TDPINo.Attributes.Add("style", "display:none");
        TDtxtPINo.Attributes.Add("style", "display:none"); 
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        txtSearchList.Text = "";
        if (ddlSearch.SelectedValue != "0")
        {
            BindperformInvoiceData(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender1.Show();            
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue , 125, 300);
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
        BindperformInvoiceData(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void ImgBtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Insert/Upadte Record Of Header & Line Item

            DataTable dtPILineItem = (DataTable)ViewState["PI_LineItem"];
            if (dtPILineItem.Rows.Count > 0)
            {
                try
                {

                    #region Insert/Update Records Of Header

                    if (HidPerformaInvoiceId.Value == "")
                    {
                        HidNewValue.Value = "True";
                        objPerformaInvoice_Tran.PerformaInvoiceID = 0;
                    }
                    else
                    {
                        HidNewValue.Value = "False";
                        objPerformaInvoice_Tran.PerformaInvoiceID = Convert.ToInt32(HidPerformaInvoiceId.Value);
                    }
                    objPerformaInvoice_Tran.PerfInvTypeID = Convert.ToInt32(ddlPIType.SelectedValue.ToString());
                    objPerformaInvoice_Tran.Year = txtPiYear.Text.Trim();

                    objPerformaInvoice_Tran.PIDate = DateTime.ParseExact(txtPiDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    objPerformaInvoice_Tran.Customer = Convert.ToInt32(hidCustomerId.Value);
                    objPerformaInvoice_Tran.Consignee = Convert.ToInt32(hidConsigneeId.Value);
                    objPerformaInvoice_Tran.DeliveryTo = Convert.ToInt32(ddlDeliveryTo.SelectedValue.ToString());

                    objPerformaInvoice_Tran.CustomerOrderNo = txtCustomerOrderNo.Text.Trim();
                    objPerformaInvoice_Tran.CustomerArticleNo = txtCustomerArticleNo .Text.Trim();
                    objPerformaInvoice_Tran.CustomerPartNo = txtCustomerPartNo.Text.Trim();

                    if (txtCustomerOrderDate.Text != "")
                    {
                        objPerformaInvoice_Tran.CustomerOrderDate = DateTime.ParseExact(txtCustomerOrderDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    }
                    else
                    {
                        objPerformaInvoice_Tran.CustomerOrderDate = "";
                    }

                    if (ddlFinalDestination.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.FinalDestination = Convert.ToInt32(ddlFinalDestination.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.FinalDestination = 0;
                    }
                    if (ddlDeliveryTolerance.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.DeliveryTolerance = Convert.ToInt32(ddlDeliveryTolerance.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.DeliveryTolerance = 0;
                    }

                    if (hidTermsOfDeliveryId.Value != "")
                    {
                        objPerformaInvoice_Tran.TermsOfDelivery = Convert.ToInt32(hidTermsOfDeliveryId.Value);
                    }
                    else
                    {
                        objPerformaInvoice_Tran.TermsOfDelivery = 0;
                    }
                    if (ddlLogistic.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.Logistics = Convert.ToInt32(ddlLogistic.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.Logistics = 0;
                    }
                    if (ddlCurrency.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.Currency = Convert.ToInt32(ddlCurrency.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.Currency = 0;
                    }
                    if (ddlPaymentMode.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.PaymentMode = Convert.ToInt32(ddlPaymentMode.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.PaymentMode = 0;
                    }
                    if (ddlCertificates.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.Certificates = Convert.ToInt32(ddlCertificates.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.Certificates = 0;
                    }
                    if (txtNoofShipments.Text != "")
                    {
                        objPerformaInvoice_Tran.NoOfShipment = Convert.ToInt32(txtNoofShipments.Text.Trim());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.NoOfShipment = 0;
                    }
                    if (ddlPackingStandard.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.PackingStandard = Convert.ToInt32(ddlPackingStandard.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.PackingStandard = 0;
                    }
                    if (txtRemittanceDays.Text.Trim() != "")
                    {
                        objPerformaInvoice_Tran.RemittanceDays = Convert.ToInt32(txtRemittanceDays.Text.Trim());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.RemittanceDays = 0;
                    }
                    if (txtCreditDays.Text.Trim() != "")
                    {
                        objPerformaInvoice_Tran.CreditDays = Convert.ToInt32(txtCreditDays.Text.Trim());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.CreditDays = 0;
                    }


                    if (ddlFilmType.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.FilmType = Convert.ToInt32(ddlFilmType.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.FilmType = 0;
                    }
                    if (ddlUnitofSale.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.UnitOfSales = Convert.ToInt32(ddlUnitofSale.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.UnitOfSales = 0;
                    }

                    if (ddlSalesArea.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.SalesAreaId = Convert.ToInt32(ddlSalesArea.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.SalesAreaId = 0;
                    }
                    if (ddlSalesOrganization.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.SalesOrganizationId = Convert.ToInt32(ddlSalesOrganization.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.SalesOrganizationId = 0;
                    }
                    if (ddlDistributionChannel.SelectedValue.ToString() != "")
                    {
                        objPerformaInvoice_Tran.DistributionChannelId = Convert.ToInt32(ddlDistributionChannel.SelectedValue.ToString());
                    }
                    else
                    {
                        objPerformaInvoice_Tran.DistributionChannelId = 0;
                    }
                    if (txtProfitCenter.Text.Trim() != "")
                    {
                        objPerformaInvoice_Tran.ProfitCenterId = Convert.ToInt32(HidProfitCenterId.Value);
                    }
                    else
                    {
                        objPerformaInvoice_Tran.ProfitCenterId = 0;
                    }

                    objPerformaInvoice_Tran.SpecialInstruction = txtSpecialInstruction.Text.Trim();
                    objPerformaInvoice_Tran.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                    objPerformaInvoice_Tran.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                    #endregion

                    #region Insert/Update Records of LineItem

                    objPerformaInvoice_Tran.dtPILineItems = new DataTable();
                    objPerformaInvoice_Tran.dtPILineItems = objPerformaInvoice_Tran.Get_PerformaInvoice_LineItem(0);
                    DataRow objdrPILineItems;

                    if (dtPILineItem.Rows.Count > 0)
                    {
                        foreach (DataRow objdrPILineItem in dtPILineItem.Rows)
                        {
                            try
                            {
                                if ((objdrPILineItem["LineItemID"].ToString() == "0" && objdrPILineItem["IsUpdate"].ToString() == "No") || (objdrPILineItem["LineItemID"].ToString() != "0" &&
                                    objdrPILineItem["IsUpdate"].ToString() == "Yes"))
                                {
                                    objdrPILineItems = objPerformaInvoice_Tran.dtPILineItems.NewRow();

                                    objdrPILineItems["LineItemID"] = Convert.ToInt32(objdrPILineItem["LineItemID"].ToString());
                                    objdrPILineItems["LineNo"] = Convert.ToInt32(objdrPILineItem["LineNo"].ToString());
                                    objdrPILineItems["SubFilmType"] = Convert.ToInt32(objdrPILineItem["SubFilmType"].ToString());
                                    objdrPILineItems["Micron"] = objdrPILineItem["Micron"].ToString();
                                    objdrPILineItems["Core"] = objdrPILineItem["Core"].ToString();
                                    objdrPILineItems["WidthInMM"] = Convert.ToInt32(objdrPILineItem["WidthInMM"].ToString());
                                    objdrPILineItems["WidthInInch"] = Convert.ToDouble(objdrPILineItem["WidthInInch"].ToString());
                                    objdrPILineItems["LengthInMtr"] = Convert.ToDouble(objdrPILineItem["LengthInMtr"].ToString());
                                    objdrPILineItems["LengthInFt"] = Convert.ToDouble(objdrPILineItem["LengthInFt"].ToString());
                                    objdrPILineItems["UnitPrice"] = Convert.ToDouble(objdrPILineItem["UnitPrice"].ToString());
                                    objdrPILineItems["NoOfRolls"] = Convert.ToInt32(objdrPILineItem["NoOfRolls"].ToString());
                                    objdrPILineItems["ReqQuantityInKG"] = Convert.ToDouble(objdrPILineItem["ReqQuantityInKG"].ToString());
                                    objdrPILineItems["EstimatedDate"] = objdrPILineItem["EstimatedDate"].ToString();
                                    objdrPILineItems["Application"] = objdrPILineItem["Application"].ToString();
                                    objdrPILineItems["COFMin"] = Convert.ToDouble(objdrPILineItem["COFMin"].ToString());
                                    objdrPILineItems["COFMax"] = Convert.ToDouble(objdrPILineItem["COFMax"].ToString());
                                    objdrPILineItems["ODMin"] = Convert.ToDouble(objdrPILineItem["ODMin"].ToString());
                                    objdrPILineItems["ODAvg"] = Convert.ToDouble(objdrPILineItem["ODAvg"].ToString());
                                    objdrPILineItems["ODMax"] = Convert.ToDouble(objdrPILineItem["ODMax"].ToString());
                                    objdrPILineItems["ShipmentNo"] = objdrPILineItem["ShipmentNo"].ToString();
                                    objdrPILineItems["Include"] = Convert.ToBoolean(objdrPILineItem["Include"].ToString());                                   
                                    objdrPILineItems["ActiveStatus"] = Convert.ToBoolean(objdrPILineItem["ActiveStatus"].ToString());
                                    objdrPILineItems["PalletType"] = objdrPILineItem["PalletType"].ToString();
                                    objdrPILineItems["NoofRollsInPallet"] = Convert.ToInt32(objdrPILineItem["NoofRollsInPallet"].ToString());

                                    objPerformaInvoice_Tran.dtPILineItems.Rows.Add(objdrPILineItems);
                                    objPerformaInvoice_Tran.dtPILineItems.AcceptChanges();
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

                    FlagInsertUpdate = objPerformaInvoice_Tran.InsertUpdate_In_Glb_PerformaInvoice();
                    if (FlagInsertUpdate == "YES")
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                        #region Clear All records after save

                        ClearHeaderItems();
                        ClearLineItems();
                        txtLineNo.Text = "10";
                        Get_PerformaInvoice_LineItem(0);

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
            DataTable objdtPILineItem = new DataTable();

            objdtPILineItem = (DataTable)ViewState["PI_LineItem"];          

            if (HidUpdateGridRecord.Value == "")
            {
                DataRow objdrPILineItem = objdtPILineItem.NewRow();
                
                objdrPILineItem["LineItemID"] = 0;
                objdrPILineItem["IsUpdate"] = "No";
                objdrPILineItem["LineNo"] = Convert.ToInt32(txtLineNo.Text.Trim());
                if (HidPerformaInvoiceId.Value != "")
                {
                    objdrPILineItem["PerformaInvoiceID"] = Convert.ToInt32(HidPerformaInvoiceId.Value);
                }
                else
                {
                    objdrPILineItem["PerformaInvoiceID"] = 0;
                }
                if (ddlSubFilmType.SelectedValue.ToString() != "")
                {
                    objdrPILineItem["SubFilmType"] = Convert.ToInt32(ddlSubFilmType.SelectedValue.ToString());
                    objdrPILineItem["SubFilmTypeName"] = ddlSubFilmType.SelectedItem.Text;
                }
                else
                {
                    objdrPILineItem["SubFilmType"] = 0;
                    objdrPILineItem["SubFilmTypeName"] = "";
                }
                objdrPILineItem["Micron"] = txtMicron.Text.Trim();
                objdrPILineItem["Core"] = txtCore.Text.Trim();
                if (ddlWidthinMM.SelectedValue != "")
                {
                    objdrPILineItem["WidthInMM"] = Convert.ToInt32(ddlWidthinMM.SelectedValue);
                    objdrPILineItem["WidthInMMName"] = ddlWidthinMM.SelectedItem.Text;
                }
                else
                {
                    objdrPILineItem["WidthInMM"] = 0;
                    objdrPILineItem["WidthInMMName"] = "";
                }

                objdrPILineItem["WidthInInch"] = Convert.ToDouble(txtWidthinInch.Text.Trim());
                if (txtLengthinMtr.Text != "")
                {
                    objdrPILineItem["LengthInMtr"] = Convert.ToDouble(txtLengthinMtr.Text.Trim());
                }
                else
                {
                    objdrPILineItem["LengthInMtr"] = 0;
                }
                objdrPILineItem["LengthInFt"] = Convert.ToDouble(txtlengthinFt.Text.Trim());
                if (txtUnitPrice.Text.Trim() != "")
                {
                    objdrPILineItem["UnitPrice"] = Convert.ToDouble(txtUnitPrice.Text.Trim());
                }
                else
                {
                    objdrPILineItem["UnitPrice"] = 0;
                }
                if (txtNoofRoles.Text != "")
                {
                    objdrPILineItem["NoOfRolls"] = Convert.ToDouble(txtNoofRoles.Text.Trim());
                }
                else
                {
                    objdrPILineItem["NoOfRolls"] = 0;
                }
                if (txtRequiredQuantity.Text != "")
                {
                    objdrPILineItem["ReqQuantityInKG"] = Convert.ToDouble(txtRequiredQuantity.Text.Trim());
                }
                else
                {
                    objdrPILineItem["ReqQuantityInKG"] = 0;
                }
                if (txtEstimatedDate.Text != "")
                {
                    objdrPILineItem["EstimatedDate"] = txtEstimatedDate.Text.Trim();
                }
                else
                {
                    objdrPILineItem["EstimatedDate"] = "";
                }
                objdrPILineItem["Application"] = txtApplication.Text.Trim();
                if (txtCofMin.Text != "")
                {
                    objdrPILineItem["COFMin"] = Convert.ToDouble(txtCofMin.Text.Trim());
                }
                else
                {
                    objdrPILineItem["COFMin"] = 0;
                }
                if (txtCofMax.Text != "")
                {
                    objdrPILineItem["COFMax"] = Convert.ToDouble(txtCofMax.Text.Trim());
                }
                else
                {
                    objdrPILineItem["COFMax"] = 0;
                }
                if (txtOdMin.Text != "")
                {
                    objdrPILineItem["ODMin"] = Convert.ToDouble(txtOdMin.Text.Trim());
                }
                else
                {
                    objdrPILineItem["ODMin"] = 0;
                }
                if (txtOdAvg.Text != "")
                {
                    objdrPILineItem["ODAvg"] = Convert.ToDouble(txtOdAvg.Text.Trim());
                }
                else
                {
                    objdrPILineItem["ODAvg"] = 0;
                }
                if (txtOdMax.Text != "")
                {
                    objdrPILineItem["ODMax"] = Convert.ToDouble(txtOdMax.Text.Trim());
                }
                else
                {
                    objdrPILineItem["ODMax"] = 0;
                }
                objdrPILineItem["ShipmentNo"] = txtShipmentNo.Text.Trim();
                if (chkInclude.Checked == true)
                {
                    objdrPILineItem["Include"] = 1;
                }
                else
                {
                    objdrPILineItem["Include"] = 0;
                }
                
                objdrPILineItem["ActiveStatus"] = true;
                if (txtPalletType.Text.Trim() != "")
                {
                    objdrPILineItem["PalletType"] = txtPalletType.Text.Trim();
                }
                else
                {
                    objdrPILineItem["PalletType"] = "";
                }
                if (txtNoofRolesinPallet.Text.Trim() != "")
                {
                    objdrPILineItem["NoofRollsInPallet"] = Convert.ToInt32(txtNoofRolesinPallet.Text.Trim());
                }
                else
                {
                    objdrPILineItem["NoofRollsInPallet"] = 0;
                }
                objdrPILineItem["CreatedBy"] = Convert.ToInt32(Session["UserId"].ToString());
                objdtPILineItem.Rows.Add(objdrPILineItem);
            }
            else if (HidUpdateGridRecord.Value == "Yes")
            {               
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["IsUpdate"] = "Yes";
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LineNo"] = Convert.ToInt32(txtLineNo.Text.Trim());
                if (HidPerformaInvoiceId.Value != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PerformaInvoiceID"] = Convert.ToInt32(HidPerformaInvoiceId.Value);
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PerformaInvoiceID"] = 0;
                }
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubFilmType"] = Convert.ToInt32(ddlSubFilmType.SelectedValue.ToString());
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubFilmTypeName"] = ddlSubFilmType.SelectedItem.Text;

                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Micron"] = txtMicron.Text.Trim();
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Core"] = txtCore.Text.Trim();
                if (ddlWidthinMM.SelectedValue != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInMM"] = Convert.ToInt32(ddlWidthinMM.SelectedValue);
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInMMName"] = ddlWidthinMM.SelectedItem.Text;
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInMM"] = 0;
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInMMName"] = "";
                }

                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInInch"] = Convert.ToDouble(txtWidthinInch.Text.Trim());
                if (txtLengthinMtr.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LengthInMtr"] = Convert.ToDouble(txtLengthinMtr.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LengthInMtr"] = 0;
                }
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LengthInFt"] = Convert.ToDouble(txtlengthinFt.Text.Trim());
                if (txtUnitPrice.Text.Trim() != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["UnitPrice"] = Convert.ToDouble(txtUnitPrice.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["UnitPrice"] = 0;                    
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.MappingNotFoundForPrice, 125, 300);
                    return;
                }
                if (txtNoofRoles.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoOfRolls"] = Convert.ToDouble(txtNoofRoles.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoOfRolls"] = 0;
                }
                if (txtRequiredQuantity.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ReqQuantityInKG"] = Convert.ToDouble(txtRequiredQuantity.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ReqQuantityInKG"] = 0;
                }
                if (txtEstimatedDate.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["EstimatedDate"] = txtEstimatedDate.Text.Trim();
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["EstimatedDate"] = "";
                }
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Application"] = txtApplication.Text.Trim();
                if (txtCofMin.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["COFMin"] = Convert.ToDouble(txtCofMin.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["COFMin"] = 0;
                }
                if (txtCofMax.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["COFMax"] = Convert.ToDouble(txtCofMax.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["COFMax"] = 0;
                }
                if (txtOdMin.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODMin"] = Convert.ToDouble(txtOdMin.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODMin"] = 0;
                }
                if (txtOdAvg.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODAvg"] = Convert.ToDouble(txtOdAvg.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODAvg"] = 0;
                }
                if (txtOdMax.Text != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODMax"] = Convert.ToDouble(txtOdMax.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODMax"] = 0;
                }
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ShipmentNo"] = txtShipmentNo.Text.Trim();
                if (chkInclude.Checked == true)
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Include"] = 1;
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Include"] = 0;
                }
               
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ActiveStatus"] = true;
                if (txtPalletType.Text.Trim() != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PalletType"] = txtPalletType.Text.Trim();
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PalletType"] = "";
                }
                if (txtNoofRolesinPallet.Text.Trim() != "")
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoofRollsInPallet"] = Convert.ToInt32(txtNoofRolesinPallet.Text.Trim());
                }
                else
                {
                    objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoofRollsInPallet"] = 0;
                }
                objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["CreatedBy"] = Convert.ToInt32(Session["UserId"].ToString());                
            }       

            ViewState["PI_LineItem"] = objdtPILineItem;            
            int LineNoInGrid = Convert.ToInt32(objdtPILineItem.Rows[0]["LineNo"].ToString());
            for (int i = 1; i < objdtPILineItem.Rows.Count; i++)
            {
                if (Convert.ToInt32(objdtPILineItem.Rows[i]["LineNo"].ToString()) > LineNoInGrid)
                {
                    LineNoInGrid = Convert.ToInt32(objdtPILineItem.Rows[i]["LineNo"].ToString());
                }
            }
            txtLineNo.Text = (LineNoInGrid + 10).ToString();
            
            gvLineItems.DataSource = objdtPILineItem;
            gvLineItems.DataBind();
            ClearLineItems();             
            TCPerformaInvoice.ActiveTabIndex = 1;
        }
        catch {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.ErrorToLineItem, 125, 300);                      
        }
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
            e.Row.Cells[26].Style.Add("display", "none");
            e.Row.Cells[27].Style.Add("display", "none");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.GridView gvLineItems = (System.Web.UI.WebControls.GridView)sender;
                GridViewRow Gi;
                Gi = e.Row;

                if (e.Row.Cells[21].Text == "True")
                {
                    e.Row.Cells[21].Text = "Yes";
                }
                else if (e.Row.Cells[21].Text == "False")
                {
                    e.Row.Cells[21].Text = "No";
                }

                if (e.Row.Cells[24].Text == "False") // Active Status
                {
                    e.Row.Visible = false;
                }
                else if (e.Row.Cells[24].Text == "True")
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

        GridView gridView = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gridView.SelectedIndex = row.RowIndex + 1;        

        DataTable objdtPILineItem = new DataTable();
        objdtPILineItem = (DataTable)ViewState["PI_LineItem"];
        TotalCountingrid = objdtPILineItem.Rows.Count;

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvLineItems.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }           
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            if (objdtPILineItem.Rows.Count > 0)
            {  
                hidRowIndex.Value = Convert.ToString(row.RowIndex);
                hidLineItemId.Value = objdtPILineItem.Rows[Convert.ToInt32( hidRowIndex.Value)]["LineItemID"].ToString();
                HidUpdateGridRecord.Value = "Yes";
                txtLineNo.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LineNo"].ToString();
                ddlSubFilmType.SelectedValue = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubFilmType"].ToString();
                txtMicron.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Micron"].ToString();
                txtCore.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Core"].ToString();
                ddlWidthinMM.SelectedValue = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInMM"].ToString();
                txtWidthinInch.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["WidthInInch"].ToString();
                txtLengthinMtr.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LengthInMtr"].ToString();
                txtlengthinFt.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["LengthInFt"].ToString();
                txtUnitPrice.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["UnitPrice"].ToString();
                txtNoofRoles.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoOfRolls"].ToString();
                txtRequiredQuantity.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ReqQuantityInKG"].ToString();
                txtEstimatedDate.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["EstimatedDate"].ToString();
                txtApplication.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Application"].ToString();
                txtCofMin.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["COFMin"].ToString();
                txtCofMax.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["COFMax"].ToString();
                txtOdMin.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODMin"].ToString();
                txtOdAvg.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODAvg"].ToString();
                txtOdMax.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ODMax"].ToString();
                txtShipmentNo.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ShipmentNo"].ToString();
                if (objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Include"].ToString() == "True")
                {
                    chkInclude.Checked = true;
                }
                else
                {
                    chkInclude.Checked = false;
                }               
                txtPalletType.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PalletType"].ToString();
                txtNoofRolesinPallet.Text = objdtPILineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["NoofRollsInPallet"].ToString();
                ImgBtnAddLine.ImageUrl = "../Images/btnUpdateLine.png";                
            }
        }
        else if (e.CommandName == "Delete")
        {
            if (Convert.ToInt32(objdtPILineItem.Rows[gridView.SelectedIndex - 1]["LineItemID"].ToString()) == 0)
            {
                int PreviousLineNo = Convert.ToInt32(objdtPILineItem.Rows[gridView.SelectedIndex - 1]["LineNo"]);
                int PreviousLineItemId = Convert.ToInt32(objdtPILineItem.Rows[gridView.SelectedIndex - 1]["LineItemID"]);
                objdtPILineItem.Rows[gridView.SelectedIndex - 1].Delete();
                if (PreviousLineItemId == 0)
                {
                    txtLineNo.Text = Convert.ToString(PreviousLineNo);
                }
                else
                {
                    int TotalRows = objdtPILineItem.Rows.Count;
                    txtLineNo.Text = (Convert.ToInt32(objdtPILineItem.Rows[TotalRows - 1]["LineNo"].ToString()) + 10).ToString(); 
                }
            }
            else if (Convert.ToInt32(objdtPILineItem.Rows[gridView.SelectedIndex - 1]["LineItemID"].ToString()) != 0)
            {
                objdtPILineItem.Rows[gridView.SelectedIndex - 1]["ActiveStatus"] = "False";
                objdtPILineItem.Rows[gridView.SelectedIndex - 1]["IsUpdate"] = "Yes";

                int TotalRows = objdtPILineItem.Rows.Count;
                txtLineNo.Text = (Convert.ToInt32(objdtPILineItem.Rows[TotalRows - 1]["LineNo"].ToString()) + 10).ToString();
            }
            objdtPILineItem.AcceptChanges();

            ViewState["PI_LineItem"] = objdtPILineItem;
            if (objdtPILineItem.Rows.Count > 0)
            {
                gvLineItems.DataSource = objdtPILineItem;
                gvLineItems.DataBind();
            }
            else
            {
                Get_PerformaInvoice_LineItem(0);
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

    protected void gvProformaInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvProformaInvoice = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvProformaInvoice.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvProformaInvoice.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidPerformaInvoiceId.Value = Convert.ToString(e.CommandArgument);
                Get_PerformaInvoice_Header(Convert.ToInt32(HidPerformaInvoiceId.Value));
                Get_PerformaInvoice_LineItem(Convert.ToInt32 (HidPerformaInvoiceId.Value));
            }
        }
        catch { }
    }

    protected void gvProformaInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProformaInvoice.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindperformInvoiceData(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
            string FormIdProformaInvoice = ConfigurationManager.AppSettings["FormIdProformaInvoice"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProformaInvoice);

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
            if(dt.Rows.Count>0)
            {
                if (Convert.ToInt32(dt.Rows[0]["FinancialStartMonth"].ToString()) > 1)
                {
                    string EndFinancialYear = dt.Rows[0]["FinancialEndYear"].ToString().Substring(2);
                    txtPiYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);                   
                }
                else
                {
                    txtPiYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();                    
                }
            }            
        }
        catch (Exception ex) { }
    }

    protected void BindPITypeMaster()
    {
        try
        { 
            colRCommontype = objCommon_mst.Get_AllPIType();
            ddlPIType.DataTextField = "PerfInvTypeName";
            ddlPIType.DataValueField = "PerfInvTypeID";
            ddlPIType.DataSource = colRCommontype;
            ddlPIType.DataBind();
            ddlPIType.Items.Insert(0, new ListItem("-Select-", ""));
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

    #endregion

    #region Function to Fill Form Data    

    protected void Get_PerformaInvoice_Header(int ProformaInvoiceId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objPerformaInvoice_Tran.Get_PerformaInvoice_Header(ProformaInvoiceId);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PerfInvTypeID"].ToString() != "0")
                {
                    ddlPIType.SelectedValue = dt.Rows[0]["PerfInvTypeID"].ToString();
                }
                else
                {
                    ddlPIType.SelectedValue = "";
                }
                txtPiYear.Text = dt.Rows[0]["Year"].ToString();

                txtPiNo.Text = dt.Rows[0]["PINo"].ToString();
                TDPINo.Attributes.Add("style", "display:block");
                TDtxtPINo.Attributes.Add("style", "display:block");

                txtPiDate.Text = dt.Rows[0]["PIDate"].ToString();
                hidCustomerId.Value = dt.Rows[0]["Customer"].ToString();
                txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                hidConsigneeId.Value = dt.Rows[0]["Consignee"].ToString();
                txtConsignee.Text = dt.Rows[0]["ConsigneeName"].ToString();
                if (dt.Rows[0]["DeliveryTo"].ToString() != "0")
                {
                    ddlDeliveryTo.SelectedValue = dt.Rows[0]["DeliveryTo"].ToString();
                }
                else
                {
                    ddlDeliveryTo.SelectedValue = "";
                }

                txtCustomerOrderNo.Text = dt.Rows[0]["CustomerOrderNo"].ToString();
                txtCustomerArticleNo.Text = dt.Rows[0]["CustomerArticleNo"].ToString();
                txtCustomerPartNo.Text = dt.Rows[0]["CustomerPartNo"].ToString();

                txtCustomerOrderDate.Text = dt.Rows[0]["CustomerOrderDate"].ToString();
                if (dt.Rows[0]["FinalDestination"].ToString() != "0")
                {
                    ddlFinalDestination.SelectedValue = dt.Rows[0]["FinalDestination"].ToString();
                }
                else
                {
                    ddlFinalDestination.SelectedValue = "0";
                }

                if (dt.Rows[0]["DeliveryTolerance"].ToString() != "0")
                {
                    ddlDeliveryTolerance.SelectedValue = dt.Rows[0]["DeliveryTolerance"].ToString();
                }
                else
                {
                    ddlDeliveryTolerance.SelectedValue = "";
                }
               
                hidTermsOfDeliveryId.Value = dt.Rows[0]["TermsOfDelivery"].ToString();
                txtTermsofDelivery.Text = dt.Rows[0]["TermsofDeliveryName"].ToString();
                if (dt.Rows[0]["Logistics"].ToString() != "0")
                {
                    ddlLogistic.SelectedValue = dt.Rows[0]["Logistics"].ToString();
                }
                else
                {
                    ddlLogistic.SelectedValue = "";
                }
                if (dt.Rows[0]["Currency"].ToString() != "0")
                {
                    ddlCurrency.SelectedValue = dt.Rows[0]["Currency"].ToString();
                }
                else
                {
                    ddlCurrency.SelectedValue = "";
                }
                if (dt.Rows[0]["PaymentMode"].ToString() != "0")
                {
                    ddlPaymentMode.SelectedValue = dt.Rows[0]["PaymentMode"].ToString();
                }
                else
                {
                    ddlPaymentMode.SelectedValue = "";
                }
                if (dt.Rows[0]["Certificates"].ToString() != "0")
                {
                    ddlCertificates.SelectedValue = dt.Rows[0]["Certificates"].ToString();
                }
                else
                {
                    ddlCertificates.SelectedValue = "";
                }
                txtNoofShipments.Text = dt.Rows[0]["NoOfShipment"].ToString();
                if (dt.Rows[0]["PackingStandard"].ToString() != "0")
                {
                    ddlPackingStandard.SelectedValue = dt.Rows[0]["PackingStandard"].ToString();
                }
                else
                {
                    ddlPackingStandard.SelectedValue = "";
                }
                txtRemittanceDays.Text = dt.Rows[0]["RemittanceDays"].ToString();
                txtCreditDays.Text = dt.Rows[0]["CreditDays"].ToString();
                if (dt.Rows[0]["FilmType"].ToString() != "0")
                {
                    ddlFilmType.SelectedValue = dt.Rows[0]["FilmType"].ToString();
                }
                else
                {
                    ddlFilmType.SelectedValue = "";
                }
                if (dt.Rows[0]["UnitOfSales"].ToString() != "0")
                {
                    ddlUnitofSale.SelectedValue = dt.Rows[0]["UnitOfSales"].ToString();
                }
                else
                {
                    ddlUnitofSale.SelectedValue = "";
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
                txtSpecialInstruction.Text = dt.Rows[0]["SpecialInstruction"].ToString();
            }
        }
        catch (Exception ex) { }
    }

    protected void Get_PerformaInvoice_LineItem(int ProformaInvoiceId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objPerformaInvoice_Tran.Get_PerformaInvoice_LineItem(ProformaInvoiceId);
            if (dt.Rows.Count > 0)
            {
                int TotalRows = dt.Rows.Count;
                txtLineNo.Text = (Convert.ToInt32(dt.Rows[TotalRows - 1]["LineNo"].ToString()) + 10).ToString();                
            }
            else
            {
                txtLineNo.Text = "10";
            }
            ViewState["PI_LineItem"] = dt; 
            gvLineItems.DataSource = dt;
            gvLineItems.DataBind();  
        }
        catch (Exception ex) { }
    }

    #endregion

    #region Function to clear records

    public void ClearHeaderItems()
    {
        FillFinancialYear();
        HidPerformaInvoiceId.Value = "";       
        ddlPIType.SelectedValue = "";       
        txtPiNo.Text = "";
        txtPiDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        txtCustomerCode.Text = "";
        hidCustomerId.Value = "";
        txtConsignee.Text = "";
        hidConsigneeId.Value = "";
        ddlDeliveryTo.SelectedValue = "";
        txtCustomerName.Text = "";
        ddlFinalDestination.SelectedValue = "";
        ddlDeliveryTolerance.SelectedValue = "";
        txtTermsofDelivery.Text = "";
        hidTermsOfDeliveryId.Value = "";
        ddlLogistic.SelectedValue = "";
        ddlCurrency.SelectedValue = "";
        ddlPaymentMode.SelectedValue = "";
        ddlCertificates.SelectedValue = "";
        txtNoofShipments.Text = "";
        ddlPackingStandard.SelectedValue = "";
        txtRemittanceDays.Text = "";
        txtCreditDays.Text = "";
        ddlFilmType.SelectedValue = "";
        txtCustomerOrderNo.Text = "";
        txtCustomerArticleNo.Text = "";
        txtCustomerPartNo.Text = "";
        ddlUnitofSale.SelectedValue = "";
        ddlSalesArea.SelectedValue = "";
        ddlSalesOrganization.SelectedValue = "";
        ddlDistributionChannel.SelectedValue = "";
        HidProfitCenterId.Value = "";
        txtProfitCenter.Text = "";
        txtCustomerOrderDate.Text = "";
        txtSpecialInstruction.Text = "";        
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
        txtEstimatedDate.Text = "";
        txtApplication.Text = "";
        txtCofMin.Text = "";
        txtCofMax.Text = "";
        txtOdMin.Text = "";
        txtOdAvg.Text="";
        txtOdMax.Text = "";
        txtShipmentNo.Text ="";       
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
            ViewState["PI_LineItem"] = null;
            Get_PerformaInvoice_LineItem(0);
            txtLineNo.Text = "10";
            gvLineItems.AllowPaging = false;
            gvLineItems.DataSource = "";
            gvLineItems.DataBind();
        }
        catch { }
    }

    #endregion   

    #region Function to fill Line Item records

    private void BindperformInvoiceData(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objPerformaInvoice_Tran.Get_PerformaInvoiceAllRecords(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvProformaInvoice.DataSource = dt;
                gvProformaInvoice.AllowPaging = true;
                gvProformaInvoice.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvProformaInvoice.AllowPaging = false;
                gvProformaInvoice.DataSource = "";
                gvProformaInvoice.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    #endregion       
    
}