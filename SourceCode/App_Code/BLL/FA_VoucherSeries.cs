using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_VoucherSeries
/// </summary>
public class FA_VoucherSeries
{

    #region PrivateFiles
    private int _id;
    private string _voucherseries;
    #endregion

    #region Public Properties
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string VoucherSeries
    {
        get { return _voucherseries; }
        set {_voucherseries = value; }
    }
    #endregion

    public FA_VoucherSeries()
	{
		
	}
    public BLLCollection<FA_VoucherSeries> Get_VoucherSeries()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_VoucherSeries();
    }

}