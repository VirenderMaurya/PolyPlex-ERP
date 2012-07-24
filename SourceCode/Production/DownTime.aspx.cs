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
    Prod_DownTime objProd_DownTime = new Prod_DownTime();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();    
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Down Time";

            txtVoucherDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);           

            #region Bind Masters

            BindSearchList();
            FillFinancialYear();
            Get_All_Prod_Line_Mst();
            FillAllPlantMaster();
            Get_All_Prod_Area_Mst();
            Get_All_Prod_Dept_Mst();
            Get_All_Prod_Machine_Mst();
            Get_All_Prod_SubMachine_Mst();
            Get_All_Prod_KKType_Mst();
            Get_All_Prod_Problem_Mst();

            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Intermediate Table Data

            Get_Prod_PET_MET_Downtime_Intermediate_AllRecords();

            #endregion  

            TCVocherNo.Attributes.Add("style", "display:none");
            TCtxtVocherNo.Attributes.Add("style", "display:none");

            txtStartDate.Attributes.Add("style", "background:lightgray");
            txtStartDate.Attributes.Add("readonly", "true");
            txtEndDate.Attributes.Add("style", "background:lightgray");
            txtEndDate.Attributes.Add("readonly", "true");
            txtVoucherNo.Attributes.Add("style", "background:lightgray");
            txtVoucherNo.Attributes.Add("readonly", "true");
            txtVoucherDate.Attributes.Add("style", "background:lightgray");
            txtVoucherDate.Attributes.Add("readonly", "true");
            txtTotalHours.Attributes.Add("readonly", "true");
            txtTotalHours.Attributes.Add("style", "background:lightgray");                                
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
            Get_Prod_PET_MET_Downtime_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
        Get_Prod_PET_MET_Downtime_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvPetMetDownTimeAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvPetMetDownTimeAll = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvPetMetDownTimeAll.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvPetMetDownTimeAll.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidDownTimeId.Value = Convert.ToString(e.CommandArgument);
                HidDownTimeIntermId.Value = "";               

                #region Fill Whole Form

                Get_Prod_PET_MET_Downtime_BothTable(Convert.ToInt32(HidDownTimeId.Value), "Main");

                #endregion
            }
        }
        catch { }
    }

    protected void gvPetMetDownTimeAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPetMetDownTimeAll.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        Get_Prod_PET_MET_Downtime_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvDownTimeGridInterm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvDownTimeGridInterm = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvDownTimeGridInterm.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvDownTimeGridInterm.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidDownTimeId.Value = "";
                HidDownTimeIntermId.Value = Convert.ToString(e.CommandArgument);                

                #region Fill Whole Form From Selected Intermediate Row

                Get_Prod_PET_MET_Downtime_BothTable(Convert.ToInt32(HidDownTimeIntermId.Value), "Intermediate");

                #endregion
            }
        }
        catch { }
    }

    protected void gvDownTimeGridInterm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDownTimeGridInterm.PageIndex = e.NewPageIndex;
            Get_Prod_PET_MET_Downtime_Intermediate_AllRecords();
        }
        catch { }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Update Records Of MainDetailsTab

            if (HidDownTimeId.Value == "")
            {
                objProd_DownTime.AutoID = 0;
            }
            else
            {
                objProd_DownTime.AutoID = Convert.ToInt32(HidDownTimeId.Value);
            }
            if (HidDownTimeIntermId.Value == "")
            {
                objProd_DownTime.IntermediateAutoID = 0;
            }
            else
            {
                objProd_DownTime.IntermediateAutoID = Convert.ToInt32(HidDownTimeIntermId.Value);
            }
            objProd_DownTime.Year = HidYear.Value;
            objProd_DownTime.ProcessType = ddlProcessType.SelectedValue;
            objProd_DownTime.PlantId = Convert.ToInt32(ddlPlant.SelectedValue);
            if (txtVoucherDate.Text.Trim() != "")
            {
                objProd_DownTime.VoucherDate = DateTime.ParseExact(txtVoucherDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_DownTime.VoucherDate = "";
            }           
            objProd_DownTime.LineId = Convert.ToInt32(ddlLine.SelectedValue);
            objProd_DownTime.AreaId = Convert.ToInt32(ddlArea.SelectedValue);
            objProd_DownTime.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
            objProd_DownTime.MachineId = Convert.ToInt32(ddlMachine.SelectedValue);
            objProd_DownTime.SubMachineId = Convert.ToInt32(ddlSubMachineId .SelectedValue);
            objProd_DownTime.KKTypeId = Convert.ToInt32(ddlKKType.SelectedValue);
            objProd_DownTime.ProblemCodeDescId = Convert.ToInt32(ddlProblemCode.SelectedValue);
            if (txtStartDate.Text.Trim() != "")
            {
                objProd_DownTime.StartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_DownTime.StartDate = "";
            }
            objProd_DownTime.StartTime = (tsStartTime.Hour).ToString() + " : " + tsStartTime.Minute.ToString();
            if (txtEndDate.Text.Trim() != "")
            {
                objProd_DownTime.EndDate = DateTime.ParseExact(txtEndDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_DownTime.EndDate = "";
            }
            objProd_DownTime.EndTime = (tsEndTime.Hour).ToString() + " : " + tsEndTime.Minute.ToString();
            if (chkHasItAffected.Checked == true)
            {
                objProd_DownTime.ProcessAffected = true;
            }
            else
            {
                objProd_DownTime.ProcessAffected = false;
            }
            objProd_DownTime.DetailsOfObservation = txtDetailofObservations.Text.Trim();
            objProd_DownTime.ActiveStatus = true;
            objProd_DownTime.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
            objProd_DownTime.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
            
            #endregion

            FlagInsertUpdate = objProd_DownTime.InsertAndUpdate_In_Prod_PET_MET_Downtime();
            if (FlagInsertUpdate == "YES")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);

                #region Clear All records after save
                Clear();
                #region Intermediate Table Data

                Get_Prod_PET_MET_Downtime_Intermediate_AllRecords();

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
            if (Session["UserId"] == null)
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Session Expired.", 125, 300);
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
            }
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
            string FormIdProdDownTime = ConfigurationManager.AppSettings["FormIdProdDownTime"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProdDownTime);

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
                    HidYear.Value = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    HidYear.Value = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch (Exception ex) { }
    }

    protected void Get_All_Prod_Line_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Line_Mst();
            ddlLine.DataTextField = "LineCode";
            ddlLine.DataValueField = "AutoId";
            ddlLine.DataSource = colRCommontype;
            ddlLine.DataBind();
            ddlLine.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    private void FillAllPlantMaster()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.FillAllPlantMaster("");

            if (dt.Rows.Count > 0)
            {
                ddlPlant.DataValueField = "autoid";
                ddlPlant.DataTextField = "PLANTNAME";
                ddlPlant.DataSource = dt;
                ddlPlant.DataBind();
                ddlPlant.Items.Insert(0, new ListItem("-Select-", ""));
                dt = null;
            }            
        }
        catch (Exception ex)
        {}
    }

    protected void Get_All_Prod_Area_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Area_Mst("");
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AutoId";
            ddlArea.DataSource = colRCommontype;
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Prod_Dept_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Dept_Mst("");
            ddlDepartment.DataTextField = "DeptName";
            ddlDepartment.DataValueField = "AutoId";
            ddlDepartment.DataSource = colRCommontype;
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Prod_Machine_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Machine_Mst("");
            ddlMachine.DataTextField = "MachineName";
            ddlMachine.DataValueField = "AutoId";
            ddlMachine.DataSource = colRCommontype;
            ddlMachine.DataBind();
            ddlMachine.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Prod_SubMachine_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_SubMachine_Mst("");
            ddlSubMachineId.DataTextField = "SubMachineName";
            ddlSubMachineId.DataValueField = "AutoId";
            ddlSubMachineId.DataSource = colRCommontype;
            ddlSubMachineId.DataBind();
            ddlSubMachineId.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Prod_KKType_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_KKType_Mst("");
            ddlKKType.DataTextField = "KKName";
            ddlKKType.DataValueField = "AutoId";
            ddlKKType.DataSource = colRCommontype;
            ddlKKType.DataBind();
            ddlKKType.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Prod_Problem_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Problem_Mst("");
            ddlProblemCode.DataTextField = "ProbDesc";
            ddlProblemCode.DataValueField = "AutoId";
            ddlProblemCode.DataSource = colRCommontype;
            ddlProblemCode.DataBind();
            ddlProblemCode.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }    

    #endregion

    private void Clear()
    {
        try
        {
            HidDownTimeId.Value = "";
            HidDownTimeIntermId.Value = "";
            ddlProcessType.SelectedValue = "";
            ddlPlant.SelectedValue = "";
            txtVoucherNo.Text = "";
            FillFinancialYear();
            txtVoucherDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            ddlLine.SelectedValue = "";
            ddlArea.SelectedValue = "";
            ddlDepartment.SelectedValue = "";
            ddlMachine.SelectedValue = "";
            ddlSubMachineId.SelectedValue = "";
            ddlKKType.SelectedValue = "";
            ddlProblemCode.SelectedValue = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtTotalHours.Text = "";
            chkHasItAffected.Checked = false;
            txtDetailofObservations.Text = "";
            TCVocherNo.Attributes.Add("style", "display:none");
            TCtxtVocherNo.Attributes.Add("style", "display:none");
        }
        catch { }
    }

    #region Function to fill Intermediate And Main List Grid

    private void Get_Prod_PET_MET_Downtime_Intermediate_AllRecords()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_DownTime .Get_Prod_PET_MET_Downtime_Intermediate_AllRecords();
            if (dt.Rows.Count > 0)
            {
                gvDownTimeGridInterm.DataSource = dt;
                gvDownTimeGridInterm.AllowPaging = true;
                gvDownTimeGridInterm.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvDownTimeGridInterm.AllowPaging = false;
                gvDownTimeGridInterm.DataSource = "";
                gvDownTimeGridInterm.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    private void Get_Prod_PET_MET_Downtime_AllRecords(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_DownTime.Get_Prod_PET_MET_Downtime_AllRecords(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvPetMetDownTimeAll.DataSource = dt;
                gvPetMetDownTimeAll.AllowPaging = true;
                gvPetMetDownTimeAll.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvPetMetDownTimeAll.AllowPaging = false;
                gvPetMetDownTimeAll.DataSource = "";
                gvPetMetDownTimeAll.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    protected void Get_Prod_PET_MET_Downtime_BothTable(int DownTimeId, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_DownTime.Get_Prod_PET_MET_Downtime_BothTable(DownTimeId, SearchType);
            if (dt.Rows.Count > 0)
            {
                if (SearchType == "Main")
                {
                    HidDownTimeId.Value = dt.Rows[0]["AutoId"].ToString();
                    TCVocherNo.Attributes.Add("style", "display:block");
                    TCtxtVocherNo.Attributes.Add("style", "display:block");
                }
                else if (SearchType == "Intermediate")
                {
                    HidDownTimeId.Value = "";
                    TCVocherNo.Attributes.Add("style", "display:none");
                    TCtxtVocherNo.Attributes.Add("style", "display:none");
                }
                HidYear.Value = dt.Rows[0]["Year"].ToString();
                if (dt.Rows[0]["ProcessType"].ToString() != "0")
                {
                    ddlProcessType.SelectedValue = dt.Rows[0]["ProcessType"].ToString();
                }
                else
                {
                    ddlProcessType.SelectedValue = "";
                }
                if (dt.Rows[0]["PlantId"].ToString() != "0")
                {
                    ddlPlant.SelectedValue = dt.Rows[0]["PlantId"].ToString();
                }
                else
                {
                    ddlPlant.SelectedValue = "";
                }
                txtVoucherNo.Text = dt.Rows[0]["VoucherNo"].ToString();
                txtVoucherDate.Text = dt.Rows[0]["VoucherDate"].ToString();
                if (dt.Rows[0]["LineId"].ToString() != "0")
                {
                    ddlLine.SelectedValue = dt.Rows[0]["LineId"].ToString();
                }
                else
                {
                    ddlLine.SelectedValue = "";
                }
                if (dt.Rows[0]["AreaId"].ToString() != "0")
                {
                    ddlArea.SelectedValue = dt.Rows[0]["AreaId"].ToString();
                }
                else
                {
                    ddlArea.SelectedValue = "";
                }
                if (dt.Rows[0]["DepartmentId"].ToString() != "0")
                {
                    ddlDepartment.SelectedValue = dt.Rows[0]["DepartmentId"].ToString();
                }
                else
                {
                    ddlDepartment.SelectedValue = "";
                }
                if (dt.Rows[0]["MachineId"].ToString() != "0")
                {
                    ddlMachine.SelectedValue = dt.Rows[0]["MachineId"].ToString();
                }
                else
                {
                    ddlMachine.SelectedValue = "";
                }
                if (dt.Rows[0]["SubMachineId"].ToString() != "0")
                {
                    ddlSubMachineId.SelectedValue = dt.Rows[0]["SubMachineId"].ToString();
                }
                else
                {
                    ddlSubMachineId.SelectedValue = "";
                }
                if (dt.Rows[0]["KKTypeId"].ToString() != "0")
                {
                    ddlKKType.SelectedValue = dt.Rows[0]["KKTypeId"].ToString();
                }
                else
                {
                    ddlKKType.SelectedValue = "";
                }
                if (dt.Rows[0]["ProblemCodeDescId"].ToString() != "0")
                {
                    ddlProblemCode.SelectedValue = dt.Rows[0]["ProblemCodeDescId"].ToString();
                }
                else
                {
                    ddlProblemCode.SelectedValue = "";
                }
                txtStartDate.Text = dt.Rows[0]["StartDate"].ToString();
                txtEndDate.Text = dt.Rows[0]["EndDate"].ToString();
                if (dt.Rows[0]["StartTime"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["StartTime"].ToString();
                    string[] timearr = time.Split(':');
                    tsStartTime.Hour = Convert.ToInt32(timearr[0]);
                    tsStartTime.Minute = Convert.ToInt32(timearr[1]);
                }
                if (dt.Rows[0]["EndTime"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["EndTime"].ToString();
                    string[] timearr = time.Split(':');
                    tsEndTime.Hour = Convert.ToInt32(timearr[0]);
                    tsEndTime.Minute = Convert.ToInt32(timearr[1]);
                } 
                //txtTotalHours.Text =  dt.Rows[0]["PetJumboId"].ToString();
                if (dt.Rows[0]["ProcessAffected"].ToString() == "True")
                {
                    chkHasItAffected.Checked = true;
                }
                else
                {
                    chkHasItAffected.Checked = false;
                }
                txtDetailofObservations.Text = dt.Rows[0]["DetailsOfObservation"].ToString();               
            }
        }
        catch (Exception ex) { }
    }

    #endregion

    #endregion


    
}