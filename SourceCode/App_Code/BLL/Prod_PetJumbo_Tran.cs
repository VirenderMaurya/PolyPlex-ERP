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
using System.Data.SqlClient;


public class Prod_PetJumbo_Tran
{
    SqlCommand objSqlCommand = new SqlCommand();
    //public DataTable dtCDNPLineItems;

    #region Private Fields

    #region MainDetails

    private int _PetJumboId;
    private int _IntermediatePetJumboId;
    private string _Year;
    private int _LineId;    
    private string _JumboDate;
    private int _ShiftId;
    private string _DateIn;
    private string _TimeIn;
    private string _DateOut;
    private string _TimeOut;
    private string _RawMaterial;
    private int _ThicknessId;
    private int _SubFilmTypeId;
    private string _RunNo;
    private int _GradeId;
    private string _BreakNo;
    private string _ElectrodKW1;
    private string _AvgGuage;
    private string _CoreNo;
    private double _OsicllationWidth;
    private string _ElectrodKW2;
    private double _FinalWidth;
    private double _Length;
    private string _Joint;
    private double _Weight;
    private string _FrictionS;
    private string _FrictionK;
    private string _ELMDLeft;
    private string _ELMDCenter;
    private string _ELMDRight;
    private string _ELMDMainThick;
    private string _ELTDLeft;
    private string _ELTDCenter;
    private string _ELTDRight;
    private string _ELTDCoexThick;
    private string _TSMDLeft;
    private string _TSMDCenter;
    private string _TSMDRight;
    private string _TSMDMainRPM;
    private string _TSTDLeft;
    private string _TSTDCenter;
    private string _TSTDRight;
    private string _TSTDCoexRPM;
    private string _Haze1;
    private string _Haze2;
    private string _TapeTestSideCoated;
    private string _BothSide;
    private string _BreakDownVoltage;
    private string _DynamicMin;
    private string _DynamicMax;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _ModifiedBy;    

    #endregion

    #region ShrinkPolariseCode

    private int _ShrinkPolarisedID;
    private string _PeakToPeak;
    private string _F5MDAvg;
    private string _F5TDAvg;
    private string _CDSpread;
    private string _YoungModulesMD;
    private string _F5MDLeft;
    private string _F5MDRight;
    private string _YoungModulesTD;
    private string _F5MDCenter;
    private string _MDL;
    private string _MDC;
    private string _MDR;
    private string _TDL;
    private string _TDC;
    private string _TDR;
    private int _PolarisedCode1;
    private string _PolarisedTotal1;
    private string _PolarisedCenter1;
    private string _PolarisedRight1;
    private int _PolarisedCode2;
    private string _PolarisedLeft2;
    private string _PolarisedCenter2;
    private string _PolarisedRight2;
    private int _PolarisedCode3;
    private string _PolarisedLeft3;
    private string _PolarisedCenter3;
    private string _PolarisedRight3;
    private int _PolarisedCode4;
    private string _PolarisedLeft4;
    private string _PolarisedCenter4;
    private string _PolarisedRight4;

    #endregion

    #region JumboQualityAnalysis

    private int _JumboQualityId;
    private string _Unflush;
    private string _RoughCutting;
    private string _Telescoping;
    private string _LooseWinding;
    private string _WindVariation;
    private string _TrimInside;
    private string _FoldInside;
    private string _TrimCut;
    private string _WrinklesInTop;
    private string _WrinklesInButtom;
    private string _HardRipplesonTop;
    private string _HardRipplesinBetween;
    private string _AccrossFullWidthScratch;
    private string _OnlyinSomePortionScratch;
    private string _AccrossFullWidthHT;
    private string _OnlyinSomePortionHT;
    private string _DieResetJumbo;
    private string _NegativeBandVisibleonWinder;
    private string _GuageBandVisibleonWinder;
    private string _ProcessConditionChanged;
    private string _ShadeVariation;
    private string _DifferentMicrons;
    private string _CoatedUncoated;
    private string _CoronaPlan;
    private string _BlackDustParticle;
    private string _Gels;
    private string _UnmoltenParticle;

    #endregion

    #region OtherDetails

    private int _OtherDetailsId;
    private string _Remarks1;
    private string _Remarks2;
    private bool _JumboPlannedUnplanned;
    private string _ReasonforUnplanned;
    private string _TrimWeightpermtr;
    private string _JumboExtrusionQty;
    private string _MainSiloMaterialCode1;
    private double _MainSiloPercentage1;
    private string _MainSiloGrade1;
    private int _MainSiloVendor1;
    private string _CoexMaterialCode1;
    private double _CoexPercentage1;
    private string _CoexGrade1;
    private int _CoexVendor1;
    private string _MainSiloMaterialCode2;
    private double _MainSiloPercentage2;
    private string _MainSiloGrade2;
    private int _MainSiloVendor2;
    private string _CoexMaterialCode2;
    private double _CoexPercentage2;
    private string _CoexGrade2;
    private int _CoexVendor2;
    private string _MainSiloMaterialCode3;
    private double _MainSiloPercentage3;
    private string _MainSiloGrade3;
    private int _MainSiloVendor3;
    private string _CoexMaterialCode3;
    private double _CoexPercentage3;
    private string _CoexGrade3;
    private int _CoexVendor3;

    #endregion

    #endregion

    #region Properties

    #region MainDetails

    public int PetJumboId
    {
        get { return _PetJumboId; }
        set { _PetJumboId = value; }
    }
    public int IntermediatePetJumboId
    {
        get { return _IntermediatePetJumboId; }
        set { _IntermediatePetJumboId = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public int LineId
    {
        get { return _LineId; }
        set { _LineId = value; }
    }
    public string JumboDate
    {
        get { return _JumboDate; }
        set { _JumboDate = value; }
    }
    public int ShiftId
    {
        get { return _ShiftId; }
        set { _ShiftId = value; }
    }
    public string DateIn
    {
        get { return _DateIn; }
        set { _DateIn = value; }
    }
    public string TimeIn
    {
        get { return _TimeIn; }
        set { _TimeIn = value; }
    }
    public string DateOut
    {
        get { return _DateOut; }
        set { _DateOut = value; }
    }
    public string TimeOut
    {
        get { return _TimeOut; }
        set { _TimeOut = value; }
    }
    public string RawMaterial
    {
        get { return _RawMaterial; }
        set { _RawMaterial = value; }
    }
    public int ThicknessId
    {
        get { return _ThicknessId; }
        set { _ThicknessId = value; }
    }
    public int SubFilmTypeId
    {
        get { return _SubFilmTypeId; }
        set { _SubFilmTypeId = value; }
    }
    public string RunNo
    {
        get { return _RunNo; }
        set { _RunNo = value; }
    }
    public int GradeId
    {
        get { return _GradeId; }
        set { _GradeId = value; }
    }
    public string BreakNo
    {
        get { return _BreakNo; }
        set { _BreakNo = value; }
    }
    public string ElectrodKW1
    {
        get { return _ElectrodKW1; }
        set { _ElectrodKW1 = value; }
    }
    public string AvgGuage
    {
        get { return _AvgGuage; }
        set { _AvgGuage = value; }
    }
    public string CoreNo
    {
        get { return _CoreNo; }
        set { _CoreNo = value; }
    }
    public double OsicllationWidth
    {
        get { return _OsicllationWidth; }
        set { _OsicllationWidth = value; }
    }
    public string ElectrodKW2
    {
        get { return _ElectrodKW2; }
        set { _ElectrodKW2 = value; }
    }
    public double FinalWidth
    {
        get { return _FinalWidth; }
        set { _FinalWidth = value; }
    }
    public double Length
    {
        get { return _Length; }
        set { _Length = value; }
    }
    public string Joint
    {
        get { return _Joint; }
        set { _Joint = value; }
    }
    public double Weight
    {
        get { return _Weight; }
        set { _Weight = value; }
    }
    public string FrictionS
    {
        get { return _FrictionS; }
        set { _FrictionS = value; }
    }
    public string FrictionK
    {
        get { return _FrictionK; }
        set { _FrictionK = value; }
    }
    public string ELMDLeft
    {
        get { return _ELMDLeft; }
        set { _ELMDLeft = value; }
    }
    public string ELMDCenter
    {
        get { return _ELMDCenter; }
        set { _ELMDCenter = value; }
    }
    public string ELMDRight
    {
        get { return _ELMDRight; }
        set { _ELMDRight = value; }
    }
    public string ELMDMainThick
    {
        get { return _ELMDMainThick; }
        set { _ELMDMainThick = value; }
    }
    public string ELTDLeft
    {
        get { return _ELTDLeft; }
        set { _ELTDLeft = value; }
    }
    public string ELTDCenter
    {
        get { return _ELTDCenter; }
        set { _ELTDCenter = value; }
    }
    public string ELTDRight
    {
        get { return _ELTDRight; }
        set { _ELTDRight = value; }
    }
    public string ELTDCoexThick
    {
        get { return _ELTDCoexThick; }
        set { _ELTDCoexThick = value; }
    }
    public string TSMDLeft
    {
        get { return _TSMDLeft; }
        set { _TSMDLeft = value; }
    }
    public string TSMDCenter
    {
        get { return _TSMDCenter; }
        set { _TSMDCenter = value; }
    }
    public string TSMDRight
    {
        get { return _TSMDRight; }
        set { _TSMDRight = value; }
    }
    public string TSMDMainRPM
    {
        get { return _TSMDMainRPM; }
        set { _TSMDMainRPM = value; }
    }
    public string TSTDLeft
    {
        get { return _TSTDLeft; }
        set { _TSTDLeft = value; }
    }
    public string TSTDCenter
    {
        get { return _TSTDCenter; }
        set { _TSTDCenter = value; }
    }
    public string TSTDRight
    {
        get { return _TSTDRight; }
        set { _TSTDRight = value; }
    }
    public string TSTDCoexRPM
    {
        get { return _TSTDCoexRPM; }
        set { _TSTDCoexRPM = value; }
    }
    public string Haze1
    {
        get { return _Haze1; }
        set { _Haze1 = value; }
    }
    public string Haze2
    {
        get { return _Haze2; }
        set { _Haze2 = value; }
    }
    public string TapeTestSideCoated
    {
        get { return _TapeTestSideCoated; }
        set { _TapeTestSideCoated = value; }
    }
    public string BothSide
    {
        get { return _BothSide; }
        set { _BothSide = value; }
    }
    public string BreakDownVoltage
    {
        get { return _BreakDownVoltage; }
        set { _BreakDownVoltage = value; }
    }
    public string DynamicMin
    {
        get { return _DynamicMin; }
        set { _DynamicMin = value; }
    }
    public string DynamicMax
    {
        get { return _DynamicMax; }
        set { _DynamicMax = value; }
    }
    public bool ActiveStatus
    {
        get { return _ActiveStatus; }
        set { _ActiveStatus = value; }
    }
    public int CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    public int ModifiedBy
    {
        get { return _ModifiedBy; }
        set { _ModifiedBy = value; }
    }     

    #endregion

    #region ShrinkPolariseCode

    public int ShrinkPolarisedID
    {
        get { return _ShrinkPolarisedID; }
        set { _ShrinkPolarisedID = value; }
    }
    public string PeakToPeak
    {
        get { return _PeakToPeak; }
        set { _PeakToPeak = value; }
    }
    public string F5MDAvg
    {
        get { return _F5MDAvg; }
        set { _F5MDAvg = value; }
    }
    public string F5TDAvg
    {
        get { return _F5TDAvg; }
        set { _F5TDAvg = value; }
    }
    public string CDSpread
    {
        get { return _CDSpread; }
        set { _CDSpread = value; }
    }
    public string YoungModulesMD
    {
        get { return _YoungModulesMD; }
        set { _YoungModulesMD = value; }
    }
    public string F5MDLeft
    {
        get { return _F5MDLeft; }
        set { _F5MDLeft = value; }
    }
    public string F5MDRight
    {
        get { return _F5MDRight; }
        set { _F5MDRight = value; }
    }
    public string YoungModulesTD
    {
        get { return _YoungModulesTD; }
        set { _YoungModulesTD = value; }
    }
    public string F5MDCenter
    {
        get { return _F5MDCenter; }
        set { _F5MDCenter = value; }
    }
    public string MDL
    {
        get { return _MDL; }
        set { _MDL = value; }
    }
    public string MDC
    {
        get { return _MDC; }
        set { _MDC = value; }
    }
    public string MDR
    {
        get { return _MDR; }
        set { _MDR = value; }
    }
    public string TDL
    {
        get { return _TDL; }
        set { _TDL = value; }
    }
    public string TDC
    {
        get { return _TDC; }
        set { _TDC = value; }
    }
    public string TDR
    {
        get { return _TDR; }
        set { _TDR = value; }
    }
    public int PolarisedCode1
    {
        get { return _PolarisedCode1; }
        set { _PolarisedCode1 = value; }
    }
    public string PolarisedTotal1
    {
        get { return _PolarisedTotal1; }
        set { _PolarisedTotal1 = value; }
    }
    public string PolarisedCenter1
    {
        get { return _PolarisedCenter1; }
        set { _PolarisedCenter1 = value; }
    }
    public string PolarisedRight1
    {
        get { return _PolarisedRight1; }
        set { _PolarisedRight1 = value; }
    }
    public int PolarisedCode2
    {
        get { return _PolarisedCode2; }
        set { _PolarisedCode2 = value; }
    }
    public string PolarisedLeft2
    {
        get { return _PolarisedLeft2; }
        set { _PolarisedLeft2 = value; }
    }
    public string PolarisedCenter2
    {
        get { return _PolarisedCenter2; }
        set { _PolarisedCenter2 = value; }
    }
    public string PolarisedRight2
    {
        get { return _PolarisedRight2; }
        set { _PolarisedRight2 = value; }
    }
    public int PolarisedCode3
    {
        get { return _PolarisedCode3; }
        set { _PolarisedCode3 = value; }
    }
    public string PolarisedLeft3
    {
        get { return _PolarisedLeft3; }
        set { _PolarisedLeft3 = value; }
    }
    public string PolarisedCenter3
    {
        get { return _PolarisedCenter3; }
        set { _PolarisedCenter3 = value; }
    }
    public string PolarisedRight3
    {
        get { return _PolarisedRight3; }
        set { _PolarisedRight3 = value; }
    }
    public int PolarisedCode4
    {
        get { return _PolarisedCode4; }
        set { _PolarisedCode4 = value; }
    }
    public string PolarisedLeft4
    {
        get { return _PolarisedLeft4; }
        set { _PolarisedLeft4 = value; }
    }
    public string PolarisedCenter4
    {
        get { return _PolarisedCenter4; }
        set { _PolarisedCenter4 = value; }
    }
    public string PolarisedRight4
    {
        get { return _PolarisedRight4; }
        set { _PolarisedRight4 = value; }
    }

    #endregion

    #region JumboQualityAnalysis

    public int JumboQualityId
    {
        get { return _JumboQualityId; }
        set { _JumboQualityId = value; }
    }
    public string Unflush
    {
        get { return _Unflush; }
        set { _Unflush = value; }
    }
    public string RoughCutting
    {
        get { return _RoughCutting; }
        set { _RoughCutting = value; }
    }
    public string Telescoping
    {
        get { return _Telescoping; }
        set { _Telescoping = value; }
    }
    public string LooseWinding
    {
        get { return _LooseWinding; }
        set { _LooseWinding = value; }
    }
    public string WindVariation
    {
        get { return _WindVariation; }
        set { _WindVariation = value; }
    }
    public string TrimInside
    {
        get { return _TrimInside; }
        set { _TrimInside = value; }
    }
    public string FoldInside
    {
        get { return _FoldInside; }
        set { _FoldInside = value; }
    }
    public string TrimCut
    {
        get { return _TrimCut; }
        set { _TrimCut = value; }
    }
    public string WrinklesInTop
    {
        get { return _WrinklesInTop; }
        set { _WrinklesInTop = value; }
    }
    public string WrinklesInButtom
    {
        get { return _WrinklesInButtom; }
        set { _WrinklesInButtom = value; }
    }
    public string HardRipplesonTop
    {
        get { return _HardRipplesonTop; }
        set { _HardRipplesonTop = value; }
    }
    public string HardRipplesinBetween
    {
        get { return _HardRipplesinBetween; }
        set { _HardRipplesinBetween = value; }
    }
    public string AccrossFullWidthScratch
    {
        get { return _AccrossFullWidthScratch; }
        set { _AccrossFullWidthScratch = value; }
    }
    public string OnlyinSomePortionScratch
    {
        get { return _OnlyinSomePortionScratch; }
        set { _OnlyinSomePortionScratch = value; }
    }
    public string AccrossFullWidthHT
    {
        get { return _AccrossFullWidthHT; }
        set { _AccrossFullWidthHT = value; }
    }
    public string OnlyinSomePortionHT
    {
        get { return _OnlyinSomePortionHT; }
        set { _OnlyinSomePortionHT = value; }
    }
    public string DieResetJumbo
    {
        get { return _DieResetJumbo; }
        set { _DieResetJumbo = value; }
    }
    public string NegativeBandVisibleonWinder
    {
        get { return _NegativeBandVisibleonWinder; }
        set { _NegativeBandVisibleonWinder = value; }
    }
    public string GuageBandVisibleonWinder
    {
        get { return _GuageBandVisibleonWinder; }
        set { _GuageBandVisibleonWinder = value; }
    }
    public string ProcessConditionChanged
    {
        get { return _ProcessConditionChanged; }
        set { _ProcessConditionChanged = value; }
    }
    public string ShadeVariation
    {
        get { return _ShadeVariation; }
        set { _ShadeVariation = value; }
    }
    public string DifferentMicrons
    {
        get { return _DifferentMicrons; }
        set { _DifferentMicrons = value; }
    }
    public string CoatedUncoated
    {
        get { return _CoatedUncoated; }
        set { _CoatedUncoated = value; }
    }
    public string CoronaPlan
    {
        get { return _CoronaPlan; }
        set { _CoronaPlan = value; }
    }
    public string BlackDustParticle
    {
        get { return _BlackDustParticle; }
        set { _BlackDustParticle = value; }
    }
    public string Gels
    {
        get { return _Gels; }
        set { _Gels = value; }
    }
    public string UnmoltenParticle
    {
        get { return _UnmoltenParticle; }
        set { _UnmoltenParticle = value; }
    }


    #endregion

    #region OtherDetails

    public int OtherDetailsId
    {
        get { return _OtherDetailsId; }
        set { _OtherDetailsId = value; }
    }
    public string Remarks1
    {
        get { return _Remarks1; }
        set { _Remarks1 = value; }
    }
    public string Remarks2
    {
        get { return _Remarks2; }
        set { _Remarks2 = value; }
    }
    public bool JumboPlannedUnplanned
    {
        get { return _JumboPlannedUnplanned; }
        set { _JumboPlannedUnplanned = value; }
    }
    public string ReasonforUnplanned
    {
        get { return _ReasonforUnplanned; }
        set { _ReasonforUnplanned = value; }
    }
    public string TrimWeightpermtr
    {
        get { return _TrimWeightpermtr; }
        set { _TrimWeightpermtr = value; }
    }
    public string JumboExtrusionQty
    {
        get { return _JumboExtrusionQty; }
        set { _JumboExtrusionQty = value; }
    }
    public string MainSiloMaterialCode1
    {
        get { return _MainSiloMaterialCode1; }
        set { _MainSiloMaterialCode1 = value; }
    }
    public double MainSiloPercentage1
    {
        get { return _MainSiloPercentage1; }
        set { _MainSiloPercentage1 = value; }
    }
    public string MainSiloGrade1
    {
        get { return _MainSiloGrade1; }
        set { _MainSiloGrade1 = value; }
    }
    public int MainSiloVendor1
    {
        get { return _MainSiloVendor1; }
        set { _MainSiloVendor1 = value; }
    }
    public string CoexMaterialCode1
    {
        get { return _CoexMaterialCode1; }
        set { _CoexMaterialCode1 = value; }
    }
    public double CoexPercentage1
    {
        get { return _CoexPercentage1; }
        set { _CoexPercentage1 = value; }
    }
    public string CoexGrade1
    {
        get { return _CoexGrade1; }
        set { _CoexGrade1 = value; }
    }
    public int CoexVendor1
    {
        get { return _CoexVendor1; }
        set { _CoexVendor1 = value; }
    }
    public string MainSiloMaterialCode2
    {
        get { return _MainSiloMaterialCode2; }
        set { _MainSiloMaterialCode2 = value; }
    }
    public double MainSiloPercentage2
    {
        get { return _MainSiloPercentage2; }
        set { _MainSiloPercentage2 = value; }
    }
    public string MainSiloGrade2
    {
        get { return _MainSiloGrade2; }
        set { _MainSiloGrade2 = value; }
    }
    public int MainSiloVendor2
    {
        get { return _MainSiloVendor2; }
        set { _MainSiloVendor2 = value; }
    }
    public string CoexMaterialCode2
    {
        get { return _CoexMaterialCode2; }
        set { _CoexMaterialCode2 = value; }
    }
    public double CoexPercentage2
    {
        get { return _CoexPercentage2; }
        set { _CoexPercentage2 = value; }
    }
    public string CoexGrade2
    {
        get { return _CoexGrade2; }
        set { _CoexGrade2 = value; }
    }
    public int CoexVendor2
    {
        get { return _CoexVendor2; }
        set { _CoexVendor2 = value; }
    }
    public string MainSiloMaterialCode3
    {
        get { return _MainSiloMaterialCode3; }
        set { _MainSiloMaterialCode3 = value; }
    }
    public double MainSiloPercentage3
    {
        get { return _MainSiloPercentage3; }
        set { _MainSiloPercentage3 = value; }
    }
    public string MainSiloGrade3
    {
        get { return _MainSiloGrade3; }
        set { _MainSiloGrade3 = value; }
    }
    public int MainSiloVendor3
    {
        get { return _MainSiloVendor3; }
        set { _MainSiloVendor3 = value; }
    }
    public string CoexMaterialCode3
    {
        get { return _CoexMaterialCode3; }
        set { _CoexMaterialCode3 = value; }
    }
    public double CoexPercentage3
    {
        get { return _CoexPercentage3; }
        set { _CoexPercentage3 = value; }
    }
    public string CoexGrade3
    {
        get { return _CoexGrade3; }
        set { _CoexGrade3 = value; }
    }
    public int CoexVendor3
    {
        get { return _CoexVendor3; }
        set { _CoexVendor3 = value; }
    }

    #endregion

    #endregion

    #region Public Methods

    public Prod_PetJumbo_Tran()
    { }

    public string InsertAndUpdate_In_Prod_Glb_MainDetails_Trans()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertAndUpdate_In_Prod_Glb_MainDetails_Trans(this);
    }

    public DataTable Get_Prod_Glb_PetJumbo_MainTable_AllRecords(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Glb_PetJumbo_MainTable_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_Glb_PetJumbo_IntermediateTable_AllRecords()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Glb_PetJumbo_IntermediateTable_AllRecords";            

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_Glb_PetJumbo_MainDetails_BothTable(int PetJumboId, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Glb_PetJumbo_MainDetails_BothTable";
        objSqlCommand.Parameters.AddWithValue("@PetJumboId", PetJumboId);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_Glb_PetJumbo_ShrinkPolariseCode_BothTable(int PetJumboId, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Glb_PetJumbo_ShrinkPolariseCode_BothTable";
        objSqlCommand.Parameters.AddWithValue("@PetJumboId", PetJumboId);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_Glb_PetJumbo_JumboQualityAnalysis_BothTable(int PetJumboId, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Glb_PetJumbo_JumboQualityAnalysis_BothTable";
        objSqlCommand.Parameters.AddWithValue("@PetJumboId", PetJumboId);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_Glb_PetJumbo_OtherDetails_BothTable(int PetJumboId, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Glb_PetJumbo_OtherDetails_BothTable";
        objSqlCommand.Parameters.AddWithValue("@PetJumboId", PetJumboId);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion

}