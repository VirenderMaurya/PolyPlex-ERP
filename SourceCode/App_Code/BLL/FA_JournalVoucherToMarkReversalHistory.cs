using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_JournalVoucherToMarkReversalHistory
/// </summary>
public class FA_JournalVoucherToMarkReversalHistory
{

    #region private fields
    private string _voucherno;
    private bool _markreversalstatus;
    private string _createdby;
    #endregion

    #region public properties
    public string VoucherNo
    {
        get { return _voucherno; }
        set { _voucherno = value; }
    }
    public bool MarkReversalStatus
    {
        get { return _markreversalstatus; }
        set { _markreversalstatus = value; }
    }
    public string CreatedBy
    {
        get { return _createdby; }
        set { _createdby = value; }
    }

    #endregion

    public FA_JournalVoucherToMarkReversalHistory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public FA_JournalVoucherToMarkReversalHistory(string voucherno, bool markreversalstatus, string createdby)
    {
        _voucherno = voucherno;
        _markreversalstatus = markreversalstatus;
        _createdby = createdby;
    }

    public int insert()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.insertJournalVoucerToMarkReversalHistory(this);   
    }
}