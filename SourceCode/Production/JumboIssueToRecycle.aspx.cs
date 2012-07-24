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
    Prod_JumboIssueToRecycle_Tran objProd_JumboIssueToRecycle_Tran = new Prod_JumboIssueToRecycle_Tran();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Jumbo Issue To Recycle/Scrap/Wrapping";

            txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);            

            #region Bind Masters

            BindSearchList();

            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Intermediate Table Data

            Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords();

            #endregion  

            txtJumboNo.Attributes.Add("style", "background:lightgray");
            txtIssueDate.Attributes.Add("style", "background:lightgray");
            txtProductionDate.Attributes.Add("style", "background:lightgray");
            //txtOriginalWeight.Attributes.Add("style", "background:lightgray");
            //txtBalanceWeight.Attributes.Add("style", "background:lightgray");
            
            //txtOriginalLength.Attributes.Add("style", "background:lightgray");
            //txtBalanceLength.Attributes.Add("style", "background:lightgray");

            txtJumboNo.Attributes.Add("readonly", "true");
            txtIssueDate.Attributes.Add("readonly", "true");
            txtProductionDate.Attributes.Add("readonly", "true");
            //txtOriginalWeight.Attributes.Add("readonly", "true");
            //txtBalanceWeight.Attributes.Add("readonly", "true");
            
            //txtOriginalLength.Attributes.Add("readonly", "true");
            //txtBalanceLength.Attributes.Add("readonly", "true");                               
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
        Clear();
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
        Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void ImgJumboNo_Click(object sender, ImageClickEventArgs e)
    {
        Get_AllJumboNo("");
        lPopUpHeader.Text = "Jumbo No.";
        lSearch.Text = "Search By Jumbo No.: ";
        ModalPopupExtender2.Show();
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        Get_AllJumboNo(txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
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
                HidJumboId.Value = Convert.ToString(e.CommandArgument);
                txtJumboNo.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                txtProductionDate.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
            }
        }
        catch { }
    }

    protected void gvJumboIssueToRecycleInterm_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gvJumboIssueToRecycleInterm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvJumboIssueToRecycleInterm = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvJumboIssueToRecycleInterm.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvJumboIssueToRecycleInterm.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                ImgJumboNo.Enabled = true;               
                HidJumboIssueId.Value = "";
                HidJumboIssueIntermId.Value = Convert.ToString(e.CommandArgument);
                HidJumboId.Value = gvJumboIssueToRecycleInterm.Rows[gvJumboIssueToRecycleInterm.SelectedIndex].Cells[1].Text;

                #region Fill Whole Form From Selected Intermediate Row

                Get_JumboIssueToRecycle_BothTable(Convert.ToInt32(HidJumboIssueIntermId.Value), "Intermediate");

                #endregion
            }
        }
        catch { }
    }

    protected void gvJumboIssueToRecycleAll_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gvJumboIssueToRecycleAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvJumboIssueToRecycleAll = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvJumboIssueToRecycleAll.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvJumboIssueToRecycleAll.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                ImgJumboNo.Enabled = false;               
                HidJumboIssueId.Value = Convert.ToString(e.CommandArgument);
                HidJumboIssueIntermId.Value = "";
                HidJumboId.Value = gvJumboIssueToRecycleAll.Rows[gvJumboIssueToRecycleAll.SelectedIndex].Cells[1].Text;

                #region Fill Whole Form

                Get_JumboIssueToRecycle_BothTable(Convert.ToInt32(HidJumboIssueId.Value), "Main");

                #endregion
            }
        }
        catch { }
    }

    protected void gvJumboIssueToRecycleAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvJumboIssueToRecycleAll.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        Get_AllJumboNo(txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void gvJumboIssueToRecycleInterm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvJumboIssueToRecycleInterm.PageIndex = e.NewPageIndex;
            Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords();
        }
        catch { }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Update Records Of MainDetailsTab

            if (HidJumboIssueId.Value == "")
            {
                objProd_JumboIssueToRecycle_Tran.AutoID = 0;
            }
            else
            {
                objProd_JumboIssueToRecycle_Tran.AutoID = Convert.ToInt32(HidJumboIssueId.Value);
            }
            if (HidJumboIssueIntermId.Value == "")
            {
                objProd_JumboIssueToRecycle_Tran.IntermediateAutoID = 0;
            }
            else
            {
                objProd_JumboIssueToRecycle_Tran.IntermediateAutoID = Convert.ToInt32(HidJumboIssueIntermId.Value);
            }
            if (HidJumboId.Value != "")
            {
                objProd_JumboIssueToRecycle_Tran.JumboNo = Convert.ToInt32(HidJumboId.Value);
            }
            else
            {
                objProd_JumboIssueToRecycle_Tran.JumboNo = 0;
            }
            if (txtIssueDate.Text.Trim() != "")
            {
                objProd_JumboIssueToRecycle_Tran.Issue_Date = DateTime.ParseExact(txtIssueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_JumboIssueToRecycle_Tran.Issue_Date = "";
            }
            objProd_JumboIssueToRecycle_Tran.Original_Weight_Kg = Convert.ToDouble(txtOriginalWeight.Text.Trim());
            objProd_JumboIssueToRecycle_Tran.Balance_Weight_Kg = Convert.ToDouble(txtBalanceWeight.Text.Trim());
            if (txtProductionDate.Text.Trim() != "")
            {
                objProd_JumboIssueToRecycle_Tran.Production_Date = DateTime.ParseExact(txtProductionDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_JumboIssueToRecycle_Tran.Production_Date = "";
            }
            objProd_JumboIssueToRecycle_Tran.Original_Length_Mtr = Convert.ToDouble(txtOriginalLength.Text.Trim());
            objProd_JumboIssueToRecycle_Tran.Balance_Length_Mtr = Convert.ToDouble(txtBalanceLength.Text.Trim());
            objProd_JumboIssueToRecycle_Tran.Recycle_Length_Mtr = Convert.ToDouble(txtRecycleLength.Text.Trim()); ;
            objProd_JumboIssueToRecycle_Tran.Recycle_Qty_Kg = Convert.ToDouble(txtRecycleQunatity.Text.Trim());
            objProd_JumboIssueToRecycle_Tran.ActiveStatus = true;
            objProd_JumboIssueToRecycle_Tran.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
            objProd_JumboIssueToRecycle_Tran.LastModifiedBy = Convert.ToInt32(Session["UserId"].ToString());


            #endregion

            FlagInsertUpdate = objProd_JumboIssueToRecycle_Tran.InsertAndUpdate_In_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping();
            if (FlagInsertUpdate == "YES")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);

                #region Clear All records after save
                Clear();
                #region Intermediate Table Data

                Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords();

                #endregion

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
            string FormIdProdJumboIssueToRecycle = ConfigurationManager.AppSettings["FormIdProdJumboIssueToRecycle"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProdJumboIssueToRecycle);

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

    private void Clear()
    {
        try
        {
            ImgJumboNo.Enabled = true;           
            HidJumboIssueId.Value  = "";
            HidJumboIssueIntermId.Value="";
            HidJumboId.Value = "";
            txtJumboNo.Text = "";
            txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            txtOriginalWeight.Text = "";
            txtBalanceWeight.Text = "";
            txtProductionDate.Text = "";
            txtOriginalLength.Text = "";
            txtBalanceLength.Text = "";
            txtRecycleLength.Text = "";
            txtRecycleQunatity.Text = "";           

        }
        catch { }
    }

    #endregion    

    private void Get_AllJumboNo(string SearchText)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_JumboIssueToRecycle_Tran.Get_AllJumboNo(SearchText);
            if (dt.Rows.Count > 0)
            {
                gvPopUpGrid.DataSource = dt;
                gvPopUpGrid.AllowPaging = true;
                gvPopUpGrid.DataBind();
                lblTotalRecordsPopUp.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
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
        }
    }

    #region Function to fill Intermediate And Main List Grid

    private void Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_JumboIssueToRecycle_Tran.Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords();
            if (dt.Rows.Count > 0)
            {
                gvJumboIssueToRecycleInterm.DataSource = dt;
                gvJumboIssueToRecycleInterm.AllowPaging = true;
                gvJumboIssueToRecycleInterm.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvJumboIssueToRecycleInterm.AllowPaging = false;
                gvJumboIssueToRecycleInterm.DataSource = "";
                gvJumboIssueToRecycleInterm.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    private void Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_AllRecords(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_JumboIssueToRecycle_Tran.Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_AllRecords(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvJumboIssueToRecycleAll.DataSource = dt;
                gvJumboIssueToRecycleAll.AllowPaging = true;
                gvJumboIssueToRecycleAll.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvJumboIssueToRecycleAll.AllowPaging = false;
                gvJumboIssueToRecycleAll.DataSource = "";
                gvJumboIssueToRecycleAll.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }    

    #endregion

    protected void Get_JumboIssueToRecycle_BothTable(int JumboIssueId, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_JumboIssueToRecycle_Tran.Get_JumboIssueToRecycle_BothTable(JumboIssueId, SearchType);
            if (dt.Rows.Count > 0)
            {
                if (SearchType == "Main")
                {
                    HidJumboIssueId.Value = dt.Rows[0]["AutoId"].ToString();
                }
                else if (SearchType == "Intermediate")
                {
                    HidJumboIssueId.Value = "";
                }
                HidJumboId.Value = dt.Rows[0]["JumboNo"].ToString();
                txtJumboNo.Text = dt.Rows[0]["JumboNoCode"].ToString();
                txtIssueDate.Text = dt.Rows[0]["Issue_Date"].ToString();
                txtOriginalWeight.Text = dt.Rows[0]["Original_Weight_Kg"].ToString();
                txtBalanceWeight.Text = dt.Rows[0]["Balance_Weight_Kg"].ToString();
                txtProductionDate.Text = dt.Rows[0]["Production_Date"].ToString();
                txtOriginalLength.Text = dt.Rows[0]["Original_Length_Mtr"].ToString();
                txtBalanceLength.Text = dt.Rows[0]["Balance_Length_Mtr"].ToString();
                txtRecycleLength.Text = dt.Rows[0]["Recycle_Length_Mtr"].ToString();
                txtRecycleQunatity.Text = dt.Rows[0]["Recycle_Qty_Kg"].ToString();
            }
        }
        catch (Exception ex) { }
    }

    #endregion
    
}