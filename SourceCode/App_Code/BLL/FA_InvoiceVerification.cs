using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_InvoiceVerification
/// </summary>
public class FA_InvoiceVerification
{
    #region private fields
    private string _voucherno;
    private string _voucherseries;
    private string _voucheryear;
    private string _ivtype;
    private string _vouchedate;
    private string _gr;
    private string _po;
    private string _vendor;
    private double _povalueinlc;
    private string _taxinvoice;
    private string _taxinvoicedate;
    private string _duedate;
    private double _pofxvalue;
    private double _pofxvaluealreadycreated;
    private string _paymenttermsinpo;
    private double _exchangerateinpo;
    private double _fxvalueinpo;
    private double _vat;
    private double _adjvalue;
    private double _vatadj;
    private double _importduty;
    private double _fxvalue;
    private string _currency;
    private double _exchangerate;
    private double _valueinlc;
    private string _createdby;
    #endregion


    #region properties

    public string VoucherNo
    {
        get { return _voucherno; }
        set { _voucherno = value; }
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
    public string IVType
    {
        get { return _ivtype; }
        set { _ivtype = value; }
    }
    public string VoucherDate
    {
        get { return _vouchedate; }
        set {_vouchedate = value; }
    }
    public string GR
    {
        get { return _gr; }
        set { _gr = value; }
    }
    public string PO
    {
        get { return _po; }
        set { _po = value; }
    }
    public string Vendor
    {
        get { return _vendor; }
        set { _vendor = value; }
    }
    public double POValueInLC
    {
        get { return _povalueinlc; }
        set { _povalueinlc = value; }
    }
    public string TaxInvoice
    {
        get { return _taxinvoice; }
        set { _taxinvoice = value; }
    }
    public string TaxInvoiceDate
    {
        get { return _taxinvoicedate; }
        set { _taxinvoicedate = value; }
    }
    public string DueDate
    {
        get { return _duedate; }
        set { _duedate = value; }
    }
    public double POFxValue
    {
        get { return _pofxvalue; }
        set { _pofxvalue = value; }
    }
    public double POFxValueAlreadyCreated
    {
        get { return _pofxvaluealreadycreated; }
        set {_pofxvaluealreadycreated = value; }
    }
    public string PaymentTermsInPO
    {
        get { return _paymenttermsinpo; }
        set { _paymenttermsinpo = value; }
    }
    public double ExchangerateInPO
    {
        get { return _exchangerateinpo; }
        set { _exchangerateinpo = value; }
    }
    public double FxValueInPO
    {
        get { return _fxvalueinpo; }
        set { _fxvalueinpo= value; }
    }
    public double Vat
    {
        get { return _vat; }
        set { _vat = value; }
    }
    public double AdjValue
    {
        get { return _adjvalue; }
        set { _adjvalue = value; }
    }
    public double VatAdj
    {
        get { return _vatadj; }
        set { _vatadj = value; }
    }
    public double ImportDuty
    {
        get { return _importduty; }
        set { _importduty = value; }
    }
    public double FxValue
    {
        get { return _fxvalue; }
        set { _fxvalue = value; }
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
    public double ValueInLC
    {
        get { return _valueinlc; }
        set {_valueinlc = value; }
    }
    public string CreatedBy
    {
        get { return _createdby; }
        set { _createdby = value; }
    }
    #endregion

    public FA_InvoiceVerification()
	{
	}

    public FA_InvoiceVerification(string voucherseries,string voucheryear,string ivtype,string vouchedate,string gr,string po,
                                  string vendor,double povalueinlc,string taxinvoice,string taxinvoicedate,string duedate,double pofxvalue,double pofxvaluealreadycreated,
                                  string paymenttermsinpo,double exchangerateinpo,double fxvalueinpo,double vat,double adjvalue,
                                  double vatadj,double importduty,double fxvalue,string currency,double exchangerate,double valueinlc,string createdby)
    {
        _voucherseries = voucherseries;
        _voucheryear = voucheryear;
        _ivtype = ivtype;
        _vouchedate = vouchedate;
        _gr = gr;
        _po = po;
        _vendor = vendor;
        _povalueinlc = povalueinlc;
        _taxinvoice = taxinvoice;
        _taxinvoicedate = taxinvoicedate;
        _duedate = duedate;
        _pofxvalue = pofxvalue;
        _pofxvaluealreadycreated = pofxvaluealreadycreated;
        _paymenttermsinpo = paymenttermsinpo;
        _exchangerateinpo = exchangerateinpo;
        _fxvalueinpo = fxvalueinpo;
        _vat = vat;
        _adjvalue = adjvalue;
        _vatadj = vatadj;
        _importduty = importduty;
        _fxvalue = fxvalue;
        _currency = currency;
        _exchangerate = exchangerate;
        _valueinlc = valueinlc;
        _createdby = createdby;
    }

    public int InsertInvoiceVerification()
    {
       SqlDataProvider sda=new SqlDataProvider();
       return sda.InsertInvoiceVerification(this);
    }
    public int UpdateInvoiceVerification(string voucherno,string voucherseries, string voucheryear, string ivtype, string vouchedate, string gr, string po,
                                  string vendor, double povalueinlc, string taxinvoice, string taxinvoicedate, string duedate, double pofxvaluealreadycreated,
                                  string paymenttermsinpo, double exchangerateinpo, double fxvalueinpo, double vat, double adjvalue,
                                  double vatadj, double importduty, double fxvalue, string currency, double exchangerate, double valueinlc, string modifiedby)
    {
       SqlDataProvider sda=new SqlDataProvider();
       return sda.UpdateInvoiceVerification(voucherno,voucherseries,voucheryear,ivtype,vouchedate,gr,po,
                                  vendor,povalueinlc,taxinvoice,taxinvoicedate,duedate,pofxvaluealreadycreated,
                                  paymenttermsinpo,exchangerateinpo,fxvalueinpo,vat, adjvalue,
                                  vatadj, importduty, fxvalue,currency,exchangerate,valueinlc,modifiedby);
    }
    

    public BLLCollection<FA_InvoiceVerification> GetAllVoucherno(string searchwhat)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetAllVoucherNo(searchwhat);
    }
    public FA_InvoiceVerification GetInvoiceVerification_HeaderInfo_By_Voucherno(string vnumber)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetInvoiceVerification_HeaderInfo_By_Voucherno(vnumber);
    }
}