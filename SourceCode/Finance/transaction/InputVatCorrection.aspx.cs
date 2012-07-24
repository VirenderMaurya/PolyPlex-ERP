using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Finance_transaction_InputVatCorrection : System.Web.UI.Page
{
    #region Global 
    BLLCollection<FA_VendorMaster> colvendorlist = new BLLCollection<FA_VendorMaster>();
    FA_VendorMaster objvendor = new FA_VendorMaster();
    string logmessage = "";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        if (!Page.IsPostBack)
        {
            TxtVoucherNo.Attributes.Add("readonly", "true");
        } 
    }
    protected void BtnAdd_VatDetails_Click(object sender, EventArgs e)
    {

    }
    protected void ImgBtnCode_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            BindVendorList();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Vat Input Correction Form- Search Vendor By Keyword(ImgBtnCode_Click) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string DataKey = GdvVendorList.SelectedDataKey.Value.ToString();
            TxtVendorCode.Text = DataKey;
            int index = GdvVendorList.SelectedIndex;
            TxtVendorName.Text = ((Label)(GdvVendorList.Rows[index].FindControl("lblvendorname"))).Text.ToString();
        }
        catch (Exception ex)
        {
            logmessage = "Input Vat Correction Form- Select event for vendor id and name(gridMaster_SelectedIndexChanged) -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void GdvVendorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvVendorList.PageIndex = e.NewPageIndex;
            BindVendorList();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            logmessage = "Input Vat Correction Form- GdvVendorList_PageIndexChanging -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    private void BindVendorList()
    {
        try
        {
            string Vendorcode = TxtVendorCode.Text;
            if (Vendorcode == "")
            {
                Vendorcode = "0";
            }
            colvendorlist = objvendor.GetVendorList_ByVendorCode(Vendorcode);
            GdvVendorList.DataSource = colvendorlist;
            GdvVendorList.DataBind();
        }
        catch (Exception ex)
        {
            logmessage = "Input Vat Correction Form- BindVendorList() -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        clearfields();
    }
    private void clearfields()
    {
        TxtBaseAmount.Text = "";
        TxtTaxAmount.Text = "";
        TxtTaxInvoice.Text = "";
        TxtTaxInvoiceDate.Text = "";
        TxtVendorCode.Text = "";
        TxtVendorName.Text = "";
    }
}