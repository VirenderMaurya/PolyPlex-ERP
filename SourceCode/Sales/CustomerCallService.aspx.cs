using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sales_CustomerCallService : System.Web.UI.Page
{

    #region Define Global
    string logmessage = "";
    Common com = new Common();
    Common_mst objCommon_mst = new Common_mst();
    Common_Message objcommonmessage = new Common_Message();
    FA_Currencymaster objcurrencymaster = new FA_Currencymaster();
    BLLCollection<FA_Currencymaster> colcurrencymaster = new BLLCollection<FA_Currencymaster>();
    SAL_CustomerCallService objcustcallservice = new SAL_CustomerCallService();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        TxtYear.Attributes.Add("readonly", "true");
        TxtNumber.Attributes.Add("readonly", "true");
        TxtCSCRDate.Attributes.Add("readonly", "true");
        TxtCustomerCode.Attributes.Add("readonly", "true");
        TxtFirstResponse.Attributes.Add("readonly", "true");
        TxtSecondResponse.Attributes.Add("readonly", "true");
        TxtThirdResponse.Attributes.Add("readonly", "true");
        TxtNatureOfCompaint.Attributes.Add("readonly", "true");
        TxtExpectedDateofCompletion.Attributes.Add("readonly", "true");
        TxtCompletionDate.Attributes.Add("readonly", "true");
        if (!IsPostBack)
        {
            BindSubType();
            BindComplaintArea();
            BindCallStatus();
            BindCurrency();
            Log.GetLog().FillFinancialYear(TxtYear);
        }
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ClearHeader();
            ClearLintItems();
        }
        catch (Exception ex)
        {
            logmessage = "Customer Call Service Form- btn_add_Click event -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
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
    protected void imgCustomerCode_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "CustomerCode";
        lPopUpHeader.Text = "Customer";
        lSearch.Text = "Search By Customer: ";
        FillAllCustomer("");
        ModalPopupExtender2.Show();
    }
    protected void BindCurrency()
    {
        try
        { 
            colcurrencymaster = objcurrencymaster.GetCurrencyList();
            DdlCurrency.DataSource = colcurrencymaster;
            DdlCurrency.DataTextField = "CurrencyName";
            DdlCurrency.DataValueField = "CurrencyName";
            DdlCurrency.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlCurrency.Items.Add(item);
            DdlCurrency.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Customer CallService Form-BindingCurrency-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
     
        }
    }
    protected void BindCallStatus()
    {
        try
        { 
            DataTable dt = new DataTable();
            dt = com.executeProcedure("Sp_Sal_GetCallStatus");
            DdlStatus.DataSource = dt;
            DdlStatus.DataTextField = "StatusName";
            DdlStatus.DataValueField = "CallStatusId";
            DdlStatus.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlStatus.Items.Add(item);
            DdlStatus.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Customer CallService Form-BindCallStatus-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
     
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
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }
    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "CustomerCode")
        {
            FillAllCustomer(txtSearchFromPopup.Text.Trim());
        }
        if (HidPopUpType.Value == "ComplaintNature")
        {
            BindComplaintNature(txtSearchFromPopup.Text.Trim());
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
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
                    TxtCustomerCode.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    lblcustomername.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                   // txtCustomerName.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                }
                if (HidPopUpType.Value == "ComplaintNature")
                {
                    hidcomplaintid.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    TxtNatureOfCompaint.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                }
           
                //else if (HidPopUpType.Value == "Consignee")
                //{
                //    hidConsigneeId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                //    txtConsignee.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                //}
                //else if (HidPopUpType.Value == "TermsOfDelivery")
                //{
                //    hidTermsOfDeliveryId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                //    txtTermsofDelivery.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                //}



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
    protected void BindComplaintArea()
    {
        try
        {
           
            DataTable dt = new DataTable();
            dt = com.executeProcedure("Sp_Com_GetComplaintArea");
            DdlAreaofComplaint.DataSource = dt;
            DdlAreaofComplaint.DataTextField = "ComplaintArea";
            DdlAreaofComplaint.DataValueField = "Id";
            DdlAreaofComplaint.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlAreaofComplaint.Items.Add(item);
            DdlAreaofComplaint.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Customer CallService Form-BindingAreaComplaint-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindSubType()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = com.executeProcedure("Sp_Get_SubFilmType_Mst");
            DdlSubtype.DataSource = dt;
            DdlSubtype.DataTextField = "SubFilmTypeName";
            DdlSubtype.DataValueField = "SubFilmTypeId";
            DdlSubtype.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlSubtype.Items.Add(item);
            DdlSubtype.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Customer CallService Form-BindSubType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void BindComplaintNature(string value)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = com.GetVal("@complaintnature", value,"Sp_Sal_GetComplaintNature");
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
            logmessage = "Customer CallService Form-BindingComplaintNature-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnComplaint_Click(object sender, ImageClickEventArgs e)
    {
        HidPopUpType.Value = "ComplaintNature";
        lPopUpHeader.Text = "Complaint Nature";
        lSearch.Text = "Search By Complaint Nature ";
        BindComplaintNature("");
        ModalPopupExtender2.Show();
    }
    protected void ImgBtnAddMore_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = null;
        int CCRLineNo;
        if (ViewState["CCRLnNo"] != null)
        {
            CCRLineNo = Convert.ToInt32(ViewState["CCRLnNo"]);
        }
        else
        {
            CCRLineNo = 10;
        }
      
        if (ViewState["Details"] != null)
        {
            dt = (DataTable)ViewState["Details"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("CCRNo", typeof(int));
            dt.Columns.Add("InvoiceNo", typeof(string));
            dt.Columns.Add("FullInvoice", typeof(string));
            dt.Columns.Add("BatchNo", typeof(string));
            dt.Columns.Add("SubType", typeof(string));
            dt.Columns.Add("Micron", typeof(string));
            dt.Columns.Add("Length", typeof(string));
            dt.Columns.Add("Width", typeof(string));
            dt.Columns.Add("Weigth", typeof(string));
            dt.Columns.Add("ComplaintDescription", typeof(string));
            dt.Columns.Add("ExpDateofCompletion", typeof(string));
            dt.Columns.Add("ResponsiblePerson", typeof(string));
            dt.Columns.Add("CompletionDate", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Remarks", typeof(string));
        }
        DataRow drow = dt.NewRow();
        if (ViewState["Details"] != null)
        {
            drow["CCRNo"] = 10 + CCRLineNo;
        }
        else
        {
            drow["CCRNo"] = CCRLineNo;
        }
        drow["InvoiceNo"] = TxtInvioce.Text.Trim();
        drow["FullInvoice"] = TxtFullInvoice.Text.Trim();
        drow["BatchNo"] = TxtBatch.Text.Trim();
        drow["SubType"] = DdlSubtype.SelectedValue;
        drow["Micron"] = TxtMicron.Text.Trim();
        drow["Length"]=TxtLength.Text.Trim();
        drow["Width"]=TxtWidth.Text.Trim();
        drow["Weigth"] = TxtWeightDetails.Text.Trim();
        drow["ComplaintDescription"]=TxtComplaintDescription.Text.Trim();
        drow["ExpDateofCompletion"]=TxtExpectedDateofCompletion.Text.Trim();
        drow["ResponsiblePerson"]=TxtResponsiblePerson.Text.Trim();
        drow["CompletionDate"]=TxtCompletionDate.Text.Trim();
        drow["Status"]=DdlStatus.SelectedValue;
        drow["Remarks"] = TxtRemarks.Text;
        dt.Rows.Add(drow);
        ViewState["Details"] = dt;
        ViewState["CCRLnNo"] = drow["CCRNo"];
        GdvDetails.DataSource = dt;
        GdvDetails.DataBind();
        ClearLintItems();
    }
    protected void GdvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView GdvDetails = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        GdvDetails.SelectedIndex = row.RowIndex;
        #region Row Deleting in temp table
        if (e.CommandName == "del")
        {
            int lineno = Convert.ToInt32(e.CommandArgument);
            DataTable dt = (DataTable)ViewState["Details"];
            int i = 0;
            while (i < dt.Rows.Count)
            {
                if (Convert.ToInt32(dt.Rows[i]["CCRNo"]) == lineno)
                {
                    dt.Rows[i].Delete();
                }
                i++;
            }
            if (dt.Rows.Count == 0)
            {
                GdvDetails.DataSource = null;
                GdvDetails.DataBind();
            }
            else
            {
                GdvDetails.DataSource = dt;
                GdvDetails.DataBind();
            }
        }
        #endregion
    }
    protected void GdvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (hidAutoIdHeader.Value == "")
            {
                e.Row.Cells[0].Visible = false;
            }
            else if (hidAutoIdHeader.Value != "")
            {
                e.Row.Cells[0].Visible = true;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Customer Call Service Form- GdvVatDetails_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ClearHeader()
    {
        lblcustomername.Text = "";
        TxtCSCRType.Text = "";
        Log.GetLog().FillFinancialYear(TxtYear);
        TxtCSCRDate.Text = "";
        TxtCSCRObservation.Text = "";
        TxtCustomerCode.Text = "";
        TxtFinalCustomer.Text = "";
        TxtContactPerson.Text = "";
        Txtweight.Text = "";
        TxtValue.Text = "";
        DdlCurrency.SelectedValue = "0";
        Chksamplerecieved.Checked = false;
        TxtNatureOfCompaint.Text = "";
        TxtCustomerClaim.Text = "";
        Chkphotorecieved.Checked = false;
        DdlAreaofComplaint.SelectedValue = "0";
        TxtOurDANo.Text = "";
        TxtNoofRolls.Text = "";
        TxtCreditNotes.Text = "";
        TxtObservations.Text = "";
        TxtFirstResponse.Text = "";
        DdlFirstDelyBy.SelectedValue = "0";
        TxtSecondResponse.Text = "";
        DdlSecondDelyBy.SelectedValue = "0";
        TxtThirdResponse.Text = "";
        DdlThirdDelyBy.SelectedValue = "0";
        TxtOLPS.Text = "";
        TxtActioPlan.Text = "";
        TxtActionTaken.Text = "";
        TxtReturnQuality.Text = "";
        TxtReturnValue.Text = "";
        GdvDetails.DataSource = null;
        GdvDetails.DataBind();
        ViewState["Details"] = null;
    }
    protected void ClearLintItems()
    {
        TxtComplaintDescription.Text = "";
        TxtExpectedDateofCompletion.Text = "";
        TxtResponsiblePerson.Text = "";
        TxtCompletionDate.Text = "";
        DdlStatus.SelectedValue = "0";
        TxtRemarks.Text = "";
     
        TxtInvioce.Text = "";
        TxtFullInvoice.Text = "";
        TxtBatch.Text = "";
        DdlSubtype.SelectedValue = "0";
        TxtMicron.Text = "";
        TxtWidth.Text = "";
        TxtWeightDetails.Text = "";
        TxtLength.Text = "";
    }

    protected void BtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string createon= DateTime.Now.ToString();
            ViewState["CreatedOn"]=createon;
            objcustcallservice.CSCRType = TxtCSCRType.Text.Trim();
            objcustcallservice.Year = TxtYear.Text.Trim();
            if (TxtCSCRDate.Text.Trim() == "")
            {
                TxtCSCRDate.Text = "01/01/1900";
            }
            objcustcallservice.CSCRDate = TxtCSCRDate.Text.Trim();
            objcustcallservice.ComplaintObservation = TxtCSCRObservation.Text.Trim();
            objcustcallservice.CustomerCode = TxtCustomerCode.Text.Trim();
            objcustcallservice.FinalCustomer = TxtFinalCustomer.Text.Trim();
            objcustcallservice.ContactPerson = TxtContactPerson.Text.Trim();
            objcustcallservice.HeaderWeight = Txtweight.Text.Trim();
            objcustcallservice.Value = TxtValue.Text.Trim();
            objcustcallservice.Currency = DdlCurrency.SelectedValue;
            objcustcallservice.SampleRecieved = Chksamplerecieved.Checked;
            objcustcallservice.NatureOfComplaint = TxtNatureOfCompaint.Text.Trim();
            objcustcallservice.CustomerClaim = TxtCustomerClaim.Text.Trim();
            objcustcallservice.PhotoReceived = Chkphotorecieved.Checked;
            objcustcallservice.AreaOfComplaint = DdlAreaofComplaint.SelectedValue;
            objcustcallservice.DANo = TxtOurDANo.Text.Trim();
            objcustcallservice.NoOfRolls = TxtNoofRolls.Text;
            objcustcallservice.CreditNotes = TxtCreditNotes.Text.Trim();
            objcustcallservice.TSObservation = TxtObservations.Text.Trim();
            if (TxtFirstResponse.Text.Trim() == "")
            {
                TxtFirstResponse.Text = "01/01/1900";
            }
            objcustcallservice.FirstResponseDate = TxtFirstResponse.Text.Trim();
            objcustcallservice.FirstDelyBy = DdlFirstDelyBy.SelectedValue;
            if (TxtSecondResponse.Text.Trim() == "")
            {
                TxtSecondResponse.Text = "01/01/1900";
            }

            objcustcallservice.SecondResponseDate = TxtSecondResponse.Text.Trim();
            objcustcallservice.SecondDelyBy = DdlSecondDelyBy.SelectedValue;
            if (TxtThirdResponse.Text.Trim() == "")
            {
                TxtThirdResponse.Text = "01/01/1900";
            }
            objcustcallservice.ThirdResponseDate = TxtThirdResponse.Text.Trim();
            objcustcallservice.ThirdDelyBy = DdlThirdDelyBy.SelectedValue;
            objcustcallservice.OPLS = TxtOLPS.Text.Trim();
            objcustcallservice.ActionPlan = TxtActioPlan.Text.Trim();
            objcustcallservice.ActionTaken = TxtActionTaken.Text.Trim();
            objcustcallservice.ReturnQuality = TxtReturnQuality.Text.Trim();
            objcustcallservice.ReturnValue = TxtReturnValue.Text.Trim();
            objcustcallservice.CreatedOn = ViewState["CreatedOn"].ToString();
            objcustcallservice.CreatedBy = Session["userid"].ToString();
            if (GdvDetails.Rows.Count > 0)
            {
                foreach (GridViewRow row in GdvDetails.Rows)
                {
                    int CSCRLineNo = Convert.ToInt32((((Label)row.FindControl("Lblccrlineno")).Text));
                    objcustcallservice.CSCRLineNo = CSCRLineNo;
                    string InvoiceNo = ((Label)row.FindControl("LblInvoiceNo")).Text;
                    objcustcallservice.InvoiceNo = InvoiceNo;
                    string FullInvoice = ((Label)row.FindControl("LblFullInvoice")).Text;
                    objcustcallservice.FullInvoice = FullInvoice;
                    string BatchNo = ((Label)row.FindControl("LblBatchNo")).Text;
                    objcustcallservice.BatchNo = BatchNo;
                    string SubType = ((Label)row.FindControl("LblSubType")).Text;
                    objcustcallservice.SubType = SubType;
                    string Micron = ((Label)row.FindControl("LblMicron")).Text;
                    objcustcallservice.Micron = Micron;
                    string Length = ((Label)row.FindControl("LblLength")).Text;
                    objcustcallservice.Length = Length;
                    string Width = ((Label)row.FindControl("LblWidth")).Text;
                    objcustcallservice.Width = Width;
                    string Weigth = ((Label)row.FindControl("LblWeigth")).Text;
                    objcustcallservice.Weight = Weigth;
                    string ComplaintDescription = ((Label)row.FindControl("LblComplaintDescription")).Text;
                    objcustcallservice.ComplaintDescription = ComplaintDescription;
                    string ExpDateOfCompletion = ((Label)row.FindControl("LblExpDateofCompletion")).Text;
                    if (ExpDateOfCompletion.Trim() == "")
                    {
                        ExpDateOfCompletion = "01/01/1900";
                    }
                    objcustcallservice.ExpDateOfCompletion = ExpDateOfCompletion;
                    string ResponsiblePerson = ((Label)row.FindControl("LblResponsiblePerson")).Text;
                    objcustcallservice.ResponsiblePerson = ResponsiblePerson;
                    string CompletionDate = ((Label)row.FindControl("LblCompletionDate")).Text;
                    if (CompletionDate.Trim() == "")
                    {
                        CompletionDate = "01/01/1900";
                    }
                    objcustcallservice.CompletionDate = CompletionDate;
                    string Remarks = ((Label)row.FindControl("LblRemarks")).Text;
                    objcustcallservice.Remarks = Remarks;
                    string CallStatus = ((Label)row.FindControl("LblStatus")).Text;
                    objcustcallservice.CallStatus = CallStatus;
                    int inserted = objcustcallservice.insertcustomercallservice();
                    if (inserted == 2)
                    {
                        ClearHeader();
                        ClearLintItems();
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                        return;
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                        return;
                    }
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.AddLineItem, 125, 300);
                return;
            }
            
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
        }
    }
}