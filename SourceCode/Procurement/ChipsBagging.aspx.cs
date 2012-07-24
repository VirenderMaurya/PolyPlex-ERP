using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_ChipsBagging : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    Common com = new Common();
    BLLCollection<Proc_ScarpReceived> objBLLObj = new BLLCollection<Proc_ScarpReceived>();
    Proc_ScarpReceived objProc = new Proc_ScarpReceived();
  
    BLLCollection<Proc_ChipsBagging> objBLLObjChips = new BLLCollection<Proc_ChipsBagging>();
    Proc_ChipsBagging objProc_Chips = new Proc_ChipsBagging();
    Common_Message commessage = new Common_Message();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
            Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lbl_PageHeader.Text = "Chips Bagging";

            gvChipsBagging.AllowPaging = false;
            gvChipsBagging.DataSource = "";
            gvChipsBagging.DataBind();
            

            DataTable dt = com.fillSearch("20");
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
            txtBaggingDate.Attributes.Add("readonly", "true");
            txtYear.Attributes.Add("readonly", "true");
            txtVrNumber.Attributes.Add("readonly", "true");
            
            txtUOM.Attributes.Add("readonly", "true");
            txtBaggingDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
            txtYear.Text = DateTime.Now.Year.ToString() + "-" + (Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) + 1).ToString();
            string strSeriesLastNamber = "";
            decimal LastNumber = GetLastSeriesNumber() + 1;
            strSeriesLastNamber = LastNumber.ToString();
            if (strSeriesLastNamber == "0")
            {
                strSeriesLastNamber = "00001";
            }
           strSeriesLastNamber=CustomPad(5, '0', strSeriesLastNamber);
            txtVrNumber.Text = "CB" + txtYear.Text + "-" + strSeriesLastNamber;
            BindMaterialCode();
           
            BindStorageLocation();
            ImgBtnSave.Enabled = false;
            
           // LastNumber();
        }
        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;
    }


    private string CustomPad(int iNoOfCharToPad, char sPadChar, string sString)
    {
        string sPadStr = "";

        if (sString.Length < iNoOfCharToPad)
        {
            for (int i = 0; i < iNoOfCharToPad - sString.Length; i++)
            {
                sPadStr += sPadChar;
            }
            sPadStr += sString;
        }
        else
        {
            sPadStr = sString;
        }

        return sPadStr;
    }


    protected void BindMaterialCode()
    {
        try
        {
            objBLLObj = objProc.Get_MaterialCode();
            ddlMaterialcode.DataSource = objBLLObj;
            ddlMaterialcode.DataTextField = "Code";
            ddlMaterialcode.DataValueField = "autoid";
            ddlMaterialcode.DataBind();
            ddlMaterialcode.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form-Binding Material Code-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }


   
   

    protected void BindStorageLocation()
    {
        try
        {
            objBLLObj = objProc.Get_StorageLocation();
            ddlStorageLocation.DataSource = objBLLObj;
            ddlStorageLocation.DataTextField = "StorageLocCode";
            ddlStorageLocation.DataValueField = "autoid";
            ddlStorageLocation.DataBind();
            ddlStorageLocation.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form-Binding Material Code-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
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
                if (ddsearch.SelectedItem.Value == "VoucherNo")
                {
                    string id = txtSearch.Text;
                    if (id == "")
                    {
                        id = "0";
                    }
                    DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Proc_Chips_Bagging");
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
        Response.Redirect("../Procurement/ChipsBagging.aspx");
    }

    protected void gvMachinData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvMachinData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
           #region Update Record
        // if (BtnSave.Text == "Update")
        if (ImgBtnSave.ImageUrl == "~/Images/btn_update.png")
        {
            string  VoucherNumber="";;
            if (ViewState["AUtoid"] != null)
            {
                VoucherNumber = ViewState["AUtoid"].ToString();
            }
            string userid = "0";
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();

            }

            int updatedheader = objProc_Chips.UpdateChipsBagging(VoucherNumber, Convert.ToInt32(ddlMaterialcode.SelectedValue), txtUOM.Text, Convert.ToInt32(ddlStorageLocation.SelectedValue), txtChipsBags.Text, txtQuantityBags.Text, userid);
            if (updatedheader > 0)
            {

                ClearLineItems();
                ImgBtnSave.ImageUrl = "~/Images/btnSave.png";
                ImgBtnSave.Enabled = false;
                txtQuantityBags.Enabled = true;
                gvChipsBagging.AllowPaging = false;
                gvChipsBagging.DataSource = "";
                gvChipsBagging.DataBind();
            
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);

            }


        }
           #endregion
        else
        {
            if (ViewState["Details"] != null)
            {
                bool booInsert = false;
                DataTable dt = (DataTable)ViewState["Details"];
                if (dt.Rows.Count > 0)
                {
                    string VoucherNumber = "";
                    VoucherNumber = txtVrNumber.Text;


                    string userid = "0";
                    if (Session["userid"] != null)
                    {
                        userid = Session["userid"].ToString();

                    }

                    int SeriesNumber = 0;
                    SeriesNumber = Convert.ToInt32(GetLastSeriesNumber());
                    SeriesNumber = SeriesNumber + 1;
                    string Chipsid = objProc_Chips.Insert_In_Chip_Bagging_Header(SeriesNumber, txtYear.Text, VoucherNumber, txtBaggingDate.Text, userid);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        if (Session["userid"] != null)
                        {
                            userid = Session["userid"].ToString();

                        }

                        booInsert = objProc_Chips.saveRecordsinChipsBagging(Convert.ToInt32(Chipsid), dt.Rows[i]["Line"].ToString(), dt.Rows[i]["MaterialCodeID"].ToString(), dt.Rows[i]["UOM"].ToString(), dt.Rows[i]["StorageLocationID"].ToString(), dt.Rows[i]["BagNo"].ToString(), dt.Rows[i]["Quantity"].ToString(), dt.Rows[i]["StatusBit"].ToString(), dt.Rows[i]["CreatedBy"].ToString());

                    }

                    if (booInsert == true)
                    {
                        ClearLineItems();
                        gvChipsBagging.AllowPaging = false;
                        gvChipsBagging.DataSource = "";
                        gvChipsBagging.DataBind();
            

                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                    }
                }

            }
        }
        ViewState["Details"] = null;
    }

    protected void ClearLineItems()
    {
        txtBaggingDate.Attributes.Add("readonly", "true");
        txtYear.Attributes.Add("readonly", "true");
        txtVrNumber.Attributes.Add("readonly", "true");

        txtUOM.Attributes.Add("readonly", "true");
        txtBaggingDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
        txtYear.Text = DateTime.Now.Year.ToString() + "-" + (Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) + 1).ToString();
        string strSeriesLastNamber = "";
        decimal LastNumber = GetLastSeriesNumber() + 1;
        strSeriesLastNamber = LastNumber.ToString();
        
        if (strSeriesLastNamber == "0")
        {
            strSeriesLastNamber = "00001";
        }
        strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
        txtVrNumber.Text = "CB" + txtYear.Text + "-" + strSeriesLastNamber;
        BindMaterialCode();

        BindStorageLocation();
        
        
        txtUOM.Text = "";
        txtQuantityBags.Text = "";
        txtChipsBags.Text = "";
    }
    protected void ImgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Procurement/ChipsBagging.aspx");
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        string id = txtSearchList.Text;
        //  ViewState["MachineDataid"] = id;

       
            if (id == "")
            {
                id = "0";
            }
            DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Proc_Chips_Bagging");
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


    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in gridMaster.Rows)
        //{
        string id = gridMaster.SelectedDataKey.Value.ToString();
        ViewState["AUtoid"] = id;
        //string id = ((Label)row.FindControl("lblRawMaterial")).Text;
        //  ViewState["MachineDataid"] = id;
        DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Proc_Chips_Bagging_By_Autoid");
        if (dt.Rows.Count > 0)
        {
            txtYear.Text = dt.Rows[0]["YEAR"].ToString();
            txtVrNumber.Text = dt.Rows[0]["VRNumber"].ToString();

            txtBaggingDate.Text = dt.Rows[0]["baggingdate"].ToString();
          
            ddlMaterialcode.SelectedValue = dt.Rows[0]["MaterialCodeID"].ToString();
            txtUOM.Text = dt.Rows[0]["UOM"].ToString();//
            ddlStorageLocation.SelectedValue = dt.Rows[0]["StorageLocationID"].ToString();
            txtChipsBags.Text = dt.Rows[0]["BagNo"].ToString();
            txtQuantityBags.Text = dt.Rows[0]["Quantity"].ToString();
            txtQuantityBags.AutoPostBack = false;
            txtQuantityBags.Enabled = false;
            ImgBtnSave.ImageUrl = "~/Images/btn_update.png";
            ImgBtnSave.Enabled = true;
            gvChipsBagging.DataSource = dt;
            gvChipsBagging.DataBind();

            if (gvChipsBagging.Rows.Count > 0)
            {
                // GridViewRow row in GdvMachineData.Rows
                foreach (GridViewRow row2 in gvChipsBagging.Rows)
                {
                    ImageButton ImgDelete = (ImageButton)row2.FindControl("ImgDelete");
                    ImgDelete.Visible = false;
                }
            }
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

            if (ddsearch.SelectedItem.Value == "VoucherNo")
            {
                string id = txtSearch.Text;
                if (id == "")
                {
                    id = "0";
                }
                DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Get_Proc_Chips_Bagging");
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
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    protected void ddlMaterialcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ddlMaterialcode.SelectedValue.ToString();
        DataTable dt = com.GetVal("@MaterialCode", id, "Sp_Set_Proc_ScarpReceived_by_MaterialCode");
        if (dt.Rows.Count > 0)
        {
            txtUOM.Text = dt.Rows[0]["StockUnit"].ToString();
        }
    }
    protected void txtQuantityBags_TextChanged(object sender, EventArgs e)
    {


        if (ddlMaterialcode.SelectedValue == "0")
        {
         
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success,"Please Select the material code!", 125, 300);
            txtQuantityBags.Text = "";
            ddlMaterialcode.Focus();
                return;
        }
        if (ddlStorageLocation.SelectedValue == "0")
        {
          
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select the Storage location!", 125, 300);
            txtQuantityBags.Text = "";
            ddlStorageLocation.Focus();
            return;
        }
        if (txtChipsBags.Text == "")
        {
         
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please enter the chips bags!", 125, 300);
            txtQuantityBags.Text = "";
            txtChipsBags.Focus();
            return;
        }



        ViewState["Line"] = null;

        ViewState["Details"] = null;
        gvChipsBagging.DataSource = null;
        gvChipsBagging.DataBind();
        int Line = 0;

        int NumberChipsBugs = 0;
        NumberChipsBugs = Convert.ToInt32(txtQuantityBags.Text);

        for (int i = 0; i < NumberChipsBugs; i++)
        {

            if (ViewState["Line"] != null)
            {
                Line = Convert.ToInt32(ViewState["Line"]);
            }
            else
            {
               // Line = Convert.ToInt32(GetLastLineNumber());
               // if (Line == 0)
                //{
                    Line = 10;
               // }

            }
            DataTable dt = null;
            if (ViewState["Details"] != null)
            {
                dt = (DataTable)ViewState["Details"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Line", typeof(int));
                dt.Columns.Add("MaterialCode", typeof(string));
                dt.Columns.Add("MaterialCodeID", typeof(string));
                dt.Columns.Add("BagNo", typeof(string));
                dt.Columns.Add("UOM", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));
                dt.Columns.Add("StorageLocation", typeof(string));
                dt.Columns.Add("StorageLocationID", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("StatusBit", typeof(string));
                dt.Columns.Add("CreatedBy", typeof(string));
                dt.Columns.Add("CreatedOn", typeof(string));
                dt.Columns.Add("LastModifiedBy", typeof(string));
                dt.Columns.Add("LastModifiedOn", typeof(string));

            }
            DataRow drow = dt.NewRow();
            if (ViewState["Details"] != null)
            {
                drow["Line"] = 10 + Line;
            }
            else
            {
                drow["Line"] = 10 ;
            }
            drow["MaterialCode"] = ddlMaterialcode.SelectedItem.Text;
            drow["MaterialCodeID"] = ddlMaterialcode.SelectedValue;
            drow["BagNo"] = txtChipsBags.Text;
            drow["UOM"] = txtUOM.Text;


            drow["Quantity"] = txtQuantityBags.Text;

            drow["StorageLocation"] = ddlStorageLocation.SelectedItem.Text;

            drow["StorageLocationID"] = ddlStorageLocation.SelectedValue;
            drow["Status"] = "True";
            drow["StatusBit"] = "1";

            string userid = "0";
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();

            }
            drow["CreatedBy"] = userid;
            drow["CreatedOn"] = txtBaggingDate.Text.Trim();
            drow["LastModifiedBy"] = "0";
            drow["LastModifiedOn"] = "";

            dt.Rows.Add(drow);
            ViewState["Details"] = dt;
            ViewState["Line"] = drow["Line"];
            gvChipsBagging.DataSource = dt;
            gvChipsBagging.DataBind();
            gvChipsBagging.AllowPaging =true;
            // ClearLineItems();
            ImgBtnSave.Enabled = true;
        }
    }


    protected decimal GetLastLineNumber()
    {
        decimal TopValueChipsBaggingLine = objProc_Chips.GetChipsTopLineNo();
        if (TopValueChipsBaggingLine == 0)
        {
            TopValueChipsBaggingLine = 0;
        }
        return TopValueChipsBaggingLine;
    }

    protected void gvChipsBagging_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["Details"];
            gvChipsBagging.PageIndex = e.NewPageIndex;
            gvChipsBagging.DataSource = dt;
            gvChipsBagging.DataBind();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void gvChipsBagging_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView GdvVatDetails = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            GdvVatDetails.SelectedIndex = row.RowIndex;

            #region Row Deleting in temp table
            if (e.CommandName == "del")
            {
                int lineno = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["Details"];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    if (Convert.ToInt32(dt.Rows[i]["Line"]) == lineno)
                    {
                        dt.Rows[i].Delete();
                    }
                    i++;
                }
                if (dt.Rows.Count == 0)
                {
                    gvChipsBagging.DataSource = null;
                    gvChipsBagging.DataBind();
                }
                else
                {
                    ViewState["Details"] = dt;
                    gvChipsBagging.DataSource = dt;
                    gvChipsBagging.DataBind();
                }
            }
            #endregion

        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form- gvChipsBagging_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void gvChipsBagging_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected decimal GetLastSeriesNumber()
    {
        decimal TopValueSeriesNumber = objProc_Chips.GetLastSeriesNumber();
        if (TopValueSeriesNumber == 0)
        {
            TopValueSeriesNumber = 0;
        }

        return TopValueSeriesNumber;


    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    