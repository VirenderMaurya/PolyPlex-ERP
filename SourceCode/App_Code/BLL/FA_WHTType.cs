using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_WHTType
/// </summary>
public class FA_WHTType
{

    #region Private variables

    int _whtid;
    string _whtdescription;
    #endregion

    #region Public Properties
    public int WHTId
    {
        get { return _whtid; }
        set { _whtid = value; }
    }
    public string WHTDescription
    {
        get { return _whtdescription; }
        set { _whtdescription = value; }
    }

    #endregion

    public BLLCollection<FA_WHTType> GetWHTType()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetWHTType();
    }

    public FA_WHTType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}