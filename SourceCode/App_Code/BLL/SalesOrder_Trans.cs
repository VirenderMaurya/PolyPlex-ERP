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



public class SalesOrder_Trans
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtSOLineItems;

    #region Private Fields

    #region Header Fields

    private int _SalesOrderId;
    private string _SONo;
    private string _Year;
    private int _SOTypeID;    
    private string _SODate;
    private bool _Confirmed;
    private int _PINo;
    private int _SOCustomer;
    private string _CustomerOrderNo;
    private string _CustomerArticleNo;
    private string _CustomerPartNo;
    private string _CustomerOrderDate;
    private int _SOConsignee;
    private int _SODeliveryTo;
    private string _SOCustomerOrder;
    private string _SOCustomerOrderDate;
    private string _RevisionNo;
    private string _RevisionDate;
    private int _SOCreditDays;
    private int _SOCreditDaysFrom;
    private int _SOFinalDestination;
    private bool _PartialShipment;
    private int _SOCurrency;
    private int _TermsOfDelivery;
    private int _SOLogistics;    
    private bool _SOVAT;
    private int _SOFilmType;
    private int _SOUnitOfSales;

    private int _SalesAreaId;
    private int _SalesOrganizationId;
    private int _DistributionChannelId;
    private int _ProfitCenterId;

    private int _SOPaymentMode;
    private bool _SOCertificateOfOrigin;
    private string _SOPaymentTerms;
    private string _SOPaymentTerms1;
    private string _SOPaymentTerms2;
    private string _SOSpecailIntructions;
    private string _CommittedETD;
    private string _CommittedETA;
    private string _RevisedETD;
    private string _RevisedETA;
    private int _SOPackingStandard;    

    private int _SODeliveryTolerance;
    private double _SOInvoiceLength;
    private bool _AllowJoints;
    private int _SOStickerType;
    private double _SOServiceLength;
    private int _MaxLengthTolerance;
    private bool _SOFumigation;
    private int _SOCertificates;
    private string _COOCTH;
    private string _BOIIncentive;
    private string _StatusCode;
    private int _LocationID;

    #endregion

    #region LineItems

    private int _SOLineItemID;
    private int _LineNo;
    private int _SubFilmType;
    private string _SOMicron;
    private string _SOCore;
    private int _SOWidthInMM;
    private double _SOWidthInInch;
    private double _SOLengthInMtr;
    private double _SOLengthInFt;
    private double _SOUnitPrice;
    private int _SONoOfRolls;
    private double _SOReqQuantityInKG;
    private string _SODeliveryDate;
    private string _SOApplication;    
    private double _SOCOFMin;
    private double _SOCOFMax;
    private double _SOODMin;
    private double _SOODAvg;
    private double _SOODMax;
    private string _ShipmentNo;
    private bool _SOInclude;    
    private bool _ActiveStatus;
    private string _PalletType;
    private int _NoofRollsInPallet;    
    private int _CreatedBy;
    private int _ModifiedBy;

    #endregion

    #region Other Fields

    private int _idType;
    private string _TypeName;

    #endregion

    #endregion

    #region Properties

    public int idType
    {
        get { return _idType; }
        set { _idType = value; }
    }
    public string TypeName
    {
        get { return _TypeName; }
        set { _TypeName = value; }
    }

    #region Header Properties

    public int SalesOrderId
    {
        get { return _SalesOrderId; }
        set { _SalesOrderId = value; }
    }
    public string SONo
    {
        get { return _SONo; }
        set { _SONo = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public int SOTypeID
    {
        get { return _SOTypeID; }
        set { _SOTypeID = value; }
    }    
    public string SODate
    {
        get { return _SODate; }
        set { _SODate = value; }
    }
    public bool Confirmed
    {
        get { return _Confirmed; }
        set { _Confirmed = value; }
    }
    public int PINo
    {
        get { return _PINo; }
        set { _PINo = value; }
    }
    public int SOCustomer
    {
        get { return _SOCustomer; }
        set { _SOCustomer = value; }
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
    public int SOConsignee
    {
        get { return _SOConsignee; }
        set { _SOConsignee = value; }
    }
    public int SODeliveryTo
    {
        get { return _SODeliveryTo; }
        set { _SODeliveryTo = value; }
    }
    public string SOCustomerOrder
    {
        get { return _SOCustomerOrder; }
        set { _SOCustomerOrder = value; }
    }
    public string SOCustomerOrderDate
    {
        get { return _SOCustomerOrderDate; }
        set { _SOCustomerOrderDate = value; }
    }
    public string RevisionNo
    {
        get { return _RevisionNo; }
        set { _RevisionNo = value; }
    }
    public string RevisionDate
    {
        get { return _RevisionDate; }
        set { _RevisionDate = value; }
    }
    public int SOCreditDays
    {
        get { return _SOCreditDays; }
        set { _SOCreditDays = value; }
    }
    public int SOCreditDaysFrom
    {
        get { return _SOCreditDaysFrom; }
        set { _SOCreditDaysFrom = value; }
    }
    public int SOFinalDestination
    {
        get { return _SOFinalDestination; }
        set { _SOFinalDestination = value; }
    }
    public bool PartialShipment
    {
        get { return _PartialShipment; }
        set { _PartialShipment = value; }
    }
    public int SOCurrency
    {
        get { return _SOCurrency; }
        set { _SOCurrency = value; }
    }
    public int TermsOfDelivery
    {
        get { return _TermsOfDelivery; }
        set { _TermsOfDelivery = value; }
    }
    public int SOLogistics
    {
        get { return _SOLogistics; }
        set { _SOLogistics = value; }
    }
    public bool SOVAT
    {
        get { return _SOVAT; }
        set { _SOVAT = value; }
    }
    public int SOFilmType
    {
        get { return _SOFilmType; }
        set { _SOFilmType = value; }
    }
    public int SOUnitOfSales
    {
        get { return _SOUnitOfSales; }
        set { _SOUnitOfSales = value; }
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
    public int SOPaymentMode
    {
        get { return _SOPaymentMode; }
        set { _SOPaymentMode = value; }
    }
    public bool SOCertificateOfOrigin
    {
        get { return _SOCertificateOfOrigin; }
        set { _SOCertificateOfOrigin = value; }
    }
    public string SOPaymentTerms
    {
        get { return _SOPaymentTerms; }
        set { _SOPaymentTerms = value; }
    }
    public string SOPaymentTerms1
    {
        get { return _SOPaymentTerms1; }
        set { _SOPaymentTerms1 = value; }
    }
    public string SOPaymentTerms2
    {
        get { return _SOPaymentTerms2; }
        set { _SOPaymentTerms2 = value; }
    }
    public string SOSpecailIntructions
    {
        get { return _SOSpecailIntructions; }
        set { _SOSpecailIntructions = value; }
    }
    public string CommittedETD
    {
        get { return _CommittedETD; }
        set { _CommittedETD = value; }
    }
    public string CommittedETA
    {
        get { return _CommittedETA; }
        set { _CommittedETA = value; }
    }
    public string RevisedETD
    {
        get { return _RevisedETD; }
        set { _RevisedETD = value; }
    }
    public string RevisedETA
    {
        get { return _RevisedETA; }
        set { _RevisedETA = value; }
    }
    public int SOPackingStandard
    {
        get { return _SOPackingStandard; }
        set { _SOPackingStandard = value; }
    }
    public int SODeliveryTolerance
    {
        get { return _SODeliveryTolerance; }
        set { _SODeliveryTolerance = value; }
    }
    public double SOInvoiceLength
    {
        get { return _SOInvoiceLength; }
        set { _SOInvoiceLength = value; }
    }
    public bool AllowJoints
    {
        get { return _AllowJoints; }
        set { _AllowJoints = value; }
    }
    public int SOStickerType
    {
        get { return _SOStickerType; }
        set { _SOStickerType = value; }
    }
    public double SOServiceLength
    {
        get { return _SOServiceLength; }
        set { _SOServiceLength = value; }
    }
    public int MaxLengthTolerance
    {
        get { return _MaxLengthTolerance; }
        set { _MaxLengthTolerance = value; }
    }
    public bool SOFumigation
    {
        get { return _SOFumigation; }
        set { _SOFumigation = value; }
    }
    public int SOCertificates
    {
        get { return _SOCertificates; }
        set { _SOCertificates = value; }
    }
    public string COOCTH
    {
        get { return _COOCTH; }
        set { _COOCTH = value; }
    }
    public string BOIIncentive
    {
        get { return _BOIIncentive; }
        set { _BOIIncentive = value; }
    }
    public string StatusCode
    {
        get { return _StatusCode; }
        set { _StatusCode = value; }
    }
    public int LocationID
    {
        get { return _LocationID; }
        set { _LocationID = value; }
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

    #region Line Item Properties

    public int SOLineItemID
    {
        get { return _SOLineItemID; }
        set { _SOLineItemID = value; }
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
    public string SOMicron
    {
        get { return _SOMicron; }
        set { _SOMicron = value; }
    }
    public string SOCore
    {
        get { return _SOCore; }
        set { _SOCore = value; }
    }
    public int SOWidthInMM
    {
        get { return _SOWidthInMM; }
        set { _SOWidthInMM = value; }
    }
    public double SOWidthInInch
    {
        get { return _SOWidthInInch; }
        set { _SOWidthInInch = value; }
    }
    public double SOLengthInMtr
    {
        get { return _SOLengthInMtr; }
        set { _SOLengthInMtr = value; }
    }
    public double SOLengthInFt
    {
        get { return _SOLengthInFt; }
        set { _SOLengthInFt = value; }
    }
    public double SOUnitPrice
    {
        get { return _SOUnitPrice; }
        set { _SOUnitPrice = value; }
    }
    public int SONoOfRolls
    {
        get { return _SONoOfRolls; }
        set { _SONoOfRolls = value; }
    }
    public double SOReqQuantityInKG
    {
        get { return _SOReqQuantityInKG; }
        set { _SOReqQuantityInKG = value; }
    }
    public string SODeliveryDate
    {
        get { return _SODeliveryDate; }
        set { _SODeliveryDate = value; }
    }
    public string SOApplication
    {
        get { return _SOApplication; }
        set { _SOApplication = value; }
    }
    public double SOCOFMin
    {
        get { return _SOCOFMin; }
        set { _SOCOFMin = value; }
    }
    public double SOCOFMax
    {
        get { return _SOCOFMax; }
        set { _SOCOFMax = value; }
    }
    public double SOODMin
    {
        get { return _SOODMin; }
        set { _SOODMin = value; }
    }
    public double SOODAvg
    {
        get { return _SOODAvg; }
        set { _SOODAvg = value; }
    }
    public double SOODMax
    {
        get { return _SOODMax; }
        set { _SOODMax = value; }
    }
    public string ShipmentNo
    {
        get { return _ShipmentNo; }
        set { _ShipmentNo = value; }
    }
    public bool SOInclude
    {
        get { return _SOInclude; }
        set { _SOInclude = value; }
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

    #region Procedure Get All Description
    private const string Sp_GetOrderLineItems = "Sp_GetOrderLineItems";

    #endregion

    #region Public Methods    

    public string InsertUpdate_In_Glb_SalesOrder()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Glb_SalesOrder(this);
    }                   

    public DataTable Get_SearchOrderLineItem(int SalesOrderId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_SalesOrderLineItem";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_SalesOrderAllRecords(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetSal_Glb_SalesOrderAllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }    

    public DataTable Get_SalesOrder_Header(int SalesOrderID)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_SalesOrderHeader";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderID);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}