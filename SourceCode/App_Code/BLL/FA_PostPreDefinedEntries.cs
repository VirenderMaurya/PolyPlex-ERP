using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PostPreDefinedEntries
/// </summary>
public class PostPreDefinedEntries
{
  SqlDataProvider sda = new SqlDataProvider();
  #region private field
  int _id;
  int _entryno;
  string _startdate;
  string _enddate;
  string _postedby;
  string _postedon;
  string _vouchertype;
  string _voucherseries;
  string _voucheryear;
  string _voucherno;
  string _voucherdate;
  string _planned;
  #endregion

  #region Properties
  public int Id
  {
      get { return _id; }
      set { _id = value; }
  }
  public int EntryNo
  {
      get { return _entryno; }
      set { _entryno = value; }
  }
  public string StartDate
  {
      get{return _startdate;}
      set{_startdate=value;}
  }
  public string EndDate
  {
      get{return _enddate;}
      set{_enddate=value;}
  }
  public string PostedBy
  {
      get { return _postedby; }
      set { _postedby = value; }
  }
  public string PostedOn
  {
      get { return _postedon; }
      set { _postedon = value; }
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
  public string VoucherDate
  {
      get { return _voucherdate; }
      set { _voucherdate = value; }
  }
  public string Planned
  {
      get { return _planned; }
      set { _planned = value; }
  }
  #endregion

  public PostPreDefinedEntries()
	{
	}
   public PostPreDefinedEntries(int entryno, string startdate, string enddate, string postedby,string vouchertype,string voucherseries,string voucheryear,string voucherdate,string planned)
	{
        _entryno = entryno;
        _startdate = startdate;
        _enddate = enddate;
        _postedby = postedby;
        _vouchertype = vouchertype;
        _voucherseries = voucherseries;
        _voucheryear = voucheryear;
        _voucherdate = voucherdate;
        _planned = planned;
    }

   public int insertPostprededineddetails(int entryno, string startdate, string enddate, string postedby, string vouchertype, string voucherseries, string voucheryear, string voucherdate, string planned)
  {
      return sda.insertPostpredefineddetails(entryno,startdate,enddate,postedby,vouchertype,voucherseries,voucheryear,voucherdate,planned);
  }
	
}