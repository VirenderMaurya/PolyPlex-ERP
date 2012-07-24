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
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();
    Proc_GRTaxInvoiceUpdation objProc_GRTaxInvoiceUpdation = new Proc_GRTaxInvoiceUpdation();
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblInfo.Text = "";
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "GR Tax Invoice Updation";

            #region Bind Masters

            BindSearchList();           

            #endregion                     

            txtGRYear.Attributes.Add("readonly", "true");
            txtGRNo.Attributes.Add("readonly", "true");
            txtGRDate.Attributes.Add("readonly", "true");
            txtTaxInvoiceNo.Attributes.Add("readonly", "true");
            txtTaxInvoiceDate.Attributes.Add("readonly", "true");
            txtDueDate.Attributes.Add("readonly", "true");

            txtGRYear.Attributes.Add("style", "background:lightgray");            
            txtGRNo.Attributes.Add("style", "background:lightgray");
            txtGRDate.Attributes.Add("style", "background:lightgray");
            txtTaxInvoiceNo.Attributes.Add("style", "background:lightgray");
            txtTaxInvoiceDate.Attributes.Add("style", "background:lightgray");
            txtDueDate.Attributes.Add("style", "background:lightgray");
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
        ClearForm();
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindAllTaxInvoiceUpdatedList(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllTaxInvoiceUpdatedList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void imgGRNo_Click(object sender, ImageClickEventArgs e)
    {
        FillAllGRNo("");
        lPopUpHeader.Text = "GR No";
        lSearch.Text = "Search By GR No: ";
        ModalPopupExtender2.Show();
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        FillAllGRNo(txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
            }
        }
        catch { }
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

                HidGrNo.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                txtGRNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text;
                txtTaxInvoiceNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[7].Text;
                txtGRDate.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                txtGRYear.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
            }
        }
        catch { }
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        FillAllGRNo(txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void gvGRTaxInvUpdateList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        lblInfo.Text = "";

        GridView gvGRTaxInvUpdateList = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvGRTaxInvUpdateList.SelectedIndex = row.RowIndex;

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvGRTaxInvUpdateList.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            HidGrNo.Value = Convert.ToString(e.CommandArgument);

            #region Bind Form

            txtGRNo.Text = gvGRTaxInvUpdateList.Rows[gvGRTaxInvUpdateList.SelectedIndex].Cells[2].Text;
            txtGRYear.Text = gvGRTaxInvUpdateList.Rows[gvGRTaxInvUpdateList.SelectedIndex].Cells[1].Text;
            txtGRDate.Text = gvGRTaxInvUpdateList.Rows[gvGRTaxInvUpdateList.SelectedIndex].Cells[3].Text;
            txtTaxInvoiceNo.Text = gvGRTaxInvUpdateList.Rows[gvGRTaxInvUpdateList.SelectedIndex].Cells[6].Text;
            txtTaxInvoiceDate.Text = gvGRTaxInvUpdateList.Rows[gvGRTaxInvUpdateList.SelectedIndex].Cells[7].Text;
            txtDueDate.Text = gvGRTaxInvUpdateList.Rows[gvGRTaxInvUpdateList.SelectedIndex].Cells[8].Text;

            #endregion
        }
    }

    protected void gvGRTaxInvUpdateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGRTaxInvUpdateList.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllTaxInvoiceUpdatedList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Update Record Of GR Tax Invoice

            objProc_GRTaxInvoiceUpdation.AutoId = Convert.ToInt32(HidGrNo.Value);
            objProc_GRTaxInvoiceUpdation.TaxInvoiceDate = DateTime.ParseExact(txtTaxInvoiceDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            objProc_GRTaxInvoiceUpdation.DueDate = DateTime.ParseExact(txtDueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();

            FlagInsertUpdate = objProc_GRTaxInvoiceUpdation.Update_In_Proc_GoodsReceiptByTaxInvoiceUpdation();
            if (FlagInsertUpdate == "0")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);

                #region Clear All records after save
                ClearForm();
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

            #endregion
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
        }
    }

    #endregion

    #region***************************************Functions***************************************

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdProcGRTaxInvoiceUpdate = ConfigurationManager.AppSettings["FormIdProcGRTaxInvoiceUpdate"].ToString();
            
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProcGRTaxInvoiceUpdate);

            ddlSearch.DataTextField = "Options"; 
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();
                ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));               
            }            
        }
        catch (Exception ex) { }
    }   

    private void ClearForm()
    {
        try
        {            
            HidGrNo.Value = "";
            txtGRNo.Text = "";
            txtGRYear.Text = "";
            txtGRDate.Text = "";
            txtTaxInvoiceNo.Text = "";
            txtTaxInvoiceDate.Text = "";
            txtDueDate.Text = "";

        }
        catch { }
    }

    private void FillAllGRNo(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_GRTaxInvoiceUpdation.FillAllGRNo(Searchtext);

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

    private void BindAllTaxInvoiceUpdatedList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_GRTaxInvoiceUpdation.BindAllTaxInvoiceUpdatedList(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvGRTaxInvUpdateList.DataSource = dt;
                gvGRTaxInvUpdateList.AllowPaging = true;
                gvGRTaxInvUpdateList.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvGRTaxInvUpdateList.AllowPaging = false;
                gvGRTaxInvUpdateList.DataSource = "";
                gvGRTaxInvUpdateList.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion    
}