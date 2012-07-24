using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_PostPredefinedEntriesHistory
/// </summary>
public class FA_PostPredefinedEntriesHistory
{
    SqlDataProvider sda = new SqlDataProvider();
    #region private field
    int _entryno;
    string _postedby;
    #endregion

    #region Properties
    public int EntryNo
    {
        get { return _entryno; }
        set { _entryno = value; }
    }
    public string PostedBy
    {
        get { return _postedby; }
        set { _postedby = value; }
    }
    #endregion
	public FA_PostPredefinedEntriesHistory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public FA_PostPredefinedEntriesHistory(int entryno,string postedby)
	{
        _entryno = entryno;
        _postedby = postedby;
     }

  public int insertPostprededinedHistorydetails()
  {
      return sda.insertPostpredefinedHistorydetails(this);
  }
}