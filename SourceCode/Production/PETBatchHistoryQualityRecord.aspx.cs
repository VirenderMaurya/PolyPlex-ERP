using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Production_PETBatchHistoryQualityRecord : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    Common com = new Common();
    Common_Message commessage = new Common_Message();
    FA_VoucherType objVoucherType = new FA_VoucherType();
    BLLCollection<FA_VoucherType> col = new BLLCollection<FA_VoucherType>();
    Proc_SalesOrderInventory objProc = new Proc_SalesOrderInventory();
    Prod_PETBatchHistoryQuality objProdPETQuality = new Prod_PETBatchHistoryQuality();
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
            Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lbl_PageHeader.Text = "C P Chips Quality";
            DataTable dt = com.fillSearch("242");
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
            BindVoucherType();
            txtVoucherNo.Attributes.Add("readonly", "true");
            txtVoucherYear.Attributes.Add("readonly", "true");
            txtVoucherDate.Attributes.Add("readonly", "true");
            txtVoucherDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
            txtVoucherYear.Text = DateTime.Now.Year.ToString() + "-" + (Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) + 1).ToString();

            string strSeriesLastNamber = "";
            decimal LastNumber = GetLastVoucherNumber() + 1;
            strSeriesLastNamber = LastNumber.ToString();
            if (strSeriesLastNamber == "0")
            {
                strSeriesLastNamber = "00001";
            }
            strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
            txtVoucherNo.Text = "PBQ" + txtVoucherYear.Text + "-" + strSeriesLastNamber;
        }
        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;

    }
    private string CustomPad(int iNoOfCharToPad, char sPadChar, string sString)
    {
        string sPadStr = "";

        if (sString.Length < iNoOfCharToPad)
        {
            for (int i = 0; i < iNoOfCharToPad - sString.Length; i++)
            {
                sPadStr += sPadChar;
            }
            sPadStr += sString;
        }
        else
        {
            sPadStr = sString;
        }

        return sPadStr;
    }


    void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        try
        {

            if (ddsearch.SelectedValue == "")
            {
                string message = "Please select any search criteria.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            }
            else
            {
                if (ddsearch.SelectedItem.Value == "VoucherNo")
                {
                    string id = txtSearch.Text;
                    if (id == "")
                    {
                        id = "0";
                    }
                    DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Prod_PETBatchQuality_byVoucherNo");
                    if (dt.Rows.Count > 0)
                    {
                        gridMaster.Visible = true;
                        // Gdvlookup.Visible = false;
                        gridMaster.DataSource = dt;
                        gridMaster.DataBind();
                        ModalPopupExtender1.Show();
                    }
                    //get datatable
                    //colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
                }

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Production/PETBatchHistoryQualityRecord.aspx");
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
            logmessage = "PET Batch History Quality Form-BindingVoucherType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected decimal GetLastVoucherNumber()
    {
        decimal TopValueOrderNumber = objProdPETQuality.GetLastPETBatchVoucherNumber();
        if (TopValueOrderNumber == 0)
        {
            TopValueOrderNumber = 0;
        }

        return TopValueOrderNumber;


    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {

        if (Convert.ToInt32(txtEICycletimeHH.Text) > 23)
        {
            txtEICycletimeHH.Text = "";
            txtEICycletimeHH.Focus();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct EI Cycle time : HH", 125, 300);
            return;
        }
        if (Convert.ToInt32(txtEICycletimeMM.Text) > 59)
        {
            txtEICycletimeMM.Text = "";
            txtEICycletimeMM.Focus();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct EI Cycle time : MM", 125, 300);
            return;
        }

        if (Convert.ToInt32(txtBATransHH.Text) > 23)
        {
            txtBATransHH.Text = "";
            txtBATransHH.Focus();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct BA Trans. time : HH", 125, 300);
            return;
        }
        if (Convert.ToInt32(txtBATransMM.Text) > 59)
        {
            txtBATransMM.Text = "";
            txtBATransMM.Focus();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct BA Trans. : MM", 125, 300);
            return;
        }

        if (Convert.ToInt32(txtPCReacTiemHH.Text) > 23)
        {
            txtPCReacTiemHH.Text = "";
            txtPCReacTiemHH.Focus();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct PC Reach. time : HH", 125, 300);
            return;
        }
        if (Convert.ToInt32(txtPCReacTiemMM.Text) > 59)
        {
            txtPCReacTiemMM.Text = "";
            txtPCReacTiemMM.Focus();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct PC Reach. time : MM", 125, 300);
            return;
        }
        if (Convert.ToInt32(txtCastingTimeHH.Text) > 23)
        {
            txtCastingTimeHH.Text = "";
            txtCastingTimeHH.Focus();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct Casting time : HH", 125, 300);
            return;
        }
        if (Convert.ToInt32(txtCastingTimeMM.Text) > 59)
        {
            txtCastingTimeMM.Text = "";
            txtCastingTimeMM.Focus();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct Casting time : MM", 125, 300);
            return;
        }

            if (ImgBtnSave.ImageUrl == "~/Images/btn_update.png")
            {
                int Autoid = 0; ;
                if (ViewState["AUtoid"] != null)
                {
                    Autoid = Convert.ToInt32(ViewState["AUtoid"].ToString());
                }
                string userid = "0";
                if (Session["userid"] != null)
                {
                    userid = Session["userid"].ToString();

                }


                int updatedheader = objProdPETQuality.UpdatePETBatchQuality(Autoid, txtVoucherYear.Text, txtVoucherNo.Text, txtVoucherDate.Text, (TimePickerVoucher.Hour).ToString() + " : " + TimePickerVoucher.Minute.ToString(), Convert.ToInt32(DdlVoucherType.SelectedValue), Convert.ToDecimal(txtSilica.Text), txtEICycletimeHH.Text + ":" + txtEICycletimeMM.Text, Convert.ToDecimal(txtEIFinalTemp.Text),
                    Convert.ToDecimal(txtBHTFilter.Text), txtBATransHH.Text + ":" + txtBATransMM.Text, Convert.ToDecimal(txtFinProd.Text), txtPCReacTiemHH.Text + ":" + txtPCReacTiemMM.Text,
      Convert.ToDecimal(txtBACutoffRPM.Text), Convert.ToDecimal(txtCutoffKW.Text), txtCastingTimeHH.Text + ":" + txtCastingTimeMM.Text, Convert.ToDecimal(txtIV.Text), Convert.ToDecimal(txtCOOH.Text), Convert.ToDecimal(txtASH.Text), Convert.ToDecimal(txtDEG.Text)
      , Convert.ToDecimal(txtMP.Text), Convert.ToDecimal(txtNumberofChips.Text), txtColorVisual.Text, Convert.ToDecimal(txtL.Text), Convert.ToDecimal(txta.Text)
      , Convert.ToDecimal(txtb.Text), txtGrade.Text, Convert.ToDecimal(txtMoisture.Text)
      , Convert.ToDecimal(txtOligomer.Text), txtRemarks.Text, Convert.ToInt32(userid));
                if (updatedheader > 0)
                {

                    ClearLineItems();
                    ImgBtnSave.ImageUrl = "~/Images/btnSave.png";
                    string strSeriesLastNamber = "";
                    decimal LastNumber = GetLastVoucherNumber() + 1;
                    strSeriesLastNamber = LastNumber.ToString();
                    if (strSeriesLastNamber == "0")
                    {
                        strSeriesLastNamber = "00001";
                    }
                    strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
                    txtVoucherNo.Text = "PBQ" + txtVoucherYear.Text + "-" + strSeriesLastNamber;

                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);

                }


            }

            else
            {
                string userid = "0";

                if (Session["userid"] != null)
                {
                    userid = Session["userid"].ToString();

                }

                bool booInsert = objProdPETQuality.saveRecordsPETBatchQuality(txtVoucherYear.Text,txtVoucherNo.Text,txtVoucherDate.Text,(TimePickerVoucher.Hour).ToString() + " : " + TimePickerVoucher.Minute.ToString(),Convert.ToInt32(DdlVoucherType.SelectedValue),Convert.ToDecimal(txtSilica.Text),txtEICycletimeHH.Text+":" +txtEICycletimeMM.Text,Convert.ToDecimal(txtEIFinalTemp.Text),
                    Convert.ToDecimal(txtBHTFilter.Text), txtBATransHH.Text+":"+txtBATransMM.Text,Convert.ToDecimal(txtFinProd.Text),txtPCReacTiemHH.Text+":"+txtPCReacTiemMM.Text,
      Convert.ToDecimal(txtBACutoffRPM.Text),Convert.ToDecimal(txtCutoffKW.Text),txtCastingTimeHH.Text+":"+txtCastingTimeMM.Text,Convert.ToDecimal(txtIV.Text),Convert.ToDecimal(txtCOOH.Text),Convert.ToDecimal(txtASH.Text),Convert.ToDecimal(txtDEG.Text)
      ,Convert.ToDecimal(txtMP.Text),Convert.ToDecimal(txtNumberofChips.Text),txtColorVisual.Text,Convert.ToDecimal(txtL.Text),Convert.ToDecimal(txta.Text)
      ,Convert.ToDecimal(txtb.Text),txtGrade.Text,Convert.ToDecimal(txtMoisture.Text)
      , Convert.ToDecimal(txtOligomer.Text), txtRemarks.Text, Convert.ToInt32(userid));


                if (booInsert == true)
                {
                    ClearLineItems();
                    string strSeriesLastNamber = "";
                    decimal LastNumber = GetLastVoucherNumber() + 1;
                    strSeriesLastNamber = LastNumber.ToString();
                    if (strSeriesLastNamber == "0")
                    {
                        strSeriesLastNamber = "00001";
                    }
                    strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
                    txtVoucherNo.Text = "PBQ" + txtVoucherYear.Text + "-" + strSeriesLastNamber;
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                }
            }





    }



    private void ClearLineItems()
    {
       BindVoucherType();
     
       txtSilica.Text = "";
       txtEICycletimeHH.Text = "";
       txtEICycletimeMM.Text = "";
       txtEIFinalTemp.Text = "";
       txtBHTFilter.Text = "";
       txtBATransHH.Text = "";
       txtBATransMM.Text = "";
       txtFinProd.Text = "";

       txtPCReacTiemHH.Text = "";
       txtPCReacTiemMM.Text = "";
       txtBACutoffRPM.Text = "";
       txtCutoffKW.Text = "";
       txtCastingTimeHH.Text = "";
       txtCastingTimeMM.Text = "";
       txtIV.Text = "";
       txtCOOH.Text = "";
       txtASH.Text = "";
       txtDEG.Text = "";
       txtMP.Text = "";
       txtNumberofChips.Text = "";
       txtGrade.Text = "";
       txtMoisture.Text = "";
       txtOligomer.Text = "";


       txtColorVisual.Text = "";
       txtL.Text = "";
       txta.Text = "";
       txtb.Text = "";
       txtRemarks.Text = "";
    }
    protected void ImgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Production/PETBatchHistoryQualityRecord.aspx");
    }

    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gridMaster.PageIndex = e.NewPageIndex;
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddsearch.SelectedItem.Value == "VoucherNo")
            {
                string id = txtSearch.Text;
                if (id == "")
                {
                    id = "0";
                }
                DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Prod_PETBatchQuality_byVoucherNo");
                if (dt.Rows.Count > 0)
                {
                    gridMaster.Visible = true;
                    // Gdvlookup.Visible = false;
                    gridMaster.DataSource = dt;
                    gridMaster.DataBind();
                    ModalPopupExtender1.Show();
                }
                //get datatable
                //colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
            }


        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        string id = txtSearchList.Text;

        if (id == "")
        {
            id = "0";
        }
        DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Prod_PETBatchQuality_byVoucherNo");
        if (dt.Rows.Count > 0)
        {
            gridMaster.Visible = true;
            // Gdvlookup.Visible = false;
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
    }


    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = gridMaster.SelectedDataKey.Value.ToString();
        ViewState["AUtoid"] = id;
        //string id = ((Label)row.FindControl("lblRawMaterial")).Text;
        //  ViewState["MachineDataid"] = id;
        DataTable dt = com.GetVal("@Autoid", id, "Sp_Get_Prod_PETBatchQuality_byAutoid");
        if (dt.Rows.Count > 0)
        {


            txtVoucherYear.Text = dt.Rows[0]["VoucherYear"].ToString();
            txtVoucherNo.Text = dt.Rows[0]["VoucherNo"].ToString();
            txtVoucherDate.Text = dt.Rows[0]["voucherDate"].ToString();
            DdlVoucherType.SelectedValue = dt.Rows[0]["Type"].ToString();

            txtSilica.Text = dt.Rows[0]["silica"].ToString(); ;

            string[] strsplit = dt.Rows[0]["EICycleTime"].ToString().Split(':');
            txtEICycletimeHH.Text = strsplit[0].ToString(); 
            ;
            txtEICycletimeMM.Text = strsplit[1].ToString();



            txtEIFinalTemp.Text = dt.Rows[0]["EIFinalTemp"].ToString(); ;
            txtBHTFilter.Text = dt.Rows[0]["BHTFilter"].ToString(); ;

            string[] strBATraTimesplit = dt.Rows[0]["BATransTime"].ToString().Split(':'); ;
            txtBATransHH.Text = strBATraTimesplit[0].ToString();


            txtBATransMM.Text = strBATraTimesplit[1].ToString();
            txtFinProd.Text = dt.Rows[0]["FINProdTemp"].ToString(); ;


            string[] strPCTime = dt.Rows[0]["PCReacTime"].ToString().Split(':');

            txtPCReacTiemHH.Text = strPCTime[0].ToString(); ;
            txtPCReacTiemMM.Text = strPCTime[1].ToString();


            txtBACutoffRPM.Text = dt.Rows[0]["BACustoffRPM"].ToString(); ;
            txtCutoffKW.Text = dt.Rows[0]["BACutoffKW"].ToString(); ;

            string[] strcasting = dt.Rows[0]["CastingTime"].ToString().Split(':');
            txtCastingTimeHH.Text = strcasting[0].ToString();


            txtCastingTimeMM.Text = strcasting[1].ToString(); ;

            txtIV.Text = dt.Rows[0]["IV"].ToString(); ;
            txtCOOH.Text = dt.Rows[0]["COOH"].ToString(); ;
            txtASH.Text = dt.Rows[0]["ASH"].ToString(); ;
            txtDEG.Text = dt.Rows[0]["DEG"].ToString(); ;
            txtMP.Text = dt.Rows[0]["MP"].ToString(); ;
            txtNumberofChips.Text = dt.Rows[0]["Numberofchipps"].ToString(); ;
            txtGrade.Text = dt.Rows[0]["Grade"].ToString(); ;
            txtMoisture.Text = dt.Rows[0]["Moisture"].ToString(); ;
            txtOligomer.Text = dt.Rows[0]["Oligomer"].ToString(); ;


            txtColorVisual.Text = dt.Rows[0]["ColourVisual"].ToString();
            txtL.Text = dt.Rows[0]["L"].ToString();
            txta.Text = dt.Rows[0]["a"].ToString();
            txtb.Text = dt.Rows[0]["b"].ToString();
            txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
            ImgBtnSave.ImageUrl = "~/Images/btn_update.png";

        }



    }


}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       