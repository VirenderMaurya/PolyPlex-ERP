using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Production_RollIssueToRecycle : System.Web.UI.Page
{
    #region***************************************Variables***************************************

    Common_mst objCommon_mst = new Common_mst();
    Common_Message objcommonmessage = new Common_Message();
    Prod_RollIssueToRecycle_Tran objProd_RollIssueToRecycle_Tran = new Prod_RollIssueToRecycle_Tran();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();
    Prod_RollSlitting objprodrollslitting = new Prod_RollSlitting();
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Roll Issue To Recycle/Scrap/Wrapping";
            txtIssueDate.Attributes.Add("readonly", "true");
            txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

            #region Bind Masters
            BindSearchList();
            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Fill Intermediate Grid
            Get_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords();
            #endregion

            txtBatchNo.Attributes.Add("style", "background:lightgray");
            txtIssueDate.Attributes.Add("style", "background:lightgray");
            txtOriginalWeight.Attributes.Add("style", "background:lightgray");
            txtBalanceWeight.Attributes.Add("style", "background:lightgray");
            txtProductionDate.Attributes.Add("style", "background:lightgray");
            txtOriginalLength.Attributes.Add("style", "background:lightgray");
            txtBalanceLength.Attributes.Add("style", "background:lightgray");

            txtBatchNo.Attributes.Add("readonly", "true");
            txtIssueDate.Attributes.Add("readonly", "true");
            txtOriginalWeight.Attributes.Add("readonly", "true");
            txtBalanceWeight.Attributes.Add("readonly", "true");
            txtProductionDate.Attributes.Add("readonly", "true");
            txtOriginalLength.Attributes.Add("readonly", "true");
            txtBalanceLength.Attributes.Add("readonly", "true");
                       
        }

        ImageButton btnAdd = (ImageButton)Master.FindControl("btnAdd");
        btnAdd.CausesValidation = false;
        btnAdd.Click += new ImageClickEventHandler(btnAdd_Click);

        ImageButton imgbtnSearch = (ImageButton)Master.FindControl("imgbtnSearch");
        imgbtnSearch.CausesValidation = false;
        imgbtnSearch.Click += new ImageClickEventHandler(imgbtnSearch_Click);
    }

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
          //  string FormIdProdJumboIssueToRecycle = ConfigurationManager.AppSettings["FormIdProdJumboIssueToRecycle"].ToString();
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria("188");
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
           // HidJumboIssueId.Value = "";
           // HidJumboIssueIntermId.Value = "";
            HidJumboId.Value = "";
            txtBatchNo.Text = "";
            txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            txtOriginalWeight.Text = "";
            txtBalanceWeight.Text = "";
            txtProductionDate.Text = "";
            txtOriginalLength.Text = "";
            txtBalanceLength.Text = "";
            txtIssueLength.Text = "";
            txtIssueQunatity.Text = "";

        }
        catch { }
    }

    #endregion

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
            Get_AllBatchNo(txtSearch.Text);
            //Get_Prod_Glb_PetJumbo_MainTable_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender2.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }
    #endregion


    #region Function to fill Intermediate List Grid
    private void Get_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_RollIssueToRecycle_Tran.Get_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords();
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

    #endregion
    protected void ImgJumboNo_Click(object sender, ImageClickEventArgs e)
    {
        Get_AllBatchNo("");
        lPopUpHeader.Text = "Batch No.";
        lSearch.Text = "Search By Batch No.: ";
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
                txtBatchNo.Text = row.Cells[1].Text;
                DataTable dt = objprodrollslitting.Roll_Slitting_Secondary(HidJumboId.Value);
                txtOriginalLength.Text = dt.Rows[0]["Orginal Length"].ToString();
                txtOriginalWeight.Text = dt.Rows[0]["Orginal Weight"].ToString();
                txtBalanceLength.Text = dt.Rows[0]["Balance Length"].ToString();
                txtBalanceWeight.Text = dt.Rows[0]["Balance Weight"].ToString();
                txtProductionDate.Text = dt.Rows[0]["Prodution Date"].ToString();

            }
        }
        catch { }
    }

    private void Get_AllBatchNo(string SearchText)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objprodrollslitting.GetAllBatchNo(SearchText);
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

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        Get_AllBatchNo(txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }
  
    protected void ImgSave_Click1(object sender, ImageClickEventArgs e)
    {
        if (txtBatchNo.Text != "")
        {
            try
            {
                #region Insert/Update Records Of MainDetailsTab

                if (HidJumboIssueId.Value == "")
                {
                    objProd_RollIssueToRecycle_Tran.AutoID = 0;
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.AutoID = Convert.ToInt32(HidJumboIssueId.Value);
                }
                if (HidJumboIssueIntermId.Value == "")
                {
                    objProd_RollIssueToRecycle_Tran.IntermediateAutoID = 0;
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.IntermediateAutoID = Convert.ToInt32(HidJumboIssueIntermId.Value);
                }

                objProd_RollIssueToRecycle_Tran.BatchNo = Convert.ToInt32(HidJumboId.Value);
                if (txtIssueDate.Text.Trim() != "")
                {
                    objProd_RollIssueToRecycle_Tran.Issue_Date = DateTime.ParseExact(txtIssueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.Issue_Date = "";
                }
                if (txtOriginalWeight.Text.Trim() == "")
                {
                    objProd_RollIssueToRecycle_Tran.Original_Weight_Kg = 0.0;
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.Original_Weight_Kg = Convert.ToDouble(txtOriginalWeight.Text.Trim());
                }
                if (txtBalanceWeight.Text.Trim() == "")
                {
                    objProd_RollIssueToRecycle_Tran.Balance_Weight_Kg = 0.0;
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.Balance_Weight_Kg = Convert.ToDouble(txtBalanceWeight.Text.Trim());
                }
                if (txtProductionDate.Text.Trim() != "")
                {
                    objProd_RollIssueToRecycle_Tran.Production_Date = DateTime.ParseExact(txtProductionDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.Production_Date = "";
                }
                if (txtOriginalLength.Text.Trim() == "")
                {
                    objProd_RollIssueToRecycle_Tran.Original_Length_Mtr = 0.0;
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.Original_Length_Mtr = Convert.ToDouble(txtOriginalLength.Text.Trim());
                }
                if (txtBalanceLength.Text.Trim() == "")
                {
                    objProd_RollIssueToRecycle_Tran.Balance_Length_Mtr = 0.0;
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.Balance_Length_Mtr = Convert.ToDouble(txtBalanceLength.Text.Trim());
                }
                if (txtIssueLength.Text.Trim() == "")
                {
                    objProd_RollIssueToRecycle_Tran.Issue_Length_Mtr = 0.0;
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.Issue_Length_Mtr = Convert.ToDouble(txtIssueLength.Text.Trim());
                }
                if (txtIssueQunatity.Text.Trim() == "")
                {
                    objProd_RollIssueToRecycle_Tran.Issue_Qty_Kg = 0.0;
                }
                else
                {
                    objProd_RollIssueToRecycle_Tran.Issue_Qty_Kg = Convert.ToDouble(txtIssueQunatity.Text.Trim());
                }
                objProd_RollIssueToRecycle_Tran.ActiveStatus = true;
                objProd_RollIssueToRecycle_Tran.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objProd_RollIssueToRecycle_Tran.LastModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                #endregion
                FlagInsertUpdate = objProd_RollIssueToRecycle_Tran.InsertAndUpdate_InProd_Roll_Issue_To_Recycle_Scrap_Wrapping();
                if (FlagInsertUpdate == "YES")
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                    #region Clear All records after save
                    Clear();
                    #region update table set record false
                    if (ViewState["AutoId"].ToString() != null)
                    {
                        objProd_RollIssueToRecycle_Tran.Update_Intermediatetable_ByAutoId(ViewState["AutoId"].ToString());
                    }
                    #endregion
                    #region Intermediate Table Data
                    Get_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords();
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
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info,"Please select Batch No", 125, 300);
        }
    }
    protected void gvJumboIssueToRecycleInterm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "sel")
        {
            string id = e.CommandArgument.ToString();
            //get data from Intermediate table
            DataTable dt = objProd_RollIssueToRecycle_Tran.Get_AllDATAFrom_Intermediatetable_ByAutoId(id);
            txtBatchNo.Text = dt.Rows[0]["BatchNo"].ToString();
            HidJumboId.Value = txtBatchNo.Text;
            ViewState["AutoId"] = dt.Rows[0]["AutoId"].ToString();
            txtOriginalWeight.Text = dt.Rows[0]["Original_Weight_Kg"].ToString();
            txtOriginalLength.Text = dt.Rows[0]["Original_Length_Mtr"].ToString();
            txtBalanceLength.Text = dt.Rows[0]["Balance_Length_Mtr"].ToString();
            txtBalanceWeight.Text = dt.Rows[0]["Balance_Weight_Kg"].ToString();
            txtProductionDate.Text = dt.Rows[0]["Production_Date"].ToString();
            txtIssueLength.Text = dt.Rows[0]["Issue_Length_Mtr"].ToString();
            txtIssueQunatity.Text =dt.Rows[0]["Issue_Qty_Kg"].ToString();
        }
    }
    
            
}