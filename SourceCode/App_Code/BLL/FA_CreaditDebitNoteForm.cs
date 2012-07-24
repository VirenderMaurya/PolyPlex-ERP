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

public class FA_CreaditDebitNoteForm
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtCDNPLineItems;

    #region Private Fields

    private int _CDNId;
    private int _CBDBProposalId;
    private string _CreditDebit;
    private int _SalesTypeId;
    private string _Year;
    private string _CRDBNo;
    private string _Date;
    private string _Type;
    private int _CurrencyId;
    private string _Description;
    private int _CustomerID;
    private double _ProfitCenter;
    private double _SalesAmount;
    private double _VATAmount;
    private double _Commission;
    private double _CashDiscount;
    private double _NetAmount;
    private string _NoteToCustomerVendor;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _ModifiedBy;

    #endregion

    #region Properties

    public int CDNId
    {
        get { return _CDNId; }
        set { _CDNId = value; }
    }
    public int CBDBProposalId
    {
        get { return _CBDBProposalId; }
        set { _CBDBProposalId = value; }
    }
    public string CreditDebit
    {
        get { return _CreditDebit; }
        set { _CreditDebit = value; }
    }
    public int SalesTypeId
    {
        get { return _SalesTypeId; }
        set { _SalesTypeId = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public string CRDBNo
    {
        get { return _CRDBNo; }
        set { _CRDBNo = value; }
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
    public int CurrencyId
    {
        get { return _CurrencyId; }
        set { _CurrencyId = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public int CustomerID
    {
        get { return _CustomerID; }
        set { _CustomerID = value; }
    }
    public double ProfitCenter
    {
        get { return _ProfitCenter; }
        set { _ProfitCenter = value; }
    }
    public double SalesAmount
    {
        get { return _SalesAmount; }
        set { _SalesAmount = value; }
    }
    public double VATAmount
    {
        get { return _VATAmount; }
        set { _VATAmount = value; }
    }
    public double Commission
    {
        get { return _Commission; }
        set { _Commission = value; }
    }
    public double CashDiscount
    {
        get { return _CashDiscount; }
        set { _CashDiscount = value; }
    }
    public double NetAmount
    {
        get { return _NetAmount; }
        set { _NetAmount = value; }
    }
    public string NoteToCustomerVendor
    {
        get { return _NoteToCustomerVendor; }
        set { _NoteToCustomerVendor = value; }
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

    #region Public Methods

    public FA_CreaditDebitNoteForm()
    { }

    public DataTable Get_CreditDebitNote_ByCDNNo(string CDNNo)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "SP_Get_CreditDebitNote_ByCDNNo";
        objSqlCommand.Parameters.AddWithValue("@CDNNo", CDNNo);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public int InsertUpdate_In_Sal_Glb_CreditDebitNote_Tran()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpadte_In_FA_Glb_CreditDebitNoteForm_Trans(this);
    }

    public DataTable Get_AllCreditDebitList(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "SP_Get_FA_CreditDebitNoteList";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_FA_CreditDebitNoteById(int CBDBProposalId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "SP_Get_FA_CreditDebitNoteById";
        objSqlCommand.Parameters.AddWithValue("@CBDBProposalId", CBDBProposalId);       

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion


    
}