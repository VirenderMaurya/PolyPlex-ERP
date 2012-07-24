using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Production_CPChipsQuality : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    Common com = new Common();
    Common_Message commessage = new Common_Message();
    FA_VoucherType objVoucherType = new FA_VoucherType();
    BLLCollection<FA_VoucherType> col = new BLLCollection<FA_VoucherType>();
    Proc_SalesOrderInventory objProc = new Proc_SalesOrderInventory();
    Prod_CPChipsQuality objProdChipsQuality = new Prod_CPChipsQuality();
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
            txtVoucherNo.Text = "CPC" + txtVoucherYear.Text + "-" + strSeriesLastNamber;
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
                    DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Prod_CPChipsQuality_byVoucherNo");
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
        Response.Redirect("../Production/CPChipsQuality.aspx");
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
            logmessage = "CP Chips Quality Form-BindingVoucherType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected decimal GetLastVoucherNumber()
    {
        decimal TopValueOrderNumber = objProdChipsQuality.GetLastVoucherNumber();
        if (TopValueOrderNumber == 0)
        {
            TopValueOrderNumber = 0;
        }

        return TopValueOrderNumber;


    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        // if (BtnSave.Text == "Update")
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


            int updatedheader = objProdChipsQuality.UpdateCpChipsQuality(Autoid, txtVoucherYear.Text, txtVoucherNo.Text, txtVoucherDate.Text, (TimePickerVoucher.Hour).ToString() + " : " + TimePickerVoucher.Minute.ToString(), Convert.ToInt32(DdlVoucherType.SelectedValue), Convert.ToDecimal(txtLab.Text), Convert.ToDecimal(txtTOV.Text), Convert.ToDecimal(txtCOOH.Text), Convert.ToDecimal(txtASH.Text), Convert.ToDecimal(txtDEG.Text), Convert.ToDecimal(txtChips.Text), txtVisual.Text, Convert.ToDecimal(txtL.Text), Convert.ToDecimal(txta.Text), Convert.ToDecimal(txtb.Text), txtRemarks.Text, Convert.ToInt32(userid));
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
                txtVoucherNo.Text = "CPC" + txtVoucherYear.Text + "-" + strSeriesLastNamber;
              
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

            bool booInsert = objProdChipsQuality.saveRecordsCpChipsQuality(txtVoucherYear.Text, txtVoucherNo.Text, txtVoucherDate.Text, (TimePickerVoucher.Hour).ToString() + " : " + TimePickerVoucher.Minute.ToString(), Convert.ToInt32(DdlVoucherType.SelectedValue), Convert.ToDecimal(txtLab.Text), Convert.ToDecimal(txtTOV.Text), Convert.ToDecimal(txtCOOH.Text), Convert.ToDecimal(txtASH.Text), Convert.ToDecimal(txtDEG.Text), Convert.ToDecimal(txtChips.Text), txtVisual.Text, Convert.ToDecimal(txtL.Text), Convert.ToDecimal(txta.Text), Convert.ToDecimal(txtb.Text), txtRemarks.Text, Convert.ToInt32(userid));


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
                txtVoucherNo.Text = "CPC" + txtVoucherYear.Text + "-" + strSeriesLastNamber;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

            }
        }
               

           

      
    }



    private void ClearLineItems()
    {
        BindVoucherType();
        txtLab.Text = "";
        txtTOV.Text = "";
        txtCOOH.Text = "";
        txtASH.Text="";
        txtDEG.Text = "";
        txtChips.Text = "";
        txtVisual.Text = "";
        txtL.Text = "";
        txta.Text = "";
        txtb.Text = "";
        txtRemarks.Text="";
    
    }
    protected void ImgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Production/CPChipsQuality.aspx");
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
                DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Prod_CPChipsQuality_byVoucherNo");
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
            DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Prod_CPChipsQuality_byVoucherNo");
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
        DataTable dt = com.GetVal("@Autoid", id, "Sp_Get_Prod_CPChipsQuality_byAutoid");
        if (dt.Rows.Count > 0)
        {
            txtVoucherYear.Text = dt.Rows[0]["VoucherYear"].ToString();
            txtVoucherNo.Text = dt.Rows[0]["VoucherNo"].ToString();
            txtVoucherDate.Text = dt.Rows[0]["voucherDate"].ToString();
            DdlVoucherType.SelectedValue = dt.Rows[0]["Type"].ToString();
            txtLab.Text = dt.Rows[0]["LAB"].ToString();
            txtTOV.Text = dt.Rows[0]["TOV"].ToString();
            txtCOOH.Text = dt.Rows[0]["COOH"].ToString();
            txtASH.Text = dt.Rows[0]["ASH"].ToString();
            txtDEG.Text = dt.Rows[0]["DEG"].ToString();
            txtChips.Text = dt.Rows[0]["Chips"].ToString();
            txtVisual.Text = dt.Rows[0]["Color Visual"].ToString();
            txtL.Text = dt.Rows[0]["L"].ToString();
            txta.Text = dt.Rows[0]["a"].ToString();
            txtb.Text = dt.Rows[0]["b"].ToString();
            txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
            ImgBtnSave.ImageUrl = "~/Images/btn_update.png";

        }



    }


}