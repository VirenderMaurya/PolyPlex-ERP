using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FA_PredefinedEntries
/// </summary>
public class FA_PredefinedEntries
{
    SqlDataProvider sda = new SqlDataProvider();
    SqlCommand objSqlCommand = new SqlCommand();

  #region private field
  int _id;
  int _entryno;
  string _startdate;
  string _enddate;
  string _planned;
  string _glcode;
  string _profitcenter;
  string _subglcode;
  string _costcenter;
  string _description;
  double _debitamount;
  double _creditAmount;
  int    _lineNo;
  bool _active;
  string _postedby;
  string _postedon;
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
  public string Planned
  {
      get{return _planned;}
      set{_planned=value;}
  }
  public double DebitAmount
  {
      get{return _debitamount;}
      set{_debitamount=value;}
  }
  public double CreditAmount
  {
      get{return _creditAmount;}
      set{_creditAmount=value;}
  }
  public string GLCode
  {
      get{return _glcode;}
      set{_glcode=value;}
  }
  public string ProfitCenter
  {
      get{return _profitcenter;}
      set{_profitcenter=value;}
  }
  public string SubGLCode
  {
      get{return _subglcode;}
      set{_subglcode=value;}
  }
  public string CostCenter
  {
      get{return _costcenter;}
      set{_costcenter=value;}
  }
  public string Description
  {
      get{return _description;}
      set{_description=value;}
  }   
  public int LineNo
  {
      get{return _lineNo;}
      set{_lineNo=value;}
  }
  public bool Active
  {
      get{ return _active;}
      set { _active = value; }
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
  #endregion

  public FA_PredefinedEntries()
  {
  }
    
   public FA_PredefinedEntries(int entryno,string startdate,string enddate,string planned,double debitamount,double creditamount,string glcode,string profitcenter,string subgl,string costcenter,string description,int lineno,bool active)
	{
        _entryno = entryno;
        _startdate = startdate;
        _enddate = enddate;
        _planned = planned;
        _debitamount = debitamount;
        _creditAmount = creditamount;
        _glcode = glcode;
        _profitcenter = profitcenter;
        _subglcode = subgl;
        _costcenter = costcenter;
        _description = description;
        _lineNo = lineno;
        _active = active;
	}

  public int insertprededineddetails()
  {
     
      return sda.inserpredefineddetails(this);
  }

  public BLLCollection<FA_PredefinedEntries> Get_PredefinedAllRecords(string searchtype,string searchtext)
  {
      return  sda.GetAllPredefinedEntries(searchtype,searchtext);
  }

  public BLLCollection<FA_PredefinedEntries> GetAllPredefinedHistory()
  {
      return sda.GetAllPredefined();
  }
  public FA_PredefinedEntries GetPredefinedEntries_ById(int id)
  {
      return sda.GetPredefinedEntries_ById(id);
  }

  public int UpdatePredefinedEntries(int id)
  {
      return sda.UpdatePredefinedEntries(id,StartDate,EndDate,Planned,GLCode,ProfitCenter,SubGLCode,CostCenter,Description,DebitAmount,CreditAmount);
  }

  public int GetLastEntryNo()
  {
     return sda.GetLastEntryNo();
  }

  public DataTable Get_FA_GetAllPostPredefinedEntries(string SearchType, string SearchText)
  {
      objSqlCommand = new SqlCommand();
      objSqlCommand.CommandText = "Sp_FA_GetAllPostPredefinedEntries";
      objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
      objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

      SqlDataProvider db = new SqlDataProvider();
      return db.GetDataTableWithProc(objSqlCommand);
  }

  public DataTable Get_FA_GetAllPostPredefinedEntriesById(int Id)
  {
      objSqlCommand = new SqlCommand();
      objSqlCommand.CommandText = "Sp_Get_FA_GetAllPostPredefinedEntriesById";
      objSqlCommand.Parameters.AddWithValue("@Id", Id);      

      SqlDataProvider db = new SqlDataProvider();
      return db.GetDataTableWithProc(objSqlCommand);
  }
  
}












