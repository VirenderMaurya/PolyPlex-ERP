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
    Prod_PetJumbo_Tran objProd_PetJumbo_Tran = new Prod_PetJumbo_Tran();    
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
                lblPageHeader.Text = "PET Jumbo";              
                TCPetJumbo.ActiveTabIndex = 0;

                TDJumboNo.Attributes.Add("style", "display:none");
                TDtxtJumboNo.Attributes.Add("style", "display:none");                              

                #region Bind Masters

                BindSearchList();
                FillFinancialYear();
                Get_All_SubFilmType_Mst();
                Get_All_Thickness_Mst();
                Get_All_Prod_Line_Mst();
                Get_All_Prod_Shift_Mst();
                Get_All_Prod_Grade_Mst();
                Get_All_Prod_Polrised_Mst();
                Get_All_FA_Glb_VendorMaster_Mst();

                #endregion

                TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
                txtSearch.Text = "";                

                #region Intermediate Table Data

                Get_Prod_Glb_PetJumbo_MainTable_Intermediate_AllRecords();

                #endregion                
                
                #region Change Color of Readonly Fields

                txtJumboDate.Attributes.Add("style", "background:lightgray");
                txtJumboNo.Attributes.Add("style", "background:lightgray");
                txtDateIn.Attributes.Add("style", "background:lightgray");
                txtDateOut.Attributes.Add("style", "background:lightgray");               
                
                #endregion

                txtJumboDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);

                #region Readonly Fields
                txtJumboDate.Attributes.Add("readonly", "true");
                txtJumboNo.Attributes.Add("readonly", "true");
                txtDateIn.Attributes.Add("readonly", "true");
                txtDateOut.Attributes.Add("readonly", "true");               
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
        ClearMainDetailsTab();
        ClearShrinkPolrisedTab();
        ClearJumboQualityAnalysisTab();
        ClearOtherDetailsTab();
        TDJumboNo.Attributes.Add("style", "display:none");
        TDtxtJumboNo.Attributes.Add("style", "display:none");   
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            Get_Prod_Glb_PetJumbo_MainTable_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
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
        Get_Prod_Glb_PetJumbo_MainTable_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());        
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Update Records Of MainDetailsTab

            if (hidPetJumboId.Value == "")
            {
                objProd_PetJumbo_Tran.PetJumboId = 0;
            }
            else
            {
                objProd_PetJumbo_Tran.PetJumboId = Convert.ToInt32(hidPetJumboId.Value);
            }
            if (HidIntermediatePetJumboId.Value == "")
            {
                objProd_PetJumbo_Tran.IntermediatePetJumboId = 0;
            }
            else
            {
                objProd_PetJumbo_Tran.IntermediatePetJumboId = Convert.ToInt32(HidIntermediatePetJumboId.Value);
            }
            objProd_PetJumbo_Tran.Year = HidYear.Value;
            if (ddlLine.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.LineId = Convert.ToInt32(ddlLine.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.LineId = 0;
            }
            if (txtJumboDate.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.JumboDate = DateTime.ParseExact(txtJumboDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_PetJumbo_Tran.JumboDate = "";
            }
            if (ddlShift.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.ShiftId = Convert.ToInt32(ddlShift.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.ShiftId = 0;
            }
            if (txtDateIn.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.DateIn = DateTime.ParseExact(txtDateIn.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_PetJumbo_Tran.DateIn = "";
            }
            objProd_PetJumbo_Tran.TimeIn = (tsTimeIn.Hour).ToString() + " : " + tsTimeIn.Minute.ToString();
            if (txtDateOut.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.DateOut = DateTime.ParseExact(txtDateOut.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_PetJumbo_Tran.DateOut = "";
            }
            objProd_PetJumbo_Tran.TimeOut = (tsTimeOut.Hour).ToString() + " : " + tsTimeOut.Minute.ToString();
            objProd_PetJumbo_Tran.RawMaterial = txtRawMaterial.Text.Trim();
            if (ddlThickness.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.ThicknessId = Convert.ToInt32(ddlThickness.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.ThicknessId = 0;
            }
            if (ddlSubFilmType.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.SubFilmTypeId = Convert.ToInt32(ddlSubFilmType.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.SubFilmTypeId = 0;
            }
            objProd_PetJumbo_Tran.RunNo = txtRunNo.Text.Trim();
            if (ddlGrade.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.GradeId = Convert.ToInt32(ddlGrade.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.GradeId = 0;
            }
            objProd_PetJumbo_Tran.BreakNo = txtBreakNo.Text.Trim();
            objProd_PetJumbo_Tran.ElectrodKW1 = txtElectrodKW1.Text.Trim();
            objProd_PetJumbo_Tran.AvgGuage = txtAvgGuage.Text.Trim();
            objProd_PetJumbo_Tran.CoreNo = txtCoreNo.Text.Trim();
            if (txtOscillationNo.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.OsicllationWidth = Convert.ToDouble(txtOscillationNo.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.OsicllationWidth = 0;
            }
            objProd_PetJumbo_Tran.ElectrodKW2 = txtElectrodKW2.Text.Trim();
            if (txtFinalWidth.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.FinalWidth = Convert.ToDouble(txtFinalWidth.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.FinalWidth = 0;
            }
            if (txtLength.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.Length = Convert.ToDouble(txtLength.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.Length = 0;
            }
            objProd_PetJumbo_Tran.Joint = txtJoint.Text.Trim();
            if (txtWeight.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.Weight = Convert.ToDouble(txtWeight.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.Weight = 0;
            }
            objProd_PetJumbo_Tran.FrictionS = txtFrictionS.Text.Trim();
            objProd_PetJumbo_Tran.FrictionK = txtFrictionK.Text;
            objProd_PetJumbo_Tran.ELMDLeft = txtELMDLeft.Text.Trim();
            objProd_PetJumbo_Tran.ELMDCenter = txtELMDCenter.Text.Trim();
            objProd_PetJumbo_Tran.ELMDRight = txtELMDRight.Text.Trim();
            objProd_PetJumbo_Tran.ELMDMainThick = txtELMDMainThick.Text.Trim();
            objProd_PetJumbo_Tran.ELTDLeft = txtELTDLeft.Text.Trim();
            objProd_PetJumbo_Tran.ELTDCenter = txtELTDCenter.Text.Trim();
            objProd_PetJumbo_Tran.ELTDRight = txtELTDRight.Text.Trim();
            objProd_PetJumbo_Tran.ELTDCoexThick = txtELTDCoexThick.Text.Trim();
            objProd_PetJumbo_Tran.TSMDLeft = txtTSMDLeft.Text.Trim();
            objProd_PetJumbo_Tran.TSMDCenter = txtTSMDCenter.Text.Trim();
            objProd_PetJumbo_Tran.TSMDRight = txtTSMDRight.Text.Trim();
            objProd_PetJumbo_Tran.TSMDMainRPM = txtTSMDMainRPM.Text.Trim();
            objProd_PetJumbo_Tran.TSTDLeft = txtTSTDLeft.Text.Trim();
            objProd_PetJumbo_Tran.TSTDCenter = txtTSTDCenter.Text.Trim();
            objProd_PetJumbo_Tran.TSTDRight = txtTSTDRight.Text.Trim();
            objProd_PetJumbo_Tran.TSTDCoexRPM = txtTSTDCoexRPM.Text.Trim();
            objProd_PetJumbo_Tran.Haze1 = txtHaze1.Text.Trim();
            objProd_PetJumbo_Tran.Haze2 = txtHaze2.Text.Trim();
            objProd_PetJumbo_Tran.TapeTestSideCoated = txtTapeTestSideCoated.Text.Trim();
            objProd_PetJumbo_Tran.BothSide = txtBothSide.Text.Trim();
            objProd_PetJumbo_Tran.BreakDownVoltage = txtBreakDownVoltage.Text.Trim();
            objProd_PetJumbo_Tran.DynamicMin = txtDynamicMin.Text.Trim();
            objProd_PetJumbo_Tran.DynamicMax = txtDynamicMax.Text.Trim();
            objProd_PetJumbo_Tran.ActiveStatus = true;
            objProd_PetJumbo_Tran.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
            objProd_PetJumbo_Tran.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

            #endregion

            #region Insert/Update Records Of ShrinkPolrisedTab

            if (HidShrinkPolarisedID.Value == "")
            {
                objProd_PetJumbo_Tran.ShrinkPolarisedID = 0;
            }
            else
            {
                objProd_PetJumbo_Tran.ShrinkPolarisedID = Convert.ToInt32(HidShrinkPolarisedID.Value);
            }
            objProd_PetJumbo_Tran.PeakToPeak = txtPeakToPeak.Text.Trim();
            objProd_PetJumbo_Tran.F5MDAvg = txtF5MDAvg.Text.Trim();
            objProd_PetJumbo_Tran.F5TDAvg = txtF5TDAvg.Text.Trim();
            objProd_PetJumbo_Tran.CDSpread = txtCDSpread.Text.Trim();
            objProd_PetJumbo_Tran.YoungModulesMD = txtYoungModulesMD.Text.Trim();
            objProd_PetJumbo_Tran.F5MDLeft = txtF5MDLeft.Text.Trim();
            objProd_PetJumbo_Tran.F5MDRight = txtF5MDRight.Text.Trim();
            objProd_PetJumbo_Tran.YoungModulesTD = txtYoungModulesTD.Text.Trim();
            objProd_PetJumbo_Tran.F5MDCenter = txtF5MDCenter.Text.Trim();
            objProd_PetJumbo_Tran.MDL = txtMDL.Text.Trim();
            objProd_PetJumbo_Tran.MDC = txtMDC.Text.Trim();
            objProd_PetJumbo_Tran.MDR = txtMDR.Text.Trim();
            objProd_PetJumbo_Tran.TDL = txtTDL.Text.Trim();
            objProd_PetJumbo_Tran.TDC = txtTDC.Text.Trim();
            objProd_PetJumbo_Tran.TDR = txtTDR.Text.Trim();
            if (ddlPolarisedCode1.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.PolarisedCode1 = Convert.ToInt32(ddlPolarisedCode1.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.PolarisedCode1 = 0;
            }
            objProd_PetJumbo_Tran.PolarisedTotal1 = txtPolarisedTotal1.Text.Trim();
            objProd_PetJumbo_Tran.PolarisedCenter1 = txtPolarisedCenter1.Text.Trim();
            objProd_PetJumbo_Tran.PolarisedRight1 = txtPolarisedRight1.Text.Trim();
            if (ddlPolarisedCode2.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.PolarisedCode2 = Convert.ToInt32(ddlPolarisedCode2.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.PolarisedCode2 = 0;
            }
            objProd_PetJumbo_Tran.PolarisedLeft2 = txtPolarisedLeft2.Text.Trim();
            objProd_PetJumbo_Tran.PolarisedCenter2 = txtPolarisedCenter2.Text.Trim();
            objProd_PetJumbo_Tran.PolarisedRight2 = txtPolarisedRight2.Text.Trim();
            if (ddlPolarisedCode3.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.PolarisedCode3 = Convert.ToInt32(ddlPolarisedCode3.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.PolarisedCode3 = 0;
            }
            objProd_PetJumbo_Tran.PolarisedLeft3 = txtPolarisedLeft3.Text.Trim();
            objProd_PetJumbo_Tran.PolarisedCenter3 = txtPolarisedCenter3.Text.Trim();
            objProd_PetJumbo_Tran.PolarisedRight3 = txtPolarisedRight3.Text.Trim();
            if (ddlPolarisedCode4.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.PolarisedCode4 = Convert.ToInt32(ddlPolarisedCode4.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.PolarisedCode4 = 0;
            }
            objProd_PetJumbo_Tran.PolarisedLeft4 = txtPolarisedLeft4.Text.Trim();
            objProd_PetJumbo_Tran.PolarisedCenter4 = txtPolarisedCenter4.Text.Trim();
            objProd_PetJumbo_Tran.PolarisedRight4 = txtPolarisedRight4.Text.Trim();

            #endregion

            #region Insert/Update Records Of JumboQualityAnalysisTab

            if (HidJumboQualityId.Value == "")
            {
                objProd_PetJumbo_Tran.JumboQualityId = 0;
            }
            else
            {
                objProd_PetJumbo_Tran.JumboQualityId = Convert.ToInt32(HidJumboQualityId.Value);
            }
            objProd_PetJumbo_Tran.Unflush = txtUnflush.Text.Trim();
            objProd_PetJumbo_Tran.RoughCutting = txtRoughCutting.Text.Trim();
            objProd_PetJumbo_Tran.Telescoping = txtTelescoping.Text.Trim();
            objProd_PetJumbo_Tran.LooseWinding = txtLooseWinding.Text.Trim();
            objProd_PetJumbo_Tran.WindVariation = txtWindVariation.Text.Trim();
            objProd_PetJumbo_Tran.TrimInside = txtTrimInside.Text.Trim(); ;
            objProd_PetJumbo_Tran.FoldInside = txtFoldInside.Text.Trim();
            objProd_PetJumbo_Tran.TrimCut = txtTrimCut.Text.Trim();
            objProd_PetJumbo_Tran.WrinklesInTop = txtWrinklesInTop.Text.Trim();
            objProd_PetJumbo_Tran.WrinklesInButtom = txtWrinklesInButtom.Text.Trim();
            objProd_PetJumbo_Tran.HardRipplesonTop = txtHardRipplesonTop.Text.Trim();
            objProd_PetJumbo_Tran.HardRipplesinBetween = txtHardRipplesinBetween.Text.Trim();
            objProd_PetJumbo_Tran.AccrossFullWidthScratch = txtAccrossFullWidthScratch.Text.Trim();
            objProd_PetJumbo_Tran.OnlyinSomePortionScratch = txtOnlyinSomePortionScratch.Text.Trim();
            objProd_PetJumbo_Tran.AccrossFullWidthHT = txtOnlyinSomePortionScratch.Text.Trim();
            objProd_PetJumbo_Tran.AccrossFullWidthHT = txtAccrossFullWidthHT.Text.Trim();
            objProd_PetJumbo_Tran.OnlyinSomePortionHT = txtOnlyinSomePortionHT.Text.Trim();
            objProd_PetJumbo_Tran.DieResetJumbo = txtDieResetJumbo.Text.Trim();
            objProd_PetJumbo_Tran.NegativeBandVisibleonWinder = txtNegativeBandVisibleonWinder.Text.Trim();
            objProd_PetJumbo_Tran.GuageBandVisibleonWinder = txtGuageBandVisibleonWinder.Text.Trim();
            objProd_PetJumbo_Tran.ProcessConditionChanged = txtProcessConditionChanged.Text.Trim();
            objProd_PetJumbo_Tran.ShadeVariation = txtShadeVariation.Text.Trim();
            objProd_PetJumbo_Tran.DifferentMicrons = txtDifferentMicrons.Text.Trim();
            objProd_PetJumbo_Tran.CoatedUncoated = txtCoatedUncoated.Text.Trim();
            objProd_PetJumbo_Tran.CoronaPlan = txtCoronaPlan.Text.Trim();
            objProd_PetJumbo_Tran.BlackDustParticle = txtBlackDustParticle.Text.Trim();
            objProd_PetJumbo_Tran.Gels = txtGels.Text.Trim();
            objProd_PetJumbo_Tran.UnmoltenParticle = txtUnmoltenParticle.Text.Trim();

            #endregion

            #region Insert/Update Records Of OtherDetailsTab


            if (HidOtherDetailsId.Value == "")
            {
                objProd_PetJumbo_Tran.OtherDetailsId = 0;
            }
            else
            {
                objProd_PetJumbo_Tran.OtherDetailsId = Convert.ToInt32(HidOtherDetailsId.Value);
            }
            objProd_PetJumbo_Tran.Remarks1 = txtRemarks1.Text.Trim();
            objProd_PetJumbo_Tran.Remarks2 = txtRemarks2.Text.Trim();
            if (chkJumboPlannedUnplanned.Checked == true)
            {
                objProd_PetJumbo_Tran.JumboPlannedUnplanned = true;
            }
            else
            {
                objProd_PetJumbo_Tran.JumboPlannedUnplanned = false;
            }
            objProd_PetJumbo_Tran.ReasonforUnplanned = txtReasonforUnplanned.Text.Trim();
            objProd_PetJumbo_Tran.TrimWeightpermtr = txtTrimWeightpermtr.Text.Trim();
            objProd_PetJumbo_Tran.JumboExtrusionQty = txtJumboExtrusionQty.Text.Trim();
            objProd_PetJumbo_Tran.MainSiloMaterialCode1 = txtMainSiloMaterialCode1.Text.Trim();
            if (txtMainSiloPercentage1.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.MainSiloPercentage1 = Convert.ToDouble(txtMainSiloPercentage1.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.MainSiloPercentage1 = 0;
            }
            objProd_PetJumbo_Tran.MainSiloGrade1 = txtMainSiloGrade1.Text.Trim();
            if (ddlMainSiloVendor1.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.MainSiloVendor1 = Convert.ToInt32(ddlMainSiloVendor1.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.MainSiloVendor1 = 0;
            }
            objProd_PetJumbo_Tran.CoexMaterialCode1 = txtCoexMaterialCode1.Text.Trim();
            if (txtCoexPercentage1.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.CoexPercentage1 = Convert.ToDouble(txtCoexPercentage1.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.CoexPercentage1 = 0;
            }
            objProd_PetJumbo_Tran.CoexGrade1 = txtCoexGrade1.Text.Trim();
            if (ddlCoexVendor1.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.CoexVendor1 = Convert.ToInt32(ddlCoexVendor1.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.CoexVendor1 = 0;
            }

            objProd_PetJumbo_Tran.MainSiloMaterialCode2 = txtMainSiloMaterialCode2.Text.Trim();
            if (txtMainSiloPercentage2.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.MainSiloPercentage2 = Convert.ToDouble(txtMainSiloPercentage2.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.MainSiloPercentage2 = 0;
            }
            objProd_PetJumbo_Tran.MainSiloGrade2 = txtMainSiloGrade2.Text.Trim();
            if (ddlMainSiloVendor2.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.MainSiloVendor2 = Convert.ToInt32(ddlMainSiloVendor2.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.MainSiloVendor2 = 0;
            }
            objProd_PetJumbo_Tran.CoexMaterialCode2 = txtCoexMaterialCode2.Text.Trim();
            if (txtCoexPercentage2.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.CoexPercentage2 = Convert.ToDouble(txtCoexPercentage2.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.CoexPercentage2 = 0;
            }
            objProd_PetJumbo_Tran.CoexGrade2 = txtCoexGrade2.Text.Trim();
            if (ddlCoexVendor2.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.CoexVendor2 = Convert.ToInt32(ddlCoexVendor2.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.CoexVendor2 = 0;
            }
            objProd_PetJumbo_Tran.MainSiloMaterialCode3 = txtMainSiloMaterialCode3.Text.Trim();
            if (txtMainSiloPercentage3.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.MainSiloPercentage3 = Convert.ToDouble(txtMainSiloPercentage3.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.MainSiloPercentage3 = 0;
            }
            objProd_PetJumbo_Tran.MainSiloGrade3 = txtMainSiloGrade3.Text.Trim();
            if (ddlMainSiloVendor3.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.MainSiloVendor3 = Convert.ToInt32(ddlMainSiloVendor3.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.MainSiloVendor3 = 0;
            }

            objProd_PetJumbo_Tran.CoexMaterialCode3 = txtCoexMaterialCode3.Text.Trim();
            if (txtCoexPercentage3.Text.Trim() != "")
            {
                objProd_PetJumbo_Tran.CoexPercentage3 = Convert.ToDouble(txtCoexPercentage3.Text.Trim());
            }
            else
            {
                objProd_PetJumbo_Tran.CoexPercentage3 = 0;
            }
            objProd_PetJumbo_Tran.CoexGrade3 = txtCoexGrade3.Text.Trim();
            if (ddlCoexVendor3.SelectedValue != "")
            {
                objProd_PetJumbo_Tran.CoexVendor3 = Convert.ToInt32(ddlCoexVendor3.SelectedValue);
            }
            else
            {
                objProd_PetJumbo_Tran.CoexVendor3 = 0;
            }

            #endregion

            FlagInsertUpdate = objProd_PetJumbo_Tran.InsertAndUpdate_In_Prod_Glb_MainDetails_Trans();
            if (FlagInsertUpdate == "YES")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                #region Clear All records after save

                ClearMainDetailsTab();
                ClearShrinkPolrisedTab();
                ClearJumboQualityAnalysisTab();
                ClearOtherDetailsTab();

                #region Intermediate Table Data

                Get_Prod_Glb_PetJumbo_MainTable_Intermediate_AllRecords();

                #endregion                

                TDJumboNo.Attributes.Add("style", "display:none");
                TDtxtJumboNo.Attributes.Add("style", "display:none");

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

    protected void gvPetJumboAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvPetJumboAll = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvPetJumboAll.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvPetJumboAll.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidIntermediatePetJumboId.Value = "";
                hidPetJumboId.Value = Convert.ToString(e.CommandArgument);

                #region Fill Whole Form

                Get_Prod_Glb_PetJumbo_MainDetails_BothTable(Convert.ToInt32(hidPetJumboId.Value), "Main");
                Get_Prod_Glb_PetJumbo_ShrinkPolariseCode_BothTable(Convert.ToInt32(hidPetJumboId.Value), "Main");
                Get_Prod_Glb_PetJumbo_JumboQualityAnalysis_BothTable(Convert.ToInt32(hidPetJumboId.Value), "Main");
                Get_Prod_Glb_PetJumbo_OtherDetails_BothTable(Convert.ToInt32(hidPetJumboId.Value), "Main");

                #endregion
            }
        }
        catch { }
    }

    protected void gvPetJumboFetchGridInterm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvPetJumboFetchGridInterm = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvPetJumboFetchGridInterm.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvPetJumboFetchGridInterm.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                hidPetJumboId.Value = "";
                HidIntermediatePetJumboId.Value = Convert.ToString(e.CommandArgument);

                #region Fill Whole Form From Selected Intermediate Row

                Get_Prod_Glb_PetJumbo_MainDetails_BothTable(Convert.ToInt32(HidIntermediatePetJumboId.Value), "Intermediate");
                Get_Prod_Glb_PetJumbo_ShrinkPolariseCode_BothTable(Convert.ToInt32(HidIntermediatePetJumboId.Value), "Intermediate");
                Get_Prod_Glb_PetJumbo_JumboQualityAnalysis_BothTable(Convert.ToInt32(HidIntermediatePetJumboId.Value), "Intermediate");
                Get_Prod_Glb_PetJumbo_OtherDetails_BothTable(Convert.ToInt32(HidIntermediatePetJumboId.Value), "Intermediate");

                #endregion
            }
        }
        catch { }
    }

    protected void gvPetJumboAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvPetJumboAll.PageIndex = e.NewPageIndex;
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            Get_Prod_Glb_PetJumbo_MainTable_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
            txtSearchList.Focus();
            ModalPopupExtender1.Show();
        }
        catch { }
    }

    protected void gvPetJumboFetchGridInterm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvPetJumboFetchGridInterm.PageIndex = e.NewPageIndex;
            Get_Prod_Glb_PetJumbo_MainTable_Intermediate_AllRecords();
        }
        catch { }
    }

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdProdPETJumbo = ConfigurationManager.AppSettings["FormIdProdPETJumbo"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProdPETJumbo);

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

    protected void Get_All_SubFilmType_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_SubFilmType_Mst();
            ddlSubFilmType.DataTextField = "SubFilmTypeName";
            ddlSubFilmType.DataValueField = "SubFilmTypeId";
            ddlSubFilmType.DataSource = colRCommontype;
            ddlSubFilmType.DataBind();
            ddlSubFilmType.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Thickness_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Thickness_Mst();
            ddlThickness.DataTextField = "Thickness";
            ddlThickness.DataValueField = "ThicknessId";
            ddlThickness.DataSource = colRCommontype;
            ddlThickness.DataBind();
            ddlThickness.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
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

    protected void Get_All_Prod_Shift_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Shift_Mst();
            ddlShift.DataTextField = "ShiftCode";
            ddlShift.DataValueField = "AutoId";
            ddlShift.DataSource = colRCommontype;
            ddlShift.DataBind();
            ddlShift.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Prod_Grade_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Grade_Mst();
            ddlGrade.DataTextField = "GradeCode";
            ddlGrade.DataValueField = "AutoId";
            ddlGrade.DataSource = colRCommontype;
            ddlGrade.DataBind();
            ddlGrade.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_Prod_Polrised_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Polrised_Mst();

            ddlPolarisedCode1.DataTextField = "PolCode";
            ddlPolarisedCode1.DataValueField = "AutoId";
            ddlPolarisedCode1.DataSource = colRCommontype;
            ddlPolarisedCode1.DataBind();
            ddlPolarisedCode1.Items.Insert(0, new ListItem("-Select-", ""));

            ddlPolarisedCode2.DataTextField = "PolCode";
            ddlPolarisedCode2.DataValueField = "AutoId";
            ddlPolarisedCode2.DataSource = colRCommontype;
            ddlPolarisedCode2.DataBind();
            ddlPolarisedCode2.Items.Insert(0, new ListItem("-Select-", ""));

            ddlPolarisedCode3.DataTextField = "PolCode";
            ddlPolarisedCode3.DataValueField = "AutoId";
            ddlPolarisedCode3.DataSource = colRCommontype;
            ddlPolarisedCode3.DataBind();
            ddlPolarisedCode3.Items.Insert(0, new ListItem("-Select-", ""));

            ddlPolarisedCode4.DataTextField = "PolCode";
            ddlPolarisedCode4.DataValueField = "AutoId";
            ddlPolarisedCode4.DataSource = colRCommontype;
            ddlPolarisedCode4.DataBind();
            ddlPolarisedCode4.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    protected void Get_All_FA_Glb_VendorMaster_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_FA_Glb_VendorMaster_Mst("");

            ddlMainSiloVendor1 .DataTextField = "VendorCodeName";
            ddlMainSiloVendor1.DataValueField = "VendorId";
            ddlMainSiloVendor1.DataSource = colRCommontype;
            ddlMainSiloVendor1.DataBind();
            ddlMainSiloVendor1.Items.Insert(0, new ListItem("-Select-", ""));

            ddlMainSiloVendor2.DataTextField = "VendorCodeName";
            ddlMainSiloVendor2.DataValueField = "VendorId";
            ddlMainSiloVendor2.DataSource = colRCommontype;
            ddlMainSiloVendor2.DataBind();
            ddlMainSiloVendor2.Items.Insert(0, new ListItem("-Select-", ""));

            ddlMainSiloVendor3.DataTextField = "VendorCodeName";
            ddlMainSiloVendor3.DataValueField = "VendorId";
            ddlMainSiloVendor3.DataSource = colRCommontype;
            ddlMainSiloVendor3.DataBind();
            ddlMainSiloVendor3.Items.Insert(0, new ListItem("-Select-", ""));

            ddlCoexVendor1.DataTextField = "VendorCodeName";
            ddlCoexVendor1.DataValueField = "VendorId";
            ddlCoexVendor1.DataSource = colRCommontype;
            ddlCoexVendor1.DataBind();
            ddlCoexVendor1.Items.Insert(0, new ListItem("-Select-", ""));

            ddlCoexVendor2.DataTextField = "VendorCodeName";
            ddlCoexVendor2.DataValueField = "VendorId";
            ddlCoexVendor2.DataSource = colRCommontype;
            ddlCoexVendor2.DataBind();
            ddlCoexVendor2.Items.Insert(0, new ListItem("-Select-", ""));

            ddlCoexVendor3.DataTextField = "VendorCodeName";
            ddlCoexVendor3.DataValueField = "VendorId";
            ddlCoexVendor3.DataSource = colRCommontype;
            ddlCoexVendor3.DataBind();
            ddlCoexVendor3.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    #endregion

    #region Function to Fill Form Data    

    #region Fetch Records Of MainDetailsTab

    protected void Get_Prod_Glb_PetJumbo_MainDetails_BothTable(int PetJumboId, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_PetJumbo_Tran.Get_Prod_Glb_PetJumbo_MainDetails_BothTable(PetJumboId, SearchType);
            if (dt.Rows.Count > 0)
            {
                if (SearchType == "Main")
                {
                    hidPetJumboId.Value = dt.Rows[0]["PetJumboId"].ToString();
                    TDJumboNo.Attributes.Add("style", "display:block");
                    TDtxtJumboNo.Attributes.Add("style", "display:block");  
                }
                else if (SearchType == "Intermediate")
                {
                    hidPetJumboId.Value = "";
                    TDJumboNo.Attributes.Add("style", "display:none");
                    TDtxtJumboNo.Attributes.Add("style", "display:none");  
                }
                if (dt.Rows[0]["LineId"].ToString() != "0")
                {
                    ddlLine.SelectedValue = dt.Rows[0]["LineId"].ToString();
                }
                else
                {
                    ddlLine.SelectedValue = "";
                }
                txtJumboNo.Text = dt.Rows[0]["JumboNo"].ToString();
                txtJumboDate.Text = dt.Rows[0]["JumboDate"].ToString();
                if (dt.Rows[0]["ShiftId"].ToString() != "0")
                {
                    ddlShift.SelectedValue = dt.Rows[0]["ShiftId"].ToString();
                }
                else
                {
                    ddlShift.SelectedValue = "";
                }
                txtDateIn.Text = dt.Rows[0]["DateIn"].ToString();
                if (dt.Rows[0]["TimeIn"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["TimeIn"].ToString();
                    string[] timearr = time.Split(':');
                    tsTimeIn.Hour = Convert.ToInt32(timearr[0]);
                    tsTimeIn.Minute = Convert.ToInt32(timearr[1]);
                }                
                txtDateOut.Text = dt.Rows[0]["DateOut"].ToString();
                if (dt.Rows[0]["TimeOut"].ToString().Contains(":"))
                {
                    string time = dt.Rows[0]["TimeOut"].ToString();
                    string[] timearr = time.Split(':');
                    tsTimeOut.Hour = Convert.ToInt32(timearr[0]);
                    tsTimeOut.Minute = Convert.ToInt32(timearr[1]);
                }               
                txtRawMaterial.Text = dt.Rows[0]["RawMaterial"].ToString();
                if (dt.Rows[0]["ThicknessId"].ToString() != "0")
                {
                    ddlThickness.SelectedValue = dt.Rows[0]["ThicknessId"].ToString();
                }
                else
                {
                    ddlThickness.SelectedValue = "";
                }
                ddlSubFilmType.SelectedValue = dt.Rows[0]["SubFilmTypeId"].ToString();
                txtRunNo.Text = dt.Rows[0]["RunNo"].ToString();
                if (dt.Rows[0]["GradeId"].ToString() != "0")
                {
                    ddlGrade.SelectedValue = dt.Rows[0]["GradeId"].ToString();
                }
                else
                {
                    ddlGrade.SelectedValue = "";
                }
                txtBreakNo.Text = dt.Rows[0]["BreakNo"].ToString();
                txtElectrodKW1.Text = dt.Rows[0]["ElectrodKW1"].ToString();
                txtAvgGuage.Text = dt.Rows[0]["AvgGuage"].ToString();
                txtCoreNo.Text = dt.Rows[0]["CoreNo"].ToString();
                txtOscillationNo.Text = dt.Rows[0]["OsicllationWidth"].ToString();
                txtElectrodKW2.Text = dt.Rows[0]["ElectrodKW2"].ToString();
                txtFinalWidth.Text = dt.Rows[0]["FinalWidth"].ToString();
                txtLength.Text = dt.Rows[0]["Length"].ToString();
                txtJoint.Text = dt.Rows[0]["Joint"].ToString();
                txtWeight.Text = dt.Rows[0]["Weight"].ToString();
                txtFrictionS.Text = dt.Rows[0]["FrictionS"].ToString();
                txtFrictionK.Text = dt.Rows[0]["FrictionK"].ToString();
                txtELMDLeft.Text = dt.Rows[0]["ELMDLeft"].ToString();
                txtELMDCenter.Text = dt.Rows[0]["ELMDCenter"].ToString();
                txtELMDRight.Text = dt.Rows[0]["ELMDRight"].ToString();
                txtELMDMainThick.Text = dt.Rows[0]["ELMDMainThick"].ToString();
                txtELTDLeft.Text = dt.Rows[0]["ELTDLeft"].ToString();
                txtELTDCenter.Text = dt.Rows[0]["ELTDCenter"].ToString();
                txtELTDRight.Text = dt.Rows[0]["ELTDRight"].ToString();
                txtELTDCoexThick.Text = dt.Rows[0]["ELTDCoexThick"].ToString();
                txtTSMDLeft.Text = dt.Rows[0]["TSMDLeft"].ToString();
                txtTSMDCenter.Text = dt.Rows[0]["TSMDCenter"].ToString();
                txtTSMDRight.Text = dt.Rows[0]["TSMDRight"].ToString();
                txtTSMDMainRPM.Text = dt.Rows[0]["TSMDMainRPM"].ToString();
                txtTSTDLeft.Text = dt.Rows[0]["TSTDLeft"].ToString();
                txtTSTDCenter.Text = dt.Rows[0]["TSTDCenter"].ToString();
                txtTSTDRight.Text = dt.Rows[0]["TSTDRight"].ToString();
                txtTSTDCoexRPM.Text = dt.Rows[0]["TSTDCoexRPM"].ToString();
                txtHaze1.Text = dt.Rows[0]["Haze1"].ToString();
                txtHaze2.Text = dt.Rows[0]["Haze2"].ToString();
                txtTapeTestSideCoated.Text = dt.Rows[0]["TapeTestSideCoated"].ToString();
                txtBothSide.Text = dt.Rows[0]["BothSide"].ToString();
                txtBreakDownVoltage.Text = dt.Rows[0]["BreakDownVoltage"].ToString();
                txtDynamicMin.Text = dt.Rows[0]["DynamicMin"].ToString();
                txtDynamicMax.Text = dt.Rows[0]["DynamicMax"].ToString();
            }            
        }
        catch (Exception ex) { }
    }

    #endregion

    #region Fetch Records Of ShrinkPolrisedTab

    protected void Get_Prod_Glb_PetJumbo_ShrinkPolariseCode_BothTable(int PetJumboId, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_PetJumbo_Tran.Get_Prod_Glb_PetJumbo_ShrinkPolariseCode_BothTable(PetJumboId, SearchType);
            if (dt.Rows.Count > 0)
            {
                if (SearchType == "Main")
                {
                    HidShrinkPolarisedID.Value = dt.Rows[0]["ShrinkPolarisedID"].ToString();
                }
                else if (SearchType == "Intermediate")
                {
                    HidShrinkPolarisedID.Value = "";
                }                
                txtPeakToPeak.Text = dt.Rows[0]["PeakToPeak"].ToString();
                txtF5MDAvg.Text = dt.Rows[0]["F5MDAvg"].ToString();
                txtF5TDAvg.Text = dt.Rows[0]["F5TDAvg"].ToString();
                txtCDSpread.Text = dt.Rows[0]["CDSpread"].ToString();
                txtYoungModulesMD.Text = dt.Rows[0]["YoungModulesMD"].ToString();
                txtF5MDLeft.Text = dt.Rows[0]["F5MDLeft"].ToString();
                txtF5MDRight.Text = dt.Rows[0]["F5MDRight"].ToString();
                txtYoungModulesTD.Text = dt.Rows[0]["YoungModulesTD"].ToString();
                txtF5MDCenter.Text = dt.Rows[0]["F5MDCenter"].ToString();
                txtMDL.Text = dt.Rows[0]["MDL"].ToString();
                txtMDC.Text = dt.Rows[0]["MDC"].ToString();
                txtMDR.Text = dt.Rows[0]["MDR"].ToString();
                txtTDL.Text = dt.Rows[0]["TDL"].ToString();
                txtTDC.Text = dt.Rows[0]["TDC"].ToString();
                txtTDR.Text = dt.Rows[0]["TDR"].ToString();
                if (dt.Rows[0]["PolarisedCode1"].ToString() != "0")
                {
                    ddlPolarisedCode1.SelectedValue = dt.Rows[0]["PolarisedCode1"].ToString();
                }
                else
                {
                    ddlPolarisedCode1.SelectedValue = "";
                }
                txtPolarisedTotal1.Text = dt.Rows[0]["PolarisedTotal1"].ToString();
                txtPolarisedCenter1.Text = dt.Rows[0]["PolarisedCenter1"].ToString();
                txtPolarisedRight1.Text = dt.Rows[0]["PolarisedRight1"].ToString();
                if (dt.Rows[0]["PolarisedCode2"].ToString() != "0")
                {
                    ddlPolarisedCode2.SelectedValue = dt.Rows[0]["PolarisedCode2"].ToString();
                }
                else
                {
                    ddlPolarisedCode2.SelectedValue = "";
                }
                txtPolarisedLeft2.Text = dt.Rows[0]["PolarisedLeft2"].ToString();
                txtPolarisedCenter2.Text = dt.Rows[0]["PolarisedCenter2"].ToString();
                txtPolarisedRight2.Text = dt.Rows[0]["PolarisedRight2"].ToString();
                if (dt.Rows[0]["PolarisedCode3"].ToString() != "0")
                {
                    ddlPolarisedCode3.SelectedValue = dt.Rows[0]["PolarisedCode3"].ToString();
                }
                else
                {
                    ddlPolarisedCode3.SelectedValue = "";
                }
                txtPolarisedLeft3.Text = dt.Rows[0]["PolarisedLeft3"].ToString();
                txtPolarisedCenter3.Text = dt.Rows[0]["PolarisedCenter3"].ToString();
                txtPolarisedRight3.Text = dt.Rows[0]["PolarisedRight3"].ToString();
                if (dt.Rows[0]["PolarisedCode4"].ToString() != "0")
                {
                    ddlPolarisedCode4.SelectedValue = dt.Rows[0]["PolarisedCode4"].ToString();
                }
                else
                {
                    ddlPolarisedCode4.SelectedValue = "";
                }
                txtPolarisedLeft4.Text = dt.Rows[0]["PolarisedLeft4"].ToString();
                txtPolarisedCenter4.Text = dt.Rows[0]["PolarisedCenter4"].ToString();
                txtPolarisedRight4.Text = dt.Rows[0]["PolarisedRight4"].ToString();
            }

        }
        catch (Exception ex) { }
    }

    #endregion

    #region Fetch Records Of JumboQualityAnalysisTab

    protected void Get_Prod_Glb_PetJumbo_JumboQualityAnalysis_BothTable(int PetJumboId, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_PetJumbo_Tran.Get_Prod_Glb_PetJumbo_JumboQualityAnalysis_BothTable(PetJumboId, SearchType);
            if (dt.Rows.Count > 0)
            {
                if (SearchType == "Main")
                {
                    HidJumboQualityId.Value = dt.Rows[0]["JumboQualityId"].ToString();
                }
                else if (SearchType == "Intermediate")
                {
                    HidJumboQualityId.Value = "";
                }                
                txtUnflush.Text = dt.Rows[0]["Unflush"].ToString();
                txtRoughCutting.Text = dt.Rows[0]["RoughCutting"].ToString();
                txtTelescoping.Text = dt.Rows[0]["Telescoping"].ToString();
                txtLooseWinding.Text = dt.Rows[0]["LooseWinding"].ToString();
                txtWindVariation.Text = dt.Rows[0]["WindVariation"].ToString();
                txtTrimInside.Text = dt.Rows[0]["TrimInside"].ToString();
                txtFoldInside.Text = dt.Rows[0]["FoldInside"].ToString();
                txtTrimCut.Text = dt.Rows[0]["TrimCut"].ToString();
                txtWrinklesInTop.Text = dt.Rows[0]["WrinklesInTop"].ToString();
                txtWrinklesInButtom.Text = dt.Rows[0]["WrinklesInButtom"].ToString();
                txtHardRipplesonTop.Text = dt.Rows[0]["HardRipplesonTop"].ToString();
                txtHardRipplesinBetween.Text = dt.Rows[0]["HardRipplesinBetween"].ToString();
                txtAccrossFullWidthScratch.Text = dt.Rows[0]["AccrossFullWidthScratch"].ToString();
                txtOnlyinSomePortionScratch.Text = dt.Rows[0]["OnlyinSomePortionScratch"].ToString();
                txtAccrossFullWidthHT.Text = dt.Rows[0]["AccrossFullWidthHT"].ToString();
                txtOnlyinSomePortionHT.Text = dt.Rows[0]["OnlyinSomePortionHT"].ToString();
                txtDieResetJumbo.Text = dt.Rows[0]["DieResetJumbo"].ToString();
                txtNegativeBandVisibleonWinder.Text = dt.Rows[0]["NegativeBandVisibleonWinder"].ToString();
                txtGuageBandVisibleonWinder.Text = dt.Rows[0]["GuageBandVisibleonWinder"].ToString();
                txtProcessConditionChanged.Text = dt.Rows[0]["ProcessConditionChanged"].ToString();
                txtShadeVariation.Text = dt.Rows[0]["ShadeVariation"].ToString();
                txtDifferentMicrons.Text = dt.Rows[0]["DifferentMicrons"].ToString();
                txtCoatedUncoated.Text = dt.Rows[0]["CoatedUncoated"].ToString();
                txtCoronaPlan.Text = dt.Rows[0]["CoronaPlan"].ToString();
                txtBlackDustParticle.Text = dt.Rows[0]["BlackDustParticle"].ToString();
                txtGels.Text = dt.Rows[0]["Gels"].ToString();
                txtUnmoltenParticle.Text = dt.Rows[0]["UnmoltenParticle"].ToString();
            }
        }
        catch (Exception ex) { }
    }

    #endregion

    #region Fetch Records Of OtherDetailsTab

    protected void Get_Prod_Glb_PetJumbo_OtherDetails_BothTable(int PetJumboId, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_PetJumbo_Tran.Get_Prod_Glb_PetJumbo_OtherDetails_BothTable(PetJumboId, SearchType);
            if (dt.Rows.Count > 0)
            {
                if (SearchType == "Main")
                {
                    HidOtherDetailsId.Value = dt.Rows[0]["OtherDetailsId"].ToString();
                }
                else if (SearchType == "Intermediate")
                {
                    HidOtherDetailsId.Value = "";
                }               
                txtRemarks1.Text = dt.Rows[0]["Remarks1"].ToString();
                txtRemarks2.Text = dt.Rows[0]["Remarks2"].ToString();
                if (dt.Rows[0]["JumboPlannedUnplanned"].ToString() == "True")
                {
                    chkJumboPlannedUnplanned.Checked = true;
                }
                else
                {
                    chkJumboPlannedUnplanned.Checked = false;
                }
                txtReasonforUnplanned.Text = dt.Rows[0]["ReasonforUnplanned"].ToString();
                txtTrimWeightpermtr.Text = dt.Rows[0]["TrimWeightpermtr"].ToString();
                txtJumboExtrusionQty.Text = dt.Rows[0]["JumboExtrusionQty"].ToString();
                txtMainSiloMaterialCode1.Text = dt.Rows[0]["MainSiloMaterialCode1"].ToString();
                txtMainSiloPercentage1.Text = dt.Rows[0]["MainSiloPercentage1"].ToString();
                txtMainSiloGrade1.Text = dt.Rows[0]["MainSiloGrade1"].ToString();
                if (dt.Rows[0]["MainSiloVendor1"].ToString() != "0")
                {
                    ddlMainSiloVendor1.SelectedValue = dt.Rows[0]["MainSiloVendor1"].ToString();
                }
                else
                {
                    ddlMainSiloVendor1.SelectedValue = "";
                }
                txtCoexMaterialCode1.Text = dt.Rows[0]["CoexMaterialCode1"].ToString();
                txtCoexPercentage1.Text = dt.Rows[0]["CoexPercentage1"].ToString();
                txtCoexGrade1.Text = dt.Rows[0]["CoexGrade1"].ToString();
                if (dt.Rows[0]["CoexVendor1"].ToString() != "0")
                {
                    ddlCoexVendor1.SelectedValue = dt.Rows[0]["CoexVendor1"].ToString();
                }
                else
                {
                    ddlCoexVendor1.SelectedValue = "";
                }
                txtMainSiloMaterialCode2.Text = dt.Rows[0]["MainSiloMaterialCode2"].ToString();
                txtMainSiloPercentage2.Text = dt.Rows[0]["MainSiloPercentage2"].ToString();
                txtMainSiloGrade2.Text = dt.Rows[0]["MainSiloGrade2"].ToString();
                if (dt.Rows[0]["MainSiloVendor2"].ToString() != "0")
                {
                    ddlMainSiloVendor2.SelectedValue = dt.Rows[0]["MainSiloVendor2"].ToString();
                }
                else
                {
                    ddlMainSiloVendor2.SelectedValue = "";
                }
                txtCoexMaterialCode2.Text = dt.Rows[0]["CoexMaterialCode2"].ToString();
                txtCoexPercentage2.Text = dt.Rows[0]["CoexPercentage2"].ToString();
                txtCoexGrade2.Text = dt.Rows[0]["CoexGrade2"].ToString();
                if (dt.Rows[0]["CoexVendor2"].ToString() != "0")
                {
                    ddlCoexVendor2.SelectedValue = dt.Rows[0]["CoexVendor2"].ToString();
                }
                else
                {
                    ddlCoexVendor2.SelectedValue = "";
                }
                txtMainSiloMaterialCode3.Text = dt.Rows[0]["MainSiloMaterialCode3"].ToString();
                txtMainSiloPercentage3.Text = dt.Rows[0]["MainSiloPercentage3"].ToString();
                txtMainSiloGrade3.Text = dt.Rows[0]["CoexMaterialCode3"].ToString();
                if (dt.Rows[0]["MainSiloVendor3"].ToString() != "0")
                {
                    ddlMainSiloVendor3.SelectedValue = dt.Rows[0]["MainSiloVendor3"].ToString();
                }
                else
                {
                    ddlMainSiloVendor3.SelectedValue = "";
                }
                txtCoexMaterialCode3.Text = dt.Rows[0]["CoexMaterialCode3"].ToString();
                txtCoexPercentage3.Text = dt.Rows[0]["CoexPercentage3"].ToString();
                txtCoexGrade3.Text = dt.Rows[0]["CoexGrade3"].ToString();
                if (dt.Rows[0]["CoexVendor3"].ToString() != "0")
                {
                    ddlCoexVendor3.SelectedValue = dt.Rows[0]["CoexVendor3"].ToString();
                }
                else
                {
                    ddlCoexVendor3.SelectedValue = "";
                }
            }

        }
        catch (Exception ex) { }
    }

    #endregion

    #endregion

    #region Function to clear records

    private void ClearMainDetailsTab()
    {
        try
        {
            TDJumboNo.Attributes.Add("style", "display:none");
            TDtxtJumboNo.Attributes.Add("style", "display:none");  
            hidPetJumboId.Value = "";
            HidIntermediatePetJumboId.Value = "";
            ddlLine.SelectedValue = "";
            txtJumboNo.Text = "";
            txtJumboDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            ddlShift.SelectedValue = "";
            txtDateIn.Text = "";
            //tsTimeIn.SetTime = "";
            txtDateOut.Text = "";
            //tsTimeOut.tex = "";
            txtRawMaterial.Text = "";
            ddlThickness.SelectedValue = "";
            ddlSubFilmType.SelectedValue = "";
            txtRunNo.Text = "";
            ddlGrade.SelectedValue = "";
            txtBreakNo.Text = "";
            txtElectrodKW1.Text = "";
            txtAvgGuage.Text = "";
            txtCoreNo.Text = "";
            txtOscillationNo.Text = "";
            txtElectrodKW2.Text = "";
            txtFinalWidth.Text = "";
            txtLength.Text = "";
            txtJoint.Text = "";
            txtWeight.Text = "";
            txtFrictionS.Text = "";
            txtFrictionK.Text = "";
            txtELMDLeft.Text = "";
            txtELMDCenter.Text = "";
            txtELMDRight.Text = "";
            txtELMDMainThick.Text = "";
            txtELTDLeft.Text = "";
            txtELTDCenter.Text = "";
            txtELTDRight.Text = "";
            txtELTDCoexThick.Text = "";
            txtTSMDLeft.Text = "";
            txtTSMDCenter.Text = "";
            txtTSMDRight.Text = "";
            txtTSMDMainRPM.Text = "";
            txtTSTDLeft.Text = "";
            txtTSTDCenter.Text = "";
            txtTSTDRight.Text = "";
            txtTSTDCoexRPM.Text = "";
            txtHaze1.Text = "";
            txtHaze2.Text = "";
            txtTapeTestSideCoated.Text = "";
            txtBothSide.Text = "";
            txtBreakDownVoltage.Text = "";
            txtDynamicMin.Text = "";
            txtDynamicMax.Text = "";
        }
        catch { }
    }

    private void ClearShrinkPolrisedTab()
    {
        try
        {
            HidShrinkPolarisedID.Value = "";
            txtPeakToPeak.Text = "";
            txtF5MDAvg.Text = "";
            txtF5TDAvg.Text = "";
            txtCDSpread.Text = "";
            txtYoungModulesMD.Text = "";
            txtF5MDLeft.Text = "";
            txtF5MDRight.Text = "";
            txtYoungModulesTD.Text = "";
            txtF5MDCenter.Text = "";
            txtMDL.Text = "";
            txtMDC.Text = "";
            txtMDR.Text = "";
            txtTDL.Text = "";
            txtTDC.Text = "";
            txtTDR.Text = "";
            ddlPolarisedCode1.SelectedValue = "";
            txtPolarisedTotal1.Text = "";
            txtPolarisedCenter1.Text = "";
            txtPolarisedRight1.Text = "";
            ddlPolarisedCode2.SelectedValue = "";
            txtPolarisedLeft2.Text = "";
            txtPolarisedCenter2.Text = "";
            txtPolarisedRight2.Text = "";
            ddlPolarisedCode3.SelectedValue = "";
            txtPolarisedLeft3.Text = "";
            txtPolarisedCenter3.Text = "";
            txtPolarisedRight3.Text = "";
            ddlPolarisedCode4.SelectedValue = "";
            txtPolarisedLeft4.Text = "";
            txtPolarisedCenter4.Text = "";
            txtPolarisedRight4.Text = "";


        }
        catch { }
    }

    private void ClearJumboQualityAnalysisTab()
    {
        try
        {
            HidJumboQualityId.Value = "";
            txtUnflush.Text = "";
            txtRoughCutting.Text = "";
            txtTelescoping.Text = "";
            txtLooseWinding.Text = "";
            txtWindVariation.Text = "";
            txtTrimInside.Text = "";
            txtFoldInside.Text = "";
            txtTrimCut.Text = "";
            txtWrinklesInTop.Text = "";
            txtWrinklesInButtom.Text = "";
            txtHardRipplesonTop.Text = "";
            txtHardRipplesinBetween.Text = "";
            txtAccrossFullWidthScratch.Text = "";
            txtOnlyinSomePortionScratch.Text = "";
            txtAccrossFullWidthHT.Text = "";
            txtOnlyinSomePortionHT.Text = "";
            txtDieResetJumbo.Text = "";
            txtNegativeBandVisibleonWinder.Text = "";
            txtGuageBandVisibleonWinder.Text = "";
            txtProcessConditionChanged.Text = "";
            txtShadeVariation.Text = "";
            txtDifferentMicrons.Text = "";
            txtCoatedUncoated.Text = "";
            txtCoronaPlan.Text = "";
            txtBlackDustParticle.Text = "";
            txtGels.Text = "";
            txtUnmoltenParticle.Text = "";
        }
        catch { }
    }

    private void ClearOtherDetailsTab()
    {
        try
        {
            HidOtherDetailsId.Value = "";
            txtRemarks1.Text = "";
            txtRemarks2.Text = "";
            chkJumboPlannedUnplanned.Checked = false;
            txtReasonforUnplanned.Text = "";
            txtTrimWeightpermtr.Text = "";
            txtJumboExtrusionQty.Text = "";
            txtMainSiloMaterialCode1.Text = "";
            txtMainSiloPercentage1.Text = "";
            txtMainSiloGrade1.Text = "";
            ddlMainSiloVendor1.SelectedValue = "";
            txtCoexMaterialCode1.Text = "";
            txtCoexPercentage1.Text = "";
            txtCoexGrade1.Text = "";
            ddlCoexVendor1.SelectedValue = "";
            txtMainSiloMaterialCode2.Text = "";
            txtMainSiloPercentage2.Text = "";
            txtMainSiloGrade2.Text = "";
            ddlMainSiloVendor2.SelectedValue = "";
            txtCoexMaterialCode2.Text = "";
            txtCoexPercentage2.Text = "";
            txtCoexGrade2.Text = "";
            ddlCoexVendor2.SelectedValue = "";
            txtMainSiloMaterialCode3.Text = "";
            txtMainSiloPercentage3.Text = "";
            txtMainSiloGrade3.Text = "";
            ddlMainSiloVendor3.SelectedValue = "";
            txtCoexMaterialCode3.Text = "";
            txtCoexPercentage3.Text = "";
            txtCoexGrade3.Text = "";
            ddlCoexVendor3.SelectedValue = "";
        }
        catch { }
    }

    #endregion      

    #region Function to fill List Grid

    private void Get_Prod_Glb_PetJumbo_MainTable_AllRecords(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_PetJumbo_Tran.Get_Prod_Glb_PetJumbo_MainTable_AllRecords(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvPetJumboAll.DataSource = dt;
                gvPetJumboAll.AllowPaging = true;
                gvPetJumboAll.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvPetJumboAll.AllowPaging = false;
                gvPetJumboAll.DataSource = "";
                gvPetJumboAll.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    #region Function to fill Intermediate List Grid

    private void Get_Prod_Glb_PetJumbo_MainTable_Intermediate_AllRecords()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_PetJumbo_Tran.Get_Prod_Glb_PetJumbo_IntermediateTable_AllRecords();
            if (dt.Rows.Count > 0)
            {
                gvPetJumboFetchGridInterm.DataSource = dt;
                gvPetJumboFetchGridInterm.AllowPaging = true;
                gvPetJumboFetchGridInterm.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvPetJumboFetchGridInterm.AllowPaging = false;
                gvPetJumboFetchGridInterm.DataSource = "";
                gvPetJumboFetchGridInterm.DataBind();
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