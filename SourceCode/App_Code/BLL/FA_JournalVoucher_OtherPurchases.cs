using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FA_JournalVoucher_OtherPurchases
/// </summary>
/// 

public class FA_JournalVoucher_OtherPurchases
{
    SqlDataProvider sda = new SqlDataProvider();
    SqlCommand objSqlCommand = new SqlCommand();

    #region private variable
    private int _lineno;
    private string _voucherseries;
    private string _voucheryear;
    private string _voucherno;
    private string _voucherdate;
    private string _vendor;
    private string _vendorinvoice;
    private string _vendorinvoicedate;
    private string _invoicebldate;
    private int _creditdays;
    private string _duedate;
    private double _amount;
    private string _headerdesc;
    private string _asset;
    private string _empcode;
    private int _project;
    private int _subproject;
    private string _voucherdescription;
    private string _glcode;
    private string _glsubcode;
    private double _debitamount;
    private string _ccenter;
    private string _pcenter;
    private string _createdby;
    private DateTime _createddate;
    private string _detailsdesc;
    #endregion

    #region public properties
    public int LineNo
    {
        get { return _lineno; }
        set { _lineno = value; }
    }
   
    public string VoucherSeries
    {
        get { return _voucherseries; }
        set { _voucherseries = value; }
    }
    public string VoucherYear
    {
        get { return _voucheryear; }
        set { _voucheryear = value; }
    }
    public string VoucherNo
    {
        get { return _voucherno; }
        set { _voucherno = value; }
    }
    public string VoucherDate
    {
        get { return _voucherdate; }
        set { _voucherdate = value; }
    }
    public string Vendor
    {
        get { return _vendor; }
        set { _vendor = value; }
    }
    public string VendorInvoice
    {
        get { return _vendorinvoice; }
        set {_vendorinvoice = value; }
    }
    public string VendorInvoiceDate
    {
        get { return _vendorinvoicedate; }
        set { _vendorinvoicedate = value; }
    }
    public string InvoiceBLDate
    {
        get { return _invoicebldate; }
        set { _invoicebldate = value; }
    }
    public int CreditDays
    {
        get { return _creditdays; }
        set { _creditdays = value; }
    }
    public string DueDate
    {
        get { return _duedate; }
        set { _duedate = value; }
    }
    public double Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public string HeaderDesc
    {
        get { return _headerdesc; }
        set { _headerdesc = value; }
    }
    public string Asset
    {
        get { return _asset; }
        set { _asset = value; }
    }
    public string EmpCode
    {
        get { return _empcode; }
        set { _empcode = value; }
    }
    public int Project
    {
        get { return _project; }
        set { _project = value; }
    }
    public int SubProject
    {
        get { return _subproject; }
        set { _subproject = value; }
    }
    public string VoucherDescription
    {
        get { return _voucherdescription; }
        set { _voucherdescription = value; }
    }
    public string GlCode
    {
        get { return _glcode; }
        set { _glcode = value; }
    }
    public string GlSubCode
    {
        get { return _glsubcode; }
        set { _glsubcode = value; }
    }
    public double DebitAmount
    {
        get { return _debitamount; }
        set { _debitamount = value; }
    }
    public string CostCenter
    {
        get { return _ccenter; }
        set { _ccenter = value; }
    }
    public string ProfitCenter
    {
        get { return _pcenter; }
        set { _pcenter = value; }
    }
    public string CreatedBy
    {
        get { return _createdby; }
        set { _createdby = value; }
    }
    public DateTime CreatedDate
    {
        get { return _createddate; }
        set { _createddate = value; }
    }
    public string DetailDescription
    {
        get { return _detailsdesc; }
        set { _detailsdesc = value; }
    }

    #endregion

	public FA_JournalVoucher_OtherPurchases()
	{
		
	}
    public FA_JournalVoucher_OtherPurchases(int lineno, string voucherseries, string voucheryear, string voucherno, string voucherdate, string vendor,string vendorinvoice,string vendorinvoicedate,string invoicebldate,int creditdays,string duedate,double amount,string headerdesc,string asset, string empcode, int project, int subproject, string voucherdescription, string glcode, string glsubcode, double debitamount, double creditamount, string ccenter, string pcenter, string createdby, DateTime createddate,string detailsdesc)
     {
         _lineno = lineno;
         _voucherseries = voucherseries;
         _voucheryear = voucheryear;
         _voucherno = voucheryear;
         _voucherdate = voucherdate;
         _vendor = vendor;
         _vendorinvoice = vendorinvoice;
         _vendorinvoicedate = vendorinvoicedate;
         _invoicebldate = invoicebldate;
         _creditdays = creditdays;
         _duedate = duedate;
         _amount = amount;
         _headerdesc = headerdesc;
         _asset=asset;
         _empcode=empcode;
         _project=project;
         _subproject=subproject;
         _voucherdescription = voucherdescription;
         _glcode = glcode;
         _glsubcode = glsubcode;
         _debitamount = debitamount;
    
         _ccenter = ccenter;
         _pcenter = pcenter;
         _createdby = createdby;
         _createddate = createddate;
         _detailsdesc = detailsdesc;
     }

    public int insertjournal_otherpurchase_details()
    {
        return sda.inserjournal_Otherpurchases_details(this);
    }
    public int UpdateJournalVoucherOtherpurchase_Details(string VoucherNo, string LineNo, string GLCode, string SubGLCode, string ProfitCenter, string CostCenter, double DebitAmount, string Asset, string EmpCode, string Project, string SubProject, string VoucherDesc, string LastChange,string DetailsDesc)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateJournalVoucher_Otherpurchase_Details(VoucherNo, LineNo, GLCode, SubGLCode, ProfitCenter, CostCenter, DebitAmount, Asset, EmpCode, Project, SubProject, VoucherDesc, LastChange,DetailsDesc);
    }
    //
    public string GetLastVoucherNo_OtherPurchase()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetTopVoucherNo_OtherPurchase();
    }

    public DataTable Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_FA_Glb_JournalVoucher_OtherPurchaseAllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_FA_Glb_JournalVoucher_Otherpurchase_Details(string VoucherNo)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_FA_Glb_JournalVoucher_Otherpurchase_Details";
        objSqlCommand.Parameters.AddWithValue("@VoucherNo", VoucherNo);       

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_FA_Glb_Journal_OtherPurchase_VATDetails(string VoucherNo)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_FA_Glb_Journal_OtherPurchase_VATDetails";
        objSqlCommand.Parameters.AddWithValue("@VoucherNo", VoucherNo);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public int UpdateJournalVoucher_Otherpurchase_Headerdetails(string voucherseries, string voucheryear, string voucherno, string voucherdate, string Vendor, string VendorInvoice, string InvoiceDate, string InvoiceBLDate, string CreditDays, string DueDate, string Amount, string Description, string lastchange)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateJournalVoucher_Otherpurchase_HeaderDetails(voucherseries, voucheryear, voucherno, voucherdate, Vendor, VendorInvoice, InvoiceDate, InvoiceBLDate, CreditDays, DueDate, Amount, Description, lastchange);
    }

}