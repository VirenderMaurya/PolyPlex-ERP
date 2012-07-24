using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_ProfitCentermaster
/// </summary>
public class FA_ProfitCentermaster
{
    #region private variable
    string _profitcenername;
    int _profitcenterid;
    int _id;
    #endregion

    #region Public properties
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string ProfitCenterName
    {
        get { return _profitcenername; }
        set { _profitcenername = value; }
    }
    public int ProfitCenterId
    {
        get { return _profitcenterid; }
        set { _profitcenterid = value; }
    }
    #endregion

    public BLLCollection<FA_ProfitCentermaster> GetProfitCenter()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetProfitCenter();
    }

    public FA_ProfitCentermaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}