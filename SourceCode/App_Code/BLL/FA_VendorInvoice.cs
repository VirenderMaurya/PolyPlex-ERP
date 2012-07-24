using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_VendorInvoice
/// </summary>
public class FA_VendorInvoice
{
    #region private fields
    private int _invoiceno;
    private DateTime _invoicedate;
    private double _amountduefx;
    private string _currency;
    private double _exchangerate;
    private double _amountduelc;
    private DateTime _duedate;
    private double _amountpaid;
    private double _debitadjfx;
    private double _amountpaidlc;
    private double _debitadjlc;
    private int _voucherno;
    #endregion

    #region pubilc fields
    public int InvoiceNo
    {
        get { return _invoiceno; }
        set { _invoiceno = value; }
    }
    public DateTime InvoiceDate
    {
        get { return _invoicedate; }
        set { _invoicedate = value; }
    }
    public double AmountDueFx
    {
        get { return _amountduefx; }
        set { _amountduefx = value; }
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
    public double AmountDueLC
    {
        get { return _amountduelc; }
        set {_amountduelc = value; }
    }
    public DateTime DueDate
    {
        get { return _duedate; }
        set { _duedate = value; }
    }
    public double AmountPaid
    {
        get { return _amountpaid; }
        set { _amountpaid = value; }
    }
    public double DebitAdjFx
    {
        get { return _debitadjfx; }
        set { _debitadjfx = value; }
    }
    public double AmountPaidLC
    {
        get { return _amountpaidlc; }
        set { _amountpaidlc = value; }
    }
    public double DebitAdjLC
    {
        get { return _debitadjlc; }
        set { _debitadjlc = value; }
    }
    public int VoucherNo
    {
        get { return _voucherno; }
        set { _voucherno = value; }
    }
    #endregion

    public BLLCollection<FA_VendorInvoice> Get_VoucherInvoiceById(string vendorid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_VoucherInvoiceById(vendorid);
    }
    public BLLCollection<FA_VendorInvoice> Get_VoucherInvoiceByInvoiceid(string invoiceid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_VoucherInvoiceByInvoiceId(invoiceid);
    }
    public BLLCollection<FA_VendorInvoice> Get_Invoices(string invoiceno)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_VoucherInvoices(invoiceno);
    }
    public FA_VendorInvoice()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int InsertVendorInvoice_PaymentSent(int invoiceno,string changedby)
    {
        SqlDataProvider sda=new SqlDataProvider();
        return sda.InsertVendorInvoice_PaymentSent(invoiceno,changedby);
    }



}