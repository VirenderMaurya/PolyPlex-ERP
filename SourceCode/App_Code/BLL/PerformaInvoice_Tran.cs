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


public class PerformaInvoice_Tran
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtPILineItems;

    #region Private Fields

    private string _SaveStatus;

    #region Header Fields

    private int _PerformaInvoiceID;
    private int _PerfInvTypeID;
    private string _Year;
    private string _PINo;
    private string _PIDate;
    private int _Customer;
    private int _Consignee;
    private int _DeliveryTo;
    private string _CustomerOrderNo;
    private string _CustomerArticleNo;
    private string _CustomerPartNo;
    private string _CustomerOrderDate;
    private int _FinalDestination;
    private int _DeliveryTolerance;
    private int _TermsOfDelivery;
    private int _Logistics;
    private int _Currency;
    private int _PaymentMode;
    private int _Certificates;
    private int _NoOfShipment;
    private int _PackingStandard;
    private int _RemittanceDays;
    private int _CreditDays;
    private int _FilmType;
    private int _UnitOfSales;

    private int _SalesAreaId;
    private int _SalesOrganizationId;
    private int _DistributionChannelId;
    private int _ProfitCenterId;

    private string _SpecialInstruction;
    private int _CreatedBy;
    private int _ModifiedBy;
    private string _StatusCode;

    #endregion

    # region Line Item Fields

    private int _LineItemID;   
    private int _LineNo;
    private int _SubFilmType;
    private string _Micron;
    private string _Core;
    private int _WidthInMM;
    private double _WidthInInch;
    private double _LengthInMtr;
    private double _LengthInFt;
    private double _UnitPrice;
    private int _NoOfRolls;
    private double _ReqQuantityInKG;
    private string _EstimatedDate;
    private string _Application;
    private double _COFMin;
    private double _COFMax;
    private double _ODMin;
    private double _ODAvg;
    private double _ODMax;
    private string _ShipmentNo;
    private bool _Include;   
    private bool _ActiveStatus;
    private string _PalletType;
    private int _NoofRollsInPallet;

    #endregion

    #endregion

    #region Properties

    public string SaveStatus
    {
        get { return _SaveStatus; }
        set { _SaveStatus = value; }
    }

    #region Header Properties

    public int PerformaInvoiceID
    {
        get { return _PerformaInvoiceID; }
        set { _PerformaInvoiceID = value; }
    }
    public int PerfInvTypeID
    {
        get { return _PerfInvTypeID; }
        set { _PerfInvTypeID = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public string PINo
    {
        get { return _PINo; }
        set { _PINo = value; }
    }
    public string PIDate
    {
        get { return _PIDate; }
        set { _PIDate = value; }
    }
    public int Customer
    {
        get { return _Customer; }
        set { _Customer = value; }
    }
    public int Consignee
    {
        get { return _Consignee; }
        set { _Consignee = value; }
    }
    public int DeliveryTo
    {
        get { return _DeliveryTo; }
        set { _DeliveryTo = value; }
    }
    public string CustomerOrderNo
    {
        get { return _CustomerOrderNo; }
        set { _CustomerOrderNo = value; }
    }
    public string CustomerArticleNo
    {
        get { return _CustomerArticleNo; }
        set { _CustomerArticleNo = value; }
    }
    public string CustomerPartNo
    {
        get { return _CustomerPartNo; }
        set { _CustomerPartNo = value; }
    }
    public string CustomerOrderDate
    {
        get { return _CustomerOrderDate; }
        set { _CustomerOrderDate = value; }
    }
    public int FinalDestination
    {
        get { return _FinalDestination; }
        set { _FinalDestination = value; }
    }
    public int DeliveryTolerance
    {
        get { return _DeliveryTolerance; }
        set { _DeliveryTolerance = value; }
    }
    public int TermsOfDelivery
    {
        get { return _TermsOfDelivery; }
        set { _TermsOfDelivery = value; }
    }
    public int Logistics
    {
        get { return _Logistics; }
        set { _Logistics = value; }
    }
    public int Currency
    {
        get { return _Currency; }
        set { _Currency = value; }
    }
    public int PaymentMode
    {
        get { return _PaymentMode; }
        set { _PaymentMode = value; }
    }
    public int Certificates
    {
        get { return _Certificates; }
        set { _Certificates = value; }
    }
    public int NoOfShipment
    {
        get { return _NoOfShipment; }
        set { _NoOfShipment = value; }
    }
    public int PackingStandard
    {
        get { return _PackingStandard; }
        set { _PackingStandard = value; }
    }
    public int RemittanceDays
    {
        get { return _RemittanceDays; }
        set { _RemittanceDays = value; }
    }
    public int CreditDays
    {
        get { return _CreditDays; }
        set { _CreditDays = value; }
    }
    public int FilmType
    {
        get { return _FilmType; }
        set { _FilmType = value; }
    }
    public int UnitOfSales
    {
        get { return _UnitOfSales; }
        set { _UnitOfSales = value; }
    }
    public int SalesAreaId
    {
        get { return _SalesAreaId; }
        set { _SalesAreaId = value; }
    }
    public int SalesOrganizationId
    {
        get { return _SalesOrganizationId; }
        set { _SalesOrganizationId = value; }
    }
    public int DistributionChannelId
    {
        get { return _DistributionChannelId; }
        set { _DistributionChannelId = value; }
    }
    public int ProfitCenterId
    {
        get { return _ProfitCenterId; }
        set { _ProfitCenterId = value; }
    }

    public string SpecialInstruction
    {
        get { return _SpecialInstruction; }
        set { _SpecialInstruction = value; }
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
    public string StatusCode
    {
        get { return _StatusCode; }
        set { _StatusCode = value; }
    }

    #endregion

    #region Line Item Properties

    public int LineItemID
    {
        get { return _LineItemID; }
        set { _LineItemID = value; }
    }    
    public int LineNo
    {
        get { return _LineNo; }
        set { _LineNo = value; }
    }
    public int SubFilmType
    {
        get { return _SubFilmType; }
        set { _SubFilmType = value; }
    }
    public string Micron
    {
        get { return _Micron; }
        set { _Micron = value; }
    }
    public string Core
    {
        get { return _Core; }
        set { _Core = value; }
    }
    public int WidthInMM
    {
        get { return _WidthInMM; }
        set { _WidthInMM = value; }
    }
    public double WidthInInch
    {
        get { return _WidthInInch; }
        set { _WidthInInch = value; }
    }
    public double LengthInMtr
    {
        get { return _LengthInMtr; }
        set { _LengthInMtr = value; }
    }
    public double LengthInFt
    {
        get { return _LengthInFt; }
        set { _LengthInFt = value; }
    }
    public double UnitPrice
    {
        get { return _UnitPrice; }
        set { _UnitPrice = value; }
    }
    public int NoOfRolls
    {
        get { return _NoOfRolls; }
        set { _NoOfRolls = value; }
    }
    public double ReqQuantityInKG
    {
        get { return _ReqQuantityInKG; }
        set { _ReqQuantityInKG = value; }
    }
    public string EstimatedDate
    {
        get { return _EstimatedDate; }
        set { _EstimatedDate = value; }
    }
    public string Application
    {
        get { return _Application; }
        set { _Application = value; }
    }
    public double COFMin
    {
        get { return _COFMin; }
        set { _COFMin = value; }
    }
    public double COFMax
    {
        get { return _COFMax; }
        set { _COFMax = value; }
    }
    public double ODMin
    {
        get { return _ODMin; }
        set { _ODMin = value; }
    }
    public double ODAvg
    {
        get { return _ODAvg; }
        set { _ODAvg = value; }
    }
    public double ODMax
    {
        get { return _ODMax; }
        set { _ODMax = value; }
    }
    public string ShipmentNo
    {
        get { return _ShipmentNo; }
        set { _ShipmentNo = value; }
    }
    public bool Include
    {
        get { return _Include; }
        set { _Include = value; }
    }    
    public bool ActiveStatus
    {
        get { return _ActiveStatus; }
        set { _ActiveStatus = value; }
    }
    public string PalletType
    {
        get { return _PalletType; }
        set { _PalletType = value; }
    }
    public int NoofRollsInPallet
    {
        get { return _NoofRollsInPallet; }
        set { _NoofRollsInPallet = value; }
    }

    #endregion

    #endregion

    #region Public Methods

    public PerformaInvoice_Tran()
    { }

    public string InsertUpdate_In_Glb_PerformaInvoice()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Glb_PerformaInvoice(this);
    }           

    public DataTable Get_PerformaInvoice_Header(int PerformaInvoiceID)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetSal_Glb_PerformaInvoiceHeader_Tran";
        objSqlCommand.Parameters.AddWithValue("@PerformaInvoiceID", PerformaInvoiceID);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_PerformaInvoice_LineItem(int PerformaInvoiceID)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetSal_Glb_PerformaInvoiceLineItem_Tran";
        objSqlCommand.Parameters.AddWithValue("@PerformaInvoiceID", PerformaInvoiceID);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_PerformaInvoiceAllRecords(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetSal_Glb_PerformaInvoiceAllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_GetPalletType(int SubFilmTypeId, string Micron, string Core, double WidthInMM, double LengthInMtr)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetPalletType";
        objSqlCommand.Parameters.AddWithValue("@SubFilmTypeId", SubFilmTypeId);
        objSqlCommand.Parameters.AddWithValue("@Micron", Micron);
        objSqlCommand.Parameters.AddWithValue("@Core", Core);
        objSqlCommand.Parameters.AddWithValue("@WidthInMM", WidthInMM);
        objSqlCommand.Parameters.AddWithValue("@LengthInMtr", LengthInMtr);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_ProfitCenter(int SalesAreaId, int SalesOrgId, int DistributionChannelId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_ProfitCenterByAreaOrgDistribution";
        objSqlCommand.Parameters.AddWithValue("@SalesAreaId", SalesAreaId);
        objSqlCommand.Parameters.AddWithValue("@SalesOrgId", SalesOrgId);
        objSqlCommand.Parameters.AddWithValue("@DistributionChannelId", DistributionChannelId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_UnitPricesFromMapping_Tran(int SalesAreaId, int SalesOrgId, int ThicknessId, int CustomerId, int FilmTypeId, int MaterialId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_UnitPricesFromMapping_Tran";
        objSqlCommand.Parameters.AddWithValue("@SalesAreaId", SalesAreaId);
        objSqlCommand.Parameters.AddWithValue("@SalesOrgId", SalesOrgId);
        objSqlCommand.Parameters.AddWithValue("@ThicknessId", ThicknessId);
        objSqlCommand.Parameters.AddWithValue("@CustomerId", CustomerId);
        objSqlCommand.Parameters.AddWithValue("@FilmTypeId", FilmTypeId);
        objSqlCommand.Parameters.AddWithValue("@MaterialId", MaterialId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}