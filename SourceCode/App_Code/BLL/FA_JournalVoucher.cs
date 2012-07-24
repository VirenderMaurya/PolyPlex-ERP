using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_JournalVoucher
/// </summary>
public class FA_JournalVoucher
{

     #region private variable
     private int _lineno;
     private string _vouchertype;
     private string _voucherseries;
     private string _voucheryear;
     private string _voucherno;
     private DateTime _voucherdate;
     private bool _markreversal;
     private string _currency;
     private double _exchangerate;
     private string _asset;
     private string _empcode;
     private double _fxamount;
     private int _project;
     private int _subproject;
     private string _voucherdescription;
     private string _glcode;
     private string _glsubcode;
     private double _debitamount;
     private double _creditamount;
     private string _ccenter;
     private string _pcenter;
     private string _chequeno;
     private DateTime _chequedate;
     private string _createdby;
     private DateTime _createddate;
     #endregion

     #region public properties
     public int LineNo
     {
         get { return _lineno; }
         set { _lineno = value; }
     }
     public string VoucherType
     {
         get { return _vouchertype; }
         set { _vouchertype = value; }
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
     public DateTime VoucherDate
     {
         get { return _voucherdate; }
         set { _voucherdate = value; }
     }
     public bool MarkReversal
     {
         get { return _markreversal; }
         set { _markreversal = value; }
     }
     public string Currency
     {
         get { return _currency; }
         set { _currency = value; }
     }
     public double ExchangeRate
     {
         get { return _exchangerate; }
         set { _exchangerate = value; }
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
     public double Fxamount
     {
         get { return _fxamount; }
         set { _fxamount = value; }
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
     public double CreditAmount
     {
         get { return _creditamount; }
         set {_creditamount = value; }
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
     public string ChequeNo
     {
         get { return _chequeno; }
         set { _chequeno = value; }
     }
     public DateTime ChequeDate
     {
         get { return _chequedate; }
         set { _chequedate = value; }
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
     #endregion

     
     
     public FA_JournalVoucher()
	  {
		
	  }

     public FA_JournalVoucher(int lineno,string vouchertype,string voucherseries,string voucheryear,string voucherno,DateTime voucherdate,bool markreveral,string currency, double exchangerate,string asset,string empcode,double fxamount,int project,int subproject,string voucherdescription,string glcode,string glsubcode,double debitamount,double creditamount,string ccenter,string pcenter,string chequeno,DateTime chequedate,string createdby,DateTime createddate)
     {
         _lineno = lineno;
         _vouchertype = vouchertype;
         _voucherseries = voucherseries;
         _voucheryear = voucheryear;
         _voucherno = voucheryear;
         _voucherdate = voucherdate;
         _markreversal = markreveral;
         _currency = currency;
         _exchangerate = exchangerate;
         _asset=asset;
         _empcode=empcode;
         _fxamount = fxamount;
         _project=project;
         _subproject=subproject;
         _voucherdescription = voucherdescription;
         _glcode = glcode;
         _glsubcode = glsubcode;
         _debitamount = debitamount;
         _creditamount = creditamount;
         _ccenter = ccenter;
         _pcenter = pcenter;
         _chequeno = chequeno;
         _chequedate = chequedate;
         _createdby = createdby;
         _createddate = createddate;
     }

     public int insertjournaldetails()
     {
         SqlDataProvider sda=new SqlDataProvider();
         return sda.inserjournaldetails(this);
     }

     public int UpdateJournalVoucher_Headerdetails(string vouchertype,string voucherseries,string voucheryear,string voucherno,DateTime voucherdate, bool markreversal,string lastchange,string currency,double exchangerate)
	 {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.UpdateJournalVoucher_HeaderDetails(vouchertype, voucherseries, voucheryear, voucherno, voucherdate, markreversal, lastchange, currency, exchangerate);
     }

     public int UpdateJournalVoucher_Details(string voucherno,string lineno, string glcode,string subglcode,string profitcenter,string costcenter, double debitamount, double creditamount,string chequeno, DateTime  chequedate, string lastchange,string asset,string empcode,double fxamount,string project,string subproject,string voucherdesc)
     {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.UpdateJournalVoucher_Details(voucherno, lineno, glcode, subglcode, profitcenter, costcenter, debitamount, creditamount, chequeno, chequedate, lastchange, asset, empcode, fxamount, project, subproject,voucherdesc);
     }
     public string GetLastVoucherNo()
     {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.GetTopVoucherNo();
     }
     public int GetLastLineNo()
     {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.GetTopLineNo();
     }

     public BLLCollection<FA_JournalVoucher> Search_JournalVoucher(string keyword)
     {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.Search_JournalVoucher_MarkReversal(keyword);
     }
     public FA_JournalVoucher GetBy_VoucherID(string voucherid)
     {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.Get_JournalVoucherDetails_ByVoucherId(voucherid); 
     }
     public BLLCollection<FA_JournalVoucher> GetBy_VoucherIDCol(string voucherid)
     {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.Get_JournalVoucherDetailsCol_ByVoucherId(voucherid); 
     }

     public FA_JournalVoucher GetBy_LineNo(string lineno,string voucherno)
     {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.Get_JournalVoucherDetailsCol_ByLineNo(lineno,voucherno);
     }
}