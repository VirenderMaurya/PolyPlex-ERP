using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_PaymentToVendor
/// </summary>
public class FA_PaymentToVendor
{
    #region Private Fields
    private string _vouchertype;
    private string _venderseries;
    private string _year;
    private int _voucherno;
    private DateTime _voucherdate;
    private string _bankaccountno;
    private string _vendor;
    private string _chequeno;
    private DateTime _chequedate;
    private string _currency;
    private double _exchangerate;
    private double _localbankcharges;
    private double _foreignbankcharges;
    private double _foreignbankchargesinLC;
    private double _fx;
    private double _adj;
    #endregion

    #region Public Fields
    public string VoucherType
    {
        get { return _vouchertype; }
        set{_vouchertype=value;    }
    }
    public string VoucherSeries
    {
        get { return _venderseries; }
        set { _venderseries = value; }
    }
    public string Year
    {
        get { return  _year; }
        set { _year = value; }
    }
    public int VoucherNo
    {
        get { return _voucherno; }
        set {_voucherno = value; }
    }
    public DateTime VoucherDate
    {
        get { return _voucherdate; }
        set { _voucherdate = value; }
    }
    public string BankAccountNo
    {
        get { return _bankaccountno; }
        set { _bankaccountno = value; }
    }
    public string Vendor
    {
        get { return _vendor; }
        set { _vendor = value; }
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
    public double LocalBankCharges
    {
        get { return _localbankcharges; }
        set { _localbankcharges = value; }
    }
    public double ForeignBankCharges
    {
        get { return _foreignbankcharges; }
        set { _foreignbankcharges = value; }
    }
    public double ForeignBankChargesinLC
    {
        get { return _foreignbankchargesinLC; }
        set { _foreignbankchargesinLC = value; }
    }
    public double Fx
    {
        get { return _fx; }
        set { _fx = value; }
    }
    public double Adj
    {
        get{return _adj;}
        set { _adj = value; }
    }

    #endregion

    public FA_PaymentToVendor Get_By_VoucherId(int voucherid)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.Get_By_VoucherId(voucherid);
    }
    
    public FA_PaymentToVendor()
	{
		
	}
    public int InsertPaymentheader(int voucherno,string vouchertype, string voucheryear, string voucherseries, DateTime voucherdate, string vendorname, string chequeno, DateTime chequedate, string currency, double exchangerate, double localbankcharges, double foreignbankcharges, double foreignbankchargesinlc, double fxplusminus, double adjplusminus, string polyplexbankaccount, int invoiceno)
    {
        SqlDataProvider db=new SqlDataProvider();
        return db.InsertPaymentheader(voucherno,vouchertype, voucheryear, voucherseries, voucherdate, vendorname, chequeno, chequedate, currency, exchangerate, localbankcharges, foreignbankcharges, foreignbankchargesinlc, fxplusminus, adjplusminus, polyplexbankaccount, invoiceno);      
    }
    public string GetLastVoucherNo()
     {
         SqlDataProvider sda = new SqlDataProvider();
         return sda.GetTopVoucherNo_FromPaymentToVendor().ToString();
     }
    
}