using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_PTAAnalysis : System.Web.UI.Page
{
    #region Define Global variable here
    string logmessage = "";
    Common_Message commessage = new Common_Message();
    Common com = new Common();
    Proc_ChipsQuality_PTAAnalysis objptaanalysis = new Proc_ChipsQuality_PTAAnalysis();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindSearchDropDown("238");
                Log.GetLog().FillFinancialYear(TxtYear);
                Readonlycontrols();
                Log.PageHeading(this, "Chips Quality-PTA Analysis Form");
            }
            BindMasterSearchBox();
        }
        catch (Exception ex)
        {
            logmessage = "PTA Analysis Form- Page_Load() -Error-" + ex.ToString();
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
            logmessage = "Chips Quality-PTAAnalysis Form- BindSearchDropDown Method -Error-" + ex.ToString();
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
        bindsearch();
    }
    private void bindsearch()
    {
        try
        {
            HidPopUpType.Value = "";
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
                    dt = objptaanalysis.SearchPTA("VoucherNo", txtSearch.Text);
                }
                if (ddsearch.SelectedItem.Value == "VendorCode")
                {
                    lSearchList.Text = "Search By Vendor Code";
                    dt = objptaanalysis.SearchPTA("VendorCode", txtSearch.Text);
                }
                if (ddsearch.SelectedItem.Value == "VendorName")
                {
                    lSearchList.Text = "Search By Vendor Name";
                    dt = objptaanalysis.SearchPTA("VendorName", txtSearch.Text);
                }
                gridMaster.Visible = true;
                Gdvlookup.Visible = false;
                gridMaster.DataSource = dt;
                gridMaster.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            logmessage = "PTA Analysis Form- btn_search_Click() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
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
            logmessage = "PTA Analysis Form- btn_add_Click() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void Readonlycontrols()
    {
        TxtYear.Attributes.Add("readonly", "true");
        TxtVoucherNo.Attributes.Add("readonly", "true");
        TxtVendor.Attributes.Add("readonly", "true");
        TxtVoucherDate.Attributes.Add("readonly", "true");
    }
    protected void ImgBtnVendor_Click(object sender, ImageClickEventArgs e)
    {
        lSearchList.Text = "Search By Vendor Code/Name";
        bindvendorlist();
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
            logmessage = "PTA Analysis Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Update record
            if (btnSave.ImageUrl == "~/Images/btn_update.png")
            {
             #region update headeritem only

                if (objptaanalysis.updateheader(TxtVoucherNo.Text,TxtYear.Text,TxtVoucherDate.Text,TxtVendor.Text,TxtTruckNo.Text,TxtGIANo.Text,TxtInvoiceNo.Text,
                    TxtBagLotNo.Text,TxtAppearance.Text,TxtParticlelSize.Text,TxtSolubilityinAmmonia.Text,TxtAlpha.Text,
                    TxtAsh.Text,TxtAcid.Text,TxtMoisture.Text,TxtRemarks.Text,Session["userId"].ToString()))
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
               saved = objptaanalysis.saveRecords(TxtYear.Text, TxtVoucherDate.Text, TxtVendor.Text, TxtTruckNo.Text, TxtGIANo.Text,
                   TxtInvoiceNo.Text, TxtBagLotNo.Text, TxtAppearance.Text, TxtParticlelSize.Text, TxtSolubilityinAmmonia.Text,
                   TxtAlpha.Text, TxtAsh.Text, TxtAcid.Text, TxtMoisture.Text, TxtRemarks.Text, Session["userId"].ToString());
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
            logmessage = "PTA Analysis Form- btnSave_Click() i-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void cleardetails()
    {
        Lblvendorname.Text = "";
        TxtVoucherNo.Text = "";
        TxtAcid.Text = "";
        TxtAlpha.Text = "";
        TxtAppearance.Text = "";
        TxtAsh.Text = "";
        TxtBagLotNo.Text = "";
        TxtGIANo.Text = "";
        TxtInvoiceNo.Text = "";
        TxtMoisture.Text = "";
        TxtParticlelSize.Text = "";
        TxtParticlelSize.Text = "";
        TxtRemarks.Text = "";
        TxtSolubilityinAmmonia.Text = "";
        TxtTruckNo.Text = "";
        TxtVendor.Text = "";
        TxtVoucherDate.Text = "";
     }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        DataTable dt = null;
        if (ddlSearch.SelectedValue.ToString() == "VoucherNo")
        {
            gridMaster.Visible = true;
            Gdvlookup.Visible = false;
            dt = objptaanalysis.SearchPTA("VoucherNo", txtSearchList.Text);
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
        }
        if (ddlSearch.SelectedValue.ToString() == "VendorCode")
        {
            gridMaster.Visible = true;
            Gdvlookup.Visible = false;
            dt = objptaanalysis.SearchPTA("VendorCode", txtSearchList.Text);
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
        }
        if (ddlSearch.SelectedValue.ToString() == "VendorName")
        {
            gridMaster.Visible = true;
            Gdvlookup.Visible = false;
            dt = objptaanalysis.SearchPTA("VendorName", txtSearchList.Text);
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
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string id = gridMaster.SelectedDataKey.Value.ToString();
            #region clear controls
            cleardetails();
            #endregion
            #region BindHeaderdetails
            DataTable dtheader = com.GetVal("@Id", id, "Sp_Proc_PTAAnalysis_GetHeaderDetails");
            if (dtheader != null)
            {
                if (dtheader.Rows.Count > 0)
                {
                    TxtVoucherNo.Text = dtheader.Rows[0]["VoucherNo"].ToString();
                    TxtYear.Text = dtheader.Rows[0]["VoucherYear"].ToString();
                    TxtVoucherDate.Text=dtheader.Rows[0]["VoucherDate"].ToString();
                    TxtVendor.Text = dtheader.Rows[0]["VendorCode"].ToString();
                    TxtTruckNo.Text = dtheader.Rows[0]["TruckNo"].ToString();
                    TxtGIANo.Text = dtheader.Rows[0]["GIANo"].ToString();
                    TxtInvoiceNo.Text = dtheader.Rows[0]["InvoiceNo"].ToString();
                    TxtBagLotNo.Text = dtheader.Rows[0]["BagLotNo"].ToString();
                    TxtAppearance.Text = dtheader.Rows[0]["Apperance"].ToString();
                    TxtParticlelSize.Text = dtheader.Rows[0]["ParticleSize"].ToString();
                    TxtSolubilityinAmmonia.Text = dtheader.Rows[0]["Solubility"].ToString();
                    TxtAlpha.Text = dtheader.Rows[0]["Alph"].ToString();
                    TxtAsh.Text = dtheader.Rows[0]["Ash"].ToString();
                    TxtAcid.Text = dtheader.Rows[0]["Acid No"].ToString();
                    TxtMoisture.Text = dtheader.Rows[0]["Moisture"].ToString();
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
            logmessage = "PTA Analysis Form- Gdvlookup_RowCommand() -Error-" + ex.ToString();
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

    private void bindvendorlist()
    {
        try
        {
            HidPopUpType.Value = "vendor";
            Gdvlookup.Visible = true;
            gridMaster.Visible = false;
            BindVendorList("");
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "PTA Analysis Form- ImgBtnVendor_Click() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
}