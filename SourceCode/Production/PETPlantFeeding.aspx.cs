using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Production_PETPlantFeeding : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    Common com = new Common();
    BLLCollection<Prod_RawMaterialFeeding> objBLLLineCode = new BLLCollection<Prod_RawMaterialFeeding>();
    Prod_RawMaterialFeeding objLineCode = new Prod_RawMaterialFeeding();

    Common_Message commessage = new Common_Message();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
        
            
            Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lbl_PageHeader.Text = "PET Plant Feeding";
            DataTable dt = com.fillSearch("220");
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
            TxtDate.Attributes.Add("readonly", "true");
            //txtVoucherNumber.Attributes.Add("readonly", "true");
            TxtDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
            BindLine();
            BindThickness();
            BindMachnData();

        }
        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;
    }
    void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        try
        {

            if (ddsearch.SelectedValue == "")
            {
                string message = "Please select any search criteria.";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            }
            else
            {
                if (ddsearch.SelectedItem.Value == "Line")
                {
                    string id = txtSearch.Text;
                    if (id == "")
                    {
                        id = "0";
                    }
                    DataTable dt = com.GetVal("@Line", id, "Sp_Set_Prod_PET_Plant_Feeding_by_Line");
                    if (dt.Rows.Count > 0)
                    {
                        gridMaster.Visible = true;
                        // Gdvlookup.Visible = false;
                        gridMaster.DataSource = dt;
                        gridMaster.DataBind();
                        ModalPopupExtender1.Show();
                    }
                    //get datatable
                    //colimportdutybooking = objimportduty.GetAllImportDuty_Voucherno(txtSearch.Text.Trim());
                }

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Production/PETPlantFeeding.aspx");
    }
    protected void BindLine()
    {
        try
        {
            objBLLLineCode = objLineCode.Get_LineCode();
            ddlLine.DataSource = objBLLLineCode;
            ddlLine.DataTextField = "LineCode";
            ddlLine.DataValueField = "autoid";
            ddlLine.DataBind();
            ddlLine.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Raw Material feeding Form-Binding Line Code-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }


    protected void BindThickness()
    {
        try
        {
            objBLLLineCode = objLineCode.Get_Thickness();
            ddlThickness.DataSource = objBLLLineCode;
            ddlThickness.DataTextField = "Thickness";
            ddlThickness.DataValueField = "Thicknessid";
            ddlThickness.DataBind();
            ddlThickness.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Raw Material feeding Form-Binding Thickness-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void Clear()
    {
        BindLine();
        BindThickness();

        TxtDate.Attributes.Add("readonly", "true");
        //txtVoucherNumber.Attributes.Add("readonly", "true");
        TxtDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);

        txtBreak.Text = "0";
        txtCast.Text = "0";
        txtHrs.Text = "0";
        txtMM.Text = "0";
        txtLumps.Text = "0";
        txtMono.Text = "0"; ;
        txtRemarks.Text = "";

    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(txtHrs.Text) > 0)
            {

            }
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the numeric value ", 125, 300);
            txtHrs.Text = "0";
            txtHrs.Focus();
            return;
        }

        try
        {
            if (Convert.ToInt32(txtMM.Text) > 0)
            {

            }
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the numeric value ", 125, 300);
            txtMM.Text = "0";
            txtMM.Focus();
            return;
        }
        if (Convert.ToInt32(txtHrs.Text) > 23)
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct number hours", 125, 300);
            txtHrs.Text = "0";
            txtHrs.Focus();
            return;
        }

        if (Convert.ToInt32(txtMM.Text) > 59)
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the correct number minute", 125, 300);
            txtMM.Text = "0";
            txtMM.Focus();
            return;
        }
        #region Update Record
        if (ImgBtnSave.ImageUrl == "~/Images/btn_update.png")
        {
            int autoid = 0;
            if (ViewState["AUtoid"] != null)
            {
                autoid = Convert.ToInt32(ViewState["AUtoid"]);
            }
            string userid = "0";
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();

            }
            int updatedheader = objLineCode.UpdatePETPlantFeeding(autoid, Convert.ToInt32(ddlLine.SelectedValue), Convert.ToInt32(ddlThickness.SelectedValue), txtHrs.Text + ":" + txtMM.Text, txtLumps.Text, txtCast.Text, txtMono.Text, txtBreak.Text, txtRemarks.Text, userid, DateTime.Now.ToString(Log.GetLog().DateFormat));
            if (updatedheader == 1)
            {
                Clear();
                ImgBtnSave.ImageUrl = "~/Images/btnSave.png";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);

            }


        }
        #endregion
        else
        {
            string userid = "0";
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();

            }

            bool booInsert = objLineCode.savePlantRecords(TxtDate.Text, ddlLine.SelectedValue.ToString(), txtHrs.Text + ":" + txtMM.Text, ddlThickness.SelectedValue.ToString(), txtLumps.Text, txtCast.Text, txtMono.Text, txtBreak.Text, txtRemarks.Text, userid, TxtDate.Text);
            if (booInsert == true)
            {
                Clear();
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

            }
        }

    }
    protected void ImgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Production/PETPlantFeeding.aspx");
    }
    protected void ImgBtnExit_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        string id = txtSearchList.Text;
        //  ViewState["MachineDataid"] = id;

        if (id == "")
        {
            id = "0";
        }
        DataTable dt = com.GetVal("@Line", id, "Sp_Set_Prod_PET_Plant_Feeding_by_Line");
        if (dt.Rows.Count > 0)
        {
            gridMaster.Visible = true;
            // Gdvlookup.Visible = false;
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
            ModalPopupExtender1.Show();
        }
    }


    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in gridMaster.Rows)
        //{
        string id = gridMaster.SelectedDataKey.Value.ToString();
        ViewState["AUtoid"] = id;
        //string id = ((Label)row.FindControl("lblRawMaterial")).Text;
        //  ViewState["MachineDataid"] = id;
        DataTable dt = com.GetVal("@autoID", id, "Sp_Set_Prod_PET_Plant_Feeding_by_AutoID");
        if (dt.Rows.Count > 0)
        {
            string[] strpl = dt.Rows[0]["Run_Hrs_HH_Min"].ToString().Split(':');
            string strhr = strpl[0].ToString();
            string strMM = strpl[1].ToString();



            //ddlLine.SelectedItem.Text, txtHrs.Text + ":" + txtMM.Text, ddlThickness.SelectedItem.Text, txtLumps.Text, txtCast.Text, txtMono.Text, txtBreak.Text, txtRemarks.Text, "", TxtDate.Text, "", ""
            //ddlThickness.Items.Clear();
            //ddlLine.Items.Clear();
            //BindThickness();
            //BindLine();
            TxtDate.Text = Convert.ToDateTime(dt.Rows[0]["Date"].ToString()).ToString("MM/dd/yyyy");
            ddlThickness.SelectedValue = dt.Rows[0]["ThicknessID"].ToString();
            //ddlThickness.Items.FindByValue(dt.Rows[0]["ThicknessID"].ToString()).Selected = true;
            ddlLine.SelectedValue = dt.Rows[0]["lineid"].ToString();
            //ddlLine.Items.FindByValue(dt.Rows[0]["lineid"].ToString()).Selected = true;

            //ddlThickness.Items.FindByText(dt.Rows[0]["Thickness"].ToString()).Selected = true;
            //ddlLine.Items.FindByText(dt.Rows[0]["Line"].ToString()).Selected = true;


            txtHrs.Text = strhr;
            txtMM.Text = strMM;

            txtLumps.Text = dt.Rows[0]["Lumps_Waste_KG"].ToString();
            txtCast.Text = dt.Rows[0]["Cast_Waste_KG"].ToString();
            txtMono.Text = dt.Rows[0]["Mono_Waste_KG"].ToString();
            txtBreak.Text = dt.Rows[0]["Number_Of_Break"].ToString();
            txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
            ImgBtnSave.ImageUrl = "~/Images/btn_update.png";
        }
        // }



    }

    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gridMaster.PageIndex = e.NewPageIndex;
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddsearch.SelectedItem.Value == "Line")
            {
                string id = txtSearchList.Text;
                //  ViewState["MachineDataid"] = id;

                if (id == "")
                {
                    id = "0";
                }
                DataTable dt = com.GetVal("@Line", id, "Sp_Set_Prod_PET_Plant_Feeding_by_Line");
                if (dt.Rows.Count > 0)
                {
                    gridMaster.Visible = true;
                    // Gdvlookup.Visible = false;
                    gridMaster.DataSource = dt;
                    gridMaster.DataBind();
                    ModalPopupExtender1.Show();
                }
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }


    protected void gvMachinData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvMachinData.PageIndex = e.NewPageIndex;
            DataTable dt = com.GetVal("@Line", "0", "Sp_SetFromMachinData_Prod_PET_Plant_Feeding_by_Line");
            if (dt.Rows.Count > 0)
            {
                gvMachinData.Visible = true;
                // Gdvlookup.Visible = false;
                gvMachinData.DataSource = dt;
                gvMachinData.DataBind();

            }
        }

        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void gvMachinData_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = gvMachinData.SelectedDataKey.Value.ToString();
        DataTable dt = com.GetVal("@autoID", id, "Sp_Set_Prod_PET_Plant_Feeding_Intermediate_by_AutoID");
        if (dt.Rows.Count > 0)
        {
            string[] strpl = dt.Rows[0]["Run_Hrs_HH_Min"].ToString().Split(':');
            string strhr = strpl[0].ToString();
            string strMM = strpl[1].ToString();



            //ddlLine.SelectedItem.Text, txtHrs.Text + ":" + txtMM.Text, ddlThickness.SelectedItem.Text, txtLumps.Text, txtCast.Text, txtMono.Text, txtBreak.Text, txtRemarks.Text, "", TxtDate.Text, "", ""
            //ddlThickness.Items.Clear();
            //ddlLine.Items.Clear();
            //BindThickness();
            //BindLine();
            TxtDate.Text = Convert.ToDateTime(dt.Rows[0]["Date"].ToString()).ToString("MM/dd/yyyy");
            ddlThickness.SelectedValue = dt.Rows[0]["ThicknessID"].ToString();
            //ddlThickness.Items.FindByValue(dt.Rows[0]["ThicknessID"].ToString()).Selected = true;
            ddlLine.SelectedValue = dt.Rows[0]["lineid"].ToString();
            //ddlLine.Items.FindByValue(dt.Rows[0]["lineid"].ToString()).Selected = true;

            //ddlThickness.Items.FindByText(dt.Rows[0]["Thickness"].ToString()).Selected = true;
            //ddlLine.Items.FindByText(dt.Rows[0]["Line"].ToString()).Selected = true;


            txtHrs.Text = strhr;
            txtMM.Text = strMM;

            txtLumps.Text = dt.Rows[0]["Lumps_Waste_KG"].ToString();
            txtCast.Text = dt.Rows[0]["Cast_Waste_KG"].ToString();
            txtMono.Text = dt.Rows[0]["Mono_Waste_KG"].ToString();
            txtBreak.Text = dt.Rows[0]["Number_Of_Break"].ToString();
            txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
        }
    }


    protected void BindMachnData()
    {
        DataTable dt = com.GetVal("@Line", "0", "Sp_SetFromMachinData_Prod_PET_Plant_Feeding_by_Line");
        if (dt.Rows.Count > 0)
        {
            gvMachinData.Visible = true;
            // Gdvlookup.Visible = false;
            gvMachinData.DataSource = dt;
            gvMachinData.DataBind();
            lblmessage.Font.Bold = true;
            lblmessage.Text = "Records from Machine";
        }
    
    }
    protected void gvMachinData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvMachinData = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvMachinData.SelectedIndex = row.RowIndex;

            if (e.CommandName == "Select")
            {
                foreach (GridViewRow oldrow in gvMachinData.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgSelect");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("imgSelect");
                img.ImageUrl = "~/Images/chkbxcheck.png";

            

            }
        }
        catch { }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          