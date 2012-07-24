using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Pages_Invoice : System.Web.UI.Page
{

    Invoice_trans cs = new Invoice_trans();
    Common cmn = new Common();
    Common_mst objCommon_mst = new Common_mst();
    Common_Message objMsg = new Common_Message();
    string financial_year = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
            Label lblHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblHeader.Text = "Invoice";
            DataTable dt = cmn.fillSearch("174");
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));


                }
            }
            financial_year = getFinancialYear();
            Txt_InvNumber.Text = AutogenerateInvoiceNo(financial_year);
            Txt_InvNumber.Enabled = false;
            txt_year.Text = financial_year;
            txt_Type.Focus();
            /***************************fill data when QueryString*******************************/
            int invid = 0;
            try
            {
                invid = Convert.ToInt32(Request.QueryString["invid"].ToString());
            }
            catch (Exception ex)
            {
            }
            if (invid != 0)
            {
                DataTable dtfill = cs.fillRecords(invid.ToString());
                fillData(dtfill);
                
            }
            /****************************************************************************/
        }


        
        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        btnUpdate.Visible = false;






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
    protected void BtnSave_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            cs.InsertInv(txt_Type.Text, txt_year.Text, Txt_invDate.Text, Txt_QSrInv.Text, lbl_SOid.Text, lbl_PIID.Text, Txt_ExporterCode.Text, Txt_CFD.Text, lbl_customerid.Text,
                lbl_ConsigneeID.Text, lbl_deliveryID.Text, Txt_BuysOrder.Text, Txt_BuysOrderDate.Text, lbl_currencyId.Text, Txt_ETD.Text, Txt_ETA.Text,
                chk_Print_in_G_I.Checked.ToString(), chk_PrintWidth.Checked.ToString(), chk_PrintBuyers.Checked.ToString(), Chk_to_order_Consignee.Checked.ToString(),
                Txt_Bill_of_loading.Text, Txt_Bill_of_loading_date.Text, Txt_containerno.Text, Txt_ShippingLine.Text, Txt_ExportEntryNumber.Text, Txt_ExportEntryDate.Text,
                Txt_FOB_CIF.Text, Txt_InlandTransport.Text, Txt_Frieght.Text, Txt_Insaurance.Text, Txt_Vessel_flight_no.Text, Txt_pre_carriage_by.Text, Txt_Place_of_Rect.Text,
                Txt_Port_of_loading.Text, Txt_Port_oif_Discharge.Text, lbl_FinalDestID.Text, Txt_Mark_No1.Text, Txt_Mark_No2.Text, Txt_Mark_No3.Text,
                Txt_NoAndKingofPKG.Text, Txt_terms_of_deliveryPayment.Text, Txt_terms_of_deliveryPayment.Text, Txt_Description_of_goods.Text, txt_footerdescription.Text,
                txt_specialInstruction.Text, Txt_footer_packing.Text, Session["UserID"].ToString());

            string message = objMsg.RecordSaved;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            clearAll();

        }
        catch (Exception ex)
        {
            string message = objMsg.RecordNotSaved;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);

        }
        finally
        {

        }

    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            string DataKey = gridMaster.SelectedDataKey.Value.ToString();
            DataTable dt = cs.fillRecords(DataKey);
            fillData(dt);
            
    }

    protected void fillData(DataTable dt)
    {
        try
        {
        if (dt.Rows.Count > 0)
            {

                Txt_InvNumber.Text = dt.Rows[0]["InvoiceNo"].ToString();
                Txt_InvNumber.Enabled = false;
                txt_Type.Text = dt.Rows[0]["InvoiceType"].ToString();
                txt_year.Text = dt.Rows[0]["InvoiceYear"].ToString();
                if (dt.Rows[0]["InvoiceDate"].ToString() != "")
                {
                    Txt_invDate.Text = DateTime.Parse(dt.Rows[0]["InvoiceDate"].ToString()).ToShortDateString();
                }
                Txt_orderno.Text = dt.Rows[0]["SONo"].ToString();
                Txt_QSrInv.Text = dt.Rows[0]["QSrInvoiceNo"].ToString();
                Txt_PINo.Text = dt.Rows[0]["PICode"].ToString();
                Txt_ExporterCode.Text = dt.Rows[0]["ExporterCode"].ToString();
                Txt_CFD.Text = dt.Rows[0]["FinalDestCountry"].ToString();
                Txt_PartyCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                Txt_ConsigneeCode.Text = dt.Rows[0]["ConsigneeCode"].ToString();
                Txt_DeliveryCode.Text = dt.Rows[0]["DeliveryToName"].ToString();
                Txt_BuysOrder.Text = dt.Rows[0]["CustomerOderNo"].ToString();
                if (dt.Rows[0]["CustOrderDate"].ToString() != "")
                {
                    Txt_BuysOrderDate.Text = DateTime.Parse(dt.Rows[0]["CustOrderDate"].ToString()).ToShortDateString();
                }
                TxtCurrency.Text = dt.Rows[0]["CurrencyCode"].ToString();
                if (dt.Rows[0]["ETD"].ToString() != "")
                {
                    Txt_ETD.Text = DateTime.Parse(dt.Rows[0]["ETD"].ToString()).ToShortDateString();

                }
                if (dt.Rows[0]["ETA"].ToString() != "")
                {
                    Txt_ETA.Text = DateTime.Parse(dt.Rows[0]["ETA"].ToString()).ToShortDateString();

                }
                if (dt.Rows[0]["PrintInGuageInch"].ToString() == "true")

                    chk_Print_in_G_I.Checked = true;
                else
                    chk_Print_in_G_I.Checked = false;
                if (dt.Rows[0]["PrintWidth"].ToString() == "true")

                    chk_PrintWidth.Checked = true;
                else
                    chk_PrintWidth.Checked = false;
                if (dt.Rows[0]["PrintBuyer"].ToString() == "true")

                    chk_PrintBuyers.Checked = true;
                else
                    chk_PrintBuyers.Checked = false;
                if (dt.Rows[0]["ToOrdInConsignee"].ToString() == "true")

                    Chk_to_order_Consignee.Checked = true;
                else
                    Chk_to_order_Consignee.Checked = false;
                Txt_Bill_of_loading.Text = dt.Rows[0]["BillOfLoadingNo"].ToString();
                if (dt.Rows[0]["BillOfLoadingDate"].ToString() != "")
                {
                    Txt_Bill_of_loading_date.Text = DateTime.Parse(dt.Rows[0]["BillOfLoadingDate"].ToString()).ToShortDateString();
                }
                Txt_containerno.Text = dt.Rows[0]["ContainerNo"].ToString();
                Txt_ShippingLine.Text = dt.Rows[0]["ShippingLine"].ToString();
                Txt_ExportEntryNumber.Text = dt.Rows[0]["ExportEntryNo"].ToString();
                if (dt.Rows[0]["ExportEntryDate"].ToString() != "")
                {
                    Txt_ExportEntryDate.Text = DateTime.Parse(dt.Rows[0]["ExportEntryDate"].ToString()).ToShortDateString();
                }
                Txt_FOB_CIF.Text = dt.Rows[0]["FOBCIF"].ToString();
                Txt_InlandTransport.Text = dt.Rows[0]["InlandTransport"].ToString();
                Txt_Frieght.Text = dt.Rows[0]["Freight"].ToString();
                Txt_Insaurance.Text = dt.Rows[0]["Insurance"].ToString();
                Txt_Vessel_flight_no.Text = dt.Rows[0]["VesselFlightNo"].ToString();
                Txt_pre_carriage_by.Text = dt.Rows[0]["PreCarriageBy"].ToString();
                Txt_Place_of_Rect.Text = dt.Rows[0]["PreCarriageRectPlace"].ToString();
                Txt_Port_of_loading.Text = dt.Rows[0]["PortofLoading"].ToString();
                Txt_Port_oif_Discharge.Text = dt.Rows[0]["PortOfDischarge"].ToString();
                Txt_final_destination.Text = dt.Rows[0]["FinalDestCode"].ToString();
                Txt_Mark_No1.Text = dt.Rows[0]["MarkNo1"].ToString();
                Txt_Mark_No2.Text = dt.Rows[0]["MarkNo2"].ToString();
                Txt_Mark_No3.Text = dt.Rows[0]["MarkNo3"].ToString();
                Txt_NoAndKingofPKG.Text = dt.Rows[0]["KindOfPackages"].ToString();
                Txt_terms_of_deliveryPayment.Text = dt.Rows[0]["TermsOfDelivery"].ToString();
                Txt_terms_of_deliveryPayment.Text = dt.Rows[0]["TermsOfPayment"].ToString();
                Txt_Description_of_goods.Text = dt.Rows[0]["GoodsDescription"].ToString();
                txt_footerdescription.Text = dt.Rows[0]["FooterDescription"].ToString();
                txt_specialInstruction.Text = dt.Rows[0]["SpecialInstructions"].ToString();
                Txt_footer_packing.Text = dt.Rows[0]["FooterPacking"].ToString();
                lbl_SOid.Text = dt.Rows[0]["SalesOrderId"].ToString();
                lbl_PIID.Text = dt.Rows[0]["ProformaInvoiceId"].ToString();
                lbl_customerid.Text = dt.Rows[0]["CustomerId"].ToString();
                lbl_ConsigneeID.Text = dt.Rows[0]["ConsigneeId"].ToString();
                lbl_deliveryID.Text = dt.Rows[0]["DeliveryCode"].ToString();
                lbl_currencyId.Text = dt.Rows[0]["Currency"].ToString();
                lbl_FinalDestID.Text = dt.Rows[0]["CountryFinalDestination"].ToString();
                btnUpdate.Visible = true;
                BtnSave.Visible = false;

            }
        }
        catch (Exception ex)
        {

        }

    }

    protected void imgCustomerCode_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void imgOrderNo_Click(object sender, ImageClickEventArgs e)
    {
        lPopUpHeader.Text = "Sales Order";
        makeLookup("SaleOrder");

    }

    protected void makeLookup(string LookupCategory)
    {
        if (LookupCategory == "SaleOrder")
        {

            DataTable dt = cs.makelookupgridSalesOrder();

            GridLookup.DataSource = dt;
            GridLookup.DataBind();
            ModalPopupExtender2.Show();

        }
    }
    protected void Img_btn_search_lookup_Click1(object sender, ImageClickEventArgs e)
    {
        string keyword = txtSearchLook.Text.Trim();
        DataTable dt = cs.makelookupgridSalesOrderwithSearch(keyword);
        GridLookup.DataKeyNames[0] = "SalesOrderId";
        GridLookup.DataSource = dt;
        GridLookup.DataBind();
        ModalPopupExtender2.Show();
    }
    protected void GridLookup_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            string DataKey = GridLookup.SelectedDataKey.Value.ToString();
            DataTable dt = cs.fillSalesOrderRecords(DataKey);
            if (dt.Rows.Count > 0)
            {
                Txt_orderno.Text = dt.Rows[0]["SONo"].ToString();

                Txt_PINo.Text = dt.Rows[0]["PICode"].ToString();
                Txt_CFD.Text = dt.Rows[0]["FinalDestCode"].ToString();
                Txt_PartyCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                Txt_ConsigneeCode.Text = dt.Rows[0]["ConsigneeCode"].ToString();
                Txt_DeliveryCode.Text = dt.Rows[0]["DeliveryToName"].ToString();
                Txt_BuysOrder.Text = dt.Rows[0]["SOCustomerOrder"].ToString();

                Txt_BuysOrderDate.Text = DateTime.Parse(dt.Rows[0]["SOCustomerOrderDate"].ToString()).ToShortDateString();
                TxtCurrency.Text = dt.Rows[0]["CurrencyCode"].ToString();
                try
                {
                    Txt_ETD.Text = DateTime.Parse(dt.Rows[0]["CommittedETD"].ToString()).ToShortDateString();
                }
                catch (Exception ex)
                {
                    Txt_ETD.Text = "";
                }
                try
                {
                    Txt_ETA.Text = DateTime.Parse(dt.Rows[0]["CommittedETA"].ToString()).ToShortDateString();
                }
                catch (Exception ex)
                {
                    Txt_ETD.Text = "";
                }

                Txt_final_destination.Text = dt.Rows[0]["FinalDestCode"].ToString();
                lbl_SOid.Text = dt.Rows[0]["SalesOrderId"].ToString();
                lbl_PIID.Text = dt.Rows[0]["PINo"].ToString();
                lbl_customerid.Text = dt.Rows[0]["SOCustomer"].ToString();
                lbl_ConsigneeID.Text = dt.Rows[0]["SOConsignee"].ToString();
                lbl_deliveryID.Text = dt.Rows[0]["SODeliveryTo"].ToString();
                lbl_currencyId.Text = dt.Rows[0]["SOCurrency"].ToString();
                lbl_FinalDestID.Text = dt.Rows[0]["SOFinalDestination"].ToString();
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void BtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        clearAll();
    }

    protected string AutogenerateInvoiceNo(string financialYear)
    {
        int inv_series;
        string inv_no = "";
        try
        {
            inv_series = cs.getInvoiceSeries(financialYear);
            inv_no = "I" + financialYear + inv_series.ToString().PadLeft(5, '0');
        }
        catch (Exception ex)
        {

        }
        return inv_no;
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            cs.UpdateInv(Txt_InvNumber.Text, txt_Type.Text, txt_year.Text, Txt_invDate.Text, Txt_QSrInv.Text, lbl_SOid.Text, lbl_PIID.Text, Txt_ExporterCode.Text, Txt_CFD.Text, lbl_customerid.Text, lbl_ConsigneeID.Text, lbl_deliveryID.Text, Txt_BuysOrder.Text, Txt_BuysOrderDate.Text, lbl_currencyId.Text, Txt_ETD.Text, Txt_ETA.Text, chk_Print_in_G_I.Checked.ToString(), chk_PrintWidth.Checked.ToString(), chk_PrintBuyers.Checked.ToString(), Chk_to_order_Consignee.Checked.ToString(), Txt_Bill_of_loading.Text, Txt_Bill_of_loading_date.Text, Txt_containerno.Text, Txt_ShippingLine.Text, Txt_ExportEntryNumber.Text, Txt_ExportEntryDate.Text, Txt_FOB_CIF.Text, Txt_InlandTransport.Text, Txt_Frieght.Text, Txt_Insaurance.Text, Txt_Vessel_flight_no.Text, Txt_pre_carriage_by.Text, Txt_Place_of_Rect.Text, Txt_Port_of_loading.Text, Txt_Port_oif_Discharge.Text, lbl_FinalDestID.Text, Txt_Mark_No1.Text, Txt_Mark_No2.Text, Txt_Mark_No3.Text, Txt_NoAndKingofPKG.Text, Txt_terms_of_deliveryPayment.Text, Txt_terms_of_deliveryPayment.Text, Txt_Description_of_goods.Text, txt_footerdescription.Text, txt_specialInstruction.Text, Txt_footer_packing.Text, Session["UserID"].ToString());
            string message = objMsg.UpdatedRecord;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            clearAll();

        }
        catch (Exception ex)
        {
            string message = objMsg.RecordNotUpdated;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);

        }
        finally
        {

        }

    }


    protected void clearAll()
    {
        Txt_InvNumber.Text = "";
        txt_Type.Text = "";
        txt_year.Text = "";
        Txt_invDate.Text = "";
        Txt_orderno.Text = "";
        Txt_QSrInv.Text = "";
        Txt_PINo.Text = "";
        Txt_ExporterCode.Text = "";
        Txt_CFD.Text = "";
        Txt_PartyCode.Text = "";
        Txt_ConsigneeCode.Text = "";
        Txt_DeliveryCode.Text = "";
        Txt_BuysOrder.Text = "";
        Txt_BuysOrderDate.Text = "";
        TxtCurrency.Text = "";
        Txt_ETD.Text = "";
        Txt_ETA.Text = "";
        
        chk_Print_in_G_I.Checked = false;
        chk_PrintWidth.Checked = false;
        chk_PrintBuyers.Checked = false;
        Chk_to_order_Consignee.Checked = false;
        Txt_Bill_of_loading.Text = "";
        Txt_Bill_of_loading_date.Text = "";
        Txt_containerno.Text = "";
        Txt_ShippingLine.Text = "";
        Txt_ExportEntryNumber.Text = "";
        Txt_ExportEntryDate.Text = "";
        Txt_FOB_CIF.Text = "";
        Txt_InlandTransport.Text = "";
        Txt_Frieght.Text = "";
        Txt_Insaurance.Text = "";
        Txt_Vessel_flight_no.Text = "";
        Txt_pre_carriage_by.Text = "";
        Txt_Place_of_Rect.Text = "";
        Txt_Port_of_loading.Text = "";
        Txt_Port_oif_Discharge.Text = "";
        Txt_final_destination.Text = "";
        Txt_NetWeight_KG.Text = "";
        Txt_Mark_No1.Text = "";
        Txt_Mark_No2.Text = "";
        Txt_Mark_No3.Text = "";
        Txt_NoAndKingofPKG.Text = "";
        Txt_terms_of_deliveryPayment.Text = "";
        Txt_terms_of_deliveryPayment.Text = "";
        Txt_Description_of_goods.Text = "";
        txt_footerdescription.Text = "";
        txt_specialInstruction.Text = "";
        Txt_footer_packing.Text = "";

        financial_year = getFinancialYear();
        Txt_InvNumber.Text = AutogenerateInvoiceNo(financial_year);
        Txt_InvNumber.Enabled = false;
        txt_year.Text = financial_year;
        btnUpdate.Visible = false;
        BtnSave.Visible = true;
        TCInvoice.TabIndex = 0;

    }
    protected void gridMaster_PageIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            SqlDataSource1.SelectCommand = cs.makeGrid(ddsearch.SelectedValue, txtSearch.Text.Trim());
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
        }
    }
    protected void GridLookup_PageIndexChanged(object sender, EventArgs e)
    {
        GridLookup.DataBind();
        ModalPopupExtender2.Show();
    }
}