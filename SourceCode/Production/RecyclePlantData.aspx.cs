using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class Production_RecyclePlantData : System.Web.UI.Page
{
    Common cmn = new Common();
    RecyclePlantData cs = new RecyclePlantData();
    Common_Message objMsg = new Common_Message();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] == null)
            {
                Server.Transfer("../SessionExpired.aspx");
            }
            else
            {
                Label lbl = (Label)Master.FindControl("lbl_PageHeader");
                lbl.Text = "Recycle Plan Data (Erema)";
               
                txtDate.Text = DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider);
                Calendarpopup.EndDate = DateTime.Now;
                btn_save.Visible = false;
                btn_cancel.Visible = false;
                btn_search.Visible = true;
                hf_MachineAutoid.Value = "none";
                hf_IsNewRecord.Value = "true";

                fillMachineGrid();


            }
        }
        ApplyNumericValidation();
        Calendarpopup.EndDate = DateTime.Now;
        

    }

    private void ApplyNumericValidation()
    {

        foreach (Control ctrl in pnlData.Controls)
            if (ctrl is TextBox)
            {
                RangeValidator myValidator = new RangeValidator();
                myValidator.ControlToValidate = ctrl.ID;
                myValidator.Type = ValidationDataType.Double;
                //RegularExpressionValidator myValidator = new RegularExpressionValidator();
                //myValidator.ControlToValidate = ctrl.ID;
                //myValidator.ValidationExpression = @"^[0-9]+(\.^[0-9])?$";
                myValidator.Display = ValidatorDisplay.None;
                myValidator.ID = "rev_n_" + ctrl.ID;
                myValidator.ErrorMessage = "Invalid value.";
                AjaxControlToolkit.ValidatorCalloutExtender vce = new AjaxControlToolkit.ValidatorCalloutExtender();
                vce.Enabled = true;
                vce.ID = "vce_" + myValidator.ID;
                vce.TargetControlID = myValidator.ID;

                vce.CssClass = "customCalloutStyle";
                pnlrev.Controls.Add(myValidator);
                pnlrev.Controls.Add(vce);
            }

    }

    protected void fillMachineGrid()
    {
        string sql = "SELECT * FROM Prod_Recycle_Plant_Data_EREMA_Intermediate where ActiveStatus='true'";
        DataTable dt = cmn.executeSqlQry(sql);
        gridMachineData.DataSource = dt;
        gridMachineData.DataBind();

    }
    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {
        bool isSaved = false;
        if (hf_IsNewRecord.Value == "true")
        {
            TimeSpan hrsMins1 = new TimeSpan(int.Parse(txttdtHr1.Text), int.Parse(txttdtMm1.Text), 00);
            TimeSpan hrsMins2 = new TimeSpan(int.Parse(txttdtHr2.Text), int.Parse(txttdtMm2.Text), 00);
            TimeSpan hrsMins3 = new TimeSpan(int.Parse(txttdtHr3.Text), int.Parse(txttdtMm3.Text), 00);

            isSaved = cs.saveRecord(DateTime.Parse(txtDate.Text).ToString(cmn.DateFormat, cmn.FormatProvider),
                txtcp1.Text, txtcc1.Text, txtlp1.Text, txtouc1.Text, txtlc1.Text, hrsMins1.ToString(), txtIv1.Text, txtCpg1.Text, txteg1.Text, txtac1.Text,
                txtcp2.Text, txtcc2.Text, txtlp2.Text, txtouc2.Text, txtlc2.Text, hrsMins2.ToString(), txtIv2.Text, txtCpg2.Text, txteg2.Text, txtac2.Text,
                txtcp3.Text, txtcc3.Text, txtlp3.Text, txtouc3.Text, txtlc3.Text, hrsMins3.ToString(), txtIv3.Text, txtCpg3.Text, txteg3.Text, txtac3.Text,
                "true", Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider), Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider));
        }
        else if (hf_IsNewRecord.Value == "false")
        {
            TimeSpan hrsMins1 = new TimeSpan(int.Parse(txttdtHr1.Text), int.Parse(txttdtMm1.Text), 00);
            TimeSpan hrsMins2 = new TimeSpan(int.Parse(txttdtHr2.Text), int.Parse(txttdtMm2.Text), 00);
            TimeSpan hrsMins3 = new TimeSpan(int.Parse(txttdtHr3.Text), int.Parse(txttdtMm3.Text), 00);

            isSaved = cs.updateRecord(hf_autoid.Value, DateTime.Parse(txtDate.Text).ToString(cmn.DateFormat, cmn.FormatProvider),
                txtcp1.Text, txtcc1.Text, txtlp1.Text, txtouc1.Text, txtlc1.Text, hrsMins1.ToString(), txtIv1.Text, txtCpg1.Text, txteg1.Text, txtac1.Text,
                txtcp2.Text, txtcc2.Text, txtlp2.Text, txtouc2.Text, txtlc2.Text, hrsMins2.ToString(), txtIv2.Text, txtCpg2.Text, txteg2.Text, txtac2.Text,
                txtcp3.Text, txtcc3.Text, txtlp3.Text, txtouc3.Text, txtlc3.Text, hrsMins3.ToString(), txtIv3.Text, txtCpg3.Text, txteg3.Text, txtac3.Text,
                "true", Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider), Session["UserID"].ToString(), DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider));


        }

        if (isSaved == true)
        {
           
            string message = objMsg.RecordSaved;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, message, 125, 300);
            clearAll();
            btn_save.Visible = false;
            btn_cancel.Visible = false;
            btn_search.Visible = true;
            if (hf_MachineAutoid.Value != "none")
            {
                string sql="UPDATE Prod_Recycle_Plant_Data_EREMA_Intermediate SET ActiveStatus = 'false' WHERE AutoID='"+hf_MachineAutoid.Value+"'";
                cmn.executeSimpleQry(sql);
            }
            fillMachineGrid();

        }
        else
        {
            string message = objMsg.RecordNotSaved;
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, message, 125, 300);
        }
    }

    protected void clearAll()
    {
        txtDate.Text = DateTime.Now.ToString(cmn.DateFormat, cmn.FormatProvider);
        foreach (Control ctrl in pnlData.Controls)
            if (ctrl is TextBox)
            {
                TextBox txbx = (TextBox)ctrl;
                txbx.Text = "0";
            }
       
    }

    protected void gridMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        int autoId = int.Parse(gridMaster.SelectedDataKey.Value.ToString());
        fillRecord(autoId);
        hf_IsNewRecord.Value = "false";
        btn_save.Visible = true;
        btn_cancel.Visible = true;
        hf_autoid.Value = autoId.ToString();


    }
    protected void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = cs.getData(DateTime.Parse(txtDate.Text).ToString(cmn.DateFormat, cmn.FormatProvider));
            gridMaster.DataSource = dt;
            gridMaster.DataBind();
            lblDateGrid.Text = DateTime.Parse(txtDate.Text).ToString(cmn.DateFormat, cmn.FormatProvider);
            ModalPopupExtender1.Show();

        }
        catch (Exception ex)
        {
        }
    }

    protected void fillRecord(int autoid)
    {
        DataTable dt = cs.getRecord(autoid.ToString());
        if (dt.Rows.Count > 0)
        {
            try
            {
                hf_IsNewRecord.Value = "false";

                txtcp1.Text = dt.Rows[0]["Line1_Chips_Prod_MT"].ToString();
                txtcc1.Text = dt.Rows[0]["Line1_Chips_Consump_MT"].ToString();
                txtlp1.Text = dt.Rows[0]["Line1_Lumps_Prod_MT"].ToString();
                txtouc1.Text = dt.Rows[0]["Line1_OverSize_UnderSize_Chips_MT"].ToString();
                txtlc1.Text = dt.Rows[0]["Line1_Lumps_Consmp_MT"].ToString();
                txttdtHr1.Text = TimeSpan.Parse(dt.Rows[0]["Line1_Total_Down_Time_HH_Min"].ToString()).Hours.ToString();
                txttdtMm1.Text = TimeSpan.Parse(dt.Rows[0]["Line1_Total_Down_Time_HH_Min"].ToString()).Minutes.ToString();
                txtIv1.Text = dt.Rows[0]["Line1_IV"].ToString();
                txtCpg1.Text = dt.Rows[0]["Line1_CPG"].ToString();
                txteg1.Text = dt.Rows[0]["Line1_End_Group"].ToString();
                txtac1.Text = dt.Rows[0]["Line1_Ash_Content"].ToString();
                txtcp2.Text = dt.Rows[0]["Line2_Chips_Prod_MT"].ToString();
                txtcc2.Text = dt.Rows[0]["Line2_Chips_Consump_MT"].ToString();
                txtlp2.Text = dt.Rows[0]["Line2_Lumps_Prod_MT"].ToString();
                txtouc2.Text = dt.Rows[0]["Line2_OverSize_UnderSize_Chips_MT"].ToString();
                txtlc2.Text = dt.Rows[0]["Line2_Lumps_Consmp_MT"].ToString();
                txttdtHr2.Text = TimeSpan.Parse(dt.Rows[0]["Line2_Total_Down_Time_HH_Min"].ToString()).Hours.ToString();
                txttdtMm2.Text = TimeSpan.Parse(dt.Rows[0]["Line2_Total_Down_Time_HH_Min"].ToString()).Minutes.ToString();
                txtIv2.Text = dt.Rows[0]["Line2_IV"].ToString();
                txtCpg2.Text = dt.Rows[0]["Line2_CPG"].ToString();
                txteg2.Text = dt.Rows[0]["Line2_End_Group"].ToString();
                txtac2.Text = dt.Rows[0]["Line2_Ash_Content"].ToString();
                txtcp3.Text = dt.Rows[0]["Line3_Chips_Prod_MT"].ToString();
                txtcc3.Text = dt.Rows[0]["Line3_Chips_Consump_MT"].ToString();
                txtlp3.Text = dt.Rows[0]["Line3_Lumps_Prod_MT"].ToString();
                txtouc3.Text = dt.Rows[0]["Line3_OverSize_UnderSize_Chips_MT"].ToString();
                txtlc3.Text = dt.Rows[0]["Line3_Lumps_Consmp_MT"].ToString();
                txttdtHr3.Text = TimeSpan.Parse(dt.Rows[0]["Line3_Total_Down_Time_HH_Min"].ToString()).Hours.ToString();
                txttdtMm3.Text = TimeSpan.Parse(dt.Rows[0]["Line3_Total_Down_Time_HH_Min"].ToString()).Minutes.ToString();
                txtIv3.Text = dt.Rows[0]["Line3_IV"].ToString();
                txtCpg3.Text = dt.Rows[0]["Line3_CPG"].ToString();
                txteg3.Text = dt.Rows[0]["Line3_End_Group"].ToString();
                txtac3.Text = dt.Rows[0]["Line3_Ash_Content"].ToString();
            }
            catch (Exception ex)
            {
            }

        }


    }

    protected void fillRecordMachine(int autoid)
    {
        DataTable dt = cs.getMachineRecord(autoid.ToString());
        if (dt.Rows.Count > 0)
        {
            try
            {
                hf_IsNewRecord.Value = "false";

                txtcp1.Text = dt.Rows[0]["Line1_Chips_Prod_MT"].ToString();
                txtcc1.Text = dt.Rows[0]["Line1_Chips_Consump_MT"].ToString();
                txtlp1.Text = dt.Rows[0]["Line1_Lumps_Prod_MT"].ToString();
                txtouc1.Text = dt.Rows[0]["Line1_OverSize_UnderSize_Chips_MT"].ToString();
                txtlc1.Text = dt.Rows[0]["Line1_Lumps_Consmp_MT"].ToString();
                txttdtHr1.Text = TimeSpan.Parse(dt.Rows[0]["Line1_Total_Down_Time_HH_Min"].ToString()).Hours.ToString();
                txttdtMm1.Text = TimeSpan.Parse(dt.Rows[0]["Line1_Total_Down_Time_HH_Min"].ToString()).Minutes.ToString();
                txtIv1.Text = dt.Rows[0]["Line1_IV"].ToString();
                txtCpg1.Text = dt.Rows[0]["Line1_CPG"].ToString();
                txteg1.Text = dt.Rows[0]["Line1_End_Group"].ToString();
                txtac1.Text = dt.Rows[0]["Line1_Ash_Content"].ToString();
                txtcp2.Text = dt.Rows[0]["Line2_Chips_Prod_MT"].ToString();
                txtcc2.Text = dt.Rows[0]["Line2_Chips_Consump_MT"].ToString();
                txtlp2.Text = dt.Rows[0]["Line2_Lumps_Prod_MT"].ToString();
                txtouc2.Text = dt.Rows[0]["Line2_OverSize_UnderSize_Chips_MT"].ToString();
                txtlc2.Text = dt.Rows[0]["Line2_Lumps_Consmp_MT"].ToString();
                txttdtHr2.Text = TimeSpan.Parse(dt.Rows[0]["Line2_Total_Down_Time_HH_Min"].ToString()).Hours.ToString();
                txttdtMm2.Text = TimeSpan.Parse(dt.Rows[0]["Line2_Total_Down_Time_HH_Min"].ToString()).Minutes.ToString();
                txtIv2.Text = dt.Rows[0]["Line2_IV"].ToString();
                txtCpg2.Text = dt.Rows[0]["Line2_CPG"].ToString();
                txteg2.Text = dt.Rows[0]["Line2_End_Group"].ToString();
                txtac2.Text = dt.Rows[0]["Line2_Ash_Content"].ToString();
                txtcp3.Text = dt.Rows[0]["Line3_Chips_Prod_MT"].ToString();
                txtcc3.Text = dt.Rows[0]["Line3_Chips_Consump_MT"].ToString();
                txtlp3.Text = dt.Rows[0]["Line3_Lumps_Prod_MT"].ToString();
                txtouc3.Text = dt.Rows[0]["Line3_OverSize_UnderSize_Chips_MT"].ToString();
                txtlc3.Text = dt.Rows[0]["Line3_Lumps_Consmp_MT"].ToString();
                txttdtHr3.Text = TimeSpan.Parse(dt.Rows[0]["Line3_Total_Down_Time_HH_Min"].ToString()).Hours.ToString();
                txttdtMm3.Text = TimeSpan.Parse(dt.Rows[0]["Line3_Total_Down_Time_HH_Min"].ToString()).Minutes.ToString();
                txtIv3.Text = dt.Rows[0]["Line3_IV"].ToString();
                txtCpg3.Text = dt.Rows[0]["Line3_CPG"].ToString();
                txteg3.Text = dt.Rows[0]["Line3_End_Group"].ToString();
                txtac3.Text = dt.Rows[0]["Line3_Ash_Content"].ToString();
            }
            catch (Exception ex)
            {
            }

        }


    }


    protected void btn_new_Click(object sender, ImageClickEventArgs e)
    {

        clearAll();
        hf_IsNewRecord.Value = "true";
        btn_save.Visible = true;
        btn_cancel.Visible = true;

    }
    protected void btn_cancel_Click(object sender, ImageClickEventArgs e)
    {
        hf_IsNewRecord.Value = "false";
        btn_save.Visible = true;
        btn_cancel.Visible = true;
        clearAll();
    }
    protected void gridMachineData_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int autoId = int.Parse(gridMachineData.SelectedDataKey.Value.ToString());
        //foreach (GridViewRow oldrow in gridMachineData.Rows)
        //{
        //    ImageButton imgbutton = (ImageButton)oldrow.FindControl("imgmachine");
        //    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
        //    oldrow.BackColor = Color.White;
        //}
        //ImageButton img = (ImageButton)gridMachineData.Rows[gridMachineData.SelectedIndex].FindControl("imgmachine");
        //img.ImageUrl = "~/Images/chkbxcheck.png";
        fillRecordMachine(autoId);
        hf_IsNewRecord.Value = "true";
        btn_save.Visible = true;
        btn_cancel.Visible = true;
        hf_MachineAutoid.Value = autoId.ToString();

    }
}