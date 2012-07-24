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
using System.Threading;

public partial class Sales_PerformaInvoice : System.Web.UI.Page
{
    #region***************************************Variables***************************************

    Common_mst objCommon_mst = new Common_mst();
    Common_Message objcommonmessage = new Common_Message();
    Proc_ChipsProductionCPBP objProc_ChipsProductionCPBP = new Proc_ChipsProductionCPBP();    
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();    
    string FlagInsertUpdate;    

    #endregion

    #region***************************************Events***************************************    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
                lblPageHeader.Text = "Chips Production CP/BP";              
                TCPetJumbo.ActiveTabIndex = 0;

                TDVoucherNo.Attributes.Add("style", "display:none");
                TDtxtVoucherNo.Attributes.Add("style", "display:none");                              

                #region Bind Masters

                BindSearchList();
                FillFinancialYear();
                Get_All_Prod_Process_Mst();
                Get_All_Prod_Dept_Mst();
                Get_All_Prod_Machine_Mst();
                Get_All_Prod_SubMachine_Mst();
                Get_All_Prod_KKType_Mst();
                Get_All_Prod_Problem_Mst();

                #endregion

                TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
                txtSearch.Text = "";  
                
                #region Change Color of Readonly Fields

                txtYear.Attributes.Add("style", "background:lightgray");
                txtVoucherNo.Attributes.Add("style", "background:lightgray");
                txtDate.Attributes.Add("style", "background:lightgray");
                txtDateFrom.Attributes.Add("style", "background:lightgray");
                txtDateTo.Attributes.Add("style", "background:lightgray");
                txtStartDate.Attributes.Add("style", "background:lightgray");
                txtEndDate.Attributes.Add("style", "background:lightgray"); 
                
                #endregion

                txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

                #region Readonly Fields               

                txtYear.Attributes.Add("readonly", "true");
                txtVoucherNo.Attributes.Add("readonly", "true");
                txtDate.Attributes.Add("readonly", "true");
                txtDateFrom.Attributes.Add("readonly", "true");
                txtDateTo.Attributes.Add("readonly", "true");
                txtStartDate.Attributes.Add("readonly", "true");
                txtEndDate.Attributes.Add("readonly", "true");                
                #endregion

            }
            catch { }            
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
        ClearChipsContinuousTab();
        ClearBreakDownDetailsTab(); 
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            BindAllChipsProductionCPBP(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender1.Show();            
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue , 125, 300);
        }
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllChipsProductionCPBP(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvChipsProductionCPBPAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvChipsProductionCPBPAll = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvChipsProductionCPBPAll.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvChipsProductionCPBPAll.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                hidAutoId.Value = Convert.ToString(e.CommandArgument);

                #region Fill Whole Form

                FillFormChipsProductionCPBP(Convert.ToInt32(hidAutoId.Value));

                #endregion
            }
        }
        catch { }
    }

    protected void gvChipsProductionCPBPAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvChipsProductionCPBPAll.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        BindAllChipsProductionCPBP(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (hidAutoId.Value == "")
            {
                objProc_ChipsProductionCPBP.AutoId = 0;
            }
            else
            {
                objProc_ChipsProductionCPBP.AutoId = Convert.ToInt32(hidAutoId.Value);
            }
            if (ddlProcess.SelectedValue != "")
            {
                objProc_ChipsProductionCPBP.ProcessId = Convert.ToInt32(ddlProcess.SelectedValue.ToString());
            }
            else
            {
                objProc_ChipsProductionCPBP.ProcessId = 0;
            }
            objProc_ChipsProductionCPBP.Year = txtYear.Text.Trim();
            if (txtDate.Text.Trim() != "")
            {
                objProc_ChipsProductionCPBP.Date = DateTime.ParseExact(txtDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProc_ChipsProductionCPBP.Date = "";
            }
            if (txtDateFrom.Text.Trim() != "")
            {
                objProc_ChipsProductionCPBP.DateFrom = DateTime.ParseExact(txtDateFrom.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProc_ChipsProductionCPBP.DateFrom = "";
            }
            objProc_ChipsProductionCPBP.TimeFrom = (tsTimeFrom.Hour).ToString() + " : " + tsTimeFrom.Minute.ToString();
            if (txtDateTo.Text.Trim() != "")
            {
                objProc_ChipsProductionCPBP.DateTo = DateTime.ParseExact(txtDateTo.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProc_ChipsProductionCPBP.DateTo = "";
            }
            objProc_ChipsProductionCPBP.TimeTo = (tsTimeTo.Hour).ToString() + " : " + tsTimeTo.Minute.ToString();
            objProc_ChipsProductionCPBP.PTA = txtPTA.Text.Trim();
            objProc_ChipsProductionCPBP.Quantity = txtQuantity.Text.Trim();
            objProc_ChipsProductionCPBP.MEG = txtMEG.Text.Trim();
            objProc_ChipsProductionCPBP.VirginQuantity = txtVirginQuantity.Text.Trim();
            objProc_ChipsProductionCPBP.BatchEG = txtBatchEG.Text.Trim();
            objProc_ChipsProductionCPBP.HotWellQuantity = txtHotWellQuantity.Text.Trim();
            objProc_ChipsProductionCPBP.ATAATO = txtATAATO.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityATA = txtQuantityATA.Text.Trim();
            objProc_ChipsProductionCPBP.ItemCode1 = txtItemCode1.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityItemCode1 = txtQuantityItemCode1.Text.Trim();
            objProc_ChipsProductionCPBP.ItemCode2 = txtItemCode2.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityItemCode2 = txtQuantityItemCode2.Text.Trim();
            objProc_ChipsProductionCPBP.ItemCode3 = txtItemCode3.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityItemCode3 = txtQuantityItemCode3.Text.Trim();
            objProc_ChipsProductionCPBP.ItemCode4 = txtItemCode4.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityItemCode4 = txtQuantityItemCode4.Text.Trim();
            objProc_ChipsProductionCPBP.ItemCode5 = txtItemCode5.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityItemCode5 = txtQuantityItemCode5.Text.Trim();
            objProc_ChipsProductionCPBP.ItemCode6 = txtItemCode6.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityItemCode6 = txtQuantityItemCode6.Text.Trim();
            objProc_ChipsProductionCPBP.ItemCode7 = txtItemCode7.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityItemCode7 = txtQuantityItemCode7.Text.Trim();
            objProc_ChipsProductionCPBP.ItemCode8 = txtItemCode8.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityItemCode8 = txtQuantityItemCode8.Text.Trim();
            objProc_ChipsProductionCPBP.OutputCode1 = txtOutputCode1.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityOutputCode1 = txtQuantityOutputCode1.Text.Trim();
            objProc_ChipsProductionCPBP.OutputCode2 = txtOutputCode2.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityOutputCode2 = txtQuantityOutputCode2.Text.Trim();
            objProc_ChipsProductionCPBP.OutputCode3 = txtOutputCode3.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityOutputCode3 = txtQuantityOutputCode3.Text.Trim();
            objProc_ChipsProductionCPBP.OutputCode4 = txtOutputCode4.Text.Trim();
            objProc_ChipsProductionCPBP.QuantityOutputCode4 = txtQuantityOutputCode4.Text.Trim();
            objProc_ChipsProductionCPBP.CrudeMEGQuantity = txtCrudeMEGQuantity.Text.Trim();
            objProc_ChipsProductionCPBP.Water = txtWater.Text.Trim();
            objProc_ChipsProductionCPBP.Lumps = txtLumps.Text.Trim();
            objProc_ChipsProductionCPBP.OverSize = txtOverSize.Text.Trim();
            objProc_ChipsProductionCPBP.Residue = txtResidue.Text.Trim();
            objProc_ChipsProductionCPBP.PTAWaste = txtPTAWaste.Text.Trim();
            objProc_ChipsProductionCPBP.NonUsableChips = txtNonUsableChips.Text.Trim();
            objProc_ChipsProductionCPBP.WasteMEG = txtMEGWaste.Text.Trim();
            objProc_ChipsProductionCPBP.Silica = txtSilica.Text.Trim();
            objProc_ChipsProductionCPBP.Catalyst = txtCatalyst.Text.Trim();

            objProc_ChipsProductionCPBP.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
            objProc_ChipsProductionCPBP.MachineId = Convert.ToInt32(ddlMachine.SelectedValue);
            objProc_ChipsProductionCPBP.SubMachineId = Convert.ToInt32(ddlSubMachineId.SelectedValue);
            objProc_ChipsProductionCPBP.KKTypeId = Convert.ToInt32(ddlKKType.SelectedValue);
            objProc_ChipsProductionCPBP.ProblemCodeId = Convert.ToInt32(ddlProblemCode.SelectedValue);
            if (txtStartDate.Text.Trim() != "")
            {
                objProc_ChipsProductionCPBP.StartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProc_ChipsProductionCPBP.StartDate = "";
            }
            objProc_ChipsProductionCPBP.StartTime = (tsStartTime.Hour).ToString() + " : " + tsStartTime.Minute.ToString();
            if (txtEndDate.Text.Trim() != "")
            {
                objProc_ChipsProductionCPBP.EndDate = DateTime.ParseExact(txtEndDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProc_ChipsProductionCPBP.EndDate = "";
            }
            objProc_ChipsProductionCPBP.EndTime = (tsEndTime.Hour).ToString() + " : " + tsEndTime.Minute.ToString();
            if (chkHasItAffected.Checked == true)
            {
                objProc_ChipsProductionCPBP.ProcessAffected = true;
            }
            else
            {
                objProc_ChipsProductionCPBP.ProcessAffected = false;
            }
            objProc_ChipsProductionCPBP.DetailsOfObservation = txtDetailofObservations.Text.Trim();
            objProc_ChipsProductionCPBP.ActiveStatus = true;
            objProc_ChipsProductionCPBP.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
            objProc_ChipsProductionCPBP.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

            FlagInsertUpdate = objProc_ChipsProductionCPBP.InsertUpdate_In_Proc_ChipsProductionCPBP_Trans();
            if (FlagInsertUpdate == "YES")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                #region Clear All records after save

                ClearChipsContinuousTab();
                ClearBreakDownDetailsTab();

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
            string FormIdProcChipsProductionCPBP = ConfigurationManager.AppSettings["FormIdProcChipsProductionCPBP"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProcChipsProductionCPBP);

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
                    txtYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);
                }
                else
                {
                    txtYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();
                }
            }
        }
        catch (Exception ex) { }
    }

    protected void Get_All_Prod_Process_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Process_Mst("");
            ddlProcess.DataTextField = "ProcessName";
            ddlProcess.DataValueField = "AutoId";
            ddlProcess.DataSource = colRCommontype;
            ddlProcess.DataBind();
            ddlProcess.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }
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

    #region Function to Fill Form Data    

    private void BindAllChipsProductionCPBP(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_ChipsProductionCPBP.BindAllChipsProductionCPBP(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvChipsProductionCPBPAll.DataSource = dt;
                gvChipsProductionCPBPAll.AllowPaging = true;
                gvChipsProductionCPBPAll.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvChipsProductionCPBPAll.AllowPaging = false;
                gvChipsProductionCPBPAll.DataSource = "";
                gvChipsProductionCPBPAll.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    private void FillFormChipsProductionCPBP(int AutoId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProc_ChipsProductionCPBP.FillFormChipsProductionCPBP(AutoId);
            if (dt.Rows.Count > 0)
            {
                #region ChipsContinuousTab

                TDVoucherNo.Attributes.Add("style", "display:block");
                TDtxtVoucherNo.Attributes.Add("style", "display:block");
                if (dt.Rows[0]["ProcessId"].ToString() != "0")
                {
                    ddlProcess.SelectedValue = dt.Rows[0]["ProcessId"].ToString();
                }
                else
                {
                    ddlProcess.SelectedValue = "";
                }
                txtYear.Text = dt.Rows[0]["Year"].ToString();
                txtVoucherNo.Text = dt.Rows[0]["VoucherNo"].ToString();
                txtDate.Text = dt.Rows[0]["Date"].ToString();
                txtDateFrom.Text = dt.Rows[0]["DateFrom"].ToString();
                if (dt.Rows[0]["TimeFrom"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["TimeFrom"].ToString();
                    string[] timearr = time.Split(':');
                    tsTimeFrom.Hour = Convert.ToInt32(timearr[0]);
                    tsTimeFrom.Minute = Convert.ToInt32(timearr[1]);
                }
                txtDateTo.Text = dt.Rows[0]["DateTo"].ToString();
                if (dt.Rows[0]["TimeTo"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["TimeTo"].ToString();
                    string[] timearr = time.Split(':');
                    tsTimeTo.Hour = Convert.ToInt32(timearr[0]);
                    tsTimeTo.Minute = Convert.ToInt32(timearr[1]);
                }
                txtPTA.Text = dt.Rows[0]["PTA"].ToString();
                txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                txtMEG.Text = dt.Rows[0]["MEG"].ToString();
                txtVirginQuantity.Text = dt.Rows[0]["VirginQuantity"].ToString();
                txtBatchEG.Text = dt.Rows[0]["BatchEG"].ToString();
                txtHotWellQuantity.Text = dt.Rows[0]["HotWellQuantity"].ToString();
                txtATAATO.Text = dt.Rows[0]["ATAATO"].ToString();
                txtQuantityATA.Text = dt.Rows[0]["QuantityATA"].ToString();
                txtItemCode1.Text = dt.Rows[0]["ItemCode1"].ToString();
                txtItemCode2.Text = dt.Rows[0]["ItemCode2"].ToString();
                txtItemCode3.Text = dt.Rows[0]["ItemCode3"].ToString();
                txtItemCode4.Text = dt.Rows[0]["ItemCode4"].ToString();
                txtItemCode5.Text = dt.Rows[0]["ItemCode5"].ToString();
                txtItemCode6.Text = dt.Rows[0]["ItemCode6"].ToString();
                txtItemCode7.Text = dt.Rows[0]["ItemCode7"].ToString();
                txtItemCode8.Text = dt.Rows[0]["ItemCode8"].ToString();
                txtQuantityItemCode1.Text = dt.Rows[0]["QuantityItemCode1"].ToString();
                txtQuantityItemCode2.Text = dt.Rows[0]["QuantityItemCode2"].ToString();
                txtQuantityItemCode3.Text = dt.Rows[0]["QuantityItemCode3"].ToString();
                txtQuantityItemCode4.Text = dt.Rows[0]["QuantityItemCode4"].ToString();
                txtQuantityItemCode5.Text = dt.Rows[0]["QuantityItemCode5"].ToString();
                txtQuantityItemCode6.Text = dt.Rows[0]["QuantityItemCode6"].ToString();
                txtQuantityItemCode7.Text = dt.Rows[0]["QuantityItemCode7"].ToString();
                txtQuantityItemCode8.Text = dt.Rows[0]["QuantityItemCode8"].ToString();
                txtOutputCode1.Text = dt.Rows[0]["OutputCode1"].ToString();
                txtOutputCode2.Text = dt.Rows[0]["OutputCode2"].ToString();
                txtOutputCode3.Text = dt.Rows[0]["OutputCode3"].ToString();
                txtOutputCode4.Text = dt.Rows[0]["OutputCode4"].ToString();
                txtQuantityOutputCode1.Text = dt.Rows[0]["QuantityOutputCode1"].ToString();
                txtQuantityOutputCode2.Text = dt.Rows[0]["QuantityOutputCode2"].ToString();
                txtQuantityOutputCode3.Text = dt.Rows[0]["QuantityOutputCode3"].ToString();
                txtQuantityOutputCode4.Text = dt.Rows[0]["QuantityOutputCode4"].ToString();
                txtCrudeMEGQuantity.Text = dt.Rows[0]["CrudeMEGQuantity"].ToString();
                txtWater.Text = dt.Rows[0]["Water"].ToString();
                txtLumps.Text = dt.Rows[0]["Lumps"].ToString();
                txtOverSize.Text = dt.Rows[0]["OverSize"].ToString();
                txtResidue.Text = dt.Rows[0]["Residue"].ToString();
                txtPTAWaste.Text = dt.Rows[0]["PTAWaste"].ToString();
                txtNonUsableChips.Text = dt.Rows[0]["NonUsableChips"].ToString();
                txtMEGWaste.Text = dt.Rows[0]["WasteMEG"].ToString();
                txtSilica.Text = dt.Rows[0]["Silica"].ToString();
                txtCatalyst.Text = dt.Rows[0]["Catalyst"].ToString();

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
                if (dt.Rows[0]["ProblemCodeId"].ToString() != "0")
                {
                    ddlProblemCode.SelectedValue = dt.Rows[0]["ProblemCodeId"].ToString();
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
                if (dt.Rows[0]["ProcessAffected"].ToString() == "True")
                {
                    chkHasItAffected.Checked = true;
                }
                else
                {
                    chkHasItAffected.Checked = false;
                }
                txtDetailofObservations.Text = dt.Rows[0]["DetailsOfObservation"].ToString();

                #endregion

                #region BreakDownDetailsTab

                #endregion
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    #region Function to clear records

    private void ClearChipsContinuousTab()
    {
        try
        {
            TDVoucherNo.Attributes.Add("style", "display:none");
            TDtxtVoucherNo.Attributes.Add("style", "display:none");
            hidAutoId.Value = "";
            ddlProcess.SelectedValue = "";
            txtYear.Text = "";
            txtVoucherNo.Text = "";
            txtDate.Text = "";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtPTA.Text = "";
            txtQuantity.Text = "";
            txtMEG.Text = "";
            txtVirginQuantity.Text = "";
            txtBatchEG.Text = "";
            txtHotWellQuantity.Text = "";
            txtATAATO.Text = "";
            txtQuantityATA.Text = "";
            txtItemCode1.Text = "";
            txtItemCode2.Text = "";
            txtItemCode3.Text = "";
            txtItemCode4.Text = "";
            txtItemCode5.Text = "";
            txtItemCode6.Text = "";
            txtItemCode7.Text = "";
            txtItemCode8.Text = "";
            txtQuantityItemCode1.Text = "";
            txtQuantityItemCode2.Text = "";
            txtQuantityItemCode3.Text = "";
            txtQuantityItemCode4.Text = "";
            txtQuantityItemCode5.Text = "";
            txtQuantityItemCode6.Text = "";
            txtQuantityItemCode7.Text = "";
            txtQuantityItemCode8.Text = "";
            txtOutputCode1.Text = "";
            txtOutputCode2.Text = "";
            txtOutputCode3.Text = "";
            txtOutputCode4.Text = "";
            txtQuantityOutputCode1.Text = "";
            txtQuantityOutputCode2.Text = "";
            txtQuantityOutputCode3.Text = "";
            txtQuantityOutputCode4.Text = "";
            txtCrudeMEGQuantity.Text = "";
            txtWater.Text = "";
            txtLumps.Text = "";
            txtOverSize.Text = "";
            txtResidue.Text = "";
            txtPTAWaste.Text = "";
            txtNonUsableChips.Text = "";
            txtMEGWaste.Text = "";
            txtSilica.Text = "";
            txtCatalyst.Text = "";            

        }
        catch { }
    }

    private void ClearBreakDownDetailsTab()
    {
        try
        {
            ddlDepartment.SelectedValue = "";
            ddlMachine.SelectedValue = "";
            ddlSubMachineId.SelectedValue = "";
            ddlKKType.SelectedValue = "";
            ddlProblemCode.SelectedValue = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";            
            chkHasItAffected.Checked = false;
            txtDetailofObservations.Text = "";
        }
        catch { }
    }    

    #endregion          

    #endregion    
}