using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Production_SlitMacArmMapMaster : System.Web.UI.Page
{
    Common_Message objMsg = new Common_Message();
    MasterFormControl obj = new MasterFormControl();
    static int iFlag = 0;
    string xml = "SlitMachinMappingMaster.xml";
    string tablename = "Prod_SlitMachine_Arm_Mapping_Mst";
    string tablePrimarykey = "autoid";
    string tableCode = "MappingCode";
    string aspxPageModuleID = "217";
    string pageHeading = "Slit Machine-Arm Mapping Master";

    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButton btn_next = (ImageButton)Master.FindControl("btn_nxt");
        btn_next.Click += new ImageClickEventHandler(btn_next_Click);
        btn_next.CausesValidation = false;

        ImageButton btn_pre = (ImageButton)Master.FindControl("btn_pre");
        btn_pre.Click += new ImageClickEventHandler(btn_pre_Click);
        btn_pre.CausesValidation = false;

        ImageButton btn_add = (ImageButton)Master.FindControl("btn_Add");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        btn_add.CausesValidation = false;

        ImageButton btn_save = (ImageButton)Master.FindControl("btn_save");
        btn_save.Click += new ImageClickEventHandler(btn_save_Click);
        btn_save.ValidationGroup = "aa";
        btn_save.Visible = false;

        ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
        btn_Search.Click += new ImageClickEventHandler(btn_Search_Click);
        btn_Search.CausesValidation = false;

        ImageButton btn_Cancel = (ImageButton)Master.FindControl("btn_cancel");
        btn_Cancel.Click += new ImageClickEventHandler(btn_Cancel_Click);
        btn_Cancel.CausesValidation = false;
        btn_Cancel.Visible = false;

        ImageButton btn_Edit = (ImageButton)Master.FindControl("btn_edit");
        btn_Edit.Click += new ImageClickEventHandler(btn_Edit_Click);
        btn_Edit.CausesValidation = false;

        if (!IsPostBack)
        {
            if (Session["UserID"] == null)
            {
                Server.Transfer("../SessionExpired.aspx");

            }
            else
            {
                setDBParameterAll();
                fillSearch();
                hf_IsNewRecord.Value = "false";
                lbl_Heading.Text = pageHeading;
                lbl_gridHeading.Text = pageHeading;
                int ti = obj.getPositionID(iFlag, tablePrimarykey);
                hf_code.Value = ti.ToString();

            }
        }
        int tid = obj.getPositionID(iFlag, tablePrimarykey);
        createformAll(tid);

    }

    void btn_Edit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            string[] usrright = obj.getUserRights(Session["UserID"].ToString(), aspxPageModuleID);
            if (usrright[2] == "0")
            {
                string message = objMsg.RightsToModify;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, message, 125, 300);
            }
            else
            {
                int tid = int.Parse(hf_code.Value);
                createformAll(tid);
                masterControlInvisible("btn_nxt");
                masterControlInvisible("btn_pre");
                masterControlVisible("btn_save");
                masterControlVisible("btn_cancel");
                EnableAllControls(true);
                ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
                btn_Search.Enabled = false;
                hf_IsNewRecord.Value = "false";
            }
        }
        catch (Exception ex)
        {
        }

    }

    void fillSearch()
    {
        ListItem[] list = obj.fillSearchDropDown(aspxPageModuleID);
        DropDownList ddl = (DropDownList)Master.FindControl("dd_search");
        for (int i = 0; i < list.Length; i++)
        {
            ddl.Items.Add(list[i]);
        }
    }

    void btn_Cancel_Click(object sender, ImageClickEventArgs e)
    {

        hf_IsNewRecord.Value = "false";
        setDBParameterAll();
        int tid = int.Parse(hf_code.Value);
        createformAll(tid);
        masterControlVisible("btn_nxt");
        masterControlVisible("btn_pre");
        masterControlInvisible("btn_save");
        masterControlInvisible("btn_cancel");
        EnableAllControls(false);
        ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
        btn_Search.Enabled = true;



    }

    void btn_Search_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddsearch = (DropDownList)Master.FindControl("dd_search");
        TextBox txtSearch = (TextBox)Master.FindControl("txt_search");

        DataTable dt = obj.searchResults(xml, tablename, ddsearch.SelectedValue, txtSearch.Text.Trim(), tablePrimarykey);
        gridMaster.DataSource = dt;
        gridMaster.DataBind();

        ModalPopupExtender1.Show();
    }

    protected void btn_next_Click(object sender, EventArgs e)
    {
        ImageButton imgbtn = (ImageButton)Master.FindControl("btn_nxt");
        imgbtn.ImageUrl = "~/Images/btn_next.png";
        ImageButton imgbtnpre = (ImageButton)Master.FindControl("btn_pre");
        imgbtnpre.ImageUrl = "~/Images/btn_previous.png";
        int[] a = obj.increaseRow(iFlag);
        iFlag = a[0];
        int tid = obj.getPositionID(iFlag, tablePrimarykey);
        hf_code.Value = tid.ToString();
        createformAll(tid);
        int color = a[1];
        if (color == 0)
        {

            imgbtn.ImageUrl = "~/Images/btnNextGrey.png";

        }


    }

    protected void btn_pre_Click(object sender, EventArgs e)
    {
        ImageButton imgbtn = (ImageButton)Master.FindControl("btn_nxt");
        imgbtn.ImageUrl = "~/Images/btn_next.png";
        ImageButton imgbtnpre = (ImageButton)Master.FindControl("btn_pre");
        imgbtnpre.ImageUrl = "~/Images/btn_previous.png";
        int[] a = obj.decreaseRow(iFlag);
        iFlag = a[0];
        int tid = obj.getPositionID(iFlag, tablePrimarykey);
        hf_code.Value = tid.ToString();
        createformAll(tid);
        int color = a[1];
        if (color == 0)
        {

            imgbtnpre.ImageUrl = "~/Images/btnPreviousGrey.png";
        }


    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {

            string[] usrright = obj.getUserRights(Session["UserID"].ToString(), aspxPageModuleID);
            if (usrright[1] == "0")
            {
                string message = objMsg.RightsToWrite;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, message, 125, 300);
            }
            else
            {


                masterControlInvisible("btn_nxt");
                masterControlInvisible("btn_pre");
                masterControlVisible("btn_save");
                masterControlVisible("btn_cancel");
                ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
                btn_Search.Enabled = false;
                hf_IsNewRecord.Value = "true";
                obj.createEmptyForm();
                ((TextBox)pnl_Master.FindControl(tableCode)).Text = obj.getNewKey(tableCode, tablename);
                EnableAllControls(true);

            }
        }
        catch (Exception ex)
        {
        }

    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (hf_IsNewRecord.Value == "true")
        {

            if (obj.saveRecords(tablename))
            {
                string message = objMsg.RecordSaved;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
                setDBParameterAll();
                int tid = int.Parse(hf_code.Value);
                createformAll(tid);
                masterControlVisible("btn_nxt");
                masterControlVisible("btn_pre");
                masterControlInvisible("btn_save");
                masterControlInvisible("btn_cancel");
                hf_IsNewRecord.Value = "false";
                EnableAllControls(false);
                ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
                btn_Search.Enabled = true;




            }
            else
            {
                string message = objMsg.RecordNotSaved;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);

            }
        }
        else if (hf_IsNewRecord.Value == "false")
        {
            if (obj.updateRecords(tablename, tablePrimarykey, hf_code.Value))
            {
                string message = objMsg.UpdatedRecord;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
                setDBParameterAll();
                int tid = obj.getPositionID(iFlag, tablePrimarykey);
                createformAll(tid);
                masterControlVisible("btn_nxt");
                masterControlVisible("btn_pre");
                masterControlInvisible("btn_save");
                masterControlInvisible("btn_cancel");
                hf_IsNewRecord.Value = "false";
                EnableAllControls(false);
                ImageButton btn_Search = (ImageButton)Master.FindControl("btn_search");
                btn_Search.Enabled = true;
            }
            else
            {
                string message = objMsg.RecordNotUpdated;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);

            }
        }
    }

    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string DataKey = gridMaster.SelectedDataKey.Value.ToString();
        hf_code.Value = DataKey;
        createformAll(int.Parse(DataKey));


    }

    protected void createformAll(int tid)
    {

        obj.createForm(pnl_Master, xml, tid, tablePrimarykey);
        EnableAllControls(false);
    }

    protected void setDBParameterAll()
    {
        obj.SetDBParameter(tablename);
    }

    private void EnableAllControls(bool status)
    {

        foreach (Control ctrl in pnl_Master.Controls)
            if (ctrl is TextBox)

                ((TextBox)ctrl).Enabled = status;

            else if (ctrl is CheckBox)

                ((CheckBox)ctrl).Enabled = status;

            else if (ctrl is DropDownList)

                ((DropDownList)ctrl).Enabled = status;

        TextBox txt_primary = (TextBox)pnl_Master.FindControl(tableCode);
        txt_primary.Enabled = false;

    }

    protected void masterControlInvisible(string id)
    {
        ImageButton btn_master = (ImageButton)Master.FindControl(id);
        btn_master.Visible = false;
    }

    protected void masterControlVisible(string id)
    {
        ImageButton btn_master = (ImageButton)Master.FindControl(id);
        btn_master.Visible = true;
    }

    protected void gridMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            e.Row.Cells[1].Visible = false;
        }
        catch (Exception ex)
        {
        }

    }

    protected void gridMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridMaster.PageIndex = e.NewPageIndex;
        DropDownList ddsearch = (DropDownList)Master.FindControl("dd_search");
        TextBox txtSearch = (TextBox)Master.FindControl("txt_search");
        DataTable dt = obj.searchResults(xml, tablename, ddsearch.SelectedValue, txtSearch.Text.Trim(), tablePrimarykey);
        gridMaster.DataSource = dt;
        gridMaster.DataBind();
        ModalPopupExtender1.Show();
    }
}