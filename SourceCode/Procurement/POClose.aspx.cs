using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_POClose : System.Web.UI.Page
{
    ProcReleasePO cs = new ProcReleasePO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {


                DataTable dt = cs.getDetailData(0);
                gridPOLine.DataSource = dt;
                gridPOLine.DataBind();



            }
            catch { }
        }
        Label lblHeader = (Label)Master.FindControl("lbl_PageHeader");
        lblHeader.Text = "Purchase Order Release";

    }
    protected void img_Customer_lookup_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = cs.posearch();
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
        }
    }
    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int DataKey = int.Parse(gridMaster.SelectedDataKey["Autoid"].ToString());
            hf_POID.Value = DataKey.ToString();
            txtPO.Text = gridMaster.SelectedDataKey["PONumber"].ToString();
            txtPODate.Text = DateTime.Parse(gridMaster.SelectedDataKey["PODate"].ToString()).ToShortDateString();
            lblVendorName.Text = gridMaster.SelectedDataKey["VendorName"].ToString();
            

            DataTable dt = cs.getDetailData(DataKey);
            gridPOLine.DataSource = dt;
            gridPOLine.DataBind();
        }
        catch { }


    }

    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridMaster.PageIndex = e.NewPageIndex;

        DataTable dt = cs.posearch();
        gridMaster.DataSource = dt;
        gridMaster.DataBind();
        ModalPopupExtender1.Show();

    }





    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (cs.UpdateRelese(int.Parse(hf_POID.Value), true, Session["UserID"].ToString()))
            {
              
                    string message = "Purchase Order closed.";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
               
            }
        }
        catch { }

    }
}