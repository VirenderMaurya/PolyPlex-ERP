using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Production_RawMaterialFeeding : System.Web.UI.Page
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
            lbl_PageHeader.Text = "Raw Material Feeding";
            DataTable dt = com.fillSearch("171");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ddl.Items.Add(new ListItem("--Select--", ""));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddl.Items.Add(new ListItem(dt.Rows[i]["Options"].ToString(), dt.Rows[i]["Value"].ToString()));
                    }
                }
            }
            GdvRawMaterialData.Visible = true;
            GdvRawMaterialData.AllowPaging = false;
            GdvRawMaterialData.DataSource = "";
            GdvRawMaterialData.DataBind();
            TxtVoucherDate.Attributes.Add("readonly", "true");
            txtVoucherNumber.Attributes.Add("readonly", "true");
            TxtVoucherDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
            BindLine();
            BindExtruder();
            BindRawMaterial();



            // binddataRawmaterial();
            LastNumber();
            ImgBtnSave.Enabled = false;
            ImgBtnAddLine.Visible = true;



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
                if (ddsearch.SelectedItem.Value == "VoucherNo")
                {
                    string id = txtSearch.Text;
                    if (id == "")
                    {
                        id = "0";
                    }
                    //Sp_Set_Prod_Raw_Material_Feeding__Headerby_VoucherNo
                    //DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Set_Prod_Raw_Material_Feeding_by_VoucherNo");
                    DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Set_Prod_Raw_Material_Feeding__Headerby_VoucherNo");
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            gridMaster.Visible = true;
                            // Gdvlookup.Visible = false;
                            gridMaster.DataSource = dt;
                            gridMaster.DataBind();
                            ModalPopupExtender1.Show();
                        }
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
        Response.Redirect("../Production/RawMaterialFeeding.aspx");
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

    protected void BindExtruder()
    {
        try
        {
            objBLLLineCode = objLineCode.Get_ExtruderCode();
            ddlExtruder.DataSource = objBLLLineCode;
            ddlExtruder.DataTextField = "ExtruderCode";
            ddlExtruder.DataValueField = "autoid";
            ddlExtruder.DataBind();
            ddlExtruder.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Raw Material feeding Form-Binding Extruder Code-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }


    protected void BindRawMaterial()
    {
        try
        {
            objBLLLineCode = objLineCode.Get_RMCode();
            ddlRawMatCode.DataSource = objBLLLineCode;
            ddlRawMatCode.DataTextField = "RMCode";
            ddlRawMatCode.DataValueField = "autoid";
            ddlRawMatCode.DataBind();
            ddlRawMatCode.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception ex)
        {
            logmessage = "Raw Material feeding Form-Binding Raw Material Code-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }


    protected void chk_CheckChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GdvRawMaterialData.Rows)
        {
            string id = ((Label)row.FindControl("lblRawMaterial")).Text;
            //  ViewState["MachineDataid"] = id;
            DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Set_Prod_Raw_Material_Feeding_by_VoucherNo");
            if (dt.Rows.Count > 0)
            {
                ddlExtruder.SelectedItem.Text = dt.Rows[0]["Extruder"].ToString();
                ddlRawMatCode.SelectedItem.Text = dt.Rows[0]["Raw_Mat_Code"].ToString();
                txtQuantity.Text = dt.Rows[0]["Qty_In_KG"].ToString();
                ImgBtnAddLine.ImageUrl = "~/Images/btnAddLineGrey.gif";
                ImgBtnAddLine.Enabled = false;
                ImgBtnSave.ImageUrl = "~/Images/btn_update.png";
            }
        }
    }
    protected void ImgBtnAddLine_Click(object sender, ImageClickEventArgs e)
    {
        int VoucherNo;
        if (ViewState["VoucherNo"] != null)
        {
            VoucherNo = Convert.ToInt32(ViewState["VoucherNo"]);
        }
        else
        {
            VoucherNo = 10;
        }
        DataTable dt = null;
        if (ViewState["Details"] != null)
        {
            dt = (DataTable)ViewState["Details"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("VoucherNo", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Line", typeof(string));
            dt.Columns.Add("Extruder", typeof(string));
            dt.Columns.Add("ExtruderCode", typeof(string));
            dt.Columns.Add("RM", typeof(string));
            dt.Columns.Add("RMCode", typeof(string));
            dt.Columns.Add("quantity", typeof(string));
            dt.Columns.Add("Remarks", typeof(string));
            //   dt.Columns.Add("ActiveStatus", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            dt.Columns.Add("CreatedOn", typeof(string));
            dt.Columns.Add("LastModifiedBy", typeof(string));
            dt.Columns.Add("LastModifiedOn", typeof(string));

        }
        DataRow drow = dt.NewRow();
        if (ViewState["Details"] != null)
        {
            drow["VoucherNo"] = 10 + VoucherNo;
        }
        else
        {
            drow["VoucherNo"] = VoucherNo;
        }
        drow["Date"] = TxtVoucherDate.Text.Trim();
        drow["Line"] = ddlLine.SelectedValue;

        drow["ExtruderCode"] = ddlExtruder.SelectedItem.Text;
        drow["Extruder"] = ddlExtruder.SelectedValue;
        drow["RM"] = ddlRawMatCode.SelectedValue;
        drow["RMCode"] = ddlRawMatCode.SelectedItem.Text;

        drow["quantity"] = txtQuantity.Text.Trim();
        drow["Remarks"] = txtRemarks.Text.Trim();
        string userid = "0";
        if (Session["userid"] != null)
        {
            userid = Session["userid"].ToString();

        }
        drow["CreatedBy"] = userid;
        drow["CreatedOn"] = TxtVoucherDate.Text.Trim();
        drow["LastModifiedBy"] = "0";
        drow["LastModifiedOn"] = "";

        dt.Rows.Add(drow);
        ViewState["Details"] = dt;
        ViewState["VoucherNo"] = drow["VoucherNo"];
        GdvRawMaterialData.Visible = true;
        GdvRawMaterialData.DataSource = dt;
        GdvRawMaterialData.DataBind();

        BindExtruder();
        BindRawMaterial();
        txtQuantity.Text = "";
        ImgBtnSave.Enabled = true;
    }

    protected void ClearLineItems()
    {
        TxtVoucherDate.Attributes.Add("readonly", "true");
        TxtVoucherDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
        BindLine();

        txtRemarks.Text = "";

    }
    protected decimal GetLastVoucherNumber()
    {
        decimal TopValueRawMaterial = objLineCode.GetRawMaterialTopVoucherNo();
        return TopValueRawMaterial;
    }

    protected void Clear()
    {
        TxtVoucherDate.Attributes.Add("readonly", "true");
        txtVoucherNumber.Attributes.Add("readonly", "true");
        TxtVoucherDate.Text = DateTime.Now.ToString(Log.GetLog().DateFormat);
        BindLine();
        BindExtruder();
        BindRawMaterial();
        binddataRawmaterial();
        LastNumber();
        txtQuantity.Text = "0";
        txtRemarks.Text = "";

    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        //////Session[userid] is use in both condition(Update and insert)
        #region Update Record
        // if (BtnSave.Text == "Update")
        if (ImgBtnSave.ImageUrl == "~/Images/btn_update.png")
        {

            if (ddlExtruder.SelectedValue == "0")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please select atleast one  checkbox from grid", 125, 300);
                return;
            
            }
            int autoid = 0;
            if (ViewState["Autoid"] != null)
            {
                autoid = Convert.ToInt32(ViewState["Autoid"]);
            }
            string userid = "0";
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();

            }

            int updatedheader = objLineCode.UpdateRawMaterialHeaderandList(autoid, txtVoucherNumber.Text, Convert.ToSByte(ddlLine.SelectedValue), txtRemarks.Text, ddlExtruder.SelectedValue, ddlRawMatCode.SelectedValue, txtQuantity.Text, userid);
            if (updatedheader > 1)
            {

                Clear();
                ImgBtnSave.ImageUrl = "~/Images/btnSave.png";
                ImgBtnSave.Enabled = false;
                ImgBtnAddLine.Visible = true;
                GdvRawMaterialData.AllowPaging = false;
                GdvRawMaterialData.DataSource = "";
                GdvRawMaterialData.DataBind();
                GdvRawMaterialData.Visible = true;
                gvRawMaterial.Visible = false;
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

                    string userid = "0";
                    if (Session["userid"] != null)
                    {
                        userid = Session["userid"].ToString();

                    }


                    string RawMaterialID = objLineCode.Insert_In_Raw_Material_Header(txtVoucherNumber.Text, TxtVoucherDate.Text, ddlLine.SelectedValue.ToString(), txtRemarks.Text, userid);





                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        if (Session["userid"] != null)
                        {
                            userid = Session["userid"].ToString();

                        }
                        booInsert = objLineCode.Insert_In_RawMaterial_ListItem(Convert.ToInt32(RawMaterialID), Convert.ToInt32(dt.Rows[i]["Extruder"].ToString()), Convert.ToInt32(dt.Rows[i]["RM"].ToString()), dt.Rows[i]["quantity"].ToString(), dt.Rows[i]["CreatedBy"].ToString());

                    }

                    if (booInsert == true)
                    {
                        Clear();
                        GdvRawMaterialData.AllowPaging = false;
                        GdvRawMaterialData.DataSource = "";
                        GdvRawMaterialData.DataBind();
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                    }
                }

            }
            ViewState["Details"] = null;
            //ClearLineItems();
            //binddataRawmaterial();
        }

    }

    protected void LastNumber()
    {
        string strSeriesLastNamber = "";
        decimal LastNumber = GetLastVoucherNumber() + 1;
        strSeriesLastNamber = LastNumber.ToString();
        if (strSeriesLastNamber == "0")
        {
            strSeriesLastNamber = "00001";
        }
        strSeriesLastNamber = CustomPad(5, '0', strSeriesLastNamber);
        txtVoucherNumber.Text = "RM" + TxtVoucherDate.Text + "-" + strSeriesLastNamber;

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


    protected void binddataRawmaterial()
    {
        objBLLLineCode = objLineCode.Get_AllDataRawMat();
        GdvRawMaterialData.DataSource = objBLLLineCode;
        GdvRawMaterialData.DataBind();
        if (GdvRawMaterialData.Rows.Count > 0)
        {
            // GridViewRow row in GdvMachineData.Rows
            foreach (GridViewRow row2 in GdvRawMaterialData.Rows)
            {
                ImageButton ImgDelete = (ImageButton)row2.FindControl("ImgDelete");
                ImgDelete.Visible = false;
            }
        }
        //
    }
    protected void GdvRawMaterialData_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    if (Convert.ToInt32(dt.Rows[i]["VoucherNo"]) == lineno)
                    {
                        dt.Rows[i].Delete();
                    }
                    i++;
                }
                if (dt.Rows.Count == 0)
                {
                    GdvVatDetails.DataSource = null;
                    GdvVatDetails.DataBind();
                }
                else
                {
                    ViewState["Details"] = dt;
                    GdvVatDetails.DataSource = dt;
                    GdvVatDetails.DataBind();
                }
            }

            if (e.CommandName == "Select")
            {
                GridView gvRawMaterial = (GridView)sender;
                GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                gvRawMaterial.SelectedIndex = row1.RowIndex;

                int Autoid = Convert.ToInt32(e.CommandArgument.ToString());
                foreach (GridViewRow oldrow in gvRawMaterial.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgSelect");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("imgSelect");
                img.ImageUrl = "~/Images/chkbxcheck.png";


                DataTable dt = com.GetVal("@Autoid", Autoid.ToString(), "Sp_Set_Prod_Raw_Material_Feeding_by_Autoid");
                ViewState["Autoid"] = Autoid;
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        ddlExtruder.SelectedValue = dt.Rows[0]["ExtruderCode"].ToString();
                        ddlRawMatCode.SelectedValue = dt.Rows[0]["RMID"].ToString();
                        txtQuantity.Text = dt.Rows[0]["Qty_In_KG"].ToString();

                    }
                }
            }
            #endregion

        }
        catch (Exception ex)
        {
            logmessage = "Raw Material Form- GdvRawMaterialData_RowCommand -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void txtVoucherNumber_TextChanged(object sender, EventArgs e)
    {
        //int Voucherno = 0;
        //if (txtVoucherNumber.Text != "")
        //{
        //    Voucherno = Convert.ToInt32(txtVoucherNumber.Text);
        //    objBLLLineCode = objLineCode.Get_RawMaterialVoucherDetails_ByVoucherId(Voucherno);
        //    GdvRawMaterialData.DataSource = objBLLLineCode;
        //    GdvRawMaterialData.DataBind();
        //    if (objBLLLineCode != null)
        //    {
        //        if (GdvRawMaterialData.Rows.Count > 0)
        //        { 
        //             // GridViewRow row in GdvMachineData.Rows
        //            foreach (GridViewRow row in GdvRawMaterialData.Rows)
        //            {
        //                RadioButton checkbx = (RadioButton)row.FindControl("checkbx");
        //                checkbx.Visible = true;
        //            }
        //        }

        //    }
        //}
        //else
        //{
        //    GdvRawMaterialData.DataSource = null;
        //    GdvRawMaterialData.DataBind();
        //}
    }
    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        string id = txtSearchList.Text;
        //  ViewState["MachineDataid"] = id;
        if (id == "")
        {
            id = "0";
        }
        DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Set_Prod_Raw_Material_Feeding__Headerby_VoucherNo");
        if (dt != null)
        {
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

    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in gridMaster.Rows)
        //{
        string id = gridMaster.SelectedDataKey.Value.ToString();
        ViewState["vno"] = id;
        //string id = ((Label)row.FindControl("lblRawMaterial")).Text;
        //  ViewState["MachineDataid"] = id;
        DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Set_Prod_Raw_Material_Feeding_by_VoucherNo");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                //ddlExtruder.SelectedItem.Text = dt.Rows[0]["Extruder"].ToString();
                //ddlRawMatCode.SelectedItem.Text = dt.Rows[0]["Raw_Mat_Code"].ToString();

                txtVoucherNumber.Text = dt.Rows[0]["VoucherNumber"].ToString(); ;
                TxtVoucherDate.Text = dt.Rows[0]["Date"].ToString(); ;

                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString(); ;
                ddlLine.SelectedValue = dt.Rows[0]["lineid"].ToString();

                gvRawMaterial.Visible = true;
                gvRawMaterial.DataSource = dt;
                gvRawMaterial.DataBind();
                GdvRawMaterialData.Visible = false;
                ImgBtnAddLine.ImageUrl = "~/Images/btnAddLineGrey.gif";
                ImgBtnAddLine.Enabled = false;
                ImgBtnSave.ImageUrl = "~/Images/btn_update.png";
                ImgBtnSave.Enabled = true;
                ImgBtnAddLine.Visible = false;


            }
        }
        // }


        if (gvRawMaterial.Rows.Count > 0)
        {
            // GridViewRow row in GdvMachineData.Rows
            foreach (GridViewRow row2 in gvRawMaterial.Rows)
            {

                ImageButton imgSelect = (ImageButton)row2.FindControl("imgSelect");
                imgSelect.Visible = true;
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
            if (ddsearch.SelectedItem.Value == "VoucherNo")
            {
                string id = txtSearch.Text;
                if (id == "")
                {
                    id = "0";
                }
                DataTable dt = com.GetVal("@VoucherNo", id, "Sp_Set_Prod_Raw_Material_Feeding__Headerby_VoucherNo");
                if (dt != null)
                {
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
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void ImgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Production/RawMaterialFeeding.aspx");
    }
    protected void ImgBtnExit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("");
    }


    protected void GdvRawMaterialData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GdvRawMaterialData.PageIndex = e.NewPageIndex;
            binddataRawmaterial();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 