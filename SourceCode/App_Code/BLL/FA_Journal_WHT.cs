using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_Journal_WHT
/// </summary>
public class FA_Journal_WHT
{

    SqlDataProvider sda = new SqlDataProvider();
     #region private variables
     private string _voucherno;
     private int _lineno;
     private int _whtlineno;
     private string _vendorcode;
     private string _vendorname;
     private int _whtgroup;
     private string _whttype;
     private double _baseamount;
     private double _whtrate;
     private double _whtamount;
     private string _createdby;
     private bool _active;
     #endregion

     #region public properties
     public string VoucherNo
     {
         get { return _voucherno; }
         set { _voucherno = value; }
     }
     public int LineNo
     {
         get { return _lineno; }
         set { _lineno = value; }
     }
     public int WhtLineNo
     {
         get { return _whtlineno; }
         set {_whtlineno = value; }
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
     public int WhtGroup
     {
         get { return _whtgroup; }
         set { _whtgroup = value; }
     }
     public string WhtType
     {
         get { return _whttype; }
         set { _whttype = value; }
     }
     public double BaseAmount
     {
         get { return _baseamount; }
         set { _baseamount = value; }
     }
     public double WhtRate
     {
         get { return _whtrate; }
         set { _whtrate = value; }
     }
     public double WhtAmount
     {
         get { return _whtamount; }
         set { _whtamount = value; }
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

     public FA_Journal_WHT()
     {
     }

     public FA_Journal_WHT(string voucherno, int lineno,int whtlineno, string vendorcode,string vendorname,int whtgroup,string whttype,double baseamount,double whtrate,double whtamount,string createdby, bool active)
     {
         _voucherno = voucherno;
         _lineno = lineno;
         _whtlineno = whtlineno;
         _vendorcode = vendorcode;
         _vendorname = vendorname;
         _whtgroup = whtgroup;
         _whttype = whttype;
         _baseamount = baseamount;
         _whtrate = whtrate;
         _whtamount = whtamount;
         _createdby = createdby;
         _active = active;
     }

     public int insertjournal_Whtdetails()
     {
        return sda.insertjournal_whtdetails(this);
     }

    public FA_Journal_WHT IsWHTDetailsExist(string voucherno,string lineno)
    {
        return sda.GetWHTDetailsBy_Voucherno(voucherno,lineno);
    }

    public BLLCollection<FA_Journal_WHT> GetWHTDetailsBy_Vrno(string voucherno)
    {
        return sda.GetWHTDetailsBy_Vrno(voucherno);
    }
    
    public int UpdateJournal_Whtdetails()
    {
        return sda.Updatejournal_whtdetails(VoucherNo,WhtLineNo,VendorCode,VendorName, WhtGroup, WhtType, BaseAmount, WhtRate, WhtAmount,CreatedBy);
    }
}