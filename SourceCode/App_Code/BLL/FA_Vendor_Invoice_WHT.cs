using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_Vendor_Invoice_WHT
/// </summary>
public class FA_Vendor_Invoice_WHT
{

    #region Private fields
    private int _whtlineno;
    private int _vcode;
    private int _whtgrp;
    private string _typeofpayment;
    private double _bamt;
    private double _whtrate;
    private double _whtamount;
    #endregion

    #region Public fields
    public int WHTLineNo
    {
        get { return _whtlineno; }
        set { _whtlineno = value; }
    }
    public int VCode
    {
        get { return _vcode; }
        set { _vcode = value; }
    }
    public int WHTGRP
    {
        get { return _whtgrp; }
        set { _whtgrp = value; }
    }
    public string TypeOfPayment
    {
        get { return _typeofpayment; }
        set { _typeofpayment = value; }
    }
    public double BAmt
    {
        get { return _bamt; }
        set { _bamt= value; }
    }
    public double WhtRate
    {
        get { return _whtrate; }
        set { _whtrate= value; }
    }
    public double WHTAmount
    {
        get { return _whtamount; }
        set { _whtamount = value; }
    }
    #endregion

    public BLLCollection<FA_Vendor_Invoice_WHT> Get_InvoiceWHT_ById(int invoiceid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_InvoiceWHT_ById(invoiceid);
    }

    public double Get_BaseAmount_ById(int invoiceid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_BaseAmount_ById(invoiceid);
    }
    public double Get_WHTAmount_ById(int invoiceid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_WHTAmount_ById(invoiceid);
    }


    public int IsWHTExist(int invoiceno)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.IsWHTExist(invoiceno);
    }
    public int IsWHTExist_ByInvoiceId(int invoiceid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.IsWHTExist_ByInvoiceId(invoiceid);
    }
    public int insert(int voucherid,int invoiceno,double whtgroup,string whttype,double baseamount,double whtrate)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.Insert_VendorPaymentInvoiceLineItem_WHT(voucherid, invoiceno, whtgroup, whttype, baseamount, whtrate);
    }

    public FA_Vendor_Invoice_WHT()
	{
    }
}