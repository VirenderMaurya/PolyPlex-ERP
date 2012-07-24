using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Procurement_ScarpReceived : System.Web.UI.Page
{
    #region Defind Global
    string logmessage = "";
    Common com = new Common();
    BLLCollection<Proc_ScarpReceived> objBLLObj = new BLLCollection<Proc_ScarpReceived>();
    Proc_ScarpReceived objProc = new Proc_ScarpReceived();
    Common_Message commessage = new Common_Message();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)Master.FindControl("ddlSearch");
        if (!IsPostBack)
        {
            Label lbl_PageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lbl_PageHeader.Text = "Scrap Received";
            DataTable dt = com.fillSearch("116");
            if (dt.Rows.Count > 0)
            {
                ddl.Items.Add(new ListItem("--Select--", ""));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                }
            }
            gvScarpData.AllowPaging = false;
            gvScarpData.Visible = true;
            gvScarpData.DataSource = "";
            gvScarpData.DataBind();

            txtEntryDate.Attributes.Add("readonly", "true");
            txtYear.Attributes.Add("readonly", "true");
            txtstock.Attributes.Add("readonly", "true");
            //txtQUantity.Attributes.Add("readonly", "true");
            txtEntry.Attributes.Add("readonly", "true");
            txtEntryDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
            txtYear.Text = DateTime.Now.Year.ToString() + "-" + (Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) + 1).ToString();
            ImgBtnSave.Enabled = false;
            ImgBtnAddLine.Visible = true;
            BindMaterialCode();
            BindPlant();
            BindValuetary();
            BindStorageLocation();
            LastNumber();
            //    binddataScarpReceived();

        }
        ImageButton btn_search = (ImageButton)Master.FindControl("imgbtnSearch");
        btn_search.CausesValidation = false;
        btn_search.Click += new ImageClickEventHandler(btn_search_Click);
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;
    }


    protected void binddataScarpReceived()
    {
        //DataTable dt = com.GetVal("@Line", "0", "Sp_Get_Proc_Scarp_Received");

        //gvScarpData.DataSource = dt;
        //gvScarpData.DataBind();
        //if (gvScarpData.Rows.Count > 0)
        //{
        //    // GridViewRow row in GdvMachineData.Rows
        //    foreach (GridViewRow row2 in gvScarpData.Rows)
        //    {
        //        ImageButton ImgDelete = (ImageButton)row2.FindControl("ImgDelete");
        //        ImgDelete.Visible = false;
        //    }
        //}
        //
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


    protected void BindPlant()
    {
        try
        {


            objBLLObj = objProc.Get_Plant();
            ddlPlant.DataSource = objBLLObj;
            ddlPlant.DataTextField = "PlantCode";
            ddlPlant.DataValueField = "autoid";
            ddlPlant.DataBind();
            ddlPlant.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form-Binding Plant-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void BindValuetary()
    {
        try
        {
            objBLLObj = objProc.Get_Valuatory();
            ddlvaluation.DataSource = objBLLObj;
            ddlvaluation.DataTextField = "Valuetype";
            ddlvaluation.DataValueField = "autoId";
            ddlvaluation.DataBind();
            ddlvaluation.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form-Binding Valuation type-Error-" + ex.ToString();
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
                if (ddsearch.SelectedItem.Value == "EntryNo")
                {
                    string id = txtSearch.Text;
                    if (id == "")
                    {
                        id = "0";
                    }
                    DataTable dt = com.GetVal("@EntryNo", id, "Sp_Get_Proc_Scarp_Received_HeaderbyEnteryNo");
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
        Response.Redirect("../Procurement/ScarpReceived.aspx");
    }

    protected void gvScarpData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (ViewState["Details"] != null)
            {
                DataTable dt = (DataTable)ViewState["Details"];
                gvScarpData.PageIndex = e.NewPageIndex;
                gvScarpData.DataSource = dt;
                gvScarpData.DataBind();
            }
            else
            {
                gvScarpData.PageIndex = e.NewPageIndex;
                binddataScarpReceived();
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void gvScarpData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        #region Update Record

        if (ddlMaterialcode.SelectedValue == "0")
        {

            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please select atleast one checkbox from grid", 125, 300);
            return;
        }

        // if (BtnSave.Text == "Update")
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

            int updatedheader = objProc.UpdateScrapReceived(autoid, Convert.ToInt32(ddlMaterialcode.SelectedValue), Convert.ToInt32(ddlPlant.SelectedValue), Convert.ToInt32(ddlvaluation.SelectedValue), Convert.ToInt32(ddlStorageLocation.SelectedValue), txtQUantity.Text, txtstock.Text, userid);
            if (updatedheader == 1)
            {

                ClearLineItems();
                ImgBtnSave.ImageUrl = "~/Images/btnSave.png";
                ImgBtnSave.Enabled = false;
                ImgBtnAddLine.Visible = true;
                gvScarp.Visible = false;
                gvScarpData.Visible = true;
                gvScarpData.AllowPaging = false;
                gvScarpData.DataSource = "";
                gvScarpData.DataBind();
                binddataScarpReceived();
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
                    int voucherno = 0;
                    //  int LastNumber = Convert.ToInt32(txtEntry.Text);


                    string userid = "0";
                    if (Session["userid"] != null)
                    {
                        userid = Session["userid"].ToString();

                    }


                    string Scarpid = objProc.Insert_In_Scarp_Received_Header(txtYear.Text, txtEntry.Text, txtEntryDate.Text, userid);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        if (Session["userid"] != null)
                        {
                            userid = Session["userid"].ToString();

                        }

                        booInsert = objProc.saveRecordsinScrapReceived(Convert.ToInt32(Scarpid), dt.Rows[i]["Line"].ToString(), dt.Rows[i]["MaterialCodeID"].ToString(), dt.Rows[i]["PlantID"].ToString(), dt.Rows[i]["ValuationTypeID"].ToString(), dt.Rows[i]["StorageLocationID"].ToString(), dt.Rows[i]["Quantity"].ToString(), dt.Rows[i]["Stock"].ToString(), dt.Rows[i]["Status"].ToString(), dt.Rows[i]["CreatedBy"].ToString());

                    }

                    if (booInsert == true)
                    {
                        ClearLineItems();
                        binddataScarpReceived();
                        gvScarpData.AllowPaging = false;
                        gvScarpData.Visible = true;
                        gvScarpData.DataSource = "";
                        gvScarpData.DataBind();


                        ImgBtnSave.Enabled = false;
                        ImgBtnAddLine.Visible = true;
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                    }
                }

            }
            ViewState["Details"] = null;
        }
    }
    protected void ImgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Procurement/ScarpReceived.aspx");
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        string id = txtSearchList.Text;
        //  ViewState["MachineDataid"] = id;

        if (id == "")
        {
            id = "0";
        }
        DataTable dt = com.GetVal("@EntryNo", id, "Sp_Get_Proc_Scarp_Received_HeaderbyEnteryNo");
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
       // ViewState["AUtoid"] = id;
        //string id = ((Label)row.FindControl("lblRawMaterial")).Text;
        //  ViewState["MachineDataid"] = id;
        DataTable dt = com.GetVal("@ScrapID", id, "Sp_Get_Proc_Scarp_Received_Details");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                txtEntry.Text = dt.Rows[0]["entry"].ToString();
                txtYear.Text = dt.Rows[0]["Year"].ToString();
                txtEntryDate.Text = dt.Rows[0]["entrydate"].ToString();


                //BindMaterialCode();
                //ddlMaterialcode.SelectedValue = dt.Rows[0]["MaterialCodeid"].ToString();
                //BindPlant();
                //ddlPlant.SelectedValue = dt.Rows[0]["Plantid"].ToString();
                //BindValuetary();
                //ddlvaluation.SelectedValue = dt.Rows[0]["ValuationTypeid"].ToString();
                //BindStorageLocation();
                //ddlStorageLocation.SelectedValue = dt.Rows[0]["StorageLocationid"].ToString();
                //txtQUantity.Text = dt.Rows[0]["Quantity"].ToString();
                //txtstock.Text = dt.Rows[0]["StockOUM"].ToString();
                ImgBtnSave.ImageUrl = "~/Images/btn_update.png";
                ImgBtnSave.Enabled = true;
                ImgBtnAddLine.Visible = false;

                gvScarp.Visible = true;
                gvScarpData.Visible = false;
                gvScarp.DataSource = dt;
                gvScarp.DataBind();

                if (gvScarp.Rows.Count > 0)
                {
                    // GridViewRow row in GdvMachineData.Rows
                    foreach (GridViewRow row2 in gvScarp.Rows)
                    {
                        ImageButton imgSelect = (ImageButton)row2.FindControl("imgSelect");
                        imgSelect.Visible = true;
                    }
                }
            }

        }


    }

    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gridMaster.PageIndex = e.NewPageIndex;
            DropDownList ddsearch = (DropDownList)Master.FindControl("ddlSearch");
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            if (ddsearch.SelectedItem.Value == "EntryNo")
            {
                string id = txtSearch.Text;
                if (id == "")
                {
                    id = "0";
                }
                DataTable dt = com.GetVal("@EntryNo", id, "Sp_Get_Proc_Scarp_Received_HeaderbyEnteryNo");
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
            txtstock.Text = dt.Rows[0]["StockUnit"].ToString();
        }
    }
    protected void ImgBtnAddLine_Click(object sender, ImageClickEventArgs e)
    {
        int Line = 0;
        if (ViewState["Line"] != null)
        {
            Line = Convert.ToInt32(ViewState["Line"]);
        }
        else
        {
            //  Line = Convert.ToInt32(GetLastLineNumber());
            //  if (Line == 0)
            //   {
            Line = 10;
            //   }

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
            dt.Columns.Add("ValuationType", typeof(string));
            dt.Columns.Add("ValuationTypeID", typeof(string));
            dt.Columns.Add("Plant", typeof(string));
            dt.Columns.Add("PlantID", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("StorageLocation", typeof(string));
            dt.Columns.Add("StorageLocationID", typeof(string));
            dt.Columns.Add("Stock", typeof(string));
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
            drow["Line"] = 10; //+ Line;
        }
        drow["MaterialCode"] = ddlMaterialcode.SelectedItem.Text;
        drow["MaterialCodeID"] = ddlMaterialcode.SelectedValue;
        drow["ValuationType"] = ddlvaluation.SelectedItem.Text;
        drow["ValuationTypeID"] = ddlvaluation.SelectedValue;

        drow["Plant"] = ddlPlant.SelectedItem.Text;
        drow["PlantID"] = ddlPlant.SelectedValue;
        drow["Quantity"] = txtQUantity.Text;

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
        drow["CreatedOn"] = txtEntryDate.Text.Trim();
        drow["LastModifiedBy"] = "0";
        drow["LastModifiedOn"] = "";
        drow["Stock"] = txtstock.Text;
        dt.Rows.Add(drow);
        ViewState["Details"] = dt;
        ViewState["Line"] = drow["Line"];
        gvScarpData.Visible = true;
        gvScarpData.AllowPaging = true;
        gvScarpData.DataSource = dt;
        gvScarpData.DataBind();
        ClearLineItems();
        ImgBtnSave.Enabled = true;
    }

    protected void ClearLineItems()
    {
        txtEntryDate.Attributes.Add("readonly", "true");
        txtYear.Attributes.Add("readonly", "true");
        txtstock.Attributes.Add("readonly", "true");
        //txtQUantity.Attributes.Add("readonly", "true");
        txtEntry.Attributes.Add("readonly", "true");
        txtEntryDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
        txtYear.Text = DateTime.Now.Year.ToString() + "-" + (Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) + 1).ToString();
        BindMaterialCode();
        BindPlant();
        BindValuetary();
        BindStorageLocation();
        //  binddataScarpReceived();
        LastNumber();
        txtstock.Text = "";
        txtQUantity.Text = "";
    }
    protected void gvScarpData_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    gvScarpData.DataSource = null;
                    gvScarpData.DataBind();
                }
                else
                {
                    ViewState["Details"] = dt;
                    gvScarpData.DataSource = dt;
                    gvScarpData.DataBind();
                }
            }
            #endregion
            if (e.CommandName == "Select")
            {
                GridView gvRawMaterial = (GridView)sender;
                GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                gvRawMaterial.SelectedIndex = row1.RowIndex;

            
                foreach (GridViewRow oldrow in gvRawMaterial.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgSelect");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("imgSelect");
                img.ImageUrl = "~/Images/chkbxcheck.png";
                int Autoid = Convert.ToInt32(e.CommandArgument.ToString());


                //string id = gridMaster.SelectedDataKey.Value.ToString();
                ViewState["AUtoid"] = Autoid.ToString();
                //string id = ((Label)row.FindControl("lblRawMaterial")).Text;
                //  ViewState["MachineDataid"] = id;
                DataTable dt = com.GetVal("@autoID", Autoid.ToString(), "Sp_Get_Proc_Scarp_Received_Autoid");
                if (dt.Rows.Count > 0)
                {

                    BindMaterialCode();
                    ddlMaterialcode.SelectedValue = dt.Rows[0]["MaterialCodeid"].ToString();
                    BindPlant();
                    ddlPlant.SelectedValue = dt.Rows[0]["Plantid"].ToString();
                    BindValuetary();
                    ddlvaluation.SelectedValue = dt.Rows[0]["ValuationTypeid"].ToString();
                    BindStorageLocation();
                    ddlStorageLocation.SelectedValue = dt.Rows[0]["StorageLocationid"].ToString();
                    txtQUantity.Text = dt.Rows[0]["Quantity"].ToString();
                    txtstock.Text = dt.Rows[0]["StockOUM"].ToString();
                }

            }

        }
        catch (Exception ex)
        {
            logmessage = "Scarp Received Form- gvScarpData_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void LastNumber()
    {
        decimal LastNumber = GetLastEntryNumber() + 1;

        string strSeriesLastNamber = "";
        strSeriesLastNamber = LastNumber.ToString();
        if (strSeriesLastNamber == "0")
        {
            strSeriesLastNamber = "00001";
        }
        strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
        txtEntry.Text = strSeriesLastNamber;
        //if (LastNumber == 0)
        //{
        //    txtEntry.Text = "1";
        //}
        //else
        //{
        //    txtEntry.Text = (LastNumber + 1).ToString();
        //}
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


    protected decimal GetLastEntryNumber()
    {
        decimal TopValueScarpReceived = objProc.GetScarpTopEntryNo();
        return TopValueScarpReceived;
    }

    protected decimal GetLastLineNumber()
    {
        decimal TopValueScarpReceived = objProc.GetScarpTopLineNo();
        if (TopValueScarpReceived == 0)
        {
            TopValueScarpReceived = 0;
        }
        return TopValueScarpReceived;
    }


}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     