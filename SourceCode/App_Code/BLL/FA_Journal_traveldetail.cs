using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_Journal_traveldetail
/// </summary>
public class FA_Journal_traveldetail
{
    SqlDataProvider sda = new SqlDataProvider();
    #region private variables
     private string _voucherno;
     private int _lineno;
     private int _travellineno;
     private string _empcode;
     private string _empname;
     private int _countryclass;
     private int _noofdays;
     private DateTime _fromdate;
     private DateTime _todate;
     private double _da;
     private double _othercost;
     private string _createdby;
     private bool _active;
     #endregion

    #region public variables
     public string VoucherNo
     {
         get{ return _voucherno;}
         set{_voucherno=value;}
     }
     public int LineNo
     {
         get{ return _lineno;}
         set{_lineno=value;}
     }
     public int TravelLineNo
     {
         get{ return _travellineno;}
         set{ _travellineno=value;}
     }
     public string EmpCode
     {
         get{ return _empcode;}
         set{_empcode=value;}
     }
     public string EmpName
     {
         get{ return _empname;}
        set{_empname=value;}
     }
     public int CountryClass
     {
         get{ return _countryclass;}
         set{ _countryclass=value;}
     }
     public int NoOfDays
     {
         get{ return _noofdays;}
         set{_noofdays=value;}
     }
     public DateTime FromDate
    {
        get{ return _fromdate;}
        set{_fromdate=value;}
    }
     public DateTime ToDate
     {
        get{ return _todate;}
        set{_todate=value;}
     }
     public double DA
     {
         get{ return _da;}
         set{_da=value;}
     }
     public double OtherCost
     {
         get{ return _othercost;}
         set{_othercost=value;}
     }
     public string CreatedBy
     {
         get{ return _createdby;}
        set{_createdby=value;}
     }
     public bool Active
     {
         get{ return _active;}
         set{ _active=value;}
     }
     #endregion
     

	public FA_Journal_traveldetail()
	{

	}

    public FA_Journal_traveldetail(string voucherno,int lineno,int travellineno,string empcode,string empname,int countryclass,int noofdays,DateTime fromdate,DateTime todate,double da,double othercost,string createdby,bool active)
    {
        _voucherno = voucherno;
        _lineno = lineno;
        _travellineno = travellineno;
        _empcode = empcode;
        _empname = empname;
        _countryclass = countryclass;
        _noofdays = noofdays;
        _fromdate = fromdate;
        _todate = todate;
        _da = da;
        _othercost = othercost;
        _createdby = createdby;
        _active = active;
    }

    public int insertjournal_Traveldetails()
    {
        return sda.insertjournal_traveldetails(this);
    }
    public FA_Journal_traveldetail IsTravelDetailsExist(string voucherno,string travellineno)
    {
        return sda.GetTravelDetailsBy_Voucherno(voucherno, travellineno);
    }

    public int UpdateJournal_TravelDetails()
    {
       return sda.updatejournal_traveldetails(VoucherNo,TravelLineNo, CountryClass, NoOfDays, FromDate, ToDate, DA, OtherCost, CreatedBy);
    }

    public BLLCollection<FA_Journal_traveldetail> TravelDetails_ByVocherNo(string voucherno)
    {
        return sda.GetTravelDetailsBy_Vrno(voucherno);
    }

}