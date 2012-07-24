using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_Currencymaster
/// </summary>
public class FA_Currencymaster
{
    #region private variables
    string _currecyname;
    int _currencyid;
    #endregion

    #region Public Properties

    public string CurrencyName
    {
        get { return _currecyname; }
        set { _currecyname = value; }
    }
    public int CurrencyId
    {
        get { return _currencyid; }
        set { _currencyid = value; }
    }
    #endregion

    
    public BLLCollection<FA_Currencymaster> GetCurrencyList()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetCurrenyList();
    }

    public FA_Currencymaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}