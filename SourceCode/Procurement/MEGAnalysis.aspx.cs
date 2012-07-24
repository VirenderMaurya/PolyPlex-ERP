using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_MEGAnalysis : System.Web.UI.Page
{
    #region Define Global variable here
    string logmessage = "";
    Common_Message commessage = new Common_Message();
    Common com = new Common();
    Proc_ChipsQuality_MEGAnalysis objmeganalysis = new Proc_ChipsQuality_MEGAnalysis();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindSearchDropDown("239");
                Log.GetLog().FillFinancialYear(TxtYear);
                Readonlycontrols();
                Log.PageHeading(this, "Chips Quality-MEG Analysis Form");
            }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "MEG Analysis Form- Page_Load() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindSearchDropDown(string formid)
    {
        try
        {
            DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
            DataTable dt = com.fillSearch(formid);
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "Chips Quality-MEGAnalysis Form- BindSearchDropDown Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindMasterSearchBox()
    {
        try
        {
            ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
            btn_add.Click += new ImageClickEventHandler(btn_add_Click);
            btn_add.CausesValidation = false;
            ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
            btn_search.CausesValidation = false;
            btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        }
        catch (Exception ex)
        {
            logmessage = "PTA Analysis Form- BindMasterSearchBox() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            bindsearch();
        }
        catch (Exception ex)
        {
            logmessage = "MEG Analysis Form- btn_search_Click() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    private void bindsearch()
    {
        txtSearchList.Text = "";
        DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddsearch.SelectedValue == "")
        {
            string message = "Please select any search criteria.";
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
        }
        else
        {
            DataTable dt = null;
            if (ddsearch.SelectedItem.Value == "VoucherNo")
            {
                lSearchList.Text = "Search By Voucher No";
                dt = objmeganalysis.SearchMEG("VoucherNo", txtSearch.Text);
            }
            if (ddsearch.SelectedItem.Value == "VendorCode")
            {
                lSearchList.Text = "Search By Vendor Code";
                dt = objmeganalysis.SearchMEG("VendorCode", txtSearch.Text);
            }
            if (ddsearch.SelectedItem.Value == "VendorName")
            {
                lSearchList.Text = "Search By Vendor Name";
                dt = objmeganalysis.SearchMEG("VendorName", txtSearch.Text);
            }
            gridMaster.Visible = true;
            Gdvlookup.Visible = false;
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            cleardetails();
            btnSave.ImageUrl = "~/Images/btnSave.png";
            btnSave.Enabled = true;
            hidAutoIdHeader.Value = "";
        }
        catch (Exception ex)
        {
            logmessage = "MEG Analysis Form- btn_add_Click() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void cleardetails()
    {
        TxtMoisture.Text = "";
        Lblvendorname.Text = "";
        TxtVoucherNo.Text = "";
        TxtGIANo.Text = "";
        TxtInvoiceNo.Text = "";
        TxtRemarks.Text = "";
        TxtAcidity.Text = "";
        TxtAppearance.Text = "";
        TxtAlpha.Text = "";
        TxtAppearance.Text = "";
        TxtNM1.Text = "";
        TxtNM2.Text = "";
        TxtNM3.Text = "";
        TxtVendor.Text = "";
        TxtTankerNo.Text = "";
        TxtVoucherDate.Text = "";
        TxtAldehyde.Text = "";
        TxtSpecificGravity.Text = "";
    }
    private void Readonlycontrols()
    {
        TxtYear.Attributes.Add("readonly", "true");
        TxtVoucherNo.Attributes.Add("readonly", "true");
        TxtVendor.Attributes.Add("readonly", "true");
        TxtVoucherDate.Attributes.Add("readonly", "true");
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Update record
            if (btnSave.ImageUrl == "~/Images/btn_update.png")
            {
                #region update headeritem only
                if (objmeganalysis.updateheader(TxtVoucherNo.Text,TxtYear.Text,TxtVoucherDate.Text,TxtVendor.Text,
                    TxtTankerNo.Text,TxtGIANo.Text,TxtInvoiceNo.Text,TxtAppearance.Text,TxtAlpha.Text,TxtMoisture.Text,
                    TxtAcidity.Text,TxtNM1.Text,TxtNM2.Text,TxtNM3.Text,TxtAldehyde.Text,TxtSpecificGravity.Text,
                    TxtRemarks.Text,Session["userId"].ToString()))
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.UpdatedRecord, 125, 300);
                    return;
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordNotUpdated, 125, 300);
                    return;
                }
                #endregion
            }
            #endregion
            #region Insert record
            else
            {
                bool saved = false;
                saved = objmeganalysis.saveRecords(TxtYear.Text, TxtVoucherDate.Text, TxtVendor.Text, TxtTankerNo.Text,
                    TxtGIANo.Text, TxtInvoiceNo.Text, TxtAppearance.Text, TxtAlpha.Text, TxtMoisture.Text, TxtAcidity.Text,
                    TxtNM1.Text, TxtNM2.Text, TxtNM3.Text, TxtAldehyde.Text, TxtSpecificGravity.Text, TxtRemarks.Text,
                    Session["userId"].ToString());
                if (saved)
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordSaved, 125, 300);
                    cleardetails();
                    return;
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, commessage.RecordNotSaved, 125, 300);
                    return;
                }
            }
        }
            #endregion
        catch (Exception ex)
        {
            logmessage = "PTA Analysis Form- btnSave_Click() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        DataTable dt = null;
        if (ddlSearch.SelectedValue.ToString() == "VoucherNo")
        {
            gridMaster.Visible = true;
            Gdvlookup.Visible = false;
            dt = objmeganalysis.SearchMEG("VoucherNo", txtSearchList.Text);
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
        }
        if (ddlSearch.SelectedValue.ToString() == "VendorCode")
        {
            gridMaster.Visible = true;
            Gdvlookup.Visible = false;
            dt = objmeganalysis.SearchMEG("VendorCode", txtSearchList.Text);
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
        }
        if (ddlSearch.SelectedValue.ToString() == "VendorName")
        {
            gridMaster.Visible = true;
            Gdvlookup.Visible = false;
            dt = objmeganalysis.SearchMEG("VendorName", txtSearchList.Text);
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
        }
        if (HidPopUpType.Value == "vendor")
        {
            gridMaster.Visible = false;
            Gdvlookup.Visible = true;
            BindVendorList(txtSearchList.Text.Trim());
        }
        ModalPopupExtender1.Show();
    }
    protected void ImgBtnVendor_Click(object sender, ImageClickEventArgs e)
    {
        bindvendorlist();
    }
    private void bindvendorlist()
    {
        try
        {
            lSearchList.Text = "Search By Vendor Code/Name";
            HidPopUpType.Value = "vendor";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindVendorList("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "MEG Analysis Form- ImgBtnVendor_Click() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindVendorList(string vendorcode)
    {
        try
        {
            DataTable dtvendors = com.GetVal("@Vendorname", vendorcode, "SP_FA_GetVendorNameFromVendor_mst");
            Gdvlookup.DataSource = dtvendors;
            Gdvlookup.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "MEG Analysis Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string id = gridMaster.SelectedDataKey.Value.ToString();
            #region clear controls
            cleardetails();
            #endregion
            #region BindHeaderdetails
            DataTable dtheader = com.GetVal("@Id", id, "Sp_Proc_MEGAnalysis_GetHeaderDetails");
            if (dtheader != null)
            {
                if (dtheader.Rows.Count > 0)
                {
                    TxtVoucherNo.Text = dtheader.Rows[0]["VoucherNo"].ToString();
                    TxtYear.Text = dtheader.Rows[0]["VoucherYear"].ToString();
                    TxtVoucherDate.Text = dtheader.Rows[0]["VoucherDate"].ToString();
                    TxtVendor.Text = dtheader.Rows[0]["VendorCode"].ToString();
                    TxtTankerNo.Text = dtheader.Rows[0]["TankerNo"].ToString();
                    TxtGIANo.Text = dtheader.Rows[0]["GIANo"].ToString();
                    TxtInvoiceNo.Text = dtheader.Rows[0]["InvoiceNo"].ToString();
                    TxtAppearance.Text = dtheader.Rows[0]["Apperance"].ToString();
                    TxtAlpha.Text = dtheader.Rows[0]["Alph"].ToString();
                    TxtMoisture.Text = dtheader.Rows[0]["Moisture"].ToString();
                    TxtAcidity.Text = dtheader.Rows[0]["Acidity"].ToString();
                    TxtNM1.Text = dtheader.Rows[0]["NM1"].ToString();
                    TxtNM2.Text = dtheader.Rows[0]["NM2"].ToString();
                    TxtNM3.Text = dtheader.Rows[0]["NM3"].ToString();
                    TxtAldehyde.Text = dtheader.Rows[0]["Aldehyde"].ToString();
                    TxtSpecificGravity.Text = dtheader.Rows[0]["SpecificGravity"].ToString();
                    TxtRemarks.Text = dtheader.Rows[0]["Remarks"].ToString();
                    hidAutoIdHeader.Value = "1";
                    btnSave.ImageUrl = "~/Images/btn_update.png";
                }
            }
            #endregion
        }
        catch (Exception ex)
        {
            logmessage = "PTA Analysis Form- gridMaster_SelectedIndexChanged() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridMaster.PageIndex = e.NewPageIndex;
        bindsearch();
    }
    protected void Gdvlookup_RowCommand(object sender, GridViewCommandEventArgs e)
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

                if (HidPopUpType.Value == "vendor")
                {
                    string vendorcode = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    string vendorname = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                    TxtVendor.Text = vendorcode;
                    Lblvendorname.Text = vendorname;
                }
            }
        }
        catch (Exception ex)
        {
            logmessage = "MEG Analysis Form- Gdvlookup_RowCommand() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void Gdvlookup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gdvlookup.PageIndex = e.NewPageIndex;
        bindvendorlist();
    }
    protected void Gdvlookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}