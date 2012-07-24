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
    Proc_IssueModification objProc_IssueModification = new Proc_IssueModification();
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblInfo.Text = "";
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Issue Modification";
            txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

            TDIssueNo.Attributes.Add("style", "display:none");
            TDtxtIssueNo.Attributes.Add("style", "display:none");
            int PalletNo = RandomNumber(100000000, 999999999);
            txtBatch.Text = Convert.ToString(PalletNo);

            #region Bind Masters

            BindSearchList();
            FillFinancialYear();
            Get_All_Prod_StorageLocation_Mst();

            #endregion            

            #region Get Line Item Grid Structure

            GetProc_IssueModification_LineItems_Trans(0);

            #endregion

            #region Blank Grid

            gvIssueModification.DataSource = "";
            gvIssueModification.DataBind(); 

            #endregion

            #region Readonly Fields

            txtIssueYear.Attributes.Add("readonly", "true");
            txtIssueNo.Attributes.Add("readonly", "true");
            txtIssueDate.Attributes.Add("readonly", "true");
            txtCostCenter.Attributes.Add("readonly", "true");
            txtBatch.Attributes.Add("readonly", "true");
            txtMaterial.Attributes.Add("readonly", "true");
            txtStockQuantity.Attributes.Add("readonly", "true");
            txtValuationType.Attributes.Add("readonly", "true");
            txtPlant.Attributes.Add("readonly", "true");
            txtPurpose.Attributes.Add("readonly", "true");
            txtProject.Attributes.Add("readonly", "true");
            txtSubProject.Attributes.Add("readonly", "true");
            txtValue.Attributes.Add("readonly", "true");

            #endregion

            #region Color Changed Controls

            txtIssueDate.Attributes.Add("style", "background:lightgray");
            txtIssueYear.Attributes.Add("style", "background:lightgray");
            txtIssueNo.Attributes.Add("style", "background:lightgray");            
            txtCostCenter.Attributes.Add("style", "background:lightgray");
            txtBatch.Attributes.Add("style", "background:lightgray");
            txtMaterial.Attributes.Add("style", "background:lightgray");
            txtStockQuantity.Attributes.Add("style", "background:lightgray");
            txtValuationType.Attributes.Add("style", "background:lightgray");
            txtPlant.Attributes.Add("style", "background:lightgray");
            txtPurpose.Attributes.Add("style", "background:lightgray");
            txtProject.Attributes.Add("style", "background:lightgray");
            txtSubProject.Attributes.Add("style", "background:lightgray");
            txtValue.Attributes.Add("style", "background:lightgray");

            #endregion
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
        ClearHeaderItems();
        ClearLineItems();
        HidLineNo.Value = "10";
        ViewState["LineItem"] = null;
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchList.Text = "";
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindAllIssueModificationList(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
        BindAllIssueModificationList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void imgMaterial_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "Material";
        lPopUpHeader.Text = "Material Master";
        lSearch.Text = "Search By Material Code/Name: ";
        FillAllMaterial("");
        ModalPopupExtender2.Show();
    }

    protected void imgBtnValuationType_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "ValuationType";
        lPopUpHeader.Text = "Valuation Type Master";
        lSearch.Text = "Search By Valuation Type: ";
        FillAllValuationTypeMaster("");
        ModalPopupExtender2.Show();
    }

    protected void imgCostCenter_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "CostCenter";
        lPopUpHeader.Text = "Cost Center Master";
        lSearch.Text = "Search By Code/Name: ";
        FillAllCostCenterMaster("");
        ModalPopupExtender2.Show();
    }

    protected void imgPlant_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "Plant";
        lPopUpHeader.Text = "Plant Master";
        lSearch.Text = "Search By Code/Name: ";
        FillAllPlantMaster("");
        ModalPopupExtender2.Show();
    }

    protected void imgPurpose_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "Purpose";
        lPopUpHeader.Text = "Purpose Master";
        lSearch.Text = "Search By Code/Name: ";
        FillAllPurposeMaster("");
        ModalPopupExtender2.Show();
    }

    protected void imgProject_Click(object sender, ImageClickEventArgs e)
    {
        txtSearchFromPopup.Text = "";
        HidPopUpType.Value = "Project";
        lPopUpHeader.Text = "Project Master";
        lSearch.Text = "Search By Code/Name: ";
        FillAllProjectMaster("");
        ModalPopupExtender2.Show();
    }

    protected void imgSubProject_Click(object sender, ImageClickEventArgs e)
    {
        if (HidProjectId.Value != "")
        {
            HidPopUpType.Value = "SubProject";
            lPopUpHeader.Text = "Sub Project Master";
            lSearch.Text = "Search By Code/Name: ";
            FillAllSubProjectMaster("", Convert.ToInt32(HidProjectId.Value));
            ModalPopupExtender2.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectProject, 125, 300);
        }
    }

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {
        if (HidPopUpType.Value == "Material")
        {
            FillAllMaterial(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "ValuationType")
        {
            FillAllValuationTypeMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "CostCenter")
        {
            FillAllCostCenterMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "Plant")
        {
            FillAllPlantMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "Purpose")
        {
            FillAllPurposeMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "Project")
        {
            FillAllProjectMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "SubProject")
        {
            if (HidProjectId.Value != "")
            {
                FillAllSubProjectMaster(txtSearchFromPopup.Text.Trim(), Convert.ToInt32(HidProjectId.Value));
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectProject, 125, 300);
            }
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void gvPopUpGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                if (HidPopUpType.Value == "Material")
                {
                    e.Row.Cells[4].Style.Add("display", "none");
                }
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

                if (HidPopUpType.Value == "Material")
                {
                    HidMaterialId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtMaterial.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text + " (" + gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text + ")";
                    HidUOMId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[4].Text;
                    HidUOMName.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[5].Text;
                }
                else if (HidPopUpType.Value == "ValuationType")
                {
                    HidValuationTypeId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtValuationType.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text;
                }
                else if (HidPopUpType.Value == "CostCenter")
                {
                    HidCostCenter.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtCostCenter.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text + " (" + gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text + ")";
                }
                else if (HidPopUpType.Value == "Plant")
                {
                    HidPlantId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtPlant.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text + " (" + gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text + ")";
                }
                else if (HidPopUpType.Value == "Purpose")
                {
                    HidPurpose.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtPurpose.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text + " (" + gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text + ")";
                }
                else if (HidPopUpType.Value == "Project")
                {
                    HidProjectId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtProject.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text + " (" + gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text + ")";
                    HidSubProjectId.Value = "";
                    txtSubProject.Text = "";
                }
                else if (HidPopUpType.Value == "SubProject")
                {
                    HidSubProjectId.Value = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[1].Text;
                    txtSubProject.Text = gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[3].Text + " (" + gvPopUpGrid.Rows[gvPopUpGrid.SelectedIndex].Cells[2].Text + ")";
                }
            }
        }
        catch { }
    }

    protected void gvPopUpGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPopUpGrid.PageIndex = e.NewPageIndex;
        if (HidPopUpType.Value == "Material")
        {
            FillAllMaterial(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "ValuationType")
        {
            FillAllValuationTypeMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "CostCenter")
        {
            FillAllCostCenterMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "Plant")
        {
            FillAllPlantMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "Purpose")
        {
            FillAllPurposeMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "Project")
        {
            FillAllProjectMaster(txtSearchFromPopup.Text.Trim());
        }
        else if (HidPopUpType.Value == "SubProject")
        {
            FillAllSubProjectMaster(txtSearchFromPopup.Text.Trim(), Convert.ToInt32(HidProjectId.Value));
        }
        txtSearchFromPopup.Focus();
        ModalPopupExtender2.Show();
    }

    protected void gvIssueModification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
                e.Row.Cells[17].Style.Add("display", "none");
                e.Row.Cells[18].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvIssueModification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvIssueModification = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvIssueModification.SelectedIndex = row.RowIndex + 1;

        DataTable objdtLineItem = new DataTable();
        objdtLineItem = (DataTable)ViewState["LineItem"];

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvIssueModification.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            if (objdtLineItem.Rows.Count > 0)
            {
                hidRowIndex.Value = Convert.ToString(row.RowIndex);
                hidLineItemId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["AutoId"].ToString();
                HidUpdateGridRecord.Value = "Yes";

                HidMaterialId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialId"].ToString();
                txtMaterial.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialName"].ToString();
                HidPlantId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PlantID"].ToString();
                txtPlant.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PlantName"].ToString();
                ddlStorageLocation.SelectedValue = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["StorageLocationId"].ToString();
                HidValuationTypeId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ValuationTypeId"].ToString();
                txtValuationType.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ValuationType"].ToString();
                HidProjectId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ProjectId"].ToString();
                txtProject.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ProjectName"].ToString();
                HidSubProjectId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubProjectId"].ToString();
                txtSubProject.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubProject"].ToString();
                HidPurpose.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PurposeId"].ToString();
                txtPurpose.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Purpose"].ToString();
                txtQuantity.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Quantity"].ToString();
                txtValue.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Value"].ToString();
                //txtStockQuantity.Text = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)][""].ToString(); 
                txtStockQuantity.Text = "0";
                HidUOMId.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["UOMId"].ToString();
                HidUOMName.Value = objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["UOM"].ToString();
                ImgBtnAddLine.ImageUrl = "../Images/btnUpdateLine.png";
            }
        }
    }

    protected void gvIssueModificationList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblInfo.Text = "";

        GridView gvIssueModificationList = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        gvIssueModificationList.SelectedIndex = row.RowIndex;

        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gvIssueModificationList.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
            }
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";

            HidAutoId.Value = Convert.ToString(e.CommandArgument);

            #region Bind Form

            Get_Proc_IssueModification_Header_Trans(Convert.ToInt32(HidAutoId.Value));
            GetProc_IssueModification_LineItems_Trans(Convert.ToInt32(HidAutoId.Value));
            #endregion

            TDIssueNo.Attributes.Add("style", "display:block");
            TDtxtIssueNo.Attributes.Add("style", "display:block");
        }
    }

    protected void gvIssueModificationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvIssueModificationList.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllIssueModificationList(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void ImgBtnAddLine_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable objdtLineItem = new DataTable();
            objdtLineItem = (DataTable)ViewState["LineItem"];

            if (HidUpdateGridRecord.Value == "") //For Insert new record
            {
                DataRow objdrLineItem = objdtLineItem.NewRow();
                objdrLineItem["AutoId"] = 0;
                objdrLineItem["IsUpdate"] = "";
                if (HidAutoId.Value != "")
                {
                    objdrLineItem["IssueModificationId"] = Convert.ToInt32(HidAutoId.Value);
                }
                else
                {
                    objdrLineItem["IssueModificationId"] = 0;
                }
                objdrLineItem["LineNo"] = Convert.ToInt32(HidLineNo.Value);
                objdrLineItem["BatchNo"] = txtBatch.Text.Trim();
                objdrLineItem["MaterialId"] = Convert.ToInt32(HidMaterialId.Value);
                objdrLineItem["MaterialName"] = txtMaterial.Text.Trim();
                objdrLineItem["UOMId"] = Convert.ToInt32(HidUOMId.Value);
                objdrLineItem["UOM"] = HidUOMName.Value;
                objdrLineItem["PlantID"] = Convert.ToInt32(HidPlantId.Value);
                objdrLineItem["PlantName"] = txtPlant.Text.Trim();
                objdrLineItem["StorageLocationId"] = Convert.ToInt32(ddlStorageLocation.SelectedValue);
                objdrLineItem["StorageLocation"] = ddlStorageLocation.SelectedItem.Text.Trim();
                objdrLineItem["ValuationTypeId"] = Convert.ToInt32(HidValuationTypeId.Value);
                objdrLineItem["ValuationType"] = txtValuationType.Text.Trim();
                objdrLineItem["ProjectId"] = Convert.ToInt32(HidProjectId.Value);
                objdrLineItem["ProjectName"] = txtProject.Text.Trim();
                objdrLineItem["SubProjectId"] = Convert.ToInt32(HidSubProjectId.Value);
                objdrLineItem["SubProject"] = txtSubProject.Text.Trim();
                if (HidPurpose.Value != "")
                {
                    objdrLineItem["PurposeId"] = Convert.ToInt32(HidPurpose.Value);
                    objdrLineItem["Purpose"] = txtPurpose.Text.Trim();
                }
                else
                {
                    objdrLineItem["PurposeId"] = 0;
                    objdrLineItem["Purpose"] = "";
                }

                if (txtQuantity.Text != "")
                {
                    objdrLineItem["Quantity"] = Convert.ToDouble(txtQuantity.Text.Trim());
                }
                else
                {
                    objdrLineItem["Quantity"] = 0;
                }
                if (txtValue.Text != "")
                {
                    objdrLineItem["Value"] = Convert.ToDouble(txtValue.Text.Trim());
                }
                else
                {
                    objdrLineItem["Value"] = 0;
                }
                objdrLineItem["ActiveStatus"] = true;
                objdtLineItem.Rows.Add(objdrLineItem);
            }
            else if (HidUpdateGridRecord.Value == "Yes") //For Update record
            {
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["IsUpdate"] = "Yes";
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialId"] = Convert.ToInt32(HidMaterialId.Value);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["MaterialName"] = txtMaterial.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["UOMId"] = Convert.ToInt32(HidUOMId.Value);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["UOM"] = HidUOMName.Value;
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PlantID"] = Convert.ToInt32(HidPlantId.Value);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PlantName"] = txtPlant.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["StorageLocationId"] = Convert.ToInt32(ddlStorageLocation.SelectedValue);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["StorageLocation"] = ddlStorageLocation.SelectedItem.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ValuationTypeId"] = Convert.ToInt32(HidValuationTypeId.Value);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ValuationType"] = txtValuationType.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ProjectId"] = Convert.ToInt32(HidProjectId.Value);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ProjectName"] = txtProject.Text.Trim();
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubProjectId"] = Convert.ToInt32(HidSubProjectId.Value);
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["SubProject"] = txtSubProject.Text.Trim();
                if (HidPurpose.Value != "")
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PurposeId"] = Convert.ToInt32(HidPurpose.Value);
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Purpose"] = txtPurpose.Text.Trim();
                }
                else
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["PurposeId"] = 0;
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Purpose"] = "";
                }
                if (txtQuantity.Text != "")
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Quantity"] = Convert.ToDouble(txtQuantity.Text.Trim());
                }
                else
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Quantity"] = 0;
                }
                if (txtValue.Text != "")
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Value"] = Convert.ToDouble(txtValue.Text.Trim());
                }
                else
                {
                    objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["Value"] = 0;
                }
                objdtLineItem.Rows[Convert.ToInt32(hidRowIndex.Value)]["ActiveStatus"] = true;
                objdtLineItem.AcceptChanges();
            }
            ViewState["LineItem"] = objdtLineItem;
            int LineNoInGrid = Convert.ToInt32(objdtLineItem.Rows[0]["LineNo"].ToString());
            for (int i = 1; i < objdtLineItem.Rows.Count; i++)
            {
                if (Convert.ToInt32(objdtLineItem.Rows[i]["LineNo"].ToString()) > LineNoInGrid)
                {
                    LineNoInGrid = Convert.ToInt32(objdtLineItem.Rows[i]["LineNo"].ToString());
                }
            }
            HidLineNo.Value = (LineNoInGrid + 10).ToString();

            gvIssueModification.DataSource = objdtLineItem;
            gvIssueModification.DataBind();
            ClearLineItems();
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.ErrorToLineItem, 125, 300);
        }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Upadte Record Of Header & Line Item

            DataTable dtLineItem = (DataTable)ViewState["LineItem"];
            if (dtLineItem.Rows.Count > 0)
            {
                #region Insert/Update Records Of Header

                if (HidAutoId.Value == "")
                {
                    objProc_IssueModification.AutoId = 0;
                }
                else
                {
                    objProc_IssueModification.AutoId = Convert.ToInt32(HidAutoId.Value);
                }
                objProc_IssueModification.IssueYear = txtIssueYear.Text.Trim();
                if (txtIssueDate.Text.Trim() != "")
                {
                    objProc_IssueModification.IssueDate = DateTime.ParseExact(txtIssueDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                }
                else
                {
                    objProc_IssueModification.IssueDate = "";
                }
                objProc_IssueModification.CostCenterId = Convert.ToInt32(HidCostCenter.Value);
                objProc_IssueModification.Remarks = txtRemarks.Text.Trim();
                objProc_IssueModification.ActiveStatus = Convert.ToBoolean(1);
                objProc_IssueModification.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objProc_IssueModification.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                #endregion

                #region Insert/Update Records of LineItem

                objProc_IssueModification.dtLineItems = new DataTable();
                objProc_IssueModification.dtLineItems = objProc_IssueModification.GetProc_IssueModification_LineItems_Trans_Structure();
                DataRow objdrLineItems;

                if (dtLineItem.Rows.Count > 0)
                {
                    foreach (DataRow objdrLineItem in dtLineItem.Rows)
                    {
                        try
                        {
                            if ((objdrLineItem["AutoId"].ToString() == "0" && objdrLineItem["IsUpdate"].ToString() == "") || (objdrLineItem["AutoId"].ToString() != "0" &&
                                objdrLineItem["IsUpdate"].ToString() == "Yes") || (objdrLineItem["AutoId"].ToString() == "0" && objdrLineItem["IsUpdate"].ToString() == "Yes"))
                            {
                                objdrLineItems = objProc_IssueModification.dtLineItems.NewRow();

                                objdrLineItems["AutoId"] = Convert.ToInt32(objdrLineItem["AutoId"].ToString());
                                if (HidAutoId.Value == "")
                                {
                                    objdrLineItems["IssueModificationId"] = 0;
                                }
                                else
                                {
                                    objdrLineItems["IssueModificationId"] = Convert.ToInt32(HidAutoId.Value);
                                }
                                objdrLineItems["LineNo"] = Convert.ToInt32(objdrLineItem["LineNo"].ToString());
                                objdrLineItems["BatchNo"] = objdrLineItem["BatchNo"].ToString();
                                objdrLineItems["MaterialId"] = Convert.ToInt32(objdrLineItem["MaterialId"].ToString());
                                objdrLineItems["UOMId"] = Convert.ToInt32(objdrLineItem["UOMId"].ToString());
                                objdrLineItems["PlantID"] = Convert.ToInt32(objdrLineItem["PlantID"].ToString());
                                objdrLineItems["StorageLocationId"] = Convert.ToInt32(objdrLineItem["StorageLocationId"].ToString());
                                objdrLineItems["ValuationTypeId"] = Convert.ToInt32(objdrLineItem["ValuationTypeId"].ToString());
                                objdrLineItems["ProjectId"] = Convert.ToInt32(objdrLineItem["ProjectId"].ToString());
                                objdrLineItems["SubProjectId"] = Convert.ToInt32(objdrLineItem["SubProjectId"].ToString());
                                if (objdrLineItem["PurposeId"].ToString() != "")
                                {
                                    objdrLineItems["PurposeId"] = Convert.ToInt32(objdrLineItem["PurposeId"].ToString());
                                }
                                else
                                {
                                    objdrLineItems["PurposeId"] = 0;
                                }
                                if (objdrLineItem["Quantity"].ToString() != "")
                                {
                                    objdrLineItems["Quantity"] = Convert.ToDouble(objdrLineItem["Quantity"].ToString());
                                }
                                else
                                {
                                    objdrLineItems["Quantity"] = 0;
                                }
                                if (objdrLineItem["Value"].ToString() != "")
                                {
                                    objdrLineItems["Value"] = Convert.ToDouble(objdrLineItem["Value"].ToString());
                                }
                                else
                                {
                                    objdrLineItems["Value"] = 0;
                                }
                                objdrLineItems["ActiveStatus"] = objdrLineItem["ActiveStatus"].ToString();

                                objProc_IssueModification.dtLineItems.Rows.Add(objdrLineItems);
                                objProc_IssueModification.dtLineItems.AcceptChanges();
                            }
                        }
                        catch
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.LineItemNotSaved, 125, 300);
                            return;
                        }
                    }
                }

                #endregion

                FlagInsertUpdate = objProc_IssueModification.InsertUpdate_In_Proc_IssueModification();
                if (FlagInsertUpdate == "0")
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                    #region Clear All records after save

                    ClearHeaderItems();
                    ClearLineItems();
                    ViewState["LineItem"] = null;

                    gvIssueModification.DataSource = "";
                    gvIssueModification.DataBind();

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
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.AddLineItem, 125, 300);
                return;
            }

            #endregion
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
            string FormIdProcIssueModification = ConfigurationManager.AppSettings["FormIdProcIssueModification"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProcIssueModification);

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

    protected void FillFinancialYear()
    {
        try
        {
            DataTable dt = new DataTable();
            string OrganizationId = ConfigurationManager.AppSettings["OrganizationId"].ToString();
            dt = objCommon_mst.Get_FinancialYear(OrganizationId);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["FinancialStartMonth"].ToString()) > 1)
                {
                    string EndFinancialYear = dt.Rows[0]["FinancialEndYear"].ToString().Substring(2);
                    txtIssueYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    txtIssueYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch (Exception ex) { }
    }

    protected void Get_All_Prod_StorageLocation_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_StorageLocation_Mst("");
            ddlStorageLocation.DataTextField = "StorageLocationName";
            ddlStorageLocation.DataValueField = "AutoId";
            ddlStorageLocation.DataSource = colRCommontype;
            ddlStorageLocation.DataBind();
            ddlStorageLocation.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
    }

    private void FillAllMaterial(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllMaterialMaster(Searchtext);

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

    private void FillAllValuationTypeMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllValuationTypeMaster(Searchtext);

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

    private void FillAllCostCenterMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllCostCenterMaster(Searchtext);

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

    private void FillAllPlantMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllPlantMaster(Searchtext);

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

    private void FillAllPurposeMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllPurposeMaster(Searchtext);

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

    private void FillAllProjectMaster(string Searchtext)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllProjectMaster(Searchtext);

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

    private void FillAllSubProjectMaster(string Searchtext, int ProjectId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllSubProjectMaster(Searchtext, ProjectId);

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

    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    #endregion

    # region Function to Clear Master

    public void ClearHeaderItems()
    {
        FillFinancialYear();
        txtIssueDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
        txtIssueNo.Text = "";
        txtCostCenter.Text = "";
        HidCostCenter.Value = "";        
        txtRemarks.Text = "";
        TDIssueNo.Attributes.Add("style", "display:none");
        TDtxtIssueNo.Attributes.Add("style", "display:none");
    }

    public void ClearLineItems()
    {
        int PalletNo = RandomNumber(100000000, 999999999);
        txtBatch.Text = Convert.ToString(PalletNo);
        HidUpdateGridRecord.Value = "";
        HidMaterialId.Value = "";
        txtMaterial.Text = "";
        HidPlantId.Value = "";
        txtPlant.Text = "";
        ddlStorageLocation.SelectedValue = "";
        HidValuationTypeId.Value = "";
        txtValuationType.Text = "";
        HidProjectId.Value = "";
        txtProject.Text = "";
        HidSubProjectId.Value = "";
        txtSubProject.Text = "";
        HidPurpose.Value = "";
        txtPurpose.Text = "";
        txtQuantity.Text = "";
        txtValue.Text = "";
        txtStockQuantity.Text = "";
        hidRowIndex.Value = "";
        HidUOMId.Value = "";
        HidUOMName.Value = "";
        hidLineItemId.Value = "";
        txtValue.Text = "";
        ImgBtnAddLine.ImageUrl = "../Images/btnAddLine.png";
    }

    #endregion

    #region Fill Form Data

    protected void GetProc_IssueModification_LineItems_Trans(int AutoId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_IssueModification.GetProc_IssueModification_LineItems_Trans(AutoId);
            if (dt.Rows.Count > 0)
            {
                int TotalRows = dt.Rows.Count;
                HidLineNo.Value = (Convert.ToInt32(dt.Rows[TotalRows - 1]["LineNo"].ToString()) + 10).ToString();
            }
            else
            {
                HidLineNo.Value = "10";
            }
            ViewState["LineItem"] = dt;
            gvIssueModification.DataSource = dt;
            gvIssueModification.DataBind();
        }
        catch (Exception ex) { }
    }

    protected void Get_Proc_IssueModification_Header_Trans(int AutoId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_IssueModification.Get_Proc_IssueModification_Header_Trans(AutoId);
            if (dt.Rows.Count > 0)
            {
                HidAutoId.Value = dt.Rows[0]["AutoId"].ToString();
                txtIssueYear.Text = dt.Rows[0]["IssueYear"].ToString();
                txtIssueDate.Text = dt.Rows[0]["IssueDate"].ToString();
                txtIssueNo.Text = dt.Rows[0]["IssueNo"].ToString();
                txtCostCenter.Text = dt.Rows[0]["CostCenter"].ToString();
                HidCostCenter.Value = dt.Rows[0]["CostCenterId"].ToString();                
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                TDIssueNo.Attributes.Add("style", "display:block");
                TDtxtIssueNo.Attributes.Add("style", "display:block");
            }
        }
        catch (Exception ex) { }
    }

    private void BindAllIssueModificationList(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_IssueModification.BindAllIssueModificationList(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvIssueModificationList.DataSource = dt;
                gvIssueModificationList.AllowPaging = true;
                gvIssueModificationList.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvIssueModificationList.AllowPaging = false;
                gvIssueModificationList.DataSource = "";
                gvIssueModificationList.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    #endregion
    
}