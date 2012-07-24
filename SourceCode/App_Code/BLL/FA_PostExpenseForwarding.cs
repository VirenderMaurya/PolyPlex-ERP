using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_PostExpenseForwarding
/// </summary>
public class FA_PostExpenseForwarding
{
    SqlDataProvider sda = new SqlDataProvider();
    #region private field
    string _vouchertype;
    string _voucherseries;
    string _voucheryear;
    string _id;
    string _voucherno;
    string _LineItemId;
    string _voucherdate;
    string _fyear;
    string _vendorcode;
    string _remarks;
    string _invoiceid;
    string _expensetype;
    string _billno;
    string _billdate;
    string _currency;
    string _fxamount;
    string _fxrate;
    string _amountinusd;
    #endregion

    #region Properties
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
    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string VoucherNo
    {
        get { return _voucherno; }
        set { _voucherno = value; }
    }
    public string LineitemId
    {
        get { return _LineItemId; }
        set { _LineItemId = value; }
    }
    public string VoucherDate
    {
        get { return _voucherdate; }
        set { _voucherdate = value; }
    }
    public string FYear
    {
        get { return _voucherdate; }
        set { _voucherdate = value; }
    }
    public string VendorCode
    {
        get { return _vendorcode; }
        set { _vendorcode = value; }
    }
    public string Remarks
    {
        get { return _remarks; }
        set { _remarks = value; }
    }
    public string InvoiceId
    {
        get { return _invoiceid; }
        set { _invoiceid = value; }
    }
    public string ExpenseType
    {
        get { return _expensetype; }
        set {_expensetype = value; }
    }
    public string BillNo
    {
        get { return _billno; }
        set {_billno = value; }
    }
    public string BillDate
    {
        get { return _billdate; }
        set {_billdate = value; }
    }
    public string Currency
    {
        get { return _currency; }
        set {_currency = value; }
    }
    public string FxAmount
    {
        get { return _fxamount; }
        set { _fxamount = value; }
    }
    public string FxRate
    {
        get { return _fxrate; }
        set { _fxrate = value; }
    }
    public string AmountInUsed
    {
        get { return _amountinusd; }
        set { _amountinusd = value; }
    }
    #endregion

    public FA_PostExpenseForwarding()
	{
		
	}

    public  BLLCollection<FA_PostExpenseForwarding> GetExpenseForwarding(string voucherid)
    {
        return sda.GetAllExpenseForForwarding(voucherid);
    }

    public BLLCollection<FA_PostExpenseForwarding> BindByBillNo(string billno)
    {
        return sda.GetExpense_By_BillNo(billno);
    }

    public BLLCollection<FA_PostExpenseForwarding> BindBillNo(string billno)
    {
        return sda.GetExpenseBillNo(billno);
    }

    //public BLLCollection<FA_PostExpenseForwarding> BindVoucherId(string voucherno)
    //{
    //    return sda.GetExpenseByVoucherId(voucherno);
    //}   
    
    public int updateexpenseforwarding(string voucherid,string lineid)
    {
        return sda.Updateexpenseforwarding(voucherid,lineid);
    }

    public int insertexpenseforwarding(string voucherid, string vtype, string vseries, string vyear, string vdate, string createdby, string lineitemid)
    {
        return sda.insertexpenseforwarding(voucherid,vtype,vseries,vyear,vdate,createdby,lineitemid);
    }

}