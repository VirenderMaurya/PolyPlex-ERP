using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_Journal_OtherPurchases_Vat
/// </summary>
public class FA_Journal_OtherPurchases_Vat
{

    #region private variables
    private int _lineno;
    private string _voucherno;
    private int _vatlineno;
    private string _vendorcode;
    private string _vendorname;
    private double _baseamount;
    private double _vamount;
    private string _taxinvoice;
    private string _taxinvoicedate;
    private double _rate;
    private string _createdby;
    private bool _active;
    #endregion


    #region Public properties
    public int LineNo
    {
        get { return _lineno; }
        set { _lineno = value; }
    }
    public string VoucherNo
    {
        get { return _voucherno; }
        set { _voucherno = value; }
    }
    public int VatLineNo
    {
        get { return _vatlineno; }
        set { _vatlineno = value; }
    }
    public string VendorCode
    {
        get { return _vendorcode; }
        set { _vendorcode = value; }
    }
    public string VendorName
    {
        get { return _vendorname; }
        set { _vendorname = value; }
    }
    public double BaseAmount
    {
        get { return _baseamount; }
        set { _baseamount = value; }
    }
    public double VAmount
    {
        get { return _vamount; }
        set { _vamount = value; }
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
    public double Rate
    {
        get { return _rate; }
        set { _rate = value; }
    }

    public string CreatedBy
    {
        get { return _createdby; }
        set { _createdby = value; }
    }
    public bool Active
    {
        get { return _active; }
        set { _active = value; }
    }
    #endregion

	public FA_Journal_OtherPurchases_Vat()
	{
	}
    public FA_Journal_OtherPurchases_Vat(int lineno, string voucherno, int vatlineno, string vendorcode, string vendorname, double baseamount, double vamount, string taxinvoice, string taxinviocedate, double rate, string createdby, bool active)
    {
        _lineno = lineno;
        _voucherno = voucherno;
        _vatlineno = vatlineno;
        _vendorcode = vendorcode;
        _vendorname = vendorname;
        _baseamount = baseamount;
        _vamount = vamount;
        _taxinvoice = taxinvoice;
        _taxinvoicedate = TaxInvoiceDate;
        _rate = rate;
        _createdby = createdby;
        _active = active;
   }

    public int insertjournal_Vatdetails_OtherPurchases()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.insertjournal_vatdetails_OtherPurchases(this);
    }

    public BLLCollection<FA_Journal_OtherPurchases_Vat> VatDetails_Otherpurchase_ByVoucherNo(string voucherno)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetVatDetails_Otherpurchase_By_Vrno(voucherno);
    }

    public int UpdateJournalVatdetails()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.updatejournal_vatdetails_otherpurchase(VoucherNo, VatLineNo, BaseAmount, VAmount, TaxInvoice, TaxInvoiceDate, CreatedBy, Rate);
    }
}