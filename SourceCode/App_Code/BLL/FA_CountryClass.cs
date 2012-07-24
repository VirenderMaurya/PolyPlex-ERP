using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_CountryClass
/// </summary>
public class FA_CountryClass
{

    #region private field
    private int _countryid;
    private string _countryname;
    #endregion

    #region Public Properties
    public int CountryId
    {
        get { return _countryid; }
        set { _countryid = value; }
    }
    public string CountryName
    {
        get { return _countryname; }
        set { _countryname = value; }
    }
    #endregion


    public BLLCollection<FA_CountryClass> GetAllCountries()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetAllCountries();
    }
    
    
    public FA_CountryClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}