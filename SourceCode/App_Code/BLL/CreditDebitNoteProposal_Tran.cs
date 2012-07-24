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


public class CreditDebitNoteProposal_Tran
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtCDNPLineItems;

    #region Private Fields

    private int _SalesTypeId;
    private string _Name;

    #region Header Fields

    private int _CBNId;    
    private string _CreditDebit;    
    private string _Year;
    private string _CRDBProposalNo;
    private string _Date;
    private string _Type;
    private string _MRNNo;
    private int _CustomerId;
    private string _DocumentNo;
    private string _DocumentDate;
    private string _From;
    private string _To;
    private string _Preamble;
    private string _Remarks;
    private double _Value;
    private double _Vat;
    private double _GrandTotal;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _ModifiedBy;

    #endregion

    #region LineItems

    private int _CBNLineItemId;
    private int _InvoiceId;
    private int _SalesOrderId;
    private int _SOLineItemId;
    private int _SubFilmTypeId;
    private string _Micron;
    private string _Core;
    private int _WidthInMM;
    private double _LengthInMtr;
    private double _UnitPrice;
    private double _ReqQuantityInKG;
    private int _Currency;
    private double _Rate;
    private double _Amount;
    private double _VatAmount;
    private double _NetAmount;
    private string _Description;

    #endregion

    #endregion

    #region Properties

    public int SalesTypeId
    {
        get { return _SalesTypeId; }
        set { _SalesTypeId = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    #region Header Properties

    public int CBNId
    {
        get { return _CBNId; }
        set { _CBNId = value; }
    }
    public string CreditDebit
    {
        get { return _CreditDebit; }
        set { _CreditDebit = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public string CRDBProposalNo
    {
        get { return _CRDBProposalNo; }
        set { _CRDBProposalNo = value; }
    }
    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }
    public string Type
    {
        get { return _Type; }
        set { _Type = value; }
    }
    public string MRNNo
    {
        get { return _MRNNo; }
        set { _MRNNo = value; }
    }
    public int CustomerId
    {
        get { return _CustomerId; }
        set { _CustomerId = value; }
    }
    public string DocumentNo
    {
        get { return _DocumentNo; }
        set { _DocumentNo = value; }
    }
    public string DocumentDate
    {
        get { return _DocumentDate; }
        set { _DocumentDate = value; }
    }
    public string From
    {
        get { return _From; }
        set { _From = value; }
    }
    public string To
    {
        get { return _To; }
        set { _To = value; }
    }
    public string Preamble
    {
        get { return _Preamble; }
        set { _Preamble = value; }
    }
    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    public double Value
    {
        get { return _Value; }
        set { _Value = value; }
    }
    public double Vat
    {
        get { return _Vat; }
        set { _Vat = value; }
    }
    public double GrandTotal
    {
        get { return _GrandTotal; }
        set { _GrandTotal = value; }
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

    #region Line Item Properties

    public int CBNLineItemId
    {
        get { return _CBNLineItemId; }
        set { _CBNLineItemId = value; }
    }
    public int InvoiceId
    {
        get { return _InvoiceId; }
        set { _InvoiceId = value; }
    }
    public int SalesOrderId
    {
        get { return _SalesOrderId; }
        set { _SalesOrderId = value; }
    }
    public int SOLineItemId
    {
        get { return _SOLineItemId; }
        set { _SOLineItemId = value; }
    }
    public int SubFilmTypeId
    {
        get { return _SubFilmTypeId; }
        set { _SubFilmTypeId = value; }
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
    public double LengthInMtr
    {
        get { return _LengthInMtr; }
        set { _LengthInMtr = value; }
    }
    public double UnitPrice
    {
        get { return _UnitPrice; }
        set { _UnitPrice = value; }
    }
    public double ReqQuantityInKG
    {
        get { return _ReqQuantityInKG; }
        set { _ReqQuantityInKG = value; }
    }
    public int Currency
    {
        get { return _Currency; }
        set { _Currency = value; }
    }
    public double Rate
    {
        get { return _Rate; }
        set { _Rate = value; }
    }
    public double Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }
    public double VatAmount
    {
        get { return _VatAmount; }
        set { _VatAmount = value; }
    }
    public double NetAmount
    {
        get { return _NetAmount; }
        set { _NetAmount = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    #endregion



    #endregion

    #region Public Methods

    public CreditDebitNoteProposal_Tran()
    { }

    public DataTable GetSalesType_Mst(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetSalesType_Mst";
        objSqlCommand.Parameters.AddWithValue("@SearchText", @SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_AllCreditDebitNoteType_Mst()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllCreditDebitNote_Type";       

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_InvoiceDetailBetweenFromAndToDate(string FromDate, string ToDate, string CustomerCode)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_InvoiceDetailBetweenFromAndToDate";
        objSqlCommand.Parameters.AddWithValue("@FromDate", FromDate);
        objSqlCommand.Parameters.AddWithValue("@ToDate", ToDate);
        objSqlCommand.Parameters.AddWithValue("@CustomerCode", CustomerCode);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_SelectedInvoiceDetailInCreditDebit(int Invoiceid)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_SelectedInvoiceDetailInCreditDebit";
        objSqlCommand.Parameters.AddWithValue("@Invoiceid", Invoiceid);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_CreditDebitNote_LineItem_TransByInvoiceId(int Invoiceid)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Sal_Glb_CreditDebitNote_LineItem_Trans";
        objSqlCommand.Parameters.AddWithValue("@Invoiceid", Invoiceid);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public string InsertUpdate_In_Sal_Glb_CreditDebitNote_Tran()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Sal_Glb_CreditDebitNote_Tran(this);
    }

    public DataTable Get_AllCreditDebitList(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "SP_Get_SAL_CreditDebitNoteList";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Check_ExistCreditDebitRecord(int CustomerId, string FromDate, string ToDate)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "SP_Check_ExistCreditDebitRecord";
        objSqlCommand.Parameters.AddWithValue("@CustomerId", CustomerId);
        objSqlCommand.Parameters.AddWithValue("@From", FromDate);
        objSqlCommand.Parameters.AddWithValue("@To", ToDate);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}