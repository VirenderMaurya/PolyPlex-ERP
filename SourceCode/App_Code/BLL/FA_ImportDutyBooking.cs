using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_ImportDutyBooking
/// </summary>
public class FA_ImportDutyBooking
{
    #region private variable
    private int _lineno;
    private string _voucheryear;
    private string _voucherno;
    private string _voucherdate;
    private string _glcode;
    private string _glsubcode;
    private string _inputsubcode;
    private string _pono;
    private double _dutyamount;
    private double _importvat;
    private double _misladj;
    private string _chequeno;
    private string _chequedate;
    private string _createdby;
    private DateTime _createddate;
    #endregion

    #region Properties
    public int LineNo
     {
         get { return _lineno; }
         set { _lineno = value; }
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
     public string InputSubCode
     {
         get { return _inputsubcode; }
         set { _inputsubcode = value; }
     }
     public string PONO
     {
         get { return _pono; }
         set { _pono = value; }
     }
     public double DutyAmount
     {
         get { return _dutyamount; }
         set { _dutyamount = value; }
     }
     public double ImportVat
     {
         get { return _importvat; }
         set { _importvat = value; }
     }
     public double MisLeAdj
     {
         get { return _misladj; }
         set { _misladj = value; }
     }
   
     public string ChequeNo
     {
         get { return _chequeno; }
         set { _chequeno = value; }
     }
     public string ChequeDate
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

    public FA_ImportDutyBooking()
	{

	}

    public FA_ImportDutyBooking(int lineno,string voucheryear,string voucherno,string voucherdate,string glcode,string glsubcode,string inputsubcode,
                                string pono,double dutyamount,double importvat,double misladj,string chequeno,string chequedate,string createdby,
                                DateTime createddate)
    {
        _lineno = lineno;
        _voucheryear = voucheryear;
        _voucherno = voucherno;
        _voucherdate = voucherdate;
        _glcode = glcode;
        _glsubcode = glsubcode;
        _inputsubcode = inputsubcode;
        _pono = pono;
        _dutyamount = dutyamount;
        _importvat = importvat;
        _misladj = misladj;
        _chequeno = chequeno;
        _chequedate = chequedate;
        _createdby = createdby;
        _createddate = createddate;
    }
    SqlDataProvider sda = new SqlDataProvider();
    public int insertimportdutybooking()
    {
      return sda.insertinimportdutybooking(this);
    }
    public int updateimportdutybooking(string voucherno,string glcode,string glsubcode,string inputsubcode,string chequeno,string cheqedate,string modifiedby)
    {
        return sda.updateinimportdutybooking(voucherno,glcode,glsubcode,inputsubcode,chequeno,cheqedate,modifiedby);
    }
    public BLLCollection<FA_ImportDutyBooking> GetAllImportDuty_Voucherno(string searchwhat)
    {
        return sda.GetAllImportDutyVoucherNo(searchwhat); 
    }

    public FA_ImportDutyBooking GetImportDuty_HeaderInfo_By_Voucherno(string vnumber)
    {
        return sda.GetImportDuty_HeaderInfo_By_Voucherno(vnumber);
    }
    public BLLCollection<FA_ImportDutyBooking> GetImportDuty_DetailsInfo_By_Voucherno(string vnumber)
    {
        return sda.GenerateImportDutyBooking_DetailsInfo_VoucherNo(vnumber);
    }
    

}