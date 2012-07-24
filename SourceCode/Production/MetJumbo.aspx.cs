using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Production_MetJumbo : System.Web.UI.Page
{
    #region Define
    Common com = new Common();
    Common_Message commessage = new Common_Message();
    string logmessage = "";
    Prod_MetJumbo_header objmetjumboheader = new Prod_MetJumbo_header();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButton btn_add = (ImageButton)Master.FindControl("btnAdd");
        btn_add.Click += new ImageClickEventHandler(btn_add_Click);
        if (!IsPostBack)
        {
                //Bind Grid to display items from Machine to be saved in database
                GetMachineData();
                //end
                TxtDate.Attributes.Add("readonly", "true");
                TxtBatch.Attributes.Add("readonly", "true");
                TxtJumboNo.Attributes.Add("readonly", "true");
                DataTable dt = new DataTable();
                TxtDate.Text= DateTime.Now.ToString(Log.GetLog().DateFormat);
                GdvDetails.DataSource = dt;
                GdvDetails.DataBind();
                BindSubType();
                BindGrade();
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        ClearHeader();
        ClearLineItems();
    }
    private void GetMachineData()
    {
        DataTable dtmachinedata= objmetjumboheader.GetMachineData();
        if (dtmachinedata.Rows.Count > 0)
        {
            lblmessage.Font.Bold = true;
            lblmessage.Text = "Records from Machine";
            GdvMachineData.DataSource = dtmachinedata;
            GdvMachineData.DataBind();
        }
        else
        {
            GdvMachineData.DataSource = null;
            GdvMachineData.DataBind();
        }
    }
    private void UpdateMachineData(string id)
    {
        objmetjumboheader.UpdateMachineData(id);
        
    }

    protected void GdvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView GdvDetails = (GridView)sender;
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        GdvDetails.SelectedIndex = row.RowIndex;
    }
    protected void GdvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (hidAutoIdHeader.Value == "")
            {
                e.Row.Cells[0].Visible = false;
            }
            else if (hidAutoIdHeader.Value != "")
            {
                e.Row.Cells[0].Visible = true;
            }
        }
        catch (Exception ex)
        {
            logmessage = "Met Jumbo Form- GdvDetails_RowDataBound -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ImgBtnAddMore_Click(object sender, ImageClickEventArgs e)
    {
     
        int LineNo;
        if (ViewState["LnNo"] != null)
        {
            LineNo = Convert.ToInt32(ViewState["LnNo"]);
        }
        else
        {
            LineNo = 10;
        }
        DataTable dt = null;
        if (ViewState["Details"] != null)
        {
            dt = (DataTable)ViewState["Details"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("BatchNo", typeof(int));
            dt.Columns.Add("ActualWeigth", typeof(string));
            dt.Columns.Add("ActualLength", typeof(string));
            dt.Columns.Add("AvailableWeigth", typeof(string));
            dt.Columns.Add("AvailableLength", typeof(string));
            dt.Columns.Add("FeedWeigth", typeof(string));
            dt.Columns.Add("FeedLength", typeof(string));
            dt.Columns.Add("Thickness", typeof(string));
            dt.Columns.Add("Width", typeof(string));
            dt.Columns.Add("Length", typeof(string));
            dt.Columns.Add("Weight", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Core", typeof(string));
            dt.Columns.Add("Joints", typeof(string));
            dt.Columns.Add("SupplierName", typeof(string));
        }
        DataRow drow = dt.NewRow();
        if (ViewState["Details"] != null)
        {
            drow["BatchNo"] = 10 + LineNo;
        }
        else
        {
            drow["BatchNo"] = LineNo;
        }
        drow["ActualWeigth"] = TxtActualWeigth.Text.Trim();
        drow["ActualLength"] = TxtActualLength.Text.Trim();
        drow["AvailableWeigth"] = TxtAvailableWeigth.Text.Trim();
        drow["AvailableLength"] = TxtAvailableLength.Text.Trim();
        drow["FeedWeigth"] = TxtFeedWeigth.Text.Trim();
        drow["FeedLength"] = TxtFeedLength.Text.Trim();
        drow["Thickness"] = TxtThickness.Text.Trim();
        drow["Width"] = TxtWidthHeader.Text.Trim();
        drow["Length"] = TxtLengthHeader.Text.Trim();
        drow["Weight"] = TxtDetailsWeigth.Text;
        drow["Type"] = TxtType.Text.Trim();
        drow["Core"] = TxtCore.Text.Trim();
        drow["Joints"] = TxtJoints.Text;
        drow["SupplierName"] = TxtSupplierName.Text;
        dt.Rows.Add(drow);
        ViewState["Details"] = dt;
        ViewState["LnNo"] = drow["BatchNo"];
        GdvDetails.DataSource = dt;
        GdvDetails.DataBind();
        ClearLineItems();
    }
    protected void BtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtlineitems=null;
        if (ViewState["Details"] != null)
        {
            dtlineitems = (DataTable)ViewState["Details"];
            dtlineitems.Columns.Add("METJumboNo");
            for(int i=0; i<dtlineitems.Rows.Count; i++)
            {
              dtlineitems.Rows[i]["METJumboNo"]="";
            }
            dtlineitems.AcceptChanges();
        }
       
        string Metalizer=TxtMetalizer.Text;
        string Date=TxtDate.Text.Trim();
        string Shift=TxtShift.Text.Trim();
        string Micron=TxtMicron.Text.Trim();
        string Type=TxtType.Text.Trim();
        string Core=TxtCore.Text.Trim();
        string Width=TxtWidth.Text;
        string Length=TxtLength.Text;
        string ActMic=TxtActMic.Text.Trim();
        string Quantity=TxtQtyKg.Text;
        string NoOfJoints=TxtNoOfJoints.Text.Trim();
        string Joint1=TxtJoint1.Text.Trim();
        string Joint2=TxtJoint2.Text.Trim();
        string Joint3=TxtJoint3.Text.Trim();
        string ODMin=TxtODMin.Text.Trim();
        string ODAverage=TxtODAvg.Text.Trim();
        string ODMax=TxtODMax.Text.Trim();
        string Grade=DdlGrade.SelectedValue;
        string Remarks=TxtObservations.Text;
        string VaccumStart=(TimePickerVaccumStart.Hour).ToString() + " : " + TimePickerVaccumStart.Minute.ToString();
        string HeatingStart=(TimePickerHeatingStart.Hour).ToString() + " : " + TimePickerHeatingStart.Minute.ToString();   
        string AccelerationTime=(TimePickerAccelerationTime.Hour).ToString() + " : " + TimePickerAccelerationTime.Minute.ToString();   
        string MetStartTime=(TimePickerMetStartTime.Hour).ToString() + " : " + TimePickerMetStartTime.Minute.ToString();   
        string Deaccelaration=(TimePickerDeacceleration.Hour).ToString() + " : " + TimePickerDeacceleration.Minute.ToString();      
        string MetStopTime=(TimePickerMetStoptime.Hour).ToString() + " : " + TimePickerMetStoptime.Minute.ToString();         
        string VentTime=(TimePickerVentTime.Hour).ToString() + " : " + TimePickerVentTime.Minute.ToString();         
        string Speed=TxtSpeed.Text.Trim();
        string OTR=TxtOTR.Text.Trim();
        string WVTR=TxtWVTR.Text.Trim();
        string BendStrength=TxtBendStrength.Text.Trim();
        string SealStrengthMin=TxtSealStrengthMin.Text;
        string SealStrengthAverage=TxtAverage.Text.Trim();
        string SealStrengthMax=TxtMax.Text.Trim();
        string COFSealToSeal=TxtCOFSealtoseal.Text.Trim();
        string COFSealToMetal=TxtCOFSealtometal.Text.Trim();
        string TapeTest=TxtTapeTest.Text.Trim();
        string TreatmentBackSide=TxtTreatmentBackSide.Text.Trim();
        string TreatmentMaterlizedSide=TxtTreatmentMaterlizedside.Text.Trim();
        string CreatedBy=Session["userid"].ToString();
        if (ViewState["MachineData"] != null)
        {
            if (objmetjumboheader.saveRecords(dtlineitems, Metalizer, Date, Shift, Micron, Type, Core, Width, Length, ActMic, Quantity, NoOfJoints, Joint1, Joint2, Joint3, ODMin, ODAverage, ODMax, Grade, Remarks, VaccumStart, HeatingStart, AccelerationTime, MetStartTime, Deaccelaration, MetStopTime, VentTime, Speed, OTR, WVTR, BendStrength, SealStrengthMin, SealStrengthAverage, SealStrengthMax, COFSealToSeal, COFSealToMetal, TapeTest, TreatmentBackSide, TreatmentMaterlizedSide, CreatedBy))
            {
                ViewState["Details"] = null;
                UpdateMachineData(ViewState["MachineDataid"].ToString());
                ClearHeader();
                GetMachineData();
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordSaved, 125, 300);
                return;
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordNotSaved, 125, 300);
                return;
            }
        }
        if (dtlineitems != null)
        {
            if (dtlineitems.Rows.Count > 0)
            {
                if (objmetjumboheader.saveRecords(dtlineitems, Metalizer, Date, Shift, Micron, Type, Core, Width, Length, ActMic, Quantity, NoOfJoints, Joint1, Joint2, Joint3, ODMin, ODAverage, ODMax, Grade, Remarks, VaccumStart, HeatingStart, AccelerationTime, MetStartTime, Deaccelaration, MetStopTime, VentTime, Speed, OTR, WVTR, BendStrength, SealStrengthMin, SealStrengthAverage, SealStrengthMax, COFSealToSeal, COFSealToMetal, TapeTest, TreatmentBackSide, TreatmentMaterlizedSide, CreatedBy))
                {
                    ViewState["Details"] = null;
                    ClearHeader();
                    GetMachineData();
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordSaved, 125, 300);
                    return;
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.RecordNotSaved, 125, 300);
                    return;
                }
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, commessage.AddLineItem, 125, 300);
            return;
        }                                                                                                                                                                            
     }


    protected void BindSubType()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = com.executeProcedure("Sp_Get_SubFilmType_Mst");
            DdlType.DataSource = dt;
            DdlType.DataTextField = "SubFilmTypeName";
            DdlType.DataValueField = "SubFilmTypeId";
            DdlType.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlType.Items.Add(item);
            DdlType.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Met Jumbo Form-BindSubType-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }

    protected void BindGrade()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = com.executeProcedure("Sp_Get_Prod_Grade_Mst");
            DdlGrade.DataSource = dt;
            DdlGrade.DataTextField = "GradeCode";
            DdlGrade.DataValueField = "autoid";
            DdlGrade.DataBind();
            ListItem item = new ListItem();
            item.Text = "----Select----";
            item.Value = "0";
            DdlGrade.Items.Add(item);
            DdlGrade.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            logmessage = "Met Jumbo Form-BindGrade-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
    }
    protected void ClearHeader()
    {
        TxtMetalizer.Text="";                          
        TxtDate.Text="";                          
        TxtShift.Text ="";                          
        TxtMicron.Text ="";                          
        TxtType.Text ="";                          
        TxtCore.Text ="";                          
        TxtWidth.Text="";                          
        TxtLength.Text="";                          
        TxtActMic.Text ="";                          
        TxtQtyKg.Text="";                          
        TxtNoOfJoints.Text ="";                          
        TxtJoint1.Text ="";                          
        TxtJoint2.Text ="";                          
        TxtJoint3.Text ="";                          
        TxtODMin.Text ="";                          
        TxtODAvg.Text ="";                          
        TxtODMax.Text ="";                          
        DdlGrade.SelectedValue="0";
        TxtObservations.Text="";                          
        TxtSpeed.Text ="";                          
        TxtOTR.Text ="";                          
        TxtWVTR.Text ="";                          
        TxtBendStrength.Text="";                          
        TxtSealStrengthMin.Text="";                          
        TxtAverage.Text="";                          
        TxtMax.Text="";                          
        TxtCOFSealtoseal.Text="";                          
        TxtCOFSealtometal.Text="";                          
        TxtTapeTest.Text="";                          
        TxtTreatmentBackSide.Text="";                          
        TxtTreatmentMaterlizedside.Text="";
        GdvDetails.DataSource = null;
        GdvDetails.DataBind();        
    }
    protected void ClearLineItems()
    {
        TxtActualWeigth.Text="";
        TxtActualLength.Text="";
        TxtAvailableWeigth.Text="";
        TxtAvailableLength.Text="";
        TxtFeedWeigth.Text="";
        TxtFeedLength.Text="";
        TxtThickness.Text="";
        TxtWidthHeader.Text="";
        TxtLengthHeader.Text="";
        TxtDetailsWeigth.Text="";
        TxtType.Text="";
        TxtCore.Text = "";
        TxtJoints.Text="";
        TxtSupplierName.Text="";
    }

    protected void GdvMachineData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GdvMachineData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       if(e.CommandName=="sel")
        {
            string id = e.CommandArgument.ToString();
            ViewState["MachineDataid"] = id;
            DataTable dt = com.GetVal("@id", id, "Sp_Prod_GetJumboHeader_DataFromMachine_ByJumboId");
            if (dt.Rows.Count > 0)
            {
                TxtMetalizer.Text = dt.Rows[0]["Metalizer"].ToString();
                //TxtDate.Text = dt.Rows[0]["Date"].ToString();
                TxtShift.Text = dt.Rows[0]["Shift"].ToString();
                TxtMicron.Text = dt.Rows[0]["Micron"].ToString();
                TxtType.Text = dt.Rows[0]["Type"].ToString();
                TxtCore.Text = dt.Rows[0]["Core"].ToString();
                TxtWidth.Text = dt.Rows[0]["Width"].ToString();
                TxtLength.Text = dt.Rows[0]["Length"].ToString();
                TxtActMic.Text = dt.Rows[0]["ActMic"].ToString();
                TxtQtyKg.Text = dt.Rows[0]["Quantity"].ToString();
                TxtNoOfJoints.Text = dt.Rows[0]["NoOfJoints"].ToString();
                TxtJoint1.Text = dt.Rows[0]["Joint1"].ToString();
                TxtJoint2.Text = dt.Rows[0]["Joint2"].ToString();
                TxtJoint3.Text = dt.Rows[0]["Joint3"].ToString();
                TxtODMin.Text = dt.Rows[0]["ODMin"].ToString();
                TxtODAvg.Text = dt.Rows[0]["ODAverage"].ToString();
                TxtODMax.Text = dt.Rows[0]["ODMax"].ToString();
                DdlGrade.SelectedValue = dt.Rows[0]["Grade"].ToString();
                TxtObservations.Text = dt.Rows[0]["Remarks"].ToString();

                if (dt.Rows[0]["VaccumStart"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["VaccumStart"].ToString();
                    string[] timearr = time.Split(':');
                    TimePickerVaccumStart.Hour = Convert.ToInt32(timearr[0]);
                    TimePickerVaccumStart.Minute = Convert.ToInt32(timearr[1]);

                }
                if (dt.Rows[0]["HeatingStart"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["HeatingStart"].ToString();
                    string[] timearr = time.Split(':');
                    TimePickerHeatingStart.Hour = Convert.ToInt32(timearr[0]);
                    TimePickerHeatingStart.Minute = Convert.ToInt32(timearr[1]);
                }
                if (dt.Rows[0]["AccelerationTime"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["AccelerationTime"].ToString();
                    string[] timearr = time.Split(':');
                    TimePickerAccelerationTime.Hour = Convert.ToInt32(timearr[0]);
                    TimePickerAccelerationTime.Minute = Convert.ToInt32(timearr[1]);
                }
                if (dt.Rows[0]["MetStartTime"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["MetStartTime"].ToString();
                    string[] timearr = time.Split(':');
                    TimePickerMetStartTime.Hour = Convert.ToInt32(timearr[0]);
                    TimePickerMetStartTime.Minute = Convert.ToInt32(timearr[1]);
                }
                if (dt.Rows[0]["Deaccelaration"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["Deaccelaration"].ToString();
                    string[] timearr = time.Split(':');
                    TimePickerDeacceleration.Hour = Convert.ToInt32(timearr[0]);
                    TimePickerDeacceleration.Minute = Convert.ToInt32(timearr[1]);
                }
                if (dt.Rows[0]["MetStopTime"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["MetStopTime"].ToString();
                    string[] timearr = time.Split(':');
                    TimePickerMetStoptime.Hour = Convert.ToInt32(timearr[0]);
                    TimePickerMetStoptime.Minute = Convert.ToInt32(timearr[1]);
                }
                if (dt.Rows[0]["VentTime"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["VentTime"].ToString();
                    string[] timearr = time.Split(':');
                    TimePickerVentTime.Hour = Convert.ToInt32(timearr[0]);
                    TimePickerVentTime.Minute = Convert.ToInt32(timearr[1]);
                }
                TxtSpeed.Text = dt.Rows[0]["Speed"].ToString();
                TxtOTR.Text = dt.Rows[0]["OTR"].ToString();
                TxtWVTR.Text = dt.Rows[0]["WVTR"].ToString();
                TxtBendStrength.Text = dt.Rows[0]["BendStrength"].ToString();
                TxtSealStrengthMin.Text = dt.Rows[0]["SealStrengthMin"].ToString();
                TxtAverage.Text = dt.Rows[0]["SealStrengthAverage"].ToString();
                TxtMax.Text = dt.Rows[0]["SealStrengthMax"].ToString();
                TxtCOFSealtoseal.Text = dt.Rows[0]["COFSealToSeal"].ToString();
                TxtCOFSealtometal.Text = dt.Rows[0]["COFSealToMetal"].ToString();
                TxtTapeTest.Text = dt.Rows[0]["TapeTest"].ToString();
                TxtTreatmentBackSide.Text = dt.Rows[0]["TreatmentBackSide"].ToString();
                TxtTreatmentMaterlizedside.Text = dt.Rows[0]["TreatmentMaterlizedSide"].ToString();
                ViewState["MachineData"] = "1";
            }
        }
       
    }
    protected void chk_CheckChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GdvMachineData.Rows)
        {
            //string id = ((Label)row.FindControl("lbljumbono")).Text;
            //ViewState["MachineDataid"] = id;
            //DataTable dt = com.GetVal("@id", id, "Sp_Prod_GetJumboHeader_DataFromMachine_ByJumboId");
            //if (dt.Rows.Count > 0)
            //{
            //    TxtMetalizer.Text= dt.Rows[0]["Metalizer"].ToString();
            //    //TxtDate.Text = dt.Rows[0]["Date"].ToString();
            //    TxtShift.Text = dt.Rows[0]["Shift"].ToString();
            //    TxtMicron.Text = dt.Rows[0]["Micron"].ToString();
            //    TxtType.Text = dt.Rows[0]["Type"].ToString();
            //    TxtCore.Text = dt.Rows[0]["Core"].ToString();
            //    TxtWidth.Text = dt.Rows[0]["Width"].ToString();
            //    TxtLength.Text = dt.Rows[0]["Length"].ToString();
            //    TxtActMic.Text = dt.Rows[0]["ActMic"].ToString();
            //    TxtQtyKg.Text = dt.Rows[0]["Quantity"].ToString();
            //    TxtNoOfJoints.Text = dt.Rows[0]["NoOfJoints"].ToString();
            //    TxtJoint1.Text = dt.Rows[0]["Joint1"].ToString();
            //    TxtJoint2.Text = dt.Rows[0]["Joint2"].ToString();
            //    TxtJoint3.Text = dt.Rows[0]["Joint3"].ToString();
            //    TxtODMin.Text = dt.Rows[0]["ODMin"].ToString();
            //    TxtODAvg.Text = dt.Rows[0]["ODAverage"].ToString();
            //    TxtODMax.Text = dt.Rows[0]["ODMax"].ToString();
            //    DdlGrade.SelectedValue = dt.Rows[0]["Grade"].ToString();
            //    TxtObservations.Text = dt.Rows[0]["Remarks"].ToString();
             
            //    if (dt.Rows[0]["VaccumStart"].ToString().Contains(":"))
            //    {
            //        string time=dt.Rows[0]["VaccumStart"].ToString();
            //        string[] timearr = time.Split(':');
            //        TimePickerVaccumStart.Hour = Convert.ToInt32(timearr[0]);
            //        TimePickerVaccumStart.Minute = Convert.ToInt32(timearr[1]);
                    
            //    }
            //    if (dt.Rows[0]["HeatingStart"].ToString().Contains(":"))
            //    {
            //        string time = dt.Rows[0]["HeatingStart"].ToString();
            //        string[] timearr = time.Split(':');
            //        TimePickerHeatingStart.Hour = Convert.ToInt32(timearr[0]);
            //        TimePickerHeatingStart.Minute = Convert.ToInt32(timearr[1]);
            //    }
            //    if (dt.Rows[0]["AccelerationTime"].ToString().Contains(":"))
            //    {
            //        string time = dt.Rows[0]["AccelerationTime"].ToString();
            //        string[] timearr = time.Split(':');
            //        TimePickerAccelerationTime.Hour = Convert.ToInt32(timearr[0]);
            //        TimePickerAccelerationTime.Minute = Convert.ToInt32(timearr[1]);
            //    }
            //    if (dt.Rows[0]["MetStartTime"].ToString().Contains(":"))
            //    {
            //        string time = dt.Rows[0]["MetStartTime"].ToString();
            //        string[] timearr = time.Split(':');
            //        TimePickerMetStartTime.Hour = Convert.ToInt32(timearr[0]);
            //        TimePickerMetStartTime.Minute = Convert.ToInt32(timearr[1]);
            //    }
            //    if (dt.Rows[0]["Deaccelaration"].ToString().Contains(":"))
            //    {
            //        string time = dt.Rows[0]["Deaccelaration"].ToString();
            //        string[] timearr = time.Split(':');
            //        TimePickerDeacceleration.Hour = Convert.ToInt32(timearr[0]);
            //        TimePickerDeacceleration.Minute = Convert.ToInt32(timearr[1]);
            //    }
            //    if (dt.Rows[0]["MetStopTime"].ToString().Contains(":"))
            //    {
            //        string time = dt.Rows[0]["MetStopTime"].ToString();
            //        string[] timearr = time.Split(':');
            //        TimePickerMetStoptime.Hour = Convert.ToInt32(timearr[0]);
            //        TimePickerMetStoptime.Minute = Convert.ToInt32(timearr[1]);
            //    }
            //    if (dt.Rows[0]["VentTime"].ToString().Contains(":"))
            //    {
            //        string time = dt.Rows[0]["VentTime"].ToString();
            //        string[] timearr = time.Split(':');
            //        TimePickerVentTime.Hour = Convert.ToInt32(timearr[0]);
            //        TimePickerVentTime.Minute = Convert.ToInt32(timearr[1]);
            //    }
            //    TxtSpeed.Text = dt.Rows[0]["Speed"].ToString();
            //    TxtOTR.Text = dt.Rows[0]["OTR"].ToString();
            //    TxtWVTR.Text = dt.Rows[0]["WVTR"].ToString();
            //    TxtBendStrength.Text = dt.Rows[0]["BendStrength"].ToString();
            //    TxtSealStrengthMin.Text = dt.Rows[0]["SealStrengthMin"].ToString();
            //    TxtAverage.Text = dt.Rows[0]["SealStrengthAverage"].ToString();
            //    TxtMax.Text = dt.Rows[0]["SealStrengthMax"].ToString();
            //    TxtCOFSealtoseal.Text = dt.Rows[0]["COFSealToSeal"].ToString();
            //    TxtCOFSealtometal.Text = dt.Rows[0]["COFSealToMetal"].ToString();
            //    TxtTapeTest.Text = dt.Rows[0]["TapeTest"].ToString();
            //    TxtTreatmentBackSide.Text = dt.Rows[0]["TreatmentBackSide"].ToString();
            //    TxtTreatmentMaterlizedside.Text = dt.Rows[0]["TreatmentMaterlizedSide"].ToString();
            //    ViewState["MachineData"] = "1";
            //}
        }
    }
}