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


public class Common_mst
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields
    
    private bool _ActiveStatus;
    private int _OrganizationId;
    private string _DateFormat = "MM/dd/yyyy";
    private IFormatProvider _FormatProvider = new System.Globalization.CultureInfo("en-US", true);

    # region ProformInvoice Type
    private int _PerfInvTypeID;
    private string _PerfInvTypeName;
    #endregion

    # region Delivery To
    private int _DeliveryToID;
    private string _DeliveryToName;    
    #endregion

    # region Final Destination
    private int _FinalDestinationID;
    private string _FinalDestinationName;
    #endregion

    # region Logistic Master
    private int _LogisticID;
    private string _LogisticName;   
    #endregion

    # region Certificate Master
    private int _CertificateID;
    private string _CertificateName;
    #endregion

    # region Unit of Master
    private int _UnitSaleID;
    private string _UnitSaleName;
    #endregion

    # region Delivery Tolerance
    private int _DeliveryToleranceID;
    private string _DeliveryToleranceName;
    #endregion

    # region Currency Master
    private int _CurrencyID;
    private string _CurrencyCode;
    #endregion

    # region Paymode Master
    private int _PayModeID;
    private string _PaymodeName;
    #endregion

    # region Packing Standard Master
    private int _PackingStandardID;
    private string _PackingStandardName;
    #endregion

    # region FilmType Master
    private int _FilmTypeID;
    private string _FilmTypeName;
    #endregion

    # region Customer Name Master
    private int _CustomerID;
    private string _CustomerCode;
    private string _Name;
    #endregion

    # region Financial Year
    private int _FinancialStartDate;
    private int _FinancialStartMonth;
    private int _FinancialStartYear;
    private int _FinancialEndDate;
    private int _FinancialEndMonth;
    private int _FinancialEndYear;

    #endregion

    #region Invoice No

    #endregion

    #region OrderNo

    #endregion

    # region Environment Master
    private int _Environmentid;
    private string _EnvironmentName;
    #endregion

    # region Location Master
    private int _LocationID;
    private string _LocationName;
    #endregion

    #region Sticker Type

    private int _StickerTypeID;
    private string _StickerTypeName;

    #endregion

    #region Sales Area Master
    private int _AutoId;
    private string _SalesAreaCode;
    #endregion

    #region Sales Orgnization Master
    private string _SalesOrgCode;
    #endregion

    #region Distribution Channel Master
    private string _Code;
    #endregion

    #region Sub Film Type
    private int _SubFilmTypeId;
    private string _SubFilmTypeName;
    #endregion

    #region Thickness Master
    private int _ThicknessId;
    private string _Thickness;
    #endregion

    #region Prod Line Master
    private string _LineCode;
    #endregion

    #region Prod Grade Master
    private string _GradeCode;
    #endregion

    #region Prod Shift Master
    private string _ShiftCode;
    #endregion

    #region Prod Polrised Master
    private string _PolCode;
    #endregion

    #region FA Vendor Master
    private int _VendorId;
    private string _VendorCodeName;
    #endregion

    private string _AreaName;
    private string _DeptName;
    private string _MachineName;
    private string _SubMachineName;
    private string _KKName;
    private string _ProbDesc;

    private string _ProcessName;
    private string _BatchName;
    private string _MaterialName;
    private string _ValuationName;
    private string _StorageLocationName;
    private string _VendorBatchName;

    #endregion

    #region Properties

    public IFormatProvider FormatProvider
    {
        get { return _FormatProvider; }
    }

    public string ProcessName
    {
        get { return _ProcessName; }
        set { _ProcessName = value; }
    }
    public string BatchName
    {
        get { return _BatchName; }
        set { _BatchName = value; }
    }
    public string MaterialName
    {
        get { return _MaterialName; }
        set { _MaterialName = value; }
    }
    public string ValuationName
    {
        get { return _ValuationName; }
        set { _ValuationName = value; }
    }
    public string StorageLocationName
    {
        get { return _StorageLocationName; }
        set { _StorageLocationName = value; }
    }
    public string VendorBatchName
    {
        get { return _VendorBatchName; }
        set { _VendorBatchName = value; }
    }

    public string DateFormat
    {
        get { return _DateFormat; }
    }
    public int LocationID
    {
        get { return _LocationID; }
        set { _LocationID = value; }
    }
    public string LocationName
    {
        get { return _LocationName; }
        set { _LocationName = value; }
    }
    public bool ActiveStatus
    {
        get { return _ActiveStatus; }
        set { _ActiveStatus = value; }
    }

    public int PerfInvTypeID
    {
        get { return _PerfInvTypeID; }
        set { _PerfInvTypeID = value; }
    }
    public string PerfInvTypeName
    {
        get { return _PerfInvTypeName; }
        set { _PerfInvTypeName = value; }
    }


    public int DeliveryToID
    {
        get { return _DeliveryToID; }
        set { _DeliveryToID = value; }
    }
    public string DeliveryToName
    {
        get { return _DeliveryToName; }
        set { _DeliveryToName = value; }
    }

    public int FinalDestinationID
    {
        get { return _FinalDestinationID; }
        set { _FinalDestinationID = value; }
    }
    public string FinalDestinationName
    {
        get { return _FinalDestinationName; }
        set { _FinalDestinationName = value; }
    }

    public int LogisticID
    {
        get { return _LogisticID; }
        set { _LogisticID = value; }
    }
    public string LogisticName
    {
        get { return _LogisticName; }
        set { _LogisticName = value; }
    }

    public int CertificateID
    {
        get { return _CertificateID; }
        set { _CertificateID = value; }
    }
    public string CertificateName
    {
        get { return _CertificateName; }
        set { _CertificateName = value; }
    }

    public int UnitSaleID
    {
        get { return _UnitSaleID; }
        set { _UnitSaleID = value; }
    }
    public string UnitSaleName
    {
        get { return _UnitSaleName; }
        set { _UnitSaleName = value; }
    }

    public int DeliveryToleranceID
    {
        get { return _DeliveryToleranceID; }
        set { _DeliveryToleranceID = value; }
    }
    public string DeliveryToleranceName
    {
        get { return _DeliveryToleranceName; }
        set { _DeliveryToleranceName = value; }
    }

    public int CurrencyID
    {
        get { return _CurrencyID; }
        set { _CurrencyID = value; }
    }
    public string CurrencyCode
    {
        get { return _CurrencyCode; }
        set { _CurrencyCode = value; }
    }

    public int PayModeID
    {
        get { return _PayModeID; }
        set { _PayModeID = value; }
    }
    public string PaymodeName
    {
        get { return _PaymodeName; }
        set { _PaymodeName = value; }
    }

    public int PackingStandardID
    {
        get { return _PackingStandardID; }
        set { _PackingStandardID = value; }
    }
    public string PackingStandardName
    {
        get { return _PackingStandardName; }
        set { _PackingStandardName = value; }
    }

    public int FilmTypeID
    {
        get { return _FilmTypeID; }
        set { _FilmTypeID = value; }
    }
    public string FilmTypeName
    {
        get { return _FilmTypeName; }
        set { _FilmTypeName = value; }
    }

    public int CustomerID
    {
        get { return _CustomerID; }
        set { _CustomerID = value; }
    }
    public string CustomerCode
    {
        get { return _CustomerCode; }
        set { _CustomerCode = value; }
    }
    public string CustomerName
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public int FinancialStartDate
    {
        get { return _FinancialStartDate; }
        set { _FinancialStartDate = value; }
    }
    public int FinancialStartMonth
    {
        get { return _FinancialStartMonth; }
        set { _FinancialStartMonth = value; }
    }
    public int FinancialStartYear
    {
        get { return _FinancialStartYear; }
        set { _FinancialStartYear = value; }
    }
    public int FinancialEndDate
    {
        get { return _FinancialEndDate; }
        set { _FinancialEndDate = value; }
    }
    public int FinancialEndMonth
    {
        get { return _FinancialEndMonth; }
        set { _FinancialEndMonth = value; }
    }
    public int FinancialEndYear
    {
        get { return _FinancialEndYear; }
        set { _FinancialEndYear = value; }
    }

    public int OrganizationId
    {
        get { return _OrganizationId; }
        set { _OrganizationId = value; }
    }

    public int Environmentid
    {
        get { return _Environmentid; }
        set { _Environmentid = value; }
    }
    public string EnvironmentName
    {
        get { return _EnvironmentName; }
        set { _EnvironmentName = value; }
    }

    public int StickerTypeID
    {
        get { return _StickerTypeID; }
        set { _StickerTypeID = value; }
    }
    public string StickerTypeName
    {
        get { return _StickerTypeName; }
        set { _StickerTypeName = value; }
    }

    public int AutoId
    {
        get { return _AutoId; }
        set { _AutoId = value; }
    }
    public string SalesAreaCode
    {
        get { return _SalesAreaCode; }
        set { _SalesAreaCode = value; }
    }
    public string SalesOrgCode
    {
        get { return _SalesOrgCode; }
        set { _SalesOrgCode = value; }
    }
    public string Code
    {
        get { return _Code; }
        set { _Code = value; }
    }

    public int SubFilmTypeId
    {
        get { return _SubFilmTypeId; }
        set { _SubFilmTypeId = value; }
    }
    public string SubFilmTypeName
    {
        get { return _SubFilmTypeName; }
        set { _SubFilmTypeName = value; }
    }

    public int ThicknessId
    {
        get { return _ThicknessId; }
        set { _ThicknessId = value; }
    }
    public string Thickness
    {
        get { return _Thickness; }
        set { _Thickness = value; }
    }

    public string LineCode
    {
        get { return _LineCode; }
        set { _LineCode = value; }
    }
    public string GradeCode
    {
        get { return _GradeCode; }
        set { _GradeCode = value; }
    }
    public string ShiftCode
    {
        get { return _ShiftCode; }
        set { _ShiftCode = value; }
    }
    public string PolCode
    {
        get { return _PolCode; }
        set { _PolCode = value; }
    }

    public int VendorId
    {
        get { return _VendorId; }
        set { _VendorId = value; }
    }
    public string VendorCodeName
    {
        get { return _VendorCodeName; }
        set { _VendorCodeName = value; }
    }

    public string AreaName
    {
        get { return _AreaName; }
        set { _AreaName = value; }
    }
    public string DeptName
    {
        get { return _DeptName; }
        set { _DeptName = value; }
    }
    public string MachineName
    {
        get { return _MachineName; }
        set { _MachineName = value; }
    }
    public string SubMachineName
    {
        get { return _SubMachineName; }
        set { _SubMachineName = value; }
    }
    public string KKName
    {
        get { return _KKName; }
        set { _KKName = value; }
    }
    public string ProbDesc
    {
        get { return _ProbDesc; }
        set { _ProbDesc = value; }
    }

    #endregion

    #region Constructors
    public Common_mst()
	{
	}    

    #endregion

    #region Public Methods

    #region**************Fill Masters*****************

    public BLLCollection<Common_mst> Get_StickerType()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_StickerType();
    }
    public BLLCollection<Common_mst> Get_AllPIType()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_AllPIType_mst();
    }
    public BLLCollection<Common_mst> Get_AllDeliveryToType()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_AllDeliveryToType();
    }
    public BLLCollection<Common_mst> Get_AllFinalDestination()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_AllFinalDestination();
    }
    public BLLCollection<Common_mst> Get_All_Glb_Logistic_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Glb_Logistic_Master();
    }
    public BLLCollection<Common_mst> Get_All_Certificate_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Certificate_Master();
    }
    public BLLCollection<Common_mst> Get_All_UnitOfSale_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_UnitOfSale_Master();
    }
    public BLLCollection<Common_mst> Get_All_DeliveryTolerance_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_DeliveryTolerance_Master();
    }
    public BLLCollection<Common_mst> Get_All_Currency_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Currency_Master();
    }
    public BLLCollection<Common_mst> Get_All_Paymode_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Paymode_Master();
    }
    public BLLCollection<Common_mst> Get_All_PackingStandard_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_PackingStandard_Master();
    }
    public BLLCollection<Common_mst> Get_All_FilmType_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_FilmType_Master();
    }
    public BLLCollection<Common_mst> Get_All_Location_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Location_Master();
    }
    public BLLCollection<Common_mst> Get_All_Environment_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Environment_Master();
    }

    public BLLCollection<Common_mst> Get_All_SalesArea_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_SalesArea_Master();
    }
    public BLLCollection<Common_mst> Get_All_Salesorganization_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Salesorganization_Master();
    }
    public BLLCollection<Common_mst> Get_All_Distribution_Master()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Distribution_Master();
    }
    public BLLCollection<Common_mst> Get_All_SubFilmType_Mst()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_SubFilmType_Mst();
    }
    public BLLCollection<Common_mst> Get_All_Thickness_Mst()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Thickness_Mst();
    }

    public BLLCollection<Common_mst> Get_All_Prod_Line_Mst()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Line_Mst();
    }
    public BLLCollection<Common_mst> Get_All_Prod_Shift_Mst()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Shift_Mst();
    }
    public BLLCollection<Common_mst> Get_All_Prod_Grade_Mst()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Grade_Mst();
    }
    public BLLCollection<Common_mst> Get_All_Prod_Polrised_Mst()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Polrised_Mst();
    }
    public BLLCollection<Common_mst> Get_All_FA_Glb_VendorMaster_Mst(string SearchText)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_FA_Glb_VendorMaster_Mst(SearchText);
    }
    public BLLCollection<Common_mst> Get_All_Prod_Area_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Area_Mst(Search);
    }
    public BLLCollection<Common_mst> Get_All_Prod_Dept_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Dept_Mst(Search);
    }
    public BLLCollection<Common_mst> Get_All_Prod_Machine_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Machine_Mst(Search);
    }
    public BLLCollection<Common_mst> Get_All_Prod_SubMachine_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_SubMachine_Mst(Search);
    }
    public BLLCollection<Common_mst> Get_All_Prod_KKType_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_KKType_Mst(Search);
    }
    public BLLCollection<Common_mst> Get_All_Prod_Problem_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Problem_Mst(Search);
    }

    public BLLCollection<Common_mst> Get_All_Prod_Process_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Process_Mst(Search);
    }
    public BLLCollection<Common_mst> Get_All_Prod_Batch_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_Batch_Mst(Search);
    }
    public BLLCollection<Common_mst> Get_All_Prod_StorageLocation_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Prod_StorageLocation_Mst(Search);
    }
    public BLLCollection<Common_mst> Get_All_Proc_VendorBatch_Mst(string Search)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_All_Proc_VendorBatch_Mst(Search);
    }    

    #endregion

    #region**************Fill Popups*****************

    public DataTable FillAllCustomer(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_CustomerName";
        objSqlCommand.Parameters.AddWithValue("@Customer", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllConsigneeByCustomerId(string CustomerId, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_ConsigneeToName";
        objSqlCommand.Parameters.AddWithValue("@CustomerId", CustomerId);
        objSqlCommand.Parameters.AddWithValue("@ConsigneeName", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllTermsOfDelivery(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllTermsOfDelivery_Master";
        objSqlCommand.Parameters.AddWithValue("@TermsofDeliveryName", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllProformaInvoice(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllProformaInvoice";
        objSqlCommand.Parameters.AddWithValue("@PICode", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillOrderNoAndInvoiveNoOfPackingCreation(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetOrderNoAndInvoiveNoOfPackingCreation";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllPlantMaster(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllPlant_Master";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllMaterialMaster(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_Proc_MaterialMaster";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllValuationTypeMaster(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_Proc_ValuationClass_Master";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllCostCenterMaster(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_FA_Glb_CostCenterMaster_Mst";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllPurposeMaster(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_Proc_Purpose_Mst";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllProjectMaster(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_Fa_Glb_Projectmst";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillAllSubProjectMaster(string SearchText, int ProjectCode)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_Fa_Glb_SubProjectmst";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);
        objSqlCommand.Parameters.AddWithValue("@ProjectCode", ProjectCode);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion

    #region********************Fill Other Records************

    public DataTable Get_FinancialYear(string OrganizationId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetFinancialYear";
        objSqlCommand.Parameters.AddWithValue("@OrganizationId", OrganizationId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_SearchCriteria(string ModuleFormID)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_search_criteria";
        objSqlCommand.Parameters.AddWithValue("@ModuleFormID", ModuleFormID);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_UserLocation(string LoginId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_UserLocation";
        objSqlCommand.Parameters.AddWithValue("@LoginId", LoginId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion

    #endregion
}